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
using GenioMVC.ViewModels.Evcat;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EVCAT]/

namespace GenioMVC.Controllers
{
	public partial class EvcatController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EVCAT_CANCEL = new("EVOLUTION_IN_THE_CAT03122", "Evcat_Cancel", "Evcat") { vueRouteName = "form-EVCAT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EVCAT_SHOW = new("EVOLUTION_IN_THE_CAT03122", "Evcat_Show", "Evcat") { vueRouteName = "form-EVCAT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EVCAT_NEW = new("EVOLUTION_IN_THE_CAT03122", "Evcat_New", "Evcat") { vueRouteName = "form-EVCAT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EVCAT_EDIT = new("EVOLUTION_IN_THE_CAT03122", "Evcat_Edit", "Evcat") { vueRouteName = "form-EVCAT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EVCAT_DUPLICATE = new("EVOLUTION_IN_THE_CAT03122", "Evcat_Duplicate", "Evcat") { vueRouteName = "form-EVCAT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EVCAT_DELETE = new("EVOLUTION_IN_THE_CAT03122", "Evcat_Delete", "Evcat") { vueRouteName = "form-EVCAT", mode = "DELETE" };

		#endregion

		#region Evcat private

		private void FormHistoryLimits_Evcat()
		{

		}

		#endregion

		#region Evcat_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EVCAT]/

		[HttpPost]
		public ActionResult Evcat_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Evcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Show_GET",
				AreaName = "evcat",
				Location = ACTION_EVCAT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Evcat();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EVCAT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Evcat_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EVCAT]/
		[HttpPost]
		public ActionResult Evcat_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Evcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_New_GET",
				AreaName = "evcat",
				FormName = "EVCAT",
				Location = ACTION_EVCAT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Evcat();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EVCAT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Evcat/Evcat_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EVCAT]/
		[HttpPost]
		public ActionResult Evcat_New([FromBody]Evcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_New",
				ViewName = "Evcat",
				AreaName = "evcat",
				Location = ACTION_EVCAT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EVCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EVCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EVCAT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Evcat_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EVCAT]/
		[HttpPost]
		public ActionResult Evcat_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Evcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Edit_GET",
				AreaName = "evcat",
				FormName = "EVCAT",
				Location = ACTION_EVCAT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Evcat();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EVCAT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Evcat/Evcat_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EVCAT]/
		[HttpPost]
		public ActionResult Evcat_Edit([FromBody]Evcat_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Edit",
				ViewName = "Evcat",
				AreaName = "evcat",
				Location = ACTION_EVCAT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EVCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EVCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EVCAT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Evcat_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EVCAT]/
		[HttpPost]
		public ActionResult Evcat_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Evcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Delete_GET",
				AreaName = "evcat",
				FormName = "EVCAT",
				Location = ACTION_EVCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Evcat();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EVCAT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Evcat/Evcat_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EVCAT]/
		[HttpPost]
		public ActionResult Evcat_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Evcat_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Delete",
				ViewName = "Evcat",
				AreaName = "evcat",
				Location = ACTION_EVCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EVCAT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Evcat_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EVCAT");
		}

		#endregion

		#region Evcat_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EVCAT]/

		[HttpPost]
		public ActionResult Evcat_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Evcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Duplicate_GET",
				AreaName = "evcat",
				FormName = "EVCAT",
				Location = ACTION_EVCAT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EVCAT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Evcat/Evcat_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EVCAT]/
		[HttpPost]
		public ActionResult Evcat_Duplicate([FromBody]Evcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_Duplicate",
				ViewName = "Evcat",
				AreaName = "evcat",
				Location = ACTION_EVCAT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EVCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EVCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EVCAT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Evcat_Cancel

		//
		// GET: /Evcat/Evcat_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EVCAT]/
		public ActionResult Evcat_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Evcat(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("evcat");

// USE /[MANUAL GQT BEFORE_CANCEL EVCAT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EVCAT]/

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

				Navigation.SetValue("ForcePrimaryRead_evcat", "true", true);
			}

			Navigation.ClearValue("evcat");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Evcat_PessoValNameModel : RequestLookupModel
		{
			public Evcat_ViewModel Model { get; set; }
		}

		//
		// GET: /Evcat/Evcat_PessoValName
		// POST: /Evcat/Evcat_PessoValName
		[ActionName("Evcat_PessoValName")]
		public ActionResult Evcat_PessoValName([FromBody] Evcat_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Evcat parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Evcat_PessoValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Evcat_Cate1ValCategoriaModel : RequestLookupModel
		{
			public Evcat_ViewModel Model { get; set; }
		}

		//
		// GET: /Evcat/Evcat_Cate1ValCategoria
		// POST: /Evcat/Evcat_Cate1ValCategoria
		[ActionName("Evcat_Cate1ValCategoria")]
		public ActionResult Evcat_Cate1ValCategoria([FromBody] Evcat_Cate1ValCategoriaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cate1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cate1");
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

			Models.Evcat parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Evcat_Cate1ValCategoria_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Evcat/Evcat_SaveEdit
		[HttpPost]
		public ActionResult Evcat_SaveEdit([FromBody]Evcat_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Evcat_SaveEdit",
				ViewName = "Evcat",
				AreaName = "evcat",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EVCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EVCAT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
