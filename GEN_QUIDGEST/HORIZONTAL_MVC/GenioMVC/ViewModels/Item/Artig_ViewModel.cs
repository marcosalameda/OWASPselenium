using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Item
{
	public class Artig_ViewModel : FormViewModel<Models.Item>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Code" Tipo:"C"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValItemcod { get; set; }

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Wareh>  TableWarehWarehdes { get; set; }

		/// <summary>Campo : "Code" Tipo:"C"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string GitemValItemgcod { get { return funcGitemValItemgcod != null ? funcGitemValItemgcod() : _auxGitemValItemgcod; } set { funcGitemValItemgcod = () => value; } }
		[JsonIgnore]
		public Func<string> funcGitemValItemgcod { get; set; }
		private string _auxGitemValItemgcod { get; set; }

		/// <summary>Campo : "Designation:" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION_35800", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Gitem>  TableGitemItemdes { get; set; }

		/// <summary>Campo : "Item" Tipo:"C"</summary>
		[Display(Name = "ITEM40802", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValItemdes { get; set; }

		/// <summary>Campo : "In use" Tipo:"L"</summary>
		[Display(Name = "IN_USE42606", ResourceType = typeof(Resources.Resources))]
		public bool ValValid { get; set; }

		/// <summary>Campo : "Tipo" Tipo:"AC"</summary>
		[Display(Name = "TIPO55111", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Tipoarti", GenioMVC.Helpers.ArrayType.Character)]
		public string ValItemtype { get; set; }
		[JsonIgnore]
		public SelectList List_ValItemtype { get; set; }

		/// <summary>Campo : "Entries:" Tipo:"N"</summary>
		[Display(Name = "ENTRIES_07375", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValEntries { get; set; }

		/// <summary>Campo : "Output:" Tipo:"N"</summary>
		[Display(Name = "OUTPUT_10769", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValExits { get; set; }

		/// <summary>Campo : "Image" Tipo:"IJ"</summary>
		[Display(Name = "IMAGE65174", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValImage { get; set; }

		/// <summary>Campo : "Movements" Tipo:"DP"</summary>
		[Display(Name = "MOVEMENTS47007", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Ccorr> ValContacor { get; set; }

		/// <summary>Campo : "Entries" Tipo:"DP"</summary>
		[Display(Name = "ENTRIES32319", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Ldent> ValLentrada { get; set; }

		/// <summary>Campo : "Output:" Tipo:"DP"</summary>
		[Display(Name = "OUTPUT_10769", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Outpu> ValLsaidas { get; set; }

		/// <summary>Campo : "Categorization" Tipo:"DV"</summary>
		[Display(Name = "CATEGORIZATION17554", ResourceType = typeof(Resources.Resources))]
		public List<GenioMVC.Models.Cattp> List_Categori { get; set; }
		public List<GenioMVC.Models.Cattp> List_CategoriSelected { get; set; }
		public string[] List_Categori_SelectedIds { get; set; }
		public string List_Categori_Area { get; set; }

		/// <summary>Campo : "Chosen Categories" Tipo:"EV"</summary>
		[Display(Name = "CHOSEN_CATEGORIES47546", ResourceType = typeof(Resources.Resources))]
		public string List_Esccateg { get; set; }

		/// <summary>Campo : "Filtered Checklist" Tipo:"DW"</summary>
		[Display(Name = "FILTERED_CHECKLIST06261", ResourceType = typeof(Resources.Resources))]
		public List<GenioMVC.Models.Cattp> List_Categor { get; set; }
		public List<GenioMVC.Models.Cattp> List_CategorSelected { get; set; }
		public string[] List_Categor_SelectedIds { get; set; }
		public string List_Categor_Area { get; set; }

		/// <summary>Campo : "Categorization" Tipo:"MO"</summary>
		[Display(Name = "CATEGORIZATION17554", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValCategory { get; set; }

		/// <summary>Campo : "Existence" Tipo:"N"</summary>
		[Display(Name = "EXISTENCE30081", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValExistenc { get; set; }

		/// <summary>Campo : "Availability" Tipo:"AC"</summary>
		[Display(Name = "AVAILABILITY56489", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Dsiponib", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDisponib { get; set; }
		[JsonIgnore]
		public SelectList List_ValDisponib { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "DESIGNATION_35800", ResourceType = typeof(Resources.Resources))]
		public string ValCodgitem { get; set; }

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCoditem { get; set; }

		public Artig_ViewModel() : base("FARTIG") { }

		public Artig_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FARTIG", currentNavigation, nestedForm) { }

		public Artig_ViewModel(Models.Item row, NavigationContext currentNavigation, bool nestedForm = false) : base("FARTIG", row, currentNavigation, nestedForm) { }

		public Artig_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("item", id);
			Model = Models.Item.Find(id, "FARTIG", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Item model = new Models.Item() { Identifier = "FARTIG" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Item model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			return DeleteConditions(Model);
		}

		public static StatusMessage DeleteConditions(Models.Item model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			return ViewConditions(Model);
		}

		public static StatusMessage ViewConditions(Models.Item model)
		{
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
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artig) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
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
 				ValCodgitem = ViewModelConversion.ToString(m.ValCodgitem);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Artig) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artig) to Model (Item) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValItemcod = ViewModelConversion.ToString(ValItemcod);
				m.ValItemdes = ViewModelConversion.ToString(ValItemdes);
				m.ValValid = ViewModelConversion.ToLogic(ValValid);
				m.ValItemtype = ViewModelConversion.ToString(ValItemtype);
				m.ValEntries = ViewModelConversion.ToNumeric(ValEntries);
				m.ValExits = ViewModelConversion.ToNumeric(ValExits);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValExistenc = ViewModelConversion.ToNumeric(ValExistenc);
				m.ValDisponib = ViewModelConversion.ToString(ValDisponib);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValCodgitem = ViewModelConversion.ToString(ValCodgitem);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artig) to Model (Item) - Error during mapping");
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
				Model = Models.Item.Find(Navigation.GetStrValue("item"), "FARTIG");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Item() { Identifier = "FARTIG" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("item");
					}

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FARTIG";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}
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
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Item.Find(Navigation.GetStrValue("item"), "FARTIG");
				if (Model == null)
				{
					Model = new Models.Item() { Identifier = "FARTIG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("item");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Artig___warehwarehdes(qs, lazyLoad);
			Load_Artig___gitemitemdes_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARTIG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARTIG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ARTIG]/
		public override void Save()
		{

			try { Model = Models.Item.Find(Navigation.GetStrValue("item"), "FARTIG"); }
			finally { if (Model == null) Model = new Models.Item() { Identifier = "FARTIG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARTIG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Item.Find(Navigation.GetStrValue("item"), "FARTIG"); }
			finally { if (Model == null) Model = new Models.Item() { Identifier = "FARTIG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARTIG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARTIG]/
		public override void Destroy(string id)
		{
			Model = Models.Item.Find(id, "FARTIG");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValItemtype = new SelectList(
				ArrayTipoarti.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValItemtype);
			this.List_ValDisponib = new SelectList(
				ArrayDsiponib.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValDisponib);
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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    artig___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
                    this.ValCodwareh = Navigation.GetStrValue("wareh");
                }
            }



            TableWarehWarehdes = new TableDBEdit<Models.Wareh>();
            TableWarehWarehdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
                    this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
                FillDependant_ArtigTableWarehWarehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
                return;
            }


            if (artig___warehwarehdesDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
                    TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
                else
                    TableWarehWarehdes.TableFilters = false;

                query = qs["qTableWarehWarehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
                }
                artig___warehwarehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIG_WAREHWAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
                    artig___warehwarehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAwareh.FldZzstate, 0)
                        .Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
                else
                    artig___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //artig___warehwarehdesConds = Wareh.AddEPH<CSGenioAwareh>(ref UserContext.Current.User, artig___warehwarehdesConds, "LED_ARTIG___WAREHWAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
                ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(false, artig___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_ARTIG___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWarehWarehdes.Query = query;
                TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(r, true, _fieldsToSerialize_ARTIG___WAREHWAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                //Seleciona se só um
                if(TableWarehWarehdes.List != null && TableWarehWarehdes.List.Count() == 1)
                {
					this.ValCodwareh = TableWarehWarehdes.List.First().Value;
					Navigation.SetValue("wareh", this.ValCodwareh);
                }
                FillDependant_ArtigTableWarehWarehdes();

                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Wareh</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ArtigTableWarehWarehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "wareh.codwareh", "wareh.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAwareh tempArea = new CSGenioAwareh(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ArtigTableWarehWarehdes(bool lazyLoad = false)
        {
            var row = GetDependant_ArtigTableWarehWarehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
                TableWarehWarehdes.Value = ViewModelConversion.ToString(row["wareh.warehdes"]);
                if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
                {
                    this.ValCodwareh = "";
                    TableWarehWarehdes.Value = "";
                    Navigation.ClearValue("wareh");
                }
                else if (lazyLoad)
                {
                    TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
                    TableWarehWarehdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodwareh),
                            Text = Convert.ToString(TableWarehWarehdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodwareh);
                }
                TableWarehWarehdes.Selected = this.ValCodwareh;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ARTIG___WAREHWAREHDES = { "Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    artig___gitemitemdes_Conds.Equal(CSGenioAgitem.FldCodgitem, Navigation.GetValue("gitem"));
                    this.ValCodgitem = Navigation.GetStrValue("gitem");
                }
            }



            TableGitemItemdes = new TableDBEdit<Models.Gitem>();
            TableGitemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_gitem") != null)
				{
                    this.ValCodgitem = Navigation.GetStrValue("RETURN_gitem");
					Navigation.CurrentLevel.SetEntry("RETURN_gitem", null);
				}
                FillDependant_ArtigTableGitemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableGitemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("gitem");
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
                if (!String.IsNullOrEmpty(qs["TableGitemItemdes_tableFilters"]))
                    TableGitemItemdes.TableFilters = bool.Parse(qs["TableGitemItemdes_tableFilters"]);
                else
                    TableGitemItemdes.TableFilters = false;

                query = qs["qTableGitemItemdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAgitem.FldItemdes, query + "%");
                }
                artig___gitemitemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableGitemItemdes"] != null ? qs["pTableGitemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ ARTIG_GITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("gitem", FormMode.New) || Navigation.checkFormMode("gitem", FormMode.Duplicate))
                    artig___gitemitemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAgitem.FldZzstate, 0)
                        .Equal(CSGenioAgitem.FldCodgitem, Navigation.GetStrValue("gitem")));
                else
                    artig___gitemitemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //artig___gitemitemdes_Conds = Gitem.AddEPH<CSGenioAgitem>(ref UserContext.Current.User, artig___gitemitemdes_Conds, "LED_ARTIG___GITEMITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("gitem", "itemdes");
                ListingMVC<CSGenioAgitem> listing = Models.ModelBase.Where<CSGenioAgitem>(false, artig___gitemitemdes_Conds, fields, offset, numberItems, sorts, "LED_ARTIG___GITEMITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableGitemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableGitemItemdes.Query = query;
                TableGitemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Gitem>((r) => new GenioMVC.Models.Gitem(r, true, _fieldsToSerialize_ARTIG___GITEMITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_gitem") != null)
				{
					this.ValCodgitem = Navigation.GetStrValue("RETURN_gitem");
					Navigation.CurrentLevel.SetEntry("RETURN_gitem", null);
				}

				TableGitemItemdes.List = new SelectList(TableGitemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCodgitem,  x => x.ValCodgitem == this.ValCodgitem), "Value", "Text", this.ValCodgitem);
                FillDependant_ArtigTableGitemItemdes();

                //Check if foreignkey comes from history
                TableGitemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("gitem");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableGitemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Gitem</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ArtigTableGitemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "gitem.codgitem", "gitem.itemdes", "gitem.itemgcod" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes, CSGenioAgitem.FldItemgcod };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAgitem tempArea = new CSGenioAgitem(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAgitem.FldCodgitem, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableGitemItemdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ArtigTableGitemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_ArtigTableGitemItemdes(this.ValCodgitem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["gitem.itemgcod"]);
                    this.funcGitemValItemgcod = () => tempValue;
                }

                // Fill List fields
                this.ValCodgitem = ViewModelConversion.ToString(row["gitem.codgitem"]);
                TableGitemItemdes.Value = ViewModelConversion.ToString(row["gitem.itemdes"]);
                if (GlobalFunctions.emptyG(this.ValCodgitem) == 1)
                {
                    this.ValCodgitem = "";
                    TableGitemItemdes.Value = "";
                    Navigation.ClearValue("gitem");
                }
                else if (lazyLoad)
                {
                    TableGitemItemdes.SetPagination(1, 0, false, false, 1);
                    TableGitemItemdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodgitem),
                            Text = Convert.ToString(TableGitemItemdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodgitem);
                }
                TableGitemItemdes.Selected = this.ValCodgitem;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGitemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ARTIG___GITEMITEMDES_ = { "Gitem", "Gitem.ValCodgitem", "Gitem.ValZzstate", "Gitem.ValItemdes" };
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
			if (List_Categori_SelectedIds == null)
				List_Categori_SelectedIds = new string[0];

			if (artig___pseudcategoriDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcattp.FldTpcatego), SortOrder.Ascending));


				CriteriaSet artig___pseudcategori_tpcatego_Conds = CriteriaSet.And();
				artig___pseudcategori_tpcatego_Conds.Equal(CSGenioAitemc.FldCoditem, ValCoditem);

// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDCATEGORI]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Cattp", FormMode.New)) // TODO: Check in Duplicate mode
					artig___pseudcategoriConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Categori = Models.ModelBase.Where<CSGenioAcattp>(false, args: artig___pseudcategoriConds, numRegs: -1, sorts: sorts, fields: new FieldRef[]
					{
						CSGenio.business.CSGenioAcattp.FldCodtpcat,
						CSGenio.business.CSGenioAcattp.FldCodsbcat,
						CSGenio.business.CSGenioAcattp.FldTpcatego,
						CSGenio.business.CSGenioAsbcat.FldSubcateg,
					}).RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(r));

				if (List_Categori_SelectedIds.Length == 0)
					List_Categori_SelectedIds = Models.ModelBase.All<CSGenioAitemc>(artig___pseudcategori_tpcatego_Conds).Rows.Select(x => x.ValCodtpcat).ToArray();
				List_CategoriSelected = List_Categori.Where(x => List_Categori_SelectedIds.Contains(x.ValCodtpcat)).ToList();
			}
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
			if (List_Categor_SelectedIds == null)
				List_Categor_SelectedIds = new string[0];

			if (artig___pseudcategor_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcattp.FldTpcatego), SortOrder.Ascending));


				CriteriaSet artig___pseudcategor__tpcatego_Conds = CriteriaSet.And();
				artig___pseudcategor__tpcatego_Conds.Equal(CSGenioAitemc.FldCoditem, ValCoditem);

// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDCATEGOR]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Cattp", FormMode.New)) // TODO: Check in Duplicate mode
					artig___pseudcategor_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Categor = Models.ModelBase.Where<CSGenioAcattp>(false, args: artig___pseudcategor_Conds, numRegs: -1, sorts: sorts, fields: new FieldRef[]
					{
						CSGenio.business.CSGenioAcattp.FldCodtpcat,
						CSGenio.business.CSGenioAcattp.FldCodsbcat,
						CSGenio.business.CSGenioAcattp.FldTpcatego,
						CSGenio.business.CSGenioAsbcat.FldSubcateg,
					}).RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(r));

				if (List_Categor_SelectedIds.Length == 0)
					List_Categor_SelectedIds = Models.ModelBase.All<CSGenioAitemc>(artig___pseudcategor__tpcatego_Conds).Rows.Select(x => x.ValCodtpcat).ToArray();
				List_CategorSelected = List_Categor.Where(x => List_Categor_SelectedIds.Contains(x.ValCodtpcat)).ToList();
			}
		}


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTIG]/
		#endregion
	}
}
