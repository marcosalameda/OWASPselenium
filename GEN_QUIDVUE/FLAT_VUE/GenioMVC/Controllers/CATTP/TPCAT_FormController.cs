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
using GenioMVC.ViewModels.Cattp;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CATTP]/

namespace GenioMVC.Controllers
{
	public partial class CattpController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPCAT_CANCEL = new("CATEGORY_TYPE23058", "Tpcat_Cancel", "Cattp") { vueRouteName = "form-TPCAT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPCAT_SHOW = new("CATEGORY_TYPE23058", "Tpcat_Show", "Cattp") { vueRouteName = "form-TPCAT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPCAT_NEW = new("CATEGORY_TYPE23058", "Tpcat_New", "Cattp") { vueRouteName = "form-TPCAT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPCAT_EDIT = new("CATEGORY_TYPE23058", "Tpcat_Edit", "Cattp") { vueRouteName = "form-TPCAT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPCAT_DUPLICATE = new("CATEGORY_TYPE23058", "Tpcat_Duplicate", "Cattp") { vueRouteName = "form-TPCAT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPCAT_DELETE = new("CATEGORY_TYPE23058", "Tpcat_Delete", "Cattp") { vueRouteName = "form-TPCAT", mode = "DELETE" };

		#endregion

		#region Tpcat private

		private void FormHistoryLimits_Tpcat()
		{

		}

		#endregion

		#region Tpcat_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPCAT]/

		[HttpPost]
		public ActionResult Tpcat_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Show_GET",
				AreaName = "cattp",
				Location = ACTION_TPCAT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcat();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPCAT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tpcat_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tpcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_New_GET",
				AreaName = "cattp",
				FormName = "TPCAT",
				Location = ACTION_TPCAT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tpcat();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPCAT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cattp/Tpcat_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_New([FromBody]Tpcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_New",
				ViewName = "Tpcat",
				AreaName = "cattp",
				Location = ACTION_TPCAT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TPCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPCAT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tpcat_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Edit_GET",
				AreaName = "cattp",
				FormName = "TPCAT",
				Location = ACTION_TPCAT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcat();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPCAT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cattp/Tpcat_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_Edit([FromBody]Tpcat_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Edit",
				ViewName = "Tpcat",
				AreaName = "cattp",
				Location = ACTION_TPCAT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPCAT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tpcat_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Delete_GET",
				AreaName = "cattp",
				FormName = "TPCAT",
				Location = ACTION_TPCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcat();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPCAT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cattp/Tpcat_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcat_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Delete",
				ViewName = "Tpcat",
				AreaName = "cattp",
				Location = ACTION_TPCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPCAT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tpcat_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPCAT");
		}

		#endregion

		#region Tpcat_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPCAT]/

		[HttpPost]
		public ActionResult Tpcat_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tpcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Duplicate_GET",
				AreaName = "cattp",
				FormName = "TPCAT",
				Location = ACTION_TPCAT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPCAT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cattp/Tpcat_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPCAT]/
		[HttpPost]
		public ActionResult Tpcat_Duplicate([FromBody]Tpcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_Duplicate",
				ViewName = "Tpcat",
				AreaName = "cattp",
				Location = ACTION_TPCAT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPCAT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tpcat_Cancel

		//
		// GET: /Cattp/Tpcat_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPCAT]/
		public ActionResult Tpcat_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cattp(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cattp");

// USE /[MANUAL GQT BEFORE_CANCEL TPCAT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPCAT]/

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

				Navigation.SetValue("ForcePrimaryRead_cattp", "true", true);
			}

			Navigation.ClearValue("cattp");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tpcat_SbcatValSubcategModel : RequestLookupModel
		{
			public Tpcat_ViewModel Model { get; set; }
		}

		//
		// GET: /Cattp/Tpcat_SbcatValSubcateg
		// POST: /Cattp/Tpcat_SbcatValSubcateg
		[ActionName("Tpcat_SbcatValSubcateg")]
		public ActionResult Tpcat_SbcatValSubcateg([FromBody] Tpcat_SbcatValSubcategModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sbcat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sbcat");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Cattp parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Tpcat_SbcatValSubcateg_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}


		// POST: /Cattp/Tpcat_SaveEdit
		[HttpPost]
		public ActionResult Tpcat_SaveEdit([FromBody]Tpcat_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcat_SaveEdit",
				ViewName = "Tpcat",
				AreaName = "cattp",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPCAT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
