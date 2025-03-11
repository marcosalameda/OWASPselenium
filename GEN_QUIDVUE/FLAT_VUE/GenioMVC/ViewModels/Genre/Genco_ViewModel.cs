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

namespace GenioMVC.ViewModels.Genre
{
	public class Genco_ViewModel : FormViewModel<Models.Genre>, IPreparableForSerialization
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
		/// Title: "Contact Genre" | Type: "AC"
		/// </summary>
		public string ValAgencont { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAgencont { get; set; }
		/// <summary>
		/// Title: "Genre" | Type: "C"
		/// </summary>
		public string ValGender { get; set; }
		/// <summary>
		/// Title: "Background Color" | Type: "C"
		/// </summary>
		public string ValBackcolo { get; set; }
		/// <summary>
		/// Title: "Text Color" | Type: "C"
		/// </summary>
		public string ValTextcolo { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodgenre { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Genco_ViewModel() : base(null!) { }

		public Genco_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGENCO", nestedForm) { }

		public Genco_ViewModel(UserContext userContext, Models.Genre row, bool nestedForm = false) : base(userContext, "FGENCO", row, nestedForm) { }

		public Genco_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("genre", id);
			Model = Models.Genre.Find(id, userContext, "FGENCO", fieldsToQuery: fieldsToLoad);
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
			Models.Genre model = new Models.Genre(userContext) { Identifier = "FGENCO" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FGENCO");
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
			Models.Genre model = Model;
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
		public override void MapFromModel(Models.Genre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Genre) to ViewModel (Genco) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAgencont = ViewModelConversion.ToString(m.ValAgencont);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
				ValTextcolo = ViewModelConversion.ToString(m.ValTextcolo);
				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Genre) to ViewModel (Genco) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Genre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Genco) to Model (Genre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAgencont = ViewModelConversion.ToString(ValAgencont);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
				m.ValTextcolo = ViewModelConversion.ToString(ValTextcolo);
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Genco) to Model (Genre) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "genre.agencont":
						this.ValAgencont = ViewModelConversion.ToString(_value);
						break;
					case "genre.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "genre.backcolo":
						this.ValBackcolo = ViewModelConversion.ToString(_value);
						break;
					case "genre.textcolo":
						this.ValTextcolo = ViewModelConversion.ToString(_value);
						break;
					case "genre.codgenre":
						this.ValCodgenre = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Genco) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Genco)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Genre.Find(id ?? Navigation.GetStrValue("genre"), m_userContext, "FGENCO"); }
			finally { Model ??= new Models.Genre(m_userContext) { Identifier = "FGENCO" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Genre.Find(Navigation.GetStrValue("genre"), m_userContext, "FGENCO");
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

			Model.Identifier = "FGENCO";
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

		protected override void LoadDocumentsProperties(Models.Genre row)
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
				Model = Models.Genre.Find(Navigation.GetStrValue("genre"), m_userContext, "FGENCO");
				if (Model == null)
				{
					Model = new Models.Genre(m_userContext) { Identifier = "FGENCO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("genre");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GENCO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GENCO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValGender", Resources.Resources.GENRE63303, ValGender, 20);
			validator.StringLength("ValBackcolo", Resources.Resources.BACKGROUND_COLOR07511, ValBackcolo, 50);
			validator.StringLength("ValTextcolo", Resources.Resources.TEXT_COLOR63426, ValTextcolo, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE GENCO]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GENCO]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GENCO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GENCO]/
		public override void Destroy(string id)
		{
			Model = Models.Genre.Find(id, m_userContext, "FGENCO");
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
				"genre.agencont" => ViewModelConversion.ToString(modelValue),
				"genre.gender" => ViewModelConversion.ToString(modelValue),
				"genre.backcolo" => ViewModelConversion.ToString(modelValue),
				"genre.textcolo" => ViewModelConversion.ToString(modelValue),
				"genre.codgenre" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GENCO]/

		#endregion
	}
}
