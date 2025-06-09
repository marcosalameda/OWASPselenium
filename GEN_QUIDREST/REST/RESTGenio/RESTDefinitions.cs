using CSGenio.framework;
using System.ComponentModel.DataAnnotations;

namespace RESTGenio
{

    public enum RESTStatus
    {
        /// <summary>
        /// The request was processed correctly
        /// </summary>
        Ok,
        /// <summary>
        /// An unspecified error occurred while processing the order
        /// </summary>
        Error,
        /// <summary>
        /// The request was processed correctly and there are more new records on the next page (for listings only)
        /// </summary>
        OkMoreNext,
        /// <summary>
        /// The request was processed correctly and there are more new records on the previous page (for listings only)
        /// </summary>
        OkMoreBefore,
        /// <summary>
        /// The request was processed correctly and there are more new records on the previous and next pages (for listings only)
        /// </summary>
        OkMoreBoth,
        /// <summary>
        /// Startup
        /// </summary>
        Init,
        /// <summary>
        /// Notice
        /// </summary>
        Warning,
        /// <summary>
        /// The request was not processed correctly and a warning was issued
        /// </summary>
        ErrorWarning,
        /// <summary>
        /// The request was processed correctly but a warning was issued
        /// </summary>
        OkWarning,
        /// <summary>
        /// The request was not processed correctly because it exceeded the processing time
        /// </summary>
        TimeOut,
        /// <summary>
        /// The request was rejected
        /// </summary>
        Reject,
        /// <summary>
        /// The request was not processed correctly due to failure to access the data
        /// </summary>
        DataAcessError
    }


    /// <summary>
    /// Response state - all responses from all requests have these attributes
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Order Processing Status
        /// </summary>
        /// <example>OK</example>
        public RESTStatus status { get; set; }

        /// <summary>
        /// Order processing return message
        /// </summary>
        /// <example>Operation successfully performed</example>
        public string? message { get; set; }
		
        /// <summary>
        /// Converts a StatusMessage to Response format
        /// </summary>
        /// <param name="msg">status message</param>
        /// <returns>Response</returns>
        public static Response FromStatus(StatusMessage msg)
        {
            var resp = new Response();
            resp.SetStatus(msg);
            return resp;
        }

        /// <summary>
        /// Sets the response according to a StatusMessage
        /// </summary>
        /// <param name="msg">status message</param>
        public void SetStatus(StatusMessage msg)
        {
            if (msg.Status == Status.W || msg.Status == Status.EW)
                status = RESTStatus.Warning;
            else if (msg.Status == Status.E)
                status = RESTStatus.Error;
            else
                status = RESTStatus.Ok;
            message = msg.Message;
        }

        /// <summary>
        /// Sets the response as ok
        /// </summary>
        public void Ok() {
            status = RESTStatus.Ok;
            message = "ok";
        }

        /// <summary>
        /// Sets the response as error
        /// </summary>
        /// <param name="err">The error message</param>
        public void Error(string err) { 
            status = RESTStatus.Error;
            message = err;
        }
    }

    /// <summary>
    /// Insert response state
    /// </summary>
    public class ResponseInsert : Response
    {
        /// <summary>
        /// Primary key for the new record
        /// </summary>
        /// <example>1</example>
        public string? primaryKey { get; set; }
		
		/// <summary>
        /// Converts a StatusMessage to ResponseInsert format
        /// </summary>
        /// <param name="msg">status message</param>
        /// <returns>Response</returns>
        public static ResponseInsert FromStatus(StatusMensagemInserir msg)
        {
            var resp = new ResponseInsert();
            resp.SetStatus(msg);
			resp.primaryKey = msg.PrimaryKey;
            return resp;
        }
    }

    /// <summary>
    /// Common attributes for requests
    /// </summary>
    public class Request
    {
    }

    /// <summary>
    /// Request that only uses one primaryKey
    /// </summary>
    public class SelectPrimaryKeyRequest : Request
    {
        /// <summary>
        /// Primary registry key to obtain
        /// </summary>
        /// <example>1</example>
		[Required]
        public string primaryKey { get; set; } = string.Empty;
    }

    /// <summary>
    /// Request that uses filters
    /// </summary>
    public class ListRequest : Request
    {
        /// <summary>
        /// Filter applied to records
        /// </summary>
        public LogicalCondition? condition { get; set; }

        /// <summary>
        /// Pagination data
        /// </summary>
        public Paging? paging { get; set; }

        /// <summary>
        /// Sorting data
        /// </summary>
        public Order? order { get; set; }
    }
	
    /// <summary>
    /// Response with the operation results of insert/change/delete in child records
    /// </summary>
    public class ListUpdateResponse : Response
    {
        /// <summary>
        /// Changes results
        /// </summary>
        public List<Response>? update { get; set; }

        /// <summary>
        /// Insert results with primary keys
        /// </summary>
        public List<ResponseInsert>? insert { get; set; }

        /// <summary>
        /// Delete results
        /// </summary>
        public List<Response>? delete { get; set; }
    }


    /// <summary>
    /// Pagination data
    /// </summary>
    public class Paging
    {
        /// <summary>
        /// Get record count
        /// </summary>
        /// <example>False</example>
        public bool getCount { get; set; }
        /// <summary>
        /// Number of records
        /// </summary>
        public int numRecords { get; set; }

        // pagination, how to do it
        // for now is an integer with the page number
        /// <summary>
        /// Page number
        /// </summary>
        public int page { get; set; }

    }
    /// <summary>
    /// Sorting data for listing requests
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Listing sort set
        /// </summary>
        [Required]
        public List<OrderBy> orders { get; set; } = new List<OrderBy>();
    }

    /// <summary>
    /// Sorting type
    /// </summary>
    public enum OrderByDirection
    {
        /// <summary>
        /// Ascendant
        /// </summary>
        ASC,
        /// <summary>
        /// Descendant
        /// </summary>
        DESC
    }

    /// <summary>
    /// Sorting a specific field
    /// </summary>
    public class OrderBy
    {
        /// <summary>
        /// Field to sort
        /// </summary>
		/// <example>fieldName</example>
		[Required]
        public string Field { get; set; } = string.Empty;
        /// <summary>
        /// Sorting type
        /// </summary>
        /// <example>ASC</example>
        public OrderByDirection Direction { get; set; } = OrderByDirection.ASC;
    }
}