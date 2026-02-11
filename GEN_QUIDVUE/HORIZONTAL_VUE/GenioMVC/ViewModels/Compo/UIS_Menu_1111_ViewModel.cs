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

namespace GenioMVC.ViewModels.Compo
{
	public class UIS_Menu_1111_ViewModel : MenuListViewModel<Models.Compo>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<UIS_Menu_1111_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "compo";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "41296779-bc8e-467e-99de-7654e1b2da77";

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
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAcompo.FldCodcompc, Navigation.GetValue("compc"));

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
// USE /[MANUAL UIS LIST_LIMITS 1111]/

			return crs;
		}

		public string CompcValCompclas { get; set; }

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param
		private void SetViewModelValue(string fullFieldName, object value)
		{
			if (string.IsNullOrEmpty(fullFieldName))
				return;

			switch (fullFieldName)
			{
				case "compc.compclas":
					CompcValCompclas = ViewModelConversion.ToString(value);
					break;
			}
		}

		/// <summary>
		/// Loads from the database the values of fields used in the menu title, columns show when, etc and populates them in the ViewModel.
		/// </summary>
		public void LoadAdditionalFields()
		{
			string[] additionalFields = ["compc.compclas"];
			FieldRef[] refAdditionalFields = [CSGenioAcompc.FldCompclas];

			var sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;
			CSGenioAcompc tempEmptyArea = new(u);

			// Fields to select
			SelectQuery querySelect = new SelectQuery();
			querySelect.PageSize(1);
			foreach (FieldRef field in refAdditionalFields)
				querySelect.Select(field);

			var args = CriteriaSet.And()
				.Equal(CSGenioAcompc.FldZzstate, 0)
				.Equal(CSGenioAcompc.FldCodcompc, Navigation.GetValue("compc"));

			args = Models.Compc.AddEPH<CSGenioAcompc>(ref u, args, "ML111");
			querySelect.From(tempEmptyArea.QSystem, tempEmptyArea.TableName, tempEmptyArea.Alias).Where(args);
			CSGenio.persistence.QueryUtils.SetInnerJoins(additionalFields, args, tempEmptyArea, querySelect);

			var dbValues = sp.executeReaderOneRow(querySelect);
			for (int i = 0; i < dbValues.Count; i++)
				SetViewModelValue(querySelect.SelectFields[i].Alias, dbValues[i]);
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("compo", user, "UIS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML1111");
			conditions.Equal(CSGenioAcompo.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAcompo.FldCodcompo, CSGenioAcompo.FldZzstate, CSGenioAcompo.FldComptype, CSGenioAcompo.FldCompicon, CSGenioAcompo.FldRelease, CSGenioAcompo.FldMvc, CSGenioAcompo.FldVuemvc, CSGenioAcompo.FldCompdesc };

			ListingMVC<CSGenioAcompo> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaCOMPC.Alias))
				qs.Join(CSGenio.business.Area.AreaCOMPC, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAcompc.FldCodcompc, CSGenioAcompo.FldCodcompc));




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public UIS_Menu_1111_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="UIS_Menu_1111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public UIS_Menu_1111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UIS_Menu_1111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public UIS_Menu_1111_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAcompo.FldComptype, FieldType.TEXT, Resources.Resources.COMPONENT_TYPE58053, 30, 0, true),
				new Exports.QColumn(CSGenioAcompo.FldCompicon, FieldType.ARRAY_NUMERIC, Resources.Resources.COMPONENT_CLASS55392, 1, 0, true, "componenticons"),
				new Exports.QColumn(CSGenioAcompo.FldRelease, FieldType.TEXT, Resources.Resources.RELEASE04894, 15, 0, true),
				new Exports.QColumn(CSGenioAcompo.FldMvc, FieldType.LOGIC, Resources.Resources.MVC48022, 1, 0, true),
				new Exports.QColumn(CSGenioAcompo.FldVuemvc, FieldType.LOGIC, Resources.Resources.VUE05393, 1, 0, true),
				new Exports.QColumn(CSGenioAcompo.FldCompdesc, FieldType.MEMO, Resources.Resources.DESCRIPTION07438, 100, 5, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAcompo> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcompo> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			Menu ??= new TablePartial<UIS_Menu_1111_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAcompo.FldCodcompc, Navigation.GetValue("compc"));
			if (isToExport)
			{
				// EPH
				crs = Models.Compo.AddEPH<CSGenioAcompo>(ref u, crs, "ML1111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcompo.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("COMPO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcompo.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_compo");
				Navigation.DestroyEntry("QMVC_POS_RECORD_compo");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Compo.AddEPH<CSGenioAcompo>(ref u, null, "ML1111"));
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
			ListingMVC<CSGenioAcompo> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcompo> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAcompo> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcompo> Qlisting, ref CriteriaSet conditions)
		{
			// Load the values of the fields used in the title or columns show when formulas
			LoadAdditionalFields();

			User u = m_userContext.User;
			Menu = new TablePartial<UIS_Menu_1111_RowViewModel>();

			CriteriaSet uis_menu_1111Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "compo", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAcompo.FldCodcompo, CSGenioAcompo.FldZzstate, CSGenioAcompo.FldComptype, CSGenioAcompo.FldCompicon, CSGenioAcompo.FldRelease, CSGenioAcompo.FldMvc, CSGenioAcompo.FldVuemvc, CSGenioAcompo.FldCompdesc };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("compo", "comptype");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(uis_menu_1111Conds);
			uis_menu_1111Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL UIS OVERRQ 1111]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAcompo>(m_userContext, false, ref uis_menu_1111Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL UIS OVERRQLSTEXP 1111]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL UIS OVERRQLIST 1111]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_compo");
				Navigation.DestroyEntry("QMVC_POS_RECORD_compo");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcompo.GetInformation(), QMVC_POS_RECORD, sorts, uis_menu_1111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAcompo> listing = Models.ModelBase.Where<CSGenioAcompo>(m_userContext, distinct, uis_menu_1111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapUIS_Menu_1111(listing);

				Menu.Identifier = "ML1111";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML1111";

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

		private List<UIS_Menu_1111_RowViewModel> MapUIS_Menu_1111(ListingMVC<CSGenioAcompo> Qlisting)
		{
			List<UIS_Menu_1111_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapUIS_Menu_1111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAcompo row
		/// to a UIS_Menu_1111_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private UIS_Menu_1111_RowViewModel MapUIS_Menu_1111(CSGenioAcompo row)
		{
			var model = new UIS_Menu_1111_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "compo":
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
		private void SetDocumentFields(ListingMVC<CSGenioAcompo> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Compo m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Compo) to ViewModel (UIS_Menu_1111) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				CompcValCompclas = ViewModelConversion.ToString(m.Compc.ValCompclas);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map Model (Compo) to ViewModel (UIS_Menu_1111) - Error during mapping.");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Compo m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (UIS_Menu_1111) to Model (Compo) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.Compc.ValCompclas = ViewModelConversion.ToString(CompcValCompclas);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map ViewModel (UIS_Menu_1111) to Model (Compo) - Error during mapping.");
				throw;
			}
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM UIS_MENU_1111]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Compo", "Compo.ValCodcompo", "Compo.ValZzstate", "Compo.ValComptype", "Compo.ValCompicon", "Compo.ValRelease", "Compo.ValMvc", "Compo.ValVuemvc", "Compo.ValCompdesc", "Compo.ValCodcompc"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValComptype", CSGenioAcompo.FldComptype, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValCompicon", CSGenioAcompo.FldCompicon, typeof(decimal), array : "componenticons"),
			new TableSearchColumn("ValRelease", CSGenioAcompo.FldRelease, typeof(string)),
			new TableSearchColumn("ValMvc", CSGenioAcompo.FldMvc, typeof(bool)),
			new TableSearchColumn("ValVuemvc", CSGenioAcompo.FldVuemvc, typeof(bool)),
			new TableSearchColumn("ValCompdesc", CSGenioAcompo.FldCompdesc, typeof(string)),
		];
	}
}
