using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.ComponentModel;

using System.Text;
using System.Collections.Generic;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.reporting;
using System.Data.OracleClient;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace CSGenio
{
    public partial class relatorioSSRS : relatorios
    {
        /// <summary>
        /// M�todo to carregar a p�gina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            //MF - o controlo report viewer faz 1 second post to a p�gina,
            //ap�s a renderiza��o do conte�do.
            if(IsPostBack)
                return;
			Response.Cache.SetExpires(DateTime.Now);
			
			ReportViewer.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            //Configurar o controlo
            ConfigurarSSRSReports(ReportViewer);

            /*************************************/
            //MF
            //adicionar tag manual aqui to o povo poder modificar propriedades do controlo caso necessitem
            /*************************************/
            

            ReportViewer.DataBind();
        }

    }
}
