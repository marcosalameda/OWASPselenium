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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTIG_CANCEL = new NavigationLocation("ITEM40802", "Artig_Cancel", "Item") { vueRouteName = "form-ARTIG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTIG_SHOW = new NavigationLocation("ITEM40802", "Artig_Show", "Item") { vueRouteName = "form-ARTIG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTIG_NEW = new NavigationLocation("ITEM40802", "Artig_New", "Item") { vueRouteName = "form-ARTIG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTIG_EDIT = new NavigationLocation("ITEM40802", "Artig_Edit", "Item") { vueRouteName = "form-ARTIG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTIG_DUPLICATE = new NavigationLocation("ITEM40802", "Artig_Duplicate", "Item") { vueRouteName = "form-ARTIG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTIG_DELETE = new NavigationLocation("ITEM40802", "Artig_Delete", "Item") { vueRouteName = "form-ARTIG", mode = "DELETE" };

		#endregion

		#region Artig private

		private void FormHistoryLimits_Artig()
		{

		}

		#endregion

		public ActionResult Artig_ModalDBEdit()
		{
			Artig_ViewModel model = new Artig_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Artig_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTIG]/

		[HttpPost]
		public ActionResult Artig_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Show_GET",
				AreaName = "item",
				Location = ACTION_ARTIG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artig();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTIG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Artig_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTIG]/
		[HttpPost]
		public ActionResult Artig_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artig_New_GET",
				AreaName = "item",
				FormName = "ARTIG",
				Location = ACTION_ARTIG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artig();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTIG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Artig_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTIG]/
		[HttpPost]
		public ActionResult Artig_New([FromBody]Artig_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artig_New",
				ViewName = "Artig",
				AreaName = "item",
				Location = ACTION_ARTIG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTIG]/
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categori_SelectedIds);
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categor_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTIG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Artig_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTIG]/
		[HttpPost]
		public ActionResult Artig_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Edit_GET",
				AreaName = "item",
				FormName = "ARTIG",
				Location = ACTION_ARTIG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artig();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTIG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Artig_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTIG]/
		[HttpPost]
		public ActionResult Artig_Edit([FromBody]Artig_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Edit",
				ViewName = "Artig",
				AreaName = "item",
				Location = ACTION_ARTIG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTIG]/
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categori_SelectedIds);
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categor_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTIG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Artig_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTIG]/
		[HttpPost]
		public ActionResult Artig_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Delete_GET",
				AreaName = "item",
				FormName = "ARTIG",
				Location = ACTION_ARTIG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artig();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTIG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Artig_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTIG]/
		[HttpPost]
		public ActionResult Artig_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artig_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artig_Delete",
				ViewName = "Artig",
				AreaName = "item",
				Location = ACTION_ARTIG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTIG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Artig_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTIG");
		}

		#endregion

		#region Artig_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTIG]/

		[HttpPost]
		public ActionResult Artig_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Duplicate_GET",
				AreaName = "item",
				FormName = "ARTIG",
				Location = ACTION_ARTIG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTIG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Artig_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTIG]/
		[HttpPost]
		public ActionResult Artig_Duplicate([FromBody]Artig_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artig_Duplicate",
				ViewName = "Artig",
				AreaName = "item",
				Location = ACTION_ARTIG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTIG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Artig_Cancel

		//
		// GET: /Item/Artig_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTIG]/
		public ActionResult Artig_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ARTIG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTIG]/

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

				Navigation.SetValue("ForcePrimaryRead_item", "true", true);
			}

			Navigation.ClearValue("item");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Artig Multiform actions

		//
		// GET /Item/MFArtig_New
		[HttpGet]
		[ActionName("MFArtig_New")]
		public ActionResult MFArtig_New()
		{
			var model = new Artig_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ARTIG_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("item", model.ValCoditem);

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
		public ActionResult MFArtig_New_GET()
		{
			return MFArtig_New();
		}

		//
		// GET /Item/MFArtig_Edit
		[HttpGet]
		[ActionName("MFArtig_Edit")]
		public ActionResult MFArtig_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ARTIG", "EDIT", new { id = id, partialView = "MFArtig", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFArtig_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFArtig_Edit(requestModel);
		}

		//
		// GET /Item/MFArtig_Cancel
		[ActionName("MFArtig_Cancel")]
		public ActionResult MFArtig_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Item(UserContext.Current);
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
		// POST /Item/MFArtig_Save
		[HttpPost]
		[ActionName("MFArtig_Save")]
		public JsonResult MFArtig_Save(Artig_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFArtig_Save",
				ViewName = "MFArtig",
				AreaName = "item"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Item/MFArtig_Delete
		[HttpPost]
		[ActionName("MFArtig_Delete")]
		public JsonResult MFArtig_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFArtig_Delete",
				ViewName = "MFArtig",
				AreaName = "item",
				Location = ACTION_ARTIG_EDIT
			};

			var model = new Artig_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Item/Artig_WarehValWarehdes
		// POST: /Item/Artig_WarehValWarehdes
		[ActionName("Artig_WarehValWarehdes")]
		public ActionResult Artig_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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
			Artig_WarehValWarehdes_ViewModel model = new Artig_WarehValWarehdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Item/Artig_GitemValItemdes
		// POST: /Item/Artig_GitemValItemdes
		[ActionName("Artig_GitemValItemdes")]
		public ActionResult Artig_GitemValItemdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_gitem")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_gitem");
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
			Artig_GitemValItemdes_ViewModel model = new Artig_GitemValItemdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Item/Artig_ValContacor
		// POST: /Item/Artig_ValContacor
		[ActionName("Artig_ValContacor")]
		public ActionResult Artig_ValContacor([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ccorr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ccorr");
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

			Artig_ValContacor_ViewModel model = new Artig_ValContacor_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Item/Artig_ValLentrada
		// POST: /Item/Artig_ValLentrada
		[ActionName("Artig_ValLentrada")]
		public ActionResult Artig_ValLentrada([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ldent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ldent");
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

			Artig_ValLentrada_ViewModel model = new Artig_ValLentrada_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Item/Artig_ValLsaidas
		// POST: /Item/Artig_ValLsaidas
		[ActionName("Artig_ValLsaidas")]
		public ActionResult Artig_ValLsaidas([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_outpu")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_outpu");
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

			Artig_ValLsaidas_ViewModel model = new Artig_ValLsaidas_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		/// <summary>
		/// GET: /Item/Artig_List_Categori
		/// </summary>
		/// <param name="partialView">Partial view file name</param>
		/// <returns>Partial View of the Checklist control</returns>
		[ActionName("Artig_List_Categori")]
		public ActionResult Artig_List_Categori([FromQuery]string partialView)
		{
			Artig_ViewModel model = new Artig_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(Navigation.CurrentLevel.FormMode);
			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			Models.Item row = null;
			try
			{
				row = Models.Item.Find(Navigation.GetStrValue("item"), UserContext.Current, "FARTIG");
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("On reload Checklist control - 'Artig_List_Categori' Not found Model item");
			}

			if (row == null)
			{
				row = new Models.Item(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("item");
			}

			row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true);
			model.MapFromModel(row);

			// MH (06/05/2020) - If submission of the form fails, when an exception is thrown (for example when not pass some business validation),
			// during re-rendering the checklist would lose the list of previously selected items.
			//if (Request.Method == "POST"
			//	&& Request.Form != null && Request.Form.ContainsKey("List_Categori_SelectedIds"))
			//	model.List_Categori_SelectedIds = Request.Form["List_Categori_SelectedIds"];

			var values = new NameValueCollection();
			values.AddRange(Request.Query);
			model.Load_Artig___pseudcategori(values);

			return JsonOK(model);
		}

		/// <summary>
		/// GET: /Item/Artig_List_Categor
		/// </summary>
		/// <param name="partialView">Partial view file name</param>
		/// <returns>Partial View of the Checklist control</returns>
		[ActionName("Artig_List_Categor")]
		public ActionResult Artig_List_Categor([FromQuery]string partialView)
		{
			Artig_ViewModel model = new Artig_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(Navigation.CurrentLevel.FormMode);
			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			Models.Item row = null;
			try
			{
				row = Models.Item.Find(Navigation.GetStrValue("item"), UserContext.Current, "FARTIG");
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("On reload Checklist control - 'Artig_List_Categor' Not found Model item");
			}

			if (row == null)
			{
				row = new Models.Item(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("item");
			}

			row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true);
			model.MapFromModel(row);

			// MH (06/05/2020) - If submission of the form fails, when an exception is thrown (for example when not pass some business validation),
			// during re-rendering the checklist would lose the list of previously selected items.
			//if (Request.Method == "POST"
			//	&& Request.Form != null && Request.Form.ContainsKey("List_Categor_SelectedIds"))
			//	model.List_Categor_SelectedIds = Request.Form["List_Categor_SelectedIds"];

			var values = new NameValueCollection();
			values.AddRange(Request.Query);
			model.Load_Artig___pseudcategor_(values);

			return JsonOK(model);
		}

		// POST: /Item/Artig_SaveEdit
		[HttpPost]
		public ActionResult Artig_SaveEdit([FromBody]Artig_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artig_SaveEdit",
				ViewName = "Artig",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTIG]/
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categori_SelectedIds);
					MergeNN(model.Navigation, "Item", model.ValCoditem, "Itemc", "Coditem", "Codtpcat", model.List_Categor_SelectedIds);
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTIG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
