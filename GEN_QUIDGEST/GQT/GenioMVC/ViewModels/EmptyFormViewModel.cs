using System.Collections.Specialized;

using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public abstract class EmptyFormViewModel : ViewModelBase
	{
		public EmptyFormViewModel()
		{
			InitLevels();
		}

		public EmptyFormViewModel(NavigationContext currentNavigation, bool nestedForm = false)
		{
			InitLevels();
			this.NestedForm = nestedForm;
			this.Navigation = currentNavigation;
		}

		public void Load(NameValueCollection qs)
		{
			LoadPartial(qs);
		}

		protected abstract void InitLevels();

		public abstract void LoadPartial(NameValueCollection qs, bool lazyLoad = false);
	}
}
