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

namespace GenioMVC.ViewModels.Pworg
{
	public class Pworg_ViewModel : FormViewModel<Models.Pworg>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Psw> TablePswNome { get; set; }

		/// <summary>
		/// Title: "Organization" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Organ> TableOrganOrganiza { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Organization" | Type: "CE"
		/// </summary>
		public string ValCodorgan { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValCodpsw { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpworg { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pworg_ViewModel() : base(null!) { }

		public Pworg_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPWORG", nestedForm) { }

		public Pworg_ViewModel(UserContext userContext, Models.Pworg row, bool nestedForm = false) : base(userContext, "FPWORG", row, nestedForm) { }

		public Pworg_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pworg", id);
			Model = Models.Pworg.Find(id, userContext, "FPWORG", fieldsToQuery: fieldsToLoad);
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
			Models.Pworg model = new Models.Pworg(userContext) { Identifier = "FPWORG" };
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
			Models.Pworg model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pworg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pworg) to ViewModel (Pworg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
				ValCodpworg = ViewModelConversion.ToString(m.ValCodpworg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pworg) to ViewModel (Pworg) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pworg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pworg) to Model (Pworg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodpworg = ViewModelConversion.ToString(ValCodpworg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pworg) to Model (Pworg) - Error during mapping");
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
				Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), m_userContext, "FPWORG");
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

			Model.Identifier = "FPWORG";
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

		protected override void LoadDocumentsProperties(Models.Pworg row)
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
				Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), m_userContext, "FPWORG");
				if (Model == null)
				{
					Model = new Models.Pworg(m_userContext) { Identifier = "FPWORG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pworg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pworg___psw__nome____(qs, lazyLoad);
			Load_Pworg___organorganiza(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PWORG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PWORG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PWORG]/
		public override void Save()
		{

			try { Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), m_userContext, "FPWORG"); }
			finally { if (Model == null) Model = new Models.Pworg(m_userContext) { Identifier = "FPWORG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PWORG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), m_userContext, "FPWORG"); }
			finally { if (Model == null) Model = new Models.Pworg(m_userContext) { Identifier = "FPWORG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PWORG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PWORG]/
		public override void Destroy(string id)
		{
			Model = Models.Pworg.Find(id, m_userContext, "FPWORG");
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
		/// TablePswNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pworg___psw__nome____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pworg___psw__nome____DoLoad = true;
			CriteriaSet pworg___psw__nome____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("psw", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pworg___psw__nome____Conds.Equal(CSGenioApsw.FldCodpsw, Navigation.GetValue("psw"));
					this.ValCodpsw = Navigation.GetStrValue("psw");
				}
			}

			TablePswNome = new TableDBEdit<Models.Psw>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
				FillDependant_PworgTablePswNome(lazyLoad);
				//Check if foreignkey comes from history
				TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
				return;
			}

			if (pworg___psw__nome____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
					TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
				else
					TablePswNome.TableFilters = false;

				query = qs["qTablePswNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
				}
				pworg___psw__nome____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWORG_PSWNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
					pworg___psw__nome____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApsw.FldZzstate, 0)
						.Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
				else
					pworg___psw__nome____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, pworg___psw__nome____Conds, fields, offset, numberItems, sorts, "LED_PWORG___PSW__NOME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePswNome.Query = query;
				TablePswNome.Elements = listing.RowsForViewModel<GenioMVC.Models.Psw>((r) => new GenioMVC.Models.Psw(m_userContext, r, true, _fieldsToSerialize_PWORG___PSW__NOME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
				FillDependant_PworgTablePswNome();

				//Check if foreignkey comes from history
				TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Psw</param>
		public ConcurrentDictionary<string, object> GetDependant_PworgTablePswNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApsw tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PworgTablePswNome(bool lazyLoad = false)
		{
			var row = GetDependant_PworgTablePswNome(this.ValCodpsw);
			try
			{

				// Fill List fields
				this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
				TablePswNome.Value = (string)row["psw.nome"];
				if (GlobalFunctions.emptyG(this.ValCodpsw) == 1)
				{
					this.ValCodpsw = "";
					TablePswNome.Value = "";
					Navigation.ClearValue("psw");
				}
				else if (lazyLoad)
				{
					TablePswNome.SetPagination(1, 0, false, false, 1);
					TablePswNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpsw),
							Text = Convert.ToString(TablePswNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpsw);
				}

				TablePswNome.Selected = this.ValCodpsw;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PWORG___PSW__NOME____ = ["Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome"];

		/// <summary>
		/// TableOrganOrganiza -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pworg___organorganiza(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pworg___organorganizaDoLoad = true;
			CriteriaSet pworg___organorganizaConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("organ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pworg___organorganizaConds.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetValue("organ"));
					this.ValCodorgan = Navigation.GetStrValue("organ");
				}
			}

			TableOrganOrganiza = new TableDBEdit<Models.Organ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}
				FillDependant_PworgTableOrganOrganiza(lazyLoad);
				//Check if foreignkey comes from history
				TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
				return;
			}

			if (pworg___organorganizaDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableOrganOrganiza, "sTableOrganOrganiza", "dTableOrganOrganiza", qs, "organ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAorgan.FldOrganiza), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableOrganOrganiza_tableFilters"]))
					TableOrganOrganiza.TableFilters = bool.Parse(qs["TableOrganOrganiza_tableFilters"]);
				else
					TableOrganOrganiza.TableFilters = false;

				query = qs["qTableOrganOrganiza"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAorgan.FldOrganiza, query + "%");
				}
				pworg___organorganizaConds.SubSet(search_filters);

				string tryParsePage = qs["pTableOrganOrganiza"] != null ? qs["pTableOrganOrganiza"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza, CSGenioAorgan.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWORG_ORGANORGANIZA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("organ", FormMode.New) || Navigation.checkFormMode("organ", FormMode.Duplicate))
					pworg___organorganizaConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAorgan.FldZzstate, 0)
						.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetStrValue("organ")));
				else
					pworg___organorganizaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAorgan.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("organ", "organiza");
				ListingMVC<CSGenioAorgan> listing = Models.ModelBase.Where<CSGenioAorgan>(m_userContext, false, pworg___organorganizaConds, fields, offset, numberItems, sorts, "LED_PWORG___ORGANORGANIZA", true, false, firstVisibleColumn: firstVisibleColumn);

				TableOrganOrganiza.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableOrganOrganiza.Query = query;
				TableOrganOrganiza.Elements = listing.RowsForViewModel<GenioMVC.Models.Organ>((r) => new GenioMVC.Models.Organ(m_userContext, r, true, _fieldsToSerialize_PWORG___ORGANORGANIZA));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}

				TableOrganOrganiza.List = new SelectList(TableOrganOrganiza.Elements.ToSelectList(x => x.ValOrganiza, x => x.ValCodorgan,  x => x.ValCodorgan == this.ValCodorgan), "Value", "Text", this.ValCodorgan);
				FillDependant_PworgTableOrganOrganiza();

				//Check if foreignkey comes from history
				TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableOrganOrganiza (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Organ</param>
		public ConcurrentDictionary<string, object> GetDependant_PworgTableOrganOrganiza(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAorgan tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAorgan.FldCodorgan, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableOrganOrganiza (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PworgTableOrganOrganiza(bool lazyLoad = false)
		{
			var row = GetDependant_PworgTableOrganOrganiza(this.ValCodorgan);
			try
			{

				// Fill List fields
				this.ValCodorgan = ViewModelConversion.ToString(row["organ.codorgan"]);
				TableOrganOrganiza.Value = (string)row["organ.organiza"];
				if (GlobalFunctions.emptyG(this.ValCodorgan) == 1)
				{
					this.ValCodorgan = "";
					TableOrganOrganiza.Value = "";
					Navigation.ClearValue("organ");
				}
				else if (lazyLoad)
				{
					TableOrganOrganiza.SetPagination(1, 0, false, false, 1);
					TableOrganOrganiza.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodorgan),
							Text = Convert.ToString(TableOrganOrganiza.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodorgan);
				}

				TableOrganOrganiza.Selected = this.ValCodorgan;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOrganOrganiza): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PWORG___ORGANORGANIZA = ["Organ", "Organ.ValCodorgan", "Organ.ValZzstate", "Organ.ValOrganiza"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pworg.codorgan" => ViewModelConversion.ToString(modelValue),
				"pworg.codpsw" => ViewModelConversion.ToString(modelValue),
				"pworg.codpworg" => ViewModelConversion.ToString(modelValue),
				"psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"psw.nome" => ViewModelConversion.ToString(modelValue),
				"organ.codorgan" => ViewModelConversion.ToString(modelValue),
				"organ.organiza" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PWORG]/

		#endregion
	}
}
