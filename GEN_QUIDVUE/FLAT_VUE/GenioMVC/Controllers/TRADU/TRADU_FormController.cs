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
using GenioMVC.ViewModels.Tradu;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TRADU]/

namespace GenioMVC.Controllers
{
	public partial class TraduController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TRADU_CANCEL = new("TRADUCOES14996", "Tradu_Cancel", "Tradu") { vueRouteName = "form-TRADU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TRADU_SHOW = new("TRADUCOES14996", "Tradu_Show", "Tradu") { vueRouteName = "form-TRADU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TRADU_NEW = new("TRADUCOES14996", "Tradu_New", "Tradu") { vueRouteName = "form-TRADU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TRADU_EDIT = new("TRADUCOES14996", "Tradu_Edit", "Tradu") { vueRouteName = "form-TRADU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TRADU_DUPLICATE = new("TRADUCOES14996", "Tradu_Duplicate", "Tradu") { vueRouteName = "form-TRADU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TRADU_DELETE = new("TRADUCOES14996", "Tradu_Delete", "Tradu") { vueRouteName = "form-TRADU", mode = "DELETE" };

		#endregion

		#region Tradu private

		private void FormHistoryLimits_Tradu()
		{

		}

		#endregion

		#region Tradu_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TRADU]/

		[HttpPost]
		public ActionResult Tradu_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tradu_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Show_GET",
				AreaName = "tradu",
				Location = ACTION_TRADU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tradu();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TRADU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tradu_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TRADU]/
		[HttpPost]
		public ActionResult Tradu_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Tradu_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tradu_New_GET",
				AreaName = "tradu",
				FormName = "TRADU",
				Location = ACTION_TRADU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tradu();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TRADU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tradu/Tradu_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TRADU]/
		[HttpPost]
		public ActionResult Tradu_New([FromBody]Tradu_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tradu_New",
				ViewName = "Tradu",
				AreaName = "tradu",
				Location = ACTION_TRADU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TRADU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TRADU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TRADU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tradu_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TRADU]/
		[HttpPost]
		public ActionResult Tradu_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tradu_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Edit_GET",
				AreaName = "tradu",
				FormName = "TRADU",
				Location = ACTION_TRADU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tradu();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TRADU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tradu/Tradu_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TRADU]/
		[HttpPost]
		public ActionResult Tradu_Edit([FromBody]Tradu_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Edit",
				ViewName = "Tradu",
				AreaName = "tradu",
				Location = ACTION_TRADU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TRADU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TRADU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TRADU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tradu_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TRADU]/
		[HttpPost]
		public ActionResult Tradu_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tradu_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Delete_GET",
				AreaName = "tradu",
				FormName = "TRADU",
				Location = ACTION_TRADU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tradu();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TRADU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tradu/Tradu_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TRADU]/
		[HttpPost]
		public ActionResult Tradu_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tradu_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Tradu_Delete",
				ViewName = "Tradu",
				AreaName = "tradu",
				Location = ACTION_TRADU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TRADU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tradu_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TRADU");
		}

		#endregion

		#region Tradu_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TRADU]/

		[HttpPost]
		public ActionResult Tradu_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Tradu_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Duplicate_GET",
				AreaName = "tradu",
				FormName = "TRADU",
				Location = ACTION_TRADU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TRADU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tradu/Tradu_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TRADU]/
		[HttpPost]
		public ActionResult Tradu_Duplicate([FromBody]Tradu_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tradu_Duplicate",
				ViewName = "Tradu",
				AreaName = "tradu",
				Location = ACTION_TRADU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TRADU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TRADU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TRADU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tradu_Cancel

		//
		// GET: /Tradu/Tradu_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TRADU]/
		public ActionResult Tradu_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Tradu model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tradu");

// USE /[MANUAL GQT BEFORE_CANCEL TRADU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TRADU]/

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

				Navigation.SetValue("ForcePrimaryRead_tradu", "true", true);
			}

			Navigation.ClearValue("tradu");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tradu_Lang1ValLanguaModel : RequestLookupModel
		{
			public Tradu_ViewModel Model { get; set; }
		}

		//
		// GET: /Tradu/Tradu_Lang1ValLangua
		// POST: /Tradu/Tradu_Lang1ValLangua
		[ActionName("Tradu_Lang1ValLangua")]
		public ActionResult Tradu_Lang1ValLangua([FromBody] Tradu_Lang1ValLanguaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lang1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lang1");
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

			Models.Tradu parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tradu_Lang1ValLangua_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Tradu_Lang2ValLanguaModel : RequestLookupModel
		{
			public Tradu_ViewModel Model { get; set; }
		}

		//
		// GET: /Tradu/Tradu_Lang2ValLangua
		// POST: /Tradu/Tradu_Lang2ValLangua
		[ActionName("Tradu_Lang2ValLangua")]
		public ActionResult Tradu_Lang2ValLangua([FromBody] Tradu_Lang2ValLanguaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lang2")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lang2");
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

			Models.Tradu parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tradu_Lang2ValLangua_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tradu/Tradu_SaveEdit
		[HttpPost]
		public ActionResult Tradu_SaveEdit([FromBody] Tradu_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tradu_SaveEdit",
				ViewName = "Tradu",
				AreaName = "tradu",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TRADU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TRADU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TraduDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tradu_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTradu([FromBody] TraduDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
