using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine
{
    public partial class FrmStringLibraryTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string res = this.txb_input.Text.Trim();
            this.lbl_result.Text = Dul.StringLibrary.CutStringUniCode(res, 6);
        }

        protected void btn_size_Click(object sender, EventArgs e)
        {
            string res = this.txb_size.Text.Trim();

            if(int.TryParse(res, out int size))
            {
                this.lbl_sizeResult.Text = Dul.BoardLibrary.ConvertToFileZise(size);
            };
            
        }
    }
}