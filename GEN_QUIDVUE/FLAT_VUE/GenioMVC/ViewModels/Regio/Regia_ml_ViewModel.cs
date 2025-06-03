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

namespace GenioMVC.ViewModels.Regio
{
	public class Regia_ml_ViewModel : FormViewModel<Models.Regio>, IPreparableForSerialization
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
		/// Title: "País:" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }
		/// <summary>
		/// Title: "País pessoa" | Type: "CE"
		/// </summary>
		public string ValCodpais1 { get; set; }

		#endregion
		/// <summary>
		/// Title: "País:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }
		/// <summary>
		/// Title: "Região:" | Type: "C"
		/// </summary>
		public string ValRegiao { get; set; }
		/// <summary>
		/// Title: "País pessoa" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pais1> TablePais1Country { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodregia { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Regia_ml_ViewModel() : base(null!) { }

		public Regia_ml_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FREGIA_ML", nestedForm) { }

		public Regia_ml_ViewModel(UserContext userContext, Models.Regio row, bool nestedForm = false) : base(userContext, "FREGIA_ML", row, nestedForm) { }

		public Regia_ml_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("regio", id);
			Model = Models.Regio.Find(id, userContext, "FREGIA_ML", fieldsToQuery: fieldsToLoad);
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
			Models.Regio model = new Models.Regio(userContext) { Identifier = "FREGIA_ML" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FREGIA_ML");
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
			Models.Regio model = Model;
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
		public override void MapFromModel(Models.Regio m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia_ml) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodpais1 = ViewModelConversion.ToString(m.ValCodpais1);
				ValRegiao = ViewModelConversion.ToString(m.ValRegiao);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia_ml) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Regio m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regia_ml) to Model (Regio) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpais1 = ViewModelConversion.ToString(ValCodpais1);
				m.ValRegiao = ViewModelConversion.ToString(ValRegiao);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Regia_ml) to Model (Regio) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "regio.codcntry":
						this.ValCodcntry = ViewModelConversion.ToString(_value);
						break;
					case "regio.codpais1":
						this.ValCodpais1 = ViewModelConversion.ToString(_value);
						break;
					case "regio.regiao":
						this.ValRegiao = ViewModelConversion.ToString(_value);
						break;
					case "regio.codregia":
						this.ValCodregia = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Regia_ml) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Regia_ml)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Regio.Find(id ?? Navigation.GetStrValue("regio"), m_userContext, "FREGIA_ML"); }
			finally { Model ??= new Models.Regio(m_userContext) { Identifier = "FREGIA_ML" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), m_userContext, "FREGIA_ML");
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

			Model.Identifier = "FREGIA_ML";
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

		protected override void LoadDocumentsProperties(Models.Regio row)
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
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), m_userContext, "FREGIA_ML");
				if (Model == null)
				{
					Model = new Models.Regio(m_userContext) { Identifier = "FREGIA_ML" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("regio");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Regia_mlcntrycountry_(qs, lazyLoad);
			Load_Regia_mlpais1country_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGIA_ML]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGIA_ML]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValRegiao", Resources.Resources.REGIAO_39589, ValRegiao, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE REGIA_ML]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGIA_ML]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGIA_ML]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGIA_ML]/
		public override void Destroy(string id)
		{
			Model = Models.Regio.Find(id, m_userContext, "FREGIA_ML");
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
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Regia_mlcntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool regia_mlcntrycountry_DoLoad = true;
			CriteriaSet regia_mlcntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					regia_mlcntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, hValue);
					this.ValCodcntry = DBConversion.ToString(hValue);
				}
			}

			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
				FillDependant_Regia_mlTableCntryCountry(lazyLoad);
				return;
			}

			if (regia_mlcntrycountry_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				query = qs["qTableCntryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				}
				regia_mlcntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ REGIA_ML_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					regia_mlcntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					regia_mlcntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, regia_mlcntrycountry_Conds, fields, offset, numberItems, sorts, "LED_REGIA_MLCNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_REGIA_MLCNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_Regia_mlTableCntryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_Regia_mlTableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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

			CSGenioAcntry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Regia_mlTableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_Regia_mlTableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GenFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TableCntryCountry.Value = "";
					Navigation.ClearValue("cntry");
				}
				else if (lazyLoad)
				{
					TableCntryCountry.SetPagination(1, 0, false, false, 1);
					TableCntryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TableCntryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TableCntryCountry.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_REGIA_MLCNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		/// <summary>
		/// TablePais1Country -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Regia_mlpais1country_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool regia_mlpais1country_DoLoad = true;
			CriteriaSet regia_mlpais1country_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pais1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					regia_mlpais1country_Conds.Equal(CSGenioApais1.FldCodcntry, hValue);
					this.ValCodpais1 = DBConversion.ToString(hValue);
				}
			}

			TablePais1Country = new TableDBEdit<Models.Pais1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodpais1 = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}
				FillDependant_Regia_mlTablePais1Country(lazyLoad);
				return;
			}

			if (regia_mlpais1country_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePais1Country, "sTablePais1Country", "dTablePais1Country", qs, "pais1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApais1.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePais1Country_tableFilters"]))
					TablePais1Country.TableFilters = bool.Parse(qs["TablePais1Country_tableFilters"]);
				else
					TablePais1Country.TableFilters = false;

				query = qs["qTablePais1Country"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApais1.FldCountry, query + "%");
				}
				regia_mlpais1country_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePais1Country"] != null ? qs["pTablePais1Country"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApais1.FldZzstate };

// USE /[MANUAL GQT OVERRQ REGIA_ML_PAIS1COUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pais1", FormMode.New) || Navigation.checkFormMode("pais1", FormMode.Duplicate))
					regia_mlpais1country_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApais1.FldZzstate, 0)
						.Equal(CSGenioApais1.FldCodcntry, Navigation.GetStrValue("pais1")));
				else
					regia_mlpais1country_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApais1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pais1", "country");
				ListingMVC<CSGenioApais1> listing = Models.ModelBase.Where<CSGenioApais1>(m_userContext, false, regia_mlpais1country_Conds, fields, offset, numberItems, sorts, "LED_REGIA_MLPAIS1COUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePais1Country.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePais1Country.Query = query;
				TablePais1Country.Elements = listing.RowsForViewModel<GenioMVC.Models.Pais1>((r) => new GenioMVC.Models.Pais1(m_userContext, r, true, _fieldsToSerialize_REGIA_MLPAIS1COUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodpais1 = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}

				TablePais1Country.List = new SelectList(TablePais1Country.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodpais1), "Value", "Text", this.ValCodpais1);
				FillDependant_Regia_mlTablePais1Country();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePais1Country (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pais1</param>
		public ConcurrentDictionary<string, object> GetDependant_Regia_mlTablePais1Country(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry];

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

			CSGenioApais1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApais1.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePais1Country (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Regia_mlTablePais1Country(bool lazyLoad = false)
		{
			var row = GetDependant_Regia_mlTablePais1Country(this.ValCodpais1);
			try
			{

				// Fill List fields
				this.ValCodpais1 = ViewModelConversion.ToString(row["pais1.codcntry"]);
				TablePais1Country.Value = (string)row["pais1.country"];
				if (GenFunctions.emptyG(this.ValCodpais1) == 1)
				{
					this.ValCodpais1 = "";
					TablePais1Country.Value = "";
					Navigation.ClearValue("pais1");
				}
				else if (lazyLoad)
				{
					TablePais1Country.SetPagination(1, 0, false, false, 1);
					TablePais1Country.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpais1),
							Text = Convert.ToString(TablePais1Country.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpais1);
				}

				TablePais1Country.Selected = this.ValCodpais1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePais1Country): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_REGIA_MLPAIS1COUNTRY_ = ["Pais1", "Pais1.ValCodcntry", "Pais1.ValZzstate", "Pais1.ValCountry"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"regio.codcntry" => ViewModelConversion.ToString(modelValue),
				"regio.codpais1" => ViewModelConversion.ToString(modelValue),
				"regio.regiao" => ViewModelConversion.ToString(modelValue),
				"regio.codregia" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"pais1.codcntry" => ViewModelConversion.ToString(modelValue),
				"pais1.country" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIA_ML]/

		#endregion
	}
}
