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

namespace GenioMVC.ViewModels
{
	public class Wid_grap_ValField001_ViewModel : MenuListViewModel<Models.Cmpny>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Wid_grap_ValField001_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "cmpny";

		/// <inheritdoc/>
		public override string Uuid => "Wid_grap_ValField001";

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
// USE /[MANUAL GQT LIST_LIMITS WID_GRAP_PSEUDFIELD001]/

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
		public Wid_grap_ValField001_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Wid_grap_ValField001_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Wid_grap_ValField001_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Wid_grap_ValField001_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Wid_grap_ValField001_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXT, Resources.Resources.COMPANY52963, 30, 0, true),
				new Exports.QColumn(CSGenioAcmpny.FldQtdpesso, FieldType.NUMERIC, Resources.Resources.NUMBER_OF_PEOPLE08859, 10, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAcmpny> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcmpny> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Wid_grap_ValField001_RowViewModel>();
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
				crs = Models.Cmpny.AddEPH<CSGenioAcmpny>(ref u, crs, "IBL_WID_GRAPPSEUDFIELD001");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcmpny.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CMPNY", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcmpny.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cmpny");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cmpny");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cmpny.AddEPH<CSGenioAcmpny>(ref u, null, "IBL_WID_GRAPPSEUDFIELD001"));
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
			ListingMVC<CSGenioAcmpny> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcmpny> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAcmpny> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcmpny> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("form_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Form", "WID_GRAP")
			}, "ms", "Time to load the form."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<Wid_grap_ValField001_RowViewModel>();

				CriteriaSet wid_grappseudfield001Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "cmpny", allSortOrders);


				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldZzstate, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldQtdpesso };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("cmpny", "designat");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAcmpny model_limit_area = new CSGenioAcmpny(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_WID_GRAPPSEUDFIELD001");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(wid_grappseudfield001Conds);
				wid_grappseudfield001Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ WID_GRAP_PSEUDFIELD001]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, wid_grappseudfield001Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WID_GRAPPSEUDFIELD001", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP WID_GRAP_PSEUDFIELD001]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST WID_GRAP_PSEUDFIELD001]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cmpny");
					Navigation.DestroyEntry("QMVC_POS_RECORD_cmpny");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcmpny.GetInformation(), QMVC_POS_RECORD, sorts, wid_grappseudfield001Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, distinct, wid_grappseudfield001Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WID_GRAPPSEUDFIELD001", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapWid_grap_ValField001(listing);

					Menu.Identifier = "IBL_WID_GRAPPSEUDFIELD001";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_WID_GRAPPSEUDFIELD001";

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

		private List<Wid_grap_ValField001_RowViewModel> MapWid_grap_ValField001(ListingMVC<CSGenioAcmpny> Qlisting)
		{
			List<Wid_grap_ValField001_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWid_grap_ValField001(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAcmpny row
		/// to a Wid_grap_ValField001_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Wid_grap_ValField001_RowViewModel MapWid_grap_ValField001(CSGenioAcmpny row)
		{
			var model = new Wid_grap_ValField001_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cmpny":
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
		private void SetDocumentFields(ListingMVC<CSGenioAcmpny> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Cmpny m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Cmpny m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_GRAP_VALFIELD001]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat", "Cmpny.ValQtdpesso", "Cmpny.ValCodcntry"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValQtdpesso", CSGenioAcmpny.FldQtdpesso, typeof(decimal?)),
		];
	}
}
