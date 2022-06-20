using Notes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoEngine.Models
{
    internal interface INoteRepository
    {

        int SaveOrUpdate(Note note, BoardWriteFormType formType);
        void Add(Note note);
        int UpdateNote(Note note);
        List<Note> GetAll(int page);
        int GetCountBySearch(string searchField, string searchQuery);
        int GetCountAll();
        string GetFileNameById(int id);
        List<Note> GetSeachAll(int page, string searchField, string searchQuery);
        void UpdateDownCount(string fileName);
        void UpdateDownCountById(int id);
        Note GetNoteById(int id);
        int DeleteNote(int id, string password);
        List<Note> GetNewPhotos();

        List<Note> GetNoteSummaryByCategory(string category);
        List<Note> GetRecentPost();
        List<Note> GetRecentPosts(int nubmerOfNotes);
    }
}
