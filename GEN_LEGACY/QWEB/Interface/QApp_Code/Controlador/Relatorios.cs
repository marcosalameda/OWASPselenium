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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

namespace CSGenio.framework
{

    public class relatorios : System.Web.UI.Page
    {
        private const string CONST_ERROR_PAGE = "default_error.htm";

        public ReportCrystal reportCrystal;
        public ReportSSRS reportSSRS;
            
        /// <summary>
        /// M�todo to fazer unload dos reports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Unload(object sender, EventArgs e)
        { 
            if (reportCrystal != null && reportCrystal.ReportDocument != null)
            {
                reportCrystal.ReportDocument.Close();
                reportCrystal.ReportDocument.Dispose();
            }

        }
       
        
        
        /// <summary>
        /// M�todo que faz a configura��o do report 
        /// </summary>
        protected void ConfigurarCrystalReports(CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer)
        {
            User user = null;
            try
            {
                user = getUtilizador();
                
                //1 - name do report
                string idReport="";
                				     if(Request.Params["IDPARAM"]!=null)
                    idReport = Request.Params["IDPARAM"].ToString()+".rpt";
                else
                    throw new BusinessException("Erro a carregar o report do crystal","reportCrsytal.ConfigurarCrystalReports","O nome do report n�o est� definido");
                
                //2 - area base do report
                string area = "";
                if(Request.Params["AREA"]!=null)
                    area = Request.Params["AREA"].ToString();
                else
                    throw new BusinessException("Erro a carregar o report do crystal","reportCrsytal.ConfigurarCrystalReports","A area base do report n�o est� definida");
               
                //3 - formata��o do report
                string formRep = "";
                if(Request.Params["TIPO"]!=null)
                    formRep = Request.Params["TIPO"].ToString();
                
                
                //4 - fields array user no report
                string arrpar = "";
                Dictionary<string,string> listaCamposArray = new Dictionary<string,string>();
                if(Request.Params["ARRPAR"]!=null)
                {
                    arrpar = Request.Params["ARRPAR"].ToString();
                    string[] paresCampoArray = arrpar.Split(',');
                    int nrParesCampoArray = paresCampoArray.Length;
                    if(nrParesCampoArray%2!=0)
                        throw new BusinessException("Erro a carregar o relatorio do crystal.","reportCrystal.ConfigurarCrystalReports","O n�mero de campos e respectivas arrays n�o corresponde.");
                    
                    
                    for(int i=0;i<nrParesCampoArray;i=i+2)
                        listaCamposArray.Add(paresCampoArray[i],paresCampoArray[i+1]);
                }

                //5 - fields da table glob
                string globpar="";
                string[] camposGlob = new string[0];
                if(Request.Params["GLOBPAR"]!=null)
                {
                    globpar = Request.Params["GLOBPAR"].ToString();
                    camposGlob = globpar.Split(',');
                }

                //6 - formulas especiais tipo sigla ou Qyear
                string specpar = "";
                string[] formulasEspeciais = new string[0];
                Dictionary<string, string> formulasValor = new Dictionary<string, string>();
                if(Request.Params["SPECPAR"]!=null)
                {
                    specpar = Request.Params["SPECPAR"].ToString();
                    string[] args = specpar.Split(',');
                    List<string> formulasEspeciaisTemp = new List<string>();
                    foreach (string arg in args)
                    {
                        //caso tenha um = ent�o � uma atribui��o e vai to as formulasValor
                        //se n�o tiver ent�o � formulas especiais
                        string[] argValue = arg.Split('=');
                        if (argValue.Length == 2)
                            formulasValor.Add(argValue[0], argValue[1]);
                        else
                            formulasEspeciaisTemp.Add(arg);
                    }

                    if (formulasEspeciaisTemp.Count > 0)
                        formulasEspeciais = formulasEspeciaisTemp.ToArray();
                }

                //7 - record selection pr� definido
                string rsf = "";
                if(Request.Params["RSF"]!=null)
                    rsf = Request.Params["RSF"].ToString();

                //8 - parametros de historial (inclui m�dulo)
                string histpar="";
                string module = "";
                string[] nomesParmsHist;
                List<string> nomesHist = new List<string>();
                List<string> valoresHist = new List<string>();

                if(Request.Params["HISTPAR"]!=null)
                {
                    histpar = Request.Params["HISTPAR"].ToString();
                    nomesParmsHist = histpar.Split(',');
                    int nrParamHist = nomesParmsHist.Length;
                    for(int i=0;i<nrParamHist;i++)
                    {
                        if(Request[nomesParmsHist[i]]!=null)
                        {
                            if (nomesParmsHist[i] == "mod")
                                module = Request[nomesParmsHist[i]];
                            else
                            {
                                nomesHist.Add(nomesParmsHist[i]);
                                valoresHist.Add(Request[nomesParmsHist[i]].ToString());
                            }
                        }
                        else
                            throw new BusinessException("Erro a carregar o report do crystal.","reportCrystal.ConfigurarCrystalReports","O campo de historial "+nomesParmsHist[i] +" n�o tem valor atribu�do.");
                    }
                }
                //9 - parametros de selec��es com condi��es
                //AV(2010/01/03) As selec��es com condi��es n�o existem em hist�rico por isso criei um 
                //par�metro novo que j� tem o Qvalue da condi��o
                string[] nomesConds;
                string[] nomeValorCond;
                string condpar = "";
                if (Request.Params["COND"] != null)
                {
                    condpar = Request.Params["COND"].ToString();
                    nomesConds = condpar.Split(',');
                    int nrConds = nomesConds.Length;

                    for (int i = 0; i < nrConds; i++)
                    {
                        nomeValorCond = nomesConds[i].Split('=');
                        nomesHist.Add(nomeValorCond[0]);
                        valoresHist.Add(nomeValorCond[1]);
                    }
                }
                //10 - parametro entre datas se existir
                string dtpar = "";
                string[] limites = new string[0];
                if(Request.Params["DATAPAR"]!=null)
                {
                    dtpar = Request.Params["DATAPAR"].ToString();
                    limites = new string[2];
                    if(Request.Params[dtpar+"GE"]!=null)
                        limites[0] = Request.Params[dtpar+"GE"].ToString();
                    else
                        throw new BusinessException("Erro a carregar o report do crystal.","reportCrystal.ConfigurarCrystalReports","A data limite inferior do campo "+dtpar +" n�o tem valor atribu�do.");
                  
                    if(Request.Params[dtpar+"LE"]!=null)
                        limites[1] = Request.Params[dtpar+"LE"].ToString();
                    else
                       throw new BusinessException("Erro a carregar o report do crystal.","reportCrystal.ConfigurarCrystalReports","A data limite superior do campo "+dtpar +" n�o tem valor atribu�do.");
                  
                }
                //11 - parametro areas do report se existir
                string areas = "";
                string[] areasReport = new string[0];
                if (Request.Params["AREASRPT"] != null)
                {
                    areas = Request.Params["AREASRPT"].ToString();
                    areasReport = areas.Split(',');
                   
                }
				
				//12 - parametro de RecordSelection do subreport
                bool subReportRecord = false;
                if (Request.Params["SRECORD"] != null)
                {
                    if (Request.Params["SRECORD"].ToString().ToLower() == "true")
                        subReportRecord = true;
                }

				CSGenio.business.Area areaCs = CSGenio.business.Area.createArea(area, user, module);

                List<Object> valoresHistConvertidos = new List<Object>();
                for (int i = 0; i < valoresHist.Count; i++)
                {
                    object element = valoresHist[i];
                    //vem o name da area e do Qfield (table.Qfield)
                    string[] campoCompleto = nomesHist[i].Split('.');
                    //AV(2011/03/29) o hist�rico � dum Qfield da �rea base do rpt
                    if (area == campoCompleto[0] && campoCompleto.Length > 1)
                    {
                        Field campoBD = areaCs.DBFields[campoCompleto[1]];
                        element = Conversion.internal2InternalValid(valoresHist[i], campoBD.FieldType.GetFormatting());
                    }

                    valoresHistConvertidos.Add(element);

                }
                reportCrystal = new ReportCrystal(idReport, area, formRep, dtpar, limites, nomesHist.ToArray(), valoresHistConvertidos.ToArray(), listaCamposArray, camposGlob, formulasEspeciais, rsf, areasReport, subReportRecord, formulasValor);
                user.CurrentModule = module;
                reportCrystal.buildReportDocument(user,module);

              
                CrystalReportViewer.ReportSource = reportCrystal.ReportDocument;
               
                

            }
            catch (BusinessException)
            {
                Response.Clear();
                Response.Redirect("erroReportCrystal.htm");
            }
            catch (PersistenceException)
            {
                Response.Clear();
                Response.Redirect("erroReportCrystal.htm");
            }
            catch (Exception e)
            {
                Log.Error("Erro a visualizar o report: " + e.Message);
                Response.Clear();
                Response.Redirect("erroReportCrystal.htm");
            }
        }
        
        // <summary>
        /// M�todo que faz a configura��o do report 
        /// AJA - o start da fun��o � tal e qual igual ao crystal , o objectivo � ler os parametros que vem do QWEB e os armazenar em dados
        /// No futuro o ideal � fazer isto apenas numa fun��o gen�rica aos 2 metodos
        /// </summary>
        protected void ConfigurarSSRSReports(ReportViewer viewer)
        {
            User user = null;
            try
            {
                user = getUtilizador();

                //1 - name do report
                string idReport = "";
                if (Request.Params["IDPARAM"] != null)
                    idReport = Request.Params["IDPARAM"].ToString();
                else
                    throw new FrameworkException("Erro a carregar o report", string.Empty, "O nome do report n�o est� definido");

                //2 - area base do report
                string area = "";
                if (Request.Params["AREA"] != null)
                    area = Request.Params["AREA"].ToString();
                else
                    throw new FrameworkException("Erro a carregar o report", string.Empty, "A area base do report n�o est� definida");

                //3 - formata��o do report
                //AJA SSRS ver se � necess�rio
                string formRep = "";
                if (Request.Params["TIPO"] != null)
                    formRep = Request.Params["TIPO"].ToString();

                //4 - fields array user no report
                string arrpar = "";
                Dictionary<string, string> listaCamposArray = new Dictionary<string, string>();
                if (Request.Params["ARRPAR"] != null)
                {
                    arrpar = Request.Params["ARRPAR"].ToString();
                    string[] paresCampoArray = arrpar.Split(',');
                    int nrParesCampoArray = paresCampoArray.Length;
                    if (nrParesCampoArray % 2 != 0)
                        throw new FrameworkException("Erro a carregar o report", string.Empty, "O n�mero de campos e respectivas arrays n�o corresponde.");

                    for (int i = 0; i < nrParesCampoArray; i = i + 2)
                        listaCamposArray.Add(paresCampoArray[i], paresCampoArray[i + 1]);
                }

                //5 - fields da table glob
                string globpar = "";
                string[] camposGlob = new string[0];
                if (Request.Params["GLOBPAR"] != null)
                {
                    globpar = Request.Params["GLOBPAR"].ToString();
                    camposGlob = globpar.Split(',');
                }

                //6 - formulas especiais tipo sigla ou Qyear
                string specpar = "";
                string[] formulasEspeciais = new string[0];
                if (Request.Params["SPECPAR"] != null)
                {
                    specpar = Request.Params["SPECPAR"].ToString();
                    formulasEspeciais = specpar.Split(',');
                }

                //MF - RSF nao se aplica a Reporting Services
                //7 - record selection pr� definido
                //string rsf = "";
                //if (Request.Params["RSF"] != null)
                //    rsf = Request.Params["RSF"].ToString();

                //8 - parametros de historial (inclui m�dulo)
                string histpar = "";
                string module = "";
                string[] nomesParmsHist;
                List<string> nomesHist = new List<string>();
                List<string> valoresHist = new List<string>();

                if (Request.Params["HISTPAR"] != null)
                {
                    histpar = Request.Params["HISTPAR"].ToString();
                    nomesParmsHist = histpar.Split(',');
                    int nrParamHist = nomesParmsHist.Length;
                    for (int i = 0; i < nrParamHist; i++)
                    {
                        if (Request[nomesParmsHist[i]] != null)
                        {
                            if (nomesParmsHist[i] == "mod")
                                module = Request[nomesParmsHist[i]];
                            else
                            {
                                nomesHist.Add(nomesParmsHist[i]);
                                valoresHist.Add(Request[nomesParmsHist[i]].ToString());
                            }
                        }
                        else
                            throw new FrameworkException("Erro a carregar o report", string.Empty, "O campo de historial " + nomesParmsHist[i] + " n�o tem valor atribu�do.");
                    }
                }
                //9 - parametros de selec��es com condi��es
                //AV(2010/01/03) As selec��es com condi��es n�o existem em hist�rico por isso criei um 
                //par�metro novo que j� tem o Qvalue da condi��o
                string[] nomesConds;
                string[] nomeValorCond;
                string condpar = "";
                if (Request.Params["COND"] != null)
                {
                    condpar = Request.Params["COND"].ToString();
                    nomesConds = condpar.Split(',');
                    int nrConds = nomesConds.Length;

                    for (int i = 0; i < nrConds; i++)
                    {
                        nomeValorCond = nomesConds[i].Split('=');
                        nomesHist.Add(nomeValorCond[0]);
                        valoresHist.Add(nomeValorCond[1]);
                    }
                }
                //10 - parametro entre datas se existir
                string dtpar = "";
                var limites = new List<ReportLimitParameter>();
                if (Request.Params["DATAPAR"] != null)
                {
                    dtpar = Request.Params["DATAPAR"].ToString();

                    string lim0, lim1 = "";
                    if (Request.Params[dtpar + "GE"] != null)
                        lim0 = Request.Params[dtpar + "GE"].ToString();
                    else
                        throw new FrameworkException("Erro a carregar o report", string.Empty, "A data limite inferior do campo " + dtpar + " n�o tem valor atribu�do.");

                    if (Request.Params[dtpar + "LE"] != null)
                        lim1 = Request.Params[dtpar + "LE"].ToString();
                    else
                        throw new FrameworkException("Erro a carregar o report", string.Empty, "A data limite superior do campo " + dtpar + " n�o tem valor atribu�do.");

                    limites.Add(new ReportLimitParameter_SE()
                    {
                        FullFieldName = dtpar.ToLower(),
                        MinFieldName = string.Concat(dtpar,"MIN"),
                        MinFieldValue = lim0,
                        MaxFieldName = string.Concat(dtpar, "MAX"),
                        MaxFieldValue = lim1,
                        FieldType = "D"
                    });
                }
				
                //11 - parametro areas do report se existir
                string areas = "";
                string[] areasReport = new string[0];
                if (Request.Params["AREASRPT"] != null)
                {
                    areas = Request.Params["AREASRPT"].ToString();
                    areasReport = areas.Split(',');
                }

                CSGenio.business.Area areaCs = CSGenio.business.Area.createArea(area, user, module);

                List<string> valoresHistConvertidos = new List<string>();
                for (int i = 0; i < valoresHist.Count; i++)
                {
                    string element = valoresHist[i];
                    //vem o name da area e do Qfield (table.Qfield)
                    string[] campoCompleto = nomesHist[i].Split('.');
                    //AV(2011/03/29) o hist�rico � dum Qfield da �rea base do rpt
                    if (area == campoCompleto[0] && campoCompleto.Length > 1)
                    {
                        Field campoBD = areaCs.DBFields[campoCompleto[1]];
                        element = Conversion.internal2InternalValid(valoresHist[i], campoBD.FieldType.GetFormatting()).ToString(); //ATEN��O: o valor devia ser passado com recurso ao ReportLimitParameter
                    }
                    valoresHistConvertidos.Add(element);
                }

				string caminho = CSGenio.framework.Configuration.SSRSServer.path + "/" + idReport;
                string report = (caminho.StartsWith("/") ? "" : "/") + caminho;
                using (var renderer = new ReportSSRS(report, report.Substring(report.LastIndexOf("/") + 1)))
				{
                    if (Configuration.SSRSServer.ContainsCredentials())
                        renderer.ServerReportInstance.ReportServerCredentials = new ReportServerCredentials(Configuration.SSRSServer.UsernameDecode, Configuration.SSRSServer.PasswordDecode, Configuration.SSRSServer.Domain);

                    renderer.ConstructReport(user, area, nomesHist.ToArray(), valoresHistConvertidos.ToArray(), camposGlob, areasReport, limites.ToArray(), formulasEspeciais);
					
					viewer.ProcessingMode = ProcessingMode.Remote;
                    viewer.ServerReport.ReportServerUrl = new Uri(renderer.GetReportServerUrl());
					viewer.ServerReport.ReportPath = renderer.GetReportNamePath();

					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
					{
						viewer.ServerReport.ReportServerCredentials = new ReportServerCredentials(Configuration.SSRSServer.UsernameDecode, Configuration.SSRSServer.PasswordDecode, Configuration.SSRSServer.Domain);
					}

					//MF 19-03-2014
					//obter os par�metros definidos no relat�rio de forma a verificar a integridade dos mesmos.
					//Podem vir quinhentas condi��es da web. S� v�o to o report, caso exista um par�metro
					//preparado to receber esses dados. 
					//TODO: Analisar se esta � a melhor abordagem, visto que � feita mais uma comunica��o ao servidor de reports.
					//Podemos tamb�m deixar o report rebentar, no entanto, isso acaba por cortar alguma da poss�vel reutiliza��o do report noutros locais
					ReportParameterInfoCollection reportParams = viewer.ServerReport.GetParameters();
					
					//condi��es aplicadas pela web
					Dictionary<string, List<string>> webParams = renderer.GetParamValues();

					foreach (var param in reportParams)
						if (webParams.ContainsKey(param.Name))
							viewer.ServerReport.SetParameters(new ReportParameter(param.Name, webParams[param.Name].ToArray()));
				}
            }
            catch (Exception e)
            {
                Log.Error("Erro a visualizar o report: " + e.Message);
                Response.Clear();
                Response.Redirect(CONST_ERROR_PAGE);
            }
        }

        /// <summary>
        /// M�todo to obter o user que est� em sess�o
        /// </summary>
        /// <returns>o user em sess�o</returns>
        private User getUtilizador()
        {
            //c�digo to ir buscar o user � sess�o
            object utilizadorObj = Session["utilizador"];
            if (utilizadorObj == null)
                throw new BusinessException("O utilizador n�o est� autenticado", "constructorPdf", "O utilizador n�o est� autenticado");
            User user = (User)utilizadorObj;
            return user;

        }
		
		protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {
            
        }

    }
}
