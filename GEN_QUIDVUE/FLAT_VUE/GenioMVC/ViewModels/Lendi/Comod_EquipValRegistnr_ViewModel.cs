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

namespace GenioMVC.ViewModels.Lendi
{
	public class Comod_EquipValRegistnr_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Equip> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "equip"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Comod_EquipValRegistnr"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodlendi { get; set; }

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

		public string ValCodpess1 { get; set; }
		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Comod_EquipValRegistnr_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Comod_EquipValRegistnr_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE00312, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtaquisi, FieldType.DATA, Resources.Resources.ACQUISITION44180, 8, 0, true),
				new Exports.QColumn(CSGenioAequip.FldDtdeco, FieldType.DATA, Resources.Resources.DECOMISSION14486, 8, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioAequip.FldValortot, FieldType.VALOR, Resources.Resources.TOTAL_VALUE30570, 12, 0, true),
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

			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioApess1.FldCodpesso, "pess1", this.ValCodpess1, true);


			if (Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Equip>();
			Menu.SetFilters(bool.Parse(requestValues["Comod_EquipValRegistnr_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
					allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "Comod_EquipValRegistnr", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Comod_EquipValRegistnr_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "IBL_COMOD___EQUIPREGISTNR");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAequip.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));


			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_equip"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "IBL_COMOD___EQUIPREGISTNR"));
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
				this.Navigation.SetValue("requestValues" + "Comod_EquipValRegistnr", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Comod_EquipValRegistnr"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Comod_EquipValRegistnr");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Equip>();

			CriteriaSet comod___equipregistnrConds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Comod_EquipValRegistnr_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
					allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "Comod_EquipValRegistnr", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pComod_EquipValRegistnr"])) ? int.Parse(requestValues["pComod_EquipValRegistnr"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sComod_EquipValRegistnr", "dComod_EquipValRegistnr", requestValues, "equip", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldRegistnr, CSGenioAequip.FldCodtpequ, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldDtdeco, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot };


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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_COMOD___EQUIPREGISTNR");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 

			//Limit type: "A"			//Current Area = "EQUIP"			//1st Area Limit: "PESS1"			//1st Area Field: "CODPESSO"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioApess1 model_limit_area = new CSGenioApess1(m_userContext.User);
				string limit_field = "codpesso", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("pess1") == null ? this.ValCodpess1 : Navigation.GetValue("pess1");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(comod___equipregistnrConds);
			comod___equipregistnrConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ COMOD_EQUIPREGISTNR]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, comod___equipregistnrConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_COMOD___EQUIPREGISTNR", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP COMOD_EQUIPREGISTNR]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST COMOD_EQUIPREGISTNR]/

				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_equip"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, comod___equipregistnrConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, comod___equipregistnrConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_COMOD___EQUIPREGISTNR", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapComod_EquipValRegistnr(listing);

				Menu.Identifier = "IBL_COMOD___EQUIPREGISTNR";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_COMOD___EQUIPREGISTNR";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Equip> MapComod_EquipValRegistnr(ListingMVC<CSGenioAequip> Qlisting)
		{
			var Elements = new List<Models.Equip>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapComod_EquipValRegistnr(row));
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
		private Models.Equip MapComod_EquipValRegistnr(CSGenioAequip row)
		{
			var model = new Models.Equip(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpequ":
						model.Tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM COMOD_EQUIPVALREGISTNR]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Tpequ", "Tpequ.ValTipoequi", "Equip.ValDesignat", "Equip.ValDtaquisi", "Equip.ValDtdeco", "Equip.ValPhotogra", "Equip.ValValortot", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodtpequ", "Equip.ValCodwareh", "Equip.ValCodrooms"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
			new TableSearchColumn("Tpequ_ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
			new TableSearchColumn("ValDtaquisi", CSGenioAequip.FldDtaquisi, typeof(DateTime?)),
			new TableSearchColumn("ValDtdeco", CSGenioAequip.FldDtdeco, typeof(DateTime?)),
			new TableSearchColumn("ValValortot", CSGenioAequip.FldValortot, typeof(decimal?))
		};
	}
}
