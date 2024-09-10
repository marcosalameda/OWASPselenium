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

namespace GenioMVC.ViewModels.Flds
{
	public class Listacam_ViewModel : FormViewModel<Models.Flds>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Text Field" Tipo:"C"</summary>
		[Display(Name = "TEXT_FIELD41810", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTxtfield { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescrip { get; set; }

		/// <summary>Campo : "Numeric" Tipo:"N"</summary>
		[Display(Name = "NUMERIC19292", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNpassage { get; set; }

		/// <summary>Campo : "Numeric Decimal" Tipo:"ND"</summary>
		[Display(Name = "NUMERIC_DECIMAL37352", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValDuration { get; set; }

		/// <summary>Campo : "Currency" Tipo:"$"</summary>
		[Display(Name = "CURRENCY13881", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get; set; }

		/// <summary>Campo : "Currency Decimal" Tipo:"$D"</summary>
		[Display(Name = "CURRENCY_DECIMAL48296", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecobil { get; set; }

		/// <summary>Campo : "Year" Tipo:"N"</summary>
		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYear { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "Date Time" Tipo:"DT"</summary>
		[Display(Name = "DATE_TIME53960", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get; set; }

		/// <summary>Campo : "Date seconds" Tipo:"DS"</summary>
		[Display(Name = "DATE_SECONDS65191", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DS")]
		public DateTime? ValDateseco { get; set; }

		/// <summary>Campo : "Time" Tipo:"T"</summary>
		[Display(Name = "TIME15328", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTime { get; set; }

		/// <summary>Campo : "Zipcode" Tipo:"C"</summary>
		[Display(Name = "ZIPCODE21021", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(8, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("CP")]
		[CheckZipCode]
		public string ValZipfield { get; set; }

		/// <summary>Campo : "VAT Number" Tipo:"C"</summary>
		[Display(Name = "VAT_NUMBER24236", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(9, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("NC")]
		[CheckNIF]
		public string ValVatnumbr { get; set; }

		/// <summary>Campo : "Licence plate" Tipo:"C"</summary>
		[Display(Name = "LICENCE_PLATE07627", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(8, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("MA")]
		[CheckCarPlatePT]
		public string ValLicplate { get; set; }

		/// <summary>Campo : "Social Security No" Tipo:"C"</summary>
		[Display(Name = "SOCIAL_SECURITY_NO48150", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(11, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("SS")]
		[CheckNISS]
		public string ValSsnumber { get; set; }

		/// <summary>Campo : "Banking Account Number" Tipo:"C"</summary>
		[Display(Name = "BANKING_ACCOUNT_NUMB62548", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(24, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("IB")]
		[CheckNIB]
		public string ValBanknmbr { get; set; }

		/// <summary>Campo : "Email" Tipo:"C"</summary>
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmailfld { get; set; }

		/// <summary>Campo : "IBAN" Tipo:"C"</summary>
		[Display(Name = "IBAN28506", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(34, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("IN")]
		[CheckIBAN]
		public string ValIbanfiel { get; set; }

		/// <summary>Campo : "Uppercase" Tipo:"C"</summary>
		[Display(Name = "UPPERCASE48238", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValUpprtext { get; set; }

		/// <summary>Campo : "Numeric enumeration" Tipo:"AN"</summary>
		[Display(Name = "NUMERIC_ENUMERATION46756", ResourceType = typeof(Resources.Resources))]
		[DataArray("Classnum", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValClassnum { get; set; }
		[JsonIgnore]
		public SelectList List_ValClassnum { get; set; }

		/// <summary>Campo : "Text Enumeration" Tipo:"AC"</summary>
		[Display(Name = "TEXT_ENUMERATION45668", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Class", GenioMVC.Helpers.ArrayType.Character)]
		public string ValClass { get; set; }
		[JsonIgnore]
		public SelectList List_ValClass { get; set; }

		/// <summary>Campo : "Logical Enumeration" Tipo:"AL"</summary>
		[Display(Name = "LOGICAL_ENUMERATION30276", ResourceType = typeof(Resources.Resources))]
		[DataArray("Primviag", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValLogicenu { get; set; }
		[JsonIgnore]
		public SelectList List_ValLogicenu { get; set; }

		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValLogo { get; set; }

		/// <summary>Campo : "Attachments" Tipo:"IB"</summary>
		[Display(Name = "ATTACHMENTS19612", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValAttach", false, true, false, false, DocumentViewTypeMode.Preview)]
		public string ValAttach { get; set; }
		public string ValAttachfk { get; set; }
		public DocumsProperties_ViewModel ValAttachPropertiesVM { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatuse { get; set; }

		/// <summary>Campo : "Date of Creation" Tipo:"OD"</summary>
		[Display(Name = "DATE_OF_CREATION49487", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }

		/// <summary>Campo : "Creation hour" Tipo:"OT"</summary>
		[Display(Name = "CREATION_HOUR49876", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("OT")]
		public string ValCreathou { get; set; }

		/// <summary>Campo : "Complete Date of Creation" Tipo:"OI"</summary>
		[Display(Name = "COMPLETE_DATE_OF_CRE57046", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OI")]
		public DateTime? ValCreatins { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodaero { get; set; }

		public string ValCodequip { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodflds { get; set; }

		public Listacam_ViewModel() : base("FLISTACAM") { }

		public Listacam_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLISTACAM", currentNavigation, nestedForm) { }

		public Listacam_ViewModel(Models.Flds row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLISTACAM", row, currentNavigation, nestedForm) { }

		public Listacam_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, "FLISTACAM", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Flds model = new Models.Flds() { Identifier = "FLISTACAM" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Flds model)
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

		public static StatusMessage DeleteConditions(Models.Flds model)
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

		public static StatusMessage ViewConditions(Models.Flds model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Flds model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Listacam) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTxtfield = ViewModelConversion.ToString(m.ValTxtfield);
 				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
 				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
 				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
 				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
 				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
 				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
 				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
 				ValTime = ViewModelConversion.ToString(m.ValTime);
 				ValZipfield = ViewModelConversion.ToString(m.ValZipfield);
 				ValVatnumbr = ViewModelConversion.ToString(m.ValVatnumbr);
 				ValLicplate = ViewModelConversion.ToString(m.ValLicplate);
 				ValSsnumber = ViewModelConversion.ToString(m.ValSsnumber);
 				ValBanknmbr = ViewModelConversion.ToString(m.ValBanknmbr);
 				ValEmailfld = ViewModelConversion.ToString(m.ValEmailfld);
 				ValIbanfiel = ViewModelConversion.ToString(m.ValIbanfiel);
 				ValUpprtext = ViewModelConversion.ToString(m.ValUpprtext);
 				ValClassnum = ViewModelConversion.ToNumeric(m.ValClassnum);
 				ValClass = ViewModelConversion.ToString(m.ValClass);
 				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
 				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
 				ValAttach = ViewModelConversion.ToString(m.ValAttach);
				ValAttachfk = ViewModelConversion.ToString(m.ValAttachfk);
 				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
 				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
 				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Listacam) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Listacam) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTxtfield = ViewModelConversion.ToString(ValTxtfield);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValZipfield = ViewModelConversion.ToString(ValZipfield);
				m.ValVatnumbr = ViewModelConversion.ToString(ValVatnumbr);
				m.ValLicplate = ViewModelConversion.ToString(ValLicplate);
				m.ValSsnumber = ViewModelConversion.ToString(ValSsnumber);
				m.ValBanknmbr = ViewModelConversion.ToString(ValBanknmbr);
				m.ValEmailfld = ViewModelConversion.ToString(ValEmailfld);
				m.ValIbanfiel = ViewModelConversion.ToString(ValIbanfiel);
				m.ValUpprtext = ViewModelConversion.ToString(ValUpprtext);
				m.ValClassnum = ViewModelConversion.ToNumeric(ValClassnum);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				m.ValAttach = ViewModelConversion.ToString(ValAttach);
				m.ValAttachfk = ViewModelConversion.ToString(ValAttachfk);

				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Listacam) to Model (Flds) - Error during mapping");
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FLISTACAM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Flds() { Identifier = "FLISTACAM" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
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

			Model.Identifier = "FLISTACAM";
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

		protected override void LoadDocumentsProperties(Models.Flds row)
		{
			try
			{
				ValAttachPropertiesVM = row.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				ValAttachPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
			}
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FLISTACAM");
				if (Model == null)
				{
					Model = new Models.Flds() { Identifier = "FLISTACAM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LISTACAM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LISTACAM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LISTACAM]/
		public override void Save()
		{

			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FLISTACAM"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FLISTACAM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LISTACAM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FLISTACAM"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FLISTACAM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LISTACAM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LISTACAM]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, "FLISTACAM");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValClassnum = new SelectList(
				ArrayClassnum.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClassnum);
			this.List_ValClass = new SelectList(
				ArrayClass.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClass);
			this.List_ValLogicenu = new SelectList(
				ArrayPrimviag.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValLogicenu);
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LISTACAM]/
		#endregion
	}
}
