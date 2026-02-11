using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Operacoes
{
	public class PTN_Menu_3N31_ViewModel : MenuListViewModel<Models.Operacoes>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<PTN_Menu_3N31_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "operacoes";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "cc6d4bc3-b7a0-4a3c-b78f-ecf7cb9cf987";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL PTN LIST_LIMITS 3N31]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("operacoes", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML3N31");
			conditions.Equal(CSGenioAoperacoes.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAoperacoes.FldCodoperacoes, CSGenioAoperacoes.FldZzstate, CSGenioAoperacoes.FldCodentidade, CSGenioAentidade.FldCodentidade, CSGenioAentidade.FldEntidade, CSGenioAoperacoes.FldPop_aa, CSGenioAoperacoes.FldSobreposicao_aa, CSGenioAoperacoes.FldOperacao_ru, CSGenioAoperacoes.FldOperacao_aa, CSGenioAoperacoes.FldOperacao_ar, CSGenioAoperacoes.FldSobreposicao_ru, CSGenioAoperacoes.FldSobreposicao_ar, CSGenioAoperacoes.FldPop_ru, CSGenioAoperacoes.FldPop_ar };

			ListingMVC<CSGenioAoperacoes> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);





			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public PTN_Menu_3N31_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3N31_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_3N31_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3N31_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_3N31_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAentidade.FldEntidade, FieldType.TEXT, Resources.Resources.ENTIDADE36471, 30, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldPop_aa, FieldType.NUMERIC, Resources.Resources.POP_ABRANGIDA36477, 6, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldSobreposicao_aa, FieldType.LOGIC, Resources.Resources.SOBREPOSICAO_AA55921, 1, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldOperacao_ru, FieldType.TEXT, Resources.Resources.OPERACAO_RU18117, 30, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldOperacao_aa, FieldType.TEXT, Resources.Resources.OPERACAO_AA07938, 30, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldOperacao_ar, FieldType.TEXT, Resources.Resources.OPERACAO_AR11207, 30, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldSobreposicao_ru, FieldType.LOGIC, Resources.Resources.SOBREPOSICAO_RU06294, 1, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldSobreposicao_ar, FieldType.LOGIC, Resources.Resources.SOBREPOSICAO_AR58360, 1, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldPop_ru, FieldType.NUMERIC, Resources.Resources.POP_ABRANGIDA36477, 6, 0, true),
				new Exports.QColumn(CSGenioAoperacoes.FldPop_ar, FieldType.NUMERIC, Resources.Resources.POP_ABRANGIDA36477, 6, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAoperacoes> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAoperacoes> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<PTN_Menu_3N31_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Operacoes.AddEPH<CSGenioAoperacoes>(ref u, crs, "ML3N31");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAoperacoes.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("OPERACOES", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAoperacoes.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_operacoes");
				Navigation.DestroyEntry("QMVC_POS_RECORD_operacoes");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Operacoes.AddEPH<CSGenioAoperacoes>(ref u, null, "ML3N31"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAoperacoes> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAoperacoes> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAoperacoes> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAoperacoes> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<PTN_Menu_3N31_RowViewModel>();

			CriteriaSet ptn_menu_3n31Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OPERACOES.OPERACAO_RU", new OrderedDictionary());
			allSortOrders["OPERACOES.OPERACAO_RU"].Add("OPERACOES.OPERACAO_RU", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "operacoes", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoperacoes.FldOperacao_ru), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAoperacoes.FldCodoperacoes, CSGenioAoperacoes.FldZzstate, CSGenioAoperacoes.FldCodentidade, CSGenioAentidade.FldCodentidade, CSGenioAentidade.FldEntidade, CSGenioAoperacoes.FldPop_aa, CSGenioAoperacoes.FldSobreposicao_aa, CSGenioAoperacoes.FldOperacao_ru, CSGenioAoperacoes.FldOperacao_aa, CSGenioAoperacoes.FldOperacao_ar, CSGenioAoperacoes.FldSobreposicao_ru, CSGenioAoperacoes.FldSobreposicao_ar, CSGenioAoperacoes.FldPop_ru, CSGenioAoperacoes.FldPop_ar };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("entidade", "entidade");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAoperacoes model_limit_area = new CSGenioAoperacoes(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3N31");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(ptn_menu_3n31Conds);
			ptn_menu_3n31Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 3N31]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAoperacoes>(m_userContext, false, ref ptn_menu_3n31Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3N31", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 3N31]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 3N31]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_operacoes");
				Navigation.DestroyEntry("QMVC_POS_RECORD_operacoes");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAoperacoes.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_3n31Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAoperacoes> listing = Models.ModelBase.Where<CSGenioAoperacoes>(m_userContext, distinct, ptn_menu_3n31Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3N31", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapPTN_Menu_3N31(listing);

				Menu.Identifier = "ML3N31";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML3N31";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<PTN_Menu_3N31_RowViewModel> MapPTN_Menu_3N31(ListingMVC<CSGenioAoperacoes> Qlisting)
		{
			List<PTN_Menu_3N31_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_3N31(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAoperacoes row
		/// to a PTN_Menu_3N31_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_3N31_RowViewModel MapPTN_Menu_3N31(CSGenioAoperacoes row)
		{
			var model = new PTN_Menu_3N31_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "operacoes":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "entidade":
						model.Entidade.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAoperacoes> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Operacoes m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Operacoes m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_3N31]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Operacoes", "Operacoes.ValCodoperacoes", "Operacoes.ValZzstate", "Entidade", "Entidade.ValEntidade", "Operacoes.ValPop_aa", "Operacoes.ValSobreposicao_aa", "Operacoes.ValOperacao_ru", "Operacoes.ValOperacao_aa", "Operacoes.ValOperacao_ar", "Operacoes.ValSobreposicao_ru", "Operacoes.ValSobreposicao_ar", "Operacoes.ValPop_ru", "Operacoes.ValPop_ar", "Operacoes.ValCodentidade"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Entidade_ValEntidade", CSGenioAentidade.FldEntidade, typeof(string)),
			new TableSearchColumn("ValPop_aa", CSGenioAoperacoes.FldPop_aa, typeof(decimal?)),
			new TableSearchColumn("ValSobreposicao_aa", CSGenioAoperacoes.FldSobreposicao_aa, typeof(bool)),
			new TableSearchColumn("ValOperacao_ru", CSGenioAoperacoes.FldOperacao_ru, typeof(string)),
			new TableSearchColumn("ValOperacao_aa", CSGenioAoperacoes.FldOperacao_aa, typeof(string)),
			new TableSearchColumn("ValOperacao_ar", CSGenioAoperacoes.FldOperacao_ar, typeof(string)),
			new TableSearchColumn("ValSobreposicao_ru", CSGenioAoperacoes.FldSobreposicao_ru, typeof(bool)),
			new TableSearchColumn("ValSobreposicao_ar", CSGenioAoperacoes.FldSobreposicao_ar, typeof(bool)),
			new TableSearchColumn("ValPop_ru", CSGenioAoperacoes.FldPop_ru, typeof(decimal?)),
			new TableSearchColumn("ValPop_ar", CSGenioAoperacoes.FldPop_ar, typeof(decimal?)),
		];
	}
}
