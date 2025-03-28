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

namespace GenioMVC.ViewModels.Itemc
{
	public class Catar_ViewModel : FormViewModel<Models.Itemc>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Item:" Tipo:"C"</summary>
		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Item>  TableItemItemdes { get; set; }

		/// <summary>Campo : "Category type" Tipo:"C"</summary>
		[Display(Name = "CATEGORY_TYPE23058", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cattp>  TableCattpTpcatego { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "CATEGORY_TYPE23058", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpcat { get; set; }

		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public string ValCoditem { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Category type" Tipo: "C"</summary>
		[AllowHtml]
		public string ValTpcateg { get; set; }
		#endregion

		public string ValCodcatar { get; set; }

		public Catar_ViewModel() : base("FCATAR") { }

		public Catar_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCATAR", currentNavigation, nestedForm) { }

		public Catar_ViewModel(Models.Itemc row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCATAR", row, currentNavigation, nestedForm) { }

		public Catar_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("itemc", id);
			Model = Models.Itemc.Find(id, "FCATAR", fieldsToQuery: fieldsToLoad);
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
			Models.Itemc model = new Models.Itemc() { Identifier = "FCATAR" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Itemc model)
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

		public static StatusMessage DeleteConditions(Models.Itemc model)
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

		public static StatusMessage ViewConditions(Models.Itemc model)
		{
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
				m.ValTpcateg = ViewModelConversion.ToString(ValTpcateg);
				m.ValCodcatar = ViewModelConversion.ToString(ValCodcatar);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Catar) to Model (Itemc) - Error during mapping");
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
				Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), "FCATAR");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Itemc() { Identifier = "FCATAR" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("itemc");
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

			Model.Identifier = "FCATAR";
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
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), "FCATAR");
				if (Model == null)
				{
					Model = new Models.Itemc() { Identifier = "FCATAR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("itemc");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Catar___item_itemdes_(qs, lazyLoad);
			Load_Catar___cattptpcatego(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CATAR]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CATAR]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CATAR]/
		public override void Save()
		{

			try { Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), "FCATAR"); }
			finally { if (Model == null) Model = new Models.Itemc() { Identifier = "FCATAR" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CATAR]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Itemc.Find(Navigation.GetStrValue("itemc"), "FCATAR"); }
			finally { if (Model == null) Model = new Models.Itemc() { Identifier = "FCATAR" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CATAR]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CATAR]/
		public override void Destroy(string id)
		{
			Model = Models.Itemc.Find(id, "FCATAR");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    catar___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, Navigation.GetValue("item"));
                    this.ValCoditem = Navigation.GetStrValue("item");
                }
            }



            TableItemItemdes = new TableDBEdit<Models.Item>();
            TableItemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
                    this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
                FillDependant_CatarTableItemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
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
                catar___item_itemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ CATAR_ITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
                    catar___item_itemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAitem.FldZzstate, 0)
                        .Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
                else
                    catar___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //catar___item_itemdes_Conds = Item.AddEPH<CSGenioAitem>(ref UserContext.Current.User, catar___item_itemdes_Conds, "LED_CATAR___ITEM_ITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
                ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(false, catar___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_CATAR___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableItemItemdes.Query = query;
                TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(r, true, _fieldsToSerialize_CATAR___ITEM_ITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
                if(!isSearchRequest)
                    FillDependant_CatarTableItemItemdes();

                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Item</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_CatarTableItemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "item.coditem", "item.itemdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };
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
        public void FillDependant_CatarTableItemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_CatarTableItemItemdes(this.ValCoditem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
                TableItemItemdes.Value = ViewModelConversion.ToString(row["item.itemdes"]);
                if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
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


        private readonly string[] _fieldsToSerialize_CATAR___ITEM_ITEMDES_ = { "Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    catar___cattptpcategoConds.Equal(CSGenioAcattp.FldCodtpcat, Navigation.GetValue("cattp"));
                    this.ValCodtpcat = Navigation.GetStrValue("cattp");
                }
            }



            TableCattpTpcatego = new TableDBEdit<Models.Cattp>();
            TableCattpTpcatego.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cattp") != null)
				{
                    this.ValCodtpcat = Navigation.GetStrValue("RETURN_cattp");
					Navigation.CurrentLevel.SetEntry("RETURN_cattp", null);
				}
                FillDependant_CatarTableCattpTpcatego(lazyLoad);
                //Check if foreignkey comes from history
                TableCattpTpcatego.FilledByHistory = Navigation.CheckFilledByHistory("cattp");
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
                if (!String.IsNullOrEmpty(qs["TableCattpTpcatego_tableFilters"]))
                    TableCattpTpcatego.TableFilters = bool.Parse(qs["TableCattpTpcatego_tableFilters"]);
                else
                    TableCattpTpcatego.TableFilters = false;

                query = qs["qTableCattpTpcatego"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAcattp.FldTpcatego, query + "%");
                }
                catar___cattptpcategoConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCattpTpcatego"] != null ? qs["pTableCattpTpcatego"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcattp.FldCodtpcat, CSGenioAcattp.FldTpcatego, CSGenioAcattp.FldZzstate };

// USE /[MANUAL GQT OVERRQ CATAR_CATTPTPCATEGO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cattp", FormMode.New) || Navigation.checkFormMode("cattp", FormMode.Duplicate))
                    catar___cattptpcategoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcattp.FldZzstate, 0)
                        .Equal(CSGenioAcattp.FldCodtpcat, Navigation.GetStrValue("cattp")));
                else
                    catar___cattptpcategoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcattp.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //catar___cattptpcategoConds = Cattp.AddEPH<CSGenioAcattp>(ref UserContext.Current.User, catar___cattptpcategoConds, "LED_CATAR___CATTPTPCATEGO");

                FieldRef firstVisibleColumn = new FieldRef("cattp", "tpcatego");
                ListingMVC<CSGenioAcattp> listing = Models.ModelBase.Where<CSGenioAcattp>(false, catar___cattptpcategoConds, fields, offset, numberItems, sorts, "LED_CATAR___CATTPTPCATEGO", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCattpTpcatego.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCattpTpcatego.Query = query;
                TableCattpTpcatego.Elements = listing.RowsForViewModel<GenioMVC.Models.Cattp>((r) => new GenioMVC.Models.Cattp(r, true, _fieldsToSerialize_CATAR___CATTPTPCATEGO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cattp") != null)
				{
					this.ValCodtpcat = Navigation.GetStrValue("RETURN_cattp");
					Navigation.CurrentLevel.SetEntry("RETURN_cattp", null);
				}

				TableCattpTpcatego.List = new SelectList(TableCattpTpcatego.Elements.ToSelectList(x => x.ValTpcatego, x => x.ValCodtpcat,  x => x.ValCodtpcat == this.ValCodtpcat), "Value", "Text", this.ValCodtpcat);
                if(!isSearchRequest)
                    FillDependant_CatarTableCattpTpcatego();

                //Check if foreignkey comes from history
                TableCattpTpcatego.FilledByHistory = Navigation.CheckFilledByHistory("cattp");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCattpTpcatego (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cattp</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_CatarTableCattpTpcatego(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cattp.codtpcat", "cattp.tpcatego" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcattp.FldCodtpcat, CSGenioAcattp.FldTpcatego };
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
            CSGenioAcattp tempArea = new CSGenioAcattp(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcattp.FldCodtpcat, PKey));
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
        /// Fill Dependant fields values -> TableCattpTpcatego (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_CatarTableCattpTpcatego(bool lazyLoad = false)
        {
            var row = GetDependant_CatarTableCattpTpcatego(this.ValCodtpcat, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpcat = ViewModelConversion.ToString(row["cattp.codtpcat"]);
                TableCattpTpcatego.Value = ViewModelConversion.ToString(row["cattp.tpcatego"]);
                if (GlobalFunctions.emptyG(this.ValCodtpcat) == 1)
                {
                    this.ValCodtpcat = "";
                    TableCattpTpcatego.Value = "";
                    Navigation.ClearValue("cattp");
                }
                else if (lazyLoad)
                {
                    TableCattpTpcatego.SetPagination(1, 0, false, false, 1);
                    TableCattpTpcatego.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpcat),
                            Text = Convert.ToString(TableCattpTpcatego.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpcat);
                }
                TableCattpTpcatego.Selected = this.ValCodtpcat;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCattpTpcatego): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_CATAR___CATTPTPCATEGO = { "Cattp", "Cattp.ValCodtpcat", "Cattp.ValZzstate", "Cattp.ValTpcatego" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CATAR]/
		#endregion
	}
}
