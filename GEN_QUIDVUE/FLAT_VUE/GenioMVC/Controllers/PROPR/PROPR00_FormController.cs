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
using GenioMVC.ViewModels.Propr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPR]/

namespace GenioMVC.Controllers
{
	public partial class ProprController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROPR00_CANCEL = new NavigationLocation("_PROPR__NAME_39336", "Propr00_Cancel", "Propr") { vueRouteName = "form-PROPR00", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPR00_SHOW = new NavigationLocation("_PROPR__NAME_39336", "Propr00_Show", "Propr") { vueRouteName = "form-PROPR00", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPR00_NEW = new NavigationLocation("_PROPR__NAME_39336", "Propr00_New", "Propr") { vueRouteName = "form-PROPR00", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPR00_EDIT = new NavigationLocation("_PROPR__NAME_39336", "Propr00_Edit", "Propr") { vueRouteName = "form-PROPR00", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPR00_DUPLICATE = new NavigationLocation("_PROPR__NAME_39336", "Propr00_Duplicate", "Propr") { vueRouteName = "form-PROPR00", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPR00_DELETE = new NavigationLocation("_PROPR__NAME_39336", "Propr00_Delete", "Propr") { vueRouteName = "form-PROPR00", mode = "DELETE" };

		#endregion

		#region Propr00 private

		private void FormHistoryLimits_Propr00()
		{

		}

		#endregion

		public ActionResult Propr00_ModalDBEdit()
		{
			Propr00_ViewModel model = new Propr00_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Propr00_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPR00]/

		[HttpPost]
		public ActionResult Propr00_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Propr00_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Show_GET",
				AreaName = "propr",
				Location = ACTION_PROPR00_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Propr00();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPR00]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Propr00_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPR00]/
		[HttpPost]
		public ActionResult Propr00_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Propr00_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_New_GET",
				AreaName = "propr",
				FormName = "PROPR00",
				Location = ACTION_PROPR00_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Propr00();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPR00]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Propr/Propr00_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPR00]/
		[HttpPost]
		public ActionResult Propr00_New([FromBody]Propr00_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_New",
				ViewName = "Propr00",
				AreaName = "propr",
				Location = ACTION_PROPR00_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPR00]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPR00]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPR00]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Propr00_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPR00]/
		[HttpPost]
		public ActionResult Propr00_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Propr00_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Edit_GET",
				AreaName = "propr",
				FormName = "PROPR00",
				Location = ACTION_PROPR00_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Propr00();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPR00]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Propr/Propr00_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPR00]/
		[HttpPost]
		public ActionResult Propr00_Edit([FromBody]Propr00_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Edit",
				ViewName = "Propr00",
				AreaName = "propr",
				Location = ACTION_PROPR00_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPR00]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPR00]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPR00]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Propr00_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPR00]/
		[HttpPost]
		public ActionResult Propr00_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Propr00_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Delete_GET",
				AreaName = "propr",
				FormName = "PROPR00",
				Location = ACTION_PROPR00_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Propr00();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPR00]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Propr/Propr00_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPR00]/
		[HttpPost]
		public ActionResult Propr00_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Propr00_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Delete",
				ViewName = "Propr00",
				AreaName = "propr",
				Location = ACTION_PROPR00_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPR00]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Propr00_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPR00");
		}

		#endregion

		#region Propr00_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPR00]/

		[HttpPost]
		public ActionResult Propr00_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Propr00_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Duplicate_GET",
				AreaName = "propr",
				FormName = "PROPR00",
				Location = ACTION_PROPR00_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPR00]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Propr/Propr00_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPR00]/
		[HttpPost]
		public ActionResult Propr00_Duplicate([FromBody]Propr00_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_Duplicate",
				ViewName = "Propr00",
				AreaName = "propr",
				Location = ACTION_PROPR00_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPR00]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPR00]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPR00]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Propr00_Cancel

		//
		// GET: /Propr/Propr00_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPR00]/
		public ActionResult Propr00_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Propr(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("propr");

// USE /[MANUAL GQT BEFORE_CANCEL PROPR00]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPR00]/

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

				Navigation.SetValue("ForcePrimaryRead_propr", "true", true);
			}

			Navigation.ClearValue("propr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Propr00 Multiform actions

		//
		// GET /Propr/MFPropr00_New
		[HttpGet]
		[ActionName("MFPropr00_New")]
		public ActionResult MFPropr00_New()
		{
			var model = new Propr00_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PROPR00_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("propr", model.ValCodpropr);

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
		public ActionResult MFPropr00_New_GET()
		{
			return MFPropr00_New();
		}

		//
		// GET /Propr/MFPropr00_Edit
		[HttpGet]
		[ActionName("MFPropr00_Edit")]
		public ActionResult MFPropr00_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PROPR00", "EDIT", new { id = id, partialView = "MFPropr00", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPropr00_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPropr00_Edit(requestModel);
		}

		//
		// GET /Propr/MFPropr00_Cancel
		[ActionName("MFPropr00_Cancel")]
		public ActionResult MFPropr00_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Propr(UserContext.Current);
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
		// POST /Propr/MFPropr00_Save
		[HttpPost]
		[ActionName("MFPropr00_Save")]
		public JsonResult MFPropr00_Save(Propr00_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPropr00_Save",
				ViewName = "MFPropr00",
				AreaName = "propr"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Propr/MFPropr00_Delete
		[HttpPost]
		[ActionName("MFPropr00_Delete")]
		public JsonResult MFPropr00_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPropr00_Delete",
				ViewName = "MFPropr00",
				AreaName = "propr",
				Location = ACTION_PROPR00_EDIT
			};

			var model = new Propr00_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Propr/Propr00_TpproValTppropri
		// POST: /Propr/Propr00_TpproValTppropri
		[ActionName("Propr00_TpproValTppropri")]
		public ActionResult Propr00_TpproValTppropri([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tppro")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tppro");
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
			Propr00_TpproValTppropri_ViewModel model = new Propr00_TpproValTppropri_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpropr = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Propr/Propr00_PessoValName
		// POST: /Propr/Propr00_PessoValName
		[ActionName("Propr00_PessoValName")]
		public ActionResult Propr00_PessoValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
			Propr00_PessoValName_ViewModel model = new Propr00_PessoValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpropr = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Propr/Propr01_CntryValCountry
		// POST: /Propr/Propr01_CntryValCountry
		[ActionName("Propr01_CntryValCountry")]
		public ActionResult Propr01_CntryValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
			Propr01_CntryValCountry_ViewModel model = new Propr01_CntryValCountry_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpropr = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Propr/Propr01_RegioValRegiao
		// POST: /Propr/Propr01_RegioValRegiao
		[ActionName("Propr01_RegioValRegiao")]
		public ActionResult Propr01_RegioValRegiao([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regio");
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
			Propr01_RegioValRegiao_ViewModel model = new Propr01_RegioValRegiao_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpropr = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Propr/Propr00_SaveEdit
		[HttpPost]
		public ActionResult Propr00_SaveEdit([FromBody]Propr00_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Propr00_SaveEdit",
				ViewName = "Propr00",
				AreaName = "propr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPR00]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPR00]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
