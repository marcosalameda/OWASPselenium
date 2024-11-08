using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers.Table.Properties
{
    public class AjaxRequest
    {
        public string requestsLink { get; set; }
        public string updateContainerId { get; set; }

        public AjaxRequest(string link, string id)
        {
            this.requestsLink = link;
            this.updateContainerId = id;
        }
    }
}