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

namespace GenioMVC.ViewModels.Conta
{
	public class Conta_ViewModel : FormViewModel<Models.Conta>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Name:" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }

		/// <summary>
		/// Title: "Genre" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Genre> TableGenreGender { get; set; }

		/// <summary>
		/// Title: "Contact Type:" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tpcon> TableTpconTipocont { get; set; }

		/// <summary>
		/// Title: "Contact" | Type: "C"
		/// </summary>
		public string ValContacto { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Genre" | Type: "CE"
		/// </summary>
		public string ValCodgenre { get; set; }

		/// <summary>
		/// Title: "Name:" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }

		/// <summary>
		/// Title: "Contact Type:" | Type: "CE"
		/// </summary>
		public string ValCodtpcon { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodconta { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Conta_ViewModel() : base(null!) { }

		public Conta_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCONTA", nestedForm) { }

		public Conta_ViewModel(UserContext userContext, Models.Conta row, bool nestedForm = false) : base(userContext, "FCONTA", row, nestedForm) { }

		public Conta_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("conta", id);
			Model = Models.Conta.Find(id, userContext, "FCONTA", fieldsToQuery: fieldsToLoad);
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
			Models.Conta model = new Models.Conta(userContext) { Identifier = "FCONTA" };
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
			Models.Conta model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Conta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Conta) to ViewModel (Conta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValContacto = ViewModelConversion.ToString(m.ValContacto);
				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodtpcon = ViewModelConversion.ToString(m.ValCodtpcon);
				ValCodconta = ViewModelConversion.ToString(m.ValCodconta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Conta) to ViewModel (Conta) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Conta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Conta) to Model (Conta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValContacto = ViewModelConversion.ToString(ValContacto);
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodtpcon = ViewModelConversion.ToString(ValCodtpcon);
				m.ValCodconta = ViewModelConversion.ToString(ValCodconta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Conta) to Model (Conta) - Error during mapping");
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
				Model = Models.Conta.Find(Navigation.GetStrValue("conta"), m_userContext, "FCONTA");
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

			Model.Identifier = "FCONTA";
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

		protected override void LoadDocumentsProperties(Models.Conta row)
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
				Model = Models.Conta.Find(Navigation.GetStrValue("conta"), m_userContext, "FCONTA");
				if (Model == null)
				{
					Model = new Models.Conta(m_userContext) { Identifier = "FCONTA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("conta");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Conta___pessoname____(qs, lazyLoad);
			Load_Conta___genregender__(qs, lazyLoad);
			Load_Conta___tpcontipocont(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CONTA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CONTA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValContacto", Resources.Resources.CONTACT59247, ValContacto, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CONTA]/
		public override void Save()
		{

			try { Model = Models.Conta.Find(Navigation.GetStrValue("conta"), m_userContext, "FCONTA"); }
			finally { if (Model == null) Model = new Models.Conta(m_userContext) { Identifier = "FCONTA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CONTA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Conta.Find(Navigation.GetStrValue("conta"), m_userContext, "FCONTA"); }
			finally { if (Model == null) Model = new Models.Conta(m_userContext) { Identifier = "FCONTA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CONTA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CONTA]/
		public override void Destroy(string id)
		{
			Model = Models.Conta.Find(id, m_userContext, "FCONTA");
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
		public void Load_Conta___pessoname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool conta___pessoname____DoLoad = true;
			CriteriaSet conta___pessoname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pesso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					conta___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
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
				FillDependant_ContaTablePessoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
				return;
			}

			if (conta___pessoname____DoLoad)
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
				conta___pessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					conta___pessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					conta___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, conta___pessoname____Conds, fields, offset, numberItems, sorts, "LED_CONTA___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_CONTA___PESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_ContaTablePessoName();

				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_ContaTablePessoName(string PKey)
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
		public void FillDependant_ContaTablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_ContaTablePessoName(this.ValCodpesso);
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

		private readonly string[] _fieldsToSerialize_CONTA___PESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		/// <summary>
		/// TableGenreGender -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Conta___genregender__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool conta___genregender__DoLoad = true;
			CriteriaSet conta___genregender__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("genre", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					conta___genregender__Conds.Equal(CSGenioAgenre.FldCodgenre, Navigation.GetValue("genre"));
					this.ValCodgenre = Navigation.GetStrValue("genre");
				}
			}

			TableGenreGender = new TableDBEdit<Models.Genre>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}
				FillDependant_ContaTableGenreGender(lazyLoad);
				//Check if foreignkey comes from history
				TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
				return;
			}

			if (conta___genregender__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableGenreGender, "sTableGenreGender", "dTableGenreGender", qs, "genre");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgenre.FldGender), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGenreGender_tableFilters"]))
					TableGenreGender.TableFilters = bool.Parse(qs["TableGenreGender_tableFilters"]);
				else
					TableGenreGender.TableFilters = false;

				query = qs["qTableGenreGender"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgenre.FldGender, query + "%");
				}
				conta___genregender__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGenreGender"] != null ? qs["pTableGenreGender"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender, CSGenioAgenre.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_GENREGENDER]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("genre", FormMode.New) || Navigation.checkFormMode("genre", FormMode.Duplicate))
					conta___genregender__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgenre.FldZzstate, 0)
						.Equal(CSGenioAgenre.FldCodgenre, Navigation.GetStrValue("genre")));
				else
					conta___genregender__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgenre.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("genre", "gender");
				ListingMVC<CSGenioAgenre> listing = Models.ModelBase.Where<CSGenioAgenre>(m_userContext, false, conta___genregender__Conds, fields, offset, numberItems, sorts, "LED_CONTA___GENREGENDER__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGenreGender.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGenreGender.Query = query;
				TableGenreGender.Elements = listing.RowsForViewModel<GenioMVC.Models.Genre>((r) => new GenioMVC.Models.Genre(m_userContext, r, true, _fieldsToSerialize_CONTA___GENREGENDER__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}

				TableGenreGender.List = new SelectList(TableGenreGender.Elements.ToSelectList(x => x.ValGender, x => x.ValCodgenre,  x => x.ValCodgenre == this.ValCodgenre), "Value", "Text", this.ValCodgenre);
				FillDependant_ContaTableGenreGender();

				//Check if foreignkey comes from history
				TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGenreGender (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Genre</param>
		public ConcurrentDictionary<string, object> GetDependant_ContaTableGenreGender(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender];

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

			CSGenioAgenre tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgenre.FldCodgenre, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGenreGender (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ContaTableGenreGender(bool lazyLoad = false)
		{
			var row = GetDependant_ContaTableGenreGender(this.ValCodgenre);
			try
			{

				// Fill List fields
				this.ValCodgenre = ViewModelConversion.ToString(row["genre.codgenre"]);
				TableGenreGender.Value = (string)row["genre.gender"];
				if (GlobalFunctions.emptyG(this.ValCodgenre) == 1)
				{
					this.ValCodgenre = "";
					TableGenreGender.Value = "";
					Navigation.ClearValue("genre");
				}
				else if (lazyLoad)
				{
					TableGenreGender.SetPagination(1, 0, false, false, 1);
					TableGenreGender.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodgenre),
							Text = Convert.ToString(TableGenreGender.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodgenre);
				}

				TableGenreGender.Selected = this.ValCodgenre;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGenreGender): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CONTA___GENREGENDER__ = ["Genre", "Genre.ValCodgenre", "Genre.ValZzstate", "Genre.ValGender"];

		/// <summary>
		/// TableTpconTipocont -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Conta___tpcontipocont(NameValueCollection qs, bool lazyLoad = false)
		{
			bool conta___tpcontipocontDoLoad = true;
			CriteriaSet conta___tpcontipocontConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpcon", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					conta___tpcontipocontConds.Equal(CSGenioAtpcon.FldCodtpcon, Navigation.GetValue("tpcon"));
					this.ValCodtpcon = Navigation.GetStrValue("tpcon");
				}
			}
			// Limits Generation

			// Area limit
			conta___tpcontipocontDoLoad &= AddCriteriaAreaLimit(conta___tpcontipocontConds, CSGenio.business.CSGenioAgenre.FldCodgenre, "genre", this.ValCodgenre, false);

			TableTpconTipocont = new TableDBEdit<Models.Tpcon>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpcon") != null)
				{
					this.ValCodtpcon = Navigation.GetStrValue("RETURN_tpcon");
					Navigation.CurrentLevel.SetEntry("RETURN_tpcon", null);
				}
				FillDependant_ContaTableTpconTipocont(lazyLoad);
				//Check if foreignkey comes from history
				TableTpconTipocont.FilledByHistory = Navigation.CheckFilledByHistory("tpcon");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodgenre))
				conta___tpcontipocontDoLoad = false;

			if (conta___tpcontipocontDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpconTipocont, "sTableTpconTipocont", "dTableTpconTipocont", qs, "tpcon");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpcon.FldTipocont), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpconTipocont_tableFilters"]))
					TableTpconTipocont.TableFilters = bool.Parse(qs["TableTpconTipocont_tableFilters"]);
				else
					TableTpconTipocont.TableFilters = false;

				query = qs["qTableTpconTipocont"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpcon.FldTipocont, query + "%");
				}
				conta___tpcontipocontConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpconTipocont"] != null ? qs["pTableTpconTipocont"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont, CSGenioAtpcon.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_TPCONTIPOCONT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpcon", FormMode.New) || Navigation.checkFormMode("tpcon", FormMode.Duplicate))
					conta___tpcontipocontConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpcon.FldZzstate, 0)
						.Equal(CSGenioAtpcon.FldCodtpcon, Navigation.GetStrValue("tpcon")));
				else
					conta___tpcontipocontConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpcon.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpcon", "tipocont");
				ListingMVC<CSGenioAtpcon> listing = Models.ModelBase.Where<CSGenioAtpcon>(m_userContext, false, conta___tpcontipocontConds, fields, offset, numberItems, sorts, "LED_CONTA___TPCONTIPOCONT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpconTipocont.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpconTipocont.Query = query;
				TableTpconTipocont.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpcon>((r) => new GenioMVC.Models.Tpcon(m_userContext, r, true, _fieldsToSerialize_CONTA___TPCONTIPOCONT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpcon") != null)
				{
					this.ValCodtpcon = Navigation.GetStrValue("RETURN_tpcon");
					Navigation.CurrentLevel.SetEntry("RETURN_tpcon", null);
				}

				TableTpconTipocont.List = new SelectList(TableTpconTipocont.Elements.ToSelectList(x => x.ValTipocont, x => x.ValCodtpcon,  x => x.ValCodtpcon == this.ValCodtpcon), "Value", "Text", this.ValCodtpcon);
				FillDependant_ContaTableTpconTipocont();

				//Check if foreignkey comes from history
				TableTpconTipocont.FilledByHistory = Navigation.CheckFilledByHistory("tpcon");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpconTipocont (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpcon</param>
		public ConcurrentDictionary<string, object> GetDependant_ContaTableTpconTipocont(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("genre");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAtpcon.FldCodgenre, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAtpcon tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpcon.FldCodtpcon, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpconTipocont (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ContaTableTpconTipocont(bool lazyLoad = false)
		{
			var row = GetDependant_ContaTableTpconTipocont(this.ValCodtpcon);
			try
			{

				// Fill List fields
				this.ValCodtpcon = ViewModelConversion.ToString(row["tpcon.codtpcon"]);
				TableTpconTipocont.Value = (string)row["tpcon.tipocont"];
				if (GlobalFunctions.emptyG(this.ValCodtpcon) == 1)
				{
					this.ValCodtpcon = "";
					TableTpconTipocont.Value = "";
					Navigation.ClearValue("tpcon");
				}
				else if (lazyLoad)
				{
					TableTpconTipocont.SetPagination(1, 0, false, false, 1);
					TableTpconTipocont.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpcon),
							Text = Convert.ToString(TableTpconTipocont.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpcon);
				}

				TableTpconTipocont.Selected = this.ValCodtpcon;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpconTipocont): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CONTA___TPCONTIPOCONT = ["Tpcon", "Tpcon.ValCodtpcon", "Tpcon.ValZzstate", "Tpcon.ValTipocont"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"conta.contacto" => ViewModelConversion.ToString(modelValue),
				"conta.codgenre" => ViewModelConversion.ToString(modelValue),
				"conta.codpesso" => ViewModelConversion.ToString(modelValue),
				"conta.codtpcon" => ViewModelConversion.ToString(modelValue),
				"conta.codconta" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"genre.codgenre" => ViewModelConversion.ToString(modelValue),
				"genre.gender" => ViewModelConversion.ToString(modelValue),
				"tpcon.codtpcon" => ViewModelConversion.ToString(modelValue),
				"tpcon.tipocont" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CONTA]/

		#endregion
	}
}
