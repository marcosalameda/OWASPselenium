using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using CSGenio.core.di;

namespace GenioMVC.ViewModels.Sale
{
	public class GQT_Menu_521_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_521_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "sale"; }

		/// <inheritdoc/>
		public override string Uuid { get => "21dca682-c791-4fe9-9d44-5aacca3310e1"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodvenda { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				return conds;
			}
		}

		/// <inheritdoc/>
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}


		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("sale", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet gqt_menu_521Conds = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML521");
			gqt_menu_521Conds.Equal(CSGenioAsale.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

// USE /[MANUAL GQT OVERRQ 521]/

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAsale.FldCodvenda, CSGenioAsale.FldZzstate, CSGenioAsale.FldNrlide, CSGenioAsale.FldStartdt, CSGenioAsale.FldIdentifi, CSGenioAsale.FldPotcompr, CSGenioAsale.FldProspecc, CSGenioAsale.FldInteress, CSGenioAsale.FldSemrfina, CSGenioAsale.FldSemcapac, CSGenioAsale.FldDtqualif, CSGenioAsale.FldQualific, CSGenioAsale.FldPreabord, CSGenioAsale.FldHomework, CSGenioAsale.FldDtaborda, CSGenioAsale.FldApproach, CSGenioAsale.FldApresent, CSGenioAsale.FldDtaprese, CSGenioAsale.FldDtsupera, CSGenioAsale.FldTentfech, CSGenioAsale.FldDtvenda, CSGenioAsale.FldDtacompa };

			ListingMVC<CSGenioAsale> listing = new ListingMVC<CSGenioAsale>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(gqt_menu_521Conds, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_521_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_521_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAsale.FldNrlide, FieldType.NUMERO, Resources.Resources.N_O_DA_LIDE50722, 10, 0, true),
				new Exports.QColumn(CSGenioAsale.FldStartdt, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldIdentifi, FieldType.TEXTO, Resources.Resources.IDENTIFICACAO_DA_OPO05341, 30, 0, true),
				new Exports.QColumn(CSGenioAsale.FldPotcompr, FieldType.TEXTO, Resources.Resources.POTENCIAIS_COMPRADOR25099, 30, 0, true),
				new Exports.QColumn(CSGenioAsale.FldProspecc, FieldType.LOGICO, Resources.Resources.PROSPECCAO_EFECTUADA42558, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldInteress, FieldType.LOGICO, Resources.Resources.INTERESSADO26080, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldSemrfina, FieldType.LOGICO, Resources.Resources.SEM_RECURSOS_FINANCE28439, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldSemcapac, FieldType.LOGICO, Resources.Resources.SEM_CAPACIDADE_DE_DE07701, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtqualif, FieldType.DATAHORA, Resources.Resources.QUALIFICACAO07026, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldQualific, FieldType.LOGICO, Resources.Resources.QUALIFICACAO_EFECTUA30983, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldPreabord, FieldType.DATAHORA, Resources.Resources.PRE_ABORDAGEM30870, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldHomework, FieldType.LOGICO, Resources.Resources.TRABALHO_DE_CASA_EFE54337, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtaborda, FieldType.DATAHORA, Resources.Resources.ABORDAGEM05839, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldApproach, FieldType.LOGICO, Resources.Resources.ABORDAGEM_EFECTUADA60152, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldApresent, FieldType.LOGICO, Resources.Resources.APRESENTACAO15975, 1, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtaprese, FieldType.DATAHORA, Resources.Resources.APRESENTACAO_EFECTUA37455, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtsupera, FieldType.DATAHORA, Resources.Resources.SUPERAR_OBJECOES02243, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldTentfech, FieldType.DATAHORA, Resources.Resources.TENTATIVAS_DE_FECHO20342, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtvenda, FieldType.DATAHORA, Resources.Resources.FECHO_DA_VENDA48081, 16, 0, true),
				new Exports.QColumn(CSGenioAsale.FldDtacompa, FieldType.DATAHORA, Resources.Resources.ACOMPANHAMENTO53507, 16, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAsale> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAsale> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfiguration);

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
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();


			if (Menu == null)
				Menu = new TablePartial<GQT_Menu_521_RowViewModel>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("SALE.STARTDT", new OrderedDictionary());
			allSortOrders["SALE.STARTDT"].Add("SALE.STARTDT", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Sale.AddEPH<CSGenioAsale>(ref u, crs, "ML521");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAsale.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("SALE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAsale.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_sale");
				Navigation.DestroyEntry("QMVC_POS_RECORD_sale");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Sale.AddEPH<CSGenioAsale>(ref u, null, "ML521"));
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
			ListingMVC<CSGenioAsale> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAsale> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAsale> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAsale> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "521"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_521_RowViewModel>();

				CriteriaSet gqt_menu_521Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("SALE.STARTDT", new OrderedDictionary());
				allSortOrders["SALE.STARTDT"].Add("SALE.STARTDT", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "sale", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsale.FldStartdt), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAsale.FldCodvenda, CSGenioAsale.FldZzstate, CSGenioAsale.FldNrlide, CSGenioAsale.FldStartdt, CSGenioAsale.FldIdentifi, CSGenioAsale.FldPotcompr, CSGenioAsale.FldProspecc, CSGenioAsale.FldInteress, CSGenioAsale.FldSemrfina, CSGenioAsale.FldSemcapac, CSGenioAsale.FldDtqualif, CSGenioAsale.FldQualific, CSGenioAsale.FldPreabord, CSGenioAsale.FldHomework, CSGenioAsale.FldDtaborda, CSGenioAsale.FldApproach, CSGenioAsale.FldApresent, CSGenioAsale.FldDtaprese, CSGenioAsale.FldDtsupera, CSGenioAsale.FldTentfech, CSGenioAsale.FldDtvenda, CSGenioAsale.FldDtacompa };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("sale", "nrlide");
				}


				// Limitations
				if (this.tableLimits == null)
					this.tableLimits = new List<Limit>();
				//Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAsale model_limit_area = new CSGenioAsale(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML521");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_521Conds);
				gqt_menu_521Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 521]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAsale>(m_userContext, false, gqt_menu_521Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML521", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 521]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 521]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_sale");
					Navigation.DestroyEntry("QMVC_POS_RECORD_sale");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAsale.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_521Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAsale> listing = Models.ModelBase.Where<CSGenioAsale>(m_userContext, false, gqt_menu_521Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML521", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_521(listing);

					Menu.Identifier = "ML521";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML521";

					Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

					// Set table totalizers
					if (listing.Totalizers != null && listing.Totalizers.Count > 0)
						Menu.SetTotalizers(listing.Totalizers);
				}

				//Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;

				//Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;
				
				// Load the user table configuration names and default name
				LoadUserTableConfigNameProperties();
			}
		}

		private List<GQT_Menu_521_RowViewModel> MapGQT_Menu_521(ListingMVC<CSGenioAsale> Qlisting)
		{
			var Elements = new List<GQT_Menu_521_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_521(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAsale row
		/// to a GQT_Menu_521_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_521_RowViewModel MapGQT_Menu_521(CSGenioAsale row)
		{
			var model = new GQT_Menu_521_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "sale":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			CalculateButtonPermissions(model);


			return model;
		}

		/// <summary>
		/// Checks CRUD conditions to determine which actions the user can perform.
		/// </summary>
		public void CalculateButtonPermissions(GQT_Menu_521_RowViewModel model)
		{
			bool canView = true;
			bool canEdit = true;
			bool canDelete = true;
			bool canDuplicate = true;
			bool canInsert = true;
			using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport)) {
			}
			model.BtnPermission = new TableRowCrudButtonPermissions()
			{
				DeleteBtnDisabled = !canDelete,
				EditBtnDisabled = !canEdit,
				ViewBtnDisabled = !canView,
				DuplicateBtnDisabled = !canDuplicate,
				InsertBtnDisabled = !canInsert,
			};
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
		/// <param name="listing">The rows.</param>
		private void SetDocumentFields(ListingMVC<CSGenioAsale> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAsale row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_521]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Sale", "Sale.ValCodvenda", "Sale.ValZzstate", "Sale.ValNrlide", "Sale.ValStartdt", "Sale.ValIdentifi", "Sale.ValPotcompr", "Sale.ValProspecc", "Sale.ValInteress", "Sale.ValSemrfina", "Sale.ValSemcapac", "Sale.ValDtqualif", "Sale.ValQualific", "Sale.ValPreabord", "Sale.ValHomework", "Sale.ValDtaborda", "Sale.ValApproach", "Sale.ValApresent", "Sale.ValDtaprese", "Sale.ValDtsupera", "Sale.ValTentfech", "Sale.ValDtvenda", "Sale.ValDtacompa", "Sale.ValCodorgan", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValNrlide", CSGenioAsale.FldNrlide, typeof(decimal?)),
			new TableSearchColumn("ValStartdt", CSGenioAsale.FldStartdt, typeof(DateTime?)),
			new TableSearchColumn("ValIdentifi", CSGenioAsale.FldIdentifi, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValPotcompr", CSGenioAsale.FldPotcompr, typeof(string)),
			new TableSearchColumn("ValProspecc", CSGenioAsale.FldProspecc, typeof(bool)),
			new TableSearchColumn("ValInteress", CSGenioAsale.FldInteress, typeof(bool)),
			new TableSearchColumn("ValSemrfina", CSGenioAsale.FldSemrfina, typeof(bool)),
			new TableSearchColumn("ValSemcapac", CSGenioAsale.FldSemcapac, typeof(bool)),
			new TableSearchColumn("ValDtqualif", CSGenioAsale.FldDtqualif, typeof(DateTime?)),
			new TableSearchColumn("ValQualific", CSGenioAsale.FldQualific, typeof(bool)),
			new TableSearchColumn("ValPreabord", CSGenioAsale.FldPreabord, typeof(DateTime?)),
			new TableSearchColumn("ValHomework", CSGenioAsale.FldHomework, typeof(bool)),
			new TableSearchColumn("ValDtaborda", CSGenioAsale.FldDtaborda, typeof(DateTime?)),
			new TableSearchColumn("ValApproach", CSGenioAsale.FldApproach, typeof(bool)),
			new TableSearchColumn("ValApresent", CSGenioAsale.FldApresent, typeof(bool)),
			new TableSearchColumn("ValDtaprese", CSGenioAsale.FldDtaprese, typeof(DateTime?)),
			new TableSearchColumn("ValDtsupera", CSGenioAsale.FldDtsupera, typeof(DateTime?)),
			new TableSearchColumn("ValTentfech", CSGenioAsale.FldTentfech, typeof(DateTime?)),
			new TableSearchColumn("ValDtvenda", CSGenioAsale.FldDtvenda, typeof(DateTime?)),
			new TableSearchColumn("ValDtacompa", CSGenioAsale.FldDtacompa, typeof(DateTime?))
		];



	}
}
