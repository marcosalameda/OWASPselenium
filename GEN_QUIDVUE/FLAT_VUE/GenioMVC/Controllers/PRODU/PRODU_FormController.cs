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
using GenioMVC.ViewModels.Produ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PRODU]/

namespace GenioMVC.Controllers
{
	public partial class ProduController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PRODU_CANCEL = new NavigationLocation("PRODUCT12880", "Produ_Cancel", "Produ") { vueRouteName = "form-PRODU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PRODU_SHOW = new NavigationLocation("PRODUCT12880", "Produ_Show", "Produ") { vueRouteName = "form-PRODU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PRODU_NEW = new NavigationLocation("PRODUCT12880", "Produ_New", "Produ") { vueRouteName = "form-PRODU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PRODU_EDIT = new NavigationLocation("PRODUCT12880", "Produ_Edit", "Produ") { vueRouteName = "form-PRODU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PRODU_DUPLICATE = new NavigationLocation("PRODUCT12880", "Produ_Duplicate", "Produ") { vueRouteName = "form-PRODU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PRODU_DELETE = new NavigationLocation("PRODUCT12880", "Produ_Delete", "Produ") { vueRouteName = "form-PRODU", mode = "DELETE" };

		#endregion

		#region Produ private

		private void FormHistoryLimits_Produ()
		{

		}

		#endregion

		public ActionResult Produ_ModalDBEdit()
		{
			Produ_ViewModel model = new Produ_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Produ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PRODU]/

		[HttpPost]
		public ActionResult Produ_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Show_GET",
				AreaName = "produ",
				Location = ACTION_PRODU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PRODU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Produ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Produ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produ_New_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PRODU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Produ/Produ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_New([FromBody]Produ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produ_New",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PRODU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Produ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Edit_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PRODU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Produ/Produ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Edit([FromBody]Produ_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Edit",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PRODU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Produ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Delete_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PRODU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Produ/Produ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produ_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Produ_Delete",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PRODU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Produ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PRODU");
		}

		#endregion

		#region Produ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PRODU]/

		[HttpPost]
		public ActionResult Produ_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Produ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Duplicate_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PRODU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Produ/Produ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Duplicate([FromBody]Produ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produ_Duplicate",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PRODU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Produ_Cancel

		//
		// GET: /Produ/Produ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PRODU]/
		public ActionResult Produ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Produ(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("produ");

// USE /[MANUAL GQT BEFORE_CANCEL PRODU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PRODU]/

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

				Navigation.SetValue("ForcePrimaryRead_produ", "true", true);
			}

			Navigation.ClearValue("produ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Produ Multiform actions

		//
		// GET /Produ/MFProdu_New
		[HttpGet]
		[ActionName("MFProdu_New")]
		public ActionResult MFProdu_New()
		{
			var model = new Produ_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PRODU_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("produ", model.ValCodprodu);

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
		public ActionResult MFProdu_New_GET()
		{
			return MFProdu_New();
		}

		//
		// GET /Produ/MFProdu_Edit
		[HttpGet]
		[ActionName("MFProdu_Edit")]
		public ActionResult MFProdu_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PRODU", "EDIT", new { id = id, partialView = "MFProdu", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFProdu_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFProdu_Edit(requestModel);
		}

		//
		// GET /Produ/MFProdu_Cancel
		[ActionName("MFProdu_Cancel")]
		public ActionResult MFProdu_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Produ(UserContext.Current);
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
		// POST /Produ/MFProdu_Save
		[HttpPost]
		[ActionName("MFProdu_Save")]
		public JsonResult MFProdu_Save(Produ_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFProdu_Save",
				ViewName = "MFProdu",
				AreaName = "produ"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Produ/MFProdu_Delete
		[HttpPost]
		[ActionName("MFProdu_Delete")]
		public JsonResult MFProdu_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFProdu_Delete",
				ViewName = "MFProdu",
				AreaName = "produ",
				Location = ACTION_PRODU_EDIT
			};

			var model = new Produ_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Produ/Produ_LocatValGln
		// POST: /Produ/Produ_LocatValGln
		[ActionName("Produ_LocatValGln")]
		public ActionResult Produ_LocatValGln([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_locat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_locat");
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
			Produ_LocatValGln_ViewModel model = new Produ_LocatValGln_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodprodu = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Produ/Produ_LcextValGlnext
		// POST: /Produ/Produ_LcextValGlnext
		[ActionName("Produ_LcextValGlnext")]
		public ActionResult Produ_LcextValGlnext([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lcext")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lcext");
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
			Produ_LcextValGlnext_ViewModel model = new Produ_LcextValGlnext_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodprodu = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Produ/Produ_ValStockevo
		// POST: /Produ/Produ_ValStockevo
		[ActionName("Produ_ValStockevo")]
		public ActionResult Produ_ValStockevo([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_stock")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_stock");
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

			Produ_ValStockevo_ViewModel model = new Produ_ValStockevo_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodprodu = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Produ/Produ_ValInputsre
		// POST: /Produ/Produ_ValInputsre
		[ActionName("Produ_ValInputsre")]
		public ActionResult Produ_ValInputsre([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_relin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_relin");
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

			Produ_ValInputsre_ViewModel model = new Produ_ValInputsre_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodprodu = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Produ/Produ_ValOutputsd
		// POST: /Produ/Produ_ValOutputsd
		[ActionName("Produ_ValOutputsd")]
		public ActionResult Produ_ValOutputsd([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dilin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dilin");
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

			Produ_ValOutputsd_ViewModel model = new Produ_ValOutputsd_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodprodu = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Produ/Produ_SaveEdit
		[HttpPost]
		public ActionResult Produ_SaveEdit([FromBody]Produ_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produ_SaveEdit",
				ViewName = "Produ",
				AreaName = "produ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PRODU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
