using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class NoteCommentRepository : INoteCommentRepository
    {
        private SqlConnection _conn;
        public NoteCommentRepository()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
           
        }
        public void AddNoteComment(NoteComment model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BOARDID", value : model.BoardId, dbType: System.Data.DbType.Int32);
            parameters.Add("@NAME", value : model.Name, dbType: System.Data.DbType.String);
            parameters.Add("@BOARDOPINION", value : model.Opinion, dbType: System.Data.DbType.String);
            parameters.Add("@PASSWORD", value : model.Password, dbType: System.Data.DbType.String);

            string sql = @"INSERT INTO dbo.NoteComments 
                         (BOARDID, NAME, BOARDOPINION, PASSWORD)
                         VALUES(@BOARDID, @NAME, @BOARDOPINION, @PASSWORD;
                         UPDATE dbo.Notes SET COMMENTCOUNT = COMMENTCOUNT + 1 WHERE ID = @BARDID;";
            _conn.Execute(sql, parameters, commandType: System.Data.CommandType.Text);



        }

        public int DeleteNoteComment(int boardId, int id, string password)
        {   
            var parameter = new DynamicParameters();
            parameter.Add("@BOARDID", boardId, System.Data.DbType.Int32);
            parameter.Add("@ID", id, System.Data.DbType.Int32);
            parameter.Add("@PASSWORD", password, System.Data.DbType.String);

            string query = @"DELETE FROM dbo.NoteComments WHERE BOARDID = @BOARDID AND ID = @ID AND PASSWORD = @PASSWORD;
                               UPDATE dbo.Notes SET COMMENTCOUNT = COMMENTCOUNT - 1 WHERE ID = @BOARDID;";
            return _conn.Query<int>(query, parameter, commandType: System.Data.CommandType.Text).SingleOrDefault();
        }

        public int GetCountBy(int boardId, int id, string password)
        {
            return _conn.Query<int>(@"SELECT COUNT(*) FROM dbo.NoteComments 
                                    WHERE BOARDID = @BOARDID AND ID = @ID AND PASSWORD = @PASSWORD;"
                                    , new { BOARDID = boardId, ID = id, PASSWORD = password }
                                    , commandType: System.Data.CommandType.Text).SingleOrDefault();
        }

        public List<NoteComment> GetNoteComments(int boardId)
        {
            try
            {
                return _conn.Query<NoteComment>("SELECT * FROM dbo.NoteComments WHERE BOARDID = @BOARDID",
                    new { BOARDID = boardId },
                    commandType: System.Data.CommandType.Text).ToList();
            }
            catch(Exception ex)
            {
                new Exception(ex.Message);
                return null;
            }
        }

        public List<NoteComment> GetRecentComment()
        {
            string query = "SELECT TOP 3 ID, BOARDID, OPINION, POSTDATE FROM dbo.NoteComments ORDER BY ID DESC";
            return _conn.Query<NoteComment>(query, commandType: System.Data.CommandType.Text).ToList();
        }
    }
}