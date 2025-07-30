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

namespace GenioMVC.ViewModels.Addre
{
	public class Addre_ViewModel : FormViewModel<Models.Addre>, IPreparableForSerialization
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
		/// Title: "Address Use" | Type: "AC"
		/// </summary>
		public string ValAddressuse { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAddressuse { get; set; }
		/// <summary>
		/// Title: "Address Type" | Type: "AC"
		/// </summary>
		public string ValAddresstype { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAddresstype { get; set; }
		/// <summary>
		/// Title: "Entire address" | Type: "MO"
		/// </summary>
		public string ValAddresstext { get; set; }
		/// <summary>
		/// Title: "Address City" | Type: "C"
		/// </summary>
		public string ValAddresscity { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Period Start" Tipo: "DT"</summary>
		[ValidateSetAccess]
		public DateTime? ValPeriodstart { get; set; }
		// Field for formula
		/// <summary>Field: "Period End" Tipo: "DT"</summary>
		[ValidateSetAccess]
		public DateTime? ValPeriodend { get; set; }

		#endregion

		public string ValCodaddre { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Addre_ViewModel() : base(null!) { }

		public Addre_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FADDRE", nestedForm) { }

		public Addre_ViewModel(UserContext userContext, Models.Addre row, bool nestedForm = false) : base(userContext, "FADDRE", row, nestedForm) { }

		public Addre_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("addre", id);
			Model = Models.Addre.Find(id, userContext, "FADDRE", fieldsToQuery: fieldsToLoad);
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
			Models.Addre model = new Models.Addre(userContext) { Identifier = "FADDRE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FADDRE");
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
		public override void MapFromModel(Models.Addre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Addre) to ViewModel (Addre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAddressuse = ViewModelConversion.ToString(m.ValAddressuse);
				ValAddresstype = ViewModelConversion.ToString(m.ValAddresstype);
				ValAddresstext = ViewModelConversion.ToString(m.ValAddresstext);
				ValAddresscity = ViewModelConversion.ToString(m.ValAddresscity);
				ValPeriodstart = ViewModelConversion.ToDateTime(m.ValPeriodstart);
				ValPeriodend = ViewModelConversion.ToDateTime(m.ValPeriodend);
				ValCodaddre = ViewModelConversion.ToString(m.ValCodaddre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Addre) to ViewModel (Addre) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Addre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Addre) to Model (Addre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAddressuse = ViewModelConversion.ToString(ValAddressuse);
				m.ValAddresstype = ViewModelConversion.ToString(ValAddresstype);
				m.ValAddresstext = ViewModelConversion.ToString(ValAddresstext);
				m.ValAddresscity = ViewModelConversion.ToString(ValAddresscity);
				m.ValCodaddre = ViewModelConversion.ToString(ValCodaddre);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValPeriodstart = ViewModelConversion.ToDateTime(ValPeriodstart);
				m.ValPeriodend = ViewModelConversion.ToDateTime(ValPeriodend);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Addre) to Model (Addre) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "addre.addressuse":
						this.ValAddressuse = ViewModelConversion.ToString(_value);
						break;
					case "addre.addresstype":
						this.ValAddresstype = ViewModelConversion.ToString(_value);
						break;
					case "addre.addresstext":
						this.ValAddresstext = ViewModelConversion.ToString(_value);
						break;
					case "addre.addresscity":
						this.ValAddresscity = ViewModelConversion.ToString(_value);
						break;
					case "addre.codaddre":
						this.ValCodaddre = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Addre) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Addre)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Addre.Find(id ?? Navigation.GetStrValue("addre"), m_userContext, "FADDRE"); }
			finally { Model ??= new Models.Addre(m_userContext) { Identifier = "FADDRE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Addre.Find(Navigation.GetStrValue("addre"), m_userContext, "FADDRE");
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

			Model.Identifier = "FADDRE";
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

		protected override void LoadDocumentsProperties(Models.Addre row)
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
				Model = Models.Addre.Find(Navigation.GetStrValue("addre"), m_userContext, "FADDRE");
				if (Model == null)
				{
					Model = new Models.Addre(m_userContext) { Identifier = "FADDRE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("addre");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ADDRE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ADDRE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValAddresscity", Resources.Resources.ADDRESS_CITY41109, ValAddresscity, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ADDRE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ADDRE]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ADDRE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ADDRE]/
		public override void Destroy(string id)
		{
			Model = Models.Addre.Find(id, m_userContext, "FADDRE");
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
				"addre.addressuse" => ViewModelConversion.ToString(modelValue),
				"addre.addresstype" => ViewModelConversion.ToString(modelValue),
				"addre.addresstext" => ViewModelConversion.ToString(modelValue),
				"addre.addresscity" => ViewModelConversion.ToString(modelValue),
				"addre.periodstart" => ViewModelConversion.ToDateTime(modelValue),
				"addre.periodend" => ViewModelConversion.ToDateTime(modelValue),
				"addre.codaddre" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ADDRE]/

		#endregion
	}
}
