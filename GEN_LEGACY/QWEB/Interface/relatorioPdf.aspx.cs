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
    public partial class relatorioPdf : relatorios
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	    Response.Cache.SetExpires(DateTime.Now);

            ConfigurarCrystalReports(CrystalReportViewer1);
            //mostrar em pdf
            Stream oStream = null;
            byte[] byteArray = null;
            oStream = reportCrystal.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length));
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.End(); 
        }
    }

}
