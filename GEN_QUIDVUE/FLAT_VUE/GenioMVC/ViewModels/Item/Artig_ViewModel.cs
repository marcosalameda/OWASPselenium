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
	public class Artig_ViewModel : FormViewModel<Models.Item>, IPreparableForSerialization
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
		/// Title: "Designation:" | Type: "CE"
		/// </summary>
		public string ValCodgitem { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "Code" | Type: "C"
		/// </summary>
		public string ValItemcod { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }
		/// <summary>
		/// Title: "Code" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string GitemValItemgcod 
		{
			get
			{
				return funcGitemValItemgcod != null ? funcGitemValItemgcod() : _auxGitemValItemgcod;
			}
			set { funcGitemValItemgcod = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcGitemValItemgcod { get; set; }

		private string _auxGitemValItemgcod { get; set; }
		/// <summary>
		/// Title: "Designation:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Gitem> TableGitemItemdes { get; set; }
		/// <summary>
		/// Title: "Item" | Type: "C"
		/// </summary>
		public string ValItemdes { get; set; }
		/// <summary>
		/// Title: "In use" | Type: "L"
		/// </summary>
		public bool ValValid { get; set; }
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
		/// Title: "Entries:" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValEntries { get; set; }
		/// <summary>
		/// Title: "Output:" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValExits { get; set; }
		/// <summary>
		/// Title: "Image" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValImage { get; set; }
		/// <summary>
		/// Title: "Categorization" | Type: "PSEUD"
		/// </summary>
		[ValidateSetAccess]
		public List<GenioMVC.Models.Cattp> List_Categori { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public List<GenioMVC.Models.Cattp> List_CategoriSelected { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string[] List_Categori_SelectedIds { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string List_Categori_Area { get; set; }
		/// <summary>
		/// Title: "Filtered Checklist" | Type: "PSEUD"
		/// </summary>
		[ValidateSetAccess]
		public List<GenioMVC.Models.Cattp> List_Categor { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public List<GenioMVC.Models.Cattp> List_CategorSelected { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string[] List_Categor_SelectedIds { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string List_Categor_Area { get; set; }
		/// <summary>
		/// Title: "Categorization" | Type: "MO"
		/// </summary>
		[ValidateSetAccess]
		public string ValCategory { get; set; }
		/// <summary>
		/// Title: "Existence" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValExistenc { get; set; }
		/// <summary>
		/// Title: "Availability" | Type: "AC"
		/// </summary>
		[ValidateSetAccess]
		public string ValDisponib { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValDisponib { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoditem { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Artig_ViewModel() : base(null!) { }

		public Artig_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FARTIG", nestedForm) { }

		public Artig_ViewModel(UserContext userContext, Models.Item row, bool nestedForm = false) : base(userContext, "FARTIG", row, nestedForm) { }

		public Artig_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("item", id);
			Model = Models.Item.Find(id, userContext, "FARTIG", fieldsToQuery: fieldsToLoad);
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
			Models.Item model = new Models.Item(userContext) { Identifier = "FARTIG" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FARTIG");
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

		/// <inheritdoc />
		public override void MapFromModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artig) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodgitem = ViewModelConversion.ToString(m.ValCodgitem);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValItemcod = ViewModelConversion.ToString(m.ValItemcod);
				funcGitemValItemgcod = () => ViewModelConversion.ToString(m.Gitem.ValItemgcod);
				ValItemdes = ViewModelConversion.ToString(m.ValItemdes);
				ValValid = ViewModelConversion.ToLogic(m.ValValid);
				ValItemtype = ViewModelConversion.ToString(m.ValItemtype);
				ValEntries = ViewModelConversion.ToNumeric(m.ValEntries);
				ValExits = ViewModelConversion.ToNumeric(m.ValExits);
				ValImage = ViewModelConversion.ToImage(m.ValImage);
				ValCategory = ViewModelConversion.ToString(m.ValCategory);
				ValExistenc = ViewModelConversion.ToNumeric(m.ValExistenc);
				ValDisponib = ViewModelConversion.ToString(m.ValDisponib);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artig) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artig) to Model (Item) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodgitem = ViewModelConversion.ToString(ValCodgitem);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValItemcod = ViewModelConversion.ToString(ValItemcod);
				m.ValItemdes = ViewModelConversion.ToString(ValItemdes);
				m.ValValid = ViewModelConversion.ToLogic(ValValid);
				m.ValItemtype = ViewModelConversion.ToString(ValItemtype);
				if (ValImage == null || !ValImage.IsThumbnail)
					m.ValImage = ViewModelConversion.ToImage(ValImage);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValEntries = ViewModelConversion.ToNumeric(ValEntries);
				m.ValExits = ViewModelConversion.ToNumeric(ValExits);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValExistenc = ViewModelConversion.ToNumeric(ValExistenc);
				m.ValDisponib = ViewModelConversion.ToString(ValDisponib);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Artig) to Model (Item) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "item.codgitem":
						this.ValCodgitem = ViewModelConversion.ToString(_value);
						break;
					case "item.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "item.itemcod":
						this.ValItemcod = ViewModelConversion.ToString(_value);
						break;
					case "item.itemdes":
						this.ValItemdes = ViewModelConversion.ToString(_value);
						break;
					case "item.valid":
						this.ValValid = ViewModelConversion.ToLogic(_value);
						break;
					case "item.itemtype":
						this.ValItemtype = ViewModelConversion.ToString(_value);
						break;
					case "item.image":
						this.ValImage = ViewModelConversion.ToImage(_value);
						break;
					case "item.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "item.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Artig) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Artig)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Item.Find(id ?? Navigation.GetStrValue("item"), m_userContext, "FARTIG"); }
			finally { Model ??= new Models.Item(m_userContext) { Identifier = "FARTIG" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIG");
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

			Model.Identifier = "FARTIG";
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
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FARTIG");
				if (Model == null)
				{
					Model = new Models.Item(m_userContext) { Identifier = "FARTIG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("item");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Artig___warehwarehdes(qs, lazyLoad);
			Load_Artig___gitemitemdes_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARTIG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARTIG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodwareh", Resources.Resources.WAREHOUSE51864, ViewModelConversion.ToString(ValCodwareh), FieldType.KEY_GUID.GetFormatting());
			validator.StringLength("ValItemcod", Resources.Resources.CODE49225, ValItemcod, 15);
			validator.StringLength("GitemValItemgcod", Resources.Resources.CODE49225, GitemValItemgcod, 15);
			validator.StringLength("ValItemdes", Resources.Resources.ITEM40802, ValItemdes, 85);

			validator.Required("ValItemdes", Resources.Resources.ITEM40802, ViewModelConversion.ToString(ValItemdes), FieldType.TEXT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ARTIG]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARTIG]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARTIG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARTIG]/
		public override void Destroy(string id)
		{
			Model = Models.Item.Find(id, m_userContext, "FARTIG");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
			Load_Artig___pseudcategori_selected_ids();
			Load_Artig___pseudcategor__selected_ids();
		}

		/// <summary>
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Artig___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool artig___warehwarehdesDoLoad = true;
			CriteriaSet artig___warehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					artig___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
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
				FillDependant_ArtigTableWarehWarehdes(lazyLoad);
				return;
			}

			if (artig___warehwarehdesDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
				if (requestedSort != null)
					sorts.Add(requestedSort);

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
				artig___warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIG_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					artig___warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					artig___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, artig___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_ARTIG___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_ARTIG___WAREHWAREHDES));

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
				FillDependant_ArtigTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_ArtigTableWarehWarehdes(string PKey)
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
		public void FillDependant_ArtigTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_ArtigTableWarehWarehdes(this.ValCodwareh);
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

		private readonly string[] _fieldsToSerialize_ARTIG___WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes"];

		/// <summary>
		/// TableGitemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Artig___gitemitemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool artig___gitemitemdes_DoLoad = true;
			CriteriaSet artig___gitemitemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("gitem", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					artig___gitemitemdes_Conds.Equal(CSGenioAgitem.FldCodgitem, hValue);
					this.ValCodgitem = DBConversion.ToString(hValue);
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
				FillDependant_ArtigTableGitemItemdes(lazyLoad);
				return;
			}

			if (artig___gitemitemdes_DoLoad)
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
				artig___gitemitemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGitemItemdes"] != null ? qs["pTableGitemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIG_GITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("gitem", FormMode.New) || Navigation.checkFormMode("gitem", FormMode.Duplicate))
					artig___gitemitemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgitem.FldZzstate, 0)
						.Equal(CSGenioAgitem.FldCodgitem, Navigation.GetStrValue("gitem")));
				else
					artig___gitemitemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("gitem", "itemdes");
				ListingMVC<CSGenioAgitem> listing = Models.ModelBase.Where<CSGenioAgitem>(m_userContext, false, artig___gitemitemdes_Conds, fields, offset, numberItems, sorts, "LED_ARTIG___GITEMITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGitemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGitemItemdes.Query = query;
				TableGitemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Gitem>((r) => new GenioMVC.Models.Gitem(m_userContext, r, true, _fieldsToSerialize_ARTIG___GITEMITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_gitem") != null)
				{
					this.ValCodgitem = Navigation.GetStrValue("RETURN_gitem");
					Navigation.CurrentLevel.SetEntry("RETURN_gitem", null);
				}

				TableGitemItemdes.List = new SelectList(TableGitemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCodgitem,  x => x.ValCodgitem == this.ValCodgitem), "Value", "Text", this.ValCodgitem);
				FillDependant_ArtigTableGitemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGitemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Gitem</param>
		public ConcurrentDictionary<string, object> GetDependant_ArtigTableGitemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldItemgcod];

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
		public void FillDependant_ArtigTableGitemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_ArtigTableGitemItemdes(this.ValCodgitem);
			try
			{
				this.funcGitemValItemgcod = () => (string)row["gitem.itemgcod"];

				// Fill List fields
				this.ValCodgitem = ViewModelConversion.ToString(row["gitem.codgitem"]);
				TableGitemItemdes.Value = (string)row["gitem.itemdes"];
				if (GenFunctions.emptyG(this.ValCodgitem) == 1)
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

		private readonly string[] _fieldsToSerialize_ARTIG___GITEMITEMDES_ = ["Gitem", "Gitem.ValCodgitem", "Gitem.ValZzstate", "Gitem.ValItemdes"];
		/// <summary>
		/// List_Categori -> (DV)
		/// </summary>
		/// <param name="qs"></param>
		public void Load_Artig___pseudcategori(NameValueCollection qs)
		{
			bool artig___pseudcategoriDoLoad = true;
			CriteriaSet artig___pseudcategoriConds = CriteriaSet.And();


			this.List_Categori_Area = "Cattp";
			this.List_Categori = new List<GenioMVC.Models.Cattp>();
			this.List_CategoriSelected = new List<GenioMVC.Models.Cattp>();
			
			if (artig___pseudcategoriDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcattp.FldTpcatego), SortOrder.Ascending));



// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDCATEGORI]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Cattp", FormMode.New)) // TODO: Check in Duplicate mode
					artig___pseudcategoriConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Categori = Models.ModelBase.Where<CSGenioAcattp>(m_userContext, false, args: artig___pseudcategoriConds, numRegs: -1, sorts: sorts).RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(m_userContext, r));
				
				// Get primary keys of selected rows
				Load_Artig___pseudcategori_selected_ids();
				
				List_CategoriSelected = List_Categori.Where(x => List_Categori_SelectedIds.Contains(x.ValCodtpcat)).ToList();
			}
		}
		
		/// <summary>
		/// List_Categori_SelectedIds
		/// </summary>
		public void Load_Artig___pseudcategori_selected_ids()
		{
			if (List_Categori_SelectedIds == null)
				List_Categori_SelectedIds = [];
			
			// Create criteria set
			CriteriaSet artig___pseudcategori_tpcatego_Conds = CriteriaSet.And();
			artig___pseudcategori_tpcatego_Conds.Equal(CSGenioAitemc.FldCoditem, ValCoditem);

			// Get primary keys of selected rows
			if (List_Categori_SelectedIds.Length == 0)
				List_Categori_SelectedIds = Models.ModelBase.All<CSGenioAitemc>(m_userContext, artig___pseudcategori_tpcatego_Conds).Rows.Select(x => x.ValCodtpcat).ToArray();
		}
		/// <summary>
		/// List_Categor -> (DW)
		/// </summary>
		/// <param name="qs"></param>
		public void Load_Artig___pseudcategor_(NameValueCollection qs)
		{
			bool artig___pseudcategor_DoLoad = true;
			CriteriaSet artig___pseudcategor_Conds = CriteriaSet.And();

			// Limits Generation

			object artig___pseudcategor__flimitcattp_tpcatego = "Papel";
			artig___pseudcategor_Conds.Equal(
				CSGenio.business.CSGenioAcattp.FldTpcatego,
				artig___pseudcategor__flimitcattp_tpcatego);

			this.List_Categor_Area = "Cattp";
			this.List_Categor = new List<GenioMVC.Models.Cattp>();
			this.List_CategorSelected = new List<GenioMVC.Models.Cattp>();
			
			if (artig___pseudcategor_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcattp.FldTpcatego), SortOrder.Ascending));



// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDCATEGOR]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Cattp", FormMode.New)) // TODO: Check in Duplicate mode
					artig___pseudcategor_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Categor = Models.ModelBase.Where<CSGenioAcattp>(m_userContext, false, args: artig___pseudcategor_Conds, numRegs: -1, sorts: sorts).RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(m_userContext, r));
				
				// Get primary keys of selected rows
				Load_Artig___pseudcategor__selected_ids();
				
				List_CategorSelected = List_Categor.Where(x => List_Categor_SelectedIds.Contains(x.ValCodtpcat)).ToList();
			}
		}
		
		/// <summary>
		/// List_Categor_SelectedIds
		/// </summary>
		public void Load_Artig___pseudcategor__selected_ids()
		{
			if (List_Categor_SelectedIds == null)
				List_Categor_SelectedIds = [];
			
			// Create criteria set
			CriteriaSet artig___pseudcategor__tpcatego_Conds = CriteriaSet.And();
			artig___pseudcategor__tpcatego_Conds.Equal(CSGenioAitemc.FldCoditem, ValCoditem);

			// Get primary keys of selected rows
			if (List_Categor_SelectedIds.Length == 0)
				List_Categor_SelectedIds = Models.ModelBase.All<CSGenioAitemc>(m_userContext, artig___pseudcategor__tpcatego_Conds).Rows.Select(x => x.ValCodtpcat).ToArray();
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"item.codgitem" => ViewModelConversion.ToString(modelValue),
				"item.codwareh" => ViewModelConversion.ToString(modelValue),
				"item.itemcod" => ViewModelConversion.ToString(modelValue),
				"gitem.itemgcod" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"item.valid" => ViewModelConversion.ToLogic(modelValue),
				"item.itemtype" => ViewModelConversion.ToString(modelValue),
				"item.entries" => ViewModelConversion.ToNumeric(modelValue),
				"item.exits" => ViewModelConversion.ToNumeric(modelValue),
				"item.image" => ViewModelConversion.ToImage(modelValue),
				"item.category" => ViewModelConversion.ToString(modelValue),
				"item.existenc" => ViewModelConversion.ToNumeric(modelValue),
				"item.disponib" => ViewModelConversion.ToString(modelValue),
				"item.date" => ViewModelConversion.ToDateTime(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"gitem.codgitem" => ViewModelConversion.ToString(modelValue),
				"gitem.itemdes" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValImage != null)
				ValImage.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaITEM, CSGenioAitem.FldImage.Field, null, ValCoditem);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTIG]/

		#endregion
	}
}
