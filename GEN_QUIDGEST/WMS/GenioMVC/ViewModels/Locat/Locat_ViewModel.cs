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

namespace GenioMVC.ViewModels.Locat
{
	public class Locat_ViewModel : FormViewModel<Models.Locat>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Legal name" Tipo:"C"</summary>
		[Display(Name = "LEGAL_NAME42902", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Entit>  TableEntitName { get; set; }

		/// <summary>Campo : "Facility name" Tipo:"C"</summary>
		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Facil>  TableFacilName { get; set; }

		/// <summary>Campo : "Global Location Number" Tipo:"C"</summary>
		[Display(Name = "GLOBAL_LOCATION_NUMB24637", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGln { get; set; }

		/// <summary>Campo : "Location Extension Components" Tipo:"DP"</summary>
		[Display(Name = "LOCATION_EXTENSION_C33560", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Lcext> ValLocalext { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "LEGAL_NAME42902", ResourceType = typeof(Resources.Resources))]
		public string ValCodentit { get; set; }

		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public string ValCodfacil { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlocat { get; set; }

		public Locat_ViewModel() : base("FLOCAT") { }

		public Locat_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLOCAT", currentNavigation, nestedForm) { }

		public Locat_ViewModel(Models.Locat row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLOCAT", row, currentNavigation, nestedForm) { }

		public Locat_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("locat", id);
			Model = Models.Locat.Find(id, "FLOCAT", fieldsToQuery: fieldsToLoad);
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
			Models.Locat model = new Models.Locat() { Identifier = "FLOCAT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Locat model)
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

		public static StatusMessage DeleteConditions(Models.Locat model)
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

		public static StatusMessage ViewConditions(Models.Locat model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Locat model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Locat m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Locat) to ViewModel (Locat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValGln = ViewModelConversion.ToString(m.ValGln);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
 				ValCodfacil = ViewModelConversion.ToString(m.ValCodfacil);
 				ValCodlocat = ViewModelConversion.ToString(m.ValCodlocat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Locat) to ViewModel (Locat) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Locat m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Locat) to Model (Locat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValGln = ViewModelConversion.ToString(ValGln);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodfacil = ViewModelConversion.ToString(ValCodfacil);
				m.ValCodlocat = ViewModelConversion.ToString(ValCodlocat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Locat) to Model (Locat) - Error during mapping");
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
				Model = Models.Locat.Find(Navigation.GetStrValue("locat"), "FLOCAT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Locat() { Identifier = "FLOCAT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("locat");
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

			Model.Identifier = "FLOCAT";
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

		protected override void LoadDocumentsProperties(Models.Locat row)
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
				Model = Models.Locat.Find(Navigation.GetStrValue("locat"), "FLOCAT");
				if (Model == null)
				{
					Model = new Models.Locat() { Identifier = "FLOCAT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("locat");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Locat___entitname____(qs, lazyLoad);
			Load_Locat___facilname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LOCAT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LOCAT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LOCAT]/
		public override void Save()
		{

			try { Model = Models.Locat.Find(Navigation.GetStrValue("locat"), "FLOCAT"); }
			finally { if (Model == null) Model = new Models.Locat() { Identifier = "FLOCAT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LOCAT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Locat.Find(Navigation.GetStrValue("locat"), "FLOCAT"); }
			finally { if (Model == null) Model = new Models.Locat() { Identifier = "FLOCAT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LOCAT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LOCAT]/
		public override void Destroy(string id)
		{
			Model = Models.Locat.Find(id, "FLOCAT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableEntitName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Locat___entitname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool locat___entitname____DoLoad = true;
            CriteriaSet locat___entitname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("entit", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    locat___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
                    this.ValCodentit = Navigation.GetStrValue("entit");
                }
            }



            TableEntitName = new TableDBEdit<Models.Entit>();
            TableEntitName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
                    this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
                FillDependant_LocatTableEntitName(lazyLoad);
                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
                return;
            }


            if (locat___entitname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
                    TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
                else
                    TableEntitName.TableFilters = false;

                query = qs["qTableEntitName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAentit.FldName, query + "%");
                }
                locat___entitname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ LOCAT_ENTITNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
                    locat___entitname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAentit.FldZzstate, 0)
                        .Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
                else
                    locat___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //locat___entitname____Conds = Entit.AddEPH<CSGenioAentit>(ref UserContext.Current.User, locat___entitname____Conds, "LED_LOCAT___ENTITNAME____");

                FieldRef firstVisibleColumn = new FieldRef("entit", "name");
                ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, locat___entitname____Conds, fields, offset, numberItems, sorts, "LED_LOCAT___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEntitName.Query = query;
                TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(r, true, _fieldsToSerialize_LOCAT___ENTITNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
                FillDependant_LocatTableEntitName();

                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Entit</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LocatTableEntitName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "entit.codentit", "entit.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName };
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
            CSGenioAentit tempArea = new CSGenioAentit(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));
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
        /// Fill Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LocatTableEntitName(bool lazyLoad = false)
        {
            var row = GetDependant_LocatTableEntitName(this.ValCodentit, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
                TableEntitName.Value = ViewModelConversion.ToString(row["entit.name"]);
                if (GlobalFunctions.emptyG(this.ValCodentit) == 1)
                {
                    this.ValCodentit = "";
                    TableEntitName.Value = "";
                    Navigation.ClearValue("entit");
                }
                else if (lazyLoad)
                {
                    TableEntitName.SetPagination(1, 0, false, false, 1);
                    TableEntitName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodentit),
                            Text = Convert.ToString(TableEntitName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodentit);
                }
                TableEntitName.Selected = this.ValCodentit;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LOCAT___ENTITNAME____ = { "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials" };

        /// <summary>
        /// TableFacilName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Locat___facilname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool locat___facilname____DoLoad = true;
            CriteriaSet locat___facilname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("facil", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    locat___facilname____Conds.Equal(CSGenioAfacil.FldCodfacil, Navigation.GetValue("facil"));
                    this.ValCodfacil = Navigation.GetStrValue("facil");
                }
            }

			// Limits Generation

			// Area limit
			locat___facilname____DoLoad &= AddCriteriaAreaLimit(locat___facilname____Conds, CSGenio.business.CSGenioAentit.FldCodentit, "entit", this.ValCodentit, true);


            TableFacilName = new TableDBEdit<Models.Facil>();
            TableFacilName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_facil") != null)
				{
                    this.ValCodfacil = Navigation.GetStrValue("RETURN_facil");
					Navigation.CurrentLevel.SetEntry("RETURN_facil", null);
				}
                FillDependant_LocatTableFacilName(lazyLoad);
                //Check if foreignkey comes from history
                TableFacilName.FilledByHistory = Navigation.CheckFilledByHistory("facil");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodentit))
                locat___facilname____DoLoad = false;

            if (locat___facilname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFacilName, "sTableFacilName", "dTableFacilName", qs, "facil");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacil.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFacilName_tableFilters"]))
                    TableFacilName.TableFilters = bool.Parse(qs["TableFacilName_tableFilters"]);
                else
                    TableFacilName.TableFilters = false;

                query = qs["qTableFacilName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfacil.FldName, query + "%");
                }
                locat___facilname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFacilName"] != null ? qs["pTableFacilName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfacil.FldCodfacil, CSGenioAfacil.FldName, CSGenioAfacil.FldZzstate };

// USE /[MANUAL GQT OVERRQ LOCAT_FACILNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("facil", FormMode.New) || Navigation.checkFormMode("facil", FormMode.Duplicate))
                    locat___facilname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfacil.FldZzstate, 0)
                        .Equal(CSGenioAfacil.FldCodfacil, Navigation.GetStrValue("facil")));
                else
                    locat___facilname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacil.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //locat___facilname____Conds = Facil.AddEPH<CSGenioAfacil>(ref UserContext.Current.User, locat___facilname____Conds, "LED_LOCAT___FACILNAME____");

                FieldRef firstVisibleColumn = new FieldRef("facil", "name");
                ListingMVC<CSGenioAfacil> listing = Models.ModelBase.Where<CSGenioAfacil>(false, locat___facilname____Conds, fields, offset, numberItems, sorts, "LED_LOCAT___FACILNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFacilName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFacilName.Query = query;
                TableFacilName.Elements = listing.RowsForViewModel<GenioMVC.Models.Facil>((r) => new GenioMVC.Models.Facil(r, true, _fieldsToSerialize_LOCAT___FACILNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_facil") != null)
				{
					this.ValCodfacil = Navigation.GetStrValue("RETURN_facil");
					Navigation.CurrentLevel.SetEntry("RETURN_facil", null);
				}

				TableFacilName.List = new SelectList(TableFacilName.Elements.ToSelectList(x => x.ValName, x => x.ValCodfacil,  x => x.ValCodfacil == this.ValCodfacil), "Value", "Text", this.ValCodfacil);
                FillDependant_LocatTableFacilName();

                //Check if foreignkey comes from history
                TableFacilName.FilledByHistory = Navigation.CheckFilledByHistory("facil");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFacilName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Facil</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LocatTableFacilName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "facil.codfacil", "facil.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfacil.FldCodfacil, CSGenioAfacil.FldName };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("entit");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAfacil.FldCodentit, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAfacil tempArea = new CSGenioAfacil(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfacil.FldCodfacil, PKey));
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
        /// Fill Dependant fields values -> TableFacilName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LocatTableFacilName(bool lazyLoad = false)
        {
            var row = GetDependant_LocatTableFacilName(this.ValCodfacil, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodfacil = ViewModelConversion.ToString(row["facil.codfacil"]);
                TableFacilName.Value = ViewModelConversion.ToString(row["facil.name"]);
                if (GlobalFunctions.emptyG(this.ValCodfacil) == 1)
                {
                    this.ValCodfacil = "";
                    TableFacilName.Value = "";
                    Navigation.ClearValue("facil");
                }
                else if (lazyLoad)
                {
                    TableFacilName.SetPagination(1, 0, false, false, 1);
                    TableFacilName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodfacil),
                            Text = Convert.ToString(TableFacilName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodfacil);
                }
                TableFacilName.Selected = this.ValCodfacil;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFacilName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LOCAT___FACILNAME____ = { "Facil", "Facil.ValCodfacil", "Facil.ValZzstate", "Facil.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LOCAT]/
		#endregion
	}
}
