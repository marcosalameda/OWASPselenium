using Microsoft.AspNetCore.Mvc.Rendering;

using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Perso
{
	public class WMS_Menu_4321_ViewModel : ViewModelBase
	{
		public SelectList List_ValGender;

		public WMS_Menu_4321_ViewModel(UserContext userContext) : base(userContext)
		{
			this.List_ValGender = new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value");
		}
	}
}
