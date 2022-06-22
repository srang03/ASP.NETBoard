using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.DotNetNote
{
    public partial class BoardDown : System.Web.UI.Page
    {
        private string _fileName = "";
        private string _dir = "";

        private INoteRepository _repository;

        public BoardDown()
        {
            _repository = new NoteRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.TryParse(Request["id"], out int id))
            {
                _fileName =
                _repository.GetFileNameById(id);

                _dir = Server.MapPath("./MyFiles/");
                if(_fileName == null)
                {
                    Response.Clear();
                    Response.End();
                }
                else
                {
                    _repository.UpdateDownCount(_fileName);
                }

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename="
                        + Server.UrlPathEncode((_fileName.Length > 50) ? _fileName.Substring(_fileName.Length - 50, 50) : _fileName));
                Response.WriteFile(_dir + _fileName);
                Response.End();
            }
            
        }
    }
}