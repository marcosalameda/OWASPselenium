using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Lstusr;
using CSGenio.framework;
using CSGenio.persistence;
using GenioServer.security;
using CSGenio.business;
using Quidgest.Persistence.GenericQuery;
using System.Globalization;
using System.Web.Routing;


namespace GenioMVC.Controllers.Lstusr
{
    public class LstusrController : ControllerBase
    {
        // GET: /Lstusr/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ChangeListProperties(string idlist, string idlistController, string idlistArea, string codlista)
        {
            ListPropertiesViewModel viewModel = new ListPropertiesViewModel();
            viewModel = ChangeListPropertiesVM(idlist, idlistController, idlistArea, codlista);
            return PartialView(viewModel);
        }

        public ListPropertiesViewModel ChangeListPropertiesVM(string idlist, string idlistController, string idlistArea, string codlista)
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";

            codlista = string.IsNullOrEmpty(codlista) ? idlist : codlista; //in order to support both menu lists (with primary key) and form lists (no key)
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And().Equal(CSGenioAlstusr.FldDescric, codlista).Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw).Equal(CSGenioAlstusr.FldZzstate, 0)).FirstOrDefault();
            ListPropertiesViewModel viewModel = new ListPropertiesViewModel();

            if (model == null)//insert new configuration list
            {
                model = new CSGenioAlstusr(user);
                //model.ValCodlstusr = Guid.NewGuid().ToString();
                model.ValCodpsw = user.Codpsw;
                model.ValIdlist = idlist;
                model.ValModulo = user.CurrentModule;
                model.ValSistema = Configuration.Program; //? confirm
                model.ValDescric = codlista;
                try
                {
                    sp.openConnection();
                    model.insert(sp);
                    sp.closeConnection();

                    UserUiSettings.Invalidate(model.ValDescric, user);
                }
                catch
                {}
                viewModel.FormMode = "1";
            }
            else
                viewModel.FormMode = "2";

            Navigation.SetValue("idlist", idlist);
            Navigation.SetValue("idlistController", idlistController);
            Navigation.SetValue("idlistArea", idlistArea);

            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());


            Navigation.SetValue("lstusr", model.ValCodlstusr);

            viewModel.Navigation = Navigation;

            viewModel.MapFromModel(model);

            return viewModel;
        }

        [HttpPost]
        [HttpParamAction]
        public JsonResult ResetListProperties(string codlstusr)
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And().Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw).Equal(CSGenioAlstusr.FldCodlstusr, codlstusr).Equal(CSGenioAlstusr.FldZzstate, 0)).FirstOrDefault();
            ListPropertiesViewModel viewModel = new ListPropertiesViewModel();

            viewModel.FormMode = "2";
            viewModel.Navigation = Navigation;
            viewModel.MapFromModel(model);

            //deletes and refreshes list columns
            List<CSGenioAlstcol> model_columns = CSGenioAlstcol.searchList(sp, user, CriteriaSet.And().Equal(CSGenioAlstcol.FldCodlstusr, codlstusr).Equal(CSGenioAlstcol.FldZzstate, 0));
            if (model_columns != null)
            {
                sp.openConnection();
                foreach (var column in model_columns)
                {
                    column.delete(sp);
                }
                sp.closeConnection();

                UserUiSettings.Invalidate(model.ValDescric, user);
            }

            return new JsonResult() { Data = new { success = true, loading = false } };
        }
		
        [HttpPost]
        public ActionResult ChangeListProperties(ListPropertiesViewModel viewModel)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            if (!ModelState.IsValid)
            {
                Navigation.SetValue("lstusr", viewModel.ValCodlstusr);

                viewModel.Navigation = Navigation;
                //Navigation.RemoveHistoryLevel();
                return PartialView(viewModel);
                //erro
            }
            sp.openConnection();

            CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And().Equal(CSGenioAlstusr.FldCodlstusr, viewModel.ValCodlstusr).Equal(CSGenioAlstusr.FldZzstate, 0)).FirstOrDefault();

            if (viewModel.FormMode == "1")
            {
                model = new CSGenioAlstusr(user);
            }
            try
            {
                //map viewmodel to model
                viewModel.MapToModel(model);

                switch (viewModel.FormMode)
                {
                    case "1":
                        {
                            model.update(sp);
                            break;
                        }
                    case "2":
                        {
                            model.update(sp);
                            break;
                        }
                    case "3":
                        {
                            model.delete(sp);
                            break;
                        }
                    default:
                        break;
                }

                sp.closeConnection();

                UserUiSettings.Invalidate(model.ValDescric, user);

                //Navigation.RemoveHistoryLevel();
                var location = Navigation.CurrentLevel.Location;
                return Json(new { Success = true, Operation = "Save", newURL = Url.Action(location.Action, location.Controller) });
            }
            catch (Exception e)
            {
                TempData["resultMsg"] = model.ResultMsg;
                model.ResultMsg = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper());
            }
            return new JsonResult() { Data = new { success = false, loading = false } };
        }

        #region GridTableList Virtual Form Methods -> Lstusr_ViewModel_ValLstcol

        // POST: /Colun/Lstusr_ViewModel_ValLstcolForm_Edit
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Lstusr_ValLstcolForm_Edit(GenioMVC.ViewModels.Lstusr.Lstusr_ValLstcolForm_ViewModel model, FormCollection collection)
        {
            var qs = Request.QueryString;

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "Lstusr_ViewModel_ValLstcolForm_Edit", "Erro");

                sp.openTransaction();
				model.Save();
                sp.closeTransaction();

                return Json(new
                {
                    Success = true,
                    Key = model.ValCodlstcol,
					Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

                return Json(new
                {
                    Success = false,
                    Key = model.ValCodlstcol,
					Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
        }

        //
        // POST: /Colun/Lstusr_ViewModel_ValLstcolForm_New
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Lstusr_ValLstcolForm_New(GenioMVC.ViewModels.Lstusr.Lstusr_ValLstcolForm_ViewModel model, FormCollection collection)
        {
            var qs = Request.QueryString;

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "Lstusr_ViewModel_ValLstcolForm_New", "Erro");

                sp.openTransaction();
                model.New();
                model.NewLoad();
                model.Save();
                sp.closeTransaction();

                return Json(new
                {
                    Success = true,
                    Key = model.ValCodlstcol,
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"]
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

                return Json(new
                {
                    Success = false,
                    Key = model.ValCodlstcol,
                    Expose = collection["expose"].ToString(),
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"]
                });
            }
        }

        // POST: /Colun/Lstusr_ViewModel_ValLstcolForm_Delete
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Lstusr_ValLstcolForm_Delete(GenioMVC.ViewModels.Lstusr.Lstusr_ValLstcolForm_ViewModel model, FormCollection collection)
        {
            var qs = Request.QueryString;
            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                if (!String.IsNullOrEmpty(model.ValCodlstcol))
                {
                    model.Navigation = Navigation;

                    sp.openTransaction();
                    model.Destroy();
                    sp.closeTransaction();
                }

                return Json(new
                {
                    Success = true,
                    Key = model.ValCodlstcol,
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

                return Json(new
                {
                    Success = false,
                    Key = model.ValCodlstcol,
                    Expose = collection["expose"].ToString(),
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
        }

        // GET: /Organ/Organ_ValColunas
        // POST: /Organ/Organ_ValColunas
        [AuthorizeForUsers]
        [ActionName("Lstusr_ValLstcol")]
        public ActionResult Lstusr_ValLstcol(string id, string partialView)
        {
            NameValueCollection requestValues = Request.Form;

            Lstusr_ValLstcol_ViewModel model = new Lstusr_ValLstcol_ViewModel(Navigation);

            model.ValCodlstusr = id;

            //Gets the current list of columns for this ViewModel, by reflection
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            RouteValueDictionary routeValueDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(Navigation.CurrentLevel.Location.RoutedValues);
			
			String idlist = (string)(routeValueDictionary["idlist"] ?? Navigation.CurrentLevel.GetEntry("idlist"));
            String idlistController = (string)(routeValueDictionary["idlistController"] ?? Navigation.CurrentLevel.GetEntry("idlistController"));
            String idlistArea = (string)(routeValueDictionary["idlistArea"] ?? Navigation.CurrentLevel.GetEntry("idlistArea"));

            string viewmodelStr = String.Format("GenioMVC.ViewModels.{0}.{1}_ViewModel", idlistController, idlist);
            var viewmodelType = Type.GetType(viewmodelStr, false, true);
            ListViewModel vm = (ListViewModel)Activator.CreateInstance(viewmodelType, new object[] { new NavigationContext() });

            string uuid = vm.Uuid;
            var listColumns = vm.GetColumnsToExport();
            List<CSGenioAlstcol> userColumns = UserUiSettings.Load(sp, uuid, user).UserColumns;

            //inserts new columns that are not present in the user list configuration
            int pos = 0;
            if (userColumns != null && userColumns.Count > 0)
            {
                bool different = false;
                foreach (Exports.QColumn column in listColumns)
                {
                    pos++;
                    string areabase = idlistArea.ToLower() == column.BaseArea.ToLower() ? "": column.BaseArea != idlistController.ToLower() ? char.ToUpper(column.BaseArea[0]) + column.BaseArea.Substring(1)  + "." : "";
                    //check if theres a match in existing list columns
                    CSGenioAlstcol matching_column = userColumns.Where(x => x.ValTabela.ToUpper() == column.BaseArea.ToUpper() /*&& x.ValAlias.ToUpper() == column.Description.ToUpper()*/ && x.ValCampo == areabase + "Val" + char.ToUpper(column.FieldName[0]) + column.FieldName.Substring(1)).FirstOrDefault(); //removed description, this caused unwanted duplication if descriptions were changed.
                    if (matching_column == null)
                    {
                        different = true;
                        CSGenioAlstcol lstcol = new CSGenioAlstcol(user);
                        lstcol.ValCodlstusr = id;
                        lstcol.ValTabela = column.BaseArea;
                        lstcol.ValAlias = column.Description; //using this as the title to show within lists
                                                              //Fields with reference to base area(if different than idlistController)
                        lstcol.ValCampo = areabase + "Val" + char.ToUpper(column.FieldName[0]) + column.FieldName.Substring(1);
                        lstcol.ValPosicao = pos;
                        lstcol.ValVisivel = 0; //in this case, the new column in user list will be invisible, in order to keep user config.
                                               //lstcol.ValOperacao = unused for now
                                               //lstcol.ValTipo = unused for now
                        try
                        {
                            sp.openConnection();
                            lstcol.insert(sp);
                            sp.closeConnection();
                        }
                        catch
                        {
                            //todo
                        }
                    }

                }
                if (different) //reloads user columns
                {
                    UserUiSettings.Invalidate(uuid, user);
                    userColumns = UserUiSettings.Load(sp, uuid, user).UserColumns;
                }
            }
            //in case it doesnt have any list loaded (BD) yet, loads the list defaults
            if (userColumns == null || userColumns.Count == 0)
            {
                pos = 1;
                foreach (Exports.QColumn column in listColumns)
                {
                    CSGenioAlstcol lstcol = new CSGenioAlstcol(user);
                    lstcol.ValCodlstusr = id;
                    lstcol.ValTabela = column.BaseArea;
                    lstcol.ValAlias = column.Description; //using this as the title to show within lists
                    //Fields with reference to base area(if different than idlistController)
                    string areabase = idlistArea.ToLower() == column.BaseArea.ToLower() ? "" : column.BaseArea.ToLower() != idlistController.ToLower() ? char.ToUpper(column.BaseArea[0]) + column.BaseArea.Substring(1) + "." : "";
                    lstcol.ValCampo = areabase + "Val" + char.ToUpper(column.FieldName[0]) + column.FieldName.Substring(1);
                    lstcol.ValPosicao = pos++;
                    lstcol.ValVisivel = column.Visible ? 1 : 0;
                    //lstcol.ValOperacao = unused for now
                    //lstcol.ValTipo = unused for now
                    try
                    {
                        sp.openConnection();
                        lstcol.insert(sp);
                        sp.closeConnection();
                    }
                    catch
                    {
                        //todo
                    }
                }
                UserUiSettings.Invalidate(uuid, user);
            }

            //checks (and remove) from the list configuration columns that no longer exist
            {

                model.Load(100, requestValues, false); //100 should be enough
                List<Lstcol> current_List = new List<Lstcol>();
                foreach (var column in model.Menu.Elements)
                {

                    string areabase = idlistArea.ToLower() == column.ValTabela.ToLower() ? "" : column.ValTabela.ToLower() != idlistController.ToLower() ? char.ToUpper(column.ValTabela[0]) + column.ValTabela.Substring(1) + "." : "";
                    var mathing_column = listColumns.Where(x => x.BaseArea.ToUpper() == column.ValTabela.ToUpper() /*&& x.Description.ToUpper() == column.ValAlias.ToUpper()*/ && areabase + "Val" + char.ToUpper(x.FieldName[0]) + x.FieldName.Substring(1) == column.ValCampo).FirstOrDefault();//removed description, this caused unwanted duplication if descriptions were changed.
                    if (mathing_column != null)
                    {
                        if(mathing_column.Description.ToUpper() != column.ValAlias.ToUpper())
                            column.ValAlias = mathing_column.Description;
                        current_List.Add(column);
                    }
                }
                model.Menu.Elements = current_List;
            }
            return PartialView(partialView, model);
        }
        
        #endregion
    }
}
