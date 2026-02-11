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

namespace GenioMVC.ViewModels.Entidade
{
	public class Entidade_ViewModel : FormViewModel<Models.Entidade>, IPreparableForSerialization
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
		/// Title: "Nome" | Type: "CE"
		/// </summary>
		public string ValCodconcelho { get; set; }

		#endregion
		/// <summary>
		/// Title: "Nome" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Concelho> TableConcelhoNome { get; set; }
		/// <summary>
		/// Title: "ID Entidade" | Type: "N"
		/// </summary>
		public decimal? ValId_entidade { get; set; }
		/// <summary>
		/// Title: "Entidade" | Type: "C"
		/// </summary>
		public string ValEntidade { get; set; }
		/// <summary>
		/// Title: "Submodelo de gestão" | Type: "C"
		/// </summary>
		public string ValSub_modelo_gestao { get; set; }
		/// <summary>
		/// Title: "Sistema contabilístico" | Type: "AC"
		/// </summary>
		public string ValSistema_contabilistico { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValSistema_contabilistico { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodentidade { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Entidade_ViewModel() : base(null!) { }

		public Entidade_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FENTIDADE", nestedForm) { }

		public Entidade_ViewModel(UserContext userContext, Models.Entidade row, bool nestedForm = false) : base(userContext, "FENTIDADE", row, nestedForm) { }

		public Entidade_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("entidade", id);
			Model = Models.Entidade.Find(id, userContext, "FENTIDADE", fieldsToQuery: fieldsToLoad);
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
			Models.Entidade model = new Models.Entidade(userContext) { Identifier = "FENTIDADE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FENTIDADE");
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
		public override void MapFromModel(Models.Entidade m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Entidade) to ViewModel (Entidade) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodconcelho = ViewModelConversion.ToString(m.ValCodconcelho);
				ValId_entidade = ViewModelConversion.ToNumeric(m.ValId_entidade);
				ValEntidade = ViewModelConversion.ToString(m.ValEntidade);
				ValSub_modelo_gestao = ViewModelConversion.ToString(m.ValSub_modelo_gestao);
				ValSistema_contabilistico = ViewModelConversion.ToString(m.ValSistema_contabilistico);
				ValCodentidade = ViewModelConversion.ToString(m.ValCodentidade);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Entidade) to ViewModel (Entidade) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Entidade m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Entidade) to Model (Entidade) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodconcelho = ViewModelConversion.ToString(ValCodconcelho);
				m.ValId_entidade = ViewModelConversion.ToNumeric(ValId_entidade);
				m.ValEntidade = ViewModelConversion.ToString(ValEntidade);
				m.ValSub_modelo_gestao = ViewModelConversion.ToString(ValSub_modelo_gestao);
				m.ValSistema_contabilistico = ViewModelConversion.ToString(ValSistema_contabilistico);
				m.ValCodentidade = ViewModelConversion.ToString(ValCodentidade);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Entidade) to Model (Entidade) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "entidade.codconcelho":
						this.ValCodconcelho = ViewModelConversion.ToString(_value);
						break;
					case "entidade.id_entidade":
						this.ValId_entidade = ViewModelConversion.ToNumeric(_value);
						break;
					case "entidade.entidade":
						this.ValEntidade = ViewModelConversion.ToString(_value);
						break;
					case "entidade.sub_modelo_gestao":
						this.ValSub_modelo_gestao = ViewModelConversion.ToString(_value);
						break;
					case "entidade.sistema_contabilistico":
						this.ValSistema_contabilistico = ViewModelConversion.ToString(_value);
						break;
					case "entidade.codentidade":
						this.ValCodentidade = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Entidade) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Entidade)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Entidade.Find(id ?? Navigation.GetStrValue("entidade"), m_userContext, "FENTIDADE"); }
			finally { Model ??= new Models.Entidade(m_userContext) { Identifier = "FENTIDADE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Entidade.Find(Navigation.GetStrValue("entidade"), m_userContext, "FENTIDADE");
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

			Model.Identifier = "FENTIDADE";
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

		protected override void LoadDocumentsProperties(Models.Entidade row)
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
				Model = Models.Entidade.Find(Navigation.GetStrValue("entidade"), m_userContext, "FENTIDADE");
				if (Model == null)
				{
					Model = new Models.Entidade(m_userContext) { Identifier = "FENTIDADE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("entidade");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Entidade__concelho__nome(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ENTIDADE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ENTIDADE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodconcelho", Resources.Resources.NOME47814, ViewModelConversion.ToString(ValCodconcelho), FieldType.KEY_GUID.GetFormatting());

			validator.Required("ValId_entidade", Resources.Resources.ID_ENTIDADE52030, ViewModelConversion.ToNumeric(ValId_entidade), FieldType.NUMERIC.GetFormatting());
			validator.StringLength("ValEntidade", Resources.Resources.ENTIDADE36471, ValEntidade, 250);
			validator.StringLength("ValSub_modelo_gestao", Resources.Resources.SUBMODELO_DE_GESTAO34607, ValSub_modelo_gestao, 100);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ENTIDADE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ENTIDADE]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ENTIDADE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ENTIDADE]/
		public override void Destroy(string id)
		{
			Model = Models.Entidade.Find(id, m_userContext, "FENTIDADE");
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
		/// TableConcelhoNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Entidade__concelho__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool entidade__concelho__nomeDoLoad = true;
			CriteriaSet entidade__concelho__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("concelho", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					entidade__concelho__nomeConds.Equal(CSGenioAconcelho.FldCodconcelho, hValue);
					this.ValCodconcelho = DBConversion.ToString(hValue);
				}
			}

			TableConcelhoNome = new TableDBEdit<Models.Concelho>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_concelho") != null)
				{
					this.ValCodconcelho = Navigation.GetStrValue("RETURN_concelho");
					Navigation.CurrentLevel.SetEntry("RETURN_concelho", null);
				}
				FillDependant_EntidadeTableConcelhoNome(lazyLoad);
				return;
			}

			if (entidade__concelho__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableConcelhoNome, "sTableConcelhoNome", "dTableConcelhoNome", qs, "concelho");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAconcelho.FldNome), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableConcelhoNome_tableFilters"]))
					TableConcelhoNome.TableFilters = bool.Parse(qs["TableConcelhoNome_tableFilters"]);
				else
					TableConcelhoNome.TableFilters = false;

				query = qs["qTableConcelhoNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAconcelho.FldNome, query + "%");
				}
				entidade__concelho__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTableConcelhoNome"] != null ? qs["pTableConcelhoNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAconcelho.FldCodconcelho, CSGenioAconcelho.FldNome, CSGenioAconcelho.FldZzstate];

// USE /[MANUAL GQT OVERRQ ENTIDADE_CONCELHONOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("concelho", FormMode.New) || Navigation.checkFormMode("concelho", FormMode.Duplicate))
					entidade__concelho__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAconcelho.FldZzstate, 0)
						.Equal(CSGenioAconcelho.FldCodconcelho, Navigation.GetStrValue("concelho")));
				else
					entidade__concelho__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAconcelho.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("concelho", "nome");
				ListingMVC<CSGenioAconcelho> listing = Models.ModelBase.Where<CSGenioAconcelho>(m_userContext, false, entidade__concelho__nomeConds, fields, offset, numberItems, sorts, "LED_ENTIDADE__CONCELHO__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableConcelhoNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableConcelhoNome.Query = query;
				TableConcelhoNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Concelho(m_userContext, r, true, _fieldsToSerialize_ENTIDADE__CONCELHO__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_concelho") != null)
				{
					this.ValCodconcelho = Navigation.GetStrValue("RETURN_concelho");
					Navigation.CurrentLevel.SetEntry("RETURN_concelho", null);
				}

				TableConcelhoNome.List = new SelectList(TableConcelhoNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodconcelho,  x => x.ValCodconcelho == this.ValCodconcelho), "Value", "Text", this.ValCodconcelho);
				//Seleciona se só um
				if (TableConcelhoNome.List != null && TableConcelhoNome.List.Count() == 1)
				{
					this.ValCodconcelho = TableConcelhoNome.List.First().Value;
					Navigation.SetValue("concelho", this.ValCodconcelho);
				}
				FillDependant_EntidadeTableConcelhoNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableConcelhoNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Concelho</param>
		public ConcurrentDictionary<string, object> GetDependant_EntidadeTableConcelhoNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAconcelho.FldCodconcelho, CSGenioAconcelho.FldNome];

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

			CSGenioAconcelho tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAconcelho.FldCodconcelho, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableConcelhoNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EntidadeTableConcelhoNome(bool lazyLoad = false)
		{
			var row = GetDependant_EntidadeTableConcelhoNome(this.ValCodconcelho);
			try
			{

				// Fill List fields
				this.ValCodconcelho = ViewModelConversion.ToString(row["concelho.codconcelho"]);
				TableConcelhoNome.Value = (string)row["concelho.nome"];
				if (GenFunctions.emptyG(this.ValCodconcelho) == 1)
				{
					this.ValCodconcelho = "";
					TableConcelhoNome.Value = "";
					Navigation.ClearValue("concelho");
				}
				else if (lazyLoad)
				{
					TableConcelhoNome.SetPagination(1, 0, false, false, 1);
					TableConcelhoNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodconcelho),
							Text = Convert.ToString(TableConcelhoNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodconcelho);
				}

				TableConcelhoNome.Selected = this.ValCodconcelho;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableConcelhoNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ENTIDADE__CONCELHO__NOME = ["Concelho", "Concelho.ValCodconcelho", "Concelho.ValZzstate", "Concelho.ValNome"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"entidade.codconcelho" => ViewModelConversion.ToString(modelValue),
				"entidade.id_entidade" => ViewModelConversion.ToNumeric(modelValue),
				"entidade.entidade" => ViewModelConversion.ToString(modelValue),
				"entidade.sub_modelo_gestao" => ViewModelConversion.ToString(modelValue),
				"entidade.sistema_contabilistico" => ViewModelConversion.ToString(modelValue),
				"entidade.codentidade" => ViewModelConversion.ToString(modelValue),
				"concelho.codconcelho" => ViewModelConversion.ToString(modelValue),
				"concelho.nome" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ENTIDADE]/

		#endregion
	}
}
