using System;
using System.Collections.Specialized;

using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.ViewModels.Equip
{
	public class PTN_MenuSE_3G1_ViewModel
	{
		[JsonIgnore]
		public NavigationContext Navigation { get; set; }

		private DateTime? _minValue = null;
		private DateTime? _maxValue = null;

		[DateAttribute("D")]
		public DateTime? ValMinvalue { get { return _minValue; } }

		[DateAttribute("D")]
		public DateTime? ValMaxvalue { get { return _maxValue; } }

		public PTN_MenuSE_3G1_ViewModel(UserContext userContext)
		{
			this.Navigation = userContext.CurrentNavigation;

			this._minValue = HtmlHelpers.GetBetweenLimitsDateValue("1M", userContext.User.NumericYear);
			this._maxValue = HtmlHelpers.GetBetweenLimitsDateValue("HJ", userContext.User.NumericYear);
		}

	}
}
