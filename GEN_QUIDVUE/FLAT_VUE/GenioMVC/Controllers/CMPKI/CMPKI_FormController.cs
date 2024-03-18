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
using GenioMVC.ViewModels.Cmpki;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPKI]/

namespace GenioMVC.Controllers
{
	public partial class CmpkiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CMPKI_CANCEL = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_Cancel", "Cmpki") { vueRouteName = "form-CMPKI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CMPKI_SHOW = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_Show", "Cmpki") { vueRouteName = "form-CMPKI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CMPKI_NEW = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_New", "Cmpki") { vueRouteName = "form-CMPKI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CMPKI_EDIT = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_Edit", "Cmpki") { vueRouteName = "form-CMPKI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CMPKI_DUPLICATE = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_Duplicate", "Cmpki") { vueRouteName = "form-CMPKI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CMPKI_DELETE = new NavigationLocation("KIT_COMPONENT05829", "Cmpki_Delete", "Cmpki") { vueRouteName = "form-CMPKI", mode = "DELETE" };

		#endregion

		#region Cmpki private

		private void FormHistoryLimits_Cmpki()
		{

		}

		#endregion

		public ActionResult Cmpki_ModalDBEdit()
		{
			Cmpki_ViewModel model = new Cmpki_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cmpki_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CMPKI]/

		[HttpPost]
		public ActionResult Cmpki_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Show_GET",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CMPKI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Cmpki_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_New_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CMPKI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cmpki/Cmpki_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_New([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_New",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_NEW,
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
							var row = CSGenioAcmpki.search(sp, model.ValCodcmpki, u);

							var orderField = model.ValOrder;
							int orderFieldValue = Convert.ToInt32(orderField);

							int maxOrder = 0;
							try
							{
								maxOrder = sp.GetMaxFieldValue(Area.AreaCMPKI, CSGenioAcmpki.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
							}
							catch (Exception ex)
							{
								Log.Error(ex.Message);
							}

							if (maxOrder > 0 && orderFieldValue > maxOrder)
								model.ValOrder = orderFieldValue = maxOrder + 1;

							row.Reorder_Order(sp, orderFieldValue - 1, tableViewModel.baseConditions, tableViewModel.relations, false);
						}
					}

// USE /[MANUAL GQT BEFORE_SAVE_NEW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CMPKI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Cmpki_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Edit_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CMPKI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cmpki/Cmpki_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Edit([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Edit",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CMPKI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Cmpki_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Delete_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CMPKI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cmpki/Cmpki_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Delete",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CMPKI]/
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
							sp.ReorderSequence(CSGenio.business.Area.AreaCMPKI, CSGenioAcmpki.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
					}
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CMPKI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Cmpki_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CMPKI");
		}

		#endregion

		#region Cmpki_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CMPKI]/

		[HttpPost]
		public ActionResult Cmpki_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Duplicate_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CMPKI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cmpki/Cmpki_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Duplicate([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Duplicate",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CMPKI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Cmpki_Cancel

		//
		// GET: /Cmpki/Cmpki_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CMPKI]/
		public ActionResult Cmpki_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpki(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpki");

// USE /[MANUAL GQT BEFORE_CANCEL CMPKI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CMPKI]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpki", "true", true);
			}

			Navigation.ClearValue("cmpki");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Cmpki Multiform actions

		//
		// GET /Cmpki/MFCmpki_New
		[HttpGet]
		[ActionName("MFCmpki_New")]
		public ActionResult MFCmpki_New()
		{
			var model = new Cmpki_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_CMPKI_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("cmpki", model.ValCodcmpki);

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
		public ActionResult MFCmpki_New_GET()
		{
			return MFCmpki_New();
		}

		//
		// GET /Cmpki/MFCmpki_Edit
		[HttpGet]
		[ActionName("MFCmpki_Edit")]
		public ActionResult MFCmpki_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("CMPKI", "EDIT", new { id = id, partialView = "MFCmpki", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFCmpki_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFCmpki_Edit(requestModel);
		}

		//
		// GET /Cmpki/MFCmpki_Cancel
		[ActionName("MFCmpki_Cancel")]
		public ActionResult MFCmpki_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Cmpki(UserContext.Current);
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
		// POST /Cmpki/MFCmpki_Save
		[HttpPost]
		[ActionName("MFCmpki_Save")]
		public JsonResult MFCmpki_Save(Cmpki_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFCmpki_Save",
				ViewName = "MFCmpki",
				AreaName = "cmpki"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Cmpki/MFCmpki_Delete
		[HttpPost]
		[ActionName("MFCmpki_Delete")]
		public JsonResult MFCmpki_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFCmpki_Delete",
				ViewName = "MFCmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_EDIT
			};

			var model = new Cmpki_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Cmpki/Cmpki_TpequValTipoequi
		// POST: /Cmpki/Cmpki_TpequValTipoequi
		[ActionName("Cmpki_TpequValTipoequi")]
		public ActionResult Cmpki_TpequValTipoequi([FromBody]RequestLookupModel requestModel)
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
			Cmpki_TpequValTipoequi_ViewModel model = new Cmpki_TpequValTipoequi_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodcmpki = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Cmpki/Cmpki_Tpeq1ValTipoequi
		// POST: /Cmpki/Cmpki_Tpeq1ValTipoequi
		[ActionName("Cmpki_Tpeq1ValTipoequi")]
		public ActionResult Cmpki_Tpeq1ValTipoequi([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpeq1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpeq1");
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
			Cmpki_Tpeq1ValTipoequi_ViewModel model = new Cmpki_Tpeq1ValTipoequi_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodcmpki = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Cmpki/Cmpki_SaveEdit
		[HttpPost]
		public ActionResult Cmpki_SaveEdit([FromBody]Cmpki_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_SaveEdit",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CMPKI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
