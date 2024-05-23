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

namespace GenioMVC.ViewModels.Tblb
{
	public class Tblb_ViewModel : FormViewModel<Models.Tblb>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Text" Tipo:"C"</summary>
		[Display(Name = "TEXT04938", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValText { get; set; }

		/// <summary>Campo : "Multiline Text" Tipo:"MO"</summary>
		[Display(Name = "MULTILINE_TEXT38013", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValTextml { get; set; }

		/// <summary>Campo : "Numeric (Integer)" Tipo:"N"</summary>
		[Display(Name = "NUMERIC__INTEGER_50289", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNumint { get; set; }

		/// <summary>Campo : "Numeric (Decimal)" Tipo:"ND"</summary>
		[Display(Name = "NUMERIC__DECIMAL_36157", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N3}" )]
		[NumericAttribute(3)]
		public decimal? ValNumdec { get; set; }

		/// <summary>Campo : "Currency (Interger)" Tipo:"$"</summary>
		[Display(Name = "CURRENCY__INTERGER_21437", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValCurint { get; set; }

		/// <summary>Campo : "Currency (Decimal)" Tipo:"$D"</summary>
		[Display(Name = "CURRENCY__DECIMAL_11718", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValCurdec { get; set; }

		/// <summary>Campo : "Boolean" Tipo:"L"</summary>
		[Display(Name = "BOOLEAN45002", ResourceType = typeof(Resources.Resources))]
		public bool ValBool { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "DateTime (Minutes)" Tipo:"DT"</summary>
		[Display(Name = "DATETIME__MINUTES_59352", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDatetm { get; set; }

		/// <summary>Campo : "DateTime (Seconds)" Tipo:"DS"</summary>
		[Display(Name = "DATETIME__SECONDS_49861", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DS")]
		public DateTime? ValDatets { get; set; }

		/// <summary>Campo : "Time (Hours-Minutes)" Tipo:"T"</summary>
		[Display(Name = "TIME__HOURS_MINUTES_01660", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTimehm { get; set; }

		/// <summary>Campo : "Enumeration (Text)" Tipo:"AC"</summary>
		[Display(Name = "ENUMERATION__TEXT_15855", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Typet", GenioMVC.Helpers.ArrayType.Character)]
		public string ValEnumt { get; set; }
		[JsonIgnore]
		public SelectList List_ValEnumt { get; set; }

		/// <summary>Campo : "Enumeration (Numeric)" Tipo:"AN"</summary>
		[Display(Name = "ENUMERATION__NUMERIC44708", ResourceType = typeof(Resources.Resources))]
		[DataArray("Typen", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValEnumn { get; set; }
		[JsonIgnore]
		public SelectList List_ValEnumn { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValFkey1 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtblb { get; set; }

		public Tblb_ViewModel() : base("FTBLB") { }

		public Tblb_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTBLB", currentNavigation, nestedForm) { }

		public Tblb_ViewModel(Models.Tblb row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTBLB", row, currentNavigation, nestedForm) { }

		public Tblb_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tblb", id);
			Model = Models.Tblb.Find(id, "FTBLB", fieldsToQuery: fieldsToLoad);
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
			Models.Tblb model = new Models.Tblb() { Identifier = "FTBLB" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tblb model)
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

		public static StatusMessage DeleteConditions(Models.Tblb model)
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

		public static StatusMessage ViewConditions(Models.Tblb model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tblb model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tblb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tblb) to ViewModel (Tblb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValText = ViewModelConversion.ToString(m.ValText);
 				ValTextml = ViewModelConversion.ToString(m.ValTextml);
 				ValNumint = ViewModelConversion.ToNumeric(m.ValNumint);
 				ValNumdec = ViewModelConversion.ToNumeric(m.ValNumdec);
 				ValCurint = ViewModelConversion.ToNumeric(m.ValCurint);
 				ValCurdec = ViewModelConversion.ToNumeric(m.ValCurdec);
 				ValBool = ViewModelConversion.ToLogic(m.ValBool);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValDatetm = ViewModelConversion.ToDateTime(m.ValDatetm);
 				ValDatets = ViewModelConversion.ToDateTime(m.ValDatets);
 				ValTimehm = ViewModelConversion.ToString(m.ValTimehm);
 				ValEnumt = ViewModelConversion.ToString(m.ValEnumt);
 				ValEnumn = ViewModelConversion.ToNumeric(m.ValEnumn);
 				ValFkey1 = ViewModelConversion.ToString(m.ValFkey1);
 				ValCodtblb = ViewModelConversion.ToString(m.ValCodtblb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tblb) to ViewModel (Tblb) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tblb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblb) to Model (Tblb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValText = ViewModelConversion.ToString(ValText);
				m.ValTextml = ViewModelConversion.ToString(ValTextml);
				m.ValNumint = ViewModelConversion.ToNumeric(ValNumint);
				m.ValNumdec = ViewModelConversion.ToNumeric(ValNumdec);
				m.ValCurint = ViewModelConversion.ToNumeric(ValCurint);
				m.ValCurdec = ViewModelConversion.ToNumeric(ValCurdec);
				m.ValBool = ViewModelConversion.ToLogic(ValBool);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetm = ViewModelConversion.ToDateTime(ValDatetm);
				m.ValDatets = ViewModelConversion.ToDateTime(ValDatets);
				m.ValTimehm = ViewModelConversion.ToString(ValTimehm);
				m.ValEnumt = ViewModelConversion.ToString(ValEnumt);
				m.ValEnumn = ViewModelConversion.ToNumeric(ValEnumn);
				m.ValFkey1 = ViewModelConversion.ToString(ValFkey1);
				m.ValCodtblb = ViewModelConversion.ToString(ValCodtblb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblb) to Model (Tblb) - Error during mapping");
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
				Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), "FTBLB");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tblb() { Identifier = "FTBLB" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");
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

			Model.Identifier = "FTBLB";
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

		protected override void LoadDocumentsProperties(Models.Tblb row)
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
				Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), "FTBLB");
				if (Model == null)
				{
					Model = new Models.Tblb() { Identifier = "FTBLB" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TBLB]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TBLB]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TBLB]/
		public override void Save()
		{

			try { Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), "FTBLB"); }
			finally { if (Model == null) Model = new Models.Tblb() { Identifier = "FTBLB" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TBLB]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), "FTBLB"); }
			finally { if (Model == null) Model = new Models.Tblb() { Identifier = "FTBLB" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TBLB]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TBLB]/
		public override void Destroy(string id)
		{
			Model = Models.Tblb.Find(id, "FTBLB");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValEnumt = new SelectList(
				ArrayTypet.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValEnumt);
			this.List_ValEnumn = new SelectList(
				ArrayTypen.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValEnumn);
		}



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBLB]/
		#endregion
	}
}
