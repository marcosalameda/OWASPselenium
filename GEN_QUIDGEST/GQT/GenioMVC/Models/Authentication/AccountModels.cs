using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

using CSGenio.framework;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Psw;
using GenioMVC.ViewModels.UserAdmin;
using GenioServer.security;

namespace GenioMVC.Models
{
	#region Models

	public class BasicUserModel : ViewModels.ViewModelBase
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "UTILIZADOR52387", ResourceType = typeof(Resources.Resources))]
		public string UserName { get; set; }

		[AllowHtml]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.Password)]
		[Display(Name = "PALAVRA_CHAVE39832", ResourceType = typeof(Resources.Resources))]
		public string Password { get; set; }
	}

	public class AChangePasswordModel : ViewModels.ViewModelBase
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[ValidatePasswordLength]
		[DataType(DataType.Password)]
		[Display(Name = "NOVA_PALAVRA_CHAVE09647", ResourceType = typeof(Resources.Resources))]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "CONFIRMAR_NOVA_PALAV02846", ResourceType = typeof(Resources.Resources))]
		[System.Web.Mvc.Compare("NewPassword", ErrorMessageResourceName = "A_NOVA_PALAVRA_CHAVE41230", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ConfirmPassword { get; set; }
	}

	public class PasswordRecoverChangeModel : AChangePasswordModel
	{
		[Display(Name = "UTILIZADOR52387", ResourceType = typeof(Resources.Resources))]
		public string UserId { get; set; }
	}

	public class ChangePasswordModel : AChangePasswordModel
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.Password)]
		[Display(Name = "PALAVRA_CHAVE_ACTUAL29965", ResourceType = typeof(Resources.Resources))]
		public string OldPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "PALAVRA_CHAVE39832", ResourceType = typeof(Resources.Resources))]
		public string Password { get; set; }

		public bool Enable2FAOptions { get; set; }
	}

	public class ProfileModel : ChangePasswordModel
	{
		public List<string> OpenIdConnAuthMethods { get; set; }

		public string ValCodpsw { get; set; }

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "UTILIZADOR52387", ResourceType = typeof(Resources.Resources))]
		public string ValNome { get; set; }

		public ProfileModel()
		{
			if (OpenIdConnAuthMethods == null)
				OpenIdConnAuthMethods = new List<string>();
		}

		public void Load(string key)
		{
		}

		public void Save()
		{
			Models.Psw item = null;

			// Precisamos posicionar a ficha to não "estragar" o Qvalue do zzstate
			try
			{
				item = Models.Psw.Find(UserContext.Current.User.Codpsw, "FPSW");
			}
			finally
			{
				if (item == null)
					item = new Models.Psw();
			}

			item.ValPasswordDecrypted = NewPassword;
			item.ValStatus = 0;
			item.Save();
		}

		public void Apply()
		{
			Models.Psw item = null;

			// Precisamos posicionar a ficha to não "estragar" o Qvalue do zzstate
			try
			{
				item = Models.Psw.Find(UserContext.Current.User.Codpsw, "FPSW");
			}
			finally
			{
				if (item == null)
					item = new Models.Psw();
			}

			item.ValPasswordDecrypted = NewPassword;
			item.ValStatus = 0;
			item.Apply();
		}
	}

	public class LogOnModel : BasicUserModel
	{
		public List<string> OpenIdConnAuthMethods { get; set; }

		public List<string> CASAuthMethods { get; set; }

		public List<string> CMDAuthMethods { get; set; }

		public void Load()
		{
			if (OpenIdConnAuthMethods == null)
				OpenIdConnAuthMethods = new List<string>();

			if (CASAuthMethods == null)
				CASAuthMethods = new List<string>();

			if (CMDAuthMethods == null)
				CMDAuthMethods = new List<string>();
		}

		/// <summary>
		/// Checks if the application is setup to allow password recovery
		/// </summary>
		/// <returns></returns>
		public bool HasPasswordRecovery
		{
			get { return SecurityFactory.HasPasswordManagement() && !string.IsNullOrEmpty(Configuration.PasswordRecoveryEmail); }
		}

		/// <summary>
		/// Determines whether username and password authentication is enabled.
		/// </summary>
		/// <remarks>
		/// This property returns true if either QuidgestIdentityProvider or LdapIdentityProvider is present in the list of identity providers.
		/// This is used to determine if username and password authentication is enabled, assuming that either QuidgestIdentityProvider
		/// or LdapIdentityProvider supports this method of authentication.
		/// </remarks>
		public bool HasUsernameAuth
		{
			get { return SecurityFactory.HasUsernameAuth(); }
		}
	}

	public class RegisterModel : BasicUserModel
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "CONFIRMAR09808", ResourceType = typeof(Resources.Resources))]
		[System.Web.Mvc.Compare("Password", ErrorMessageResourceName = "A_NOVA_PALAVRA_CHAVE41230", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ConfirmPassword { get; set; }
	}

	#endregion

	#region Services

	// The FormsAuthentication type is sealed and contains static members, so it is difficult to
	// unit test code that calls its members. The interface and helper class below demonstrate
	// how to create an abstract wrapper around such a type in order to make the AccountController
	// code unit testable.

	public interface IMembershipService
	{
		int MinPasswordLength { get; }

		bool ValidateUser(string userName, string password);

		MembershipCreateStatus CreateUser(string userName, string password, string email);

		bool ChangePassword(string userName, string oldPassword, string newPassword);
	}

	public class AccountMembershipService : IMembershipService
	{
		private readonly MembershipProvider _provider;

		public AccountMembershipService() : this(null) { }

		public AccountMembershipService(MembershipProvider provider)
		{
			_provider = provider ?? Membership.Provider;
		}

		public int MinPasswordLength
		{
			get
			{
				return _provider.MinRequiredPasswordLength;
			}
		}

		public bool ValidateUser(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("Value cannot be null or empty.", "password");

			return _provider.ValidateUser(userName, password);
		}

		public MembershipCreateStatus CreateUser(string userName, string password, string email)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("Value cannot be null or empty.", "password");
			if (string.IsNullOrEmpty(email))
				throw new ArgumentException("Value cannot be null or empty.", "email");

			MembershipCreateStatus status;
			_provider.CreateUser(userName, password, email, null, null, true, null, out status);

			return status;
		}

		public bool ChangePassword(string userName, string oldPassword, string newPassword)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (string.IsNullOrEmpty(oldPassword))
				throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
			if (string.IsNullOrEmpty(newPassword))
				throw new ArgumentException("Value cannot be null or empty.", "newPassword");

			// The underlying ChangePassword() will throw an exception rather
			// than return false in certain failure scenarios.
			try
			{
				MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
				return currentUser.ChangePassword(oldPassword, newPassword);
			}
			catch (ArgumentException)
			{
				return false;
			}
			catch (MembershipPasswordException)
			{
				return false;
			}
		}
	}

	public interface IFormsAuthenticationService
	{
		void SignIn(string userName, bool createPersistentCookie);
		void SignOut();
	}

	public class FormsAuthenticationService : IFormsAuthenticationService
	{
		public void SignIn(string userName, bool createPersistentCookie)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentException("Value cannot be null or empty.", "userName");

			FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}

	#endregion

	#region Validation

	public static class AccountValidation
	{
		public static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "Username already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A username for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
	{
		private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";
		// To be compatible with BO and QWeb solutions we must allow passwords with size 1
		private readonly int _minCharacters = 1;

		public ValidatePasswordLengthAttribute() : base(_defaultErrorMessage) { }

		public override string FormatErrorMessage(string name)
		{
			return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _minCharacters);
		}

		public override bool IsValid(object value)
		{
			string valueAsString = value as string;
			return valueAsString != null && valueAsString.Length >= _minCharacters;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			return new[]
			{
				new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), _minCharacters, int.MaxValue)
			};
		}
	}

	#endregion
}
