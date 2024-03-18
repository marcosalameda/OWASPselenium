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

namespace GenioMVC.ViewModels.Pesso
{
	public class Pessosep_ViewModel : FormViewModel<Models.Pesso>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Employee No." | Type: "N"
		/// </summary>
		public decimal? ValIdfuncio { get; set; }

		/// <summary>
		/// Title: "Name:" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Birth" | Type: "D"
		/// </summary>
		public DateTime? ValDtnascim { get; set; }

		/// <summary>
		/// Title: "Gender" | Type: "AC"
		/// </summary>
		public string ValGender { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }

		/// <summary>
		/// Title: "Intern" | Type: "L"
		/// </summary>
		public bool ValInterna { get; set; }

		/// <summary>
		/// Title: "External" | Type: "L"
		/// </summary>
		public bool ValExterna { get; set; }

		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Categ> TableCategCategory { get; set; }

		/// <summary>
		/// Title: "Since" | Type: "D"
		/// </summary>
		public DateTime? ValDtultcat { get; set; }

		/// <summary>
		/// Title: "Designation" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }

		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }

		/// <summary>
		/// Title: "Email:" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValPhotogra { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Designation" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodpaise { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }

		/// <summary>
		/// Title: "Category" | Type: "CE"
		/// </summary>
		public string ValCodcateg { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpesso { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pessosep_ViewModel() : base(null!) { }

		public Pessosep_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPESSOSEP", nestedForm) { }

		public Pessosep_ViewModel(UserContext userContext, Models.Pesso row, bool nestedForm = false) : base(userContext, "FPESSOSEP", row, nestedForm) { }

		public Pessosep_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, userContext, "FPESSOSEP", fieldsToQuery: fieldsToLoad);
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
			Models.Pesso model = new Models.Pesso(userContext) { Identifier = "FPESSOSEP" };
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
			Models.Pesso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pessosep) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValIdfuncio = ViewModelConversion.ToNumeric(m.ValIdfuncio);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDtnascim = ViewModelConversion.ToDateTime(m.ValDtnascim);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValInterna = ViewModelConversion.ToLogic(m.ValInterna);
				ValExterna = ViewModelConversion.ToLogic(m.ValExterna);
				ValDtultcat = ViewModelConversion.ToDateTime(m.ValDtultcat);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodpaise = ViewModelConversion.ToString(m.ValCodpaise);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pessosep) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pessosep) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValInterna = ViewModelConversion.ToLogic(ValInterna);
				m.ValExterna = ViewModelConversion.ToLogic(ValExterna);
				m.ValDtultcat = ViewModelConversion.ToDateTime(ValDtultcat);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpaise = ViewModelConversion.ToString(ValCodpaise);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pessosep) to Model (Pesso) - Error during mapping");
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSOSEP");
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

			Model.Identifier = "FPESSOSEP";
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

		protected override void LoadDocumentsProperties(Models.Pesso row)
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSOSEP");
				if (Model == null)
				{
					Model = new Models.Pesso(m_userContext) { Identifier = "FPESSOSEP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pessosepcategcategory(qs, lazyLoad);
			Load_Pessos00cmpnydesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESSOSEP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESSOSEP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.NAME_23841, ValName, 85);
			validator.Required("ValName", Resources.Resources.NAME_23841, ValName);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL_44228, ValEmail, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PESSOSEP]/
		public override void Save()
		{

			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSOSEP"); }
			finally { if (Model == null) Model = new Models.Pesso(m_userContext) { Identifier = "FPESSOSEP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSOSEP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSOSEP"); }
			finally { if (Model == null) Model = new Models.Pesso(m_userContext) { Identifier = "FPESSOSEP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSOSEP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSOSEP]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, m_userContext, "FPESSOSEP");
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
		/// TableCategCategory -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pessosepcategcategory(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pessosepcategcategoryDoLoad = true;
			CriteriaSet pessosepcategcategoryConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("categ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pessosepcategcategoryConds.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetValue("categ"));
					this.ValCodcateg = Navigation.GetStrValue("categ");
				}
			}

			TableCategCategory = new TableDBEdit<Models.Categ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}
				FillDependant_PessosepTableCategCategory(lazyLoad);
				//Check if foreignkey comes from history
				TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
				return;
			}

			if (pessosepcategcategoryDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCategCategory, "sTableCategCategory", "dTableCategCategory", qs, "categ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldCategoria), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldAbbreviation), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCategCategory_tableFilters"]))
					TableCategCategory.TableFilters = bool.Parse(qs["TableCategCategory_tableFilters"]);
				else
					TableCategCategory.TableFilters = false;

				query = qs["qTableCategCategory"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcateg.FldCategoria, query + "%");
				}
				pessosepcategcategoryConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategCategory"] != null ? qs["pTableCategCategory"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioAcateg.FldAbbreviation, CSGenioAcateg.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSOSEP_CATEGCATEGORY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("categ", FormMode.New) || Navigation.checkFormMode("categ", FormMode.Duplicate))
					pessosepcategcategoryConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcateg.FldZzstate, 0)
						.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetStrValue("categ")));
				else
					pessosepcategcategoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcateg.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("categ", "categoria");
				ListingMVC<CSGenioAcateg> listing = Models.ModelBase.Where<CSGenioAcateg>(m_userContext, false, pessosepcategcategoryConds, fields, offset, numberItems, sorts, "LED_PESSOSEPCATEGCATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategCategory.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategCategory.Query = query;
				TableCategCategory.Elements = listing.RowsForViewModel<GenioMVC.Models.Categ>((r) => new GenioMVC.Models.Categ(m_userContext, r, true, _fieldsToSerialize_PESSOSEPCATEGCATEGORY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}

				TableCategCategory.List = new SelectList(TableCategCategory.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
				FillDependant_PessosepTableCategCategory();

				//Check if foreignkey comes from history
				TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategCategory (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Categ</param>
		public ConcurrentDictionary<string, object> GetDependant_PessosepTableCategCategory(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria];

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

			CSGenioAcateg tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcateg.FldCodcateg, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCategCategory (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PessosepTableCategCategory(bool lazyLoad = false)
		{
			var row = GetDependant_PessosepTableCategCategory(this.ValCodcateg);
			try
			{

				// Fill List fields
				this.ValCodcateg = ViewModelConversion.ToString(row["categ.codcateg"]);
				TableCategCategory.Value = (string)row["categ.categoria"];
				if (GlobalFunctions.emptyG(this.ValCodcateg) == 1)
				{
					this.ValCodcateg = "";
					TableCategCategory.Value = "";
					Navigation.ClearValue("categ");
				}
				else if (lazyLoad)
				{
					TableCategCategory.SetPagination(1, 0, false, false, 1);
					TableCategCategory.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcateg),
							Text = Convert.ToString(TableCategCategory.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcateg);
				}

				TableCategCategory.Selected = this.ValCodcateg;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategCategory): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESSOSEPCATEGCATEGORY = ["Categ", "Categ.ValCodcateg", "Categ.ValZzstate", "Categ.ValCategoria", "Categ.ValAbbreviation"];

		/// <summary>
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pessos00cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pessos00cmpnydesignatDoLoad = true;
			CriteriaSet pessos00cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pessos00cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
					this.ValCodempre = Navigation.GetStrValue("cmpny");
				}
			}

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
				FillDependant_Pessos00TableCmpnyDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
				return;
			}

			if (pessos00cmpnydesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldAcronym), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldNif), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldTelephon), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldEmail), SortOrder.Ascending));

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
				pessos00cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail, CSGenioAcmpny.FldLogo, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSOS00_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					pessos00cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					pessos00cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, pessos00cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESSOS00CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_PESSOS00CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_Pessos00TableCmpnyDesignat();

				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_Pessos00TableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];

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
		public void FillDependant_Pessos00TableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_Pessos00TableCmpnyDesignat(this.ValCodempre);
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

		private readonly string[] _fieldsToSerialize_PESSOS00CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat", "Cmpny.ValAcronym", "Cmpny.ValNif", "Cmpny.ValTelephon", "Cmpny.ValEmail", "Cmpny.ValLogo"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pesso.idfuncio" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"pesso.dtnascim" => ViewModelConversion.ToDateTime(modelValue),
				"pesso.gender" => ViewModelConversion.ToString(modelValue),
				"pesso.interna" => ViewModelConversion.ToLogic(modelValue),
				"pesso.externa" => ViewModelConversion.ToLogic(modelValue),
				"pesso.dtultcat" => ViewModelConversion.ToDateTime(modelValue),
				"pesso.telephon" => ViewModelConversion.ToString(modelValue),
				"pesso.email" => ViewModelConversion.ToString(modelValue),
				"pesso.photogra" => ViewModelConversion.ToImage(modelValue),
				"pesso.codempre" => ViewModelConversion.ToString(modelValue),
				"pesso.codpaise" => ViewModelConversion.ToString(modelValue),
				"pesso.codcntry" => ViewModelConversion.ToString(modelValue),
				"pesso.codregia" => ViewModelConversion.ToString(modelValue),
				"pesso.codcateg" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"categ.codcateg" => ViewModelConversion.ToString(modelValue),
				"categ.categoria" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSOSEP]/

		#endregion
	}
}
