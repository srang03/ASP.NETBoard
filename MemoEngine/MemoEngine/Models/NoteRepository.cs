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
            return _conn.Execute("dbo.DeleteNote", new {Id= id, Password = password }, commandType: System.Data.CommandType.Stor )
        }

        public List<Note> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public int GetCountAll()
        {
            throw new NotImplementedException();
        }

        public int GetCountBySearch(string searchField, string searchQuery)
        {
            throw new NotImplementedException();
        }

        public string GetFileNameById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetNewPhotos()
        {
            throw new NotImplementedException();
        }

        public Note GetNoteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetNoteSummaryByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetRecentPost()
        {
            throw new NotImplementedException();
        }

        public List<Note> GetRecentPosts(int nubmerOfNotes)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetSeachAll(int page, string searchField, string searchQuery)
        {
            throw new NotImplementedException();
        }

        public int SaveOrUpdate(Note note, BoardWriteFormType formType)
        {
            throw new NotImplementedException();
        }

        public void UpdateDownCount(string fileName)
        {
            throw new NotImplementedException();
        }

        public void UpdateDownCountById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}