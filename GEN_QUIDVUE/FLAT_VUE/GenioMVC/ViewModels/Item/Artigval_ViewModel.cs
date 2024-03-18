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

namespace GenioMVC.ViewModels.Item
{
	public class Artigval_ViewModel : FormViewModel<Models.Item>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Image" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValImage { get; set; }

		/// <summary>
		/// Title: "Global Item" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Gitem> TableGitemItemdes { get; set; }

		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }

		/// <summary>
		/// Title: "Tipo" | Type: "AC"
		/// </summary>
		public string ValItemtype { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValItemtype { get; set; }

		/// <summary>
		/// Title: "Code" | Type: "C"
		/// </summary>
		public string ValItemcod { get; set; }

		/// <summary>
		/// Title: "Item" | Type: "C"
		/// </summary>
		public string ValItemdes { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }

		/// <summary>
		/// Title: "Entries" | Type: "N"
		/// </summary>
		public decimal? ValEntries { get; set; }

		/// <summary>
		/// Title: "Output:" | Type: "N"
		/// </summary>
		public decimal? ValExits { get; set; }

		/// <summary>
		/// Title: "Existence" | Type: "N"
		/// </summary>
		public decimal? ValExistenc { get; set; }

		/// <summary>
		/// Title: "Categorization" | Type: "MO"
		/// </summary>
		public string ValCategory { get; set; }

		/// <summary>
		/// Title: "Availability" | Type: "AC"
		/// </summary>
		public string ValDisponib { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValDisponib { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Global Item" | Type: "CE"
		/// </summary>
		public string ValCodgitem { get; set; }

		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the GitemValItemgcod field</summary>
		[JsonIgnore]
		public Func<string> funcGitemValItemgcod { get; set; }
		private string _auxGitemValItemgcod { get; set; }
		/// <summary>Field: "Code" Tipo: "C"</summary>
		public string GitemValItemgcod { get { return funcGitemValItemgcod != null ? funcGitemValItemgcod() : _auxGitemValItemgcod; } set { funcGitemValItemgcod = () => value; } }

		#endregion

		public string ValCoditem { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Artigval_ViewModel() : base(null!) { }

		public Artigval_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FARTIGVAL", nestedForm) { }

		public Artigval_ViewModel(UserContext userContext, Models.Item row, bool nestedForm = false) : base(userContext, "FARTIGVAL", row, nestedForm) { }

		public Artigval_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("item", id);
			Model = Models.Item.Find(id, userContext, "FARTIGVAL", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Item model = new Models.Item(userContext) { Identifier = "FARTIGVAL" };
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
			Models.Item model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artigval) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValImage = ViewModelConversion.ToImage(m.ValImage);
				ValItemtype = ViewModelConversion.ToString(m.ValItemtype);
				ValItemcod = ViewModelConversion.ToString(m.ValItemcod);
				ValItemdes = ViewModelConversion.ToString(m.ValItemdes);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValEntries = ViewModelConversion.ToNumeric(m.ValEntries);
				ValExits = ViewModelConversion.ToNumeric(m.ValExits);
				ValExistenc = ViewModelConversion.ToNumeric(m.ValExistenc);
				ValCategory = ViewModelConversion.ToString(m.ValCategory);
				ValDisponib = ViewModelConversion.ToString(m.ValDisponib);
				ValCodgitem = ViewModelConversion.ToString(m.ValCodgitem);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				funcGitemValItemgcod = () => ViewModelConversion.ToString(m.Gitem.ValItemgcod);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artigval) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artigval) to Model (Item) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValImage = ViewModelConversion.ToImage(ValImage);
				m.ValItemtype = ViewModelConversion.ToString(ValItemtype);
				m.ValItemcod = ViewModelConversion.ToString(ValItemcod);
				m.ValItemdes = ViewModelConversion.ToString(ValItemdes);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValEntries = ViewModelConversion.ToNumeric(ValEntries);
				m.ValExits = ViewModelConversion.ToNumeric(ValExits);
				m.ValExistenc = ViewModelConversion.ToNumeric(ValExistenc);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValDisponib = ViewModelConversion.ToString(ValDisponib);
				m.ValCodgitem = ViewModelConversion.ToString(ValCodgitem);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artigval) to Model (Item) - Error during mapping");
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
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIGVAL");
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

			Model.Identifier = "FARTIGVAL";
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

		protected override void LoadDocumentsProperties(Models.Item row)
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
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIGVAL");
				if (Model == null)
				{
					Model = new Models.Item(m_userContext) { Identifier = "FARTIGVAL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("item");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Artigvalgitemitemdes_(qs, lazyLoad);
			Load_Artigvalwarehwarehdes(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARTIGVAL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARTIGVAL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValItemcod", Resources.Resources.CODE49225, ValItemcod, 15);
			validator.StringLength("ValItemdes", Resources.Resources.ITEM40802, ValItemdes, 85);
			validator.Required("ValItemdes", Resources.Resources.ITEM40802, ValItemdes);
			validator.Required("ValCodwareh", Resources.Resources.WAREHOUSE51864, ValCodwareh);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ARTIGVAL]/
		public override void Save()
		{

			try { Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIGVAL"); }
			finally { if (Model == null) Model = new Models.Item(m_userContext) { Identifier = "FARTIGVAL" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARTIGVAL]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIGVAL"); }
			finally { if (Model == null) Model = new Models.Item(m_userContext) { Identifier = "FARTIGVAL" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARTIGVAL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARTIGVAL]/
		public override void Destroy(string id)
		{
			Model = Models.Item.Find(id, m_userContext, "FARTIGVAL");
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
		/// TableGitemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Artigvalgitemitemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool artigvalgitemitemdes_DoLoad = true;
			CriteriaSet artigvalgitemitemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("gitem", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					artigvalgitemitemdes_Conds.Equal(CSGenioAgitem.FldCodgitem, Navigation.GetValue("gitem"));
					this.ValCodgitem = Navigation.GetStrValue("gitem");
				}
			}

			TableGitemItemdes = new TableDBEdit<Models.Gitem>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_gitem") != null)
				{
					this.ValCodgitem = Navigation.GetStrValue("RETURN_gitem");
					Navigation.CurrentLevel.SetEntry("RETURN_gitem", null);
				}
				FillDependant_ArtigvalTableGitemItemdes(lazyLoad);
				//Check if foreignkey comes from history
				TableGitemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("gitem");
				return;
			}

			if (artigvalgitemitemdes_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableGitemItemdes, "sTableGitemItemdes", "dTableGitemItemdes", qs, "gitem");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgitem.FldItemdes), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGitemItemdes_tableFilters"]))
					TableGitemItemdes.TableFilters = bool.Parse(qs["TableGitemItemdes_tableFilters"]);
				else
					TableGitemItemdes.TableFilters = false;

				query = qs["qTableGitemItemdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgitem.FldItemdes, query + "%");
				}
				artigvalgitemitemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGitemItemdes"] != null ? qs["pTableGitemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIGVAL_GITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("gitem", FormMode.New) || Navigation.checkFormMode("gitem", FormMode.Duplicate))
					artigvalgitemitemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgitem.FldZzstate, 0)
						.Equal(CSGenioAgitem.FldCodgitem, Navigation.GetStrValue("gitem")));
				else
					artigvalgitemitemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("gitem", "itemdes");
				ListingMVC<CSGenioAgitem> listing = Models.ModelBase.Where<CSGenioAgitem>(m_userContext, false, artigvalgitemitemdes_Conds, fields, offset, numberItems, sorts, "LED_ARTIGVALGITEMITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGitemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGitemItemdes.Query = query;
				TableGitemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Gitem>((r) => new GenioMVC.Models.Gitem(m_userContext, r, true, _fieldsToSerialize_ARTIGVALGITEMITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_gitem") != null)
				{
					this.ValCodgitem = Navigation.GetStrValue("RETURN_gitem");
					Navigation.CurrentLevel.SetEntry("RETURN_gitem", null);
				}

				TableGitemItemdes.List = new SelectList(TableGitemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCodgitem,  x => x.ValCodgitem == this.ValCodgitem), "Value", "Text", this.ValCodgitem);
				FillDependant_ArtigvalTableGitemItemdes();

				//Check if foreignkey comes from history
				TableGitemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("gitem");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGitemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Gitem</param>
		public ConcurrentDictionary<string, object> GetDependant_ArtigvalTableGitemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldItemgcod];

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

			CSGenioAgitem tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgitem.FldCodgitem, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGitemItemdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ArtigvalTableGitemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_ArtigvalTableGitemItemdes(this.ValCodgitem);
			try
			{
				this.funcGitemValItemgcod = () => (string)row["gitem.itemgcod"];

				// Fill List fields
				this.ValCodgitem = ViewModelConversion.ToString(row["gitem.codgitem"]);
				TableGitemItemdes.Value = (string)row["gitem.itemdes"];
				if (GlobalFunctions.emptyG(this.ValCodgitem) == 1)
				{
					this.ValCodgitem = "";
					TableGitemItemdes.Value = "";
					Navigation.ClearValue("gitem");
				}
				else if (lazyLoad)
				{
					TableGitemItemdes.SetPagination(1, 0, false, false, 1);
					TableGitemItemdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodgitem),
							Text = Convert.ToString(TableGitemItemdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodgitem);
				}

				TableGitemItemdes.Selected = this.ValCodgitem;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGitemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ARTIGVALGITEMITEMDES_ = ["Gitem", "Gitem.ValCodgitem", "Gitem.ValZzstate", "Gitem.ValItemdes"];

		/// <summary>
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Artigvalwarehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool artigvalwarehwarehdesDoLoad = true;
			CriteriaSet artigvalwarehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					artigvalwarehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
					this.ValCodwareh = Navigation.GetStrValue("wareh");
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
				FillDependant_ArtigvalTableWarehWarehdes(lazyLoad);
				//Check if foreignkey comes from history
				TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
				return;
			}

			if (artigvalwarehwarehdesDoLoad)
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
				artigvalwarehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIGVAL_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					artigvalwarehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					artigvalwarehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, artigvalwarehwarehdesConds, fields, offset, numberItems, sorts, "LED_ARTIGVALWAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_ARTIGVALWAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				//Seleciona se só um
				if (TableWarehWarehdes.List != null && TableWarehWarehdes.List.Count() == 1)
				{
					this.ValCodwareh = TableWarehWarehdes.List.First().Value;
					Navigation.SetValue("wareh", this.ValCodwareh);
				}
				FillDependant_ArtigvalTableWarehWarehdes();

				//Check if foreignkey comes from history
				TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_ArtigvalTableWarehWarehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes];

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
		public void FillDependant_ArtigvalTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_ArtigvalTableWarehWarehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
				TableWarehWarehdes.Value = (string)row["wareh.warehdes"];
				if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
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

		private readonly string[] _fieldsToSerialize_ARTIGVALWAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"item.image" => ViewModelConversion.ToImage(modelValue),
				"item.itemtype" => ViewModelConversion.ToString(modelValue),
				"item.itemcod" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"item.date" => ViewModelConversion.ToDateTime(modelValue),
				"item.entries" => ViewModelConversion.ToNumeric(modelValue),
				"item.exits" => ViewModelConversion.ToNumeric(modelValue),
				"item.existenc" => ViewModelConversion.ToNumeric(modelValue),
				"item.category" => ViewModelConversion.ToString(modelValue),
				"item.disponib" => ViewModelConversion.ToString(modelValue),
				"item.codgitem" => ViewModelConversion.ToString(modelValue),
				"item.codwareh" => ViewModelConversion.ToString(modelValue),
				"gitem.itemgcod" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"gitem.codgitem" => ViewModelConversion.ToString(modelValue),
				"gitem.itemdes" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTIGVAL]/

		#endregion
	}
}
