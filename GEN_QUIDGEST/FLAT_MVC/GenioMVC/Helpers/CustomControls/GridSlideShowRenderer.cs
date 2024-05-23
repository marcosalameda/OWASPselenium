using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class GridSlideShowRenderer<TModel> : TableListRenderer<TModel> where TModel : class
    {
        public GridSlideShowRenderer(Table<TModel> builder)
            : base(builder)
        {
        }

        protected virtual TagBuilder CreateActions(TModel model, RouteValueDictionary routeValueDictionary)
        {
            // Dropdown container
            var dropdown = new TagBuilder("div");
            dropdown.AddCssClass("gss-dropdownActions");
            // Dropdown button
            var btn = new TagBuilder("div");
            btn.GenerateId("gssBtnAction");
            btn.AddCssClass("btn dropdown-toggle b-icon--secondary i-select--secondary");
            btn.Attributes.Add("type", "button");
            btn.Attributes.Add("role", "button");
            btn.Attributes.Add("data-toggle", "dropdown");
            dropdown.InnerHtml += btn;

            // Dropdown list of actions
            var dropdownMenu = new TagBuilder("div");
            dropdownMenu.AddCssClass("dropdown-menu");
            dropdownMenu.Attributes.Add("aria-labelledby", "gssBtnAction");

            // Addictional HTML attributes
            var htmlAttr = new Dictionary<string, object>();
            htmlAttr.Add("class", "dropdown-item");
            if (Builder.Form.OpenInPopup)
            {
                htmlAttr.Add("data-modal-form", true);
                htmlAttr.Add("data-table", Builder.TableId);
            }

            // Table actions
            var actions = TableUtils.GetTableActions(Builder.TableActions);
            foreach (var tAction in actions)
            {
                var actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, model, tAction.RouteValuesFun, tAction.Title, tAction.IsRoutine, tAction.HtmlAttributes);

                var icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                if (tAction.IsAjaxAction)
                {
                    actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                    actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                    actionLink.Attributes["href"] = "#";
                }
                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink;
                }

                dropdownMenu.InnerHtml += actionLink;
            }

            if (actions.Any() && (Builder.HasViewAction() || Builder.HasEditAction() || Builder.HasDuplicateAction() || Builder.HasDeleteAction()))
            {
                TagBuilder divider = new TagBuilder("div");
                divider.AddCssClass("dropdown-divider");
                dropdownMenu.InnerHtml += divider;
            }


            if (Builder.HasViewAction())
            {
                var actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Show", routeValueDictionary, TableString.View.ToString(), htmlAttr);

                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "SHOW");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "icon-eye-open", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink;
                }

                dropdownMenu.InnerHtml += actionLink;
            }
            if (Builder.HasEditAction())
            {
                var actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Edit", routeValueDictionary, TableString.Edit.ToString(), htmlAttr);

                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "EDIT");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "icon-pencil", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink;
                }

                dropdownMenu.InnerHtml += actionLink;
            }
            if (Builder.HasDuplicateAction())
            {
                var actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Duplicate", routeValueDictionary, TableString.Duplicate.ToString(), htmlAttr);

                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DUP')");
                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "DUP");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "icon-retweet", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink;
                }

                dropdownMenu.InnerHtml += actionLink;
            }
            if (Builder.HasDeleteAction())
            {
                var actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Delete", routeValueDictionary, TableString.Delete.ToString(), htmlAttr);

                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DELETE')");
                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "DELETE");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "icon-trash", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink;
                }

                dropdownMenu.InnerHtml += actionLink;
            }

            dropdown.InnerHtml += dropdownMenu;
            if (actions.Any() || Builder.HasHelpForm())
                return dropdown;

            return null;
        }

        protected override TagBuilder GenerateBodyActionsCell(TModel model, ITableColumnInternal<TModel> tc, RouteValueDictionary routeValueDictionary)
        {
            return this.CreateActions(model, routeValueDictionary) ?? new TagBuilder("");
        }

        internal override void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
            bool EstaModoEdicao = ((TableList<TModel>)Builder).IsInEditMode,
                EstaVazia = String.IsNullOrEmpty(tRow.InnerHtml),
                TemHelpForm = Builder.HasHelpForm(),
                PodeVer = Builder.Permissions.CanView;

            if (!EstaVazia && !EstaModoEdicao && TemHelpForm && PodeVer)
            {
                TagBuilder tCell = new TagBuilder("td");
                tCell.AddCssClass("row-actions");
                Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
                if (Builder.Form.OpenInPopup)
                {
                    htmlAttributes.Add("data-modal-form", true);
                    htmlAttributes.Add("data-table", Builder.TableId);
                    htmlAttributes.Add("data-modal-form-mode", "SHOW");
                }

                tRow.InnerHtml += tCell;
            }
            else
            {
                //Only if the column is type image or action (if it has actions)
                if (tc.ColumnVisible && (tc.DataType == ColumnDataType.Image || tc.DataType == ColumnDataType.Action) && tc.IsActionsColumn && (Builder.HasActions() ||
                    !Builder.HasActions() && Builder.hasFilters))
                    tRow.InnerHtml += GenerateBodyActionsCell(model, tc, routeValueDictionary);
            }
        }

        /// <summary>
        /// Convert the control to Html
        /// </summary>
        /// <returns></returns>
        public override MvcHtmlString ToHtml(bool hidden = false)
        {
            var div = new TagBuilder("div");
            div.AddCssClass(String.Join(" ", this.Builder.TableCssClass));
            div.Attributes.Add("id", Builder.TableId);
            div.Attributes.Add("data-table-id", Builder.TableId);
            div.Attributes.Add("data-element", "gridslideshow");
            div.Attributes.Add("data-ajax-update-container", Builder.ajaxUpdateContainerId);

            var area = typeof(TModel).Name;
            var delLink = (new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)).Action(area + "_MultiDelete", area);
            div.Attributes.Add("data-multi-delete-url", delLink);


            if (Builder.Data.Any())
            {
                div.AddCssClass("gridSlideMosaic");

                div.InnerHtml += Header();
                div.InnerHtml += Body();
                div.InnerHtml += Footer();
            }
            else
            {
                div.InnerHtml += EmptyList();
                Footer();
            }

            GetHtmlAttributes().ToList().ForEach(p => { if (!div.Attributes.ContainsKey(p.Key)) div.Attributes.Add(p.Key, p.Value); });

            var divHiddenFields = new TagBuilder("div");
            divHiddenFields.Attributes.Add("id", Builder.TableId + "_inputs");
            divHiddenFields.InnerHtml = GenerateHiddenFields().ToHtmlString();

            return new MvcHtmlString(div.ToString() + divHiddenFields.ToString() + "<script>" + GenerateScripts().ToHtmlString() + "</script>");
        }

        protected override TagBuilder Header()
        {
            TagBuilder tHead = new TagBuilder("div");
            tHead.AddCssClass("i-gridslideshow__header");

            TagBuilder divViews = new TagBuilder("div"); // Div views
            divViews.AddCssClass("b-btn-group divGroupViews");
            divViews.Attributes.Add("data-element", "gridslideshow-btn-views");

            string actions = "";
            if (Builder.HasDeleteAction() && ((TableList<TModel>)Builder).IsInEditMode && Builder.HasHelpForm())
            {
                TagBuilder divSAc = new TagBuilder("div"); //Div views
                divSAc.AddCssClass("i-gridslideshow-group-actions");

                // Select button
                var btnSelect = new TagBuilder("button");
                btnSelect.Attributes.Add("type", "button");
                btnSelect.Attributes.Add("data-element", "gridslideshow-btn-select");
                btnSelect.AddCssClass("b-btn b-icon-text b-icon-text--secondary i-gridslideshow__btn-select");
                btnSelect.SetInnerText(Resources.Resources.SELECIONAR08804); // Selecionar
                divSAc.InnerHtml += btnSelect;

                // Delete (all) buttons
                var deleteBtns = new TagBuilder("div");
                deleteBtns.AddCssClass("i-gridslideshow__btn-delete");
                deleteBtns.Attributes.Add("data-element", "gridslideshow__btn-delete");
                deleteBtns.Attributes.Add("style", "display: none;");

                var btnSellectAll = new TagBuilder("button");
                btnSellectAll.AddCssClass("b-btn b-icon-text b-icon-text--secondary");
                btnSellectAll.Attributes.Add("type", "button");
                btnSellectAll.Attributes.Add("onclick", "SelectAll('" + Builder.TableId + "')");
                btnSellectAll.SetInnerText("Selecionar todas");
                deleteBtns.InnerHtml += btnSellectAll;

                var btnDel = new TagBuilder("button");
                btnDel.AddCssClass("b-btn b-icon-text b-icon-text--danger");
                btnDel.Attributes.Add("type", "button");
                btnDel.Attributes.Add("onclick", "gssModalDeleteAll('" + Builder.TableId + "')");
                btnDel.SetInnerText("Eliminar");
                deleteBtns.InnerHtml += btnDel;

                divSAc.InnerHtml += deleteBtns;

                actions = divSAc.ToString();
            }

            // Grid view
            TagBuilder iconeGrid = new TagBuilder("i");
            iconeGrid.AddCssClass("glyphicons glyphicons-show-big-thumbnails e-icon");

            TagBuilder btnGrid = new TagBuilder("button"); //Btn grid
            btnGrid.Attributes.Add("type", "button");
            btnGrid.Attributes.Add("title", Resources.Resources.GRELHA37797);
            btnGrid.Attributes.Add("data-element", "gridslideshow-btn-chg-view");
            btnGrid.Attributes.Add("data-view", "grid");
            btnGrid.AddCssClass("b-btn b-icon b-icon--secondary active");
            btnGrid.InnerHtml += iconeGrid;

            // Slide view
            TagBuilder iconeSlide = new TagBuilder("i");
            iconeSlide.AddCssClass("glyphicons glyphicons-play e-icon");

            TagBuilder btnSlide = new TagBuilder("button"); //Btn Slide
            btnSlide.Attributes.Add("type", "button");
            btnSlide.Attributes.Add("data-element", "gridslideshow-btn-chg-view");
            btnSlide.Attributes.Add("data-view", "slide");
            btnSlide.AddCssClass("Slide");
            btnSlide.Attributes.Add("title", Resources.Resources.DIAPORAMA12951);
            btnSlide.AddCssClass("b-btn b-icon b-icon--secondary");
            btnSlide.InnerHtml += iconeSlide;

            // Mosaic view
            TagBuilder iconeMosaic = new TagBuilder("i");
            iconeMosaic.AddCssClass("glyphicons glyphicons-show-thumbnails e-icon");

            TagBuilder btnMosaic = new TagBuilder("button"); //Btn Slide
            btnMosaic.Attributes.Add("type", "button");
            btnMosaic.Attributes.Add("data-element", "gridslideshow-btn-chg-view");
            btnMosaic.Attributes.Add("data-view", "mosaic");
            btnMosaic.AddCssClass("b-btn b-icon b-icon--secondary");
            btnMosaic.Attributes.Add("title", "Mosaico");

            btnMosaic.InnerHtml += iconeMosaic;

            divViews.InnerHtml += btnGrid;
            divViews.InnerHtml += btnSlide;
            divViews.InnerHtml += btnMosaic;

            TagBuilder hrGrid = new TagBuilder("hr");
            hrGrid.AddCssClass("hrSlideGrid");
            TagBuilder divContainer = new TagBuilder("div");
            divContainer.Attributes.Add("class", "container");

            tHead.InnerHtml += divContainer.ToString();
            tHead.InnerHtml += hrGrid.ToString() + actions + divViews.ToString() + "<br>" + hrGrid.ToString();

            return tHead;
        }

        protected override TagBuilder Body()
        {
            //Buttons to control Slideshow view mode
            TagBuilder divTeste = new TagBuilder("div");
            divTeste.AddCssClass("contGrid");
            TagBuilder btnLeft = new TagBuilder("button");
            btnLeft.AddCssClass("btnGridLeft");
            btnLeft.Attributes.Add("type", "button");
            btnLeft.Attributes.Add("onclick", "plusDivs(-1," + "'" + Builder.ajaxUpdateContainerId + "'" + ")");
            btnLeft.InnerHtml = "&#10094;";

            TagBuilder btnRight = new TagBuilder("button");
            btnRight.AddCssClass("btnGridRight");
            btnRight.Attributes.Add("type", "button");
            btnRight.Attributes.Add("onclick", "plusDivs(1," + "'" + Builder.ajaxUpdateContainerId + "'" + ")");
            btnRight.InnerHtml = "&#10095;";


            TagBuilder tBody = new TagBuilder("div");
            tBody.AddCssClass("i-gridslideshow__body");
            var legendaImg = new TagBuilder("div");

            foreach (TModel model in Builder.Data)
            {
                int countImg = 0;
                var key = Builder.TableKey.Evaluate(model);
                var routeValueDictionary = new RouteValueDictionary();
                routeValueDictionary.Add("id", key);

                var tRow = new TagBuilder("div");
                tRow.MergeAttribute("data-key", key);
                tRow.Attributes.Add("style", "display: inline-flex;");
                if (isDirtyRow(model))
                    tRow.Attributes.Add("class", "dirty-row");

                foreach (var tc in Builder.TableColumns)
                {
                    ProcessColumnProperties(tc);

                    if (tc.ColumnVisible && !tc.IsActionsColumn && !tc.IsCheckListColumn && countImg < 1)
                    {
                        if (tc.DataType == ColumnDataType.Image || tc.DataType == ColumnDataType.Action)
                        {
                            tRow.InnerHtml += GenerateBodyCell(model, tc);
                        }
                        else if (tc.DataType == ColumnDataType.Text && !string.IsNullOrEmpty(tc.Evaluate(model)))
                        {
                            legendaImg.AddCssClass("legendGrid");
                            legendaImg.InnerHtml += "<br>" + tc.Evaluate(model);
                            tRow.InnerHtml += legendaImg;
                            legendaImg.InnerHtml = "";
                        }
                    }

                    GenerateOtherCell(model, tc, tRow, routeValueDictionary);
                    if (tc.DataType == ColumnDataType.Image)
                        countImg++;

                }
                tBody.InnerHtml += tRow;
            }

            divTeste.InnerHtml += tBody.ToString() + btnRight.ToString() + btnLeft.ToString() + "<br>";

            return divTeste;
        }

        private bool isDirtyRow(TModel model)
        {
            var tcZzstate = Builder.TableColumns.First(tc => tc.ColumnField == "ValZzstate");
            if (tcZzstate == null) return false;
            var value = tcZzstate.Evaluate(model);
            return value != "0";
        }

        private void ProcessColumnProperties(ITableColumnInternal<TModel> tc)
        {
            int tableSize = TableUtils.CalculateTableSize<TModel>(Builder.TableColumns);
            string cellWidth = ColumnUtils.CalculateColumnWidth(tc.ColumnSize, tableSize);

            if ((this.Builder.TableType == Properties.TableType.GridTableList && !(this.Builder as GridTableList<TModel>).IsInEditMode) &&
                this.Builder.TableType != Properties.TableType.CheckList)
            {
                tc.AddInlineStyle("width", cellWidth + "%", true);
            }
        }

        internal override MvcHtmlString GenerateExtraFooterContent() //Necessário para criar o botão de inserir
        {
            String extraContent = String.Empty;
            TagBuilder hrAfter = new TagBuilder("hr");
            hrAfter.AddCssClass("hrSlideGrid");
            extraContent += hrAfter;
            // Insert Action
            if (((TableList<TModel>)Builder).IsInEditMode && Builder.Permissions.CanInsert && Builder.HasHelpForm())
            {
                extraContent += CreateInsertAction();
            }

            if (!String.IsNullOrEmpty(extraContent))
                return new MvcHtmlString(extraContent);

            return base.GenerateExtraFooterContent();
        }

        internal override TagBuilder GenerateHeaderCell(TModel model, ITableColumnInternal<TModel> tc) //Para não criar titulo de coluna
        {
            TagBuilder tCell = base.GenerateHeaderCell(model, tc);
            tCell.SetInnerText("");
            if ((tc.DataType != ColumnDataType.Image || tc.DataType != ColumnDataType.Action))
                tCell = null;
            return tCell;

        }
    }
}
