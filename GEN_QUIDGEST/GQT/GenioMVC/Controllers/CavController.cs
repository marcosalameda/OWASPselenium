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
using CSGenio.framework;

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

            Log.Error($"CAV - Could not create new report. {area};");
            return Json(new { Success = false, Message = "Could not create new report!" });
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
                        GenioMVC.Models.Cav.Field field = table.Fields.FirstOrDefault(p => p.Id.Equals(fieldToAdd, System.StringComparison.OrdinalIgnoreCase));

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

            Log.Error($"CAV - Error adding field. Unrelated field. table: {tableId}; field: {fieldId};");
            return Json(new { Success = false, Message = "Error adding field. Unrelated field!" });
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
            catch (Exception e)
            {
                Log.Error($"CAV - Error updating the query. {e.Message}");
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
                if (cavServices == null)
                {
                    Log.Error("CAV - Could not save the query. The 'XMLCavService' needs to be initialized");
                    return Content("Could not save the query!");
                }

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
                    return Content("Query saved successfully!");

                Log.Error($"CAV - Error saving the query! id: {id}");
                return Content("Could not save the query!");
            }
            catch (Exception e)
            {
                Log.Error($"CAV - Error saving the query! {e.Message}");
                return Content("Error saving the query!");
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
                        throw new FrameworkException("Error processing Advanced Query", "ExecuteQueryNew", e.Message, e);
                    }

                    // Construir o modelo de dados para a vista
                    model_result = new ResultModel(response, query);
                }

                if (model_result == null)
                    throw new FrameworkException("Some problem with the service or the query is not recognized.", "ExecuteQuery2", "Either queryid isn't null or cavServices is null", new ArgumentNullException());

                TempData["CavModelResult"] = model_result.Result;
                TempData["CavModelQuery"] = model_result.Query;
                TempData["CavQuerySQL"] = model_result.Result.QuerySQL;

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
                    querySQL = model_result.Result.QuerySQL,
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
            var errorMessage = Resources.Resources.OCORREU_UM_ERRO_AO_P53091;
            if (error is GenioException genioError)
                errorMessage += " - " + genioError.UserMessage;

            Log.Error($"CAV - onErrorExecuteQuery: {error.Message}");

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
                Log.Error("CAV - The 'XMLCavService' needs to be initialized");
                return Json(new { result = "E", message = "CAV service is unavailable" }, JsonRequestBehavior.AllowGet);
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
            return Json(new { result = "OK", message = reportList }, JsonRequestBehavior.AllowGet); // TODO: check 'reportList'
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
                return PartialView("cavindex", model); // TODO: check
            }
            else
            {
                Log.Error($"CAV - Error getting query. {queryid}");
                return Content("Error getting query!");
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
    }
}
