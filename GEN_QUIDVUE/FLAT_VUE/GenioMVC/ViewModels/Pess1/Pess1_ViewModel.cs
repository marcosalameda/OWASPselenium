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

namespace GenioMVC.ViewModels.Pess1
{
	public class Pess1_ViewModel : FormViewModel<Models.Pess1>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Company:" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }

		/// <summary>
		/// Title: "Interested" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Stake> TableStakeDesignat { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

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
		/// Title: "Birth" | Type: "D"
		/// </summary>
		public DateTime? ValDtnascim { get; set; }

		/// <summary>
		/// Title: "Employee No." | Type: "N"
		/// </summary>
		public decimal? ValIdfuncio { get; set; }

		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }

		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		/// <summary>
		/// Title: "Email (confirm)" | Type: "C"
		/// </summary>
		public string ValEmail2 { get; set; }

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValPhotogra { get; set; }

		/// <summary>
		/// Title: "Since" | Type: "D"
		/// </summary>
		public DateTime? ValDtultcat { get; set; }

		/// <summary>
		/// Title: "External" | Type: "L"
		/// </summary>
		public bool ValExterna { get; set; }

		/// <summary>
		/// Title: "Intern" | Type: "L"
		/// </summary>
		public bool ValInterna { get; set; }

		/// <summary>
		/// Title: "Age" | Type: "N"
		/// </summary>
		public decimal? ValIdade { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodcateg { get; set; }

		/// <summary>
		/// Title: "Company:" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }

		/// <summary>
		/// Title: "Interested" | Type: "CE"
		/// </summary>
		public string ValCodparte { get; set; }
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
		public Pess1_ViewModel() : base(null!) { }

		public Pess1_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPESS1", nestedForm) { }

		public Pess1_ViewModel(UserContext userContext, Models.Pess1 row, bool nestedForm = false) : base(userContext, "FPESS1", row, nestedForm) { }

		public Pess1_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pess1", id);
			Model = Models.Pess1.Find(id, userContext, "FPESS1", fieldsToQuery: fieldsToLoad);
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
			Models.Pess1 model = new Models.Pess1(userContext) { Identifier = "FPESS1" };
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
			Models.Pess1 model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pess1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pess1) to ViewModel (Pess1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValDtnascim = ViewModelConversion.ToDateTime(m.ValDtnascim);
				ValIdfuncio = ViewModelConversion.ToNumeric(m.ValIdfuncio);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValEmail2 = ViewModelConversion.ToString(m.ValEmail2);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValDtultcat = ViewModelConversion.ToDateTime(m.ValDtultcat);
				ValExterna = ViewModelConversion.ToLogic(m.ValExterna);
				ValInterna = ViewModelConversion.ToLogic(m.ValInterna);
				ValIdade = ViewModelConversion.ToNumeric(m.ValIdade);
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodparte = ViewModelConversion.ToString(m.ValCodparte);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pess1) to ViewModel (Pess1) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pess1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pess1) to Model (Pess1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValEmail2 = ViewModelConversion.ToString(ValEmail2);
				m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValDtultcat = ViewModelConversion.ToDateTime(ValDtultcat);
				m.ValExterna = ViewModelConversion.ToLogic(ValExterna);
				m.ValInterna = ViewModelConversion.ToLogic(ValInterna);
				m.ValIdade = ViewModelConversion.ToNumeric(ValIdade);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodparte = ViewModelConversion.ToString(ValCodparte);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pess1) to Model (Pess1) - Error during mapping");
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
				Model = Models.Pess1.Find(Navigation.GetStrValue("pess1"), m_userContext, "FPESS1");
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

			Model.Identifier = "FPESS1";
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

		protected override void LoadDocumentsProperties(Models.Pess1 row)
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
				Model = Models.Pess1.Find(Navigation.GetStrValue("pess1"), m_userContext, "FPESS1");
				if (Model == null)
				{
					Model = new Models.Pess1(m_userContext) { Identifier = "FPESS1" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pess1");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pess1___cmpnydesignat(qs, lazyLoad);
			Load_Pess1___stakedesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESS1]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESS1]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 85);
			validator.Required("ValName", Resources.Resources.NAME31974, ValName);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL25170, ValEmail, 254);
			validator.StringLength("ValEmail2", Resources.Resources.EMAIL__CONFIRM_56391, ValEmail2, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PESS1]/
		public override void Save()
		{

			try { Model = Models.Pess1.Find(Navigation.GetStrValue("pess1"), m_userContext, "FPESS1"); }
			finally { if (Model == null) Model = new Models.Pess1(m_userContext) { Identifier = "FPESS1" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESS1]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pess1.Find(Navigation.GetStrValue("pess1"), m_userContext, "FPESS1"); }
			finally { if (Model == null) Model = new Models.Pess1(m_userContext) { Identifier = "FPESS1" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESS1]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESS1]/
		public override void Destroy(string id)
		{
			Model = Models.Pess1.Find(id, m_userContext, "FPESS1");
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
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pess1___cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pess1___cmpnydesignatDoLoad = true;
			CriteriaSet pess1___cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pess1___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
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
				FillDependant_Pess1TableCmpnyDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
				return;
			}

			if (pess1___cmpnydesignatDoLoad)
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
				pess1___cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESS1_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					pess1___cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					pess1___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, pess1___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESS1___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_PESS1___CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_Pess1TableCmpnyDesignat();

				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_Pess1TableCmpnyDesignat(string PKey)
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
		public void FillDependant_Pess1TableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_Pess1TableCmpnyDesignat(this.ValCodempre);
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

		private readonly string[] _fieldsToSerialize_PESS1___CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		/// <summary>
		/// TableStakeDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pess1___stakedesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pess1___stakedesignatDoLoad = true;
			CriteriaSet pess1___stakedesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("stake", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pess1___stakedesignatConds.Equal(CSGenioAstake.FldCodparte, Navigation.GetValue("stake"));
					this.ValCodparte = Navigation.GetStrValue("stake");
				}
			}

			TableStakeDesignat = new TableDBEdit<Models.Stake>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_stake") != null)
				{
					this.ValCodparte = Navigation.GetStrValue("RETURN_stake");
					Navigation.CurrentLevel.SetEntry("RETURN_stake", null);
				}
				FillDependant_Pess1TableStakeDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableStakeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("stake");
				return;
			}

			if (pess1___stakedesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableStakeDesignat, "sTableStakeDesignat", "dTableStakeDesignat", qs, "stake");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAstake.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableStakeDesignat_tableFilters"]))
					TableStakeDesignat.TableFilters = bool.Parse(qs["TableStakeDesignat_tableFilters"]);
				else
					TableStakeDesignat.TableFilters = false;

				query = qs["qTableStakeDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAstake.FldDesignat, query + "%");
				}
				pess1___stakedesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableStakeDesignat"] != null ? qs["pTableStakeDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAstake.FldCodparte, CSGenioAstake.FldDesignat, CSGenioAstake.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESS1_STAKEDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("stake", FormMode.New) || Navigation.checkFormMode("stake", FormMode.Duplicate))
					pess1___stakedesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAstake.FldZzstate, 0)
						.Equal(CSGenioAstake.FldCodparte, Navigation.GetStrValue("stake")));
				else
					pess1___stakedesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAstake.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("stake", "designat");
				ListingMVC<CSGenioAstake> listing = Models.ModelBase.Where<CSGenioAstake>(m_userContext, false, pess1___stakedesignatConds, fields, offset, numberItems, sorts, "LED_PESS1___STAKEDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableStakeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableStakeDesignat.Query = query;
				TableStakeDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Stake>((r) => new GenioMVC.Models.Stake(m_userContext, r, true, _fieldsToSerialize_PESS1___STAKEDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_stake") != null)
				{
					this.ValCodparte = Navigation.GetStrValue("RETURN_stake");
					Navigation.CurrentLevel.SetEntry("RETURN_stake", null);
				}

				TableStakeDesignat.List = new SelectList(TableStakeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodparte,  x => x.ValCodparte == this.ValCodparte), "Value", "Text", this.ValCodparte);
				FillDependant_Pess1TableStakeDesignat();

				//Check if foreignkey comes from history
				TableStakeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("stake");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableStakeDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Stake</param>
		public ConcurrentDictionary<string, object> GetDependant_Pess1TableStakeDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAstake.FldCodparte, CSGenioAstake.FldDesignat];

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

			CSGenioAstake tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAstake.FldCodparte, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableStakeDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Pess1TableStakeDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_Pess1TableStakeDesignat(this.ValCodparte);
			try
			{

				// Fill List fields
				this.ValCodparte = ViewModelConversion.ToString(row["stake.codparte"]);
				TableStakeDesignat.Value = (string)row["stake.designat"];
				if (GlobalFunctions.emptyG(this.ValCodparte) == 1)
				{
					this.ValCodparte = "";
					TableStakeDesignat.Value = "";
					Navigation.ClearValue("stake");
				}
				else if (lazyLoad)
				{
					TableStakeDesignat.SetPagination(1, 0, false, false, 1);
					TableStakeDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodparte),
							Text = Convert.ToString(TableStakeDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodparte);
				}

				TableStakeDesignat.Selected = this.ValCodparte;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableStakeDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESS1___STAKEDESIGNAT = ["Stake", "Stake.ValCodparte", "Stake.ValZzstate", "Stake.ValDesignat"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				"pess1.gender" => ViewModelConversion.ToString(modelValue),
				"pess1.dtnascim" => ViewModelConversion.ToDateTime(modelValue),
				"pess1.idfuncio" => ViewModelConversion.ToNumeric(modelValue),
				"pess1.telephon" => ViewModelConversion.ToString(modelValue),
				"pess1.email" => ViewModelConversion.ToString(modelValue),
				"pess1.email2" => ViewModelConversion.ToString(modelValue),
				"pess1.photogra" => ViewModelConversion.ToImage(modelValue),
				"pess1.dtultcat" => ViewModelConversion.ToDateTime(modelValue),
				"pess1.externa" => ViewModelConversion.ToLogic(modelValue),
				"pess1.interna" => ViewModelConversion.ToLogic(modelValue),
				"pess1.idade" => ViewModelConversion.ToNumeric(modelValue),
				"pess1.codcateg" => ViewModelConversion.ToString(modelValue),
				"pess1.codempre" => ViewModelConversion.ToString(modelValue),
				"pess1.codparte" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"stake.codparte" => ViewModelConversion.ToString(modelValue),
				"stake.designat" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESS1]/

		#endregion
	}
}
