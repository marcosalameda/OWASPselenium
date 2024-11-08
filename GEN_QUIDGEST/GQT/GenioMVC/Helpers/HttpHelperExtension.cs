using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
    public static class HttpHelperExtension
    {
        public static string getPath(HttpRequestBase helper) {
            return helper.Url.GetLeftPart(UriPartial.Path);   
        }

        public static string addQueryAndReturnURL(HttpRequestBase helper, string key, string query)
        {
            var q = helper.Url.Query;
            Dictionary<string, string> queryString = new Dictionary<string, string>();
            if (q.Length > 0 && q[0] == '?')
            {
                q = q.Substring(1);
                string[] querys = q.Split('&');
                foreach (var qs in querys)
                {
                    string[] args = qs.Split('=');
                    if ((args[0] == "area_s" || args[0].EndsWith("_dt")) && queryString.ContainsKey(args[0]))
                    {
                        var value = queryString[args[0]];
                        value += "," + args[1];
                        queryString.Remove(args[0]);
                        queryString.Add(args[0], value);

                    }
                    else
                        queryString.Add(args[0], args[1]);
                }
            }
            string encodedQuery = HttpUtility.UrlPathEncode(query); 
            if (queryString.ContainsKey(key))
            {
                if (queryString[key] == encodedQuery)
                {
                    //same query... so remove
                    queryString.Remove(key);
                    if(queryString.Count == 0 ) 
                        return getPath(helper);
                }
                else
                    //value for query
                    queryString[key] = query;
            }
            else
                //new query
                queryString.Add(key, query);

            return getPathQuery(helper, queryString);
        }

        private static string getPathQuery(HttpRequestBase helper, Dictionary<string, string> queryString)
        {
            string url = getPath(helper) + "?";
            int count = 0;
            foreach (var pair in queryString)
            {
                count++;
                url += pair.Key + "=" + pair.Value;
                if (count != queryString.Count)
                    url += "&";

            }
            return url;
        }
    }
}