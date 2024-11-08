using System;
using System.Collections.Generic;
using System.Linq;

using CSGenio.persistence;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Dashboard
{
	public abstract class Widget : WidgetProperties
	{
		/// <summary>
		/// The type of the widget.
		/// </summary>
		/// <remarks>
		/// Only used to preserve the type of the widget during JSON encoding.
		/// </remarks>
		public abstract WidgetType Type { get; }

		public abstract object GetData();

		public abstract bool UserHasAccess();
	}

	public class AlertWidget : Widget
	{
		/// <summary>
		/// A type that safely encapsulates the method to generate the alert.
		/// </summary>
		/// <param name="sp">The persistent support.</param>
		/// <param name="user">The user.</param>
		public delegate List<GenioMVC.Models.Navigation.Alert>
			GenAlert(PersistentSupport sp, CSGenio.framework.User user);

		/// <summary>
		/// The identifier of the alert associated with the widget
		/// </summary>
		public string Idalert;

		/// <summary>
		/// The alert generation method
		/// </summary>
		private readonly GenAlert _generateAlert;

		public override WidgetType Type { get => WidgetType.Alert; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlertWidget"/> class.
		/// </summary>
		/// <param name="generateAlert">The alert generation method.</param>
		public AlertWidget(GenAlert generateAlert)
		{
			_generateAlert = generateAlert;
		}

		public override object GetData()
		{
			var user = UserContext.Current.User;
			var sp = UserContext.Current.PersistentSupport;

			sp.openConnection();
			GenioMVC.Models.Navigation.Alert alert = _generateAlert(sp, user).FirstOrDefault();
			sp.closeConnection();

			if (alert != null)
				return new AlertDto(alert);
			return null;
		}

		public override bool UserHasAccess()
		{
			var user = UserContext.Current.User;
			return user.VerifyAccess(Role);
		}
	}

	public class CustomWidget : Widget
	{
		public string Form { get; set; }

		public string Component { get; set; }

		public override WidgetType Type { get => WidgetType.Custom; }

		public override object GetData()
		{
			throw new NotSupportedException();
		}

		public override bool UserHasAccess()
		{
			var user = UserContext.Current.User;
			return user.VerifyAccess(Role);
		}
	}

	public class MenuWidget : Widget
	{
		public string Path { get; set; }

		public GenioMVC.Helpers.Menus.MenuEntry MenuEntry { get; set; }

		public string ButtonText { get; set; }

		public override WidgetType Type { get => WidgetType.Menu; }

		public override object GetData()
		{
			throw new NotSupportedException();
		}

		public override bool UserHasAccess()
		{
			return true;
		}
	}

	public class BookmarkWidget : MenuWidget
	{
		public BookmarkWidget(GenioMVC.ViewModels.Bookmarks.Bookmark_Menu_ViewModel bookmark)
		{
			Module = bookmark.Module;
			Path = bookmark.Description;
			MenuEntry = bookmark.MenuEntryObj;
		}

		public override WidgetType Type { get => WidgetType.Bookmark; }
	}

	public class CustomPaginatedWidget : Widget
	{
		public string Form { get; set; }

		public string Component { get; set; }

		/// <summary>
		/// The primary key associated with the widget from
		/// </summary>
		public List<string> Keys;

		public override WidgetType Type { get => WidgetType.CustomPaginated; }

		public override object GetData()
		{
			throw new NotSupportedException();
		}

		public override bool UserHasAccess()
		{
			var user = UserContext.Current.User;
			return user.VerifyAccess(Role);
		}
	}
}
