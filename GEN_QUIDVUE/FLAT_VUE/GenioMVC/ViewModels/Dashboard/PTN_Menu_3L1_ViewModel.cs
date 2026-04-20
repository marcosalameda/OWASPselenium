using System.Collections.Generic;
using System.Text.Json.Serialization;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// PTN_Menu_3L1 Dashboard Viewmodel
	/// </summary>
	public class PTN_Menu_3L1_ViewModel : DashboardViewModel
	{
		[JsonPropertyName("uuid")]
		public override string Uuid => "4ba4f954-073b-4474-b7e9-6685eeec4e3b";

		public PTN_Menu_3L1_ViewModel(UserContext userContext): base(userContext)
		{
			GenioMVC.Models.Glob glob = GenioMVC.Models.Glob.GetGlob(userContext);
			RoleToShow = CSGenio.framework.Role.ROLE_1;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
			};

			WidgetProviders =
			[
				new CustomWidgetProvider<CSGenio.business.CSGenioAcmpny>
{
					Id = "COLAB",
					Order = 4,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.EMPLOYEES22728,
					Group = "_GROUP02",
					Form = "WID_COLA",
					Component = "QFormWidCola",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAcmpny>,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Split
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "EMPLOY",
					Order = 5,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.ALL_EMPLOYEES64244,
					Group = "_GROUP02",
					Form = "WID_PESS",
					Component = "QFormWidPess",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Both
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "GRAPH_COUNT",
					Order = 3,
					Width = 6,
					Height = 4,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
					Title = Resources.Resources.COMPANHY_S_PEOPLE_CO22385,
					Group = "_GROUP01",
					Form = "WID_GRAP",
					Component = "QFormWidGrap",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
			];
		}


	}
}
