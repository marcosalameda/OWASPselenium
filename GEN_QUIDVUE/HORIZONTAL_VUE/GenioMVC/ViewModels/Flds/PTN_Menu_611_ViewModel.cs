using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Flds
{
	public class PTN_Menu_611_ViewModel : MenuListViewModel<Models.Flds>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_611_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "flds";

		/// <inheritdoc/>
		public override string Uuid => "8c79866f-7459-4fd0-8b1b-b5434e42c174";

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
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
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
// USE /[MANUAL PTN LIST_LIMITS 611]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("flds", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML611");
			conditions.Equal(CSGenioAflds.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAflds.FldTxtfield, CSGenioAflds.FldEmailfld, CSGenioAflds.FldZipfield, CSGenioAflds.FldIbanfiel, CSGenioAflds.FldSsnumber, CSGenioAflds.FldLicplate, CSGenioAflds.FldVatnumbr, CSGenioAflds.FldBanknmbr, CSGenioAflds.FldUpprtext, CSGenioAflds.FldPassfld, CSGenioAflds.FldClrpicke, CSGenioAflds.FldShwrc, CSGenioAflds.FldRadiob };

			ListingMVC<CSGenioAflds> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public PTN_Menu_611_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_611_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_611_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAaero.FldName, FieldType.TEXT, Resources.Resources.AIRLINE_NAME55130, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldDescrip, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldNpassage, FieldType.NUMERIC, Resources.Resources.NUMERIC19292, 3, 0, true),
				new Exports.QColumn(CSGenioAflds.FldDuration, FieldType.NUMERIC, Resources.Resources.NUMERIC_DECIMAL37352, 5, 2, true),
				new Exports.QColumn(CSGenioAflds.FldPrice, FieldType.CURRENCY, Resources.Resources.CURRENCY13881, 6, 0, true),
				new Exports.QColumn(CSGenioAflds.FldPrecobil, FieldType.CURRENCY, Resources.Resources.CURRENCY_DECIMAL48296, 6, 0, true),
				new Exports.QColumn(CSGenioAflds.FldDate, FieldType.DATE, Resources.Resources.DATE__DD_MM_YY_57869, 8, 0, true),
				new Exports.QColumn(CSGenioAflds.FldDatetime, FieldType.DATETIME, Resources.Resources.DATETIME61308, 16, 0, true),
				new Exports.QColumn(CSGenioAflds.FldDateseco, FieldType.DATETIMESECONDS, Resources.Resources.DATESECOND44557, 19, 0, true),
				new Exports.QColumn(CSGenioAflds.FldTime, FieldType.TIME_HOURS, Resources.Resources.TIME15328, 5, 0, true),
				new Exports.QColumn(CSGenioAflds.FldYear, FieldType.NUMERIC, Resources.Resources.YEAR61794, 4, 0, true),
				new Exports.QColumn(CSGenioAflds.FldPrimviag, FieldType.LOGIC, Resources.Resources.LOGICAL47485, 1, 0, true),
				new Exports.QColumn(CSGenioAflds.FldConditio, FieldType.NUMERIC, Resources.Resources.CONDITIONAL01431, 1, 0, true),
				new Exports.QColumn(CSGenioAflds.FldClass, FieldType.ARRAY_TEXT, Resources.Resources.TEXT_ENUMERATION45668, 2, 0, true, "CLASS"),
				new Exports.QColumn(CSGenioAflds.FldClassnum, FieldType.ARRAY_NUMERIC, Resources.Resources.NUMERIC_ENUMERATION19068, 1, 0, true, "CLASSNUM"),
				new Exports.QColumn(CSGenioAflds.FldLogicenu, FieldType.ARRAY_LOGIC, Resources.Resources.LOGICAL_ENUMERATION30276, 1, 0, true, "PRIMVIAG"),
				!ajaxRequest ? new Exports.QColumn(CSGenioAflds.FldLogo, FieldType.IMAGE, Resources.Resources.LOGO62483, 3, 1, true):null,
				new Exports.QColumn(CSGenioAflds.FldAttach, FieldType.DOCUMENT, Resources.Resources.DOCUMENT00695, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldLogoexte, FieldType.PATH, Resources.Resources.LOGO__EXTERNAL_FILE_58162, 3, 0, true),
				new Exports.QColumn(CSGenioAflds.FldCreatuse, FieldType.TEXT, Resources.Resources.CREATED_BY12292, 20, 0, true),
				new Exports.QColumn(CSGenioAflds.FldCreatdat, FieldType.DATETIMESECONDS, Resources.Resources.DATE_OF_CREATION__DD02208, 8, 0, true),
				new Exports.QColumn(CSGenioAflds.FldCreathou, FieldType.TIME_HOURS, Resources.Resources.HOUR_OF_CREATION33629, 5, 0, true),
				new Exports.QColumn(CSGenioAflds.FldCreatins, FieldType.DATETIMESECONDS, Resources.Resources.COMPLETE_DATE_OF_CRE57046, 15, 0, true),
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXT, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAflds.FldTxtfield, FieldType.TEXT, Resources.Resources.TEXT_FIELD41810, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldEmailfld, FieldType.TEXT, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldZipfield, FieldType.TEXT, Resources.Resources.ZIPCODE21021, 8, 0, true),
				new Exports.QColumn(CSGenioAflds.FldIbanfiel, FieldType.TEXT, Resources.Resources.IBAN28506, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldSsnumber, FieldType.TEXT, Resources.Resources.SOCIAL_SECURITY_NO48150, 11, 0, true),
				new Exports.QColumn(CSGenioAflds.FldLicplate, FieldType.TEXT, Resources.Resources.LICENCE_PLATE07627, 8, 0, true),
				new Exports.QColumn(CSGenioAflds.FldVatnumbr, FieldType.TEXT, Resources.Resources.VAT_NUMBER24236, 9, 0, true),
				new Exports.QColumn(CSGenioAflds.FldBanknmbr, FieldType.TEXT, Resources.Resources.BANKING_ACCOUNT_NUMB62548, 24, 0, true),
				new Exports.QColumn(CSGenioAflds.FldUpprtext, FieldType.TEXT, Resources.Resources.UPPERCASE48238, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldPassfld, FieldType.TEXT, Resources.Resources.PASSWORD09467, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldClrpicke, FieldType.TEXT, Resources.Resources.COLORPICKER39653, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldShwrc, FieldType.LOGIC, Resources.Resources.SHOW_RECORD53851, 1, 0, true),
				new Exports.QColumn(CSGenioAflds.FldRadiob, FieldType.ARRAY_TEXT, Resources.Resources.RADIO_BTN20980, 5, 0, true, "RADIOBTN"),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAflds> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAflds> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<PTN_Menu_611_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Flds.AddEPH<CSGenioAflds>(ref u, crs, "ML611");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAflds.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FLDS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAflds.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Flds.AddEPH<CSGenioAflds>(ref u, null, "ML611"));
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
			ListingMVC<CSGenioAflds> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAflds> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAflds> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAflds> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
                new("PageId", "PTN.611"),
                new("PageType", "menu")
            ]), "ms", "Time to load the page."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_611_RowViewModel>();

				CriteriaSet ptn_menu_611Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("FLDS.DURATION", new OrderedDictionary());
				allSortOrders["FLDS.DURATION"].Add("FLDS.DURATION", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "flds", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAflds.FldDuration), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldAttachfk, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAflds.FldTxtfield, CSGenioAflds.FldEmailfld, CSGenioAflds.FldZipfield, CSGenioAflds.FldIbanfiel, CSGenioAflds.FldSsnumber, CSGenioAflds.FldLicplate, CSGenioAflds.FldVatnumbr, CSGenioAflds.FldBanknmbr, CSGenioAflds.FldUpprtext, CSGenioAflds.FldPassfld, CSGenioAflds.FldClrpicke, CSGenioAflds.FldShwrc, CSGenioAflds.FldRadiob };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("aero", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAflds model_limit_area = new CSGenioAflds(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML611");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_611Conds);
				ptn_menu_611Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 611]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAflds>(m_userContext, false, ptn_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 611]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST 611]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
					Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAflds.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_611Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(m_userContext, distinct, ptn_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapPTN_Menu_611(listing);

					Menu.Identifier = "ML611";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML611";

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
		}

		private List<PTN_Menu_611_RowViewModel> MapPTN_Menu_611(ListingMVC<CSGenioAflds> Qlisting)
		{
			List<PTN_Menu_611_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_611(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAflds row
		/// to a PTN_Menu_611_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_611_RowViewModel MapPTN_Menu_611(CSGenioAflds row)
		{
			var model = new PTN_Menu_611_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "flds":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "aero":
						model.Aero.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "equip":
						model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			SetTicketToImageFields(model);
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
		private void SetDocumentFields(ListingMVC<CSGenioAflds> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAflds row in listing.Rows)
			{
				{
					if (!string.IsNullOrEmpty((string)row.returnValueField("flds.attachfk")))
					{
						ResourceQuery resource = new("Flds", "ValAttach", "ValAttachfk", row.ValCodflds);
						string ticket = QResources.CreateTicketEncryptedBase64(m_userContext.User.Name, m_userContext.User.Location, resource);

						row.insertNameValueField("flds.attach", Newtonsoft.Json.JsonConvert.SerializeObject(new
						{
							fileName = row.returnValueField("flds.attach"),
							ticket
						}));
					}
					else
						row.removeFieldValue("flds.attach");
				}
			}
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Flds m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Flds m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_611]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Aero", "Aero.ValName", "Flds.ValDescrip", "Flds.ValNpassage", "Flds.ValDuration", "Flds.ValPrice", "Flds.ValPrecobil", "Flds.ValDate", "Flds.ValDatetime", "Flds.ValDateseco", "Flds.ValTime", "Flds.ValYear", "Flds.ValPrimviag", "Flds.ValConditio", "Flds.ValClass", "Flds.ValClassnum", "Flds.ValLogicenu", "Flds.ValLogo", "Flds.ValAttach", "Flds.ValLogoexte", "Flds.ValCreatuse", "Flds.ValCreatdat", "Flds.ValCreathou", "Flds.ValCreatins", "Equip", "Equip.ValRegistnr", "Flds.ValTxtfield", "Flds.ValEmailfld", "Flds.ValZipfield", "Flds.ValIbanfiel", "Flds.ValSsnumber", "Flds.ValLicplate", "Flds.ValVatnumbr", "Flds.ValBanknmbr", "Flds.ValUpprtext", "Flds.ValPassfld", "Flds.ValClrpicke", "Flds.ValShwrc", "Flds.ValRadiob", "Flds.ValCodaero", "Flds.ValCodequip"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Aero_ValName", CSGenioAaero.FldName, typeof(string)),
			new TableSearchColumn("ValDescrip", CSGenioAflds.FldDescrip, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValNpassage", CSGenioAflds.FldNpassage, typeof(decimal?)),
			new TableSearchColumn("ValDuration", CSGenioAflds.FldDuration, typeof(decimal?)),
			new TableSearchColumn("ValPrice", CSGenioAflds.FldPrice, typeof(decimal?)),
			new TableSearchColumn("ValPrecobil", CSGenioAflds.FldPrecobil, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAflds.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDatetime", CSGenioAflds.FldDatetime, typeof(DateTime?)),
			new TableSearchColumn("ValDateseco", CSGenioAflds.FldDateseco, typeof(DateTime?)),
			new TableSearchColumn("ValTime", CSGenioAflds.FldTime, typeof(string)),
			new TableSearchColumn("ValYear", CSGenioAflds.FldYear, typeof(decimal?)),
			new TableSearchColumn("ValPrimviag", CSGenioAflds.FldPrimviag, typeof(bool)),
			new TableSearchColumn("ValConditio", CSGenioAflds.FldConditio, typeof(decimal)),
			new TableSearchColumn("ValClass", CSGenioAflds.FldClass, typeof(string), array : "CLASS"),
			new TableSearchColumn("ValClassnum", CSGenioAflds.FldClassnum, typeof(decimal), array : "CLASSNUM"),
			new TableSearchColumn("ValLogicenu", CSGenioAflds.FldLogicenu, typeof(int), array : "PRIMVIAG"),
			new TableSearchColumn("ValAttach", CSGenioAflds.FldAttach, typeof(string)),
			new TableSearchColumn("ValCreatuse", CSGenioAflds.FldCreatuse, typeof(string)),
			new TableSearchColumn("ValCreatdat", CSGenioAflds.FldCreatdat, typeof(DateTime?)),
			new TableSearchColumn("ValCreathou", CSGenioAflds.FldCreathou, typeof(string)),
			new TableSearchColumn("ValCreatins", CSGenioAflds.FldCreatins, typeof(DateTime?)),
			new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
			new TableSearchColumn("ValTxtfield", CSGenioAflds.FldTxtfield, typeof(string)),
			new TableSearchColumn("ValEmailfld", CSGenioAflds.FldEmailfld, typeof(string)),
			new TableSearchColumn("ValZipfield", CSGenioAflds.FldZipfield, typeof(string)),
			new TableSearchColumn("ValIbanfiel", CSGenioAflds.FldIbanfiel, typeof(string)),
			new TableSearchColumn("ValSsnumber", CSGenioAflds.FldSsnumber, typeof(string)),
			new TableSearchColumn("ValLicplate", CSGenioAflds.FldLicplate, typeof(string)),
			new TableSearchColumn("ValVatnumbr", CSGenioAflds.FldVatnumbr, typeof(string)),
			new TableSearchColumn("ValBanknmbr", CSGenioAflds.FldBanknmbr, typeof(string)),
			new TableSearchColumn("ValUpprtext", CSGenioAflds.FldUpprtext, typeof(string)),
			new TableSearchColumn("ValPassfld", CSGenioAflds.FldPassfld, typeof(string)),
			new TableSearchColumn("ValClrpicke", CSGenioAflds.FldClrpicke, typeof(string)),
			new TableSearchColumn("ValShwrc", CSGenioAflds.FldShwrc, typeof(bool)),
			new TableSearchColumn("ValRadiob", CSGenioAflds.FldRadiob, typeof(string), array : "RADIOBTN"),
		];
		protected void SetTicketToImageFields(Models.Flds row)
		{
			if (row == null)
				return;

			row.ValLogoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaFLDS, CSGenioAflds.FldLogo.Field, null, row.ValCodflds);
		}
	}
}
