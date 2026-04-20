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
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Lendi;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
	public partial class LendiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_COMOD_CANCEL = new("CANCELAR49513", "Comod_Cancel", "Lendi") { vueRouteName = "form-COMOD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_COMOD_SHOW = new("CONSULTA40695", "Comod_Show", "Lendi") { vueRouteName = "form-COMOD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_COMOD_NEW = new("INSERIR43365", "Comod_New", "Lendi") { vueRouteName = "form-COMOD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_COMOD_EDIT = new("EDITAR11616", "Comod_Edit", "Lendi") { vueRouteName = "form-COMOD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_COMOD_DUPLICATE = new("DUPLICAR09748", "Comod_Duplicate", "Lendi") { vueRouteName = "form-COMOD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_COMOD_DELETE = new("APAGAR04097", "Comod_Delete", "Lendi") { vueRouteName = "form-COMOD", mode = "DELETE" };

		#endregion

		#region Comod private

		private void FormHistoryLimits_Comod()
		{

		}

		#endregion

		#region Comod_Show

// USE /[MANUAL GQT CONTROLLER_SHOW COMOD]/

		[HttpPost]
		public ActionResult Comod_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comod_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comod_Show_GET",
				AreaName = "lendi",
				Location = ACTION_COMOD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW COMOD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Comod_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Comod_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comod_New_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW COMOD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lendi/Comod_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_New([FromBody]Comod_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comod_New",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX COMOD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Comod_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comod_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comod_Edit_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT COMOD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lendi/Comod_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Edit([FromBody]Comod_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comod_Edit",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX COMOD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Comod_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comod_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comod_Delete_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE COMOD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lendi/Comod_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comod_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Comod_Delete",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE COMOD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Comod_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("COMOD");
		}

		#endregion

		#region Comod_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET COMOD]/

		[HttpPost]
		public ActionResult Comod_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Comod_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comod_Duplicate_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE COMOD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lendi/Comod_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Duplicate([FromBody]Comod_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comod_Duplicate",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX COMOD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Comod_Cancel

		//
		// GET: /Lendi/Comod_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET COMOD]/
		public ActionResult Comod_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("lendi");
					var model = GenioMVC.Models.Lendi.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("lendi");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL COMOD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL COMOD]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_lendi", "true", true);
			}

			Navigation.ClearValue("lendi");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Comod_Pess1ValNameModel : RequestLookupModel
		{
			public Comod_ViewModel Model { get; set; }
		}

		//
		// GET: /Lendi/Comod_Pess1ValName
		// POST: /Lendi/Comod_Pess1ValName
		[ActionName("Comod_Pess1ValName")]
		public ActionResult Comod_Pess1ValName([FromBody] Comod_Pess1ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess1");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Lendi parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Comod_Pess1ValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Comod_Pess2ValNameModel : RequestLookupModel
		{
			public Comod_ViewModel Model { get; set; }
		}

		//
		// GET: /Lendi/Comod_Pess2ValName
		// POST: /Lendi/Comod_Pess2ValName
		[ActionName("Comod_Pess2ValName")]
		public ActionResult Comod_Pess2ValName([FromBody] Comod_Pess2ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess2")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess2");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Lendi parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Comod_Pess2ValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Comod_EquipValRegistnrModel : RequestLookupModel
		{
			public Comod_ViewModel Model { get; set; }
		}

		//
		// GET: /Lendi/Comod_EquipValRegistnr
		// POST: /Lendi/Comod_EquipValRegistnr
		[ActionName("Comod_EquipValRegistnr")]
		public ActionResult Comod_EquipValRegistnr([FromBody] Comod_EquipValRegistnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Lendi parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Comod_EquipValRegistnr_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Lendi/Comod_SaveEdit
		[HttpPost]
		public ActionResult Comod_SaveEdit([FromBody] Comod_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comod_SaveEdit",
				ViewName = "Comod",
				AreaName = "lendi",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT COMOD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ComodDocumValidateTickets : RequestDocumValidateTickets
		{
			public Comod_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsComod([FromBody] ComodDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
