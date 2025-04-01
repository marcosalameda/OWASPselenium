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
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Ldent
{
	public class Ldent_ViewModel : FormViewModel<Models.Ldent>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "" Tipo:"N"</summary>
		public TableDBEdit<GenioMVC.Models.Indoc>  TableIndocDocumenr { get; set; }

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Wareh>  TableWarehWarehdes { get; set; }

		/// <summary>Campo : "Line" Tipo:"N"</summary>
		[Display(Name = "LINE27983", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N1}" )]
		[NumericAttribute(1)]
		public decimal? ValLine { get; set; }

		/// <summary>Campo : "Items in use" Tipo:"L"</summary>
		[Display(Name = "ITEMS_IN_USE00587", ResourceType = typeof(Resources.Resources))]
		public bool ValEmuso { get; set; }

		/// <summary>Campo : "Item" Tipo:"C"</summary>
		[Display(Name = "ITEM40802", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Item>  TableItemItemdes { get; set; }

		/// <summary>Campo : "Input Quantity" Tipo:"N"</summary>
		[Display(Name = "INPUT_QUANTITY01675", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdentra { get; set; }

		/// <summary>Campo : "" Tipo:"CE"</summary>
		public string IndocValCodwareh { get { return funcIndocValCodwareh != null ? funcIndocValCodwareh() : _auxIndocValCodwareh; } set { funcIndocValCodwareh = () => value; } }
		[JsonIgnore]
		public Func<string> funcIndocValCodwareh { get; set; }
		private string _auxIndocValCodwareh { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ValCoddentr")]
		public string ValCoddentr { get; set; }

		[Display(Name = "ITEM40802", ResourceType = typeof(Resources.Resources))]
		public string ValCoditem { get; set; }

		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodldent { get; set; }

		public Ldent_ViewModel() : base("FLDENT") { }

		public Ldent_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLDENT", currentNavigation, nestedForm) { }

		public Ldent_ViewModel(Models.Ldent row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLDENT", row, currentNavigation, nestedForm) { }

		public Ldent_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("ldent", id);
			Model = Models.Ldent.Find(id, "FLDENT", fieldsToQuery: fieldsToLoad);
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
			Models.Ldent model = new Models.Ldent() { Identifier = "FLDENT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Ldent model)
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

		public static StatusMessage DeleteConditions(Models.Ldent model)
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

		public static StatusMessage ViewConditions(Models.Ldent model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Ldent model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Ldent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Ldent) to ViewModel (Ldent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
				ValEmuso = ViewModelConversion.ToLogic(m.ValEmuso);
				ValQtdentra = ViewModelConversion.ToNumeric(m.ValQtdentra);
				funcIndocValCodwareh = () => ViewModelConversion.ToString(m.Indoc.ValCodwareh);
				ValCoddentr = ViewModelConversion.ToString(m.ValCoddentr);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValCodldent = ViewModelConversion.ToString(m.ValCodldent);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Ldent) to ViewModel (Ldent) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Ldent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldent) to Model (Ldent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValEmuso = ViewModelConversion.ToLogic(ValEmuso);
				m.ValQtdentra = ViewModelConversion.ToNumeric(ValQtdentra);
				m.ValCoddentr = ViewModelConversion.ToString(ValCoddentr);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodldent = ViewModelConversion.ToString(ValCodldent);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldent) to Model (Ldent) - Error during mapping");
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
				Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), "FLDENT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Ldent() { Identifier = "FLDENT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");
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

			Model.Identifier = "FLDENT";
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
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), "FLDENT");
				if (Model == null)
				{
					Model = new Models.Ldent() { Identifier = "FLDENT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

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

// USE /[MANUAL GQT VIEWMODEL_SAVE LDENT]/
		public override void Save()
		{

			try { Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), "FLDENT"); }
			finally { if (Model == null) Model = new Models.Ldent() { Identifier = "FLDENT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LDENT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Ldent.Find(Navigation.GetStrValue("ldent"), "FLDENT"); }
			finally { if (Model == null) Model = new Models.Ldent() { Identifier = "FLDENT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LDENT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LDENT]/
		public override void Destroy(string id)
		{
			Model = Models.Ldent.Find(id, "FLDENT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldent___indocdocumenrConds.Equal(CSGenioAindoc.FldCoddentr, Navigation.GetValue("indoc"));
                    this.ValCoddentr = Navigation.GetStrValue("indoc");
                }
            }



            TableIndocDocumenr = new TableDBEdit<Models.Indoc>();
            TableIndocDocumenr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_indoc") != null)
				{
                    this.ValCoddentr = Navigation.GetStrValue("RETURN_indoc");
					Navigation.CurrentLevel.SetEntry("RETURN_indoc", null);
				}
                FillDependant_LdentTableIndocDocumenr(lazyLoad);
                //Check if foreignkey comes from history
                TableIndocDocumenr.FilledByHistory = Navigation.CheckFilledByHistory("indoc");
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
                if (!String.IsNullOrEmpty(qs["TableIndocDocumenr_tableFilters"]))
                    TableIndocDocumenr.TableFilters = bool.Parse(qs["TableIndocDocumenr_tableFilters"]);
                else
                    TableIndocDocumenr.TableFilters = false;

                query = qs["qTableIndocDocumenr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAindoc.FldDocumenr, query + "%");
                }
                ldent___indocdocumenrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableIndocDocumenr"] != null ? qs["pTableIndocDocumenr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldDocumenr, CSGenioAindoc.FldDhdocume, CSGenioAindoc.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_INDOCDOCUMENR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("indoc", FormMode.New) || Navigation.checkFormMode("indoc", FormMode.Duplicate))
                    ldent___indocdocumenrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAindoc.FldZzstate, 0)
                        .Equal(CSGenioAindoc.FldCoddentr, Navigation.GetStrValue("indoc")));
                else
                    ldent___indocdocumenrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAindoc.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldent___indocdocumenrConds = Indoc.AddEPH<CSGenioAindoc>(ref UserContext.Current.User, ldent___indocdocumenrConds, "LED_LDENT___INDOCDOCUMENR");

                FieldRef firstVisibleColumn = new FieldRef("indoc", "documenr");
                ListingMVC<CSGenioAindoc> listing = Models.ModelBase.Where<CSGenioAindoc>(false, ldent___indocdocumenrConds, fields, offset, numberItems, sorts, "LED_LDENT___INDOCDOCUMENR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableIndocDocumenr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableIndocDocumenr.Query = query;
                TableIndocDocumenr.Elements = listing.RowsForViewModel<GenioMVC.Models.Indoc>((r) => new GenioMVC.Models.Indoc(r, true, _fieldsToSerialize_LDENT___INDOCDOCUMENR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_indoc") != null)
				{
					this.ValCoddentr = Navigation.GetStrValue("RETURN_indoc");
					Navigation.CurrentLevel.SetEntry("RETURN_indoc", null);
				}

				TableIndocDocumenr.List = new SelectList(TableIndocDocumenr.Elements.ToSelectList(x => x.ValDocumenr, x => x.ValCoddentr,  x => x.ValCoddentr == this.ValCoddentr), "Value", "Text", this.ValCoddentr);
                if(!isSearchRequest)
                    FillDependant_LdentTableIndocDocumenr();

                //Check if foreignkey comes from history
                TableIndocDocumenr.FilledByHistory = Navigation.CheckFilledByHistory("indoc");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableIndocDocumenr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Indoc</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdentTableIndocDocumenr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "indoc.coddentr", "indoc.documenr", "indoc.codwareh" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldDocumenr, CSGenioAindoc.FldCodwareh };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GenFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAindoc tempArea = new CSGenioAindoc(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAindoc.FldCoddentr, PKey));
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
        /// Fill Dependant fields values -> TableIndocDocumenr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdentTableIndocDocumenr(bool lazyLoad = false)
        {
            var row = GetDependant_LdentTableIndocDocumenr(this.ValCoddentr, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["indoc.codwareh"]);
                    this.funcIndocValCodwareh = () => tempValue;
                }

                // Fill List fields
                this.ValCoddentr = ViewModelConversion.ToString(row["indoc.coddentr"]);
                TableIndocDocumenr.Value = ViewModelConversion.ToNumeric(row["indoc.documenr"]);
                if (GenFunctions.emptyG(this.ValCoddentr) == 1)
                {
                    this.ValCoddentr = "";
                    TableIndocDocumenr.Value = 0m;
                    Navigation.ClearValue("indoc");
                }
                else if (lazyLoad)
                {
                    TableIndocDocumenr.SetPagination(1, 0, false, false, 1);
                    TableIndocDocumenr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoddentr),
                            Text = Convert.ToString(TableIndocDocumenr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoddentr);
                }
                TableIndocDocumenr.Selected = this.ValCoddentr;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableIndocDocumenr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDENT___INDOCDOCUMENR = { "Indoc", "Indoc.ValCoddentr", "Indoc.ValZzstate", "Indoc.ValDocumenr", "Indoc.ValDhdocume" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldent___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
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
                FillDependant_LdentTableWarehWarehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
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
                if (!String.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
                    TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
                else
                    TableWarehWarehdes.TableFilters = false;

                query = qs["qTableWarehWarehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
                }
                ldent___warehwarehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_WAREHWAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
                    ldent___warehwarehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAwareh.FldZzstate, 0)
                        .Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
                else
                    ldent___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldent___warehwarehdesConds = Wareh.AddEPH<CSGenioAwareh>(ref UserContext.Current.User, ldent___warehwarehdesConds, "LED_LDENT___WAREHWAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
                ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(false, ldent___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_LDENT___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWarehWarehdes.Query = query;
                TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(r, true, _fieldsToSerialize_LDENT___WAREHWAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                if(!isSearchRequest)
                    FillDependant_LdentTableWarehWarehdes();

                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Wareh</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdentTableWarehWarehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "wareh.codwareh", "wareh.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GenFunctions.emptyG(PKey) == 1)
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
        public void FillDependant_LdentTableWarehWarehdes(bool lazyLoad = false)
        {
            var row = GetDependant_LdentTableWarehWarehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
                TableWarehWarehdes.Value = ViewModelConversion.ToString(row["wareh.warehdes"]);
                if (GenFunctions.emptyG(this.ValCodwareh) == 1)
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


        private readonly string[] _fieldsToSerialize_LDENT___WAREHWAREHDES = { "Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldent___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, Navigation.GetValue("item"));
                    this.ValCoditem = Navigation.GetStrValue("item");
                }
            }

			// Limits Generation

			// Area limit
			ldent___item_itemdes_DoLoad &= AddCriteriaAreaLimit(ldent___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);


            TableItemItemdes = new TableDBEdit<Models.Item>();
            TableItemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
                    this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
                FillDependant_LdentTableItemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodwareh))
                ldent___item_itemdes_DoLoad = false;

            if (ldent___item_itemdes_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
                    TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
                else
                    TableItemItemdes.TableFilters = false;

                query = qs["qTableItemItemdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
                }
                ldent___item_itemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldValid, CSGenioAitem.FldItemtype, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDENT_ITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
                    ldent___item_itemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAitem.FldZzstate, 0)
                        .Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
                else
                    ldent___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldent___item_itemdes_Conds = Item.AddEPH<CSGenioAitem>(ref UserContext.Current.User, ldent___item_itemdes_Conds, "LED_LDENT___ITEM_ITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
                ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(false, ldent___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_LDENT___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableItemItemdes.Query = query;
                TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(r, true, _fieldsToSerialize_LDENT___ITEM_ITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
                if(!isSearchRequest)
                    FillDependant_LdentTableItemItemdes();

                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Item</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdentTableItemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "item.coditem", "item.itemdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };
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
                    else
                        wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAitem tempArea = new CSGenioAitem(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));
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
        /// Fill Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdentTableItemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_LdentTableItemItemdes(this.ValCoditem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
                TableItemItemdes.Value = ViewModelConversion.ToString(row["item.itemdes"]);
                if (GenFunctions.emptyG(this.ValCoditem) == 1)
                {
                    this.ValCoditem = "";
                    TableItemItemdes.Value = "";
                    Navigation.ClearValue("item");
                }
                else if (lazyLoad)
                {
                    TableItemItemdes.SetPagination(1, 0, false, false, 1);
                    TableItemItemdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoditem),
                            Text = Convert.ToString(TableItemItemdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoditem);
                }
                TableItemItemdes.Selected = this.ValCoditem;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDENT___ITEM_ITEMDES_ = { "Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod", "Item.ValValid", "Item.ValItemtype" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LDENT]/
		#endregion
	}
}
