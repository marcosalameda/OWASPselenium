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

namespace GenioMVC.ViewModels.Fami1
{
	public class Fami1_ValTiposequ_ViewModel : MenuListViewModel<Models.Tpeq1>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Fami1_ValTiposequ_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tpeq1";

		/// <inheritdoc/>
		public override string Uuid => "Fami1_ValTiposequ";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string Fami1ValCodfamil { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS FAMI1_PSEUDTIPOSEQU]/

			return crs;
		}

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Fami1_ValTiposequ_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Fami1_ValTiposequ_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Fami1_ValTiposequ_ViewModel(UserContext userContext) : base(userContext)
		{
			Fami1ValCodfamil = userContext.CurrentNavigation.CurrentLevel.GetEntry("fami1")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fami1_ValTiposequ_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Fami1_ValTiposequ_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXT, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldTpequcod, FieldType.TEXT, Resources.Resources.CODE49225, 20, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldTpequpai, FieldType.TEXT, Resources.Resources.DEPENDENT_ON28321, 20, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldNivel, FieldType.NUMERIC, Resources.Resources.LEVEL06184, 3, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldBackcolo, FieldType.TEXT, Resources.Resources.BACKGROUND_COLOR47883, 30, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldCorletra, FieldType.TEXT, Resources.Resources.LETTER_COLOR15736, 30, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldPrecomax, FieldType.CURRENCY, Resources.Resources.MAXIMUM_PRICE55489, 12, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldPrecoult, FieldType.CURRENCY, Resources.Resources.LAST_PRICE25852, 12, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldSince, FieldType.DATETIME, Resources.Resources.IN34902, 16, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldQtdequip, FieldType.NUMERIC, Resources.Resources.AMOUNT46885, 6, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldKit, FieldType.LOGIC, Resources.Resources.KIT27179, 1, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpeq1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpeq1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Fami1_ValTiposequ_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.Fami1ValCodfamil != null)
				crs.Equal(CSGenioAtpeq1.FldCodfamil, this.Fami1ValCodfamil);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Tpeq1.AddEPH<CSGenioAtpeq1>(ref u, crs, "IBL_FAMI1___PSEUDTIPOSEQU");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpeq1.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TPEQ1", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtpeq1.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpeq1");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tpeq1");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpeq1.AddEPH<CSGenioAtpeq1>(ref u, null, "IBL_FAMI1___PSEUDTIPOSEQU"));
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
			ListingMVC<CSGenioAtpeq1> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpeq1> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtpeq1> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpeq1> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAMI1.TIPOSEQU"),
				new("PageType", "component")
			]), "ms", "Time to load the page."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<Fami1_ValTiposequ_RowViewModel>();

				CriteriaSet fami1___pseudtiposequConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "tpeq1", allSortOrders);


				FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldNivel, CSGenioAtpeq1.FldBackcolo, CSGenioAtpeq1.FldCorletra, CSGenioAtpeq1.FldPrecomax, CSGenioAtpeq1.FldPrecoult, CSGenioAtpeq1.FldSince, CSGenioAtpeq1.FldQtdequip, CSGenioAtpeq1.FldKit };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("tpeq1", "tipoequi");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAtpeq1 model_limit_area = new CSGenioAtpeq1(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_FAMI1___PSEUDTIPOSEQU");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(fami1___pseudtiposequConds);
				fami1___pseudtiposequConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ FAMI1_PSEUDTIPOSEQU]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAtpeq1>(m_userContext, false, fami1___pseudtiposequConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FAMI1___PSEUDTIPOSEQU", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP FAMI1_PSEUDTIPOSEQU]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST FAMI1_PSEUDTIPOSEQU]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpeq1");
					Navigation.DestroyEntry("QMVC_POS_RECORD_tpeq1");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtpeq1.GetInformation(), QMVC_POS_RECORD, sorts, fami1___pseudtiposequConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(m_userContext, distinct, fami1___pseudtiposequConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FAMI1___PSEUDTIPOSEQU", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapFami1_ValTiposequ(listing);

					Menu.Identifier = "IBL_FAMI1___PSEUDTIPOSEQU";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_FAMI1___PSEUDTIPOSEQU";

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

		private List<Fami1_ValTiposequ_RowViewModel> MapFami1_ValTiposequ(ListingMVC<CSGenioAtpeq1> Qlisting)
		{
			List<Fami1_ValTiposequ_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapFami1_ValTiposequ(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtpeq1 row
		/// to a Fami1_ValTiposequ_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Fami1_ValTiposequ_RowViewModel MapFami1_ValTiposequ(CSGenioAtpeq1 row)
		{
			var model = new Fami1_ValTiposequ_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpeq1":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAtpeq1> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tpeq1 m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tpeq1 m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FAMI1_VALTIPOSEQU]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi", "Tpeq1.ValTpequcod", "Tpeq1.ValTpequpai", "Tpeq1.ValNivel", "Tpeq1.ValBackcolo", "Tpeq1.ValCorletra", "Tpeq1.ValPrecomax", "Tpeq1.ValPrecoult", "Tpeq1.ValSince", "Tpeq1.ValQtdequip", "Tpeq1.ValKit", "Tpeq1.ValCodfamil"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValTpequcod", CSGenioAtpeq1.FldTpequcod, typeof(string)),
			new TableSearchColumn("ValTpequpai", CSGenioAtpeq1.FldTpequpai, typeof(string)),
			new TableSearchColumn("ValNivel", CSGenioAtpeq1.FldNivel, typeof(decimal)),
			new TableSearchColumn("ValBackcolo", CSGenioAtpeq1.FldBackcolo, typeof(string)),
			new TableSearchColumn("ValCorletra", CSGenioAtpeq1.FldCorletra, typeof(string)),
			new TableSearchColumn("ValPrecomax", CSGenioAtpeq1.FldPrecomax, typeof(decimal?)),
			new TableSearchColumn("ValPrecoult", CSGenioAtpeq1.FldPrecoult, typeof(decimal?)),
			new TableSearchColumn("ValSince", CSGenioAtpeq1.FldSince, typeof(DateTime?)),
			new TableSearchColumn("ValQtdequip", CSGenioAtpeq1.FldQtdequip, typeof(decimal?)),
			new TableSearchColumn("ValKit", CSGenioAtpeq1.FldKit, typeof(bool)),
		];
	}
}
