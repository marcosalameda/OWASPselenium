using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Up_rules
{
	public class Up_rules_ViewModel : FormViewModel<Models.Up_rules>, IPreparableForSerialization
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
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescript { get; set; }
		/// <summary>
		/// Title: "Place where you run" | Type: "AC"
		/// </summary>
		public string ValLocal { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValLocal { get; set; }
		/// <summary>
		/// Title: "Allow all" | Type: "L"
		/// </summary>
		public bool ValAllow_all { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodup_rules { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Up_rules_ViewModel() : base(null!) { }

		public Up_rules_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FUP_RULES", nestedForm) { }

		public Up_rules_ViewModel(UserContext userContext, Models.Up_rules row, bool nestedForm = false) : base(userContext, "FUP_RULES", row, nestedForm) { }

		public Up_rules_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("up_rules", id);
			Model = Models.Up_rules.Find(id, userContext, "FUP_RULES", fieldsToQuery: fieldsToLoad);
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
			Models.Up_rules model = new Models.Up_rules(userContext) { Identifier = "FUP_RULES" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FUP_RULES");
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
			Models.Up_rules areaUp_rules = model;
			try
			{
				// (UP_RULES form condition) [UP_RULES->DESCRIPT]!="UPDATE" || [UP_RULES->LOCAL]!="F" || [UP_RULES->ALLOW_ALL] == 1 || HasRole("99")
				if (!(areaUp_rules.klass.ValDescript!="UPDATE"||areaUp_rules.klass.ValLocal!="F"||areaUp_rules.klass.ValAllow_all==1||CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"99")))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_CONDICAO_DE_E17481); // Message: "Falhou condição de edição na tabela"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FUP_RULES access condition: {exc.Message}");
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

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			Models.Up_rules areaUp_rules = model;
			try
			{
				// (UP_RULES form condition) [UP_RULES->DESCRIPT]!="VIEW" || [UP_RULES->LOCAL]!="F" || [UP_RULES->ALLOW_ALL] == 1
				if (!(areaUp_rules.klass.ValDescript!="VIEW"||areaUp_rules.klass.ValLocal!="F"||areaUp_rules.klass.ValAllow_all==1))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.FALHOU_CONDICAO_DE_V12527); // Message: "Falhou condição de visualização na tabela"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FUP_RULES access condition: {exc.Message}");
				throw;
			}
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Up_rules model = Model;
			Models.Up_rules areaUp_rules = model;
			try
			{
				// (UP_RULES form condition) [UP_RULES->DESCRIPT]!="WARN" || [UP_RULES->LOCAL]!="F" || [UP_RULES->ALLOW_ALL] == 1
				if (!isApply && !(areaUp_rules.klass.ValDescript!="WARN"||areaUp_rules.klass.ValLocal!="F"||areaUp_rules.klass.ValAllow_all==1))
				{
					var status = Status.W;
					StatusMessage message = new(status, Resources.Resources.A_VALIDACAO_DA_TABEL53583); // Message: "A validação da tabela deu um warning"
					result.MergeStatusMessage(message);
				}
				// (UP_RULES form condition) [UP_RULES->DESCRIPT]!="WRITE" || [UP_RULES->LOCAL]!="T" || [UP_RULES->ALLOW_ALL] == 1
				if (!isApply && !(areaUp_rules.klass.ValDescript!="WRITE"||areaUp_rules.klass.ValLocal!="T"||areaUp_rules.klass.ValAllow_all==1))
				{
					var status = Status.E;
					StatusMessage message = new(status, Resources.Resources.A_CONDICAO_DE_ESCRIT21929); // Message: "A condição de escrita da tabela não está a ser cumprida"
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FUP_RULES access condition: {exc.Message}");
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
		public override void MapFromModel(Models.Up_rules m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Up_rules) to ViewModel (Up_rules) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValLocal = ViewModelConversion.ToString(m.ValLocal);
				ValAllow_all = ViewModelConversion.ToLogic(m.ValAllow_all);
				ValCodup_rules = ViewModelConversion.ToString(m.ValCodup_rules);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Up_rules) to ViewModel (Up_rules) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Up_rules m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Up_rules) to Model (Up_rules) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValLocal = ViewModelConversion.ToString(ValLocal);
				m.ValAllow_all = ViewModelConversion.ToLogic(ValAllow_all);
				m.ValCodup_rules = ViewModelConversion.ToString(ValCodup_rules);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Up_rules) to Model (Up_rules) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "up_rules.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "up_rules.local":
						this.ValLocal = ViewModelConversion.ToString(_value);
						break;
					case "up_rules.allow_all":
						this.ValAllow_all = ViewModelConversion.ToLogic(_value);
						break;
					case "up_rules.codup_rules":
						this.ValCodup_rules = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Up_rules) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Up_rules)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Up_rules.Find(id ?? Navigation.GetStrValue("up_rules"), m_userContext, "FUP_RULES"); }
			finally { Model ??= new Models.Up_rules(m_userContext) { Identifier = "FUP_RULES" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Up_rules.Find(Navigation.GetStrValue("up_rules"), m_userContext, "FUP_RULES");
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

			Model.Identifier = "FUP_RULES";
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

		protected override void LoadDocumentsProperties(Models.Up_rules row)
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
				Model = Models.Up_rules.Find(Navigation.GetStrValue("up_rules"), m_userContext, "FUP_RULES");
				if (Model == null)
				{
					Model = new Models.Up_rules(m_userContext) { Identifier = "FUP_RULES" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("up_rules");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL UP_RULES]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW UP_RULES]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValDescript", Resources.Resources.DESCRIPTION07383, ValDescript, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE UP_RULES]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY UP_RULES]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE UP_RULES]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY UP_RULES]/
		public override void Destroy(string id)
		{
			Model = Models.Up_rules.Find(id, m_userContext, "FUP_RULES");
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
				"up_rules.descript" => ViewModelConversion.ToString(modelValue),
				"up_rules.local" => ViewModelConversion.ToString(modelValue),
				"up_rules.allow_all" => ViewModelConversion.ToLogic(modelValue),
				"up_rules.codup_rules" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM UP_RULES]/

		#endregion
	}
}
