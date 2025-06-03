using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels
{
	public class Alerts_ViewModel
	{
		private UserContext m_userContext;

		private NavigationContext Navigation => m_userContext.CurrentNavigation;

		private NameValueCollection QueryString { get; set; }

		private bool IsAjaxRequest { get; set; }

		public Alerts_ViewModel(UserContext userContext, NameValueCollection queryString = null, bool isAjaxRequest = true)
		{
			m_userContext = userContext;
			QueryString = queryString;
			IsAjaxRequest = isAjaxRequest;
		}

		public List<Models.Navigation.Alert> GenAlerts()
		{
			var user = m_userContext.User;
			var sp = m_userContext.PersistentSupport;

			List<Models.Navigation.Alert> alerts = new List<Models.Navigation.Alert>();

			sp.openConnection();
			alerts.AddRange(GenAlert_NCARDSDANGER(sp, user, false));
			alerts.AddRange(GenAlert_NCARDSWARNING(sp, user, false));
			alerts.AddRange(GenAlert_NCARDSINFO(sp, user, false));
			alerts.AddRange(GenAlert_NOTUSEDITEMS(sp, user, false));
			alerts.AddRange(GenAlert_DEVOLUCAO(sp, user, false));
			alerts.AddRange(GenAlert_NCARDSSUCESS(sp, user, false));
			sp.closeConnection();

			return alerts;
		}

		public List<Models.Navigation.Alert> GenAlert_NCARDSDANGER(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_NCARDSDANGER = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);

			int alertType = 3;
			string idalert = "NCARDSDANGER";
			double alertTagValue = 0;

			Role alertRole = Role.ROLE_1;

			// Tag processing
			{ //{STY_OVERVIEW_Count}

				if (!user.VerifyAccess(alertRole, "STY"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "STY")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(m_userContext);
				vm.Identifier = "ALERT_NCARDSDANGER";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "STY"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;


				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
				};

				Alert_NCARDSDANGER.Add(alert);
			}

			return Alert_NCARDSDANGER;
		}

		public List<Models.Navigation.Alert> GenAlert_NCARDSWARNING(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_NCARDSWARNING = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);

			int alertType = 2;
			string idalert = "NCARDSWARNING";
			double alertTagValue = 0;

			Role alertRole = Role.ROLE_1;

			// Tag processing
			{ //{STY_OVERVIEW_Count}

				if (!user.VerifyAccess(alertRole, "STY"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "STY")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(m_userContext);
				vm.Identifier = "ALERT_NCARDSWARNING";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "STY"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;


				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
				};

				Alert_NCARDSWARNING.Add(alert);
			}

			return Alert_NCARDSWARNING;
		}

		public List<Models.Navigation.Alert> GenAlert_NCARDSINFO(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_NCARDSINFO = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);

			int alertType = 1;
			string idalert = "NCARDSINFO";
			double alertTagValue = 0;

			Role alertRole = Role.ROLE_1;

			// Tag processing
			{ //{STY_OVERVIEW_Count}

				if (!user.VerifyAccess(alertRole, "STY"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "STY")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(m_userContext);
				vm.Identifier = "ALERT_NCARDSINFO";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "STY"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;


				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
				};

				Alert_NCARDSINFO.Add(alert);
			}

			return Alert_NCARDSINFO;
		}

		public List<Models.Navigation.Alert> GenAlert_NOTUSEDITEMS(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_NOTUSEDITEMS = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("_GQT_UNUSED_ITEMS_CO34020", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_GQT_UNUSED_ITEMS_CO35460", user.Language);

			int alertType = 0;
			string idalert = "NOTUSEDITEMS";
			double alertTagValue = 0;

			Role alertRole = Role.UNAUTHORIZED;

			// Tag processing
			{ //{GQT_UNUSED_ITEMS_Count}

				if (!user.VerifyAccess(alertRole, "GQT"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "GQT")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Item.GQT_Menu_UNUSED_ITEMS_ViewModel vm = new ViewModels.Item.GQT_Menu_UNUSED_ITEMS_ViewModel(m_userContext);
				vm.Identifier = "ALERT_NOTUSEDITEMS";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{GQT_UNUSED_ITEMS_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{GQT_UNUSED_ITEMS_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "GQT"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				//Alert level is defined by thresholds of this Tag
				float lvl0Threshhold = 5;
				float lvl1Threshhold = 10;
				float lvl2Threshhold = 15;
				float lvl3Threshhold = 20;

				if (alertTagValue >= lvl0Threshhold)
					alertType = 0;
				if (alertTagValue >= lvl1Threshhold)
					alertType = 1;
				if (alertTagValue >= lvl2Threshhold)
					alertType = 2;
				if (alertTagValue >= lvl3Threshhold)
					alertType = 3;

				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "GQT_UNUSED_ITEMS" },
				};

				Alert_NOTUSEDITEMS.Add(alert);
			}

			return Alert_NOTUSEDITEMS;
		}

		public List<Models.Navigation.Alert> GenAlert_DEVOLUCAO(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_DEVOLUCAO = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("_GQT_DEVOL_COUNT__TO39432", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_GQT_DEVOL_COUNT__TO39432", user.Language);

			int alertType = 0;
			string idalert = "DEVOLUCAO";
			double alertTagValue = 0;

			Role alertRole = Role.ROLE_1;

			// Tag processing
			{ //{GQT_DEVOL_Count}

				if (!user.VerifyAccess(alertRole, "GQT"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "GQT")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Lendi.GQT_Menu_DEVOL_ViewModel vm = new ViewModels.Lendi.GQT_Menu_DEVOL_ViewModel(m_userContext);
				vm.Identifier = "ALERT_DEVOLUCAO";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{GQT_DEVOL_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{GQT_DEVOL_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "GQT"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				//Alert level is defined by thresholds of this Tag
				float lvl0Threshhold = 1;
				float lvl1Threshhold = 2;
				float lvl2Threshhold = 3;
				float lvl3Threshhold = 4;

				if (alertTagValue >= lvl0Threshhold)
					alertType = 0;
				if (alertTagValue >= lvl1Threshhold)
					alertType = 1;
				if (alertTagValue >= lvl2Threshhold)
					alertType = 2;
				if (alertTagValue >= lvl3Threshhold)
					alertType = 3;

				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "GQT_DEVOL" },
				};

				Alert_DEVOLUCAO.Add(alert);
			}

			return Alert_DEVOLUCAO;
		}

		public List<Models.Navigation.Alert> GenAlert_NCARDSSUCESS(PersistentSupport sp, User user, bool FromWidget = true)
		{
			List<Models.Navigation.Alert> Alert_NCARDSSUCESS = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);

			int alertType = 0;
			string idalert = "NCARDSSUCESS";
			double alertTagValue = 0;

			Role alertRole = Role.ROLE_1;

			// Tag processing
			{ //{STY_OVERVIEW_Count}

				if (!user.VerifyAccess(alertRole, "STY"))
					return Alert_EMPTY;
				//alerts from other modules are not supposed to be displayed
				//unless it comes from widgets
				if(!FromWidget && user.CurrentModule != "STY")
					return Alert_EMPTY;
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(m_userContext);
				vm.Identifier = "ALERT_NCARDSSUCESS";
				float tagValue = vm.GetCount(user);

				// Replace the tag with the value
				alertTitle = alertTitle.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));
				alertText = alertText.Replace("{STY_OVERVIEW_Count}", tagValue.ToString("F0"));

				// (tag matches alert main tag) - this tag was selected to override alert defaults
				alertTagValue = tagValue;

				// URL link request from current alert menu
				string oldCurrentModule = user.CurrentModule;
				user.CurrentModule = "STY"; //simulates user entry

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;


				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Idalert = idalert,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
				};

				Alert_NCARDSSUCESS.Add(alert);
			}

			return Alert_NCARDSSUCESS;
		}

	}
}
