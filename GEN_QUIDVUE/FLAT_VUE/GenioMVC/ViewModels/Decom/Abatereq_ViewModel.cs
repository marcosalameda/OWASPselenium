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

namespace GenioMVC.ViewModels.Decom
{
	public class Abatereq_ViewModel : FormViewModel<Models.Decom>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Number" | Type: "N"
		/// </summary>
		public decimal? ValDecomnr { get; set; }

		/// <summary>
		/// Title: "Notes" | Type: "MO"
		/// </summary>
		public string ValNote { get; set; }

		/// <summary>
		/// Title: "Decomission" | Type: "DT"
		/// </summary>
		public DateTime? ValDtdeco { get; set; }

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

		public string ValCoddeco { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Abatereq_ViewModel() : base(null!) { }

		public Abatereq_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FABATEREQ", nestedForm) { }

		public Abatereq_ViewModel(UserContext userContext, Models.Decom row, bool nestedForm = false) : base(userContext, "FABATEREQ", row, nestedForm) { }

		public Abatereq_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("decom", id);
			Model = Models.Decom.Find(id, userContext, "FABATEREQ", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Decom model = new Models.Decom(userContext) { Identifier = "FABATEREQ" };
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
			Models.Decom model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abatereq) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDecomnr = ViewModelConversion.ToNumeric(m.ValDecomnr);
				ValNote = ViewModelConversion.ToString(m.ValNote);
				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abatereq) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Abatereq) to Model (Decom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDecomnr = ViewModelConversion.ToNumeric(ValDecomnr);
				m.ValNote = ViewModelConversion.ToString(ValNote);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Abatereq) to Model (Decom) - Error during mapping");
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
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ");
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

			Model.Identifier = "FABATEREQ";
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

		protected override void LoadDocumentsProperties(Models.Decom row)
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
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ");
				if (Model == null)
				{
					Model = new Models.Decom(m_userContext) { Identifier = "FABATEREQ" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("decom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ABATEREQ]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ABATEREQ]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValDecomnr", Resources.Resources.NUMBER35625, ValDecomnr);
			validator.Required("ValNote", Resources.Resources.NOTES05274, ValNote);
			validator.Required("ValDtdeco", Resources.Resources.DECOMISSION14486, ValDtdeco);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ABATEREQ]/
		public override void Save()
		{

			try { Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ"); }
			finally { if (Model == null) Model = new Models.Decom(m_userContext) { Identifier = "FABATEREQ" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ABATEREQ]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Decom.Find(Navigation.GetStrValue("decom"), m_userContext, "FABATEREQ"); }
			finally { if (Model == null) Model = new Models.Decom(m_userContext) { Identifier = "FABATEREQ" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ABATEREQ]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ABATEREQ]/
		public override void Destroy(string id)
		{
			Model = Models.Decom.Find(id, m_userContext, "FABATEREQ");
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
				"decom.decomnr" => ViewModelConversion.ToNumeric(modelValue),
				"decom.note" => ViewModelConversion.ToString(modelValue),
				"decom.dtdeco" => ViewModelConversion.ToDateTime(modelValue),
				"decom.coddeco" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ABATEREQ]/

		#endregion
	}
}
