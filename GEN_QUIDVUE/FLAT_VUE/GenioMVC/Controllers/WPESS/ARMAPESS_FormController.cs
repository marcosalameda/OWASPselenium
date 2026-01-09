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
using GenioMVC.ViewModels.Wpess;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WPESS]/

namespace GenioMVC.Controllers
{
	public partial class WpessController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARMAPESS_CANCEL = new("PERSON10446", "Armapess_Cancel", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARMAPESS_SHOW = new("PERSON10446", "Armapess_Show", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARMAPESS_NEW = new("PERSON10446", "Armapess_New", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARMAPESS_EDIT = new("PERSON10446", "Armapess_Edit", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARMAPESS_DUPLICATE = new("PERSON10446", "Armapess_Duplicate", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARMAPESS_DELETE = new("PERSON10446", "Armapess_Delete", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "DELETE" };

		#endregion

		#region Armapess private

		private void FormHistoryLimits_Armapess()
		{

		}

		#endregion

		#region Armapess_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARMAPESS]/

		[HttpPost]
		public ActionResult Armapess_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armapess_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Show_GET",
				AreaName = "wpess",
				Location = ACTION_ARMAPESS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armapess();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARMAPESS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Armapess_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Armapess_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armapess_New_GET",
				AreaName = "wpess",
				FormName = "ARMAPESS",
				Location = ACTION_ARMAPESS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Armapess();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARMAPESS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wpess/Armapess_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_New([FromBody]Armapess_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armapess_New",
				ViewName = "Armapess",
				AreaName = "wpess",
				Location = ACTION_ARMAPESS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARMAPESS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARMAPESS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARMAPESS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Armapess_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armapess_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Edit_GET",
				AreaName = "wpess",
				FormName = "ARMAPESS",
				Location = ACTION_ARMAPESS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armapess();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARMAPESS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wpess/Armapess_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_Edit([FromBody]Armapess_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Edit",
				ViewName = "Armapess",
				AreaName = "wpess",
				Location = ACTION_ARMAPESS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARMAPESS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARMAPESS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARMAPESS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Armapess_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armapess_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Delete_GET",
				AreaName = "wpess",
				FormName = "ARMAPESS",
				Location = ACTION_ARMAPESS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armapess();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARMAPESS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wpess/Armapess_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armapess_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Armapess_Delete",
				ViewName = "Armapess",
				AreaName = "wpess",
				Location = ACTION_ARMAPESS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARMAPESS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Armapess_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARMAPESS");
		}

		#endregion

		#region Armapess_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARMAPESS]/

		[HttpPost]
		public ActionResult Armapess_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Armapess_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Duplicate_GET",
				AreaName = "wpess",
				FormName = "ARMAPESS",
				Location = ACTION_ARMAPESS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARMAPESS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wpess/Armapess_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARMAPESS]/
		[HttpPost]
		public ActionResult Armapess_Duplicate([FromBody]Armapess_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armapess_Duplicate",
				ViewName = "Armapess",
				AreaName = "wpess",
				Location = ACTION_ARMAPESS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARMAPESS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARMAPESS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARMAPESS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Armapess_Cancel

		//
		// GET: /Wpess/Armapess_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARMAPESS]/
		public ActionResult Armapess_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Wpess model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");

// USE /[MANUAL GQT BEFORE_CANCEL ARMAPESS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARMAPESS]/

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

				Navigation.SetValue("ForcePrimaryRead_wpess", "true", true);
			}

			Navigation.ClearValue("wpess");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Armapess_WarehValWarehdesModel : RequestLookupModel
		{
			public Armapess_ViewModel Model { get; set; }
		}

		//
		// GET: /Wpess/Armapess_WarehValWarehdes
		// POST: /Wpess/Armapess_WarehValWarehdes
		[ActionName("Armapess_WarehValWarehdes")]
		public ActionResult Armapess_WarehValWarehdes([FromBody] Armapess_WarehValWarehdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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

			Models.Wpess parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Armapess_WarehValWarehdes_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Wpess/Armapess_SaveEdit
		[HttpPost]
		public ActionResult Armapess_SaveEdit([FromBody] Armapess_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armapess_SaveEdit",
				ViewName = "Armapess",
				AreaName = "wpess",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARMAPESS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARMAPESS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ArmapessDocumValidateTickets : RequestDocumValidateTickets
		{
			public Armapess_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArmapess([FromBody] ArmapessDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
