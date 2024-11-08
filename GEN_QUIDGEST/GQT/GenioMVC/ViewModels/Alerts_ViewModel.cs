using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

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
		private NavigationContext Navigation { get; set; }

		private NameValueCollection QueryString { get; set; }

		private bool IsAjaxRequest { get; set; }

		public Alerts_ViewModel(NavigationContext navigation, NameValueCollection queryString = null, bool isAjaxRequest = true)
		{
			Navigation = navigation;
			QueryString = queryString;
			IsAjaxRequest = isAjaxRequest;
		}

		public List<Models.Navigation.Alert> GenAlerts()
		{
			var user = UserContext.Current.User;
			var sp = UserContext.Current.PersistentSupport;

			List<Models.Navigation.Alert> alerts = new List<Models.Navigation.Alert>();

			sp.openConnection();
 			alerts.AddRange(GenAlert_NCARDSDANGER(sp, user));
 			alerts.AddRange(GenAlert_NCARDSWARNING(sp, user));
 			alerts.AddRange(GenAlert_NCARDSINFO(sp, user));
 			alerts.AddRange(GenAlert_DEVOLUCAO(sp, user));
 			alerts.AddRange(GenAlert_NCARDSSUCESS(sp, user));
			sp.closeConnection();

			return alerts;
		}

 		public List<Models.Navigation.Alert> GenAlert_NCARDSDANGER(PersistentSupport sp, User user)
		{
			List<Models.Navigation.Alert> Alert_NCARDSDANGER = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);
			int dismissible = 1;
			int disableIfLowerThan = 0;
			int alertType = 3;
			string idalert = "NCARDSDANGER";

			//inits
			string alertModule = string.Empty;
			double alertTagValue = 0;
			string action = string.Empty;
			string controller = string.Empty;
			object additionalRouteValues = null;

			Role alertRole = Role.ROLE_1;

			if (!user.VerifyAccess(alertRole))
				return Alert_EMPTY;

			// Tag processing
			{ //{STY_OVERVIEW_Count}
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(Navigation);
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
				action = "STY_Menu_OVERVIEW";
				controller = "UICOM";

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				// Alert will be displayed only in this module
				alertModule = "STY";

				System.Web.Mvc.UrlHelper urlHelper
					= new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

				//JGF 2022.04.21 Should always redirect to the target module, or the EPH won't be correctly applied
				additionalRouteValues = new { module = "STY"};
				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Dismissible = dismissible,
					Idalert = idalert,
					Module = alertModule,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Action = action,
					Controller = controller,
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
					AdditionalRouteValues = additionalRouteValues,
					DisableIfLowerThan = disableIfLowerThan,
					URL = urlHelper.Action(action, controller, additionalRouteValues)
				};
				Alert_NCARDSDANGER.Add(alert);


			}

			return Alert_NCARDSDANGER;
		}

 		public List<Models.Navigation.Alert> GenAlert_NCARDSWARNING(PersistentSupport sp, User user)
		{
			List<Models.Navigation.Alert> Alert_NCARDSWARNING = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);
			int dismissible = 1;
			int disableIfLowerThan = 0;
			int alertType = 2;
			string idalert = "NCARDSWARNING";

			//inits
			string alertModule = string.Empty;
			double alertTagValue = 0;
			string action = string.Empty;
			string controller = string.Empty;
			object additionalRouteValues = null;

			Role alertRole = Role.ROLE_1;

			if (!user.VerifyAccess(alertRole))
				return Alert_EMPTY;

			// Tag processing
			{ //{STY_OVERVIEW_Count}
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(Navigation);
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
				action = "STY_Menu_OVERVIEW";
				controller = "UICOM";

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				// Alert will be displayed only in this module
				alertModule = "STY";

				System.Web.Mvc.UrlHelper urlHelper
					= new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

				//JGF 2022.04.21 Should always redirect to the target module, or the EPH won't be correctly applied
				additionalRouteValues = new { module = "STY"};
				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Dismissible = dismissible,
					Idalert = idalert,
					Module = alertModule,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Action = action,
					Controller = controller,
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
					AdditionalRouteValues = additionalRouteValues,
					DisableIfLowerThan = disableIfLowerThan,
					URL = urlHelper.Action(action, controller, additionalRouteValues)
				};
				Alert_NCARDSWARNING.Add(alert);


			}

			return Alert_NCARDSWARNING;
		}

 		public List<Models.Navigation.Alert> GenAlert_NCARDSINFO(PersistentSupport sp, User user)
		{
			List<Models.Navigation.Alert> Alert_NCARDSINFO = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);
			int dismissible = 1;
			int disableIfLowerThan = 0;
			int alertType = 1;
			string idalert = "NCARDSINFO";

			//inits
			string alertModule = string.Empty;
			double alertTagValue = 0;
			string action = string.Empty;
			string controller = string.Empty;
			object additionalRouteValues = null;

			Role alertRole = Role.ROLE_1;

			if (!user.VerifyAccess(alertRole))
				return Alert_EMPTY;

			// Tag processing
			{ //{STY_OVERVIEW_Count}
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(Navigation);
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
				action = "STY_Menu_OVERVIEW";
				controller = "UICOM";

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				// Alert will be displayed only in this module
				alertModule = "STY";

				System.Web.Mvc.UrlHelper urlHelper
					= new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

				//JGF 2022.04.21 Should always redirect to the target module, or the EPH won't be correctly applied
				additionalRouteValues = new { module = "STY"};
				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Dismissible = dismissible,
					Idalert = idalert,
					Module = alertModule,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Action = action,
					Controller = controller,
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
					AdditionalRouteValues = additionalRouteValues,
					DisableIfLowerThan = disableIfLowerThan,
					URL = urlHelper.Action(action, controller, additionalRouteValues)
				};
				Alert_NCARDSINFO.Add(alert);


			}

			return Alert_NCARDSINFO;
		}

 		public List<Models.Navigation.Alert> GenAlert_DEVOLUCAO(PersistentSupport sp, User user)
		{
			List<Models.Navigation.Alert> Alert_DEVOLUCAO = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("_GQT_DEVOL_COUNT__TO39432", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_GQT_DEVOL_COUNT__TO39432", user.Language);
			int dismissible = 1;
			int disableIfLowerThan = -1;
			int alertType = 0;
			string idalert = "DEVOLUCAO";

			//inits
			string alertModule = string.Empty;
			double alertTagValue = 0;
			string action = string.Empty;
			string controller = string.Empty;
			object additionalRouteValues = null;

			Role alertRole = Role.ROLE_1;

			if (!user.VerifyAccess(alertRole))
				return Alert_EMPTY;

			// Tag processing
			{ //{GQT_DEVOL_Count}
				// Count menu records
				ViewModels.Lendi.GQT_Menu_DEVOL_ViewModel vm = new ViewModels.Lendi.GQT_Menu_DEVOL_ViewModel(Navigation);
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
				action = "GQT_Menu_DEVOL";
				controller = "LENDI";

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

				System.Web.Mvc.UrlHelper urlHelper
					= new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

				//JGF 2022.04.21 Should always redirect to the target module, or the EPH won't be correctly applied
				additionalRouteValues = new { module = "GQT"};
				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Dismissible = dismissible,
					Idalert = idalert,
					Module = alertModule,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Action = action,
					Controller = controller,
					Target = new AlertClickTarget() { Type = "menu", Name = "GQT_DEVOL" },
					AdditionalRouteValues = additionalRouteValues,
					DisableIfLowerThan = disableIfLowerThan,
					URL = urlHelper.Action(action, controller, additionalRouteValues)
				};
				Alert_DEVOLUCAO.Add(alert);


			}

			return Alert_DEVOLUCAO;
		}

 		public List<Models.Navigation.Alert> GenAlert_NCARDSSUCESS(PersistentSupport sp, User user)
		{
			List<Models.Navigation.Alert> Alert_NCARDSSUCESS = new List<Models.Navigation.Alert>();
			List<Models.Navigation.Alert> Alert_EMPTY = new List<Models.Navigation.Alert>();

			string alertTitle = CSGenio.framework.Translations.GetByCode("THERE_ARE__STY_OVERV27174", user.Language);
			string alertText = CSGenio.framework.Translations.GetByCode("_STY_OVERVIEW_COUNT_30342", user.Language);
			int dismissible = 1;
			int disableIfLowerThan = 0;
			int alertType = 0;
			string idalert = "NCARDSSUCESS";

			//inits
			string alertModule = string.Empty;
			double alertTagValue = 0;
			string action = string.Empty;
			string controller = string.Empty;
			object additionalRouteValues = null;

			Role alertRole = Role.ROLE_1;

			if (!user.VerifyAccess(alertRole))
				return Alert_EMPTY;

			// Tag processing
			{ //{STY_OVERVIEW_Count}
				// Count menu records
				ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel vm = new ViewModels.Uicom.STY_Menu_OVERVIEW_ViewModel(Navigation);
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
				action = "STY_Menu_OVERVIEW";
				controller = "UICOM";

				CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.List);
				user.CurrentModule = oldCurrentModule;

				if (result.Status.Equals(CSGenio.framework.Status.E))
					return Alert_EMPTY;

				// Alert will be displayed only in this module
				alertModule = "STY";

				System.Web.Mvc.UrlHelper urlHelper
					= new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

				//JGF 2022.04.21 Should always redirect to the target module, or the EPH won't be correctly applied
				additionalRouteValues = new { module = "STY"};
				Models.Navigation.Alert alert = new Models.Navigation.Alert()
				{
					Count = tagValue,
					Content = alertText,
					Dismissible = dismissible,
					Idalert = idalert,
					Module = alertModule,
					Title = alertTitle,
					Type = Enum.GetName(typeof(AlertType), alertType),
					Action = action,
					Controller = controller,
					Target = new AlertClickTarget() { Type = "menu", Name = "STY_OVERVIEW" },
					AdditionalRouteValues = additionalRouteValues,
					DisableIfLowerThan = disableIfLowerThan,
					URL = urlHelper.Action(action, controller, additionalRouteValues)
				};
				Alert_NCARDSSUCESS.Add(alert);


			}

			return Alert_NCARDSSUCESS;
		}

	}
}
