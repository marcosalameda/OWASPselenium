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

		private static readonly NavigationLocation ACTION_PESSO_CANCEL = new("PERSON10446", "Pesso_Cancel", "Pesso") { vueRouteName = "form-PESSO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSO_SHOW = new("PERSON10446", "Pesso_Show", "Pesso") { vueRouteName = "form-PESSO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSO_NEW = new("PERSON10446", "Pesso_New", "Pesso") { vueRouteName = "form-PESSO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSO_EDIT = new("PERSON10446", "Pesso_Edit", "Pesso") { vueRouteName = "form-PESSO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSO_DUPLICATE = new("PERSON10446", "Pesso_Duplicate", "Pesso") { vueRouteName = "form-PESSO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSO_DELETE = new("PERSON10446", "Pesso_Delete", "Pesso") { vueRouteName = "form-PESSO", mode = "DELETE" };

		#endregion

		#region Pesso private

		private void FormHistoryLimits_Pesso()
		{

		}

		#endregion

		#region Pesso_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSO]/

		[HttpPost]
		public ActionResult Pesso_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Show_GET",
				AreaName = "pesso",
				Location = ACTION_PESSO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pesso_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSO]/
		[HttpPost]
		public ActionResult Pesso_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pesso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_New_GET",
				AreaName = "pesso",
				FormName = "PESSO",
				Location = ACTION_PESSO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pesso();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Pesso_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSO]/
		[HttpPost]
		public ActionResult Pesso_New([FromBody]Pesso_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_New",
				ViewName = "Pesso",
				AreaName = "pesso",
				Location = ACTION_PESSO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSO]/
					MergeNN(model.Navigation, "Pesso", model.ValCodpesso, "Esppe", "Codpesso", "Codespec", model.List_Especial_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pesso_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSO]/
		[HttpPost]
		public ActionResult Pesso_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Edit_GET",
				AreaName = "pesso",
				FormName = "PESSO",
				Location = ACTION_PESSO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSO]/
		[HttpPost]
		public ActionResult Pesso_Edit([FromBody]Pesso_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Edit",
				ViewName = "Pesso",
				AreaName = "pesso",
				Location = ACTION_PESSO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSO]/
					MergeNN(model.Navigation, "Pesso", model.ValCodpesso, "Esppe", "Codpesso", "Codespec", model.List_Especial_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pesso_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSO]/
		[HttpPost]
		public ActionResult Pesso_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Delete_GET",
				AreaName = "pesso",
				FormName = "PESSO",
				Location = ACTION_PESSO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSO]/
		[HttpPost]
		public ActionResult Pesso_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesso_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Delete",
				ViewName = "Pesso",
				AreaName = "pesso",
				Location = ACTION_PESSO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pesso_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSO");
		}

		#endregion

		#region Pesso_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSO]/

		[HttpPost]
		public ActionResult Pesso_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pesso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Duplicate_GET",
				AreaName = "pesso",
				FormName = "PESSO",
				Location = ACTION_PESSO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Pesso_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSO]/
		[HttpPost]
		public ActionResult Pesso_Duplicate([FromBody]Pesso_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_Duplicate",
				ViewName = "Pesso",
				AreaName = "pesso",
				Location = ACTION_PESSO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSO]/
					MergeNN(model.Navigation, "Pesso", model.ValCodpesso, "Esppe", "Codpesso", "Codespec", model.List_Especial_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pesso_Cancel

		//
		// GET: /Pesso/Pesso_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSO]/
		public ActionResult Pesso_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pesso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");

// USE /[MANUAL GQT BEFORE_CANCEL PESSO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSO]/

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

				Navigation.SetValue("ForcePrimaryRead_pesso", "true", true);
			}

			Navigation.ClearValue("pesso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Pesso/Pesso_CategValCategoria
		// POST: /Pesso/Pesso_CategValCategoria
		[ActionName("Pesso_CategValCategoria")]
		public ActionResult Pesso_CategValCategoria([FromBody]RequestLookupModel requestModel)
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
			Pesso_CategValCategoria_ViewModel model = new Pesso_CategValCategoria_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Pesso/Pesso_Pais1ValCountry
		// POST: /Pesso/Pesso_Pais1ValCountry
		[ActionName("Pesso_Pais1ValCountry")]
		public ActionResult Pesso_Pais1ValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pais1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pais1");
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
			Pesso_Pais1ValCountry_ViewModel model = new Pesso_Pais1ValCountry_ViewModel(UserContext.Current);
			
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

		/// <summary>
		/// GET: /Pesso/Pesso_List_Especial
		/// </summary>
		/// <param name="partialView">Partial view file name</param>
		/// <returns>Partial View of the Checklist control</returns>
		[ActionName("Pesso_List_Especial")]
		public ActionResult Pesso_List_Especial([FromQuery]string partialView)
		{
			Pesso_ViewModel model = new Pesso_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(Navigation.CurrentLevel.FormMode);
			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			Models.Pesso row = null;
			try
			{
				row = Models.Pesso.Find(Navigation.GetStrValue("pesso"), UserContext.Current, "FPESSO");
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("On reload Checklist control - 'Pesso_List_Especial' Not found Model pesso");
			}

			if (row == null)
			{
				row = new Models.Pesso(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
			}

			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true);
			model.MapFromModel(row);

			// MH (06/05/2020) - If submission of the form fails, when an exception is thrown (for example when not pass some business validation),
			// during re-rendering the checklist would lose the list of previously selected items.
			//if (Request.Method == "POST"
			//	&& Request.Form != null && Request.Form.ContainsKey("List_Especial_SelectedIds"))
			//	model.List_Especial_SelectedIds = Request.Form["List_Especial_SelectedIds"];

			var values = new NameValueCollection();
			values.AddRange(Request.Query);
			model.Load_Pesso___pseudespecial(values);

			return JsonOK(model);
		}

		//
		// GET: /Pesso/Pesso_ValEspecitl
		// POST: /Pesso/Pesso_ValEspecitl
		[ActionName("Pesso_ValEspecitl")]
		public ActionResult Pesso_ValEspecitl([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_esppe")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_esppe");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Pesso_ValEspecitl_ViewModel model = new Pesso_ValEspecitl_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Pesso/Pesso_ValContacto
		// POST: /Pesso/Pesso_ValContacto
		[ActionName("Pesso_ValContacto")]
		public ActionResult Pesso_ValContacto([FromBody]RequestLookupModel requestModel)
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

			Pesso_ValContacto_ViewModel model = new Pesso_ValContacto_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Pesso/Pesso_CmpnyValDesignat
		// POST: /Pesso/Pesso_CmpnyValDesignat
		[ActionName("Pesso_CmpnyValDesignat")]
		public ActionResult Pesso_CmpnyValDesignat([FromBody]RequestLookupModel requestModel)
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
			Pesso_CmpnyValDesignat_ViewModel model = new Pesso_CmpnyValDesignat_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Pesso/Pesso_Regi1ValRegiao
		// POST: /Pesso/Pesso_Regi1ValRegiao
		[ActionName("Pesso_Regi1ValRegiao")]
		public ActionResult Pesso_Regi1ValRegiao([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regi1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regi1");
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
			Pesso_Regi1ValRegiao_ViewModel model = new Pesso_Regi1ValRegiao_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Pesso/Pesso_ValEvolucao
		// POST: /Pesso/Pesso_ValEvolucao
		[ActionName("Pesso_ValEvolucao")]
		public ActionResult Pesso_ValEvolucao([FromBody]RequestLookupModel requestModel)
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

			Pesso_ValEvolucao_ViewModel model = new Pesso_ValEvolucao_ViewModel(UserContext.Current);
			
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


		// POST: /Pesso/Pesso_SaveEdit
		[HttpPost]
		public ActionResult Pesso_SaveEdit([FromBody]Pesso_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesso_SaveEdit",
				ViewName = "Pesso",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSO]/
					MergeNN(model.Navigation, "Pesso", model.ValCodpesso, "Esppe", "Codpesso", "Codespec", model.List_Especial_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
