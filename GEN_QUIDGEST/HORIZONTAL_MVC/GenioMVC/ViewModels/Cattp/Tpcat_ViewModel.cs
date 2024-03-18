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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Cattp
{
	public class Tpcat_ViewModel : FormViewModel<Models.Cattp>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Category type" Tipo:"C"</summary>
		[Display(Name = "CATEGORY_TYPE23058", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTpcatego { get; set; }

		/// <summary>Campo : "Sub categoria" Tipo:"C"</summary>
		[Display(Name = "SUB_CATEGORIA15612", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Sbcat>  TableSbcatSubcateg { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "SUB_CATEGORIA15612", ResourceType = typeof(Resources.Resources))]
		public string ValCodsbcat { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtpcat { get; set; }

		public Tpcat_ViewModel() : base("FTPCAT") { }

		public Tpcat_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTPCAT", currentNavigation, nestedForm) { }

		public Tpcat_ViewModel(Models.Cattp row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTPCAT", row, currentNavigation, nestedForm) { }

		public Tpcat_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cattp", id);
			Model = Models.Cattp.Find(id, "FTPCAT", fieldsToQuery: fieldsToLoad);
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
			Models.Cattp model = new Models.Cattp() { Identifier = "FTPCAT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cattp model)
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

		public static StatusMessage DeleteConditions(Models.Cattp model)
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

		public static StatusMessage ViewConditions(Models.Cattp model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cattp model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cattp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cattp) to ViewModel (Tpcat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTpcatego = ViewModelConversion.ToString(m.ValTpcatego);
 				ValCodsbcat = ViewModelConversion.ToString(m.ValCodsbcat);
 				ValCodtpcat = ViewModelConversion.ToString(m.ValCodtpcat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cattp) to ViewModel (Tpcat) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cattp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcat) to Model (Cattp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTpcatego = ViewModelConversion.ToString(ValTpcatego);
				m.ValCodsbcat = ViewModelConversion.ToString(ValCodsbcat);
				m.ValCodtpcat = ViewModelConversion.ToString(ValCodtpcat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcat) to Model (Cattp) - Error during mapping");
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
				Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), "FTPCAT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cattp() { Identifier = "FTPCAT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cattp");
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

			Model.Identifier = "FTPCAT";
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

		protected override void LoadDocumentsProperties(Models.Cattp row)
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
				Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), "FTPCAT");
				if (Model == null)
				{
					Model = new Models.Cattp() { Identifier = "FTPCAT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cattp");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tpcat___sbcatsubcateg(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPCAT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPCAT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPCAT]/
		public override void Save()
		{

			try { Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), "FTPCAT"); }
			finally { if (Model == null) Model = new Models.Cattp() { Identifier = "FTPCAT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPCAT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), "FTPCAT"); }
			finally { if (Model == null) Model = new Models.Cattp() { Identifier = "FTPCAT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPCAT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPCAT]/
		public override void Destroy(string id)
		{
			Model = Models.Cattp.Find(id, "FTPCAT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableSbcatSubcateg -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tpcat___sbcatsubcateg(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tpcat___sbcatsubcategDoLoad = true;
            CriteriaSet tpcat___sbcatsubcategConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("sbcat", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tpcat___sbcatsubcategConds.Equal(CSGenioAsbcat.FldCodsbcat, Navigation.GetValue("sbcat"));
                    this.ValCodsbcat = Navigation.GetStrValue("sbcat");
                }
            }



            TableSbcatSubcateg = new TableDBEdit<Models.Sbcat>();
            TableSbcatSubcateg.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_sbcat") != null)
				{
                    this.ValCodsbcat = Navigation.GetStrValue("RETURN_sbcat");
					Navigation.CurrentLevel.SetEntry("RETURN_sbcat", null);
				}
                FillDependant_TpcatTableSbcatSubcateg(lazyLoad);
                //Check if foreignkey comes from history
                TableSbcatSubcateg.FilledByHistory = Navigation.CheckFilledByHistory("sbcat");
                return;
            }


            if (tpcat___sbcatsubcategDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableSbcatSubcateg, "sTableSbcatSubcateg", "dTableSbcatSubcateg", qs, "sbcat");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsbcat.FldSubcateg), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableSbcatSubcateg_tableFilters"]))
                    TableSbcatSubcateg.TableFilters = bool.Parse(qs["TableSbcatSubcateg_tableFilters"]);
                else
                    TableSbcatSubcateg.TableFilters = false;

                query = qs["qTableSbcatSubcateg"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAsbcat.FldSubcateg, query + "%");
                }
                tpcat___sbcatsubcategConds.SubSet(search_filters);


                string tryParsePage = qs["pTableSbcatSubcateg"] != null ? qs["pTableSbcatSubcateg"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAsbcat.FldCodsbcat, CSGenioAsbcat.FldSubcateg, CSGenioAsbcat.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPCAT_SBCATSUBCATEG]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("sbcat", FormMode.New) || Navigation.checkFormMode("sbcat", FormMode.Duplicate))
                    tpcat___sbcatsubcategConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAsbcat.FldZzstate, 0)
                        .Equal(CSGenioAsbcat.FldCodsbcat, Navigation.GetStrValue("sbcat")));
                else
                    tpcat___sbcatsubcategConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAsbcat.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tpcat___sbcatsubcategConds = Sbcat.AddEPH<CSGenioAsbcat>(ref UserContext.Current.User, tpcat___sbcatsubcategConds, "LED_TPCAT___SBCATSUBCATEG");

                FieldRef firstVisibleColumn = new FieldRef("sbcat", "subcateg");
                ListingMVC<CSGenioAsbcat> listing = Models.ModelBase.Where<CSGenioAsbcat>(false, tpcat___sbcatsubcategConds, fields, offset, numberItems, sorts, "LED_TPCAT___SBCATSUBCATEG", true, false, firstVisibleColumn: firstVisibleColumn);

                TableSbcatSubcateg.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableSbcatSubcateg.Query = query;
                TableSbcatSubcateg.Elements = listing.RowsForViewModel<GenioMVC.Models.Sbcat>((r) => new GenioMVC.Models.Sbcat(r, true, _fieldsToSerialize_TPCAT___SBCATSUBCATEG));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_sbcat") != null)
				{
					this.ValCodsbcat = Navigation.GetStrValue("RETURN_sbcat");
					Navigation.CurrentLevel.SetEntry("RETURN_sbcat", null);
				}

				TableSbcatSubcateg.List = new SelectList(TableSbcatSubcateg.Elements.ToSelectList(x => x.ValSubcateg, x => x.ValCodsbcat,  x => x.ValCodsbcat == this.ValCodsbcat), "Value", "Text", this.ValCodsbcat);
                FillDependant_TpcatTableSbcatSubcateg();

                //Check if foreignkey comes from history
                TableSbcatSubcateg.FilledByHistory = Navigation.CheckFilledByHistory("sbcat");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableSbcatSubcateg (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Sbcat</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TpcatTableSbcatSubcateg(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "sbcat.codsbcat", "sbcat.subcateg" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAsbcat.FldCodsbcat, CSGenioAsbcat.FldSubcateg };
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
            CSGenioAsbcat tempArea = new CSGenioAsbcat(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAsbcat.FldCodsbcat, PKey));
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
        /// Fill Dependant fields values -> TableSbcatSubcateg (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TpcatTableSbcatSubcateg(bool lazyLoad = false)
        {
            var row = GetDependant_TpcatTableSbcatSubcateg(this.ValCodsbcat, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodsbcat = ViewModelConversion.ToString(row["sbcat.codsbcat"]);
                TableSbcatSubcateg.Value = ViewModelConversion.ToString(row["sbcat.subcateg"]);
                if (GlobalFunctions.emptyG(this.ValCodsbcat) == 1)
                {
                    this.ValCodsbcat = "";
                    TableSbcatSubcateg.Value = "";
                    Navigation.ClearValue("sbcat");
                }
                else if (lazyLoad)
                {
                    TableSbcatSubcateg.SetPagination(1, 0, false, false, 1);
                    TableSbcatSubcateg.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodsbcat),
                            Text = Convert.ToString(TableSbcatSubcateg.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodsbcat);
                }
                TableSbcatSubcateg.Selected = this.ValCodsbcat;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSbcatSubcateg): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TPCAT___SBCATSUBCATEG = { "Sbcat", "Sbcat.ValCodsbcat", "Sbcat.ValZzstate", "Sbcat.ValSubcateg" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPCAT]/
		#endregion
	}
}
