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

namespace GenioMVC.ViewModels.Sale
{
	public class Vendaw01_ViewModel : FormViewModel<Models.Sale>, IPreparableForSerialization
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
		/// Title: "Identification of business opportunity" | Type: "C"
		/// </summary>
		public string ValIdentifi { get; set; }
		/// <summary>
		/// Title: "Potential buyers" | Type: "C"
		/// </summary>
		public string ValPotcompr { get; set; }
		/// <summary>
		/// Title: "Prospecting carried out" | Type: "L"
		/// </summary>
		public bool ValProspecc { get; set; }

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
		public Vendaw01_ViewModel() : base(null!) { }

		public Vendaw01_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FVENDAW01", nestedForm) { }

		public Vendaw01_ViewModel(UserContext userContext, Models.Sale row, bool nestedForm = false) : base(userContext, "FVENDAW01", row, nestedForm) { }

		public Vendaw01_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("sale", id);
			Model = Models.Sale.Find(id, userContext, "FVENDAW01", fieldsToQuery: fieldsToLoad);
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
			Models.Sale model = new Models.Sale(userContext) { Identifier = "FVENDAW01" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FVENDAW01");
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

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Sale model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw01) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
				ValPotcompr = ViewModelConversion.ToString(m.ValPotcompr);
				ValProspecc = ViewModelConversion.ToLogic(m.ValProspecc);
				ValCodvenda = ViewModelConversion.ToString(m.ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw01) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Vendaw01) to Model (Sale) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValPotcompr = ViewModelConversion.ToString(ValPotcompr);
				m.ValProspecc = ViewModelConversion.ToLogic(ValProspecc);
				m.ValCodvenda = ViewModelConversion.ToString(ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Vendaw01) to Model (Sale) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "sale.identifi":
						this.ValIdentifi = ViewModelConversion.ToString(_value);
						break;
					case "sale.potcompr":
						this.ValPotcompr = ViewModelConversion.ToString(_value);
						break;
					case "sale.prospecc":
						this.ValProspecc = ViewModelConversion.ToLogic(_value);
						break;
					case "sale.codvenda":
						this.ValCodvenda = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Vendaw01) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Vendaw01)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Sale.Find(id ?? Navigation.GetStrValue("sale"), m_userContext, "FVENDAW01"); }
			finally { Model ??= new Models.Sale(m_userContext) { Identifier = "FVENDAW01" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW01");
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

			Model.Identifier = "FVENDAW01";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), m_userContext, "FVENDAW01");
				if (Model == null)
				{
					Model = new Models.Sale(m_userContext) { Identifier = "FVENDAW01" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Vendaw01organorganiza(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VENDAW01]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VENDAW01]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValIdentifi", Resources.Resources.IDENTIFICATION_OF_BU58085, ValIdentifi, 85);
			validator.StringLength("ValPotcompr", Resources.Resources.POTENTIAL_BUYERS44829, ValPotcompr, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE VENDAW01]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VENDAW01]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VENDAW01]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VENDAW01]/
		public override void Destroy(string id)
		{
			Model = Models.Sale.Find(id, m_userContext, "FVENDAW01");
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
		public void Load_Vendaw01organorganiza(NameValueCollection qs, bool lazyLoad = false)
		{
			bool vendaw01organorganizaDoLoad = true;
			CriteriaSet vendaw01organorganizaConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("organ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					vendaw01organorganizaConds.Equal(CSGenioAorgan.FldCodorgan, hValue);
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
				FillDependant_Vendaw01TableOrganOrganiza(lazyLoad);
				return;
			}

			if (vendaw01organorganizaDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
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
				vendaw01organorganizaConds.SubSet(search_filters);

				string tryParsePage = qs["pTableOrganOrganiza"] != null ? qs["pTableOrganOrganiza"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza, CSGenioAorgan.FldZzstate };

// USE /[MANUAL GQT OVERRQ VENDAW01_ORGANORGANIZA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("organ", FormMode.New) || Navigation.checkFormMode("organ", FormMode.Duplicate))
					vendaw01organorganizaConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAorgan.FldZzstate, 0)
						.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetStrValue("organ")));
				else
					vendaw01organorganizaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAorgan.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("organ", "organiza");
				ListingMVC<CSGenioAorgan> listing = Models.ModelBase.Where<CSGenioAorgan>(m_userContext, false, vendaw01organorganizaConds, fields, offset, numberItems, sorts, "LED_VENDAW01ORGANORGANIZA", true, false, firstVisibleColumn: firstVisibleColumn);

				TableOrganOrganiza.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableOrganOrganiza.Query = query;
				TableOrganOrganiza.Elements = listing.RowsForViewModel<GenioMVC.Models.Organ>((r) => new GenioMVC.Models.Organ(m_userContext, r, true, _fieldsToSerialize_VENDAW01ORGANORGANIZA));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}

				TableOrganOrganiza.List = new SelectList(TableOrganOrganiza.Elements.ToSelectList(x => x.ValOrganiza, x => x.ValCodorgan,  x => x.ValCodorgan == this.ValCodorgan), "Value", "Text", this.ValCodorgan);
				FillDependant_Vendaw01TableOrganOrganiza();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableOrganOrganiza (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Organ</param>
		public ConcurrentDictionary<string, object> GetDependant_Vendaw01TableOrganOrganiza(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
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
		public void FillDependant_Vendaw01TableOrganOrganiza(bool lazyLoad = false)
		{
			var row = GetDependant_Vendaw01TableOrganOrganiza(this.ValCodorgan);
			try
			{

				// Fill List fields
				this.ValCodorgan = ViewModelConversion.ToString(row["organ.codorgan"]);
				TableOrganOrganiza.Value = (string)row["organ.organiza"];
				if (GlobalFunctions.emptyG(this.ValCodorgan) == 1)
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

		private readonly string[] _fieldsToSerialize_VENDAW01ORGANORGANIZA = ["Organ", "Organ.ValCodorgan", "Organ.ValZzstate", "Organ.ValOrganiza"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"sale.codorgan" => ViewModelConversion.ToString(modelValue),
				"sale.identifi" => ViewModelConversion.ToString(modelValue),
				"sale.potcompr" => ViewModelConversion.ToString(modelValue),
				"sale.prospecc" => ViewModelConversion.ToLogic(modelValue),
				"sale.codvenda" => ViewModelConversion.ToString(modelValue),
				"organ.codorgan" => ViewModelConversion.ToString(modelValue),
				"organ.organiza" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM VENDAW01]/

		#endregion
	}
}
