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

namespace GenioMVC.ViewModels.Wareh
{
	public class Armaz03_ValArtigos_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Item> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "item"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Armaz03_ValArtigos"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodwareh { get; set; }

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
		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Armaz03_ValArtigos_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Armaz03_ValArtigos_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXTO, Resources.Resources.ARTICLE60065, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldItemcod, FieldType.TEXTO, Resources.Resources.CODE49225, 15, 0, true),
				new Exports.QColumn(CSGenioAitem.FldEntries, FieldType.NUMERO, Resources.Resources.ENTRIES32319, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldExits, FieldType.NUMERO, Resources.Resources.OUTPUTS47833, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldExistenc, FieldType.NUMERO, Resources.Resources.STOCKS47349, 10, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAitem.FldImage, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE65174, 3, 1, true):null,
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAitem> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
					string areabase = column.ValTabela.ToLower() != "item" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Item>();
			Menu.SetFilters(bool.Parse(requestValues["ValArtigos_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("ITEM.ITEMDES", new OrderedDictionary());
					allSortOrders["ITEM.ITEMDES"].Add("ITEM.ITEMDES", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "ValArtigos", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValArtigos_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if (this.ValCodwareh != null)
				crs.Equal(CSGenioAitem.FldCodwareh, this.ValCodwareh);





			if (isToExport)
			{
				// EPH
				crs = Models.Item.AddEPH<CSGenioAitem>(ref u, crs, "IBL_ARMAZ03_PSEUDARTIGOS_");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAitem.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ITEM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAitem.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
				Navigation.DestroyEntry("QMVC_POS_RECORD_item");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Item.AddEPH<CSGenioAitem>(ref u, null, "IBL_ARMAZ03_PSEUDARTIGOS_"));
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
			ListingMVC<CSGenioAitem> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAitem> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Armaz03_ValArtigos", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Armaz03_ValArtigos"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Armaz03_ValArtigos");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Item>();

			CriteriaSet armaz03_pseudartigos_Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValArtigos_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("ITEM.ITEMDES", new OrderedDictionary());
					allSortOrders["ITEM.ITEMDES"].Add("ITEM.ITEMDES", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "ValArtigos", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValArtigos"])) ? int.Parse(requestValues["pValArtigos"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValArtigos", "dValArtigos", requestValues, "item", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemdes), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldEntries, CSGenioAitem.FldExits, CSGenioAitem.FldExistenc, CSGenioAitem.FldImage };


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
					firstVisibleColumn = new FieldRef("item", "itemdes");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAitem model_limit_area = new CSGenioAitem(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ARMAZ03_PSEUDARTIGOS_");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(armaz03_pseudartigos_Conds);
			armaz03_pseudartigos_Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ARMAZ03_PSEUDARTIGOS]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, armaz03_pseudartigos_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARMAZ03_PSEUDARTIGOS_", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ARMAZ03_PSEUDARTIGOS]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ARMAZ03_PSEUDARTIGOS]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
				Navigation.DestroyEntry("QMVC_POS_RECORD_item");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAitem.GetInformation(), QMVC_POS_RECORD, sorts, armaz03_pseudartigos_Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, armaz03_pseudartigos_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARMAZ03_PSEUDARTIGOS_", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapArmaz03_ValArtigos(listing);

				Menu.Identifier = "IBL_ARMAZ03_PSEUDARTIGOS_";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ARMAZ03_PSEUDARTIGOS_";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Item> MapArmaz03_ValArtigos(ListingMVC<CSGenioAitem> Qlisting)
		{
			var Elements = new List<Models.Item>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapArmaz03_ValArtigos(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAitem row
		/// to a Models.Item object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Item MapArmaz03_ValArtigos(CSGenioAitem row)
		{
			var model = new Models.Item(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
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
		private void SetDocumentFields(ListingMVC<CSGenioAitem> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAitem row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARMAZ03_VALARTIGOS]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod", "Item.ValEntries", "Item.ValExits", "Item.ValExistenc", "Item.ValImage", "Item.ValCodgitem", "Item.ValCodwareh"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValItemdes", CSGenioAitem.FldItemdes, typeof(string)),
			new TableSearchColumn("ValItemcod", CSGenioAitem.FldItemcod, typeof(string)),
			new TableSearchColumn("ValEntries", CSGenioAitem.FldEntries, typeof(decimal?)),
			new TableSearchColumn("ValExits", CSGenioAitem.FldExits, typeof(decimal?)),
			new TableSearchColumn("ValExistenc", CSGenioAitem.FldExistenc, typeof(decimal?))
		};
	}
}
