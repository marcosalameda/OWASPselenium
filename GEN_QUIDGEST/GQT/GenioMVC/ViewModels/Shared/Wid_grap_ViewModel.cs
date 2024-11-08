using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CSGenio.business;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using System.Collections.Specialized;
using GenioMVC.Models.Exception;
using CSGenio.framework;
using GenioMVC.Helpers.Table.Properties;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.ViewModels
{
	public class Wid_grap_ViewModel : EmptyFormViewModel
	{
		/// <summary>Campo : "Company's people count" Tipo:"DA"</summary>
		[Display(Name = "COMPANY_S_PEOPLE_COU57461", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Cmpny> ValField001 { get; set; }


		#region DatabaseFields used in title buttons

		#endregion


		#region Foreign Keys
		#endregion

		#region Fields for formulas
		#endregion

		#region ViewModel Wid_grap ()

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public Wid_grap_ViewModel() : base() { }

		public Wid_grap_ViewModel(NavigationContext currentNavigation, bool nestedForm = false)
			: base(currentNavigation, nestedForm) { }

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL WID_GRAP]/
		}

		private void LoadArrays()
		{
			// Load used arrays into form fields. Can be empty.
		}

		#endregion

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_GRAP]/
		#endregion
	}
}
