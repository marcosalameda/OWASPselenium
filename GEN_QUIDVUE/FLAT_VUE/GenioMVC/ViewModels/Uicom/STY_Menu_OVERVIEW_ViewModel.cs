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

namespace GenioMVC.ViewModels.Uicom
{
	public class STY_Menu_OVERVIEW_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<STY_Menu_OVERVIEW_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "uicom"; }

		/// <inheritdoc/>
		public override string Uuid { get => "7a94d3ef-80ac-4408-8016-eb66cf9a4ae5"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCoduicom { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

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

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL STY LIST_LIMITS OVERVIEW]/

			return crs;
		}




		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("uicom", user, "STY");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLOVERVIEW");
			conditions.Equal(CSGenioAuicom.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAuicom.FldCoduicom, CSGenioAuicom.FldZzstate, CSGenioAuicom.FldName, CSGenioAuicom.FldCategory, CSGenioAuicom.FldMenuid, CSGenioAuicom.FldThumbnai };

			ListingMVC<CSGenioAuicom> listing = new ListingMVC<CSGenioAuicom>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_OVERVIEW_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public STY_Menu_OVERVIEW_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAuicom.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAuicom.FldCategory, FieldType.TEXTO, Resources.Resources.CATEGORY18978, 30, 0, true),
				new Exports.QColumn(CSGenioAuicom.FldMenuid, FieldType.TEXTO, Resources.Resources.FIXED_MENU_NAME38578, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAuicom.FldThumbnai, FieldType.IMAGEM_JPEG, Resources.Resources.THUMBNAIL30025, 3, 1, true):null,
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAuicom> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAuicom> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<STY_Menu_OVERVIEW_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("UICOM.NAME", new OrderedDictionary());
			allSortOrders["UICOM.NAME"].Add("UICOM.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Uicom.AddEPH<CSGenioAuicom>(ref u, crs, "MLOVERVIEW");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAuicom.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("UICOM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAuicom.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_uicom");
				Navigation.DestroyEntry("QMVC_POS_RECORD_uicom");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Uicom.AddEPH<CSGenioAuicom>(ref u, null, "MLOVERVIEW"));
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
			ListingMVC<CSGenioAuicom> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAuicom> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAuicom> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAuicom> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "OVERVIEW"),
				new("Module", "STY")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<STY_Menu_OVERVIEW_RowViewModel>();

				CriteriaSet sty_menu_overviewConds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("UICOM.NAME", new OrderedDictionary());
				allSortOrders["UICOM.NAME"].Add("UICOM.NAME", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "uicom", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAuicom.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAuicom.FldCoduicom, CSGenioAuicom.FldZzstate, CSGenioAuicom.FldName, CSGenioAuicom.FldCategory, CSGenioAuicom.FldMenuid, CSGenioAuicom.FldThumbnai };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("uicom", "name");
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
				CSGenioAuicom model_limit_area = new CSGenioAuicom(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLOVERVIEW");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(sty_menu_overviewConds);
				sty_menu_overviewConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ OVERVIEW]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAuicom>(m_userContext, false, sty_menu_overviewConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLOVERVIEW", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP OVERVIEW]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL STY OVERRQLIST OVERVIEW]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_uicom");
					Navigation.DestroyEntry("QMVC_POS_RECORD_uicom");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAuicom.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_overviewConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAuicom> listing = Models.ModelBase.Where<CSGenioAuicom>(m_userContext, false, sty_menu_overviewConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLOVERVIEW", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapSTY_Menu_OVERVIEW(listing);

					Menu.Identifier = "MLOVERVIEW";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLOVERVIEW";

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

		private List<STY_Menu_OVERVIEW_RowViewModel> MapSTY_Menu_OVERVIEW(ListingMVC<CSGenioAuicom> Qlisting)
		{
			var Elements = new List<STY_Menu_OVERVIEW_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_OVERVIEW(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAuicom row
		/// to a STY_Menu_OVERVIEW_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private STY_Menu_OVERVIEW_RowViewModel MapSTY_Menu_OVERVIEW(CSGenioAuicom row)
		{
			var model = new STY_Menu_OVERVIEW_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "uicom":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(STY_Menu_OVERVIEW_RowViewModel model)
		{
			bool canView = false;
			bool canEdit = false;
			bool canDelete = false;
			bool canDuplicate = false;
			bool canInsert = false;
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
		private void SetDocumentFields(ListingMVC<CSGenioAuicom> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAuicom row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_OVERVIEW]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Uicom", "Uicom.ValCoduicom", "Uicom.ValZzstate", "Uicom.ValName", "Uicom.ValCategory", "Uicom.ValMenuid", "Uicom.ValThumbnai", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValName", CSGenioAuicom.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValCategory", CSGenioAuicom.FldCategory, typeof(string)),
			new TableSearchColumn("ValMenuid", CSGenioAuicom.FldMenuid, typeof(string))
		];



		protected void SetTicketToImageFields(Models.Uicom row)
		{
			if(row == null)
				return;

			row.ValThumbnaiQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaUICOM, CSGenioAuicom.FldThumbnai.Field, null, row.ValCoduicom);
		}
	}
}
