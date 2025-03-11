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
	public class GQT_Menu_61411_ViewModel : MenuListViewModel<Models.Pesso>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_61411_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "pesso";

		/// <inheritdoc/>
		public override string Uuid => "5e65936e-5e88-4afe-9d15-53eb4dc381cd";

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
				// Limitations

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
// USE /[MANUAL GQT LIST_LIMITS 61411]/

			return crs;
		}



		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("pesso", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML61411");
			conditions.Equal(CSGenioApesso.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldIdade, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldEmail2, CSGenioApesso.FldPhotogra, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldExterna, CSGenioApesso.FldInterna, CSGenioApesso.FldCodpaise, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApesso.FldCodcntry, CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApesso.FldCodregia, CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao };

			ListingMVC<CSGenioApesso> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			if (qs.FromTable.TableAlias != areaBase.Alias)
			{
				if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaPESSO.Alias))
					qs.Join(CSGenio.business.Area.AreaPESSO, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}
			else
			{
				if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaCATE1.Alias))
					qs.Join(CSGenio.business.Area.AreaCATE1, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public GQT_Menu_61411_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_61411_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_61411_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_61411_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public GQT_Menu_61411_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldGender, FieldType.ARRAY_COD_TEXTO, Resources.Resources.GENUS37471, 1, 0, true, "Genero"),
				new Exports.QColumn(CSGenioApesso.FldDtnascim, FieldType.DATA, Resources.Resources.BIRTH21799, 8, 0, true),
				new Exports.QColumn(CSGenioApesso.FldIdade, FieldType.NUMERO, Resources.Resources.AGE28663, 5, 0, true),
				new Exports.QColumn(CSGenioApesso.FldIdfuncio, FieldType.NUMERO, Resources.Resources.OFFICIAL_NO_34819, 6, 0, true),
				new Exports.QColumn(CSGenioApesso.FldTelephon, FieldType.TEXTO, Resources.Resources.PHONE56703, 20, 0, true),
				new Exports.QColumn(CSGenioApesso.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldEmail2, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioApesso.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioApesso.FldDtultcat, FieldType.DATA, Resources.Resources.SINCE47259, 8, 0, true),
				new Exports.QColumn(CSGenioAcateg.FldCategoria, FieldType.TEXTO, Resources.Resources.CATEGORY18978, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldExterna, FieldType.LOGICO, Resources.Resources.EXTERNAL13375, 1, 0, true),
				new Exports.QColumn(CSGenioApesso.FldInterna, FieldType.LOGICO, Resources.Resources.INTERNAL04894, 1, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXTO, Resources.Resources.COUNTRY64133, 30, 0, true),
				new Exports.QColumn(CSGenioApais1.FldCountry, FieldType.TEXTO, Resources.Resources.COUNTRY64133, 30, 0, true),
				new Exports.QColumn(CSGenioAregi1.FldRegiao, FieldType.TEXTO, Resources.Resources.REGION12723, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioApesso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

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
				Menu = new TablePartial<GQT_Menu_61411_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);



			//DbEdit N:N Limits
			crs.SubSets.Add(GetConditionsToNN(CSGenio.business.Area.AreaPESSO, CSGenioApesso.FldCodpesso, CSGenio.business.Area.AreaEVCAT, CSGenio.business.Area.AreaCATE1, CSGenioAcate1.FldCodcateg, (string)Navigation.GetValue("cate1"), "ML61411"));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			if (isToExport)
			{
				// EPH
				crs = Models.Pesso.AddEPH<CSGenioApesso>(ref u, crs, "ML61411");

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
					crs.Equals(Models.Pesso.AddEPH<CSGenioApesso>(ref u, null, "ML61411"));
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
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "61411"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_61411_RowViewModel>();

				CriteriaSet gqt_menu_61411Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PESSO.NAME", new OrderedDictionary());
				allSortOrders["PESSO.NAME"].Add("PESSO.NAME", "A");
				allSortOrders.Add("PESSO.DTNASCIM", new OrderedDictionary());
				allSortOrders["PESSO.DTNASCIM"].Add("PESSO.DTNASCIM", "A");
				allSortOrders.Add("PESSO.TELEPHON", new OrderedDictionary());
				allSortOrders["PESSO.TELEPHON"].Add("PESSO.TELEPHON", "A");
				allSortOrders.Add("PESSO.EMAIL", new OrderedDictionary());
				allSortOrders["PESSO.EMAIL"].Add("PESSO.EMAIL", "A");
				allSortOrders.Add("PESSO.EMAIL2", new OrderedDictionary());
				allSortOrders["PESSO.EMAIL2"].Add("PESSO.EMAIL2", "A");
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
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldDtnascim), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldTelephon), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldEmail), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldEmail2), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldDtultcat), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldIdade, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldEmail2, CSGenioApesso.FldPhotogra, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldExterna, CSGenioApesso.FldInterna, CSGenioApesso.FldCodpaise, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApesso.FldCodcntry, CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApesso.FldCodregia, CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("cmpny", "designat");
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
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML61411");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}
				//Tooltip for "DbEdit N:N Limit" affecting this viewmodel list
				//Tooltip for "DC" type, affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.DC;
					CSGenioAcate1 model_limit_area = new CSGenioAcate1(m_userContext.User);
					string limit_field = "codcateg";
					Limit_Filler(ref limit, model_limit_area, limit_field, "", null, LimitAreaType.AreaLimita);
					CSGenioAevcat model_limit_areaN = new CSGenioAevcat(m_userContext.User);
					string limit_fieldN = "codprogr";
					Limit_Filler(ref limit, model_limit_areaN, limit_fieldN, "", null, LimitAreaType.AreaLimitaN);

					this.tableLimits.Add(limit);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 
				//Tooltip for limit "DB" to area "CATE1" was ignored (unrelated to this viewmodel).


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_61411Conds);
				gqt_menu_61411Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 61411]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, gqt_menu_61411Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML61411", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 61411]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 61411]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
					Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApesso.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_61411Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, gqt_menu_61411Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML61411", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_61411(listing);

					Menu.Identifier = "ML61411";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML61411";

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

		private List<GQT_Menu_61411_RowViewModel> MapGQT_Menu_61411(ListingMVC<CSGenioApesso> Qlisting)
		{
			List<GQT_Menu_61411_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_61411(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioApesso row
		/// to a GQT_Menu_61411_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_61411_RowViewModel MapGQT_Menu_61411(CSGenioApesso row)
		{
			var model = new GQT_Menu_61411_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "categ":
						model.Categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cntry":
						model.Cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pais1":
						model.Pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "regi1":
						model.Regi1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_61411]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Cmpny", "Cmpny.ValDesignat", "Pesso.ValName", "Pesso.ValGender", "Pesso.ValDtnascim", "Pesso.ValIdade", "Pesso.ValIdfuncio", "Pesso.ValTelephon", "Pesso.ValEmail", "Pesso.ValEmail2", "Pesso.ValPhotogra", "Pesso.ValDtultcat", "Categ", "Categ.ValCategoria", "Pesso.ValExterna", "Pesso.ValInterna", "Cntry", "Cntry.ValCountry", "Pais1", "Pais1.ValCountry", "Regi1", "Regi1.ValRegiao", "Pesso.ValCodcateg", "Pesso.ValCodempre", "Pesso.ValCodpaise", "Pesso.ValCodcntry", "Pesso.ValCodregia"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
			new TableSearchColumn("ValName", CSGenioApesso.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValGender", CSGenioApesso.FldGender, typeof(string), array : "Genero"),
			new TableSearchColumn("ValDtnascim", CSGenioApesso.FldDtnascim, typeof(DateTime?)),
			new TableSearchColumn("ValIdade", CSGenioApesso.FldIdade, typeof(decimal?)),
			new TableSearchColumn("ValIdfuncio", CSGenioApesso.FldIdfuncio, typeof(decimal?)),
			new TableSearchColumn("ValTelephon", CSGenioApesso.FldTelephon, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioApesso.FldEmail, typeof(string)),
			new TableSearchColumn("ValEmail2", CSGenioApesso.FldEmail2, typeof(string)),
			new TableSearchColumn("ValDtultcat", CSGenioApesso.FldDtultcat, typeof(DateTime?)),
			new TableSearchColumn("Categ_ValCategoria", CSGenioAcateg.FldCategoria, typeof(string)),
			new TableSearchColumn("ValExterna", CSGenioApesso.FldExterna, typeof(bool)),
			new TableSearchColumn("ValInterna", CSGenioApesso.FldInterna, typeof(bool)),
			new TableSearchColumn("Cntry_ValCountry", CSGenioAcntry.FldCountry, typeof(string)),
			new TableSearchColumn("Pais1_ValCountry", CSGenioApais1.FldCountry, typeof(string)),
			new TableSearchColumn("Regi1_ValRegiao", CSGenioAregi1.FldRegiao, typeof(string))
		];
		protected void SetTicketToImageFields(Models.Pesso row)
		{
			if (row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPESSO, CSGenioApesso.FldPhotogra.Field, null, row.ValCodpesso);
		}
	}
}
