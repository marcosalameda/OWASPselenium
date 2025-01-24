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

namespace GenioMVC.ViewModels.Wpess
{
	public class STY_Menu_IMAGEMAGNIFIER_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<STY_Menu_IMAGEMAGNIFIER_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "wpess"; }

		/// <inheritdoc/>
		public override string Uuid { get => "9113c297-09a6-4691-925e-b000abf7937c"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodpess { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				if (Navigation.CheckKey("wpess.showreco"))
					conds.Equal(CSGenioAwpess.FldShowreco, Navigation.GetValue("wpess.showreco"));
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
			var areaBase = CSGenio.business.Area.createArea("wpess", user, "STY");

			//gets eph conditions to be applied in listing
			CriteriaSet sty_menu_imagemagnifierConds = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLIMAGEMAGNIFIER");
			sty_menu_imagemagnifierConds.Equal(CSGenioAwpess.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

						sty_menu_imagemagnifierConds.Equal(CSGenioAwpess.FldShowreco, 1);


// USE /[MANUAL STY OVERRQ IMAGEMAGNIFIER]/

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldPfoto, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwpess.FldFtimgtop, CSGenioAwpess.FldFtthumb, CSGenioAwpess.FldFtbackgr };

			ListingMVC<CSGenioAwpess> listing = new ListingMVC<CSGenioAwpess>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(sty_menu_imagemagnifierConds, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_IMAGEMAGNIFIER_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public STY_Menu_IMAGEMAGNIFIER_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAwpess.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldDate, FieldType.DATA, Resources.Resources.DATA_DE_NASCIMENTO48110, 8, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldSex, FieldType.ARRAY_COD_TEXTO, Resources.Resources.SEXO52099, 9, 0, true, "SEXO"),
				new Exports.QColumn(CSGenioAwpess.FldNfunc, FieldType.NUMERO, Resources.Resources.NOFUNCIONARIO21429, 6, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldAdress, FieldType.TEXTO, Resources.Resources.ADDRESS04342, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldZipcode, FieldType.TEXTO, Resources.Resources.ZIP_CODE56964, 8, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldCountry, FieldType.TEXTO, Resources.Resources.PAIS04637, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldCellphon, FieldType.NUMERO, Resources.Resources.NOTELEFONE56747, 9, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldNaturali, FieldType.TEXTO, Resources.Resources.NATURALNESS33189, 30, 0, true),
				new Exports.QColumn(CSGenioAwpess.FldNacional, FieldType.TEXTO, Resources.Resources.NACIONALIDADE23735, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAwpess.FldPfoto, FieldType.IMAGEM_JPEG, Resources.Resources.FOTO_DE_PERFIL03502, 3, 1, true):null,
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAwpess.FldFtimgtop, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE_TOP34930, 3, 1, true):null,
				!ajaxRequest ? new Exports.QColumn(CSGenioAwpess.FldFtthumb, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE_THUMBNAIL01682, 3, 1, true):null,
				!ajaxRequest ? new Exports.QColumn(CSGenioAwpess.FldFtbackgr, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE_BACKGROUND07216, 3, 1, true):null,
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<STY_Menu_IMAGEMAGNIFIER_RowViewModel>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("WPESS.NAME", new OrderedDictionary());
			allSortOrders["WPESS.NAME"].Add("WPESS.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "SC"
			crs.Equal(CSGenioAwpess.FldShowreco, "1");

			if (isToExport)
			{
				// EPH
				crs = Models.Wpess.AddEPH<CSGenioAwpess>(ref u, crs, "MLIMAGEMAGNIFIER");

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
					crs.Equals(Models.Wpess.AddEPH<CSGenioAwpess>(ref u, null, "MLIMAGEMAGNIFIER"));
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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAwpess> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "IMAGEMAGNIFIER"),
				new("Module", "STY")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<STY_Menu_IMAGEMAGNIFIER_RowViewModel>();

				CriteriaSet sty_menu_imagemagnifierConds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("WPESS.NAME", new OrderedDictionary());
				allSortOrders["WPESS.NAME"].Add("WPESS.NAME", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "wpess", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwpess.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldPfoto, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwpess.FldFtimgtop, CSGenioAwpess.FldFtthumb, CSGenioAwpess.FldFtbackgr };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("wpess", "name");
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
				CSGenioAwpess model_limit_area = new CSGenioAwpess(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLIMAGEMAGNIFIER");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "SC"
			//Current Area = "WPESS"
			//1st Area Limit: "WPESS"
			//1st Area Field: "SHOWRECO"
			//1st Area Value: "1"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.SC;
				limit.NaoAplicaSeNulo = false;
				CSGenioAwpess model_limit_area = new CSGenioAwpess(m_userContext.User);
				string limit_field = "showreco", limit_field_value = "1";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(sty_menu_imagemagnifierConds);
				sty_menu_imagemagnifierConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ IMAGEMAGNIFIER]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAwpess>(m_userContext, false, sty_menu_imagemagnifierConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLIMAGEMAGNIFIER", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP IMAGEMAGNIFIER]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL STY OVERRQLIST IMAGEMAGNIFIER]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
					Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAwpess.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_imagemagnifierConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAwpess> listing = Models.ModelBase.Where<CSGenioAwpess>(m_userContext, false, sty_menu_imagemagnifierConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLIMAGEMAGNIFIER", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapSTY_Menu_IMAGEMAGNIFIER(listing);

					Menu.Identifier = "MLIMAGEMAGNIFIER";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLIMAGEMAGNIFIER";

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

		private List<STY_Menu_IMAGEMAGNIFIER_RowViewModel> MapSTY_Menu_IMAGEMAGNIFIER(ListingMVC<CSGenioAwpess> Qlisting)
		{
			var Elements = new List<STY_Menu_IMAGEMAGNIFIER_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_IMAGEMAGNIFIER(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAwpess row
		/// to a STY_Menu_IMAGEMAGNIFIER_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private STY_Menu_IMAGEMAGNIFIER_RowViewModel MapSTY_Menu_IMAGEMAGNIFIER(CSGenioAwpess row)
		{
			var model = new STY_Menu_IMAGEMAGNIFIER_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "wpess":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			CalculateButtonPermissions(model);


			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks CRUD conditions to determine which actions the user can perform.
		/// </summary>
		public void CalculateButtonPermissions(STY_Menu_IMAGEMAGNIFIER_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAwpess> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAwpess row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_IMAGEMAGNIFIER]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Wpess", "Wpess.ValCodpess", "Wpess.ValZzstate", "Wpess.ValName", "Wpess.ValDate", "Wpess.ValSex", "Wpess.ValNfunc", "Wpess.ValAdress", "Wpess.ValZipcode", "Wpess.ValCountry", "Wpess.ValEmail", "Wpess.ValCellphon", "Wpess.ValNaturali", "Wpess.ValNacional", "Wpess.ValPfoto", "Wareh", "Wareh.ValWarehdes", "Wpess.ValFtimgtop", "Wpess.ValFtthumb", "Wpess.ValFtbackgr", "Wpess.ValCodwareh", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValName", CSGenioAwpess.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDate", CSGenioAwpess.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValSex", CSGenioAwpess.FldSex, typeof(string), array : "SEXO"),
			new TableSearchColumn("ValNfunc", CSGenioAwpess.FldNfunc, typeof(decimal?)),
			new TableSearchColumn("ValAdress", CSGenioAwpess.FldAdress, typeof(string)),
			new TableSearchColumn("ValZipcode", CSGenioAwpess.FldZipcode, typeof(string)),
			new TableSearchColumn("ValCountry", CSGenioAwpess.FldCountry, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioAwpess.FldEmail, typeof(string)),
			new TableSearchColumn("ValCellphon", CSGenioAwpess.FldCellphon, typeof(decimal?)),
			new TableSearchColumn("ValNaturali", CSGenioAwpess.FldNaturali, typeof(string)),
			new TableSearchColumn("ValNacional", CSGenioAwpess.FldNacional, typeof(string)),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string))
		];



		protected void SetTicketToImageFields(Models.Wpess row)
		{
			if(row == null)
				return;

			row.ValPfotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaWPESS, CSGenioAwpess.FldPfoto.Field, null, row.ValCodpess);
			row.ValFtimgtopQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaWPESS, CSGenioAwpess.FldFtimgtop.Field, null, row.ValCodpess);
			row.ValFtthumbQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaWPESS, CSGenioAwpess.FldFtthumb.Field, null, row.ValCodpess);
			row.ValFtbackgrQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaWPESS, CSGenioAwpess.FldFtbackgr.Field, null, row.ValCodpess);
		}
	}
}
