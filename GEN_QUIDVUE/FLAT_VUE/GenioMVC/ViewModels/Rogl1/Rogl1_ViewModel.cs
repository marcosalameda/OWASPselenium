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

namespace GenioMVC.ViewModels.Rogl1
{
	public class Rogl1_ViewModel : FormViewModel<Models.Rogl1>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }

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

		public string ValCodrogl1 { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Rogl1_ViewModel() : base(null!) { }

		public Rogl1_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FROGL1", nestedForm) { }

		public Rogl1_ViewModel(UserContext userContext, Models.Rogl1 row, bool nestedForm = false) : base(userContext, "FROGL1", row, nestedForm) { }

		public Rogl1_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("rogl1", id);
			Model = Models.Rogl1.Find(id, userContext, "FROGL1", fieldsToQuery: fieldsToLoad);
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
			Models.Rogl1 model = new Models.Rogl1(userContext) { Identifier = "FROGL1" };
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
			Models.Rogl1 model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Rogl1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Rogl1) to ViewModel (Rogl1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValCodrogl1 = ViewModelConversion.ToString(m.ValCodrogl1);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Rogl1) to ViewModel (Rogl1) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Rogl1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Rogl1) to Model (Rogl1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValCodrogl1 = ViewModelConversion.ToString(ValCodrogl1);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Rogl1) to Model (Rogl1) - Error during mapping");
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
				Model = Models.Rogl1.Find(Navigation.GetStrValue("rogl1"), m_userContext, "FROGL1");
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

			Model.Identifier = "FROGL1";
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

		protected override void LoadDocumentsProperties(Models.Rogl1 row)
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
				Model = Models.Rogl1.Find(Navigation.GetStrValue("rogl1"), m_userContext, "FROGL1");
				if (Model == null)
				{
					Model = new Models.Rogl1(m_userContext) { Identifier = "FROGL1" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("rogl1");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ROGL1]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ROGL1]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ROGL1]/
		public override void Save()
		{

			try { Model = Models.Rogl1.Find(Navigation.GetStrValue("rogl1"), m_userContext, "FROGL1"); }
			finally { if (Model == null) Model = new Models.Rogl1(m_userContext) { Identifier = "FROGL1" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ROGL1]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Rogl1.Find(Navigation.GetStrValue("rogl1"), m_userContext, "FROGL1"); }
			finally { if (Model == null) Model = new Models.Rogl1(m_userContext) { Identifier = "FROGL1" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ROGL1]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ROGL1]/
		public override void Destroy(string id)
		{
			Model = Models.Rogl1.Find(id, m_userContext, "FROGL1");
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
				"rogl1.title" => ViewModelConversion.ToString(modelValue),
				"rogl1.codrogl1" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ROGL1]/

		#endregion
	}
}
