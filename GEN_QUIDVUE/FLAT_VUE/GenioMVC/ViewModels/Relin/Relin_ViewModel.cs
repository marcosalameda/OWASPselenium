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

namespace GenioMVC.ViewModels.Relin
{
	public class Relin_ViewModel : FormViewModel<Models.Relin>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Receipt number" | Type: "N"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Recei> TableReceiNumber { get; set; }

		/// <summary>
		/// Title: "Legal name" | Type: "C"
		/// </summary>
		public string EntitValName 
		{
			get
			{
				return funcEntitValName != null ? funcEntitValName() : _auxEntitValName;
			}
			set { funcEntitValName = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcEntitValName { get; set; }

		private string _auxEntitValName { get; set; }

		/// <summary>
		/// Title: "Line" | Type: "N"
		/// </summary>
		public decimal? ValLinenumb { get; set; }

		/// <summary>
		/// Title: "Product" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Produ> TableProduProduct { get; set; }

		/// <summary>
		/// Title: "Ordered" | Type: "N"
		/// </summary>
		public decimal? ValOrdered { get; set; }

		/// <summary>
		/// Title: "Received" | Type: "N"
		/// </summary>
		public decimal? ValReceived { get; set; }

		/// <summary>
		/// Title: "Outstanding" | Type: "N"
		/// </summary>
		public decimal? ValOutstand { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodentit { get; set; }

		/// <summary>
		/// Title: "Product" | Type: "CE"
		/// </summary>
		public string ValCodprodu { get; set; }

		/// <summary>
		/// Title: "Receipt number" | Type: "CE"
		/// </summary>
		public string ValCodrecei { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddilin { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Relin_ViewModel() : base(null!) { }

		public Relin_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FRELIN", nestedForm) { }

		public Relin_ViewModel(UserContext userContext, Models.Relin row, bool nestedForm = false) : base(userContext, "FRELIN", row, nestedForm) { }

		public Relin_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("relin", id);
			Model = Models.Relin.Find(id, userContext, "FRELIN", fieldsToQuery: fieldsToLoad);
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
			Models.Relin model = new Models.Relin(userContext) { Identifier = "FRELIN" };
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
			Models.Relin model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Relin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Relin) to ViewModel (Relin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				funcEntitValName = () => ViewModelConversion.ToString(m.Entit.ValName);
				ValLinenumb = ViewModelConversion.ToNumeric(m.ValLinenumb);
				ValOrdered = ViewModelConversion.ToNumeric(m.ValOrdered);
				ValReceived = ViewModelConversion.ToNumeric(m.ValReceived);
				ValOutstand = ViewModelConversion.ToNumeric(m.ValOutstand);
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
				ValCodprodu = ViewModelConversion.ToString(m.ValCodprodu);
				ValCodrecei = ViewModelConversion.ToString(m.ValCodrecei);
				ValCoddilin = ViewModelConversion.ToString(m.ValCoddilin);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Relin) to ViewModel (Relin) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Relin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Relin) to Model (Relin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValLinenumb = ViewModelConversion.ToNumeric(ValLinenumb);
				m.ValOrdered = ViewModelConversion.ToNumeric(ValOrdered);
				m.ValReceived = ViewModelConversion.ToNumeric(ValReceived);
				m.ValOutstand = ViewModelConversion.ToNumeric(ValOutstand);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodprodu = ViewModelConversion.ToString(ValCodprodu);
				m.ValCodrecei = ViewModelConversion.ToString(ValCodrecei);
				m.ValCoddilin = ViewModelConversion.ToString(ValCoddilin);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Relin) to Model (Relin) - Error during mapping");
				throw;
			}
		}

		#endregion


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Relin.Find(Navigation.GetStrValue("relin"), m_userContext, "FRELIN");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FRELIN";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
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

		protected override void LoadDocumentsProperties(Models.Relin row)
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
				Model = Models.Relin.Find(Navigation.GetStrValue("relin"), m_userContext, "FRELIN");
				if (Model == null)
				{
					Model = new Models.Relin(m_userContext) { Identifier = "FRELIN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("relin");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Relin___receinumber__(qs, lazyLoad);
			Load_Relin___produproduct_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL RELIN]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW RELIN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("EntitValName", Resources.Resources.LEGAL_NAME42902, EntitValName, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE RELIN]/
		public override void Save()
		{

			try { Model = Models.Relin.Find(Navigation.GetStrValue("relin"), m_userContext, "FRELIN"); }
			finally { if (Model == null) Model = new Models.Relin(m_userContext) { Identifier = "FRELIN" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY RELIN]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Relin.Find(Navigation.GetStrValue("relin"), m_userContext, "FRELIN"); }
			finally { if (Model == null) Model = new Models.Relin(m_userContext) { Identifier = "FRELIN" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE RELIN]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY RELIN]/
		public override void Destroy(string id)
		{
			Model = Models.Relin.Find(id, m_userContext, "FRELIN");
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
		/// TableReceiNumber -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Relin___receinumber__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool relin___receinumber__DoLoad = true;
			CriteriaSet relin___receinumber__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("recei", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					relin___receinumber__Conds.Equal(CSGenioArecei.FldCodrecei, Navigation.GetValue("recei"));
					this.ValCodrecei = Navigation.GetStrValue("recei");
				}
			}

			TableReceiNumber = new TableDBEdit<Models.Recei>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_recei") != null)
				{
					this.ValCodrecei = Navigation.GetStrValue("RETURN_recei");
					Navigation.CurrentLevel.SetEntry("RETURN_recei", null);
				}
				FillDependant_RelinTableReceiNumber(lazyLoad);
				//Check if foreignkey comes from history
				TableReceiNumber.FilledByHistory = Navigation.CheckFilledByHistory("recei");
				return;
			}

			if (relin___receinumber__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableReceiNumber, "sTableReceiNumber", "dTableReceiNumber", qs, "recei");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableReceiNumber_tableFilters"]))
					TableReceiNumber.TableFilters = bool.Parse(qs["TableReceiNumber_tableFilters"]);
				else
					TableReceiNumber.TableFilters = false;

				query = qs["qTableReceiNumber"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioArecei.FldNumber, query + "%");
				}
				relin___receinumber__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableReceiNumber"] != null ? qs["pTableReceiNumber"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioArecei.FldCodrecei, CSGenioArecei.FldNumber, CSGenioArecei.FldZzstate };

// USE /[MANUAL GQT OVERRQ RELIN_RECEINUMBER]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("recei", FormMode.New) || Navigation.checkFormMode("recei", FormMode.Duplicate))
					relin___receinumber__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioArecei.FldZzstate, 0)
						.Equal(CSGenioArecei.FldCodrecei, Navigation.GetStrValue("recei")));
				else
					relin___receinumber__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArecei.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("recei", "number");
				ListingMVC<CSGenioArecei> listing = Models.ModelBase.Where<CSGenioArecei>(m_userContext, false, relin___receinumber__Conds, fields, offset, numberItems, sorts, "LED_RELIN___RECEINUMBER__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableReceiNumber.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableReceiNumber.Query = query;
				TableReceiNumber.Elements = listing.RowsForViewModel<GenioMVC.Models.Recei>((r) => new GenioMVC.Models.Recei(m_userContext, r, true, _fieldsToSerialize_RELIN___RECEINUMBER__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_recei") != null)
				{
					this.ValCodrecei = Navigation.GetStrValue("RETURN_recei");
					Navigation.CurrentLevel.SetEntry("RETURN_recei", null);
				}

				TableReceiNumber.List = new SelectList(TableReceiNumber.Elements.ToSelectList(x => x.ValNumber, x => x.ValCodrecei,  x => x.ValCodrecei == this.ValCodrecei), "Value", "Text", this.ValCodrecei);
				FillDependant_RelinTableReceiNumber();

				//Check if foreignkey comes from history
				TableReceiNumber.FilledByHistory = Navigation.CheckFilledByHistory("recei");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableReceiNumber (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Recei</param>
		public ConcurrentDictionary<string, object> GetDependant_RelinTableReceiNumber(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioArecei.FldCodrecei, CSGenioArecei.FldNumber, CSGenioAentit.FldCodentit, CSGenioAentit.FldName];

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

			CSGenioArecei tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioArecei.FldCodrecei, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableReceiNumber (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_RelinTableReceiNumber(bool lazyLoad = false)
		{
			var row = GetDependant_RelinTableReceiNumber(this.ValCodrecei);
			try
			{
				this.ValCodentit = (string)row["entit.codentit"];
				this.funcEntitValName = () => (string)row["entit.name"];

				// Fill List fields
				this.ValCodrecei = ViewModelConversion.ToString(row["recei.codrecei"]);
				TableReceiNumber.Value = (decimal?)row["recei.number"];
				if (GlobalFunctions.emptyG(this.ValCodrecei) == 1)
				{
					this.ValCodrecei = "";
					TableReceiNumber.Value = 0;
					Navigation.ClearValue("recei");
				}
				else if (lazyLoad)
				{
					TableReceiNumber.SetPagination(1, 0, false, false, 1);
					TableReceiNumber.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodrecei),
							Text = Convert.ToString(TableReceiNumber.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodrecei);
				}

				TableReceiNumber.Selected = this.ValCodrecei;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableReceiNumber): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_RELIN___RECEINUMBER__ = ["Recei", "Recei.ValCodrecei", "Recei.ValZzstate", "Recei.ValNumber"];

		/// <summary>
		/// TableProduProduct -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Relin___produproduct_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool relin___produproduct_DoLoad = true;
			CriteriaSet relin___produproduct_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("produ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					relin___produproduct_Conds.Equal(CSGenioAprodu.FldCodprodu, Navigation.GetValue("produ"));
					this.ValCodprodu = Navigation.GetStrValue("produ");
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
				FillDependant_RelinTableProduProduct(lazyLoad);
				//Check if foreignkey comes from history
				TableProduProduct.FilledByHistory = Navigation.CheckFilledByHistory("produ");
				return;
			}

			if (relin___produproduct_DoLoad)
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
				relin___produproduct_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableProduProduct"] != null ? qs["pTableProduProduct"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct, CSGenioAprodu.FldZzstate };

// USE /[MANUAL GQT OVERRQ RELIN_PRODUPRODUCT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("produ", FormMode.New) || Navigation.checkFormMode("produ", FormMode.Duplicate))
					relin___produproduct_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAprodu.FldZzstate, 0)
						.Equal(CSGenioAprodu.FldCodprodu, Navigation.GetStrValue("produ")));
				else
					relin___produproduct_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAprodu.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("produ", "product");
				ListingMVC<CSGenioAprodu> listing = Models.ModelBase.Where<CSGenioAprodu>(m_userContext, false, relin___produproduct_Conds, fields, offset, numberItems, sorts, "LED_RELIN___PRODUPRODUCT_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableProduProduct.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableProduProduct.Query = query;
				TableProduProduct.Elements = listing.RowsForViewModel<GenioMVC.Models.Produ>((r) => new GenioMVC.Models.Produ(m_userContext, r, true, _fieldsToSerialize_RELIN___PRODUPRODUCT_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_produ") != null)
				{
					this.ValCodprodu = Navigation.GetStrValue("RETURN_produ");
					Navigation.CurrentLevel.SetEntry("RETURN_produ", null);
				}

				TableProduProduct.List = new SelectList(TableProduProduct.Elements.ToSelectList(x => x.ValProduct, x => x.ValCodprodu,  x => x.ValCodprodu == this.ValCodprodu), "Value", "Text", this.ValCodprodu);
				FillDependant_RelinTableProduProduct();

				//Check if foreignkey comes from history
				TableProduProduct.FilledByHistory = Navigation.CheckFilledByHistory("produ");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableProduProduct (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Produ</param>
		public ConcurrentDictionary<string, object> GetDependant_RelinTableProduProduct(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct];

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
		public void FillDependant_RelinTableProduProduct(bool lazyLoad = false)
		{
			var row = GetDependant_RelinTableProduProduct(this.ValCodprodu);
			try
			{

				// Fill List fields
				this.ValCodprodu = ViewModelConversion.ToString(row["produ.codprodu"]);
				TableProduProduct.Value = (string)row["produ.product"];
				if (GlobalFunctions.emptyG(this.ValCodprodu) == 1)
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

		private readonly string[] _fieldsToSerialize_RELIN___PRODUPRODUCT_ = ["Produ", "Produ.ValCodprodu", "Produ.ValZzstate", "Produ.ValProduct"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"entit.name" => ViewModelConversion.ToString(modelValue),
				"relin.linenumb" => ViewModelConversion.ToNumeric(modelValue),
				"relin.ordered" => ViewModelConversion.ToNumeric(modelValue),
				"relin.received" => ViewModelConversion.ToNumeric(modelValue),
				"relin.outstand" => ViewModelConversion.ToNumeric(modelValue),
				"relin.codentit" => ViewModelConversion.ToString(modelValue),
				"relin.codprodu" => ViewModelConversion.ToString(modelValue),
				"relin.codrecei" => ViewModelConversion.ToString(modelValue),
				"relin.coddilin" => ViewModelConversion.ToString(modelValue),
				"recei.codrecei" => ViewModelConversion.ToString(modelValue),
				"recei.number" => ViewModelConversion.ToNumeric(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"produ.codprodu" => ViewModelConversion.ToString(modelValue),
				"produ.product" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM RELIN]/

		#endregion
	}
}
