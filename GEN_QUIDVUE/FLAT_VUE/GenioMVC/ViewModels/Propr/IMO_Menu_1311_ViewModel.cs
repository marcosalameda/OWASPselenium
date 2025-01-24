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

namespace GenioMVC.ViewModels.Propr
{
	public class IMO_Menu_1311_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<IMO_Menu_1311_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "propr"; }

		/// <inheritdoc/>
		public override string Uuid { get => "b6a2ec7f-338e-44c1-acf0-952b71cb46b6"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodpropr { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioApropr.FldCodcntry, Navigation.GetValue("cntry"));
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
			var areaBase = CSGenio.business.Area.createArea("propr", user, "IMO");

			//gets eph conditions to be applied in listing
			CriteriaSet imo_menu_1311Conds = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML1311");
			imo_menu_1311Conds.Equal(CSGenioApropr.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

// USE /[MANUAL IMO OVERRQ 1311]/

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldCodtppro, CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioApropr.FldEndereco, CSGenioApropr.FldLocalida, CSGenioApropr.FldCodregia, CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioApropr.FldPostalco, CSGenioApropr.FldPostallo, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApropr.FldMobilada, CSGenioApropr.FldQtd_wc, CSGenioApropr.FldQtdquart, CSGenioApropr.FldM2, CSGenioApropr.FldDtdispon, CSGenioApropr.FldPhotogra, CSGenioApropr.FldDescript };

			ListingMVC<CSGenioApropr> listing = new ListingMVC<CSGenioApropr>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(imo_menu_1311Conds, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			if (!qs.Joins.Select(x => x.Table).Select(y=>y.TableAlias).Contains(CSGenio.business.Area.AreaCNTRY.Alias))
				qs.Join(CSGenio.business.Area.AreaCNTRY, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAcntry.FldCodcntry, CSGenioApropr.FldCodcntry));

			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IMO_Menu_1311_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public IMO_Menu_1311_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApropr.FldName, FieldType.TEXTO, Resources.Resources.PROPERTY43977, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldPrecoest, FieldType.VALOR, Resources.Resources.ESTIMATED_PRICE02986, 12, 0, true),
				new Exports.QColumn(CSGenioAtppro.FldTppropri, FieldType.TEXTO, Resources.Resources.TYPE00312, 20, 0, true),
				new Exports.QColumn(CSGenioApropr.FldEndereco, FieldType.MEMO, Resources.Resources.ADDRESS04342, 30, 2, false),
				new Exports.QColumn(CSGenioApropr.FldLocalida, FieldType.TEXTO, Resources.Resources.LOCALE34521, 30, 0, true),
				new Exports.QColumn(CSGenioAregio.FldRegiao, FieldType.TEXTO, Resources.Resources.REGION12723, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldPostalco, FieldType.TEXTO, Resources.Resources.ZIP_CODE56964, 20, 0, false),
				new Exports.QColumn(CSGenioApropr.FldPostallo, FieldType.TEXTO, Resources.Resources.POSTAL_LOCATION08708, 30, 0, false),
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXTO, Resources.Resources.COUNTRY64133, 30, 0, false),
				new Exports.QColumn(CSGenioApropr.FldMobilada, FieldType.LOGICO, Resources.Resources.FURNISHED37431, 1, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtd_wc, FieldType.NUMERO, Resources.Resources.TOILET13557, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtdquart, FieldType.NUMERO, Resources.Resources.ROOMS06809, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldM2, FieldType.NUMERO, Resources.Resources.M212241, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldDtdispon, FieldType.DATA, Resources.Resources.AVAILABILITY56489, 8, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioApropr.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioApropr.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 10, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<IMO_Menu_1311_RowViewModel>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PROPR.NAME", new OrderedDictionary());
			allSortOrders["PROPR.NAME"].Add("PROPR.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioApropr.FldCodcntry, Navigation.GetValue("cntry"));

			if (isToExport)
			{
				// EPH
				crs = Models.Propr.AddEPH<CSGenioApropr>(ref u, crs, "ML1311");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApropr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApropr.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Propr.AddEPH<CSGenioApropr>(ref u, null, "ML1311"));
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
			ListingMVC<CSGenioApropr> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApropr> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioApropr> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApropr> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "1311"),
				new("Module", "IMO")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<IMO_Menu_1311_RowViewModel>();

				CriteriaSet imo_menu_1311Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PROPR.NAME", new OrderedDictionary());
				allSortOrders["PROPR.NAME"].Add("PROPR.NAME", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "propr", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApropr.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldCodtppro, CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioApropr.FldEndereco, CSGenioApropr.FldLocalida, CSGenioApropr.FldCodregia, CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioApropr.FldPostalco, CSGenioApropr.FldPostallo, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApropr.FldMobilada, CSGenioApropr.FldQtd_wc, CSGenioApropr.FldQtdquart, CSGenioApropr.FldM2, CSGenioApropr.FldDtdispon, CSGenioApropr.FldPhotogra, CSGenioApropr.FldDescript };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("propr", "name");
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
				CSGenioApropr model_limit_area = new CSGenioApropr(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML1311");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "PROPR"
			//1st Area Limit: "CNTRY"
			//1st Area Field: "CODCNTRY"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAcntry model_limit_area = new CSGenioAcntry(m_userContext.User);
				string limit_field = "codcntry", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(imo_menu_1311Conds);
				imo_menu_1311Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL IMO OVERRQ 1311]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, imo_menu_1311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1311", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL IMO OVERRQLSTEXP 1311]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL IMO OVERRQLIST 1311]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
					Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApropr.GetInformation(), QMVC_POS_RECORD, sorts, imo_menu_1311Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioApropr> listing = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, imo_menu_1311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1311", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapIMO_Menu_1311(listing);

					Menu.Identifier = "ML1311";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML1311";

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

		private List<IMO_Menu_1311_RowViewModel> MapIMO_Menu_1311(ListingMVC<CSGenioApropr> Qlisting)
		{
			var Elements = new List<IMO_Menu_1311_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapIMO_Menu_1311(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioApropr row
		/// to a IMO_Menu_1311_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private IMO_Menu_1311_RowViewModel MapIMO_Menu_1311(CSGenioApropr row)
		{
			var model = new IMO_Menu_1311_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "propr":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tppro":
						model.Tppro.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "regio":
						model.Regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cntry":
						model.Cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			CalculateButtonPermissions(model);


			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks CRUD conditions to determine which actions the user can perform.
		/// </summary>
		public void CalculateButtonPermissions(IMO_Menu_1311_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioApropr> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioApropr row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM IMO_MENU_1311]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Propr", "Propr.ValCodpropr", "Propr.ValZzstate", "Propr.ValName", "Propr.ValPrecoest", "Tppro", "Tppro.ValTppropri", "Propr.ValEndereco", "Propr.ValLocalida", "Regio", "Regio.ValRegiao", "Propr.ValPostalco", "Propr.ValPostallo", "Cntry", "Cntry.ValCountry", "Propr.ValMobilada", "Propr.ValQtd_wc", "Propr.ValQtdquart", "Propr.ValM2", "Propr.ValDtdispon", "Propr.ValPhotogra", "Propr.ValDescript", "Propr.ValCodcntry", "Propr.ValCodpais1", "Propr.ValCodpesso", "Propr.ValCodregia", "Propr.ValCodtppro", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValName", CSGenioApropr.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValPrecoest", CSGenioApropr.FldPrecoest, typeof(decimal?)),
			new TableSearchColumn("Tppro_ValTppropri", CSGenioAtppro.FldTppropri, typeof(string)),
			new TableSearchColumn("ValEndereco", CSGenioApropr.FldEndereco, typeof(string), visible : false),
			new TableSearchColumn("ValLocalida", CSGenioApropr.FldLocalida, typeof(string)),
			new TableSearchColumn("Regio_ValRegiao", CSGenioAregio.FldRegiao, typeof(string)),
			new TableSearchColumn("ValPostalco", CSGenioApropr.FldPostalco, typeof(string), visible : false),
			new TableSearchColumn("ValPostallo", CSGenioApropr.FldPostallo, typeof(string), visible : false),
			new TableSearchColumn("Cntry_ValCountry", CSGenioAcntry.FldCountry, typeof(string), visible : false),
			new TableSearchColumn("ValMobilada", CSGenioApropr.FldMobilada, typeof(bool)),
			new TableSearchColumn("ValQtd_wc", CSGenioApropr.FldQtd_wc, typeof(decimal?)),
			new TableSearchColumn("ValQtdquart", CSGenioApropr.FldQtdquart, typeof(decimal?)),
			new TableSearchColumn("ValM2", CSGenioApropr.FldM2, typeof(decimal?)),
			new TableSearchColumn("ValDtdispon", CSGenioApropr.FldDtdispon, typeof(DateTime?)),
			new TableSearchColumn("ValDescript", CSGenioApropr.FldDescript, typeof(string), visible : false)
		];



		protected void SetTicketToImageFields(Models.Propr row)
		{
			if(row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPR, CSGenioApropr.FldPhotogra.Field, null, row.ValCodpropr);
		}
	}
}
