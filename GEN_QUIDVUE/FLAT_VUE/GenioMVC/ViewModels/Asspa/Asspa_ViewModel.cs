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

namespace GenioMVC.ViewModels.Asspa
{
	public class Asspa_ViewModel : FormViewModel<Models.Asspa>, IPreparableForSerialization
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
		/// Title: "Identification name" | Type: "CE"
		/// </summary>
		public string ValCodasset { get; set; }
		/// <summary>
		/// Title: "Parameter" | Type: "CE"
		/// </summary>
		public string ValCodparam { get; set; }

		#endregion
		/// <summary>
		/// Title: "Identification name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Asset> TableAssetName { get; set; }
		/// <summary>
		/// Title: "Data type" | Type: "AC"
		/// </summary>
		public string ValDatatype { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValDatatype { get; set; }
		/// <summary>
		/// Title: "Decimal places" | Type: "N"
		/// </summary>
		public decimal? ValDecimalplaces { get; set; }
		/// <summary>
		/// Title: "Parameter" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Param> TableParamParamete { get; set; }
		/// <summary>
		/// Title: "Text" | Type: "C"
		/// </summary>
		public string ValText { get; set; }
		/// <summary>
		/// Title: "Quantity" | Type: "N"
		/// </summary>
		public decimal? ValQuantity { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "To show" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValToshow { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodasspa { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Asspa_ViewModel() : base(null!) { }

		public Asspa_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FASSPA", nestedForm) { }

		public Asspa_ViewModel(UserContext userContext, Models.Asspa row, bool nestedForm = false) : base(userContext, "FASSPA", row, nestedForm) { }

		public Asspa_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("asspa", id);
			Model = Models.Asspa.Find(id, userContext, "FASSPA", fieldsToQuery: fieldsToLoad);
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
			Models.Asspa model = new Models.Asspa(userContext) { Identifier = "FASSPA" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FASSPA");
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
			Models.Asspa model = Model;
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
		public override void MapFromModel(Models.Asspa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Asspa) to ViewModel (Asspa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
				ValCodparam = ViewModelConversion.ToString(m.ValCodparam);
				ValDatatype = ViewModelConversion.ToString(m.ValDatatype);
				ValDecimalplaces = ViewModelConversion.ToNumeric(m.ValDecimalplaces);
				ValText = ViewModelConversion.ToString(m.ValText);
				ValQuantity = ViewModelConversion.ToNumeric(m.ValQuantity);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValToshow = ViewModelConversion.ToString(m.ValToshow);
				ValCodasspa = ViewModelConversion.ToString(m.ValCodasspa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Asspa) to ViewModel (Asspa) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Asspa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Asspa) to Model (Asspa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodparam = ViewModelConversion.ToString(ValCodparam);
				m.ValDatatype = ViewModelConversion.ToString(ValDatatype);
				m.ValDecimalplaces = ViewModelConversion.ToNumeric(ValDecimalplaces);
				m.ValText = ViewModelConversion.ToString(ValText);
				m.ValQuantity = ViewModelConversion.ToNumeric(ValQuantity);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValCodasspa = ViewModelConversion.ToString(ValCodasspa);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValToshow = ViewModelConversion.ToString(ValToshow);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Asspa) to Model (Asspa) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "asspa.codasset":
						this.ValCodasset = ViewModelConversion.ToString(_value);
						break;
					case "asspa.codparam":
						this.ValCodparam = ViewModelConversion.ToString(_value);
						break;
					case "asspa.datatype":
						this.ValDatatype = ViewModelConversion.ToString(_value);
						break;
					case "asspa.decimalplaces":
						this.ValDecimalplaces = ViewModelConversion.ToNumeric(_value);
						break;
					case "asspa.text":
						this.ValText = ViewModelConversion.ToString(_value);
						break;
					case "asspa.quantity":
						this.ValQuantity = ViewModelConversion.ToNumeric(_value);
						break;
					case "asspa.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "asspa.codasspa":
						this.ValCodasspa = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Asspa) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Asspa)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Asspa.Find(id ?? Navigation.GetStrValue("asspa"), m_userContext, "FASSPA"); }
			finally { Model ??= new Models.Asspa(m_userContext) { Identifier = "FASSPA" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), m_userContext, "FASSPA");
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

			Model.Identifier = "FASSPA";
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

		protected override void LoadDocumentsProperties(Models.Asspa row)
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
				Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), m_userContext, "FASSPA");
				if (Model == null)
				{
					Model = new Models.Asspa(m_userContext) { Identifier = "FASSPA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("asspa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Asspa___assetname____(qs, lazyLoad);
			Load_Asspa___paramparamete(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ASSPA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ASSPA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValDatatype", Resources.Resources.DATA_TYPE47159, ViewModelConversion.ToString(ValDatatype), FieldType.ARRAY_TEXT.GetFormatting());
			validator.StringLength("ValText", Resources.Resources.TEXT04938, ValText, 50);
			validator.StringLength("ValToshow", Resources.Resources.TO_SHOW13268, ValToshow, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ASSPA]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ASSPA]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ASSPA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ASSPA]/
		public override void Destroy(string id)
		{
			Model = Models.Asspa.Find(id, m_userContext, "FASSPA");
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
		/// TableAssetName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Asspa___assetname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool asspa___assetname____DoLoad = true;
			CriteriaSet asspa___assetname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("asset", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					asspa___assetname____Conds.Equal(CSGenioAasset.FldCodasset, hValue);
					this.ValCodasset = DBConversion.ToString(hValue);
				}
			}

			TableAssetName = new TableDBEdit<Models.Asset>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}
				FillDependant_AsspaTableAssetName(lazyLoad);
				return;
			}

			if (asspa___assetname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAssetName, "sTableAssetName", "dTableAssetName", qs, "asset");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAssetName_tableFilters"]))
					TableAssetName.TableFilters = bool.Parse(qs["TableAssetName_tableFilters"]);
				else
					TableAssetName.TableFilters = false;

				query = qs["qTableAssetName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAasset.FldName, query + "%");
				}
				asspa___assetname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSPA_ASSETNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
					asspa___assetname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAasset.FldZzstate, 0)
						.Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
				else
					asspa___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("asset", "name");
				ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(m_userContext, false, asspa___assetname____Conds, fields, offset, numberItems, sorts, "LED_ASSPA___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAssetName.Query = query;
				TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(m_userContext, r, true, _fieldsToSerialize_ASSPA___ASSETNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
				FillDependant_AsspaTableAssetName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAssetName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Asset</param>
		public ConcurrentDictionary<string, object> GetDependant_AsspaTableAssetName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAasset.FldCodasset, CSGenioAasset.FldName];

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

			CSGenioAasset tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAasset.FldCodasset, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAssetName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AsspaTableAssetName(bool lazyLoad = false)
		{
			var row = GetDependant_AsspaTableAssetName(this.ValCodasset);
			try
			{

				// Fill List fields
				this.ValCodasset = ViewModelConversion.ToString(row["asset.codasset"]);
				TableAssetName.Value = (string)row["asset.name"];
				if (GenFunctions.emptyG(this.ValCodasset) == 1)
				{
					this.ValCodasset = "";
					TableAssetName.Value = "";
					Navigation.ClearValue("asset");
				}
				else if (lazyLoad)
				{
					TableAssetName.SetPagination(1, 0, false, false, 1);
					TableAssetName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodasset),
							Text = Convert.ToString(TableAssetName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodasset);
				}

				TableAssetName.Selected = this.ValCodasset;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAssetName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ASSPA___ASSETNAME____ = ["Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName"];

		/// <summary>
		/// TableParamParamete -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Asspa___paramparamete(NameValueCollection qs, bool lazyLoad = false)
		{
			bool asspa___paramparameteDoLoad = true;
			CriteriaSet asspa___paramparameteConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("param", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					asspa___paramparameteConds.Equal(CSGenioAparam.FldCodparam, hValue);
					this.ValCodparam = DBConversion.ToString(hValue);
				}
			}

			TableParamParamete = new TableDBEdit<Models.Param>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_param") != null)
				{
					this.ValCodparam = Navigation.GetStrValue("RETURN_param");
					Navigation.CurrentLevel.SetEntry("RETURN_param", null);
				}
				FillDependant_AsspaTableParamParamete(lazyLoad);
				return;
			}

			if (asspa___paramparameteDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableParamParamete, "sTableParamParamete", "dTableParamParamete", qs, "param");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAparam.FldParameter), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableParamParamete_tableFilters"]))
					TableParamParamete.TableFilters = bool.Parse(qs["TableParamParamete_tableFilters"]);
				else
					TableParamParamete.TableFilters = false;

				query = qs["qTableParamParamete"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAparam.FldParameter, query + "%");
				}
				asspa___paramparameteConds.SubSet(search_filters);

				string tryParsePage = qs["pTableParamParamete"] != null ? qs["pTableParamParamete"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter, CSGenioAparam.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSPA_PARAMPARAMETE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("param", FormMode.New) || Navigation.checkFormMode("param", FormMode.Duplicate))
					asspa___paramparameteConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAparam.FldZzstate, 0)
						.Equal(CSGenioAparam.FldCodparam, Navigation.GetStrValue("param")));
				else
					asspa___paramparameteConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAparam.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("param", "parameter");
				ListingMVC<CSGenioAparam> listing = Models.ModelBase.Where<CSGenioAparam>(m_userContext, false, asspa___paramparameteConds, fields, offset, numberItems, sorts, "LED_ASSPA___PARAMPARAMETE", true, false, firstVisibleColumn: firstVisibleColumn);

				TableParamParamete.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableParamParamete.Query = query;
				TableParamParamete.Elements = listing.RowsForViewModel<GenioMVC.Models.Param>((r) => new GenioMVC.Models.Param(m_userContext, r, true, _fieldsToSerialize_ASSPA___PARAMPARAMETE));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_param") != null)
				{
					this.ValCodparam = Navigation.GetStrValue("RETURN_param");
					Navigation.CurrentLevel.SetEntry("RETURN_param", null);
				}

				TableParamParamete.List = new SelectList(TableParamParamete.Elements.ToSelectList(x => x.ValParameter, x => x.ValCodparam,  x => x.ValCodparam == this.ValCodparam), "Value", "Text", this.ValCodparam);
				FillDependant_AsspaTableParamParamete();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableParamParamete (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Param</param>
		public ConcurrentDictionary<string, object> GetDependant_AsspaTableParamParamete(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter];

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

			CSGenioAparam tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAparam.FldCodparam, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableParamParamete (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AsspaTableParamParamete(bool lazyLoad = false)
		{
			var row = GetDependant_AsspaTableParamParamete(this.ValCodparam);
			try
			{

				// Fill List fields
				this.ValCodparam = ViewModelConversion.ToString(row["param.codparam"]);
				TableParamParamete.Value = (string)row["param.parameter"];
				if (GenFunctions.emptyG(this.ValCodparam) == 1)
				{
					this.ValCodparam = "";
					TableParamParamete.Value = "";
					Navigation.ClearValue("param");
				}
				else if (lazyLoad)
				{
					TableParamParamete.SetPagination(1, 0, false, false, 1);
					TableParamParamete.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodparam),
							Text = Convert.ToString(TableParamParamete.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodparam);
				}

				TableParamParamete.Selected = this.ValCodparam;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableParamParamete): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ASSPA___PARAMPARAMETE = ["Param", "Param.ValCodparam", "Param.ValZzstate", "Param.ValParameter"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"asspa.codasset" => ViewModelConversion.ToString(modelValue),
				"asspa.codparam" => ViewModelConversion.ToString(modelValue),
				"asspa.datatype" => ViewModelConversion.ToString(modelValue),
				"asspa.decimalplaces" => ViewModelConversion.ToNumeric(modelValue),
				"asspa.text" => ViewModelConversion.ToString(modelValue),
				"asspa.quantity" => ViewModelConversion.ToNumeric(modelValue),
				"asspa.date" => ViewModelConversion.ToDateTime(modelValue),
				"asspa.toshow" => ViewModelConversion.ToString(modelValue),
				"asspa.codasspa" => ViewModelConversion.ToString(modelValue),
				"asset.codasset" => ViewModelConversion.ToString(modelValue),
				"asset.name" => ViewModelConversion.ToString(modelValue),
				"param.codparam" => ViewModelConversion.ToString(modelValue),
				"param.parameter" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSPA]/

		#endregion
	}
}
