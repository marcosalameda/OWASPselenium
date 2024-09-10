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

namespace GenioMVC.ViewModels.Lcext
{
	public class Lcext_ViewModel : FormViewModel<Models.Lcext>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Global Location Number" Tipo:"C"</summary>
		[Display(Name = "GLOBAL_LOCATION_NUMB24637", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Locat>  TableLocatGln { get; set; }

		/// <summary>Campo : "GLN Extension Component" Tipo:"C"</summary>
		[Display(Name = "GLN_EXTENSION_COMPON55869", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGlnext { get; set; }

		/// <summary>Campo : "Space type" Tipo:"AC"</summary>
		[Display(Name = "SPACE_TYPE42493", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Spacetyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpacetyp { get; set; }
		[JsonIgnore]
		public SelectList List_ValSpacetyp { get; set; }

		/// <summary>Campo : "Space" Tipo:"C"</summary>
		[Display(Name = "SPACE62433", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValSpaceobs { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "GLOBAL_LOCATION_NUMB24637", ResourceType = typeof(Resources.Resources))]
		public string ValCodlocat { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlcext { get; set; }

		public Lcext_ViewModel() : base("FLCEXT") { }

		public Lcext_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLCEXT", currentNavigation, nestedForm) { }

		public Lcext_ViewModel(Models.Lcext row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLCEXT", row, currentNavigation, nestedForm) { }

		public Lcext_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("lcext", id);
			Model = Models.Lcext.Find(id, "FLCEXT", fieldsToQuery: fieldsToLoad);
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
			Models.Lcext model = new Models.Lcext() { Identifier = "FLCEXT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Lcext model)
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

		public static StatusMessage DeleteConditions(Models.Lcext model)
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

		public static StatusMessage ViewConditions(Models.Lcext model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Lcext model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lcext m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lcext) to ViewModel (Lcext) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValGlnext = ViewModelConversion.ToString(m.ValGlnext);
 				ValSpacetyp = ViewModelConversion.ToString(m.ValSpacetyp);
 				ValSpaceobs = ViewModelConversion.ToString(m.ValSpaceobs);
 				ValCodlocat = ViewModelConversion.ToString(m.ValCodlocat);
 				ValCodlcext = ViewModelConversion.ToString(m.ValCodlcext);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lcext) to ViewModel (Lcext) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lcext m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lcext) to Model (Lcext) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValGlnext = ViewModelConversion.ToString(ValGlnext);
				m.ValSpacetyp = ViewModelConversion.ToString(ValSpacetyp);
				m.ValSpaceobs = ViewModelConversion.ToString(ValSpaceobs);
				m.ValCodlocat = ViewModelConversion.ToString(ValCodlocat);
				m.ValCodlcext = ViewModelConversion.ToString(ValCodlcext);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lcext) to Model (Lcext) - Error during mapping");
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
				Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), "FLCEXT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Lcext() { Identifier = "FLCEXT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("lcext");
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

			Model.Identifier = "FLCEXT";
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

		protected override void LoadDocumentsProperties(Models.Lcext row)
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
				Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), "FLCEXT");
				if (Model == null)
				{
					Model = new Models.Lcext() { Identifier = "FLCEXT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lcext");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Lcext___locatgln_____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LCEXT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LCEXT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LCEXT]/
		public override void Save()
		{

			try { Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), "FLCEXT"); }
			finally { if (Model == null) Model = new Models.Lcext() { Identifier = "FLCEXT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LCEXT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), "FLCEXT"); }
			finally { if (Model == null) Model = new Models.Lcext() { Identifier = "FLCEXT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LCEXT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LCEXT]/
		public override void Destroy(string id)
		{
			Model = Models.Lcext.Find(id, "FLCEXT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValSpacetyp = new SelectList(
				ArraySpacetyp.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValSpacetyp);
		}


        /// <summary>
        /// TableLocatGln -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lcext___locatgln_____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lcext___locatgln_____DoLoad = true;
            CriteriaSet lcext___locatgln_____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("locat", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lcext___locatgln_____Conds.Equal(CSGenioAlocat.FldCodlocat, Navigation.GetValue("locat"));
                    this.ValCodlocat = Navigation.GetStrValue("locat");
                }
            }



            TableLocatGln = new TableDBEdit<Models.Locat>();
            TableLocatGln.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
                    this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}
                FillDependant_LcextTableLocatGln(lazyLoad);
                //Check if foreignkey comes from history
                TableLocatGln.FilledByHistory = Navigation.CheckFilledByHistory("locat");
                return;
            }


            if (lcext___locatgln_____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLocatGln, "sTableLocatGln", "dTableLocatGln", qs, "locat");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlocat.FldGln), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLocatGln_tableFilters"]))
                    TableLocatGln.TableFilters = bool.Parse(qs["TableLocatGln_tableFilters"]);
                else
                    TableLocatGln.TableFilters = false;

                query = qs["qTableLocatGln"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAlocat.FldGln, query + "%");
                }
                lcext___locatgln_____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLocatGln"] != null ? qs["pTableLocatGln"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAlocat.FldZzstate };

// USE /[MANUAL GQT OVERRQ LCEXT_LOCATGLN]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("locat", FormMode.New) || Navigation.checkFormMode("locat", FormMode.Duplicate))
                    lcext___locatgln_____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlocat.FldZzstate, 0)
                        .Equal(CSGenioAlocat.FldCodlocat, Navigation.GetStrValue("locat")));
                else
                    lcext___locatgln_____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlocat.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lcext___locatgln_____Conds = Locat.AddEPH<CSGenioAlocat>(ref UserContext.Current.User, lcext___locatgln_____Conds, "LED_LCEXT___LOCATGLN_____");

                FieldRef firstVisibleColumn = new FieldRef("locat", "gln");
                ListingMVC<CSGenioAlocat> listing = Models.ModelBase.Where<CSGenioAlocat>(false, lcext___locatgln_____Conds, fields, offset, numberItems, sorts, "LED_LCEXT___LOCATGLN_____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLocatGln.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLocatGln.Query = query;
                TableLocatGln.Elements = listing.RowsForViewModel<GenioMVC.Models.Locat>((r) => new GenioMVC.Models.Locat(r, true, _fieldsToSerialize_LCEXT___LOCATGLN_____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}

				TableLocatGln.List = new SelectList(TableLocatGln.Elements.ToSelectList(x => x.ValGln, x => x.ValCodlocat,  x => x.ValCodlocat == this.ValCodlocat), "Value", "Text", this.ValCodlocat);
                FillDependant_LcextTableLocatGln();

                //Check if foreignkey comes from history
                TableLocatGln.FilledByHistory = Navigation.CheckFilledByHistory("locat");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLocatGln (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Locat</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LcextTableLocatGln(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "locat.codlocat", "locat.gln" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln };
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
            CSGenioAlocat tempArea = new CSGenioAlocat(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlocat.FldCodlocat, PKey));
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
        /// Fill Dependant fields values -> TableLocatGln (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LcextTableLocatGln(bool lazyLoad = false)
        {
            var row = GetDependant_LcextTableLocatGln(this.ValCodlocat, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodlocat = ViewModelConversion.ToString(row["locat.codlocat"]);
                TableLocatGln.Value = ViewModelConversion.ToString(row["locat.gln"]);
                if (GlobalFunctions.emptyG(this.ValCodlocat) == 1)
                {
                    this.ValCodlocat = "";
                    TableLocatGln.Value = "";
                    Navigation.ClearValue("locat");
                }
                else if (lazyLoad)
                {
                    TableLocatGln.SetPagination(1, 0, false, false, 1);
                    TableLocatGln.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodlocat),
                            Text = Convert.ToString(TableLocatGln.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodlocat);
                }
                TableLocatGln.Selected = this.ValCodlocat;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLocatGln): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LCEXT___LOCATGLN_____ = { "Locat", "Locat.ValCodlocat", "Locat.ValZzstate", "Locat.ValGln" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LCEXT]/
		#endregion
	}
}
