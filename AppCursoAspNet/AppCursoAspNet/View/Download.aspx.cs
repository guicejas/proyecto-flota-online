using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string file = Request.QueryString["file"];
                    hl_download_Click(file);
                }
                catch
                { }
            }
            else
            { }
        }

        public void hl_download_Click(string file)
        {
            Response.AddHeader("Content-Type", "application/octet-stream");
            Response.AddHeader("Content-Transfer-Encoding", "Binary");
            Response.AddHeader("Content-disposition", "attachment; filename=\"" + file + "\"");
            Response.WriteFile(@"C:\Program Files\IIS Express\" + file);
            Response.End();
        }
    }
}