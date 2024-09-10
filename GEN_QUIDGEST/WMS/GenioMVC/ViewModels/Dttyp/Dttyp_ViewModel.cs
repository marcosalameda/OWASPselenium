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

namespace GenioMVC.ViewModels.Dttyp
{
	public class Dttyp_ViewModel : FormViewModel<Models.Dttyp>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Text" Tipo:"C"</summary>
		[Display(Name = "TEXT04938", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValString { get; set; }

		/// <summary>Campo : "Text (Upper case)" Tipo:"C"</summary>
		[Display(Name = "TEXT__UPPER_CASE_62204", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValUppercas { get; set; }

		/// <summary>Campo : "Text (UUID aka GUID)" Tipo:"C"</summary>
		[Display(Name = "TEXT__UUID_AKA_GUID_03442", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(36, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValUuid { get; set; }

		/// <summary>Campo : "Text (QR Code)" Tipo:"C"</summary>
		[Display(Name = "TEXT__QR_CODE_35902", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[UIHint("QRcode")]
		public string ValQrcode { get; set; }

		/// <summary>Campo : "Multiline text" Tipo:"MO"</summary>
		[Display(Name = "MULTILINE_TEXT57254", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValMultilin { get; set; }

		/// <summary>Campo : "Multiline text (Text editor)" Tipo:"MO"</summary>
		[Display(Name = "MULTILINE_TEXT__TEXT35132", ResourceType = typeof(Resources.Resources))]
		[UIHint("tinymce")]
		[AllowHtml, Helpers.Attributes.HtmlSanitizer(isDocument: true)]
		public string ValMultili3 { get; set; }

		/// <summary>Campo : "Logical (tinyint) (storage: 1 byte)" Tipo:"L"</summary>
		[Display(Name = "LOGICAL__TINYINT___S35014", ResourceType = typeof(Resources.Resources))]
		public bool ValBoolean { get; set; }

		/// <summary>Campo : "Conditional (smallint) (storage: 2 byte)" Tipo:"IF"</summary>
		[Display(Name = "CONDITIONAL__SMALLIN41010", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBConditional")]
		[ConditionalBinder]
		public decimal ValBoolean2 { get; set; }

		/// <summary>Campo : "Numeric  4.0 - small integer (storage: 2 byte)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC__4_0___SMALL21475", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValSmallint { get; set; }

		/// <summary>Campo : "Numeric  9.0 - integer (storage: 4 byte)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC__9_0___INTEG03994", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValInteger { get; set; }

		/// <summary>Campo : "Numeric 15.0 - big integer (storage: 8 byte)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC_15_0___BIG_I46007", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValBigint { get; set; }

		/// <summary>Campo : "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC__8_2_REAL_FL21391", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValReal { get; set; }

		/// <summary>Campo : "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC_15_2_DOUBLE_11443", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValFloat { get; set; }

		/// <summary>Campo : "Decimal (1-10) (storage: 5 byte)" Tipo:"ND"</summary>
		[Display(Name = "DECIMAL__1_10___STOR64402", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N4}" )]
		[NumericAttribute(4)]
		public decimal? ValDecimal { get; set; }

		/// <summary>Campo : "Decimal (11-15) (storage: 9 byte)" Tipo:"ND"</summary>
		[Display(Name = "DECIMAL__11_15___STO64707", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N4}" )]
		[NumericAttribute(4)]
		public decimal? ValDecimal9 { get; set; }

		/// <summary>Campo : "Money - decimal (1-10) (storage: 5 byte)" Tipo:"$D"</summary>
		[Display(Name = "MONEY___DECIMAL__1_124403", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney { get; set; }

		/// <summary>Campo : "Money - decimal (11-15) (storage: 9 byte)" Tipo:"$D"</summary>
		[Display(Name = "MONEY___DECIMAL__11_02101", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney9 { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "Date Time" Tipo:"DT"</summary>
		[Display(Name = "DATE_TIME53960", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get; set; }

		/// <summary>Campo : "Date Time Second" Tipo:"DS"</summary>
		[Display(Name = "DATE_TIME_SECOND45106", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DS")]
		public DateTime? ValDtsesond { get; set; }

		/// <summary>Campo : "Time" Tipo:"T"</summary>
		[Display(Name = "TIME15328", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTime { get; set; }

		/// <summary>Campo : "Image (binary)" Tipo:"IJ"</summary>
		[Display(Name = "IMAGE__BINARY_46903", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 115, 138, false, true)]
		public byte[] ValImage { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCoddttyp { get; set; }

		public Dttyp_ViewModel() : base("FDTTYP") { }

		public Dttyp_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDTTYP", currentNavigation, nestedForm) { }

		public Dttyp_ViewModel(Models.Dttyp row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDTTYP", row, currentNavigation, nestedForm) { }

		public Dttyp_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("dttyp", id);
			Model = Models.Dttyp.Find(id, "FDTTYP", fieldsToQuery: fieldsToLoad);
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
			Models.Dttyp model = new Models.Dttyp() { Identifier = "FDTTYP" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Dttyp model)
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

		public static StatusMessage DeleteConditions(Models.Dttyp model)
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

		public static StatusMessage ViewConditions(Models.Dttyp model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Dttyp model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Dttyp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Dttyp) to ViewModel (Dttyp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValString = ViewModelConversion.ToString(m.ValString);
 				ValUppercas = ViewModelConversion.ToString(m.ValUppercas);
 				ValUuid = ViewModelConversion.ToString(m.ValUuid);
 				ValQrcode = ViewModelConversion.ToString(m.ValQrcode);
 				ValMultilin = ViewModelConversion.ToString(m.ValMultilin);
 				ValMultili3 = ViewModelConversion.ToString(m.ValMultili3);
 				ValBoolean = ViewModelConversion.ToLogic(m.ValBoolean);
 				ValBoolean2 = ViewModelConversion.ToNumeric(m.ValBoolean2);
 				ValSmallint = ViewModelConversion.ToNumeric(m.ValSmallint);
 				ValInteger = ViewModelConversion.ToNumeric(m.ValInteger);
 				ValBigint = ViewModelConversion.ToNumeric(m.ValBigint);
 				ValReal = ViewModelConversion.ToNumeric(m.ValReal);
 				ValFloat = ViewModelConversion.ToNumeric(m.ValFloat);
 				ValDecimal = ViewModelConversion.ToNumeric(m.ValDecimal);
 				ValDecimal9 = ViewModelConversion.ToNumeric(m.ValDecimal9);
 				ValMoney = ViewModelConversion.ToNumeric(m.ValMoney);
 				ValMoney9 = ViewModelConversion.ToNumeric(m.ValMoney9);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
 				ValDtsesond = ViewModelConversion.ToDateTime(m.ValDtsesond);
 				ValTime = ViewModelConversion.ToString(m.ValTime);
 				ValImage = ViewModelConversion.ToImage(m.ValImage);
 				ValCoddttyp = ViewModelConversion.ToString(m.ValCoddttyp);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Dttyp) to ViewModel (Dttyp) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Dttyp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dttyp) to Model (Dttyp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValString = ViewModelConversion.ToString(ValString);
				m.ValUppercas = ViewModelConversion.ToString(ValUppercas);
				m.ValUuid = ViewModelConversion.ToString(ValUuid);
				m.ValQrcode = ViewModelConversion.ToString(ValQrcode);
				m.ValMultilin = ViewModelConversion.ToString(ValMultilin);
				m.ValMultili3 = ViewModelConversion.ToString(ValMultili3);
				m.ValBoolean = ViewModelConversion.ToLogic(ValBoolean);
				m.ValBoolean2 = ViewModelConversion.ToNumeric(ValBoolean2);
				m.ValSmallint = ViewModelConversion.ToNumeric(ValSmallint);
				m.ValInteger = ViewModelConversion.ToNumeric(ValInteger);
				m.ValBigint = ViewModelConversion.ToNumeric(ValBigint);
				m.ValReal = ViewModelConversion.ToNumeric(ValReal);
				m.ValFloat = ViewModelConversion.ToNumeric(ValFloat);
				m.ValDecimal = ViewModelConversion.ToNumeric(ValDecimal);
				m.ValDecimal9 = ViewModelConversion.ToNumeric(ValDecimal9);
				m.ValMoney = ViewModelConversion.ToNumeric(ValMoney);
				m.ValMoney9 = ViewModelConversion.ToNumeric(ValMoney9);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDtsesond = ViewModelConversion.ToDateTime(ValDtsesond);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValCoddttyp = ViewModelConversion.ToString(ValCoddttyp);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dttyp) to Model (Dttyp) - Error during mapping");
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
				Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), "FDTTYP");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Dttyp() { Identifier = "FDTTYP" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");
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

			Model.Identifier = "FDTTYP";
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

		protected override void LoadDocumentsProperties(Models.Dttyp row)
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
				Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), "FDTTYP");
				if (Model == null)
				{
					Model = new Models.Dttyp() { Identifier = "FDTTYP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DTTYP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DTTYP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DTTYP]/
		public override void Save()
		{

			try { Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), "FDTTYP"); }
			finally { if (Model == null) Model = new Models.Dttyp() { Identifier = "FDTTYP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DTTYP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), "FDTTYP"); }
			finally { if (Model == null) Model = new Models.Dttyp() { Identifier = "FDTTYP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DTTYP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DTTYP]/
		public override void Destroy(string id)
		{
			Model = Models.Dttyp.Find(id, "FDTTYP");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}




		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValMultili3 = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValMultili3, true);
		}

		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DTTYP]/
		#endregion
	}
}
