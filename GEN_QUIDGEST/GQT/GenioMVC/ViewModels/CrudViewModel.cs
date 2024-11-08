using System.Collections.Generic;
using System.Collections.Specialized;

using CSGenio.framework;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public interface ICrudViewModel : IViewModel
	{
		// Interface Properties
		string QPrimaryKey { get; }

		NavigationContext Navigation { get; set; }

		bool HasWriteConditions { get; }

		// Interface Methods
		void Save();

		void Apply();

		void Duplicate(string id);

		void Destroy();

		void Destroy(string id);

		void New();

		void Load();

		void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false);

		void LoadPartial(NameValueCollection qs, bool lazyLoad = false);

		void NewLoad();

		void MapFromModel();

		StatusMessage ViewConditions();

		StatusMessage InsertConditions();

		StatusMessage UpdateConditions();

		StatusMessage DeleteConditions();

		void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false);
	}

	public abstract class CrudViewModel<T> : ViewModelBase, ICrudViewModel where T : Models.ModelBase, new()
	{
		/// <summary>
		/// The model
		/// </summary>
		protected T Model;

		/// <summary>
		/// The model's queue list property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
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

		protected CrudViewModel()
		{
			ExtraProperties = new Dictionary<string, object>();
			InitLevels();
			// Fill the values that can already be filled (those that don't depend on the model).
			FillExtraProperties();
		}

		protected CrudViewModel(string identifier) : this()
		{
			Identifier = identifier;
		}

		protected CrudViewModel(NavigationContext currentNavigation, bool nestedForm = false) : this()
		{
			this.NestedForm = nestedForm;
			this.Navigation = currentNavigation;
		}

		protected CrudViewModel(string identifier, NavigationContext currentNavigation, bool nestedForm = false) : this(identifier)
		{
			this.NestedForm = nestedForm;
			this.Navigation = currentNavigation;
		}

		protected CrudViewModel(string identifier, T row, NavigationContext currentNavigation, bool nestedForm = false) : this(identifier, currentNavigation, nestedForm)
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
			SanitizeContent();
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

		[Newtonsoft.Json.JsonIgnore]
		public abstract bool HasWriteConditions { get; }

		[Newtonsoft.Json.JsonIgnore]
		public bool editable { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public List<string> Characs { get; set; }

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

		[Newtonsoft.Json.JsonIgnore]
		public bool IsInsideCalendar { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public CalendarVariables CalendarOptions { get; set; }

		public void UpdateCalendarOptions()
		{
			Navigation = UserContext.Current.CurrentNavigation;
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
