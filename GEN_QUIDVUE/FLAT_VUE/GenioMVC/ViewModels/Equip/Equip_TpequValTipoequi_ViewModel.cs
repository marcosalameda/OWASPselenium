using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Equip
{
	public class Equip_TpequValTipoequi_ViewModel : MenuListViewModel<Models.Tpequ>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Equip_TpequValTipoequi_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tpequ";

		/// <inheritdoc/>
		public override string Uuid => "Equip_TpequValTipoequi";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ValCodequip { get; set; }

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
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
// USE /[MANUAL GQT LIST_LIMITS EQUIP_TPEQUTIPOEQUI]/

			return crs;
		}


		public string ValCorletra { get; set; }

		public string ValBackcolo { get; set; }

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param
		private void SetViewModelValue(string fullFieldName, object value)
		{
			if (string.IsNullOrEmpty(fullFieldName))
				return;

			switch (fullFieldName)
			{
				case "tpequ.corletra":
					ValCorletra = ViewModelConversion.ToString(value);
					break;
				case "tpequ.backcolo":
					ValBackcolo = ViewModelConversion.ToString(value);
					break;
			}
		}

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Equip_TpequValTipoequi_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_TpequValTipoequi_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Equip_TpequValTipoequi_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodequip = userContext.CurrentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Equip_TpequValTipoequi_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Equip_TpequValTipoequi_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAtpequ.FldTpequcod, FieldType.TEXTO, Resources.Resources.CODE49225, 20, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 50, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTpequpai, FieldType.TEXTO, Resources.Resources.DEPENDENT_ON28321, 20, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldNivel, FieldType.NUMERO, Resources.Resources.LEVEL06184, 3, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldBackcolo, FieldType.TEXTO, Resources.Resources.BACKGROUND_COLOR47883, 30, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldCorletra, FieldType.TEXTO, Resources.Resources.LETTER_COLOR15736, 30, 0, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpequ> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpequ> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Equip_TpequValTipoequi_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);





			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, crs, "IBL_EQUIP___TPEQUTIPOEQUI");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpequ.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));


			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_tpequ"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, null, "IBL_EQUIP___TPEQUTIPOEQUI"));
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
			ListingMVC<CSGenioAtpequ> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpequ> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtpequ> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpequ> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("form_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Form", "EQUIP")
			}, "ms", "Time to load the form."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<Equip_TpequValTipoequi_RowViewModel>();

				CriteriaSet equip___tpequtipoequiConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("TPEQU.TPEQUCOD", new OrderedDictionary());
				allSortOrders["TPEQU.TPEQUCOD"].Add("TPEQU.TPEQUCOD", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "tpequ", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAtpequ model_limit_area = new CSGenioAtpequ(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_EQUIP___TPEQUTIPOEQUI");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(equip___tpequtipoequiConds);
				equip___tpequtipoequiConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ EQUIP_TPEQUTIPOEQUI]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, equip___tpequtipoequiConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___TPEQUTIPOEQUI", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP EQUIP_TPEQUTIPOEQUI]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST EQUIP_TPEQUTIPOEQUI]/

					string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_tpequ"];
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtpequ.GetInformation(), QMVC_POS_RECORD, sorts, equip___tpequtipoequiConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, equip___tpequtipoequiConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___TPEQUTIPOEQUI", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapEquip_TpequValTipoequi(listing);

					Menu.Identifier = "IBL_EQUIP___TPEQUTIPOEQUI";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_EQUIP___TPEQUTIPOEQUI";

					Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

					// Set table totalizers
					if (listing.Totalizers != null && listing.Totalizers.Count > 0)
						Menu.SetTotalizers(listing.Totalizers);
				}

				// Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;

				// Load the user table configuration names and default name
				LoadUserTableConfigNameProperties();
			}
		}

		private List<Equip_TpequValTipoequi_RowViewModel> MapEquip_TpequValTipoequi(ListingMVC<CSGenioAtpequ> Qlisting)
		{
			List<Equip_TpequValTipoequi_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEquip_TpequValTipoequi(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtpequ row
		/// to a Equip_TpequValTipoequi_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Equip_TpequValTipoequi_RowViewModel MapEquip_TpequValTipoequi(CSGenioAtpequ row)
		{
			var model = new Equip_TpequValTipoequi_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
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
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAtpequ> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Equip_TpequValTipoequi) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCorletra = ViewModelConversion.ToString(m.ValCorletra);
				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Equip_TpequValTipoequi) - Error during mapping.");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equip_TpequValTipoequi) to Model (Tpequ) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCorletra = ViewModelConversion.ToString(ValCorletra);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equip_TpequValTipoequi) to Model (Tpequ) - Error during mapping.");
				throw;
			}
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_TPEQUVALTIPOEQUI]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra", "Tpequ.ValCodfamil"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTpequcod", CSGenioAtpequ.FldTpequcod, typeof(string)),
			new TableSearchColumn("ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValTpequpai", CSGenioAtpequ.FldTpequpai, typeof(string), visible : false),
			new TableSearchColumn("ValNivel", CSGenioAtpequ.FldNivel, typeof(decimal), visible : false),
			new TableSearchColumn("ValBackcolo", CSGenioAtpequ.FldBackcolo, typeof(string), visible : false),
			new TableSearchColumn("ValCorletra", CSGenioAtpequ.FldCorletra, typeof(string), visible : false)
		];
	}
}
