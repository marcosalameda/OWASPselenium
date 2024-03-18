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

namespace GenioMVC.ViewModels.Pesso
{
	public class TBS_Menu_121_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Pesso> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "pesso"; }

		/// <inheritdoc/>
		public override string Uuid { get => "5bbb3c85-0f2b-4e4a-a096-baeef7fb9b34"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodpesso { get; set; }

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
			dbeditTitle = Resources.Resources.PEOPLE34206;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("pesso", user, "TBS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioApesso.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldPhotogra, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };

			ListingMVC<CSGenioApesso> listing = new ListingMVC<CSGenioApesso>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_121_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TBS_Menu_121_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 50, 0, true),
				new Exports.QColumn(CSGenioApesso.FldGender, FieldType.ARRAY_COD_TEXTO, Resources.Resources.GENUS37471, 1, 0, true, "Genero"),
				new Exports.QColumn(CSGenioApesso.FldDtnascim, FieldType.DATA, Resources.Resources.BIRTH21799, 8, 0, true),
				new Exports.QColumn(CSGenioApesso.FldTelephon, FieldType.TEXTO, Resources.Resources.PHONE56703, 20, 0, true),
				new Exports.QColumn(CSGenioApesso.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioApesso.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioApesso.FldIdfuncio, FieldType.NUMERO, Resources.Resources.OFFICIAL_NO_34819, 6, 0, true),
				new Exports.QColumn(CSGenioApesso.FldDtultcat, FieldType.DATA, Resources.Resources.SINCE47259, 8, 0, true),
				new Exports.QColumn(CSGenioAcateg.FldCategoria, FieldType.TEXTO, Resources.Resources.CATEGORY18978, 30, 0, true),
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.COMPANY52963, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioApesso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "pesso" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Pesso>();
			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_121_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PESSO.NAME", new OrderedDictionary());
					allSortOrders["PESSO.NAME"].Add("PESSO.NAME", "A");
				allSortOrders.Add("PESSO.DTULTCAT", new OrderedDictionary());
					allSortOrders["PESSO.DTULTCAT"].Add("PESSO.DTULTCAT", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "TBS_Menu_121", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "TBS_Menu_121_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Pesso.AddEPH<CSGenioApesso>(ref u, crs, "ML121");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApesso.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PESSO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApesso.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Pesso.AddEPH<CSGenioApesso>(ref u, null, "ML121"));
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
			ListingMVC<CSGenioApesso> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApesso> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "TBS_Menu_121", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "TBS_Menu_121"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "TBS_Menu_121");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Pesso>();

			CriteriaSet tbs_menu_121Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_121_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PESSO.NAME", new OrderedDictionary());
					allSortOrders["PESSO.NAME"].Add("PESSO.NAME", "A");
				allSortOrders.Add("PESSO.DTULTCAT", new OrderedDictionary());
					allSortOrders["PESSO.DTULTCAT"].Add("PESSO.DTULTCAT", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "TBS_Menu_121", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pTBS_Menu_121"])) ? int.Parse(requestValues["pTBS_Menu_121"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sTBS_Menu_121", "dTBS_Menu_121", requestValues, "pesso", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldDtultcat), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldName, CSGenioApesso.FldGender, CSGenioApesso.FldDtnascim, CSGenioApesso.FldTelephon, CSGenioApesso.FldEmail, CSGenioApesso.FldPhotogra, CSGenioApesso.FldIdfuncio, CSGenioApesso.FldDtultcat, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };


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
					firstVisibleColumn = new FieldRef("pesso", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApesso model_limit_area = new CSGenioApesso(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML121");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tbs_menu_121Conds);
			tbs_menu_121Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TBS OVERRQ 121]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, tbs_menu_121Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML121", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 121]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL TBS OVERRQLIST 121]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApesso.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_121Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, tbs_menu_121Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML121", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTBS_Menu_121(listing);

				Menu.Identifier = "ML121";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML121";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Pesso> MapTBS_Menu_121(ListingMVC<CSGenioApesso> Qlisting)
		{
			var Elements = new List<Models.Pesso>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_121(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioApesso row
		/// to a Models.Pesso object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Pesso MapTBS_Menu_121(CSGenioApesso row)
		{
			var model = new Models.Pesso(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "categ":
						model.Categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioApesso> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioApesso row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_121]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName", "Pesso.ValGender", "Pesso.ValDtnascim", "Pesso.ValTelephon", "Pesso.ValEmail", "Pesso.ValPhotogra", "Pesso.ValIdfuncio", "Pesso.ValDtultcat", "Categ", "Categ.ValCategoria", "Cmpny", "Cmpny.ValDesignat", "Pesso.ValCodempre", "Cmpny.ValCodempre", "Pesso.ValCodpaise", "Pesso.ValCodcntry", "Pesso.ValCodregia", "Pesso.ValCodcateg"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValName", CSGenioApesso.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValGender", CSGenioApesso.FldGender, typeof(string), array : "Genero"),
			new TableSearchColumn("ValDtnascim", CSGenioApesso.FldDtnascim, typeof(DateTime?)),
			new TableSearchColumn("ValTelephon", CSGenioApesso.FldTelephon, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioApesso.FldEmail, typeof(string)),
			new TableSearchColumn("ValIdfuncio", CSGenioApesso.FldIdfuncio, typeof(decimal?)),
			new TableSearchColumn("ValDtultcat", CSGenioApesso.FldDtultcat, typeof(DateTime?)),
			new TableSearchColumn("Categ_ValCategoria", CSGenioAcateg.FldCategoria, typeof(string)),
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string))
		};
	}
}
