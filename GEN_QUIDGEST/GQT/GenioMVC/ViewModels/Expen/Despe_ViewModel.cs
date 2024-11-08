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

namespace GenioMVC.ViewModels.Expen
{
	public class Despe_ViewModel : FormViewModel<Models.Expen>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Project" Tipo:"C"</summary>
		[Display(Name = "PROJECT37121", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Proje>  TableProjeProjecto { get; set; }

		/// <summary>Campo : "Year" Tipo:"C"</summary>
		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Year>  TableYearYear { get; set; }

		/// <summary>Campo : "Value" Tipo:"$D"</summary>
		[Display(Name = "VALUE10285", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Agreg>  TableAgregValue { get; set; }

		/// <summary>Campo : "Description" Tipo:"C"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDescript { get; set; }

		/// <summary>Campo : "Value" Tipo:"$D"</summary>
		[Display(Name = "VALUE10285", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get; set; }

		/// <summary>Campo : "Previous Value" Tipo:"$D"</summary>
		[Display(Name = "PREVIOUS_VALUE30042", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrevval { get; set; }

		/// <summary>Campo : "Previous Year" Tipo:"N"</summary>
		[Display(Name = "PREVIOUS_YEAR22440", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYearprev { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "VALUE10285", ResourceType = typeof(Resources.Resources))]
		public string ValCodaggre { get; set; }

		[Display(Name = "PROJECT37121", ResourceType = typeof(Resources.Resources))]
		public string ValCodproje { get; set; }

		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		public string ValCodyear { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Used only for lazy loading of the YearValYearnum field</summary>
		[Newtonsoft.Json.JsonIgnore]
		public Func<decimal?> funcYearValYearnum { get; set; }
		private decimal? _auxYearValYearnum { get; set; }
		/// <summary>Field : "Year (numbers)" Tipo: "N"</summary>
		public decimal? YearValYearnum { get { return funcYearValYearnum != null ? funcYearValYearnum() : _auxYearValYearnum; } set { funcYearValYearnum = () => value;} }
		#endregion

		public string ValCoddespe { get; set; }

		public Despe_ViewModel() : base("FDESPE") { }

		public Despe_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDESPE", currentNavigation, nestedForm) { }

		public Despe_ViewModel(Models.Expen row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDESPE", row, currentNavigation, nestedForm) { }

		public Despe_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("expen", id);
			Model = Models.Expen.Find(id, "FDESPE", fieldsToQuery: fieldsToLoad);
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
			Models.Expen model = new Models.Expen() { Identifier = "FDESPE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Expen model)
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

		public static StatusMessage DeleteConditions(Models.Expen model)
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

		public static StatusMessage ViewConditions(Models.Expen model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Expen model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Expen m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Expen) to ViewModel (Despe) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
 				ValPrevval = ViewModelConversion.ToNumeric(m.ValPrevval);
 				ValYearprev = ViewModelConversion.ToNumeric(m.ValYearprev);
 				ValCodaggre = ViewModelConversion.ToString(m.ValCodaggre);
 				ValCodproje = ViewModelConversion.ToString(m.ValCodproje);
 				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
 				funcYearValYearnum = () => ViewModelConversion.ToNumeric(m.Year.ValYearnum);
 				ValCoddespe = ViewModelConversion.ToString(m.ValCoddespe);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Expen) to ViewModel (Despe) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Expen m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Despe) to Model (Expen) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValPrevval = ViewModelConversion.ToNumeric(ValPrevval);
				m.ValYearprev = ViewModelConversion.ToNumeric(ValYearprev);
				m.ValCodaggre = ViewModelConversion.ToString(ValCodaggre);
				m.ValCodproje = ViewModelConversion.ToString(ValCodproje);
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
				m.ValCoddespe = ViewModelConversion.ToString(ValCoddespe);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Despe) to Model (Expen) - Error during mapping");
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
				Model = Models.Expen.Find(Navigation.GetStrValue("expen"), "FDESPE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Expen() { Identifier = "FDESPE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("expen");
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

			Model.Identifier = "FDESPE";
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

		protected override void LoadDocumentsProperties(Models.Expen row)
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
				Model = Models.Expen.Find(Navigation.GetStrValue("expen"), "FDESPE");
				if (Model == null)
				{
					Model = new Models.Expen() { Identifier = "FDESPE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("expen");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Despe___projeprojecto(qs, lazyLoad);
			Load_Despe___year_year____(qs, lazyLoad);
			Load_Despe___agregvalue___(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DESPE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DESPE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DESPE]/
		public override void Save()
		{

			try { Model = Models.Expen.Find(Navigation.GetStrValue("expen"), "FDESPE"); }
			finally { if (Model == null) Model = new Models.Expen() { Identifier = "FDESPE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DESPE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Expen.Find(Navigation.GetStrValue("expen"), "FDESPE"); }
			finally { if (Model == null) Model = new Models.Expen() { Identifier = "FDESPE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DESPE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DESPE]/
		public override void Destroy(string id)
		{
			Model = Models.Expen.Find(id, "FDESPE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableProjeProjecto -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Despe___projeprojecto(NameValueCollection qs, bool lazyLoad = false)
        {
            bool despe___projeprojectoDoLoad = true;
            CriteriaSet despe___projeprojectoConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("proje", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    despe___projeprojectoConds.Equal(CSGenioAproje.FldCodproje, Navigation.GetValue("proje"));
                    this.ValCodproje = Navigation.GetStrValue("proje");
                }
            }



            TableProjeProjecto = new TableDBEdit<Models.Proje>();
            TableProjeProjecto.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_proje") != null)
				{
                    this.ValCodproje = Navigation.GetStrValue("RETURN_proje");
					Navigation.CurrentLevel.SetEntry("RETURN_proje", null);
				}
                FillDependant_DespeTableProjeProjecto(lazyLoad);
                //Check if foreignkey comes from history
                TableProjeProjecto.FilledByHistory = Navigation.CheckFilledByHistory("proje");
                return;
            }


            if (despe___projeprojectoDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableProjeProjecto, "sTableProjeProjecto", "dTableProjeProjecto", qs, "proje");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAproje.FldProjecto), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableProjeProjecto_tableFilters"]))
                    TableProjeProjecto.TableFilters = bool.Parse(qs["TableProjeProjecto_tableFilters"]);
                else
                    TableProjeProjecto.TableFilters = false;

                query = qs["qTableProjeProjecto"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAproje.FldProjecto, query + "%");
                }
                despe___projeprojectoConds.SubSet(search_filters);


                string tryParsePage = qs["pTableProjeProjecto"] != null ? qs["pTableProjeProjecto"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto, CSGenioAproje.FldZzstate };

// USE /[MANUAL GQT OVERRQ DESPE_PROJEPROJECTO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("proje", FormMode.New) || Navigation.checkFormMode("proje", FormMode.Duplicate))
                    despe___projeprojectoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAproje.FldZzstate, 0)
                        .Equal(CSGenioAproje.FldCodproje, Navigation.GetStrValue("proje")));
                else
                    despe___projeprojectoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAproje.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //despe___projeprojectoConds = Proje.AddEPH<CSGenioAproje>(ref UserContext.Current.User, despe___projeprojectoConds, "LED_DESPE___PROJEPROJECTO");

                FieldRef firstVisibleColumn = new FieldRef("proje", "projecto");
                ListingMVC<CSGenioAproje> listing = Models.ModelBase.Where<CSGenioAproje>(false, despe___projeprojectoConds, fields, offset, numberItems, sorts, "LED_DESPE___PROJEPROJECTO", true, false, firstVisibleColumn: firstVisibleColumn);

                TableProjeProjecto.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableProjeProjecto.Query = query;
                TableProjeProjecto.Elements = listing.RowsForViewModel<GenioMVC.Models.Proje>((r) => new GenioMVC.Models.Proje(r, true, _fieldsToSerialize_DESPE___PROJEPROJECTO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_proje") != null)
				{
					this.ValCodproje = Navigation.GetStrValue("RETURN_proje");
					Navigation.CurrentLevel.SetEntry("RETURN_proje", null);
				}

				TableProjeProjecto.List = new SelectList(TableProjeProjecto.Elements.ToSelectList(x => x.ValProjecto, x => x.ValCodproje,  x => x.ValCodproje == this.ValCodproje), "Value", "Text", this.ValCodproje);
                FillDependant_DespeTableProjeProjecto();

                //Check if foreignkey comes from history
                TableProjeProjecto.FilledByHistory = Navigation.CheckFilledByHistory("proje");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableProjeProjecto (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Proje</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DespeTableProjeProjecto(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "proje.codproje", "proje.projecto" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto };
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
            CSGenioAproje tempArea = new CSGenioAproje(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAproje.FldCodproje, PKey));
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
        /// Fill Dependant fields values -> TableProjeProjecto (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DespeTableProjeProjecto(bool lazyLoad = false)
        {
            var row = GetDependant_DespeTableProjeProjecto(this.ValCodproje, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodproje = ViewModelConversion.ToString(row["proje.codproje"]);
                TableProjeProjecto.Value = ViewModelConversion.ToString(row["proje.projecto"]);
                if (GlobalFunctions.emptyG(this.ValCodproje) == 1)
                {
                    this.ValCodproje = "";
                    TableProjeProjecto.Value = "";
                    Navigation.ClearValue("proje");
                }
                else if (lazyLoad)
                {
                    TableProjeProjecto.SetPagination(1, 0, false, false, 1);
                    TableProjeProjecto.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodproje),
                            Text = Convert.ToString(TableProjeProjecto.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodproje);
                }
                TableProjeProjecto.Selected = this.ValCodproje;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableProjeProjecto): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DESPE___PROJEPROJECTO = { "Proje", "Proje.ValCodproje", "Proje.ValZzstate", "Proje.ValProjecto" };

        /// <summary>
        /// TableYearYear -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Despe___year_year____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool despe___year_year____DoLoad = true;
            CriteriaSet despe___year_year____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("year", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    despe___year_year____Conds.Equal(CSGenioAyear.FldCodyear, Navigation.GetValue("year"));
                    this.ValCodyear = Navigation.GetStrValue("year");
                }
            }



            TableYearYear = new TableDBEdit<Models.Year>();
            TableYearYear.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_year") != null)
				{
                    this.ValCodyear = Navigation.GetStrValue("RETURN_year");
					Navigation.CurrentLevel.SetEntry("RETURN_year", null);
				}
                FillDependant_DespeTableYearYear(lazyLoad);
                //Check if foreignkey comes from history
                TableYearYear.FilledByHistory = Navigation.CheckFilledByHistory("year");
                return;
            }


            if (despe___year_year____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableYearYear, "sTableYearYear", "dTableYearYear", qs, "year");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAyear.FldYear), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableYearYear_tableFilters"]))
                    TableYearYear.TableFilters = bool.Parse(qs["TableYearYear_tableFilters"]);
                else
                    TableYearYear.TableFilters = false;

                query = qs["qTableYearYear"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAyear.FldYear, query + "%");
                }
                despe___year_year____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableYearYear"] != null ? qs["pTableYearYear"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAyear.FldZzstate };

// USE /[MANUAL GQT OVERRQ DESPE_YEARYEAR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("year", FormMode.New) || Navigation.checkFormMode("year", FormMode.Duplicate))
                    despe___year_year____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAyear.FldZzstate, 0)
                        .Equal(CSGenioAyear.FldCodyear, Navigation.GetStrValue("year")));
                else
                    despe___year_year____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAyear.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //despe___year_year____Conds = Year.AddEPH<CSGenioAyear>(ref UserContext.Current.User, despe___year_year____Conds, "LED_DESPE___YEAR_YEAR____");

                FieldRef firstVisibleColumn = new FieldRef("year", "year");
                ListingMVC<CSGenioAyear> listing = Models.ModelBase.Where<CSGenioAyear>(false, despe___year_year____Conds, fields, offset, numberItems, sorts, "LED_DESPE___YEAR_YEAR____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableYearYear.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableYearYear.Query = query;
                TableYearYear.Elements = listing.RowsForViewModel<GenioMVC.Models.Year>((r) => new GenioMVC.Models.Year(r, true, _fieldsToSerialize_DESPE___YEAR_YEAR____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_year") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year");
					Navigation.CurrentLevel.SetEntry("RETURN_year", null);
				}

				TableYearYear.List = new SelectList(TableYearYear.Elements.ToSelectList(x => x.ValYear, x => x.ValCodyear,  x => x.ValCodyear == this.ValCodyear), "Value", "Text", this.ValCodyear);
                FillDependant_DespeTableYearYear();

                //Check if foreignkey comes from history
                TableYearYear.FilledByHistory = Navigation.CheckFilledByHistory("year");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableYearYear (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Year</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DespeTableYearYear(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "year.codyear", "year.year", "year.yearnum" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAyear.FldYearnum };
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
            CSGenioAyear tempArea = new CSGenioAyear(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAyear.FldCodyear, PKey));
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
        /// Fill Dependant fields values -> TableYearYear (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DespeTableYearYear(bool lazyLoad = false)
        {
            var row = GetDependant_DespeTableYearYear(this.ValCodyear, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["year.yearnum"]);
                    this.funcYearValYearnum = () => tempValue;
                }

                // Fill List fields
                this.ValCodyear = ViewModelConversion.ToString(row["year.codyear"]);
                TableYearYear.Value = ViewModelConversion.ToString(row["year.year"]);
                if (GlobalFunctions.emptyG(this.ValCodyear) == 1)
                {
                    this.ValCodyear = "";
                    TableYearYear.Value = "";
                    Navigation.ClearValue("year");
                }
                else if (lazyLoad)
                {
                    TableYearYear.SetPagination(1, 0, false, false, 1);
                    TableYearYear.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodyear),
                            Text = Convert.ToString(TableYearYear.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodyear);
                }
                TableYearYear.Selected = this.ValCodyear;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableYearYear): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DESPE___YEAR_YEAR____ = { "Year", "Year.ValCodyear", "Year.ValZzstate", "Year.ValYear" };

        /// <summary>
        /// TableAgregValue -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Despe___agregvalue___(NameValueCollection qs, bool lazyLoad = false)
        {
            bool despe___agregvalue___DoLoad = true;
            CriteriaSet despe___agregvalue___Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("agreg", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    despe___agregvalue___Conds.Equal(CSGenioAagreg.FldCodaggre, Navigation.GetValue("agreg"));
                    this.ValCodaggre = Navigation.GetStrValue("agreg");
                }
            }

			// Limits Generation

			// Area limit
			despe___agregvalue___DoLoad &= AddCriteriaAreaLimit(despe___agregvalue___Conds, CSGenio.business.CSGenioAyear.FldCodyear, "year", this.ValCodyear, true);

			// Area limit
			despe___agregvalue___DoLoad &= AddCriteriaAreaLimit(despe___agregvalue___Conds, CSGenio.business.CSGenioAproje.FldCodproje, "proje", this.ValCodproje, true);


            TableAgregValue = new TableDBEdit<Models.Agreg>();
            TableAgregValue.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_agreg") != null)
				{
                    this.ValCodaggre = Navigation.GetStrValue("RETURN_agreg");
					Navigation.CurrentLevel.SetEntry("RETURN_agreg", null);
				}
                FillDependant_DespeTableAgregValue(lazyLoad);
                //Check if foreignkey comes from history
                TableAgregValue.FilledByHistory = Navigation.CheckFilledByHistory("agreg");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodyear))
                despe___agregvalue___DoLoad = false;
            if (String.IsNullOrEmpty(this.ValCodproje))
                despe___agregvalue___DoLoad = false;

            if (despe___agregvalue___DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableAgregValue, "sTableAgregValue", "dTableAgregValue", qs, "agreg");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAagreg.FldValue), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableAgregValue_tableFilters"]))
                    TableAgregValue.TableFilters = bool.Parse(qs["TableAgregValue_tableFilters"]);
                else
                    TableAgregValue.TableFilters = false;

                query = qs["qTableAgregValue"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAagreg.FldValue, query + "%");
                }
                despe___agregvalue___Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAgregValue"] != null ? qs["pTableAgregValue"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue, CSGenioAagreg.FldZzstate };

// USE /[MANUAL GQT OVERRQ DESPE_AGREGVALUE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("agreg", FormMode.New) || Navigation.checkFormMode("agreg", FormMode.Duplicate))
                    despe___agregvalue___Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAagreg.FldZzstate, 0)
                        .Equal(CSGenioAagreg.FldCodaggre, Navigation.GetStrValue("agreg")));
                else
                    despe___agregvalue___Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAagreg.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //despe___agregvalue___Conds = Agreg.AddEPH<CSGenioAagreg>(ref UserContext.Current.User, despe___agregvalue___Conds, "LED_DESPE___AGREGVALUE___");

                FieldRef firstVisibleColumn = new FieldRef("agreg", "value");
                ListingMVC<CSGenioAagreg> listing = Models.ModelBase.Where<CSGenioAagreg>(false, despe___agregvalue___Conds, fields, offset, numberItems, sorts, "LED_DESPE___AGREGVALUE___", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAgregValue.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAgregValue.Query = query;
                TableAgregValue.Elements = listing.RowsForViewModel<GenioMVC.Models.Agreg>((r) => new GenioMVC.Models.Agreg(r, true, _fieldsToSerialize_DESPE___AGREGVALUE___));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_agreg") != null)
				{
					this.ValCodaggre = Navigation.GetStrValue("RETURN_agreg");
					Navigation.CurrentLevel.SetEntry("RETURN_agreg", null);
				}

				TableAgregValue.List = new SelectList(TableAgregValue.Elements.ToSelectList(x => x.ValValue, x => x.ValCodaggre,  x => x.ValCodaggre == this.ValCodaggre), "Value", "Text", this.ValCodaggre);
                FillDependant_DespeTableAgregValue();

                //Check if foreignkey comes from history
                TableAgregValue.FilledByHistory = Navigation.CheckFilledByHistory("agreg");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAgregValue (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Agreg</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DespeTableAgregValue(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "agreg.codaggre", "agreg.value" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("year");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAagreg.FldCodyear, hValue);
                }
            }
            {
                object hValue = Navigation.GetValue("proje");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAagreg.FldCodproje, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAagreg tempArea = new CSGenioAagreg(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAagreg.FldCodaggre, PKey));
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
        /// Fill Dependant fields values -> TableAgregValue (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DespeTableAgregValue(bool lazyLoad = false)
        {
            var row = GetDependant_DespeTableAgregValue(this.ValCodaggre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodaggre = ViewModelConversion.ToString(row["agreg.codaggre"]);
                TableAgregValue.Value = ViewModelConversion.ToNumeric(row["agreg.value"]);
                if (GlobalFunctions.emptyG(this.ValCodaggre) == 1)
                {
                    this.ValCodaggre = "";
                    TableAgregValue.Value = 0m;
                    Navigation.ClearValue("agreg");
                }
                else if (lazyLoad)
                {
                    TableAgregValue.SetPagination(1, 0, false, false, 1);
                    TableAgregValue.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodaggre),
                            Text = Convert.ToString(TableAgregValue.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodaggre);
                }
                TableAgregValue.Selected = this.ValCodaggre;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAgregValue): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DESPE___AGREGVALUE___ = { "Agreg", "Agreg.ValCodaggre", "Agreg.ValZzstate", "Agreg.ValValue" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DESPE]/
		#endregion
	}
}
