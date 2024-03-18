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
using GenioMVC.ViewModels.Tpequ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPEQU]/

namespace GenioMVC.Controllers
{
	public partial class TpequController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPEQU_CANCEL = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_Cancel", "Tpequ") { vueRouteName = "form-TPEQU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPEQU_SHOW = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_Show", "Tpequ") { vueRouteName = "form-TPEQU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPEQU_NEW = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_New", "Tpequ") { vueRouteName = "form-TPEQU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPEQU_EDIT = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_Edit", "Tpequ") { vueRouteName = "form-TPEQU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPEQU_DUPLICATE = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_Duplicate", "Tpequ") { vueRouteName = "form-TPEQU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPEQU_DELETE = new NavigationLocation("TYPE_OF_EQUIPMENT18080", "Tpequ_Delete", "Tpequ") { vueRouteName = "form-TPEQU", mode = "DELETE" };

		#endregion

		#region Tpequ private

		private void FormHistoryLimits_Tpequ()
		{

		}

		#endregion

		public ActionResult Tpequ_ModalDBEdit()
		{
			Tpequ_ViewModel model = new Tpequ_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Tpequ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPEQU]/

		[HttpPost]
		public ActionResult Tpequ_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Show_GET",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPEQU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tpequ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tpequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_New_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPEQU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tpequ/Tpequ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_New([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_New",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
					model.MapFromModel();
//Platform: MVC | Type: AFTER_SAVE_NEW | Module: GQT | Parameter: TPEQU | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:57efd9ed-6ccb-482f-961e-bf3a993ced4a
					var requestModel = new RequestCargaModel()
					{
						Idsrc = model.ValCodtpequ
					};

					GetCarga_unico(requestModel);
//END_MANUALCODE
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPEQU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tpequ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Edit_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPEQU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tpequ/Tpequ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Edit([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Edit",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPEQU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tpequ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Delete_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPEQU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tpequ/Tpequ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpequ_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Delete",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPEQU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tpequ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPEQU");
		}

		#endregion

		#region Tpequ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPEQU]/

		[HttpPost]
		public ActionResult Tpequ_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tpequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Duplicate_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPEQU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tpequ/Tpequ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Duplicate([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_Duplicate",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPEQU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tpequ_Cancel

		//
		// GET: /Tpequ/Tpequ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPEQU]/
		public ActionResult Tpequ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tpequ(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");

// USE /[MANUAL GQT BEFORE_CANCEL TPEQU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPEQU]/

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

				Navigation.SetValue("ForcePrimaryRead_tpequ", "true", true);
			}

			Navigation.ClearValue("tpequ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Tpequ Multiform actions

		//
		// GET /Tpequ/MFTpequ_New
		[HttpGet]
		[ActionName("MFTpequ_New")]
		public ActionResult MFTpequ_New()
		{
			var model = new Tpequ_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_TPEQU_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("tpequ", model.ValCodtpequ);

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
		public ActionResult MFTpequ_New_GET()
		{
			return MFTpequ_New();
		}

		//
		// GET /Tpequ/MFTpequ_Edit
		[HttpGet]
		[ActionName("MFTpequ_Edit")]
		public ActionResult MFTpequ_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("TPEQU", "EDIT", new { id = id, partialView = "MFTpequ", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFTpequ_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFTpequ_Edit(requestModel);
		}

		//
		// GET /Tpequ/MFTpequ_Cancel
		[ActionName("MFTpequ_Cancel")]
		public ActionResult MFTpequ_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Tpequ(UserContext.Current);
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
		// POST /Tpequ/MFTpequ_Save
		[HttpPost]
		[ActionName("MFTpequ_Save")]
		public JsonResult MFTpequ_Save(Tpequ_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFTpequ_Save",
				ViewName = "MFTpequ",
				AreaName = "tpequ"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Tpequ/MFTpequ_Delete
		[HttpPost]
		[ActionName("MFTpequ_Delete")]
		public JsonResult MFTpequ_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFTpequ_Delete",
				ViewName = "MFTpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_EDIT
			};

			var model = new Tpequ_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Tpequ/Tpequ_FamilValFamily
		// POST: /Tpequ/Tpequ_FamilValFamily
		[ActionName("Tpequ_FamilValFamily")]
		public ActionResult Tpequ_FamilValFamily([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_famil")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_famil");
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
			Tpequ_FamilValFamily_ViewModel model = new Tpequ_FamilValFamily_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Tpequ/Tpequ_ValComponen
		// POST: /Tpequ/Tpequ_ValComponen
		[ActionName("Tpequ_ValComponen")]
		public ActionResult Tpequ_ValComponen([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpki")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpki");
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

			Tpequ_ValComponen_ViewModel model = new Tpequ_ValComponen_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Tpequ/Tpequ_ValEvolucao
		// POST: /Tpequ/Tpequ_ValEvolucao
		[ActionName("Tpequ_ValEvolucao")]
		public ActionResult Tpequ_ValEvolucao([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tabpr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tabpr");
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

			Tpequ_ValEvolucao_ViewModel model = new Tpequ_ValEvolucao_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
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
		public ActionResult GetCarga_unico([FromBody]RequestCargaModel requestModel)
		{
			var idsrc = requestModel.Idsrc;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Tpequ.Find(idsrc, UserContext.Current).carga_unico(idsrc);
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
		// GET: /Tpequ/Tpequ_ValUnico
		// POST: /Tpequ/Tpequ_ValUnico
		[ActionName("Tpequ_ValUnico")]
		public ActionResult Tpequ_ValUnico([FromBody]RequestLookupModel requestModel)
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

			Tpequ_ValUnico_ViewModel model = new Tpequ_ValUnico_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Tpequ/Tpequ_ValInstalac
		// POST: /Tpequ/Tpequ_ValInstalac
		[ActionName("Tpequ_ValInstalac")]
		public ActionResult Tpequ_ValInstalac([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
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

			Tpequ_ValInstalac_ViewModel model = new Tpequ_ValInstalac_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Tpequ/Tpequ_ValInstala1
		// POST: /Tpequ/Tpequ_ValInstala1
		[ActionName("Tpequ_ValInstala1")]
		public ActionResult Tpequ_ValInstala1([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
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

			Tpequ_ValInstala1_ViewModel model = new Tpequ_ValInstala1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpequ = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tpequ/Tpequ_SaveEdit
		[HttpPost]
		public ActionResult Tpequ_SaveEdit([FromBody]Tpequ_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpequ_SaveEdit",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPEQU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
