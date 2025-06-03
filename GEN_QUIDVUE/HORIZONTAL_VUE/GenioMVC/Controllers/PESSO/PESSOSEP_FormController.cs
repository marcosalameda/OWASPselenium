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
using GenioMVC.ViewModels.Pesso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
	public partial class PessoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESSOSEP_CANCEL = new("PERSON10446", "Pessosep_Cancel", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSOSEP_SHOW = new("PERSON10446", "Pessosep_Show", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSOSEP_NEW = new("PERSON10446", "Pessosep_New", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSOSEP_EDIT = new("PERSON10446", "Pessosep_Edit", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSOSEP_DUPLICATE = new("PERSON10446", "Pessosep_Duplicate", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSOSEP_DELETE = new("PERSON10446", "Pessosep_Delete", "Pesso") { vueRouteName = "form-PESSOSEP", mode = "DELETE" };

		#endregion

		#region Pessosep private

		private void FormHistoryLimits_Pessosep()
		{

		}

		#endregion

		#region Pessosep_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSOSEP]/

		[HttpPost]
		public ActionResult Pessosep_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessosep_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Show_GET",
				AreaName = "pesso",
				Location = ACTION_PESSOSEP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessosep();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSOSEP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pessosep_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pessosep_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_New_GET",
				AreaName = "pesso",
				FormName = "PESSOSEP",
				Location = ACTION_PESSOSEP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pessosep();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSOSEP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Pessosep_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_New([FromBody]Pessosep_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_New",
				ViewName = "Pessosep",
				AreaName = "pesso",
				Location = ACTION_PESSOSEP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSOSEP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSOSEP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSOSEP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pessosep_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessosep_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Edit_GET",
				AreaName = "pesso",
				FormName = "PESSOSEP",
				Location = ACTION_PESSOSEP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessosep();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSOSEP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pessosep_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_Edit([FromBody]Pessosep_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Edit",
				ViewName = "Pessosep",
				AreaName = "pesso",
				Location = ACTION_PESSOSEP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSOSEP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSOSEP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSOSEP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pessosep_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessosep_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Delete_GET",
				AreaName = "pesso",
				FormName = "PESSOSEP",
				Location = ACTION_PESSOSEP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessosep();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSOSEP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pessosep_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessosep_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Delete",
				ViewName = "Pessosep",
				AreaName = "pesso",
				Location = ACTION_PESSOSEP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSOSEP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pessosep_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSOSEP");
		}

		#endregion

		#region Pessosep_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSOSEP]/

		[HttpPost]
		public ActionResult Pessosep_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pessosep_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Duplicate_GET",
				AreaName = "pesso",
				FormName = "PESSOSEP",
				Location = ACTION_PESSOSEP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSOSEP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Pessosep_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSOSEP]/
		[HttpPost]
		public ActionResult Pessosep_Duplicate([FromBody]Pessosep_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_Duplicate",
				ViewName = "Pessosep",
				AreaName = "pesso",
				Location = ACTION_PESSOSEP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSOSEP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSOSEP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSOSEP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pessosep_Cancel

		//
		// GET: /Pesso/Pessosep_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSOSEP]/
		public ActionResult Pessosep_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pesso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");

// USE /[MANUAL GQT BEFORE_CANCEL PESSOSEP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSOSEP]/

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

				Navigation.SetValue("ForcePrimaryRead_pesso", "true", true);
			}

			Navigation.ClearValue("pesso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pessosep_CategValCategoriaModel : RequestLookupModel
		{
			public Pessosep_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pessosep_CategValCategoria
		// POST: /Pesso/Pessosep_CategValCategoria
		[ActionName("Pessosep_CategValCategoria")]
		public ActionResult Pessosep_CategValCategoria([FromBody] Pessosep_CategValCategoriaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pessosep_CategValCategoria_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pessos00_CmpnyValDesignatModel : RequestLookupModel
		{
			public Pessosep_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pessos00_CmpnyValDesignat
		// POST: /Pesso/Pessos00_CmpnyValDesignat
		[ActionName("Pessos00_CmpnyValDesignat")]
		public ActionResult Pessos00_CmpnyValDesignat([FromBody] Pessos00_CmpnyValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pessos00_CmpnyValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pessos01_ValEvolucaoModel : RequestLookupModel
		{
			public Pessosep_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pessos01_ValEvolucao
		// POST: /Pesso/Pessos01_ValEvolucao
		[ActionName("Pessos01_ValEvolucao")]
		public ActionResult Pessos01_ValEvolucao([FromBody] Pessos01_ValEvolucaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pessos01_ValEvolucao_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pessos01_ValContactoModel : RequestLookupModel
		{
			public Pessosep_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pessos01_ValContacto
		// POST: /Pesso/Pessos01_ValContacto
		[ActionName("Pessos01_ValContacto")]
		public ActionResult Pessos01_ValContacto([FromBody] Pessos01_ValContactoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pessos01_ValContacto_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Pesso/Pessosep_SaveEdit
		[HttpPost]
		public ActionResult Pessosep_SaveEdit([FromBody]Pessosep_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessosep_SaveEdit",
				ViewName = "Pessosep",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSOSEP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSOSEP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
