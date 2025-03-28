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

namespace GenioMVC.ViewModels.Tpcon
{
	public class Tpcon_ViewModel : FormViewModel<Models.Tpcon>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Genre" Tipo:"C"</summary>
		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Genre>  TableGenreGender { get; set; }

		/// <summary>Campo : "Contact Type:" Tipo:"C"</summary>
		[Display(Name = "CONTACT_TYPE_27897", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTipocont { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		public string ValCodgenre { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtpcon { get; set; }

		public Tpcon_ViewModel() : base("FTPCON") { }

		public Tpcon_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTPCON", currentNavigation, nestedForm) { }

		public Tpcon_ViewModel(Models.Tpcon row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTPCON", row, currentNavigation, nestedForm) { }

		public Tpcon_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tpcon", id);
			Model = Models.Tpcon.Find(id, "FTPCON", fieldsToQuery: fieldsToLoad);
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
			Models.Tpcon model = new Models.Tpcon() { Identifier = "FTPCON" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tpcon model)
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

		public static StatusMessage DeleteConditions(Models.Tpcon model)
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

		public static StatusMessage ViewConditions(Models.Tpcon model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tpcon model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tpcon m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpcon) to ViewModel (Tpcon) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValTipocont = ViewModelConversion.ToString(m.ValTipocont);
				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
				ValCodtpcon = ViewModelConversion.ToString(m.ValCodtpcon);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tpcon) to ViewModel (Tpcon) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tpcon m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcon) to Model (Tpcon) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTipocont = ViewModelConversion.ToString(ValTipocont);
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
				m.ValCodtpcon = ViewModelConversion.ToString(ValCodtpcon);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcon) to Model (Tpcon) - Error during mapping");
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
				Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), "FTPCON");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tpcon() { Identifier = "FTPCON" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tpcon");
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

			Model.Identifier = "FTPCON";
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

		protected override void LoadDocumentsProperties(Models.Tpcon row)
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
				Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), "FTPCON");
				if (Model == null)
				{
					Model = new Models.Tpcon() { Identifier = "FTPCON" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tpcon");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tpcon___genregender__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPCON]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPCON]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPCON]/
		public override void Save()
		{

			try { Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), "FTPCON"); }
			finally { if (Model == null) Model = new Models.Tpcon() { Identifier = "FTPCON" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPCON]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), "FTPCON"); }
			finally { if (Model == null) Model = new Models.Tpcon() { Identifier = "FTPCON" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPCON]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPCON]/
		public override void Destroy(string id)
		{
			Model = Models.Tpcon.Find(id, "FTPCON");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableGenreGender -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tpcon___genregender__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tpcon___genregender__DoLoad = true;
            CriteriaSet tpcon___genregender__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("genre", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tpcon___genregender__Conds.Equal(CSGenioAgenre.FldCodgenre, Navigation.GetValue("genre"));
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
                FillDependant_TpconTableGenreGender(lazyLoad);
                //Check if foreignkey comes from history
                TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
                return;
            }


            if (tpcon___genregender__DoLoad)
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
                tpcon___genregender__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableGenreGender"] != null ? qs["pTableGenreGender"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender, CSGenioAgenre.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPCON_GENREGENDER]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("genre", FormMode.New) || Navigation.checkFormMode("genre", FormMode.Duplicate))
                    tpcon___genregender__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAgenre.FldZzstate, 0)
                        .Equal(CSGenioAgenre.FldCodgenre, Navigation.GetStrValue("genre")));
                else
                    tpcon___genregender__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgenre.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tpcon___genregender__Conds = Genre.AddEPH<CSGenioAgenre>(ref UserContext.Current.User, tpcon___genregender__Conds, "LED_TPCON___GENREGENDER__");

                FieldRef firstVisibleColumn = new FieldRef("genre", "gender");
                ListingMVC<CSGenioAgenre> listing = Models.ModelBase.Where<CSGenioAgenre>(false, tpcon___genregender__Conds, fields, offset, numberItems, sorts, "LED_TPCON___GENREGENDER__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableGenreGender.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableGenreGender.Query = query;
                TableGenreGender.Elements = listing.RowsForViewModel<GenioMVC.Models.Genre>((r) => new GenioMVC.Models.Genre(r, true, _fieldsToSerialize_TPCON___GENREGENDER__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}

				TableGenreGender.List = new SelectList(TableGenreGender.Elements.ToSelectList(x => x.ValGender, x => x.ValCodgenre,  x => x.ValCodgenre == this.ValCodgenre), "Value", "Text", this.ValCodgenre);
                if(!isSearchRequest)
                    FillDependant_TpconTableGenreGender();

                //Check if foreignkey comes from history
                TableGenreGender.FilledByHistory = Navigation.CheckFilledByHistory("genre");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableGenreGender (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Genre</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TpconTableGenreGender(string PKey, NavigationContext Navigation)
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
        public void FillDependant_TpconTableGenreGender(bool lazyLoad = false)
        {
            var row = GetDependant_TpconTableGenreGender(this.ValCodgenre, Navigation);
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


        private readonly string[] _fieldsToSerialize_TPCON___GENREGENDER__ = { "Genre", "Genre.ValCodgenre", "Genre.ValZzstate", "Genre.ValGender" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPCON]/
		#endregion
	}
}
