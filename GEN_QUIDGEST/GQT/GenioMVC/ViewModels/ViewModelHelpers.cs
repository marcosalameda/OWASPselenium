using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;

namespace GenioMVC.ViewModels
{
	public class SearchParams
	{
		public IDictionary<string, IDictionary<string, string>> Filters { get; set; }

		public string Query { get; set; }

		public string SimilarQueries { get; set; }

		public SearchParams()
		{
			Filters = new Dictionary<string, IDictionary<string, string>>();
		}
	}

	public class TablePartial<A>
	{
		/// <summary>
		/// [MH] - [17-08-2015]: Ainda nao usado, mas vai ser refatorizado o Identificador nos menus
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public string Identifier { get; set; }

		public TablePagination Pagination { get; set; }

		public TableSort Sort { get; set; }

		public TableFiltering Filters { get; set; }

		public string Query { get; set; }

		public bool TableFilters { get; set; }

		public virtual IEnumerable<A> Elements { get; set; }

		public Dictionary<string, SelectList> Distincts { get; set; }

		public string FocusOnRecord { get; set; }

		//Slot report list
		public Dictionary<string, List<object>> Slots { get; set; }

		public TablePartial()
		{
			Elements = new List<A>();
			Distincts = new Dictionary<string, SelectList>();
			Pagination = new TablePagination(1, 0, false, false, 0);
			Filters = new TableFiltering();
		}

		public void SetPagination(int pageNumber, int itemsNumber, bool hasMore, bool showTotal, int totalRows)
		{
			Pagination = new TablePagination(pageNumber, itemsNumber, hasMore, showTotal, totalRows);
		}

		public void SetSort(string column, string direction)
		{
			Sort = new TableSort(column, direction);
		}

		public void SetFilters(bool showTableFilters, bool hasFilters)
		{
			Filters = new TableFiltering(showTableFilters, hasFilters, new Dictionary<string, string>());
		}

		public bool HasMore()
		{
			return Pagination.HasMore;
		}
	}

	[Newtonsoft.Json.JsonObject(memberSerialization: Newtonsoft.Json.MemberSerialization.OptIn)]
	public class TableDBEdit<A> : TablePartial<A>
	{
		[Newtonsoft.Json.JsonProperty]
		public SelectList List { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public string Selected { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public object Value { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public bool FilledByHistory { get; set; }

		[Newtonsoft.Json.JsonProperty("HasMore")]
		public bool _HasMore { get { return base.HasMore(); } }

		[Newtonsoft.Json.JsonProperty]
		public bool IsLazyLoad { get; set; }

		public TableDBEdit() : base()
		{
			List = new SelectList(new List<string>());
		}

		public override string ToString()
		{
			if (this.Value == null || this.Value is DateTime && (DateTime)this.Value == DateTime.MinValue)
				return String.Empty;
			if (this.Value is DateTime)
				return ((DateTime)this.Value).ToString(System.Globalization.CultureInfo.InvariantCulture);
			return this.Value.ToString();
		}
	}

	public class TableSort
	{
		public string Column { get; set; }

		public string Direction { get; set; }

		public TableSort(string column, string direction)
		{
			Column = column;
			Direction = direction;
		}
	}

	public class TablePagination
	{
		public bool HasTotal { get; set; }

		public int TotalRows { get; set; }

		public bool HasMore { get; set; }

		public int PageNumber { get; set; }

		public int NumberOfItems { get; set; }

		public TablePagination(int pageNumber, int numberOfItems, bool hasMore, bool hasTotal, int totalRows)
		{
			PageNumber = pageNumber;
			NumberOfItems = numberOfItems;
			HasMore = hasMore;
			HasTotal = hasTotal;
			TotalRows = totalRows;
		}
	}

	public class TableFiltering
	{
		public bool ShowTableFilters { get; set; }

		public bool HasFilters { get; set; }

		public Dictionary<string, string> FiltersValues { get; set; }

		public string Query { get; set; }

		public string QueryField { get; set; }

		public FieldRef FilterDateStart { get; set; }

		public FieldRef FilterDateEnd { get; set; }

		/// <summary>
		/// Parameterless constructor for deserializing
		/// </summary>
		public TableFiltering()
		{
			this.FiltersValues = new Dictionary<string, string>();
		}

		public TableFiltering(bool showTableFilters, bool hasFilters, Dictionary<string, string> filtersValues)
		{
			this.ShowTableFilters = showTableFilters;
			this.HasFilters = hasFilters;
			this.FiltersValues = filtersValues;
		}
	}

	public class TableSearchColumn
	{
		public string Field { get; private set; }

		public FieldRef AreaField { get; private set; }

		public Type FieldType { get; private set; }

		public string ArrayName { get; private set; }

		public bool Visible { get; private set; }

		public bool IsDefaultSearch { get; private set; }

		public TableSearchColumn(string field, FieldRef areaField, Type fieldType, bool visible = true, bool defaultSearch = false, string array = null)
		{
			this.Field = field;
			this.AreaField = areaField;
			this.FieldType = fieldType;
			this.ArrayName = array;
			this.Visible = visible;
			this.IsDefaultSearch = defaultSearch;
		}
	}

	[Newtonsoft.Json.JsonObject(memberSerialization: Newtonsoft.Json.MemberSerialization.OptIn)]
	public class GridTableList<T> : TablePartial<T> where T: ICrudViewModel, new()
	{
		[Newtonsoft.Json.JsonProperty]
		public override IEnumerable<T> Elements { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public List<T> NewElements { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public List<T> EditedElements { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public List<string> RemovedElements { get; set; }

		[Newtonsoft.Json.JsonProperty]
		public T NewRecordTemplate { get; set; }

		public GridTableList()
		{
			NewRecordTemplate = new T();

			// Make the template row have data already calculated
			NewRecordTemplate.Navigation = UserContext.Current.CurrentNavigation;
			NewRecordTemplate.NewLoad();

			Elements = new List<T>();

			EditedElements = new List<T>();
			NewElements = new List<T>();
			RemovedElements = new List<string>();
		}

		public void Save()
		{
			var result = StatusMessage.GetAggregator();

			// 1. Delete rows marked to be deleted
			foreach (string pk in RemovedElements)
			{
				try
				{
					T model = new T();
					model.Destroy(pk);
				}
				catch (BusinessException e)
				{
					result.MergeStatusMessage(StatusMessage.Error(e.UserMessage, string.Format("RemovedElements[{0}]", RemovedElements.IndexOf(pk))));
				}
			}

			// 2. Save edited rows
			foreach (T model in EditedElements)
			{
				try
				{
					model.Save();
				}
				catch (FieldValidationException fvExc)
				{
					foreach (var message in fvExc.StatusMessage.GetErrorList())
						result.MergeStatusMessage(StatusMessage.Error(message.PrintMessages(), string.Format("EditedElements[{0}]", NewElements.IndexOf(model))));
				}
				catch (BusinessException e)
				{
					result.MergeStatusMessage(StatusMessage.Error(e.UserMessage, string.Format("EditedElements[{0}]", NewElements.IndexOf(model))));
				}
			}

			// 3. Insert new rows
			foreach (T model in NewElements)
			{
				try
				{
					// Navigation is needed to load keys from history
					model.Navigation = UserContext.Current.CurrentNavigation;
					// Add the primary key
					model.New();
					model.Save();
				}
				catch (FieldValidationException fvExc)
				{
					foreach (var message in fvExc.StatusMessage.GetErrorList())
						result.MergeStatusMessage(StatusMessage.Error(message.PrintMessages(), string.Format("NewElements[{0}]", NewElements.IndexOf(model))));
				}
				catch (BusinessException e)
				{
					result.MergeStatusMessage(StatusMessage.Error(e.UserMessage, string.Format("NewElements[{0}]", NewElements.IndexOf(model))));
				}
			}

			if (result.Status != Status.OK)
				throw new FieldValidationException(result, "Grid table list - Save");
		}
	}
}
