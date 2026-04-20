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
	public class Wid_pess_ViewModel(UserContext userContext, bool nestedForm = false) : EmptyFormViewModel(userContext, nestedForm)
	{

		#region DatabaseFields used in title buttons



		#endregion

		#region Tab region


		#endregion

		#region Foreign Keys


		#endregion

		#region Fields for formulas



		#endregion

		#region ViewModel Wid_pess ()

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		protected override void FillExtraProperties()
		{
		}

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL WID_PESS]/
		}

		#endregion

		#region Global filter lookup fields

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					default:
						Log.Error($"SetViewModelValue (Wid_pess) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Wid_pess)", "Unexpected error", ex);
			}
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_PESS]/

		#endregion
	}
}
