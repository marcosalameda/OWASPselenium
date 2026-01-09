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
using GenioMVC.ViewModels.Tpequ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPEQU]/

namespace GenioMVC.Controllers
{
	public partial class TpequController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPEQU_CANCEL = new("TYPE_OF_EQUIPMENT18080", "Tpequ_Cancel", "Tpequ") { vueRouteName = "form-TPEQU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPEQU_SHOW = new("TYPE_OF_EQUIPMENT18080", "Tpequ_Show", "Tpequ") { vueRouteName = "form-TPEQU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPEQU_NEW = new("TYPE_OF_EQUIPMENT18080", "Tpequ_New", "Tpequ") { vueRouteName = "form-TPEQU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPEQU_EDIT = new("TYPE_OF_EQUIPMENT18080", "Tpequ_Edit", "Tpequ") { vueRouteName = "form-TPEQU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPEQU_DUPLICATE = new("TYPE_OF_EQUIPMENT18080", "Tpequ_Duplicate", "Tpequ") { vueRouteName = "form-TPEQU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPEQU_DELETE = new("TYPE_OF_EQUIPMENT18080", "Tpequ_Delete", "Tpequ") { vueRouteName = "form-TPEQU", mode = "DELETE" };

		#endregion

		#region Tpequ private

		private void FormHistoryLimits_Tpequ()
		{

		}

		#endregion

		#region Tpequ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPEQU]/

		[HttpPost]
		public ActionResult Tpequ_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpequ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Show_GET",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPEQU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tpequ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Tpequ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_New_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPEQU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tpequ/Tpequ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_New([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_New",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
					model.MapFromModel();
					using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("manua_exec_time", new System.Diagnostics.TagList([
						new("Name", "AFTER_SAVE_NEW"),
						new("Parameter", "TPEQU"),
						new("ModuleOrSystem", "GQT")
					]), "ms", "Time to execute the manual code.")) {
//Platform: MVC | Type: AFTER_SAVE_NEW | Module: GQT | Parameter: TPEQU | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:57efd9ed-6ccb-482f-961e-bf3a993ced4a
					var requestModel = new RequestCargaModel()
					{
						Idsrc = model.ValCodtpequ
					};

					GetCarga_unico(requestModel);
//END_MANUALCODE
					}

				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPEQU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tpequ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpequ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Edit_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPEQU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tpequ/Tpequ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Edit([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Edit",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPEQU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tpequ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpequ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Delete_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpequ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPEQU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tpequ/Tpequ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpequ_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Delete",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPEQU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tpequ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPEQU");
		}

		#endregion

		#region Tpequ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPEQU]/

		[HttpPost]
		public ActionResult Tpequ_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Tpequ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Duplicate_GET",
				AreaName = "tpequ",
				FormName = "TPEQU",
				Location = ACTION_TPEQU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPEQU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tpequ/Tpequ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPEQU]/
		[HttpPost]
		public ActionResult Tpequ_Duplicate([FromBody]Tpequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_Duplicate",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				Location = ACTION_TPEQU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPEQU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tpequ_Cancel

		//
		// GET: /Tpequ/Tpequ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPEQU]/
		public ActionResult Tpequ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Tpequ model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");

// USE /[MANUAL GQT BEFORE_CANCEL TPEQU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPEQU]/

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

				Navigation.SetValue("ForcePrimaryRead_tpequ", "true", true);
			}

			Navigation.ClearValue("tpequ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tpequ_FamilValFamilyModel : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_FamilValFamily
		// POST: /Tpequ/Tpequ_FamilValFamily
		[ActionName("Tpequ_FamilValFamily")]
		public ActionResult Tpequ_FamilValFamily([FromBody] Tpequ_FamilValFamilyModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_famil")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_famil");
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

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_FamilValFamily_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Tpequ_ValComponenModel : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_ValComponen
		// POST: /Tpequ/Tpequ_ValComponen
		[ActionName("Tpequ_ValComponen")]
		public ActionResult Tpequ_ValComponen([FromBody] Tpequ_ValComponenModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpki")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpki");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_ValComponen_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Tpequ_ValEvolucaoModel : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_ValEvolucao
		// POST: /Tpequ/Tpequ_ValEvolucao
		[ActionName("Tpequ_ValEvolucao")]
		public ActionResult Tpequ_ValEvolucao([FromBody] Tpequ_ValEvolucaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tabpr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tabpr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_ValEvolucao_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_unico([FromBody] RequestCargaModel requestModel)
		{
			string idsrc = requestModel.Idsrc;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Tpequ.Find(idsrc, UserContext.Current).carga_unico(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 });
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return JsonERROR();
			}
		}

		#endregion

		public class Tpequ_ValUnicoModel : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_ValUnico
		// POST: /Tpequ/Tpequ_ValUnico
		[ActionName("Tpequ_ValUnico")]
		public ActionResult Tpequ_ValUnico([FromBody] Tpequ_ValUnicoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tabpr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tabpr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_ValUnico_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Tpequ_ValInstalacModel : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_ValInstalac
		// POST: /Tpequ/Tpequ_ValInstalac
		[ActionName("Tpequ_ValInstalac")]
		public ActionResult Tpequ_ValInstalac([FromBody] Tpequ_ValInstalacModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_ValInstalac_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Tpequ_ValInstala1Model : RequestLookupModel
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpequ/Tpequ_ValInstala1
		// POST: /Tpequ/Tpequ_ValInstala1
		[ActionName("Tpequ_ValInstala1")]
		public ActionResult Tpequ_ValInstala1([FromBody] Tpequ_ValInstala1Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Tpequ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpequ_ValInstala1_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tpequ/Tpequ_SaveEdit
		[HttpPost]
		public ActionResult Tpequ_SaveEdit([FromBody] Tpequ_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpequ_SaveEdit",
				ViewName = "Tpequ",
				AreaName = "tpequ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPEQU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		/// <summary>
		/// Server-side component of action #1 (RECALC) of trigger UPDATE_FORMULAS
		/// </summary>
		/// <param name="data">The client-side context of the trigger.</param>
		/// <returns>
		/// Success message
		/// </returns>
		public ActionResult Tpequ_FormTriggers_UPDATE_FORMULAS_1([FromBody] Tpequ_ViewModel vm)
		{
			var key = vm.ValCodtpequ;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = Models.Tpequ.Find(key, UserContext.Current, "FTPEQU");
				vm.MapToModel(model);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model.klass,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger UPDATE_FORMULAS
				CSGenio.business.Triggers.ITrigger trigger_UPDATE_FORMULAS = new CSGenio.business.Triggers.TriggerUpdateFormulas(context);
				CSGenio.business.Triggers.IAction action = trigger_UPDATE_FORMULAS.GetAction(1);
				trigger_UPDATE_FORMULAS.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
			);
		}

		public class TpequDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tpequ_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTpequ([FromBody] TpequDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
