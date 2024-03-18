using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Dashboard;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;

namespace GenioMVC.Controllers
{
	public class DashboardControllerBase : ControllerBase
	{
		public DashboardControllerBase(UserContextService userContextService) : base(userContextService)
        {
        }

		protected ActionResult GetWidgetData(DashboardViewModel vm, WidgetType widgetType, string widgetId)
		{
			object data = null;
			Widget widget = null;

			if (widgetType == WidgetType.Alert || widgetType == WidgetType.Bookmark || widgetType == WidgetType.Menu)
				widget = vm.GetWidget(widgetType, widgetId);

			if (widget == null)
				return JsonERROR("Widget with id " + widgetId + " not found");

			if (!widget.UserHasAccess(UserContext.Current))
				return JsonERROR("Permission denied to Widget with id " + widgetId);

			// TODO: check if user must be authenticated
			User user = UserContext.Current.User;

			string ckey = string.Format("{0}.{1}.{2}.{3}", vm.Action, widget.Id, widget.Rowkey, user.Codpsw);

			if (widget.UsesCache)
				data = QCache.Instance.Dashboard.Get(ckey);

			if (data == null)
			{
				data = widget.GetData(UserContext.Current);

				if (data != null && widget.UsesCache)
					QCache.Instance.Dashboard.Put(ckey, data, TimeSpan.FromSeconds(widget.CacheTTL));
			}

			return Json(data);
		}

		// POST: "/Dashboard/Save"
		[HttpPost]
		public ActionResult Save(List<WidgetDto> grid, string uuid)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
			CSGenioAlstusr lstusr = GetOrInitLstusr(uuid);

			// Gets the current list of user widgets for this viewmodel
			List<CSGenioAusrwid> userWidgets = UserUiSettings.Load(sp, lstusr.ValDescric, user).userWidgets;

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

			UserUiSettings.Invalidate(lstusr.ValDescric, user);

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

				sp.openConnection();
				model.insert(sp);
				sp.closeConnection();

				UserUiSettings.Invalidate(model.ValDescric, user);
			}

			return model;
		}
	}
}
