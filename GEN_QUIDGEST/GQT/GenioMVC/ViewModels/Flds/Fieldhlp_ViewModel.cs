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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Flds
{
	public class Fieldhlp_ViewModel : FormViewModel<Models.Flds>
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

		/// <summary>Campo : "Multine Text" Tipo:"MO"</summary>
		[Display(Name = "MULTINE_TEXT05310", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescrip { get; set; }

		/// <summary>Campo : "Year" Tipo:"N"</summary>
		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYear { get; set; }

		/// <summary>Campo : "Time" Tipo:"T"</summary>
		[Display(Name = "TIME15328", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTime { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "Date time" Tipo:"DT"</summary>
		[Display(Name = "DATE_TIME59103", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get; set; }

		/// <summary>Campo : "Date second" Tipo:"DS"</summary>
		[Display(Name = "DATE_SECOND44057", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DS")]
		public DateTime? ValDateseco { get; set; }

		/// <summary>Campo : "Numeric" Tipo:"N"</summary>
		[Display(Name = "NUMERIC19292", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNpassage { get; set; }

		/// <summary>Campo : "Numeric decimal" Tipo:"ND"</summary>
		[Display(Name = "NUMERIC_DECIMAL49512", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValDuration { get; set; }

		/// <summary>Campo : "Currency Decimal" Tipo:"$D"</summary>
		[Display(Name = "CURRENCY_DECIMAL48296", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecobil { get; set; }

		/// <summary>Campo : "Currency" Tipo:"$"</summary>
		[Display(Name = "CURRENCY13881", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get; set; }

		/// <summary>Campo : "Social Security No" Tipo:"C"</summary>
		[Display(Name = "SOCIAL_SECURITY_NO48150", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(11, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[MaskAttribute("SS")]
		[CheckNISS]
		public string ValSsnumber { get; set; }

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

		/// <summary>Campo : "Password" Tipo:"C"</summary>
		[Display(Name = "PASSWORD09467", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPassfld { get; set; }

		/// <summary>Campo : "Colorpicker" Tipo:"C"</summary>
		[Display(Name = "COLORPICKER39653", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValClrpicke { get; set; }

		/// <summary>Campo : "Logical" Tipo:"L"</summary>
		[Display(Name = "LOGICAL47485", ResourceType = typeof(Resources.Resources))]
		public bool ValPrimviag { get; set; }

		/// <summary>Campo : "" Tipo:"AL"</summary>
		[DataArray("Primviag", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValLogicenu { get; set; }
		[JsonIgnore]
		public SelectList List_ValLogicenu { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatuse { get; set; }

		/// <summary>Campo : "Day" Tipo:"OD"</summary>
		[Display(Name = "DAY27593", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }

		/// <summary>Campo : "Complete Date" Tipo:"OI"</summary>
		[Display(Name = "COMPLETE_DATE53774", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OI")]
		public DateTime? ValCreatins { get; set; }

		/// <summary>Campo : "Hour" Tipo:"OT"</summary>
		[Display(Name = "HOUR15646", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("OT")]
		public string ValCreathou { get; set; }


		/// <summary>Campo : "Airline name" Tipo:"C"</summary>
		[Display(Name = "AIRLINE_NAME55130", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Aero>  TableAeroName { get; set; }

		/// <summary>Campo : "Conditional" Tipo:"IF"</summary>
		[Display(Name = "CONDITIONAL01431", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBConditional")]
		[ConditionalBinder]
		public double ValConditio { get; set; }

		/// <summary>Campo : "Text Enumeration" Tipo:"AC"</summary>
		[Display(Name = "TEXT_ENUMERATION45668", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Class", GenioMVC.Helpers.ArrayType.Character)]
		public string ValClass { get; set; }
		[JsonIgnore]
		public SelectList List_ValClass { get; set; }

		/// <summary>Campo : "Radio Btn" Tipo:"AC"</summary>
		[Display(Name = "RADIO_BTN20980", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Radiobtn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValRadiob { get; set; }
		[JsonIgnore]
		public SelectList List_ValRadiob { get; set; }

		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValLogo { get; set; }

		/// <summary>Campo : "Document" Tipo:"IB"</summary>
		[Display(Name = "DOCUMENT00695", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValAttach", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValAttach { get; set; }
		public string ValAttachfk { get; set; }
		public DocumsProperties_ViewModel ValAttachPropertiesVM { get; set; }

		/// <summary>Campo : "No. register" Tipo:"C"</summary>
		[Display(Name = "NO__REGISTER04207", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "Show record" Tipo:"L"</summary>
		[Display(Name = "SHOW_RECORD53851", ResourceType = typeof(Resources.Resources))]
		public bool ValShwrc { get; set; }

		/// <summary>Campo : "Numeric Enumeration" Tipo:"AN"</summary>
		[Display(Name = "NUMERIC_ENUMERATION19068", ResourceType = typeof(Resources.Resources))]
		[DataArray("Classnum", GenioMVC.Helpers.ArrayType.Numeric)]
		public double? ValClassnum { get; set; }
		[JsonIgnore]
		public SelectList List_ValClassnum { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "AIRLINE_NAME55130", ResourceType = typeof(Resources.Resources))]
		public string ValCodaero { get; set; }

		[Display(Name = "NO__REGISTER04207", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodflds { get; set; }

		public Fieldhlp_ViewModel() : base("FFIELDHLP") { }

		public Fieldhlp_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFIELDHLP", currentNavigation, nestedForm) { }

		public Fieldhlp_ViewModel(Models.Flds row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFIELDHLP", row, currentNavigation, nestedForm) { }

		public Fieldhlp_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, "FFIELDHLP", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds() { Identifier = "FFIELDHLP" };
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
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fieldhlp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTxtfield = ViewModelConversion.ToString(m.ValTxtfield);
 				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
 				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
 				ValTime = ViewModelConversion.ToString(m.ValTime);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
 				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
 				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
 				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
 				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
 				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
 				ValSsnumber = ViewModelConversion.ToString(m.ValSsnumber);
 				ValZipfield = ViewModelConversion.ToString(m.ValZipfield);
 				ValVatnumbr = ViewModelConversion.ToString(m.ValVatnumbr);
 				ValLicplate = ViewModelConversion.ToString(m.ValLicplate);
 				ValBanknmbr = ViewModelConversion.ToString(m.ValBanknmbr);
 				ValEmailfld = ViewModelConversion.ToString(m.ValEmailfld);
 				ValIbanfiel = ViewModelConversion.ToString(m.ValIbanfiel);
 				ValUpprtext = ViewModelConversion.ToString(m.ValUpprtext);
 				ValPassfld = ViewModelConversion.ToString(m.ValPassfld);
 				ValClrpicke = ViewModelConversion.ToString(m.ValClrpicke);
 				ValPrimviag = ViewModelConversion.ToLogic(m.ValPrimviag);
 				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
 				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
 				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
 				ValConditio = ViewModelConversion.ToDouble(m.ValConditio);
 				ValClass = ViewModelConversion.ToString(m.ValClass);
 				ValRadiob = ViewModelConversion.ToString(m.ValRadiob);
 				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
 				ValAttach = ViewModelConversion.ToString(m.ValAttach);
				ValAttachfk = ViewModelConversion.ToString(m.ValAttachfk);
 				ValShwrc = ViewModelConversion.ToLogic(m.ValShwrc);
 				ValClassnum = ViewModelConversion.ToDouble(m.ValClassnum);
 				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fieldhlp) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fieldhlp) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTxtfield = ViewModelConversion.ToString(ValTxtfield);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValSsnumber = ViewModelConversion.ToString(ValSsnumber);
				m.ValZipfield = ViewModelConversion.ToString(ValZipfield);
				m.ValVatnumbr = ViewModelConversion.ToString(ValVatnumbr);
				m.ValLicplate = ViewModelConversion.ToString(ValLicplate);
				m.ValBanknmbr = ViewModelConversion.ToString(ValBanknmbr);
				m.ValEmailfld = ViewModelConversion.ToString(ValEmailfld);
				m.ValIbanfiel = ViewModelConversion.ToString(ValIbanfiel);
				m.ValUpprtext = ViewModelConversion.ToString(ValUpprtext);
				m.ValPassfld = ViewModelConversion.ToString(ValPassfld);
				m.ValClrpicke = ViewModelConversion.ToString(ValClrpicke);
				m.ValPrimviag = ViewModelConversion.ToLogic(ValPrimviag);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValConditio = ViewModelConversion.ToDouble(ValConditio);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValRadiob = ViewModelConversion.ToString(ValRadiob);
				m.ValAttach = ViewModelConversion.ToString(ValAttach);
				m.ValAttachfk = ViewModelConversion.ToString(ValAttachfk);

				m.ValShwrc = ViewModelConversion.ToLogic(ValShwrc);
				m.ValClassnum = ViewModelConversion.ToDouble(ValClassnum);
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fieldhlp) to Model (Flds) - Error during mapping");
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFIELDHLP");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Flds() { Identifier = "FFIELDHLP" };
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

			Model.Identifier = "FFIELDHLP";
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFIELDHLP");
				if (Model == null)
				{
					Model = new Models.Flds() { Identifier = "FFIELDHLP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Fieldhlpaero_name____(qs, lazyLoad);
			Load_Fieldhlpequipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FIELDHLP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FIELDHLP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FIELDHLP]/
		public override void Save()
		{

			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFIELDHLP"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FFIELDHLP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FIELDHLP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFIELDHLP"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FFIELDHLP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FIELDHLP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FIELDHLP]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, "FFIELDHLP");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValLogicenu = new SelectList(
				ArrayPrimviag.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValLogicenu);
			this.List_ValClass = new SelectList(
				ArrayClass.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClass);
			this.List_ValRadiob = new SelectList(
				ArrayRadiobtn.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValRadiob);
			this.List_ValClassnum = new SelectList(
				ArrayClassnum.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClassnum);
		}


        /// <summary>
        /// TableAeroName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Fieldhlpaero_name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool fieldhlpaero_name____DoLoad = true;
            CriteriaSet fieldhlpaero_name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("aero", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    fieldhlpaero_name____Conds.Equal(CSGenioAaero.FldCodaero, Navigation.GetValue("aero"));
                    this.ValCodaero = Navigation.GetStrValue("aero");
                }
            }



            TableAeroName = new TableDBEdit<Models.Aero>();
            TableAeroName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
                    this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}
                FillDependant_FieldhlpTableAeroName(lazyLoad);
                //Check if foreignkey comes from history
                TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
                return;
            }


            if (fieldhlpaero_name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableAeroName, "sTableAeroName", "dTableAeroName", qs, "aero");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAaero.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableAeroName_tableFilters"]))
                    TableAeroName.TableFilters = bool.Parse(qs["TableAeroName_tableFilters"]);
                else
                    TableAeroName.TableFilters = false;

                query = qs["qTableAeroName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAaero.FldName, query + "%");
                }
                fieldhlpaero_name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAeroName"] != null ? qs["pTableAeroName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAaero.FldZzstate };

// USE /[MANUAL GQT OVERRQ FIELDHLP_AERONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("aero", FormMode.New) || Navigation.checkFormMode("aero", FormMode.Duplicate))
                    fieldhlpaero_name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAaero.FldZzstate, 0)
                        .Equal(CSGenioAaero.FldCodaero, Navigation.GetStrValue("aero")));
                else
                    fieldhlpaero_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAaero.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //fieldhlpaero_name____Conds = Aero.AddEPH<CSGenioAaero>(ref UserContext.Current.User, fieldhlpaero_name____Conds, "LED_FIELDHLPAERO_NAME____");

                FieldRef firstVisibleColumn = new FieldRef("aero", "name");
                ListingMVC<CSGenioAaero> listing = Models.ModelBase.Where<CSGenioAaero>(false, fieldhlpaero_name____Conds, fields, offset, numberItems, sorts, "LED_FIELDHLPAERO_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAeroName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAeroName.Query = query;
                TableAeroName.Elements = listing.RowsForViewModel<GenioMVC.Models.Aero>((r) => new GenioMVC.Models.Aero(r, true, _fieldsToSerialize_FIELDHLPAERO_NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}

				TableAeroName.List = new SelectList(TableAeroName.Elements.ToSelectList(x => x.ValName, x => x.ValCodaero,  x => x.ValCodaero == this.ValCodaero), "Value", "Text", this.ValCodaero);
                FillDependant_FieldhlpTableAeroName();

                //Check if foreignkey comes from history
                TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAeroName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Aero</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_FieldhlpTableAeroName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "aero.codaero", "aero.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAaero.FldCodaero, CSGenioAaero.FldName };
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
            CSGenioAaero tempArea = new CSGenioAaero(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAaero.FldCodaero, PKey));
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
        /// Fill Dependant fields values -> TableAeroName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_FieldhlpTableAeroName(bool lazyLoad = false)
        {
            var row = GetDependant_FieldhlpTableAeroName(this.ValCodaero, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodaero = ViewModelConversion.ToString(row["aero.codaero"]);
                TableAeroName.Value = ViewModelConversion.ToString(row["aero.name"]);
                if (GlobalFunctions.emptyG(this.ValCodaero) == 1)
                {
                    this.ValCodaero = "";
                    TableAeroName.Value = "";
                    Navigation.ClearValue("aero");
                }
                else if (lazyLoad)
                {
                    TableAeroName.SetPagination(1, 0, false, false, 1);
                    TableAeroName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodaero),
                            Text = Convert.ToString(TableAeroName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodaero);
                }
                TableAeroName.Selected = this.ValCodaero;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAeroName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_FIELDHLPAERO_NAME____ = { "Aero", "Aero.ValCodaero", "Aero.ValZzstate", "Aero.ValName" };

        /// <summary>
        /// TableEquipRegistnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Fieldhlpequipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool fieldhlpequipregistnrDoLoad = true;
            CriteriaSet fieldhlpequipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    fieldhlpequipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
                    this.ValCodequip = Navigation.GetStrValue("equip");
                }
            }



            TableEquipRegistnr = new TableDBEdit<Models.Equip>();
            TableEquipRegistnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
                    this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
                FillDependant_FieldhlpTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }


            if (fieldhlpequipregistnrDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEquipRegistnr_tableFilters"]))
                    TableEquipRegistnr.TableFilters = bool.Parse(qs["TableEquipRegistnr_tableFilters"]);
                else
                    TableEquipRegistnr.TableFilters = false;

                query = qs["qTableEquipRegistnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
                }
                fieldhlpequipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ FIELDHLP_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    fieldhlpequipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    fieldhlpequipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //fieldhlpequipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, fieldhlpequipregistnrConds, "LED_FIELDHLPEQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, fieldhlpequipregistnrConds, fields, offset, numberItems, sorts, "LED_FIELDHLPEQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_FIELDHLPEQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                FillDependant_FieldhlpTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_FieldhlpTableEquipRegistnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "equip.codequip", "equip.registnr" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr };
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
            CSGenioAequip tempArea = new CSGenioAequip(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAequip.FldCodequip, PKey));
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
        /// Fill Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_FieldhlpTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_FieldhlpTableEquipRegistnr(this.ValCodequip, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodequip = ViewModelConversion.ToString(row["equip.codequip"]);
                TableEquipRegistnr.Value = ViewModelConversion.ToString(row["equip.registnr"]);
                if (GlobalFunctions.emptyG(this.ValCodequip) == 1)
                {
                    this.ValCodequip = "";
                    TableEquipRegistnr.Value = "";
                    Navigation.ClearValue("equip");
                }
                else if (lazyLoad)
                {
                    TableEquipRegistnr.SetPagination(1, 0, false, false, 1);
                    TableEquipRegistnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodequip),
                            Text = Convert.ToString(TableEquipRegistnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodequip);
                }
                TableEquipRegistnr.Selected = this.ValCodequip;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEquipRegistnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_FIELDHLPEQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FIELDHLP]/
		#endregion
	}
}
