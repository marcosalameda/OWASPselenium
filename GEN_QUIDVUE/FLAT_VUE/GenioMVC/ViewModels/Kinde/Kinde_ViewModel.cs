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

namespace GenioMVC.ViewModels.Kinde
{
	public class Kinde_ViewModel : FormViewModel<Models.Kinde>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Kind of equipment" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }

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

		public string ValCodkinde { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Kinde_ViewModel() : base(null!) { }

		public Kinde_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FKINDE", nestedForm) { }

		public Kinde_ViewModel(UserContext userContext, Models.Kinde row, bool nestedForm = false) : base(userContext, "FKINDE", row, nestedForm) { }

		public Kinde_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("kinde", id);
			Model = Models.Kinde.Find(id, userContext, "FKINDE", fieldsToQuery: fieldsToLoad);
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
			Models.Kinde model = new Models.Kinde(userContext) { Identifier = "FKINDE" };
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
			Models.Kinde model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Kinde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Kinde) to ViewModel (Kinde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Kinde) to ViewModel (Kinde) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Kinde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Kinde) to Model (Kinde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Kinde) to Model (Kinde) - Error during mapping");
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
				Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), m_userContext, "FKINDE");
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

			Model.Identifier = "FKINDE";
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

		protected override void LoadDocumentsProperties(Models.Kinde row)
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
				Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), m_userContext, "FKINDE");
				if (Model == null)
				{
					Model = new Models.Kinde(m_userContext) { Identifier = "FKINDE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("kinde");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL KINDE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW KINDE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValDesignat", Resources.Resources.KIND_OF_EQUIPMENT22928, ValDesignat, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE KINDE]/
		public override void Save()
		{

			try { Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), m_userContext, "FKINDE"); }
			finally { if (Model == null) Model = new Models.Kinde(m_userContext) { Identifier = "FKINDE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY KINDE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), m_userContext, "FKINDE"); }
			finally { if (Model == null) Model = new Models.Kinde(m_userContext) { Identifier = "FKINDE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE KINDE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY KINDE]/
		public override void Destroy(string id)
		{
			Model = Models.Kinde.Find(id, m_userContext, "FKINDE");
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
				"kinde.designat" => ViewModelConversion.ToString(modelValue),
				"kinde.codkinde" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM KINDE]/

		#endregion
	}
}
