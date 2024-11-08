using System;
using System.Collections.Generic;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
    public class Breadcrumbs_ViewModel
    {
		public class Breadcrumb
		{
			public NavigationLocation Location
			{
				get;
				private set;
			}

			public FormMode Mode
			{
				get;
				private set;
			}

			public string MenuFont
			{
				get;
				private set;
			}

			public string HumanKeyValues
			{
				get;
				private set;
			}

			public Breadcrumb(NavigationLocation location, FormMode mode, string menuFont, string humanKeyValues)
			{
				Location = location;
				Mode = mode;
				MenuFont = menuFont;
				HumanKeyValues = humanKeyValues;
			}
		}

		private List<Breadcrumb> m_items;
		public IList<Breadcrumb> Items
		{
			get { return m_items; }
		}

		public string PathToMenu { get; private set; }

		public void SetPathToMenu(string pathToMenu)
        {
			PathToMenu = pathToMenu;
        }


		public Breadcrumbs_ViewModel()
        {
			m_items = new List<Breadcrumb>();
        }

		public void Add(NavigationLocation location, FormMode mode, string menuFont, string humanKeyValues)
		{
			m_items.Add(new Breadcrumb(location, mode, menuFont, humanKeyValues));
		}

		public void Insert(int index, NavigationLocation location, FormMode mode, string menuFont, string humanKeyValues)
		{
			m_items.Insert(index, new Breadcrumb(location, mode, menuFont, humanKeyValues));
		}
    }
}