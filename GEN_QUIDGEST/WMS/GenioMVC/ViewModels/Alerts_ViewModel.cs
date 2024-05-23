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
			sp.closeConnection();

			return alerts;
		}

	}
}
