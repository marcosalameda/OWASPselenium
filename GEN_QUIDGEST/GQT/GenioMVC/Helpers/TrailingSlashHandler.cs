using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenioMVC.Helpers
{
	/// <summary>
	/// TrailingSlashRouteHandler class
	/// </summary>
	/// <seealso cref="System.Web.Mvc.MvcRouteHandler" />
	public class TrailingSlashRouteHandler : MvcRouteHandler
	{
		/// <summary>
		/// Returns the HTTP handler by using the specified HTTP context.
		/// </summary>
		/// <param name="requestContext">The request context.</param>
		/// <returns>The HTTP handler by using the specified HTTP context.</returns>
		protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			return new TrailingSlashHandler(requestContext);
		}
	}

	/// <summary>
	/// TrailingSlashHandler class
	/// </summary>
	/// <seealso cref="System.Web.Mvc.MvcHandler" />
	public class TrailingSlashHandler : MvcHandler
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TrailingSlashHandler"/> class.
		/// </summary>
		/// <param name="requestContext">The request context.</param>
		public TrailingSlashHandler(RequestContext requestContext) : base(requestContext) { }

		/// <summary>
		/// Called by ASP.NET to begin asynchronous request processing.
		/// </summary>
		/// <param name="httpContext">The HTTP context.</param>
		/// <param name="callback">The callback.</param>
		/// <param name="state">The state.</param>
		/// <returns>The status of the asynchronous operation</returns>
		protected override IAsyncResult BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, object state)
		{
			string absolutePath = httpContext.Request.Url.AbsolutePath;

			if (!absolutePath.EndsWith("/"))
			{
				httpContext.Response.StatusCode = 301;
				httpContext.Response.AddHeader("Location", absolutePath + "/");
			}

			return base.BeginProcessRequest(httpContext, callback, state);
		}
	}
}
