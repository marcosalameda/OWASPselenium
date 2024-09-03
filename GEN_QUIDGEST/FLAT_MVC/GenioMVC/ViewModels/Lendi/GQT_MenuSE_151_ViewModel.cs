using System;
using System.Collections.Specialized;

using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Lendi
{
	public class GQT_MenuSE_151_ViewModel
	{
		[Newtonsoft.Json.JsonIgnore]
		public NavigationContext Navigation { get; set; }

		private DateTime? _minValue = null;
		private DateTime? _maxValue = null;

		[DateAttribute("DT")]
		public DateTime? ValMinvalue { get { return _minValue; } }

		[DateAttribute("DT")]
		public DateTime? ValMaxvalue { get { return _maxValue; } }

		public GQT_MenuSE_151_ViewModel(NavigationContext currentNavigation)
		{
			this.Navigation = currentNavigation;

			this._minValue = HtmlHelpers.GetBetweenLimitsDateValue("1A");
			this._maxValue = HtmlHelpers.GetBetweenLimitsDateValue("HJ");
		}

	}
}
