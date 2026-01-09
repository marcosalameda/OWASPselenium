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
using GenioMVC.ViewModels.Insta;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER INSTA]/

namespace GenioMVC.Controllers
{
	public partial class InstaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LEAFLETT_CANCEL = new("INSTALLATION12952", "Leaflett_Cancel", "Insta") { vueRouteName = "form-LEAFLETT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LEAFLETT_SHOW = new("INSTALLATION12952", "Leaflett_Show", "Insta") { vueRouteName = "form-LEAFLETT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LEAFLETT_NEW = new("INSTALLATION12952", "Leaflett_New", "Insta") { vueRouteName = "form-LEAFLETT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LEAFLETT_EDIT = new("INSTALLATION12952", "Leaflett_Edit", "Insta") { vueRouteName = "form-LEAFLETT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LEAFLETT_DUPLICATE = new("INSTALLATION12952", "Leaflett_Duplicate", "Insta") { vueRouteName = "form-LEAFLETT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LEAFLETT_DELETE = new("INSTALLATION12952", "Leaflett_Delete", "Insta") { vueRouteName = "form-LEAFLETT", mode = "DELETE" };

		#endregion

		#region Leaflett private

		private void FormHistoryLimits_Leaflett()
		{

		}

		#endregion

		#region Leaflett_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LEAFLETT]/

		[HttpPost]
		public ActionResult Leaflett_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Leaflett_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Show_GET",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LEAFLETT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Leaflett_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Leaflett_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_New_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LEAFLETT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Insta/Leaflett_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_New([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_New",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Leaflett_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Leaflett_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Edit_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LEAFLETT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Insta/Leaflett_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Edit([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Edit",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Leaflett_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Leaflett_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Delete_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LEAFLETT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Insta/Leaflett_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Leaflett_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Delete",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LEAFLETT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Leaflett_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LEAFLETT");
		}

		#endregion

		#region Leaflett_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LEAFLETT]/

		[HttpPost]
		public ActionResult Leaflett_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Leaflett_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Duplicate_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LEAFLETT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Insta/Leaflett_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Duplicate([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_Duplicate",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Leaflett_Cancel

		//
		// GET: /Insta/Leaflett_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LEAFLETT]/
		public ActionResult Leaflett_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Insta model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("insta");

// USE /[MANUAL GQT BEFORE_CANCEL LEAFLETT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LEAFLETT]/

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

				Navigation.SetValue("ForcePrimaryRead_insta", "true", true);
			}

			Navigation.ClearValue("insta");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Leaflett_EquipValRegistnrModel : RequestLookupModel
		{
			public Leaflett_ViewModel Model { get; set; }
		}

		//
		// GET: /Insta/Leaflett_EquipValRegistnr
		// POST: /Insta/Leaflett_EquipValRegistnr
		[ActionName("Leaflett_EquipValRegistnr")]
		public ActionResult Leaflett_EquipValRegistnr([FromBody] Leaflett_EquipValRegistnrModel requestModel)
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

			Models.Insta parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Leaflett_EquipValRegistnr_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Insta/Leaflett_SaveEdit
		[HttpPost]
		public ActionResult Leaflett_SaveEdit([FromBody] Leaflett_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Leaflett_SaveEdit",
				ViewName = "Leaflett",
				AreaName = "insta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LEAFLETT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class LeaflettDocumValidateTickets : RequestDocumValidateTickets
		{
			public Leaflett_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsLeaflett([FromBody] LeaflettDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
