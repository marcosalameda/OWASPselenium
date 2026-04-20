using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Dttyp
{
	public class Dttyp_ViewModel : FormViewModel<Models.Dttyp>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys

		#endregion

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
		public decimal ValBoolean2 { get; set; }
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
		public GenioMVC.Models.ImageModel ValImage { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddttyp { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
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

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDTTYP");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

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

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
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

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
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
				if (ValImage == null || !ValImage.IsThumbnail)
					m.ValImage = ViewModelConversion.ToImage(ValImage);
				m.ValCoddttyp = ViewModelConversion.ToString(ValCoddttyp);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Dttyp) to Model (Dttyp) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <inheritdoc />
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "dttyp.string":
						this.ValString = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.uppercas":
						this.ValUppercas = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.uuid":
						this.ValUuid = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.multilin":
						this.ValMultilin = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.multili3":
						this.ValMultili3 = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.boolean":
						this.ValBoolean = ViewModelConversion.ToLogic(_value);
						break;
					case "dttyp.boolean2":
						this.ValBoolean2 = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.smallint":
						this.ValSmallint = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.integer":
						this.ValInteger = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.bigint":
						this.ValBigint = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.real":
						this.ValReal = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.float":
						this.ValFloat = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.decimal":
						this.ValDecimal = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.decimal9":
						this.ValDecimal9 = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.money":
						this.ValMoney = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.money9":
						this.ValMoney9 = ViewModelConversion.ToNumeric(_value);
						break;
					case "dttyp.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "dttyp.datetime":
						this.ValDatetime = ViewModelConversion.ToDateTime(_value);
						break;
					case "dttyp.dtsesond":
						this.ValDtsesond = ViewModelConversion.ToDateTime(_value);
						break;
					case "dttyp.time":
						this.ValTime = ViewModelConversion.ToString(_value);
						break;
					case "dttyp.image":
						this.ValImage = ViewModelConversion.ToImage(_value);
						break;
					case "dttyp.coddttyp":
						this.ValCoddttyp = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Dttyp) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Dttyp)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Dttyp.Find(id ?? Navigation.GetStrValue("dttyp"), m_userContext, "FDTTYP"); }
			finally { Model ??= new Models.Dttyp(m_userContext) { Identifier = "FDTTYP" }; }

			base.LoadModel();
		}

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
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FDTTYP";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

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

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE DTTYP]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DTTYP]/

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
				"dttyp.boolean2" => ViewModelConversion.ToNumeric(modelValue),
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
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValMultili3 = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValMultili3, true);
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValImage != null)
				ValImage.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaDTTYP, CSGenioAdttyp.FldImage.Field, null, ValCoddttyp);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DTTYP]/

		#endregion
	}
}
