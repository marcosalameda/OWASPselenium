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

namespace GenioMVC.ViewModels.Equip
{
	public class GQT_Menu_2D111_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Equip> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "equip"; }

		/// <inheritdoc/>
		public override string Uuid { get => "bab5f91b-0ea6-4734-93b1-4dd943ec66c5"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodequip { get; set; }

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
			dbeditTitle = Resources.Resources.EQUIPMENT03632;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("equip", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioAequip.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };

			ListingMVC<CSGenioAequip> listing = new ListingMVC<CSGenioAequip>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			if (!qs.Joins.Select(x => x.Table).Select(y=>y.TableAlias).Contains(CSGenio.business.Area.AreaTPEQU.Alias))
				qs.Join(CSGenio.business.Area.AreaTPEQU, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAtpequ.FldCodtpequ, CSGenioAequip.FldCodtpequ));

			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_2D111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_2D111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXTO, Resources.Resources.EQUIPMENT03632, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioAroom1.FldRoomnr, FieldType.TEXTO, Resources.Resources.N_R__ROOM43805, 10, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, false),
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, false),
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXTO, Resources.Resources.ARTICLE60065, 30, 0, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "equip" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Equip>();
			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_2D111_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
					allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "GQT_Menu_2D111", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "GQT_Menu_2D111_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "DM"
			//Limiting DMs can now be used without filters, thanks to the implementation of the selectAll option
			{
				var limValue = (string[])Navigation.GetValue("tpequ_Selections");
				if (limValue != null && limValue.Any())
					crs.In(CSGenioAequip.FldCodtpequ, limValue);
			}

			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "ML2D111");

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
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "ML2D111"));
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
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "GQT_Menu_2D111", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "GQT_Menu_2D111"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_2D111");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Equip>();

			CriteriaSet gqt_menu_2d111Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_2D111_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
					allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "GQT_Menu_2D111", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pGQT_Menu_2D111"])) ? int.Parse(requestValues["pGQT_Menu_2D111"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sGQT_Menu_2D111", "dGQT_Menu_2D111", requestValues, "equip", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };


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
					firstVisibleColumn = new FieldRef("equip", "registnr");


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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2D111");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 


			//Limit type: "DM"			//Current Area = "EQUIP"			//1st Area Limit: "TPEQU"			//1st Area Field: "CODTPEQU"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DM;
				limit.NaoAplicaSeNulo = false;
				CSGenioAtpequ model_limit_area = new CSGenioAtpequ(m_userContext.User);
				string limit_field = "codtpequ", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(gqt_menu_2d111Conds);
			gqt_menu_2d111Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 2D111]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, gqt_menu_2d111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2D111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 2D111]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST 2D111]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
				Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_2d111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, gqt_menu_2d111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2D111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapGQT_Menu_2D111(listing);

				Menu.Identifier = "ML2D111";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML2D111";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Equip> MapGQT_Menu_2D111(ListingMVC<CSGenioAequip> Qlisting)
		{
			var Elements = new List<Models.Equip>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_2D111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAequip row
		/// to a Models.Equip object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Equip MapGQT_Menu_2D111(CSGenioAequip row)
		{
			var model = new Models.Equip(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "room1":
						model.Room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpequ":
						model.Tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "item":
						model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAequip> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAequip row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_2D111]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Equip.ValDesignat", "Equip.ValPhotogra", "Room1", "Room1.ValRoomnr", "Tpequ", "Tpequ.ValTipoequi", "Wareh", "Wareh.ValWarehdes", "Item", "Item.ValItemdes", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodtpequ", "Equip.ValCodwareh", "Equip.ValCodrooms"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
			new TableSearchColumn("Room1_ValRoomnr", CSGenioAroom1.FldRoomnr, typeof(string)),
			new TableSearchColumn("Tpequ_ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string), visible : false),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string), visible : false),
			new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string), visible : false)
		};
	}
}
