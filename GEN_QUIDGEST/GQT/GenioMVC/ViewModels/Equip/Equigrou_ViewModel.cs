using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Equip
{
	public class Equigrou_ViewModel : FormViewModel<Models.Equip>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] Pess1ValPhotogra { get { return funcPess1ValPhotogra != null ? funcPess1ValPhotogra() : _auxPess1ValPhotogra; } set { funcPess1ValPhotogra = () => value; } }
		[JsonIgnore]
		public Func<byte[]> funcPess1ValPhotogra { get; set; }
		private byte[] _auxPess1ValPhotogra { get; set; }

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess1>  TablePess1Name { get; set; }

		/// <summary>Campo : "Genre" Tipo:"AC"</summary>
		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string Pess1ValGender { get { return funcPess1ValGender != null ? funcPess1ValGender() : _auxPess1ValGender; } set { funcPess1ValGender = () => value; } }
		[JsonIgnore]
		public SelectList List_Pess1ValGender { get; set; }
		[JsonIgnore]
		public Func<string> funcPess1ValGender { get; set; }
		private string _auxPess1ValGender { get; set; }

		/// <summary>Campo : "Birth" Tipo:"D"</summary>
		[Display(Name = "BIRTH21799", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? Pess1ValDtnascim { get { return funcPess1ValDtnascim != null ? funcPess1ValDtnascim() : _auxPess1ValDtnascim; } set { funcPess1ValDtnascim = () => value; } }
		[JsonIgnore]
		public Func<DateTime?> funcPess1ValDtnascim { get; set; }
		private DateTime? _auxPess1ValDtnascim { get; set; }

		/// <summary>Campo : "Age" Tipo:"N"</summary>
		[Display(Name = "AGE28663", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? Pess1ValIdade { get { return funcPess1ValIdade != null ? funcPess1ValIdade() : _auxPess1ValIdade; } set { funcPess1ValIdade = () => value; } }
		[JsonIgnore]
		public Func<decimal?> funcPess1ValIdade { get; set; }
		private decimal? _auxPess1ValIdade { get; set; }

		/// <summary>Campo : "Official No." Tipo:"N"</summary>
		[Display(Name = "OFFICIAL_NO_34819", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? Pess1ValIdfuncio { get { return funcPess1ValIdfuncio != null ? funcPess1ValIdfuncio() : _auxPess1ValIdfuncio; } set { funcPess1ValIdfuncio = () => value; } }
		[JsonIgnore]
		public Func<decimal?> funcPess1ValIdfuncio { get; set; }
		private decimal? _auxPess1ValIdfuncio { get; set; }

		/// <summary>Campo : "Phone" Tipo:"C"</summary>
		[Display(Name = "PHONE56703", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Pess1ValTelephon { get { return funcPess1ValTelephon != null ? funcPess1ValTelephon() : _auxPess1ValTelephon; } set { funcPess1ValTelephon = () => value; } }
		[JsonIgnore]
		public Func<string> funcPess1ValTelephon { get; set; }
		private string _auxPess1ValTelephon { get; set; }

		/// <summary>Campo : "Email 1" Tipo:"C"</summary>
		[Display(Name = "EMAIL_106184", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Pess1ValEmail { get { return funcPess1ValEmail != null ? funcPess1ValEmail() : _auxPess1ValEmail; } set { funcPess1ValEmail = () => value; } }
		[JsonIgnore]
		public Func<string> funcPess1ValEmail { get; set; }
		private string _auxPess1ValEmail { get; set; }

		/// <summary>Campo : "Email 2" Tipo:"C"</summary>
		[Display(Name = "EMAIL_211233", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Pess1ValEmail2 { get { return funcPess1ValEmail2 != null ? funcPess1ValEmail2() : _auxPess1ValEmail2; } set { funcPess1ValEmail2 = () => value; } }
		[JsonIgnore]
		public Func<string> funcPess1ValEmail2 { get; set; }
		private string _auxPess1ValEmail2 { get; set; }


		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] CmpnyValLogo { get { return funcCmpnyValLogo != null ? funcCmpnyValLogo() : _auxCmpnyValLogo; } set { funcCmpnyValLogo = () => value; } }
		[JsonIgnore]
		public Func<byte[]> funcCmpnyValLogo { get; set; }
		private byte[] _auxCmpnyValLogo { get; set; }

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CmpnyValDesignat { get { return funcCmpnyValDesignat != null ? funcCmpnyValDesignat() : _auxCmpnyValDesignat; } set { funcCmpnyValDesignat = () => value; } }
		[JsonIgnore]
		public Func<string> funcCmpnyValDesignat { get; set; }
		private string _auxCmpnyValDesignat { get; set; }

		/// <summary>Campo : "Acronym" Tipo:"C"</summary>
		[Display(Name = "ACRONYM00872", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CmpnyValAcronym { get { return funcCmpnyValAcronym != null ? funcCmpnyValAcronym() : _auxCmpnyValAcronym; } set { funcCmpnyValAcronym = () => value; } }
		[JsonIgnore]
		public Func<string> funcCmpnyValAcronym { get; set; }
		private string _auxCmpnyValAcronym { get; set; }

		/// <summary>Campo : "Tax identification" Tipo:"C"</summary>
		[Display(Name = "TAX_IDENTIFICATION51190", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CmpnyValNif { get { return funcCmpnyValNif != null ? funcCmpnyValNif() : _auxCmpnyValNif; } set { funcCmpnyValNif = () => value; } }
		[JsonIgnore]
		public Func<string> funcCmpnyValNif { get; set; }
		private string _auxCmpnyValNif { get; set; }

		/// <summary>Campo : "Phone" Tipo:"C"</summary>
		[Display(Name = "PHONE56703", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CmpnyValTelephon { get { return funcCmpnyValTelephon != null ? funcCmpnyValTelephon() : _auxCmpnyValTelephon; } set { funcCmpnyValTelephon = () => value; } }
		[JsonIgnore]
		public Func<string> funcCmpnyValTelephon { get; set; }
		private string _auxCmpnyValTelephon { get; set; }

		/// <summary>Campo : "Email" Tipo:"C"</summary>
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CmpnyValEmail { get { return funcCmpnyValEmail != null ? funcCmpnyValEmail() : _auxCmpnyValEmail; } set { funcCmpnyValEmail = () => value; } }
		[JsonIgnore]
		public Func<string> funcCmpnyValEmail { get; set; }
		private string _auxCmpnyValEmail { get; set; }

		/// <summary>Campo : "Changes number" Tipo:"N"</summary>
		[Display(Name = "CHANGES_NUMBER59897", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdmovim { get; set; }

		/// <summary>Campo : "Acquisition" Tipo:"D"</summary>
		[Display(Name = "ACQUISITION44180", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtaquisi { get; set; }

		/// <summary>Campo : "TYPE OF EQUIPMENT" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT18080", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpequ>  TableTpequTipoequi { get; set; }

		/// <summary>Campo : "Code" Tipo:"TF"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string TpequValTpequcod { get { return funcTpequValTpequcod != null ? funcTpequValTpequcod() : _auxTpequValTpequcod; } set { funcTpequValTpequcod = () => value; } }
		[JsonIgnore]
		public Func<string> funcTpequValTpequcod { get; set; }
		private string _auxTpequValTpequcod { get; set; }

		/// <summary>Campo : "Maximum price" Tipo:"$D"</summary>
		[Display(Name = "MAXIMUM_PRICE55489", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? TpequValPrecomax { get { return funcTpequValPrecomax != null ? funcTpequValPrecomax() : _auxTpequValPrecomax; } set { funcTpequValPrecomax = () => value; } }
		[JsonIgnore]
		public Func<decimal?> funcTpequValPrecomax { get; set; }
		private decimal? _auxTpequValPrecomax { get; set; }

		/// <summary>Campo : "Dependent on" Tipo:"TP"</summary>
		[Display(Name = "DEPENDENT_ON28321", ResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string TpequValTpequpai { get { return funcTpequValTpequpai != null ? funcTpequValTpequpai() : _auxTpequValTpequpai; } set { funcTpequValTpequpai = () => value; } }
		[JsonIgnore]
		public Func<string> funcTpequValTpequpai { get; set; }
		private string _auxTpequValTpequpai { get; set; }

		/// <summary>Campo : "Level" Tipo:"TN"</summary>
		[Display(Name = "LEVEL06184", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public decimal TpequValNivel { get { return funcTpequValNivel != null ? funcTpequValNivel() : _auxTpequValNivel; } set { funcTpequValNivel = () => value; } }
		[JsonIgnore]
		public Func<decimal> funcTpequValNivel { get; set; }
		private decimal _auxTpequValNivel { get; set; }

		/// <summary>Campo : "Background color" Tipo:"C"</summary>
		[Display(Name = "BACKGROUND_COLOR47883", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string TpequValBackcolo { get { return funcTpequValBackcolo != null ? funcTpequValBackcolo() : _auxTpequValBackcolo; } set { funcTpequValBackcolo = () => value; } }
		[JsonIgnore]
		public Func<string> funcTpequValBackcolo { get; set; }
		private string _auxTpequValBackcolo { get; set; }

		/// <summary>Campo : "Letter color" Tipo:"C"</summary>
		[Display(Name = "LETTER_COLOR15736", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string TpequValCorletra { get { return funcTpequValCorletra != null ? funcTpequValCorletra() : _auxTpequValCorletra; } set { funcTpequValCorletra = () => value; } }
		[JsonIgnore]
		public Func<string> funcTpequValCorletra { get; set; }
		private string _auxTpequValCorletra { get; set; }

		/// <summary>Campo : "Sequential no." Tipo:"N"</summary>
		[Display(Name = "SEQUENTIAL_NO_38590", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValSequennr { get; set; }

		/// <summary>Campo : "No. register" Tipo:"C"</summary>
		[Display(Name = "NO__REGISTER04207", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(6, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegistnr { get; set; }

		/// <summary>Campo : "Total value" Tipo:"$D"</summary>
		[Display(Name = "TOTAL_VALUE30570", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValortot { get; set; }

		/// <summary>Campo : "Loan frequency" Tipo:"AN"</summary>
		[Display(Name = "LOAN_FREQUENCY00701", ResourceType = typeof(Resources.Resources))]
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValFrequenc { get; set; }
		[JsonIgnore]
		public SelectList List_ValFrequenc { get; set; }

		/// <summary>Campo : "Bought" Tipo:"L"</summary>
		[Display(Name = "BOUGHT32044", ResourceType = typeof(Resources.Resources))]
		public bool ValBought { get; set; }

		/// <summary>Campo : "Reference" Tipo:"DT"</summary>
		[Display(Name = "REFERENCE28402", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtrefere { get; set; }

		/// <summary>Campo : "First" Tipo:"C"</summary>
		[Display(Name = "FIRST42972", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFirst { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodempre { get; set; }

		public string ValCoddeco { get; set; }

		public string ValCoditem { get; set; }

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess1 { get; set; }

		public string ValCodrooms { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT18080", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Used only for lazy loading of the ItemValItemdes field</summary>
		[Newtonsoft.Json.JsonIgnore]
		public Func<string> funcItemValItemdes { get; set; }
		private string _auxItemValItemdes { get; set; }
		/// <summary>Field : "Article" Tipo: "C"</summary>
		[AllowHtml]
		public string ItemValItemdes { get { return funcItemValItemdes != null ? funcItemValItemdes() : _auxItemValItemdes; } set { funcItemValItemdes = () => value;} }
		#endregion

		public string ValCodequip { get; set; }

		public Equigrou_ViewModel() : base("FEQUIGROU") { }

		public Equigrou_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIGROU", currentNavigation, nestedForm) { }

		public Equigrou_ViewModel(Models.Equip row, NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIGROU", row, currentNavigation, nestedForm) { }

		public Equigrou_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, "FEQUIGROU", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Equip model = new Models.Equip() { Identifier = "FEQUIGROU" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Equip model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			return DeleteConditions(Model);
		}

		public static StatusMessage DeleteConditions(Models.Equip model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			return ViewConditions(Model);
		}

		public static StatusMessage ViewConditions(Models.Equip model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Equip model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equigrou) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				funcPess1ValPhotogra = () => ViewModelConversion.ToImage(m.Pess1.ValPhotogra);
 				funcPess1ValGender = () => ViewModelConversion.ToString(m.Pess1.ValGender);
 				funcPess1ValDtnascim = () => ViewModelConversion.ToDateTime(m.Pess1.ValDtnascim);
 				funcPess1ValIdade = () => ViewModelConversion.ToNumeric(m.Pess1.ValIdade);
 				funcPess1ValIdfuncio = () => ViewModelConversion.ToNumeric(m.Pess1.ValIdfuncio);
 				funcPess1ValTelephon = () => ViewModelConversion.ToString(m.Pess1.ValTelephon);
 				funcPess1ValEmail = () => ViewModelConversion.ToString(m.Pess1.ValEmail);
 				funcPess1ValEmail2 = () => ViewModelConversion.ToString(m.Pess1.ValEmail2);
 				funcCmpnyValLogo = () => ViewModelConversion.ToImage(m.Cmpny.ValLogo);
 				funcCmpnyValDesignat = () => ViewModelConversion.ToString(m.Cmpny.ValDesignat);
 				funcCmpnyValAcronym = () => ViewModelConversion.ToString(m.Cmpny.ValAcronym);
 				funcCmpnyValNif = () => ViewModelConversion.ToString(m.Cmpny.ValNif);
 				funcCmpnyValTelephon = () => ViewModelConversion.ToString(m.Cmpny.ValTelephon);
 				funcCmpnyValEmail = () => ViewModelConversion.ToString(m.Cmpny.ValEmail);
 				ValQtdmovim = ViewModelConversion.ToNumeric(m.ValQtdmovim);
 				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
 				funcTpequValTpequcod = () => ViewModelConversion.ToString(m.Tpequ.ValTpequcod);
 				funcTpequValPrecomax = () => ViewModelConversion.ToNumeric(m.Tpequ.ValPrecomax);
 				funcTpequValTpequpai = () => ViewModelConversion.ToString(m.Tpequ.ValTpequpai);
 				funcTpequValNivel = () => ViewModelConversion.ToNumeric(m.Tpequ.ValNivel);
 				funcTpequValBackcolo = () => ViewModelConversion.ToString(m.Tpequ.ValBackcolo);
 				funcTpequValCorletra = () => ViewModelConversion.ToString(m.Tpequ.ValCorletra);
 				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
 				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
 				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
 				ValFrequenc = ViewModelConversion.ToNumeric(m.ValFrequenc);
 				ValBought = ViewModelConversion.ToLogic(m.ValBought);
 				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
 				ValFirst = ViewModelConversion.ToString(m.ValFirst);
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				funcItemValItemdes = () => ViewModelConversion.ToString(m.Item.ValItemdes);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equigrou) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equigrou) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValQtdmovim = ViewModelConversion.ToNumeric(ValQtdmovim);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValFrequenc = ViewModelConversion.ToNumeric(ValFrequenc);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equigrou) to Model (Equip) - Error during mapping");
				throw;
			}
		}

		#endregion


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIGROU");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Equip() { Identifier = "FEQUIGROU" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
					}

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FEQUIGROU";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Equip row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIGROU");
				if (Model == null)
				{
					Model = new Models.Equip() { Identifier = "FEQUIGROU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Equigroupess1name____(qs, lazyLoad);
			Load_Equigroutpequtipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIGROU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIGROU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIGROU]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIGROU"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUIGROU" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIGROU]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIGROU"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUIGROU" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIGROU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIGROU]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, "FEQUIGROU");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_Pess1ValGender = new SelectList(
				ArrayGenero.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.Pess1ValGender);
			this.List_ValFrequenc = new SelectList(
				ArrayFreqempr.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValFrequenc);
		}


        /// <summary>
        /// TablePess1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equigroupess1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equigroupess1name____DoLoad = true;
            CriteriaSet equigroupess1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equigroupess1name____Conds.Equal(CSGenioApess1.FldCodpesso, Navigation.GetValue("pess1"));
                    this.ValCodpess1 = Navigation.GetStrValue("pess1");
                }
            }

			// Limits Generation

			// Area limit
			equigroupess1name____DoLoad &= AddCriteriaAreaLimit(equigroupess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);


            TablePess1Name = new TableDBEdit<Models.Pess1>();
            TablePess1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
                    this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
                FillDependant_EquigrouTablePess1Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodempre))
                equigroupess1name____DoLoad = false;

            if (equigroupess1name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
                    TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
                else
                    TablePess1Name.TableFilters = false;

                query = qs["qTablePess1Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApess1.FldName, query + "%");
                }
                equigroupess1name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIGROU_PESS1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
                    equigroupess1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess1.FldZzstate, 0)
                        .Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
                else
                    equigroupess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equigroupess1name____Conds = Pess1.AddEPH<CSGenioApess1>(ref UserContext.Current.User, equigroupess1name____Conds, "LED_EQUIGROUPESS1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
                ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, equigroupess1name____Conds, fields, offset, numberItems, sorts, "LED_EQUIGROUPESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess1Name.Query = query;
                TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(r, true, _fieldsToSerialize_EQUIGROUPESS1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
                if(!isSearchRequest)
                    FillDependant_EquigrouTablePess1Name();

                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquigrouTablePess1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess1.codpesso", "pess1.name", "pess1.gender", "pess1.dtnascim", "pess1.idade", "pess1.idfuncio", "pess1.telephon", "pess1.email", "pess1.email2", "cmpny.codempre", "cmpny.designat", "cmpny.acronym", "cmpny.nif", "cmpny.telephon", "cmpny.email" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldGender, CSGenioApess1.FldDtnascim, CSGenioApess1.FldIdade, CSGenioApess1.FldIdfuncio, CSGenioApess1.FldTelephon, CSGenioApess1.FldEmail, CSGenioApess1.FldEmail2, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("cmpny");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioApess1 tempArea = new CSGenioApess1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquigrouTablePess1Name(bool lazyLoad = false)
        {
            var row = GetDependant_EquigrouTablePess1Name(this.ValCodpess1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["pess1.gender"]);
                    this.funcPess1ValGender = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToDateTime(row["pess1.dtnascim"]);
                    this.funcPess1ValDtnascim = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["pess1.idade"]);
                    this.funcPess1ValIdade = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["pess1.idfuncio"]);
                    this.funcPess1ValIdfuncio = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["pess1.telephon"]);
                    this.funcPess1ValTelephon = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["pess1.email"]);
                    this.funcPess1ValEmail = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["pess1.email2"]);
                    this.funcPess1ValEmail2 = () => tempValue;
                }
                this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.designat"]);
                    this.funcCmpnyValDesignat = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.acronym"]);
                    this.funcCmpnyValAcronym = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.nif"]);
                    this.funcCmpnyValNif = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.telephon"]);
                    this.funcCmpnyValTelephon = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.email"]);
                    this.funcCmpnyValEmail = () => tempValue;
                }

                // Fill List fields
                this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
                TablePess1Name.Value = ViewModelConversion.ToString(row["pess1.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpess1) == 1)
                {
                    this.ValCodpess1 = "";
                    TablePess1Name.Value = "";
                    Navigation.ClearValue("pess1");
                }
                else if (lazyLoad)
                {
                    TablePess1Name.SetPagination(1, 0, false, false, 1);
                    TablePess1Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpess1),
                            Text = Convert.ToString(TablePess1Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpess1);
                }
                TablePess1Name.Selected = this.ValCodpess1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIGROUPESS1NAME____ = { "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName" };

        /// <summary>
        /// TableTpequTipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equigroutpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equigroutpequtipoequiDoLoad = true;
            CriteriaSet equigroutpequtipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpequ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equigroutpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
                    this.ValCodtpequ = Navigation.GetStrValue("tpequ");
                }
            }



            TableTpequTipoequi = new TableDBEdit<Models.Tpequ>();
            TableTpequTipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
                    this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
                FillDependant_EquigrouTableTpequTipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
                return;
            }


            if (equigroutpequtipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
                    TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
                else
                    TableTpequTipoequi.TableFilters = false;

                query = qs["qTableTpequTipoequi"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
                }
                equigroutpequtipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIGROU_TPEQUTIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
                    equigroutpequtipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpequ.FldZzstate, 0)
                        .Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
                else
                    equigroutpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equigroutpequtipoequiConds = Tpequ.AddEPH<CSGenioAtpequ>(ref UserContext.Current.User, equigroutpequtipoequiConds, "LED_EQUIGROUTPEQUTIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
                ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, equigroutpequtipoequiConds, fields, offset, numberItems, sorts, "LED_EQUIGROUTPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpequTipoequi.Query = query;
                TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(r, true, _fieldsToSerialize_EQUIGROUTPEQUTIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                if(!isSearchRequest)
                    FillDependant_EquigrouTableTpequTipoequi();

                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpequ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquigrouTableTpequTipoequi(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpequ.codtpequ", "tpequ.tipoequi", "tpequ.tpequcod", "tpequ.precomax", "tpequ.tpequpai", "tpequ.nivel", "tpequ.backcolo", "tpequ.corletra" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAtpequ tempArea = new CSGenioAtpequ(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquigrouTableTpequTipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_EquigrouTableTpequTipoequi(this.ValCodtpequ, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["tpequ.tpequcod"]);
                    this.funcTpequValTpequcod = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["tpequ.precomax"]);
                    this.funcTpequValPrecomax = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["tpequ.tpequpai"]);
                    this.funcTpequValTpequpai = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["tpequ.nivel"]);
                    this.funcTpequValNivel = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["tpequ.backcolo"]);
                    this.funcTpequValBackcolo = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToString(row["tpequ.corletra"]);
                    this.funcTpequValCorletra = () => tempValue;
                }

                // Fill List fields
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
                TableTpequTipoequi.Value = ViewModelConversion.ToString(row["tpequ.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
                {
                    this.ValCodtpequ = "";
                    TableTpequTipoequi.Value = "";
                    Navigation.ClearValue("tpequ");
                }
                else if (lazyLoad)
                {
                    TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpequTipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpequ),
                            Text = Convert.ToString(TableTpequTipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpequ);
                }
                TableTpequTipoequi.Selected = this.ValCodtpequ;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIGROUTPEQUTIPOEQUI = { "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIGROU]/
		#endregion
	}
}
