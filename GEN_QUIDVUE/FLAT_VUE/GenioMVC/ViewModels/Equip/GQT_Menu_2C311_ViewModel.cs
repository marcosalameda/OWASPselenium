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

namespace GenioMVC.ViewModels.Equip
{
	public class GQT_Menu_2C311_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_2C311_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "equip"; }

		/// <inheritdoc/>
		public override string Uuid { get => "a9fa1cd7-7fc1-464f-9b11-ea8abaa66953"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodequip { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();
				// Limitations

				return conditions;
			}
		}

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAequip.FldCoddeco, Navigation.GetValue("decom"));

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
// USE /[MANUAL GQT LIST_LIMITS 2C311]/

			return crs;
		}




		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("equip", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML2C311");
			conditions.Equal(CSGenioAequip.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldCoddeco, CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAequip.FldDtdeco, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr };

			ListingMVC<CSGenioAequip> listing = new ListingMVC<CSGenioAequip>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			if (qs.FromTable.TableAlias != areaBase.Alias)
			{
				if (!qs.Joins.Select(x => x.Table).Select(y=>y.TableAlias).Contains(CSGenio.business.Area.AreaEQUIP.Alias))
					qs.Join(CSGenio.business.Area.AreaEQUIP, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}
			else
			{
				if (!qs.Joins.Select(x => x.Table).Select(y=>y.TableAlias).Contains(CSGenio.business.Area.AreaDECOM.Alias))
					qs.Join(CSGenio.business.Area.AreaDECOM, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}

			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_2C311_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_2C311_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXTO, Resources.Resources.EQUIPMENT03632, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtaquisi, FieldType.DATA, Resources.Resources.ACQUISITION44180, 8, 0, true),
				new Exports.QColumn(CSGenioAdecom.FldDecomnr, FieldType.NUMERO, Resources.Resources.NO_BATE21045, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtdeco, FieldType.DATA, Resources.Resources.DECOMISSION14486, 8, 0, true),
				new Exports.QColumn(CSGenioAequip.FldIfabatif, FieldType.LOGICO, Resources.Resources.DOWNED_EQUIPMENT43331, 1, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioAroom1.FldRoomnr, FieldType.TEXTO, Resources.Resources.N_R__ROOM43805, 10, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GQT_Menu_2C311_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
			allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			crs.Equal(CSGenioAequip.FldCoddeco, Navigation.GetValue("decom"));
			if (GlobalFunctions.emptyG(Navigation.GetValue("decom")) == 1)
				tableReload = false;

			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "ML2C311");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAequip.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EQUIP", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAequip.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
				Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "ML2C311"));
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
			ListingMVC<CSGenioAequip> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAequip> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAequip> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAequip> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "2C311"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_2C311_RowViewModel>();

				CriteriaSet gqt_menu_2c311Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
				allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "equip", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldCoddeco, CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAequip.FldDtdeco, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("equip", "registnr");
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
				CSGenioAequip model_limit_area = new CSGenioAequip(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2C311");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "EQUIP"
			//1st Area Limit: "DECOM"
			//1st Area Field: "CODDECO"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAdecom model_limit_area = new CSGenioAdecom(m_userContext.User);
				string limit_field = "coddeco", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_2c311Conds);
				gqt_menu_2c311Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 2C311]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, gqt_menu_2c311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2C311", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 2C311]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 2C311]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
					Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_2c311Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, gqt_menu_2c311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2C311", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_2C311(listing);

					Menu.Identifier = "ML2C311";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML2C311";

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

		private List<GQT_Menu_2C311_RowViewModel> MapGQT_Menu_2C311(ListingMVC<CSGenioAequip> Qlisting)
		{
			var Elements = new List<GQT_Menu_2C311_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_2C311(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAequip row
		/// to a GQT_Menu_2C311_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_2C311_RowViewModel MapGQT_Menu_2C311(CSGenioAequip row)
		{
			var model = new GQT_Menu_2C311_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "decom":
						model.Decom.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "room1":
						model.Room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(GQT_Menu_2C311_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAequip> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAequip row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_2C311]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Equip.ValDesignat", "Equip.ValDtaquisi", "Decom", "Decom.ValDecomnr", "Equip.ValDtdeco", "Equip.ValIfabatif", "Equip.ValPhotogra", "Room1", "Room1.ValRoomnr", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodrooms", "Equip.ValCodtpequ", "Equip.ValCodwareh", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
			new TableSearchColumn("ValDtaquisi", CSGenioAequip.FldDtaquisi, typeof(DateTime?)),
			new TableSearchColumn("Decom_ValDecomnr", CSGenioAdecom.FldDecomnr, typeof(decimal?)),
			new TableSearchColumn("ValDtdeco", CSGenioAequip.FldDtdeco, typeof(DateTime?)),
			new TableSearchColumn("ValIfabatif", CSGenioAequip.FldIfabatif, typeof(bool)),
			new TableSearchColumn("Room1_ValRoomnr", CSGenioAroom1.FldRoomnr, typeof(string))
		];



		protected void SetTicketToImageFields(Models.Equip row)
		{
			if(row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, row.ValCodequip);
		}
	}
}
