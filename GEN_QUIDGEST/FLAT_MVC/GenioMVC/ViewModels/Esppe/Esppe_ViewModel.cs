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

namespace GenioMVC.ViewModels.Esppe
{
	public class Esppe_ViewModel : FormViewModel<Models.Esppe>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pesso>  TablePessoName { get; set; }

		/// <summary>Campo : "Specialty" Tipo:"C"</summary>
		[Display(Name = "SPECIALTY09304", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Speci>  TableSpeciEspecial { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValCodpesso { get; set; }

		[Display(Name = "SPECIALTY09304", ResourceType = typeof(Resources.Resources))]
		public string ValCodespec { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodesppe { get; set; }

		public Esppe_ViewModel() : base("FESPPE") { }

		public Esppe_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FESPPE", currentNavigation, nestedForm) { }

		public Esppe_ViewModel(Models.Esppe row, NavigationContext currentNavigation, bool nestedForm = false) : base("FESPPE", row, currentNavigation, nestedForm) { }

		public Esppe_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("esppe", id);
			Model = Models.Esppe.Find(id, "FESPPE", fieldsToQuery: fieldsToLoad);
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
			Models.Esppe model = new Models.Esppe() { Identifier = "FESPPE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Esppe model)
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

		public static StatusMessage DeleteConditions(Models.Esppe model)
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

		public static StatusMessage ViewConditions(Models.Esppe model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Esppe model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Esppe m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Esppe) to ViewModel (Esppe) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
 				ValCodespec = ViewModelConversion.ToString(m.ValCodespec);
 				ValCodesppe = ViewModelConversion.ToString(m.ValCodesppe);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Esppe) to ViewModel (Esppe) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Esppe m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Esppe) to Model (Esppe) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodespec = ViewModelConversion.ToString(ValCodespec);
				m.ValCodesppe = ViewModelConversion.ToString(ValCodesppe);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Esppe) to Model (Esppe) - Error during mapping");
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
				Model = Models.Esppe.Find(Navigation.GetStrValue("esppe"), "FESPPE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Esppe() { Identifier = "FESPPE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("esppe");
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

			Model.Identifier = "FESPPE";
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

		protected override void LoadDocumentsProperties(Models.Esppe row)
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
				Model = Models.Esppe.Find(Navigation.GetStrValue("esppe"), "FESPPE");
				if (Model == null)
				{
					Model = new Models.Esppe() { Identifier = "FESPPE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("esppe");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Esppe___pessoname____(qs, lazyLoad);
			Load_Esppe___speciespecial(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ESPPE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ESPPE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ESPPE]/
		public override void Save()
		{

			try { Model = Models.Esppe.Find(Navigation.GetStrValue("esppe"), "FESPPE"); }
			finally { if (Model == null) Model = new Models.Esppe() { Identifier = "FESPPE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ESPPE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Esppe.Find(Navigation.GetStrValue("esppe"), "FESPPE"); }
			finally { if (Model == null) Model = new Models.Esppe() { Identifier = "FESPPE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ESPPE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ESPPE]/
		public override void Destroy(string id)
		{
			Model = Models.Esppe.Find(id, "FESPPE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TablePessoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Esppe___pessoname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool esppe___pessoname____DoLoad = true;
            CriteriaSet esppe___pessoname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pesso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    esppe___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
                    this.ValCodpesso = Navigation.GetStrValue("pesso");
                }
            }



            TablePessoName = new TableDBEdit<Models.Pesso>();
            TablePessoName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
                    this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
                FillDependant_EsppeTablePessoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
                return;
            }


            if (esppe___pessoname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
                    TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
                else
                    TablePessoName.TableFilters = false;

                query = qs["qTablePessoName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApesso.FldName, query + "%");
                }
                esppe___pessoname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ ESPPE_PESSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
                    esppe___pessoname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApesso.FldZzstate, 0)
                        .Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
                else
                    esppe___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //esppe___pessoname____Conds = Pesso.AddEPH<CSGenioApesso>(ref UserContext.Current.User, esppe___pessoname____Conds, "LED_ESPPE___PESSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
                ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(false, esppe___pessoname____Conds, fields, offset, numberItems, sorts, "LED_ESPPE___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePessoName.Query = query;
                TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(r, true, _fieldsToSerialize_ESPPE___PESSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
                FillDependant_EsppeTablePessoName();

                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pesso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EsppeTablePessoName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pesso.codpesso", "pesso.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName };
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
            CSGenioApesso tempArea = new CSGenioApesso(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EsppeTablePessoName(bool lazyLoad = false)
        {
            var row = GetDependant_EsppeTablePessoName(this.ValCodpesso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
                TablePessoName.Value = ViewModelConversion.ToString(row["pesso.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
                {
                    this.ValCodpesso = "";
                    TablePessoName.Value = "";
                    Navigation.ClearValue("pesso");
                }
                else if (lazyLoad)
                {
                    TablePessoName.SetPagination(1, 0, false, false, 1);
                    TablePessoName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpesso),
                            Text = Convert.ToString(TablePessoName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpesso);
                }
                TablePessoName.Selected = this.ValCodpesso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ESPPE___PESSONAME____ = { "Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName" };

        /// <summary>
        /// TableSpeciEspecial -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Esppe___speciespecial(NameValueCollection qs, bool lazyLoad = false)
        {
            bool esppe___speciespecialDoLoad = true;
            CriteriaSet esppe___speciespecialConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("speci", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    esppe___speciespecialConds.Equal(CSGenioAspeci.FldCodespec, Navigation.GetValue("speci"));
                    this.ValCodespec = Navigation.GetStrValue("speci");
                }
            }



            TableSpeciEspecial = new TableDBEdit<Models.Speci>();
            TableSpeciEspecial.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
                    this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}
                FillDependant_EsppeTableSpeciEspecial(lazyLoad);
                //Check if foreignkey comes from history
                TableSpeciEspecial.FilledByHistory = Navigation.CheckFilledByHistory("speci");
                return;
            }


            if (esppe___speciespecialDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableSpeciEspecial, "sTableSpeciEspecial", "dTableSpeciEspecial", qs, "speci");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAspeci.FldEspecial), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableSpeciEspecial_tableFilters"]))
                    TableSpeciEspecial.TableFilters = bool.Parse(qs["TableSpeciEspecial_tableFilters"]);
                else
                    TableSpeciEspecial.TableFilters = false;

                query = qs["qTableSpeciEspecial"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAspeci.FldEspecial, query + "%");
                }
                esppe___speciespecialConds.SubSet(search_filters);


                string tryParsePage = qs["pTableSpeciEspecial"] != null ? qs["pTableSpeciEspecial"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldZzstate };

// USE /[MANUAL GQT OVERRQ ESPPE_SPECIESPECIAL]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("speci", FormMode.New) || Navigation.checkFormMode("speci", FormMode.Duplicate))
                    esppe___speciespecialConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAspeci.FldZzstate, 0)
                        .Equal(CSGenioAspeci.FldCodespec, Navigation.GetStrValue("speci")));
                else
                    esppe___speciespecialConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //esppe___speciespecialConds = Speci.AddEPH<CSGenioAspeci>(ref UserContext.Current.User, esppe___speciespecialConds, "LED_ESPPE___SPECIESPECIAL");

                FieldRef firstVisibleColumn = new FieldRef("speci", "especial");
                ListingMVC<CSGenioAspeci> listing = Models.ModelBase.Where<CSGenioAspeci>(false, esppe___speciespecialConds, fields, offset, numberItems, sorts, "LED_ESPPE___SPECIESPECIAL", true, false, firstVisibleColumn: firstVisibleColumn);

                TableSpeciEspecial.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableSpeciEspecial.Query = query;
                TableSpeciEspecial.Elements = listing.RowsForViewModel<GenioMVC.Models.Speci>((r) => new GenioMVC.Models.Speci(r, true, _fieldsToSerialize_ESPPE___SPECIESPECIAL));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
					this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}

				TableSpeciEspecial.List = new SelectList(TableSpeciEspecial.Elements.ToSelectList(x => x.ValEspecial, x => x.ValCodespec,  x => x.ValCodespec == this.ValCodespec), "Value", "Text", this.ValCodespec);
                FillDependant_EsppeTableSpeciEspecial();

                //Check if foreignkey comes from history
                TableSpeciEspecial.FilledByHistory = Navigation.CheckFilledByHistory("speci");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableSpeciEspecial (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Speci</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EsppeTableSpeciEspecial(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "speci.codespec", "speci.especial" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial };
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
            CSGenioAspeci tempArea = new CSGenioAspeci(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAspeci.FldCodespec, PKey));
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
        /// Fill Dependant fields values -> TableSpeciEspecial (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EsppeTableSpeciEspecial(bool lazyLoad = false)
        {
            var row = GetDependant_EsppeTableSpeciEspecial(this.ValCodespec, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodespec = ViewModelConversion.ToString(row["speci.codespec"]);
                TableSpeciEspecial.Value = ViewModelConversion.ToString(row["speci.especial"]);
                if (GlobalFunctions.emptyG(this.ValCodespec) == 1)
                {
                    this.ValCodespec = "";
                    TableSpeciEspecial.Value = "";
                    Navigation.ClearValue("speci");
                }
                else if (lazyLoad)
                {
                    TableSpeciEspecial.SetPagination(1, 0, false, false, 1);
                    TableSpeciEspecial.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodespec),
                            Text = Convert.ToString(TableSpeciEspecial.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodespec);
                }
                TableSpeciEspecial.Selected = this.ValCodespec;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSpeciEspecial): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ESPPE___SPECIESPECIAL = { "Speci", "Speci.ValCodespec", "Speci.ValZzstate", "Speci.ValEspecial" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ESPPE]/
		#endregion
	}
}
