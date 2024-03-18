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

namespace GenioMVC.ViewModels.Propr
{
	public class IMO_Menu_111_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Propr> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "propr"; }

		/// <inheritdoc/>
		public override string Uuid { get => "5d7b8c5d-ac05-4bf4-b866-40e2585c681e"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodpropr { get; set; }

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

		private string dbeditTitle;
		public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

		public void GetTitle()
		{
			dbeditTitle = Resources.Resources.REAL_ESTATE24996;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("propr", user, "IMO");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioApropr.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldCodtppro, CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioApropr.FldEndereco, CSGenioApropr.FldLocalida, CSGenioApropr.FldCodregia, CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioApropr.FldPostalco, CSGenioApropr.FldPostallo, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApropr.FldMobilada, CSGenioApropr.FldQtd_wc, CSGenioApropr.FldQtdquart, CSGenioApropr.FldM2, CSGenioApropr.FldDtdispon, CSGenioApropr.FldPhotogra, CSGenioApropr.FldDescript };

			ListingMVC<CSGenioApropr> listing = new ListingMVC<CSGenioApropr>(fields, null, 1, 1, false, user, true, string.Empty, true);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IMO_Menu_111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public IMO_Menu_111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApropr.FldName, FieldType.TEXTO, Resources.Resources.PROPERTY43977, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldPrecoest, FieldType.VALOR, Resources.Resources.ESTIMATED_PRICE02986, 12, 0, true),
				new Exports.QColumn(CSGenioAtppro.FldTppropri, FieldType.TEXTO, Resources.Resources.TYPE00312, 20, 0, true),
				new Exports.QColumn(CSGenioApropr.FldEndereco, FieldType.MEMO, Resources.Resources.ADDRESS04342, 30, 2, false),
				new Exports.QColumn(CSGenioApropr.FldLocalida, FieldType.TEXTO, Resources.Resources.LOCALE34521, 30, 0, true),
				new Exports.QColumn(CSGenioAregio.FldRegiao, FieldType.TEXTO, Resources.Resources.REGION12723, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldPostalco, FieldType.TEXTO, Resources.Resources.ZIP_CODE56964, 20, 0, false),
				new Exports.QColumn(CSGenioApropr.FldPostallo, FieldType.TEXTO, Resources.Resources.POSTAL_LOCATION08708, 30, 0, false),
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXTO, Resources.Resources.COUNTRY64133, 30, 0, false),
				new Exports.QColumn(CSGenioApropr.FldMobilada, FieldType.LOGICO, Resources.Resources.FURNISHED37431, 1, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtd_wc, FieldType.NUMERO, Resources.Resources.TOILET13557, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtdquart, FieldType.NUMERO, Resources.Resources.ROOMS06809, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldM2, FieldType.NUMERO, Resources.Resources.M212241, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldDtdispon, FieldType.DATA, Resources.Resources.AVAILABILITY56489, 8, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioApropr.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioApropr.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 10, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetColumnsToExport(ajaxRequest);
			Load(-1, requestValues, ajaxRequest, true, ref listing, ref conditions);

			//user config listing:
			if (ajaxRequest && userColumns!=null)
			{
				List<Exports.QColumn> current_List = new List<Exports.QColumn>();
				foreach (CSGenioAlstcol column in userColumns)
				{
					//check if theres a match in existing list columns
					string areabase = column.ValTabela.ToLower() != "propr" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
					Exports.QColumn matching_column = columns.Where(x => x.BaseArea == column.ValTabela && areabase + "Val" + x.FieldName.First().ToString().ToUpper() + x.FieldName.Substring(1).ToLower() == column.ValCampo && column.ValVisivel==1).FirstOrDefault();
					if (matching_column != null)
						current_List.Add(matching_column);
				}
				columns = current_List;
			}
		}

		/// <summary>
		/// Builds the list CriteriaSet with all the limits, filters and conditions
		/// </summary>
		/// <param name="requestValues">Table filters</param>
		/// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
		/// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
		/// <param name="isToExport">If the  table is to be exported</param>
		public CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();


			if (Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Propr>();
			Menu.SetFilters(bool.Parse(requestValues["IMO_Menu_111_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PROPR.NAME", new OrderedDictionary());
					allSortOrders["PROPR.NAME"].Add("PROPR.NAME", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "IMO_Menu_111", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "IMO_Menu_111_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Propr.AddEPH<CSGenioApropr>(ref u, crs, "ML111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApropr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApropr.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Propr.AddEPH<CSGenioApropr>(ref u, null, "ML111"));
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
			ListingMVC<CSGenioApropr> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApropr> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "IMO_Menu_111", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "IMO_Menu_111"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "IMO_Menu_111");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Propr>();

			CriteriaSet imo_menu_111Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["IMO_Menu_111_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PROPR.NAME", new OrderedDictionary());
					allSortOrders["PROPR.NAME"].Add("PROPR.NAME", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "IMO_Menu_111", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pIMO_Menu_111"])) ? int.Parse(requestValues["pIMO_Menu_111"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sIMO_Menu_111", "dIMO_Menu_111", requestValues, "propr", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApropr.FldName), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldCodtppro, CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioApropr.FldEndereco, CSGenioApropr.FldLocalida, CSGenioApropr.FldCodregia, CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioApropr.FldPostalco, CSGenioApropr.FldPostallo, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApropr.FldMobilada, CSGenioApropr.FldQtd_wc, CSGenioApropr.FldQtdquart, CSGenioApropr.FldM2, CSGenioApropr.FldDtdispon, CSGenioApropr.FldPhotogra, CSGenioApropr.FldDescript };


			//columns by users list (TemplateDBEditViewModel)
			userColumns = UserUiSettings.Load(m_userContext.PersistentSupport, Uuid, m_userContext.User).userColumns;
			FieldRef firstVisibleColumn = null;

			if (sorts == null)
				if (userColumns != null)
				{
					CSGenioAlstcol col = userColumns.FirstOrDefault(x => x.ValVisivel == 1);

					if (col != null)
					{
						string table = col.ValTabela.ToLower();
						string field = col.ValCampo.ToLower(); //may contain Table.ValField
						if (field.Contains("."))
						{
							field = field.Substring(table.Length + 4); //remove table name and .Val from ValCampo data. i.e: "Pesso.ValNome", pesso lenght will remove "Pesso" and then +4 for the fixed ".Val"
						}
						else
						{
							field = field.Substring(3); //remove table Val from ValCampo data. i.e: "ValNome", Substring(3) will remove "Val"
						}

						firstVisibleColumn = new FieldRef(table, field);
					}
				}
				else
					firstVisibleColumn = new FieldRef("propr", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApropr model_limit_area = new CSGenioApropr(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML111");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(imo_menu_111Conds);
			imo_menu_111Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL IMO OVERRQ 111]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, imo_menu_111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL IMO OVERRQLSTEXP 111]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL IMO OVERRQLIST 111]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApropr.GetInformation(), QMVC_POS_RECORD, sorts, imo_menu_111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioApropr> listing = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, imo_menu_111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML111", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapIMO_Menu_111(listing);

				Menu.Identifier = "ML111";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML111";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Propr> MapIMO_Menu_111(ListingMVC<CSGenioApropr> Qlisting)
		{
			var Elements = new List<Models.Propr>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapIMO_Menu_111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioApropr row
		/// to a Models.Propr object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Propr MapIMO_Menu_111(CSGenioApropr row)
		{
			var model = new Models.Propr(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "propr":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tppro":
						model.Tppro.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "regio":
						model.Regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cntry":
						model.Cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}


		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows.</param>
		private void SetDocumentFields(ListingMVC<CSGenioApropr> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioApropr row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM IMO_MENU_111]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Propr", "Propr.ValCodpropr", "Propr.ValZzstate", "Propr.ValName", "Propr.ValPrecoest", "Tppro", "Tppro.ValTppropri", "Propr.ValEndereco", "Propr.ValLocalida", "Regio", "Regio.ValRegiao", "Propr.ValPostalco", "Propr.ValPostallo", "Cntry", "Cntry.ValCountry", "Propr.ValMobilada", "Propr.ValQtd_wc", "Propr.ValQtdquart", "Propr.ValM2", "Propr.ValDtdispon", "Propr.ValPhotogra", "Propr.ValDescript", "Propr.ValCodcntry", "Propr.ValCodpais1", "Propr.ValCodpesso", "Propr.ValCodregia", "Propr.ValCodtppro"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValName", CSGenioApropr.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValPrecoest", CSGenioApropr.FldPrecoest, typeof(decimal?)),
			new TableSearchColumn("Tppro_ValTppropri", CSGenioAtppro.FldTppropri, typeof(string)),
			new TableSearchColumn("ValEndereco", CSGenioApropr.FldEndereco, typeof(string), visible : false),
			new TableSearchColumn("ValLocalida", CSGenioApropr.FldLocalida, typeof(string)),
			new TableSearchColumn("Regio_ValRegiao", CSGenioAregio.FldRegiao, typeof(string)),
			new TableSearchColumn("ValPostalco", CSGenioApropr.FldPostalco, typeof(string), visible : false),
			new TableSearchColumn("ValPostallo", CSGenioApropr.FldPostallo, typeof(string), visible : false),
			new TableSearchColumn("Cntry_ValCountry", CSGenioAcntry.FldCountry, typeof(string), visible : false),
			new TableSearchColumn("ValMobilada", CSGenioApropr.FldMobilada, typeof(bool)),
			new TableSearchColumn("ValQtd_wc", CSGenioApropr.FldQtd_wc, typeof(decimal?)),
			new TableSearchColumn("ValQtdquart", CSGenioApropr.FldQtdquart, typeof(decimal?)),
			new TableSearchColumn("ValM2", CSGenioApropr.FldM2, typeof(decimal?)),
			new TableSearchColumn("ValDtdispon", CSGenioApropr.FldDtdispon, typeof(DateTime?)),
			new TableSearchColumn("ValDescript", CSGenioApropr.FldDescript, typeof(string), visible : false)
		};
	}
}
