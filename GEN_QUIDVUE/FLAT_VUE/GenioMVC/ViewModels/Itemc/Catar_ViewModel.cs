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

namespace GenioMVC.ViewModels.Itemc
{
	public class Catar_ViewModel : FormViewModel<Models.Itemc>, IPreparableForSerialization
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
		/// Title: "Category type" | Type: "CE"
		/// </summary>
		public string ValCodtpcat { get; set; }
		/// <summary>
		/// Title: "Item:" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }

		#endregion
		/// <summary>
		/// Title: "Item:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemItemdes { get; set; }
		/// <summary>
		/// Title: "Category type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cattp> TableCattpTpcatego { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Category type" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string ValTpcateg { get; set; }

		#endregion

		public string ValCodcatar { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Catar_ViewModel() : base(null!) { }

		public Catar_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCATAR", nestedForm) { }

		public Catar_ViewModel(UserContext userContext, Models.Itemc row, bool nestedForm = false) : base(userContext, "FCATAR", row, nestedForm) { }

		public Catar_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("itemc", id);
			Model = Models.Itemc.Find(id, userContext, "FCATAR", fieldsToQuery: fieldsToLoad);
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
			Models.Itemc model = new Models.Itemc(userContext) { Identifier = "FCATAR" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCATAR");
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
			Models.Itemc model = Model;
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
		public override void MapFromModel(Models.Itemc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Itemc) to ViewModel (Catar) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodtpcat = ViewModelConversion.ToString(m.ValCodtpcat);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValTpcateg = ViewModelConversion.ToString(m.ValTpcateg);
				ValCodcatar = ViewModelConversion.ToString(m.ValCodcatar);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Itemc) to ViewModel (Catar) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Itemc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Catar) to Model (Itemc) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodtpcat = ViewModelConversion.ToString(ValCodtpcat);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodcatar = ViewModelConversion.ToString(ValCodcatar);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValTpcateg = ViewModelConversion.ToString(ValTpcateg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Catar) to Model (Itemc) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "itemc.codtpcat":
						this.ValCodtpcat = ViewModelConversion.ToString(_value);
						break;
					case "itemc.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					case "itemc.codcatar":
						this.ValCodcatar = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Catar) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Catar)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Itemc.Find(id ?? Navigation.GetStrValue("itemc"), m_userContext, "FCATAR"); }
			finally { Model ??= new Models.Itemc(m_userContext) { Identifier = "FCATAR" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), m_userContext, "FCATAR");
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

			Model.Identifier = "FCATAR";
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

		protected override void LoadDocumentsProperties(Models.Itemc row)
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
				Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), m_userContext, "FCATAR");
				if (Model == null)
				{
					Model = new Models.Itemc(m_userContext) { Identifier = "FCATAR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("itemc");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Catar___item_itemdes_(qs, lazyLoad);
			Load_Catar___cattptpcatego(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CATAR]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CATAR]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE CATAR]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CATAR]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CATAR]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CATAR]/
		public override void Destroy(string id)
		{
			Model = Models.Itemc.Find(id, m_userContext, "FCATAR");
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
		/// TableItemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Catar___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool catar___item_itemdes_DoLoad = true;
			CriteriaSet catar___item_itemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("item", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					catar___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValCoditem = DBConversion.ToString(hValue);
				}
			}

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
				FillDependant_CatarTableItemItemdes(lazyLoad);
				return;
			}

			if (catar___item_itemdes_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemdes), SortOrder.Ascending));

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
				catar___item_itemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ CATAR_ITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					catar___item_itemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					catar___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, catar___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_CATAR___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemItemdes.Query = query;
				TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_CATAR___ITEM_ITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
				FillDependant_CatarTableItemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_CatarTableItemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes];

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
		public void FillDependant_CatarTableItemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_CatarTableItemItemdes(this.ValCoditem);
			try
			{

				// Fill List fields
				this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemItemdes.Value = (string)row["item.itemdes"];
				if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
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

		private readonly string[] _fieldsToSerialize_CATAR___ITEM_ITEMDES_ = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes"];

		/// <summary>
		/// TableCattpTpcatego -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Catar___cattptpcatego(NameValueCollection qs, bool lazyLoad = false)
		{
			bool catar___cattptpcategoDoLoad = true;
			CriteriaSet catar___cattptpcategoConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cattp", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					catar___cattptpcategoConds.Equal(CSGenioAcattp.FldCodtpcat, hValue);
					this.ValCodtpcat = DBConversion.ToString(hValue);
				}
			}

			TableCattpTpcatego = new TableDBEdit<Models.Cattp>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cattp") != null)
				{
					this.ValCodtpcat = Navigation.GetStrValue("RETURN_cattp");
					Navigation.CurrentLevel.SetEntry("RETURN_cattp", null);
				}
				FillDependant_CatarTableCattpTpcatego(lazyLoad);
				return;
			}

			if (catar___cattptpcategoDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCattpTpcatego, "sTableCattpTpcatego", "dTableCattpTpcatego", qs, "cattp");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcattp.FldTpcatego), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCattpTpcatego_tableFilters"]))
					TableCattpTpcatego.TableFilters = bool.Parse(qs["TableCattpTpcatego_tableFilters"]);
				else
					TableCattpTpcatego.TableFilters = false;

				query = qs["qTableCattpTpcatego"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcattp.FldTpcatego, query + "%");
				}
				catar___cattptpcategoConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCattpTpcatego"] != null ? qs["pTableCattpTpcatego"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcattp.FldCodtpcat, CSGenioAcattp.FldTpcatego, CSGenioAcattp.FldZzstate };

// USE /[MANUAL GQT OVERRQ CATAR_CATTPTPCATEGO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cattp", FormMode.New) || Navigation.checkFormMode("cattp", FormMode.Duplicate))
					catar___cattptpcategoConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcattp.FldZzstate, 0)
						.Equal(CSGenioAcattp.FldCodtpcat, Navigation.GetStrValue("cattp")));
				else
					catar___cattptpcategoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cattp", "tpcatego");
				ListingMVC<CSGenioAcattp> listing = Models.ModelBase.Where<CSGenioAcattp>(m_userContext, false, catar___cattptpcategoConds, fields, offset, numberItems, sorts, "LED_CATAR___CATTPTPCATEGO", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCattpTpcatego.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCattpTpcatego.Query = query;
				TableCattpTpcatego.Elements = listing.RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(m_userContext, r, true, _fieldsToSerialize_CATAR___CATTPTPCATEGO));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cattp") != null)
				{
					this.ValCodtpcat = Navigation.GetStrValue("RETURN_cattp");
					Navigation.CurrentLevel.SetEntry("RETURN_cattp", null);
				}

				TableCattpTpcatego.List = new SelectList(TableCattpTpcatego.Elements.ToSelectList(x => x.ValTpcatego, x => x.ValCodtpcat,  x => x.ValCodtpcat == this.ValCodtpcat), "Value", "Text", this.ValCodtpcat);
				FillDependant_CatarTableCattpTpcatego();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCattpTpcatego (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cattp</param>
		public ConcurrentDictionary<string, object> GetDependant_CatarTableCattpTpcatego(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcattp.FldCodtpcat, CSGenioAcattp.FldTpcatego];

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

			CSGenioAcattp tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcattp.FldCodtpcat, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCattpTpcatego (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_CatarTableCattpTpcatego(bool lazyLoad = false)
		{
			var row = GetDependant_CatarTableCattpTpcatego(this.ValCodtpcat);
			try
			{

				// Fill List fields
				this.ValCodtpcat = ViewModelConversion.ToString(row["cattp.codtpcat"]);
				TableCattpTpcatego.Value = (string)row["cattp.tpcatego"];
				if (GlobalFunctions.emptyG(this.ValCodtpcat) == 1)
				{
					this.ValCodtpcat = "";
					TableCattpTpcatego.Value = "";
					Navigation.ClearValue("cattp");
				}
				else if (lazyLoad)
				{
					TableCattpTpcatego.SetPagination(1, 0, false, false, 1);
					TableCattpTpcatego.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpcat),
							Text = Convert.ToString(TableCattpTpcatego.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpcat);
				}

				TableCattpTpcatego.Selected = this.ValCodtpcat;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCattpTpcatego): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CATAR___CATTPTPCATEGO = ["Cattp", "Cattp.ValCodtpcat", "Cattp.ValZzstate", "Cattp.ValTpcatego"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"itemc.codtpcat" => ViewModelConversion.ToString(modelValue),
				"itemc.coditem" => ViewModelConversion.ToString(modelValue),
				"itemc.tpcateg" => ViewModelConversion.ToString(modelValue),
				"itemc.codcatar" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"cattp.codtpcat" => ViewModelConversion.ToString(modelValue),
				"cattp.tpcatego" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CATAR]/

		#endregion
	}
}
