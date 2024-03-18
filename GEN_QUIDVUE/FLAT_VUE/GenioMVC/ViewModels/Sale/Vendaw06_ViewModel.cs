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

namespace GenioMVC.ViewModels.Sale
{
	public class Vendaw06_ViewModel : FormViewModel<Models.Sale>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Overcoming objections" | Type: "DT"
		/// </summary>
		public DateTime? ValDtsupera { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodorgan { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Identification of business opportunity" Tipo: "C"</summary>
		public string ValIdentifi { get; set; }
		// Field for formula
		/// <summary>Field: "Presentation" Tipo: "L"</summary>
		public bool ValApresent { get; set; }

		#endregion

		public string ValCodvenda { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Vendaw06_ViewModel() : base(null!) { }

		public Vendaw06_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FVENDAW06", nestedForm) { }

		public Vendaw06_ViewModel(UserContext userContext, Models.Sale row, bool nestedForm = false) : base(userContext, "FVENDAW06", row, nestedForm) { }

		public Vendaw06_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("sale", id);
			Model = Models.Sale.Find(id, userContext, "FVENDAW06", fieldsToQuery: fieldsToLoad);
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
			Models.Sale model = new Models.Sale(userContext) { Identifier = "FVENDAW06" };
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
			Models.Sale model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw06) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDtsupera = ViewModelConversion.ToDateTime(m.ValDtsupera);
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
				ValApresent = ViewModelConversion.ToLogic(m.ValApresent);
				ValCodvenda = ViewModelConversion.ToString(m.ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw06) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Vendaw06) to Model (Sale) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDtsupera = ViewModelConversion.ToDateTime(ValDtsupera);
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValApresent = ViewModelConversion.ToLogic(ValApresent);
				m.ValCodvenda = ViewModelConversion.ToString(ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Vendaw06) to Model (Sale) - Error during mapping");
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW06");
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

			Model.Identifier = "FVENDAW06";
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

		protected override void LoadDocumentsProperties(Models.Sale row)
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW06");
				if (Model == null)
				{
					Model = new Models.Sale(m_userContext) { Identifier = "FVENDAW06" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VENDAW06]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VENDAW06]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE VENDAW06]/
		public override void Save()
		{

			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW06"); }
			finally { if (Model == null) Model = new Models.Sale(m_userContext) { Identifier = "FVENDAW06" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VENDAW06]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW06"); }
			finally { if (Model == null) Model = new Models.Sale(m_userContext) { Identifier = "FVENDAW06" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VENDAW06]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VENDAW06]/
		public override void Destroy(string id)
		{
			Model = Models.Sale.Find(id, m_userContext, "FVENDAW06");
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
				"sale.dtsupera" => ViewModelConversion.ToDateTime(modelValue),
				"sale.codorgan" => ViewModelConversion.ToString(modelValue),
				"sale.identifi" => ViewModelConversion.ToString(modelValue),
				"sale.apresent" => ViewModelConversion.ToLogic(modelValue),
				"sale.codvenda" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM VENDAW06]/

		#endregion
	}
}
