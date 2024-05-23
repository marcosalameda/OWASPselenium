using Microsoft.Reporting.WebForms;
using CSGenio.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace GenioMVC
{
    /// <summary>
    /// The Web Form used for rendering a ReportViewer control.
    /// </summary>
    public partial class ReportViewerWebForm : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //MF - o controlo report viewer faz 1 second post para a página, após a renderização do conteúdo.
            if (IsPostBack)
                return;

            Response.Cache.SetExpires(DateTime.Now);

            //save the control Id
            string controlId = ReportViewer1.ID;
            string reportId = Request.QueryString["id"];
            if (reportId == null)
                return;

            var report = ReportViewerHelperExtensions.PopReport(reportId);
            if (report == null)
                return;

            //When the reportviewer control is replaced it does not work correctily
            //So unfortunately we have to copy all the properties of the configured report into the Ui control.
            SetViewerProperties(ReportViewer1, report);

            //restore the control Id after the copy
            ReportViewer1.ID = controlId;
        }


        /// <summary>
        /// Copy the properties of the specified ReportViewer to the ReportViewer.
        /// </summary>
        /// <param name="reportViewer">The ReportViewer that this method extends.</param>
        /// <param name="properties">The ReportViewer whose properties should be copied to the ReportViewer.</param>
        private static void SetViewerProperties(ReportViewer reportViewer, ReportViewer properties)
        {
            if (reportViewer == null)
            {
                throw new ArgumentNullException("reportViewer", "Value cannot be null.");
            }

            Copy<ReportViewer>(ref reportViewer, properties);

            SetProperties(reportViewer.LocalReport, properties.LocalReport);
            SetProperties(reportViewer.ServerReport, properties.ServerReport);
        }

        /// <summary>
        /// Copy the properties of the specified LocalReport to the LocalReport.
        /// </summary>
        /// <param name="localReport">The LocalReport that this method extends.</param>
        /// <param name="properties">The LocalReport whose properties should be copied to the LocalReport.</param>
        private static void SetProperties(LocalReport localReport, LocalReport properties)
        {
            if (localReport == null)
            {
                throw new ArgumentNullException("localReport", "Value cannot be null.");
            }

            Copy<LocalReport>(ref localReport, properties);

            CopyDataSources(localReport.DataSources, properties.DataSources.ToList());

            try
            {
                SetParameters(localReport, properties.GetParameters());
            }
            catch (MissingReportSourceException) { } //Do nothing
        }

        /// <summary>
        /// Copy the properties of the specified ServerReport to the ServerReport.
        /// </summary>
        /// <param name="serverReport">The ServerReport that this method extends.</param>
        /// <param name="properties">The ServerReport whose properties should be copied to the ServerReport.</param>
        private static void SetProperties(ServerReport serverReport, ServerReport properties)
        {
            if (serverReport == null)
            {
                throw new ArgumentNullException("serverReport", "Value cannot be null.");
            }

            Copy<ServerReport>(ref serverReport, properties);

            try
            {
                SetParameters(serverReport, properties.GetParameters());
            }
            catch (MissingReportSourceException) { } //Do nothing
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the ReportDataSourceCollection.
        /// </summary>
        /// <param name="reportDataSourceCollection">The ReportDataSourceCollection that this method extends.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the ReportDataSourceCollection.</param>
        private static void CopyDataSources(ReportDataSourceCollection reportDataSourceCollection, IEnumerable<ReportDataSource> collection)
        {
            if (reportDataSourceCollection == null)
            {
                throw new ArgumentNullException("reportDataSourceCollection", "Value cannot be null.");
            }
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Value cannot be null.");
            }

            foreach (ReportDataSource reportDataSource in collection)
            {
                reportDataSourceCollection.Add(reportDataSource);
            }
        }



        /// <summary>
        /// Set the ReportParameters of the specified ReportParameterInfoCollection.
        /// </summary>
        /// <param name="report">The Report that this method extends.</param>
        /// <param name="collection">The collection whose ReportParameters should be added to the Report.</param>
        private static void SetParameters(Report report, ReportParameterInfoCollection collection)
        {
            if (report == null)
            {
                throw new ArgumentNullException("report", "Value cannot be null.");
            }
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Value cannot be null.");
            }

            foreach (ReportParameterInfo reportParameterInfo in collection)
            {
                SetParameters(report, reportParameterInfo);
            }
        }

        /// <summary>
        /// Set the ReportParameter of the specified ReportParameterInfo.
        /// </summary>
        /// <param name="report">The Report that this method extends.</param>
        /// <param name="reportParameterInfo">The ReportParameterInfor whose parameter should be added to the Report.</param>
        private static void SetParameters(Report report, ReportParameterInfo reportParameterInfo)
        {
            if (report == null)
            {
                throw new ArgumentNullException("report", "Value cannot be null.");
            }

            if (reportParameterInfo == null)
            {
                throw new ArgumentNullException("reportParameterInfo", "Value cannot be null.");
            }

            ReportParameter reportParameter = new ReportParameter(
                    reportParameterInfo.Name,
                    reportParameterInfo.Values.ToArray(),
                    reportParameterInfo.Visible);

            report.SetParameters(reportParameter);
        }


        private static void Copy<T>(ref T obj, T properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties", "Value cannot be null.");
            }

            Copy<T, T>(ref obj, properties);
        }

        private static void Copy<T1, T2>(ref T1 obj, T2 properties)
        {
            Type objType = obj.GetType();
            Type propertiesType = properties.GetType();
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            foreach (PropertyInfo propertyInfo in propertiesType.GetProperties(bindingFlags))
            {
                try
                {
                    if (propertyInfo.CanRead)
                    {
                        var valueToCopy = propertyInfo.GetValue(properties, null);
                        var objProperty = objType.GetProperty(propertyInfo.Name);

                        if (objProperty.CanWrite)
                        {
                            objProperty.SetValue(obj, valueToCopy, null);
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (TargetInvocationException) { } //Do nothing, just like my boss.
            }
        }
    }
}