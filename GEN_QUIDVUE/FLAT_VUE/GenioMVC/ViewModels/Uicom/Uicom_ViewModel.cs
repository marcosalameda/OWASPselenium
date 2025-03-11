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

namespace GenioMVC.ViewModels.Uicom
{
	public class Uicom_ViewModel : FormViewModel<Models.Uicom>, IPreparableForSerialization
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
		/// Title: "Miniature" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(270, 50)]
		public GenioMVC.Models.ImageModel ValThumbnai { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		public string ValCategory { get; set; }
		/// <summary>
		/// Title: "Fixed menu name" | Type: "C"
		/// </summary>
		public string ValMenuid { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoduicom { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Uicom_ViewModel() : base(null!) { }

		public Uicom_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FUICOM", nestedForm) { }

		public Uicom_ViewModel(UserContext userContext, Models.Uicom row, bool nestedForm = false) : base(userContext, "FUICOM", row, nestedForm) { }

		public Uicom_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("uicom", id);
			Model = Models.Uicom.Find(id, userContext, "FUICOM", fieldsToQuery: fieldsToLoad);
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
			Models.Uicom model = new Models.Uicom(userContext) { Identifier = "FUICOM" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FUICOM");
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
			Models.Uicom model = Model;
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
		public override void MapFromModel(Models.Uicom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Uicom) to ViewModel (Uicom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValThumbnai = ViewModelConversion.ToImage(m.ValThumbnai);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCategory = ViewModelConversion.ToString(m.ValCategory);
				ValMenuid = ViewModelConversion.ToString(m.ValMenuid);
				ValCoduicom = ViewModelConversion.ToString(m.ValCoduicom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Uicom) to ViewModel (Uicom) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Uicom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Uicom) to Model (Uicom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				if (ValThumbnai == null || !ValThumbnai.IsThumbnail)
					m.ValThumbnai = ViewModelConversion.ToImage(ValThumbnai);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValMenuid = ViewModelConversion.ToString(ValMenuid);
				m.ValCoduicom = ViewModelConversion.ToString(ValCoduicom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Uicom) to Model (Uicom) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "uicom.thumbnai":
						this.ValThumbnai = ViewModelConversion.ToImage(_value);
						break;
					case "uicom.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "uicom.category":
						this.ValCategory = ViewModelConversion.ToString(_value);
						break;
					case "uicom.menuid":
						this.ValMenuid = ViewModelConversion.ToString(_value);
						break;
					case "uicom.coduicom":
						this.ValCoduicom = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Uicom) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Uicom)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Uicom.Find(id ?? Navigation.GetStrValue("uicom"), m_userContext, "FUICOM"); }
			finally { Model ??= new Models.Uicom(m_userContext) { Identifier = "FUICOM" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), m_userContext, "FUICOM");
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

			Model.Identifier = "FUICOM";
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

		protected override void LoadDocumentsProperties(Models.Uicom row)
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
				Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), m_userContext, "FUICOM");
				if (Model == null)
				{
					Model = new Models.Uicom(m_userContext) { Identifier = "FUICOM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("uicom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL UICOM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW UICOM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);
			validator.StringLength("ValCategory", Resources.Resources.CATEGORY18978, ValCategory, 50);
			validator.StringLength("ValMenuid", Resources.Resources.FIXED_MENU_NAME38578, ValMenuid, 30);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE UICOM]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY UICOM]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE UICOM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY UICOM]/
		public override void Destroy(string id)
		{
			Model = Models.Uicom.Find(id, m_userContext, "FUICOM");
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
				"uicom.thumbnai" => ViewModelConversion.ToImage(modelValue),
				"uicom.name" => ViewModelConversion.ToString(modelValue),
				"uicom.category" => ViewModelConversion.ToString(modelValue),
				"uicom.menuid" => ViewModelConversion.ToString(modelValue),
				"uicom.coduicom" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValThumbnai != null)
				ValThumbnai.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaUICOM, CSGenioAuicom.FldThumbnai.Field, null, ValCoduicom);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM UICOM]/

		#endregion
	}
}
