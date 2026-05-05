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

namespace GenioMVC.ViewModels.Ufeedback
{
	public class Detailedfeedback_ViewModel : FormViewModel<Models.Ufeedback>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodfeedbacktype { get; set; }

		#endregion
		/// <summary>
		/// Title: "Identify wich service you want to evaluate" | Type: "AC"
		/// </summary>
		public string ValServicefeedback { get; set; }
		/// <summary>
		/// Title: "Identify what's the subject you intend to give feedback on" | Type: "AC"
		/// </summary>
		public string ValServicetype { get; set; }
		/// <summary>
		/// Title: "Comments" | Type: "MO"
		/// </summary>
		public string ValFeedbcoment { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "DT"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValFeedbackdate { get; set; }
		/// <summary>
		/// Title: "Files" | Type: "IB"
		/// </summary>
		[Document("ValFeedbfile", true, false, false, DocumentViewTypeMode.Preview)]
		public string ValFeedbfile { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValFeedbfilefk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValFeedbfilePropertiesVM { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodufeedback { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Detailedfeedback_ViewModel() : base(null!) { }

		public Detailedfeedback_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDETAILEDFEEDBACK", nestedForm) { }

		public Detailedfeedback_ViewModel(UserContext userContext, Models.Ufeedback row, bool nestedForm = false) : base(userContext, "FDETAILEDFEEDBACK", row, nestedForm) { }

		public Detailedfeedback_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("ufeedback", id);
			Model = Models.Ufeedback.Find(id, userContext, "FDETAILEDFEEDBACK", fieldsToQuery: fieldsToLoad);
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
			Models.Ufeedback model = new Models.Ufeedback(userContext) { Identifier = "FDETAILEDFEEDBACK" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDETAILEDFEEDBACK");
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
		public override void MapFromModel(Models.Ufeedback m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Ufeedback) to ViewModel (Detailedfeedback) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodfeedbacktype = ViewModelConversion.ToString(m.ValCodfeedbacktype);
				ValServicefeedback = ViewModelConversion.ToString(m.ValServicefeedback);
				ValServicetype = ViewModelConversion.ToString(m.ValServicetype);
				ValFeedbcoment = ViewModelConversion.ToString(m.ValFeedbcoment);
				ValFeedbackdate = ViewModelConversion.ToDateTime(m.ValFeedbackdate);
				ValFeedbfile = ViewModelConversion.ToString(m.ValFeedbfile);
				ValFeedbfilefk = ViewModelConversion.ToString(m.ValFeedbfilefk);
				ValCodufeedback = ViewModelConversion.ToString(m.ValCodufeedback);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Ufeedback) to ViewModel (Detailedfeedback) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Ufeedback m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Detailedfeedback) to Model (Ufeedback) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValServicefeedback = ViewModelConversion.ToString(ValServicefeedback);
				m.ValServicetype = ViewModelConversion.ToString(ValServicetype);
				m.ValFeedbcoment = ViewModelConversion.ToString(ValFeedbcoment);
				m.ValFeedbfile = ViewModelConversion.ToString(ValFeedbfile);
				m.ValFeedbfilefk = ViewModelConversion.ToString(ValFeedbfilefk);
				m.ValCodufeedback = ViewModelConversion.ToString(ValCodufeedback);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodfeedbacktype = ViewModelConversion.ToString(ValCodfeedbacktype);
				m.ValFeedbackdate = ViewModelConversion.ToDateTime(ValFeedbackdate);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Detailedfeedback) to Model (Ufeedback) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "ufeedback.servicefeedback":
						this.ValServicefeedback = ViewModelConversion.ToString(_value);
						break;
					case "ufeedback.servicetype":
						this.ValServicetype = ViewModelConversion.ToString(_value);
						break;
					case "ufeedback.feedbcoment":
						this.ValFeedbcoment = ViewModelConversion.ToString(_value);
						break;
					case "ufeedback.feedbfile":
						this.ValFeedbfile = ViewModelConversion.ToString(_value);
						break;
					case "ufeedback.codufeedback":
						this.ValCodufeedback = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Detailedfeedback) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Detailedfeedback)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Ufeedback.Find(id ?? Navigation.GetStrValue("ufeedback"), m_userContext, "FDETAILEDFEEDBACK"); }
			finally { Model ??= new Models.Ufeedback(m_userContext) { Identifier = "FDETAILEDFEEDBACK" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Ufeedback.Find(Navigation.GetStrValue("ufeedback"), m_userContext, "FDETAILEDFEEDBACK");
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

			Model.Identifier = "FDETAILEDFEEDBACK";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
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

		protected override void LoadDocumentsProperties(Models.Ufeedback row)
		{
			try
			{
				ValFeedbfilePropertiesVM = row.GetInfoDoc("ValFeedbfile");
			}
			catch (Exception)
			{
				ValFeedbfilePropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
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
				Model = Models.Ufeedback.Find(Navigation.GetStrValue("ufeedback"), m_userContext, "FDETAILEDFEEDBACK");
				if (Model == null)
				{
					Model = new Models.Ufeedback(m_userContext) { Identifier = "FDETAILEDFEEDBACK" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("ufeedback");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DETAILEDFEEDBACK]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DETAILEDFEEDBACK]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValServicefeedback", Resources.Resources.IDENTIFY_WICH_SERVIC17055, ViewModelConversion.ToString(ValServicefeedback), FieldType.ARRAY_TEXT.GetFormatting());

			validator.Required("ValServicetype", Resources.Resources.IDENTIFY_WHAT_S_THE_05318, ViewModelConversion.ToString(ValServicetype), FieldType.ARRAY_TEXT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE DETAILEDFEEDBACK]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DETAILEDFEEDBACK]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DETAILEDFEEDBACK]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DETAILEDFEEDBACK]/
		public override void Destroy(string id)
		{
			Model = Models.Ufeedback.Find(id, m_userContext, "FDETAILEDFEEDBACK");
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
				"ufeedback.codfeedbacktype" => ViewModelConversion.ToString(modelValue),
				"ufeedback.servicefeedback" => ViewModelConversion.ToString(modelValue),
				"ufeedback.servicetype" => ViewModelConversion.ToString(modelValue),
				"ufeedback.feedbcoment" => ViewModelConversion.ToString(modelValue),
				"ufeedback.feedbackdate" => ViewModelConversion.ToDateTime(modelValue),
				"ufeedback.feedbfile" => ViewModelConversion.ToString(modelValue),
				"ufeedback.codufeedback" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DETAILEDFEEDBACK]/

		#endregion
	}
}
