using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Equip
{
	public class Equip_ValReparaco_ViewModel : MenuListViewModel<Models.Repar>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Equip_ValReparaco_RowViewModel> Menu { get; set; }

		[JsonIgnore]
		public override TableManagementMode ViewsManagementMode => TableManagementMode.PersistMany;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "repar";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Equip_ValReparaco";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string EquipValCodequip { get; set; }

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
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS EQUIP_PSEUDREPARACO]/

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
		public Equip_ValReparaco_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_ValReparaco_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Equip_ValReparaco_ViewModel(UserContext userContext) : base(userContext)
		{
			EquipValCodequip = userContext.CurrentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_ValReparaco_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Equip_ValReparaco_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioArepar.FldNrrepara, FieldType.NUMERIC, Resources.Resources.NO_RUMOUR_IN_THE_COM15248, 10, 0, true),
				new Exports.QColumn(CSGenioArepar.FldDtrepara, FieldType.DATETIME, Resources.Resources.FIXED_IN00179, 16, 0, true),
				new Exports.QColumn(CSGenioAcate1.FldCategoria, FieldType.TEXT, Resources.Resources.SPECIALTY09304, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXT, Resources.Resources.EXPERT27393, 30, 0, true),
				new Exports.QColumn(CSGenioArepar.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION_OF_THE_R26085, 30, 3, true),
				new Exports.QColumn(CSGenioArepar.FldHours, FieldType.NUMERIC, Resources.Resources.SPENT_ON_HOURS19285, 10, 0, true),
				new Exports.QColumn(CSGenioArepar.FldTipoarea, FieldType.ARRAY_TEXT, Resources.Resources.TECHNICAL_AREA50773, 1, 0, true, "AreaTecn"),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

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
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();


			Menu ??= new TablePartial<Equip_ValReparaco_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_ValReparaco_STARTED"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValReparaco_STARTED", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValReparaco_STARTED_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValReparaco_STARTED"))
					filter_ValReparaco_STARTED_1 = tableConfig.GroupFilters["filter_ValReparaco_STARTED"].Contains("1");
				if (filter_ValReparaco_STARTED_1)
				{
					groupFilters.NotEqual(CSGenioArepar.FldTipoarea, "");

				}

				bool filter_ValReparaco_STARTED_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValReparaco_STARTED"))
					filter_ValReparaco_STARTED_2 = tableConfig.GroupFilters["filter_ValReparaco_STARTED"].Contains("2");
				if (filter_ValReparaco_STARTED_2)
				{
					groupFilters.NotEqual(CSGenioArepar.FldDescript, "");

				}

				bool filter_ValReparaco_STARTED_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValReparaco_STARTED"))
					filter_ValReparaco_STARTED_3 = tableConfig.GroupFilters["filter_ValReparaco_STARTED"].Contains("3");
				if (filter_ValReparaco_STARTED_3)
				{
					groupFilters.Greater(CSGenioArepar.FldHours, 0);

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			if (tableConfig.FieldFilters != null)
				crs.SubSets.Add(ProcessFieldFilters(tableConfig.FieldFilters));

			if (this.EquipValCodequip != null)
				crs.Equal(CSGenioArepar.FldCodequip, this.EquipValCodequip);
			else
				tableReload = false;
				

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Repar.AddEPH<CSGenioArepar>(ref u, crs, "IBL_EQUIP___PSEUDREPARACO");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArepar.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("REPAR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArepar.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Repar.AddEPH<CSGenioArepar>(ref u, null, "IBL_EQUIP___PSEUDREPARACO"));
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
			ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Equip_ValReparaco_RowViewModel>();

			CriteriaSet equip___pseudreparacoConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("REPAR.NRREPARA", new OrderedDictionary());
			allSortOrders["REPAR.NRREPARA"].Add("REPAR.NRREPARA", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "repar", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArepar.FldNrrepara), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldCodcateg, CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldDescript, CSGenioArepar.FldHours, CSGenioArepar.FldTipoarea };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("repar", "nrrepara");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArepar model_limit_area = new CSGenioArepar(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_EQUIP___PSEUDREPARACO");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(equip___pseudreparacoConds);
			equip___pseudreparacoConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ EQUIP_PSEUDREPARACO]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioArepar>(m_userContext, false, ref equip___pseudreparacoConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDREPARACO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP EQUIP_PSEUDREPARACO]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST EQUIP_PSEUDREPARACO]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioArepar.GetInformation(), QMVC_POS_RECORD, sorts, equip___pseudreparacoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioArepar> listing = Models.ModelBase.Where<CSGenioArepar>(m_userContext, distinct, equip___pseudreparacoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDREPARACO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapEquip_ValReparaco(listing);

				Menu.Identifier = "IBL_EQUIP___PSEUDREPARACO";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_EQUIP___PSEUDREPARACO";

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

		private List<Equip_ValReparaco_RowViewModel> MapEquip_ValReparaco(ListingMVC<CSGenioArepar> Qlisting)
		{
			List<Equip_ValReparaco_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEquip_ValReparaco(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioArepar row
		/// to a Equip_ValReparaco_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Equip_ValReparaco_RowViewModel MapEquip_ValReparaco(CSGenioArepar row)
		{
			var model = new Equip_ValReparaco_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "repar":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cate1":
						model.Cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pesso":
						model.Pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioArepar> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Repar m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Repar m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_VALREPARACO]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Repar", "Repar.ValCodrepar", "Repar.ValZzstate", "Repar.ValNrrepara", "Repar.ValDtrepara", "Cate1", "Cate1.ValCategoria", "Pesso", "Pesso.ValName", "Repar.ValDescript", "Repar.ValHours", "Repar.ValTipoarea", "Repar.ValCodcateg", "Repar.ValCodempre", "Repar.ValCodequip", "Repar.ValCodpesso", "Repar.ValCodespec"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValNrrepara", CSGenioArepar.FldNrrepara, typeof(decimal?)),
			new TableSearchColumn("ValDtrepara", CSGenioArepar.FldDtrepara, typeof(DateTime?)),
			new TableSearchColumn("Cate1_ValCategoria", CSGenioAcate1.FldCategoria, typeof(string)),
			new TableSearchColumn("Pesso_ValName", CSGenioApesso.FldName, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioArepar.FldDescript, typeof(string)),
			new TableSearchColumn("ValHours", CSGenioArepar.FldHours, typeof(decimal?)),
			new TableSearchColumn("ValTipoarea", CSGenioArepar.FldTipoarea, typeof(string), array : "AreaTecn"),
		];
	}
}
