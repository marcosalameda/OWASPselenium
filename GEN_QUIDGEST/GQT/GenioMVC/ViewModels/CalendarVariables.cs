using System;

using CSGenio.business;

namespace GenioMVC.ViewModels
{
	public class CalendarVariables
	{
		public string startDateField;
		public string endDateField;
		public string minTime;
		public string maxTime;
		public string allDayField;
		public string startTimeField;
		public string endTimeField;
		public string selectedDateField;
		public string validDateStart;
		public string validDateEnd;

		public bool isScheduler;
		public bool allDay;
		public bool noDates;
		public bool newEdit;
		public bool hasNewResource;
		public bool hasChildren;

		public string resourceId;
		public string dateTimeINI;
		public DateTime? selectedDate;

		public bool HasCalendarFields
		{
			get
			{
				return !string.IsNullOrWhiteSpace(startDateField) && !string.IsNullOrWhiteSpace(endDateField);
			}
		}

		public string DateMin
		{
			get
			{
				return (minTime ?? "00:00").Substring(0, 5);
			}
		}

		public string DateMax
		{
			get
			{
				return (maxTime ?? "23:59").Substring(0, 5);
			}
		}

		public DateTime? DateStart
		{
			get
			{
				if (selectedDate.HasValue)
					return allDay ? GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(selectedDate.Value), DateMin) : selectedDate.Value;
				return null;
			}
		}

		public DateTime? DateEnd
		{
			get
			{
				if (selectedDate.HasValue)
					return allDay ? GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(selectedDate.Value), DateMax) : selectedDate.Value;
				return null;
			}
		}
	}
}
