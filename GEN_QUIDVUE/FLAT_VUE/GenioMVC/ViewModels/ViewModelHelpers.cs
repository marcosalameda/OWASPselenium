using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

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
		[JsonIgnore]
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
			this.Distincts = new Dictionary<string, SelectList>();
			this.Elements = new List<A>();
			this.Pagination = new TablePagination(1, 0, false, false, 0);
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

	public class TableDBEdit<A> : TablePartial<A>
	{
		public SelectList List { get; set; }

		public string Selected { get; set; }

		public object Value { get; set; }

		public bool FilledByHistory { get; set; }

		[JsonPropertyName("HasMore")]
		public bool _HasMore { get { return base.HasMore(); } }

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
		public TableFiltering() { }

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

	public class GridTableList<T> : TablePartial<T> where T: class, ICrudViewModel
	{
		private UserContext m_userContext;

		public override IEnumerable<T> Elements { get; set; }

		public List<T> NewElements { get; set; }

		public List<T> EditedElements { get; set; }

		public List<string> RemovedElements { get; set; }

		public T NewRecordTemplate { get; set; }

		public T CreateModelBase()
		{
			return Activator.CreateInstance(typeof(T), m_userContext, false) as T ?? throw new InvalidOperationException("Failed to create ModelBase of type " + typeof(T));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public GridTableList() { }

		public void Init(UserContext userContext)
		{
			m_userContext = userContext;
			foreach(var e in NewElements)
				e.Init(userContext);
			foreach (var e in EditedElements)
				e.Init(userContext);
		}

		public GridTableList(UserContext userContext)
		{
			m_userContext = userContext;
			NewRecordTemplate = CreateModelBase();

			// Make the template row have data already calculated
			NewRecordTemplate.NewLoad();

			Elements = new List<T>();

			EditedElements = new List<T>();
			NewElements = new List<T>();
			RemovedElements = new List<string>();
		}

		/// <summary>
		/// Validates the elements within the editable table list.
		/// </summary>
		/// <remarks>
		/// This method iterates through both the edited and new elements, invoking the Validate method on each individual
		/// element of type T. The validation results are then merged into a single <see cref="CrudViewModelValidationResult"/>.
		/// </remarks>
		/// <returns>
		/// A <see cref="CrudViewModelValidationResult"/> containing the consolidated validation results for all elements
		/// within the editable table list.
		/// </returns>
		public CrudViewModelValidationResult Validate()
		{
			CrudViewModelValidationResult result = new();

			for (int i = 0; i < EditedElements.Count; i++)
			{
				var model = EditedElements[i];
				var partialResult = model.Validate();
				result.Merge(partialResult, $"EditedElements[{i}]");
			}

			for (int i = 0; i < NewElements.Count; i++)
			{
				var model = NewElements[i];
				var partialResult = model.Validate();
				result.Merge(partialResult, $"NewElements[{i}]");
			}

			return result;
		}

		public void Save()
		{
			var result = StatusMessage.GetAggregator();

			// 1. Delete rows marked to be deleted
			foreach (string pk in RemovedElements)
			{
				try
				{
					T model = CreateModelBase();
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

	// New properties added here will need to be accounted for in ImageModelJsonConverter.
	public class ImageModel
	{
		[JsonPropertyName("data")]
		public string Data { get; set; }

		[JsonPropertyName("dataFormat")]
		public string DataFormat { get; set; }

		[JsonPropertyName("fileName")]
		public string FileName { get; set; }

		[JsonPropertyName("encoding")]
		public string Encoding { get; set; } = "base64";
	}
}
