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

namespace GenioMVC.ViewModels.Decom
{
	public class Abatereq_ViewModel : FormViewModel<Models.Decom>, IPreparableForSerialization
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
		/// Title: "Number" | Type: "N"
		/// </summary>
		public decimal? ValDecomnr { get; set; }
		/// <summary>
		/// Title: "Notes" | Type: "MO"
		/// </summary>
		public string ValNote { get; set; }
		/// <summary>
		/// Title: "Decomission" | Type: "DT"
		/// </summary>
		public DateTime? ValDtdeco { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddeco { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Abatereq_ViewModel() : base(null!) { }

		public Abatereq_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FABATEREQ", nestedForm) { }

		public Abatereq_ViewModel(UserContext userContext, Models.Decom row, bool nestedForm = false) : base(userContext, "FABATEREQ", row, nestedForm) { }

		public Abatereq_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("decom", id);
			Model = Models.Decom.Find(id, userContext, "FABATEREQ", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Decom model = new Models.Decom(userContext) { Identifier = "FABATEREQ" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FABATEREQ");
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

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Decom model = Model;
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
		public override void MapFromModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abatereq) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDecomnr = ViewModelConversion.ToNumeric(m.ValDecomnr);
				ValNote = ViewModelConversion.ToString(m.ValNote);
				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abatereq) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Abatereq) to Model (Decom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDecomnr = ViewModelConversion.ToNumeric(ValDecomnr);
				m.ValNote = ViewModelConversion.ToString(ValNote);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Abatereq) to Model (Decom) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "decom.decomnr":
						this.ValDecomnr = ViewModelConversion.ToNumeric(_value);
						break;
					case "decom.note":
						this.ValNote = ViewModelConversion.ToString(_value);
						break;
					case "decom.dtdeco":
						this.ValDtdeco = ViewModelConversion.ToDateTime(_value);
						break;
					case "decom.coddeco":
						this.ValCoddeco = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Abatereq) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Abatereq)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Decom.Find(id ?? Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ"); }
			finally { Model ??= new Models.Decom(m_userContext) { Identifier = "FABATEREQ" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ");
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

			Model.Identifier = "FABATEREQ";
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

		protected override void LoadDocumentsProperties(Models.Decom row)
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
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ");
				if (Model == null)
				{
					Model = new Models.Decom(m_userContext) { Identifier = "FABATEREQ" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("decom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ABATEREQ]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ABATEREQ]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValDecomnr", Resources.Resources.NUMBER35625, ViewModelConversion.ToNumeric(ValDecomnr), FieldType.NUMERIC.GetFormatting());

			validator.Required("ValNote", Resources.Resources.NOTES05274, ViewModelConversion.ToString(ValNote), FieldType.MEMO.GetFormatting());

			validator.Required("ValDtdeco", Resources.Resources.DECOMISSION14486, ViewModelConversion.ToDateTime(ValDtdeco), FieldType.DATETIME.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ABATEREQ]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ABATEREQ]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ABATEREQ]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ABATEREQ]/
		public override void Destroy(string id)
		{
			Model = Models.Decom.Find(id, m_userContext, "FABATEREQ");
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
				"decom.decomnr" => ViewModelConversion.ToNumeric(modelValue),
				"decom.note" => ViewModelConversion.ToString(modelValue),
				"decom.dtdeco" => ViewModelConversion.ToDateTime(modelValue),
				"decom.coddeco" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ABATEREQ]/

		#endregion
	}
}
