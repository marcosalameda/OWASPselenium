using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Lstusr;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using Quidgest.Persistence.GenericQuery;
using System.Globalization;
using System.Web.Routing;

namespace GenioMVC.Controllers.SpecialRendering
{
    public class SpecialRenderingController : ControllerBase
    {
        // GET: /SpecialRendering/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeListProperties(string idlist, string idlistController, string idlistArea, string codlista)
        {
            // To support both menu lists (with primary key) and table lists (no key)
            codlista = string.IsNullOrEmpty(codlista) ? idlist : codlista;

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstusr.FldDescric, codlista)
                .Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAlstusr.FldZzstate, 0))
                .FirstOrDefault();

            ListPropertiesViewModel viewModel = new ListPropertiesViewModel();

            if (model == null)
            {
                model = new CSGenioAlstusr(user)
                {
                    ValCodpsw = user.Codpsw,
                    ValIdlist = idlist,
                    ValModulo = user.CurrentModule,
                    ValSistema = Configuration.Program,
                    ValDescric = codlista
                };

                sp.openConnection();
                model.insert(sp);
                sp.closeConnection();

                TableUiSettingsDbRec.Invalidate(model.ValDescric, user);

                viewModel.FormMode = "1";
            }
            else
                viewModel.FormMode = "2";

            Navigation.SetValue("idlist", idlist);
            Navigation.SetValue("idlistController", idlistController);
            Navigation.SetValue("idlistArea", idlistArea);

            string action = Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription();
            CSGenio.framework.Audit.registAction(UserContext.Current.User, action);

            Navigation.SetValue("lstusr", model.ValCodlstusr);
            viewModel.Navigation = Navigation;
            viewModel.MapFromModel(model);

            return PartialView("ChangeViewMode", viewModel);
        }

        #region GridTableList Virtual Form Methods

        // PostMapping("/SpecialRendering/EditRendering")
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult EditRendering(SpecialRenderingViewModel model, FormCollection collection)
        {
            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                if (!ModelState.IsValid)
                    throw new BusinessException (
                        Resources.Resources.NAO_E_POSSIVEL_GRAVA23775,
                        "EditRendering",
                        "Model is in invalid state"
                    );

                sp.openTransaction();
                model.Save();
                sp.closeTransaction();

                return Json(new
                {
                    Success = true,
                    Key = model.ValCodlstren,
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
                    Key = model.ValCodlstren,
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
					Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
        }

        [AuthorizeForUsers]
        [ActionName("Lstusr_ValLstcol")]
        public ActionResult Lstusr_ValLstcol(string id, string partialView)
        {
            NameValueCollection requestValues = Request.Form;

            MenuRenderingViewModel vm = new MenuRenderingViewModel(Navigation);
            vm.ValCodlstusr = id;

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            RouteValueDictionary routeValueDictionary =
                HtmlHelper.AnonymousObjectToHtmlAttributes(Navigation.CurrentLevel.Location.RoutedValues);

            string idlist = (string)(routeValueDictionary["idlist"] ?? Navigation.CurrentLevel.GetEntry("idlist"));
            string idlistController = (string)(routeValueDictionary["idlistController"] ?? Navigation.CurrentLevel.GetEntry("idlistController"));
			var cfg = GetViewModesCfg(idlist, idlistController);

            InitLstren(cfg, user, sp, id, idlist, idlistController);
            RemoveUnknownViewModes(cfg, vm, requestValues);

            return PartialView(partialView, vm);
        }

        // PostMapping("/SpecialRendering/Save")
        [HttpPost]
        public ActionResult Save(ListPropertiesViewModel viewModel)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            if (!ModelState.IsValid)
            {
                Navigation.SetValue("lstusr", viewModel.ValCodlstusr);

                viewModel.Navigation = Navigation;
                Navigation.RemoveHistoryLevel();
                return PartialView(viewModel);
            }

            sp.openConnection();

            CSGenioAlstusr model = CSGenioAlstusr
                .searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstusr.FldCodlstusr, viewModel.ValCodlstusr)
                .Equal(CSGenioAlstusr.FldZzstate, 0))
                .FirstOrDefault();

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
                TableUiSettingsDbRec.Invalidate(model.ValDescric, user);
                Navigation.RemoveHistoryLevel();
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

        // PostMapping("/SpecialRendering/ToggleViewMode")
        [HttpPost]
        public ActionResult ToggleViewMode(string idlist, string idlistController, string idlistArea, string codlista, int target = 1)
        {
            // target = 1: to list
            // target = 2: to alternative view mode (e.g., cards)

            // To support both menu lists (with primary key) and table lists (no key)
            codlista = string.IsNullOrEmpty(codlista) ? idlist : codlista;
			var cfg = GetViewModesCfg(idlist, idlistController);
			
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            CSGenioAlstusr lstusr = GetLstusr(sp, user, codlista, idlist);
            InitLstren(cfg, user, sp, lstusr.ValCodlstusr, idlist, idlistController);

            sp.openConnection();

            List<CSGenioAlstren> lstrens = CSGenioAlstren.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstren.FldCodlstusr, lstusr.ValCodlstusr));

            foreach (CSGenioAlstren lstren in lstrens)
            {
                if (lstren.ValRenderizacao == "LIST")
                    lstren.ValVisivel = target == 1 ? 1 : 0;
                else
                    lstren.ValVisivel = target == 1 ? 0 : 1;

                lstren.update(sp);
            }
            sp.closeConnection();

            TableUiSettingsDbRec.Invalidate(lstusr.ValDescric, user);

            var location = Navigation.CurrentLevel.Location;
            return Json(new { Success = true, Operation = "ToggleViewMode", newURL = Url.Action(location.Action, location.Controller) });
        }

        // PostMapping("/SpecialRendering/ResetViewModes")
        [HttpPost]
        [HttpParamAction]
        public JsonResult ResetViewModes(string codlstusr)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            CSGenioAlstusr lstusr = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAlstusr.FldCodlstusr, codlstusr)
                .Equal(CSGenioAlstusr.FldZzstate, 0))
                .FirstOrDefault();

            ListPropertiesViewModel viewModel = new ListPropertiesViewModel();

            viewModel.FormMode = "2";
            viewModel.Navigation = Navigation;
            viewModel.MapFromModel(lstusr);

            // Deletes and refreshes view modes
            List<CSGenioAlstren> models = CSGenioAlstren.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstren.FldCodlstusr, codlstusr)
                .Equal(CSGenioAlstren.FldZzstate, 0));

            if (models != null)
            {
                sp.openConnection();

                foreach (var model in models)
                    model.delete(sp);

                sp.closeConnection();

                TableUiSettingsDbRec.Invalidate(lstusr.ValDescric, user);
            }

            return new JsonResult() { Data = new { success = true, loading = false } };
        }

        #endregion

        #region Auxiliary  methods

        private void InitLstren(SpecialRenderingsCfg cfg, User user, PersistentSupport sp, string codlstusr, string idlist, string idlistController)
        {
            string uuid = GetViewModelUUID(idlist, idlistController);
			
            // User preferences (might not exist yet)
            List<CSGenioAlstren> userRenderings = TableUiSettingsDbRec.Load(sp, uuid, user).UserRenderings;

            // Inserts new view modes that are not present in the current user configuration
            int pos = 1;
            if (userRenderings != null && userRenderings.Count > 0)
            {
                bool different = false;
                foreach (GenioMVC.SpecialRendering viewMode in cfg.SpecialRenderings)
                {
                    // Attempt to find it in the current user configuration
                    CSGenioAlstren match = userRenderings
                        .FirstOrDefault(x => x.ValRenderizacao.ToUpper() == viewMode.Id.ToUpper());

                    if (match == null)
                    {
                        // Will need to invalidate cache
                        different = true;

                        CSGenioAlstren lstren = new CSGenioAlstren(user)
                        {
                            ValCodlstusr = codlstusr,
                            ValRenderizacao = viewMode.Id,
                            ValPosicao = pos,

                            // New view mode hidden by default
                            ValVisivel = 0
                        };

                        sp.openConnection();
                        lstren.insert(sp);
                        sp.closeConnection();
                    }

                    pos++;
                }

                if (different)
                {
                    TableUiSettingsDbRec.Invalidate(uuid, user);
                    userRenderings = TableUiSettingsDbRec.Load(sp, uuid, user).UserRenderings;
                }
            }
            else
            {
                // User configuration did not exist, load defaults
                LoadDefaultConfiguration(cfg, user, sp, codlstusr, idlist, uuid);
            }
        }

        private void LoadDefaultConfiguration(SpecialRenderingsCfg cfg, User user, PersistentSupport sp, string codlstusr, string idlist, string uuid)
        {
            bool first = true;

            foreach (GenioMVC.SpecialRendering sr in cfg.SpecialRenderings)
            {
                CSGenioAlstren lstren = new CSGenioAlstren(user)
                {
                    ValCodlstusr = codlstusr,
                    ValRenderizacao = sr.Id,
                    ValPosicao = sr.Ordem,
                    ValVisivel = first ? 1 : 0
                };

                first = false;

                sp.openConnection();
                lstren.insert(sp);
                sp.closeConnection();
            }

            TableUiSettingsDbRec.Invalidate(uuid, user);
        }

        // Check (and remove) view mode configurations that no longer exist
        private void RemoveUnknownViewModes(SpecialRenderingsCfg cfg, MenuRenderingViewModel vm, NameValueCollection requestValues)
        {
            // User preferences (might contain view modes that no longer exist in the definition)
            vm.Load(100, requestValues, false);

            List<Lstren> currentList = new List<Lstren>();
            foreach (var viewMode in vm.lstren.Elements)
            {
                var match = cfg.SpecialRenderings
                    .FirstOrDefault(x => x.Id.ToUpper() == viewMode.ValRenderizacao.ToUpper());

                if (match != null)
                    currentList.Add(viewMode);
            }

            vm.lstren.Elements = currentList;
        }

        private ListViewModel GetViewModel(string idlist, string idlistController)
        {
            string viewModelNameSpace = string.IsNullOrEmpty(idlistController)
                ? "GenioMVC.ViewModels"
                : string.Format("GenioMVC.ViewModels.{0}", idlistController);

            string fullyQualifiedViewModelName = string.Format("{0}.{1}_ViewModel", viewModelNameSpace, idlist);

            var viewmodelType = Type.GetType(fullyQualifiedViewModelName, false, true);
            return (ListViewModel)Activator.CreateInstance(viewmodelType, new object[] { new NavigationContext() });
        }

        private string GetViewModelUUID(string idlist, string idlistController)
        {
            ListViewModel vm = GetViewModel(idlist, idlistController);
            return vm.Uuid;
        }
		
		private SpecialRenderingsCfg GetViewModesCfg(string idlist, string idlistController)
        {
            ListViewModel vm = GetViewModel(idlist, idlistController);
            return vm.ViewModesCfg;
        }

        private CSGenioAlstusr GetLstusr(PersistentSupport sp, User user, string codlista, string idlist)
        {
            CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstusr.FldDescric, codlista)
                .Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAlstusr.FldZzstate, 0))
                .FirstOrDefault();

            if (model == null)
            {
                model = new CSGenioAlstusr(user)
                {
                    ValCodpsw = user.Codpsw,
                    ValIdlist = idlist,
                    ValModulo = user.CurrentModule,
                    ValSistema = Configuration.Program,
                    ValDescric = codlista
                };

                sp.openConnection();
                model.insert(sp);
                sp.closeConnection();
            }

            return model;
        }

        #endregion
    }
}
