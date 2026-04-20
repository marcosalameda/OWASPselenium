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
using GenioMVC.ViewModels.Repar;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REPAR]/

namespace GenioMVC.Controllers
{
	public partial class ReparController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REPAR_CANCEL = new("REPAIR34508", "Repar_Cancel", "Repar") { vueRouteName = "form-REPAR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REPAR_SHOW = new("REPAIR34508", "Repar_Show", "Repar") { vueRouteName = "form-REPAR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REPAR_NEW = new("REPAIR34508", "Repar_New", "Repar") { vueRouteName = "form-REPAR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REPAR_EDIT = new("REPAIR34508", "Repar_Edit", "Repar") { vueRouteName = "form-REPAR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REPAR_DUPLICATE = new("REPAIR34508", "Repar_Duplicate", "Repar") { vueRouteName = "form-REPAR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REPAR_DELETE = new("REPAIR34508", "Repar_Delete", "Repar") { vueRouteName = "form-REPAR", mode = "DELETE" };

		#endregion

		#region Repar private

		private void FormHistoryLimits_Repar()
		{

		}

		#endregion

		#region Repar_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REPAR]/

		[HttpPost]
		public ActionResult Repar_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Repar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Repar_Show_GET",
				AreaName = "repar",
				Location = ACTION_REPAR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REPAR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Repar_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Repar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Repar_New_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REPAR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Repar/Repar_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_New([FromBody]Repar_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Repar_New",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REPAR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Repar_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Repar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Repar_Edit_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REPAR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Repar/Repar_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Edit([FromBody]Repar_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Repar_Edit",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REPAR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Repar_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Repar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Repar_Delete_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REPAR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Repar/Repar_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Repar_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Repar_Delete",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REPAR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Repar_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}

		#endregion

		#region Repar_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REPAR]/

		[HttpPost]
		public ActionResult Repar_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Repar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Repar_Duplicate_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REPAR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Repar/Repar_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Duplicate([FromBody]Repar_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Repar_Duplicate",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REPAR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Repar_Cancel

		//
		// GET: /Repar/Repar_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REPAR]/
		public ActionResult Repar_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("repar");
					var model = GenioMVC.Models.Repar.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("repar");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL REPAR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REPAR]/

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

				Navigation.SetValue("ForcePrimaryRead_repar", "true", true);
			}

			Navigation.ClearValue("repar");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Repar_EquipValRegistnrModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_EquipValRegistnr
		// POST: /Repar/Repar_EquipValRegistnr
		[ActionName("Repar_EquipValRegistnr")]
		public ActionResult Repar_EquipValRegistnr([FromBody] Repar_EquipValRegistnrModel requestModel)
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

			Models.Repar parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_EquipValRegistnr_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Repar_SpeciValEspecialModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_SpeciValEspecial
		// POST: /Repar/Repar_SpeciValEspecial
		[ActionName("Repar_SpeciValEspecial")]
		public ActionResult Repar_SpeciValEspecial([FromBody] Repar_SpeciValEspecialModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_speci")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_speci");
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

			Models.Repar parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_SpeciValEspecial_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			// Map received value to field - The 'field' type limit
			model.ValTipoarea = Navigation.GetValue<string>("repar.tipoarea");
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Repar_PessoValNameModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_PessoValName
		// POST: /Repar/Repar_PessoValName
		[ActionName("Repar_PessoValName")]
		public ActionResult Repar_PessoValName([FromBody] Repar_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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

			Models.Repar parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_PessoValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Repar/Repar_SaveEdit
		[HttpPost]
		public ActionResult Repar_SaveEdit([FromBody] Repar_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Repar_SaveEdit",
				ViewName = "Repar",
				AreaName = "repar",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REPAR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ReparDocumValidateTickets : RequestDocumValidateTickets
		{
			public Repar_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRepar([FromBody] ReparDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
