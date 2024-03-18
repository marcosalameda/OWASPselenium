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

namespace GenioMVC.ViewModels.Year
{
	public class Ano_ViewModel : FormViewModel<Models.Year>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Year" | Type: "C"
		/// </summary>
		public string ValYear { get; set; }

		/// <summary>
		/// Title: "Year (numbers)" | Type: "N"
		/// </summary>
		public decimal? ValYearnum { get; set; }

		/// <summary>
		/// Title: "Value" | Type: "$D"
		/// </summary>
		public decimal? ValValue { get; set; }

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

		public string ValCodyear { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Ano_ViewModel() : base(null!) { }

		public Ano_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FANO", nestedForm) { }

		public Ano_ViewModel(UserContext userContext, Models.Year row, bool nestedForm = false) : base(userContext, "FANO", row, nestedForm) { }

		public Ano_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("year", id);
			Model = Models.Year.Find(id, userContext, "FANO", fieldsToQuery: fieldsToLoad);
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
			Models.Year model = new Models.Year(userContext) { Identifier = "FANO" };
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
			Models.Year model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Year m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Year) to ViewModel (Ano) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValYear = ViewModelConversion.ToString(m.ValYear);
				ValYearnum = ViewModelConversion.ToNumeric(m.ValYearnum);
				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Year) to ViewModel (Ano) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Year m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ano) to Model (Year) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValYear = ViewModelConversion.ToString(ValYear);
				m.ValYearnum = ViewModelConversion.ToNumeric(ValYearnum);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ano) to Model (Year) - Error during mapping");
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
				Model = Models.Year.Find(Navigation.GetStrValue("year"), m_userContext, "FANO");
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

			Model.Identifier = "FANO";
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

		protected override void LoadDocumentsProperties(Models.Year row)
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
				Model = Models.Year.Find(Navigation.GetStrValue("year"), m_userContext, "FANO");
				if (Model == null)
				{
					Model = new Models.Year(m_userContext) { Identifier = "FANO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("year");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ANO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ANO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValYear", Resources.Resources.YEAR61794, ValYear, 4);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ANO]/
		public override void Save()
		{

			try { Model = Models.Year.Find(Navigation.GetStrValue("year"), m_userContext, "FANO"); }
			finally { if (Model == null) Model = new Models.Year(m_userContext) { Identifier = "FANO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ANO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Year.Find(Navigation.GetStrValue("year"), m_userContext, "FANO"); }
			finally { if (Model == null) Model = new Models.Year(m_userContext) { Identifier = "FANO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ANO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ANO]/
		public override void Destroy(string id)
		{
			Model = Models.Year.Find(id, m_userContext, "FANO");
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
				"year.year" => ViewModelConversion.ToString(modelValue),
				"year.yearnum" => ViewModelConversion.ToNumeric(modelValue),
				"year.value" => ViewModelConversion.ToNumeric(modelValue),
				"year.codyear" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ANO]/

		#endregion
	}
}
