//TSX (09/04/2019) ESTE FICHEIRO ESTÁ AQUI SÓ PARA HISTÓRICO, PODERÁ SER REMOVIDO PASSADO ALGUM TEMPO

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using CSGenio.framework;
using CSGenio.reporting;
using GenioMVC.Models.Navigation;
using Microsoft.Reporting.WebForms;
using CSGenio.business;

namespace GenioMVC.Helpers
{
    /// <summary>
    /// Reporting Services render result
    /// </summary>
    public class SSRS_Render_Result
    {
        public string MimeType;
        public string Encoding;
        public string FileNameExtension;
        public string[] Streams;
        public Warning[] Warnings;
        public byte[] File;

        public SSRS_Render_Result() { }
    }

    /// <summary>
    /// Assists in executing and rendering Reporting Service reports.
	///
	/// Source code from: http://www.danielroot.info/2009/06/how-to-render-reporting-services.html
    /// </summary>
    public class SSRS_Render : IDisposable
    {
        #region Private fields
        private bool isServerReport;
        private string fullReportPath;
        private string downloadFileName;
        private LocalReport localReportInstance;
        private ServerReport serverReportInstance;
        private MemoryStream reportMemoryStream;
        private string reportMimeType;
        /// <summary>
        /// Limitations of the Report
        /// </summary>
        private List<ReportLimitParameter> limitations;
        #endregion
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SSRS_Render"/> class.
        /// </summary>
        /// <param name="reportPath">The report path.</param>
        /// <param name="downloadFileName">Name of the download file.</param>
        public SSRS_Render(string reportPath, string downloadFileName, bool isServerReport = true)
        {
            this.downloadFileName = downloadFileName;
            this.isServerReport = isServerReport;
            if (!this.isServerReport)
            {
                fullReportPath = HttpContext.Current.Server.MapPath(reportPath);
                using (System.IO.FileStream reportFile = new System.IO.FileStream(fullReportPath, System.IO.FileMode.Open, FileAccess.Read))
                {
                    localReportInstance = new LocalReport();
                    localReportInstance.DisplayName = this.downloadFileName;
                    localReportInstance.LoadReportDefinition(reportFile);
                }
            }
            else
            {
                serverReportInstance = new ServerReport();
                serverReportInstance.DisplayName = this.downloadFileName;
                serverReportInstance.ReportServerUrl = new Uri(Configuration.SSRSServer.url);
                serverReportInstance.ReportPath = reportPath;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the local report instance.
        /// </summary>
        /// <value>The report instance.</value>
        public LocalReport LocalReportInstance
        {
            get
            {
                return localReportInstance;
            }
        }
        /// <summary>
        /// Gets the server report instance.
        /// </summary>
        /// <value>The report instance.</value>
        public ServerReport ServerReportInstance
        {
            get
            {
                return serverReportInstance;
            }
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Render the SSRS report
        /// </summary>
        /// <param name="exportType">PDF | EXCEL | WORD | EXCELOPENXML | ...</param>
        /// <returns></returns>
        public SSRS_Render_Result Render(string exportType)
        {
            var result = new SSRS_Render_Result();
            if (!this.isServerReport)
                result.File = localReportInstance.Render(exportType, null, out result.MimeType, out result.Encoding, out result.FileNameExtension, out result.Streams, out result.Warnings);
            else
                result.File = serverReportInstance.Render(exportType, null, out result.MimeType, out result.Encoding, out result.FileNameExtension, out result.Streams, out result.Warnings);
            return result;
        }

        public void ConstructReport(string areaBase, string[] historicFieldNames, string[] historicFieldValues, NavigationContext Navigation, string limitSelectionField = "", string[] limitSelectionValues = null, string[] specialFormulasFields = null)
        {
            List<ReportParameterInfo> loadedReportParams = this.ServerReportInstance.GetParameters().ToList();
            List<ReportParameter> lstParameters = new List<ReportParameter>();

            if (limitSelectionField != "" && limitSelectionValues != null && limitSelectionValues.Length == 2)
            {
                List<string> tmpLst = new List<string>();
                tmpLst.Add(limitSelectionField + "MIN");
                tmpLst.Add(limitSelectionField + "MAX");

                List<string> tmlHF = historicFieldNames.ToList();
                tmlHF.AddRange(tmpLst);
                historicFieldNames = tmlHF.ToArray();

                tmlHF = historicFieldValues.ToList();
                tmlHF.AddRange(limitSelectionValues.ToList());
                historicFieldValues = tmlHF.ToArray();
            }

            // Preencher limites entre Qvalues e seleção em arvore
            var limitParam = PreencherLimites(loadedReportParams);
            if (limitParam != null && limitParam.Any())
                lstParameters.AddRange(limitParam);

            for (int i = 0; i < historicFieldNames.Length; i++)
            {
                bool areaField = !historicFieldNames[i].Contains(".");
                string field = historicFieldNames[i];
                string pValue = historicFieldValues[i];

                object value = Navigation.GetValue(field);
				if (value != null)
				{
					historicFieldValues[i] = Convert.ToString(value);
					pValue = Convert.ToString(value);
				}

                field = (areaField ? "cod" : "") + field;

                if (!areaField)
                    field = field.Replace(".", "_");

                if (loadedReportParams.Where(x => x.Name.ToLower() == field.ToLower() ||
                    (!areaField && x.Name.ToLower() == field.ToLower().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[1])).Count() == 1)
                {
                    if (areaField)
                        lstParameters.Add(new ReportParameter(loadedReportParams.Where(x => x.Name.ToLower() == field.ToLower()).First().Name, pValue));
                    else
                        lstParameters.Add(
                            new ReportParameter(
                                loadedReportParams.Where(x =>
                                    x.Name.ToLower() == field.ToLower() ||
                                    x.Name.ToLower() == field.ToLower().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[1]
                                ).First().Name, pValue));
                }

            }

            // Preencher as formulas especiais
            lstParameters.AddRange(GetFormulasEspeciaisParameters(loadedReportParams, specialFormulasFields));

            //Obter e adicionar as EPHs à lista de parâmetros
            lstParameters.AddRange(
                GetEphParameters(areaBase, UserContext.Current.User)
                .Where(x => loadedReportParams.FindIndex(y => y.Name == x.Name) != -1)
            );

            this.ServerReportInstance.SetParameters(lstParameters);
        }

        public void SetReportLimits(List<ReportLimitParameter> limits)
        {
            this.limitations = limits;
        }
        #endregion
        
		#region Private Methods

        /// <summary>
        /// Devolve a lista de report parameters das EPHs
        /// </summary>
        /// <param name="area">area base do report</param>
        /// <param name="utilizador">user a executar o relatório</param>
        /// <returns></returns>
        private IEnumerable<ReportParameter> GetEphParameters(string area, User user)
        {
            List<ReportParameter> result = new List<ReportParameter>();

            //obter as ephs ligadas ao user
            var areaBase = CSGenio.business.Area.createArea(area, user, user.CurrentModule);
            List<EPHOfArea> ephsDaArea = areaBase.CalculateAreaEphs(user.Ephs, null, false);

            //to cada uma delas, criar um parâmetro de report
            foreach (EPHOfArea v in ephsDaArea)
            {
                //criar o name do parametro
                var paramKey = string.Join("_", new string[] { v.Eph.Name, v.Eph.Table, v.Eph.Field });    //nomeEph_tabela_campo

                //se já existir uma entrada com o mesmo name, estamos perante uma eph multivalue
                //Nesse caso, adicionamos os Qvalues ao já existente
                int idx = result.FindIndex(x => x.Name == paramKey);
                
                if (idx != -1)
                    result[idx].Values.AddRange(v.ValuesList);
                else
                    result.Add(new ReportParameter(paramKey, v.ValuesList));
            }
            return result;
        }

		/// <summary>
        /// Creates a memory stream that can be used by the report when rendering to an email attachment.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="willSeek">if set to <c>true</c> [will seek].</param>
        /// <returns></returns>
        private Stream CreateMemoryStream(string name, string extension, System.Text.Encoding encoding, string mimeType, bool willSeek)
        {
            reportMemoryStream = new MemoryStream();
            reportMimeType = mimeType;
            return reportMemoryStream;
        }

        /// <summary>
        /// Método to preencher as formulas especiais
        /// </summary>
        /// <param name="loadedReportParams">Parametros do report</param>
        /// <param name="specialFormulasFields">Formulas especiais</param>
        /// <returns></returns>
        private IEnumerable<ReportParameter> GetFormulasEspeciaisParameters(List<ReportParameterInfo> loadedReportParams, string[] specialFormulasFields)
        {
            var result = new List<ReportParameter>();
            // The Database needs be always passed into reports.
            if(loadedReportParams.Any(prm => prm.Name == "Database")) {
                var connetion = new Configuration(UserContext.Current.User.Year);
                result.Add(new ReportParameter("Database", connetion.Database));
            }

            if(loadedReportParams != null && specialFormulasFields != null)
            {
                foreach(var formulaEspecial in specialFormulasFields)
                {
                    var sFormula = "f_" + formulaEspecial; // Os nomes dos parametros das formulas devem começar com "f_"
                    if (loadedReportParams.Any(prm => prm.Name == sFormula)) // Validate se o report utiliza o parametro
                    {
                        switch (formulaEspecial)
                        {
                            case "ano":
                                result.Add(new ReportParameter(sFormula, UserContext.Current.User.Year));
                                break;
                            case "sigla":
                                result.Add(new ReportParameter(sFormula, "\"" + Configuration.Acronym + "\""));
                                break;
                            case "user":
                                result.Add(new ReportParameter(sFormula, "\"" + UserContext.Current.User.Name + "\""));
                                break;
                            case "moeda":
                                result.Add(new ReportParameter(sFormula, "\"" + Configuration.Currency + "\""));
                                break;
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.localReportInstance != null) this.localReportInstance.Dispose();
            if (this.reportMemoryStream != null) this.reportMemoryStream.Dispose();
        }

        /// <summary>
        /// Método to preencher as limitações
        /// </summary>
        private List<ReportParameter> PreencherLimites(List<ReportParameterInfo> reportParams)
        {
            if (this.limitations == null)
                return null;
            var output = new List<ReportParameter>();
            foreach (var genLimit in this.limitations)
            {
                switch (genLimit.Source)
                {
                    case ReportLimitParameter.LimitSource.SE:
                        {
                            var limit = genLimit as ReportLimitParameter_SE;
                            switch (limit.FieldType)
                            {
                                case "D":
                                    SetDateLimit(limit.FullFieldName + "MIN", limit.MinFieldValue, reportParams, ref output);
                                    SetDateLimit(limit.FullFieldName + "MAX", limit.MaxFieldValue, reportParams, ref output);
                                    break;
                                default:
                                    SetLimitValue(limit.FullFieldName + "MIN", Convert.ToString(limit.MinFieldValue), reportParams, ref output);
                                    SetLimitValue(limit.FullFieldName + "MAX", Convert.ToString(limit.MaxFieldValue), reportParams, ref output);
                                    break;
                            }
                        }
                        break;
                    case ReportLimitParameter.LimitSource.SU:
                        {
                            var limit = genLimit as ReportLimitParameter_SU;
                            switch (limit.FieldType)
                            {
                                case "D":
                                    SetDateLimit(limit.FullFieldName, limit.FieldValue, reportParams, ref output);
                                    break;
                                default:
                                    SetLimitValue(limit.FullFieldName, Convert.ToString(limit.FieldValue), reportParams, ref output);
                                    break;
                            }
                        }
                        break;
                    case ReportLimitParameter.LimitSource.DB:
                        {
                            // DBEdit com limitação em arvore
                            var limit = genLimit as ReportLimitParameter_DB;
                            if (string.IsNullOrEmpty(limit.FieldValue))
                                throw new BusinessException(null, "ReportSSRS.PreencherLimites", "Null or Empty tree seelction limit value");
                            SetLimitValue(limit.FullFieldName, Convert.ToString(limit.FieldValue), reportParams, ref output);
                        }
                        break;
                }
            }
            return output;
        }

        #region Metodos auxiliares do PreencherLimites
        private void SetLimitValue(string FieldName, string FieldValue, List<ReportParameterInfo> reportParams, ref List<ReportParameter> output)
        {
            if (string.IsNullOrEmpty(FieldName) || string.IsNullOrEmpty(FieldValue))
                throw new BusinessException(null, "SSRS_Render.SetLimitValue", "Null or Empty argument value");
            var finalFullFieldName = FieldName.Replace('.', '_');
            if (reportParams.Any(x => x.Name == finalFullFieldName))
            {
                output.Add(new ReportParameter(finalFullFieldName, FieldValue));
            }
        }

        private void SetDateLimit(string FieldName, object FieldValue, List<ReportParameterInfo> reportParams, ref List<ReportParameter> output)
        {
            if (string.IsNullOrEmpty(FieldName) || FieldValue == null)
                throw new BusinessException(null, "SSRS_Render.SetDateLimit", "Null or Empty argument value");
            if (FieldValue is string)
            {
                DateTime tempDate;
                if (!DateTime.TryParse(FieldValue as string, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out tempDate))
                    throw new BusinessException(null, "SSRS_Render.SetDateLimit", "Error parsing date limit: " + Convert.ToString(FieldValue));
                FieldValue = tempDate;
            }
            string dateValue = (FieldValue as DateTime?).GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss");
            SetLimitValue(FieldName, dateValue, reportParams, ref output);
        }
        #endregion

        #endregion
    }
}