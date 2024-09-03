using System;
using System.Collections.Specialized;

using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Equip
{
	public class PTN_MenuSE_3C1_ViewModel
	{
		[Newtonsoft.Json.JsonIgnore]
		public NavigationContext Navigation { get; set; }

		private DateTime? _minValue = null;
		private DateTime? _maxValue = null;

		[DateAttribute("D")]
		public DateTime? ValMinvalue { get { return _minValue; } }

		[DateAttribute("D")]
		public DateTime? ValMaxvalue { get { return _maxValue; } }

		public PTN_MenuSE_3C1_ViewModel(NavigationContext currentNavigation)
		{
			this.Navigation = currentNavigation;

			this._minValue = HtmlHelpers.GetBetweenLimitsDateValue("1M");
			this._maxValue = HtmlHelpers.GetBetweenLimitsDateValue("HJ");
		}

	}
}
