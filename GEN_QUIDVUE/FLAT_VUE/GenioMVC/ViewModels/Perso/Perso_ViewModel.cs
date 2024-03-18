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
	public class Perso_ViewModel : FormViewModel<Models.Perso>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 115)]
		public GenioMVC.ViewModels.ImageModel ValPhoto { get; set; }

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
		public double ValMonth { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValMonth { get; set; }

		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		public string ValCreatusr { get; set; }

		/// <summary>
		/// Title: "Created on" | Type: "OD"
		/// </summary>
		public DateTime? ValCreatdat { get; set; }

		/// <summary>
		/// Title: "Modified by" | Type: "EN"
		/// </summary>
		public string ValModifusr { get; set; }

		/// <summary>
		/// Title: "Modified on" | Type: "ED"
		/// </summary>
		public DateTime? ValModifdat { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodperso { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
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
			Models.Perso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

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
				ValMonth = ViewModelConversion.ToDouble(m.ValMonth);
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

		public override void MapToModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Perso) to Model (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValDob = ViewModelConversion.ToDateTime(ValDob);
				m.ValTob = ViewModelConversion.ToString(ValTob);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValMonth = ViewModelConversion.ToDouble(ValMonth);
				m.ValCreatusr = ViewModelConversion.ToString(ValCreatusr);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValModifusr = ViewModelConversion.ToString(ValModifusr);
				m.ValModifdat = ViewModelConversion.ToDateTime(ValModifdat);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Perso) to Model (Perso) - Error during mapping");
				throw;
			}
		}

		#endregion


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
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FPERSO";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
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

// USE /[MANUAL GQT VIEWMODEL_SAVE PERSO]/
		public override void Save()
		{

			try { Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPERSO"); }
			finally { if (Model == null) Model = new Models.Perso(m_userContext) { Identifier = "FPERSO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PERSO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Perso.Find(Navigation.GetStrValue("perso"), m_userContext, "FPERSO"); }
			finally { if (Model == null) Model = new Models.Perso(m_userContext) { Identifier = "FPERSO" }; }

			base.Apply();
		}

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
				"perso.month" => ViewModelConversion.ToDouble(modelValue),
				"perso.creatusr" => ViewModelConversion.ToString(modelValue),
				"perso.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"perso.modifusr" => ViewModelConversion.ToString(modelValue),
				"perso.modifdat" => ViewModelConversion.ToDateTime(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PERSO]/

		#endregion
	}
}
