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

namespace GenioMVC.ViewModels.Pesso
{
	public class TBS_Menu_121_ViewModel : MenuListViewModel<Models.Pesso>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<TBS_Menu_121_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "pesso";

		/// <inheritdoc/>
		public override string Uuid => "5bbb3c85-0f2b-4e4a-a096-baeef7fb9b34";

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
// USE /[MANUAL TBS LIST_LIMITS 121]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("pesso", user, "TBS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML121");
			conditions.Equal(CSGenioApesso.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldPhotogra, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };

			ListingMVC<CSGenioApesso> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public TBS_Menu_121_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_121_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TBS_Menu_121_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_121_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public TBS_Menu_121_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 50, 0, true),
				new Exports.QColumn(CSGenioApesso.FldGender, FieldType.ARRAY_TEXT, Resources.Resources.GENUS37471, 1, 0, true, "Genero"),
				new Exports.QColumn(CSGenioApesso.FldDtnascim, FieldType.DATE, Resources.Resources.BIRTH21799, 8, 0, true),
				new Exports.QColumn(CSGenioApesso.FldTelephon, FieldType.TEXT, Resources.Resources.PHONE56703, 20, 0, true),
				new Exports.QColumn(CSGenioApesso.FldEmail, FieldType.TEXT, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldIdfuncio, FieldType.NUMERIC, Resources.Resources.OFFICIAL_NO_34819, 6, 0, true),
				new Exports.QColumn(CSGenioApesso.FldDtultcat, FieldType.DATE, Resources.Resources.SINCE47259, 8, 0, true),
				new Exports.QColumn(CSGenioAcateg.FldCategoria, FieldType.TEXT, Resources.Resources.CATEGORY18978, 30, 0, true),
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXT, Resources.Resources.COMPANY52963, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioApesso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioApesso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<TBS_Menu_121_RowViewModel>();
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
				crs = Models.Pesso.AddEPH<CSGenioApesso>(ref u, crs, "ML121");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApesso.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PESSO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApesso.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Pesso.AddEPH<CSGenioApesso>(ref u, null, "ML121"));
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
			ListingMVC<CSGenioApesso> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApesso> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioApesso> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApesso> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<TBS_Menu_121_RowViewModel>();

				CriteriaSet tbs_menu_121Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PESSO.NAME", new OrderedDictionary());
				allSortOrders["PESSO.NAME"].Add("PESSO.NAME", "A");
				allSortOrders.Add("PESSO.DTULTCAT", new OrderedDictionary());
				allSortOrders["PESSO.DTULTCAT"].Add("PESSO.DTULTCAT", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "pesso", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldDtultcat), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldPhotogra, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("pesso", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioApesso model_limit_area = new CSGenioApesso(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML121");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(tbs_menu_121Conds);
				tbs_menu_121Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TBS OVERRQ 121]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, tbs_menu_121Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML121", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 121]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL TBS OVERRQLIST 121]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
					Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApesso.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_121Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, distinct, tbs_menu_121Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML121", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapTBS_Menu_121(listing);

					Menu.Identifier = "ML121";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML121";

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

		private List<TBS_Menu_121_RowViewModel> MapTBS_Menu_121(ListingMVC<CSGenioApesso> Qlisting)
		{
			List<TBS_Menu_121_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_121(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioApesso row
		/// to a TBS_Menu_121_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TBS_Menu_121_RowViewModel MapTBS_Menu_121(CSGenioApesso row)
		{
			var model = new TBS_Menu_121_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "categ":
						model.Categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioApesso> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Pesso m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Pesso m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_121]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName", "Pesso.ValGender", "Pesso.ValDtnascim", "Pesso.ValTelephon", "Pesso.ValEmail", "Pesso.ValPhotogra", "Pesso.ValIdfuncio", "Pesso.ValDtultcat", "Categ", "Categ.ValCategoria", "Cmpny", "Cmpny.ValDesignat", "Pesso.ValCodempre", "Cmpny.ValCodempre", "Pesso.ValCodcateg", "Pesso.ValCodpaise", "Pesso.ValCodcntry", "Pesso.ValCodregia"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValName", CSGenioApesso.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValGender", CSGenioApesso.FldGender, typeof(string), array : "Genero"),
			new TableSearchColumn("ValDtnascim", CSGenioApesso.FldDtnascim, typeof(DateTime?)),
			new TableSearchColumn("ValTelephon", CSGenioApesso.FldTelephon, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioApesso.FldEmail, typeof(string)),
			new TableSearchColumn("ValIdfuncio", CSGenioApesso.FldIdfuncio, typeof(decimal?)),
			new TableSearchColumn("ValDtultcat", CSGenioApesso.FldDtultcat, typeof(DateTime?)),
			new TableSearchColumn("Categ_ValCategoria", CSGenioAcateg.FldCategoria, typeof(string)),
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Pesso row)
		{
			if (row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPESSO, CSGenioApesso.FldPhotogra.Field, null, row.ValCodpesso);
		}
	}
}
