using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Sale
{
	public class Venda_ViewModel : FormViewModel<Models.Sale>, IPreparableForSerialization
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
		/// Title: "Organization" | Type: "CE"
		/// </summary>
		public string ValCodorgan { get; set; }

		#endregion
		/// <summary>
		/// Title: "Organization" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Organ> TableOrganOrganiza { get; set; }
		/// <summary>
		/// Title: "leader no." | Type: "N"
		/// </summary>
		public decimal? ValNrlide { get; set; }
		/// <summary>
		/// Title: "Start" | Type: "DT"
		/// </summary>
		public DateTime? ValStartdt { get; set; }
		/// <summary>
		/// Title: "Identification of business opportunity" | Type: "C"
		/// </summary>
		public string ValIdentifi { get; set; }
		/// <summary>
		/// Title: "Potential Buyers" | Type: "C"
		/// </summary>
		public string ValPotcompr { get; set; }
		/// <summary>
		/// Title: "Prospection carried out" | Type: "L"
		/// </summary>
		public bool ValProspecc { get; set; }
		/// <summary>
		/// Title: "Interested" | Type: "L"
		/// </summary>
		public bool ValInteress { get; set; }
		/// <summary>
		/// Title: "Without Financial Resources" | Type: "L"
		/// </summary>
		public bool ValSemrfina { get; set; }
		/// <summary>
		/// Title: "No decision-making power" | Type: "L"
		/// </summary>
		public bool ValSemcapac { get; set; }
		/// <summary>
		/// Title: "Qualification" | Type: "DT"
		/// </summary>
		public DateTime? ValDtqualif { get; set; }
		/// <summary>
		/// Title: "Qualification carried out" | Type: "L"
		/// </summary>
		public bool ValQualific { get; set; }
		/// <summary>
		/// Title: "Pre-approach" | Type: "DT"
		/// </summary>
		public DateTime? ValPreabord { get; set; }
		/// <summary>
		/// Title: "Homework done" | Type: "L"
		/// </summary>
		public bool ValHomework { get; set; }
		/// <summary>
		/// Title: "Approach" | Type: "DT"
		/// </summary>
		public DateTime? ValDtaborda { get; set; }
		/// <summary>
		/// Title: "Approach made" | Type: "L"
		/// </summary>
		public bool ValApproach { get; set; }
		/// <summary>
		/// Title: "Presentation made" | Type: "DT"
		/// </summary>
		public DateTime? ValDtaprese { get; set; }
		/// <summary>
		/// Title: "Presentation" | Type: "L"
		/// </summary>
		public bool ValApresent { get; set; }
		/// <summary>
		/// Title: "Overcoming objections" | Type: "DT"
		/// </summary>
		public DateTime? ValDtsupera { get; set; }
		/// <summary>
		/// Title: "Closing Attempts" | Type: "DT"
		/// </summary>
		public DateTime? ValTentfech { get; set; }
		/// <summary>
		/// Title: "Closing of the sale" | Type: "DT"
		/// </summary>
		public DateTime? ValDtvenda { get; set; }
		/// <summary>
		/// Title: "Follow-up" | Type: "DT"
		/// </summary>
		public DateTime? ValDtacompa { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodvenda { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Venda_ViewModel() : base(null!) { }

		public Venda_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FVENDA", nestedForm) { }

		public Venda_ViewModel(UserContext userContext, Models.Sale row, bool nestedForm = false) : base(userContext, "FVENDA", row, nestedForm) { }

		public Venda_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("sale", id);
			Model = Models.Sale.Find(id, userContext, "FVENDA", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
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
			Models.Sale model = new Models.Sale(userContext) { Identifier = "FVENDA" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FVENDA");
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
		public override void MapFromModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Venda) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValNrlide = ViewModelConversion.ToNumeric(m.ValNrlide);
				ValStartdt = ViewModelConversion.ToDateTime(m.ValStartdt);
				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
				ValPotcompr = ViewModelConversion.ToString(m.ValPotcompr);
				ValProspecc = ViewModelConversion.ToLogic(m.ValProspecc);
				ValInteress = ViewModelConversion.ToLogic(m.ValInteress);
				ValSemrfina = ViewModelConversion.ToLogic(m.ValSemrfina);
				ValSemcapac = ViewModelConversion.ToLogic(m.ValSemcapac);
				ValDtqualif = ViewModelConversion.ToDateTime(m.ValDtqualif);
				ValQualific = ViewModelConversion.ToLogic(m.ValQualific);
				ValPreabord = ViewModelConversion.ToDateTime(m.ValPreabord);
				ValHomework = ViewModelConversion.ToLogic(m.ValHomework);
				ValDtaborda = ViewModelConversion.ToDateTime(m.ValDtaborda);
				ValApproach = ViewModelConversion.ToLogic(m.ValApproach);
				ValDtaprese = ViewModelConversion.ToDateTime(m.ValDtaprese);
				ValApresent = ViewModelConversion.ToLogic(m.ValApresent);
				ValDtsupera = ViewModelConversion.ToDateTime(m.ValDtsupera);
				ValTentfech = ViewModelConversion.ToDateTime(m.ValTentfech);
				ValDtvenda = ViewModelConversion.ToDateTime(m.ValDtvenda);
				ValDtacompa = ViewModelConversion.ToDateTime(m.ValDtacompa);
				ValCodvenda = ViewModelConversion.ToString(m.ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Venda) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Venda) to Model (Sale) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValNrlide = ViewModelConversion.ToNumeric(ValNrlide);
				m.ValStartdt = ViewModelConversion.ToDateTime(ValStartdt);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValPotcompr = ViewModelConversion.ToString(ValPotcompr);
				m.ValProspecc = ViewModelConversion.ToLogic(ValProspecc);
				m.ValInteress = ViewModelConversion.ToLogic(ValInteress);
				m.ValSemrfina = ViewModelConversion.ToLogic(ValSemrfina);
				m.ValSemcapac = ViewModelConversion.ToLogic(ValSemcapac);
				m.ValDtqualif = ViewModelConversion.ToDateTime(ValDtqualif);
				m.ValQualific = ViewModelConversion.ToLogic(ValQualific);
				m.ValPreabord = ViewModelConversion.ToDateTime(ValPreabord);
				m.ValHomework = ViewModelConversion.ToLogic(ValHomework);
				m.ValDtaborda = ViewModelConversion.ToDateTime(ValDtaborda);
				m.ValApproach = ViewModelConversion.ToLogic(ValApproach);
				m.ValDtaprese = ViewModelConversion.ToDateTime(ValDtaprese);
				m.ValApresent = ViewModelConversion.ToLogic(ValApresent);
				m.ValDtsupera = ViewModelConversion.ToDateTime(ValDtsupera);
				m.ValTentfech = ViewModelConversion.ToDateTime(ValTentfech);
				m.ValDtvenda = ViewModelConversion.ToDateTime(ValDtvenda);
				m.ValDtacompa = ViewModelConversion.ToDateTime(ValDtacompa);
				m.ValCodvenda = ViewModelConversion.ToString(ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Venda) to Model (Sale) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "sale.codorgan":
						this.ValCodorgan = ViewModelConversion.ToString(_value);
						break;
					case "sale.nrlide":
						this.ValNrlide = ViewModelConversion.ToNumeric(_value);
						break;
					case "sale.startdt":
						this.ValStartdt = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.identifi":
						this.ValIdentifi = ViewModelConversion.ToString(_value);
						break;
					case "sale.potcompr":
						this.ValPotcompr = ViewModelConversion.ToString(_value);
						break;
					case "sale.prospecc":
						this.ValProspecc = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.interess":
						this.ValInteress = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.semrfina":
						this.ValSemrfina = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.semcapac":
						this.ValSemcapac = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.dtqualif":
						this.ValDtqualif = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.qualific":
						this.ValQualific = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.preabord":
						this.ValPreabord = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.homework":
						this.ValHomework = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.dtaborda":
						this.ValDtaborda = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.approach":
						this.ValApproach = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.dtaprese":
						this.ValDtaprese = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.apresent":
						this.ValApresent = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.dtsupera":
						this.ValDtsupera = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.tentfech":
						this.ValTentfech = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.dtvenda":
						this.ValDtvenda = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.dtacompa":
						this.ValDtacompa = ViewModelConversion.ToDateTime(_value);
						break;
					case "sale.codvenda":
						this.ValCodvenda = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Venda) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Venda)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Sale.Find(id ?? Navigation.GetStrValue("sale"), m_userContext, "FVENDA"); }
			finally { Model ??= new Models.Sale(m_userContext) { Identifier = "FVENDA" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDA");
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

			Model.Identifier = "FVENDA";
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

		protected override void LoadDocumentsProperties(Models.Sale row)
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDA");
				if (Model == null)
				{
					Model = new Models.Sale(m_userContext) { Identifier = "FVENDA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Venda___organorganiza(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VENDA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VENDA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValIdentifi", Resources.Resources.IDENTIFICATION_OF_BU58085, ValIdentifi, 85);
			validator.StringLength("ValPotcompr", Resources.Resources.POTENTIAL_BUYERS56564, ValPotcompr, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE VENDA]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VENDA]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VENDA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VENDA]/
		public override void Destroy(string id)
		{
			Model = Models.Sale.Find(id, m_userContext, "FVENDA");
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
		/// TableOrganOrganiza -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Venda___organorganiza(NameValueCollection qs, bool lazyLoad = false)
		{
			bool venda___organorganizaDoLoad = true;
			CriteriaSet venda___organorganizaConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("organ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					venda___organorganizaConds.Equal(CSGenioAorgan.FldCodorgan, hValue);
					this.ValCodorgan = DBConversion.ToString(hValue);
				}
			}

			TableOrganOrganiza = new TableDBEdit<Models.Organ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}
				FillDependant_VendaTableOrganOrganiza(lazyLoad);
				return;
			}

			if (venda___organorganizaDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableOrganOrganiza, "sTableOrganOrganiza", "dTableOrganOrganiza", qs, "organ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAorgan.FldOrganiza), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableOrganOrganiza_tableFilters"]))
					TableOrganOrganiza.TableFilters = bool.Parse(qs["TableOrganOrganiza_tableFilters"]);
				else
					TableOrganOrganiza.TableFilters = false;

				query = qs["qTableOrganOrganiza"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAorgan.FldOrganiza, query + "%");
				}
				venda___organorganizaConds.SubSet(search_filters);

				string tryParsePage = qs["pTableOrganOrganiza"] != null ? qs["pTableOrganOrganiza"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza, CSGenioAorgan.FldZzstate];

// USE /[MANUAL GQT OVERRQ VENDA_ORGANORGANIZA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("organ", FormMode.New) || Navigation.checkFormMode("organ", FormMode.Duplicate))
					venda___organorganizaConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAorgan.FldZzstate, 0)
						.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetStrValue("organ")));
				else
					venda___organorganizaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAorgan.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("organ", "organiza");
				ListingMVC<CSGenioAorgan> listing = Models.ModelBase.Where<CSGenioAorgan>(m_userContext, false, venda___organorganizaConds, fields, offset, numberItems, sorts, "LED_VENDA___ORGANORGANIZA", true, false, firstVisibleColumn: firstVisibleColumn);

				TableOrganOrganiza.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableOrganOrganiza.Query = query;
				TableOrganOrganiza.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Organ(m_userContext, r, true, _fieldsToSerialize_VENDA___ORGANORGANIZA));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}

				TableOrganOrganiza.List = new SelectList(TableOrganOrganiza.Elements.ToSelectList(x => x.ValOrganiza, x => x.ValCodorgan,  x => x.ValCodorgan == this.ValCodorgan), "Value", "Text", this.ValCodorgan);
				FillDependant_VendaTableOrganOrganiza();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableOrganOrganiza (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Organ</param>
		public ConcurrentDictionary<string, object> GetDependant_VendaTableOrganOrganiza(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza];

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

			CSGenioAorgan tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAorgan.FldCodorgan, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableOrganOrganiza (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_VendaTableOrganOrganiza(bool lazyLoad = false)
		{
			var row = GetDependant_VendaTableOrganOrganiza(this.ValCodorgan);
			try
			{

				// Fill List fields
				this.ValCodorgan = ViewModelConversion.ToString(row["organ.codorgan"]);
				TableOrganOrganiza.Value = (string)row["organ.organiza"];
				if (GenFunctions.emptyG(this.ValCodorgan) == 1)
				{
					this.ValCodorgan = "";
					TableOrganOrganiza.Value = "";
					Navigation.ClearValue("organ");
				}
				else if (lazyLoad)
				{
					TableOrganOrganiza.SetPagination(1, 0, false, false, 1);
					TableOrganOrganiza.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodorgan),
							Text = Convert.ToString(TableOrganOrganiza.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodorgan);
				}

				TableOrganOrganiza.Selected = this.ValCodorgan;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOrganOrganiza): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_VENDA___ORGANORGANIZA = ["Organ", "Organ.ValCodorgan", "Organ.ValZzstate", "Organ.ValOrganiza"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"sale.codorgan" => ViewModelConversion.ToString(modelValue),
				"sale.nrlide" => ViewModelConversion.ToNumeric(modelValue),
				"sale.startdt" => ViewModelConversion.ToDateTime(modelValue),
				"sale.identifi" => ViewModelConversion.ToString(modelValue),
				"sale.potcompr" => ViewModelConversion.ToString(modelValue),
				"sale.prospecc" => ViewModelConversion.ToLogic(modelValue),
				"sale.interess" => ViewModelConversion.ToLogic(modelValue),
				"sale.semrfina" => ViewModelConversion.ToLogic(modelValue),
				"sale.semcapac" => ViewModelConversion.ToLogic(modelValue),
				"sale.dtqualif" => ViewModelConversion.ToDateTime(modelValue),
				"sale.qualific" => ViewModelConversion.ToLogic(modelValue),
				"sale.preabord" => ViewModelConversion.ToDateTime(modelValue),
				"sale.homework" => ViewModelConversion.ToLogic(modelValue),
				"sale.dtaborda" => ViewModelConversion.ToDateTime(modelValue),
				"sale.approach" => ViewModelConversion.ToLogic(modelValue),
				"sale.dtaprese" => ViewModelConversion.ToDateTime(modelValue),
				"sale.apresent" => ViewModelConversion.ToLogic(modelValue),
				"sale.dtsupera" => ViewModelConversion.ToDateTime(modelValue),
				"sale.tentfech" => ViewModelConversion.ToDateTime(modelValue),
				"sale.dtvenda" => ViewModelConversion.ToDateTime(modelValue),
				"sale.dtacompa" => ViewModelConversion.ToDateTime(modelValue),
				"sale.codvenda" => ViewModelConversion.ToString(modelValue),
				"organ.codorgan" => ViewModelConversion.ToString(modelValue),
				"organ.organiza" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM VENDA]/

		#endregion
	}
}
