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

namespace GenioMVC.ViewModels.Authenticatopt
{
	public class Authentcopt_ViewModel : FormViewModel<Models.Authenticatopt>, IPreparableForSerialization
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
		/// Title: "Variable type" | Type: "C"
		/// </summary>
		public string ValAuthvariablet { get; set; }
		/// <summary>
		/// Title: "Variable name" | Type: "C"
		/// </summary>
		public string ValAuthvarname { get; set; }
		/// <summary>
		/// Title: "Option" | Type: "AC"
		/// </summary>
		public string ValAuthoptions { get; set; }
		/// <summary>
		/// Title: "MVC" | Type: "L"
		/// </summary>
		public bool ValAuthmvc { get; set; }
		/// <summary>
		/// Title: "VUE" | Type: "L"
		/// </summary>
		public bool ValAuthvue { get; set; }
		/// <summary>
		/// Title: "Notes" | Type: "MO"
		/// </summary>
		public string ValAuthnotes { get; set; }
		/// <summary>
		/// Title: "Preview" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(300, 400)]
		public GenioMVC.Models.ImageModel ValAuthpreview { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodauthenticatopt { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Authentcopt_ViewModel() : base(null!) { }

		public Authentcopt_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FAUTHENTCOPT", nestedForm) { }

		public Authentcopt_ViewModel(UserContext userContext, Models.Authenticatopt row, bool nestedForm = false) : base(userContext, "FAUTHENTCOPT", row, nestedForm) { }

		public Authentcopt_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("authenticatopt", id);
			Model = Models.Authenticatopt.Find(id, userContext, "FAUTHENTCOPT", fieldsToQuery: fieldsToLoad);
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
			Models.Authenticatopt model = new Models.Authenticatopt(userContext) { Identifier = "FAUTHENTCOPT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FAUTHENTCOPT");
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
		public override void MapFromModel(Models.Authenticatopt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Authenticatopt) to ViewModel (Authentcopt) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAuthvariablet = ViewModelConversion.ToString(m.ValAuthvariablet);
				ValAuthvarname = ViewModelConversion.ToString(m.ValAuthvarname);
				ValAuthoptions = ViewModelConversion.ToString(m.ValAuthoptions);
				ValAuthmvc = ViewModelConversion.ToLogic(m.ValAuthmvc);
				ValAuthvue = ViewModelConversion.ToLogic(m.ValAuthvue);
				ValAuthnotes = ViewModelConversion.ToString(m.ValAuthnotes);
				ValAuthpreview = ViewModelConversion.ToImage(m.ValAuthpreview);
				ValCodauthenticatopt = ViewModelConversion.ToString(m.ValCodauthenticatopt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Authenticatopt) to ViewModel (Authentcopt) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Authenticatopt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Authentcopt) to Model (Authenticatopt) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAuthvariablet = ViewModelConversion.ToString(ValAuthvariablet);
				m.ValAuthvarname = ViewModelConversion.ToString(ValAuthvarname);
				m.ValAuthoptions = ViewModelConversion.ToString(ValAuthoptions);
				m.ValAuthmvc = ViewModelConversion.ToLogic(ValAuthmvc);
				m.ValAuthvue = ViewModelConversion.ToLogic(ValAuthvue);
				m.ValAuthnotes = ViewModelConversion.ToString(ValAuthnotes);
				if (ValAuthpreview == null || !ValAuthpreview.IsThumbnail)
					m.ValAuthpreview = ViewModelConversion.ToImage(ValAuthpreview);
				m.ValCodauthenticatopt = ViewModelConversion.ToString(ValCodauthenticatopt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Authentcopt) to Model (Authenticatopt) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "authenticatopt.authvariablet":
						this.ValAuthvariablet = ViewModelConversion.ToString(_value);
						break;
					case "authenticatopt.authvarname":
						this.ValAuthvarname = ViewModelConversion.ToString(_value);
						break;
					case "authenticatopt.authoptions":
						this.ValAuthoptions = ViewModelConversion.ToString(_value);
						break;
					case "authenticatopt.authmvc":
						this.ValAuthmvc = ViewModelConversion.ToLogic(_value);
						break;
					case "authenticatopt.authvue":
						this.ValAuthvue = ViewModelConversion.ToLogic(_value);
						break;
					case "authenticatopt.authnotes":
						this.ValAuthnotes = ViewModelConversion.ToString(_value);
						break;
					case "authenticatopt.authpreview":
						this.ValAuthpreview = ViewModelConversion.ToImage(_value);
						break;
					case "authenticatopt.codauthenticatopt":
						this.ValCodauthenticatopt = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Authentcopt) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Authentcopt)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Authenticatopt.Find(id ?? Navigation.GetStrValue("authenticatopt"), m_userContext, "FAUTHENTCOPT"); }
			finally { Model ??= new Models.Authenticatopt(m_userContext) { Identifier = "FAUTHENTCOPT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Authenticatopt.Find(Navigation.GetStrValue("authenticatopt"), m_userContext, "FAUTHENTCOPT");
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

			Model.Identifier = "FAUTHENTCOPT";
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

		protected override void LoadDocumentsProperties(Models.Authenticatopt row)
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
				Model = Models.Authenticatopt.Find(Navigation.GetStrValue("authenticatopt"), m_userContext, "FAUTHENTCOPT");
				if (Model == null)
				{
					Model = new Models.Authenticatopt(m_userContext) { Identifier = "FAUTHENTCOPT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("authenticatopt");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL AUTHENTCOPT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW AUTHENTCOPT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValAuthvariablet", Resources.Resources.VARIABLE_TYPE39289, ValAuthvariablet, 50);
			validator.StringLength("ValAuthvarname", Resources.Resources.VARIABLE_NAME27631, ValAuthvarname, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE AUTHENTCOPT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY AUTHENTCOPT]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE AUTHENTCOPT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY AUTHENTCOPT]/
		public override void Destroy(string id)
		{
			Model = Models.Authenticatopt.Find(id, m_userContext, "FAUTHENTCOPT");
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
				"authenticatopt.authvariablet" => ViewModelConversion.ToString(modelValue),
				"authenticatopt.authvarname" => ViewModelConversion.ToString(modelValue),
				"authenticatopt.authoptions" => ViewModelConversion.ToString(modelValue),
				"authenticatopt.authmvc" => ViewModelConversion.ToLogic(modelValue),
				"authenticatopt.authvue" => ViewModelConversion.ToLogic(modelValue),
				"authenticatopt.authnotes" => ViewModelConversion.ToString(modelValue),
				"authenticatopt.authpreview" => ViewModelConversion.ToImage(modelValue),
				"authenticatopt.codauthenticatopt" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValAuthpreview != null)
				ValAuthpreview.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaAUTHENTICATOPT, CSGenioAauthenticatopt.FldAuthpreview.Field, null, ValCodauthenticatopt);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM AUTHENTCOPT]/

		#endregion
	}
}
