using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Lnhpd;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHPD]/

namespace GenioMVC.Controllers
{
	public partial class LnhpdController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHPD_CANCEL = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Cancel", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHPD_SHOW = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Show", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHPD_NEW = new NavigationLocation("ORDER_LINE50035", "Lnhpd_New", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHPD_EDIT = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Edit", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHPD_DUPLICATE = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Duplicate", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHPD_DELETE = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Delete", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DELETE" };

		#endregion

		#region Lnhpd private

		private void FormHistoryLimits_Lnhpd()
		{

		}

		#endregion

		public ActionResult Lnhpd_ModalDBEdit()
		{
			Lnhpd_ViewModel model = new Lnhpd_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Lnhpd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHPD]/

		[HttpPost]
		public ActionResult Lnhpd_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Show_GET",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHPD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lnhpd_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_New_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHPD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lnhpd/Lnhpd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_New([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_New",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
					//FOR: ROW_REORDERING
					string tableName = Navigation.GetStrValue("TableName");
					string tableViewModelName = Navigation.GetStrValue("TableViewModelName");

					Type tableViewModelType = Type.GetType("GenioMVC.ViewModels." + tableName + "." + tableViewModelName);
					if (tableViewModelType != null)
					{
						dynamic tableViewModel = Activator.CreateInstance(tableViewModelType, this.UserContext.Current);
						if (tableViewModel != null)
						{
							User u = UserContext.Current.User;
							var row = CSGenioAlnhpd.search(sp, model.ValCodlnhpd, u);

							var orderField = model.ValLine;
							int orderFieldValue = Convert.ToInt32(orderField);

							int maxOrder = 0;
							try
							{
								maxOrder = sp.GetMaxFieldValue(Area.AreaLNHPD, CSGenioAlnhpd.FldLine, tableViewModel.baseConditions, tableViewModel.relations);
							}
							catch (Exception ex)
							{
								Log.Error(ex.Message);
							}

							if (maxOrder > 0 && orderFieldValue > maxOrder)
								model.ValLine = orderFieldValue = maxOrder + 1;

							row.Reorder_Line(sp, orderFieldValue - 1, tableViewModel.baseConditions, tableViewModel.relations, false);
						}
					}

// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHPD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lnhpd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Edit_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHPD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lnhpd/Lnhpd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Edit([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Edit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHPD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lnhpd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Delete_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHPD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lnhpd/Lnhpd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Delete",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
					//FOR: ROW_REORDERING
					string tableName = Navigation.GetStrValue("TableName");
					string tableViewModelName = Navigation.GetStrValue("TableViewModelName");

					Type tableViewModelType = Type.GetType("GenioMVC.ViewModels." + tableName + "." + tableViewModelName);
					if (tableViewModelType != null)
					{
						dynamic tableViewModel = Activator.CreateInstance(tableViewModelType, this.UserContext.Current);
						if (tableViewModel != null)
							sp.ReorderSequence(CSGenio.business.Area.AreaLNHPD, CSGenioAlnhpd.FldLine, tableViewModel.baseConditions, tableViewModel.relations);
					}
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHPD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lnhpd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}

		#endregion

		#region Lnhpd_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHPD]/

		[HttpPost]
		public ActionResult Lnhpd_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Duplicate_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHPD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lnhpd/Lnhpd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Duplicate([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Duplicate",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHPD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lnhpd_Cancel

		//
		// GET: /Lnhpd/Lnhpd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHPD]/
		public ActionResult Lnhpd_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhpd(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");

// USE /[MANUAL GQT BEFORE_CANCEL LNHPD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHPD]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_lnhpd", "true", true);
			}

			Navigation.ClearValue("lnhpd");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Lnhpd Multiform actions

		//
		// GET /Lnhpd/MFLnhpd_New
		[HttpGet]
		[ActionName("MFLnhpd_New")]
		public ActionResult MFLnhpd_New()
		{
			var model = new Lnhpd_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LNHPD_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("lnhpd", model.ValCodlnhpd);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return JsonOK(model);
		}

		[HttpPost]
		public ActionResult MFLnhpd_New_GET()
		{
			return MFLnhpd_New();
		}

		//
		// GET /Lnhpd/MFLnhpd_Edit
		[HttpGet]
		[ActionName("MFLnhpd_Edit")]
		public ActionResult MFLnhpd_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("LNHPD", "EDIT", new { id = id, partialView = "MFLnhpd", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFLnhpd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFLnhpd_Edit(requestModel);
		}

		//
		// GET /Lnhpd/MFLnhpd_Cancel
		[ActionName("MFLnhpd_Cancel")]
		public ActionResult MFLnhpd_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Lnhpd(UserContext.Current);
				model.klass.QPrimaryKey = id;

				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				ClearMessages();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				return JsonERROR(exceptionUserMessage);
			}

			return JsonOK(new { Success = true });
		}

		//
		// POST /Lnhpd/MFLnhpd_Save
		[HttpPost]
		[ActionName("MFLnhpd_Save")]
		public JsonResult MFLnhpd_Save(Lnhpd_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhpd_Save",
				ViewName = "MFLnhpd",
				AreaName = "lnhpd"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Lnhpd/MFLnhpd_Delete
		[HttpPost]
		[ActionName("MFLnhpd_Delete")]
		public JsonResult MFLnhpd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhpd_Delete",
				ViewName = "MFLnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_EDIT
			};

			var model = new Lnhpd_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Lnhpd/Lnhpd_PedidValNrpedido
		// POST: /Lnhpd/Lnhpd_PedidValNrpedido
		[ActionName("Lnhpd_PedidValNrpedido")]
		public ActionResult Lnhpd_PedidValNrpedido([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pedid")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pedid");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Lnhpd_PedidValNrpedido_ViewModel model = new Lnhpd_PedidValNrpedido_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlnhpd = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Lnhpd/Lnhpd_TpequValTipoequi
		// POST: /Lnhpd/Lnhpd_TpequValTipoequi
		[ActionName("Lnhpd_TpequValTipoequi")]
		public ActionResult Lnhpd_TpequValTipoequi([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Lnhpd_TpequValTipoequi_ViewModel model = new Lnhpd_TpequValTipoequi_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlnhpd = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_CONJUNTO([FromBody]RequestCargaModel requestModel)
		{
			var idsrc = requestModel.Idsrc;
			var iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Lnhpd.Find(iddst, UserContext.Current).carga_CONJUNTO(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 });
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return JsonERROR();
			}
		}

		#endregion

		//
		// GET: /Lnhpd/Lnhpd_ValDesconju
		// POST: /Lnhpd/Lnhpd_ValDesconju
		[ActionName("Lnhpd_ValDesconju")]
		public ActionResult Lnhpd_ValDesconju([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Lnhpd_ValDesconju_ViewModel model = new Lnhpd_ValDesconju_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlnhpd = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Lnhpd/Lnhpd_ValDesagreg
		// POST: /Lnhpd/Lnhpd_ValDesagreg
		[ActionName("Lnhpd_ValDesagreg")]
		public ActionResult Lnhpd_ValDesagreg([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Lnhpd_ValDesagreg_ViewModel model = new Lnhpd_ValDesagreg_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlnhpd = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Lnhpd/Lnhpd_SaveEdit
		[HttpPost]
		public ActionResult Lnhpd_SaveEdit([FromBody]Lnhpd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_SaveEdit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHPD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
