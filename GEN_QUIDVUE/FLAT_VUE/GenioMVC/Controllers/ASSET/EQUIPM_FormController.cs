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
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Asset;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSET]/

namespace GenioMVC.Controllers
{
	public partial class AssetController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EQUIPM_CANCEL = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_Cancel", "Asset") { vueRouteName = "form-EQUIPM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EQUIPM_SHOW = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_Show", "Asset") { vueRouteName = "form-EQUIPM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EQUIPM_NEW = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_New", "Asset") { vueRouteName = "form-EQUIPM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EQUIPM_EDIT = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_Edit", "Asset") { vueRouteName = "form-EQUIPM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EQUIPM_DUPLICATE = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_Duplicate", "Asset") { vueRouteName = "form-EQUIPM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EQUIPM_DELETE = new NavigationLocation("_ASSET__ASSETNUM____37227", "Equipm_Delete", "Asset") { vueRouteName = "form-EQUIPM", mode = "DELETE" };

		#endregion

		#region Equipm private

		private void FormHistoryLimits_Equipm()
		{

		}

		#endregion

		public ActionResult Equipm_ModalDBEdit()
		{
			Equipm_ViewModel model = new Equipm_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Equipm_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EQUIPM]/

		[HttpPost]
		public ActionResult Equipm_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Show_GET",
				AreaName = "asset",
				Location = ACTION_EQUIPM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EQUIPM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Equipm_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Equipm_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_New_GET",
				AreaName = "asset",
				FormName = "EQUIPM",
				Location = ACTION_EQUIPM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Equipm();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EQUIPM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Asset/Equipm_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_New([FromBody]Equipm_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_New",
				ViewName = "Equipm",
				AreaName = "asset",
				Location = ACTION_EQUIPM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EQUIPM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EQUIPM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EQUIPM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Equipm_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Edit_GET",
				AreaName = "asset",
				FormName = "EQUIPM",
				Location = ACTION_EQUIPM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EQUIPM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Asset/Equipm_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_Edit([FromBody]Equipm_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Edit",
				ViewName = "Equipm",
				AreaName = "asset",
				Location = ACTION_EQUIPM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EQUIPM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EQUIPM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EQUIPM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Equipm_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Delete_GET",
				AreaName = "asset",
				FormName = "EQUIPM",
				Location = ACTION_EQUIPM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EQUIPM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Asset/Equipm_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Delete",
				ViewName = "Equipm",
				AreaName = "asset",
				Location = ACTION_EQUIPM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EQUIPM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Equipm_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EQUIPM");
		}

		#endregion

		#region Equipm_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EQUIPM]/

		[HttpPost]
		public ActionResult Equipm_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Equipm_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Duplicate_GET",
				AreaName = "asset",
				FormName = "EQUIPM",
				Location = ACTION_EQUIPM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EQUIPM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Asset/Equipm_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EQUIPM]/
		[HttpPost]
		public ActionResult Equipm_Duplicate([FromBody]Equipm_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_Duplicate",
				ViewName = "Equipm",
				AreaName = "asset",
				Location = ACTION_EQUIPM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EQUIPM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EQUIPM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EQUIPM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Equipm_Cancel

		//
		// GET: /Asset/Equipm_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EQUIPM]/
		public ActionResult Equipm_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Asset(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("asset");

// USE /[MANUAL GQT BEFORE_CANCEL EQUIPM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EQUIPM]/

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

				Navigation.SetValue("ForcePrimaryRead_asset", "true", true);
			}

			Navigation.ClearValue("asset");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Equipm Multiform actions

		//
		// GET /Asset/MFEquipm_New
		[HttpGet]
		[ActionName("MFEquipm_New")]
		public ActionResult MFEquipm_New()
		{
			var model = new Equipm_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_EQUIPM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("asset", model.ValCodasset);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return JsonOK(model);
		}

		[HttpPost]
		public ActionResult MFEquipm_New_GET()
		{
			return MFEquipm_New();
		}

		//
		// GET /Asset/MFEquipm_Edit
		[HttpGet]
		[ActionName("MFEquipm_Edit")]
		public ActionResult MFEquipm_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("EQUIPM", "EDIT", new { id = id, partialView = "MFEquipm", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEquipm_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEquipm_Edit(requestModel);
		}

		//
		// GET /Asset/MFEquipm_Cancel
		[ActionName("MFEquipm_Cancel")]
		public ActionResult MFEquipm_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Asset(UserContext.Current);
				model.klass.QPrimaryKey = id;

				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
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

			return JsonOK(new { Success = true });
		}

		//
		// POST /Asset/MFEquipm_Save
		[HttpPost]
		[ActionName("MFEquipm_Save")]
		public JsonResult MFEquipm_Save(Equipm_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEquipm_Save",
				ViewName = "MFEquipm",
				AreaName = "asset"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Asset/MFEquipm_Delete
		[HttpPost]
		[ActionName("MFEquipm_Delete")]
		public JsonResult MFEquipm_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEquipm_Delete",
				ViewName = "MFEquipm",
				AreaName = "asset",
				Location = ACTION_EQUIPM_EDIT
			};

			var model = new Equipm_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Asset/Equipm_ManufValName
		// POST: /Asset/Equipm_ManufValName
		[ActionName("Equipm_ManufValName")]
		public ActionResult Equipm_ManufValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_manuf")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_manuf");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Equipm_ManufValName_ViewModel model = new Equipm_ManufValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Asset/Equipm_KindeValDesignat
		// POST: /Asset/Equipm_KindeValDesignat
		[ActionName("Equipm_KindeValDesignat")]
		public ActionResult Equipm_KindeValDesignat([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Equipm_KindeValDesignat_ViewModel model = new Equipm_KindeValDesignat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Asset/Equip02_ValAttachme
		// POST: /Asset/Equip02_ValAttachme
		[ActionName("Equip02_ValAttachme")]
		public ActionResult Equip02_ValAttachme([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_attac")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_attac");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Equip02_ValAttachme_ViewModel model = new Equip02_ValAttachme_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Asset/Equip03_ValDocument
		// POST: /Asset/Equip03_ValDocument
		[ActionName("Equip03_ValDocument")]
		public ActionResult Equip03_ValDocument([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_assma")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_assma");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Equip03_ValDocument_ViewModel model = new Equip03_ValDocument_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_Parameters([FromBody]RequestCargaModel requestModel)
		{
			var idsrc = requestModel.Idsrc;
			var iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Asset.Find(iddst, UserContext.Current).carga_Parameters(idsrc);
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

		//
		// GET: /Asset/Equip04_ValParamloa
		// POST: /Asset/Equip04_ValParamloa
		[ActionName("Equip04_ValParamloa")]
		public ActionResult Equip04_ValParamloa([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Equip04_ValParamloa_ViewModel model = new Equip04_ValParamloa_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_Manuals([FromBody]RequestCargaModel requestModel)
		{
			var idsrc = requestModel.Idsrc;
			var iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Asset.Find(iddst, UserContext.Current).carga_Manuals(idsrc);
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

		//
		// GET: /Asset/Equip04_ValManuals
		// POST: /Asset/Equip04_ValManuals
		[ActionName("Equip04_ValManuals")]
		public ActionResult Equip04_ValManuals([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Equip04_ValManuals_ViewModel model = new Equip04_ValManuals_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Asset/Equip04_ValParamete
		// POST: /Asset/Equip04_ValParamete
		[ActionName("Equip04_ValParamete")]
		public ActionResult Equip04_ValParamete([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asspa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asspa");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Equip04_ValParamete_ViewModel model = new Equip04_ValParamete_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasset = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Asset/Equipm_SaveEdit
		[HttpPost]
		public ActionResult Equipm_SaveEdit([FromBody]Equipm_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm_SaveEdit",
				ViewName = "Equipm",
				AreaName = "asset",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EQUIPM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EQUIPM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
