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
using GenioMVC.ViewModels.Esppe;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ESPPE]/

namespace GenioMVC.Controllers
{
	public partial class EsppeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ESPPE_CANCEL = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_Cancel", "Esppe") { vueRouteName = "form-ESPPE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ESPPE_SHOW = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_Show", "Esppe") { vueRouteName = "form-ESPPE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ESPPE_NEW = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_New", "Esppe") { vueRouteName = "form-ESPPE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ESPPE_EDIT = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_Edit", "Esppe") { vueRouteName = "form-ESPPE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ESPPE_DUPLICATE = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_Duplicate", "Esppe") { vueRouteName = "form-ESPPE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ESPPE_DELETE = new NavigationLocation("PERSON_SPECIALTY62734", "Esppe_Delete", "Esppe") { vueRouteName = "form-ESPPE", mode = "DELETE" };

		#endregion

		#region Esppe private

		private void FormHistoryLimits_Esppe()
		{

		}

		#endregion

		public ActionResult Esppe_ModalDBEdit()
		{
			Esppe_ViewModel model = new Esppe_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Esppe_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ESPPE]/

		[HttpPost]
		public ActionResult Esppe_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Esppe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Show_GET",
				AreaName = "esppe",
				Location = ACTION_ESPPE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Esppe();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ESPPE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Esppe_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ESPPE]/
		[HttpPost]
		public ActionResult Esppe_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Esppe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_New_GET",
				AreaName = "esppe",
				FormName = "ESPPE",
				Location = ACTION_ESPPE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Esppe();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ESPPE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Esppe/Esppe_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ESPPE]/
		[HttpPost]
		public ActionResult Esppe_New([FromBody]Esppe_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_New",
				ViewName = "Esppe",
				AreaName = "esppe",
				Location = ACTION_ESPPE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ESPPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ESPPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ESPPE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Esppe_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ESPPE]/
		[HttpPost]
		public ActionResult Esppe_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Esppe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Edit_GET",
				AreaName = "esppe",
				FormName = "ESPPE",
				Location = ACTION_ESPPE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Esppe();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ESPPE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Esppe/Esppe_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ESPPE]/
		[HttpPost]
		public ActionResult Esppe_Edit([FromBody]Esppe_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Edit",
				ViewName = "Esppe",
				AreaName = "esppe",
				Location = ACTION_ESPPE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ESPPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ESPPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ESPPE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Esppe_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ESPPE]/
		[HttpPost]
		public ActionResult Esppe_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Esppe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Delete_GET",
				AreaName = "esppe",
				FormName = "ESPPE",
				Location = ACTION_ESPPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Esppe();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ESPPE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Esppe/Esppe_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ESPPE]/
		[HttpPost]
		public ActionResult Esppe_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Esppe_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Delete",
				ViewName = "Esppe",
				AreaName = "esppe",
				Location = ACTION_ESPPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ESPPE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Esppe_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ESPPE");
		}

		#endregion

		#region Esppe_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ESPPE]/

		[HttpPost]
		public ActionResult Esppe_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Esppe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Duplicate_GET",
				AreaName = "esppe",
				FormName = "ESPPE",
				Location = ACTION_ESPPE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ESPPE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Esppe/Esppe_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ESPPE]/
		[HttpPost]
		public ActionResult Esppe_Duplicate([FromBody]Esppe_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_Duplicate",
				ViewName = "Esppe",
				AreaName = "esppe",
				Location = ACTION_ESPPE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ESPPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ESPPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ESPPE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Esppe_Cancel

		//
		// GET: /Esppe/Esppe_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ESPPE]/
		public ActionResult Esppe_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Esppe(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("esppe");

// USE /[MANUAL GQT BEFORE_CANCEL ESPPE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ESPPE]/

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

				Navigation.SetValue("ForcePrimaryRead_esppe", "true", true);
			}

			Navigation.ClearValue("esppe");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Esppe Multiform actions

		//
		// GET /Esppe/MFEsppe_New
		[HttpGet]
		[ActionName("MFEsppe_New")]
		public ActionResult MFEsppe_New()
		{
			var model = new Esppe_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ESPPE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("esppe", model.ValCodesppe);

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
		public ActionResult MFEsppe_New_GET()
		{
			return MFEsppe_New();
		}

		//
		// GET /Esppe/MFEsppe_Edit
		[HttpGet]
		[ActionName("MFEsppe_Edit")]
		public ActionResult MFEsppe_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ESPPE", "EDIT", new { id = id, partialView = "MFEsppe", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEsppe_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEsppe_Edit(requestModel);
		}

		//
		// GET /Esppe/MFEsppe_Cancel
		[ActionName("MFEsppe_Cancel")]
		public ActionResult MFEsppe_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Esppe(UserContext.Current);
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
		// POST /Esppe/MFEsppe_Save
		[HttpPost]
		[ActionName("MFEsppe_Save")]
		public JsonResult MFEsppe_Save(Esppe_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEsppe_Save",
				ViewName = "MFEsppe",
				AreaName = "esppe"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Esppe/MFEsppe_Delete
		[HttpPost]
		[ActionName("MFEsppe_Delete")]
		public JsonResult MFEsppe_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEsppe_Delete",
				ViewName = "MFEsppe",
				AreaName = "esppe",
				Location = ACTION_ESPPE_EDIT
			};

			var model = new Esppe_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Esppe/Esppe_PessoValName
		// POST: /Esppe/Esppe_PessoValName
		[ActionName("Esppe_PessoValName")]
		public ActionResult Esppe_PessoValName([FromBody]RequestLookupModel requestModel)
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
			Esppe_PessoValName_ViewModel model = new Esppe_PessoValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodesppe = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Esppe/Esppe_SpeciValEspecial
		// POST: /Esppe/Esppe_SpeciValEspecial
		[ActionName("Esppe_SpeciValEspecial")]
		public ActionResult Esppe_SpeciValEspecial([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_speci")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_speci");
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
			Esppe_SpeciValEspecial_ViewModel model = new Esppe_SpeciValEspecial_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodesppe = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Esppe/Esppe_SaveEdit
		[HttpPost]
		public ActionResult Esppe_SaveEdit([FromBody]Esppe_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Esppe_SaveEdit",
				ViewName = "Esppe",
				AreaName = "esppe",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ESPPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ESPPE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
