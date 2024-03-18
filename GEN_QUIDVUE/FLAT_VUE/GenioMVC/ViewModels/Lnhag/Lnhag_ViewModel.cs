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

namespace GenioMVC.ViewModels.Lnhag
{
	public class Lnhag_ViewModel : FormViewModel<Models.Lnhag>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "No." | Type: "N"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Pedid> TablePedidNrpedido { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tpeq1> TableTpeq1Tipoequi { get; set; }

		/// <summary>
		/// Title: "Quantity" | Type: "N"
		/// </summary>
		public decimal? ValQtdtpequ { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "No." | Type: "CE"
		/// </summary>
		public string ValCodpedid { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodlnhag { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Lnhag_ViewModel() : base(null!) { }

		public Lnhag_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLNHAG", nestedForm) { }

		public Lnhag_ViewModel(UserContext userContext, Models.Lnhag row, bool nestedForm = false) : base(userContext, "FLNHAG", row, nestedForm) { }

		public Lnhag_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("lnhag", id);
			Model = Models.Lnhag.Find(id, userContext, "FLNHAG", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhag model = new Models.Lnhag(userContext) { Identifier = "FLNHAG" };
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
			Models.Lnhag model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lnhag m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhag) to ViewModel (Lnhag) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValQtdtpequ = ViewModelConversion.ToNumeric(m.ValQtdtpequ);
				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodlnhag = ViewModelConversion.ToString(m.ValCodlnhag);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhag) to ViewModel (Lnhag) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lnhag m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhag) to Model (Lnhag) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValQtdtpequ = ViewModelConversion.ToNumeric(ValQtdtpequ);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodlnhag = ViewModelConversion.ToString(ValCodlnhag);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhag) to Model (Lnhag) - Error during mapping");
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
				Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), m_userContext, "FLNHAG");
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

			Model.Identifier = "FLNHAG";
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

		protected override void LoadDocumentsProperties(Models.Lnhag row)
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
				Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), m_userContext, "FLNHAG");
				if (Model == null)
				{
					Model = new Models.Lnhag(m_userContext) { Identifier = "FLNHAG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Lnhag___pedidnrpedido(qs, lazyLoad);
			Load_Lnhag___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHAG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHAG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LNHAG]/
		public override void Save()
		{

			try { Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), m_userContext, "FLNHAG"); }
			finally { if (Model == null) Model = new Models.Lnhag(m_userContext) { Identifier = "FLNHAG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHAG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), m_userContext, "FLNHAG"); }
			finally { if (Model == null) Model = new Models.Lnhag(m_userContext) { Identifier = "FLNHAG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHAG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHAG]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhag.Find(id, m_userContext, "FLNHAG");
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
		/// TablePedidNrpedido -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhag___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhag___pedidnrpedidoDoLoad = true;
			CriteriaSet lnhag___pedidnrpedidoConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pedid", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhag___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, Navigation.GetValue("pedid"));
					this.ValCodpedid = Navigation.GetStrValue("pedid");
				}
			}

			TablePedidNrpedido = new TableDBEdit<Models.Pedid>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}
				FillDependant_LnhagTablePedidNrpedido(lazyLoad);
				//Check if foreignkey comes from history
				TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
				return;
			}

			if (lnhag___pedidnrpedidoDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePedidNrpedido, "sTablePedidNrpedido", "dTablePedidNrpedido", qs, "pedid");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePedidNrpedido_tableFilters"]))
					TablePedidNrpedido.TableFilters = bool.Parse(qs["TablePedidNrpedido_tableFilters"]);
				else
					TablePedidNrpedido.TableFilters = false;

				query = qs["qTablePedidNrpedido"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApedid.FldNrpedido, query + "%");
				}
				lnhag___pedidnrpedidoConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHAG_PEDIDNRPEDIDO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
					lnhag___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApedid.FldZzstate, 0)
						.Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
				else
					lnhag___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
				ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(m_userContext, false, lnhag___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHAG___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePedidNrpedido.Query = query;
				TablePedidNrpedido.Elements = listing.RowsForViewModel<GenioMVC.Models.Pedid>((r) => new GenioMVC.Models.Pedid(m_userContext, r, true, _fieldsToSerialize_LNHAG___PEDIDNRPEDIDO));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
				FillDependant_LnhagTablePedidNrpedido();

				//Check if foreignkey comes from history
				TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePedidNrpedido (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pedid</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhagTablePedidNrpedido(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido];

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

			CSGenioApedid tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApedid.FldCodpedid, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePedidNrpedido (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LnhagTablePedidNrpedido(bool lazyLoad = false)
		{
			var row = GetDependant_LnhagTablePedidNrpedido(this.ValCodpedid);
			try
			{

				// Fill List fields
				this.ValCodpedid = ViewModelConversion.ToString(row["pedid.codpedid"]);
				TablePedidNrpedido.Value = (decimal?)row["pedid.nrpedido"];
				if (GlobalFunctions.emptyG(this.ValCodpedid) == 1)
				{
					this.ValCodpedid = "";
					TablePedidNrpedido.Value = 0;
					Navigation.ClearValue("pedid");
				}
				else if (lazyLoad)
				{
					TablePedidNrpedido.SetPagination(1, 0, false, false, 1);
					TablePedidNrpedido.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpedid),
							Text = Convert.ToString(TablePedidNrpedido.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpedid);
				}

				TablePedidNrpedido.Selected = this.ValCodpedid;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePedidNrpedido): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LNHAG___PEDIDNRPEDIDO = ["Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido"];

		/// <summary>
		/// TableTpeq1Tipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhag___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhag___tpeq1tipoequiDoLoad = true;
			CriteriaSet lnhag___tpeq1tipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpeq1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhag___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
					this.ValCodtpequ = Navigation.GetStrValue("tpeq1");
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
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}
				FillDependant_LnhagTableTpeq1Tipoequi(lazyLoad);
				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
				return;
			}

			if (lnhag___tpeq1tipoequiDoLoad)
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
				lnhag___tpeq1tipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHAG_TPEQ1TIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
					lnhag___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpeq1.FldZzstate, 0)
						.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
				else
					lnhag___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tipoequi");
				ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(m_userContext, false, lnhag___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_LNHAG___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpeq1Tipoequi.Query = query;
				TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(m_userContext, r, true, _fieldsToSerialize_LNHAG___TPEQ1TIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_LnhagTableTpeq1Tipoequi();

				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpeq1</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhagTableTpeq1Tipoequi(string PKey)
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
		public void FillDependant_LnhagTableTpeq1Tipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_LnhagTableTpeq1Tipoequi(this.ValCodtpequ);
			try
			{

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpeq1.codtpequ"]);
				TableTpeq1Tipoequi.Value = (string)row["tpeq1.tipoequi"];
				if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
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
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpeq1Tipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpeq1Tipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpeq1Tipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LNHAG___TPEQ1TIPOEQUI = ["Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"lnhag.qtdtpequ" => ViewModelConversion.ToNumeric(modelValue),
				"lnhag.codpedid" => ViewModelConversion.ToString(modelValue),
				"lnhag.codtpequ" => ViewModelConversion.ToString(modelValue),
				"lnhag.codlnhag" => ViewModelConversion.ToString(modelValue),
				"pedid.codpedid" => ViewModelConversion.ToString(modelValue),
				"pedid.nrpedido" => ViewModelConversion.ToNumeric(modelValue),
				"tpeq1.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpeq1.tipoequi" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHAG]/

		#endregion
	}
}
