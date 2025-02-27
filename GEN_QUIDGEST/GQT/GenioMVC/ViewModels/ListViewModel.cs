using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models.Navigation;
using Newtonsoft.Json;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

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

    public abstract class ListViewModel : ViewModelBase
    {
        private Models.Glob _globTable;
        private List<CSGenioAlstren> _userViewModes;
        protected List<CSGenioAlstcol> userColumns;

        /// <summary>
        /// Gets a reference to the GLOB table
        /// to provide access to the necessary fields
        /// to client and server-side formulas.
        /// </summary>
        public override Models.Glob TGlob
        {
            get
            {
                if (_globTable == null)
                    _globTable = Models.Glob.GetGlob(false, this?.FieldsToSerialize);

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

        /// <summary>
        /// Gets the list of fields to serialize.
        /// </summary>
        abstract protected string[] FieldsToSerialize { get; }

        /// <summary>
        /// Gets the searchable columns.
        /// </summary>
        abstract protected List<TableSearchColumn> SearchableColumns { get; }
		
		/// <summary>
		/// Gets the tables limits that are always applied.
		/// </summary>
		abstract public CriteriaSet StaticLimits { get; }

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
        /// Gets the configuration of the view modes of the list.
        /// </summary>
        virtual public SpecialRenderingsCfg ViewModesCfg { get => null; }

        /// <summary>
        /// Whether or not the TGlob property should be serialized.
        /// </summary>
        public override bool ShouldSerializeTGlob()
        {
            return this?.FieldsToSerialize != null
                && this.FieldsToSerialize.Contains("Glob");
        }

        /// <summary>
        /// Gets the user column configuration.
        /// </summary>
        public List<CSGenioAlstcol> UserColumns
        {
            get => userColumns;
        }

        /// <summary>
        /// Gets or sets the table limits.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public List<Limit> tableLimits { get; set; }

        /// <summary>
        /// Gets or sets the data to display the table limits.
        /// </summary>
        public List<LimitDisplayData> tableLimitsDisplayData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewModel" /> class.
        /// </summary>
        /// <param name="current_navigation">The current navigation</param>
        public ListViewModel(NavigationContext current_navigation)
        {
            Navigation = current_navigation;
        }
		
		/// <summary>
		/// Applies manual code to change the static limits property
		/// </summary>
		public virtual CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
			return crs;
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

            string userLanguage = Models.Navigation.UserContext.Current.User.Language;
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;

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
                    if (
                        limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "minLim")
                    )
                    {
                        string minLimValue = limit.AreaLimita.Fields[
                            limit.AreaLimita.Alias + "." + "minLim"
                        ].ToString();

                        limitDisplayData.ValueMin = GenioMVC.Models.AuditModel.GetHumanValue(
                            sp,
                            limit.AreaLimita.Information,
                            limit.CampoLimita,
                            minLimValue
                        );
                    }

                    // Between dates (max).
                    if (
                        limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "maxLim")
                    )
                    {
                        string maxLimValue = limit.AreaLimita.Fields[
                            limit.AreaLimita.Alias + "." + "maxLim"
                        ].ToString();

                        limitDisplayData.ValueMax = GenioMVC.Models.AuditModel.GetHumanValue(
                            sp,
                            limit.AreaLimita.Information,
                            limit.CampoLimita,
                            maxLimValue
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
                            FieldValue
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
            var userColumns = TableUiSettingsDbRec
                .Load(UserContext.Current.PersistentSupport, Uuid, UserContext.Current.User)
                .UserColumns;

            return SearchableColumns.Where(tsc => IsColumnVisible(tsc, userColumns)).ToList();
        }

        /// <summary>
        /// Loads the user view modes.
        /// </summary>
        public void LoadUserViewModes()
        {
            if (_userViewModes == null)
            {
                _userViewModes = TableUiSettingsDbRec.Load(
                    UserContext.Current.PersistentSupport,
                    Uuid,
                    UserContext.Current.User
                ).UserRenderings;
            }
        }

        /// <summary>
        /// Determines whether the user view mode configuration is up-to-date
        /// with the latest definition.
        /// </summary>
        private bool UserCfgIsUpToDate()
        {
            if (ViewModesCfg == null || _userViewModes.Count != ViewModesCfg.SpecialRenderings.Count)
                return false;

            return _userViewModes.All(u => ViewModesCfg.SpecialRenderings.Any(c => c.Id == u.ValRenderizacao));
        }

        /// <summary>
        /// Gets the relative position of the view mode
        /// with the provided id.
        /// <param name="id">The view mode identifier</param>
        /// </summary>
        public int GetViewModePosition(string render)
        {
            LoadUserViewModes();

            // check if user configuration exists
            if (_userViewModes != null)
            {
                // check if the configuration is up to date
                if (UserCfgIsUpToDate())
                {
                    // uses what is defined in LSTREN
                    CSGenioAlstren cfg = _userViewModes.FirstOrDefault(r => r.ValRenderizacao == render);

                    if (cfg != null)
                        return (int)cfg.ValPosicao;
                }
                else
                {
                    // TODO: if the config is not up to date it should be deleted
                }
            }

            // uses the default settings
            SpecialRendering specialRendering = ViewModesCfg.SpecialRenderings
                .FirstOrDefault(s => s.Id == render);

            if (specialRendering != null)
                return specialRendering.Ordem;
            return -1;
        }

        /// <summary>
        /// Gets whether the view mode with the provided id
        /// should be displayed or not.
        /// <param name="id">The view mode identifier</param>
        /// </summary>
        public bool IsViewModeHidden(string render)
        {
            LoadUserViewModes();

            // check if user configuration exists
            if (_userViewModes != null)
            {
                // check if the configuration is up to date
                if (UserCfgIsUpToDate())
                {
                    // uses what is defined in LSTREN
                    CSGenioAlstren cfg = _userViewModes.FirstOrDefault(r => r.ValRenderizacao == render);

                    if (cfg != null)
                        return cfg.ValVisivel != 1;
                }
                else
                {
                    // TODO: if the config is not up to date it should be deleted
                }
            }

            // default setting: the first view mode is the one visible by default
            SpecialRendering firstVisibleByDefault = ViewModesCfg?.SpecialRenderings?.FirstOrDefault();
            return firstVisibleByDefault != null && firstVisibleByDefault.Id != render;
        }

        /// <summary>
        /// Gets the list of columns to export.
        /// </summary>
        /// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
        public abstract List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false);

        /// <summary>
        /// Builds the list CriteriaSet with all the limits, filters and conditions
        /// </summary>
        /// <param name="requestValues">Table filters</param>
        /// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
        /// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
        /// <param name="isToExport">If the  table is to be exported</param>
        public abstract CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false);
    }
}
