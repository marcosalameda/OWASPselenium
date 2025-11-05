using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.IO;
namespace CSGenio
{
    public partial class relatorioRtf : relatorios
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now);

            ConfigurarCrystalReports(CrystalReportViewer1);
            
            Stream oStream = null;
            byte[] byteArray = null;
            oStream = reportCrystal.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.EditableRTF);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length));
            Response.Clear();
            Response.Buffer = true;
            string[] filename=reportCrystal.ReportName.Split('.');
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename[0]+".rtf");

            Response.ContentType = "application/rtf";
            Response.BinaryWrite(byteArray);
            Response.End();
        }
    }

}
