using System.Collections.Generic;
using System.Collections.Specialized;

using CSGenio.framework;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.ViewModels
{
	/// <summary>
	/// Represents an interface for a CRUD ViewModel.
	/// </summary>
	public interface ICrudViewModel : IViewModel
	{
		// Interface Properties

		/// <summary>
		/// Gets the primary key used for querying the ViewModel data.
		/// </summary>
		string QPrimaryKey { get; }

		/// <summary>
		/// Gets the navigation context, providing information about the current navigation state.
		/// </summary>
		NavigationContext Navigation { get; }

		/// <summary>
		/// Indicates whether the ViewModel has write conditions, determining if modifications are allowed.
		/// </summary>
		bool HasWriteConditions { get; }

		// Interface Methods

		/// <summary>
		/// Initializes the CRUD ViewModel with the provided user context.
		/// </summary>
		/// <param name="userContext">The user context for initializing the ViewModel.</param>
		void Init(UserContext userContext);

		/// <summary>
		/// Validates the state of the CRUD ViewModel, checking for any broken validation rules.
		/// </summary>
		/// <returns>A result object containing information about the validation status.</returns>
		CrudViewModelValidationResult Validate();

		/// <summary>
		/// Saves the changes made to the ViewModel.
		/// </summary>
		void Save();

		/// <summary>
		/// Applies any pending changes to the ViewModel.
		/// </summary>
		void Apply();

		/// <summary>
		/// Creates a duplicate of the ViewModel with the specified identifier.
		/// </summary>
		/// <param name="id">The identifier of the ViewModel to duplicate.</param>
		void Duplicate(string id);

		/// <summary>
		/// Destroys the ViewModel, removing it from the system.
		/// </summary>
		void Destroy();

		/// <summary>
		/// Destroys the ViewModel with the specified identifier, removing it from the system.
		/// </summary>
		/// <param name="id">The identifier of the ViewModel to destroy.</param>
		void Destroy(string id);

		/// <summary>
		/// Initializes the ViewModel for creating a new instance.
		/// </summary>
		void New();

		/// <summary>
		/// Loads data into the ViewModel.
		/// </summary>
		void Load();

		/// <summary>
		/// Loads data into the ViewModel based on the provided query string, editable status, and additional parameters.
		/// </summary>
		/// <param name="qs">The query string parameters for loading data.</param>
		/// <param name="editable">Specifies whether the ViewModel should be loaded in an editable state.</param>
		/// <param name="ajaxRequest">Indicates whether the request is an AJAX request.</param>
		/// <param name="lazyLoad">Specifies whether lazy loading should be applied.</param>
		void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false);

		/// <summary>
		/// Loads partial data into the ViewModel based on the provided query string and lazy loading option.
		/// </summary>
		/// <param name="qs">The query string parameters for loading data.</param>
		/// <param name="lazyLoad">Specifies whether lazy loading should be applied.</param>
		void LoadPartial(NameValueCollection qs, bool lazyLoad = false);

		/// <summary>
		/// Initializes the ViewModel for creating a new instance and loads data.
		/// </summary>
		void NewLoad();

		/// <summary>
		/// Maps data from the underlying data model to the ViewModel.
		/// </summary>
		void MapFromModel();

		/// <summary>
		/// Displays conditions relevant to the current view.
		/// </summary>
		/// <returns>A status message containing information about view conditions.</returns>
		StatusMessage ViewConditions();

		/// <summary>
		/// Displays conditions relevant to inserting data into the ViewModel.
		/// </summary>
		/// <returns>A status message containing information about insert conditions.</returns>
		StatusMessage InsertConditions();

		/// <summary>
		/// Displays conditions relevant to updating data in the ViewModel.
		/// </summary>
		/// <returns>A status message containing information about update conditions.</returns>
		StatusMessage UpdateConditions();

		/// <summary>
		/// Displays conditions relevant to deleting data from the ViewModel.
		/// </summary>
		/// <returns>A status message containing information about delete conditions.</returns>
		StatusMessage DeleteConditions();

		/// <summary>
		/// Loads global data into the ViewModel based on the provided query string, editable status, and additional parameters.
		/// </summary>
		/// <param name="qs">The query string parameters for loading data.</param>
		/// <param name="editable">Specifies whether the ViewModel should be loaded in an editable state.</param>
		/// <param name="ajaxRequest">Indicates whether the request is an AJAX request.</param>
		void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false);
	}


	public abstract class CrudViewModel<T> : ViewModelBase, ICrudViewModel where T : Models.ModelBase
	{
		/// <summary>
		/// The model
		/// </summary>
		protected T Model;

		/// <summary>
		/// Allocates a new empty ModelBase of the correct type
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
        public T CreateModelBase()
        {
            return Activator.CreateInstance(typeof(T), m_userContext, false, null) as T ?? throw new InvalidOperationException("Failed to create ModelBase of type " + typeof(T));
        }

		/// <summary>
		/// The model's queue list property
		/// </summary>
		[JsonIgnore]
		public List<string> GetQueueList
		{
			get
			{
				List<string> queueList = new List<string>();

				if (Model?.baseklass?.Information?.QueuesList != null)
					foreach (var item in Model.baseklass.Information.QueuesList)
						queueList.Add(item.Name);

				return queueList;
			}
		}

		public string QPrimaryKey { get => Model?.baseklass.QPrimaryKey; }

		public IDictionary<string, object> ExtraProperties { get; private set; }

		protected CrudViewModel(UserContext userContext, string? identifier = null, bool nestedForm = false) : base(userContext)
		{
			ExtraProperties = new Dictionary<string, object>();
			InitLevels();
			// Fill the values that can already be filled (those that don't depend on the model).
			FillExtraProperties();
			Identifier = identifier;
			NestedForm = nestedForm;
		}

		protected CrudViewModel(UserContext userContext, string identifier, T row, bool nestedForm = false) : this(userContext, identifier, nestedForm)
		{
			if (row == null)
				throw new ModelNotFoundException("Model not found");
			Model = row;
			InitModel();
		}

		protected void InitModel(NameValueCollection qs = null, bool lazyLoad = false, bool loadDocuments = true)
		{
			if (Model == null)
				return;

			Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
			MapFromModel(Model);
			if (loadDocuments)
				LoadDocumentsProperties(Model);
				
			// Here we already have access to the model, so we can fill the remaining values.
			FillExtraProperties();
			LoadPartial(qs ?? new NameValueCollection(), lazyLoad);
		}

		/// <summary>
		/// Fills the ExtraProperties dictionary with any additional values that might be necessary
		/// </summary>
		protected virtual void FillExtraProperties() { /* Method intentionally left empty. */ }

		public void Load()
		{
			Load(new NameValueCollection(), false, false);
		}

		public void Destroy()
		{
			Destroy(QPrimaryKey);
		}

		public void MapFromModel()
		{
			MapFromModel(Model);
		}

		[JsonIgnore]
		public abstract bool HasWriteConditions { get; }

		[JsonIgnore]
		public bool editable { get; set; }

		[JsonIgnore]
		public List<string> Characs { get; set; }

		public abstract CrudViewModelValidationResult Validate();

		public abstract void Save();

		public abstract void Apply();

		public abstract void Duplicate(string id);

		public abstract void Destroy(string id);

		public abstract void New();

		public abstract void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false);

		public abstract void LoadPartial(NameValueCollection qs, bool lazyLoad = false);

		public abstract void NewLoad();

		// Mapping must be implemented by the subclass
		public abstract void MapFromModel(T model);

		public abstract void MapToModel(T model);

		public abstract StatusMessage ViewConditions();

		public abstract StatusMessage InsertConditions();

		public abstract StatusMessage UpdateConditions();

		public abstract StatusMessage DeleteConditions();

		protected abstract void InitLevels();

		protected abstract void LoadDefaultValues();

		protected abstract void LoadDocumentsProperties(T model);

		protected abstract StatusMessage EvaluateWriteConditions(bool isApply);

		public virtual void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false) { }

		[JsonIgnore]
		public bool IsInsideCalendar { get; set; }

		[JsonIgnore]
		public CalendarVariables CalendarOptions { get; set; }

		public void UpdateCalendarOptions()
		{
			var startDateField = Navigation.GetStrValue("startDateField");
			var endDateField = Navigation.GetStrValue("endDateField");
			IsInsideCalendar = (startDateField != "" && endDateField != "");

			var minTime = Navigation.GetStrValue("minTime").Substring(0, 5);
			var maxTime = Navigation.GetStrValue("maxTime").Substring(0, 5);

			var allDayField = Navigation.GetStrValue("allDayField");
			var startTimeField = Navigation.GetStrValue("startTimeField");
			var endTimeField = Navigation.GetStrValue("endTimeField");

			var validDateStart = Navigation.GetStrValue("validDateStart");
			var validDateEnd = Navigation.GetStrValue("validDateEnd");

			CalendarOptions = new CalendarVariables()
			{
				startDateField = startDateField,
				endDateField = endDateField,
				minTime = minTime,
				maxTime = maxTime,
				allDayField = allDayField,
				startTimeField = startTimeField,
				endTimeField = endTimeField,
				validDateStart = validDateStart,
				validDateEnd = validDateEnd
			};
		}
	}
}
