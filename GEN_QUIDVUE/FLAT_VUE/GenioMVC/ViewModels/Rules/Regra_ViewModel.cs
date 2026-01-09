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
	public class Regra_ViewModel : FormViewModel<Models.Rules>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => true; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys

		#endregion
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

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodregra { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
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

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FREGRA");
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

			NavigationContext Navigation = m_userContext.CurrentNavigation;
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]!="U" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="U"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE02451); // Message: "Falhou a condição de edição no form"
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
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE16866); // Message: "Falhou a condição de eliminação no form"
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
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE57428); // Message: "Falhou a condição de visualização no form"
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

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Rules model = Model;
			Models.Rules areaRules = model;
			try
			{
				// (REGRA form condition) [RULES->TIPOCOND]=="M"
				if (!isApply && (areaRules.klass.ValTipocond=="M")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioArules.FldDescript).isEmptyValue(ViewModelConversion.ToString(model.ValDescript)))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.E_OBRIGATORIO_PREENC03702); // Message: "É obrigatório preencher a descrição: Regra do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="E" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="E"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE23304); // Message: "Falhou a condição de escrita do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="W" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="W"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.W;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_VALIDACAO_D60313); // Message: "Falhou a validação do form sem apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]=="M" && [RULES->LOCAL]=="F"
				if ((areaRules.klass.ValTipocond=="M"&&areaRules.klass.ValLocal=="F")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioArules.FldDescript).isEmptyValue(ViewModelConversion.ToString(model.ValDescript)))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.E_OBRIGATORIO_PREENC62370); // Message: "É obrigatório preencher a descrição: Regra do form com apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="I" || [RULES->LOCAL]!="F"
				if (!isApply && !(areaRules.klass.ValTipocond!="I"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE23484); // Message: "Falhou a condição de inserção no form"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="W" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="W"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.W;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_VALIDACAO_D54728); // Message: "Falhou a validação do form com apply"
					result.MergeStatusMessage(message);
				}
				// (REGRA form condition) [RULES->TIPOCOND]!="E" || [RULES->LOCAL]!="F"
				if (!(areaRules.klass.ValTipocond!="E"||areaRules.klass.ValLocal!="F"))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_A_CONDICAO_DE06933); // Message: "Falhou a condição de escrita do form com apply"
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

		/// <inheritdoc />
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

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
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
				CSGenio.framework.Log.Error($"Map ViewModel (Regra) to Model (Rules) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "rules.tipocond":
						this.ValTipocond = ViewModelConversion.ToString(_value);
						break;
					case "rules.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "rules.local":
						this.ValLocal = ViewModelConversion.ToString(_value);
						break;
					case "rules.codregra":
						this.ValCodregra = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Regra) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Regra)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Rules.Find(id ?? Navigation.GetStrValue("rules"), m_userContext, "FREGRA"); }
			finally { Model ??= new Models.Rules(m_userContext) { Identifier = "FREGRA" }; }

			base.LoadModel();
		}

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
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FREGRA";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

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

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE REGRA]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGRA]/

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
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGRA]/

		#endregion
	}
}
