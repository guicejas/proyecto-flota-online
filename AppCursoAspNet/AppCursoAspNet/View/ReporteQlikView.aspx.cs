using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class ReporteQlikView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void hl_download_Click(Object sender, EventArgs e)
        {
            Response.AddHeader("Content-Type", "application/octet-stream");
            Response.AddHeader("Content-Transfer-Encoding", "Binary");
            Response.AddHeader("Content-disposition", "attachment; filename=\"IndicadoresQV.qvw\"");
            Response.WriteFile(HttpRuntime.AppDomainAppPath + @"Docs\IndicadoresQV.qvw");
            Response.End();
        }
    }
}