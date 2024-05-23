using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using CSGenio.reporting;

namespace GenioMVC
{
	/// <summary>
	/// HTML helpers for ReportViewerForMvc
	/// </summary>
	public static class ReportViewerHelperExtensions
	{
		/// <summary>
		/// Reports are created during the MVC rendering phase, but this only renders the IFrame where the report viewer will live.
		/// This means we need to keep the report parametrization in memory so that when the aspx page inside the iframe is called
		///  we can recover this report parametrization.
		/// A unique identifier is generated per report and assigned to the iframe src so that the aspx can recover the correct report.
		/// To limit undue data acess the report is removed from memory as soon as its requested.
		/// This MUST be viewed as a temporary solution. Not only it lacks an invalidation timer for memeorized reports leading to leaks,
		///  it also limits the ability to fully load balance web servers, because this memory is local to this process only.
		///
		/// This solution is a workaround of the even worse solution of a single static variable used in the Github project:
		/// https://github.com/dev4s/ReportViewerForMvc
		/// that made it unusable in production due to concurrency issues.
		/// </summary>
		private static ConcurrentDictionary<string, ReportViewer> active_viewers = new ConcurrentDictionary<string, ReportViewer>();

		/// <summary>
		/// Pushes a report into memory
		/// </summary>
		/// <param name="id">The unique id of the report call</param>
		/// <param name="viewer">The report to memorize</param>
		public static void PushReport(string id, ReportViewer viewer)
		{
			active_viewers.TryAdd(id, viewer);
		}

		/// <summary>
		/// Retrieves a report from memory
		/// </summary>
		/// <param name="id">The id of the report to retrieve</param>
		/// <returns>The report in case we found it</returns>
		public static ReportViewer PopReport(string id)
		{
			ReportViewer res;
			active_viewers.TryRemove(id, out res);
			return res;
		}

		/// <summary>
		/// Returns an HTML iframe that renders an ASP.NET ReportViewer control.
		/// </summary>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="reportViewer">The object containing the ReportViewer control properties.</param>
		/// <returns>An HTML iframe that sets its heigh and width based on the content of the report.</returns>
		public static HtmlString ReportViewer(this HtmlHelper helper, ReportViewer reportViewer)
		{
			return ReportViewer(helper, reportViewer, null);
		}

		/// <summary>
		/// Returns an HTML iframe that renders an ASP.NET ReportViewer control.
		/// </summary>
		/// <param name="helper">The HTML helper instance that this method extends.</param>
		/// <param name="reportViewer">The object containing the ReportViewer control properties.</param>
		/// <param name="htmlAttributes">The object containing the HTML attributes of the iframe.</param>
		/// <returns>An HTML iframe with the specified attributes that sets its heigh and width based on the content of the report.</returns>
		public static HtmlString ReportViewer(this HtmlHelper helper, ReportViewer reportViewer, object htmlAttributes)
		{
			if (reportViewer == null)
			{
				throw new ArgumentNullException("reportViewer", "Value cannot be null.");
			}

			string id = "r" + Guid.NewGuid().ToString();
			PushReport(id, reportViewer);
			return CreateIframe(htmlAttributes, id);
		}

		private static HtmlString CreateIframe(object htmlAttributes, string id)
		{
			IDictionary<string, object> parsedHtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
			string parsedIframe = CreateIframeTag(parsedHtmlAttributes, id);
			parsedIframe += ReceiveMessageScript();
			parsedIframe += SetIframeIdScript(id);

			return new HtmlString(parsedIframe);
		}

		private static string CreateIframeTag(IDictionary<string, object> htmlAttributes, string id)
		{
			string applicationPath = (HttpContext.Current.Request.ApplicationPath == "/") ? "" : HttpContext.Current.Request.ApplicationPath;

			TagBuilder tagBuilder = new TagBuilder("iframe");
			tagBuilder.GenerateId(id);
			tagBuilder.MergeAttribute("src", applicationPath + "/ReportViewerWebForm.aspx?id=" + id);
			tagBuilder.MergeAttributes(htmlAttributes, false);
			tagBuilder.SetInnerText("iframes not supported.");

			return tagBuilder.ToString();
		}

		private static string ReceiveMessageScript()
		{
			return @"<script>
var ReportViewerForMvc = ReportViewerForMvc || (new function () {
	var _iframeId = {};

	var resizeIframe = function (msg) {
		var height = msg.source.document.body.scrollHeight;
		var width = msg.source.document.body.scrollWidth;

		$(ReportViewerForMvc.getIframeId()).height(height);
		$(ReportViewerForMvc.getIframeId()).width(width);
	}

	var addEvent = function (element, eventName, eventHandler) {
		if (element.addEventListener) {
			element.addEventListener(eventName, eventHandler);
		} else if (element.attachEvent) {
			element.attachEvent('on' + eventName, eventHandler);
		}
	}

	this.setIframeId = function (value) {
		_iframeId = '#' + value;
	};

	this.getIframeId = function () {
		return _iframeId;
	};

	this.setAutoSize = function () {
		addEvent(window, 'message', resizeIframe);
	}
}());

ReportViewerForMvc.setAutoSize();
</script>";
		}

		private static string SetIframeIdScript(string id)
		{
			return "<script>ReportViewerForMvc.setIframeId('" + id + "');</script>";
		}
	}
}
