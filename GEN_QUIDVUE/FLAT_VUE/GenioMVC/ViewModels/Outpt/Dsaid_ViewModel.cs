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

namespace GenioMVC.ViewModels.Outpt
{
	public class Dsaid_ViewModel : FormViewModel<Models.Outpt>, IPreparableForSerialization
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
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Ware1> TableWare1Warehdes { get; set; }
		/// <summary>
		/// Title: "No:" | Type: "N"
		/// </summary>
		public decimal? ValDocumenr { get; set; }
		/// <summary>
		/// Title: "Date:" | Type: "DT"
		/// </summary>
		public DateTime? ValDhdocume { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodoutpt { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dsaid_ViewModel() : base(null!) { }

		public Dsaid_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDSAID", nestedForm) { }

		public Dsaid_ViewModel(UserContext userContext, Models.Outpt row, bool nestedForm = false) : base(userContext, "FDSAID", row, nestedForm) { }

		public Dsaid_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("outpt", id);
			Model = Models.Outpt.Find(id, userContext, "FDSAID", fieldsToQuery: fieldsToLoad);
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
			Models.Outpt model = new Models.Outpt(userContext) { Identifier = "FDSAID" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDSAID");
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
			Models.Outpt model = Model;
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
		public override void MapFromModel(Models.Outpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Outpt) to ViewModel (Dsaid) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValDocumenr = ViewModelConversion.ToNumeric(m.ValDocumenr);
				ValDhdocume = ViewModelConversion.ToDateTime(m.ValDhdocume);
				ValCodoutpt = ViewModelConversion.ToString(m.ValCodoutpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Outpt) to ViewModel (Dsaid) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Outpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dsaid) to Model (Outpt) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValDocumenr = ViewModelConversion.ToNumeric(ValDocumenr);
				m.ValDhdocume = ViewModelConversion.ToDateTime(ValDhdocume);
				m.ValCodoutpt = ViewModelConversion.ToString(ValCodoutpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Dsaid) to Model (Outpt) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "outpt.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "outpt.documenr":
						this.ValDocumenr = ViewModelConversion.ToNumeric(_value);
						break;
					case "outpt.dhdocume":
						this.ValDhdocume = ViewModelConversion.ToDateTime(_value);
						break;
					case "outpt.codoutpt":
						this.ValCodoutpt = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Dsaid) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Dsaid)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Outpt.Find(id ?? Navigation.GetStrValue("outpt"), m_userContext, "FDSAID"); }
			finally { Model ??= new Models.Outpt(m_userContext) { Identifier = "FDSAID" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), m_userContext, "FDSAID");
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

			Model.Identifier = "FDSAID";
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

		protected override void LoadDocumentsProperties(Models.Outpt row)
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
				Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), m_userContext, "FDSAID");
				if (Model == null)
				{
					Model = new Models.Outpt(m_userContext) { Identifier = "FDSAID" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("outpt");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Dsaid___ware1warehdes(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DSAID]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DSAID]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodwareh", Resources.Resources.WAREHOUSE51864, ViewModelConversion.ToString(ValCodwareh), FieldType.CHAVE_ESTRANGEIRA_GUID.Formatting);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE DSAID]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DSAID]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DSAID]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DSAID]/
		public override void Destroy(string id)
		{
			Model = Models.Outpt.Find(id, m_userContext, "FDSAID");
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
		/// TableWare1Warehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dsaid___ware1warehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dsaid___ware1warehdesDoLoad = true;
			CriteriaSet dsaid___ware1warehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("ware1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dsaid___ware1warehdesConds.Equal(CSGenioAware1.FldCodwareh, hValue);
					this.ValCodwareh = DBConversion.ToString(hValue);
				}
			}

			TableWare1Warehdes = new TableDBEdit<Models.Ware1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}
				FillDependant_DsaidTableWare1Warehdes(lazyLoad);
				return;
			}

			if (dsaid___ware1warehdesDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableWare1Warehdes, "sTableWare1Warehdes", "dTableWare1Warehdes", qs, "ware1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAware1.FldWarehdes), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableWare1Warehdes_tableFilters"]))
					TableWare1Warehdes.TableFilters = bool.Parse(qs["TableWare1Warehdes_tableFilters"]);
				else
					TableWare1Warehdes.TableFilters = false;

				query = qs["qTableWare1Warehdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAware1.FldWarehdes, query + "%");
				}
				dsaid___ware1warehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWare1Warehdes"] != null ? qs["pTableWare1Warehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes, CSGenioAware1.FldZzstate };

// USE /[MANUAL GQT OVERRQ DSAID_WARE1WAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("ware1", FormMode.New) || Navigation.checkFormMode("ware1", FormMode.Duplicate))
					dsaid___ware1warehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAware1.FldZzstate, 0)
						.Equal(CSGenioAware1.FldCodwareh, Navigation.GetStrValue("ware1")));
				else
					dsaid___ware1warehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAware1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("ware1", "warehdes");
				ListingMVC<CSGenioAware1> listing = Models.ModelBase.Where<CSGenioAware1>(m_userContext, false, dsaid___ware1warehdesConds, fields, offset, numberItems, sorts, "LED_DSAID___WARE1WAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWare1Warehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWare1Warehdes.Query = query;
				TableWare1Warehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Ware1>((r) => new GenioMVC.Models.Ware1(m_userContext, r, true, _fieldsToSerialize_DSAID___WARE1WAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}

				TableWare1Warehdes.List = new SelectList(TableWare1Warehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_DsaidTableWare1Warehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWare1Warehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Ware1</param>
		public ConcurrentDictionary<string, object> GetDependant_DsaidTableWare1Warehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes];

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

			CSGenioAware1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAware1.FldCodwareh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableWare1Warehdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DsaidTableWare1Warehdes(bool lazyLoad = false)
		{
			var row = GetDependant_DsaidTableWare1Warehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["ware1.codwareh"]);
				TableWare1Warehdes.Value = (string)row["ware1.warehdes"];
				if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
				{
					this.ValCodwareh = "";
					TableWare1Warehdes.Value = "";
					Navigation.ClearValue("ware1");
				}
				else if (lazyLoad)
				{
					TableWare1Warehdes.SetPagination(1, 0, false, false, 1);
					TableWare1Warehdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodwareh),
							Text = Convert.ToString(TableWare1Warehdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodwareh);
				}

				TableWare1Warehdes.Selected = this.ValCodwareh;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWare1Warehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DSAID___WARE1WAREHDES = ["Ware1", "Ware1.ValCodwareh", "Ware1.ValZzstate", "Ware1.ValWarehdes"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"outpt.codwareh" => ViewModelConversion.ToString(modelValue),
				"outpt.documenr" => ViewModelConversion.ToNumeric(modelValue),
				"outpt.dhdocume" => ViewModelConversion.ToDateTime(modelValue),
				"outpt.codoutpt" => ViewModelConversion.ToString(modelValue),
				"ware1.codwareh" => ViewModelConversion.ToString(modelValue),
				"ware1.warehdes" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DSAID]/

		#endregion
	}
}
