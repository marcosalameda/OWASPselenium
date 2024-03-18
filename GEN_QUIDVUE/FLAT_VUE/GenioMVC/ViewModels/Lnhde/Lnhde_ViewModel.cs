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

namespace GenioMVC.ViewModels.Lnhde
{
	public class Lnhde_ViewModel : FormViewModel<Models.Lnhde>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Order no:" | Type: "N"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Pedid> TablePedidNrpedido { get; set; }

		/// <summary>
		/// Title: "Order line:" | Type: "N"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Lnhpd> TableLnhpdLine { get; set; }

		/// <summary>
		/// Title: "Order" | Type: "N"
		/// </summary>
		public decimal? ValOrdem { get; set; }

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
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodlnhag { get; set; }

		/// <summary>
		/// Title: "Order line:" | Type: "CE"
		/// </summary>
		public string ValCodlnhpd { get; set; }

		/// <summary>
		/// Title: "Order no:" | Type: "CE"
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

		public string ValCodlnhde { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Lnhde_ViewModel() : base(null!) { }

		public Lnhde_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLNHDE", nestedForm) { }

		public Lnhde_ViewModel(UserContext userContext, Models.Lnhde row, bool nestedForm = false) : base(userContext, "FLNHDE", row, nestedForm) { }

		public Lnhde_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("lnhde", id);
			Model = Models.Lnhde.Find(id, userContext, "FLNHDE", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhde model = new Models.Lnhde(userContext) { Identifier = "FLNHDE" };
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
			Models.Lnhde model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lnhde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhde) to ViewModel (Lnhde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValOrdem = ViewModelConversion.ToNumeric(m.ValOrdem);
				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
				ValCode = ViewModelConversion.ToString(m.ValCode);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValUrl = ViewModelConversion.ToString(m.ValUrl);
				ValCodlnhag = ViewModelConversion.ToString(m.ValCodlnhag);
				ValCodlnhpd = ViewModelConversion.ToString(m.ValCodlnhpd);
				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodlnhde = ViewModelConversion.ToString(m.ValCodlnhde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhde) to ViewModel (Lnhde) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lnhde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhde) to Model (Lnhde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValOrdem = ViewModelConversion.ToNumeric(ValOrdem);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValCode = ViewModelConversion.ToString(ValCode);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValUrl = ViewModelConversion.ToString(ValUrl);
				m.ValCodlnhag = ViewModelConversion.ToString(ValCodlnhag);
				m.ValCodlnhpd = ViewModelConversion.ToString(ValCodlnhpd);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodlnhde = ViewModelConversion.ToString(ValCodlnhde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhde) to Model (Lnhde) - Error during mapping");
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
				Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), m_userContext, "FLNHDE");
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

			Model.Identifier = "FLNHDE";
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

		protected override void LoadDocumentsProperties(Models.Lnhde row)
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
				Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), m_userContext, "FLNHDE");
				if (Model == null)
				{
					Model = new Models.Lnhde(m_userContext) { Identifier = "FLNHDE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhde");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Lnhde___pedidnrpedido(qs, lazyLoad);
			Load_Lnhde___lnhpdline____(qs, lazyLoad);
			Load_Lnhde___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHDE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHDE]/

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

// USE /[MANUAL GQT VIEWMODEL_SAVE LNHDE]/
		public override void Save()
		{

			try { Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), m_userContext, "FLNHDE"); }
			finally { if (Model == null) Model = new Models.Lnhde(m_userContext) { Identifier = "FLNHDE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHDE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), m_userContext, "FLNHDE"); }
			finally { if (Model == null) Model = new Models.Lnhde(m_userContext) { Identifier = "FLNHDE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHDE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHDE]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhde.Find(id, m_userContext, "FLNHDE");
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
		public void Load_Lnhde___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhde___pedidnrpedidoDoLoad = true;
			CriteriaSet lnhde___pedidnrpedidoConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pedid", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhde___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, Navigation.GetValue("pedid"));
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
				FillDependant_LnhdeTablePedidNrpedido(lazyLoad);
				//Check if foreignkey comes from history
				TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
				return;
			}

			if (lnhde___pedidnrpedidoDoLoad)
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
				lnhde___pedidnrpedidoConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_PEDIDNRPEDIDO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
					lnhde___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApedid.FldZzstate, 0)
						.Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
				else
					lnhde___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
				ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(m_userContext, false, lnhde___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHDE___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePedidNrpedido.Query = query;
				TablePedidNrpedido.Elements = listing.RowsForViewModel<GenioMVC.Models.Pedid>((r) => new GenioMVC.Models.Pedid(m_userContext, r, true, _fieldsToSerialize_LNHDE___PEDIDNRPEDIDO));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
				FillDependant_LnhdeTablePedidNrpedido();

				//Check if foreignkey comes from history
				TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePedidNrpedido (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pedid</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhdeTablePedidNrpedido(string PKey)
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
		public void FillDependant_LnhdeTablePedidNrpedido(bool lazyLoad = false)
		{
			var row = GetDependant_LnhdeTablePedidNrpedido(this.ValCodpedid);
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

		private readonly string[] _fieldsToSerialize_LNHDE___PEDIDNRPEDIDO = ["Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido"];

		/// <summary>
		/// TableLnhpdLine -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhde___lnhpdline____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhde___lnhpdline____DoLoad = true;
			CriteriaSet lnhde___lnhpdline____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("lnhpd", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhde___lnhpdline____Conds.Equal(CSGenioAlnhpd.FldCodlnhpd, Navigation.GetValue("lnhpd"));
					this.ValCodlnhpd = Navigation.GetStrValue("lnhpd");
				}
			}
			// Limits Generation

			// Area limit
			lnhde___lnhpdline____DoLoad &= AddCriteriaAreaLimit(lnhde___lnhpdline____Conds, CSGenio.business.CSGenioApedid.FldCodpedid, "pedid", this.ValCodpedid, false);

			TableLnhpdLine = new TableDBEdit<Models.Lnhpd>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_lnhpd") != null)
				{
					this.ValCodlnhpd = Navigation.GetStrValue("RETURN_lnhpd");
					Navigation.CurrentLevel.SetEntry("RETURN_lnhpd", null);
				}
				FillDependant_LnhdeTableLnhpdLine(lazyLoad);
				//Check if foreignkey comes from history
				TableLnhpdLine.FilledByHistory = Navigation.CheckFilledByHistory("lnhpd");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodpedid))
				lnhde___lnhpdline____DoLoad = false;

			if (lnhde___lnhpdline____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableLnhpdLine, "sTableLnhpdLine", "dTableLnhpdLine", qs, "lnhpd");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLnhpdLine_tableFilters"]))
					TableLnhpdLine.TableFilters = bool.Parse(qs["TableLnhpdLine_tableFilters"]);
				else
					TableLnhpdLine.TableFilters = false;

				query = qs["qTableLnhpdLine"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlnhpd.FldLine, query + "%");
				}
				lnhde___lnhpdline____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLnhpdLine"] != null ? qs["pTableLnhpdLine"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAlnhpd.FldCodlnhpd, CSGenioAlnhpd.FldLine, CSGenioAlnhpd.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_LNHPDLINE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("lnhpd", FormMode.New) || Navigation.checkFormMode("lnhpd", FormMode.Duplicate))
					lnhde___lnhpdline____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlnhpd.FldZzstate, 0)
						.Equal(CSGenioAlnhpd.FldCodlnhpd, Navigation.GetStrValue("lnhpd")));
				else
					lnhde___lnhpdline____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlnhpd.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("lnhpd", "line");
				ListingMVC<CSGenioAlnhpd> listing = Models.ModelBase.Where<CSGenioAlnhpd>(m_userContext, false, lnhde___lnhpdline____Conds, fields, offset, numberItems, sorts, "LED_LNHDE___LNHPDLINE____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLnhpdLine.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLnhpdLine.Query = query;
				TableLnhpdLine.Elements = listing.RowsForViewModel<GenioMVC.Models.Lnhpd>((r) => new GenioMVC.Models.Lnhpd(m_userContext, r, true, _fieldsToSerialize_LNHDE___LNHPDLINE____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_lnhpd") != null)
				{
					this.ValCodlnhpd = Navigation.GetStrValue("RETURN_lnhpd");
					Navigation.CurrentLevel.SetEntry("RETURN_lnhpd", null);
				}

				TableLnhpdLine.List = new SelectList(TableLnhpdLine.Elements.ToSelectList(x => x.ValLine, x => x.ValCodlnhpd,  x => x.ValCodlnhpd == this.ValCodlnhpd), "Value", "Text", this.ValCodlnhpd);
				FillDependant_LnhdeTableLnhpdLine();

				//Check if foreignkey comes from history
				TableLnhpdLine.FilledByHistory = Navigation.CheckFilledByHistory("lnhpd");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLnhpdLine (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Lnhpd</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhdeTableLnhpdLine(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlnhpd.FldCodlnhpd, CSGenioAlnhpd.FldLine];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("pedid");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAlnhpd.FldCodpedid, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAlnhpd tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlnhpd.FldCodlnhpd, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLnhpdLine (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LnhdeTableLnhpdLine(bool lazyLoad = false)
		{
			var row = GetDependant_LnhdeTableLnhpdLine(this.ValCodlnhpd);
			try
			{

				// Fill List fields
				this.ValCodlnhpd = ViewModelConversion.ToString(row["lnhpd.codlnhpd"]);
				TableLnhpdLine.Value = (decimal?)row["lnhpd.line"];
				if (GlobalFunctions.emptyG(this.ValCodlnhpd) == 1)
				{
					this.ValCodlnhpd = "";
					TableLnhpdLine.Value = 0;
					Navigation.ClearValue("lnhpd");
				}
				else if (lazyLoad)
				{
					TableLnhpdLine.SetPagination(1, 0, false, false, 1);
					TableLnhpdLine.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodlnhpd),
							Text = Convert.ToString(TableLnhpdLine.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodlnhpd);
				}

				TableLnhpdLine.Selected = this.ValCodlnhpd;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLnhpdLine): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LNHDE___LNHPDLINE____ = ["Lnhpd", "Lnhpd.ValCodlnhpd", "Lnhpd.ValZzstate", "Lnhpd.ValLine"];

		/// <summary>
		/// TableTpeq1Tipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhde___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhde___tpeq1tipoequiDoLoad = true;
			CriteriaSet lnhde___tpeq1tipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpeq1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhde___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
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
				FillDependant_LnhdeTableTpeq1Tipoequi(lazyLoad);
				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
				return;
			}

			if (lnhde___tpeq1tipoequiDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpeq1Tipoequi, "sTableTpeq1Tipoequi", "dTableTpeq1Tipoequi", qs, "tpeq1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTpequcod), SortOrder.Ascending));
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
				lnhde___tpeq1tipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_TPEQ1TIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
					lnhde___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpeq1.FldZzstate, 0)
						.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
				else
					lnhde___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tpequcod");
				ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(m_userContext, false, lnhde___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_LNHDE___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpeq1Tipoequi.Query = query;
				TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(m_userContext, r, true, _fieldsToSerialize_LNHDE___TPEQ1TIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_LnhdeTableTpeq1Tipoequi();

				//Check if foreignkey comes from history
				TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpeq1</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhdeTableTpeq1Tipoequi(string PKey)
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
		public void FillDependant_LnhdeTableTpeq1Tipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_LnhdeTableTpeq1Tipoequi(this.ValCodtpequ);
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

		public List<TreeNode> Tree_TableTpeq1Tipoequi { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TableTpeq1Tipoequi
		/// </summary>
		public void LoadTree_TableTpeq1Tipoequi(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTpequcod), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldNivel };
			CriteriaSet subfilters = CriteriaSet.And();


			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ LNHDE_TPEQ1VALTIPOEQUI]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet lnhde___tpeq1tipoequiConds = CriteriaSet.And();
					{
						bool lnhde___tpeq1tipoequiDoLoad = true;

						if (!lnhde___tpeq1tipoequiDoLoad)
							return;
						lnhde___tpeq1tipoequiConds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioAtpeq1>()
					{
						BranchLevel = 0, Area = "TPEQ1", Form = "", IsTree = true, IsTreeTable = true,
						KeySelector = CSGenioAtpeq1.FldCodtpequ,
						Selector = CSGenioAtpeq1.FldTpequcod,
						ParentSelector = CSGenioAtpeq1.FldTpequpai,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending), new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTpequcod), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioAtpeq1.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTpequpai }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, lnhde___tpeq1tipoequiConds, currentSelectedKey, "IBL_LNHDE___TPEQ1TIPOEQUI"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TableTpeq1Tipoequi = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_LNHDE___TPEQ1TIPOEQUI = ["Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTpequcod", "Tpeq1.ValTipoequi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"lnhde.ordem" => ViewModelConversion.ToNumeric(modelValue),
				"lnhde.quantida" => ViewModelConversion.ToNumeric(modelValue),
				"lnhde.code" => ViewModelConversion.ToString(modelValue),
				"lnhde.descript" => ViewModelConversion.ToString(modelValue),
				"lnhde.url" => ViewModelConversion.ToString(modelValue),
				"lnhde.codlnhag" => ViewModelConversion.ToString(modelValue),
				"lnhde.codlnhpd" => ViewModelConversion.ToString(modelValue),
				"lnhde.codpedid" => ViewModelConversion.ToString(modelValue),
				"lnhde.codtpequ" => ViewModelConversion.ToString(modelValue),
				"lnhde.codlnhde" => ViewModelConversion.ToString(modelValue),
				"pedid.codpedid" => ViewModelConversion.ToString(modelValue),
				"pedid.nrpedido" => ViewModelConversion.ToNumeric(modelValue),
				"lnhpd.codlnhpd" => ViewModelConversion.ToString(modelValue),
				"lnhpd.line" => ViewModelConversion.ToNumeric(modelValue),
				"tpeq1.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpeq1.tipoequi" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHDE]/

		#endregion
	}
}
