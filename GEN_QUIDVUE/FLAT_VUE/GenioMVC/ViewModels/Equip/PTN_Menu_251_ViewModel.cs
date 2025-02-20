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

namespace GenioMVC.ViewModels.Equip
{
	public class PTN_Menu_251_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "${exposeField.Fajuda}"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_251_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "equip"; }

		/// <inheritdoc/>
		public override string Uuid { get => "78f755ff-cf65-4633-86d1-399c04d9bb97"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodequip { get; set; }

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
// USE /[MANUAL PTN LIST_LIMITS 251]/

			return crs;
		}




		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("equip", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML251");
			conditions.Equal(CSGenioAequip.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAequip.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAequip.FldSequennr, CSGenioAequip.FldRegistnr, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldCoddeco, CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAequip.FldDtdeco, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldFrequenc, CSGenioAequip.FldBought, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldDtrefere, CSGenioAequip.FldFirst, CSGenioAequip.FldBefore, CSGenioAequip.FldFollowin, CSGenioAequip.FldLast, CSGenioAequip.FldSitefabr, CSGenioAequip.FldLastpho, CSGenioAequip.FldMoviment, CSGenioAequip.FldQtdmovim, CSGenioAequip.FldShowrc };

			ListingMVC<CSGenioAequip> listing = new ListingMVC<CSGenioAequip>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_251_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_251_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldSequennr, FieldType.NUMERO, Resources.Resources.SEQUENTIAL_NO_38590, 6, 0, true),
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXTO, Resources.Resources.ARTICLE60065, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtaquisi, FieldType.DATA, Resources.Resources.ACQUISITION44180, 8, 0, true),
				new Exports.QColumn(CSGenioAdecom.FldDecomnr, FieldType.NUMERO, Resources.Resources.NO_BATE21045, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtdeco, FieldType.DATA, Resources.Resources.DECOMISSION14486, 8, 0, true),
				new Exports.QColumn(CSGenioAequip.FldIfabatif, FieldType.LOGICO, Resources.Resources.DOWNED_EQUIPMENT43331, 1, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioAequip.FldValortot, FieldType.VALOR, Resources.Resources.TOTAL_VALUE30570, 12, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFrequenc, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.LOAN_FREQUENCY00701, 1, 0, true, "FreqEmpr"),
				new Exports.QColumn(CSGenioAequip.FldBought, FieldType.LOGICO, Resources.Resources.BOUGHT32044, 1, 0, true),
				new Exports.QColumn(CSGenioAroom1.FldRoomnr, FieldType.TEXTO, Resources.Resources.N_R__ROOM43805, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtrefere, FieldType.DATAHORA, Resources.Resources.REFERENCE28402, 16, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFirst, FieldType.TEXTO, Resources.Resources.FIRST42972, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldBefore, FieldType.TEXTO, Resources.Resources.BEFORE60156, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFollowin, FieldType.TEXTO, Resources.Resources.FOLLOWING22170, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldLast, FieldType.TEXTO, Resources.Resources.LAST49207, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldSitefabr, FieldType.TEXTO, Resources.Resources.MANUFACTURER_S_WEBSI11084, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldLastpho, FieldType.IMAGEM_JPEG, Resources.Resources.LAST_PHOTO_ATTACHED43884, 3, 1, true):null,
				new Exports.QColumn(CSGenioAequip.FldMoviment, FieldType.MEMO, Resources.Resources.DRIVES34119, 30, 2, true),
				new Exports.QColumn(CSGenioAequip.FldQtdmovim, FieldType.NUMERO, Resources.Resources.QTD__MOVIMENTACOES28400, 10, 0, true),
				new Exports.QColumn(CSGenioAequip.FldShowrc, FieldType.LOGICO, Resources.Resources.SHOW_RECORD53851, 1, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<PTN_Menu_251_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
			allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "ML251");

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
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "ML251"));
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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAequip> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>() {
				new("Menu", "251"),
				new("Module", "PTN")
			}, "ms", "Time to load the menu.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_251_RowViewModel>();

				CriteriaSet ptn_menu_251Conds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
				allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "equip", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAequip.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAequip.FldSequennr, CSGenioAequip.FldRegistnr, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldCoddeco, CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAequip.FldDtdeco, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldFrequenc, CSGenioAequip.FldBought, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldDtrefere, CSGenioAequip.FldFirst, CSGenioAequip.FldBefore, CSGenioAequip.FldFollowin, CSGenioAequip.FldLast, CSGenioAequip.FldSitefabr, CSGenioAequip.FldLastpho, CSGenioAequip.FldMoviment, CSGenioAequip.FldQtdmovim, CSGenioAequip.FldShowrc };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("cmpny", "designat");
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
				CSGenioAequip model_limit_area = new CSGenioAequip(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML251");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_251Conds);
				ptn_menu_251Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 251]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, ptn_menu_251Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML251", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 251]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST 251]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
					Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_251Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, ptn_menu_251Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML251", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapPTN_Menu_251(listing);

					Menu.Identifier = "ML251";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML251";

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

		private List<PTN_Menu_251_RowViewModel> MapPTN_Menu_251(ListingMVC<CSGenioAequip> Qlisting)
		{
			var Elements = new List<PTN_Menu_251_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_251(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioAequip row
		/// to a PTN_Menu_251_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_251_RowViewModel MapPTN_Menu_251(CSGenioAequip row)
		{
			var model = new PTN_Menu_251_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pess1":
						model.Pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpequ":
						model.Tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "item":
						model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "decom":
						model.Decom.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "room1":
						model.Room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		public void CalculateButtonPermissions(PTN_Menu_251_RowViewModel model)
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
		private void SetDocumentFields(ListingMVC<CSGenioAequip> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAequip row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_251]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Cmpny", "Cmpny.ValDesignat", "Pess1", "Pess1.ValName", "Equip.ValSequennr", "Equip.ValRegistnr", "Tpequ", "Tpequ.ValTipoequi", "Wareh", "Wareh.ValWarehdes", "Item", "Item.ValItemdes", "Equip.ValDesignat", "Equip.ValDtaquisi", "Decom", "Decom.ValDecomnr", "Equip.ValDtdeco", "Equip.ValIfabatif", "Equip.ValPhotogra", "Equip.ValValortot", "Equip.ValFrequenc", "Equip.ValBought", "Room1", "Room1.ValRoomnr", "Equip.ValDtrefere", "Equip.ValFirst", "Equip.ValBefore", "Equip.ValFollowin", "Equip.ValLast", "Equip.ValSitefabr", "Equip.ValLastpho", "Equip.ValMoviment", "Equip.ValQtdmovim", "Equip.ValShowrc", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodrooms", "Equip.ValCodtpequ", "Equip.ValCodwareh", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
			new TableSearchColumn("Pess1_ValName", CSGenioApess1.FldName, typeof(string)),
			new TableSearchColumn("ValSequennr", CSGenioAequip.FldSequennr, typeof(decimal?)),
			new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string), defaultSearch : true),
			new TableSearchColumn("Tpequ_ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string)),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string)),
			new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string)),
			new TableSearchColumn("ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
			new TableSearchColumn("ValDtaquisi", CSGenioAequip.FldDtaquisi, typeof(DateTime?)),
			new TableSearchColumn("Decom_ValDecomnr", CSGenioAdecom.FldDecomnr, typeof(decimal?)),
			new TableSearchColumn("ValDtdeco", CSGenioAequip.FldDtdeco, typeof(DateTime?)),
			new TableSearchColumn("ValIfabatif", CSGenioAequip.FldIfabatif, typeof(bool)),
			new TableSearchColumn("ValValortot", CSGenioAequip.FldValortot, typeof(decimal?)),
			new TableSearchColumn("ValFrequenc", CSGenioAequip.FldFrequenc, typeof(decimal), array : "FreqEmpr"),
			new TableSearchColumn("ValBought", CSGenioAequip.FldBought, typeof(bool)),
			new TableSearchColumn("Room1_ValRoomnr", CSGenioAroom1.FldRoomnr, typeof(string)),
			new TableSearchColumn("ValDtrefere", CSGenioAequip.FldDtrefere, typeof(DateTime?)),
			new TableSearchColumn("ValFirst", CSGenioAequip.FldFirst, typeof(string)),
			new TableSearchColumn("ValBefore", CSGenioAequip.FldBefore, typeof(string)),
			new TableSearchColumn("ValFollowin", CSGenioAequip.FldFollowin, typeof(string)),
			new TableSearchColumn("ValLast", CSGenioAequip.FldLast, typeof(string)),
			new TableSearchColumn("ValSitefabr", CSGenioAequip.FldSitefabr, typeof(string)),
			new TableSearchColumn("ValMoviment", CSGenioAequip.FldMoviment, typeof(string)),
			new TableSearchColumn("ValQtdmovim", CSGenioAequip.FldQtdmovim, typeof(decimal?)),
			new TableSearchColumn("ValShowrc", CSGenioAequip.FldShowrc, typeof(bool))
		];



		protected void SetTicketToImageFields(Models.Equip row)
		{
			if(row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, row.ValCodequip);
			row.ValLastphoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldLastpho.Field, null, row.ValCodequip);
		}
	}
}
