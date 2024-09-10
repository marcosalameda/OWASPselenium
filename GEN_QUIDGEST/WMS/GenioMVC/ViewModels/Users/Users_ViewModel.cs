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

namespace GenioMVC.ViewModels.Users
{
	public class Users_ViewModel : FormViewModel<Models.Users>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Login name" Tipo:"C"</summary>
		[Display(Name = "LOGIN_NAME31337", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Psw>  TablePswNome { get; set; }

		/// <summary>Campo : "Person name" Tipo:"C"</summary>
		[Display(Name = "PERSON_NAME40980", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Perso>  TablePersoName { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "PERSON_NAME40980", ResourceType = typeof(Resources.Resources))]
		public string ValCodperso { get; set; }

		[Display(Name = "LOGIN_NAME31337", ResourceType = typeof(Resources.Resources))]
		public string ValCodpsw { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodusers { get; set; }

		public Users_ViewModel() : base("FUSERS") { }

		public Users_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FUSERS", currentNavigation, nestedForm) { }

		public Users_ViewModel(Models.Users row, NavigationContext currentNavigation, bool nestedForm = false) : base("FUSERS", row, currentNavigation, nestedForm) { }

		public Users_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("users", id);
			Model = Models.Users.Find(id, "FUSERS", fieldsToQuery: fieldsToLoad);
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
			Models.Users model = new Models.Users() { Identifier = "FUSERS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Users model)
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

		public static StatusMessage DeleteConditions(Models.Users model)
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

		public static StatusMessage ViewConditions(Models.Users model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Users model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Users m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Users) to ViewModel (Users) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
 				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
 				ValCodusers = ViewModelConversion.ToString(m.ValCodusers);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Users) to ViewModel (Users) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Users m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Users) to Model (Users) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodusers = ViewModelConversion.ToString(ValCodusers);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Users) to Model (Users) - Error during mapping");
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
				Model = Models.Users.Find(Navigation.GetStrValue("users"), "FUSERS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Users() { Identifier = "FUSERS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("users");
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

			Model.Identifier = "FUSERS";
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

		protected override void LoadDocumentsProperties(Models.Users row)
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
				Model = Models.Users.Find(Navigation.GetStrValue("users"), "FUSERS");
				if (Model == null)
				{
					Model = new Models.Users() { Identifier = "FUSERS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("users");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Users___psw__nome____(qs, lazyLoad);
			Load_Users___personame____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL USERS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW USERS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE USERS]/
		public override void Save()
		{

			try { Model = Models.Users.Find(Navigation.GetStrValue("users"), "FUSERS"); }
			finally { if (Model == null) Model = new Models.Users() { Identifier = "FUSERS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY USERS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Users.Find(Navigation.GetStrValue("users"), "FUSERS"); }
			finally { if (Model == null) Model = new Models.Users() { Identifier = "FUSERS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE USERS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY USERS]/
		public override void Destroy(string id)
		{
			Model = Models.Users.Find(id, "FUSERS");
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
        public void Load_Users___psw__nome____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool users___psw__nome____DoLoad = true;
            CriteriaSet users___psw__nome____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("psw", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    users___psw__nome____Conds.Equal(CSGenioApsw.FldCodpsw, Navigation.GetValue("psw"));
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
                FillDependant_UsersTablePswNome(lazyLoad);
                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
                return;
            }


            if (users___psw__nome____DoLoad)
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
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
                }
                users___psw__nome____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate };

// USE /[MANUAL GQT OVERRQ USERS_PSWNOME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
                    users___psw__nome____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApsw.FldZzstate, 0)
                        .Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
                else
                    users___psw__nome____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //users___psw__nome____Conds = Psw.AddEPH<CSGenioApsw>(ref UserContext.Current.User, users___psw__nome____Conds, "LED_USERS___PSW__NOME____");

                FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
                ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(false, users___psw__nome____Conds, fields, offset, numberItems, sorts, "LED_USERS___PSW__NOME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePswNome.Query = query;
                TablePswNome.Elements = listing.RowsForViewModel<GenioMVC.Models.Psw>((r) => new GenioMVC.Models.Psw(r, true, _fieldsToSerialize_USERS___PSW__NOME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
                FillDependant_UsersTablePswNome();

                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePswNome (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Psw</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_UsersTablePswNome(string PKey, NavigationContext Navigation)
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
        public void FillDependant_UsersTablePswNome(bool lazyLoad = false)
        {
            var row = GetDependant_UsersTablePswNome(this.ValCodpsw, Navigation);
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


        private readonly string[] _fieldsToSerialize_USERS___PSW__NOME____ = { "Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome" };

        /// <summary>
        /// TablePersoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Users___personame____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool users___personame____DoLoad = true;
            CriteriaSet users___personame____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("perso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    users___personame____Conds.Equal(CSGenioAperso.FldCodperso, Navigation.GetValue("perso"));
                    this.ValCodperso = Navigation.GetStrValue("perso");
                }
            }



            TablePersoName = new TableDBEdit<Models.Perso>();
            TablePersoName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
                    this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}
                FillDependant_UsersTablePersoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
                return;
            }


            if (users___personame____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePersoName, "sTablePersoName", "dTablePersoName", qs, "perso");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePersoName_tableFilters"]))
                    TablePersoName.TableFilters = bool.Parse(qs["TablePersoName_tableFilters"]);
                else
                    TablePersoName.TableFilters = false;

                query = qs["qTablePersoName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAperso.FldName, query + "%");
                }
                users___personame____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate };

// USE /[MANUAL GQT OVERRQ USERS_PERSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
                    users___personame____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAperso.FldZzstate, 0)
                        .Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
                else
                    users___personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //users___personame____Conds = Perso.AddEPH<CSGenioAperso>(ref UserContext.Current.User, users___personame____Conds, "LED_USERS___PERSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("perso", "name");
                ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(false, users___personame____Conds, fields, offset, numberItems, sorts, "LED_USERS___PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePersoName.Query = query;
                TablePersoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Perso>((r) => new GenioMVC.Models.Perso(r, true, _fieldsToSerialize_USERS___PERSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodperso), "Value", "Text", this.ValCodperso);
                FillDependant_UsersTablePersoName();

                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePersoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Perso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_UsersTablePersoName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "perso.codperso", "perso.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName };
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
            CSGenioAperso tempArea = new CSGenioAperso(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAperso.FldCodperso, PKey));
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
        /// Fill Dependant fields values -> TablePersoName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_UsersTablePersoName(bool lazyLoad = false)
        {
            var row = GetDependant_UsersTablePersoName(this.ValCodperso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodperso = ViewModelConversion.ToString(row["perso.codperso"]);
                TablePersoName.Value = ViewModelConversion.ToString(row["perso.name"]);
                if (GlobalFunctions.emptyG(this.ValCodperso) == 1)
                {
                    this.ValCodperso = "";
                    TablePersoName.Value = "";
                    Navigation.ClearValue("perso");
                }
                else if (lazyLoad)
                {
                    TablePersoName.SetPagination(1, 0, false, false, 1);
                    TablePersoName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodperso),
                            Text = Convert.ToString(TablePersoName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodperso);
                }
                TablePersoName.Selected = this.ValCodperso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_USERS___PERSONAME____ = { "Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM USERS]/
		#endregion
	}
}
