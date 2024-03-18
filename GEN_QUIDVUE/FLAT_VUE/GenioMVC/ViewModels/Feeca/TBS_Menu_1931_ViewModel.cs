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

namespace GenioMVC.ViewModels.Feeca
{
	public class TBS_Menu_1931_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Feeca> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode { get => TableViewsManagementMode.PersistOne; }

		/// <inheritdoc/>
		public override string TableAlias { get => "feeca"; }

		/// <inheritdoc/>
		public override string Uuid { get => "bcd28de4-9e50-4d1a-92e0-3c661c0ab999"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodfeeca { get; set; }

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
			dbeditTitle = Resources.Resources.FEEDBACK_CAMPO42437;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("feeca", user, "TBS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
			conditions.Equal(CSGenioAfeeca.FldZzstate, 0); //valid zzstate only

			//Menu fixed limits and relations:

			

			// Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAfeeca.FldCodfeeca, CSGenioAfeeca.FldZzstate, CSGenioAfeeca.FldCodflds, CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAfeeca.FldFeedback, CSGenioAflds.FldAttach };

			ListingMVC<CSGenioAfeeca> listing = new ListingMVC<CSGenioAfeeca>(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			//Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_1931_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TBS_Menu_1931_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAflds.FldDescrip, FieldType.MEMO, Resources.Resources.DESCRICAO51618, 30, 0, true),
				new Exports.QColumn(CSGenioAfeeca.FldFeedback, FieldType.TEXTO, Resources.Resources.FEEDBACK52855, 30, 0, true),
				new Exports.QColumn(CSGenioAflds.FldAttach, FieldType.FICHEIRO_BD, Resources.Resources.ANEXOS65235, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAfeeca> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "feeca" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Feeca>();
			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_1931_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("FEECA.FEEDBACK", new OrderedDictionary());
					allSortOrders["FEECA.FEEDBACK"].Add("FEECA.FEEDBACK", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "TBS_Menu_1931", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "TBS_Menu_1931_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Feeca.AddEPH<CSGenioAfeeca>(ref u, crs, "ML1931");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfeeca.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FEECA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfeeca.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_feeca");
				Navigation.DestroyEntry("QMVC_POS_RECORD_feeca");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Feeca.AddEPH<CSGenioAfeeca>(ref u, null, "ML1931"));
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
			ListingMVC<CSGenioAfeeca> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfeeca> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "TBS_Menu_1931", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "TBS_Menu_1931"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "TBS_Menu_1931");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Feeca>();

			CriteriaSet tbs_menu_1931Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_1931_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("FEECA.FEEDBACK", new OrderedDictionary());
					allSortOrders["FEECA.FEEDBACK"].Add("FEECA.FEEDBACK", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "TBS_Menu_1931", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pTBS_Menu_1931"])) ? int.Parse(requestValues["pTBS_Menu_1931"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sTBS_Menu_1931", "dTBS_Menu_1931", requestValues, "feeca", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfeeca.FldFeedback), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAfeeca.FldCodfeeca, CSGenioAfeeca.FldZzstate, CSGenioAfeeca.FldCodflds, CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAfeeca.FldFeedback, CSGenioAflds.FldAttach, CSGenioAflds.FldAttachfk };


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
					firstVisibleColumn = new FieldRef("flds", "descrip");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfeeca model_limit_area = new CSGenioAfeeca(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML1931");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tbs_menu_1931Conds);
			tbs_menu_1931Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TBS OVERRQ 1931]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfeeca>(m_userContext, false, tbs_menu_1931Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1931", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 1931]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL TBS OVERRQLIST 1931]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_feeca");
				Navigation.DestroyEntry("QMVC_POS_RECORD_feeca");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAfeeca.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_1931Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfeeca> listing = Models.ModelBase.Where<CSGenioAfeeca>(m_userContext, false, tbs_menu_1931Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1931", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTBS_Menu_1931(listing);

				Menu.Identifier = "ML1931";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML1931";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Feeca> MapTBS_Menu_1931(ListingMVC<CSGenioAfeeca> Qlisting)
		{
			var Elements = new List<Models.Feeca>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_1931(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAfeeca row
		/// to a Models.Feeca object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Feeca MapTBS_Menu_1931(CSGenioAfeeca row)
		{
			var model = new Models.Feeca(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "feeca":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "flds":
						model.Flds.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAfeeca> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAfeeca row in listing.Rows)
			{
				{
					if (!string.IsNullOrEmpty((string)row.returnValueField("flds.attachfk"))){
						ResourceQuery resource = new ResourceQuery("Flds", "ValAttach", "ValAttachfk", row.ValCodflds);
						string ticket = QResources.CreateTicketEncryptedBase64(m_userContext.User.Name, m_userContext.User.Location, resource);

						row.insertNameValueField("flds.attach", Newtonsoft.Json.JsonConvert.SerializeObject(new
						{
							fileName = row.returnValueField("flds.attach"),
							ticket
						}));
					}
					else
						row.removeFieldValue("flds.attach");
				}
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_1931]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Feeca", "Feeca.ValCodfeeca", "Feeca.ValZzstate", "Flds", "Flds.ValDescrip", "Feeca.ValFeedback", "Flds.ValAttach", "Feeca.ValCodflds"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("Flds_ValDescrip", CSGenioAflds.FldDescrip, typeof(string)),
			new TableSearchColumn("ValFeedback", CSGenioAfeeca.FldFeedback, typeof(string), defaultSearch : true),
			new TableSearchColumn("Flds_ValAttach", CSGenioAflds.FldAttach, typeof(string))
		};
	}
}
