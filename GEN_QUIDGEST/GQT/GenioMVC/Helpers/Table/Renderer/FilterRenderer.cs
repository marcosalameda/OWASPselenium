using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class FilterRenderer<TModel> where TModel : class
    {
        private DbEdit<TModel> DbEdit { get; set; }
        private DbEditRenderer<TModel> Renderer { get; set; }

        public FilterRenderer(Table<TModel> builder, TableRenderer<TModel> renderer)
        {
            this.DbEdit = builder as DbEdit<TModel>;
            this.Renderer = renderer as DbEditRenderer<TModel>;
        }

        internal TagBuilder GenerateHeaderFilterRow()
        {
            TagBuilder trHeadFilter = new TagBuilder("tr");
            trHeadFilter.AddCssClass("filtersRow");

            TModel model = this.DbEdit.Data.FirstOrDefault();
            trHeadFilter.Attributes.Add("id", this.DbEdit.TableId + "_complex_filter");
            if (!this.DbEdit.Filter.ShowTableFilters)
                trHeadFilter.Attributes.Add("style", "display:none");

            if(this.DbEdit.multipleSelection || this.DbEdit._DEF_MultipleSelection)
                trHeadFilter.InnerHtml += new TagBuilder("th");

            foreach (ITableColumnInternal<TModel> tc in this.DbEdit.TableColumns)
            {
                if (!tc.ColumnUsedForFilter) continue;
                if (tc.ColumnVisible && !tc.IsActionsColumn)
                {
                    trHeadFilter.InnerHtml += GenerateHeaderFilterCell(model, tc).ToString();
                }
                else if (tc.ColumnVisible && tc.IsActionsColumn)
                {
                    trHeadFilter.InnerHtml += GenerateHeaderFilterActionsCell();
                }
            }

            return trHeadFilter;
        }

        private TagBuilder GenerateHeaderFilterCell(TModel model, ITableColumnInternal<TModel> tc)
        {
            NameValueCollection qs = this.DbEdit.HttpRequest.QueryString;

			TagBuilder th = new TagBuilder("th");
            if (tc.ColumnField != null)
            {
				String columnName = tc.ColumnField.Replace(".", "_");
				String id = String.IsNullOrEmpty(this.DbEdit.TableId) ? tc.ColumnField : (this.DbEdit.TableId + "_" + columnName);
				String value = this.DbEdit.Filter.FiltersValues.ContainsKey(columnName) ? this.DbEdit.Filter.FiltersValues[columnName] : "";
				MvcHtmlString input = null;

				// Last updated by [DSG] at [2018.07.02]
                // Add id to the header creating a link between td and th by adding td's attribute headers equal to the corresponding header id
                // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.MissingHeaderIds of the WCAG2 rules)
                String tableName = typeof(TModel).Name;
                th.Attributes.Add("id", "Filter_" + tableName + "_" + id);

				if (tc.Distincts != null)
				{
					List<SelectListItem> selectList = new List<SelectListItem>();
					foreach (var item in tc.Distincts)
					{
						if (item.Value.Equals(value))
							item.Selected = true;

						selectList.Add(item);
					}   

					input = System.Web.Mvc.Html.SelectExtensions.DropDownList(this.DbEdit.HtmlHelper, id, selectList, TableString.Choice.ToString(), new { @value = value, @class = "i-select chosen-dropdown", @elem_identifier = "ChosenDropdown", data_placeholder = TableString.Choice.ToString(), data_no_results_text = TableString.NoResults.ToString(), @style = "font-weight:normal; width:100%;", title = Resources.Resources.SELECIONAR08804 + " " + tc.ColumnTitle });
					th.InnerHtml += input;
				}
				else
				{
					if (tc.ColumnType == typeof(Boolean))
					{
						// Drop Down List with 3 option: None, True and False
						var select = new TagBuilder("select");
						select.GenerateId(id);
						select.AddCssClass("i-select");
						select.Attributes.Add("value", value);
						select.Attributes.Add("style", "width: 85px;");

						// Options
						var option = new TagBuilder("option");
						option.SetInnerText(Resources.Resources.VAZIO58398);
						option.Attributes.Add("value", "");
						if(string.IsNullOrEmpty(value))
							option.Attributes.Add("selected", "");
						select.InnerHtml += option;

						option = new TagBuilder("option");
						option.InnerHtml = "&#10003;";
						option.Attributes.Add("value", "true");
						if (value == "true")
							option.Attributes.Add("selected", "");
						select.InnerHtml += option;

						option = new TagBuilder("option");
						option.InnerHtml = "&#10005;";
						option.Attributes.Add("value", "false");
						if (value == "false")
							option.Attributes.Add("selected", "");
						select.InnerHtml += option;

						th.InnerHtml += select;
					}
					else if (tc.ColumnType == typeof(DateTime?))
					{
						string value1 = this.DbEdit.Filter.FiltersValues.ContainsKey(columnName) ? this.DbEdit.Filter.FiltersValues[columnName] : "";
						string value2 = this.DbEdit.Filter.FiltersValues.ContainsKey(columnName + "2") ? this.DbEdit.Filter.FiltersValues[columnName + "2"] : "";

						DateTime.TryParse(value1, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime dtValue1);
						DateTime.TryParse(value2, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime dtValue2);

						DateAttribute.DateEnum dateEnum = DateAttribute.DateEnum.Date;

						if (tc.ColumnSize > 8)
							dateEnum = DateAttribute.DateEnum.DateTime;

						input = HtmlHelpers.DateTextBox(this.DbEdit.HtmlHelper, dateEnum, id, dtValue1, new { @class = "bootstrap-date i-date-picker__field", @style = "width: 64px;", @title = tc.ColumnTitle });
						TagBuilder hiddable = new TagBuilder("div");
						hiddable.MergeAttribute("hiddable", "");
						var input2 = HtmlHelpers.DateTextBox(this.DbEdit.HtmlHelper, dateEnum, id + "2", dtValue2, new { @class = "bootstrap-date i-date-picker__field", @style = "width: 64px;", @title = tc.ColumnTitle + " (" + TableString.Until.ToString() + ")" });
						hiddable.InnerHtml = TableString.Until.ToString() + " " + input2;
						th.InnerHtml += input + " " + hiddable.ToString();

						/* Added to allow date selectors to show beyond size of menu lists */
						th.AddCssClass("filter-date-cell");
					}
					else if (tc.ColumnType == typeof(SelectList))
					{
						Type type = Type.GetType("CSGenio.business." + tc.ColumnArray + "," + "CSGenio.core");
						MethodInfo getDictionary = type.GetMethod("GetDictionary", BindingFlags.Static | BindingFlags.Public);
						object dictionary = getDictionary.Invoke(null, null);
						SelectList selectList = null;
						if (dictionary is Dictionary<string, string>)
						{
							Dictionary<string, string> dic = (Dictionary<string, string>)dictionary;
							selectList = new System.Web.Mvc.SelectList(dic.ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
						}
						else if(dictionary is Dictionary<int, string>)
						{
							var dic = (Dictionary<int, string>)dictionary;
							selectList = new SelectList(dic.ToDictionary(p => p.Key, p => Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
						}
						else
						{
							Dictionary<double, string> dic = (Dictionary<double, string>)dictionary;
							selectList = new System.Web.Mvc.SelectList(dic.ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value)), "Key", "Value", value);
						}
						input = System.Web.Mvc.Html.SelectExtensions.DropDownList(this.DbEdit.HtmlHelper, id, selectList, TableString.Choice.ToString(), new { @value = value, @class = "i-select chosen-dropdown", @elem_identifier = "ChosenDropdown", data_placeholder = TableString.Choice.ToString(), data_no_results_text = TableString.NoResults.ToString(), @style = "width: 100%", data_is_array = true, title = Resources.Resources.SELECIONAR08804 + " " + tc.ColumnTitle });
						th.InnerHtml += input;
					}
					else
					{
						input = System.Web.Mvc.Html.InputExtensions.TextBox(this.DbEdit.HtmlHelper, id, value, new {@class= "i-text__field", @style = "width: 100%", @title = tc.ColumnTitle });
						th.InnerHtml += input;
					}
				}
			}

            return th;
        }

        private TagBuilder GenerateHeaderFilterActionsCell()
        {
            TagBuilder th_search = new TagBuilder("th");

			// Last updated by [DSG] at [2018.07.02]
            // Add id to the header creating a link between td and th 
			// by adding td's attribute headers equal to the corresponding header id
            // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.MissingHeaderIds of the WCAG2 rules);
            String tableName = typeof(TModel).Name;

            th_search.Attributes.Add("id", "Filter_" + tableName + "_" + this.DbEdit.TableId + "_actions");


            TagBuilder ContainerDiv = new TagBuilder("div");
            ContainerDiv.AddCssClass("c-action-bar b-btn-group d-flex");

            TagBuilder SearchButton = new TagBuilder("button");
            TagBuilder ClearButton = new TagBuilder("button");

            ClearButton.GenerateId("clearComplexFilter");
            SearchButton.GenerateId("applyComplexFilter");
            SearchButton.Attributes.Add("data-id", "applyComplexFilter");

            if (!String.IsNullOrEmpty(this.DbEdit.ajaxUpdateContainerId) && this.DbEdit.useAjax)
            {
                string click = "window." + this.DbEdit.TableId + ".Search(); ClearSearchBox('q" + this.DbEdit.TableId + "');";
                SearchButton.Attributes.Add("type", "button");
                SearchButton.Attributes.Add("onclick", click);

                string removeFilters = "RemoveAllSearchFilters(); window." + this.DbEdit.TableId + ".Search();";
                ClearButton.Attributes.Add("type", "button");
                ClearButton.Attributes.Add("onclick", removeFilters);
            }
            else
            {
                SearchButton.Attributes.Add("type", "submit"); // Why 'submit' ???
            }

            SearchButton.Attributes.Add("title", Resources.Resources.APLICAR_FILTRO_COMPL40940);
            SearchButton.AddCssClass("b-btn b-icon b-icon--secondary" + this.Renderer.buttonSize);
            ClearButton.AddCssClass("b-btn b-icon b-icon--secondary" + this.Renderer.buttonSize);

            TagBuilder icon_search = new TagBuilder("i");
            TagBuilder icon_remove = new TagBuilder("i");

            icon_remove.AddCssClass("glyphicons glyphicons-remove e-icon");
            icon_search.AddCssClass("glyphicons glyphicons-search e-icon");

            icon_remove.Attributes.Add("style", "font-size: 15px;");
            icon_search.Attributes.Add("style", "font-size: 15px;");

            SearchButton.InnerHtml += icon_search;
            ClearButton.InnerHtml += icon_remove;

            ContainerDiv.InnerHtml += SearchButton;
            ContainerDiv.InnerHtml += ClearButton;

            th_search.InnerHtml += ContainerDiv;

            return th_search;
        }
    }
}