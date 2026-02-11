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

namespace GenioMVC.ViewModels.Rules
{
	public class Regra2_ViewModel : FormViewModel<Models.Rules>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Description" | Type: "CE"
		/// </summary>
		public string ValCodup_rules { get; set; }

		#endregion
		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Up_rules> TableUp_rulesDescript { get; set; }
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
		public Regra2_ViewModel() : base(null!) { }

		public Regra2_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FREGRA2", nestedForm) { }

		public Regra2_ViewModel(UserContext userContext, Models.Rules row, bool nestedForm = false) : base(userContext, "FREGRA2", row, nestedForm) { }

		public Regra2_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("rules", id);
			Model = Models.Rules.Find(id, userContext, "FREGRA2", fieldsToQuery: fieldsToLoad);
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
			Models.Rules model = new Models.Rules(userContext) { Identifier = "FREGRA2" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FREGRA2");
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

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
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
				CSGenio.framework.Log.Error("Map Model (Rules) to ViewModel (Regra2) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodup_rules = ViewModelConversion.ToString(m.ValCodup_rules);
				ValTipocond = ViewModelConversion.ToString(m.ValTipocond);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValLocal = ViewModelConversion.ToString(m.ValLocal);
				ValCodregra = ViewModelConversion.ToString(m.ValCodregra);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Rules) to ViewModel (Regra2) - Error during mapping");
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
				CSGenio.framework.Log.Error("Map ViewModel (Regra2) to Model (Rules) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodup_rules = ViewModelConversion.ToString(ValCodup_rules);
				m.ValTipocond = ViewModelConversion.ToString(ValTipocond);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValLocal = ViewModelConversion.ToString(ValLocal);
				m.ValCodregra = ViewModelConversion.ToString(ValCodregra);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Regra2) to Model (Rules) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "rules.codup_rules":
						this.ValCodup_rules = ViewModelConversion.ToString(_value);
						break;
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
						Log.Error($"SetViewModelValue (Regra2) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Regra2)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Rules.Find(id ?? Navigation.GetStrValue("rules"), m_userContext, "FREGRA2"); }
			finally { Model ??= new Models.Rules(m_userContext) { Identifier = "FREGRA2" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA2");
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

			Model.Identifier = "FREGRA2";
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
				Model = Models.Rules.Find(Navigation.GetStrValue("rules"), m_userContext, "FREGRA2");
				if (Model == null)
				{
					Model = new Models.Rules(m_userContext) { Identifier = "FREGRA2" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("rules");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Regra2__up_rules__descript(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGRA2]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGRA2]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE REGRA2]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGRA2]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGRA2]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGRA2]/
		public override void Destroy(string id)
		{
			Model = Models.Rules.Find(id, m_userContext, "FREGRA2");
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

		/// <summary>
		/// TableUp_rulesDescript -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Regra2__up_rules__descript(NameValueCollection qs, bool lazyLoad = false)
		{
			bool regra2__up_rules__descriptDoLoad = true;
			CriteriaSet regra2__up_rules__descriptConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("up_rules", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					regra2__up_rules__descriptConds.Equal(CSGenioAup_rules.FldCodup_rules, hValue);
					this.ValCodup_rules = DBConversion.ToString(hValue);
				}
			}

			TableUp_rulesDescript = new TableDBEdit<Models.Up_rules>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_up_rules") != null)
				{
					this.ValCodup_rules = Navigation.GetStrValue("RETURN_up_rules");
					Navigation.CurrentLevel.SetEntry("RETURN_up_rules", null);
				}
				FillDependant_Regra2TableUp_rulesDescript(lazyLoad);
				return;
			}

			if (regra2__up_rules__descriptDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableUp_rulesDescript, "sTableUp_rulesDescript", "dTableUp_rulesDescript", qs, "up_rules");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAup_rules.FldDescript), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableUp_rulesDescript_tableFilters"]))
					TableUp_rulesDescript.TableFilters = bool.Parse(qs["TableUp_rulesDescript_tableFilters"]);
				else
					TableUp_rulesDescript.TableFilters = false;

				query = qs["qTableUp_rulesDescript"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAup_rules.FldDescript, query + "%");
				}
				regra2__up_rules__descriptConds.SubSet(search_filters);

				string tryParsePage = qs["pTableUp_rulesDescript"] != null ? qs["pTableUp_rulesDescript"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAup_rules.FldCodup_rules, CSGenioAup_rules.FldDescript, CSGenioAup_rules.FldZzstate];

// USE /[MANUAL GQT OVERRQ REGRA2_UP_RULESDESCRIPT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("up_rules", FormMode.New) || Navigation.checkFormMode("up_rules", FormMode.Duplicate))
					regra2__up_rules__descriptConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAup_rules.FldZzstate, 0)
						.Equal(CSGenioAup_rules.FldCodup_rules, Navigation.GetStrValue("up_rules")));
				else
					regra2__up_rules__descriptConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAup_rules.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("up_rules", "descript");
				ListingMVC<CSGenioAup_rules> listing = Models.ModelBase.Where<CSGenioAup_rules>(m_userContext, false, regra2__up_rules__descriptConds, fields, offset, numberItems, sorts, "LED_REGRA2__UP_RULES__DESCRIPT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableUp_rulesDescript.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableUp_rulesDescript.Query = query;
				TableUp_rulesDescript.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Up_rules(m_userContext, r, true, _fieldsToSerialize_REGRA2__UP_RULES__DESCRIPT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_up_rules") != null)
				{
					this.ValCodup_rules = Navigation.GetStrValue("RETURN_up_rules");
					Navigation.CurrentLevel.SetEntry("RETURN_up_rules", null);
				}

				TableUp_rulesDescript.List = new SelectList(TableUp_rulesDescript.Elements.ToSelectList(x => x.ValDescript, x => x.ValCodup_rules,  x => x.ValCodup_rules == this.ValCodup_rules), "Value", "Text", this.ValCodup_rules);
				FillDependant_Regra2TableUp_rulesDescript();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableUp_rulesDescript (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Up_rules</param>
		public ConcurrentDictionary<string, object> GetDependant_Regra2TableUp_rulesDescript(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAup_rules.FldCodup_rules, CSGenioAup_rules.FldDescript];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAup_rules tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAup_rules.FldCodup_rules, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableUp_rulesDescript (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Regra2TableUp_rulesDescript(bool lazyLoad = false)
		{
			var row = GetDependant_Regra2TableUp_rulesDescript(this.ValCodup_rules);
			try
			{

				// Fill List fields
				this.ValCodup_rules = ViewModelConversion.ToString(row["up_rules.codup_rules"]);
				TableUp_rulesDescript.Value = (string)row["up_rules.descript"];
				if (GenFunctions.emptyG(this.ValCodup_rules) == 1)
				{
					this.ValCodup_rules = "";
					TableUp_rulesDescript.Value = "";
					Navigation.ClearValue("up_rules");
				}
				else if (lazyLoad)
				{
					TableUp_rulesDescript.SetPagination(1, 0, false, false, 1);
					TableUp_rulesDescript.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodup_rules),
							Text = Convert.ToString(TableUp_rulesDescript.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodup_rules);
				}

				TableUp_rulesDescript.Selected = this.ValCodup_rules;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableUp_rulesDescript): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_REGRA2__UP_RULES__DESCRIPT = ["Up_rules", "Up_rules.ValCodup_rules", "Up_rules.ValZzstate", "Up_rules.ValDescript", "Up_rules.ValLocal", "Up_rules.ValAllow_all"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"rules.codup_rules" => ViewModelConversion.ToString(modelValue),
				"rules.tipocond" => ViewModelConversion.ToString(modelValue),
				"rules.descript" => ViewModelConversion.ToString(modelValue),
				"rules.local" => ViewModelConversion.ToString(modelValue),
				"rules.codregra" => ViewModelConversion.ToString(modelValue),
				"up_rules.codup_rules" => ViewModelConversion.ToString(modelValue),
				"up_rules.descript" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGRA2]/

		#endregion
	}
}
