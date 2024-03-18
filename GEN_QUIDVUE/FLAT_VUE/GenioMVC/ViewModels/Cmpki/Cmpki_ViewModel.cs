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

namespace GenioMVC.ViewModels.Cmpki
{
	public class Cmpki_ViewModel : FormViewModel<Models.Cmpki>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }

		/// <summary>
		/// Title: "Order" | Type: "N"
		/// </summary>
		public decimal? ValOrder { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tpeq1> TableTpeq1Tipoequi { get; set; }

		/// <summary>
		/// Title: "Quantity:" | Type: "N"
		/// </summary>
		public decimal? ValQuantida { get; set; }

		/// <summary>
		/// Title: "Code" | Type: "C"
		/// </summary>
		public string ValCode { get; set; }

		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }

		/// <summary>
		/// Title: "Site" | Type: "C"
		/// </summary>
		public string ValUrl { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpeq1 { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodcmpki { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Cmpki_ViewModel() : base(null!) { }

		public Cmpki_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCMPKI", nestedForm) { }

		public Cmpki_ViewModel(UserContext userContext, Models.Cmpki row, bool nestedForm = false) : base(userContext, "FCMPKI", row, nestedForm) { }

		public Cmpki_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("cmpki", id);
			Model = Models.Cmpki.Find(id, userContext, "FCMPKI", fieldsToQuery: fieldsToLoad);
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
			Models.Cmpki model = new Models.Cmpki(userContext) { Identifier = "FCMPKI" };
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
			Models.Cmpki model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cmpki m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpki) to ViewModel (Cmpki) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
				ValCode = ViewModelConversion.ToString(m.ValCode);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValUrl = ViewModelConversion.ToString(m.ValUrl);
				ValCodtpeq1 = ViewModelConversion.ToString(m.ValCodtpeq1);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodcmpki = ViewModelConversion.ToString(m.ValCodcmpki);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpki) to ViewModel (Cmpki) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cmpki m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cmpki) to Model (Cmpki) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValCode = ViewModelConversion.ToString(ValCode);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValUrl = ViewModelConversion.ToString(ValUrl);
				m.ValCodtpeq1 = ViewModelConversion.ToString(ValCodtpeq1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodcmpki = ViewModelConversion.ToString(ValCodcmpki);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cmpki) to Model (Cmpki) - Error during mapping");
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
				Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), m_userContext, "FCMPKI");
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

			Model.Identifier = "FCMPKI";
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

		protected override void LoadDocumentsProperties(Models.Cmpki row)
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
				Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), m_userContext, "FCMPKI");
				if (Model == null)
				{
					Model = new Models.Cmpki(m_userContext) { Identifier = "FCMPKI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpki");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Cmpki___tpequtipoequi(qs, lazyLoad);
			Load_Cmpki___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CMPKI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CMPKI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValCode", Resources.Resources.CODE49225, ValCode, 10);
			validator.StringLength("ValUrl", Resources.Resources.SITE06486, ValUrl, 250);
			validator.Hyperlink(Resources.Resources.SITE06486, ValUrl);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CMPKI]/
		public override void Save()
		{

			try { Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), m_userContext, "FCMPKI"); }
			finally { if (Model == null) Model = new Models.Cmpki(m_userContext) { Identifier = "FCMPKI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CMPKI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), m_userContext, "FCMPKI"); }
			finally { if (Model == null) Model = new Models.Cmpki(m_userContext) { Identifier = "FCMPKI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CMPKI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CMPKI]/
		public override void Destroy(string id)
		{
			Model = Models.Cmpki.Find(id, m_userContext, "FCMPKI");
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
		/// TableTpequTipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Cmpki___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool cmpki___tpequtipoequiDoLoad = true;
			CriteriaSet cmpki___tpequtipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpequ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					cmpki___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
					this.ValCodtpequ = Navigation.GetStrValue("tpequ");
				}
			}

			TableTpequTipoequi = new TableDBEdit<Models.Tpequ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
				FillDependant_CmpkiTableTpequTipoequi(lazyLoad);
				//Check if foreignkey comes from history
				TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
				return;
			}

			if (cmpki___tpequtipoequiDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTipoequi), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
					TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
				else
					TableTpequTipoequi.TableFilters = false;

				query = qs["qTableTpequTipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
				}
				cmpki___tpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ CMPKI_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					cmpki___tpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					cmpki___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, cmpki___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_CMPKI___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_CMPKI___TPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_CmpkiTableTpequTipoequi();

				//Check if foreignkey comes from history
				TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_CmpkiTableTpequTipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi];

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

			CSGenioAtpequ tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_CmpkiTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_CmpkiTableTpequTipoequi(this.ValCodtpequ);
			try
			{

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
				TableTpequTipoequi.Value = (string)row["tpequ.tipoequi"];
				if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
					TableTpequTipoequi.Value = "";
					Navigation.ClearValue("tpequ");
				}
				else if (lazyLoad)
				{
					TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
					TableTpequTipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpequTipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpequTipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CMPKI___TPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi"];

		/// <summary>
		/// TableTpeq1Tipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Cmpki___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool cmpki___tpeq1tipoequiDoLoad = true;
			CriteriaSet cmpki___tpeq1tipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpeq1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					cmpki___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
					this.ValCodtpeq1 = Navigation.GetStrValue("tpeq1");
				}
			}

			TableTpeq1Tipoequi = new TableDBEdit<Models.Tpeq1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpeq1 = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}
				FillDependant_CmpkiTableTpeq1Tipoequi(lazyLoad);
				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
				return;
			}

			if (cmpki___tpeq1tipoequiDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpeq1Tipoequi, "sTableTpeq1Tipoequi", "dTableTpeq1Tipoequi", qs, "tpeq1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpeq1Tipoequi_tableFilters"]))
					TableTpeq1Tipoequi.TableFilters = bool.Parse(qs["TableTpeq1Tipoequi_tableFilters"]);
				else
					TableTpeq1Tipoequi.TableFilters = false;

				query = qs["qTableTpeq1Tipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpeq1.FldTipoequi, query + "%");
				}
				cmpki___tpeq1tipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ CMPKI_TPEQ1TIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
					cmpki___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpeq1.FldZzstate, 0)
						.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
				else
					cmpki___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tipoequi");
				ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(m_userContext, false, cmpki___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_CMPKI___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpeq1Tipoequi.Query = query;
				TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(m_userContext, r, true, _fieldsToSerialize_CMPKI___TPEQ1TIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpeq1 = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpeq1), "Value", "Text", this.ValCodtpeq1);
				FillDependant_CmpkiTableTpeq1Tipoequi();

				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpeq1</param>
		public ConcurrentDictionary<string, object> GetDependant_CmpkiTableTpeq1Tipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi];

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

			CSGenioAtpeq1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpeq1.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpeq1Tipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_CmpkiTableTpeq1Tipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_CmpkiTableTpeq1Tipoequi(this.ValCodtpeq1);
			try
			{

				// Fill List fields
				this.ValCodtpeq1 = ViewModelConversion.ToString(row["tpeq1.codtpequ"]);
				TableTpeq1Tipoequi.Value = (string)row["tpeq1.tipoequi"];
				if (GlobalFunctions.emptyG(this.ValCodtpeq1) == 1)
				{
					this.ValCodtpeq1 = "";
					TableTpeq1Tipoequi.Value = "";
					Navigation.ClearValue("tpeq1");
				}
				else if (lazyLoad)
				{
					TableTpeq1Tipoequi.SetPagination(1, 0, false, false, 1);
					TableTpeq1Tipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpeq1),
							Text = Convert.ToString(TableTpeq1Tipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpeq1);
				}

				TableTpeq1Tipoequi.Selected = this.ValCodtpeq1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpeq1Tipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CMPKI___TPEQ1TIPOEQUI = ["Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"cmpki.order" => ViewModelConversion.ToNumeric(modelValue),
				"cmpki.quantida" => ViewModelConversion.ToNumeric(modelValue),
				"cmpki.code" => ViewModelConversion.ToString(modelValue),
				"cmpki.descript" => ViewModelConversion.ToString(modelValue),
				"cmpki.url" => ViewModelConversion.ToString(modelValue),
				"cmpki.codtpeq1" => ViewModelConversion.ToString(modelValue),
				"cmpki.codtpequ" => ViewModelConversion.ToString(modelValue),
				"cmpki.codcmpki" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"tpeq1.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpeq1.tipoequi" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CMPKI]/

		#endregion
	}
}
