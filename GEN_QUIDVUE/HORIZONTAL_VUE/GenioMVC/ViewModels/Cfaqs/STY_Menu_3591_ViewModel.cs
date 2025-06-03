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

namespace GenioMVC.ViewModels.Cfaqs
{
	public class STY_Menu_3591_ViewModel : MenuListViewModel<Models.Cfaqs>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<STY_Menu_3591_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "cfaqs";

		/// <inheritdoc/>
		public override string Uuid => "c620143f-29ba-4b06-855d-55c48acfe0c6";

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
// USE /[MANUAL STY LIST_LIMITS 3591]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("cfaqs", user, "STY");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML3591");
			conditions.Equal(CSGenioAcfaqs.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAcfaqs.FldCodcfaqs, CSGenioAcfaqs.FldZzstate, CSGenioAcfaqs.FldIcon, CSGenioAcfaqs.FldCategory, CSGenioAcfaqs.FldDescript };

			ListingMVC<CSGenioAcfaqs> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public STY_Menu_3591_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_3591_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public STY_Menu_3591_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_3591_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public STY_Menu_3591_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				!ajaxRequest ? new Exports.QColumn(CSGenioAcfaqs.FldIcon, FieldType.IMAGE, String.Empty, 3, 1, true):null,
				new Exports.QColumn(CSGenioAcfaqs.FldCategory, FieldType.MEMO, Resources.Resources.CATEGORY18978, 30, 3, true),
				new Exports.QColumn(CSGenioAcfaqs.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 3, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAcfaqs> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcfaqs> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<STY_Menu_3591_RowViewModel>();
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
				crs = Models.Cfaqs.AddEPH<CSGenioAcfaqs>(ref u, crs, "ML3591");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcfaqs.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CFAQS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcfaqs.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cfaqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cfaqs");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cfaqs.AddEPH<CSGenioAcfaqs>(ref u, null, "ML3591"));
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
			ListingMVC<CSGenioAcfaqs> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcfaqs> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAcfaqs> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcfaqs> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "3591"),
				new("Module", "STY")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<STY_Menu_3591_RowViewModel>();

				CriteriaSet sty_menu_3591Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "cfaqs", allSortOrders);


				FieldRef[] fields = new FieldRef[] { CSGenioAcfaqs.FldCodcfaqs, CSGenioAcfaqs.FldZzstate, CSGenioAcfaqs.FldIcon, CSGenioAcfaqs.FldCategory, CSGenioAcfaqs.FldDescript };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("cfaqs", "icon");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAcfaqs model_limit_area = new CSGenioAcfaqs(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3591");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(sty_menu_3591Conds);
				sty_menu_3591Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ 3591]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAcfaqs>(m_userContext, false, sty_menu_3591Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3591", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP 3591]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL STY OVERRQLIST 3591]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cfaqs");
					Navigation.DestroyEntry("QMVC_POS_RECORD_cfaqs");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcfaqs.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_3591Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAcfaqs> listing = Models.ModelBase.Where<CSGenioAcfaqs>(m_userContext, distinct, sty_menu_3591Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3591", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapSTY_Menu_3591(listing);

					Menu.Identifier = "ML3591";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML3591";

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

		private List<STY_Menu_3591_RowViewModel> MapSTY_Menu_3591(ListingMVC<CSGenioAcfaqs> Qlisting)
		{
			List<STY_Menu_3591_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_3591(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAcfaqs row
		/// to a STY_Menu_3591_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private STY_Menu_3591_RowViewModel MapSTY_Menu_3591(CSGenioAcfaqs row)
		{
			var model = new STY_Menu_3591_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cfaqs":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAcfaqs> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Cfaqs m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Cfaqs m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_3591]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Cfaqs", "Cfaqs.ValCodcfaqs", "Cfaqs.ValZzstate", "Cfaqs.ValIcon", "Cfaqs.ValCategory", "Cfaqs.ValDescript"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValCategory", CSGenioAcfaqs.FldCategory, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioAcfaqs.FldDescript, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Cfaqs row)
		{
			if (row == null)
				return;

			row.ValIconQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCFAQS, CSGenioAcfaqs.FldIcon.Field, null, row.ValCodcfaqs);
		}
	}
}
