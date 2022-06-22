using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class Note
    {
        [Display(Name = "변호")]
        public int Id { get; set; }

        [Display(Name = "작성자")]
        [Required(ErrorMessage = "* 이름을 입력해주세요.")]
        public string Name { get; set; }
        [Display(Name = "이메일")]
        [EmailAddress(ErrorMessage = "이메일을 정확히 입력해주세요")]
        public string Email { get; set; }

        [Display(Name = "제목")]
        [Required(ErrorMessage = "* 제목을 입력해주세요.")]
        public string Title { get; set; }

        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; }

        public string PostIP { get; set; }

        [Display(Name = "내용")]
        [Required(ErrorMessage = "* 내용을 작성해주세요")]
        public string Content { get; set; }

        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "* 비밀번호를 작성해주세요")]
        public string Password { get; set; }

        [Display(Name = "조회수")]
        public int ReadCount { get; set; }

        [Display(Name = "인코딩")]
        public string Encoding { get; set; }

        [Display(Name = "홈페이지")]
        public string Homepage { get; set; }

        [Display(Name = "수정일")]
        public DateTime ModifyDate { get; set; }

        [Display(Name = "수정 IP")]
        public string ModifyIP { get; set; }

        [Display(Name = "파일명")]
        public string FileName { get; set; }


        [Display(Name = "파일 사이즈")]
        public int FileSize { get; set; }


        [Display(Name = "다운로드 수")]
        public int DownCount { get; set; }

        public int Ref { get; set; }
        public int Step { get; set; }

        public int StepOrder { get; set; }
        public int AnswerNum { get; set; }
        public int ParentNum { get; set; }
        public int CommentCount { get; set; }
        public string Category { get; set; } = "Free";
    }
}