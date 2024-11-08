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

namespace GenioMVC.ViewModels.Agreg
{
	public class Agreg_ViewModel : FormViewModel<Models.Agreg>
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
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "PROJECT37121", ResourceType = typeof(Resources.Resources))]
		public string ValCodproje { get; set; }

		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		public string ValCodyear { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodaggre { get; set; }

		public Agreg_ViewModel() : base("FAGREG") { }

		public Agreg_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FAGREG", currentNavigation, nestedForm) { }

		public Agreg_ViewModel(Models.Agreg row, NavigationContext currentNavigation, bool nestedForm = false) : base("FAGREG", row, currentNavigation, nestedForm) { }

		public Agreg_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("agreg", id);
			Model = Models.Agreg.Find(id, "FAGREG", fieldsToQuery: fieldsToLoad);
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
			Models.Agreg model = new Models.Agreg() { Identifier = "FAGREG" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Agreg model)
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

		public static StatusMessage DeleteConditions(Models.Agreg model)
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

		public static StatusMessage ViewConditions(Models.Agreg model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Agreg model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Agreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Agreg) to ViewModel (Agreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
 				ValCodproje = ViewModelConversion.ToString(m.ValCodproje);
 				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
 				ValCodaggre = ViewModelConversion.ToString(m.ValCodaggre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Agreg) to ViewModel (Agreg) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Agreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Agreg) to Model (Agreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCodproje = ViewModelConversion.ToString(ValCodproje);
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
				m.ValCodaggre = ViewModelConversion.ToString(ValCodaggre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Agreg) to Model (Agreg) - Error during mapping");
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
				Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), "FAGREG");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Agreg() { Identifier = "FAGREG" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("agreg");
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

			Model.Identifier = "FAGREG";
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

		protected override void LoadDocumentsProperties(Models.Agreg row)
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
				Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), "FAGREG");
				if (Model == null)
				{
					Model = new Models.Agreg() { Identifier = "FAGREG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("agreg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Agreg___projeprojecto(qs, lazyLoad);
			Load_Agreg___year_year____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL AGREG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW AGREG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE AGREG]/
		public override void Save()
		{

			try { Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), "FAGREG"); }
			finally { if (Model == null) Model = new Models.Agreg() { Identifier = "FAGREG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY AGREG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), "FAGREG"); }
			finally { if (Model == null) Model = new Models.Agreg() { Identifier = "FAGREG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE AGREG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY AGREG]/
		public override void Destroy(string id)
		{
			Model = Models.Agreg.Find(id, "FAGREG");
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
        public void Load_Agreg___projeprojecto(NameValueCollection qs, bool lazyLoad = false)
        {
            bool agreg___projeprojectoDoLoad = true;
            CriteriaSet agreg___projeprojectoConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("proje", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    agreg___projeprojectoConds.Equal(CSGenioAproje.FldCodproje, Navigation.GetValue("proje"));
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
                FillDependant_AgregTableProjeProjecto(lazyLoad);
                //Check if foreignkey comes from history
                TableProjeProjecto.FilledByHistory = Navigation.CheckFilledByHistory("proje");
                return;
            }


            if (agreg___projeprojectoDoLoad)
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
                agreg___projeprojectoConds.SubSet(search_filters);


                string tryParsePage = qs["pTableProjeProjecto"] != null ? qs["pTableProjeProjecto"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto, CSGenioAproje.FldZzstate };

// USE /[MANUAL GQT OVERRQ AGREG_PROJEPROJECTO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("proje", FormMode.New) || Navigation.checkFormMode("proje", FormMode.Duplicate))
                    agreg___projeprojectoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAproje.FldZzstate, 0)
                        .Equal(CSGenioAproje.FldCodproje, Navigation.GetStrValue("proje")));
                else
                    agreg___projeprojectoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAproje.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //agreg___projeprojectoConds = Proje.AddEPH<CSGenioAproje>(ref UserContext.Current.User, agreg___projeprojectoConds, "LED_AGREG___PROJEPROJECTO");

                FieldRef firstVisibleColumn = new FieldRef("proje", "projecto");
                ListingMVC<CSGenioAproje> listing = Models.ModelBase.Where<CSGenioAproje>(false, agreg___projeprojectoConds, fields, offset, numberItems, sorts, "LED_AGREG___PROJEPROJECTO", true, false, firstVisibleColumn: firstVisibleColumn);

                TableProjeProjecto.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableProjeProjecto.Query = query;
                TableProjeProjecto.Elements = listing.RowsForViewModel<GenioMVC.Models.Proje>((r) => new GenioMVC.Models.Proje(r, true, _fieldsToSerialize_AGREG___PROJEPROJECTO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_proje") != null)
				{
					this.ValCodproje = Navigation.GetStrValue("RETURN_proje");
					Navigation.CurrentLevel.SetEntry("RETURN_proje", null);
				}

				TableProjeProjecto.List = new SelectList(TableProjeProjecto.Elements.ToSelectList(x => x.ValProjecto, x => x.ValCodproje,  x => x.ValCodproje == this.ValCodproje), "Value", "Text", this.ValCodproje);
                FillDependant_AgregTableProjeProjecto();

                //Check if foreignkey comes from history
                TableProjeProjecto.FilledByHistory = Navigation.CheckFilledByHistory("proje");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableProjeProjecto (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Proje</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AgregTableProjeProjecto(string PKey, NavigationContext Navigation)
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
        public void FillDependant_AgregTableProjeProjecto(bool lazyLoad = false)
        {
            var row = GetDependant_AgregTableProjeProjecto(this.ValCodproje, Navigation);
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


        private readonly string[] _fieldsToSerialize_AGREG___PROJEPROJECTO = { "Proje", "Proje.ValCodproje", "Proje.ValZzstate", "Proje.ValProjecto" };

        /// <summary>
        /// TableYearYear -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Agreg___year_year____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool agreg___year_year____DoLoad = true;
            CriteriaSet agreg___year_year____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("year", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    agreg___year_year____Conds.Equal(CSGenioAyear.FldCodyear, Navigation.GetValue("year"));
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
                FillDependant_AgregTableYearYear(lazyLoad);
                //Check if foreignkey comes from history
                TableYearYear.FilledByHistory = Navigation.CheckFilledByHistory("year");
                return;
            }


            if (agreg___year_year____DoLoad)
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
                agreg___year_year____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableYearYear"] != null ? qs["pTableYearYear"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAyear.FldZzstate };

// USE /[MANUAL GQT OVERRQ AGREG_YEARYEAR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("year", FormMode.New) || Navigation.checkFormMode("year", FormMode.Duplicate))
                    agreg___year_year____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAyear.FldZzstate, 0)
                        .Equal(CSGenioAyear.FldCodyear, Navigation.GetStrValue("year")));
                else
                    agreg___year_year____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAyear.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //agreg___year_year____Conds = Year.AddEPH<CSGenioAyear>(ref UserContext.Current.User, agreg___year_year____Conds, "LED_AGREG___YEAR_YEAR____");

                FieldRef firstVisibleColumn = new FieldRef("year", "year");
                ListingMVC<CSGenioAyear> listing = Models.ModelBase.Where<CSGenioAyear>(false, agreg___year_year____Conds, fields, offset, numberItems, sorts, "LED_AGREG___YEAR_YEAR____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableYearYear.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableYearYear.Query = query;
                TableYearYear.Elements = listing.RowsForViewModel<GenioMVC.Models.Year>((r) => new GenioMVC.Models.Year(r, true, _fieldsToSerialize_AGREG___YEAR_YEAR____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_year") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year");
					Navigation.CurrentLevel.SetEntry("RETURN_year", null);
				}

				TableYearYear.List = new SelectList(TableYearYear.Elements.ToSelectList(x => x.ValYear, x => x.ValCodyear,  x => x.ValCodyear == this.ValCodyear), "Value", "Text", this.ValCodyear);
                FillDependant_AgregTableYearYear();

                //Check if foreignkey comes from history
                TableYearYear.FilledByHistory = Navigation.CheckFilledByHistory("year");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableYearYear (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Year</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AgregTableYearYear(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "year.codyear", "year.year" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAyear.FldCodyear, CSGenioAyear.FldYear };
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
        public void FillDependant_AgregTableYearYear(bool lazyLoad = false)
        {
            var row = GetDependant_AgregTableYearYear(this.ValCodyear, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

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


        private readonly string[] _fieldsToSerialize_AGREG___YEAR_YEAR____ = { "Year", "Year.ValCodyear", "Year.ValZzstate", "Year.ValYear" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM AGREG]/
		#endregion
	}
}
