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

namespace GenioMVC.ViewModels.Operacoes
{
	public class Operacoes_ViewModel : FormViewModel<Models.Operacoes>, IPreparableForSerialization
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
		/// Title: "Entidade" | Type: "CE"
		/// </summary>
		public string ValCodentidade { get; set; }

		#endregion
		/// <summary>
		/// Title: "Entidade" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Entidade> TableEntidadeEntidade { get; set; }
		/// <summary>
		/// Title: "Operação AA" | Type: "C"
		/// </summary>
		public string ValOperacao_aa { get; set; }
		/// <summary>
		/// Title: "Pop abrangida" | Type: "N"
		/// </summary>
		public decimal? ValPop_aa { get; set; }
		/// <summary>
		/// Title: "Sobreposição AA" | Type: "L"
		/// </summary>
		public bool ValSobreposicao_aa { get; set; }
		/// <summary>
		/// Title: "Operação AR" | Type: "C"
		/// </summary>
		public string ValOperacao_ar { get; set; }
		/// <summary>
		/// Title: "Pop abrangida" | Type: "N"
		/// </summary>
		public decimal? ValPop_ar { get; set; }
		/// <summary>
		/// Title: "Sobreposição AR" | Type: "L"
		/// </summary>
		public bool ValSobreposicao_ar { get; set; }
		/// <summary>
		/// Title: "Operação RU" | Type: "C"
		/// </summary>
		public string ValOperacao_ru { get; set; }
		/// <summary>
		/// Title: "Pop abrangida" | Type: "N"
		/// </summary>
		public decimal? ValPop_ru { get; set; }
		/// <summary>
		/// Title: "Sobreposição RU" | Type: "L"
		/// </summary>
		public bool ValSobreposicao_ru { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodoperacoes { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Operacoes_ViewModel() : base(null!) { }

		public Operacoes_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FOPERACOES", nestedForm) { }

		public Operacoes_ViewModel(UserContext userContext, Models.Operacoes row, bool nestedForm = false) : base(userContext, "FOPERACOES", row, nestedForm) { }

		public Operacoes_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("operacoes", id);
			Model = Models.Operacoes.Find(id, userContext, "FOPERACOES", fieldsToQuery: fieldsToLoad);
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
			Models.Operacoes model = new Models.Operacoes(userContext) { Identifier = "FOPERACOES" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FOPERACOES");
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
		public override void MapFromModel(Models.Operacoes m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Operacoes) to ViewModel (Operacoes) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodentidade = ViewModelConversion.ToString(m.ValCodentidade);
				ValOperacao_aa = ViewModelConversion.ToString(m.ValOperacao_aa);
				ValPop_aa = ViewModelConversion.ToNumeric(m.ValPop_aa);
				ValSobreposicao_aa = ViewModelConversion.ToLogic(m.ValSobreposicao_aa);
				ValOperacao_ar = ViewModelConversion.ToString(m.ValOperacao_ar);
				ValPop_ar = ViewModelConversion.ToNumeric(m.ValPop_ar);
				ValSobreposicao_ar = ViewModelConversion.ToLogic(m.ValSobreposicao_ar);
				ValOperacao_ru = ViewModelConversion.ToString(m.ValOperacao_ru);
				ValPop_ru = ViewModelConversion.ToNumeric(m.ValPop_ru);
				ValSobreposicao_ru = ViewModelConversion.ToLogic(m.ValSobreposicao_ru);
				ValCodoperacoes = ViewModelConversion.ToString(m.ValCodoperacoes);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Operacoes) to ViewModel (Operacoes) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Operacoes m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Operacoes) to Model (Operacoes) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodentidade = ViewModelConversion.ToString(ValCodentidade);
				m.ValOperacao_aa = ViewModelConversion.ToString(ValOperacao_aa);
				m.ValPop_aa = ViewModelConversion.ToNumeric(ValPop_aa);
				m.ValSobreposicao_aa = ViewModelConversion.ToLogic(ValSobreposicao_aa);
				m.ValOperacao_ar = ViewModelConversion.ToString(ValOperacao_ar);
				m.ValPop_ar = ViewModelConversion.ToNumeric(ValPop_ar);
				m.ValSobreposicao_ar = ViewModelConversion.ToLogic(ValSobreposicao_ar);
				m.ValOperacao_ru = ViewModelConversion.ToString(ValOperacao_ru);
				m.ValPop_ru = ViewModelConversion.ToNumeric(ValPop_ru);
				m.ValSobreposicao_ru = ViewModelConversion.ToLogic(ValSobreposicao_ru);
				m.ValCodoperacoes = ViewModelConversion.ToString(ValCodoperacoes);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Operacoes) to Model (Operacoes) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "operacoes.codentidade":
						this.ValCodentidade = ViewModelConversion.ToString(_value);
						break;
					case "operacoes.operacao_aa":
						this.ValOperacao_aa = ViewModelConversion.ToString(_value);
						break;
					case "operacoes.pop_aa":
						this.ValPop_aa = ViewModelConversion.ToNumeric(_value);
						break;
					case "operacoes.sobreposicao_aa":
						this.ValSobreposicao_aa = ViewModelConversion.ToLogic(_value);
						break;
					case "operacoes.operacao_ar":
						this.ValOperacao_ar = ViewModelConversion.ToString(_value);
						break;
					case "operacoes.pop_ar":
						this.ValPop_ar = ViewModelConversion.ToNumeric(_value);
						break;
					case "operacoes.sobreposicao_ar":
						this.ValSobreposicao_ar = ViewModelConversion.ToLogic(_value);
						break;
					case "operacoes.operacao_ru":
						this.ValOperacao_ru = ViewModelConversion.ToString(_value);
						break;
					case "operacoes.pop_ru":
						this.ValPop_ru = ViewModelConversion.ToNumeric(_value);
						break;
					case "operacoes.sobreposicao_ru":
						this.ValSobreposicao_ru = ViewModelConversion.ToLogic(_value);
						break;
					case "operacoes.codoperacoes":
						this.ValCodoperacoes = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Operacoes) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Operacoes)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Operacoes.Find(id ?? Navigation.GetStrValue("operacoes"), m_userContext, "FOPERACOES"); }
			finally { Model ??= new Models.Operacoes(m_userContext) { Identifier = "FOPERACOES" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Operacoes.Find(Navigation.GetStrValue("operacoes"), m_userContext, "FOPERACOES");
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

			Model.Identifier = "FOPERACOES";
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

		protected override void LoadDocumentsProperties(Models.Operacoes row)
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
				Model = Models.Operacoes.Find(Navigation.GetStrValue("operacoes"), m_userContext, "FOPERACOES");
				if (Model == null)
				{
					Model = new Models.Operacoes(m_userContext) { Identifier = "FOPERACOES" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("operacoes");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Operacoes__entidade__entidade(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL OPERACOES]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW OPERACOES]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodentidade", Resources.Resources.ENTIDADE36471, ViewModelConversion.ToString(ValCodentidade), FieldType.KEY_GUID.GetFormatting());
			validator.StringLength("ValOperacao_aa", Resources.Resources.OPERACAO_AA07938, ValOperacao_aa, 50);
			validator.StringLength("ValOperacao_ar", Resources.Resources.OPERACAO_AR11207, ValOperacao_ar, 50);
			validator.StringLength("ValOperacao_ru", Resources.Resources.OPERACAO_RU18117, ValOperacao_ru, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE OPERACOES]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY OPERACOES]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE OPERACOES]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY OPERACOES]/
		public override void Destroy(string id)
		{
			Model = Models.Operacoes.Find(id, m_userContext, "FOPERACOES");
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
		/// TableEntidadeEntidade -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Operacoes__entidade__entidade(NameValueCollection qs, bool lazyLoad = false)
		{
			bool operacoes__entidade__entidadeDoLoad = true;
			CriteriaSet operacoes__entidade__entidadeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("entidade", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					operacoes__entidade__entidadeConds.Equal(CSGenioAentidade.FldCodentidade, hValue);
					this.ValCodentidade = DBConversion.ToString(hValue);
				}
			}

			TableEntidadeEntidade = new TableDBEdit<Models.Entidade>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_entidade") != null)
				{
					this.ValCodentidade = Navigation.GetStrValue("RETURN_entidade");
					Navigation.CurrentLevel.SetEntry("RETURN_entidade", null);
				}
				FillDependant_OperacoesTableEntidadeEntidade(lazyLoad);
				return;
			}

			if (operacoes__entidade__entidadeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableEntidadeEntidade, "sTableEntidadeEntidade", "dTableEntidadeEntidade", qs, "entidade");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentidade.FldEntidade), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEntidadeEntidade_tableFilters"]))
					TableEntidadeEntidade.TableFilters = bool.Parse(qs["TableEntidadeEntidade_tableFilters"]);
				else
					TableEntidadeEntidade.TableFilters = false;

				query = qs["qTableEntidadeEntidade"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAentidade.FldEntidade, query + "%");
				}
				operacoes__entidade__entidadeConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEntidadeEntidade"] != null ? qs["pTableEntidadeEntidade"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAentidade.FldCodentidade, CSGenioAentidade.FldEntidade, CSGenioAentidade.FldZzstate];

// USE /[MANUAL GQT OVERRQ OPERACOES_ENTIDADEENTIDADE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("entidade", FormMode.New) || Navigation.checkFormMode("entidade", FormMode.Duplicate))
					operacoes__entidade__entidadeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAentidade.FldZzstate, 0)
						.Equal(CSGenioAentidade.FldCodentidade, Navigation.GetStrValue("entidade")));
				else
					operacoes__entidade__entidadeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentidade.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("entidade", "entidade");
				ListingMVC<CSGenioAentidade> listing = Models.ModelBase.Where<CSGenioAentidade>(m_userContext, false, operacoes__entidade__entidadeConds, fields, offset, numberItems, sorts, "LED_OPERACOES__ENTIDADE__ENTIDADE", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEntidadeEntidade.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEntidadeEntidade.Query = query;
				TableEntidadeEntidade.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Entidade(m_userContext, r, true, _fieldsToSerialize_OPERACOES__ENTIDADE__ENTIDADE));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_entidade") != null)
				{
					this.ValCodentidade = Navigation.GetStrValue("RETURN_entidade");
					Navigation.CurrentLevel.SetEntry("RETURN_entidade", null);
				}

				TableEntidadeEntidade.List = new SelectList(TableEntidadeEntidade.Elements.ToSelectList(x => x.ValEntidade, x => x.ValCodentidade,  x => x.ValCodentidade == this.ValCodentidade), "Value", "Text", this.ValCodentidade);
				//Seleciona se só um
				if (TableEntidadeEntidade.List != null && TableEntidadeEntidade.List.Count() == 1)
				{
					this.ValCodentidade = TableEntidadeEntidade.List.First().Value;
					Navigation.SetValue("entidade", this.ValCodentidade);
				}
				FillDependant_OperacoesTableEntidadeEntidade();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEntidadeEntidade (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Entidade</param>
		public ConcurrentDictionary<string, object> GetDependant_OperacoesTableEntidadeEntidade(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAentidade.FldCodentidade, CSGenioAentidade.FldEntidade];

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

			CSGenioAentidade tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAentidade.FldCodentidade, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEntidadeEntidade (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_OperacoesTableEntidadeEntidade(bool lazyLoad = false)
		{
			var row = GetDependant_OperacoesTableEntidadeEntidade(this.ValCodentidade);
			try
			{

				// Fill List fields
				this.ValCodentidade = ViewModelConversion.ToString(row["entidade.codentidade"]);
				TableEntidadeEntidade.Value = (string)row["entidade.entidade"];
				if (GenFunctions.emptyG(this.ValCodentidade) == 1)
				{
					this.ValCodentidade = "";
					TableEntidadeEntidade.Value = "";
					Navigation.ClearValue("entidade");
				}
				else if (lazyLoad)
				{
					TableEntidadeEntidade.SetPagination(1, 0, false, false, 1);
					TableEntidadeEntidade.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodentidade),
							Text = Convert.ToString(TableEntidadeEntidade.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodentidade);
				}

				TableEntidadeEntidade.Selected = this.ValCodentidade;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntidadeEntidade): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_OPERACOES__ENTIDADE__ENTIDADE = ["Entidade", "Entidade.ValCodentidade", "Entidade.ValZzstate", "Entidade.ValEntidade"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"operacoes.codentidade" => ViewModelConversion.ToString(modelValue),
				"operacoes.operacao_aa" => ViewModelConversion.ToString(modelValue),
				"operacoes.pop_aa" => ViewModelConversion.ToNumeric(modelValue),
				"operacoes.sobreposicao_aa" => ViewModelConversion.ToLogic(modelValue),
				"operacoes.operacao_ar" => ViewModelConversion.ToString(modelValue),
				"operacoes.pop_ar" => ViewModelConversion.ToNumeric(modelValue),
				"operacoes.sobreposicao_ar" => ViewModelConversion.ToLogic(modelValue),
				"operacoes.operacao_ru" => ViewModelConversion.ToString(modelValue),
				"operacoes.pop_ru" => ViewModelConversion.ToNumeric(modelValue),
				"operacoes.sobreposicao_ru" => ViewModelConversion.ToLogic(modelValue),
				"operacoes.codoperacoes" => ViewModelConversion.ToString(modelValue),
				"entidade.codentidade" => ViewModelConversion.ToString(modelValue),
				"entidade.entidade" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM OPERACOES]/

		#endregion
	}
}
