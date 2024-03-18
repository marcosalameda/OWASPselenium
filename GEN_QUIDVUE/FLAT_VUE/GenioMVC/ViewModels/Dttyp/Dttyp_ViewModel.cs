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

namespace GenioMVC.ViewModels.Dttyp
{
	public class Dttyp_ViewModel : FormViewModel<Models.Dttyp>
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
		public string ValString { get; set; }

		/// <summary>
		/// Title: "Text (Upper case)" | Type: "C"
		/// </summary>
		public string ValUppercas { get; set; }

		/// <summary>
		/// Title: "Text (UUID aka GUID)" | Type: "C"
		/// </summary>
		public string ValUuid { get; set; }

		/// <summary>
		/// Title: "Multiline text" | Type: "MO"
		/// </summary>
		public string ValMultilin { get; set; }

		/// <summary>
		/// Title: "Multiline text (Text editor)" | Type: "MO"
		/// </summary>
		public string ValMultili3 { get; set; }

		/// <summary>
		/// Title: "Logical (tinyint) (storage: 1 byte)" | Type: "L"
		/// </summary>
		public bool ValBoolean { get; set; }

		/// <summary>
		/// Title: "Conditional (smallint) (storage: 2 byte)" | Type: "IF"
		/// </summary>
		public double ValBoolean2 { get; set; }

		/// <summary>
		/// Title: "Numeric  4.0 - small integer (storage: 2 byte)" | Type: "N"
		/// </summary>
		public decimal? ValSmallint { get; set; }

		/// <summary>
		/// Title: "Numeric  9.0 - integer (storage: 4 byte)" | Type: "N"
		/// </summary>
		public decimal? ValInteger { get; set; }

		/// <summary>
		/// Title: "Numeric 15.0 - big integer (storage: 8 byte)" | Type: "N"
		/// </summary>
		public decimal? ValBigint { get; set; }

		/// <summary>
		/// Title: "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" | Type: "N"
		/// </summary>
		public decimal? ValReal { get; set; }

		/// <summary>
		/// Title: "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" | Type: "N"
		/// </summary>
		public decimal? ValFloat { get; set; }

		/// <summary>
		/// Title: "Decimal (1-10) (storage: 5 byte)" | Type: "ND"
		/// </summary>
		public decimal? ValDecimal { get; set; }

		/// <summary>
		/// Title: "Decimal (11-15) (storage: 9 byte)" | Type: "ND"
		/// </summary>
		public decimal? ValDecimal9 { get; set; }

		/// <summary>
		/// Title: "Money - decimal (1-10) (storage: 5 byte)" | Type: "$D"
		/// </summary>
		public decimal? ValMoney { get; set; }

		/// <summary>
		/// Title: "Money - decimal (11-15) (storage: 9 byte)" | Type: "$D"
		/// </summary>
		public decimal? ValMoney9 { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }

		/// <summary>
		/// Title: "Date Time" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetime { get; set; }

		/// <summary>
		/// Title: "Date Time Second" | Type: "DS"
		/// </summary>
		public DateTime? ValDtsesond { get; set; }

		/// <summary>
		/// Title: "Time" | Type: "T"
		/// </summary>
		public string ValTime { get; set; }

		/// <summary>
		/// Title: "Image (binary)" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(115, 138)]
		public GenioMVC.ViewModels.ImageModel ValImage { get; set; }

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

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dttyp_ViewModel() : base(null!) { }

		public Dttyp_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDTTYP", nestedForm) { }

		public Dttyp_ViewModel(UserContext userContext, Models.Dttyp row, bool nestedForm = false) : base(userContext, "FDTTYP", row, nestedForm) { }

		public Dttyp_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("dttyp", id);
			Model = Models.Dttyp.Find(id, userContext, "FDTTYP", fieldsToQuery: fieldsToLoad);
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
			Models.Dttyp model = new Models.Dttyp(userContext) { Identifier = "FDTTYP" };
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
				ValMultilin = ViewModelConversion.ToString(m.ValMultilin);
				ValMultili3 = ViewModelConversion.ToString(m.ValMultili3);
				ValBoolean = ViewModelConversion.ToLogic(m.ValBoolean);
				ValBoolean2 = ViewModelConversion.ToDouble(m.ValBoolean2);
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
				m.ValMultilin = ViewModelConversion.ToString(ValMultilin);
				m.ValMultili3 = ViewModelConversion.ToString(ValMultili3);
				m.ValBoolean = ViewModelConversion.ToLogic(ValBoolean);
				m.ValBoolean2 = ViewModelConversion.ToDouble(ValBoolean2);
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
				m.ValImage = ViewModelConversion.ToImage(ValImage);
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
				Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), m_userContext, "FDTTYP");
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

			Model.Identifier = "FDTTYP";
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
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), m_userContext, "FDTTYP");
				if (Model == null)
				{
					Model = new Models.Dttyp(m_userContext) { Identifier = "FDTTYP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DTTYP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DTTYP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValString", Resources.Resources.TEXT04938, ValString, 50);
			validator.StringLength("ValUppercas", Resources.Resources.TEXT__UPPER_CASE_62204, ValUppercas, 50);
			validator.StringLength("ValUuid", Resources.Resources.TEXT__UUID_AKA_GUID_03442, ValUuid, 36);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DTTYP]/
		public override void Save()
		{

			try { Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), m_userContext, "FDTTYP"); }
			finally { if (Model == null) Model = new Models.Dttyp(m_userContext) { Identifier = "FDTTYP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DTTYP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Dttyp.Find(Navigation.GetStrValue("dttyp"), m_userContext, "FDTTYP"); }
			finally { if (Model == null) Model = new Models.Dttyp(m_userContext) { Identifier = "FDTTYP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DTTYP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DTTYP]/
		public override void Destroy(string id)
		{
			Model = Models.Dttyp.Find(id, m_userContext, "FDTTYP");
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
				"dttyp.string" => ViewModelConversion.ToString(modelValue),
				"dttyp.uppercas" => ViewModelConversion.ToString(modelValue),
				"dttyp.uuid" => ViewModelConversion.ToString(modelValue),
				"dttyp.multilin" => ViewModelConversion.ToString(modelValue),
				"dttyp.multili3" => ViewModelConversion.ToString(modelValue),
				"dttyp.boolean" => ViewModelConversion.ToLogic(modelValue),
				"dttyp.boolean2" => ViewModelConversion.ToDouble(modelValue),
				"dttyp.smallint" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.integer" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.bigint" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.real" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.float" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.decimal" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.decimal9" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.money" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.money9" => ViewModelConversion.ToNumeric(modelValue),
				"dttyp.date" => ViewModelConversion.ToDateTime(modelValue),
				"dttyp.datetime" => ViewModelConversion.ToDateTime(modelValue),
				"dttyp.dtsesond" => ViewModelConversion.ToDateTime(modelValue),
				"dttyp.time" => ViewModelConversion.ToString(modelValue),
				"dttyp.image" => ViewModelConversion.ToImage(modelValue),
				"dttyp.coddttyp" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DTTYP]/

		#endregion
	}
}
