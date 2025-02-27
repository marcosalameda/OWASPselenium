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
	public class Regia_ViewModel : FormViewModel<Models.Regio>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cntry>  TableCntryCountry { get; set; }

		/// <summary>Campo : "Region" Tipo:"C"</summary>
		[Display(Name = "REGION12723", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegiao { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public string ValCodcntry { get; set; }

		public string ValCodpais1 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodregia { get; set; }

		public Regia_ViewModel() : base("FREGIA") { }

		public Regia_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIA", currentNavigation, nestedForm) { }

		public Regia_ViewModel(Models.Regio row, NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIA", row, currentNavigation, nestedForm) { }

		public Regia_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("regio", id);
			Model = Models.Regio.Find(id, "FREGIA", fieldsToQuery: fieldsToLoad);
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
			Models.Regio model = new Models.Regio() { Identifier = "FREGIA" };
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
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia) - Model is a null reference");
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
				CSGenio.framework.Log.Error("Map Model (Regio) to ViewModel (Regia) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Regio m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regia) to Model (Regio) - Model is a null reference");
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
				CSGenio.framework.Log.Error("Map ViewModel (Regia) to Model (Regio) - Error during mapping");
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
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Regio() { Identifier = "FREGIA" };
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

			Model.Identifier = "FREGIA";
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
				Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA");
				if (Model == null)
				{
					Model = new Models.Regio() { Identifier = "FREGIA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("regio");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Regia___cntrycountry_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGIA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGIA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REGIA]/
		public override void Save()
		{

			try { Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA"); }
			finally { if (Model == null) Model = new Models.Regio() { Identifier = "FREGIA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGIA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Regio.Find(Navigation.GetStrValue("regio"), "FREGIA"); }
			finally { if (Model == null) Model = new Models.Regio() { Identifier = "FREGIA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGIA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGIA]/
		public override void Destroy(string id)
		{
			Model = Models.Regio.Find(id, "FREGIA");
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
        public void Load_Regia___cntrycountry_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool regia___cntrycountry_DoLoad = true;
            CriteriaSet regia___cntrycountry_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cntry", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    regia___cntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
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
                FillDependant_RegiaTableCntryCountry(lazyLoad);
                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
                return;
            }


            if (regia___cntrycountry_DoLoad)
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
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
                }
                regia___cntrycountry_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ REGIA_CNTRYCOUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
                    regia___cntrycountry_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcntry.FldZzstate, 0)
                        .Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
                else
                    regia___cntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //regia___cntrycountry_Conds = Cntry.AddEPH<CSGenioAcntry>(ref UserContext.Current.User, regia___cntrycountry_Conds, "LED_REGIA___CNTRYCOUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
                ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(false, regia___cntrycountry_Conds, fields, offset, numberItems, sorts, "LED_REGIA___CNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCntryCountry.Query = query;
                TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(r, true, _fieldsToSerialize_REGIA___CNTRYCOUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
                if(!isSearchRequest)
                    FillDependant_RegiaTableCntryCountry();

                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cntry</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_RegiaTableCntryCountry(string PKey, NavigationContext Navigation)
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
        public void FillDependant_RegiaTableCntryCountry(bool lazyLoad = false)
        {
            var row = GetDependant_RegiaTableCntryCountry(this.ValCodcntry, Navigation);
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


        private readonly string[] _fieldsToSerialize_REGIA___CNTRYCOUNTRY_ = { "Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIA]/
		#endregion
	}
}
