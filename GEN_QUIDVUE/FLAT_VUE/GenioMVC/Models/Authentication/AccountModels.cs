using System;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using GenioServer.security;
using System.ComponentModel.DataAnnotations;

namespace GenioMVC.Models
{

	public class BasicUserModel
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "UTILIZADOR52387", ResourceType = typeof(Resources.Resources))]
		public string UserName { get; set; }

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.Password)]
		[Display(Name = "PALAVRA_CHAVE39832", ResourceType = typeof(Resources.Resources))]
		public string Password { get; set; }
	}

	public class AChangePasswordModel
	{
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.Password)]
		[Display(Name = "NOVA_PALAVRA_CHAVE09647", ResourceType = typeof(Resources.Resources))]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "CONFIRMAR_NOVA_PALAV02846", ResourceType = typeof(Resources.Resources))]
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


		public void Save(UserContext userContext)
		{
			Models.Psw item = null;

			// Precisamos posicionar a ficha to não "estragar" o Qvalue do zzstate
			try
			{
				item = Models.Psw.Find(userContext.User.Codpsw, userContext, "FPSW");
			}
			finally
			{
				if (item == null)
					item = new Models.Psw(userContext);
			}

			item.ValPasswordDecrypted = NewPassword;
			item.ValStatus = 0;
			item.Save();
		}

		public void Apply(UserContext userContext)
		{
			Models.Psw item = null;

			// Precisamos posicionar a ficha to não "estragar" o Qvalue do zzstate
			try
			{
				item = Models.Psw.Find(userContext.User.Codpsw, userContext,"FPSW");
			}
			finally
			{
				if (item == null)
					item = new Models.Psw(userContext);
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
		public string ConfirmPassword { get; set; }
	}

}
