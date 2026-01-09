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

namespace GenioMVC.ViewModels.Prope
{
	public class Prope08_ViewModel : FormViewModel<Models.Prope>, IPreparableForSerialization
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
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValCodagent { get; set; }
		/// <summary>
		/// Title: "Cidade" | Type: "CE"
		/// </summary>
		public string ValCodcity { get; set; }

		#endregion
		/// <summary>
		/// Title: "Foto principal" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(480, 10)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Price" | Type: "$D"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }
		/// <summary>
		/// Title: "Cidade" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.City> TableCityCity { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CityCtryValCountry 
		{
			get
			{
				return funcCityCtryValCountry != null ? funcCityCtryValCountry() : _auxCityCtryValCountry;
			}
			set { funcCityCtryValCountry = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCityCtryValCountry { get; set; }

		private string _auxCityCtryValCountry { get; set; }
		/// <summary>
		/// Title: "Tamanho (m2)" | Type: "ND"
		/// </summary>
		public decimal? ValSize { get; set; }
		/// <summary>
		/// Title: "Numero de Casa de banhos" | Type: "N"
		/// </summary>
		public decimal? ValBathrms { get; set; }
		/// <summary>
		/// Title: "Ano construído" | Type: "C"
		/// </summary>
		public string ValYear { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Agent> TableAgentName { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string AgentValEmail 
		{
			get
			{
				return funcAgentValEmail != null ? funcAgentValEmail() : _auxAgentValEmail;
			}
			set { funcAgentValEmail = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcAgentValEmail { get; set; }

		private string _auxAgentValEmail { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(480, 10)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel AgentValPhoto 
		{
			get
			{
				return funcAgentValPhoto != null ? funcAgentValPhoto() : _auxAgentValPhoto;
			}
			set { funcAgentValPhoto = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.Models.ImageModel> funcAgentValPhoto { get; set; }

		private GenioMVC.Models.ImageModel _auxAgentValPhoto { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodprope { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Prope08_ViewModel() : base(null!) { }

		public Prope08_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPROPE08", nestedForm) { }

		public Prope08_ViewModel(UserContext userContext, Models.Prope row, bool nestedForm = false) : base(userContext, "FPROPE08", row, nestedForm) { }

		public Prope08_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("prope", id);
			Model = Models.Prope.Find(id, userContext, "FPROPE08", fieldsToQuery: fieldsToLoad);
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
			Models.Prope model = new Models.Prope(userContext) { Identifier = "FPROPE08" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPROPE08");
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
		public override void MapFromModel(Models.Prope m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Prope) to ViewModel (Prope08) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodagent = ViewModelConversion.ToString(m.ValCodagent);
				ValCodcity = ViewModelConversion.ToString(m.ValCodcity);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValSize = ViewModelConversion.ToNumeric(m.ValSize);
				ValBathrms = ViewModelConversion.ToNumeric(m.ValBathrms);
				ValYear = ViewModelConversion.ToString(m.ValYear);
				funcAgentValEmail = () => ViewModelConversion.ToString(m.Agent.ValEmail);
				funcAgentValPhoto = () => ViewModelConversion.ToImage(m.Agent.ValPhoto);
				ValCodprope = ViewModelConversion.ToString(m.ValCodprope);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Prope) to ViewModel (Prope08) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Prope m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Prope08) to Model (Prope) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodagent = ViewModelConversion.ToString(ValCodagent);
				m.ValCodcity = ViewModelConversion.ToString(ValCodcity);
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValSize = ViewModelConversion.ToNumeric(ValSize);
				m.ValBathrms = ViewModelConversion.ToNumeric(ValBathrms);
				m.ValYear = ViewModelConversion.ToString(ValYear);
				m.ValCodprope = ViewModelConversion.ToString(ValCodprope);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Prope08) to Model (Prope) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "prope.codagent":
						this.ValCodagent = ViewModelConversion.ToString(_value);
						break;
					case "prope.codcity":
						this.ValCodcity = ViewModelConversion.ToString(_value);
						break;
					case "prope.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "prope.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "prope.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "prope.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "prope.size":
						this.ValSize = ViewModelConversion.ToNumeric(_value);
						break;
					case "prope.bathrms":
						this.ValBathrms = ViewModelConversion.ToNumeric(_value);
						break;
					case "prope.year":
						this.ValYear = ViewModelConversion.ToString(_value);
						break;
					case "prope.codprope":
						this.ValCodprope = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Prope08) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Prope08)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Prope.Find(id ?? Navigation.GetStrValue("prope"), m_userContext, "FPROPE08"); }
			finally { Model ??= new Models.Prope(m_userContext) { Identifier = "FPROPE08" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Prope.Find(Navigation.GetStrValue("prope"), m_userContext, "FPROPE08");
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

			Model.Identifier = "FPROPE08";
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

		protected override void LoadDocumentsProperties(Models.Prope row)
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
				Model = Models.Prope.Find(Navigation.GetStrValue("prope"), m_userContext, "FPROPE08");
				if (Model == null)
				{
					Model = new Models.Prope(m_userContext) { Identifier = "FPROPE08" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("prope");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Prope08_city_city____(qs, lazyLoad);
			Load_Prope08_agentname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROPE08]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROPE08]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);
			validator.StringLength("CityCtryValCountry", Resources.Resources.COUNTRY64133, CityCtryValCountry, 50);
			validator.StringLength("ValYear", Resources.Resources.ANO_CONSTRUIDO64369, ValYear, 50);
			validator.StringLength("AgentValEmail", Resources.Resources.EMAIL25170, AgentValEmail, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PROPE08]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROPE08]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROPE08]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROPE08]/
		public override void Destroy(string id)
		{
			Model = Models.Prope.Find(id, m_userContext, "FPROPE08");
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
		/// TableCityCity -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Prope08_city_city____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool prope08_city_city____DoLoad = true;
			CriteriaSet prope08_city_city____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("city", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					prope08_city_city____Conds.Equal(CSGenioAcity.FldCodcity, hValue);
					this.ValCodcity = DBConversion.ToString(hValue);
				}
			}

			TableCityCity = new TableDBEdit<Models.City>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}
				FillDependant_Prope08TableCityCity(lazyLoad);
				return;
			}

			if (prope08_city_city____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCityCity, "sTableCityCity", "dTableCityCity", qs, "city");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcity.FldCity), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCityCity_tableFilters"]))
					TableCityCity.TableFilters = bool.Parse(qs["TableCityCity_tableFilters"]);
				else
					TableCityCity.TableFilters = false;

				query = qs["qTableCityCity"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcity.FldCity, query + "%");
				}
				prope08_city_city____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCityCity"] != null ? qs["pTableCityCity"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcity.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPE08_CITYCITY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("city", FormMode.New) || Navigation.checkFormMode("city", FormMode.Duplicate))
					prope08_city_city____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcity.FldZzstate, 0)
						.Equal(CSGenioAcity.FldCodcity, Navigation.GetStrValue("city")));
				else
					prope08_city_city____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcity.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("city", "city");
				ListingMVC<CSGenioAcity> listing = Models.ModelBase.Where<CSGenioAcity>(m_userContext, false, prope08_city_city____Conds, fields, offset, numberItems, sorts, "LED_PROPE08_CITY_CITY____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCityCity.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCityCity.Query = query;
				TableCityCity.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.City(m_userContext, r, true, _fieldsToSerialize_PROPE08_CITY_CITY____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}

				TableCityCity.List = new SelectList(TableCityCity.Elements.ToSelectList(x => x.ValCity, x => x.ValCodcity,  x => x.ValCodcity == this.ValCodcity), "Value", "Text", this.ValCodcity);
				FillDependant_Prope08TableCityCity();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of City</param>
		public ConcurrentDictionary<string, object> GetDependant_Prope08TableCityCity(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioActry.FldCodctry, CSGenioActry.FldCountry];

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

			CSGenioAcity tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcity.FldCodcity, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Prope08TableCityCity(bool lazyLoad = false)
		{
			var row = GetDependant_Prope08TableCityCity(this.ValCodcity);
			try
			{
				this.funcCityCtryValCountry = () => (string)row["ctry.country"];

				// Fill List fields
				this.ValCodcity = ViewModelConversion.ToString(row["city.codcity"]);
				TableCityCity.Value = (string)row["city.city"];
				if (GenFunctions.emptyG(this.ValCodcity) == 1)
				{
					this.ValCodcity = "";
					TableCityCity.Value = "";
					Navigation.ClearValue("city");
				}
				else if (lazyLoad)
				{
					TableCityCity.SetPagination(1, 0, false, false, 1);
					TableCityCity.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcity),
							Text = Convert.ToString(TableCityCity.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcity);
				}

				TableCityCity.Selected = this.ValCodcity;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCityCity): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPE08_CITY_CITY____ = ["City", "City.ValCodcity", "City.ValZzstate", "City.ValCity"];

		/// <summary>
		/// TableAgentName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Prope08_agentname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool prope08_agentname____DoLoad = true;
			CriteriaSet prope08_agentname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("agent", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					prope08_agentname____Conds.Equal(CSGenioAagent.FldCodagent, hValue);
					this.ValCodagent = DBConversion.ToString(hValue);
				}
			}

			TableAgentName = new TableDBEdit<Models.Agent>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_agent") != null)
				{
					this.ValCodagent = Navigation.GetStrValue("RETURN_agent");
					Navigation.CurrentLevel.SetEntry("RETURN_agent", null);
				}
				FillDependant_Prope08TableAgentName(lazyLoad);
				return;
			}

			if (prope08_agentname____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableAgentName, "sTableAgentName", "dTableAgentName", qs, "agent");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAagent.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAgentName_tableFilters"]))
					TableAgentName.TableFilters = bool.Parse(qs["TableAgentName_tableFilters"]);
				else
					TableAgentName.TableFilters = false;

				query = qs["qTableAgentName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAagent.FldName, query + "%");
				}
				prope08_agentname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAgentName"] != null ? qs["pTableAgentName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAagent.FldCodagent, CSGenioAagent.FldName, CSGenioAagent.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPE08_AGENTNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("agent", FormMode.New) || Navigation.checkFormMode("agent", FormMode.Duplicate))
					prope08_agentname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAagent.FldZzstate, 0)
						.Equal(CSGenioAagent.FldCodagent, Navigation.GetStrValue("agent")));
				else
					prope08_agentname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAagent.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("agent", "name");
				ListingMVC<CSGenioAagent> listing = Models.ModelBase.Where<CSGenioAagent>(m_userContext, false, prope08_agentname____Conds, fields, offset, numberItems, sorts, "LED_PROPE08_AGENTNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAgentName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAgentName.Query = query;
				TableAgentName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Agent(m_userContext, r, true, _fieldsToSerialize_PROPE08_AGENTNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_agent") != null)
				{
					this.ValCodagent = Navigation.GetStrValue("RETURN_agent");
					Navigation.CurrentLevel.SetEntry("RETURN_agent", null);
				}

				TableAgentName.List = new SelectList(TableAgentName.Elements.ToSelectList(x => x.ValName, x => x.ValCodagent,  x => x.ValCodagent == this.ValCodagent), "Value", "Text", this.ValCodagent);
				FillDependant_Prope08TableAgentName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAgentName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Agent</param>
		public ConcurrentDictionary<string, object> GetDependant_Prope08TableAgentName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAagent.FldCodagent, CSGenioAagent.FldName, CSGenioAagent.FldEmail, CSGenioAagent.FldPhoto];

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

			CSGenioAagent tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAagent.FldCodagent, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAgentName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Prope08TableAgentName(bool lazyLoad = false)
		{
			var row = GetDependant_Prope08TableAgentName(this.ValCodagent);
			try
			{
				this.funcAgentValEmail = () => (string)row["agent.email"];
				this.funcAgentValPhoto = () => (GenioMVC.Models.ImageModel)row["agent.photo"];

				// Fill List fields
				this.ValCodagent = ViewModelConversion.ToString(row["agent.codagent"]);
				TableAgentName.Value = (string)row["agent.name"];
				if (GenFunctions.emptyG(this.ValCodagent) == 1)
				{
					this.ValCodagent = "";
					TableAgentName.Value = "";
					Navigation.ClearValue("agent");
				}
				else if (lazyLoad)
				{
					TableAgentName.SetPagination(1, 0, false, false, 1);
					TableAgentName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodagent),
							Text = Convert.ToString(TableAgentName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodagent);
				}

				TableAgentName.Selected = this.ValCodagent;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAgentName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPE08_AGENTNAME____ = ["Agent", "Agent.ValCodagent", "Agent.ValZzstate", "Agent.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"prope.codagent" => ViewModelConversion.ToString(modelValue),
				"prope.codcity" => ViewModelConversion.ToString(modelValue),
				"prope.photo" => ViewModelConversion.ToImage(modelValue),
				"prope.title" => ViewModelConversion.ToString(modelValue),
				"prope.price" => ViewModelConversion.ToNumeric(modelValue),
				"prope.descript" => ViewModelConversion.ToString(modelValue),
				"ctry.country" => ViewModelConversion.ToString(modelValue),
				"prope.size" => ViewModelConversion.ToNumeric(modelValue),
				"prope.bathrms" => ViewModelConversion.ToNumeric(modelValue),
				"prope.year" => ViewModelConversion.ToString(modelValue),
				"agent.email" => ViewModelConversion.ToString(modelValue),
				"agent.photo" => ViewModelConversion.ToImage(modelValue),
				"prope.codprope" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				"ctry.codctry" => ViewModelConversion.ToString(modelValue),
				"agent.codagent" => ViewModelConversion.ToString(modelValue),
				"agent.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPE, CSGenioAprope.FldPhoto.Field, null, ValCodprope);
			if (AgentValPhoto != null)
				AgentValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaAGENT, CSGenioAagent.FldPhoto.Field, null, ValCodagent);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPE08]/

		#endregion
	}
}
