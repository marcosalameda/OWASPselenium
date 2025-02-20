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

namespace GenioMVC.ViewModels.Anexd
{
	public class GQT_Menu_931_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_931_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "anexd"; }

		/// <inheritdoc/>
		public override string Uuid { get => "d0edbebe-a828-4bc2-8c79-fd97739f9c49"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodanexd { get; set; }

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

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS 931]/

			return crs;
		}




		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("anexd", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML931");
			conditions.Equal(CSGenioAanexd.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAanexd.FldCodanexd, CSGenioAanexd.FldZzstate, CSGenioAanexd.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAanexd.FldDthranex, CSGenioAanexd.FldTitle, CSGenioAanexd.FldDocument, CSGenioAanexd.FldCodlang, CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua, CSGenioAanexd.FldTittradu };

			ListingMVC<CSGenioAanexd> listing = new ListingMVC<CSGenioAanexd>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_931_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_931_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAanexd.FldDthranex, FieldType.DATAHORA, Resources.Resources.ATTACHED26247, 16, 0, true),
				new Exports.QColumn(CSGenioAanexd.FldTitle, FieldType.TEXTO, Resources.Resources.TITLE21885, 30, 0, true),
				new Exports.QColumn(CSGenioAanexd.FldDocument, FieldType.FICHEIRO_BD, Resources.Resources.DOCUMENT00695, 30, 0, true),
				new Exports.QColumn(CSGenioAlangu.FldLangua, FieldType.TEXTO, Resources.Resources.IDIOMA44057, 30, 0, true),
				new Exports.QColumn(CSGenioAanexd.FldTittradu, FieldType.TEXTO, Resources.Resources.TITULO_TRADUZIDO52244, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAanexd> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAanexd> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GQT_Menu_931_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ANEXD.DTHRANEX", new OrderedDictionary());
			allSortOrders["ANEXD.DTHRANEX"].Add("ANEXD.DTHRANEX", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Anexd.AddEPH<CSGenioAanexd>(ref u, crs, "ML931");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAanexd.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ANEXD", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAanexd.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_anexd");
				Navigation.DestroyEntry("QMVC_POS_RECORD_anexd");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Anexd.AddEPH<CSGenioAanexd>(ref u, null, "ML931"));
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
			ListingMVC<CSGenioAanexd> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAanexd> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAanexd> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAanexd> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "931"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_931_RowViewModel>();

				CriteriaSet gqt_menu_931Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("ANEXD.DTHRANEX", new OrderedDictionary());
				allSortOrders["ANEXD.DTHRANEX"].Add("ANEXD.DTHRANEX", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "anexd", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAanexd.FldDthranex), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAanexd.FldCodanexd, CSGenioAanexd.FldZzstate, CSGenioAanexd.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAanexd.FldDthranex, CSGenioAanexd.FldTitle, CSGenioAanexd.FldDocument, CSGenioAanexd.FldDocumentfk, CSGenioAanexd.FldCodlang, CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua, CSGenioAanexd.FldTittradu };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("equip", "registnr");
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
				CSGenioAanexd model_limit_area = new CSGenioAanexd(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML931");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_931Conds);
				gqt_menu_931Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 931]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAanexd>(m_userContext, false, gqt_menu_931Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML931", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 931]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 931]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_anexd");
					Navigation.DestroyEntry("QMVC_POS_RECORD_anexd");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAanexd.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_931Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAanexd> listing = Models.ModelBase.Where<CSGenioAanexd>(m_userContext, false, gqt_menu_931Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML931", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_931(listing);

					Menu.Identifier = "ML931";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML931";

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

		private List<GQT_Menu_931_RowViewModel> MapGQT_Menu_931(ListingMVC<CSGenioAanexd> Qlisting)
		{
			var Elements = new List<GQT_Menu_931_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_931(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAanexd row
		/// to a GQT_Menu_931_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_931_RowViewModel MapGQT_Menu_931(CSGenioAanexd row)
		{
			var model = new GQT_Menu_931_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "anexd":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "equip":
						model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "langu":
						model.Langu.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(GQT_Menu_931_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAanexd> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAanexd row in listing.Rows)
			{
				{
					if (!string.IsNullOrEmpty((string)row.returnValueField("anexd.documentfk"))){
						ResourceQuery resource = new ResourceQuery("Anexd", "ValDocument", "ValDocumentfk", row.ValCodanexd);
						string ticket = QResources.CreateTicketEncryptedBase64(m_userContext.User.Name, m_userContext.User.Location, resource);

						row.insertNameValueField("anexd.document", Newtonsoft.Json.JsonConvert.SerializeObject(new
						{
							fileName = row.returnValueField("anexd.document"),
							ticket
						}));
					}
					else
						row.removeFieldValue("anexd.document");
				}
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_931]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Anexd", "Anexd.ValCodanexd", "Anexd.ValZzstate", "Equip", "Equip.ValRegistnr", "Anexd.ValDthranex", "Anexd.ValTitle", "Anexd.ValDocument", "Langu", "Langu.ValLangua", "Anexd.ValTittradu", "Anexd.ValCodequip", "Anexd.ValCodlang", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
			new TableSearchColumn("ValDthranex", CSGenioAanexd.FldDthranex, typeof(DateTime?)),
			new TableSearchColumn("ValTitle", CSGenioAanexd.FldTitle, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDocument", CSGenioAanexd.FldDocument, typeof(string)),
			new TableSearchColumn("Langu_ValLangua", CSGenioAlangu.FldLangua, typeof(string)),
			new TableSearchColumn("ValTittradu", CSGenioAanexd.FldTittradu, typeof(string))
		];



	}
}
