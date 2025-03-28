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

namespace GenioMVC.ViewModels.Pworg
{
	public class Pworg_ViewModel : FormViewModel<Models.Pworg>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Psw>  TablePswNome { get; set; }

		/// <summary>Campo : "Organization" Tipo:"C"</summary>
		[Display(Name = "ORGANIZATION64123", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Organ>  TableOrganOrganiza { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ORGANIZATION64123", ResourceType = typeof(Resources.Resources))]
		public string ValCodorgan { get; set; }

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValCodpsw { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodpworg { get; set; }

		public Pworg_ViewModel() : base("FPWORG") { }

		public Pworg_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPWORG", currentNavigation, nestedForm) { }

		public Pworg_ViewModel(Models.Pworg row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPWORG", row, currentNavigation, nestedForm) { }

		public Pworg_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pworg", id);
			Model = Models.Pworg.Find(id, "FPWORG", fieldsToQuery: fieldsToLoad);
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
			Models.Pworg model = new Models.Pworg() { Identifier = "FPWORG" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Pworg model)
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

		public static StatusMessage DeleteConditions(Models.Pworg model)
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

		public static StatusMessage ViewConditions(Models.Pworg model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Pworg model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pworg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pworg) to ViewModel (Pworg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
				ValCodpworg = ViewModelConversion.ToString(m.ValCodpworg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pworg) to ViewModel (Pworg) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pworg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pworg) to Model (Pworg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodpworg = ViewModelConversion.ToString(ValCodpworg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pworg) to Model (Pworg) - Error during mapping");
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
				Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), "FPWORG");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pworg() { Identifier = "FPWORG" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("pworg");
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

			Model.Identifier = "FPWORG";
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

		protected override void LoadDocumentsProperties(Models.Pworg row)
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
				Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), "FPWORG");
				if (Model == null)
				{
					Model = new Models.Pworg() { Identifier = "FPWORG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pworg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Pworg___psw__nome____(qs, lazyLoad);
			Load_Pworg___organorganiza(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PWORG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PWORG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PWORG]/
		public override void Save()
		{

			try { Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), "FPWORG"); }
			finally { if (Model == null) Model = new Models.Pworg() { Identifier = "FPWORG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PWORG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pworg.Find(Navigation.GetStrValue("pworg"), "FPWORG"); }
			finally { if (Model == null) Model = new Models.Pworg() { Identifier = "FPWORG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PWORG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PWORG]/
		public override void Destroy(string id)
		{
			Model = Models.Pworg.Find(id, "FPWORG");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TablePswNome -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pworg___psw__nome____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pworg___psw__nome____DoLoad = true;
            CriteriaSet pworg___psw__nome____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("psw", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pworg___psw__nome____Conds.Equal(CSGenioApsw.FldCodpsw, Navigation.GetValue("psw"));
                    this.ValCodpsw = Navigation.GetStrValue("psw");
                }
            }



            TablePswNome = new TableDBEdit<Models.Psw>();
            TablePswNome.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
                    this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
                FillDependant_PworgTablePswNome(lazyLoad);
                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
                return;
            }


            if (pworg___psw__nome____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
                    TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
                else
                    TablePswNome.TableFilters = false;

                query = qs["qTablePswNome"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
                }
                pworg___psw__nome____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWORG_PSWNOME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
                    pworg___psw__nome____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApsw.FldZzstate, 0)
                        .Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
                else
                    pworg___psw__nome____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pworg___psw__nome____Conds = Psw.AddEPH<CSGenioApsw>(ref UserContext.Current.User, pworg___psw__nome____Conds, "LED_PWORG___PSW__NOME____");

                FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
                ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(false, pworg___psw__nome____Conds, fields, offset, numberItems, sorts, "LED_PWORG___PSW__NOME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePswNome.Query = query;
                TablePswNome.Elements = listing.RowsForViewModel<GenioMVC.Models.Psw>((r) => new GenioMVC.Models.Psw(r, true, _fieldsToSerialize_PWORG___PSW__NOME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
                if(!isSearchRequest)
                    FillDependant_PworgTablePswNome();

                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePswNome (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Psw</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PworgTablePswNome(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "psw.codpsw", "psw.nome" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome };
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
            CSGenioApsw tempArea = new CSGenioApsw(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));
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
        /// Fill Dependant fields values -> TablePswNome (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PworgTablePswNome(bool lazyLoad = false)
        {
            var row = GetDependant_PworgTablePswNome(this.ValCodpsw, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
                TablePswNome.Value = ViewModelConversion.ToString(row["psw.nome"]);
                if (GlobalFunctions.emptyG(this.ValCodpsw) == 1)
                {
                    this.ValCodpsw = "";
                    TablePswNome.Value = "";
                    Navigation.ClearValue("psw");
                }
                else if (lazyLoad)
                {
                    TablePswNome.SetPagination(1, 0, false, false, 1);
                    TablePswNome.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpsw),
                            Text = Convert.ToString(TablePswNome.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpsw);
                }
                TablePswNome.Selected = this.ValCodpsw;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PWORG___PSW__NOME____ = { "Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome" };

        /// <summary>
        /// TableOrganOrganiza -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pworg___organorganiza(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pworg___organorganizaDoLoad = true;
            CriteriaSet pworg___organorganizaConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("organ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pworg___organorganizaConds.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetValue("organ"));
                    this.ValCodorgan = Navigation.GetStrValue("organ");
                }
            }



            TableOrganOrganiza = new TableDBEdit<Models.Organ>();
            TableOrganOrganiza.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
                    this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}
                FillDependant_PworgTableOrganOrganiza(lazyLoad);
                //Check if foreignkey comes from history
                TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
                return;
            }


            if (pworg___organorganizaDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableOrganOrganiza, "sTableOrganOrganiza", "dTableOrganOrganiza", qs, "organ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAorgan.FldOrganiza), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableOrganOrganiza_tableFilters"]))
                    TableOrganOrganiza.TableFilters = bool.Parse(qs["TableOrganOrganiza_tableFilters"]);
                else
                    TableOrganOrganiza.TableFilters = false;

                query = qs["qTableOrganOrganiza"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAorgan.FldOrganiza, query + "%");
                }
                pworg___organorganizaConds.SubSet(search_filters);


                string tryParsePage = qs["pTableOrganOrganiza"] != null ? qs["pTableOrganOrganiza"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza, CSGenioAorgan.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWORG_ORGANORGANIZA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("organ", FormMode.New) || Navigation.checkFormMode("organ", FormMode.Duplicate))
                    pworg___organorganizaConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAorgan.FldZzstate, 0)
                        .Equal(CSGenioAorgan.FldCodorgan, Navigation.GetStrValue("organ")));
                else
                    pworg___organorganizaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAorgan.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pworg___organorganizaConds = Organ.AddEPH<CSGenioAorgan>(ref UserContext.Current.User, pworg___organorganizaConds, "LED_PWORG___ORGANORGANIZA");

                FieldRef firstVisibleColumn = new FieldRef("organ", "organiza");
                ListingMVC<CSGenioAorgan> listing = Models.ModelBase.Where<CSGenioAorgan>(false, pworg___organorganizaConds, fields, offset, numberItems, sorts, "LED_PWORG___ORGANORGANIZA", true, false, firstVisibleColumn: firstVisibleColumn);

                TableOrganOrganiza.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableOrganOrganiza.Query = query;
                TableOrganOrganiza.Elements = listing.RowsForViewModel<GenioMVC.Models.Organ>((r) => new GenioMVC.Models.Organ(r, true, _fieldsToSerialize_PWORG___ORGANORGANIZA));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}

				TableOrganOrganiza.List = new SelectList(TableOrganOrganiza.Elements.ToSelectList(x => x.ValOrganiza, x => x.ValCodorgan,  x => x.ValCodorgan == this.ValCodorgan), "Value", "Text", this.ValCodorgan);
                if(!isSearchRequest)
                    FillDependant_PworgTableOrganOrganiza();

                //Check if foreignkey comes from history
                TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableOrganOrganiza (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Organ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PworgTableOrganOrganiza(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "organ.codorgan", "organ.organiza" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza };
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
            CSGenioAorgan tempArea = new CSGenioAorgan(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAorgan.FldCodorgan, PKey));
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
        /// Fill Dependant fields values -> TableOrganOrganiza (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PworgTableOrganOrganiza(bool lazyLoad = false)
        {
            var row = GetDependant_PworgTableOrganOrganiza(this.ValCodorgan, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodorgan = ViewModelConversion.ToString(row["organ.codorgan"]);
                TableOrganOrganiza.Value = ViewModelConversion.ToString(row["organ.organiza"]);
                if (GlobalFunctions.emptyG(this.ValCodorgan) == 1)
                {
                    this.ValCodorgan = "";
                    TableOrganOrganiza.Value = "";
                    Navigation.ClearValue("organ");
                }
                else if (lazyLoad)
                {
                    TableOrganOrganiza.SetPagination(1, 0, false, false, 1);
                    TableOrganOrganiza.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodorgan),
                            Text = Convert.ToString(TableOrganOrganiza.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodorgan);
                }
                TableOrganOrganiza.Selected = this.ValCodorgan;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOrganOrganiza): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PWORG___ORGANORGANIZA = { "Organ", "Organ.ValCodorgan", "Organ.ValZzstate", "Organ.ValOrganiza" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PWORG]/
		#endregion
	}
}
