using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.DotNetNote
{
    public partial class ImageDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Request.Params["FileName"];
            if (String.IsNullOrEmpty(fileName))
            {
                Response.End();
            }

            string ext = Path.GetExtension(fileName);
            string contentType = string.Empty;
            if(ext == ".gif" || ext ==".jpg" || ext == ".jpeg" || ext == ".png")
            {
                switch (ext)
                {
                    case ".gif":
                        contentType = "image/gif";
                        break;

                    case ".jpg":
                        contentType = "image/jpg";
                        break;

                    case ".jpeg":
                        contentType = "image/jpeg";
                        break;

                    case ".png":
                        contentType = "image/png";
                        break;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('이미지 파일이 아닙니다.')</script>");
                Response.End();
            }
            string file = Server.MapPath("./MyFiles/") + fileName;

            Response.Clear();
            Response.ContentType = contentType;
            Response.WriteFile(file);
            Response.End(); 
        }
    }
}