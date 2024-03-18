using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Tblb
{
	public class Tblb_ViewModel : FormViewModel<Models.Tblb>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Text" | Type: "C"
		/// </summary>
		public string ValText { get; set; }

		/// <summary>
		/// Title: "Multiline Text" | Type: "MO"
		/// </summary>
		public string ValTextml { get; set; }

		/// <summary>
		/// Title: "Numeric (Integer)" | Type: "N"
		/// </summary>
		public decimal? ValNumint { get; set; }

		/// <summary>
		/// Title: "Numeric (Decimal)" | Type: "ND"
		/// </summary>
		public decimal? ValNumdec { get; set; }

		/// <summary>
		/// Title: "Currency (Interger)" | Type: "$"
		/// </summary>
		public decimal? ValCurint { get; set; }

		/// <summary>
		/// Title: "Currency (Decimal)" | Type: "$D"
		/// </summary>
		public decimal? ValCurdec { get; set; }

		/// <summary>
		/// Title: "Boolean" | Type: "L"
		/// </summary>
		public bool ValBool { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }

		/// <summary>
		/// Title: "DateTime (Minutes)" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetm { get; set; }

		/// <summary>
		/// Title: "DateTime (Seconds)" | Type: "DS"
		/// </summary>
		public DateTime? ValDatets { get; set; }

		/// <summary>
		/// Title: "Time (Hours-Minutes)" | Type: "T"
		/// </summary>
		public string ValTimehm { get; set; }

		/// <summary>
		/// Title: "Enumeration (Text)" | Type: "AC"
		/// </summary>
		public string ValEnumt { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValEnumt { get; set; }

		/// <summary>
		/// Title: "Enumeration (Numeric)" | Type: "AN"
		/// </summary>
		public double ValEnumn { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValEnumn { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValFkey1 { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtblb { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tblb_ViewModel() : base(null!) { }

		public Tblb_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTBLB", nestedForm) { }

		public Tblb_ViewModel(UserContext userContext, Models.Tblb row, bool nestedForm = false) : base(userContext, "FTBLB", row, nestedForm) { }

		public Tblb_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tblb", id);
			Model = Models.Tblb.Find(id, userContext, "FTBLB", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Tblb model = new Models.Tblb(userContext) { Identifier = "FTBLB" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
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
				ValEnumn = ViewModelConversion.ToDouble(m.ValEnumn);
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
				m.ValEnumn = ViewModelConversion.ToDouble(ValEnumn);
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
				Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), m_userContext, "FTBLB");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

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
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
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
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), m_userContext, "FTBLB");
				if (Model == null)
				{
					Model = new Models.Tblb(m_userContext) { Identifier = "FTBLB" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TBLB]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TBLB]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValText", Resources.Resources.TEXT04938, ValText, 50);
			validator.Required("ValText", Resources.Resources.TEXT04938, ValText);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TBLB]/
		public override void Save()
		{

			try { Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), m_userContext, "FTBLB"); }
			finally { if (Model == null) Model = new Models.Tblb(m_userContext) { Identifier = "FTBLB" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TBLB]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), m_userContext, "FTBLB"); }
			finally { if (Model == null) Model = new Models.Tblb(m_userContext) { Identifier = "FTBLB" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TBLB]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TBLB]/
		public override void Destroy(string id)
		{
			Model = Models.Tblb.Find(id, m_userContext, "FTBLB");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tblb.text" => ViewModelConversion.ToString(modelValue),
				"tblb.textml" => ViewModelConversion.ToString(modelValue),
				"tblb.numint" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.numdec" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.curint" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.curdec" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.bool" => ViewModelConversion.ToLogic(modelValue),
				"tblb.date" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.datetm" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.datets" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.timehm" => ViewModelConversion.ToString(modelValue),
				"tblb.enumt" => ViewModelConversion.ToString(modelValue),
				"tblb.enumn" => ViewModelConversion.ToDouble(modelValue),
				"tblb.fkey1" => ViewModelConversion.ToString(modelValue),
				"tblb.codtblb" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBLB]/

		#endregion
	}
}
