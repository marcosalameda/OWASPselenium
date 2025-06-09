using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;


namespace RESTGenio.XRS
{
    [ApiController]
    [Route("XRS")]
    public class RESTServiceXRS : Controller
    {
        private static readonly string modulo = "XRS";


		private List<ListRecordWarehouses> ListWarehouses_internal(User user, LogicalCondition? condition, Paging? paging, Order? order, PersistentSupport sp, out int numRecords)
		{
			List<ListRecordWarehouses> result = new List<ListRecordWarehouses>();
			string areaName = "wareh";
			string id = "XRSML11";
			Area area = Area.createArea(areaName, user, modulo);

            if (user is null)
                throw new Exception("Session user not initialized");
			if (!area.AccessRightsToConsult(user))
				throw new Exception("User does not have sufficient access rights");

			Dictionary<string, FieldRef> fieldMap = new Dictionary<string, FieldRef>(StringComparer.OrdinalIgnoreCase);
			fieldMap["PRIMARYKEY"] = CSGenioAwareh.FldCodwareh;
			fieldMap["WAREHOUSE"] = CSGenioAwareh.FldWarehdes;
			fieldMap["ACRONYM"] = CSGenioAwareh.FldWarehcod;
			fieldMap["ACTIVITY"] = CSGenioAwareh.FldActivity;
			fieldMap["SHOWRECORD"] = CSGenioAwareh.FldShowreco;
			fieldMap["NUMBEROFEMPLOYEES"] = CSGenioAwareh.FldNum_employee;

			CriteriaSet cond = condition is null ? CriteriaSet.And() : condition.ToCriteriaSet(fieldMap);

			if (paging != null)
			{
				if (paging.getCount == true)
					numRecords = DatabaseService.SelectCount(modulo, areaName, user, cond, id, sp);
				else
					numRecords = -1;
			}
			else
			{
				paging = new Paging();
				numRecords = -1;
			}

			List<ColumnSort> orderBy = [];

			if (order != null)
			{
				foreach (OrderBy ord in order.orders)
                {
                    ColumnReference cr = new ColumnReference(fieldMap[ord.Field]);
                    orderBy.Add(new ColumnSort(cr, (ord.Direction == OrderByDirection.ASC ? SortOrder.Ascending : SortOrder.Descending)));
                }
			}

			DataTable t = DatabaseService.SelectSeveral(modulo, areaName, user, id, paging.numRecords, cond, paging.page, orderBy, sp);

			for (int i = 0; i < t.Rows.Count; i++)
			{
				DatabaseService.MapRow2Area(t.Rows[i], area);
				ListRecordWarehouses newRecord = new ListRecordWarehouses();
				newRecord.primaryKey = area.Fields.ContainsKey("wareh.codwareh") ? DatabaseService.FormatDataField(area, "wareh.codwareh") : String.Empty;
				newRecord.Warehouse = area.Fields.ContainsKey("wareh.warehdes") ? DatabaseService.FormatDataField(area, "wareh.warehdes") : String.Empty;
				newRecord.Acronym = area.Fields.ContainsKey("wareh.warehcod") ? DatabaseService.FormatDataField(area, "wareh.warehcod") : String.Empty;
				newRecord.Activity = area.Fields.ContainsKey("wareh.activity") ? RESTArrays.GetArrayActividadeValueById(DatabaseService.FormatDataField(area, "wareh.activity")) : null;
				newRecord.ShowRecord = area.Fields.ContainsKey("wareh.showreco") ? DatabaseService.FormatDataField(area, "wareh.showreco") : String.Empty;
				newRecord.NumberOfEmployees = area.Fields.ContainsKey("wareh.num_employee") ? DatabaseService.FormatDataField(area, "wareh.num_employee") : String.Empty;
				result.Add(newRecord);
			}

			return result;
		}


		/// <summary>
		/// Lists records of Warehouses
		/// </summary>
		[Authorize]
		[HttpGet("Warehouses/List", Name = "ListWarehousesGet")]
		[SwaggerOperation(Tags = new[] { "XRS - Warehouses" })]
		public ActionResult<ListResponseWarehouses> ListWarehousesGet()
		{
			return ListWarehousesPost(new ListRequest());
        }

		/// <summary>
        /// Queries records of Warehouses
        /// </summary>
		[Authorize]
        [HttpPost("Warehouses/List", Name = "ListWarehousesPost")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouses" })]
		public ActionResult<ListResponseWarehouses> ListWarehousesPost(ListRequest request)
		{
			var response = new ListResponseWarehouses();
			PersistentSupport? sp = null;

			try
			{
				User user = AuthService.ValidateAuthentication(HttpContext, modulo);
				sp = PersistentSupport.getPersistentSupport(user.Year);
				sp.openTransaction();

				response.Data = ListWarehouses_internal(user, request.condition, request.paging, request.order, sp, out int auxRecords);
				response.numRecords = auxRecords;

				sp.closeTransaction();

				response.Ok();
			}
			catch (GenioException ep)
			{
				sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
			}
			catch (Exception e)
			{
				sp?.rollbackTransaction();
				response.Error(e.Message);
			}
			return response;
		}

		private Response FormGenericDelete_internal(string modulo, string area, string primaryKey)
        {
            Response response = new Response();
            PersistentSupport? sp = null;

            try
            {
                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction ();
                StatusMessage status = DatabaseService.Delete(area, user, primaryKey, sp);
                sp.closeTransaction();

                response.Ok();
            }
            catch (GenioException ep)
            {
				sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
				sp?.rollbackTransaction();
                response.Error(e.Message);
            }

            return response;
        }


		//-------------------------------------
		// Operations on the form Articles
		//-------------------------------------

		/// <summary>
        /// Writes the area into the record
        /// </summary>
        /// <param name="record">Target</param>
        /// <param name="area">Source</param>
		private void WriteFormRecordArticles(FormRecordArticles record, Area area)
		{
			record.primaryKey = area.Fields.ContainsKey("item.coditem") ? DatabaseService.FormatDataField(area, "item.coditem") : String.Empty;
			record.GlobalArticle = area.Fields.ContainsKey("gitem.itemdes") ? DatabaseService.FormatDataField(area, "gitem.itemdes") : String.Empty;
			record.Warehouse = area.Fields.ContainsKey("wareh.warehdes") ? DatabaseService.FormatDataField(area, "wareh.warehdes") : String.Empty;
			record.Type = area.Fields.ContainsKey("item.itemtype") ? RESTArrays.GetArrayArticleTypesValueById(DatabaseService.FormatDataField(area, "item.itemtype")) : null;
			record.Article = area.Fields.ContainsKey("item.itemdes") ? DatabaseService.FormatDataField(area, "item.itemdes") : String.Empty;
			record.Code = area.Fields.ContainsKey("item.itemcod") ? DatabaseService.FormatDataField(area, "item.itemcod") : String.Empty;
			record.Entries = area.Fields.ContainsKey("item.entries") ? DatabaseService.FormatDataField(area, "item.entries") : String.Empty;
			record.Outputs = area.Fields.ContainsKey("item.exits") ? DatabaseService.FormatDataField(area, "item.exits") : String.Empty;
			record.Stocks = area.Fields.ContainsKey("item.existenc") ? DatabaseService.FormatDataField(area, "item.existenc") : String.Empty;
			record.Image = area.Fields.ContainsKey("item.image") ? DatabaseService.FormatDataField(area, "item.image") : String.Empty;
			record.Image_Ticket = DatabaseService.EncodeBinaryRef(area, "item.image", area.User);
			record.Categorization = area.Fields.ContainsKey("item.category") ? DatabaseService.FormatDataField(area, "item.category") : String.Empty;
			record.InUse = area.Fields.ContainsKey("item.valid") ? DatabaseService.FormatDataField(area, "item.valid") : String.Empty;
			record.Availability = area.Fields.ContainsKey("item.disponib") ? RESTArrays.GetArrayAvailabilityValueById(DatabaseService.FormatDataField(area, "item.disponib")) : null;
			record.Date = area.Fields.ContainsKey("item.date") ? DatabaseService.FormatDataField(area, "item.date") : String.Empty;
			record.Specifications = area.Fields.ContainsKey("item.techspec") ? DatabaseService.FormatDataField(area, "item.techspec") : String.Empty;
			record.Specifications_Ticket = DatabaseService.EncodeDocumRef(area, "item.techspec", area.User);
			record.Codgitem = area.Fields.ContainsKey("item.codgitem") ? DatabaseService.FormatDataField(area, "item.codgitem") : String.Empty;
			record.Codwareh = area.Fields.ContainsKey("item.codwareh") ? DatabaseService.FormatDataField(area, "item.codwareh") : String.Empty;
		}

		/// <summary>
        /// Reads the record into the area
        /// </summary>
        /// <param name="record">Source</param>
        /// <param name="area">Target</param>
		private void ReadFormRecordArticles(FormRecordArticles record, Area area)
		{
            var lstFieldNames = new List<string>();
            var lstFiledValues = new List<string>();

			if (record.primaryKey != null)
            {
                lstFieldNames.Add("item.coditem");
                lstFiledValues.Add(record.primaryKey);
            }
			if (record.Type != null)
            {
                lstFieldNames.Add("item.itemtype");
				lstFiledValues.Add(RESTArrays.GetArrayArticleTypesIdByValue(record.Type));
            }
			if (record.Article != null)
            {
                lstFieldNames.Add("item.itemdes");
                lstFiledValues.Add(record.Article);
            }
			if (record.Code != null)
            {
                lstFieldNames.Add("item.itemcod");
                lstFiledValues.Add(record.Code);
            }
			if (record.Entries != null)
            {
                lstFieldNames.Add("item.entries");
                lstFiledValues.Add(record.Entries);
            }
			if (record.Outputs != null)
            {
                lstFieldNames.Add("item.exits");
                lstFiledValues.Add(record.Outputs);
            }
			if (record.Stocks != null)
            {
                lstFieldNames.Add("item.existenc");
                lstFiledValues.Add(record.Stocks);
            }
			if (record.Categorization != null)
            {
                lstFieldNames.Add("item.category");
                lstFiledValues.Add(record.Categorization);
            }
			if (record.InUse != null)
            {
                lstFieldNames.Add("item.valid");
                lstFiledValues.Add(record.InUse);
            }
			if (record.Availability != null)
            {
                lstFieldNames.Add("item.disponib");
				lstFiledValues.Add(RESTArrays.GetArrayAvailabilityIdByValue(record.Availability));
            }
			if (record.Date != null)
            {
                lstFieldNames.Add("item.date");
                lstFiledValues.Add(record.Date);
            }
			if (record.Codgitem != null)
            {
                lstFieldNames.Add("item.codgitem");
                lstFiledValues.Add(record.Codgitem);
            }
			if (record.Codwareh != null)
            {
                lstFieldNames.Add("item.codwareh");
                lstFiledValues.Add(record.Codwareh);
            }
			area.insertNamesValuesFields(lstFieldNames.ToArray(), lstFiledValues.ToArray());
		}


		private FormRecordArticles FormSelectOneArticles_internal(User user, string primaryKey, PersistentSupport sp)
		{
			var response = new FormRecordArticles();
            string areaName = "item";
            string[] fieldNamesArray = { "item.coditem","gitem.itemdes","wareh.warehdes","item.itemtype","item.itemdes","item.itemcod","item.entries","item.exits","item.existenc","item.image","item.category","item.valid","item.disponib","item.date","item.techspec","item.techspecfk","item.codgitem","item.codwareh", };
			// TODO data validation
			Area area = Area.createArea(areaName, user, modulo);
			Field key = area.DBFields[area.PrimaryKeyName];

			DatabaseService.ValidarCampoChave(key, primaryKey);

			if (!area.AccessRightsToConsult(user))
				throw new Exception("User does not have sufficient access rights");

			area.insertNamesFields(fieldNamesArray);

			CriteriaSet condition = CriteriaSet.And().Equal(area.Alias, area.PrimaryKeyName, primaryKey);

			area.selectOne(condition, new List<ColumnSort>(), "", sp);
			WriteFormRecordArticles(response, area);

			return response;
		}

		/// <summary>
        /// Returns a record of Articles
        /// </summary>
		/// <param name="primaryKey">Primary key</param>
		[Authorize]
		[HttpGet("Articles/Select/{primaryKey}", Name = "SelectArticles")]
        [SwaggerOperation(Tags = new[] { "XRS - Articles" })]
		public ActionResult<ArticlesFormResponse> FormSelectOneArticles(string primaryKey)
		{
			var response = new ArticlesFormResponse();
			try
			{
				User user = AuthService.ValidateAuthentication(HttpContext, modulo); ;
				PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year);
				sp.openConnection();

				response.record = FormSelectOneArticles_internal(user, primaryKey, sp);

				sp.closeTransaction();
				response.Ok();
			}
			catch (GenioException ep)
			{
				response.Error(ep.UserMessage);
			}
			catch (Exception e)
			{
				response.Error(e.Message);
			}
			return response;
		}

		private ArticlesFormResponse FormInsertArticles_internal(User user, FormRecordArticles record, PersistentSupport sp)
		{
			var response = new ArticlesFormResponse();
			string areaName = "item";

			Area area = Area.createArea(areaName, user, modulo);
			ReadFormRecordArticles(record, area);

			StatusMessage msg = area.inserir_WS(sp);
			if (msg.Status != Status.E)
			{
                var result = new FormRecordArticles();
                WriteFormRecordArticles(result, area);
				response.record = result;
			}
			response.SetStatus(msg);

			return response;
		}

		/// <summary>
        /// Inserts a record of Articles
        /// </summary>
		[Authorize]
        [HttpPost("Articles/Insert", Name = "InsertArticles")]
        [SwaggerOperation(Tags = new[] { "XRS - Articles" })]
		public ActionResult<ArticlesFormResponse> FormInsertArticles(ArticlesFormRequest request)
        {
            var response = new ArticlesFormResponse();
            PersistentSupport? sp = null;
            var record = request.record;

            try
            {
                if (record is null)
                    throw new Exception("Record cannot be empty");

                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                response = FormInsertArticles_internal(user, record, sp);

                sp.closeTransaction();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
                response.Error(e.Message);
            }

			return response;
        }

		private StatusMessage FormUpdateArticles_internal(User user, FormRecordArticles record, PersistentSupport sp)
        {
			Area area = Area.createArea("item", user, modulo);
			ReadFormRecordArticles(record, area);
			return DatabaseService.Update(area, sp);
        }

		/// <summary>
        /// Updates a record of Articles
        /// </summary>
		[Authorize]
        [HttpPut("Articles/Update", Name = "UpdateArticles")]
        [SwaggerOperation(Tags = new[] { "XRS - Articles" })]
        public ActionResult<Response> FormUpdateArticles(ArticlesFormRequest request)
        {
            var response = new Response();
            PersistentSupport? sp = null;
            var record = request.record;

            try
            {
                if (record is null)
                    throw new Exception("Record cannot be empty");

                // throws exception if it fails
                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                StatusMessage result = FormUpdateArticles_internal(user, record, sp);

                sp.closeTransaction();

				response.Ok();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
                response.Error(e.Message);
            }

			return response;
        }

		/// <summary>
        /// Deletes a record of Articles
        /// </summary>
		/// <param name="primaryKey">Primary key</param>
		[Authorize]
        [HttpDelete("Articles/Delete/{primaryKey}", Name = "DeleteArticles")]
        [SwaggerOperation(Tags = new[] { "XRS - Articles" })]
		public ActionResult<Response> FormDeleteArticles(string primaryKey)
        {
            return FormGenericDelete_internal(modulo, "item", primaryKey);
        }



		//-------------------------------------
		// Operations on the form Warehouse
		//-------------------------------------

		/// <summary>
        /// Writes the area into the record
        /// </summary>
        /// <param name="record">Target</param>
        /// <param name="area">Source</param>
		private void WriteFormRecordWarehouse(FormRecordWarehouse record, Area area)
		{
			record.primaryKey = area.Fields.ContainsKey("wareh.codwareh") ? DatabaseService.FormatDataField(area, "wareh.codwareh") : String.Empty;
			record.Warehouse = area.Fields.ContainsKey("wareh.warehdes") ? DatabaseService.FormatDataField(area, "wareh.warehdes") : String.Empty;
			record.Acronym = area.Fields.ContainsKey("wareh.warehcod") ? DatabaseService.FormatDataField(area, "wareh.warehcod") : String.Empty;
			record.Activity = area.Fields.ContainsKey("wareh.activity") ? RESTArrays.GetArrayActividadeValueById(DatabaseService.FormatDataField(area, "wareh.activity")) : null;
			record.ShowRecord = area.Fields.ContainsKey("wareh.showreco") ? DatabaseService.FormatDataField(area, "wareh.showreco") : String.Empty;
			record.NumberOfEmployees = area.Fields.ContainsKey("wareh.num_employee") ? DatabaseService.FormatDataField(area, "wareh.num_employee") : String.Empty;
		}

		/// <summary>
        /// Reads the record into the area
        /// </summary>
        /// <param name="record">Source</param>
        /// <param name="area">Target</param>
		private void ReadFormRecordWarehouse(FormRecordWarehouse record, Area area)
		{
            var lstFieldNames = new List<string>();
            var lstFiledValues = new List<string>();

			if (record.primaryKey != null)
            {
                lstFieldNames.Add("wareh.codwareh");
                lstFiledValues.Add(record.primaryKey);
            }
			if (record.Warehouse != null)
            {
                lstFieldNames.Add("wareh.warehdes");
                lstFiledValues.Add(record.Warehouse);
            }
			if (record.Acronym != null)
            {
                lstFieldNames.Add("wareh.warehcod");
                lstFiledValues.Add(record.Acronym);
            }
			if (record.Activity != null)
            {
                lstFieldNames.Add("wareh.activity");
				lstFiledValues.Add(RESTArrays.GetArrayActividadeIdByValue(record.Activity));
            }
			if (record.ShowRecord != null)
            {
                lstFieldNames.Add("wareh.showreco");
                lstFiledValues.Add(record.ShowRecord);
            }
			if (record.NumberOfEmployees != null)
            {
                lstFieldNames.Add("wareh.num_employee");
                lstFiledValues.Add(record.NumberOfEmployees);
            }
			area.insertNamesValuesFields(lstFieldNames.ToArray(), lstFiledValues.ToArray());
		}


		private FormRecordWarehouse FormSelectOneWarehouse_internal(User user, string primaryKey, PersistentSupport sp)
		{
			var response = new FormRecordWarehouse();
            string areaName = "wareh";
            string[] fieldNamesArray = { "wareh.codwareh","wareh.warehdes","wareh.warehcod","wareh.activity","wareh.showreco","wareh.num_employee", };
			// TODO data validation
			Area area = Area.createArea(areaName, user, modulo);
			Field key = area.DBFields[area.PrimaryKeyName];

			DatabaseService.ValidarCampoChave(key, primaryKey);

			if (!area.AccessRightsToConsult(user))
				throw new Exception("User does not have sufficient access rights");

			area.insertNamesFields(fieldNamesArray);

			CriteriaSet condition = CriteriaSet.And().Equal(area.Alias, area.PrimaryKeyName, primaryKey);

			area.selectOne(condition, new List<ColumnSort>(), "", sp);
			WriteFormRecordWarehouse(response, area);

			return response;
		}

		/// <summary>
        /// Returns a record of Warehouse
        /// </summary>
		/// <param name="primaryKey">Primary key</param>
		[Authorize]
		[HttpGet("Warehouse/Select/{primaryKey}", Name = "SelectWarehouse")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseFormResponse> FormSelectOneWarehouse(string primaryKey)
		{
			var response = new WarehouseFormResponse();
			try
			{
				User user = AuthService.ValidateAuthentication(HttpContext, modulo); ;
				PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year);
				sp.openConnection();

				response.record = FormSelectOneWarehouse_internal(user, primaryKey, sp);

				sp.closeTransaction();
				response.Ok();
			}
			catch (GenioException ep)
			{
				response.Error(ep.UserMessage);
			}
			catch (Exception e)
			{
				response.Error(e.Message);
			}
			return response;
		}

		private WarehouseFormResponse FormInsertWarehouse_internal(User user, FormRecordWarehouse record, PersistentSupport sp)
		{
			var response = new WarehouseFormResponse();
			string areaName = "wareh";

			Area area = Area.createArea(areaName, user, modulo);
			ReadFormRecordWarehouse(record, area);

			StatusMessage msg = area.inserir_WS(sp);
			if (msg.Status != Status.E)
			{
                var result = new FormRecordWarehouse();
                WriteFormRecordWarehouse(result, area);
				response.record = result;
			}
			response.SetStatus(msg);

			return response;
		}

		/// <summary>
        /// Inserts a record of Warehouse
        /// </summary>
		[Authorize]
        [HttpPost("Warehouse/Insert", Name = "InsertWarehouse")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseFormResponse> FormInsertWarehouse(WarehouseFormRequest request)
        {
            var response = new WarehouseFormResponse();
            PersistentSupport? sp = null;
            var record = request.record;

            try
            {
                if (record is null)
                    throw new Exception("Record cannot be empty");

                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                response = FormInsertWarehouse_internal(user, record, sp);

                sp.closeTransaction();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
                response.Error(e.Message);
            }

			return response;
        }

		private StatusMessage FormUpdateWarehouse_internal(User user, FormRecordWarehouse record, PersistentSupport sp)
        {
			Area area = Area.createArea("wareh", user, modulo);
			ReadFormRecordWarehouse(record, area);
			return DatabaseService.Update(area, sp);
        }

		/// <summary>
        /// Updates a record of Warehouse
        /// </summary>
		[Authorize]
        [HttpPut("Warehouse/Update", Name = "UpdateWarehouse")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
        public ActionResult<Response> FormUpdateWarehouse(WarehouseFormRequest request)
        {
            var response = new Response();
            PersistentSupport? sp = null;
            var record = request.record;

            try
            {
                if (record is null)
                    throw new Exception("Record cannot be empty");

                // throws exception if it fails
                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                StatusMessage result = FormUpdateWarehouse_internal(user, record, sp);

                sp.closeTransaction();

				response.Ok();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
                response.Error(e.Message);
            }

			return response;
        }

		/// <summary>
        /// Deletes a record of Warehouse
        /// </summary>
		/// <param name="primaryKey">Primary key</param>
		[Authorize]
        [HttpDelete("Warehouse/Delete/{primaryKey}", Name = "DeleteWarehouse")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<Response> FormDeleteWarehouse(string primaryKey)
        {
            return FormGenericDelete_internal(modulo, "wareh", primaryKey);
        }
		private List<WarehouseArticlesListRecord> ShowTableSelectSeveralArticles_internal(User user, LogicalCondition? condition, Paging? paging, Order? order, PersistentSupport sp, out int numRecords)
		{
			var response = new List<WarehouseArticlesListRecord>();
			string id = "LDP_WARE_WS_XITEM___";
			string areaName = "item";

			Area area = Area.createArea(areaName, user, modulo);
			Dictionary<string, FieldRef> fieldMap = new Dictionary<string, FieldRef>(StringComparer.OrdinalIgnoreCase);
			fieldMap["PRIMARYKEY"] = CSGenioAitem.FldCoditem;
			fieldMap["TYPE"] = CSGenioAitem.FldItemtype;
			fieldMap["ARTICLE"] = CSGenioAitem.FldItemdes;
			fieldMap["CODE"] = CSGenioAitem.FldItemcod;
			fieldMap["ENTRIES"] = CSGenioAitem.FldEntries;
			fieldMap["OUTPUTS"] = CSGenioAitem.FldExits;
			fieldMap["STOCKS"] = CSGenioAitem.FldExistenc;
			fieldMap["IMAGE"] = CSGenioAitem.FldImage;
			fieldMap["CATEGORIZATION"] = CSGenioAitem.FldCategory;
			fieldMap["INUSE"] = CSGenioAitem.FldValid;
			fieldMap["AVAILABILITY"] = CSGenioAitem.FldDisponib;
			fieldMap["DATE"] = CSGenioAitem.FldDate;
			fieldMap["CODWAREH"] = CSGenioAitem.FldCodwareh;

			CriteriaSet cond = condition is null ? CriteriaSet.And() : condition.ToCriteriaSet(fieldMap);

			if (paging != null)
			{
				if (paging.getCount == true)
					numRecords = DatabaseService.SelectCount(modulo, areaName, user, cond, id, sp);
				else
					numRecords = -1;
			}
			else
			{
				paging = new Paging();
				numRecords = -1;
			}

			List<ColumnSort> orderBy = [];

			if (order != null)
			{
				foreach (OrderBy ord in order.orders)
				{
					ColumnReference cr = new ColumnReference(fieldMap[ord.Field]);
                    orderBy.Add(new ColumnSort(cr,(ord.Direction == OrderByDirection.ASC ? SortOrder.Ascending : SortOrder.Descending)));
				}
			}
			DataTable t = DatabaseService.SelectSeveral(modulo, areaName, user, id, paging.numRecords, cond, paging.page, orderBy, sp);

			for (int i = 0; i < t.Rows.Count; i++)
			{
				DatabaseService.MapRow2Area(t.Rows[i], area);
				WarehouseArticlesListRecord newRecord = new WarehouseArticlesListRecord();
				newRecord.primaryKey = area.Fields.ContainsKey("item.coditem") ? DatabaseService.FormatDataField(area, "item.coditem") : String.Empty;
				newRecord.Type = area.Fields.ContainsKey("item.itemtype") ? RESTArrays.GetArrayArticleTypesValueById(DatabaseService.FormatDataField(area, "item.itemtype")) : null;
				newRecord.Article = area.Fields.ContainsKey("item.itemdes") ? DatabaseService.FormatDataField(area, "item.itemdes") : String.Empty;
				newRecord.Code = area.Fields.ContainsKey("item.itemcod") ? DatabaseService.FormatDataField(area, "item.itemcod") : String.Empty;
				newRecord.Entries = area.Fields.ContainsKey("item.entries") ? DatabaseService.FormatDataField(area, "item.entries") : String.Empty;
				newRecord.Outputs = area.Fields.ContainsKey("item.exits") ? DatabaseService.FormatDataField(area, "item.exits") : String.Empty;
				newRecord.Stocks = area.Fields.ContainsKey("item.existenc") ? DatabaseService.FormatDataField(area, "item.existenc") : String.Empty;
				newRecord.Image = area.Fields.ContainsKey("item.image") ? DatabaseService.FormatDataField(area, "item.image") : String.Empty;
				newRecord.Image_Ticket = DatabaseService.EncodeBinaryRef(area, "item.image", user);
				newRecord.Categorization = area.Fields.ContainsKey("item.category") ? DatabaseService.FormatDataField(area, "item.category") : String.Empty;
				newRecord.InUse = area.Fields.ContainsKey("item.valid") ? DatabaseService.FormatDataField(area, "item.valid") : String.Empty;
				newRecord.Availability = area.Fields.ContainsKey("item.disponib") ? RESTArrays.GetArrayAvailabilityValueById(DatabaseService.FormatDataField(area, "item.disponib")) : null;
				newRecord.Date = area.Fields.ContainsKey("item.date") ? DatabaseService.FormatDataField(area, "item.date") : String.Empty;
				newRecord.Codwareh = area.Fields.ContainsKey("item.codwareh") ? DatabaseService.FormatDataField(area, "item.codwareh") : String.Empty;
				response.Add(newRecord);
			}

			return response;
		}

		/// <summary>
        /// Lists child records Articles of record Warehouse
        /// </summary>
		[Authorize]
        [HttpPost("Warehouse/ArticlesList", Name = "WarehouseArticlesList")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseArticlesListResponse> ShowTableSelectSeveralArticles(ListRequest request)
		{
			var response = new WarehouseArticlesListResponse();
			PersistentSupport? sp = null;

			try
			{
				User user = AuthService.ValidateAuthentication(HttpContext, modulo);
				sp = PersistentSupport.getPersistentSupport(user.Year);
				sp.openTransaction();

				response.Data = ShowTableSelectSeveralArticles_internal(user, request.condition, request.paging, request.order, sp, out int auxRecords);
				response.numRecords = auxRecords;

				sp.closeTransaction();

				response.Ok();
			}
			catch (GenioException ep)
			{
				sp?.rollbackTransaction();
				response.Error(ep.UserMessage);
			}
			catch (Exception e)
			{
				sp?.rollbackTransaction();
				response.Error(e.Message);
			}

			return response;
		}


		private ListUpdateResponse WarehouseArticlesListUpdate_internal(User user, PersistentSupport sp, List<FormRecordArticles>? updateRecords, List<FormRecordArticles>? insertRecords, List<string>? deleteRecords, bool stopOnError)
		{
			var response = new ListUpdateResponse();
			string areaName = "item";

			response.update = new List<Response>();
			if (updateRecords != null)
			foreach (FormRecordArticles reg in updateRecords)
			{
				Response resp;
				try
				{
					StatusMessage msg = FormUpdateArticles_internal(user, reg, sp);
					resp = RESTGenio.Response.FromStatus(msg);
				}
				catch (Exception e)
				{
					resp = new Response();
					resp.Error(e.Message);
				}

				response.update.Add(resp);
				if (resp.status == RESTStatus.Error && stopOnError)
					throw new Exception(resp.message);
			}

			response.insert = new List<ResponseInsert>();
			if (insertRecords != null)
			foreach (FormRecordArticles reg in insertRecords)
			{
				ResponseInsert resp;
				try
				{
					var msg = FormInsertArticles_internal(user, reg, sp);
					resp = new ResponseInsert();
					resp.status = msg.status;
					resp.message = msg.message;
					resp.primaryKey = msg.record?.primaryKey;
				}
				catch (Exception e)
				{
					resp = new ResponseInsert();
					resp.Error(e.Message);
				}

				response.insert.Add(resp);
				if (resp.status == RESTStatus.Error && stopOnError)
					throw new Exception(resp.message);
			}

			response.delete = new List<Response>();
			if (deleteRecords != null)
			{
				foreach (string reg in deleteRecords)
				{
					Response resp;
					try
					{
						StatusMessage msg = DatabaseService.Delete(areaName, user, reg, sp);
						resp = RESTGenio.Response.FromStatus(msg);
					}
					catch (Exception e)
					{
						resp = new Response();
						resp.Error(e.Message);
					}

					response.delete.Add(resp);
					if (resp.status == RESTStatus.Error && stopOnError)
						throw new Exception(resp.message);
				}
			}

			return response;
		}

		/// <summary>
        /// Updates child records Articles of record Warehouse
        /// </summary>
		[Authorize]
        [HttpPut("Warehouse/ArticlesListUpdate", Name = "WarehouseArticlesListUpdate")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<ListUpdateResponse> WarehouseArticlesListUpdate(WarehouseArticlesListUpdateRequest request)
		{
			var response = new ListUpdateResponse();
            PersistentSupport? sp = null;
            bool stopOnError = request.stopOnError;

            try
            {
                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

				response = WarehouseArticlesListUpdate_internal(user, sp, request.updateRecords, request.insertRecords, request.deleteRecords, stopOnError);

                sp.closeTransaction();

                response.Ok();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
				response.Error(e.Message);
            }

			return response;
		}


		// Warehouse composite methods


		/// <summary>
		/// Composite selects a record of Warehouse and all its child records
		/// </summary>
		/// <param name="primaryKey">Primary key</param>
		[Authorize]
		[HttpGet("Warehouse/SelectComposite/{primaryKey}", Name = "SelectCompositeWarehouseGet")]
		[SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseFormCompositeResponse> FormSelectOneWarehouseCompositeGet(string primaryKey)
		{
			return FormSelectOneWarehouseCompositePost(new WarehouseFormCompositeRequest()
			{
				primaryKey = primaryKey
			});
        }

		/// <summary>
        /// Composite selects a record of Warehouse and queries its child records
        /// </summary>
		[Authorize]
        [HttpPost("Warehouse/SelectComposite", Name = "SelectCompositeWarehousePost")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseFormCompositeResponse> FormSelectOneWarehouseCompositePost(WarehouseFormCompositeRequest request)
		{
			var response = new WarehouseFormCompositeResponse();

			try
			{
				User user = AuthService.ValidateAuthentication(HttpContext, modulo);
				PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openConnection();

				response.recordWarehouse = FormSelectOneWarehouse_internal(user, request.primaryKey, sp);
				int dummy;
				// TODO - is the condition of equality of the external key of each expoe table for the registration of the form here hardcoded or already comes from the client?

				// TODO - add a count to the result for each exposure? will change the signature of the contract
				// The composites do not return counts, a dummy variable is used to receive the value that is then discarded
				response.listArticles =
					ShowTableSelectSeveralArticles_internal(
						user,
						request.conditionArticles,
						request.pagingArticles,
						request.orderArticles,
						sp,
						out dummy);

				response.Ok();
			}
			catch (GenioException ep)
            {
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                response.Error(e.Message);
            }

			return response;
		}

		/// <summary>
        /// Composite update data for a record of Warehouse and all its child records
        /// </summary>
		[Authorize]
        [HttpPut("Warehouse/UpdateComposite", Name = "WarehouseUpdateComposite")]
        [SwaggerOperation(Tags = new[] { "XRS - Warehouse" })]
		public ActionResult<WarehouseUpdateCompositeResponse> FormUpdateWarehouseComposite(WarehouseUpdateCompositeRequest request)
		{
			var response = new WarehouseUpdateCompositeResponse();
            PersistentSupport? sp = null;
            bool stopOnError = request.stopOnError;

            try
            {
                User user = AuthService.ValidateAuthentication(HttpContext, modulo);

                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                if (request.recordWarehouse != null)
                {
                    StatusMessage result = FormUpdateWarehouse_internal(user, request.recordWarehouse, sp);
                    response.recordWarehouse = RESTGenio.Response.FromStatus(result);
                    if (response.recordWarehouse.status == RESTStatus.Error && stopOnError)
                        throw new Exception(result.Message);
				}


				var responseTempArticles =
					WarehouseArticlesListUpdate_internal(
						user,
						sp,
						request.updateRecordsArticles,
						request.insertRecordsArticles,
						request.deleteRecordsArticles,
						stopOnError);

				response.updateArticles = responseTempArticles.update;
				response.insertArticles = responseTempArticles.insert;
				response.deleteArticles = responseTempArticles.delete;

                sp.closeTransaction();

                response.Ok();
            }
            catch (GenioException ep)
            {
                sp?.rollbackTransaction();
                response.Error(ep.UserMessage);
            }
            catch (Exception e)
            {
                sp?.rollbackTransaction();
                response.Error(e.Message);
            }

			return response;
		}

		// Implementation of manual methods
		
    }
}
