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

namespace GenioMVC.ViewModels.Wpess
{
	public class Pesspop_ViewModel : FormViewModel<Models.Wpess>, IPreparableForSerialization
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
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "Employee Number" | Type: "N"
		/// </summary>
		public decimal? ValNfunc { get; set; }
		/// <summary>
		/// Title: "Profille picture" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValPfoto { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Birth date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Sex" | Type: "AC"
		/// </summary>
		public string ValSex { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValSex { get; set; }
		/// <summary>
		/// Title: "Country of Birth" | Type: "C"
		/// </summary>
		public string ValNaturali { get; set; }
		/// <summary>
		/// Title: "Nationality" | Type: "C"
		/// </summary>
		public string ValNacional { get; set; }
		/// <summary>
		/// Title: "Adress" | Type: "C"
		/// </summary>
		public string ValAdress { get; set; }
		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValZipcode { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		public string ValCountry { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Cellphone" | Type: "N"
		/// </summary>
		public decimal? ValCellphon { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpess { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pesspop_ViewModel() : base(null!) { }

		public Pesspop_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPESSPOP", nestedForm) { }

		public Pesspop_ViewModel(UserContext userContext, Models.Wpess row, bool nestedForm = false) : base(userContext, "FPESSPOP", row, nestedForm) { }

		public Pesspop_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("wpess", id);
			Model = Models.Wpess.Find(id, userContext, "FPESSPOP", fieldsToQuery: fieldsToLoad);
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
			Models.Wpess model = new Models.Wpess(userContext) { Identifier = "FPESSPOP" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPESSPOP");
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
		public override void MapFromModel(Models.Wpess m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Wpess) to ViewModel (Pesspop) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValNfunc = ViewModelConversion.ToNumeric(m.ValNfunc);
				ValPfoto = ViewModelConversion.ToImage(m.ValPfoto);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValSex = ViewModelConversion.ToString(m.ValSex);
				ValNaturali = ViewModelConversion.ToString(m.ValNaturali);
				ValNacional = ViewModelConversion.ToString(m.ValNacional);
				ValAdress = ViewModelConversion.ToString(m.ValAdress);
				ValZipcode = ViewModelConversion.ToString(m.ValZipcode);
				ValCountry = ViewModelConversion.ToString(m.ValCountry);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValCellphon = ViewModelConversion.ToNumeric(m.ValCellphon);
				ValCodpess = ViewModelConversion.ToString(m.ValCodpess);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Wpess) to ViewModel (Pesspop) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Wpess m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesspop) to Model (Wpess) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValNfunc = ViewModelConversion.ToNumeric(ValNfunc);
				if (ValPfoto == null || !ValPfoto.IsThumbnail)
					m.ValPfoto = ViewModelConversion.ToImage(ValPfoto);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValSex = ViewModelConversion.ToString(ValSex);
				m.ValNaturali = ViewModelConversion.ToString(ValNaturali);
				m.ValNacional = ViewModelConversion.ToString(ValNacional);
				m.ValAdress = ViewModelConversion.ToString(ValAdress);
				m.ValZipcode = ViewModelConversion.ToString(ValZipcode);
				m.ValCountry = ViewModelConversion.ToString(ValCountry);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValCellphon = ViewModelConversion.ToNumeric(ValCellphon);
				m.ValCodpess = ViewModelConversion.ToString(ValCodpess);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Pesspop) to Model (Wpess) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "wpess.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "wpess.nfunc":
						this.ValNfunc = ViewModelConversion.ToNumeric(_value);
						break;
					case "wpess.pfoto":
						this.ValPfoto = ViewModelConversion.ToImage(_value);
						break;
					case "wpess.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "wpess.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "wpess.sex":
						this.ValSex = ViewModelConversion.ToString(_value);
						break;
					case "wpess.naturali":
						this.ValNaturali = ViewModelConversion.ToString(_value);
						break;
					case "wpess.nacional":
						this.ValNacional = ViewModelConversion.ToString(_value);
						break;
					case "wpess.adress":
						this.ValAdress = ViewModelConversion.ToString(_value);
						break;
					case "wpess.zipcode":
						this.ValZipcode = ViewModelConversion.ToString(_value);
						break;
					case "wpess.country":
						this.ValCountry = ViewModelConversion.ToString(_value);
						break;
					case "wpess.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "wpess.cellphon":
						this.ValCellphon = ViewModelConversion.ToNumeric(_value);
						break;
					case "wpess.codpess":
						this.ValCodpess = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Pesspop) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Pesspop)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Wpess.Find(id ?? Navigation.GetStrValue("wpess"), m_userContext, "FPESSPOP"); }
			finally { Model ??= new Models.Wpess(m_userContext) { Identifier = "FPESSPOP" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), m_userContext, "FPESSPOP");
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

			Model.Identifier = "FPESSPOP";
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

		protected override void LoadDocumentsProperties(Models.Wpess row)
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
				Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), m_userContext, "FPESSPOP");
				if (Model == null)
				{
					Model = new Models.Wpess(m_userContext) { Identifier = "FPESSPOP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pesspop_warehwarehdes(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESSPOP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESSPOP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);
			validator.StringLength("ValNaturali", Resources.Resources.COUNTRY_OF_BIRTH53244, ValNaturali, 50);
			validator.StringLength("ValNacional", Resources.Resources.NATIONALITY34787, ValNacional, 50);
			validator.StringLength("ValAdress", Resources.Resources.ADRESS39816, ValAdress, 100);
			validator.StringLength("ValZipcode", Resources.Resources.ZIPCODE21021, ValZipcode, 8);
			validator.StringLength("ValCountry", Resources.Resources.COUNTRY64133, ValCountry, 50);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL25170, ValEmail, 150);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PESSPOP]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSPOP]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSPOP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSPOP]/
		public override void Destroy(string id)
		{
			Model = Models.Wpess.Find(id, m_userContext, "FPESSPOP");
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
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pesspop_warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pesspop_warehwarehdesDoLoad = true;
			CriteriaSet pesspop_warehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pesspop_warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
					this.ValCodwareh = DBConversion.ToString(hValue);
				}
			}

			TableWarehWarehdes = new TableDBEdit<Models.Wareh>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
				FillDependant_PesspopTableWarehWarehdes(lazyLoad);
				return;
			}

			if (pesspop_warehwarehdesDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehdes), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
					TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
				else
					TableWarehWarehdes.TableFilters = false;

				query = qs["qTableWarehWarehdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
				}
				pesspop_warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSPOP_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					pesspop_warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					pesspop_warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, pesspop_warehwarehdesConds, fields, offset, numberItems, sorts, "LED_PESSPOP_WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_PESSPOP_WAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_PesspopTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_PesspopTableWarehWarehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes];

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

			CSGenioAwareh tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PesspopTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_PesspopTableWarehWarehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
				TableWarehWarehdes.Value = (string)row["wareh.warehdes"];
				if (GenFunctions.emptyG(this.ValCodwareh) == 1)
				{
					this.ValCodwareh = "";
					TableWarehWarehdes.Value = "";
					Navigation.ClearValue("wareh");
				}
				else if (lazyLoad)
				{
					TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
					TableWarehWarehdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodwareh),
							Text = Convert.ToString(TableWarehWarehdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodwareh);
				}

				TableWarehWarehdes.Selected = this.ValCodwareh;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESSPOP_WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"wpess.codwareh" => ViewModelConversion.ToString(modelValue),
				"wpess.nfunc" => ViewModelConversion.ToNumeric(modelValue),
				"wpess.pfoto" => ViewModelConversion.ToImage(modelValue),
				"wpess.name" => ViewModelConversion.ToString(modelValue),
				"wpess.date" => ViewModelConversion.ToDateTime(modelValue),
				"wpess.sex" => ViewModelConversion.ToString(modelValue),
				"wpess.naturali" => ViewModelConversion.ToString(modelValue),
				"wpess.nacional" => ViewModelConversion.ToString(modelValue),
				"wpess.adress" => ViewModelConversion.ToString(modelValue),
				"wpess.zipcode" => ViewModelConversion.ToString(modelValue),
				"wpess.country" => ViewModelConversion.ToString(modelValue),
				"wpess.email" => ViewModelConversion.ToString(modelValue),
				"wpess.cellphon" => ViewModelConversion.ToNumeric(modelValue),
				"wpess.codpess" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPfoto != null)
				ValPfoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaWPESS, CSGenioAwpess.FldPfoto.Field, null, ValCodpess);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSPOP]/

		#endregion
	}
}
