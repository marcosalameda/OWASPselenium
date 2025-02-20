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

namespace GenioMVC.ViewModels.Tpequ
{
	public class Tpequ_ValComponen_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "DP"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Tpequ_ValComponen_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "cmpki"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Tpequ_ValComponen"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodtpequ { get; set; }

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
				conds.Equal(CSGenioAcmpki.FldCodtpequ, this.ValCodtpequ ?? Navigation.GetStrValue("tpequ"));

				return conds;
			}
		}

		/// <inheritdoc/>
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				List<string> aboveTables = new List<string>();
				User u = m_userContext.User;
				var area = new CSGenioAcmpki(u);
				relations = CSGenio.persistence.QueryUtils.tablesRelationships(aboveTables.Distinct().ToList(), area);
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS TPEQU_PSEUDCOMPONEN]/

			return crs;
		}


		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Tpequ_ValComponen_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Tpequ_ValComponen_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodtpequ = userContext.CurrentNavigation.CurrentLevel.GetEntry("tpequ")?.ToString();
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcmpki.FldOrder, FieldType.NUMERO, Resources.Resources.ORDER39632, 5, 1, true),
				new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 50, 0, true),
				new Exports.QColumn(CSGenioAcmpki.FldQuantida, FieldType.NUMERO, Resources.Resources.AMOUNT46885, 3, 0, true),
				new Exports.QColumn(CSGenioAcmpki.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 2, true),
				new Exports.QColumn(CSGenioAcmpki.FldCode, FieldType.TEXTO, Resources.Resources.CODE49225, 10, 0, true),
				new Exports.QColumn(CSGenioAcmpki.FldUrl, FieldType.TEXTO, Resources.Resources.SITE06486, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAcmpki> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcmpki> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Tpequ_ValComponen_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("CMPKI.ORDER", new OrderedDictionary());
			allSortOrders["CMPKI.ORDER"].Add("CMPKI.ORDER", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.ValCodtpequ != null)
				crs.Equal(CSGenioAcmpki.FldCodtpequ, this.ValCodtpequ);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Cmpki.AddEPH<CSGenioAcmpki>(ref u, crs, "IBL_TPEQU___PSEUDCOMPONEN");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcmpki.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CMPKI", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcmpki.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cmpki");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cmpki");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cmpki.AddEPH<CSGenioAcmpki>(ref u, null, "IBL_TPEQU___PSEUDCOMPONEN"));
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
			ListingMVC<CSGenioAcmpki> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcmpki> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAcmpki> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcmpki> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("form_load_time", new List<KeyValuePair<string, object>>() {
				new("Form", "TPEQU")
			}, "ms", "Time to load the form.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<Tpequ_ValComponen_RowViewModel>();

				CriteriaSet tpequ___pseudcomponenConds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("CMPKI.ORDER", new OrderedDictionary());
				allSortOrders["CMPKI.ORDER"].Add("CMPKI.ORDER", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "cmpki", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpki.FldOrder), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpki.FldCodcmpki, CSGenioAcmpki.FldZzstate, CSGenioAcmpki.FldOrder, CSGenioAcmpki.FldCodtpeq1, CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAcmpki.FldQuantida, CSGenioAcmpki.FldDescript, CSGenioAcmpki.FldCode, CSGenioAcmpki.FldUrl };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("cmpki", "order");
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
				CSGenioAcmpki model_limit_area = new CSGenioAcmpki(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_TPEQU___PSEUDCOMPONEN");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(tpequ___pseudcomponenConds);
				tpequ___pseudcomponenConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ TPEQU_PSEUDCOMPONEN]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAcmpki>(m_userContext, false, tpequ___pseudcomponenConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TPEQU___PSEUDCOMPONEN", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP TPEQU_PSEUDCOMPONEN]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST TPEQU_PSEUDCOMPONEN]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cmpki");
					Navigation.DestroyEntry("QMVC_POS_RECORD_cmpki");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcmpki.GetInformation(), QMVC_POS_RECORD, sorts, tpequ___pseudcomponenConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAcmpki> listing = Models.ModelBase.Where<CSGenioAcmpki>(m_userContext, false, tpequ___pseudcomponenConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TPEQU___PSEUDCOMPONEN", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapTpequ_ValComponen(listing);

					Menu.Identifier = "IBL_TPEQU___PSEUDCOMPONEN";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_TPEQU___PSEUDCOMPONEN";

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

		private List<Tpequ_ValComponen_RowViewModel> MapTpequ_ValComponen(ListingMVC<CSGenioAcmpki> Qlisting)
		{
			var Elements = new List<Tpequ_ValComponen_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTpequ_ValComponen(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAcmpki row
		/// to a Tpequ_ValComponen_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Tpequ_ValComponen_RowViewModel MapTpequ_ValComponen(CSGenioAcmpki row)
		{
			var model = new Tpequ_ValComponen_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cmpki":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpeq1":
						model.Tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(Tpequ_ValComponen_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAcmpki> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAcmpki row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPEQU_VALCOMPONEN]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Cmpki", "Cmpki.ValCodcmpki", "Cmpki.ValZzstate", "Cmpki.ValOrder", "Tpeq1", "Tpeq1.ValTipoequi", "Cmpki.ValQuantida", "Cmpki.ValDescript", "Cmpki.ValCode", "Cmpki.ValUrl", "Cmpki.ValCodtpeq1", "Cmpki.ValCodtpequ", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValOrder", CSGenioAcmpki.FldOrder, typeof(decimal?)),
			new TableSearchColumn("Tpeq1_ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValQuantida", CSGenioAcmpki.FldQuantida, typeof(decimal?)),
			new TableSearchColumn("ValDescript", CSGenioAcmpki.FldDescript, typeof(string)),
			new TableSearchColumn("ValCode", CSGenioAcmpki.FldCode, typeof(string)),
			new TableSearchColumn("ValUrl", CSGenioAcmpki.FldUrl, typeof(string))
		];



	}
}
