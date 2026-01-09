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
using GenioMVC.ViewModels.Itemc;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEMC]/

namespace GenioMVC.Controllers
{
	public partial class ItemcController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATAR_CANCEL = new("ARTICLE_CATEGORIZATI07119", "Catar_Cancel", "Itemc") { vueRouteName = "form-CATAR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATAR_SHOW = new("ARTICLE_CATEGORIZATI07119", "Catar_Show", "Itemc") { vueRouteName = "form-CATAR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATAR_NEW = new("ARTICLE_CATEGORIZATI07119", "Catar_New", "Itemc") { vueRouteName = "form-CATAR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATAR_EDIT = new("ARTICLE_CATEGORIZATI07119", "Catar_Edit", "Itemc") { vueRouteName = "form-CATAR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATAR_DUPLICATE = new("ARTICLE_CATEGORIZATI07119", "Catar_Duplicate", "Itemc") { vueRouteName = "form-CATAR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATAR_DELETE = new("ARTICLE_CATEGORIZATI07119", "Catar_Delete", "Itemc") { vueRouteName = "form-CATAR", mode = "DELETE" };

		#endregion

		#region Catar private

		private void FormHistoryLimits_Catar()
		{

		}

		#endregion

		#region Catar_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CATAR]/

		[HttpPost]
		public ActionResult Catar_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Catar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Catar_Show_GET",
				AreaName = "itemc",
				Location = ACTION_CATAR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Catar();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CATAR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Catar_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CATAR]/
		[HttpPost]
		public ActionResult Catar_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Catar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Catar_New_GET",
				AreaName = "itemc",
				FormName = "CATAR",
				Location = ACTION_CATAR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Catar();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CATAR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Itemc/Catar_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CATAR]/
		[HttpPost]
		public ActionResult Catar_New([FromBody]Catar_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Catar_New",
				ViewName = "Catar",
				AreaName = "itemc",
				Location = ACTION_CATAR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CATAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CATAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CATAR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Catar_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CATAR]/
		[HttpPost]
		public ActionResult Catar_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Catar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Catar_Edit_GET",
				AreaName = "itemc",
				FormName = "CATAR",
				Location = ACTION_CATAR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Catar();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CATAR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Itemc/Catar_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CATAR]/
		[HttpPost]
		public ActionResult Catar_Edit([FromBody]Catar_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Catar_Edit",
				ViewName = "Catar",
				AreaName = "itemc",
				Location = ACTION_CATAR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CATAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CATAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CATAR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Catar_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CATAR]/
		[HttpPost]
		public ActionResult Catar_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Catar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Catar_Delete_GET",
				AreaName = "itemc",
				FormName = "CATAR",
				Location = ACTION_CATAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Catar();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CATAR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Itemc/Catar_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CATAR]/
		[HttpPost]
		public ActionResult Catar_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Catar_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Catar_Delete",
				ViewName = "Catar",
				AreaName = "itemc",
				Location = ACTION_CATAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CATAR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Catar_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATAR");
		}

		#endregion

		#region Catar_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CATAR]/

		[HttpPost]
		public ActionResult Catar_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Catar_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Catar_Duplicate_GET",
				AreaName = "itemc",
				FormName = "CATAR",
				Location = ACTION_CATAR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CATAR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Itemc/Catar_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CATAR]/
		[HttpPost]
		public ActionResult Catar_Duplicate([FromBody]Catar_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Catar_Duplicate",
				ViewName = "Catar",
				AreaName = "itemc",
				Location = ACTION_CATAR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CATAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CATAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CATAR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Catar_Cancel

		//
		// GET: /Itemc/Catar_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CATAR]/
		public ActionResult Catar_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Itemc model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("itemc");

// USE /[MANUAL GQT BEFORE_CANCEL CATAR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CATAR]/

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

				Navigation.SetValue("ForcePrimaryRead_itemc", "true", true);
			}

			Navigation.ClearValue("itemc");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Catar_ItemValItemdesModel : RequestLookupModel
		{
			public Catar_ViewModel Model { get; set; }
		}

		//
		// GET: /Itemc/Catar_ItemValItemdes
		// POST: /Itemc/Catar_ItemValItemdes
		[ActionName("Catar_ItemValItemdes")]
		public ActionResult Catar_ItemValItemdes([FromBody] Catar_ItemValItemdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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

			Models.Itemc parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Catar_ItemValItemdes_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Catar_CattpValTpcategoModel : RequestLookupModel
		{
			public Catar_ViewModel Model { get; set; }
		}

		//
		// GET: /Itemc/Catar_CattpValTpcatego
		// POST: /Itemc/Catar_CattpValTpcatego
		[ActionName("Catar_CattpValTpcatego")]
		public ActionResult Catar_CattpValTpcatego([FromBody] Catar_CattpValTpcategoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cattp")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cattp");
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

			Models.Itemc parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Catar_CattpValTpcatego_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Itemc/Catar_SaveEdit
		[HttpPost]
		public ActionResult Catar_SaveEdit([FromBody] Catar_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Catar_SaveEdit",
				ViewName = "Catar",
				AreaName = "itemc",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CATAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CATAR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CatarDocumValidateTickets : RequestDocumValidateTickets
		{
			public Catar_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCatar([FromBody] CatarDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
