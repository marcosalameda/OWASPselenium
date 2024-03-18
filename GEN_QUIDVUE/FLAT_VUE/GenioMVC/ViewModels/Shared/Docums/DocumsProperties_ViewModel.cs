using System.ComponentModel.DataAnnotations;
using System.Globalization;

using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	[Newtonsoft.Json.JsonObject(memberSerialization: Newtonsoft.Json.MemberSerialization.OptIn)]
	public class DocumsProperties_ViewModel : ViewModelBase
	{
		[Newtonsoft.Json.JsonProperty]
		public string Coddocums;

		[Newtonsoft.Json.JsonProperty]
		public string DocumId { get; set; }

		[Display(Name = "NOME__48276", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string Name { get; set; }

		[Display(Name = "TAMANHO__48454", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string Size { get; set; }

		[Display(Name = "EXTENSAO__24742", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string FileType { get; set; }

		[Display(Name = "AUTOR__36547", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string Author { get; set; }

		[Display(Name = "DATA_DE_CRIACAO__05001", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string CreatedAt { get; set; }

		[Display(Name = "VERSAO_ATUAL__01161", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string Version { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public bool IsCheckout { get; set; }

		[Display(Name = "EM_EDICAO_POR__14850", ResourceType = typeof(Resources.Resources))]
		[Newtonsoft.Json.JsonProperty]
		public string CheckoutEditor { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public SortedList<String, String> Versions { get; set; }

		public DocumsProperties_ViewModel(UserContext userContext, string coddocums, string documId, string name, string size, string extension, string author, string createdAt, string version, bool isCheckout, string checkoutEditor, SortedList<string, string> versions) : base(userContext)
		{
			Coddocums = coddocums;
			DocumId = documId;
			Name = name;
			Size = size;
			FileType = extension;
			Author = author;
			if (!string.IsNullOrEmpty(createdAt))
				CreatedAt = DateTime.Parse(createdAt, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
			Version = version;
			this.IsCheckout = isCheckout;
			this.CheckoutEditor = checkoutEditor;
			this.Versions = versions;
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public DocumsProperties_ViewModel() : base(null!) { }

		public DocumsProperties_ViewModel(UserContext userContext) : base(userContext) { }

		public bool IsCurrentUserEditing()
		{
			return m_userContext.User.Name == this.CheckoutEditor;
		}

		public bool IsEmpty()
		{
			return Versions == null || Versions.Count == 0;
		}

		public string MinorVersion
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Version))
					return string.Empty;

				int index = Version.IndexOf('.');
				if (index == -1)
					return Version + ".1";

				string decimalPart = Version.Substring(index + 1);
				int intDecimalPart = int.Parse(decimalPart) + 1;
				return Version.Substring(0, index + 1) + intDecimalPart;
			}
		}

		public string MajorVersion
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Version)) return string.Empty;
				int index = Version.IndexOf('.');
				int version = -1;
				if (index == -1)
					version = int.Parse(Version);
				else
				{
					string numericPart = Version.Substring(0, index);
					version = int.Parse(numericPart);
				}
				return (version + 1).ToString();
			}
		}
	}

	public class DocumsControl_ViewModel : DocumsProperties_ViewModel
	{
		public string Model { get; set; }

		public string FieldName { get; set; }

		public string FieldNameFK { get; set; }

		public string ModelKey { get; set; }

		public bool UsesTemplates { get; set; }

		public string Ticket { get; set; }

		public DocumsControl_ViewModel(UserContext userContext, string ticket, string model, string fldname, string modelKey, string documId, string coddocums, string name, string size, string extension, string author, string createdAt, string version, bool isCheckout, string checkoutEditor, SortedList<string, string> versions, bool usesTemplates)
			: base(userContext, coddocums, documId, name, size, extension, author, createdAt, version, isCheckout, checkoutEditor, versions)
		{
			this.Ticket = ticket;
			this.Model = model;
			this.FieldName = fldname;
			this.FieldNameFK = fldname + "fk";
			this.ModelKey = modelKey;
			this.UsesTemplates = usesTemplates;
		}

		public static DocumsControl_ViewModel FromPropertiesToDocums(UserContext userContext, string model, string fldname, string modelKey, string documId, DocumsProperties_ViewModel other, bool usesTemplates)
		{
			ResourceQuery resource = new ResourceQuery(other.Name, model.ToLower(), fldname, "", modelKey);
			string ticket = QResources.CreateTicketEncryptedBase64(userContext.User.Name, userContext.User.Location, resource);
			return new DocumsControl_ViewModel(userContext, ticket, model, fldname, modelKey, documId, other.Coddocums, other.Name, other.Size, other.FileType, other.Author, other.CreatedAt, other.Version, other.IsCheckout, other.CheckoutEditor, other.Versions, usesTemplates);
		}
	}
}
