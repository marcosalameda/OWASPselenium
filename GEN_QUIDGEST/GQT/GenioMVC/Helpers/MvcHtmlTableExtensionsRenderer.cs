using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Routing;
using System.Collections.Specialized;
using System.Dynamic;
using RB = Microsoft.CSharp.RuntimeBinder;
using System.Text;
using System.Web.Helpers;
using System.Globalization;
using System.Web.WebPages;
using GenioMVC.Helpers;

namespace System.Web.Mvc.Html
{
    public class MvcTableRenderer
    {
        public const string ASCENDING_ORDER = "ASC";
        public const string DESCENDING_ORDER = "DESC";

        public const string ASC_VISUALIZER_HELPER = " ▲";
        public const string DESC_VISUALIZER_HELPER = " ▼";

        public const string SORT_QUERYSTRING = "sort";
        public const string SORT_ORDER_QUERYSTRING = "sortDir";
        public const string PAGE_NUMBER_QUERYSTRING = "page";

        private string GetSortUrl(string containerDiv, string column)
        {
            return "changeTableSort('" + containerDiv + "', '" + column +"')";
        }

        private string GetLinkHtml(string jsAction, string text, string direction, string divId)
        {
            TagBuilder linkTag = new TagBuilder("span");
            linkTag.AddCssClass("btn-link");
            linkTag.MergeAttribute("onclick", jsAction);
            linkTag.MergeAttribute("data-divid", divId);
            if (direction != null)
                text += direction == ASCENDING_ORDER ? ASC_VISUALIZER_HELPER : DESC_VISUALIZER_HELPER;
            linkTag.SetInnerText(text);
            return linkTag.ToString();
        }

        private string GetSortLinkHtml(string column, SortInfo chosen, string text = null, AjaxRequest ar = null, string partialView = null)
        {
            if (String.IsNullOrEmpty(text))
            {
                text = column;
            }
            NameValueCollection qs = new HttpContextWrapper(System.Web.HttpContext.Current).Request.QueryString;
            string direction = null;
            if (column == chosen.Column)
                direction = chosen.Direction;
            return GetLinkHtml(GetSortUrl(partialView, column), text, direction, ar.DivId);
        }

        private HelperResult Format(Func<dynamic, object> format, dynamic arg)
        {
            var result = format(arg);
            return new HelperResult(tw =>
            {
                var helper = result as HelperResult;
                if (helper != null)
                {
                    helper.WriteTo(tw);
                    return;
                }
                IHtmlString htmlString = result as IHtmlString;
                if (htmlString != null)
                {
                    tw.Write(htmlString);
                    return;
                }
                if (result != null)
                {
                    tw.Write(HttpUtility.HtmlEncode(result));
                }
            });
        }

        private string GetPageUrl(string containerDiv, int page)
        {
            return "changeTablePagination('" + containerDiv + "', '" + page + "')";
        }

        private string GetPageLinkHtml(int pageIndex, string text = null, AjaxRequest ar = null, string partialView = null, string tab = null, bool tableFilters = false)
        {
		    pageIndex += 1;
            if (String.IsNullOrEmpty(text))
            {
                text = pageIndex.ToString(CultureInfo.CurrentCulture);
            }
			string link = GetLinkHtml(GetPageUrl(partialView, pageIndex), text, null, ar.DivId);
            TagBuilder li = new TagBuilder("li");
            li.InnerHtml = link;
            return li.ToString();
        }

        private bool ModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }

        private HelperResult Pager<TModel>(
          TableBuilder<TModel> t,
          WebGridPagerModes mode = WebGridPagerModes.NextPrevious | WebGridPagerModes.Numeric,
          string firstText = null,
          string previousText = null,
          string nextText = null,
          string lastText = null,
          int numericLinksCount = 5) where TModel : class
        {
            int currentPage = t.GetPageInfo.PageNumber - 1;
            double totalRows = t.GetPageInfo.TotalRows;
            int totalPages = (int)Math.Ceiling(totalRows / t.GetPageInfo.ItemsPerPage);
            int lastPage = totalPages - 1;

            return new HelperResult(tw =>
            {
                if (ModeEnabled(mode, WebGridPagerModes.FirstLast) && currentPage > 1)
                {
                    if (String.IsNullOrEmpty(firstText))
                    {
                        firstText = "<<";
                    }
                    tw.Write(GetPageLinkHtml(0, firstText, t.GetAjaxRequest, t.PartialView, t.GetTab, t.UseTableFilters));
                    tw.Write(" ");
                }
                if (ModeEnabled(mode, WebGridPagerModes.NextPrevious) && currentPage > 0)
                {
                    if (String.IsNullOrEmpty(previousText))
                    {
                        previousText = "<";
                    }
                    tw.Write(GetPageLinkHtml(currentPage - 1, previousText, t.GetAjaxRequest, t.PartialView, t.GetTab, t.UseTableFilters));
                    tw.Write(" ");
                }

                if (ModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
                {
                    int last = currentPage + (numericLinksCount / 2);
                    int first = last - numericLinksCount + 1;
                    if (last > lastPage)
                    {
                        first -= last - lastPage;
                        last = lastPage;
                    }
                    if (first < 0)
                    {
                        last = Math.Min(last + (0 - first), lastPage);
                        first = 0;
                    }
                    for (int i = first; i <= last; i++)
                    {
                        if (i == currentPage)
                        {
                            TagBuilder li = new TagBuilder("li");
                            TagBuilder a = new TagBuilder("a");
                            a.AddCssClass("disabled");
                            a.SetInnerText((i + 1).ToString(CultureInfo.InvariantCulture));
                            li.InnerHtml = a.ToString();
                            tw.Write(li.ToString());
                        }
                        else
                        {
                            tw.Write(GetPageLinkHtml(i, null, t.GetAjaxRequest, t.PartialView, t.GetTab, t.UseTableFilters));
                        }
                        tw.Write(" ");
                    }
                }

                if (ModeEnabled(mode, WebGridPagerModes.NextPrevious) && (currentPage < lastPage))
                {
                    if (String.IsNullOrEmpty(nextText))
                    {
                        nextText = ">";
                    }
                    tw.Write(GetPageLinkHtml(currentPage + 1, nextText, t.GetAjaxRequest, t.PartialView, t.GetTab, t.UseTableFilters));
                    tw.Write(" ");
                }
                if (ModeEnabled(mode, WebGridPagerModes.FirstLast) && (currentPage < lastPage - 1))
                {
                    if (String.IsNullOrEmpty(lastText))
                    {
                        lastText = ">>";
                    }
                    tw.Write(GetPageLinkHtml(lastPage, lastText, t.GetAjaxRequest, t.PartialView, t.GetTab, t.UseTableFilters));
                }
            });
        }

        internal string Footer<TModel>(TableBuilder<TModel> t) where TModel : class
        {
            string footerActions = "";

            //Actions
            if (t.IsTableEditable && t.GetPermissions.CanInsert && !String.IsNullOrEmpty(t.GetHelpForm))
            {
				if(t.HasAjaxActions)
					footerActions += System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                                  new System.Web.Mvc.AjaxHelper(t.GetHtmlHelper.ViewContext, t.GetHtmlHelper.ViewDataContainer, t.GetHtmlHelper.RouteCollection),
                                  GenioMVC.Resources.Resources.INSERIR43365,
                                  t.GetHelpForm + "_New",
                                  t.GetController,
                                  new { nestedForm = "true" },
                                  new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = t.GetAjaxOption("updateTarget") as string },
                                  new { @class = "b-icon-text b-icon-text--primary", @onclick = "onNavigation(event, this, 'NEW')", qbutton = "insert" }
                                  ).ToString();
				else
					footerActions += t.GetHtmlHelper.ActionLink(GenioMVC.Resources.Resources.INSERIR43365, t.GetHelpForm + "_New", typeof(TModel).Name, null, new { @class = "b-icon-text b-icon-text--primary", @onclick = "onNavigation(event, this, 'NEW')", qbutton = "insert" }).ToString();
            }

            //pagination
            double totalRows = t.GetPageInfo.TotalRows;
            int totalColumns = t.TableColumns.Count(x => x.ColumnVisible) + 1;
            int totalPages = (int)Math.Ceiling(totalRows / t.GetPageInfo.ItemsPerPage);
            if (t.HasPagination)
            {
                        
				if (totalPages > 1)
				{
					Func<dynamic, object> footer = footer = item => Pager(t);
					TagBuilder div = new TagBuilder("div");
					div.Attributes.Add("elem-identifier", "Pagination");
					div.AddCssClass("pagination pull-right");
					TagBuilder ul = new TagBuilder("ul");
					ul.InnerHtml += Format(footer, null).ToString();
					div.InnerHtml += ul;

					footerActions += div.ToString();
				}
			}

            TagBuilder tfoot = new TagBuilder("tfoot");
            if (footerActions.Length > 0)
            {
                TagBuilder tr = new TagBuilder("tr");
                TagBuilder td = new TagBuilder("td");
                td.MergeAttribute("colspan", totalColumns.ToString(CultureInfo.InvariantCulture));
                td.InnerHtml = footerActions;
                tr.InnerHtml = td.ToString();
                tfoot.InnerHtml = tr.ToString();
            }

            return tfoot.ToString();
        }

        /// <summary>
        /// Convert the TableBuilder to HTML.
        /// </summary>
        public MvcHtmlString ToHtml<TModel>(TableBuilder<TModel> t) where TModel : class
        {
            TagBuilder table = new TagBuilder("table");
            table.Attributes.Add("class", "table table-striped table-condensed");
            table.Attributes.Add("id", t.GetTableId);
			
            string ajax_action = "";

            TagBuilder tr = Header<TModel>(t, table);

            table.InnerHtml += Footer(t);


            TagBuilder tbody = new TagBuilder("tbody");
            IEnumerable<TModel> data = t.GetData;
            int row = 0;
            if (data != null)
            {
                if (t.HasAjaxActions)
                {
                    ajax_action = t.GetHelpForm.Equals("Home") ? "Index" : t.GetHelpForm;
                }

                foreach (TModel model in data)
                {
                    PropertyInfo key_property = model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
                    RouteValueDictionary dictionary = new RouteValueDictionary();

                    if (t.HasCustomAction)
                        dictionary.Add(key_property.Name, t.GetKey.Evaluate(model));
                    else
                        dictionary.Add("id", t.GetKey.Evaluate(model));

                    tr = new TagBuilder("tr");
                    tr.Attributes.Add("data-key", t.GetKey.Evaluate(model));
                    
                    int totalSizeTable = TotalSize(t.TableColumns);
                    if (t.IsChecklist)
                    {
                        TagBuilder input = new TagBuilder("input");
                        input.Attributes.Add("type", "checkbox");
                        input.Attributes.Add("value", t.GetKey.Evaluate(model));
                        input.Attributes.Add("name", t.ChecklistName);
                        if (t.SelectedRows.Contains(t.GetKey.Evaluate(model)))
                            input.Attributes.Add("checked", "");
                        TagBuilder td = new TagBuilder("td");
                        td.InnerHtml += input;
                        tr.InnerHtml += td;
                    }
                    foreach (ITableColumnInternal<TModel> tc in t.TableColumns)
                    {
                        if (tc.ColumnVisible)
                        {
                            TagBuilder td = new TagBuilder("td");
                            String style = "";
                            if (totalSizeTable > 0)
                                style += "width:"+(((double)tc.ColumnSize / (double)totalSizeTable)*100.0).ToString().Replace(",",".") + "%;";
                            if (tc.TextCentered)
                                style += "text-align:center;";
                            if(!String.IsNullOrEmpty(style))
                                td.Attributes.Add("style", style);

                            var value = tc.Evaluate(model);
                            if (tc.ColumnType.Equals("SelectList") && !String.IsNullOrEmpty(value))
                            {
                                var values = value.Split('_');
                                value = values[1];
                                td.AddCssClass(tc.ColumnField + "_" + values[0].Replace('.', '-'));
                            }

							if (tc.IsDocument)
                            {
                                TagBuilder a = new TagBuilder("a");
                                a.Attributes.Add("href", value);
                                a.Attributes.Add("rel", "tooltip");
                                a.Attributes.Add("title", GenioMVC.Resources.Resources.DESCARREGAR58418);
                                TagBuilder i = new TagBuilder("i");
                                if (String.IsNullOrEmpty(value))
                                {
                                    i.AddCssClass("glyphicons glyphicons-remove e-icon");
                                    i.Attributes.Add("rel", "tooltip");
                                    i.Attributes.Add("title", GenioMVC.Resources.Resources.FICHEIRO_NAO_ENCONTR42952);
                                    td.InnerHtml += i;
                                }
                                else
                                {
                                    i.AddCssClass("icon-file");
                                    a.InnerHtml += i;
                                    td.InnerHtml += a;
                                }
                            }
							else if (tc.ColumnForm != null)
                            {
                                TagBuilder a = new TagBuilder("a");
                                var routeValues = new { id = tc.EvaluateKey(model), nav = t.Navigation.NavigationId, lvl = t.Navigation.CurrentLevel.Level };
                                a.Attributes.Add("data-href", (new UrlHelper(t.GetHtmlHelper.ViewContext.RequestContext)).Action(tc.ColumnForm, tc.ColumnArea, routeValues));
                                a.Attributes.Add("data-ispopup", tc.ColumnFormIsPopUp.ToString().ToLower());

                                if(tc.ColumnNewTab)
                                    a.Attributes.Add("target","_blank");

                                a.InnerHtml = value;
                                td.InnerHtml += a;
                            }
                            else
                                td.InnerHtml += value;

                            tr.InnerHtml += td;
                        }
                        else if (tc.ColumnField == "ValZzstate")
                        {
                            var value = tc.Evaluate(model);
                            if(value != "0")
							{
								tr.Attributes.Add("class", "dirty-row");
								tr.Attributes.Add("rel", "tooltip");
								tr.Attributes.Add("title", GenioMVC.Resources.Resources.ATENCAO__ESTA_FICHA_24725);
							}
                        }
                    }

					CreateActions<TModel>(t, ajax_action, tr, model, dictionary);
                    tbody.InnerHtml += tr;

                    row++;
                }
            }

            table.InnerHtml += tbody;

            TagBuilder main = DivWrapper<TModel>(t, table, row);

            return MvcHtmlString.Create(main.ToString(TagRenderMode.Normal));
        }
		
		internal TagBuilder DivWrapper<TModel>(TableBuilder<TModel> t, TagBuilder table, int row) where TModel : class
        {
            TagBuilder main = new TagBuilder("div");
            main.AddCssClass("table-container");
            if (row == 0)
            {
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("alert");
                div.AddCssClass("block");

                if (t.IsTableEditable && t.GetPermissions.CanInsert)
                {
                    if (t.HasAjaxActions)
                        div.InnerHtml += System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                                  new System.Web.Mvc.AjaxHelper(t.GetHtmlHelper.ViewContext, t.GetHtmlHelper.ViewDataContainer, t.GetHtmlHelper.RouteCollection),
                                  GenioMVC.Resources.Resources.INSERIR43365,



                                  t.GetHelpForm + "_New",
                                  t.GetController,
                                  new { nestedForm = "true" },
                                  new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = t.GetAjaxOption("updateTarget") as string },
                                  new { @class = "b-icon-text b-icon-text--primary", @onclick = "onNavigation(event, this, 'NEW')", qbutton = "insert" }
                                  ).ToString();
                    else

                        div.InnerHtml += t.GetHtmlHelper.ActionLink(GenioMVC.Resources.Resources.INSERIR43365, t.GetHelpForm + "_New", typeof(TModel).Name, null, new { @class = "b-icon-text b-icon-text--primary", @onclick = "onNavigation(event, this, 'NEW')", qbutton = "insert" }).ToString();
                }

                div.InnerHtml += " " + GenioMVC.Resources.Resources.ESTA_LISTA_ESTA_VAZI62240;
                main.InnerHtml += div;

            }
            else
            {
                main.InnerHtml += table;
                main.InnerHtml += CreateHiddenInputs(t);
            }
            return main;
        }

        private TagBuilder CreateHiddenInputs<TModel>(TableBuilder<TModel> t) where TModel: class
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("id", "table-inputs");

			if(t.HasPagination) {
				TagBuilder page = new TagBuilder("input");
				page.Attributes.Add("id", "p" + t.GetTableId);
				page.Attributes.Add("type", "hidden");
				page.Attributes.Add("value", t.GetPageInfo.PageNumber.ToString());
				div.InnerHtml += page;
			}
            if (t.GetSortInfo != null) {
                TagBuilder sort = new TagBuilder("input");
                sort.Attributes.Add("id", "s" + t.GetTableId);
                sort.Attributes.Add("type", "hidden");
                sort.Attributes.Add("value", t.GetSortInfo.Column);
                div.InnerHtml += sort;

                TagBuilder direction = new TagBuilder("input");
                direction.Attributes.Add("id", "d" + t.GetTableId);
                direction.Attributes.Add("type", "hidden");
                direction.Attributes.Add("value", t.GetSortInfo.Direction);
                div.InnerHtml += direction;
            }

            return div;
        }
		
		private void CreateActions<TModel>(TableBuilder<TModel> t, string ajax_action, TagBuilder tr, TModel model, RouteValueDictionary dictionary) where TModel : class
        {
            // Action buttons
            var rtValues = new { id = t.GetKey.Evaluate(model) };

            TagBuilder tdActions = new TagBuilder("td");

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("dropdown-menu");
            ul.AddCssClass("pull-right");

            bool hasActions = false;

            if (t.TableActions.Count > 0)
            {
                if (t.TableActions.Count == 1 && String.IsNullOrEmpty(t.GetHelpForm))
                {
                    TableAction<TModel> action = t.TableActions.First();
					TagBuilder a = MakeFollowUpLink<TModel>(t.GetHtmlHelper, action.Action, action.Controller, model, action.RouteValuesFun, action.Icon, action.IsBootstrapIcon, action.Title, action.IsRoutine, action.HtmlAttributes, true, keyvalue: rtValues.id);
                    tdActions.InnerHtml += a;
                }
                else
                {
                    foreach (TableAction<TModel> action in t.TableActions)
                    {
                        TagBuilder li = new TagBuilder("li");
                        li.InnerHtml += MakeFollowUpLink<TModel>(t.GetHtmlHelper, action.Action, action.Controller, model, action.RouteValuesFun, action.Icon, action.IsBootstrapIcon, action.Title, action.IsRoutine, action.HtmlAttributes, keyvalue: rtValues.id);
                        ul.InnerHtml += li;
                    }
                }
                hasActions = true;
            }
			
			TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("elem-identifier", "BtnGroup");
            div.AddCssClass("btn-group");

            bool hasFollowUp = true;

            // Followup link
			if (t.HasFollowUp)
            {
                TagBuilder followUp;

                if (t.AppendToPage)
                {                   
                    followUp = new TagBuilder("a");
                    followUp.Attributes.Add("id", rtValues.id);
                    followUp.Attributes.Add("href", "javascript:void(0)");
                    followUp.Attributes.Add("onclick", t.FollowUpAction+"('" + rtValues.id + "');");
                         
                    TagBuilder i = new TagBuilder("i");
                    i.AddCssClass("icon-play-circle");

                    followUp.InnerHtml = i.ToString();
                }
                else
                {
                    followUp = MakeDetailLink<TModel>(t.GetHtmlHelper, t.FollowUpAction, t.FollowUpController, model, t.FollowUpRouteValuesFun, null);
                }
                followUp.AddCssClass("btn");
                div.InnerHtml += followUp;
                hasFollowUp = true;
            }

			// Continuation form actions
            if (t.IsTableEditable && !String.IsNullOrEmpty(t.GetHelpForm))
            {
				// Edit Actions
                if (t.HasAjaxActions)
                {
                    IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
                    htmlAttributes.Add("class", "btn");
                    htmlAttributes.Add("qbutton", "edit");
                    if (t.HasCustomAction)
                        htmlAttributes.Add("style", "display:none");
                    dictionary.Add("nestedForm", "true");
                    tdActions.InnerHtml += System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
						new System.Web.Mvc.AjaxHelper(t.GetHtmlHelper.ViewContext, t.GetHtmlHelper.ViewDataContainer, t.GetHtmlHelper.RouteCollection),
						GenioMVC.Resources.Resources.CONSULTAR57388,
						t.GetHelpForm + "_Edit",
						t.GetController,
						dictionary,
						new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = t.GetAjaxOption("updateTarget") as string },
						htmlAttributes
                    ).ToString();
                }
                else
                {
                    if (t.GetPermissions.CanDelete)
                    {
                        TagBuilder li = new TagBuilder("li");
						TagBuilder deleteAction = MakeIconFormLink<TModel>(t.GetHtmlHelper, t.GetHelpForm + "_Delete", rtValues, "icon-trash", GenioMVC.Resources.Resources.APAGAR04097);
						deleteAction.Attributes.Add("onclick", "onNavigation(event, this, 'DELETE')");
                        deleteAction.Attributes.Add("qbutton", "delete");
                        li.InnerHtml += deleteAction;
                        ul.InnerHtml = li + ul.InnerHtml;
                        hasActions = true;
                    }
                    if (t.GetPermissions.CanEdit)
                    {
                        TagBuilder li = new TagBuilder("li");
						TagBuilder editAction = MakeIconFormLink<TModel>(t.GetHtmlHelper, t.GetHelpForm + "_Edit", rtValues, "icon-pencil", GenioMVC.Resources.Resources.EDITAR11616);
						editAction.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                        editAction.Attributes.Add("qbutton", "edit");
                        li.InnerHtml += editAction;
                        ul.InnerHtml = li + ul.InnerHtml;
                        hasActions = true;
                    }
					if (t.GetPermissions.CanDuplicate)
                    {
                        TagBuilder li = new TagBuilder("li");
						TagBuilder dupAction = MakeIconFormLink<TModel>(t.GetHtmlHelper, t.GetHelpForm + "_Duplicate", rtValues, "icon-retweet", GenioMVC.Resources.Resources.DUPLICAR09748);
						dupAction.Attributes.Add("onclick", "onNavigation(event, this, 'DUP')");
                        dupAction.Attributes.Add("qbutton", "duplicate");
                        li.InnerHtml += dupAction;
                        ul.InnerHtml = li + ul.InnerHtml;
                        hasActions = true;
                    }
                }
            }
            else if(!String.IsNullOrEmpty(t.GetHelpForm))
            {
			    // Show Action
                string action = ajax_action == "Index" ? ajax_action : t.GetHelpForm + "_Show";
                
				if (t.HasAjaxActions)
				{
					IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
					htmlAttributes.Add("class", "btn");
                    htmlAttributes.Add("qbutton", "show");
					if (t.HasCustomAction)
						htmlAttributes.Add("style", "display:none");
					dictionary.Add("nestedForm", "true");
					tdActions.InnerHtml += System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
						new System.Web.Mvc.AjaxHelper(t.GetHtmlHelper.ViewContext, t.GetHtmlHelper.ViewDataContainer, t.GetHtmlHelper.RouteCollection),
						GenioMVC.Resources.Resources.CONSULTAR57388,
						action,
						t.GetController,
						dictionary,
						new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = t.GetAjaxOption("updateTarget") as string },
						htmlAttributes
					).ToString();
				}
				else {
					if (hasActions)
					{
						TagBuilder li = new TagBuilder("li");
						TagBuilder showAction = MakeIconFormLink<TModel>(t.GetHtmlHelper, t.GetHelpForm + "_Show", rtValues, "icon-eye-open", GenioMVC.Resources.Resources.CONSULTAR57388);
						showAction.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                        showAction.Attributes.Add("qbutton", "show");
						li.InnerHtml += showAction;
						ul.InnerHtml = li + ul.InnerHtml;
					}
					else {
						IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
						htmlAttributes.Add("class", "btn");
                        htmlAttributes.Add("qbutton", "show");

						div.InnerHtml += t.GetHtmlHelper.ActionLink(
						  GenioMVC.Resources.Resources.CONSULTAR57388,
						  action,
						  t.GetController,
						  dictionary,
						  htmlAttributes
						  ).ToString();
					}
				}
			}
			
			if (hasFollowUp || hasActions || t.HasAjaxActions)
            {
                if (hasActions && (t.TableActions.Count > 1 || t.IsTableEditable))
                {
                    TagBuilder button = new TagBuilder("button");
                    button.AddCssClass("btn dropdown-toggle");
                    button.Attributes.Add("data-toggle", "dropdown");

                    TagBuilder caret = new TagBuilder("span");
                    caret.AddCssClass("caret");
                    button.InnerHtml += caret;

                    div.InnerHtml += button;
                    div.InnerHtml += ul;
                }

                if (hasActions || hasFollowUp)
                    tdActions.InnerHtml += div;

                tr.InnerHtml += tdActions;
            }
        }
		
        private TagBuilder Header<TModel>(TableBuilder<TModel> t, TagBuilder table) where TModel : class
        {
            TagBuilder thead = new TagBuilder("thead");
            TagBuilder trFilters = new TagBuilder("tr");
            trFilters.Attributes.Add("id", t.GetTableId + "_complex_filter");
            if (!t.UseTableFilters)
                trFilters.Attributes.Add("style", "display:none");

            NameValueCollection qs = new HttpContextWrapper(System.Web.HttpContext.Current).Request.Form;				
			
            foreach (ITableColumnInternal<TModel> tc in t.TableColumns)
            {
                if (tc.ColumnVisible)
                {
                    TagBuilder td = new TagBuilder("th");
                    td.MergeAttribute("scope", "col");
					String id = String.IsNullOrEmpty(t.GetTableId) ? tc.ColumnField : (t.GetTableId + "." + tc.ColumnField).Replace(".", "_");
					String value = qs[id];
                    MvcHtmlString input = null;
                    if(!tc.IsDocument) {
					    if (tc.Distincts != null) {
                            input = Html.SelectExtensions.DropDownList(t.GetHtmlHelper, id, tc.Distincts, GenioMVC.Resources.Resources.ESCOLHA___40245, new { @value = value, @class = "i-select chosen-dropdown", @elem_identifier = "ChosenDropdown", data_placeholder = GenioMVC.Resources.Resources.ESCOLHA___40245, data_no_results_text = GenioMVC.Resources.Resources.NAO_HA_RESULTADOS_PA53055, @style = "font-weight:normal" });
                            td.InnerHtml += input;
                        }
                        else
                        {
							switch (tc.ColumnType)
							{
								case "Boolean":
									bool v = value != null && value.StartsWith("true");
									input = Html.InputExtensions.CheckBox(t.GetHtmlHelper, id, v, new { });
									td.InnerHtml += input; 
									break;
								case "DateTime":
									string value1 = "";
									string value2 = "";
									if (!String.IsNullOrEmpty(value))
									{
										string[] splits = value.Split(',');
										if (!String.IsNullOrEmpty(splits[0]) && !String.IsNullOrEmpty(splits[1]))
										{
											value1 = splits[0];
											value2 = splits[1];
										}
									}
									input = Html.InputExtensions.TextBox(t.GetHtmlHelper, id, value1, new { @class="bootstrap-date input-mini" });
									var input2 = Html.InputExtensions.TextBox(t.GetHtmlHelper, id, value2, new { @class = "bootstrap-date input-mini" });
									td.InnerHtml += input + " " + GenioMVC.Resources.Resources.ATE14291 + " " + input2;
									td.Attributes.Add("style", "font-weight:normal; vertical-align: middle");
									break;
								case "SelectList":
									Type type = Type.GetType("CSGenio.business." + tc.ColumnArray + "," + "CSGenio.core" );
									MethodInfo getDictionary = type.GetMethod("GetDictionary", BindingFlags.Static | BindingFlags.Public );
									object dictionary = getDictionary.Invoke(null, null);
                                    SelectList selectList = null;
                                    if(dictionary is Dictionary<string,string>) {
                                        Dictionary<string,string> dic = (Dictionary<string,string>)dictionary;
                                        selectList = new System.Web.Mvc.SelectList(dic.ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
                                    }
                                    else if (dictionary is Dictionary<int, string>)
                                    {
                                        var dic = (Dictionary<int, string>)dictionary;
                                        selectList = new SelectList(dic.ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
                                    }
                                    else {
                                        Dictionary<double, string> dic = (Dictionary<double, string>)dictionary;
                                        selectList = new System.Web.Mvc.SelectList(dic.ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
                                    }
									input = Html.SelectExtensions.DropDownList(t.GetHtmlHelper, id, selectList, GenioMVC.Resources.Resources.ESCOLHA___40245, new { @value=value, @class = "i-select chosen-dropdown", @elem_identifier = "ChosenDropdown", data_placeholder = GenioMVC.Resources.Resources.ESCOLHA___40245, data_no_results_text = GenioMVC.Resources.Resources.NAO_HA_RESULTADOS_PA53055, @style="font-weight:normal" });
									td.InnerHtml += input;
									break;
								default:
									input = Html.InputExtensions.TextBox(t.GetHtmlHelper, id, value);
									td.InnerHtml += input;
									break;
							}
						}
					}
                    trFilters.InnerHtml += td;
                }
            }

            TagBuilder th_search = new TagBuilder("th");

            TagBuilder inputAppend = new TagBuilder("div");
            inputAppend.AddCssClass("i-input-group");

            TagBuilder button = new TagBuilder("button");
            if (!String.IsNullOrEmpty(t.GetTableId) && !t.IsChecklist)
            {
                button.Attributes.Add("type", "button");
                button.Attributes.Add("onclick", "makeAjaxRequest('" + t.GetAjaxRequest.LoadTableLink + "','" + t.PartialView + "', '" + t.GetTableId + "')");   
            }       
            else {
                button.Attributes.Add("type", "submit");
            }
            button.AddCssClass("btn");
            TagBuilder icon_search = new TagBuilder("i");
            icon_search.AddCssClass("icon-search");
            button.InnerHtml += icon_search;

            inputAppend.InnerHtml += button;

            if (t.HasFilters)
            {
                TagBuilder button_filters = new TagBuilder("button");
                button_filters.Attributes.Add("type", "button");
                button_filters.AddCssClass("btn");
                button_filters.Attributes.Add("onclick", "hideShowDiv('" + t.GetTableId + "_filters')");
                TagBuilder icon_filter = new TagBuilder("i");
                icon_search.AddCssClass("icon-filter");
                button_filters.InnerHtml += icon_search;

                inputAppend.InnerHtml += button_filters;
            }

            TagBuilder button_i = new TagBuilder("button");
            button_i.AddCssClass("dropup btn");
            button_i.Attributes.Add("type", "button");
            button_i.Attributes.Add("onclick", "changeFilters('#" + t.GetTableId + "_complex_filter', '" + t.GetTableId + "_tableFilters')");
            button_i.Attributes.Add("title", "Less filters");

            TagBuilder caret = new TagBuilder("span");
            caret.AddCssClass("caret");
            button_i.InnerHtml += caret;

			inputAppend.InnerHtml += button_i;

            th_search.InnerHtml += inputAppend;
            trFilters.InnerHtml += th_search;

            TagBuilder tr = new TagBuilder("tr");

            if (t.IsChecklist)
            {
                tr.InnerHtml += new TagBuilder("th");
            }

            foreach (ITableColumnInternal<TModel> tc in t.TableColumns)
            {
                if (tc.ColumnVisible)
                {
                    TagBuilder td = new TagBuilder("th");
                    td.MergeAttribute("scope", "col");

                    if (!t.CanSort || String.IsNullOrEmpty(tc.ColumnField))
                    {
                        td.SetInnerText(tc.ColumnTitle);
                    }
                    else
                    {
                        td.InnerHtml = GetSortLinkHtml(tc.ColumnField, t.GetSortInfo, tc.ColumnTitle, t.GetAjaxRequest, t.PartialView);
                    }

                    tr.InnerHtml += td;
                }
            }

            // Add the actions element
            TagBuilder td_actions = new TagBuilder("th");
            td_actions.AddCssClass("btn-group-fixed");
            td_actions.InnerHtml = GenioMVC.Resources.Resources.ACOES22599;

            if (!String.IsNullOrEmpty(t.GetHelpForm) && !t.HasCustomAction)
                tr.InnerHtml += td_actions;

            thead.InnerHtml += tr;
            thead.InnerHtml += trFilters;
            table.InnerHtml += thead;
            return tr;
        }

        private int TotalSize<TModel>(IList<ITableColumnInternal<TModel>> columns) where TModel : class
        {
            int result = 0;
            foreach (ITableColumnInternal<TModel> tc in columns)
            {
                result += tc.ColumnSize;
            }
            return result;
        }

        private TagBuilder MakeIconFormLink<TModel>(HtmlHelper h, string form, object routeValues, string icon, string text) where TModel : class
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", (new UrlHelper(h.ViewContext.RequestContext)).Action(form, typeof(TModel).Name, routeValues));

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass(icon);

            a.InnerHtml += i;
            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            return a;
        }

        private TagBuilder MakeDetailLink<TModel>(HtmlHelper h, string action, string controller, TModel model, Func<TModel, object> routeValuesFun, string text) where TModel : class
        {
            TagBuilder a = MakeFollowUpLink(h, action, controller, model, routeValuesFun, "", false, text, false, new { });

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("icon-play-circle");

            a.InnerHtml = i.ToString();

            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            return a;
        }

        private TagBuilder MakeFollowUpLink<TModel>(HtmlHelper h, string action, string controller, TModel model, Func<TModel, object> routeValuesFun, string icon, bool isBootsrapIcon, string text, bool isRoutine, object htmlAttributes, bool singleAction = false, string keyvalue = null) where TModel : class
        {
            TagBuilder a = new TagBuilder("a");

            string url = !isRoutine ? new UrlHelper(h.ViewContext.RequestContext).Action(action, controller, routeValuesFun(model)) : "javascript:void(0)";
            if (isRoutine)
            {
                a.Attributes.Add("routine", action);
                a.Attributes.Add("onclick", action + "('" + keyvalue + "');");
            }

            a.Attributes.Add("href", url);
			IDictionary<string, object> attrs = new RouteValueDictionary(htmlAttributes);
            a.MergeAttributes(attrs);

            TagBuilder tag;

            if (isBootsrapIcon)
            {
                TagBuilder i = new TagBuilder("i");
                if (icon.IsEmpty())
                {
                    if (!singleAction)
                        i.AddCssClass("icon-arrow-right");
                }
                else
                    i.AddCssClass(icon);
                tag = i;
            }
            else
            {
                string imgUrl = UrlHelper.GenerateContentUrl("~/Content/img/" + icon, h.ViewContext.RequestContext.HttpContext);
                TagBuilder img = new TagBuilder("img");
                img.AddCssClass("img-icon");
                img.Attributes.Add("src", imgUrl);
                tag = img;
            }
            a.InnerHtml += tag;
            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            if (singleAction)
                a.AddCssClass("btn");
				
            return a;
        }
    }
}