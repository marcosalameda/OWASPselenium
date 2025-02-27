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

namespace GenioMVC.ViewModels.Tradu
{
	public class Tradu_ViewModel : FormViewModel<Models.Tradu>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Reference" Tipo:"C"</summary>
		[Display(Name = "REFERENCE28402", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValReferenc { get; set; }

		/// <summary>Campo : "Language" Tipo:"C"</summary>
		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Lang1>  TableLang1Langua { get; set; }

		/// <summary>Campo : "To translate" Tipo:"C"</summary>
		[Display(Name = "TO_TRANSLATE20058", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAtraduzi { get; set; }

		/// <summary>Campo : "Language" Tipo:"C"</summary>
		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Lang2>  TableLang2Langua { get; set; }

		/// <summary>Campo : "Translated" Tipo:"C"</summary>
		[Display(Name = "TRANSLATED03333", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTraduzid { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public string ValCodidio1 { get; set; }

		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public string ValCodidio2 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtradu { get; set; }

		public Tradu_ViewModel() : base("FTRADU") { }

		public Tradu_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTRADU", currentNavigation, nestedForm) { }

		public Tradu_ViewModel(Models.Tradu row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTRADU", row, currentNavigation, nestedForm) { }

		public Tradu_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tradu", id);
			Model = Models.Tradu.Find(id, "FTRADU", fieldsToQuery: fieldsToLoad);
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
			Models.Tradu model = new Models.Tradu() { Identifier = "FTRADU" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tradu model)
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

		public static StatusMessage DeleteConditions(Models.Tradu model)
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

		public static StatusMessage ViewConditions(Models.Tradu model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tradu model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tradu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tradu) to ViewModel (Tradu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValReferenc = ViewModelConversion.ToString(m.ValReferenc);
 				ValAtraduzi = ViewModelConversion.ToString(m.ValAtraduzi);
 				ValTraduzid = ViewModelConversion.ToString(m.ValTraduzid);
 				ValCodidio1 = ViewModelConversion.ToString(m.ValCodidio1);
 				ValCodidio2 = ViewModelConversion.ToString(m.ValCodidio2);
 				ValCodtradu = ViewModelConversion.ToString(m.ValCodtradu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tradu) to ViewModel (Tradu) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tradu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tradu) to Model (Tradu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValReferenc = ViewModelConversion.ToString(ValReferenc);
				m.ValAtraduzi = ViewModelConversion.ToString(ValAtraduzi);
				m.ValTraduzid = ViewModelConversion.ToString(ValTraduzid);
				m.ValCodidio1 = ViewModelConversion.ToString(ValCodidio1);
				m.ValCodidio2 = ViewModelConversion.ToString(ValCodidio2);
				m.ValCodtradu = ViewModelConversion.ToString(ValCodtradu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tradu) to Model (Tradu) - Error during mapping");
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
				Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), "FTRADU");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tradu() { Identifier = "FTRADU" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tradu");
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

			Model.Identifier = "FTRADU";
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

		protected override void LoadDocumentsProperties(Models.Tradu row)
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
				Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), "FTRADU");
				if (Model == null)
				{
					Model = new Models.Tradu() { Identifier = "FTRADU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tradu");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tradu___lang1langua__(qs, lazyLoad);
			Load_Tradu___lang2langua__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TRADU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TRADU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TRADU]/
		public override void Save()
		{

			try { Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), "FTRADU"); }
			finally { if (Model == null) Model = new Models.Tradu() { Identifier = "FTRADU" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TRADU]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), "FTRADU"); }
			finally { if (Model == null) Model = new Models.Tradu() { Identifier = "FTRADU" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TRADU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TRADU]/
		public override void Destroy(string id)
		{
			Model = Models.Tradu.Find(id, "FTRADU");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableLang1Langua -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tradu___lang1langua__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tradu___lang1langua__DoLoad = true;
            CriteriaSet tradu___lang1langua__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("lang1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tradu___lang1langua__Conds.Equal(CSGenioAlang1.FldCodlang, Navigation.GetValue("lang1"));
                    this.ValCodidio1 = Navigation.GetStrValue("lang1");
                }
            }



            TableLang1Langua = new TableDBEdit<Models.Lang1>();
            TableLang1Langua.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_lang1") != null)
				{
                    this.ValCodidio1 = Navigation.GetStrValue("RETURN_lang1");
					Navigation.CurrentLevel.SetEntry("RETURN_lang1", null);
				}
                FillDependant_TraduTableLang1Langua(lazyLoad);
                //Check if foreignkey comes from history
                TableLang1Langua.FilledByHistory = Navigation.CheckFilledByHistory("lang1");
                return;
            }


            if (tradu___lang1langua__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLang1Langua, "sTableLang1Langua", "dTableLang1Langua", qs, "lang1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlang1.FldLangua), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLang1Langua_tableFilters"]))
                    TableLang1Langua.TableFilters = bool.Parse(qs["TableLang1Langua_tableFilters"]);
                else
                    TableLang1Langua.TableFilters = false;

                query = qs["qTableLang1Langua"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAlang1.FldLangua, query + "%");
                }
                tradu___lang1langua__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLang1Langua"] != null ? qs["pTableLang1Langua"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlang1.FldCodlang, CSGenioAlang1.FldLangua, CSGenioAlang1.FldZzstate };

// USE /[MANUAL GQT OVERRQ TRADU_LANG1LANGUA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("lang1", FormMode.New) || Navigation.checkFormMode("lang1", FormMode.Duplicate))
                    tradu___lang1langua__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlang1.FldZzstate, 0)
                        .Equal(CSGenioAlang1.FldCodlang, Navigation.GetStrValue("lang1")));
                else
                    tradu___lang1langua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlang1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tradu___lang1langua__Conds = Lang1.AddEPH<CSGenioAlang1>(ref UserContext.Current.User, tradu___lang1langua__Conds, "LED_TRADU___LANG1LANGUA__");

                FieldRef firstVisibleColumn = new FieldRef("lang1", "langua");
                ListingMVC<CSGenioAlang1> listing = Models.ModelBase.Where<CSGenioAlang1>(false, tradu___lang1langua__Conds, fields, offset, numberItems, sorts, "LED_TRADU___LANG1LANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLang1Langua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLang1Langua.Query = query;
                TableLang1Langua.Elements = listing.RowsForViewModel<GenioMVC.Models.Lang1>((r) => new GenioMVC.Models.Lang1(r, true, _fieldsToSerialize_TRADU___LANG1LANGUA__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_lang1") != null)
				{
					this.ValCodidio1 = Navigation.GetStrValue("RETURN_lang1");
					Navigation.CurrentLevel.SetEntry("RETURN_lang1", null);
				}

				TableLang1Langua.List = new SelectList(TableLang1Langua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodidio1), "Value", "Text", this.ValCodidio1);
                if(!isSearchRequest)
                    FillDependant_TraduTableLang1Langua();

                //Check if foreignkey comes from history
                TableLang1Langua.FilledByHistory = Navigation.CheckFilledByHistory("lang1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLang1Langua (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Lang1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TraduTableLang1Langua(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "lang1.codlang", "lang1.langua" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlang1.FldCodlang, CSGenioAlang1.FldLangua };
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
            CSGenioAlang1 tempArea = new CSGenioAlang1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlang1.FldCodlang, PKey));
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
        /// Fill Dependant fields values -> TableLang1Langua (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TraduTableLang1Langua(bool lazyLoad = false)
        {
            var row = GetDependant_TraduTableLang1Langua(this.ValCodidio1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodidio1 = ViewModelConversion.ToString(row["lang1.codlang"]);
                TableLang1Langua.Value = ViewModelConversion.ToString(row["lang1.langua"]);
                if (GlobalFunctions.emptyG(this.ValCodidio1) == 1)
                {
                    this.ValCodidio1 = "";
                    TableLang1Langua.Value = "";
                    Navigation.ClearValue("lang1");
                }
                else if (lazyLoad)
                {
                    TableLang1Langua.SetPagination(1, 0, false, false, 1);
                    TableLang1Langua.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodidio1),
                            Text = Convert.ToString(TableLang1Langua.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodidio1);
                }
                TableLang1Langua.Selected = this.ValCodidio1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLang1Langua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TRADU___LANG1LANGUA__ = { "Lang1", "Lang1.ValCodlang", "Lang1.ValZzstate", "Lang1.ValLangua" };

        /// <summary>
        /// TableLang2Langua -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tradu___lang2langua__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tradu___lang2langua__DoLoad = true;
            CriteriaSet tradu___lang2langua__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("lang2", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tradu___lang2langua__Conds.Equal(CSGenioAlang2.FldCodlang, Navigation.GetValue("lang2"));
                    this.ValCodidio2 = Navigation.GetStrValue("lang2");
                }
            }



            TableLang2Langua = new TableDBEdit<Models.Lang2>();
            TableLang2Langua.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_lang2") != null)
				{
                    this.ValCodidio2 = Navigation.GetStrValue("RETURN_lang2");
					Navigation.CurrentLevel.SetEntry("RETURN_lang2", null);
				}
                FillDependant_TraduTableLang2Langua(lazyLoad);
                //Check if foreignkey comes from history
                TableLang2Langua.FilledByHistory = Navigation.CheckFilledByHistory("lang2");
                return;
            }


            if (tradu___lang2langua__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLang2Langua, "sTableLang2Langua", "dTableLang2Langua", qs, "lang2");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlang2.FldLangua), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLang2Langua_tableFilters"]))
                    TableLang2Langua.TableFilters = bool.Parse(qs["TableLang2Langua_tableFilters"]);
                else
                    TableLang2Langua.TableFilters = false;

                query = qs["qTableLang2Langua"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAlang2.FldLangua, query + "%");
                }
                tradu___lang2langua__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLang2Langua"] != null ? qs["pTableLang2Langua"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlang2.FldCodlang, CSGenioAlang2.FldLangua, CSGenioAlang2.FldZzstate };

// USE /[MANUAL GQT OVERRQ TRADU_LANG2LANGUA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("lang2", FormMode.New) || Navigation.checkFormMode("lang2", FormMode.Duplicate))
                    tradu___lang2langua__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlang2.FldZzstate, 0)
                        .Equal(CSGenioAlang2.FldCodlang, Navigation.GetStrValue("lang2")));
                else
                    tradu___lang2langua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlang2.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tradu___lang2langua__Conds = Lang2.AddEPH<CSGenioAlang2>(ref UserContext.Current.User, tradu___lang2langua__Conds, "LED_TRADU___LANG2LANGUA__");

                FieldRef firstVisibleColumn = new FieldRef("lang2", "langua");
                ListingMVC<CSGenioAlang2> listing = Models.ModelBase.Where<CSGenioAlang2>(false, tradu___lang2langua__Conds, fields, offset, numberItems, sorts, "LED_TRADU___LANG2LANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLang2Langua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLang2Langua.Query = query;
                TableLang2Langua.Elements = listing.RowsForViewModel<GenioMVC.Models.Lang2>((r) => new GenioMVC.Models.Lang2(r, true, _fieldsToSerialize_TRADU___LANG2LANGUA__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_lang2") != null)
				{
					this.ValCodidio2 = Navigation.GetStrValue("RETURN_lang2");
					Navigation.CurrentLevel.SetEntry("RETURN_lang2", null);
				}

				TableLang2Langua.List = new SelectList(TableLang2Langua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodidio2), "Value", "Text", this.ValCodidio2);
                if(!isSearchRequest)
                    FillDependant_TraduTableLang2Langua();

                //Check if foreignkey comes from history
                TableLang2Langua.FilledByHistory = Navigation.CheckFilledByHistory("lang2");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLang2Langua (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Lang2</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TraduTableLang2Langua(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "lang2.codlang", "lang2.langua" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlang2.FldCodlang, CSGenioAlang2.FldLangua };
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
            CSGenioAlang2 tempArea = new CSGenioAlang2(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlang2.FldCodlang, PKey));
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
        /// Fill Dependant fields values -> TableLang2Langua (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TraduTableLang2Langua(bool lazyLoad = false)
        {
            var row = GetDependant_TraduTableLang2Langua(this.ValCodidio2, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodidio2 = ViewModelConversion.ToString(row["lang2.codlang"]);
                TableLang2Langua.Value = ViewModelConversion.ToString(row["lang2.langua"]);
                if (GlobalFunctions.emptyG(this.ValCodidio2) == 1)
                {
                    this.ValCodidio2 = "";
                    TableLang2Langua.Value = "";
                    Navigation.ClearValue("lang2");
                }
                else if (lazyLoad)
                {
                    TableLang2Langua.SetPagination(1, 0, false, false, 1);
                    TableLang2Langua.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodidio2),
                            Text = Convert.ToString(TableLang2Langua.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodidio2);
                }
                TableLang2Langua.Selected = this.ValCodidio2;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLang2Langua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TRADU___LANG2LANGUA__ = { "Lang2", "Lang2.ValCodlang", "Lang2.ValZzstate", "Lang2.ValLangua" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TRADU]/
		#endregion
	}
}
