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

namespace GenioMVC.ViewModels.Cntry
{
	public class Proppais_ViewModel : FormViewModel<Models.Cntry>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Designation:" | Type: "C"
		/// </summary>
		public string ValCountry { get; set; }

		/// <summary>
		/// Title: "Active" | Type: "L"
		/// </summary>
		public bool ValActive { get; set; }

		/// <summary>
		/// Title: "Numeric" | Type: "C"
		/// </summary>
		public string ValCodigonr { get; set; }

		/// <summary>
		/// Title: "Alphabetic 2:" | Type: "C"
		/// </summary>
		public string ValAlfa2 { get; set; }

		/// <summary>
		/// Title: "Alphabetic 3:" | Type: "C"
		/// </summary>
		public string ValAlfa3 { get; set; }

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

		public string ValCodcntry { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Proppais_ViewModel() : base(null!) { }

		public Proppais_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPROPPAIS", nestedForm) { }

		public Proppais_ViewModel(UserContext userContext, Models.Cntry row, bool nestedForm = false) : base(userContext, "FPROPPAIS", row, nestedForm) { }

		public Proppais_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("cntry", id);
			Model = Models.Cntry.Find(id, userContext, "FPROPPAIS", fieldsToQuery: fieldsToLoad);
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
			Models.Cntry model = new Models.Cntry(userContext) { Identifier = "FPROPPAIS" };
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
			Models.Cntry model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cntry m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cntry) to ViewModel (Proppais) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCountry = ViewModelConversion.ToString(m.ValCountry);
				ValActive = ViewModelConversion.ToLogic(m.ValActive);
				ValCodigonr = ViewModelConversion.ToString(m.ValCodigonr);
				ValAlfa2 = ViewModelConversion.ToString(m.ValAlfa2);
				ValAlfa3 = ViewModelConversion.ToString(m.ValAlfa3);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cntry) to ViewModel (Proppais) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cntry m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proppais) to Model (Cntry) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCountry = ViewModelConversion.ToString(ValCountry);
				m.ValActive = ViewModelConversion.ToLogic(ValActive);
				m.ValCodigonr = ViewModelConversion.ToString(ValCodigonr);
				m.ValAlfa2 = ViewModelConversion.ToString(ValAlfa2);
				m.ValAlfa3 = ViewModelConversion.ToString(ValAlfa3);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proppais) to Model (Cntry) - Error during mapping");
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
				Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), m_userContext, "FPROPPAIS");
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

			Model.Identifier = "FPROPPAIS";
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

		protected override void LoadDocumentsProperties(Models.Cntry row)
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
				Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), m_userContext, "FPROPPAIS");
				if (Model == null)
				{
					Model = new Models.Cntry(m_userContext) { Identifier = "FPROPPAIS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROPPAIS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROPPAIS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValCountry", Resources.Resources.DESIGNATION_35800, ValCountry, 90);
			validator.StringLength("ValCodigonr", Resources.Resources.NUMERIC19292, ValCodigonr, 3);
			validator.StringLength("ValAlfa2", Resources.Resources.ALPHABETIC_2_16300, ValAlfa2, 2);
			validator.StringLength("ValAlfa3", Resources.Resources.ALPHABETIC_3_29295, ValAlfa3, 3);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PROPPAIS]/
		public override void Save()
		{

			try { Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), m_userContext, "FPROPPAIS"); }
			finally { if (Model == null) Model = new Models.Cntry(m_userContext) { Identifier = "FPROPPAIS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROPPAIS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), m_userContext, "FPROPPAIS"); }
			finally { if (Model == null) Model = new Models.Cntry(m_userContext) { Identifier = "FPROPPAIS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROPPAIS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROPPAIS]/
		public override void Destroy(string id)
		{
			Model = Models.Cntry.Find(id, m_userContext, "FPROPPAIS");
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
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"cntry.active" => ViewModelConversion.ToLogic(modelValue),
				"cntry.codigonr" => ViewModelConversion.ToString(modelValue),
				"cntry.alfa2" => ViewModelConversion.ToString(modelValue),
				"cntry.alfa3" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPPAIS]/

		#endregion
	}
}
