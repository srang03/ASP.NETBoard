using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class NoteComment
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        [Required(ErrorMessage = "이름을 입력하세요.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "댓글을 입력하세요.")]
        public string Opinion { get; set; }
        public DateTime PostDate { get; set; }
        [Required(ErrorMessage = "암호를 입력하세요.")]
        public string Password { get; set; }
    }
}