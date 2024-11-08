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
	public class People_ViewModel : EmptyFormViewModel
	{
		/// <summary>Campo : "" Tipo:"DA"</summary>
		public TablePartial<GenioMVC.Models.Pesso> ValPeoplels { get; set; }


		#region DatabaseFields used in title buttons

		#endregion


		#region Foreign Keys
		#endregion

		#region Fields for formulas
		#endregion

		#region ViewModel People ()

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public People_ViewModel() : base() { }

		public People_ViewModel(NavigationContext currentNavigation, bool nestedForm = false)
			: base(currentNavigation, nestedForm) { }

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PEOPLE]/
		}

		private void LoadArrays()
		{
			// Load used arrays into form fields. Can be empty.
		}

		#endregion

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PEOPLE]/
		#endregion
	}
}
