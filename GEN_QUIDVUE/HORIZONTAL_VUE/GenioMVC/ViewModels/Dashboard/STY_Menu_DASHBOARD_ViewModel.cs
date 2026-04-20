using System.Collections.Generic;
using System.Text.Json.Serialization;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// STY_Menu_DASHBOARD Dashboard Viewmodel
	/// </summary>
	public class STY_Menu_DASHBOARD_ViewModel : DashboardViewModel
	{
		[JsonPropertyName("uuid")]
		public override string Uuid => "5cc14c77-0a21-4b0d-b997-4190549f33bb";

		public STY_Menu_DASHBOARD_ViewModel(UserContext userContext): base(userContext)
		{
			GenioMVC.Models.Glob glob = GenioMVC.Models.Glob.GetGlob(userContext);
			RoleToShow = CSGenio.framework.Role.ROLE_1;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 1,
						Width = 2,
						Height = 2,
						Style = "",
						Required = false,
						Visible = false,
						ButtonText = Resources.Resources.IR_PARA07866
					}
				},
			};

			WidgetProviders =
			[
			];

			IndependentWidgetInstances =
			[
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_DEVOLUCAO)
				{
					Id = "ALERT_DEVOLUCAO",
					Order = 3,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "STY",
					Title = Resources.Resources.ALERT38887,
					Idalert = "DEVOLUCAO",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
			];
		}


	}
}
