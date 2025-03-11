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

namespace GenioMVC.ViewModels.Cntry
{
	public class Proppais_ValPropried_ViewModel : MenuListViewModel<Models.Propr>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.ViewModels.Propr.Proprall_ViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "propr";

		/// <inheritdoc/>
		public override string Uuid => "Proppais_ValPropried";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ValCodcntry { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS PROPPAIS_PSEUDPROPRIED]/

			return crs;
		}


		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Proppais_ValPropried_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Proppais_ValPropried_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Proppais_ValPropried_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodcntry = userContext.CurrentNavigation.CurrentLevel.GetEntry("cntry")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Proppais_ValPropried_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Proppais_ValPropried_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApropr.FldName, FieldType.TEXTO, Resources.Resources.PROPERTY_NAME18934, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldPrecoest, FieldType.VALOR, Resources.Resources.ESTIMATED_PRICE02986, 12, 0, true),
				new Exports.QColumn(CSGenioAtppro.FldTppropri, FieldType.TEXTO, Resources.Resources.PROPERTY_TYPE51419, 20, 0, true),
				new Exports.QColumn(CSGenioAregio.FldRegiao, FieldType.TEXTO, Resources.Resources.REGION12723, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldLocalida, FieldType.TEXTO, Resources.Resources.LOCALE34521, 30, 0, true),
				new Exports.QColumn(CSGenioApropr.FldEndereco, FieldType.MEMO, Resources.Resources.ADDRESS04342, 30, 2, false),
				new Exports.QColumn(CSGenioApropr.FldPostalco, FieldType.TEXTO, Resources.Resources.ZIP_CODE56964, 20, 0, false),
				new Exports.QColumn(CSGenioApropr.FldPostallo, FieldType.TEXTO, Resources.Resources.POSTAL_LOCATION08708, 30, 0, false),
				new Exports.QColumn(CSGenioApropr.FldMobilada, FieldType.LOGICO, Resources.Resources.FURNISHED37431, 1, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtd_wc, FieldType.NUMERO, Resources.Resources.BATHROOMS54249, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldQtdquart, FieldType.NUMERO, Resources.Resources.ROOMS06809, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldM2, FieldType.NUMERO, Resources.Resources.SQUARE_METERS28913, 6, 0, true),
				new Exports.QColumn(CSGenioApropr.FldDtdispon, FieldType.DATA, Resources.Resources.AVAILABILITY56489, 8, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioApropr.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
				new Exports.QColumn(CSGenioApropr.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 10, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GenioMVC.ViewModels.Propr.Proprall_ViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.ValCodcntry != null)
				crs.Equal(CSGenioApropr.FldCodcntry, this.ValCodcntry);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Propr.AddEPH<CSGenioApropr>(ref u, crs, "IBL_PROPPAISPSEUDPROPRIED");

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
					crs.Equals(Models.Propr.AddEPH<CSGenioApropr>(ref u, null, "IBL_PROPPAISPSEUDPROPRIED"));
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
			ListingMVC<CSGenioApropr> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApropr> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("form_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Form", "PROPPAIS")
			}, "ms", "Time to load the form."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<GenioMVC.ViewModels.Propr.Proprall_ViewModel>();

				CriteriaSet proppaispseudpropriedConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "propr", allSortOrders);


				FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldPhotogra, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldCodtppro, CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioApropr.FldMobilada, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioApropr.FldCodregia, CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioApropr.FldEndereco, CSGenioApropr.FldLocalida, CSGenioApropr.FldPostalco, CSGenioApropr.FldPostallo, CSGenioApropr.FldQtd_wc, CSGenioApropr.FldQtdquart, CSGenioApropr.FldM2, CSGenioApropr.FldDtdispon, CSGenioApropr.FldDescript, CSGenioApropr.FldCoordgeo, CSGenioApropr.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("propr", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioApropr model_limit_area = new CSGenioApropr(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PROPPAISPSEUDPROPRIED");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(proppaispseudpropriedConds);
				proppaispseudpropriedConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PROPPAIS_PSEUDPROPRIED]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, proppaispseudpropriedConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PROPPAISPSEUDPROPRIED", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PROPPAIS_PSEUDPROPRIED]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST PROPPAIS_PSEUDPROPRIED]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
					Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApropr.GetInformation(), QMVC_POS_RECORD, sorts, proppaispseudpropriedConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioApropr> listing = Models.ModelBase.Where<CSGenioApropr>(m_userContext, false, proppaispseudpropriedConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PROPPAISPSEUDPROPRIED", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					List<GenioMVC.ViewModels.Propr.Proprall_ViewModel> tempList = new List<GenioMVC.ViewModels.Propr.Proprall_ViewModel>();

					//By using the support form it will create entries into the navigation, making the next rows equal to the first one
					//This puts back the navigation to the starting point before calling the multiform support form
					NavigationContext Cloned = m_userContext.CurrentNavigation.Clone();

					foreach (GenioMVC.Models.Propr Propr in listing.RowsForViewModel<GenioMVC.Models.Propr>((r) => new GenioMVC.Models.Propr(m_userContext, r, true)))
					{
						tempList.Add(new GenioMVC.ViewModels.Propr.Proprall_ViewModel(m_userContext, Propr));
						m_userContext.SetNavigation(Cloned.Clone());
					}
					this.Menu.Elements = tempList;

					Menu.Identifier = "IBL_PROPPAISPSEUDPROPRIED";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_PROPPAISPSEUDPROPRIED";

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

		private List<Models.Propr> MapProppais_ValPropried(ListingMVC<CSGenioApropr> Qlisting)
		{
			List<Models.Propr> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapProppais_ValPropried(row));
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
		private Models.Propr MapProppais_ValPropried(CSGenioApropr row)
		{
			var model = new Models.Propr(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

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
					default:
						break;
				}
			}

			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return false;
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioApropr> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Propr m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Propr m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPPAIS_VALPROPRIED]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Propr", "Propr.ValCodpropr", "Propr.ValZzstate", "Propr.ValName", "Propr.ValPrecoest", "Tppro", "Tppro.ValTppropri", "Regio", "Regio.ValRegiao", "Propr.ValLocalida", "Propr.ValEndereco", "Propr.ValPostalco", "Propr.ValPostallo", "Propr.ValMobilada", "Propr.ValQtd_wc", "Propr.ValQtdquart", "Propr.ValM2", "Propr.ValDtdispon", "Propr.ValPhotogra", "Propr.ValDescript", "Propr.ValCodcntry", "Propr.ValCodpais1", "Propr.ValCodpesso", "Propr.ValCodregia", "Propr.ValCodtppro"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValName", CSGenioApropr.FldName, typeof(string)),
			new TableSearchColumn("ValPrecoest", CSGenioApropr.FldPrecoest, typeof(decimal?)),
			new TableSearchColumn("ValTppropri", CSGenioAtppro.FldTppropri, typeof(string)),
			new TableSearchColumn("ValMobilada", CSGenioApropr.FldMobilada, typeof(bool)),
			new TableSearchColumn("ValCountry", CSGenioAcntry.FldCountry, typeof(string)),
			new TableSearchColumn("ValRegiao", CSGenioAregio.FldRegiao, typeof(string)),
			new TableSearchColumn("ValEndereco", CSGenioApropr.FldEndereco, typeof(string)),
			new TableSearchColumn("ValLocalida", CSGenioApropr.FldLocalida, typeof(string)),
			new TableSearchColumn("ValPostalco", CSGenioApropr.FldPostalco, typeof(string)),
			new TableSearchColumn("ValPostallo", CSGenioApropr.FldPostallo, typeof(string)),
			new TableSearchColumn("ValQtd_wc", CSGenioApropr.FldQtd_wc, typeof(decimal?)),
			new TableSearchColumn("ValQtdquart", CSGenioApropr.FldQtdquart, typeof(decimal?)),
			new TableSearchColumn("ValM2", CSGenioApropr.FldM2, typeof(decimal?)),
			new TableSearchColumn("ValDtdispon", CSGenioApropr.FldDtdispon, typeof(DateTime?)),
			new TableSearchColumn("ValDescript", CSGenioApropr.FldDescript, typeof(string)),
			new TableSearchColumn("ValCoordgeo", CSGenioApropr.FldCoordgeo, typeof(string)),
			new TableSearchColumn("ValName", CSGenioApesso.FldName, typeof(string))
		];
		protected void SetTicketToImageFields(Models.Propr row)
		{
			if (row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPR, CSGenioApropr.FldPhotogra.Field, null, row.ValCodpropr);
		}
	}
}
