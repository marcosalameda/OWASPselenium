using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Pagination;
using GenioMVC.Helpers.Table.Sorting;
using GenioMVC.Helpers.Table.Utils;
using GenioMVC.Helpers.Table.Builder;
using CSGenio.business;

namespace GenioMVC.Helpers.Table
{
    /// <summary>
    /// Build a table based on an enumerable list of model objects.
    /// </summary>
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
    public class TableBuilder<TModel> : ITableBuilder<TModel> where TModel : class
    {
        public Table<TModel> _builder { get; set; }
        public Table<TModel> Builder
        {
            get { return _builder; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal TableBuilder(HtmlHelper helper, TableType tableType, bool edit, bool canPage, bool canSort, bool countRec = false)
        {
            this._builder = new Table<TModel>(helper, tableType, edit, canPage, canSort, countRec);
        }

        public TableBuilder()
        {
        }

        #region Builder Methods

        /// Set the enumerable list of model objects.
        public TableBuilder<TModel> DataSource(IEnumerable<TModel> dataSource, bool autoSortAndPage = false)
        {
            this.Builder.SetDataSource(dataSource, autoSortAndPage);

            return this;
        }

        /// Set the html table id.
        public TableBuilder<TModel> Id(string tableId)
        {
            this.Builder.SetId(tableId);
            return this;
        }

        /// Prepares the table to generate links for Ajax requests
        public TableBuilder<TModel> AjaxRequest(string ajaxUpdateContainerId)
        {
            this.Builder.SetAjaxRequest(ajaxUpdateContainerId);
            return this;
        }

        ///
        public TableBuilder<TModel> DefaultSort(string column)
        {
            this.Builder.SetDefaultSort(column);
            return this;
        }

        ///
        public TableBuilder<TModel> Sort(GenioMVC.ViewModels.TableSort sort)
        {
            if (sort != null)
                this.Builder.SetSort(sort.Column, SortDirection.getSortDirection(sort.Direction));
            return this;
        }

        ///
        public TableBuilder<TModel> Pager(GenioMVC.ViewModels.TablePagination pager)
        {
            this.Builder.SetPager(pager.PageNumber, pager.NumberOfItems, pager.HasMore, pager.HasTotal, pager.TotalRows);
            return this;
        }

        /// Focus the table on the specific record
        public TableBuilder<TModel> Focus(string id)
        {
            this.Builder.SetFocus(id);
            return this;
        }
        
        /// Slots reports on the specific control
        public TableBuilder<TModel> Slots(Dictionary<string, List<object>> slots)
        {
            this.Builder.SetSlotReports(slots);
            return this;
        }

        #endregion Builder Methods

        #region Convert Methods

        /// <summary>
        /// Set this table as DbEdit
        /// </summary>
        public DbEditBuilder<TModel> DBEdit(bool canFilter = true)
        {
            this.Builder.SetNewTableType(TableType.DBedit);
            return new DbEditBuilder<TModel>(this.Builder, canFilter);
        }

        /// <summary>
        /// Set this table as TableList
        /// </summary>
        public TableListBuilder<TModel> TableList(bool hasFilters = false)
        {
            this.Builder.SetNewTableType(TableType.List);
            return new TableListBuilder<TModel>(this.Builder, hasFilters);
        }

        /// <summary>
        /// Set this table as GridTableList
        /// </summary>
        public GridTableListBuilder<TModel> GridTableList()
        {
            this.Builder.SetNewTableType(TableType.GridTableList);
            return new GridTableListBuilder<TModel>(this.Builder);
        }

        /// <summary>
        /// Set this table as SearchList
        /// </summary>
        public SearchListBuilder<TModel> SearchList()
        {
            this.Builder.SetNewTableType(TableType.SearchList);
            return new SearchListBuilder<TModel>(this.Builder);
        }
        
        /// <summary>
        /// Set this table as MatrixList
        /// </summary>
        public MatrixBuilder<TModel> MatrixList()
        {
            return new MatrixBuilder<TModel>(this.Builder, false);
        }

        #region Limits
        public TableBuilder<TModel> SetLimits(List<Limit> tableLimits)
        {
            if (this.Builder.tableLimits == null)
                this.Builder.tableLimits = new List<Limit>();

            if(tableLimits != null)
                this.Builder.tableLimits = tableLimits;
            
            return this;
        }
        #endregion

        #endregion Convert Methods

        #region Custom Convert Methods
        /// <summary>
        /// Set this table as Leaflet
        /// </summary>
        public LeafletBuilder<TModel> ToLeaflet(bool hasFilters = false)
        {
            return new LeafletBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as GoogleMaps
        /// </summary>
        public GoogleMapsBuilder<TModel> ToGoogleMaps(bool hasFilters = false)
        {
            return new GoogleMapsBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as GridSlideShow
        /// </summary>
        public GridSlideShowBuilder<TModel> ToGridSlideShow(bool hasFilters = false)
        {
            return new GridSlideShowBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as FullCalendar
        /// </summary>
        public FullCalendarBuilder<TModel> ToFullCalendar(bool hasFilters = false)
        {
            return new FullCalendarBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as ColorPicker
        /// </summary>
        public ColorPickerBuilder<TModel> ToColorPicker(bool hasFilters = false)
        {
            return new ColorPickerBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as ImageMagnifier
        /// </summary>
        public ImageMagnifierBuilder<TModel> ToImageMagnifier(bool hasFilters = false)
        {
            return new ImageMagnifierBuilder<TModel>(this.Builder, hasFilters);
        }
        /// <summary>
        /// Set this table as LeafletDraw
        /// </summary>
        public LeafletDrawBuilder<TModel> ToLeafletDraw(bool hasFilters = false)
        {
            return new LeafletDrawBuilder<TModel>(this.Builder, hasFilters);
        }
        public SpecialRenderingBuilder<TModel> ToSpecialRendering(bool hasFilters = false)
        {
            return new SpecialRenderingBuilder<TModel>(this.Builder, hasFilters);
        }
        #endregion

        #region Columns

        /// <summary>
        /// Applies the user column configuration to the table columns.
        /// </summary>
        /// <param name="columnBuilder">The user column configuration.</param>
        /// <param name="baseArea">The base area of the table list.</param>
        public TableBuilder<TModel> SetUserColumns(List<CSGenioAlstcol> userColumns, string baseArea)
        {
            if (userColumns != null && userColumns.Any())
            {
                this.Builder.userTableColumns
                    = new List<ITableColumnInternal<TModel>>
                    {
                        // Add primary key
                        this.Builder.TableColumns[0]
                    };

                // Change visibility and reorder columns
                foreach (var userColumn in userColumns)
                {
                    foreach (var column in this.Builder.TableColumns)
                    {
                        if (column.ColumnField == null)
                            continue;

                        string fullName;
                        string[] split = column.ColumnField.Split('.');

                        /** Normalize table column names */
                        // add base area to columns with the same base area as the table:
                        //  * ValField => BaseArea.ValField
                        // columns of a direct parent table remain unchanged:
                        //  * Area.ValField => Area.ValField
                        // columns of tables not directly related:
                        //  * Area1.(...).AreaN.ValField => AreaN.ValField
                        if (split.Length >= 2)
                            fullName = split[split.Length - 2] + "." + split.Last();
                        else
                            fullName = baseArea + "." + split.Last();

                        /** Normalize user configuration column names */
                        // stored in PascalCase, sometimes without base area, sometimes not
                        // however the base area is always stored in a separate column, in lowercase
                        // ... we can merge it with last part of Split('.') and discard the rest
                        string cfgFullName = userColumn.ValTabela + "." + userColumn.ValCampo.Split('.').Last();

                        // at this point there's a mix of lowercase and PascalCase,
                        // normalize before comparing
                        if (fullName.ToLower() == cfgFullName.ToLower())
                        {
                            column.ColumnVisible = userColumn.ValVisivel == 1;
                            this.Builder.userTableColumns.Add(column);

                            // a match for this user column cfg has been found,
                            // jump to the next one
                            break;
                        }
                    }
                }

                // Add zzstate
                this.Builder.userTableColumns.Add(this.Builder.TableColumns[this.Builder.TableColumns.Count - 1]);

                // Replace original columns with the user configuration
                this.Builder.TableColumns = this.Builder.userTableColumns;
            }
            return this;
        }
        
        /// <summary>
        /// Create an instance of the ColumnBuilder to add columns to the table.
        /// </summary>
        /// <param name="columnBuilder">The column builder.</param>
        public TableBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            this.Builder.SetColumns(columnBuilder);
            return this;
        }

        #endregion

        /// <summary>
        /// Convert the TableBuilder to HTML.
        /// </summary>
        public MvcHtmlString ToHtml()
        {
            this.Builder.DoInternalActions();

            return new TableRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}
