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

namespace GenioMVC.ViewModels.Facty
{
	public class Facty_ViewModel : FormViewModel<Models.Facty>, IPreparableForSerialization
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
		/// Title: "Facility type" | Type: "C"
		/// </summary>
		public string ValType { get; set; }
		/// <summary>
		/// Title: "Layer name" | Type: "C"
		/// </summary>
		public string ValLayrname { get; set; }
		/// <summary>
		/// Title: "Icon URL" | Type: "C"
		/// </summary>
		public string ValIconurl { get; set; }
		/// <summary>
		/// Title: "Shadow URL" | Type: "C"
		/// </summary>
		public string ValShadowur { get; set; }
		/// <summary>
		/// Title: "Icon anchor (x-axis)" | Type: "N"
		/// </summary>
		public decimal? ValIconancx { get; set; }
		/// <summary>
		/// Title: "Icon anchor (y-axis)" | Type: "N"
		/// </summary>
		public decimal? ValIconancy { get; set; }
		/// <summary>
		/// Title: "Icon height" | Type: "N"
		/// </summary>
		public decimal? ValIconheig { get; set; }
		/// <summary>
		/// Title: "Icon width" | Type: "N"
		/// </summary>
		public decimal? ValIconwid { get; set; }
		/// <summary>
		/// Title: "Popup anchor (x-axis)" | Type: "N"
		/// </summary>
		public decimal? ValPopupanx { get; set; }
		/// <summary>
		/// Title: "Popup anchor (y-axis)" | Type: "N"
		/// </summary>
		public decimal? ValPopupany { get; set; }
		/// <summary>
		/// Title: "Shadow anchor (x-axis)" | Type: "N"
		/// </summary>
		public decimal? ValShadowax { get; set; }
		/// <summary>
		/// Title: "Shadow anchor (y-axis)" | Type: "N"
		/// </summary>
		public decimal? ValShadoway { get; set; }
		/// <summary>
		/// Title: "Shadow height" | Type: "N"
		/// </summary>
		public decimal? ValShadowhe { get; set; }
		/// <summary>
		/// Title: "Shadow width" | Type: "N"
		/// </summary>
		public decimal? ValShadowwi { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodfacty { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Facty_ViewModel() : base(null!) { }

		public Facty_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFACTY", nestedForm) { }

		public Facty_ViewModel(UserContext userContext, Models.Facty row, bool nestedForm = false) : base(userContext, "FFACTY", row, nestedForm) { }

		public Facty_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("facty", id);
			Model = Models.Facty.Find(id, userContext, "FFACTY", fieldsToQuery: fieldsToLoad);
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
			Models.Facty model = new Models.Facty(userContext) { Identifier = "FFACTY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFACTY");
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
			Models.Facty model = Model;
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
		public override void MapFromModel(Models.Facty m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Facty) to ViewModel (Facty) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValType = ViewModelConversion.ToString(m.ValType);
				ValLayrname = ViewModelConversion.ToString(m.ValLayrname);
				ValIconurl = ViewModelConversion.ToString(m.ValIconurl);
				ValShadowur = ViewModelConversion.ToString(m.ValShadowur);
				ValIconancx = ViewModelConversion.ToNumeric(m.ValIconancx);
				ValIconancy = ViewModelConversion.ToNumeric(m.ValIconancy);
				ValIconheig = ViewModelConversion.ToNumeric(m.ValIconheig);
				ValIconwid = ViewModelConversion.ToNumeric(m.ValIconwid);
				ValPopupanx = ViewModelConversion.ToNumeric(m.ValPopupanx);
				ValPopupany = ViewModelConversion.ToNumeric(m.ValPopupany);
				ValShadowax = ViewModelConversion.ToNumeric(m.ValShadowax);
				ValShadoway = ViewModelConversion.ToNumeric(m.ValShadoway);
				ValShadowhe = ViewModelConversion.ToNumeric(m.ValShadowhe);
				ValShadowwi = ViewModelConversion.ToNumeric(m.ValShadowwi);
				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Facty) to ViewModel (Facty) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Facty m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facty) to Model (Facty) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValType = ViewModelConversion.ToString(ValType);
				m.ValLayrname = ViewModelConversion.ToString(ValLayrname);
				m.ValIconurl = ViewModelConversion.ToString(ValIconurl);
				m.ValShadowur = ViewModelConversion.ToString(ValShadowur);
				m.ValIconancx = ViewModelConversion.ToNumeric(ValIconancx);
				m.ValIconancy = ViewModelConversion.ToNumeric(ValIconancy);
				m.ValIconheig = ViewModelConversion.ToNumeric(ValIconheig);
				m.ValIconwid = ViewModelConversion.ToNumeric(ValIconwid);
				m.ValPopupanx = ViewModelConversion.ToNumeric(ValPopupanx);
				m.ValPopupany = ViewModelConversion.ToNumeric(ValPopupany);
				m.ValShadowax = ViewModelConversion.ToNumeric(ValShadowax);
				m.ValShadoway = ViewModelConversion.ToNumeric(ValShadoway);
				m.ValShadowhe = ViewModelConversion.ToNumeric(ValShadowhe);
				m.ValShadowwi = ViewModelConversion.ToNumeric(ValShadowwi);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Facty) to Model (Facty) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "facty.type":
						this.ValType = ViewModelConversion.ToString(_value);
						break;
					case "facty.layrname":
						this.ValLayrname = ViewModelConversion.ToString(_value);
						break;
					case "facty.iconurl":
						this.ValIconurl = ViewModelConversion.ToString(_value);
						break;
					case "facty.shadowur":
						this.ValShadowur = ViewModelConversion.ToString(_value);
						break;
					case "facty.iconancx":
						this.ValIconancx = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.iconancy":
						this.ValIconancy = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.iconheig":
						this.ValIconheig = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.iconwid":
						this.ValIconwid = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.popupanx":
						this.ValPopupanx = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.popupany":
						this.ValPopupany = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.shadowax":
						this.ValShadowax = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.shadoway":
						this.ValShadoway = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.shadowhe":
						this.ValShadowhe = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.shadowwi":
						this.ValShadowwi = ViewModelConversion.ToNumeric(_value);
						break;
					case "facty.codfacty":
						this.ValCodfacty = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Facty) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Facty)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Facty.Find(id ?? Navigation.GetStrValue("facty"), m_userContext, "FFACTY"); }
			finally { Model ??= new Models.Facty(m_userContext) { Identifier = "FFACTY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Facty.Find(Navigation.GetStrValue("facty"), m_userContext, "FFACTY");
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

			Model.Identifier = "FFACTY";
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

		protected override void LoadDocumentsProperties(Models.Facty row)
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
				Model = Models.Facty.Find(Navigation.GetStrValue("facty"), m_userContext, "FFACTY");
				if (Model == null)
				{
					Model = new Models.Facty(m_userContext) { Identifier = "FFACTY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("facty");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FACTY]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FACTY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValType", Resources.Resources.FACILITY_TYPE44577, ValType, 25);
			validator.StringLength("ValLayrname", Resources.Resources.LAYER_NAME49545, ValLayrname, 50);
			validator.StringLength("ValIconurl", Resources.Resources.ICON_URL07016, ValIconurl, 50);
			validator.StringLength("ValShadowur", Resources.Resources.SHADOW_URL57805, ValShadowur, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE FACTY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FACTY]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FACTY]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FACTY]/
		public override void Destroy(string id)
		{
			Model = Models.Facty.Find(id, m_userContext, "FFACTY");
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
				"facty.type" => ViewModelConversion.ToString(modelValue),
				"facty.layrname" => ViewModelConversion.ToString(modelValue),
				"facty.iconurl" => ViewModelConversion.ToString(modelValue),
				"facty.shadowur" => ViewModelConversion.ToString(modelValue),
				"facty.iconancx" => ViewModelConversion.ToNumeric(modelValue),
				"facty.iconancy" => ViewModelConversion.ToNumeric(modelValue),
				"facty.iconheig" => ViewModelConversion.ToNumeric(modelValue),
				"facty.iconwid" => ViewModelConversion.ToNumeric(modelValue),
				"facty.popupanx" => ViewModelConversion.ToNumeric(modelValue),
				"facty.popupany" => ViewModelConversion.ToNumeric(modelValue),
				"facty.shadowax" => ViewModelConversion.ToNumeric(modelValue),
				"facty.shadoway" => ViewModelConversion.ToNumeric(modelValue),
				"facty.shadowhe" => ViewModelConversion.ToNumeric(modelValue),
				"facty.shadowwi" => ViewModelConversion.ToNumeric(modelValue),
				"facty.codfacty" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FACTY]/

		#endregion
	}
}
