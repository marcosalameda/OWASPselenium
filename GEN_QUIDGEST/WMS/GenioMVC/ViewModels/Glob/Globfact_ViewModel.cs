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

namespace GenioMVC.ViewModels.Glob
{
	public class Globfact_ViewModel : FormViewModel<Models.Glob>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Facility type" Tipo:"C"</summary>
		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Facty>  TableFactyType { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		public string ValCodfacty { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Home text" Tipo: "MO"</summary>
		[AllowHtml]
		public string ValHome { get; set; }
		#endregion

		public string ValCodglob { get; set; }

		public Globfact_ViewModel() : base("FGLOBFACT") { }

		public Globfact_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FGLOBFACT", currentNavigation, nestedForm) { }

		public Globfact_ViewModel(Models.Glob row, NavigationContext currentNavigation, bool nestedForm = false) : base("FGLOBFACT", row, currentNavigation, nestedForm) { }

		public Globfact_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("glob", id);
			Model = Models.Glob.Find(id, "FGLOBFACT", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Glob model = new Models.Glob() { Identifier = "FGLOBFACT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Glob model)
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

		public static StatusMessage DeleteConditions(Models.Glob model)
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

		public static StatusMessage ViewConditions(Models.Glob model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Glob model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Globfact) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
 				ValHome = ViewModelConversion.ToString(m.ValHome);
 				ValCodglob = ViewModelConversion.ToString(m.ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Globfact) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Globfact) to Model (Glob) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValHome = ViewModelConversion.ToString(ValHome);
				m.ValCodglob = ViewModelConversion.ToString(ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Globfact) to Model (Glob) - Error during mapping");
				throw;
			}
		}

		#endregion

		public void LoadGlob()
		{
			LoadGlob(new NameValueCollection(), false, false);
		}

		public override void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false)
		{
			this.editable = editable;

			Model = Models.Glob.GetGlob(true);

			if (Model == null)
				throw new ModelNotFoundException("Model not found");

			InitModel(qs);
		}


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FGLOBFACT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Glob() { Identifier = "FGLOBFACT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
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

			Model.Identifier = "FGLOBFACT";
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

		protected override void LoadDocumentsProperties(Models.Glob row)
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
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FGLOBFACT");
				if (Model == null)
				{
					Model = new Models.Glob() { Identifier = "FGLOBFACT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Globfactfactytype____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GLOBFACT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GLOBFACT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GLOBFACT]/
		public override void Save()
		{

			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FGLOBFACT"); }
			finally { if (Model == null) Model = new Models.Glob() { Identifier = "FGLOBFACT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GLOBFACT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FGLOBFACT"); }
			finally { if (Model == null) Model = new Models.Glob() { Identifier = "FGLOBFACT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GLOBFACT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GLOBFACT]/
		public override void Destroy(string id)
		{
			Model = Models.Glob.Find(id, "FGLOBFACT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableFactyType -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Globfactfactytype____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool globfactfactytype____DoLoad = true;
            CriteriaSet globfactfactytype____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("facty", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    globfactfactytype____Conds.Equal(CSGenioAfacty.FldCodfacty, Navigation.GetValue("facty"));
                    this.ValCodfacty = Navigation.GetStrValue("facty");
                }
            }



            TableFactyType = new TableDBEdit<Models.Facty>();
            TableFactyType.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
                    this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}
                FillDependant_GlobfactTableFactyType(lazyLoad);
                //Check if foreignkey comes from history
                TableFactyType.FilledByHistory = Navigation.CheckFilledByHistory("facty");
                return;
            }


            if (globfactfactytype____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFactyType, "sTableFactyType", "dTableFactyType", qs, "facty");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFactyType_tableFilters"]))
                    TableFactyType.TableFilters = bool.Parse(qs["TableFactyType_tableFilters"]);
                else
                    TableFactyType.TableFilters = false;

                query = qs["qTableFactyType"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfacty.FldType, query + "%");
                }
                globfactfactytype____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFactyType"] != null ? qs["pTableFactyType"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType, CSGenioAfacty.FldZzstate };

// USE /[MANUAL GQT OVERRQ GLOBFACT_FACTYTYPE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("facty", FormMode.New) || Navigation.checkFormMode("facty", FormMode.Duplicate))
                    globfactfactytype____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfacty.FldZzstate, 0)
                        .Equal(CSGenioAfacty.FldCodfacty, Navigation.GetStrValue("facty")));
                else
                    globfactfactytype____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacty.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //globfactfactytype____Conds = Facty.AddEPH<CSGenioAfacty>(ref UserContext.Current.User, globfactfactytype____Conds, "LED_GLOBFACTFACTYTYPE____");

                FieldRef firstVisibleColumn = new FieldRef("facty", "type");
                ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(false, globfactfactytype____Conds, fields, offset, numberItems, sorts, "LED_GLOBFACTFACTYTYPE____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFactyType.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFactyType.Query = query;
                TableFactyType.Elements = listing.RowsForViewModel<GenioMVC.Models.Facty>((r) => new GenioMVC.Models.Facty(r, true, _fieldsToSerialize_GLOBFACTFACTYTYPE____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}

				TableFactyType.List = new SelectList(TableFactyType.Elements.ToSelectList(x => x.ValType, x => x.ValCodfacty,  x => x.ValCodfacty == this.ValCodfacty), "Value", "Text", this.ValCodfacty);
                FillDependant_GlobfactTableFactyType();

                //Check if foreignkey comes from history
                TableFactyType.FilledByHistory = Navigation.CheckFilledByHistory("facty");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFactyType (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Facty</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_GlobfactTableFactyType(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "facty.codfacty", "facty.type" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType };
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
            CSGenioAfacty tempArea = new CSGenioAfacty(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfacty.FldCodfacty, PKey));
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
        /// Fill Dependant fields values -> TableFactyType (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_GlobfactTableFactyType(bool lazyLoad = false)
        {
            var row = GetDependant_GlobfactTableFactyType(this.ValCodfacty, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodfacty = ViewModelConversion.ToString(row["facty.codfacty"]);
                TableFactyType.Value = ViewModelConversion.ToString(row["facty.type"]);
                if (GlobalFunctions.emptyG(this.ValCodfacty) == 1)
                {
                    this.ValCodfacty = "";
                    TableFactyType.Value = "";
                    Navigation.ClearValue("facty");
                }
                else if (lazyLoad)
                {
                    TableFactyType.SetPagination(1, 0, false, false, 1);
                    TableFactyType.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodfacty),
                            Text = Convert.ToString(TableFactyType.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodfacty);
                }
                TableFactyType.Selected = this.ValCodfacty;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFactyType): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_GLOBFACTFACTYTYPE____ = { "Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GLOBFACT]/
		#endregion
	}
}
