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

namespace GenioMVC.ViewModels.Evcat
{
	public class Evcat_ViewModel : FormViewModel<Models.Evcat>
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
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }

		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cate1> TableCate1Category { get; set; }

		/// <summary>
		/// Title: "Since:" | Type: "D"
		/// </summary>
		public DateTime? ValSince { get; set; }

		/// <summary>
		/// Title: "Until" | Type: "D"
		/// </summary>
		public DateTime? ValUntil { get; set; }

		/// <summary>
		/// Title: "End" | Type: "D"
		/// </summary>
		public DateTime? ValUntilman { get; set; }

		/// <summary>
		/// Title: "End of period" | Type: "D"
		/// </summary>
		public DateTime? ValFimperio { get; set; }

		/// <summary>
		/// Title: "Observation" | Type: "MO"
		/// </summary>
		public string ValObservat { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Category" | Type: "CE"
		/// </summary>
		public string ValCodcateg { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodprogr { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Evcat_ViewModel() : base(null!) { }

		public Evcat_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEVCAT", nestedForm) { }

		public Evcat_ViewModel(UserContext userContext, Models.Evcat row, bool nestedForm = false) : base(userContext, "FEVCAT", row, nestedForm) { }

		public Evcat_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("evcat", id);
			Model = Models.Evcat.Find(id, userContext, "FEVCAT", fieldsToQuery: fieldsToLoad);
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
			Models.Evcat model = new Models.Evcat(userContext) { Identifier = "FEVCAT" };
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
			Models.Evcat model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Evcat m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Evcat) to ViewModel (Evcat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
				ValUntil = ViewModelConversion.ToDateTime(m.ValUntil);
				ValUntilman = ViewModelConversion.ToDateTime(m.ValUntilman);
				ValFimperio = ViewModelConversion.ToDateTime(m.ValFimperio);
				ValObservat = ViewModelConversion.ToString(m.ValObservat);
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodprogr = ViewModelConversion.ToString(m.ValCodprogr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Evcat) to ViewModel (Evcat) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Evcat m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Evcat) to Model (Evcat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValUntil = ViewModelConversion.ToDateTime(ValUntil);
				m.ValUntilman = ViewModelConversion.ToDateTime(ValUntilman);
				m.ValFimperio = ViewModelConversion.ToDateTime(ValFimperio);
				m.ValObservat = ViewModelConversion.ToString(ValObservat);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodprogr = ViewModelConversion.ToString(ValCodprogr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Evcat) to Model (Evcat) - Error during mapping");
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
				Model = Models.Evcat.Find(Navigation.GetStrValue("evcat"), m_userContext, "FEVCAT");
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

			Model.Identifier = "FEVCAT";
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

		protected override void LoadDocumentsProperties(Models.Evcat row)
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
				Model = Models.Evcat.Find(Navigation.GetStrValue("evcat"), m_userContext, "FEVCAT");
				if (Model == null)
				{
					Model = new Models.Evcat(m_userContext) { Identifier = "FEVCAT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("evcat");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Evcat___pessoname____(qs, lazyLoad);
			Load_Evcat___cate1category(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EVCAT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EVCAT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EVCAT]/
		public override void Save()
		{

			try { Model = Models.Evcat.Find(Navigation.GetStrValue("evcat"), m_userContext, "FEVCAT"); }
			finally { if (Model == null) Model = new Models.Evcat(m_userContext) { Identifier = "FEVCAT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EVCAT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Evcat.Find(Navigation.GetStrValue("evcat"), m_userContext, "FEVCAT"); }
			finally { if (Model == null) Model = new Models.Evcat(m_userContext) { Identifier = "FEVCAT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EVCAT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EVCAT]/
		public override void Destroy(string id)
		{
			Model = Models.Evcat.Find(id, m_userContext, "FEVCAT");
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
		/// TablePessoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Evcat___pessoname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool evcat___pessoname____DoLoad = true;
			CriteriaSet evcat___pessoname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pesso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					evcat___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
					this.ValCodpesso = Navigation.GetStrValue("pesso");
				}
			}

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
				FillDependant_EvcatTablePessoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
				return;
			}

			if (evcat___pessoname____DoLoad)
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
				evcat___pessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ EVCAT_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					evcat___pessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					evcat___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, evcat___pessoname____Conds, fields, offset, numberItems, sorts, "LED_EVCAT___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_EVCAT___PESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_EvcatTablePessoName();

				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_EvcatTablePessoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName];

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
		public void FillDependant_EvcatTablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_EvcatTablePessoName(this.ValCodpesso);
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

		private readonly string[] _fieldsToSerialize_EVCAT___PESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		/// <summary>
		/// TableCate1Category -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Evcat___cate1category(NameValueCollection qs, bool lazyLoad = false)
		{
			bool evcat___cate1categoryDoLoad = true;
			CriteriaSet evcat___cate1categoryConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cate1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					evcat___cate1categoryConds.Equal(CSGenioAcate1.FldCodcateg, Navigation.GetValue("cate1"));
					this.ValCodcateg = Navigation.GetStrValue("cate1");
				}
			}

			TableCate1Category = new TableDBEdit<Models.Cate1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cate1") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_cate1");
					Navigation.CurrentLevel.SetEntry("RETURN_cate1", null);
				}
				FillDependant_EvcatTableCate1Category(lazyLoad);
				//Check if foreignkey comes from history
				TableCate1Category.FilledByHistory = Navigation.CheckFilledByHistory("cate1");
				return;
			}

			if (evcat___cate1categoryDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCate1Category, "sTableCate1Category", "dTableCate1Category", qs, "cate1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcate1.FldCategoria), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCate1Category_tableFilters"]))
					TableCate1Category.TableFilters = bool.Parse(qs["TableCate1Category_tableFilters"]);
				else
					TableCate1Category.TableFilters = false;

				query = qs["qTableCate1Category"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcate1.FldCategoria, query + "%");
				}
				evcat___cate1categoryConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCate1Category"] != null ? qs["pTableCate1Category"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria, CSGenioAcate1.FldAbbreviation, CSGenioAcate1.FldZzstate };

// USE /[MANUAL GQT OVERRQ EVCAT_CATE1CATEGORY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cate1", FormMode.New) || Navigation.checkFormMode("cate1", FormMode.Duplicate))
					evcat___cate1categoryConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcate1.FldZzstate, 0)
						.Equal(CSGenioAcate1.FldCodcateg, Navigation.GetStrValue("cate1")));
				else
					evcat___cate1categoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcate1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cate1", "categoria");
				ListingMVC<CSGenioAcate1> listing = Models.ModelBase.Where<CSGenioAcate1>(m_userContext, false, evcat___cate1categoryConds, fields, offset, numberItems, sorts, "LED_EVCAT___CATE1CATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCate1Category.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCate1Category.Query = query;
				TableCate1Category.Elements = listing.RowsForViewModel<GenioMVC.Models.Cate1>((r) => new GenioMVC.Models.Cate1(m_userContext, r, true, _fieldsToSerialize_EVCAT___CATE1CATEGORY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cate1") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_cate1");
					Navigation.CurrentLevel.SetEntry("RETURN_cate1", null);
				}

				TableCate1Category.List = new SelectList(TableCate1Category.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
				FillDependant_EvcatTableCate1Category();

				//Check if foreignkey comes from history
				TableCate1Category.FilledByHistory = Navigation.CheckFilledByHistory("cate1");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCate1Category (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cate1</param>
		public ConcurrentDictionary<string, object> GetDependant_EvcatTableCate1Category(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria];

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

			CSGenioAcate1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcate1.FldCodcateg, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCate1Category (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EvcatTableCate1Category(bool lazyLoad = false)
		{
			var row = GetDependant_EvcatTableCate1Category(this.ValCodcateg);
			try
			{

				// Fill List fields
				this.ValCodcateg = ViewModelConversion.ToString(row["cate1.codcateg"]);
				TableCate1Category.Value = (string)row["cate1.categoria"];
				if (GlobalFunctions.emptyG(this.ValCodcateg) == 1)
				{
					this.ValCodcateg = "";
					TableCate1Category.Value = "";
					Navigation.ClearValue("cate1");
				}
				else if (lazyLoad)
				{
					TableCate1Category.SetPagination(1, 0, false, false, 1);
					TableCate1Category.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcateg),
							Text = Convert.ToString(TableCate1Category.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcateg);
				}

				TableCate1Category.Selected = this.ValCodcateg;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCate1Category): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EVCAT___CATE1CATEGORY = ["Cate1", "Cate1.ValCodcateg", "Cate1.ValZzstate", "Cate1.ValCategoria", "Cate1.ValAbbreviation"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"evcat.since" => ViewModelConversion.ToDateTime(modelValue),
				"evcat.until" => ViewModelConversion.ToDateTime(modelValue),
				"evcat.untilman" => ViewModelConversion.ToDateTime(modelValue),
				"evcat.fimperio" => ViewModelConversion.ToDateTime(modelValue),
				"evcat.observat" => ViewModelConversion.ToString(modelValue),
				"evcat.codcateg" => ViewModelConversion.ToString(modelValue),
				"evcat.codpesso" => ViewModelConversion.ToString(modelValue),
				"evcat.codprogr" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"cate1.codcateg" => ViewModelConversion.ToString(modelValue),
				"cate1.categoria" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EVCAT]/

		#endregion
	}
}
