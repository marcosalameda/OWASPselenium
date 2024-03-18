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

namespace GenioMVC.ViewModels.Recei
{
	public class WMS_Menu_111_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Recei> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "recei"; }

		/// <inheritdoc/>
		public override string Uuid { get => "6bb55b0e-5337-4429-b2f8-3175958c9c5b"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodrecei { get; set; }

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
			dbeditTitle = Resources.Resources.RECEIPTS_OF_GOODS02355;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("recei", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioArecei.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioArecei.FldCodrecei, CSGenioArecei.FldZzstate, CSGenioArecei.FldNumber, CSGenioArecei.FldDtreceip, CSGenioArecei.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioArecei.FldDtcheck, CSGenioArecei.FldChecked, CSGenioArecei.FldTocheck, CSGenioArecei.FldDtstorag };

			ListingMVC<CSGenioArecei> listing = new ListingMVC<CSGenioArecei>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioArecei.FldNumber, FieldType.NUMERO, Resources.Resources.RECEIPT_NUMBER31380, 10, 0, true),
				new Exports.QColumn(CSGenioArecei.FldDtreceip, FieldType.DATAHORA, Resources.Resources.RECEIPT_DATE00996, 16, 0, true),
				new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXTO, Resources.Resources.LEGAL_NAME42902, 30, 0, true),
				new Exports.QColumn(CSGenioArecei.FldDtcheck, FieldType.DATAHORA, Resources.Resources.RECEIPT_VERIFICATION62328, 16, 0, true),
				new Exports.QColumn(CSGenioArecei.FldChecked, FieldType.LOGICO, Resources.Resources.CHECKED31708, 1, 0, true),
				new Exports.QColumn(CSGenioArecei.FldTocheck, FieldType.LOGICO, Resources.Resources.TO_CHECK57511, 1, 0, true),
				new Exports.QColumn(CSGenioArecei.FldDtstorag, FieldType.DATAHORA, Resources.Resources.STORAGE_DATE59954, 16, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioArecei> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "recei" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Recei>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_111_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("RECEI.DTRECEIP", new OrderedDictionary());
					allSortOrders["RECEI.DTRECEIP"].Add("RECEI.DTRECEIP", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "WMS_Menu_111", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_111_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Recei.AddEPH<CSGenioArecei>(ref u, crs, "ML111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArecei.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("RECEI", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArecei.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_recei");
				Navigation.DestroyEntry("QMVC_POS_RECORD_recei");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Recei.AddEPH<CSGenioArecei>(ref u, null, "ML111"));
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
			ListingMVC<CSGenioArecei> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArecei> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_111", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_111"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_111");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Recei>();

			CriteriaSet wms_menu_111Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_111_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("RECEI.DTRECEIP", new OrderedDictionary());
					allSortOrders["RECEI.DTRECEIP"].Add("RECEI.DTRECEIP", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "WMS_Menu_111", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_111"])) ? int.Parse(requestValues["pWMS_Menu_111"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_111", "dWMS_Menu_111", requestValues, "recei", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArecei.FldDtreceip), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioArecei.FldCodrecei, CSGenioArecei.FldZzstate, CSGenioArecei.FldNumber, CSGenioArecei.FldDtreceip, CSGenioArecei.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioArecei.FldDtcheck, CSGenioArecei.FldChecked, CSGenioArecei.FldTocheck, CSGenioArecei.FldDtstorag };


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
					firstVisibleColumn = new FieldRef("recei", "number");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArecei model_limit_area = new CSGenioArecei(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML111");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(wms_menu_111Conds);
			wms_menu_111Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 111]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioArecei>(m_userContext, false, wms_menu_111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 111]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 111]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_recei");
				Navigation.DestroyEntry("QMVC_POS_RECORD_recei");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioArecei.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioArecei> listing = Models.ModelBase.Where<CSGenioArecei>(m_userContext, false, wms_menu_111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapWMS_Menu_111(listing);

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

		private List<Models.Recei> MapWMS_Menu_111(ListingMVC<CSGenioArecei> Qlisting)
		{
			var Elements = new List<Models.Recei>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioArecei row
		/// to a Models.Recei object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Recei MapWMS_Menu_111(CSGenioArecei row)
		{
			var model = new Models.Recei(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "recei":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "entit":
						model.Entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioArecei> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioArecei row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_111]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Recei", "Recei.ValCodrecei", "Recei.ValZzstate", "Recei.ValNumber", "Recei.ValDtreceip", "Entit", "Entit.ValName", "Recei.ValDtcheck", "Recei.ValChecked", "Recei.ValTocheck", "Recei.ValDtstorag", "Recei.ValCodentit"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValNumber", CSGenioArecei.FldNumber, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValDtreceip", CSGenioArecei.FldDtreceip, typeof(DateTime?)),
			new TableSearchColumn("Entit_ValName", CSGenioAentit.FldName, typeof(string)),
			new TableSearchColumn("ValDtcheck", CSGenioArecei.FldDtcheck, typeof(DateTime?)),
			new TableSearchColumn("ValChecked", CSGenioArecei.FldChecked, typeof(bool)),
			new TableSearchColumn("ValTocheck", CSGenioArecei.FldTocheck, typeof(bool)),
			new TableSearchColumn("ValDtstorag", CSGenioArecei.FldDtstorag, typeof(DateTime?))
		};
	}
}
