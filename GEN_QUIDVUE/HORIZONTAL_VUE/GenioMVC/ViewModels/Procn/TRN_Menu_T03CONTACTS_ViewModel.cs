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

namespace GenioMVC.ViewModels.Procn
{
	public class TRN_Menu_T03CONTACTS_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<TRN_Menu_T03CONTACTS_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "procn"; }

		/// <inheritdoc/>
		public override string Uuid { get => "f466d4c5-0d31-47ec-9148-68505eb904b5"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodprocn { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				return conds;
			}
		}

		/// <inheritdoc/>
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}


		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("procn", user, "TRN");

			//gets eph conditions to be applied in listing
			CriteriaSet trn_menu_t03contactsConds = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLT03CONTACTS");
			trn_menu_t03contactsConds.Equal(CSGenioAprocn.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

// USE /[MANUAL TRN OVERRQ T03CONTACTS]/

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAprocn.FldCodprocn, CSGenioAprocn.FldZzstate, CSGenioAprocn.FldName, CSGenioAprocn.FldEmail, CSGenioAprocn.FldTelephon, CSGenioAprocn.FldDescript, CSGenioAprocn.FldDate, CSGenioAprocn.FldCodprope, CSGenioAprope.FldCodprope, CSGenioAprope.FldTitle };

			ListingMVC<CSGenioAprocn> listing = new ListingMVC<CSGenioAprocn>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(trn_menu_t03contactsConds, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TRN_Menu_T03CONTACTS_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TRN_Menu_T03CONTACTS_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAprocn.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAprocn.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioAprocn.FldTelephon, FieldType.TEXTO, Resources.Resources.TELEPHONE28697, 30, 0, true),
				new Exports.QColumn(CSGenioAprocn.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
				new Exports.QColumn(CSGenioAprocn.FldDate, FieldType.DATA, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAprope.FldTitle, FieldType.TEXTO, Resources.Resources.TITLE21885, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAprocn> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAprocn> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<TRN_Menu_T03CONTACTS_RowViewModel>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PROCN.NAME", new OrderedDictionary());
			allSortOrders["PROCN.NAME"].Add("PROCN.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Procn.AddEPH<CSGenioAprocn>(ref u, crs, "MLT03CONTACTS");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAprocn.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROCN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAprocn.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_procn");
				Navigation.DestroyEntry("QMVC_POS_RECORD_procn");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Procn.AddEPH<CSGenioAprocn>(ref u, null, "MLT03CONTACTS"));
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
			ListingMVC<CSGenioAprocn> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprocn> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAprocn> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprocn> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "T03CONTACTS"),
				new("Module", "TRN")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<TRN_Menu_T03CONTACTS_RowViewModel>();

				CriteriaSet trn_menu_t03contactsConds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PROCN.NAME", new OrderedDictionary());
				allSortOrders["PROCN.NAME"].Add("PROCN.NAME", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "procn", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAprocn.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAprocn.FldCodprocn, CSGenioAprocn.FldZzstate, CSGenioAprocn.FldName, CSGenioAprocn.FldEmail, CSGenioAprocn.FldTelephon, CSGenioAprocn.FldDescript, CSGenioAprocn.FldDate, CSGenioAprocn.FldCodprope, CSGenioAprope.FldCodprope, CSGenioAprope.FldTitle };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("procn", "name");
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
				CSGenioAprocn model_limit_area = new CSGenioAprocn(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLT03CONTACTS");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(trn_menu_t03contactsConds);
				trn_menu_t03contactsConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TRN OVERRQ T03CONTACTS]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAprocn>(m_userContext, false, trn_menu_t03contactsConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLT03CONTACTS", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TRN OVERRQLSTEXP T03CONTACTS]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL TRN OVERRQLIST T03CONTACTS]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_procn");
					Navigation.DestroyEntry("QMVC_POS_RECORD_procn");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAprocn.GetInformation(), QMVC_POS_RECORD, sorts, trn_menu_t03contactsConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAprocn> listing = Models.ModelBase.Where<CSGenioAprocn>(m_userContext, false, trn_menu_t03contactsConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLT03CONTACTS", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapTRN_Menu_T03CONTACTS(listing);

					Menu.Identifier = "MLT03CONTACTS";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLT03CONTACTS";

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

		private List<TRN_Menu_T03CONTACTS_RowViewModel> MapTRN_Menu_T03CONTACTS(ListingMVC<CSGenioAprocn> Qlisting)
		{
			var Elements = new List<TRN_Menu_T03CONTACTS_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTRN_Menu_T03CONTACTS(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAprocn row
		/// to a TRN_Menu_T03CONTACTS_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TRN_Menu_T03CONTACTS_RowViewModel MapTRN_Menu_T03CONTACTS(CSGenioAprocn row)
		{
			var model = new TRN_Menu_T03CONTACTS_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "procn":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "prope":
						model.Prope.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(TRN_Menu_T03CONTACTS_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAprocn> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAprocn row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TRN_MENU_T03CONTACTS]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Procn", "Procn.ValCodprocn", "Procn.ValZzstate", "Procn.ValName", "Procn.ValEmail", "Procn.ValTelephon", "Procn.ValDescript", "Procn.ValDate", "Prope", "Prope.ValTitle", "Procn.ValCodprope", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValName", CSGenioAprocn.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValEmail", CSGenioAprocn.FldEmail, typeof(string)),
			new TableSearchColumn("ValTelephon", CSGenioAprocn.FldTelephon, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioAprocn.FldDescript, typeof(string)),
			new TableSearchColumn("ValDate", CSGenioAprocn.FldDate, typeof(DateTime?)),
			new TableSearchColumn("Prope_ValTitle", CSGenioAprope.FldTitle, typeof(string))
		];



	}
}
