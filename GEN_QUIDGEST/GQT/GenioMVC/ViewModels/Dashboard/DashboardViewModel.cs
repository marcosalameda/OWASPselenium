using System;
using System.Collections.Generic;
using System.Linq;

using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Dashboard
{
	public abstract class DashboardViewModel : ViewModelBase
	{
		private List<Widget> m_widgets;

		/// <summary>
		/// Unique user interface descriptor
		/// </summary>
		public string uuid { get; protected set; }

		/// <summary>
		/// Prefix of the methods of the associated dashboard controller
		/// </summary>
		public string Action { get; protected set; }

		/// <summary>
		/// The list of the registered singleton widget providers for this dashboard
		/// </summary>
		protected Dictionary<WidgetType, WidgetProvider> m_singletonWidgetProviders { get; set; }

		/// <summary>
		/// The list of the registered widget providers for this dashboard
		/// </summary>
		protected List<WidgetProvider> m_widgetProviders { get; set; }

		/// <summary>
		/// The list of the registered independent widget instances for this dashboard
		/// </summary>
		protected List<Widget> m_independentWidgetInstances { get; set; }

		/// <summary>
		/// The title of the dashboard
		/// </summary>
		public string DashboardTitle { get; protected set; }

		/// <summary>
		/// The list of widgets of this dashboard that this user has access to
		/// </summary>
		public List<Widget> Widgets
		{
			get { return m_widgets; }
		}

		/// <summary>
		/// The list of the defined groups of widgets for this dashboard
		/// </summary>
		public List<WidgetGroup> WidgetGroups { get; protected set; }

		/// <summary>
		/// A set of text resources used by the dashboard
		/// </summary>
		public Dictionary<string, string> Texts { get; protected set; }

		/// <summary>
		/// Loads the dashboard widgets.
		/// </summary>
		public void Load()
		{
			m_widgets = new List<Widget>();

			foreach (var singleton in m_singletonWidgetProviders)
			{
				WidgetProvider provider = singleton.Value;
				provider.LoadInstances();
				m_widgets.AddRange(provider.Widgets);
			}

			foreach (var provider in m_widgetProviders)
			{
				provider.LoadInstances();
				m_widgets.AddRange(provider.Widgets);
			}

			foreach (var widget in m_independentWidgetInstances)
				m_widgets.Add(widget);
		}

		/// <summary>
		/// Gets the widget with the provided type and identifier.
		/// </summary>
		/// <param name="widgetType">Type of the widget.</param>
		/// <param name="widgetId">The widget identifier.</param>
		public Widget GetWidget(WidgetType widgetType, string widgetId)
		{
			switch (widgetType)
			{
				case WidgetType.Alert:
				case WidgetType.Menu:
					return m_independentWidgetInstances.FirstOrDefault(w => w.Id == widgetId);
				case WidgetType.Bookmark:
					if (m_singletonWidgetProviders.ContainsKey(WidgetType.Bookmark))
					{
						var provider = m_singletonWidgetProviders[WidgetType.Bookmark];
						provider.LoadInstances();
						return provider.GetInstance(widgetId);
					}
					return null;
				default:
					return null;
			}
		}
	}
}
