using System.ComponentModel.DataAnnotations;

namespace RESTGenio.XRS
{

    /// <summary>
    /// Record of query Warehouses
    /// </summary>
    public class ListRecordWarehouses
    {
        /// <summary>
        /// 
        /// </summary>
        public string? primaryKey { get; set; }
        /// <summary>
        /// Warehouse
        /// </summary>
        public string? Warehouse { get; set; }
        /// <summary>
        /// Acronym
        /// </summary>
        public string? Acronym { get; set; }
        /// <summary>
        /// Activity
        /// </summary>
        public ArrayActividade? Activity { get; set; }
        /// <summary>
        /// Show Record
        /// </summary>
        public string? ShowRecord { get; set; }
        /// <summary>
        /// Number of employees
        /// </summary>
        public string? NumberOfEmployees { get; set; }
    }

    /// <summary>
    /// Response from list of Warehouses
    /// </summary>
    public class ListResponseWarehouses : Response
    {
        /// <summary>
        /// Number of records in the listing (only filled in if requested)
        /// </summary>
        public int numRecords { get; set; }

        /// <summary>
        /// List of records
        /// </summary>
        public List<ListRecordWarehouses>? Data { get; set; }
    }

    /// <summary>
    /// Record of Articles
    /// </summary>
    public class FormRecordArticles
    {
        /// <summary>
        /// 
        /// </summary>
		[MaxLength(36)]
        public string? primaryKey { get; set; }
        /// <summary>
        /// Global article
        /// </summary>
		[MaxLength(85)]
        public string? GlobalArticle { get; set; }
        /// <summary>
        /// Warehouse
        /// </summary>
		[MaxLength(85)]
        public string? Warehouse { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public ArrayArticleTypes? Type { get; set; }
        /// <summary>
        /// Article
        /// </summary>
		[MaxLength(85)]
        public string? Article { get; set; }
        /// <summary>
        /// Code
        /// </summary>
		[MaxLength(15)]
        public string? Code { get; set; }
        /// <summary>
        /// Entries
        /// </summary>
        public string? Entries { get; set; }
        /// <summary>
        /// Outputs
        /// </summary>
        public string? Outputs { get; set; }
        /// <summary>
        /// Stocks
        /// </summary>
        public string? Stocks { get; set; }
        /// <summary>
        /// Image
        /// </summary>
		[MaxLength(3)]
        public string? Image { get; set; }
        /// <summary>
        /// Ticket for Image binary access
        /// </summary>
        public string? Image_Ticket { get; set; }
        /// <summary>
        /// Categorization
        /// </summary>
		[MaxLength(85)]
        public string? Categorization { get; set; }
        /// <summary>
        /// In use
        /// </summary>
        public string? InUse { get; set; }
        /// <summary>
        /// Availability
        /// </summary>
        public ArrayAvailability? Availability { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        public string? Date { get; set; }
        /// <summary>
        /// Specifications
        /// </summary>
		[MaxLength(50)]
        public string? Specifications { get; set; }
        /// <summary>
        /// Ticket for Specifications binary access
        /// </summary>
        public string? Specifications_Ticket { get; set; }
        /// <summary>
        /// >GLOBAL ARTICLE
        /// </summary>
		[MaxLength(36)]
        public string? Codgitem { get; set; }
        /// <summary>
        /// >WAREHOUSE
        /// </summary>
		[MaxLength(36)]
        public string? Codwareh { get; set; }
    }

    /// <summary>
    /// Request that only uses one record with the data to be entered
    /// </summary>
    public class ArticlesFormRequest : Request
    {
        /// <summary>
        /// Record of Articles
        /// </summary>
        public FormRecordArticles? record { get; set; }
    }




    /// <summary>
    /// Response with the data of a record of Articles
    /// </summary>
    public class ArticlesFormResponse : Response
    {
        /// <summary>
        /// Record with all fields of Articles
        /// </summary>
        public FormRecordArticles? record { get; set; }
    }

    /// <summary>
    /// Record of Warehouse
    /// </summary>
    public class FormRecordWarehouse
    {
        /// <summary>
        /// 
        /// </summary>
		[MaxLength(36)]
        public string? primaryKey { get; set; }
        /// <summary>
        /// Warehouse
        /// </summary>
		[MaxLength(85)]
        public string? Warehouse { get; set; }
        /// <summary>
        /// Acronym
        /// </summary>
		[MaxLength(10)]
        public string? Acronym { get; set; }
        /// <summary>
        /// Activity
        /// </summary>
        public ArrayActividade? Activity { get; set; }
        /// <summary>
        /// Show Record
        /// </summary>
        public string? ShowRecord { get; set; }
        /// <summary>
        /// Number of employees
        /// </summary>
        public string? NumberOfEmployees { get; set; }
    }

    /// <summary>
    /// Request that only uses one record with the data to be entered
    /// </summary>
    public class WarehouseFormRequest : Request
    {
        /// <summary>
        /// Record of Warehouse
        /// </summary>
        public FormRecordWarehouse? record { get; set; }
    }

    /// <summary>
    /// Request with composite input data type used to obtain a record of Warehouse and its children
    /// </summary>
    public class WarehouseArticlesListUpdateRequest : Request
    {
        /// <summary>
        /// Whether the operation should be aborted if an error occurs
        /// </summary>  
        public bool stopOnError { get; set; }

        /// <summary>
        /// List of records to change
        /// </summary>
        public List<FormRecordArticles>? updateRecords { get; set; }

        /// <summary>
        /// List of records to insert
        /// </summary>
        public List<FormRecordArticles>? insertRecords { get; set; }

        /// <summary>
        /// List of primary keys for records to be deleted
        /// </summary>
        public List<string>? deleteRecords { get; set; }		
    }

    /// <summary>
    /// Request with composite input data type used to update a record of Warehouse and its children
    /// </summary>
    public class WarehouseUpdateCompositeRequest : Request
    {
        /// <summary>
        /// Whether the operation should be aborted if an error occurs
        /// </summary>     
        public bool stopOnError { get; set; }

        /// <summary>
        /// Record of Warehouse
        /// </summary>
        public FormRecordWarehouse? recordWarehouse { get; set; }
        
        /// <summary>
        /// Children of Articles to update
        /// </summary>
        public List<FormRecordArticles>? updateRecordsArticles { get; set; }

        /// <summary>
        /// Children of Articles to insert
        /// </summary>
        public List<FormRecordArticles>? insertRecordsArticles { get; set; }

        /// <summary>
        /// Children of Articles to delete
        /// </summary>
        public List<string>? deleteRecordsArticles { get; set; }
    }

    /// <summary>
    /// Request with composite input data type used to select a record of Warehouse and its children
    /// </summary>
    public class WarehouseFormCompositeRequest : Request
    {
        /// <summary>
        /// Primary key
        /// </summary>
		[Required]
        public string primaryKey { get; set; } = string.Empty;

        /// <summary>
        /// Listing conditions for children Articles
        /// </summary>
        public LogicalCondition? conditionArticles { get; set; }

        /// <summary>
        /// Listing pagination for children Articles
        /// </summary>
        public Paging? pagingArticles { get; set; }

        /// <summary>
        /// Listing sorting for children Articles
        /// </summary>
        public Order? orderArticles { get; set; }
    }

    /// <summary>
    /// Response with the data of a record of Warehouse
    /// </summary>
    public class WarehouseFormResponse : Response
    {
        /// <summary>
        /// Record with all fields of Warehouse
        /// </summary>
        public FormRecordWarehouse? record { get; set; }
    }

    /// <summary>
    /// Record of Articles in record Warehouse
    /// </summary>
    public class WarehouseArticlesListRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public string? primaryKey { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public ArrayArticleTypes? Type { get; set; }
        /// <summary>
        /// Article
        /// </summary>
        public string? Article { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Entries
        /// </summary>
        public string? Entries { get; set; }
        /// <summary>
        /// Outputs
        /// </summary>
        public string? Outputs { get; set; }
        /// <summary>
        /// Stocks
        /// </summary>
        public string? Stocks { get; set; }
        /// <summary>
        /// Image
        /// </summary>
        public string? Image { get; set; }
        /// <summary>
        /// Ticket for Image binary access
        /// </summary>
        public string? Image_Ticket { get; set; }
        /// <summary>
        /// Categorization
        /// </summary>
        public string? Categorization { get; set; }
        /// <summary>
        /// In use
        /// </summary>
        public string? InUse { get; set; }
        /// <summary>
        /// Availability
        /// </summary>
        public ArrayAvailability? Availability { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        public string? Date { get; set; }
        /// <summary>
        /// >WAREHOUSE
        /// </summary>
        public string? Codwareh { get; set; }
    }

    /// <summary>
    /// Response with data from children Articles list of Warehouse
    /// </summary>
    public class WarehouseArticlesListResponse : Response
    {
        /// <summary>
        /// Number of records in the listing (only filled in if requested)
        /// </summary>
        public int numRecords { get; set; }

        /// <summary>
        /// List of Articles records
        /// </summary>
        public List<WarehouseArticlesListRecord>? Data { get; set; }    
    }
    /// <summary>
    /// Response of record Warehouse including all children
    /// </summary>
    public class WarehouseFormCompositeResponse : Response
    {
        /// <summary>
        /// Record of Warehouse
        /// </summary>
        public FormRecordWarehouse? recordWarehouse { get; set; }

        /// <summary>
        /// List of records from child Articles
        /// </summary>
        public List<WarehouseArticlesListRecord>? listArticles { get; set; }
    }
    /// <summary>
    /// Response with the result set of composite operation on Warehouse and all its children records
    /// </summary>
    public class WarehouseUpdateCompositeResponse : Response
    {
        /// <summary>
        /// Result of the change in record Warehouse
        /// </summary>
        public Response? recordWarehouse { get; set; }
    
        /// <summary>
        /// Change results for child Articles
        /// </summary>
        public List<Response>? updateArticles { get; set; }

        /// <summary>
        /// Insert results for child Articles
        /// </summary>
        public List<ResponseInsert>? insertArticles { get; set; }

        /// <summary>
        /// Delete results for child Articles
        /// </summary>
        public List<Response>? deleteArticles { get; set; }
    }



    // Aditional data types for manual routines


}
