using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public class QDebug_ViewModel : ViewModelBase
	{
		/// <summary>
		/// Action executed on current history level
		/// </summary>
		public string lastAction { get { return this.Navigation.CurrentLevel.Location.Action; } }

		/// <summary>
		/// Controller used on current history level
		/// </summary>
		public string lastController { get { return this.Navigation.CurrentLevel.Location.Controller;  } }

		public string curUser { get { return UserContext.Current.User.Name; } }

		public string curUserLevels { get { return PrintAccessRoles(); } }

		void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		public QDebug_ViewModel()
		{
			InitLevels();
		}

		public QDebug_ViewModel(NavigationContext current_navigation)
		{
			InitLevels();
			this.Navigation = current_navigation;
		}

		public string PrintAccessRoles()
		{
			List<string> moduleRoles = new List<string>();

			// We only allow code debugging when event tracing is active.
			if(Configuration.EventTracking)
			{
				foreach (var module in Configuration.Application.Modules.Select(m => m.Key))
				{
					var user = UserContext.Current.User;
					var roleList = user.GetModuleRoles(module);
					string moduleRoleList = string.Join(",", roleList);
					moduleRoles.Add($"({module} : {moduleRoleList})");
				}
			}

			return string.Join(",", moduleRoles);
		}
	}
}
