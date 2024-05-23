using System.Collections.Generic;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Linq.Expressions;
using System;
using System.Text;
using System.Web;
using GenioMVC.Helpers.Table.Properties;
using System.Web.Routing;

namespace GenioMVC.Helpers
{
    public class TreeBuilder : ITreeBuilder
    {
        private HtmlHelper HtmlHelper { get; set; }
        private List<TreeNode> Data { get; set; }

        public TablePermissions Permissions { get; protected set; }
        public List<TreeTableAction> TableActions { get; protected set; }

        public FormProperties Form { get; protected set; }
        public string FormController { get; set; }

        private bool IsInEditMode { get; set; }
        private string HtmlId { get; set; }

        /// <summary>
        /// Set the enumerable tree of model objects.
        /// </summary>
        /// <param name="dataSource">Enumerable tree of model objects.</param>
        /// <returns>Reference to the TreeBuilder object.</returns>
        public TreeBuilder DataSource(List<TreeNode> dataSource)
        {
            this.Data = dataSource;
            return this;
        }

        /// <summary>
        /// Constructor
        /// <param name="edit">Allows the TreeBuilder to be editable</param>
        /// </summary>
        internal TreeBuilder(HtmlHelper helper, bool edit)
        {
            this.HtmlHelper = helper;
            this.IsInEditMode = edit;
            this.Permissions = new TablePermissions(this.IsInEditMode);
            this.TableActions = new List<TreeTableAction>();
            this.Form = new FormProperties(null, false, false);
        }

        /// <summary>
        /// Sets the html id of the outmost tag
        /// </summary>
        /// <param name="id">The html id</param>
        /// <returns>The current TreeBuilder instance</returns>
        public TreeBuilder Id(string id)
        {
            this.HtmlId = id;
            return this;
        }

        /// <summary>
        /// Set the support form of the first tree branch
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="helpForm"></param>
        /// <param name="openInPopup"></param>
        public TreeBuilder SetForm(string controller, string helpForm, bool openInPopup, bool repeatInsertion)
        {
            this.Form = new FormProperties(helpForm, openInPopup, repeatInsertion);
            this.FormController = controller;
            return this;
        }

        /// <summary>
        /// Sets the tree node support forms permissions
        /// </summary>
        /// <param name="canView"></param>
        /// <param name="canInsert"></param>
        /// <param name="canEdit"></param>
        /// <param name="canDuplicate"></param>
        /// <param name="canDelete"></param>
        /// <returns></returns>
        public TreeBuilder SetPermissions(bool canView = false, bool canInsert = false, bool canEdit = false, bool canDuplicate = false, bool canDelete = false)
        {
            this.Permissions = new TablePermissions(canView, canInsert, canEdit, canDuplicate, canDelete, this.IsInEditMode);
            return this;
        }

        public TreeBuilder AddTableAction(string action, string icon, string title, bool isRoutine = false, object htmlAttributes = null, bool isFollowUpAction = false, bool isAjaxAction = false)
        {
            this.TableActions.Add(new TreeTableAction(action, icon, title, isRoutine, htmlAttributes, isFollowUpAction, isAjaxAction));
            return this;
        }

        /// <summary>
        /// Convert the TreeBuilder to JSON data
        /// </summary>
        /// <returns></returns>
        public MvcHtmlString ToJSON()
        {
            Data.ForEach(n => _fillNode(n));
            //filter the final list to only include the top nodes
            return MvcHtmlString.Create(Newtonsoft.Json.JsonConvert.SerializeObject(Data.FindAll(x => x.hasParent == false)));
        }

        private void _fillNode(TreeNode node)
        {
            //Actions
            TagBuilder tbActions = NodeActions(node);
            if (tbActions != null)
                node.Action = tbActions.ToString();

            //Icon
            if (node.ImageData != null && node.ImageData.Length != 0)
                node.Image = HtmlHelper.Image(node.ImageData, new { @class = "tree_node_icon"}).ToHtmlString();
            //Fill children
            node.Children.ForEach(n => _fillNode(n));
        }

        private TagBuilder NodeActions(TreeNode item)
        {
            if(string.IsNullOrEmpty(item.Form) && this.TableActions.Count == 0)
                return null;

            if (string.IsNullOrEmpty(item.Area) || string.IsNullOrEmpty(item.Key))
                return null;

            TagBuilder group = new TagBuilder("div");
            group.Attributes.Add("elem-identifier", "BtnGroup");
            group.AddCssClass("b-btn-group");
            group.AddCssClass("options");
            //group.AddCssClass("btn-group-fixed");

            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("id", item.Key);

            TagBuilder dropdown = null;
            if (!IsInEditMode && Permissions.CanView && !string.IsNullOrEmpty(item.Form))
            {
                //default action
                dropdown = MakeIconFormLink(item.Area, item.Form + "_Show", routeValues, "glyphicons glyphicons-eye-open", null);
                dropdown.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                dropdown.AddCssClass("options-button");
                group.InnerHtml += dropdown;
            }
            else if(IsInEditMode && Permissions.NumberOfPermissons > 0)
            {
                //dropdown button for split button
                dropdown = new TagBuilder("div");
                dropdown.AddCssClass("options-button");
                dropdown.Attributes.Add("data-toggle", "dropdown");                
				
                var icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-option-horizontal");
                dropdown.InnerHtml += icon;
				
				group.InnerHtml += dropdown;

                //the list of actions
                dropdown = new TagBuilder("div");
                dropdown.AddCssClass("dropdown-menu");
                dropdown.AddCssClass("options-menu");

                //Routine buttons
                foreach (TreeTableAction tta in this.TableActions)
                    dropdown.InnerHtml += MakeAction(item, tta);

                if (this.TableActions.Count > 0 && !string.IsNullOrEmpty(item.Form))
                {
                    TagBuilder divider = new TagBuilder("div");
                    divider.AddCssClass("dropdown-divider");
                    dropdown.InnerHtml += divider;
                }

                if (Permissions.CanView && !string.IsNullOrEmpty(item.Form))
                {
                    TagBuilder showAction = MakeIconFormLink(item.Area, item.Form + "_Show", routeValues, "glyphicons glyphicons-eye-open e-icon", Resources.Resources.CONSULTAR57388);
                    showAction.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                    showAction.Attributes.Add("qbutton", "show");
					showAction.AddCssClass("options-submenu dropdown-item");
                    dropdown.InnerHtml += showAction;
                }

                if (Permissions.CanEdit && !string.IsNullOrEmpty(item.Form))
                {
                    
                    TagBuilder editAction = MakeIconFormLink(item.Area, item.Form + "_Edit", routeValues, "glyphicons glyphicons-pencil e-icon", Resources.Resources.EDITAR11616);
                    editAction.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                    editAction.Attributes.Add("qbutton", "edit");
					editAction.AddCssClass("options-submenu dropdown-item");
                    dropdown.InnerHtml += editAction;
                }

                if (Permissions.CanInsert)
                {
                    if (!string.IsNullOrEmpty(item.InsertFormArea) && !string.IsNullOrEmpty(item.InsertFormName))
                    {
                        RouteValueDictionary rd = new RouteValueDictionary();
                        rd.Add(item.Area.ToLower(), item.Key);
                        TagBuilder insertAction = MakeIconFormLink(item.InsertFormArea, item.InsertFormName + "_New", rd, "glyphicons glyphicons-plus e-icon", Resources.Resources.INSERIR43365);
                        insertAction.Attributes.Add("onclick", "onNavigation(event, this, 'NEW')");
                        insertAction.Attributes.Add("qbutton", "insert");
						insertAction.AddCssClass("options-submenu dropdown-item");
                        dropdown.InnerHtml += insertAction;
                    }
                }

                if (Permissions.CanDelete && !string.IsNullOrEmpty(item.Form))
                {
                    TagBuilder deleteAction = MakeIconFormLink(item.Area, item.Form + "_Delete", routeValues, "glyphicons glyphicons-delete e-icon", Resources.Resources.APAGAR04097);
                    deleteAction.Attributes.Add("onclick", "onNavigation(event, this, 'DELETE')");
                    deleteAction.Attributes.Add("qbutton", "delete");
					deleteAction.AddCssClass("options-submenu dropdown-item");
                    dropdown.InnerHtml += deleteAction;
                }

                group.InnerHtml += dropdown;
            }

            return group;
        }

        private TagBuilder MakeIconFormLink(string area, string form, RouteValueDictionary routeValues, string icon, string text)
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", (new UrlHelper(HtmlHelper.ViewContext.RequestContext)).Action(form, /*typeof(TModel).Name*/ area, routeValues));

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass(icon);

            a.InnerHtml += i;
            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            return a;
        }

        private TagBuilder MakeAction(TreeNode item, TreeTableAction ttAction)
        {
            RouteValueDictionary rd = new RouteValueDictionary();
            rd.Add(item.Area.ToLower(), item.Key);

            if (ttAction.IsFollowUp)
            {
                TagBuilder action = MakeIconFormLink(item.Area, ttAction.Action, rd, ttAction.Icon, ttAction.Title);
                action.MergeAttributes(new RouteValueDictionary(ttAction.HtmlAttributes), true);
                action.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                action.AddCssClass("options-submenu dropdown-item");
                return action;
            }
            else if (ttAction.IsRoutine)
            {
                TagBuilder action = MakeRoutineAction(ttAction.Action, item.Area, ttAction.Icon, ttAction.Title, ttAction.HtmlAttributes, item.Key);
                action.AddCssClass("options-submenu dropdown-item");
                return action;
            }
            else return new TagBuilder("a");
        }


        private TagBuilder MakeRoutineAction(string action, string controller, string icon, string text, object htmlAttributes, string keyvalue = null)
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", "javascript:void(0)");
            a.Attributes.Add("routine", action);
            a.Attributes.Add("onclick", string.Format("{0}({{area:\"{1}\", id:\"{2}\"}})", action, controller, keyvalue));
            a.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            if (string.IsNullOrEmpty(icon))
            {
                TagBuilder i = new TagBuilder("i");
                i.AddCssClass("icon-arrow-right");
                a.InnerHtml += i;
            }
            else
            {
                string imgUrl = UrlHelper.GenerateContentUrl("~/Content/img/" + icon, this.HtmlHelper.ViewContext.RequestContext.HttpContext);
                TagBuilder img = new TagBuilder("img");
                img.AddCssClass("img-icon");
                img.Attributes.Add("src", imgUrl);
                a.InnerHtml += img;
            }

            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            return a;
        }

        public MvcHtmlString CreateInsertAction()
        {
            if (!Permissions.CanInsert || string.IsNullOrEmpty(this.FormController) || string.IsNullOrEmpty(this.Form.HelpForm))
                return MvcHtmlString.Empty;
            RouteValueDictionary rd = new RouteValueDictionary();
            TagBuilder insertAction = MakeIconFormLink(this.FormController, this.Form.HelpForm + "_New", rd, "glyphicons glyphicons-plus-sign e-icon", Resources.Resources.INSERIR43365);
            insertAction.Attributes.Add("onclick", "onNavigation(event, this, 'NEW')");
            insertAction.Attributes.Add("qbutton", "insert");
            insertAction.AddCssClass("b-icon-text b-icon-text--secondary");

            return new MvcHtmlString(insertAction.ToString());
        }
    }

    public class TreeTableAction
    {
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public bool IsRoutine { get; set; }
        public object HtmlAttributes { get; set; }
        public bool IsFollowUp { get; set; }
        public bool IsAjaxAction { get; set; }


        public TreeTableAction(string action, string icon, string title, bool isRoutine, object htmlAttributes, bool isFollowUpAction, bool isAjaxAction)
        {
            this.Action = action;
            this.Icon = icon;
            this.Title = title;
            this.IsRoutine = isRoutine;
            this.HtmlAttributes = htmlAttributes == null ? new { } : htmlAttributes;
            this.IsFollowUp = isFollowUpAction;
            this.IsAjaxAction = isAjaxAction;
        }
    }
}