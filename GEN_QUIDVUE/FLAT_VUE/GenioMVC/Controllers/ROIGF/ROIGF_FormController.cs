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
using GenioMVC.ViewModels.Roigf;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGF]/

namespace GenioMVC.Controllers
{
	public partial class RoigfController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROIGF_CANCEL = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_Cancel", "Roigf") { vueRouteName = "form-ROIGF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROIGF_SHOW = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_Show", "Roigf") { vueRouteName = "form-ROIGF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROIGF_NEW = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_New", "Roigf") { vueRouteName = "form-ROIGF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROIGF_EDIT = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_Edit", "Roigf") { vueRouteName = "form-ROIGF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROIGF_DUPLICATE = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_Duplicate", "Roigf") { vueRouteName = "form-ROIGF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROIGF_DELETE = new NavigationLocation("ORDER_IN_GROUP__FLOA51083", "Roigf_Delete", "Roigf") { vueRouteName = "form-ROIGF", mode = "DELETE" };

		#endregion

		#region Roigf private

		private void FormHistoryLimits_Roigf()
		{

		}

		#endregion

		public ActionResult Roigf_ModalDBEdit()
		{
			Roigf_ViewModel model = new Roigf_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Roigf_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ROIGF]/

		[HttpPost]
		public ActionResult Roigf_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Show_GET",
				AreaName = "roigf",
				Location = ACTION_ROIGF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ROIGF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Roigf_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Roigf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_New_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ROIGF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Roigf/Roigf_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_New([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_New",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_NEW,
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
							var row = CSGenioAroigf.search(sp, model.ValCodroigf, u);

							var orderField = model.ValOrder;
							int orderFieldValue = Convert.ToInt32(orderField);

							int maxOrder = 0;
							try
							{
								maxOrder = sp.GetMaxFieldValue(Area.AreaROIGF, CSGenioAroigf.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
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

// USE /[MANUAL GQT BEFORE_SAVE_NEW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ROIGF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Roigf_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Edit_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ROIGF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Roigf/Roigf_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Edit([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Edit",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ROIGF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Roigf_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Delete_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ROIGF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Roigf/Roigf_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Roigf_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Delete",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ROIGF]/
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
							sp.ReorderSequence(CSGenio.business.Area.AreaROIGF, CSGenioAroigf.FldOrder, tableViewModel.baseConditions, tableViewModel.relations);
					}
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ROIGF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Roigf_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROIGF");
		}

		#endregion

		#region Roigf_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ROIGF]/

		[HttpPost]
		public ActionResult Roigf_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Roigf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Duplicate_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ROIGF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Roigf/Roigf_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Duplicate([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_Duplicate",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ROIGF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Roigf_Cancel

		//
		// GET: /Roigf/Roigf_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ROIGF]/
		public ActionResult Roigf_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Roigf(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("roigf");

// USE /[MANUAL GQT BEFORE_CANCEL ROIGF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ROIGF]/

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

				Navigation.SetValue("ForcePrimaryRead_roigf", "true", true);
			}

			Navigation.ClearValue("roigf");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Roigf Multiform actions

		//
		// GET /Roigf/MFRoigf_New
		[HttpGet]
		[ActionName("MFRoigf_New")]
		public ActionResult MFRoigf_New()
		{
			var model = new Roigf_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ROIGF_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("roigf", model.ValCodroigf);

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
		public ActionResult MFRoigf_New_GET()
		{
			return MFRoigf_New();
		}

		//
		// GET /Roigf/MFRoigf_Edit
		[HttpGet]
		[ActionName("MFRoigf_Edit")]
		public ActionResult MFRoigf_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ROIGF", "EDIT", new { id = id, partialView = "MFRoigf", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFRoigf_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFRoigf_Edit(requestModel);
		}

		//
		// GET /Roigf/MFRoigf_Cancel
		[ActionName("MFRoigf_Cancel")]
		public ActionResult MFRoigf_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Roigf(UserContext.Current);
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
		// POST /Roigf/MFRoigf_Save
		[HttpPost]
		[ActionName("MFRoigf_Save")]
		public JsonResult MFRoigf_Save(Roigf_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRoigf_Save",
				ViewName = "MFRoigf",
				AreaName = "roigf"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Roigf/MFRoigf_Delete
		[HttpPost]
		[ActionName("MFRoigf_Delete")]
		public JsonResult MFRoigf_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFRoigf_Delete",
				ViewName = "MFRoigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_EDIT
			};

			var model = new Roigf_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Roigf/Roigf_Rogl1ValTitle
		// POST: /Roigf/Roigf_Rogl1ValTitle
		[ActionName("Roigf_Rogl1ValTitle")]
		public ActionResult Roigf_Rogl1ValTitle([FromBody]RequestLookupModel requestModel)
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
			Roigf_Rogl1ValTitle_ViewModel model = new Roigf_Rogl1ValTitle_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodroigf = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Roigf/Roigf_SaveEdit
		[HttpPost]
		public ActionResult Roigf_SaveEdit([FromBody]Roigf_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Roigf_SaveEdit",
				ViewName = "Roigf",
				AreaName = "roigf",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ROIGF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
