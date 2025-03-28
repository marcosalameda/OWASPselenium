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

namespace GenioMVC.ViewModels.Conta
{
	public class Conta_ViewModel : FormViewModel<Models.Conta>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name:" Tipo:"C"</summary>
		[Display(Name = "NAME_23841", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pesso>  TablePessoName { get; set; }

		/// <summary>Campo : "Genre" Tipo:"C"</summary>
		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Genre>  TableGenreGender { get; set; }

		/// <summary>Campo : "Contact Type:" Tipo:"C"</summary>
		[Display(Name = "CONTACT_TYPE_27897", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpcon>  TableTpconTipocont { get; set; }

		/// <summary>Campo : "Contact" Tipo:"C"</summary>
		[Display(Name = "CONTACT59247", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValContacto { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		public string ValCodgenre { get; set; }

		[Display(Name = "NAME_23841", ResourceType = typeof(Resources.Resources))]
		public string ValCodpesso { get; set; }

		[Display(Name = "CONTACT_TYPE_27897", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpcon { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodconta { get; set; }

		public Conta_ViewModel() : base("FCONTA") { }

		public Conta_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCONTA", currentNavigation, nestedForm) { }

		public Conta_ViewModel(Models.Conta row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCONTA", row, currentNavigation, nestedForm) { }

		public Conta_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("conta", id);
			Model = Models.Conta.Find(id, "FCONTA", fieldsToQuery: fieldsToLoad);
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
			Models.Conta model = new Models.Conta() { Identifier = "FCONTA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Conta model)
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

		public static StatusMessage DeleteConditions(Models.Conta model)
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

		public static StatusMessage ViewConditions(Models.Conta model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Conta model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Conta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Conta) to ViewModel (Conta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValContacto = ViewModelConversion.ToString(m.ValContacto);
				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodtpcon = ViewModelConversion.ToString(m.ValCodtpcon);
				ValCodconta = ViewModelConversion.ToString(m.ValCodconta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Conta) to ViewModel (Conta) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Conta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Conta) to Model (Conta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValContacto = ViewModelConversion.ToString(ValContacto);
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodtpcon = ViewModelConversion.ToString(ValCodtpcon);
				m.ValCodconta = ViewModelConversion.ToString(ValCodconta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Conta) to Model (Conta) - Error during mapping");
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
				Model = Models.Conta.Find(Navigation.GetStrValue("conta"), "FCONTA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Conta() { Identifier = "FCONTA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("conta");
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

			Model.Identifier = "FCONTA";
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

		protected override void LoadDocumentsProperties(Models.Conta row)
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
				Model = Models.Conta.Find(Navigation.GetStrValue("conta"), "FCONTA");
				if (Model == null)
				{
					Model = new Models.Conta() { Identifier = "FCONTA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("conta");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Conta___pessoname____(qs, lazyLoad);
			Load_Conta___genregender__(qs, lazyLoad);
			Load_Conta___tpcontipocont(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CONTA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CONTA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CONTA]/
		public override void Save()
		{

			try { Model = Models.Conta.Find(Navigation.GetStrValue("conta"), "FCONTA"); }
			finally { if (Model == null) Model = new Models.Conta() { Identifier = "FCONTA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CONTA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Conta.Find(Navigation.GetStrValue("conta"), "FCONTA"); }
			finally { if (Model == null) Model = new Models.Conta() { Identifier = "FCONTA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CONTA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CONTA]/
		public override void Destroy(string id)
		{
			Model = Models.Conta.Find(id, "FCONTA");
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
        public void Load_Conta___pessoname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool conta___pessoname____DoLoad = true;
            CriteriaSet conta___pessoname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pesso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    conta___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
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
                FillDependant_ContaTablePessoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
                return;
            }


            if (conta___pessoname____DoLoad)
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
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApesso.FldName, query + "%");
                }
                conta___pessoname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_PESSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
                    conta___pessoname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApesso.FldZzstate, 0)
                        .Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
                else
                    conta___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //conta___pessoname____Conds = Pesso.AddEPH<CSGenioApesso>(ref UserContext.Current.User, conta___pessoname____Conds, "LED_CONTA___PESSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
                ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(false, conta___pessoname____Conds, fields, offset, numberItems, sorts, "LED_CONTA___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePessoName.Query = query;
                TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(r, true, _fieldsToSerialize_CONTA___PESSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
                if(!isSearchRequest)
                    FillDependant_ContaTablePessoName();

                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pesso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ContaTablePessoName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_ContaTablePessoName(bool lazyLoad = false)
        {
            var row = GetDependant_ContaTablePessoName(this.ValCodpesso, Navigation);
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


        private readonly string[] _fieldsToSerialize_CONTA___PESSONAME____ = { "Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName" };

        /// <summary>
        /// TableGenreGender -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Conta___genregender__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool conta___genregender__DoLoad = true;
            CriteriaSet conta___genregender__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("genre", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    conta___genregender__Conds.Equal(CSGenioAgenre.FldCodgenre, Navigation.GetValue("genre"));
                    this.ValCodgenre = Navigation.GetStrValue("genre");
                }
            }



            TableGenreGender = new TableDBEdit<Models.Genre>();
            TableGenreGender.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
                    this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}
                FillDependant_ContaTableGenreGender(lazyLoad);
                //Check if foreignkey comes from history
                TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
                return;
            }


            if (conta___genregender__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableGenreGender, "sTableGenreGender", "dTableGenreGender", qs, "genre");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgenre.FldGender), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableGenreGender_tableFilters"]))
                    TableGenreGender.TableFilters = bool.Parse(qs["TableGenreGender_tableFilters"]);
                else
                    TableGenreGender.TableFilters = false;

                query = qs["qTableGenreGender"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAgenre.FldGender, query + "%");
                }
                conta___genregender__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableGenreGender"] != null ? qs["pTableGenreGender"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender, CSGenioAgenre.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_GENREGENDER]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("genre", FormMode.New) || Navigation.checkFormMode("genre", FormMode.Duplicate))
                    conta___genregender__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAgenre.FldZzstate, 0)
                        .Equal(CSGenioAgenre.FldCodgenre, Navigation.GetStrValue("genre")));
                else
                    conta___genregender__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgenre.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //conta___genregender__Conds = Genre.AddEPH<CSGenioAgenre>(ref UserContext.Current.User, conta___genregender__Conds, "LED_CONTA___GENREGENDER__");

                FieldRef firstVisibleColumn = new FieldRef("genre", "gender");
                ListingMVC<CSGenioAgenre> listing = Models.ModelBase.Where<CSGenioAgenre>(false, conta___genregender__Conds, fields, offset, numberItems, sorts, "LED_CONTA___GENREGENDER__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableGenreGender.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableGenreGender.Query = query;
                TableGenreGender.Elements = listing.RowsForViewModel<GenioMVC.Models.Genre>((r) => new GenioMVC.Models.Genre(r, true, _fieldsToSerialize_CONTA___GENREGENDER__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}

				TableGenreGender.List = new SelectList(TableGenreGender.Elements.ToSelectList(x => x.ValGender, x => x.ValCodgenre,  x => x.ValCodgenre == this.ValCodgenre), "Value", "Text", this.ValCodgenre);
                if(!isSearchRequest)
                    FillDependant_ContaTableGenreGender();

                //Check if foreignkey comes from history
                TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableGenreGender (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Genre</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ContaTableGenreGender(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "genre.codgenre", "genre.gender" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender };
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
            CSGenioAgenre tempArea = new CSGenioAgenre(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAgenre.FldCodgenre, PKey));
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
        /// Fill Dependant fields values -> TableGenreGender (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ContaTableGenreGender(bool lazyLoad = false)
        {
            var row = GetDependant_ContaTableGenreGender(this.ValCodgenre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodgenre = ViewModelConversion.ToString(row["genre.codgenre"]);
                TableGenreGender.Value = ViewModelConversion.ToString(row["genre.gender"]);
                if (GlobalFunctions.emptyG(this.ValCodgenre) == 1)
                {
                    this.ValCodgenre = "";
                    TableGenreGender.Value = "";
                    Navigation.ClearValue("genre");
                }
                else if (lazyLoad)
                {
                    TableGenreGender.SetPagination(1, 0, false, false, 1);
                    TableGenreGender.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodgenre),
                            Text = Convert.ToString(TableGenreGender.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodgenre);
                }
                TableGenreGender.Selected = this.ValCodgenre;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGenreGender): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_CONTA___GENREGENDER__ = { "Genre", "Genre.ValCodgenre", "Genre.ValZzstate", "Genre.ValGender" };

        /// <summary>
        /// TableTpconTipocont -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Conta___tpcontipocont(NameValueCollection qs, bool lazyLoad = false)
        {
            bool conta___tpcontipocontDoLoad = true;
            CriteriaSet conta___tpcontipocontConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpcon", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    conta___tpcontipocontConds.Equal(CSGenioAtpcon.FldCodtpcon, Navigation.GetValue("tpcon"));
                    this.ValCodtpcon = Navigation.GetStrValue("tpcon");
                }
            }

			// Limits Generation

			// Area limit
			conta___tpcontipocontDoLoad &= AddCriteriaAreaLimit(conta___tpcontipocontConds, CSGenio.business.CSGenioAgenre.FldCodgenre, "genre", this.ValCodgenre, true);


            TableTpconTipocont = new TableDBEdit<Models.Tpcon>();
            TableTpconTipocont.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpcon") != null)
				{
                    this.ValCodtpcon = Navigation.GetStrValue("RETURN_tpcon");
					Navigation.CurrentLevel.SetEntry("RETURN_tpcon", null);
				}
                FillDependant_ContaTableTpconTipocont(lazyLoad);
                //Check if foreignkey comes from history
                TableTpconTipocont.FilledByHistory = Navigation.CheckFilledByHistory("tpcon");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodgenre))
                conta___tpcontipocontDoLoad = false;

            if (conta___tpcontipocontDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpconTipocont, "sTableTpconTipocont", "dTableTpconTipocont", qs, "tpcon");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpcon.FldTipocont), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpconTipocont_tableFilters"]))
                    TableTpconTipocont.TableFilters = bool.Parse(qs["TableTpconTipocont_tableFilters"]);
                else
                    TableTpconTipocont.TableFilters = false;

                query = qs["qTableTpconTipocont"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAtpcon.FldTipocont, query + "%");
                }
                conta___tpcontipocontConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpconTipocont"] != null ? qs["pTableTpconTipocont"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont, CSGenioAtpcon.FldZzstate };

// USE /[MANUAL GQT OVERRQ CONTA_TPCONTIPOCONT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpcon", FormMode.New) || Navigation.checkFormMode("tpcon", FormMode.Duplicate))
                    conta___tpcontipocontConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpcon.FldZzstate, 0)
                        .Equal(CSGenioAtpcon.FldCodtpcon, Navigation.GetStrValue("tpcon")));
                else
                    conta___tpcontipocontConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpcon.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //conta___tpcontipocontConds = Tpcon.AddEPH<CSGenioAtpcon>(ref UserContext.Current.User, conta___tpcontipocontConds, "LED_CONTA___TPCONTIPOCONT");

                FieldRef firstVisibleColumn = new FieldRef("tpcon", "tipocont");
                ListingMVC<CSGenioAtpcon> listing = Models.ModelBase.Where<CSGenioAtpcon>(false, conta___tpcontipocontConds, fields, offset, numberItems, sorts, "LED_CONTA___TPCONTIPOCONT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpconTipocont.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpconTipocont.Query = query;
                TableTpconTipocont.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpcon>((r) => new GenioMVC.Models.Tpcon(r, true, _fieldsToSerialize_CONTA___TPCONTIPOCONT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpcon") != null)
				{
					this.ValCodtpcon = Navigation.GetStrValue("RETURN_tpcon");
					Navigation.CurrentLevel.SetEntry("RETURN_tpcon", null);
				}

				TableTpconTipocont.List = new SelectList(TableTpconTipocont.Elements.ToSelectList(x => x.ValTipocont, x => x.ValCodtpcon,  x => x.ValCodtpcon == this.ValCodtpcon), "Value", "Text", this.ValCodtpcon);
                if(!isSearchRequest)
                    FillDependant_ContaTableTpconTipocont();

                //Check if foreignkey comes from history
                TableTpconTipocont.FilledByHistory = Navigation.CheckFilledByHistory("tpcon");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpconTipocont (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpcon</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ContaTableTpconTipocont(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpcon.codtpcon", "tpcon.tipocont" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("genre");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAtpcon.FldCodgenre, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAtpcon tempArea = new CSGenioAtpcon(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpcon.FldCodtpcon, PKey));
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
        /// Fill Dependant fields values -> TableTpconTipocont (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ContaTableTpconTipocont(bool lazyLoad = false)
        {
            var row = GetDependant_ContaTableTpconTipocont(this.ValCodtpcon, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpcon = ViewModelConversion.ToString(row["tpcon.codtpcon"]);
                TableTpconTipocont.Value = ViewModelConversion.ToString(row["tpcon.tipocont"]);
                if (GlobalFunctions.emptyG(this.ValCodtpcon) == 1)
                {
                    this.ValCodtpcon = "";
                    TableTpconTipocont.Value = "";
                    Navigation.ClearValue("tpcon");
                }
                else if (lazyLoad)
                {
                    TableTpconTipocont.SetPagination(1, 0, false, false, 1);
                    TableTpconTipocont.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpcon),
                            Text = Convert.ToString(TableTpconTipocont.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpcon);
                }
                TableTpconTipocont.Selected = this.ValCodtpcon;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpconTipocont): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_CONTA___TPCONTIPOCONT = { "Tpcon", "Tpcon.ValCodtpcon", "Tpcon.ValZzstate", "Tpcon.ValTipocont" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CONTA]/
		#endregion
	}
}
