using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoEngine.Models
{
    internal interface INoteCommentRepository
    {
        void AddNoteComment(NoteComment model);
        List<NoteComment> GetNoteComments(int boardId);
        int GetCountBy(int boardId, int id, string password);
        int DeleteNoteComment(int boardId, int id, string password);
        List<NoteComment> GetRecentComment();
    }
}
