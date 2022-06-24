using Dul;
using MemoEngine.Models;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.DotNetNote.Controls
{
    public partial class BoardEditorFormControl : System.Web.UI.Page
    {
        private string _id;
        public BoardWriteFormType FormType { get; set; }


        private string _baseDir = string.Empty; // 파일 업로드 폴더
        private string _fileName = string.Empty; // 파일 이름
        private int _fileSize = 0; // 파일 크기 저장

        protected void Page_Load(object sender, EventArgs e)
        {
            _id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        lbl_notice.Text = "글쓰기 - 다음 필드를 채워주세요.";
                        break;
                    case BoardWriteFormType.Modify:
                        lbl_notice.Text = "글수정 - 아래 항목을 수정하세요.";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        lbl_notice.Text = "글 답변 - 답변을 달아주세요.";
                        DisplayDataForReply();
                        break;
                }
            }

        }

        private void DisplayDataForReply()
        {
            INoteRepository _repository = new NoteRepository();
            if (int.TryParse(_id, out int id))
            {
                var note = _repository.GetNoteById(id);

                this.txb_title.Text = $"RE: {note.Title}";
                this.txb_content.Text = $"\n\nOn {note.PostDate}, '{note.Name}' wrote:\n------------------\n>"
                    + $"{note.Content.Replace("\n", "\n")}\n----------";

            }
        }
        private void DisplayDataForModify()
        {
            INoteRepository _repository = new NoteRepository();
            if(int.TryParse(_id, out int id))
            {
                var note = _repository.GetNoteById(id);

                this.txb_name.Text = note.Name;
                this.txb_title.Text = note.Title;
                this.txb_content.Text = note.Content;
                this.txb_homepage.Text = note.Homepage;
                this.txb_email.Text = note.Email;

                string strEncoding = note.Encoding;
                switch (strEncoding)
                {
                    case "Text":
                        rbl_encoding.SelectedIndex = 0;
                        break;
                    case "Mixed":
                        rbl_encoding.SelectedIndex = 2;
                        break;
                    case "HTML":
                        rbl_encoding.SelectedIndex = 1;

                        break;
                    default:
                        break;
                }

                if(note.FileName.Length > 1)
                {
                    ViewState["FileName"] = note.FileName;
                    ViewState["FileSize"] = note.FileSize;

                    this.pnl_file.Height = 50;
                    this.pnl_file.Visible = true;
                    this.lbl_fileName.Visible = true;
                    this.lbl_fileName.Text = note.FileName;
                }
                else
                {
                    ViewState["FileName"] = "";
                    ViewState["FileSize"] = 0;
                }
            }
         
        }

        protected void cbx_fileAttach_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbx_fileAttach.Checked)
            {
                this.pnl_file.Visible = true;
                lbl_fileName.Visible = true;
            }
            else
            {
                this.pnl_file.Visible = false;
                lbl_fileName.Visible = true;
            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                if(int.TryParse(_id, out int id))
                {
                    UploadProcess();


                    Note note = new Note();
                    note.Id = id;

                    note.Name = this.txb_name.Text;
                    note.Email = this.txb_email.Text;
                    note.Homepage = this.txb_homepage.Text;
                    note.Title = this.txb_title.Text;
                    note.Content = this.txb_content.Text;
                    note.FileName = _fileName;
                    note.FileSize = _fileSize;
                    note.Password = this.txb_password.Text;
                    note.PostIP = Request.UserHostAddress;
                    note.Encoding = this.rbl_encoding.SelectedValue;

                    INoteRepository _repository = new NoteRepository();
                    switch (FormType)
                    {
                        case BoardWriteFormType.Write:
                            _repository.Add(note);
                            Response.Redirect("BoardList.aspx");
                            break;
                        case BoardWriteFormType.Modify:
                            note.ModifyIP = Request.UserHostAddress;
                            note.FileName = ViewState["FileName"].ToString();
                            note.FileSize = Convert.ToInt32(ViewState["FileSize"]);
                            int r = _repository.UpdateNote(note);

                            if(r > 0)
                            {
                                Response.Redirect($"BoardView.aspx?id={_id}");
                            }
                            else
                            {
                                this.lbl_error.Text = "업데이트가 정상적으로 되지 않았습니다.";
                            }
                            break;

                        default:
                            _repository.Add(note);
                            Response.Redirect("BoardList.aspx");
                            break;
                    }
                    
                }
            }
            else
            {
                this.lbl_error.Text = "보안코드를 다시 입력해주세요.";
            }
        }

        private void UploadProcess()
        {
            _baseDir = Server.MapPath("./MyFiles");
            _fileName = String.Empty;
            _fileSize = 0;

            if(this.ful_file.PostedFile.FileName.Trim().Length > 0 &&
                this.ful_file.PostedFile.ContentLength > 0)
            {
                if(FormType == BoardWriteFormType.Modify)
                {
                    ViewState["FileName"] = FileUtility.GetFileNameWithNumbering(_baseDir, Path.GetFileName(this.ful_file.PostedFile.FileName));
                    ViewState["FileSize"] = this.ful_file.PostedFile.ContentLength;

                    this.ful_file.PostedFile.SaveAs(Path.Combine(_baseDir, ViewState["FileName"].ToString()));
                }
                else
                {
                    _fileName = FileUtility.GetFileNameWithNumbering(_baseDir, Path.GetFileName(this.ful_file.PostedFile.FileName));
                    _fileSize = this.ful_file.PostedFile.ContentLength;

                    this.ful_file.PostedFile.SaveAs(Path.Combine(_baseDir, _fileName));
                }
            }
        }

        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (this.txb_code.Text == Session["ImageText"].ToString());
                }
            }
            return false;
        }
    }
}