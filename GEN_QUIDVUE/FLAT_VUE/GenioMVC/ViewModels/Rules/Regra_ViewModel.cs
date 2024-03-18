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

namespace GenioMVC.ViewModels.Rules
{
	public class Regra_ViewModel : FormViewModel<Models.Rules>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => true; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Condition type" | Type: "AC"
		/// </summary>
		public string ValTipocond { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValTipocond { get; set; }

		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescript { get; set; }

		/// <summary>
		/// Title: "Local onde executa" | Type: "AC"
		/// </summary>
		public string ValLocal { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValLocal { get; set; }

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

		public string ValCodregra { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Regra_ViewModel() : base(null!) { }

		public Regra_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FREGRA", nestedForm) { }

		public Regra_ViewModel(UserContext userContext, Models.Rules row, bool nestedForm = false) : base(userContext, "FREGRA", row, nestedForm) { }

		public Regra_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("rules", id);
			Model = Models.Rules.Find(id, userContext, "FREGRA", fieldsToQuery: fieldsToLoad);
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
			Models.Rules model = new Models.Rules(userContext) { Identifier = "FREGRA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			NavigationContext Navigation = m_userContext.CurrentNavigation;
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]!="U" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="U"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE02451); // Message: "Falhou a condição de edição no form"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FREGRA access condition: {exc.Message}");
				throw;
			}
			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			NavigationContext Navigation = m_userContext.CurrentNavigation;
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]!="D" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="D"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE16866); // Message: "Falhou a condição de eliminação no form"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FREGRA access condition: {exc.Message}");
				throw;
			}
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]!="V" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="V"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE57428); // Message: "Falhou a condição de visualização no form"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FREGRA access condition: {exc.Message}");
				throw;
			}
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Rules model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]=="M"
				if (!isApply && (areaRules.klass.ValTipocond=="M")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioArules.FldDescript).isEmptyValue(model.ValDescript))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.E_OBRIGATORIO_PREENC03702); // Message: "É obrigatório preencher a descrição: Regra do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="E" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="E"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE23304); // Message: "Falhou a condição de escrita do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="W" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="W"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.W;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_VALIDACAO_D60313); // Message: "Falhou a validação do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]=="M" && [RULES->LOCAL]=="F"
				if ((areaRules.klass.ValTipocond=="M"&&areaRules.klass.ValLocal=="F")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioArules.FldDescript).isEmptyValue(model.ValDescript))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.E_OBRIGATORIO_PREENC62370); // Message: "É obrigatório preencher a descrição: Regra do form com apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="I" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="I"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE23484); // Message: "Falhou a condição de inserção no form"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="W" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="W"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.W;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_VALIDACAO_D54728); // Message: "Falhou a validação do form com apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="E" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="E"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					var message = new StatusMessage(status, Resources.Resources.FALHOU_A_CONDICAO_DE06933); // Message: "Falhou a condição de escrita do form com apply"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FREGRA access condition: {exc.Message}");
				throw;
			}
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Rules m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Rules) to ViewModel (Regra) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValTipocond = ViewModelConversion.ToString(m.ValTipocond);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValLocal = ViewModelConversion.ToString(m.ValLocal);
				ValCodregra = ViewModelConversion.ToString(m.ValCodregra);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Rules) to ViewModel (Regra) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Rules m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regra) to Model (Rules) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTipocond = ViewModelConversion.ToString(ValTipocond);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValLocal = ViewModelConversion.ToString(ValLocal);
				m.ValCodregra = ViewModelConversion.ToString(ValCodregra);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regra) to Model (Rules) - Error during mapping");
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
				Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA");
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

			Model.Identifier = "FREGRA";
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

		protected override void LoadDocumentsProperties(Models.Rules row)
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
				Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA");
				if (Model == null)
				{
					Model = new Models.Rules(m_userContext) { Identifier = "FREGRA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("rules");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGRA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGRA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValDescript", Resources.Resources.DESCRIPTION07383, ValDescript, 100);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REGRA]/
		public override void Save()
		{

			try { Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA"); }
			finally { if (Model == null) Model = new Models.Rules(m_userContext) { Identifier = "FREGRA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGRA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA"); }
			finally { if (Model == null) Model = new Models.Rules(m_userContext) { Identifier = "FREGRA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGRA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGRA]/
		public override void Destroy(string id)
		{
			Model = Models.Rules.Find(id, m_userContext, "FREGRA");
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
				"rules.tipocond" => ViewModelConversion.ToString(modelValue),
				"rules.descript" => ViewModelConversion.ToString(modelValue),
				"rules.local" => ViewModelConversion.ToString(modelValue),
				"rules.codregra" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGRA]/

		#endregion
	}
}
