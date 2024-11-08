using System.Collections.Specialized;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public abstract class FormViewModel<T> : CrudViewModel<T> where T : ModelBase, new()
	{
		protected FormViewModel() : base() { }

		protected FormViewModel(string identifier) : base(identifier) { }

		protected FormViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base(currentNavigation, nestedForm) { }

		protected FormViewModel(string identifier, NavigationContext currentNavigation, bool nestedForm = false) : base(identifier, currentNavigation, nestedForm) { }

		protected FormViewModel(string identifier, T row, NavigationContext currentNavigation, bool nestedForm = false) : base(identifier, row, currentNavigation, nestedForm) { }

		public override StatusMessage CheckPermissions(FormMode mode)
		{
			if (Model == null)
				Model = new T() { Identifier = Identifier };
			if (mode.Equals(FormMode.Edit) || mode.Equals(FormMode.Delete))
				MapToModel(Model);
			return base.CheckPermissions(Model, mode);
		}

		public override void Apply()
		{
			MapToModel(Model);

			var result = EvaluateWriteConditions(isApply: true);
			if (result.Status != Status.OK)
				this.flashMessage = result;
			if (result.Status == Status.E)
				throw new FieldValidationException(result, "apply");

			Model.Apply();
			MapFromModel(Model);
		}

		public override void Save()
		{
			var backupFields = Model.BackupAgregationFields();
			MapToModel(Model);
			Model.MergeFields(backupFields);

			// Write conditions
			if (HasWriteConditions)
			{
				StatusMessage result, formResult = new StatusMessage(), tblResult = new StatusMessage();
				result = EvaluateWriteConditions(isApply: false); // Comes from form conditions
				formResult.Clone(result);

				if (result.Status == Status.E)
					throw new FieldValidationException(result, string.Format("{0}.Save", Identifier));

				result = result.MergeStatusMessage(Model.Save()); // Comes from table conditions
				tblResult.Clone(result);

				// In case both tbl and form have conditions, show the form only
				if (formResult.Status == Status.OK && tblResult.Status == Status.OK)
				{
					if (!string.IsNullOrEmpty(formResult.Message))
					{
						this.flashMessage = formResult;
						return;
					}
				}

				this.flashMessage = result;
			}
			else
				this.flashMessage = Model.Save();
		}

		// Creates the pseudo-new record in the database (zzstate=1)
		public override void New()
		{
			editable = true;
			Model = new T();
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
			Model.New(Identifier);
			// Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
			MapFromModel(Model);
		}

		// Loads all the information needed to present the form in insert mode
		public override void NewLoad()
		{
			this.LoadPartial(new NameValueCollection());

			// After the interface contextual fill, we give a last chance for the row to update internal formulas
			if (Model == null) // To não perder o Qvalue do ZZState executa inicialização do Model só quando o objeto está vazio.
				Model = new T() { Identifier = Identifier };
			MapToModel(Model);
			// Fill in the event fields inserted by the calendar control
			LoadCalendarValues();
			// Fill in default values
			Model.baseklass.fillValuesDefault(UserContext.Current.PersistentSupport, FunctionType.INS);
			LoadDefaultValues();
			// Preencher operações internas
			Model.baseklass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
			MapFromModel(Model);
		}

		public override void Duplicate(string id)
		{
			this.editable = true;
			Model = new T() { Identifier = Identifier };
			Model.Duplicate(id);
			Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
			LoadDefaultValues();
			MapFromModel(Model);
			this.LoadPartial(new NameValueCollection());
		}

		// Fill in the event fields inserted by the calendar control
		private void LoadCalendarValues()
		{
			try
			{
				var json = Navigation.GetStrValue("CalendarOptions", true);
				if (!string.IsNullOrWhiteSpace(json))
				{
					var options = Newtonsoft.Json.JsonConvert.DeserializeObject<CalendarVariables>(json);
					if (options != null/* && this.IsInsideCalendar*/ && options.HasCalendarFields)
					{
						if (!string.IsNullOrWhiteSpace(options.startDateField))
							Model.baseklass.insertNameValueField(options.startDateField.ToLower(), options.DateStart);
						if (!string.IsNullOrWhiteSpace(options.endDateField))
							Model.baseklass.insertNameValueField(options.endDateField.ToLower(), options.DateEnd);
						if (!string.IsNullOrWhiteSpace(options.allDayField))
							Model.baseklass.insertNameValueField(options.allDayField.ToLower(), options.allDay ? 1 : 0);

						// Start and Ending Times
						// http://jenkinsvm/geniodoc/patterns/interface/custom-controls/fullcalendar/extra-options/nodates/nodates-starting-time
						if (!string.IsNullOrWhiteSpace(options.startTimeField))
							Model.baseklass.insertNameValueField(options.startTimeField.ToLower(), options.minTime);
						if (!string.IsNullOrWhiteSpace(options.endTimeField))
							Model.baseklass.insertNameValueField(options.endTimeField.ToLower(), options.maxTime);
						if (!string.IsNullOrWhiteSpace(options.selectedDateField))
							Model.baseklass.insertNameValueField(options.selectedDateField.ToLower(), options.selectedDate);
					}
					// Remove the history entry after it has already been used.
					Navigation.ClearValue("CalendarOptions", true);
				}

			}
			catch (System.Exception e)
			{
				Log.Error("LoadCalendarValues: " + e.Message);
			}
		}
	}
}
