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

namespace GenioMVC.ViewModels.Inpgr
{
	public class STY_Menu_361_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Inpgr> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "inpgr"; }

		/// <inheritdoc/>
		public override string Uuid { get => "bbdc57e0-4d64-4aa6-8f57-c642f9358f3a"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodinpgr { get; set; }

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
			dbeditTitle = Resources.Resources.INPUT_GROUPS32118;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("inpgr", user, "STY");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioAinpgr.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAinpgr.FldCodinpgr, CSGenioAinpgr.FldZzstate, CSGenioAinpgr.FldNumbgro, CSGenioAinpgr.FldTextgro, CSGenioAinpgr.FldButtngro, CSGenioAinpgr.FldSpangro, CSGenioAinpgr.FldName, CSGenioAinpgr.FldLastname, CSGenioAinpgr.FldAdress, CSGenioAinpgr.FldPrefix, CSGenioAinpgr.FldPhone, CSGenioAinpgr.FldEmail, CSGenioAinpgr.FldWeb, CSGenioAinpgr.FldIban, CSGenioAinpgr.FldBankacco, CSGenioAinpgr.FldTextspan, CSGenioAinpgr.FldDirectio, CSGenioAinpgr.FldBankcomp };

			ListingMVC<CSGenioAinpgr> listing = new ListingMVC<CSGenioAinpgr>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_361_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public STY_Menu_361_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAinpgr.FldNumbgro, FieldType.NUMERO, Resources.Resources.VAT_NUMBER24236, 9, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldTextgro, FieldType.TEXTO, Resources.Resources.TEXT_FIELD41810, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldButtngro, FieldType.TEXTO, String.Empty, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldSpangro, FieldType.TEXTO, Resources.Resources.PROFILE65433, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldLastname, FieldType.TEXTO, Resources.Resources.LAST_NAME63426, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldAdress, FieldType.ARRAY_COD_TEXTO, Resources.Resources.ADDRESS_TYPE64627, 8, 0, true, "AddressT"),
				new Exports.QColumn(CSGenioAinpgr.FldPrefix, FieldType.ARRAY_COD_TEXTO, Resources.Resources.PREFIX02493, 3, 0, true, "phonepre"),
				new Exports.QColumn(CSGenioAinpgr.FldPhone, FieldType.NUMERO, Resources.Resources.PHONE_NUMBER20774, 15, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldEmail, FieldType.TEXTO, Resources.Resources.E_MAIL42251, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldWeb, FieldType.TEXTO, Resources.Resources.WEB09813, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldIban, FieldType.TEXTO, Resources.Resources.IBAN28506, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldBankacco, FieldType.TEXTO, Resources.Resources.BANKING_ACCOUNT_NUMB62548, 24, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldTextspan, FieldType.TEXTO, Resources.Resources.TEXT04938, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldDirectio, FieldType.TEXTO, Resources.Resources.ADRESS39816, 30, 0, true),
				new Exports.QColumn(CSGenioAinpgr.FldBankcomp, FieldType.ARRAY_COD_TEXTO, Resources.Resources.ENTITY62049, 2, 0, true, "bankComp"),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAinpgr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "inpgr" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Inpgr>();
			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_361_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("INPGR.TEXTGRO", new OrderedDictionary());
					allSortOrders["INPGR.TEXTGRO"].Add("INPGR.TEXTGRO", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "STY_Menu_361", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "STY_Menu_361_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Inpgr.AddEPH<CSGenioAinpgr>(ref u, crs, "ML361");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAinpgr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("INPGR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAinpgr.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_inpgr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_inpgr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Inpgr.AddEPH<CSGenioAinpgr>(ref u, null, "ML361"));
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
			ListingMVC<CSGenioAinpgr> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinpgr> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "STY_Menu_361", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "STY_Menu_361"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "STY_Menu_361");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Inpgr>();

			CriteriaSet sty_menu_361Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_361_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("INPGR.TEXTGRO", new OrderedDictionary());
					allSortOrders["INPGR.TEXTGRO"].Add("INPGR.TEXTGRO", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "STY_Menu_361", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pSTY_Menu_361"])) ? int.Parse(requestValues["pSTY_Menu_361"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sSTY_Menu_361", "dSTY_Menu_361", requestValues, "inpgr", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAinpgr.FldTextgro), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAinpgr.FldCodinpgr, CSGenioAinpgr.FldZzstate, CSGenioAinpgr.FldNumbgro, CSGenioAinpgr.FldTextgro, CSGenioAinpgr.FldButtngro, CSGenioAinpgr.FldSpangro, CSGenioAinpgr.FldName, CSGenioAinpgr.FldLastname, CSGenioAinpgr.FldAdress, CSGenioAinpgr.FldPrefix, CSGenioAinpgr.FldPhone, CSGenioAinpgr.FldEmail, CSGenioAinpgr.FldWeb, CSGenioAinpgr.FldIban, CSGenioAinpgr.FldBankacco, CSGenioAinpgr.FldTextspan, CSGenioAinpgr.FldDirectio, CSGenioAinpgr.FldBankcomp };


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
					firstVisibleColumn = new FieldRef("inpgr", "numbgro");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAinpgr model_limit_area = new CSGenioAinpgr(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML361");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(sty_menu_361Conds);
			sty_menu_361Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ 361]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAinpgr>(m_userContext, false, sty_menu_361Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML361", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP 361]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL STY OVERRQLIST 361]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_inpgr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_inpgr");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAinpgr.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_361Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAinpgr> listing = Models.ModelBase.Where<CSGenioAinpgr>(m_userContext, false, sty_menu_361Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML361", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapSTY_Menu_361(listing);

				Menu.Identifier = "ML361";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML361";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Inpgr> MapSTY_Menu_361(ListingMVC<CSGenioAinpgr> Qlisting)
		{
			var Elements = new List<Models.Inpgr>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_361(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAinpgr row
		/// to a Models.Inpgr object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Inpgr MapSTY_Menu_361(CSGenioAinpgr row)
		{
			var model = new Models.Inpgr(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "inpgr":
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

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}


		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows.</param>
		private void SetDocumentFields(ListingMVC<CSGenioAinpgr> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAinpgr row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_361]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Inpgr", "Inpgr.ValCodinpgr", "Inpgr.ValZzstate", "Inpgr.ValNumbgro", "Inpgr.ValTextgro", "Inpgr.ValButtngro", "Inpgr.ValSpangro", "Inpgr.ValName", "Inpgr.ValLastname", "Inpgr.ValAdress", "Inpgr.ValPrefix", "Inpgr.ValPhone", "Inpgr.ValEmail", "Inpgr.ValWeb", "Inpgr.ValIban", "Inpgr.ValBankacco", "Inpgr.ValTextspan", "Inpgr.ValDirectio", "Inpgr.ValBankcomp"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValNumbgro", CSGenioAinpgr.FldNumbgro, typeof(decimal?)),
			new TableSearchColumn("ValTextgro", CSGenioAinpgr.FldTextgro, typeof(string)),
			new TableSearchColumn("ValButtngro", CSGenioAinpgr.FldButtngro, typeof(string)),
			new TableSearchColumn("ValSpangro", CSGenioAinpgr.FldSpangro, typeof(string)),
			new TableSearchColumn("ValName", CSGenioAinpgr.FldName, typeof(string)),
			new TableSearchColumn("ValLastname", CSGenioAinpgr.FldLastname, typeof(string)),
			new TableSearchColumn("ValAdress", CSGenioAinpgr.FldAdress, typeof(string), array : "AddressT"),
			new TableSearchColumn("ValPrefix", CSGenioAinpgr.FldPrefix, typeof(string), array : "phonepre"),
			new TableSearchColumn("ValPhone", CSGenioAinpgr.FldPhone, typeof(decimal?)),
			new TableSearchColumn("ValEmail", CSGenioAinpgr.FldEmail, typeof(string)),
			new TableSearchColumn("ValWeb", CSGenioAinpgr.FldWeb, typeof(string)),
			new TableSearchColumn("ValIban", CSGenioAinpgr.FldIban, typeof(string)),
			new TableSearchColumn("ValBankacco", CSGenioAinpgr.FldBankacco, typeof(string)),
			new TableSearchColumn("ValTextspan", CSGenioAinpgr.FldTextspan, typeof(string)),
			new TableSearchColumn("ValDirectio", CSGenioAinpgr.FldDirectio, typeof(string)),
			new TableSearchColumn("ValBankcomp", CSGenioAinpgr.FldBankcomp, typeof(string), array : "bankComp")
		};
	}
}
