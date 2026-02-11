using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels
{
	public class Lendexpl_ViewModel(UserContext userContext, bool nestedForm = false) : EmptyFormViewModel(userContext, nestedForm)
	{
		/// <summary>
		/// Title: "Equipment: Bought" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValBought 
		{
			get
			{
				return funcValBought != null ? funcValBought() : _auxValBought;
			}
			set { funcValBought = () => value; }
		}

		[JsonIgnore]
		public Func<bool> funcValBought { get; set; }

		private bool _auxValBought { get; set; }
		/// <summary>
		/// Title: "Lending: Returned" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValReturned 
		{
			get
			{
				return funcValReturned != null ? funcValReturned() : _auxValReturned;
			}
			set { funcValReturned = () => value; }
		}

		[JsonIgnore]
		public Func<bool> funcValReturned { get; set; }

		private bool _auxValReturned { get; set; }
		#region DatabaseFields used in title buttons



		#endregion

		#region Tab region


		#endregion

		#region Foreign Keys


		#endregion

		#region Fields for formulas



		#endregion

		#region Global filters fields
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
