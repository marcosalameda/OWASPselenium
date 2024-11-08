using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Attributes
{
	/// <summary>
	/// Prevents caching the requests to the methods or controllers, protected by this attribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public sealed class NoCacheAttribute : FilterAttribute, IResultFilter
	{
		public void OnResultExecuting(ResultExecutingContext filterContext) { }

		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
			var cache = filterContext.HttpContext.Response.Cache;
			cache.SetCacheability(HttpCacheability.NoCache);
			cache.SetRevalidation(HttpCacheRevalidation.ProxyCaches);
			cache.SetExpires(DateTime.Now.AddYears(-5));
			cache.AppendCacheExtension("private");
			cache.AppendCacheExtension("no-cache=Set-Cookie");
			cache.SetProxyMaxAge(TimeSpan.Zero);
			cache.SetNoStore();
		}
	}
}
