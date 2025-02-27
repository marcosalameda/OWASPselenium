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
	public class Wid_equi_ViewModel : EmptyFormViewModel
	{
		/// <summary>Campo : "" Tipo:"DA"</summary>
		public TablePartial<GenioMVC.Models.Equip> ValWidequi { get; set; }


		#region DatabaseFields used in title buttons

		#endregion


		#region Foreign Keys
		#endregion

		#region Fields for formulas
		#endregion

		#region ViewModel Wid_equi (Equip)

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		public Wid_equi_ViewModel() : base() { }

		public Wid_equi_ViewModel(NavigationContext currentNavigation, bool nestedForm = false)
			: base(currentNavigation, nestedForm) { }

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL WID_EQUI]/
		}

		private void LoadArrays()
		{
			// Load used arrays into form fields. Can be empty.
		}

		#endregion

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_EQUI]/
		#endregion
	}
}
