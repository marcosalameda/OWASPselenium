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

namespace GenioMVC.ViewModels.Asset
{
	public class Asset_global_filter_ViewModel : FormViewModel<Models.Asset>, IPreparableForSerialization
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
		/// Title: "Kind of equipment" | Type: "CE"
		/// </summary>
		public string ValCodkinde { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodmanuf { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ParamValCodparamFilterKey { get; set; }
		public TableDBEdit<Models.Param> TableParamParamete { get; set; }

		#endregion
		/// <summary>
		/// Title: "Kind of equipment" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Kinde> TableKindeDesignat { get; set; }
		/// <summary>
		/// Title: "Asset number" | Type: "N"
		/// </summary>
		public decimal? ValAssetnum { get; set; }
		/// <summary>
		/// Title: "Asset type" | Type: "AC"
		/// </summary>
		public string ValAssettyp { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAssettyp { get; set; }

		#region Filters
		public Dictionary<string, object> DefaultFilterValues { get; private set; }

		private void LoadDefaultFilterValues()
		{
			DefaultFilterValues = new Dictionary<string, object>
			{
			};
		}


		/// <summary>
		/// TableParamParamete -> (FG/lk)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Asset_global_filter__param__paramete_fg(NameValueCollection qs, bool lazyLoad = false)
		{
			TableParamParamete = new TableDBEdit<Models.Param>
			{
				IsLazyLoad = lazyLoad
			};

			if(lazyLoad)
			{
				var historyKeyValue = Navigation.GetStrValue("param");
				IncludeSelected_Asset_global_filterTableParamParamete(historyKeyValue);
				return;
			}

			bool loadData = true;
			CriteriaSet mainCondition = CriteriaSet.And();
			if (loadData)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableParamParamete, "sTableParamParamete", "dTableParamParamete", qs, "param");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				if (!string.IsNullOrEmpty(qs["TableParamParamete_tableFilters"]))
					TableParamParamete.TableFilters = bool.Parse(qs["TableParamParamete_tableFilters"]);
				else
					TableParamParamete.TableFilters = false;

				string query = qs["qTableParamParamete"];
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
					search_filters.Like(CSGenioAparam.FldParameter, query + "%");
				mainCondition.SubSet(search_filters);

				string tryParsePage = qs["pTableParamParamete"]?.ToString() ?? "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter, CSGenioAparam.FldZzstate];

				// Limitation by Zzstate
				mainCondition.Criterias.Add(new Criteria(new ColumnReference(CSGenioAparam.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAparam> listing = Models.ModelBase.Where<CSGenioAparam>(m_userContext, false, mainCondition, fields, offset, numberItems, sorts, "FILTER_ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG", true, false, firstVisibleColumn: firstVisibleColumn);

				TableParamParamete.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableParamParamete.Query = query;
				TableParamParamete.Elements = listing.RowsForViewModel((r) => new Models.Param(m_userContext, r, true, _fieldsToSerialize_ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG));

				var currentSelected = Navigation.CurrentLevel.GetEntry<string>("global-filter-param");

				TableParamParamete.List = new SelectList(TableParamParamete.Elements.ToSelectList(x => x.ValParameter, x => x.ValCodparam,  x => x.ValCodparam == currentSelected), "Value", "Text", currentSelected);
				IncludeSelected_Asset_global_filterTableParamParamete(currentSelected);
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableParamParamete
		/// </summary>
		/// <param name="PKey">Primary Key of Param</param>
		/// <param name="returnEmptyValues"></param>
		public ConcurrentDictionary<string, object> GetDependant_Asset_global_filterTableParamParamete(string PKey, bool returnEmptyValues = true)
		{
			FieldRef[] refDependantFields = [CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter];
			
			User u = m_userContext.User;
			bool loadData = GenFunctions.emptyG(PKey) == 0;
			CriteriaSet mainCondition = CriteriaSet.And()
				.Equal(CSGenioAparam.FldCodparam, PKey);
			

			// Return default values
			if (!loadData)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			mainCondition = Models.ModelBase.AddEPH<CSGenioAparam>(ref u, mainCondition, "FILTER_ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG");
			// Select option primery key and text field
			SelectQuery querySelect = new SelectQuery()
				.PageSize(1)
				.Select(CSGenioAparam.FldCodparam)
				.Select(CSGenioAparam.FldParameter)
				.From(Area.AreaPARAM)
				.Where(mainCondition);

			string[] dependantFields = [.. refDependantFields.Select(f => f.FullName)];
			QueryUtils.SetInnerJoins(dependantFields, mainCondition, new CSGenioAparam(u), querySelect);

			ArrayList values = m_userContext.PersistentSupport.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			// Return default values
			if (useDefaults)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Get Dependant fields values -> TableParamParamete
		/// </summary>
		/// <param name="selectedKey">Primary Key of Param</param>
		/// <param name="returnEmptyValues"></param>
		public void IncludeSelected_Asset_global_filterTableParamParamete(string selectedKey)
		{
			bool tryIncludeSelected = GenFunctions.emptyG(selectedKey) == 0 && TableParamParamete.List?.Any(item => item.Value == selectedKey) != true;
			if (tryIncludeSelected)
			{
				var row = GetDependant_Asset_global_filterTableParamParamete(selectedKey, false);
				if(row != null)
				{
					TableParamParamete.Value = ViewModelConversion.ToString(row[CSGenioAparam.FldParameter]);
					var selectedItem = new SelectListItem()
					{
						Value = Convert.ToString(selectedKey),
						Text = Convert.ToString(TableParamParamete.Value),
						Selected = true

					};
					var items = TableParamParamete.List == null ? [selectedItem] : TableParamParamete.List.Prepend(selectedItem);
					TableParamParamete.List = new SelectList(items, "Value", "Text", selectedKey);
					TableParamParamete.Selected = selectedKey;
					ParamValCodparamFilterKey = selectedKey;
				}
				else
				{
					TableParamParamete.Selected = null;
					ParamValCodparamFilterKey = null;
				}
			}
		}

		private readonly string[] _fieldsToSerialize_ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG = ["Param", "Param.ValCodparam", "Param.ValZzstate"];
		#endregion

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Identification name" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string ValName { get; set; }

		#endregion

		public string ValCodasset { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Asset_global_filter_ViewModel() : base(null!) { }

		public Asset_global_filter_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FASSET_GLOBAL_FILTER", nestedForm) { }

		public Asset_global_filter_ViewModel(UserContext userContext, Models.Asset row, bool nestedForm = false) : base(userContext, "FASSET_GLOBAL_FILTER", row, nestedForm) { }

		public Asset_global_filter_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("asset", id);
			Model = Models.Asset.Find(id, userContext, "FASSET_GLOBAL_FILTER", fieldsToQuery: fieldsToLoad);
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
			Models.Asset model = new Models.Asset(userContext) { Identifier = "FASSET_GLOBAL_FILTER" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FASSET_GLOBAL_FILTER");
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
		public override void MapFromModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Asset_global_filter) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
				ValCodmanuf = ViewModelConversion.ToString(m.ValCodmanuf);
				ValAssetnum = ViewModelConversion.ToNumeric(m.ValAssetnum);
				ValAssettyp = ViewModelConversion.ToString(m.ValAssettyp);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Asset_global_filter) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Asset_global_filter) to Model (Asset) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
				m.ValAssetnum = ViewModelConversion.ToNumeric(ValAssetnum);
				m.ValAssettyp = ViewModelConversion.ToString(ValAssettyp);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodmanuf = ViewModelConversion.ToString(ValCodmanuf);
				m.ValName = ViewModelConversion.ToString(ValName);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Asset_global_filter) to Model (Asset) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "asset.codkinde":
						this.ValCodkinde = ViewModelConversion.ToString(_value);
						break;
					case "asset.assetnum":
						this.ValAssetnum = ViewModelConversion.ToNumeric(_value);
						break;
					case "asset.assettyp":
						this.ValAssettyp = ViewModelConversion.ToString(_value);
						break;
					case "asset.codasset":
						this.ValCodasset = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Asset_global_filter) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Asset_global_filter)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Asset.Find(id ?? Navigation.GetStrValue("asset"), m_userContext, "FASSET_GLOBAL_FILTER"); }
			finally { Model ??= new Models.Asset(m_userContext) { Identifier = "FASSET_GLOBAL_FILTER" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FASSET_GLOBAL_FILTER");
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

			Model.Identifier = "FASSET_GLOBAL_FILTER";
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
			LoadDefaultFilterValues();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Asset row)
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
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FASSET_GLOBAL_FILTER");
				if (Model == null)
				{
					Model = new Models.Asset(m_userContext) { Identifier = "FASSET_GLOBAL_FILTER" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("asset");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Asset_global_filter__kinde__designat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ASSET_GLOBAL_FILTER]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ASSET_GLOBAL_FILTER]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValAssettyp", Resources.Resources.ASSET_TYPE02033, ViewModelConversion.ToString(ValAssettyp), FieldType.ARRAY_TEXT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ASSET_GLOBAL_FILTER]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ASSET_GLOBAL_FILTER]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ASSET_GLOBAL_FILTER]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ASSET_GLOBAL_FILTER]/
		public override void Destroy(string id)
		{
			Model = Models.Asset.Find(id, m_userContext, "FASSET_GLOBAL_FILTER");
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
		/// TableKindeDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Asset_global_filter__kinde__designat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool asset_global_filter__kinde__designatDoLoad = true;
			CriteriaSet asset_global_filter__kinde__designatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("kinde", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					asset_global_filter__kinde__designatConds.Equal(CSGenioAkinde.FldCodkinde, hValue);
					this.ValCodkinde = DBConversion.ToString(hValue);
				}
			}

			TableKindeDesignat = new TableDBEdit<Models.Kinde>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}
				FillDependant_Asset_global_filterTableKindeDesignat(lazyLoad);
				return;
			}

			if (asset_global_filter__kinde__designatDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableKindeDesignat, "sTableKindeDesignat", "dTableKindeDesignat", qs, "kinde");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableKindeDesignat_tableFilters"]))
					TableKindeDesignat.TableFilters = bool.Parse(qs["TableKindeDesignat_tableFilters"]);
				else
					TableKindeDesignat.TableFilters = false;

				query = qs["qTableKindeDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAkinde.FldDesignat, query + "%");
				}
				asset_global_filter__kinde__designatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableKindeDesignat"] != null ? qs["pTableKindeDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAkinde.FldZzstate];

// USE /[MANUAL GQT OVERRQ ASSET_GLOBAL_FILTER_KINDEDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("kinde", FormMode.New) || Navigation.checkFormMode("kinde", FormMode.Duplicate))
					asset_global_filter__kinde__designatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAkinde.FldZzstate, 0)
						.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetStrValue("kinde")));
				else
					asset_global_filter__kinde__designatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAkinde.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("kinde", "designat");
				ListingMVC<CSGenioAkinde> listing = Models.ModelBase.Where<CSGenioAkinde>(m_userContext, false, asset_global_filter__kinde__designatConds, fields, offset, numberItems, sorts, "LED_ASSET_GLOBAL_FILTER__KINDE__DESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableKindeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableKindeDesignat.Query = query;
				TableKindeDesignat.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Kinde(m_userContext, r, true, _fieldsToSerialize_ASSET_GLOBAL_FILTER__KINDE__DESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}

				TableKindeDesignat.List = new SelectList(TableKindeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodkinde,  x => x.ValCodkinde == this.ValCodkinde), "Value", "Text", this.ValCodkinde);
				FillDependant_Asset_global_filterTableKindeDesignat();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Kinde</param>
		public ConcurrentDictionary<string, object> GetDependant_Asset_global_filterTableKindeDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat];

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

			CSGenioAkinde tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAkinde.FldCodkinde, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Asset_global_filterTableKindeDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_Asset_global_filterTableKindeDesignat(this.ValCodkinde);
			try
			{

				// Fill List fields
				this.ValCodkinde = ViewModelConversion.ToString(row["kinde.codkinde"]);
				TableKindeDesignat.Value = (string)row["kinde.designat"];
				if (GenFunctions.emptyG(this.ValCodkinde) == 1)
				{
					this.ValCodkinde = "";
					TableKindeDesignat.Value = "";
					Navigation.ClearValue("kinde");
				}
				else if (lazyLoad)
				{
					TableKindeDesignat.SetPagination(1, 0, false, false, 1);
					TableKindeDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodkinde),
							Text = Convert.ToString(TableKindeDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodkinde);
				}

				TableKindeDesignat.Selected = this.ValCodkinde;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableKindeDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ASSET_GLOBAL_FILTER__KINDE__DESIGNAT = ["Kinde", "Kinde.ValCodkinde", "Kinde.ValZzstate", "Kinde.ValDesignat"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"asset.codkinde" => ViewModelConversion.ToString(modelValue),
				"asset.codmanuf" => ViewModelConversion.ToString(modelValue),
				"asset.assetnum" => ViewModelConversion.ToNumeric(modelValue),
				"asset.assettyp" => ViewModelConversion.ToString(modelValue),
				"asset.name" => ViewModelConversion.ToString(modelValue),
				"asset.codasset" => ViewModelConversion.ToString(modelValue),
				"kinde.codkinde" => ViewModelConversion.ToString(modelValue),
				"kinde.designat" => ViewModelConversion.ToString(modelValue),
				"param.codparam" => ViewModelConversion.ToString(modelValue),
				"param.parameter" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSET_GLOBAL_FILTER]/

		#endregion
	}
}
