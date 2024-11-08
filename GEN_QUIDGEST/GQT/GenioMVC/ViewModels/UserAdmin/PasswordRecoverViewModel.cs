using System;
using System.ComponentModel.DataAnnotations;

namespace GenioMVC.ViewModels.UserAdmin
{
	public class PasswordRecoverViewModel
	{
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "EMAIL_44228", ResourceType = typeof(Resources.Resources))]
		public string Email { get; set; }

		/// <summary>
		/// Checks if the email was already sent or not
		/// </summary>
		public bool IsEmailSent { get; set; }
	}
}
