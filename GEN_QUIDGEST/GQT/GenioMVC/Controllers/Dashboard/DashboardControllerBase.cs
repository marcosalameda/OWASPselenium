using System;
using System.Linq;
using System.Web.Mvc;
using GenioMVC.Models.Navigation;
using GenioMVC.Helpers;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.ViewModels.Dashboard;
using GenioMVC.Helpers.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GenioMVC.Controllers
{
	public class DashboardControllerBase : ControllerBase
	{
		// GET: "/Dashboard/RenderAlertWidget"
		[HttpGet]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult RenderAlertWidget()
		{
			return PartialView("Template/Widgets/AlertWidget");
		}

		protected ActionResult RenderMenuWidget(DashboardViewModel vm, WidgetType type, string widgetId)
		{
			Widget widget = vm.GetWidget(type, widgetId);

			return PartialView("Template/Widgets/MenuWidget", widget);
		}

		protected ActionResult GetWidgetData(DashboardViewModel vm, WidgetType widgetType, string widgetId)
		{
			object data = null;
			Widget widget = null;

			if (widgetType == WidgetType.Alert || widgetType == WidgetType.Bookmark || widgetType == WidgetType.Menu)
				widget = vm.GetWidget(widgetType, widgetId);

			// TODO: check if user must be authenticated
			User user = UserContext.Current.User;

			string ckey = string.Format("{0}.{1}.{2}.{3}", vm.Action, widget.Id, widget.Rowkey, user.Codpsw);

			if (widget.UsesCache)
			{
				data = QCache.Instance.Dashboard.Get(ckey);
			}

			if (data == null)
			{
				data = widget.GetData();

				if (data != null && widget.UsesCache)
				{
					QCache.Instance.Dashboard.Put(ckey, data, TimeSpan.FromSeconds(widget.CacheTTL));
				}
			}

			return Json(data, JsonRequestBehavior.AllowGet);
		}

		// POST: "/Dashboard/Save"
		[AuthorizeForUsers]
		[HttpPost]
		public ActionResult Save(List<WidgetDto> grid, string uuid)
		{
			// Don't allow changes in maintenance mode
			if (Maintenance.Current.IsActive)
				return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
			CSGenioAlstusr lstusr = GetOrInitLstusr(uuid);

			// Gets the current list of user widgets for this viewmodel
			List<CSGenioAusrwid> userWidgets = DashboardUiSettingsDbRec.Load(sp, lstusr.ValDescric, user).UserWidgets;

			foreach (CSGenioAusrwid userWidget in userWidgets)
			{
				WidgetDto widget = !string.IsNullOrEmpty(userWidget.ValRowkey)
					? grid.FirstOrDefault(w => w.rowkey == userWidget.ValRowkey)
					: widget = grid.FirstOrDefault(w => w.id == userWidget.ValWidget);

				if (widget == null)
				{
					// Widget no longer exists in the configuration
					sp.openConnection();
					userWidget.delete(sp);
					sp.closeConnection();
				}
				else
				{
					// Update configuration
					userWidget.ValWidget = widget.id;
					userWidget.ValRowkey = widget.rowkey;
					userWidget.ValVisible = widget.visible ? 1 : 0;
					userWidget.ValHposition = widget.x;
					userWidget.ValVposition = widget.y;

					sp.openConnection();
					userWidget.update(sp);
					sp.closeConnection();

					grid.Remove(widget);
				}
			}

			foreach (var widget in grid)
			{
				// New widget configuration
				CSGenioAusrwid config = new CSGenioAusrwid(user)
				{
					ValCodlstusr = lstusr.ValCodlstusr,
					ValWidget = widget.id,
					ValRowkey = widget.rowkey,
					ValVisible = widget.visible ? 1 : 0,
					ValHposition = widget.x,
					ValVposition = widget.y
				};

				sp.openConnection();
				config.insert(sp);
				sp.closeConnection();
			}

			DashboardUiSettingsDbRec.Invalidate(lstusr.ValDescric, user);

			return Json(new { Success = true, Operation = "Save" });
		}

		protected CSGenioAlstusr GetOrInitLstusr(string uuid)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			CSGenioAlstusr model = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAlstusr.FldDescric, uuid)
				.Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAlstusr.FldZzstate, 0))
				.FirstOrDefault();

			// Create lstusr if it does not exist yet
			if (model == null)
			{
				model = new CSGenioAlstusr(user)
				{
					ValCodpsw = user.Codpsw,
					ValModulo = user.CurrentModule,
					ValSistema = Configuration.Program,
					ValDescric = uuid
				};

				// Only save the record to the database if not in maintenance mode
				if (!Maintenance.Current.IsActive)
				{
					sp.openConnection();
					model.insert(sp);
					sp.closeConnection();
				}

				DashboardUiSettingsDbRec.Invalidate(model.ValDescric, user);
			}

			return model;
		}
	}
}
