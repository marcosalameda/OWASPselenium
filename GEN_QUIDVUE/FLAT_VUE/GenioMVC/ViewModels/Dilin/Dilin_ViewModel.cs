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

namespace GenioMVC.ViewModels.Dilin
{
	public class Dilin_ViewModel : FormViewModel<Models.Dilin>, IPreparableForSerialization
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
		/// Title: "Dispatch number" | Type: "CE"
		/// </summary>
		public string ValCoddispa { get; set; }
		/// <summary>
		/// Title: "Product" | Type: "CE"
		/// </summary>
		public string ValCodprodu { get; set; }

		#endregion
		/// <summary>
		/// Title: "Dispatch number" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Dispa> TableDispaDispanr { get; set; }
		/// <summary>
		/// Title: "Line" | Type: "N"
		/// </summary>
		public decimal? ValLinenumb { get; set; }
		/// <summary>
		/// Title: "Product" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Produ> TableProduProduct { get; set; }
		/// <summary>
		/// Title: "Ordered" | Type: "N"
		/// </summary>
		public decimal? ValOrdered { get; set; }
		/// <summary>
		/// Title: "Delivered" | Type: "N"
		/// </summary>
		public decimal? ValDelivere { get; set; }
		/// <summary>
		/// Title: "Outstanding" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValOutstand { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddilin { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dilin_ViewModel() : base(null!) { }

		public Dilin_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDILIN", nestedForm) { }

		public Dilin_ViewModel(UserContext userContext, Models.Dilin row, bool nestedForm = false) : base(userContext, "FDILIN", row, nestedForm) { }

		public Dilin_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("dilin", id);
			Model = Models.Dilin.Find(id, userContext, "FDILIN", fieldsToQuery: fieldsToLoad);
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
			Models.Dilin model = new Models.Dilin(userContext) { Identifier = "FDILIN" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDILIN");
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
		public override void MapFromModel(Models.Dilin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Dilin) to ViewModel (Dilin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCoddispa = ViewModelConversion.ToString(m.ValCoddispa);
				ValCodprodu = ViewModelConversion.ToString(m.ValCodprodu);
				ValLinenumb = ViewModelConversion.ToNumeric(m.ValLinenumb);
				ValOrdered = ViewModelConversion.ToNumeric(m.ValOrdered);
				ValDelivere = ViewModelConversion.ToNumeric(m.ValDelivere);
				ValOutstand = ViewModelConversion.ToNumeric(m.ValOutstand);
				ValCoddilin = ViewModelConversion.ToString(m.ValCoddilin);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Dilin) to ViewModel (Dilin) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Dilin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dilin) to Model (Dilin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCoddispa = ViewModelConversion.ToString(ValCoddispa);
				m.ValCodprodu = ViewModelConversion.ToString(ValCodprodu);
				m.ValLinenumb = ViewModelConversion.ToNumeric(ValLinenumb);
				m.ValOrdered = ViewModelConversion.ToNumeric(ValOrdered);
				m.ValDelivere = ViewModelConversion.ToNumeric(ValDelivere);
				m.ValCoddilin = ViewModelConversion.ToString(ValCoddilin);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValOutstand = ViewModelConversion.ToNumeric(ValOutstand);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Dilin) to Model (Dilin) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "dilin.coddispa":
						this.ValCoddispa = ViewModelConversion.ToString(_value);
						break;
					case "dilin.codprodu":
						this.ValCodprodu = ViewModelConversion.ToString(_value);
						break;
					case "dilin.linenumb":
						this.ValLinenumb = ViewModelConversion.ToNumeric(_value);
						break;
					case "dilin.ordered":
						this.ValOrdered = ViewModelConversion.ToNumeric(_value);
						break;
					case "dilin.delivere":
						this.ValDelivere = ViewModelConversion.ToNumeric(_value);
						break;
					case "dilin.coddilin":
						this.ValCoddilin = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Dilin) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Dilin)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Dilin.Find(id ?? Navigation.GetStrValue("dilin"), m_userContext, "FDILIN"); }
			finally { Model ??= new Models.Dilin(m_userContext) { Identifier = "FDILIN" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), m_userContext, "FDILIN");
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

			Model.Identifier = "FDILIN";
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

		protected override void LoadDocumentsProperties(Models.Dilin row)
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
				Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), m_userContext, "FDILIN");
				if (Model == null)
				{
					Model = new Models.Dilin(m_userContext) { Identifier = "FDILIN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dilin");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Dilin___dispadispanr_(qs, lazyLoad);
			Load_Dilin___produproduct_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DILIN]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DILIN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodprodu", Resources.Resources.PRODUCT12880, ViewModelConversion.ToString(ValCodprodu), FieldType.KEY_GUID.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE DILIN]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DILIN]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DILIN]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DILIN]/
		public override void Destroy(string id)
		{
			Model = Models.Dilin.Find(id, m_userContext, "FDILIN");
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
		/// TableDispaDispanr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dilin___dispadispanr_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dilin___dispadispanr_DoLoad = true;
			CriteriaSet dilin___dispadispanr_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("dispa", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dilin___dispadispanr_Conds.Equal(CSGenioAdispa.FldCoddispa, hValue);
					this.ValCoddispa = DBConversion.ToString(hValue);
				}
			}

			TableDispaDispanr = new TableDBEdit<Models.Dispa>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_dispa") != null)
				{
					this.ValCoddispa = Navigation.GetStrValue("RETURN_dispa");
					Navigation.CurrentLevel.SetEntry("RETURN_dispa", null);
				}
				FillDependant_DilinTableDispaDispanr(lazyLoad);
				return;
			}

			if (dilin___dispadispanr_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableDispaDispanr, "sTableDispaDispanr", "dTableDispaDispanr", qs, "dispa");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableDispaDispanr_tableFilters"]))
					TableDispaDispanr.TableFilters = bool.Parse(qs["TableDispaDispanr_tableFilters"]);
				else
					TableDispaDispanr.TableFilters = false;

				query = qs["qTableDispaDispanr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAdispa.FldDispanr, query + "%");
				}
				dilin___dispadispanr_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableDispaDispanr"] != null ? qs["pTableDispaDispanr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldDispanr, CSGenioAdispa.FldZzstate };

// USE /[MANUAL GQT OVERRQ DILIN_DISPADISPANR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("dispa", FormMode.New) || Navigation.checkFormMode("dispa", FormMode.Duplicate))
					dilin___dispadispanr_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAdispa.FldZzstate, 0)
						.Equal(CSGenioAdispa.FldCoddispa, Navigation.GetStrValue("dispa")));
				else
					dilin___dispadispanr_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAdispa.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("dispa", "dispanr");
				ListingMVC<CSGenioAdispa> listing = Models.ModelBase.Where<CSGenioAdispa>(m_userContext, false, dilin___dispadispanr_Conds, fields, offset, numberItems, sorts, "LED_DILIN___DISPADISPANR_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableDispaDispanr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableDispaDispanr.Query = query;
				TableDispaDispanr.Elements = listing.RowsForViewModel<GenioMVC.Models.Dispa>((r) => new GenioMVC.Models.Dispa(m_userContext, r, true, _fieldsToSerialize_DILIN___DISPADISPANR_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_dispa") != null)
				{
					this.ValCoddispa = Navigation.GetStrValue("RETURN_dispa");
					Navigation.CurrentLevel.SetEntry("RETURN_dispa", null);
				}

				TableDispaDispanr.List = new SelectList(TableDispaDispanr.Elements.ToSelectList(x => x.ValDispanr, x => x.ValCoddispa,  x => x.ValCoddispa == this.ValCoddispa), "Value", "Text", this.ValCoddispa);
				FillDependant_DilinTableDispaDispanr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableDispaDispanr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Dispa</param>
		public ConcurrentDictionary<string, object> GetDependant_DilinTableDispaDispanr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldDispanr];

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

			CSGenioAdispa tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAdispa.FldCoddispa, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableDispaDispanr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DilinTableDispaDispanr(bool lazyLoad = false)
		{
			var row = GetDependant_DilinTableDispaDispanr(this.ValCoddispa);
			try
			{

				// Fill List fields
				this.ValCoddispa = ViewModelConversion.ToString(row["dispa.coddispa"]);
				TableDispaDispanr.Value = (decimal?)row["dispa.dispanr"];
				if (GenFunctions.emptyG(this.ValCoddispa) == 1)
				{
					this.ValCoddispa = "";
					TableDispaDispanr.Value = 0m;
					Navigation.ClearValue("dispa");
				}
				else if (lazyLoad)
				{
					TableDispaDispanr.SetPagination(1, 0, false, false, 1);
					TableDispaDispanr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoddispa),
							Text = Convert.ToString(TableDispaDispanr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoddispa);
				}

				TableDispaDispanr.Selected = this.ValCoddispa;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableDispaDispanr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DILIN___DISPADISPANR_ = ["Dispa", "Dispa.ValCoddispa", "Dispa.ValZzstate", "Dispa.ValDispanr"];

		/// <summary>
		/// TableProduProduct -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dilin___produproduct_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dilin___produproduct_DoLoad = true;
			CriteriaSet dilin___produproduct_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("produ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dilin___produproduct_Conds.Equal(CSGenioAprodu.FldCodprodu, hValue);
					this.ValCodprodu = DBConversion.ToString(hValue);
				}
			}

			TableProduProduct = new TableDBEdit<Models.Produ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_produ") != null)
				{
					this.ValCodprodu = Navigation.GetStrValue("RETURN_produ");
					Navigation.CurrentLevel.SetEntry("RETURN_produ", null);
				}
				FillDependant_DilinTableProduProduct(lazyLoad);
				return;
			}

			if (dilin___produproduct_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableProduProduct, "sTableProduProduct", "dTableProduProduct", qs, "produ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAprodu.FldProduct), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableProduProduct_tableFilters"]))
					TableProduProduct.TableFilters = bool.Parse(qs["TableProduProduct_tableFilters"]);
				else
					TableProduProduct.TableFilters = false;

				query = qs["qTableProduProduct"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAprodu.FldProduct, query + "%");
				}
				dilin___produproduct_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableProduProduct"] != null ? qs["pTableProduProduct"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct, CSGenioAprodu.FldZzstate };

// USE /[MANUAL GQT OVERRQ DILIN_PRODUPRODUCT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("produ", FormMode.New) || Navigation.checkFormMode("produ", FormMode.Duplicate))
					dilin___produproduct_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAprodu.FldZzstate, 0)
						.Equal(CSGenioAprodu.FldCodprodu, Navigation.GetStrValue("produ")));
				else
					dilin___produproduct_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAprodu.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("produ", "product");
				ListingMVC<CSGenioAprodu> listing = Models.ModelBase.Where<CSGenioAprodu>(m_userContext, false, dilin___produproduct_Conds, fields, offset, numberItems, sorts, "LED_DILIN___PRODUPRODUCT_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableProduProduct.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableProduProduct.Query = query;
				TableProduProduct.Elements = listing.RowsForViewModel<GenioMVC.Models.Produ>((r) => new GenioMVC.Models.Produ(m_userContext, r, true, _fieldsToSerialize_DILIN___PRODUPRODUCT_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_produ") != null)
				{
					this.ValCodprodu = Navigation.GetStrValue("RETURN_produ");
					Navigation.CurrentLevel.SetEntry("RETURN_produ", null);
				}

				TableProduProduct.List = new SelectList(TableProduProduct.Elements.ToSelectList(x => x.ValProduct, x => x.ValCodprodu,  x => x.ValCodprodu == this.ValCodprodu), "Value", "Text", this.ValCodprodu);
				//Seleciona se só um
				if (TableProduProduct.List != null && TableProduProduct.List.Count() == 1)
				{
					this.ValCodprodu = TableProduProduct.List.First().Value;
					Navigation.SetValue("produ", this.ValCodprodu);
				}
				FillDependant_DilinTableProduProduct();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableProduProduct (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Produ</param>
		public ConcurrentDictionary<string, object> GetDependant_DilinTableProduProduct(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct];

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

			CSGenioAprodu tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAprodu.FldCodprodu, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableProduProduct (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DilinTableProduProduct(bool lazyLoad = false)
		{
			var row = GetDependant_DilinTableProduProduct(this.ValCodprodu);
			try
			{

				// Fill List fields
				this.ValCodprodu = ViewModelConversion.ToString(row["produ.codprodu"]);
				TableProduProduct.Value = (string)row["produ.product"];
				if (GenFunctions.emptyG(this.ValCodprodu) == 1)
				{
					this.ValCodprodu = "";
					TableProduProduct.Value = "";
					Navigation.ClearValue("produ");
				}
				else if (lazyLoad)
				{
					TableProduProduct.SetPagination(1, 0, false, false, 1);
					TableProduProduct.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodprodu),
							Text = Convert.ToString(TableProduProduct.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodprodu);
				}

				TableProduProduct.Selected = this.ValCodprodu;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableProduProduct): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DILIN___PRODUPRODUCT_ = ["Produ", "Produ.ValCodprodu", "Produ.ValZzstate", "Produ.ValProduct"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"dilin.coddispa" => ViewModelConversion.ToString(modelValue),
				"dilin.codprodu" => ViewModelConversion.ToString(modelValue),
				"dilin.linenumb" => ViewModelConversion.ToNumeric(modelValue),
				"dilin.ordered" => ViewModelConversion.ToNumeric(modelValue),
				"dilin.delivere" => ViewModelConversion.ToNumeric(modelValue),
				"dilin.outstand" => ViewModelConversion.ToNumeric(modelValue),
				"dilin.coddilin" => ViewModelConversion.ToString(modelValue),
				"dispa.coddispa" => ViewModelConversion.ToString(modelValue),
				"dispa.dispanr" => ViewModelConversion.ToNumeric(modelValue),
				"produ.codprodu" => ViewModelConversion.ToString(modelValue),
				"produ.product" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DILIN]/

		#endregion
	}
}
