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

namespace GenioMVC.ViewModels.Wareh
{
	public class Armazpop_ViewModel : FormViewModel<Models.Wareh>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Code:" | Type: "C"
		/// </summary>
		public string ValWarehcod { get; set; }

		/// <summary>
		/// Title: "Activity:" | Type: "AL"
		/// </summary>
		public int ValActivity { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValActivity { get; set; }

		/// <summary>
		/// Title: "Warehouse:" | Type: "C"
		/// </summary>
		public string ValWarehdes { get; set; }

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

		public string ValCodwareh { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Armazpop_ViewModel() : base(null!) { }

		public Armazpop_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FARMAZPOP", nestedForm) { }

		public Armazpop_ViewModel(UserContext userContext, Models.Wareh row, bool nestedForm = false) : base(userContext, "FARMAZPOP", row, nestedForm) { }

		public Armazpop_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("wareh", id);
			Model = Models.Wareh.Find(id, userContext, "FARMAZPOP", fieldsToQuery: fieldsToLoad);
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
			Models.Wareh model = new Models.Wareh(userContext) { Identifier = "FARMAZPOP" };
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
			Models.Wareh model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Wareh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Wareh) to ViewModel (Armazpop) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValWarehcod = ViewModelConversion.ToString(m.ValWarehcod);
				ValActivity = ViewModelConversion.ToInteger(m.ValActivity);
				ValWarehdes = ViewModelConversion.ToString(m.ValWarehdes);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Wareh) to ViewModel (Armazpop) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Wareh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Armazpop) to Model (Wareh) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValWarehcod = ViewModelConversion.ToString(ValWarehcod);
				m.ValActivity = ViewModelConversion.ToInteger(ValActivity);
				m.ValWarehdes = ViewModelConversion.ToString(ValWarehdes);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Armazpop) to Model (Wareh) - Error during mapping");
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
				Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), m_userContext, "FARMAZPOP");
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

			Model.Identifier = "FARMAZPOP";
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

		protected override void LoadDocumentsProperties(Models.Wareh row)
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
				Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), m_userContext, "FARMAZPOP");
				if (Model == null)
				{
					Model = new Models.Wareh(m_userContext) { Identifier = "FARMAZPOP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARMAZPOP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARMAZPOP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValWarehcod", Resources.Resources.CODE_49120, ValWarehcod, 10);
			validator.StringLength("ValWarehdes", Resources.Resources.WAREHOUSE_33475, ValWarehdes, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ARMAZPOP]/
		public override void Save()
		{

			try { Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), m_userContext, "FARMAZPOP"); }
			finally { if (Model == null) Model = new Models.Wareh(m_userContext) { Identifier = "FARMAZPOP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARMAZPOP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), m_userContext, "FARMAZPOP"); }
			finally { if (Model == null) Model = new Models.Wareh(m_userContext) { Identifier = "FARMAZPOP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARMAZPOP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARMAZPOP]/
		public override void Destroy(string id)
		{
			Model = Models.Wareh.Find(id, m_userContext, "FARMAZPOP");
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
				"wareh.warehcod" => ViewModelConversion.ToString(modelValue),
				"wareh.activity" => ViewModelConversion.ToInteger(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARMAZPOP]/

		#endregion
	}
}
