using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

using CSGenio.framework;
using GenioMVC.Helpers.Menus;
using GenioMVC.Models;

namespace GenioMVC.ViewModels
{
	public class Menu_ViewModel
	{
		private List<MenuEntry> m_allMenus;

		public List<MenuEntry> MenuList { get { return m_allMenus; } }

		public List<MenuEntry> AvailableModules { get; set; }

		public string CurrentModule { get; set; }

		public string Icon { get; set; }

		public Menu_ViewModel(User user)
		{
			AvailableModules = Menus.AvailableModules(user);

			if (AvailableModules.Count >= 1)
			{
				if (user.CurrentModule != null && user.CurrentModule != "Public" && user.CurrentModule != "admin")
				{
					try
					{
						MenuEntry selectedModule = AvailableModules.First(m => m.ID.Equals(user.CurrentModule));
						FillMenuInfo(user, selectedModule);
					}
					catch (Exception)
					{
						m_allMenus = new List<MenuEntry>();
					}
				}
				else
					FillMenuInfo(user, AvailableModules.First());
			}
			else
				m_allMenus = new List<MenuEntry>();
		}

		private void FillMenuInfo(User user, MenuEntry selectedModule)
		{
			m_allMenus = Menus.MenusForModule(user, selectedModule, true);
			user.CurrentModule = selectedModule.ID;
			CurrentModule = user.CurrentModule;
			if (!String.IsNullOrEmpty(selectedModule.Image))
				Icon = selectedModule.Image;
		}
	}
}
