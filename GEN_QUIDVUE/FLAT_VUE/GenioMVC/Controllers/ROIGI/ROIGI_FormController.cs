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
using GenioMVC.ViewModels.Roigi;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGI]/

namespace GenioMVC.Controllers
{
	public partial class RoigiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROIGI_CANCEL = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_Cancel", "Roigi") { vueRouteName = "form-ROIGI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROIGI_SHOW = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_Show", "Roigi") { vueRouteName = "form-ROIGI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROIGI_NEW = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_New", "Roigi") { vueRouteName = "form-ROIGI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROIGI_EDIT = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_Edit", "Roigi") { vueRouteName = "form-ROIGI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROIGI_DUPLICATE = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_Duplicate", "Roigi") { vueRouteName = "form-ROIGI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROIGI_DELETE = new NavigationLocation("ORDER_IN_GROUP__INTE56416", "Roigi_Delete", "Roigi") { vueRouteName = "form-ROIGI", mode = "DELETE" };

		#endregion

		#region Roigi private

		private void FormHistoryLimits_Roigi()
		{

		}

		#endregion

		public ActionResult Roigi_ModalDBEdit()
		{
			Roigi_ViewModel model = new Roigi_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Roigi_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ROIGI]/

		[HttpPost]
		public ActionResult Roigi_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Show_GET",
				AreaName = "roigi",
				Location = ACTION_ROIGI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ROIGI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Roigi_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Roigi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_New_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ROIGI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Roigi/Roigi_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_New([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_New",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
					//FOR: ROW_REORDERING
					string tableName = Navigation.GetStrValue("TableName");
					string tableViewModelName = Navigation.GetStrValue("TableViewModelName");

					Type tableViewModelType = Type.GetType("GenioMVC.ViewModels." + tableName + "." + tableViewModelName);
					if (tableViewModelType != null)
					{
						dynamic tableViewModel = Activator.CreateInstance(tableViewModelType, this.UserContext.Current);
						if (tableViewModel != null)
						{
							User u = UserContext.Current.User;
							var row = CSGenioAroigi.search(sp, model.ValCodroigi, u);

							var orderField = model.ValOrder;
							int orderFieldValue = Convert.ToInt32(orderField);

							int maxOrder = 0;
							try
							{
								maxOrder = sp.GetMaxFieldValue(Area.AreaROIGI, CSGenioAroigi.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
							}
							catch (Exception ex)
							{
								Log.Error(ex.Message);
							}

							if (maxOrder > 0 && orderFieldValue > maxOrder)
								model.ValOrder = orderFieldValue = maxOrder + 1;

							row.Reorder_Order(sp, orderFieldValue - 1, tableViewModel.baseConditions, tableViewModel.relations, false);
						}
					}

// USE /[MANUAL GQT BEFORE_SAVE_NEW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ROIGI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Roigi_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Edit_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ROIGI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Roigi/Roigi_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Edit([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Edit",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ROIGI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Roigi_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Delete_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ROIGI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Roigi/Roigi_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigi_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Delete",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
					//FOR: ROW_REORDERING
					string tableName = Navigation.GetStrValue("TableName");
					string tableViewModelName = Navigation.GetStrValue("TableViewModelName");

					Type tableViewModelType = Type.GetType("GenioMVC.ViewModels." + tableName + "." + tableViewModelName);
					if (tableViewModelType != null)
					{
						dynamic tableViewModel = Activator.CreateInstance(tableViewModelType, this.UserContext.Current);
						if (tableViewModel != null)
							sp.ReorderSequence(CSGenio.business.Area.AreaROIGI, CSGenioAroigi.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
					}
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ROIGI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Roigi_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROIGI");
		}

		#endregion

		#region Roigi_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ROIGI]/

		[HttpPost]
		public ActionResult Roigi_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Roigi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Duplicate_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ROIGI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Roigi/Roigi_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Duplicate([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_Duplicate",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ROIGI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Roigi_Cancel

		//
		// GET: /Roigi/Roigi_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ROIGI]/
		public ActionResult Roigi_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Roigi(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("roigi");

// USE /[MANUAL GQT BEFORE_CANCEL ROIGI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ROIGI]/

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

				Navigation.SetValue("ForcePrimaryRead_roigi", "true", true);
			}

			Navigation.ClearValue("roigi");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Roigi Multiform actions

		//
		// GET /Roigi/MFRoigi_New
		[HttpGet]
		[ActionName("MFRoigi_New")]
		public ActionResult MFRoigi_New()
		{
			var model = new Roigi_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ROIGI_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("roigi", model.ValCodroigi);

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
		public ActionResult MFRoigi_New_GET()
		{
			return MFRoigi_New();
		}

		//
		// GET /Roigi/MFRoigi_Edit
		[HttpGet]
		[ActionName("MFRoigi_Edit")]
		public ActionResult MFRoigi_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ROIGI", "EDIT", new { id = id, partialView = "MFRoigi", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFRoigi_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFRoigi_Edit(requestModel);
		}

		//
		// GET /Roigi/MFRoigi_Cancel
		[ActionName("MFRoigi_Cancel")]
		public ActionResult MFRoigi_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Roigi(UserContext.Current);
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
		// POST /Roigi/MFRoigi_Save
		[HttpPost]
		[ActionName("MFRoigi_Save")]
		public JsonResult MFRoigi_Save(Roigi_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRoigi_Save",
				ViewName = "MFRoigi",
				AreaName = "roigi"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Roigi/MFRoigi_Delete
		[HttpPost]
		[ActionName("MFRoigi_Delete")]
		public JsonResult MFRoigi_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFRoigi_Delete",
				ViewName = "MFRoigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_EDIT
			};

			var model = new Roigi_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Roigi/Roigi_Rogl1ValTitle
		// POST: /Roigi/Roigi_Rogl1ValTitle
		[ActionName("Roigi_Rogl1ValTitle")]
		public ActionResult Roigi_Rogl1ValTitle([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rogl1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rogl1");
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
			Roigi_Rogl1ValTitle_ViewModel model = new Roigi_Rogl1ValTitle_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodroigi = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Roigi/Roigi_SaveEdit
		[HttpPost]
		public ActionResult Roigi_SaveEdit([FromBody]Roigi_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigi_SaveEdit",
				ViewName = "Roigi",
				AreaName = "roigi",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ROIGI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
