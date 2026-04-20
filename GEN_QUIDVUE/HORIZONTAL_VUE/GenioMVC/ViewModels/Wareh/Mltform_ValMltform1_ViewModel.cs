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

namespace GenioMVC.ViewModels.Wareh
{
	public class Mltform_ValMltform1_ViewModel : MenuListViewModel<Models.Wpess>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "wpess";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Mltform_ValMltform1";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string WarehValCodwareh { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS MLTFORM_PSEUDMLTFORM1]/

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
		public Mltform_ValMltform1_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Mltform_ValMltform1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Mltform_ValMltform1_ViewModel(UserContext userContext) : base(userContext)
		{
			WarehValCodwareh = userContext.CurrentNavigation.CurrentLevel.GetEntry("wareh")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Mltform_ValMltform1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Mltform_ValMltform1_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAwpess.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldNfunc, FieldType.NUMERIC, Resources.Resources.EMPLOYEE_NUMBER50873, 1, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldDate, FieldType.DATE, Resources.Resources.BIRTH_DATE00284, 8, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			if (this.WarehValCodwareh != null)
				crs.Equal(CSGenioAwpess.FldCodwareh, this.WarehValCodwareh);
			else
				tableReload = false;


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Wpess.AddEPH<CSGenioAwpess>(ref u, crs, "IBL_MLTFORM_PSEUDMLTFORM1");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAwpess.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("WPESS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAwpess.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Wpess.AddEPH<CSGenioAwpess>(ref u, null, "IBL_MLTFORM_PSEUDMLTFORM1"));
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
			ListingMVC<CSGenioAwpess> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAwpess> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAwpess> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAwpess> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();

			CriteriaSet mltform_pseudmltform1Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "wpess", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldPfoto, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("wpess", "name");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAwpess model_limit_area = new CSGenioAwpess(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_MLTFORM_PSEUDMLTFORM1");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(mltform_pseudmltform1Conds);
			mltform_pseudmltform1Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ MLTFORM_PSEUDMLTFORM1]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAwpess>(m_userContext, false, ref mltform_pseudmltform1Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_MLTFORM_PSEUDMLTFORM1", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP MLTFORM_PSEUDMLTFORM1]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST MLTFORM_PSEUDMLTFORM1]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAwpess.GetInformation(), QMVC_POS_RECORD, sorts, mltform_pseudmltform1Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAwpess> listing = Models.ModelBase.Where<CSGenioAwpess>(m_userContext, distinct, mltform_pseudmltform1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_MLTFORM_PSEUDMLTFORM1", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<GenioMVC.ViewModels.Wpess.Armapess_ViewModel> tempList = new List<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();

				//By using the support form it will create entries into the navigation, making the next rows equal to the first one
				//This puts back the navigation to the starting point before calling the multiform support form
				NavigationContext Cloned = m_userContext.CurrentNavigation.Clone();

				foreach (GenioMVC.Models.Wpess Wpess in listing.RowsForViewModel<GenioMVC.Models.Wpess>((r) => new GenioMVC.Models.Wpess(m_userContext, r, true)))
				{
					tempList.Add(new GenioMVC.ViewModels.Wpess.Armapess_ViewModel(m_userContext, Wpess));
					m_userContext.SetNavigation(Cloned.Clone());
				}
				this.Menu.Elements = tempList;

				Menu.Identifier = "IBL_MLTFORM_PSEUDMLTFORM1";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_MLTFORM_PSEUDMLTFORM1";

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

		private List<Models.Wpess> MapMltform_ValMltform1(ListingMVC<CSGenioAwpess> Qlisting)
		{
			List<Models.Wpess> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapMltform_ValMltform1(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAwpess row
		/// to a Models.Wpess object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Wpess MapMltform_ValMltform1(CSGenioAwpess row)
		{
			var model = new Models.Wpess(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "wpess":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return false;
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAwpess> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Wpess m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Wpess m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM MLTFORM_VALMLTFORM1]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Wpess", "Wpess.ValCodpess", "Wpess.ValZzstate", "Wpess.ValName", "Wpess.ValNfunc", "Wpess.ValDate", "Wpess.ValCodwareh"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValNfunc", CSGenioAwpess.FldNfunc, typeof(decimal?)),
			new TableSearchColumn("ValName", CSGenioAwpess.FldName, typeof(string)),
			new TableSearchColumn("ValDate", CSGenioAwpess.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValSex", CSGenioAwpess.FldSex, typeof(string)),
			new TableSearchColumn("ValNaturali", CSGenioAwpess.FldNaturali, typeof(string)),
			new TableSearchColumn("ValNacional", CSGenioAwpess.FldNacional, typeof(string)),
			new TableSearchColumn("ValAdress", CSGenioAwpess.FldAdress, typeof(string)),
			new TableSearchColumn("ValZipcode", CSGenioAwpess.FldZipcode, typeof(string)),
			new TableSearchColumn("ValCountry", CSGenioAwpess.FldCountry, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioAwpess.FldEmail, typeof(string)),
			new TableSearchColumn("ValCellphon", CSGenioAwpess.FldCellphon, typeof(decimal?)),
			new TableSearchColumn("ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string))		];
	}
}
