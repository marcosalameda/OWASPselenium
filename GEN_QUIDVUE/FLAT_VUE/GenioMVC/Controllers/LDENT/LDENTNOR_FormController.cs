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
using GenioMVC.ViewModels.Ldent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LDENT]/

namespace GenioMVC.Controllers
{
	public partial class LdentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LDENTNOR_CANCEL = new NavigationLocation("ENTRY29068", "Ldentnor_Cancel", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LDENTNOR_SHOW = new NavigationLocation("ENTRY29068", "Ldentnor_Show", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LDENTNOR_NEW = new NavigationLocation("ENTRY29068", "Ldentnor_New", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LDENTNOR_EDIT = new NavigationLocation("ENTRY29068", "Ldentnor_Edit", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LDENTNOR_DUPLICATE = new NavigationLocation("ENTRY29068", "Ldentnor_Duplicate", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LDENTNOR_DELETE = new NavigationLocation("ENTRY29068", "Ldentnor_Delete", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "DELETE" };

		#endregion

		#region Ldentnor private

		private void FormHistoryLimits_Ldentnor()
		{

		}

		#endregion

		public ActionResult Ldentnor_ModalDBEdit()
		{
			Ldentnor_ViewModel model = new Ldentnor_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Ldentnor_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LDENTNOR]/

		[HttpPost]
		public ActionResult Ldentnor_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Show_GET",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LDENTNOR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ldentnor_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_New_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LDENTNOR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Ldent/Ldentnor_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_New([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_New",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_NEW,
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
							var row = CSGenioAldent.search(sp, model.ValCodldent, u);

							var orderField = model.ValLine;
							int orderFieldValue = Convert.ToInt32(orderField);

							int maxOrder = 0;
							try
							{
								maxOrder = sp.GetMaxFieldValue(Area.AreaLDENT, CSGenioAldent.FldLine, tableViewModel.baseConditions, tableViewModel.relations);
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

// USE /[MANUAL GQT BEFORE_SAVE_NEW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ldentnor_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Edit_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LDENTNOR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldentnor_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Edit([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Edit",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ldentnor_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Delete_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LDENTNOR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldentnor_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Delete",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LDENTNOR]/
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
							sp.ReorderSequence(CSGenio.business.Area.AreaLDENT, CSGenioAldent.FldLine, tableViewModel.baseConditions, tableViewModel.relations);
					}
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LDENTNOR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ldentnor_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LDENTNOR");
		}

		#endregion

		#region Ldentnor_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LDENTNOR]/

		[HttpPost]
		public ActionResult Ldentnor_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Duplicate_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LDENTNOR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Ldent/Ldentnor_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Duplicate([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Duplicate",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ldentnor_Cancel

		//
		// GET: /Ldent/Ldentnor_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LDENTNOR]/
		public ActionResult Ldentnor_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ldent(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");

// USE /[MANUAL GQT BEFORE_CANCEL LDENTNOR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LDENTNOR]/

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

				Navigation.SetValue("ForcePrimaryRead_ldent", "true", true);
			}

			Navigation.ClearValue("ldent");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Ldentnor Multiform actions

		//
		// GET /Ldent/MFLdentnor_New
		[HttpGet]
		[ActionName("MFLdentnor_New")]
		public ActionResult MFLdentnor_New()
		{
			var model = new Ldentnor_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LDENTNOR_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("ldent", model.ValCodldent);

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
		public ActionResult MFLdentnor_New_GET()
		{
			return MFLdentnor_New();
		}

		//
		// GET /Ldent/MFLdentnor_Edit
		[HttpGet]
		[ActionName("MFLdentnor_Edit")]
		public ActionResult MFLdentnor_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("LDENTNOR", "EDIT", new { id = id, partialView = "MFLdentnor", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFLdentnor_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFLdentnor_Edit(requestModel);
		}

		//
		// GET /Ldent/MFLdentnor_Cancel
		[ActionName("MFLdentnor_Cancel")]
		public ActionResult MFLdentnor_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Ldent(UserContext.Current);
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
		// POST /Ldent/MFLdentnor_Save
		[HttpPost]
		[ActionName("MFLdentnor_Save")]
		public JsonResult MFLdentnor_Save(Ldentnor_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLdentnor_Save",
				ViewName = "MFLdentnor",
				AreaName = "ldent"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Ldent/MFLdentnor_Delete
		[HttpPost]
		[ActionName("MFLdentnor_Delete")]
		public JsonResult MFLdentnor_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFLdentnor_Delete",
				ViewName = "MFLdentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_EDIT
			};

			var model = new Ldentnor_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Ldent/Ldentnor_IndocValDocumenr
		// POST: /Ldent/Ldentnor_IndocValDocumenr
		[ActionName("Ldentnor_IndocValDocumenr")]
		public ActionResult Ldentnor_IndocValDocumenr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_indoc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_indoc");
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
			Ldentnor_IndocValDocumenr_ViewModel model = new Ldentnor_IndocValDocumenr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodldent = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Ldent/Ldentnor_WarehValWarehdes
		// POST: /Ldent/Ldentnor_WarehValWarehdes
		[ActionName("Ldentnor_WarehValWarehdes")]
		public ActionResult Ldentnor_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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
			Ldentnor_WarehValWarehdes_ViewModel model = new Ldentnor_WarehValWarehdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodldent = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Ldent/Ldentnor_ItemValItemdes
		// POST: /Ldent/Ldentnor_ItemValItemdes
		[ActionName("Ldentnor_ItemValItemdes")]
		public ActionResult Ldentnor_ItemValItemdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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
			Ldentnor_ItemValItemdes_ViewModel model = new Ldentnor_ItemValItemdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodldent = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Ldent/Ldentnor_SaveEdit
		[HttpPost]
		public ActionResult Ldentnor_SaveEdit([FromBody]Ldentnor_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_SaveEdit",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LDENTNOR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
