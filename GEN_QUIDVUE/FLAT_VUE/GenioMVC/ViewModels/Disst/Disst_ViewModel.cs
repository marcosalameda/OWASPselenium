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

namespace GenioMVC.ViewModels.Disst
{
	public class Disst_ViewModel : FormViewModel<Models.Disst>, IPreparableForSerialization
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
		/// Title: "Status" | Type: "C"
		/// </summary>
		public string ValStatus { get; set; }
		/// <summary>
		/// Title: "Order" | Type: "N"
		/// </summary>
		public decimal? ValOrder { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescript { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddisst { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Disst_ViewModel() : base(null!) { }

		public Disst_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDISST", nestedForm) { }

		public Disst_ViewModel(UserContext userContext, Models.Disst row, bool nestedForm = false) : base(userContext, "FDISST", row, nestedForm) { }

		public Disst_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("disst", id);
			Model = Models.Disst.Find(id, userContext, "FDISST", fieldsToQuery: fieldsToLoad);
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
			Models.Disst model = new Models.Disst(userContext) { Identifier = "FDISST" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDISST");
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
			Models.Disst model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Disst m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Disst) to ViewModel (Disst) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValStatus = ViewModelConversion.ToString(m.ValStatus);
				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValCoddisst = ViewModelConversion.ToString(m.ValCoddisst);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Disst) to ViewModel (Disst) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Disst m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Disst) to Model (Disst) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValStatus = ViewModelConversion.ToString(ValStatus);
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValCoddisst = ViewModelConversion.ToString(ValCoddisst);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Disst) to Model (Disst) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "disst.status":
						this.ValStatus = ViewModelConversion.ToString(_value);
						break;
					case "disst.order":
						this.ValOrder = ViewModelConversion.ToNumeric(_value);
						break;
					case "disst.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "disst.coddisst":
						this.ValCoddisst = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Disst) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Disst)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Disst.Find(id ?? Navigation.GetStrValue("disst"), m_userContext, "FDISST"); }
			finally { Model ??= new Models.Disst(m_userContext) { Identifier = "FDISST" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Disst.Find(Navigation.GetStrValue("disst"), m_userContext, "FDISST");
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

			Model.Identifier = "FDISST";
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

		protected override void LoadDocumentsProperties(Models.Disst row)
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
				Model = Models.Disst.Find(Navigation.GetStrValue("disst"), m_userContext, "FDISST");
				if (Model == null)
				{
					Model = new Models.Disst(m_userContext) { Identifier = "FDISST" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("disst");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DISST]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DISST]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValStatus", Resources.Resources.STATUS62033, ValStatus, 50);

			validator.Required("ValStatus", Resources.Resources.STATUS62033, ViewModelConversion.ToString(ValStatus), FieldType.TEXTO.Formatting);
			validator.StringLength("ValDescript", Resources.Resources.DESCRIPTION07383, ValDescript, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE DISST]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DISST]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DISST]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DISST]/
		public override void Destroy(string id)
		{
			Model = Models.Disst.Find(id, m_userContext, "FDISST");
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
				"disst.status" => ViewModelConversion.ToString(modelValue),
				"disst.order" => ViewModelConversion.ToNumeric(modelValue),
				"disst.descript" => ViewModelConversion.ToString(modelValue),
				"disst.coddisst" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DISST]/

		#endregion
	}
}
