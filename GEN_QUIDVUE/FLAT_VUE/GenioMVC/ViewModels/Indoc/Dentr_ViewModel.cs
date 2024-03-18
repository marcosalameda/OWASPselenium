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

namespace GenioMVC.ViewModels.Indoc
{
	public class Dentr_ViewModel : FormViewModel<Models.Indoc>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }

		/// <summary>
		/// Title: "Company" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }

		/// <summary>
		/// Title: "Person" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }

		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Ware1> TableWare1Warehdes { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "DT"
		/// </summary>
		public DateTime? ValDate { get; set; }

		/// <summary>
		/// Title: "No." | Type: "N"
		/// </summary>
		public decimal? ValDocumenr { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "DT"
		/// </summary>
		public DateTime? ValDhdocume { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Company" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }

		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

		/// <summary>
		/// Title: "Person" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }

		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddentr { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dentr_ViewModel() : base(null!) { }

		public Dentr_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDENTR", nestedForm) { }

		public Dentr_ViewModel(UserContext userContext, Models.Indoc row, bool nestedForm = false) : base(userContext, "FDENTR", row, nestedForm) { }

		public Dentr_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("indoc", id);
			Model = Models.Indoc.Find(id, userContext, "FDENTR", fieldsToQuery: fieldsToLoad);
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
			Models.Indoc model = new Models.Indoc(userContext) { Identifier = "FDENTR" };
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
			Models.Indoc model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Indoc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Indoc) to ViewModel (Dentr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDocumenr = ViewModelConversion.ToNumeric(m.ValDocumenr);
				ValDhdocume = ViewModelConversion.ToDateTime(m.ValDhdocume);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValCoddentr = ViewModelConversion.ToString(m.ValCoddentr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Indoc) to ViewModel (Dentr) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Indoc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dentr) to Model (Indoc) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDocumenr = ViewModelConversion.ToNumeric(ValDocumenr);
				m.ValDhdocume = ViewModelConversion.ToDateTime(ValDhdocume);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCoddentr = ViewModelConversion.ToString(ValCoddentr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dentr) to Model (Indoc) - Error during mapping");
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
				Model = Models.Indoc.Find(Navigation.GetStrValue("indoc"), m_userContext, "FDENTR");
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

			Model.Identifier = "FDENTR";
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

		protected override void LoadDocumentsProperties(Models.Indoc row)
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
				Model = Models.Indoc.Find(Navigation.GetStrValue("indoc"), m_userContext, "FDENTR");
				if (Model == null)
				{
					Model = new Models.Indoc(m_userContext) { Identifier = "FDENTR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("indoc");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Dentr___cntrycountry_(qs, lazyLoad);
			Load_Dentr___cmpnydesignat(qs, lazyLoad);
			Load_Dentr___pessoname____(qs, lazyLoad);
			Load_Dentr___ware1warehdes(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DENTR]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DENTR]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DENTR]/
		public override void Save()
		{

			try { Model = Models.Indoc.Find(Navigation.GetStrValue("indoc"), m_userContext, "FDENTR"); }
			finally { if (Model == null) Model = new Models.Indoc(m_userContext) { Identifier = "FDENTR" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DENTR]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Indoc.Find(Navigation.GetStrValue("indoc"), m_userContext, "FDENTR"); }
			finally { if (Model == null) Model = new Models.Indoc(m_userContext) { Identifier = "FDENTR" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DENTR]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DENTR]/
		public override void Destroy(string id)
		{
			Model = Models.Indoc.Find(id, m_userContext, "FDENTR");
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
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dentr___cntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dentr___cntrycountry_DoLoad = true;
			CriteriaSet dentr___cntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dentr___cntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
					this.ValCodcntry = Navigation.GetStrValue("cntry");
				}
			}

			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
				FillDependant_DentrTableCntryCountry(lazyLoad);
				//Check if foreignkey comes from history
				TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
				return;
			}

			if (dentr___cntrycountry_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				query = qs["qTableCntryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				}
				dentr___cntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ DENTR_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					dentr___cntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					dentr___cntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, dentr___cntrycountry_Conds, fields, offset, numberItems, sorts, "LED_DENTR___CNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_DENTR___CNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_DentrTableCntryCountry();

				//Check if foreignkey comes from history
				TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_DentrTableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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

			CSGenioAcntry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DentrTableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_DentrTableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TableCntryCountry.Value = "";
					Navigation.ClearValue("cntry");
				}
				else if (lazyLoad)
				{
					TableCntryCountry.SetPagination(1, 0, false, false, 1);
					TableCntryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TableCntryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TableCntryCountry.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DENTR___CNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		/// <summary>
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dentr___cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dentr___cmpnydesignatDoLoad = true;
			CriteriaSet dentr___cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dentr___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
					this.ValCodempre = Navigation.GetStrValue("cmpny");
				}
			}
			// Limits Generation

			// Area limit
			dentr___cmpnydesignatDoLoad &= AddCriteriaAreaLimit(dentr___cmpnydesignatConds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, false);

			TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
				FillDependant_DentrTableCmpnyDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				dentr___cmpnydesignatDoLoad = false;

			if (dentr___cmpnydesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
					TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
				else
					TableCmpnyDesignat.TableFilters = false;

				query = qs["qTableCmpnyDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
				}
				dentr___cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ DENTR_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					dentr___cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					dentr___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, dentr___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_DENTR___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_DENTR___CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_DentrTableCmpnyDesignat();

				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_DentrTableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cntry");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAcmpny.FldCodcntry, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcmpny tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DentrTableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_DentrTableCmpnyDesignat(this.ValCodempre);
			try
			{

				// Fill List fields
				this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
				TableCmpnyDesignat.Value = (string)row["cmpny.designat"];
				if (GlobalFunctions.emptyG(this.ValCodempre) == 1)
				{
					this.ValCodempre = "";
					TableCmpnyDesignat.Value = "";
					Navigation.ClearValue("cmpny");
				}
				else if (lazyLoad)
				{
					TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
					TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodempre),
							Text = Convert.ToString(TableCmpnyDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodempre);
				}

				TableCmpnyDesignat.Selected = this.ValCodempre;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DENTR___CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		/// <summary>
		/// TablePessoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dentr___pessoname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dentr___pessoname____DoLoad = true;
			CriteriaSet dentr___pessoname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pesso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dentr___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
					this.ValCodpesso = Navigation.GetStrValue("pesso");
				}
			}
			// Limits Generation

			// Area limit
			dentr___pessoname____DoLoad &= AddCriteriaAreaLimit(dentr___pessoname____Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, false);

			// Area limit
			dentr___pessoname____DoLoad &= AddCriteriaAreaLimit(dentr___pessoname____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, false);

			TablePessoName = new TableDBEdit<Models.Pesso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
				FillDependant_DentrTablePessoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				dentr___pessoname____DoLoad = false;
			if (string.IsNullOrEmpty(this.ValCodempre))
				dentr___pessoname____DoLoad = false;

			if (dentr___pessoname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
					TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
				else
					TablePessoName.TableFilters = false;

				query = qs["qTablePessoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApesso.FldName, query + "%");
				}
				dentr___pessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ DENTR_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					dentr___pessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					dentr___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, dentr___pessoname____Conds, fields, offset, numberItems, sorts, "LED_DENTR___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_DENTR___PESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_DentrTablePessoName();

				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_DentrTablePessoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cntry");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApesso.FldCodpaise, hValue);
				}
			}
			{
				object hValue = Navigation.GetValue("cmpny");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApesso.FldCodempre, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApesso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DentrTablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_DentrTablePessoName(this.ValCodpesso);
			try
			{

				// Fill List fields
				this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
				TablePessoName.Value = (string)row["pesso.name"];
				if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
				{
					this.ValCodpesso = "";
					TablePessoName.Value = "";
					Navigation.ClearValue("pesso");
				}
				else if (lazyLoad)
				{
					TablePessoName.SetPagination(1, 0, false, false, 1);
					TablePessoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpesso),
							Text = Convert.ToString(TablePessoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpesso);
				}

				TablePessoName.Selected = this.ValCodpesso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DENTR___PESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		/// <summary>
		/// TableWare1Warehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dentr___ware1warehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dentr___ware1warehdesDoLoad = true;
			CriteriaSet dentr___ware1warehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("ware1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dentr___ware1warehdesConds.Equal(CSGenioAware1.FldCodwareh, Navigation.GetValue("ware1"));
					this.ValCodwareh = Navigation.GetStrValue("ware1");
				}
			}

			TableWare1Warehdes = new TableDBEdit<Models.Ware1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}
				FillDependant_DentrTableWare1Warehdes(lazyLoad);
				//Check if foreignkey comes from history
				TableWare1Warehdes.FilledByHistory = Navigation.CheckFilledByHistory("ware1");
				return;
			}

			if (dentr___ware1warehdesDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableWare1Warehdes, "sTableWare1Warehdes", "dTableWare1Warehdes", qs, "ware1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAware1.FldWarehdes), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableWare1Warehdes_tableFilters"]))
					TableWare1Warehdes.TableFilters = bool.Parse(qs["TableWare1Warehdes_tableFilters"]);
				else
					TableWare1Warehdes.TableFilters = false;

				query = qs["qTableWare1Warehdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAware1.FldWarehdes, query + "%");
				}
				dentr___ware1warehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWare1Warehdes"] != null ? qs["pTableWare1Warehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes, CSGenioAware1.FldZzstate };

// USE /[MANUAL GQT OVERRQ DENTR_WARE1WAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("ware1", FormMode.New) || Navigation.checkFormMode("ware1", FormMode.Duplicate))
					dentr___ware1warehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAware1.FldZzstate, 0)
						.Equal(CSGenioAware1.FldCodwareh, Navigation.GetStrValue("ware1")));
				else
					dentr___ware1warehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAware1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("ware1", "warehdes");
				ListingMVC<CSGenioAware1> listing = Models.ModelBase.Where<CSGenioAware1>(m_userContext, false, dentr___ware1warehdesConds, fields, offset, numberItems, sorts, "LED_DENTR___WARE1WAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWare1Warehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWare1Warehdes.Query = query;
				TableWare1Warehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Ware1>((r) => new GenioMVC.Models.Ware1(m_userContext, r, true, _fieldsToSerialize_DENTR___WARE1WAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}

				TableWare1Warehdes.List = new SelectList(TableWare1Warehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_DentrTableWare1Warehdes();

				//Check if foreignkey comes from history
				TableWare1Warehdes.FilledByHistory = Navigation.CheckFilledByHistory("ware1");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWare1Warehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Ware1</param>
		public ConcurrentDictionary<string, object> GetDependant_DentrTableWare1Warehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes];

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

			CSGenioAware1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAware1.FldCodwareh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableWare1Warehdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DentrTableWare1Warehdes(bool lazyLoad = false)
		{
			var row = GetDependant_DentrTableWare1Warehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["ware1.codwareh"]);
				TableWare1Warehdes.Value = (string)row["ware1.warehdes"];
				if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
				{
					this.ValCodwareh = "";
					TableWare1Warehdes.Value = "";
					Navigation.ClearValue("ware1");
				}
				else if (lazyLoad)
				{
					TableWare1Warehdes.SetPagination(1, 0, false, false, 1);
					TableWare1Warehdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodwareh),
							Text = Convert.ToString(TableWare1Warehdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodwareh);
				}

				TableWare1Warehdes.Selected = this.ValCodwareh;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWare1Warehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DENTR___WARE1WAREHDES = ["Ware1", "Ware1.ValCodwareh", "Ware1.ValZzstate", "Ware1.ValWarehdes"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"indoc.date" => ViewModelConversion.ToDateTime(modelValue),
				"indoc.documenr" => ViewModelConversion.ToNumeric(modelValue),
				"indoc.dhdocume" => ViewModelConversion.ToDateTime(modelValue),
				"indoc.codempre" => ViewModelConversion.ToString(modelValue),
				"indoc.codcntry" => ViewModelConversion.ToString(modelValue),
				"indoc.codpesso" => ViewModelConversion.ToString(modelValue),
				"indoc.codwareh" => ViewModelConversion.ToString(modelValue),
				"indoc.coddentr" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"ware1.codwareh" => ViewModelConversion.ToString(modelValue),
				"ware1.warehdes" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DENTR]/

		#endregion
	}
}
