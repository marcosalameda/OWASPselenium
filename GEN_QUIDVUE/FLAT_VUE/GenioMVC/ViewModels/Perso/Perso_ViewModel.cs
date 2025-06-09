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

namespace GenioMVC.ViewModels.Perso
{
	public class Perso_ViewModel : FormViewModel<Models.Perso>, IPreparableForSerialization
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
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 115)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Person name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Identification number" | Type: "C"
		/// </summary>
		public string ValIdentifi { get; set; }
		/// <summary>
		/// Title: "Gender" | Type: "AC"
		/// </summary>
		public string ValGender { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Date of birth" | Type: "D"
		/// </summary>
		public DateTime? ValDob { get; set; }
		/// <summary>
		/// Title: "Time of birth" | Type: "T"
		/// </summary>
		public string ValTob { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "N"
		/// </summary>
		public decimal? ValYear { get; set; }
		/// <summary>
		/// Title: "Month" | Type: "AN"
		/// </summary>
		public decimal ValMonth { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValMonth { get; set; }
		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreatusr { get; set; }
		/// <summary>
		/// Title: "Created on" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatdat { get; set; }
		/// <summary>
		/// Title: "Modified by" | Type: "EN"
		/// </summary>
		[ValidateSetAccess]
		public string ValModifusr { get; set; }
		/// <summary>
		/// Title: "Modified on" | Type: "ED"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValModifdat { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodperso { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Perso_ViewModel() : base(null!) { }

		public Perso_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPERSO", nestedForm) { }

		public Perso_ViewModel(UserContext userContext, Models.Perso row, bool nestedForm = false) : base(userContext, "FPERSO", row, nestedForm) { }

		public Perso_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("perso", id);
			Model = Models.Perso.Find(id, userContext, "FPERSO", fieldsToQuery: fieldsToLoad);
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
			Models.Perso model = new Models.Perso(userContext) { Identifier = "FPERSO" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPERSO");
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
		public override void MapFromModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValDob = ViewModelConversion.ToDateTime(m.ValDob);
				ValTob = ViewModelConversion.ToString(m.ValTob);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValMonth = ViewModelConversion.ToNumeric(m.ValMonth);
				ValCreatusr = ViewModelConversion.ToString(m.ValCreatusr);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValModifusr = ViewModelConversion.ToString(m.ValModifusr);
				ValModifdat = ViewModelConversion.ToDateTime(m.ValModifdat);
				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Perso) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Perso) to Model (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValDob = ViewModelConversion.ToDateTime(ValDob);
				m.ValTob = ViewModelConversion.ToString(ValTob);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValMonth = ViewModelConversion.ToNumeric(ValMonth);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCreatusr = ViewModelConversion.ToString(ValCreatusr);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValModifusr = ViewModelConversion.ToString(ValModifusr);
				m.ValModifdat = ViewModelConversion.ToDateTime(ValModifdat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Perso) to Model (Perso) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "perso.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "perso.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "perso.identifi":
						this.ValIdentifi = ViewModelConversion.ToString(_value);
						break;
					case "perso.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "perso.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "perso.dob":
						this.ValDob = ViewModelConversion.ToDateTime(_value);
						break;
					case "perso.tob":
						this.ValTob = ViewModelConversion.ToString(_value);
						break;
					case "perso.year":
						this.ValYear = ViewModelConversion.ToNumeric(_value);
						break;
					case "perso.month":
						this.ValMonth = ViewModelConversion.ToNumeric(_value);
						break;
					case "perso.codperso":
						this.ValCodperso = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Perso) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Perso)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Perso.Find(id ?? Navigation.GetStrValue("perso"), m_userContext, "FPERSO"); }
			finally { Model ??= new Models.Perso(m_userContext) { Identifier = "FPERSO" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPERSO");
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

			Model.Identifier = "FPERSO";
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

		protected override void LoadDocumentsProperties(Models.Perso row)
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
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPERSO");
				if (Model == null)
				{
					Model = new Models.Perso(m_userContext) { Identifier = "FPERSO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("perso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PERSO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PERSO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.PERSON_NAME40980, ValName, 85);
			validator.StringLength("ValIdentifi", Resources.Resources.IDENTIFICATION_NUMBE11999, ValIdentifi, 10);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL25170, ValEmail, 254);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PERSO]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PERSO]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PERSO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PERSO]/
		public override void Destroy(string id)
		{
			Model = Models.Perso.Find(id, m_userContext, "FPERSO");
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
				"perso.photo" => ViewModelConversion.ToImage(modelValue),
				"perso.name" => ViewModelConversion.ToString(modelValue),
				"perso.identifi" => ViewModelConversion.ToString(modelValue),
				"perso.gender" => ViewModelConversion.ToString(modelValue),
				"perso.email" => ViewModelConversion.ToString(modelValue),
				"perso.dob" => ViewModelConversion.ToDateTime(modelValue),
				"perso.tob" => ViewModelConversion.ToString(modelValue),
				"perso.year" => ViewModelConversion.ToNumeric(modelValue),
				"perso.month" => ViewModelConversion.ToNumeric(modelValue),
				"perso.creatusr" => ViewModelConversion.ToString(modelValue),
				"perso.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"perso.modifusr" => ViewModelConversion.ToString(modelValue),
				"perso.modifdat" => ViewModelConversion.ToDateTime(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPERSO, CSGenioAperso.FldPhoto.Field, null, ValCodperso);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PERSO]/

		#endregion
	}
}
