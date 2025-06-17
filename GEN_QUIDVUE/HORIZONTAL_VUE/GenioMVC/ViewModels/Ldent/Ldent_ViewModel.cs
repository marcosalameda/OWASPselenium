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

namespace GenioMVC.ViewModels.Ldent
{
	public class Ldent_ViewModel : FormViewModel<Models.Ldent>, IPreparableForSerialization
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
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCoddentr { get; set; }
		/// <summary>
		/// Title: "Item" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Indoc> TableIndocDocumenr { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }
		/// <summary>
		/// Title: "Line" | Type: "N"
		/// </summary>
		public decimal? ValLine { get; set; }
		/// <summary>
		/// Title: "Items in use" | Type: "L"
		/// </summary>
		public bool ValEmuso { get; set; }
		/// <summary>
		/// Title: "Item" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemItemdes { get; set; }
		/// <summary>
		/// Title: "Input Quantity" | Type: "N"
		/// </summary>
		public decimal? ValQtdentra { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string IndocValCodwareh 
		{
			get
			{
				return funcIndocValCodwareh != null ? funcIndocValCodwareh() : _auxIndocValCodwareh;
			}
			set { funcIndocValCodwareh = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcIndocValCodwareh { get; set; }

		private string _auxIndocValCodwareh { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodldent { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Ldent_ViewModel() : base(null!) { }

		public Ldent_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLDENT", nestedForm) { }

		public Ldent_ViewModel(UserContext userContext, Models.Ldent row, bool nestedForm = false) : base(userContext, "FLDENT", row, nestedForm) { }

		public Ldent_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("ldent", id);
			Model = Models.Ldent.Find(id, userContext, "FLDENT", fieldsToQuery: fieldsToLoad);
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
			Models.Ldent model = new Models.Ldent(userContext) { Identifier = "FLDENT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLDENT");
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
		public override void MapFromModel(Models.Ldent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Ldent) to ViewModel (Ldent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCoddentr = ViewModelConversion.ToString(m.ValCoddentr);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
				ValEmuso = ViewModelConversion.ToLogic(m.ValEmuso);
				ValQtdentra = ViewModelConversion.ToNumeric(m.ValQtdentra);
				funcIndocValCodwareh = () => ViewModelConversion.ToString(m.Indoc.ValCodwareh);
				ValCodldent = ViewModelConversion.ToString(m.ValCodldent);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Ldent) to ViewModel (Ldent) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Ldent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldent) to Model (Ldent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCoddentr = ViewModelConversion.ToString(ValCoddentr);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValEmuso = ViewModelConversion.ToLogic(ValEmuso);
				m.ValQtdentra = ViewModelConversion.ToNumeric(ValQtdentra);
				m.ValCodldent = ViewModelConversion.ToString(ValCodldent);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Ldent) to Model (Ldent) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "ldent.coddentr":
						this.ValCoddentr = ViewModelConversion.ToString(_value);
						break;
					case "ldent.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					case "ldent.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "ldent.line":
						this.ValLine = ViewModelConversion.ToNumeric(_value);
						break;
					case "ldent.emuso":
						this.ValEmuso = ViewModelConversion.ToLogic(_value);
						break;
					case "ldent.qtdentra":
						this.ValQtdentra = ViewModelConversion.ToNumeric(_value);
						break;
					case "ldent.codldent":
						this.ValCodldent = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Ldent) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Ldent)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Ldent.Find(id ?? Navigation.GetStrValue("ldent"), m_userContext, "FLDENT"); }
			finally { Model ??= new Models.Ldent(m_userContext) { Identifier = "FLDENT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), m_userContext, "FLDENT");
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

			Model.Identifier = "FLDENT";
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

		protected override void LoadDocumentsProperties(Models.Ldent row)
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
				Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), m_userContext, "FLDENT");
				if (Model == null)
				{
					Model = new Models.Ldent(m_userContext) { Identifier = "FLDENT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Ldent___indocdocumenr(qs, lazyLoad);
			Load_Ldent___warehwarehdes(qs, lazyLoad);
			Load_Ldent___item_itemdes_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LDENT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LDENT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE LDENT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LDENT]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LDENT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LDENT]/
		public override void Destroy(string id)
		{
			Model = Models.Ldent.Find(id, m_userContext, "FLDENT");
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
		/// TableIndocDocumenr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldent___indocdocumenr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldent___indocdocumenrDoLoad = true;
			CriteriaSet ldent___indocdocumenrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("indoc", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldent___indocdocumenrConds.Equal(CSGenioAindoc.FldCoddentr, hValue);
					this.ValCoddentr = DBConversion.ToString(hValue);
				}
			}

			TableIndocDocumenr = new TableDBEdit<Models.Indoc>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_indoc") != null)
				{
					this.ValCoddentr = Navigation.GetStrValue("RETURN_indoc");
					Navigation.CurrentLevel.SetEntry("RETURN_indoc", null);
				}
				FillDependant_LdentTableIndocDocumenr(lazyLoad);
				return;
			}

			if (ldent___indocdocumenrDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableIndocDocumenr, "sTableIndocDocumenr", "dTableIndocDocumenr", qs, "indoc");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAindoc.FldDhdocume), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableIndocDocumenr_tableFilters"]))
					TableIndocDocumenr.TableFilters = bool.Parse(qs["TableIndocDocumenr_tableFilters"]);
				else
					TableIndocDocumenr.TableFilters = false;

				query = qs["qTableIndocDocumenr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAindoc.FldDocumenr, query + "%");
				}
				ldent___indocdocumenrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableIndocDocumenr"] != null ? qs["pTableIndocDocumenr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldDocumenr, CSGenioAindoc.FldDhdocume, CSGenioAindoc.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_INDOCDOCUMENR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("indoc", FormMode.New) || Navigation.checkFormMode("indoc", FormMode.Duplicate))
					ldent___indocdocumenrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAindoc.FldZzstate, 0)
						.Equal(CSGenioAindoc.FldCoddentr, Navigation.GetStrValue("indoc")));
				else
					ldent___indocdocumenrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAindoc.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("indoc", "documenr");
				ListingMVC<CSGenioAindoc> listing = Models.ModelBase.Where<CSGenioAindoc>(m_userContext, false, ldent___indocdocumenrConds, fields, offset, numberItems, sorts, "LED_LDENT___INDOCDOCUMENR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableIndocDocumenr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableIndocDocumenr.Query = query;
				TableIndocDocumenr.Elements = listing.RowsForViewModel<GenioMVC.Models.Indoc>((r) => new GenioMVC.Models.Indoc(m_userContext, r, true, _fieldsToSerialize_LDENT___INDOCDOCUMENR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_indoc") != null)
				{
					this.ValCoddentr = Navigation.GetStrValue("RETURN_indoc");
					Navigation.CurrentLevel.SetEntry("RETURN_indoc", null);
				}

				TableIndocDocumenr.List = new SelectList(TableIndocDocumenr.Elements.ToSelectList(x => x.ValDocumenr, x => x.ValCoddentr,  x => x.ValCoddentr == this.ValCoddentr), "Value", "Text", this.ValCoddentr);
				FillDependant_LdentTableIndocDocumenr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableIndocDocumenr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Indoc</param>
		public ConcurrentDictionary<string, object> GetDependant_LdentTableIndocDocumenr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldDocumenr, CSGenioAindoc.FldCodwareh];

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

			CSGenioAindoc tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAindoc.FldCoddentr, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableIndocDocumenr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LdentTableIndocDocumenr(bool lazyLoad = false)
		{
			var row = GetDependant_LdentTableIndocDocumenr(this.ValCoddentr);
			try
			{
				this.funcIndocValCodwareh = () => (string)row["indoc.codwareh"];

				// Fill List fields
				this.ValCoddentr = ViewModelConversion.ToString(row["indoc.coddentr"]);
				TableIndocDocumenr.Value = (decimal?)row["indoc.documenr"];
				if (GenFunctions.emptyG(this.ValCoddentr) == 1)
				{
					this.ValCoddentr = "";
					TableIndocDocumenr.Value = 0m;
					Navigation.ClearValue("indoc");
				}
				else if (lazyLoad)
				{
					TableIndocDocumenr.SetPagination(1, 0, false, false, 1);
					TableIndocDocumenr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoddentr),
							Text = Convert.ToString(TableIndocDocumenr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoddentr);
				}

				TableIndocDocumenr.Selected = this.ValCoddentr;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableIndocDocumenr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LDENT___INDOCDOCUMENR = ["Indoc", "Indoc.ValCoddentr", "Indoc.ValZzstate", "Indoc.ValDocumenr", "Indoc.ValDhdocume"];

		/// <summary>
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldent___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldent___warehwarehdesDoLoad = true;
			CriteriaSet ldent___warehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldent___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
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
				FillDependant_LdentTableWarehWarehdes(lazyLoad);
				return;
			}

			if (ldent___warehwarehdesDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
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
				ldent___warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					ldent___warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					ldent___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, ldent___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_LDENT___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_LDENT___WAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_LdentTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_LdentTableWarehWarehdes(string PKey)
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
		public void FillDependant_LdentTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_LdentTableWarehWarehdes(this.ValCodwareh);
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

		private readonly string[] _fieldsToSerialize_LDENT___WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes"];

		/// <summary>
		/// TableItemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldent___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldent___item_itemdes_DoLoad = true;
			CriteriaSet ldent___item_itemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("item", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldent___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValCoditem = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			ldent___item_itemdes_DoLoad &= AddCriteriaAreaLimit(ldent___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);

			TableItemItemdes = new TableDBEdit<Models.Item>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
				FillDependant_LdentTableItemItemdes(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodwareh))
				ldent___item_itemdes_DoLoad = false;

			if (ldent___item_itemdes_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
					TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
				else
					TableItemItemdes.TableFilters = false;

				query = qs["qTableItemItemdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
				}
				ldent___item_itemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldValid, CSGenioAitem.FldItemtype, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_ITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					ldent___item_itemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					ldent___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, ldent___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_LDENT___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemItemdes.Query = query;
				TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_LDENT___ITEM_ITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
				FillDependant_LdentTableItemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_LdentTableItemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("wareh");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAitem tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LdentTableItemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_LdentTableItemItemdes(this.ValCoditem);
			try
			{

				// Fill List fields
				this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemItemdes.Value = (string)row["item.itemdes"];
				if (GenFunctions.emptyG(this.ValCoditem) == 1)
				{
					this.ValCoditem = "";
					TableItemItemdes.Value = "";
					Navigation.ClearValue("item");
				}
				else if (lazyLoad)
				{
					TableItemItemdes.SetPagination(1, 0, false, false, 1);
					TableItemItemdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoditem),
							Text = Convert.ToString(TableItemItemdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoditem);
				}

				TableItemItemdes.Selected = this.ValCoditem;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LDENT___ITEM_ITEMDES_ = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod", "Item.ValValid", "Item.ValItemtype"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"ldent.coddentr" => ViewModelConversion.ToString(modelValue),
				"ldent.coditem" => ViewModelConversion.ToString(modelValue),
				"ldent.codwareh" => ViewModelConversion.ToString(modelValue),
				"ldent.line" => ViewModelConversion.ToNumeric(modelValue),
				"ldent.emuso" => ViewModelConversion.ToLogic(modelValue),
				"ldent.qtdentra" => ViewModelConversion.ToNumeric(modelValue),
				"indoc.codwareh" => ViewModelConversion.ToString(modelValue),
				"ldent.codldent" => ViewModelConversion.ToString(modelValue),
				"indoc.coddentr" => ViewModelConversion.ToString(modelValue),
				"indoc.documenr" => ViewModelConversion.ToNumeric(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LDENT]/

		#endregion
	}
}
