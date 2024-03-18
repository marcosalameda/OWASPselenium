using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels
{
	public enum TableViewsManagementMode
	{
		/// <summary>
		/// The user is not allowed to change the list in any way.
		/// </summary>
		None,

		/// <summary>
		/// The user is allowed to customize the table but the changes are not saved.
		/// </summary>
		NonPersistent,

		/// <summary>
		/// The user changes are automatically saved in a single user table configuration.
		/// </summary>
		PersistOne,

		/// <summary>
		/// The user can fully create and manage multiple table configurations.
		/// </summary>
		PersistMany
	}

	public abstract class ListViewModel : ViewModelBase, IConditionalSerializer
	{
		private Models.Glob _globTable;
		private readonly UserUiSettings _userUiSettings;

		protected List<CSGenioAlstcol> userColumns;

		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[ShouldSerialize("Glob")]
		public override Models.Glob TGlob
		{
			get
			{
				if (_globTable == null)
					_globTable = Models.Glob.GetGlob(m_userContext, false, this?.FieldsToSerialize);

				return _globTable;
			}
		}



		/// <summary>
		/// Gets the alias of the table.
		/// </summary>
		abstract public string TableAlias { get; }

		/// <summary>
		/// Gets the unique user interface descriptor.
		/// </summary>
		abstract public string Uuid { get; }

		public bool ShouldSerialize(string tag)
		{
			return FieldsToSerialize?.Contains(tag) ?? false;
		}

		/// <summary>
		/// Gets the list of fields to serialize.
		/// </summary>
		abstract protected string[] FieldsToSerialize { get; }

		/// <summary>
		/// Gets the searchable columns.
		/// </summary>
		abstract protected List<TableSearchColumn> SearchableColumns { get; }

		/// <summary>
		/// Gets the list base conditions.
		/// For row reordering.
		/// </summary>
		abstract public CriteriaSet baseConditions { get; }

		/// <summary>
		/// Gets the list of relations.
		/// For row reordering.
		/// </summary>
		abstract public List<Relation> relations { get; }

		/// <summary>
		/// Gets the user column configuration.
		/// </summary>
		[JsonIgnore]
		public List<CSGenioAlstcol> UserColumns
		{
			get => userColumns;
		}

		/// <summary>
		/// Gets or sets the table limits.
		/// </summary>
		[JsonIgnore]
		public List<Limit> tableLimits { get; set; }

		/// <summary>
		/// Gets or sets the data to display the table limits.
		/// </summary>
		public List<LimitDisplayData> tableLimitsDisplayData { get; set; }

		/// <summary>
		/// Gets the table views management mode.
		/// </summary>
		virtual protected TableViewsManagementMode ViewsManagementMode
		{
			get => TableViewsManagementMode.None;
		}

		/// <summary>
		/// Gets the selected user table configuration.
		/// </summary>
		public string UserTableConfig => _userUiSettings?.userTableConfigSelected;

		/// <summary>
		/// Gets the primary key of the selected user table configuration.
		/// </summary>
		public string UserTableConfigPK => _userUiSettings?.userTableConfigSelectedPk;

		/// <summary>
		/// Gets the name of the selected user table configuration.
		/// </summary>
		public string UserTableConfigName => _userUiSettings?.userTableConfigSelectedName;

		/// <summary>
		/// Gets the names of the user table configurations.
		/// </summary>
		public List<string> UserTableConfigNames => _userUiSettings?.userTableConfigNames;

		/// <summary>
		/// Gets the name of the default user table configuration.
		/// </summary>
		public string UserTableConfigNameDefault => _userUiSettings?.userTableConfigDefaultName;

		/// <summary>
		/// Gets the current table configuration. The current state which is not saved.
		/// </summary>
		public string CurrentTableConfig;

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public ListViewModel(UserContext userContext) : base(userContext)
		{
			if (ViewsManagementMode == TableViewsManagementMode.PersistOne ||
				ViewsManagementMode == TableViewsManagementMode.PersistMany)
			{
				_userUiSettings = UserUiSettings.Load(
					userContext.PersistentSupport,
					Uuid,
					userContext.User,
					Navigation.GetStrValue("UserTableConfigName"),
					Convert.ToBoolean(Navigation.GetValue("LoadBaseTable"))
				);
			}
		}

		/// <summary>
		/// Sets the table limits display property.
		/// </summary>
		protected void FillTableLimitsDisplayData()
		{
			// Nothing to do if table has no limits.
			if (this.tableLimits == null || this.tableLimits.Count < 1)
				return;

			this.tableLimitsDisplayData = new List<LimitDisplayData>();

			string userLanguage = m_userContext.User.Language;
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;

			// Iterate limits and set display data.
			foreach (Limit limit in this.tableLimits)
			{
				LimitDisplayData limitDisplayData = new LimitDisplayData();
				limitDisplayData.Type = Enum.GetName(typeof(LimitType), limit.TipoLimite);

				string Area = "",
					AreaPlural = "",
					Field = "",
					Value = "";

				FillAreaFieldDisplayData(
					limit.AreaLimita,
					limit.CampoLimita,
					ref Area,
					ref AreaPlural,
					ref Field,
					ref Value,
					TableAlias,
					userLanguage,
					sp
				);

				limitDisplayData.Area = Area;
				limitDisplayData.AreaPlural = AreaPlural;
				limitDisplayData.Field = Field;
				limitDisplayData.Value = Value;

				string AreaN = "",
					AreaNPlural = "",
					FieldN = "",
					ValueN = "";

				FillAreaFieldDisplayData(
					limit.AreaLimitaN,
					limit.CampoLimitaN,
					ref AreaN,
					ref AreaNPlural,
					ref FieldN,
					ref ValueN,
					TableAlias,
					userLanguage,
					sp
				);

				limitDisplayData.AreaN = AreaN;
				limitDisplayData.AreaNPlural = AreaNPlural;
				limitDisplayData.FieldN = FieldN;
				limitDisplayData.ValueN = ValueN;

				string AreaToCompare = "",
					AreaToComparePlural = "",
					FieldToCompare = "",
					ValueToCompare = "";

				FillAreaFieldDisplayData(
					limit.AreaComparar,
					limit.CampoComparar,
					ref AreaToCompare,
					ref AreaToComparePlural,
					ref FieldToCompare,
					ref ValueToCompare,
					TableAlias,
					userLanguage,
					sp
				);

				limitDisplayData.AreaToCompare = AreaToCompare;
				limitDisplayData.AreaToComparePlural = AreaToComparePlural;
				limitDisplayData.FieldToCompare = FieldToCompare;
				limitDisplayData.ValueToCompare = ValueToCompare;

				if (limit.AreaLimita != null)
				{
					// Between dates (min).
					if (limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "minLim"))
					{
						string minLimValue = limit.AreaLimita.Fields[
							limit.AreaLimita.Alias + "." + "minLim"
						].ToString();

						limitDisplayData.ValueMin = GenioMVC.Models.AuditModel.GetHumanValue(
							sp,
							limit.AreaLimita.Information,
							limit.CampoLimita,
							minLimValue,
							m_userContext.User.Language
						);
					}

					// Between dates (max).
					if (limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "maxLim"))
					{
						string maxLimValue = limit.AreaLimita.Fields[
							limit.AreaLimita.Alias + "." + "maxLim"
						].ToString();

						limitDisplayData.ValueMax = GenioMVC.Models.AuditModel.GetHumanValue(
							sp,
							limit.AreaLimita.Information,
							limit.CampoLimita,
							maxLimValue,
							m_userContext.User.Language
						);
					}
				}

				limitDisplayData.OperatorType = limit.TipoLimiteOperator ?? "";

				// OperatorThreshold for SU limit.
				switch (limit.TipoLimiteSU)
				{
					case OperationType.LESS:
						limitDisplayData.OperatorThreshold = "<";
						break;
					case OperationType.LESSEQUAL:
						limitDisplayData.OperatorThreshold = "<=";
						break;
					case OperationType.GREAT:
						limitDisplayData.OperatorThreshold = ">";
						break;
					case OperationType.GREATEQUAL:
						limitDisplayData.OperatorThreshold = ">=";
						break;
					case OperationType.DIFF:
						limitDisplayData.OperatorThreshold = "<>";
						break;
					case OperationType.EQUAL:
					default:
						limitDisplayData.OperatorThreshold = "=";
						break;
				}

				limitDisplayData.ManualHTMLText = limit.ManualHTMLText ?? "";
				limitDisplayData.ApplyOnlyIfExists = limit.NaoAplicaSeNulo.ToString();

				// Add limit data to array.
				this.tableLimitsDisplayData.Add(limitDisplayData);
			}
		}

		/// <summary>
		/// Fills the area field display data.
		/// </summary>
		/// <param name="LimitArea">The limit area.</param>
		/// <param name="LimitField">The limit field.</param>
		/// <param name="Area">The area.</param>
		/// <param name="AreaPlural">The area plural.</param>
		/// <param name="Field">The field.</param>
		/// <param name="Value">The value.</param>
		/// <param name="TableAlias">The table alias.</param>
		/// <param name="userLanguage">The user language.</param>
		/// <param name="sp">The persistent support.</param>
		private void FillAreaFieldDisplayData(
			CSGenio.business.Area LimitArea,
			Field LimitField,
			ref string Area,
			ref string AreaPlural,
			ref string Field,
			ref string Value,
			string TableAlias,
			string userLanguage,
			CSGenio.persistence.PersistentSupport sp
		)
		{
			if (LimitArea != null)
			{
				// Area
				if (LimitArea.Alias != TableAlias)
				{
					// Naming with translations
					string Designation = CSGenio.framework.Translations.Get(
						LimitArea.AreaDesignation,
						userLanguage
					);
					string PluralDesignation = CSGenio.framework.Translations.Get(
						LimitArea.AreaPluralDesignation,
						userLanguage
					);
					string Alias = CSGenio.framework.Translations.Get(
						LimitArea.Alias,
						userLanguage
					);

					Area = !string.IsNullOrEmpty(Designation) ? Designation : Alias;
					AreaPlural = !string.IsNullOrEmpty(PluralDesignation)
						? PluralDesignation
						: Alias;
				}

				// Field
				if (LimitField != null)
				{
					string FieldName = LimitField.Name;
					string[] HumanFields = LimitArea.Information.HumanKeyName.Split(',');

					if (
						FieldName != LimitArea.Information.PrimaryKeyName
						&& (!HumanFields.Contains(FieldName) || LimitArea.Alias == TableAlias)
					)
					{
						//Naming with Translations
						//CampoLimita
						string Description = CSGenio.framework.Translations.Get(
							LimitArea.DBFields[FieldName].FieldDescription,
							userLanguage
						);
						string Name = LimitArea.DBFields[FieldName].Name;

						Field = !string.IsNullOrEmpty(Description) ? Description : Name;
					}
					else if (
						LimitArea.Alias == TableAlias
						&& FieldName == LimitArea.Information.PrimaryKeyName
						&& CSGenio.business.GlobalFunctions.emptyC(
							LimitArea.Information.HumanKeyName
						) == 0
					) //special case
					{
						//Naming with Translations
						//CampoLimita (as humankey)
						string HumanKeyDescription = CSGenio.framework.Translations.Get(
							LimitArea.DBFields[
								LimitArea.Information.HumanKeyName.Split(',')[0]
							].FieldDescription,
							userLanguage
						);
						string HumanKeyName = LimitArea.DBFields[
							LimitArea.Information.HumanKeyName.Split(',')[0]
						].Name;

						Field = !string.IsNullOrEmpty(HumanKeyDescription)
							? HumanKeyDescription
							: HumanKeyName;
					}
					//Value
					if (LimitArea.Fields.ContainsKey(LimitArea.Alias + "." + FieldName))
					{
						string FieldValue = (
							(CSGenio.framework.RequestedField)
								LimitArea.Fields[LimitArea.Alias + "." + FieldName]
							).Value.ToString();

						Value = GenioMVC.Models.AuditModel.GetHumanValue(
							sp,
							LimitArea.Information,
							LimitField,
							FieldValue,
							m_userContext.User.Language
						);
					}
				}
			}
		}

		/// <summary>
		/// Gets the available search columns,
		/// with respect to the user column configuration.
		/// </summary>
		/// <param name="includeInvisibleFields">Whether to include invisible fields.</param>
		public List<TableSearchColumn> GetSearchColumns(bool includeInvisibleFields = false)
		{
			// If the user has some hidden columns we should not search in them
			if (includeInvisibleFields)
				return SearchableColumns;

			//JGF 2021.09.01 Moved this line nearer the usage, it was going to the server a lot needlessly
			var userColumns = UserUiSettings
				.Load(m_userContext.PersistentSupport, Uuid, m_userContext.User)
				.userColumns;

			return SearchableColumns.Where(tsc => IsColumnVisible(tsc, userColumns)).ToList();
		}

		/// <summary>
		/// Loads the user table configuration.
		/// </summary>
		/// <param name="requestValues">The request values.</param>
		/// <param name="allSortOrders">All sort orders.</param>
		/// <param name="requestPrefix">The request prefix.</param>
		/// <param name="numberListItems">The number of rows per page to load.</param>
		public void LoadUserTableConfig(
			NameValueCollection requestValues,
			Dictionary<string, OrderedDictionary> allSortOrders,
			string requestPrefix,
			ref int numberListItems
		)
		{
			string configDataStr;

			CurrentTableConfig = (string)Navigation.CurrentLevel.Location.RoutedValues["CurrentTableConfig_" + requestPrefix];

			if (!string.IsNullOrEmpty(CurrentTableConfig))
				configDataStr = CurrentTableConfig;
			else if (!string.IsNullOrEmpty(UserTableConfig))
				configDataStr = UserTableConfig;
			else
				return;

			// Deserialize configuration data into sub-configurations.
			var configData = JsonConvert.DeserializeObject<Dictionary<string, string>>(configDataStr);

			if (configData == null)
				return;

			// Get unsaved advanced filters and column filters
			string currentSearchFiltersDataStr = requestValues.Get("SearchFilters") ?? "";
			SearchFilter[] currentSearchFiltersData;
			try
			{
				currentSearchFiltersData = JsonConvert.DeserializeObject<SearchFilter[]>(currentSearchFiltersDataStr);
			}
			catch(Exception ex)
			{
				currentSearchFiltersData = new SearchFilter[0];
				Log.Error(ex.Message);
			}

			// Load filters if they are not loaded already.
			if (currentSearchFiltersData == null)
			{
				// Get filters sub-configurations.
				List<object> searchFiltersData = new List<object>();

				// Get and merge advanced filters sub-configuration (array).
				if (configData.ContainsKey("advancedFilters"))
				{
					List<object> advancedFiltersData = JsonConvert.DeserializeObject<List<object>>(
						configData["advancedFilters"]
					);

					foreach (var filter in advancedFiltersData)
						searchFiltersData.Add(filter);
				}

				// Get and merge column filters sub-configuration (hashtable).
				if (configData.ContainsKey("columnFilters"))
				{
					Dictionary<string, object> columnFiltersData = JsonConvert.DeserializeObject<
						Dictionary<string, object>
					>(configData["columnFilters"]);

					foreach (var filter in columnFiltersData)
						searchFiltersData.Add(filter.Value);
				}

				// Convert to string and set as query parameter.
				string searchFiltersStr = JsonConvert.SerializeObject(searchFiltersData);
				requestValues.Set("SearchFilters", searchFiltersStr);
			}

			// Get static filters
			if (configData.ContainsKey("groupFilterValues"))
			{
				Dictionary<string, string> groupFilterValuesData = JsonConvert.DeserializeObject<
						Dictionary<string, string>
				>(configData["groupFilterValues"]);

				foreach (var filter in groupFilterValuesData)
				{
					// If no filter value was set by the user, use the value from the saved configuration
					if (requestValues.Get(filter.Key) == null)
						requestValues.Set(filter.Key, filter.Value);
				}
			}

			// Load custom initial sort column and sort order.
			if (
				configData.ContainsKey("initialSortColumn")
				&& (
					string.IsNullOrEmpty(requestValues.Get($"s{requestPrefix}"))
					|| string.IsNullOrEmpty(requestValues.Get($"d{requestPrefix}"))
				)
			)
			{
				// Get initial sort sub-configuration.
				var configDataInitialSortColumn = JsonConvert.DeserializeObject<Dictionary<string, string>>(configData["initialSortColumn"]);

				if (
					configDataInitialSortColumn.ContainsKey("columnName")
					&& configDataInitialSortColumn.ContainsKey("sortOrder")
				)
				{
					string initialSortColumnName = configDataInitialSortColumn["columnName"];
					string initialSortColumnOrder = configDataInitialSortColumn["sortOrder"];

					if (
						!string.IsNullOrEmpty(initialSortColumnName)
						&& !string.IsNullOrEmpty(initialSortColumnOrder)
					)
					{
						string columnName = initialSortColumnName
							.Substring(initialSortColumnName.IndexOf("Val") + 3)
							.ToUpper();

						if (columnName.IndexOf(".") < 0)
							columnName = TableAlias.ToUpper() + "." + columnName;

						string sortOrder = initialSortColumnOrder.ToUpper().Substring(0, 1);

						if (sortOrder != "D")
							sortOrder = "A";

						allSortOrders.Clear();
						allSortOrders.Add(columnName, new OrderedDictionary());
						allSortOrders[columnName].Add(columnName, sortOrder);

						requestValues.Add($"s{requestPrefix}", initialSortColumnName);
						requestValues.Add($"d{requestPrefix}", sortOrder);
					}
				}
			}

			// Load number of records per page.
			if (configData.ContainsKey("perPage") && string.IsNullOrEmpty(requestValues.Get("perPage")))
			{
				int perPage = 0;
				bool isNumber = int.TryParse(configData["perPage"], out perPage);

				if (isNumber)
					numberListItems = perPage;
			}
		}

		/// <summary>
		/// Gets the list of columns to export.
		/// </summary>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		abstract public List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false);

		/// <summary>
		/// Counts the total number of records in the data underlying this list
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		abstract public int GetCount(User user);

		/// <summary>
		/// Instantiates a new ListViewModel given its name
		/// </summary>
		/// <param name="userContext">The current user context</param>
		/// <param name="controller">Base of the list</param>
		/// <param name="action">Id of the list</param>
		/// <returns>The instantiated ListViewModel</returns>
		public static ListViewModel CreateListViewModel(UserContext userContext, string controller, string action)
		{
			string viewmodelStr = string.Format("GenioMVC.ViewModels.{0}.{1}_ViewModel", controller, action);
			var viewmodelType = Type.GetType(viewmodelStr, false, true) ?? throw new InvalidOperationException($"Could not instantiate a ListViewModel for {controller}/{action}");
			var newViewmodel = Activator.CreateInstance(viewmodelType, userContext);
			return newViewmodel as ListViewModel ?? throw new InvalidOperationException($"Could not instantiate a ListViewModel for {controller}/{action}");
		}
	}
}
