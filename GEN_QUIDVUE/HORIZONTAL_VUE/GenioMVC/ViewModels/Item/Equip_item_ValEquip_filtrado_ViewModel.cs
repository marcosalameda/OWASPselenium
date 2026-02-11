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

namespace GenioMVC.ViewModels.Item
{
	public class Equip_item_ValEquip_filtrado_ViewModel : MenuListViewModel<Models.Equip>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Equip_item_ValEquip_filtrado_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "equip";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Equip_item_ValEquip_filtrado";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ItemValCoditem { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS EQUIP_ITEM_PSEUDEQUIP_FILTRADO]/

			return crs;
		}

		public string ValCodwareh { get; set; }

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Equip_item_ValEquip_filtrado_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_item_ValEquip_filtrado_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Equip_item_ValEquip_filtrado_ViewModel(UserContext userContext) : base(userContext)
		{
			ItemValCoditem = userContext.CurrentNavigation.CurrentLevel.GetEntry("item")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_item_ValEquip_filtrado_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Equip_item_ValEquip_filtrado_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAequip.FldDtrefere, FieldType.DATETIME, Resources.Resources.REFERENCE28402, 16, 0, true),
				new Exports.QColumn(CSGenioAequip.FldIfabatif, FieldType.LOGIC, Resources.Resources.DOWNED_EQUIPMENT43331, 1, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXT, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldLast, FieldType.TEXT, Resources.Resources.LAST49207, 10, 0, true),
				new Exports.QColumn(CSGenioAroom1.FldRoomnr, FieldType.TEXT, Resources.Resources.N_R__ROOM43805, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldMoviment, FieldType.MEMO, Resources.Resources.DRIVES34119, 30, 2, true),
				new Exports.QColumn(CSGenioAdecom.FldDecomnr, FieldType.NUMERIC, Resources.Resources.NO_BATE21045, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldBefore, FieldType.TEXT, Resources.Resources.BEFORE60156, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldShowrc, FieldType.LOGIC, Resources.Resources.SHOW_RECORD53851, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFollowin, FieldType.TEXT, Resources.Resources.FOLLOWING22170, 10, 0, true),
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXT, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFirst, FieldType.TEXT, Resources.Resources.FIRST42972, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldQtdmovim, FieldType.NUMERIC, Resources.Resources.QTD__MOVIMENTACOES28400, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldValortot, FieldType.CURRENCY, Resources.Resources.TOTAL_VALUE30570, 12, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtdeco, FieldType.DATETIME, Resources.Resources.DECOMISSION14486, 16, 0, true),
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXT, Resources.Resources.WAREHOUSE51864, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXT, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtaquisi, FieldType.DATE, Resources.Resources.ACQUISITION44180, 8, 0, true),
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXT, Resources.Resources.ARTICLE60065, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXT, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAequip.FldBought, FieldType.LOGIC, Resources.Resources.BOUGHT32044, 1, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFrequenc, FieldType.ARRAY_NUMERIC, Resources.Resources.LOAN_FREQUENCY00701, 2, 0, true, "FreqEmpr"),
				new Exports.QColumn(CSGenioAequip.FldSitefabr, FieldType.TEXT, Resources.Resources.MANUFACTURER_S_WEBSI11084, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldSequennr, FieldType.NUMERIC, Resources.Resources.SEQUENTIAL_NO_38590, 6, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);

			Menu ??= new TablePartial<Equip_item_ValEquip_filtrado_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			if (tableConfig.FieldFilters != null)
				crs.SubSets.Add(ProcessFieldFilters(tableConfig.FieldFilters));

			if (this.ItemValCoditem != null)
				crs.Equal(CSGenioAequip.FldCoditem, this.ItemValCoditem);
			else
				tableReload = false;
				

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO");

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
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO"));
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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAequip> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Equip_item_ValEquip_filtrado_RowViewModel>();

			CriteriaSet equip_item__pseud__equip_filtradoConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "equip", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldDtrefere, CSGenioAequip.FldLastpho, CSGenioAequip.FldIfabatif, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldLast, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldMoviment, CSGenioAequip.FldCoddeco, CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAequip.FldBefore, CSGenioAequip.FldShowrc, CSGenioAequip.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAequip.FldFollowin, CSGenioAequip.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAequip.FldFirst, CSGenioAequip.FldQtdmovim, CSGenioAequip.FldValortot, CSGenioAequip.FldDtdeco, CSGenioAequip.FldPhotogra, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAequip.FldRegistnr, CSGenioAequip.FldBought, CSGenioAequip.FldFrequenc, CSGenioAequip.FldSitefabr, CSGenioAequip.FldSequennr };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("equip", "dtrefere");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAequip model_limit_area = new CSGenioAequip(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 
			//Limit type: "A"
			//Current Area = "EQUIP"
			//1st Area Limit: "WAREH"
			//1st Area Field: "CODWAREH"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioAwareh model_limit_area = new CSGenioAwareh(m_userContext.User);
				string limit_field = "codwareh", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("wareh") == null ? this.ValCodwareh : Navigation.GetValue("wareh");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(equip_item__pseud__equip_filtradoConds);
			equip_item__pseud__equip_filtradoConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ EQUIP_ITEM_PSEUDEQUIP_FILTRADO]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAequip>(m_userContext, false, ref equip_item__pseud__equip_filtradoConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP EQUIP_ITEM_PSEUDEQUIP_FILTRADO]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST EQUIP_ITEM_PSEUDEQUIP_FILTRADO]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
				Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, equip_item__pseud__equip_filtradoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, distinct, equip_item__pseud__equip_filtradoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapEquip_item_ValEquip_filtrado(listing);

				Menu.Identifier = "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_EQUIP_ITEM__PSEUD__EQUIP_FILTRADO";

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

		private List<Equip_item_ValEquip_filtrado_RowViewModel> MapEquip_item_ValEquip_filtrado(ListingMVC<CSGenioAequip> Qlisting)
		{
			List<Equip_item_ValEquip_filtrado_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEquip_item_ValEquip_filtrado(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAequip row
		/// to a Equip_item_ValEquip_filtrado_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Equip_item_ValEquip_filtrado_RowViewModel MapEquip_item_ValEquip_filtrado(CSGenioAequip row)
		{
			var model = new Equip_item_ValEquip_filtrado_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpequ":
						model.Tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "room1":
						model.Room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "decom":
						model.Decom.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pess1":
						model.Pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "item":
						model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			// Use the parent context, so the formulas are calculated with the current values.
			model.Item = ParentCtx as Models.Item;

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
		private void SetDocumentFields(ListingMVC<CSGenioAequip> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Equip m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Equip m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_ITEM_VALEQUIP_FILTRADO]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValDtrefere", "Equip.ValLastpho", "Equip.ValIfabatif", "Tpequ", "Tpequ.ValTipoequi", "Equip.ValLast", "Room1", "Room1.ValRoomnr", "Equip.ValMoviment", "Decom", "Decom.ValDecomnr", "Equip.ValBefore", "Equip.ValShowrc", "Pess1", "Pess1.ValName", "Equip.ValFollowin", "Cmpny", "Cmpny.ValDesignat", "Equip.ValFirst", "Equip.ValQtdmovim", "Equip.ValValortot", "Equip.ValDtdeco", "Equip.ValPhotogra", "Wareh", "Wareh.ValWarehdes", "Equip.ValDesignat", "Equip.ValDtaquisi", "Item", "Item.ValItemdes", "Equip.ValRegistnr", "Equip.ValBought", "Equip.ValFrequenc", "Equip.ValSitefabr", "Equip.ValSequennr", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodrooms", "Equip.ValCodtpequ", "Equip.ValCodwareh"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValDtrefere", CSGenioAequip.FldDtrefere, typeof(DateTime?)),
			new TableSearchColumn("ValIfabatif", CSGenioAequip.FldIfabatif, typeof(bool)),
			new TableSearchColumn("Tpequ_ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValLast", CSGenioAequip.FldLast, typeof(string)),
			new TableSearchColumn("Room1_ValRoomnr", CSGenioAroom1.FldRoomnr, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValMoviment", CSGenioAequip.FldMoviment, typeof(string)),
			new TableSearchColumn("Decom_ValDecomnr", CSGenioAdecom.FldDecomnr, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValBefore", CSGenioAequip.FldBefore, typeof(string)),
			new TableSearchColumn("ValShowrc", CSGenioAequip.FldShowrc, typeof(bool)),
			new TableSearchColumn("Pess1_ValName", CSGenioApess1.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValFollowin", CSGenioAequip.FldFollowin, typeof(string)),
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValFirst", CSGenioAequip.FldFirst, typeof(string)),
			new TableSearchColumn("ValQtdmovim", CSGenioAequip.FldQtdmovim, typeof(decimal?)),
			new TableSearchColumn("ValValortot", CSGenioAequip.FldValortot, typeof(decimal?)),
			new TableSearchColumn("ValDtdeco", CSGenioAequip.FldDtdeco, typeof(DateTime?)),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
			new TableSearchColumn("ValDtaquisi", CSGenioAequip.FldDtaquisi, typeof(DateTime?)),
			new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValBought", CSGenioAequip.FldBought, typeof(bool)),
			new TableSearchColumn("ValFrequenc", CSGenioAequip.FldFrequenc, typeof(decimal), array : "FreqEmpr"),
			new TableSearchColumn("ValSitefabr", CSGenioAequip.FldSitefabr, typeof(string)),
			new TableSearchColumn("ValSequennr", CSGenioAequip.FldSequennr, typeof(decimal?)),
		];
		protected void SetTicketToImageFields(Models.Equip row)
		{
			if (row == null)
				return;

			row.ValLastphoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldLastpho.Field, null, row.ValCodequip);
			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, row.ValCodequip);
		}

		private static readonly List<Field> _globalFilters =
		[
			CSGenioAcntry.GetInformation().DBFields[CSGenioAcntry.FldCodcntry.Field],
			CSGenioAcmpny.GetInformation().DBFields[CSGenioAcmpny.FldCodempre.Field],
			CSGenioApess1.GetInformation().DBFields[CSGenioApess1.FldCodpesso.Field],
		];
		protected override List<Field> GlobalFilters => _globalFilters;
	}
}
