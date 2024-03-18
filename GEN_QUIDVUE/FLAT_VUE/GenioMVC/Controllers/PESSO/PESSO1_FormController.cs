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
using GenioMVC.ViewModels.Pesso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
	public partial class PessoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESSO1_CANCEL = new NavigationLocation("PERSON10446", "Pesso1_Cancel", "Pesso") { vueRouteName = "form-PESSO1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSO1_SHOW = new NavigationLocation("PERSON10446", "Pesso1_Show", "Pesso") { vueRouteName = "form-PESSO1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSO1_NEW = new NavigationLocation("PERSON10446", "Pesso1_New", "Pesso") { vueRouteName = "form-PESSO1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSO1_EDIT = new NavigationLocation("PERSON10446", "Pesso1_Edit", "Pesso") { vueRouteName = "form-PESSO1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSO1_DUPLICATE = new NavigationLocation("PERSON10446", "Pesso1_Duplicate", "Pesso") { vueRouteName = "form-PESSO1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSO1_DELETE = new NavigationLocation("PERSON10446", "Pesso1_Delete", "Pesso") { vueRouteName = "form-PESSO1", mode = "DELETE" };

		#endregion

		#region Pesso1 private

		private void FormHistoryLimits_Pesso1()
		{

		}

		#endregion

		public ActionResult Pesso1_ModalDBEdit()
		{
			Pesso1_ViewModel model = new Pesso1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Pesso1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSO1]/

		[HttpPost]
		public ActionResult Pesso1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Show_GET",
				AreaName = "pesso",
				Location = ACTION_PESSO1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSO1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pesso1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pesso1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_New_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSO1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Pesso1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_New([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_New",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSO1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pesso1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Edit_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSO1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Edit([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Edit",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSO1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pesso1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Delete_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSO1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Delete",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSO1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pesso1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSO1");
		}

		#endregion

		#region Pesso1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSO1]/

		[HttpPost]
		public ActionResult Pesso1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pesso1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Duplicate_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSO1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Pesso1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Duplicate([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_Duplicate",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSO1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pesso1_Cancel

		//
		// GET: /Pesso/Pesso1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSO1]/
		public ActionResult Pesso1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pesso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");

// USE /[MANUAL GQT BEFORE_CANCEL PESSO1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSO1]/

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

				Navigation.SetValue("ForcePrimaryRead_pesso", "true", true);
			}

			Navigation.ClearValue("pesso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Pesso1 Multiform actions

		//
		// GET /Pesso/MFPesso1_New
		[HttpGet]
		[ActionName("MFPesso1_New")]
		public ActionResult MFPesso1_New()
		{
			var model = new Pesso1_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PESSO1_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("pesso", model.ValCodpesso);

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
		public ActionResult MFPesso1_New_GET()
		{
			return MFPesso1_New();
		}

		//
		// GET /Pesso/MFPesso1_Edit
		[HttpGet]
		[ActionName("MFPesso1_Edit")]
		public ActionResult MFPesso1_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PESSO1", "EDIT", new { id = id, partialView = "MFPesso1", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPesso1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPesso1_Edit(requestModel);
		}

		//
		// GET /Pesso/MFPesso1_Cancel
		[ActionName("MFPesso1_Cancel")]
		public ActionResult MFPesso1_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Pesso(UserContext.Current);
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
		// POST /Pesso/MFPesso1_Save
		[HttpPost]
		[ActionName("MFPesso1_Save")]
		public JsonResult MFPesso1_Save(Pesso1_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPesso1_Save",
				ViewName = "MFPesso1",
				AreaName = "pesso"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Pesso/MFPesso1_Delete
		[HttpPost]
		[ActionName("MFPesso1_Delete")]
		public JsonResult MFPesso1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPesso1_Delete",
				ViewName = "MFPesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_EDIT
			};

			var model = new Pesso1_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Pesso/Pesso1_CategValCategoria
		// POST: /Pesso/Pesso1_CategValCategoria
		[ActionName("Pesso1_CategValCategoria")]
		public ActionResult Pesso1_CategValCategoria([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_categ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_categ");
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
			Pesso1_CategValCategoria_ViewModel model = new Pesso1_CategValCategoria_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pesso/Pesso1_ValContacto
		// POST: /Pesso/Pesso1_ValContacto
		[ActionName("Pesso1_ValContacto")]
		public ActionResult Pesso1_ValContacto([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_conta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_conta");
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

			Pesso1_ValContacto_ViewModel model = new Pesso1_ValContacto_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pesso/Pesso1_CmpnyValDesignat
		// POST: /Pesso/Pesso1_CmpnyValDesignat
		[ActionName("Pesso1_CmpnyValDesignat")]
		public ActionResult Pesso1_CmpnyValDesignat([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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
			Pesso1_CmpnyValDesignat_ViewModel model = new Pesso1_CmpnyValDesignat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pesso/Pesso1_ValEvolucao
		// POST: /Pesso/Pesso1_ValEvolucao
		[ActionName("Pesso1_ValEvolucao")]
		public ActionResult Pesso1_ValEvolucao([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_evcat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_evcat");
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

			Pesso1_ValEvolucao_ViewModel model = new Pesso1_ValEvolucao_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pesso/Pesso1_Regi1ValRegiao
		// POST: /Pesso/Pesso1_Regi1ValRegiao
		[ActionName("Pesso1_Regi1ValRegiao")]
		public ActionResult Pesso1_Regi1ValRegiao([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regi1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regi1");
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
			Pesso1_Regi1ValRegiao_ViewModel model = new Pesso1_Regi1ValRegiao_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pesso/Pesso1_SaveEdit
		[HttpPost]
		public ActionResult Pesso1_SaveEdit([FromBody]Pesso1_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso1_SaveEdit",
				ViewName = "Pesso1",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSO1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
