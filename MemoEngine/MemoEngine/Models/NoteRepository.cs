using Dapper;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class NoteRepository : INoteRepository
    {
        private SqlConnection _conn;

        public NoteRepository()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public void Add(Note note)
        {
            try
            {
                SaveOrUpdate(note, BoardWriteFormType.Write);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteNote(int id, string password)
        {
            return _conn.Execute("dbo.DeleteNote", new { Id = id, Password = password }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public List<Note> GetAll(int page)
        {
            try
            {
                string proc = "dbo.ListNotes";
                var parameter = new DynamicParameters();
                parameter.Add("@PAGE", page);

                return _conn.Query<Note>(proc, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public int GetCountAll()
        {
            try
            {
                var proc = "dbo.GetCountNotes";
                return _conn.Query<int>(proc, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch
            {
                return -1;
            }
        }

        public int GetCountBySearch(string searchField, string searchValue)
        {
            try
            {
                var proc = "dbo.SearchNoteCount";
                var parameter = new DynamicParameters();
                parameter.Add("@SearchField", searchField);
                parameter.Add("@SearchValue", searchField);

                return _conn.Query<int>(proc, parameter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();

            }
            catch (Exception ex)
            { 
                throw new System.Exception(ex.Message);
            }
        }

        public string GetFileNameById(int id)
        {
            var proc = "dbo.SelectFileName";
            var parameter = new DynamicParameters();
            parameter.Add("@ID", id);

            return _conn.Query<string>(proc, parameter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
        }

        public List<Note> GetNewPhotos()
        {
            var query = @"SELECT TOP 4 ID, TITLE, FILENAME, FILESIZE FROM dbo.Notes
                        WHERE 
                        FILENAME LIKE '%.png' OR 
                        FILENAME LIKE '%.jpg' OR 
                        FILENAME LIKE '%.jpeg' OR
                        FILENAME LIKE '%.gif'
                        ORDER BY ID DESC;
                    ";
            return _conn.Query<Note>(query).ToList();
        }

        public Note GetNoteById(int id)
        {
        
                var proc = "dbo. ViewNote";
                var parameter = new DynamicParameters();
                parameter.Add("@ID", id);
                return _conn.Query<Note>(proc, parameter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
        }

        public List<Note> GetNoteSummaryByCategory(string category)
        {
            string query = "SELECT TOP3 ID, TITLE, NAME, POSTDATE, FILENAME, FILESIZE, READCOUNT, COMMENTCOUNT, STEP"
                           + "FROM dbo.Notes"
                           + $"WHERE CATEGORY = {category} ORDER BY ID DESC";
            return _conn.Query<Note>(query).ToList();
        }

        public List<Note> GetRecentPost()
        {
            string query = "SELECT TOP 3 ID, TITLE, NAME, POSTDATE FROM dbo.Memos ORDER BY ID DESC";
            return _conn.Query<Note>(query).ToList();
        }

        public List<Note> GetRecentPosts(int nubmerOfNotes)
        {
            string query = $"SELECT TOP {nubmerOfNotes} ID, TITLE, NAME, POSTDATE FROM dbo.Notes ORDER BY ID DESC";
            return _conn.Query<Note>(query).ToList();
        }

        public List<Note> GetSeachAll(int page, string searchField, string searchQuery)
        {
            var proc = "dbo.SearchNotes";
            var parameter = new DynamicParameters();
            parameter.Add("@Page", page);
            parameter.Add("@SearchField", searchField);
            parameter.Add("@SearchQuery", searchQuery);

            return _conn.Query<Note>(proc, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public int SaveOrUpdate(Note note, BoardWriteFormType formType)
        {
            int r = 0;

            var parameter = new DynamicParameters();
            parameter.Add("@NAME", value: note.Name, dbType: System.Data.DbType.String);
            parameter.Add("@EMAIL", value: note.Email, dbType: System.Data.DbType.String);
            parameter.Add("@TITLE", value: note.Title, dbType: System.Data.DbType.String);
          
            parameter.Add("@CONTENT", value: note.Content, dbType: System.Data.DbType.String);
            parameter.Add("@PASSWORD", value: note.Password, dbType: System.Data.DbType.String);
            parameter.Add("@ENCODING", value: note.Encoding, dbType: System.Data.DbType.String);
            parameter.Add("@HOMEPAGE", value: note.Homepage, dbType: System.Data.DbType.String);
            parameter.Add("@FILENAME", value: note.FileName, dbType: System.Data.DbType.String);
            parameter.Add("@FILESIZE", value: note.FileSize, dbType: System.Data.DbType.Int32);

            switch (formType)
            {
                case BoardWriteFormType.Write:
                    parameter.Add("@POSTIP", value: note.PostIP, dbType: System.Data.DbType.String);

                    r = _conn.Execute("dbo.WriteNote", parameter, commandType: System.Data.CommandType.StoredProcedure);
                    
                    break;

                case BoardWriteFormType.Modify:
                    parameter.Add("@ID", value: note.Id, dbType: System.Data.DbType.Int32);
                    parameter.Add("@MODIFYIP", value: note.ModifyIP, dbType: System.Data.DbType.String);

                    r = _conn.Execute("dbo.ModifyNote", parameter, commandType: System.Data.CommandType.StoredProcedure);
                    
                    break;

                case BoardWriteFormType.Reply:
                    parameter.Add("@POSTIP", value: note.PostIP, dbType: System.Data.DbType.String);
                    parameter.Add("@PARENTNUM", value: note.ParentNum, dbType: System.Data.DbType.Int32);

                    r = _conn.Execute("dbo.RelplyNote", parameter, commandType: System.Data.CommandType.StoredProcedure);
                    break;
            }
            return r;
        }

        public void UpdateDownCount(string fileName)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@FILENAME", fileName);
            var query = "UPDATE dbo.Notes SET DOWNCOUNT = DOWNCOUNT+1 "
                            + "WHERE FILENAME = @FILENAME";
            _conn.Execute(query, parameter);
        }

        public void UpdateDownCountById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ID", id);
            var query = "UPDATE dbo.Notes SET DOWNCOUNT = DOWNCOUNT+1 "
                            + "WHERE ID = @ID";
            _conn.Execute(query, parameter);
        }

        public int UpdateNote(Note note)
        {
            int r = 0;
            try
            {
                r = SaveOrUpdate(note, BoardWriteFormType.Modify);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return r;
        }
    }
}