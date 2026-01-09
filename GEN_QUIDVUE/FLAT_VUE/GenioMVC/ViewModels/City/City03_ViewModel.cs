using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.City
{
	public class City03_ViewModel : FormViewModel<Models.City>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodctry { get; set; }

		#endregion
		/// <summary>
		/// Title: "Cidade" | Type: "C"
		/// </summary>
		public string ValCity { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Ctry> TableCtryCountry { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodcity { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public City03_ViewModel() : base(null!) { }

		public City03_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCITY03", nestedForm) { }

		public City03_ViewModel(UserContext userContext, Models.City row, bool nestedForm = false) : base(userContext, "FCITY03", row, nestedForm) { }

		public City03_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("city", id);
			Model = Models.City.Find(id, userContext, "FCITY03", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.City model = new Models.City(userContext) { Identifier = "FCITY03" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCITY03");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.City m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (City) to ViewModel (City03) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodctry = ViewModelConversion.ToString(m.ValCodctry);
				ValCity = ViewModelConversion.ToString(m.ValCity);
				ValCodcity = ViewModelConversion.ToString(m.ValCodcity);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (City) to ViewModel (City03) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.City m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (City03) to Model (City) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodctry = ViewModelConversion.ToString(ValCodctry);
				m.ValCity = ViewModelConversion.ToString(ValCity);
				m.ValCodcity = ViewModelConversion.ToString(ValCodcity);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (City03) to Model (City) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "city.codctry":
						this.ValCodctry = ViewModelConversion.ToString(_value);
						break;
					case "city.city":
						this.ValCity = ViewModelConversion.ToString(_value);
						break;
					case "city.codcity":
						this.ValCodcity = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (City03) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (City03)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.City.Find(id ?? Navigation.GetStrValue("city"), m_userContext, "FCITY03"); }
			finally { Model ??= new Models.City(m_userContext) { Identifier = "FCITY03" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.City.Find(Navigation.GetStrValue("city"), m_userContext, "FCITY03");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FCITY03";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.City row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.City.Find(Navigation.GetStrValue("city"), m_userContext, "FCITY03");
				if (Model == null)
				{
					Model = new Models.City(m_userContext) { Identifier = "FCITY03" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("city");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_City03__ctry_country_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CITY03]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CITY03]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValCity", Resources.Resources.CIDADE42080, ValCity, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE CITY03]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CITY03]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CITY03]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CITY03]/
		public override void Destroy(string id)
		{
			Model = Models.City.Find(id, m_userContext, "FCITY03");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableCtryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_City03__ctry_country_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool city03__ctry_country_DoLoad = true;
			CriteriaSet city03__ctry_country_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("ctry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					city03__ctry_country_Conds.Equal(CSGenioActry.FldCodctry, hValue);
					this.ValCodctry = DBConversion.ToString(hValue);
				}
			}

			TableCtryCountry = new TableDBEdit<Models.Ctry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_ctry") != null)
				{
					this.ValCodctry = Navigation.GetStrValue("RETURN_ctry");
					Navigation.CurrentLevel.SetEntry("RETURN_ctry", null);
				}
				FillDependant_City03TableCtryCountry(lazyLoad);
				return;
			}

			if (city03__ctry_country_DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCtryCountry, "sTableCtryCountry", "dTableCtryCountry", qs, "ctry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioActry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCtryCountry_tableFilters"]))
					TableCtryCountry.TableFilters = bool.Parse(qs["TableCtryCountry_tableFilters"]);
				else
					TableCtryCountry.TableFilters = false;

				query = qs["qTableCtryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioActry.FldCountry, query + "%");
				}
				city03__ctry_country_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCtryCountry"] != null ? qs["pTableCtryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioActry.FldCodctry, CSGenioActry.FldCountry, CSGenioActry.FldZzstate };

// USE /[MANUAL GQT OVERRQ CITY03_CTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("ctry", FormMode.New) || Navigation.checkFormMode("ctry", FormMode.Duplicate))
					city03__ctry_country_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioActry.FldZzstate, 0)
						.Equal(CSGenioActry.FldCodctry, Navigation.GetStrValue("ctry")));
				else
					city03__ctry_country_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioActry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("ctry", "country");
				ListingMVC<CSGenioActry> listing = Models.ModelBase.Where<CSGenioActry>(m_userContext, false, city03__ctry_country_Conds, fields, offset, numberItems, sorts, "LED_CITY03__CTRY_COUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCtryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCtryCountry.Query = query;
				TableCtryCountry.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Ctry(m_userContext, r, true, _fieldsToSerialize_CITY03__CTRY_COUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_ctry") != null)
				{
					this.ValCodctry = Navigation.GetStrValue("RETURN_ctry");
					Navigation.CurrentLevel.SetEntry("RETURN_ctry", null);
				}

				TableCtryCountry.List = new SelectList(TableCtryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodctry,  x => x.ValCodctry == this.ValCodctry), "Value", "Text", this.ValCodctry);
				FillDependant_City03TableCtryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCtryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Ctry</param>
		public ConcurrentDictionary<string, object> GetDependant_City03TableCtryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioActry.FldCodctry, CSGenioActry.FldCountry];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioActry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioActry.FldCodctry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCtryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_City03TableCtryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_City03TableCtryCountry(this.ValCodctry);
			try
			{

				// Fill List fields
				this.ValCodctry = ViewModelConversion.ToString(row["ctry.codctry"]);
				TableCtryCountry.Value = (string)row["ctry.country"];
				if (GenFunctions.emptyG(this.ValCodctry) == 1)
				{
					this.ValCodctry = "";
					TableCtryCountry.Value = "";
					Navigation.ClearValue("ctry");
				}
				else if (lazyLoad)
				{
					TableCtryCountry.SetPagination(1, 0, false, false, 1);
					TableCtryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodctry),
							Text = Convert.ToString(TableCtryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodctry);
				}

				TableCtryCountry.Selected = this.ValCodctry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCtryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CITY03__CTRY_COUNTRY_ = ["Ctry", "Ctry.ValCodctry", "Ctry.ValZzstate", "Ctry.ValCountry"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"city.codctry" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"ctry.codctry" => ViewModelConversion.ToString(modelValue),
				"ctry.country" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CITY03]/

		#endregion
	}
}
