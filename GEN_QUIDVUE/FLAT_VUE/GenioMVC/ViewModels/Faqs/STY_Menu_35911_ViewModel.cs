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

namespace GenioMVC.ViewModels.Faqs
{
	public class STY_Menu_35911_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Faqs> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "faqs"; }

		/// <inheritdoc/>
		public override string Uuid { get => "2d789e4b-4145-4b00-8473-3b6215ee3fab"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodfaqs { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAfaqs.FldCodcfaqs, Navigation.GetValue("cfaqs"));
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
			dbeditTitle = Resources.Resources.FAQS53959;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("faqs", user, "STY");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioAfaqs.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAfaqs.FldCodfaqs, CSGenioAfaqs.FldZzstate, CSGenioAfaqs.FldQuestion, CSGenioAfaqs.FldAnswer };

			ListingMVC<CSGenioAfaqs> listing = new ListingMVC<CSGenioAfaqs>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			if (!qs.Joins.Select(x => x.Table).Select(y=>y.TableAlias).Contains(CSGenio.business.Area.AreaCFAQS.Alias))
				qs.Join(CSGenio.business.Area.AreaCFAQS, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAcfaqs.FldCodcfaqs, CSGenioAfaqs.FldCodcfaqs));

			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="STY_Menu_35911_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public STY_Menu_35911_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAfaqs.FldQuestion, FieldType.MEMO, Resources.Resources.QUESTION00194, 30, 0, true),
				new Exports.QColumn(CSGenioAfaqs.FldAnswer, FieldType.MEMO, Resources.Resources.ANSWER22961, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAfaqs> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "faqs" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Faqs>();
			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_35911_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "STY_Menu_35911", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "STY_Menu_35911_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAfaqs.FldCodcfaqs, Navigation.GetValue("cfaqs"));

			if (isToExport)
			{
				// EPH
				crs = Models.Faqs.AddEPH<CSGenioAfaqs>(ref u, crs, "ML35911");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfaqs.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FAQS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfaqs.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_faqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_faqs");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Faqs.AddEPH<CSGenioAfaqs>(ref u, null, "ML35911"));
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
			ListingMVC<CSGenioAfaqs> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfaqs> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "STY_Menu_35911", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "STY_Menu_35911"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "STY_Menu_35911");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Faqs>();

			CriteriaSet sty_menu_35911Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_35911_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			LoadUserTableConfig(requestValues, allSortOrders, "STY_Menu_35911", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pSTY_Menu_35911"])) ? int.Parse(requestValues["pSTY_Menu_35911"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sSTY_Menu_35911", "dSTY_Menu_35911", requestValues, "faqs", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAfaqs.FldCodfaqs, CSGenioAfaqs.FldZzstate, CSGenioAfaqs.FldQuestion, CSGenioAfaqs.FldAnswer };


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
					firstVisibleColumn = new FieldRef("faqs", "question");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfaqs model_limit_area = new CSGenioAfaqs(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML35911");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 


			//Limit type: "DB"			//Current Area = "FAQS"			//1st Area Limit: "CFAQS"			//1st Area Field: "CODCFAQS"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAcfaqs model_limit_area = new CSGenioAcfaqs(m_userContext.User);
				string limit_field = "codcfaqs", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(sty_menu_35911Conds);
			sty_menu_35911Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ 35911]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfaqs>(m_userContext, false, sty_menu_35911Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML35911", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP 35911]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL STY OVERRQLIST 35911]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_faqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_faqs");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAfaqs.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_35911Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfaqs> listing = Models.ModelBase.Where<CSGenioAfaqs>(m_userContext, false, sty_menu_35911Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML35911", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapSTY_Menu_35911(listing);

				Menu.Identifier = "ML35911";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML35911";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Faqs> MapSTY_Menu_35911(ListingMVC<CSGenioAfaqs> Qlisting)
		{
			var Elements = new List<Models.Faqs>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_35911(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAfaqs row
		/// to a Models.Faqs object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Faqs MapSTY_Menu_35911(CSGenioAfaqs row)
		{
			var model = new Models.Faqs(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "faqs":
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
		private void SetDocumentFields(ListingMVC<CSGenioAfaqs> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAfaqs row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_35911]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Faqs", "Faqs.ValCodfaqs", "Faqs.ValZzstate", "Faqs.ValQuestion", "Faqs.ValAnswer", "Faqs.ValCodcfaqs"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValQuestion", CSGenioAfaqs.FldQuestion, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValAnswer", CSGenioAfaqs.FldAnswer, typeof(string))
		};
	}
}
