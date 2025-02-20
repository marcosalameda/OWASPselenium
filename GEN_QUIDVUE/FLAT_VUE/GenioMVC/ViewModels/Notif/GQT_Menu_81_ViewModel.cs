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

namespace GenioMVC.ViewModels.Notif
{
	public class GQT_Menu_81_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_81_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "notif"; }

		/// <inheritdoc/>
		public override string Uuid { get => "8a24817a-f3db-4158-821e-86bf9df25ea0"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodnotif { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS 81]/

			return crs;
		}




		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("notif", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML81");
			conditions.Equal(CSGenioAnotif.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAnotif.FldCodnotif, CSGenioAnotif.FldZzstate, CSGenioAnotif.FldNrcomoda, CSGenioAnotif.FldBegin, CSGenioAnotif.FldEnd, CSGenioAnotif.FldEmail, CSGenioAnotif.FldIdnotif, CSGenioAnotif.FldIdmsg, CSGenioAnotif.FldMessage, CSGenioAnotif.FldMailerr, CSGenioAnotif.FldDesignat, CSGenioAnotif.FldCreatdat, CSGenioAnotif.FldCreatope, CSGenioAnotif.FldReturned, CSGenioAnotif.FldDtdevolu, CSGenioAnotif.FldCodpesso, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };

			ListingMVC<CSGenioAnotif> listing = new ListingMVC<CSGenioAnotif>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_81_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_81_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAnotif.FldNrcomoda, FieldType.NUMERO, Resources.Resources.NO__OF_THE_DADATO35934, 6, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldBegin, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldEnd, FieldType.DATAHORA, Resources.Resources.END47577, 16, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldEmail, FieldType.TEXTO, Resources.Resources.RECIPIENT_S_EMAIL43894, 30, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldIdnotif, FieldType.TEXTO, Resources.Resources.NOTIFICATION_ID_THAT61751, 30, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldIdmsg, FieldType.TEXTO, Resources.Resources.MESSAGE_ID37133, 30, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldMessage, FieldType.MEMO, Resources.Resources.TEXT_OF_THE_SENT_MES52307, 30, 15, true),
				new Exports.QColumn(CSGenioAnotif.FldMailerr, FieldType.TEXTO, Resources.Resources.ERROR_SENDING_EMAIL53846, 30, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldDesignat, FieldType.TEXTO, Resources.Resources.RECIPIENT65165, 30, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldCreatdat, FieldType.DATACRIA, Resources.Resources.CREATION__DATE13180, 8, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldCreatope, FieldType.OPERCRIA, Resources.Resources.CREATION__OPERATOR50535, 20, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldReturned, FieldType.LOGICO, Resources.Resources.RETURNED01606, 1, 0, true),
				new Exports.QColumn(CSGenioAnotif.FldDtdevolu, FieldType.DATA, Resources.Resources.RETURN32222, 8, 0, true),
				new Exports.QColumn(CSGenioApess2.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAnotif> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAnotif> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GQT_Menu_81_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("NOTIF.BEGIN", new OrderedDictionary());
			allSortOrders["NOTIF.BEGIN"].Add("NOTIF.BEGIN", "A");
			allSortOrders.Add("NOTIF.END", new OrderedDictionary());
			allSortOrders["NOTIF.END"].Add("NOTIF.END", "A");
			allSortOrders.Add("NOTIF.EMAIL", new OrderedDictionary());
			allSortOrders["NOTIF.EMAIL"].Add("NOTIF.EMAIL", "A");
			allSortOrders.Add("NOTIF.IDNOTIF", new OrderedDictionary());
			allSortOrders["NOTIF.IDNOTIF"].Add("NOTIF.IDNOTIF", "A");
			allSortOrders.Add("NOTIF.IDMSG", new OrderedDictionary());
			allSortOrders["NOTIF.IDMSG"].Add("NOTIF.IDMSG", "A");
			allSortOrders.Add("NOTIF.MAILERR", new OrderedDictionary());
			allSortOrders["NOTIF.MAILERR"].Add("NOTIF.MAILERR", "A");
			allSortOrders.Add("NOTIF.DESIGNAT", new OrderedDictionary());
			allSortOrders["NOTIF.DESIGNAT"].Add("NOTIF.DESIGNAT", "A");
			allSortOrders.Add("NOTIF.CREATDAT", new OrderedDictionary());
			allSortOrders["NOTIF.CREATDAT"].Add("NOTIF.CREATDAT", "A");
			allSortOrders.Add("NOTIF.CREATOPE", new OrderedDictionary());
			allSortOrders["NOTIF.CREATOPE"].Add("NOTIF.CREATOPE", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Notif.AddEPH<CSGenioAnotif>(ref u, crs, "ML81");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAnotif.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("NOTIF", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAnotif.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_notif");
				Navigation.DestroyEntry("QMVC_POS_RECORD_notif");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Notif.AddEPH<CSGenioAnotif>(ref u, null, "ML81"));
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
			ListingMVC<CSGenioAnotif> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAnotif> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAnotif> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAnotif> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "81"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_81_RowViewModel>();

				CriteriaSet gqt_menu_81Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("NOTIF.BEGIN", new OrderedDictionary());
				allSortOrders["NOTIF.BEGIN"].Add("NOTIF.BEGIN", "A");
				allSortOrders.Add("NOTIF.END", new OrderedDictionary());
				allSortOrders["NOTIF.END"].Add("NOTIF.END", "A");
				allSortOrders.Add("NOTIF.EMAIL", new OrderedDictionary());
				allSortOrders["NOTIF.EMAIL"].Add("NOTIF.EMAIL", "A");
				allSortOrders.Add("NOTIF.IDNOTIF", new OrderedDictionary());
				allSortOrders["NOTIF.IDNOTIF"].Add("NOTIF.IDNOTIF", "A");
				allSortOrders.Add("NOTIF.IDMSG", new OrderedDictionary());
				allSortOrders["NOTIF.IDMSG"].Add("NOTIF.IDMSG", "A");
				allSortOrders.Add("NOTIF.MAILERR", new OrderedDictionary());
				allSortOrders["NOTIF.MAILERR"].Add("NOTIF.MAILERR", "A");
				allSortOrders.Add("NOTIF.DESIGNAT", new OrderedDictionary());
				allSortOrders["NOTIF.DESIGNAT"].Add("NOTIF.DESIGNAT", "A");
				allSortOrders.Add("NOTIF.CREATDAT", new OrderedDictionary());
				allSortOrders["NOTIF.CREATDAT"].Add("NOTIF.CREATDAT", "A");
				allSortOrders.Add("NOTIF.CREATOPE", new OrderedDictionary());
				allSortOrders["NOTIF.CREATOPE"].Add("NOTIF.CREATOPE", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "notif", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldBegin), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldEnd), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldEmail), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldIdnotif), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldIdmsg), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldMailerr), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldDesignat), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldCreatdat), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldCreatope), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAnotif.FldCodnotif, CSGenioAnotif.FldZzstate, CSGenioAnotif.FldNrcomoda, CSGenioAnotif.FldBegin, CSGenioAnotif.FldEnd, CSGenioAnotif.FldEmail, CSGenioAnotif.FldIdnotif, CSGenioAnotif.FldIdmsg, CSGenioAnotif.FldMessage, CSGenioAnotif.FldMailerr, CSGenioAnotif.FldDesignat, CSGenioAnotif.FldCreatdat, CSGenioAnotif.FldCreatope, CSGenioAnotif.FldReturned, CSGenioAnotif.FldDtdevolu, CSGenioAnotif.FldCodpesso, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("notif", "nrcomoda");
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
				CSGenioAnotif model_limit_area = new CSGenioAnotif(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML81");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_81Conds);
				gqt_menu_81Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 81]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAnotif>(m_userContext, false, gqt_menu_81Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML81", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 81]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 81]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_notif");
					Navigation.DestroyEntry("QMVC_POS_RECORD_notif");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAnotif.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_81Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAnotif> listing = Models.ModelBase.Where<CSGenioAnotif>(m_userContext, false, gqt_menu_81Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML81", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_81(listing);

					Menu.Identifier = "ML81";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML81";

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

		private List<GQT_Menu_81_RowViewModel> MapGQT_Menu_81(ListingMVC<CSGenioAnotif> Qlisting)
		{
			var Elements = new List<GQT_Menu_81_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_81(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAnotif row
		/// to a GQT_Menu_81_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_81_RowViewModel MapGQT_Menu_81(CSGenioAnotif row)
		{
			var model = new GQT_Menu_81_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "notif":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pess2":
						model.Pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(GQT_Menu_81_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAnotif> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAnotif row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_81]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Notif", "Notif.ValCodnotif", "Notif.ValZzstate", "Notif.ValNrcomoda", "Notif.ValBegin", "Notif.ValEnd", "Notif.ValEmail", "Notif.ValIdnotif", "Notif.ValIdmsg", "Notif.ValMessage", "Notif.ValMailerr", "Notif.ValDesignat", "Notif.ValCreatdat", "Notif.ValCreatope", "Notif.ValReturned", "Notif.ValDtdevolu", "Pess2", "Pess2.ValName", "Notif.ValCodpesso", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValNrcomoda", CSGenioAnotif.FldNrcomoda, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValBegin", CSGenioAnotif.FldBegin, typeof(DateTime?)),
			new TableSearchColumn("ValEnd", CSGenioAnotif.FldEnd, typeof(DateTime?)),
			new TableSearchColumn("ValEmail", CSGenioAnotif.FldEmail, typeof(string)),
			new TableSearchColumn("ValIdnotif", CSGenioAnotif.FldIdnotif, typeof(string)),
			new TableSearchColumn("ValIdmsg", CSGenioAnotif.FldIdmsg, typeof(string)),
			new TableSearchColumn("ValMessage", CSGenioAnotif.FldMessage, typeof(string)),
			new TableSearchColumn("ValMailerr", CSGenioAnotif.FldMailerr, typeof(string)),
			new TableSearchColumn("ValDesignat", CSGenioAnotif.FldDesignat, typeof(string)),
			new TableSearchColumn("ValCreatdat", CSGenioAnotif.FldCreatdat, typeof(DateTime?)),
			new TableSearchColumn("ValCreatope", CSGenioAnotif.FldCreatope, typeof(string)),
			new TableSearchColumn("ValReturned", CSGenioAnotif.FldReturned, typeof(bool)),
			new TableSearchColumn("ValDtdevolu", CSGenioAnotif.FldDtdevolu, typeof(DateTime?)),
			new TableSearchColumn("Pess2_ValName", CSGenioApess2.FldName, typeof(string))
		];



	}
}
