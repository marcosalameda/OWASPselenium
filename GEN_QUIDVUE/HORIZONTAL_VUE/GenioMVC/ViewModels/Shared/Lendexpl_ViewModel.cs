using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels
{
	public class Lendexpl_ViewModel(UserContext userContext, bool nestedForm = false) : EmptyFormViewModel(userContext, nestedForm)
	{
		/// <summary>
		/// Title: "Lender: Gender" | Type: "AC"
		/// </summary>
		public List<string> Pess1ValGender { get; set; }
		/// <summary>
		/// Title: "Equipment: Loan frequency" | Type: "AN"
		/// </summary>
		public List<decimal> EquipValFrequenc { get; set; }
		/// <summary>
		/// Title: "Equipment: Bought" | Type: "L"
		/// </summary>
		public bool EquipValBought { get; set; }
		/// <summary>
		/// Title: "Lending: Returned" | Type: "L"
		/// </summary>
		public bool LendiValReturned { get; set; }
		#region DatabaseFields used in title buttons



		#endregion

		#region Tab region


		#endregion

		#region Foreign Keys


		#endregion

		#region Fields for formulas



		#endregion

		#region ViewModel Lendexpl (Explore lendings)

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LENDEXPL]/
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LENDEXPL]/

		#endregion
	}
}
