using GenioMVC.Models.Cav;
using GenioMVC.ViewModels.Cav;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web.Script.Serialization;
using System;
using PagedList;
using GenioMVC.Models.Navigation;
using GenioMVC.Helpers.Cav;
using CSGenio.business;
using Newtonsoft.Json;

namespace GenioMVC.Controllers.Cav
{
    public class CavController : ControllerExtention
    {
        XmlCavService cavServices = XmlCavService.Instance;

        //
        // GET: /Cav/
        [Authorize]
        [HttpGet]
        public ActionResult Index(string area)
        {
            if (!string.IsNullOrEmpty(area) && Area.ListaAreas.Contains(area.ToLower()))
            {
                List<CAVTable> tables = new List<CAVTable>();
                ReportDefinition query = Session["Query"] as ReportDefinition;

                //if report does not exist it will be created a new one
                if (query == null)
                {
                    query = CreateEmptyQuery(area);
                    Session["Query"] = query;
                    Session["QueryId"] = "new";
                    ViewBag.QueryId = "new";
                }
                else
                {
                    tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);
                }

                GlobalViewModel model = new GlobalViewModel(tables, query);
                return PartialView("cavindex", model);
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewQuery(string area)
        {
            if (cavServices != null && !string.IsNullOrEmpty(area))
            {
                ReportDefinition query = CreateEmptyQuery(area);
                Session["Query"] = query;
                Session["QueryId"] = "new";

                List<CAVTable> tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);
                GlobalViewModel model = new GlobalViewModel(tables, query);
                return PartialView("cavindex", model);
            }

            return Json(new { Success = false, Message = "Não foi possivel criar um novo relatório!" });
        }

        private ReportDefinition CreateEmptyQuery(string area)
        {
            if (cavServices != null && string.IsNullOrEmpty(area))
                return null;

            ReportDefinition query = new ReportDefinition();
            query.DetailsGroup = new ReportGroup();
            query.DetailsGroup.Fields = new List<ReportField>();

            query.BaseTable = area.ToUpper();
            //query.BaseTable = area.ToLower();

            if (!string.IsNullOrEmpty(query.BaseTable))
            {
                List<CAVTable> tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);
                CAVTable table = tables.FirstOrDefault(p => p.Id.Equals(query.BaseTable, System.StringComparison.OrdinalIgnoreCase));
                if (table != null)
                    query.BaseTableDescription = table.Description;
            }

            return query;
        }


        [Authorize]
        [HttpGet]
        public ActionResult Details()
        {
            if (cavServices != null)
            {
                ReportDefinition query = Session["Query"] as ReportDefinition;
                List<CAVTable> tables = new List<CAVTable>();

                if (!string.IsNullOrEmpty(query.BaseTable))
                    tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);

                GlobalViewModel model = new GlobalViewModel(tables, query);

                return PartialView("Details", model);
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetTabContentByType(string type)
        {
            if (cavServices != null)
            {
                ReportDefinition query = Session["Query"] as ReportDefinition;
                List<CAVTable> tables = new List<CAVTable>();

                if (!string.IsNullOrEmpty(query.BaseTable))
                    tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);

                GlobalViewModel model = new GlobalViewModel(tables, query);
                ViewBag.Table = query.BaseTable;

                switch (type)
                {
                    case "C":
                        {
                            return PartialView("_ConditionsSelected", model);
                        }
                    case "G":
                        {
                            return PartialView("_GroupBySelected", model);
                        }
                    case "O":
                        {
                            return PartialView("_OrderBySelected", model);
                        }
                    case "T":
                        {
                            return PartialView("_TotalSelected", model);
                        }
                    case "E":
                        {
                            return PartialView("_ExecuteQuery", model);
                        }
                    default:
                        break;
                }
                return View();
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddField(string tableId, string fieldId)
        {
            ReportDefinition query = Session["Query"] as ReportDefinition;
            if (query != null && cavServices != null)
            {
                List<CAVTable> upTables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);

                CAVTable table = cavServices.GetTable(tableId, UserContext.Current.User.Language);

                if (table != null)
                {
                    if (table.Id.Equals(query.BaseTable, System.StringComparison.OrdinalIgnoreCase) || cavServices.ExistRelationship(query.BaseTable, tableId))
                    {
                        var fieldToAdd = tableId + "." + fieldId.Substring(3);
                        Field field = table.Fields.FirstOrDefault(p => p.Id.Equals(fieldToAdd, System.StringComparison.OrdinalIgnoreCase));

                        if (field != null)
                        {
                            ReportField rptField = new ReportField { FieldId = field.Id, Title = field.Description, TableId = field.TableId };
                            if (query.DetailsGroup.Fields == null)
                                query.DetailsGroup.Fields = new List<ReportField>();
                            query.DetailsGroup.Fields.Add(rptField);
                            Session["Query"] = query;

                            GlobalViewModel model = new GlobalViewModel(upTables, query);
                            return PartialView("_FieldsSelected", model);
                        }
                    }
                }
            }

            return Json(new { Success = false, Message = "Erro ao adicionar campo. Campo não relacionado!" });
        }

        [Authorize]
        [HttpGet]
        public ActionResult SaveQuery(string table)
        {
            if(cavServices != null)
            {
                // o título do report
                ReportDefinition query = Session["Query"] as ReportDefinition;
                ViewBag.QueryDesc = query != null ? query.Title ?? "" : "";
                ViewBag.QueryId = Session["QueryId"] ?? "";
            }
            return PartialView("_SaveQuery");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateQuery(string fields, string orderby, string conditions, string groupby)
        {
            // utilizar este método para atravessar o limbo
            // ou seja, antes de qualquer operação que exija
            // que a query esteja actualizada do lado do servidor
            // deve-se invocar este método
            ReportDefinition query = Session["Query"] as ReportDefinition;

            try
            {
                Dictionary<string, string> collection = new Dictionary<string, string>();
                collection.Add("fields", fields);
                collection.Add("conditions", conditions);
                collection.Add("orderby", orderby);
                collection.Add("groupby", groupby);
                collection.Add("relations", "");
                collection.Add("yearmode", "");
                collection.Add("years", "");

                ReportDefinition request = CreateReportDefinition(query.BaseTable, collection);
                query.DetailsGroup = request.DetailsGroup;
                query.Condition = request.Condition;
                query.Groups = request.Groups;
                query.Orderings = request.Orderings;
            }
            catch (Exception)
            {
                // se falhou a des-serializar a query é porque não tem campos escolhidos, logo não se grava nada
                // TODO: melhorar isto (CreateReportDefinition)
            }

            return Content("");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveQueryData(FormCollection collection)
        {
            try
            {
                if (cavServices ==null)
                    return Content("Não foi possivel gravar a query!");

                // o título do report
                string id = collection["id"];
                string qoverride = collection["override"];

                if (!string.IsNullOrEmpty(id) && id.Equals("new", StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(qoverride))
                    id = null;

                ReportDefinition query = Session["Query"] as ReportDefinition;
                ViewBag.QueryDesc = query != null ? query.Title ?? "" : "";
                ViewBag.QueryId = Session["QueryId"] ?? "";

                if (query != null)
                {
                    query.Title = collection["title"];
                    query.Acesso = collection["access"];
                }

                if (cavServices.SaveQuery(query, UserContext.Current.User, id))
                    return Content("Query gravada com sucesso!");
                return Content("Não foi possivel gravar a query!");
            }
            catch (Exception)
            {
                return Content("Erro na gravação da query!");
            }
        }

        [Authorize]
        public ActionResult ExecuteQuery(string table, string data, int? page, string queryid = null)
        {
            try
            {
                Dictionary<string, string> collection = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

                ReportDefinition query = null;
                // Construir pedido
                if (queryid == null && cavServices != null)
                    query = CreateReportDefinition(table, collection);

                return ExecuteQuery2(query, page, queryid);
            }
            catch (Exception e)
            {
                return onErrorExecuteQuery(e);
            }
        }

        [Authorize]
        public ActionResult ExecuteQuery2(ReportDefinition query, int? page, string queryid = null)
        {
            try
            {
                ResultModel model_result = null;
                if (queryid == null && cavServices != null)
                {
                    ReportReply response = new ReportReply();
                    try
                    {
                        CavEngine cavEng = new CavEngine(cavServices);
                        response = cavEng.ExecuteQuery(UserContext.Current.User, query);
                    }
                    catch (Exception e)
                    {
                        // Não foi possível concluir o pedido
                        response.Result = "E";
                        response.ResultMessage = e.Message;
                    }

                    // Construir o modelo de dados para a vista
                    model_result = new ResultModel(response, query);
                }

                if (model_result == null)
                    throw new BusinessException("\"model_result\" object is null", "ExecuteQuery2", "Either queryid isn't null or cavServices is null", new ArgumentNullException());

                // hack para apanhar a excepção correcta
                if (model_result.Result.Result == "E")
                    throw new Exception(model_result.Result.ResultMessage);

                TempData["CavModelResult"] = model_result.Result;
                TempData["CavModelQuery"] = model_result.Query;
                TempData["CavQuerySQL"] = model_result.Result.ResultMessage;

                List<SpecialList> results = ResultsHelpers.CreateResultsTableFlat(model_result.Result.MainGroup, model_result.Query);

                // Paginação de resultados

                var pageNumber = page ?? 1;
                // Para já está com 50 rows, mas podem ser mais...
                IPagedList<SpecialList> paged_list = results.ToPagedList(pageNumber, 50);
                List<SpecialList> final_list = paged_list.ToList();

                // isto não pode ser feito assim para multi-ano, por agora leva esta martelada só para resolver
                if (pageNumber != 1 && !(model_result.Query.Years != null && model_result.Query.Years.Count > 0 && model_result.Query.MultiYearMode == "PAGE"))
                {
                    SpecialList header = results.First(); // Vai se reter a tabela header para aparecer em todas as páginas
                    final_list.Insert(0, header);
                }

                HtmlHelper test = null;
                string html = test.FinalResults(final_list.ToList());

                JavaScriptSerializer js = new JavaScriptSerializer();
                js.MaxJsonLength = int.MaxValue;
                var final_result = new
                {
                    querySQL = model_result.Result.ResultMessage,
                    record_count = model_result.Result.ResultCount.ToString(),
                    total_pages = paged_list.PageCount,
                    current_page = paged_list.PageNumber,
                    results = html
                };

                return new ContentResult { Content = js.Serialize(final_result), ContentType = "text/json" };
            }
            catch (Exception e)
            {
                return onErrorExecuteQuery(e);
            }
        }

        private ActionResult onErrorExecuteQuery(Exception error)
        {
            var errorMessage = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 + " - " + error.Message;
            TempData["CavQuerySQL"] = errorMessage;
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            var final_result = new
            {
                querySQL = errorMessage,
                record_count = "0",
                total_pages = 1,
                current_page = 1,
                results = "<p class=\"result-error\">"+ Resources.Resources.OCORREU_UM_ERRO_AO_P53091 + "</p>"

            };
            return new ContentResult { Content = js.Serialize(final_result), ContentType = "text/json" };
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetTableRelations(string table)
        {
            if (cavServices != null)
            {
                object result = cavServices.ConstructRelationList(table);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "E", message = "É necessário inicializar 'XMLCavService'" }, JsonRequestBehavior.AllowGet);
            }
        }

        private static ReportDefinition CreateReportDefinition(string table, Dictionary<string, string> collection)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            ReportDefinition result = new ReportDefinition()
            {
                BaseTable = table,
                DetailsGroup = new ReportGroup() { Fields = js.Deserialize<List<ReportField>>(collection["fields"]) },
                Condition = js.Deserialize<ReportCondition>(collection["conditions"]),
                Orderings = js.Deserialize<List<ReportOrdering>>(collection["orderby"]),
                Groups = js.Deserialize<List<ReportGroup>>(collection["groupby"]),
                ExtraPaths = js.Deserialize<List<ReportLink>>(collection["relations"])
            };

            return result;
        }

        [Authorize]
        public ActionResult ObtainSQLQuery()
        {
            // Versão antiga do HomeController
            string result = TempData["CavQuerySQL"] as string;
            TempData["CavQuerySQL"] = result;
            return new ContentResult { Content = result, ContentType = "text/html" };
        }

        [Authorize]
        public ActionResult LoadQueryList()
        {
            var reportList = cavServices.LoadQueryList(UserContext.Current.User);
            return Json(new { result = "OK", message = reportList }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult LoadQuery(string queryid)
        {
            ReportDefinition query = cavServices.LoadQuery(queryid, UserContext.Current.User);

            if (query != null)
            {
                Session["Query"] = query;
                Session["QueryId"] = queryid;

                List<CAVTable> tables = cavServices.GetTableUpList(query.BaseTable, UserContext.Current.User.Language);
                GlobalViewModel model = new GlobalViewModel(tables, query);
                return PartialView("cavindex", model);
            }
            else
            {
                return Content("Erro ao obter a query!");
            }
        }

        [Authorize]
        public FileResult GenerateExcel()
        {
            // Versão antiga do HomeController
            // Model received from the ExecuteQuery request
            var reportReplay = (ReportReply)TempData["CavModelResult"];
            var reportQuery = (ReportDefinition)TempData["CavModelQuery"];
            ResultModel model = new ResultModel(reportReplay, reportQuery);

            // Report Excel instance
            ReportExcel report = new ReportExcel(model);

            // Generate Excel file
            byte[] exelfile = report.GenerateExcelBytes();

            TempData["CavModelResult"] = model.Result;
            TempData["CavModelQuery"] = model.Query;

            // Write it back to the client
            string fileName = model.Query.BaseTable + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Response.AddHeader("content-disposition", "attachment;  filename=" + fileName + ".xlsx");
            return File(exelfile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //FIXME Vue functions

        [Authorize]
        public ActionResult ExecuteQueryNew(string jsonQuery)
        {
            try
            {
                ReportDefinition query = JsonConvert.DeserializeObject<ReportDefinition>(jsonQuery);

                ResultModel model_result = null;
                // Construir pedido
                ReportReply response = new ReportReply();
                try
                {
                    CavEngine cavEng = new CavEngine(cavServices);
                    response = cavEng.ExecuteQuery(UserContext.Current.User, query);
                }
                catch (Exception e)
                {
                    // Não foi possível concluir o pedido
                    response.Result = "E";
                    response.ResultMessage = e.Message;
                }

                // Construir o modelo de dados para a vista
                model_result = new ResultModel(response, query);

                // hack para apanhar a excepção correcta
                if (model_result.Result.Result == "E")
                    throw new Exception(model_result.Result.ResultMessage);

                List<SpecialList> results = ResultsHelpers.CreateResultsTableFlat(model_result.Result.MainGroup, model_result.Query);

                List<List<string>> query_results = new List<List<string>>();
                List<string> headers = new List<string>();

                headers = results[0].GetRange(1, results[0].Count() - 1);

                for (int i = 1; i < results.Count(); i++)
                {
                    var aux = new List<string>();
                    for (int j = 1; j < results[i].Count(); j++)
                        aux.Add(results[i][j]);
                    query_results.Add(aux);
                }

                return Json(new { Results = query_results, Headers = headers, Query = model_result.Result.ResultMessage });
            }
            catch (Exception)
            {
                return Json(new { Results = new List<string>(), Headers = new List<string>(), Query = "Error" });
            }
        }

        [Authorize]
        public FileResult ExcelTest(string jsonQuery)
        {
            ReportDefinition query = JsonConvert.DeserializeObject<ReportDefinition>(jsonQuery);

            ResultModel model = null;
            // Construir pedido
            ReportReply response = new ReportReply();
            try
            {
                CavEngine cavEng = new CavEngine(cavServices);
                response = cavEng.ExecuteQuery(UserContext.Current.User, query);
            }
            catch (Exception e)
            {
                // Não foi possível concluir o pedido
                response.Result = "E";
                response.ResultMessage = e.Message;
            }

            // Construir o modelo de dados para a vista
            model = new ResultModel(response, query);

            ReportExcel report = new ReportExcel(model);

            // Generate Excel file
            byte[] exelfile = report.GenerateExcelBytes();

            // Write it back to the client
            string fileName = model.Query.BaseTable + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Response.AddHeader("content-disposition", "attachment;  filename=" + fileName + ".xlsx");
            return File(exelfile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
