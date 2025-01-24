using System;
using System.Collections.Specialized;

using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.ViewModels.Lendi
{
	public class GQT_MenuSE_151_ViewModel
	{
		[JsonIgnore]
		public NavigationContext Navigation { get; set; }

		private DateTime? _minValue = null;
		private DateTime? _maxValue = null;

		[DateAttribute("DT")]
		public DateTime? ValMinvalue { get { return _minValue; } }

		[DateAttribute("DT")]
		public DateTime? ValMaxvalue { get { return _maxValue; } }

		public GQT_MenuSE_151_ViewModel(UserContext userContext)
		{
			this.Navigation = userContext.CurrentNavigation;

			this._minValue = HtmlHelpers.GetBetweenLimitsDateValue("1A", userContext.User.NumericYear);
			this._maxValue = HtmlHelpers.GetBetweenLimitsDateValue("HJ", userContext.User.NumericYear);
		}

	}
}
