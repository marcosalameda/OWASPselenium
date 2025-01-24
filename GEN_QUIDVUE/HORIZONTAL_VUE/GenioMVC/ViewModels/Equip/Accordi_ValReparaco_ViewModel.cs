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
using CSGenio.core.di;

namespace GenioMVC.ViewModels.Equip
{
	public class Accordi_ValReparaco_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements. List type: "DP"
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Accordi_ValReparaco_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "repar"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Accordi_ValReparaco"; }

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
		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Accordi_ValReparaco_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Accordi_ValReparaco_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodequip = userContext.CurrentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioArepar.FldNrrepara, FieldType.NUMERO, Resources.Resources.NO_RUMOUR_IN_THE_COM15248, 10, 0, true),
				new Exports.QColumn(CSGenioArepar.FldDtrepara, FieldType.DATAHORA, Resources.Resources.FIXED_IN00179, 16, 0, true),
				new Exports.QColumn(CSGenioAcate1.FldCategoria, FieldType.TEXTO, Resources.Resources.SPECIALTY09304, 30, 0, true),
				new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.EXPERT27393, 30, 0, true),
				new Exports.QColumn(CSGenioArepar.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION_OF_THE_R26085, 30, 3, true),
				new Exports.QColumn(CSGenioArepar.FldHours, FieldType.NUMERO, Resources.Resources.SPENT_ON_HOURS19285, 10, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Accordi_ValReparaco_RowViewModel>();
			Menu.SetFilters(false, false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("REPAR.NRREPARA", new OrderedDictionary());
			allSortOrders["REPAR.NRREPARA"].Add("REPAR.NRREPARA", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.ValCodequip != null)
				crs.Equal(CSGenioArepar.FldCodequip, this.ValCodequip);





			if (isToExport)
			{
				// EPH
				crs = Models.Repar.AddEPH<CSGenioArepar>(ref u, crs, "IBL_ACCORDI_PSEUDREPARACO");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArepar.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("REPAR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArepar.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Repar.AddEPH<CSGenioArepar>(ref u, null, "IBL_ACCORDI_PSEUDREPARACO"));
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
			ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("form_load_time", new List<KeyValuePair<string, object>>() {
				new("Form", "ACCORDI")
			}, "ms", "Time to load the form.")) {

				User u = m_userContext.User;
				Menu = new TablePartial<Accordi_ValReparaco_RowViewModel>();

				CriteriaSet accordi_pseudreparacoConds = CriteriaSet.And();

				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("REPAR.NRREPARA", new OrderedDictionary());
				allSortOrders["REPAR.NRREPARA"].Add("REPAR.NRREPARA", "A");




				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "repar", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArepar.FldNrrepara), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldCodcateg, CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldDescript, CSGenioArepar.FldHours };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("repar", "nrrepara");
				}


				// Limitations
				if (this.tableLimits == null)
					this.tableLimits = new List<Limit>();
				//Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArepar model_limit_area = new CSGenioArepar(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ACCORDI_PSEUDREPARACO");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(accordi_pseudreparacoConds);
				accordi_pseudreparacoConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ACCORDI_PSEUDREPARACO]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioArepar>(m_userContext, false, accordi_pseudreparacoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PSEUDREPARACO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ACCORDI_PSEUDREPARACO]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST ACCORDI_PSEUDREPARACO]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
					Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioArepar.GetInformation(), QMVC_POS_RECORD, sorts, accordi_pseudreparacoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioArepar> listing = Models.ModelBase.Where<CSGenioArepar>(m_userContext, false, accordi_pseudreparacoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PSEUDREPARACO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;


					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapAccordi_ValReparaco(listing);

					Menu.Identifier = "IBL_ACCORDI_PSEUDREPARACO";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_ACCORDI_PSEUDREPARACO";

					Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

					// Set table totalizers
					if (listing.Totalizers != null && listing.Totalizers.Count > 0)
						Menu.SetTotalizers(listing.Totalizers);
				}

				//Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;

				//Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;
				
				// Load the user table configuration names and default name
				LoadUserTableConfigNameProperties();
			}
		}

		private List<Accordi_ValReparaco_RowViewModel> MapAccordi_ValReparaco(ListingMVC<CSGenioArepar> Qlisting)
		{
			var Elements = new List<Accordi_ValReparaco_RowViewModel>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAccordi_ValReparaco(row));
					i++;
				}
			}

			return Elements;
		}


		/// <summary>
		/// Maps a single CSGenioArepar row
		/// to a Accordi_ValReparaco_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Accordi_ValReparaco_RowViewModel MapAccordi_ValReparaco(CSGenioArepar row)
		{
			var model = new Accordi_ValReparaco_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;
			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "repar":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cate1":
						model.Cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pesso":
						model.Pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			CalculateButtonPermissions(model);


			return model;
		}

		/// <summary>
		/// Checks CRUD conditions to determine which actions the user can perform.
		/// </summary>
		public void CalculateButtonPermissions(Accordi_ValReparaco_RowViewModel model)
		{
			bool canView = true;
			bool canEdit = true;
			bool canDelete = true;
			bool canDuplicate = true;
			bool canInsert = true;
			using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport)) {
			}
			model.BtnPermission = new TableRowCrudButtonPermissions()
			{
				DeleteBtnDisabled = !canDelete,
				EditBtnDisabled = !canEdit,
				ViewBtnDisabled = !canView,
				DuplicateBtnDisabled = !canDuplicate,
				InsertBtnDisabled = !canInsert,
			};
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
		private void SetDocumentFields(ListingMVC<CSGenioArepar> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioArepar row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ACCORDI_VALREPARACO]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Repar", "Repar.ValCodrepar", "Repar.ValZzstate", "Repar.ValNrrepara", "Repar.ValDtrepara", "Cate1", "Cate1.ValCategoria", "Pesso", "Pesso.ValName", "Repar.ValDescript", "Repar.ValHours", "Repar.ValCodcateg", "Repar.ValCodempre", "Repar.ValCodequip", "Repar.ValCodpesso", "Repar.ValCodespec", "BtnPermission"
		];

		private static readonly List<TableSearchColumn> _searchableColumns = 
		[
			new TableSearchColumn("ValNrrepara", CSGenioArepar.FldNrrepara, typeof(decimal?)),
			new TableSearchColumn("ValDtrepara", CSGenioArepar.FldDtrepara, typeof(DateTime?)),
			new TableSearchColumn("Cate1_ValCategoria", CSGenioAcate1.FldCategoria, typeof(string)),
			new TableSearchColumn("Pesso_ValName", CSGenioApesso.FldName, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioArepar.FldDescript, typeof(string)),
			new TableSearchColumn("ValHours", CSGenioArepar.FldHours, typeof(decimal?))
		];



	}
}
