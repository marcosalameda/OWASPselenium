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
using System.Data.OracleClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CSGenio
{
    public partial class relatorioCrystal : relatorios
    {
        /// <summary>
        /// Método to carregar a página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
			Response.Cache.SetExpires(DateTime.Now);

            ConfigurarCrystalReports(CrystalReportViewer1);
        }

    }
}
