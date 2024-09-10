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

namespace GenioMVC.ViewModels.Regio
{
	public class Regia_on_ViewModel : FormViewModel<Models.Regio>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "País:" Tipo:"C"</summary>
		[Display(Name = "PAIS_44650", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cntry>  TableCntryCountry { get; set; }

		/// <summary>Campo : "Região:" Tipo:"C"</summary>
		[Display(Name = "REGIAO_39589", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegiao { get; set; }

		/// <summary>Campo : "País pessoa" Tipo:"C"</summary>
		[Display(Name = "PAIS_PESSOA61621", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pais1>  TablePais1Country { get; set; }

		/// <summary>Campo : "Imóveis" Tipo:"DP"</summary>
		[Display(Name = "IMOVEIS09219", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Propr> ValImoveisl { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "PAIS_44650", ResourceType = typeof(Resources.Resources))]
		public string ValCodcntry { get; set; }

		[Display(Name = "PAIS_PESSOA61621", ResourceType = typeof(Resources.Resources))]
		public string ValCodpais1 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodregia { get; set; }

		public Regia_on_ViewModel() : base("FREGIA_ON") { }

		public Regia_on_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIA_ON", currentNavigation, nestedForm) { }

		public Regia_on_ViewModel(Models.Regio row, NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIA_ON", row, currentNavigation, nestedForm) { }

		public Regia_on_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("regio", id);
			Model = Models.Regio.Find(id, "FREGIA_ON", fieldsToQuery: fieldsToLoad);
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
			Models.Regio model = new Models.Regio() { Identifier = "FREGIA_ON" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Regio model)
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

		public static StatusMessage DeleteConditions(Models.Regio model)
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

		public static StatusMessage ViewConditions(Models.Regio model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Regio model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Regio m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia_on) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValRegiao = ViewModelConversion.ToString(m.ValRegiao);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
 				ValCodpais1 = ViewModelConversion.ToString(m.ValCodpais1);
 				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia_on) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Regio m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regia_on) to Model (Regio) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValRegiao = ViewModelConversion.ToString(ValRegiao);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpais1 = ViewModelConversion.ToString(ValCodpais1);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regia_on) to Model (Regio) - Error during mapping");
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
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA_ON");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Regio() { Identifier = "FREGIA_ON" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("regio");
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

			Model.Identifier = "FREGIA_ON";
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

		protected override void LoadDocumentsProperties(Models.Regio row)
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
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA_ON");
				if (Model == null)
				{
					Model = new Models.Regio() { Identifier = "FREGIA_ON" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("regio");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Regia_oncntrycountry_(qs, lazyLoad);
			Load_Regia_onpais1country_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGIA_ON]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGIA_ON]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REGIA_ON]/
		public override void Save()
		{

			try { Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA_ON"); }
			finally { if (Model == null) Model = new Models.Regio() { Identifier = "FREGIA_ON" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGIA_ON]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA_ON"); }
			finally { if (Model == null) Model = new Models.Regio() { Identifier = "FREGIA_ON" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGIA_ON]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGIA_ON]/
		public override void Destroy(string id)
		{
			Model = Models.Regio.Find(id, "FREGIA_ON");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableCntryCountry -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Regia_oncntrycountry_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool regia_oncntrycountry_DoLoad = true;
            CriteriaSet regia_oncntrycountry_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cntry", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    regia_oncntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
                    this.ValCodcntry = Navigation.GetStrValue("cntry");
                }
            }



            TableCntryCountry = new TableDBEdit<Models.Cntry>();
            TableCntryCountry.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
                    this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
                FillDependant_Regia_onTableCntryCountry(lazyLoad);
                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
                return;
            }


            if (regia_oncntrycountry_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
                    TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
                else
                    TableCntryCountry.TableFilters = false;

                query = qs["qTableCntryCountry"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
                }
                regia_oncntrycountry_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ REGIA_ON_CNTRYCOUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
                    regia_oncntrycountry_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcntry.FldZzstate, 0)
                        .Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
                else
                    regia_oncntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //regia_oncntrycountry_Conds = Cntry.AddEPH<CSGenioAcntry>(ref UserContext.Current.User, regia_oncntrycountry_Conds, "LED_REGIA_ONCNTRYCOUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
                ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(false, regia_oncntrycountry_Conds, fields, offset, numberItems, sorts, "LED_REGIA_ONCNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCntryCountry.Query = query;
                TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(r, true, _fieldsToSerialize_REGIA_ONCNTRYCOUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
                FillDependant_Regia_onTableCntryCountry();

                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cntry</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Regia_onTableCntryCountry(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cntry.codcntry", "cntry.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };
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
            CSGenioAcntry tempArea = new CSGenioAcntry(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));
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
        /// Fill Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Regia_onTableCntryCountry(bool lazyLoad = false)
        {
            var row = GetDependant_Regia_onTableCntryCountry(this.ValCodcntry, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
                TableCntryCountry.Value = ViewModelConversion.ToString(row["cntry.country"]);
                if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
                {
                    this.ValCodcntry = "";
                    TableCntryCountry.Value = "";
                    Navigation.ClearValue("cntry");
                }
                else if (lazyLoad)
                {
                    TableCntryCountry.SetPagination(1, 0, false, false, 1);
                    TableCntryCountry.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodcntry),
                            Text = Convert.ToString(TableCntryCountry.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodcntry);
                }
                TableCntryCountry.Selected = this.ValCodcntry;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_REGIA_ONCNTRYCOUNTRY_ = { "Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry" };

        /// <summary>
        /// TablePais1Country -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Regia_onpais1country_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool regia_onpais1country_DoLoad = true;
            CriteriaSet regia_onpais1country_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pais1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    regia_onpais1country_Conds.Equal(CSGenioApais1.FldCodcntry, Navigation.GetValue("pais1"));
                    this.ValCodpais1 = Navigation.GetStrValue("pais1");
                }
            }



            TablePais1Country = new TableDBEdit<Models.Pais1>();
            TablePais1Country.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
                    this.ValCodpais1 = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}
                FillDependant_Regia_onTablePais1Country(lazyLoad);
                //Check if foreignkey comes from history
                TablePais1Country.FilledByHistory = Navigation.CheckFilledByHistory("pais1");
                return;
            }


            if (regia_onpais1country_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePais1Country, "sTablePais1Country", "dTablePais1Country", qs, "pais1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApais1.FldCountry), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePais1Country_tableFilters"]))
                    TablePais1Country.TableFilters = bool.Parse(qs["TablePais1Country_tableFilters"]);
                else
                    TablePais1Country.TableFilters = false;

                query = qs["qTablePais1Country"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApais1.FldCountry, query + "%");
                }
                regia_onpais1country_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePais1Country"] != null ? qs["pTablePais1Country"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApais1.FldZzstate };

// USE /[MANUAL GQT OVERRQ REGIA_ON_PAIS1COUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pais1", FormMode.New) || Navigation.checkFormMode("pais1", FormMode.Duplicate))
                    regia_onpais1country_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApais1.FldZzstate, 0)
                        .Equal(CSGenioApais1.FldCodcntry, Navigation.GetStrValue("pais1")));
                else
                    regia_onpais1country_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApais1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //regia_onpais1country_Conds = Pais1.AddEPH<CSGenioApais1>(ref UserContext.Current.User, regia_onpais1country_Conds, "LED_REGIA_ONPAIS1COUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("pais1", "country");
                ListingMVC<CSGenioApais1> listing = Models.ModelBase.Where<CSGenioApais1>(false, regia_onpais1country_Conds, fields, offset, numberItems, sorts, "LED_REGIA_ONPAIS1COUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePais1Country.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePais1Country.Query = query;
                TablePais1Country.Elements = listing.RowsForViewModel<GenioMVC.Models.Pais1>((r) => new GenioMVC.Models.Pais1(r, true, _fieldsToSerialize_REGIA_ONPAIS1COUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodpais1 = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}

				TablePais1Country.List = new SelectList(TablePais1Country.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodpais1), "Value", "Text", this.ValCodpais1);
                FillDependant_Regia_onTablePais1Country();

                //Check if foreignkey comes from history
                TablePais1Country.FilledByHistory = Navigation.CheckFilledByHistory("pais1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePais1Country (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pais1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Regia_onTablePais1Country(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pais1.codcntry", "pais1.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry };
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
            CSGenioApais1 tempArea = new CSGenioApais1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApais1.FldCodcntry, PKey));
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
        /// Fill Dependant fields values -> TablePais1Country (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Regia_onTablePais1Country(bool lazyLoad = false)
        {
            var row = GetDependant_Regia_onTablePais1Country(this.ValCodpais1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpais1 = ViewModelConversion.ToString(row["pais1.codcntry"]);
                TablePais1Country.Value = ViewModelConversion.ToString(row["pais1.country"]);
                if (GlobalFunctions.emptyG(this.ValCodpais1) == 1)
                {
                    this.ValCodpais1 = "";
                    TablePais1Country.Value = "";
                    Navigation.ClearValue("pais1");
                }
                else if (lazyLoad)
                {
                    TablePais1Country.SetPagination(1, 0, false, false, 1);
                    TablePais1Country.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpais1),
                            Text = Convert.ToString(TablePais1Country.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpais1);
                }
                TablePais1Country.Selected = this.ValCodpais1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePais1Country): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_REGIA_ONPAIS1COUNTRY_ = { "Pais1", "Pais1.ValCodcntry", "Pais1.ValZzstate", "Pais1.ValCountry" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIA_ON]/
		#endregion
	}
}
