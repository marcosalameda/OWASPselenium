using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Sorting;

namespace GenioMVC.Helpers.Table
{
    /// <summary>
    /// Properties and methods used by the consumer to configure the TableBuilder.
    /// </summary>
    public interface ITableBuilder<TModel>
        where TModel : class
    {
        Table<TModel> _builder { get; set; }
    }

    public interface IDbEditBuilder<TModel> : ITableBuilder<TModel>
       where TModel : class
    {
       
    }

    public interface ITableListBuilder<TModel> : IDbEditBuilder<TModel>
       where TModel : class
    {
       
    }

    public interface ICheckListBuilder<TModel> : ITableBuilder<TModel>
       where TModel : class
    {
        
    }
	
    public interface IMultiformBuilder<TModel> : ITableBuilder<TModel>
        where TModel : class
    {

    }
	
	public interface IGridTableListBuilder<TModel> : ITableBuilder<TModel>
        where TModel : class
    {

    }
	
	public interface ITimelineBuilder <TModel> : ITableBuilder<TModel>
        where TModel : class
    {

    }
}