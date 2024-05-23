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

namespace GenioMVC.ViewModels.Dilin
{
	public class Dilin_ViewModel : FormViewModel<Models.Dilin>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Dispatch number" Tipo:"N"</summary>
		[Display(Name = "DISPATCH_NUMBER23616", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Dispa>  TableDispaDispanr { get; set; }

		/// <summary>Campo : "Line" Tipo:"N"</summary>
		[Display(Name = "LINE27983", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValLinenumb { get; set; }

		/// <summary>Campo : "Product" Tipo:"C"</summary>
		[Display(Name = "PRODUCT12880", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Produ>  TableProduProduct { get; set; }

		/// <summary>Campo : "Ordered" Tipo:"N"</summary>
		[Display(Name = "ORDERED04034", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOrdered { get; set; }

		/// <summary>Campo : "Delivered" Tipo:"N"</summary>
		[Display(Name = "DELIVERED26597", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDelivere { get; set; }

		/// <summary>Campo : "Outstanding" Tipo:"N"</summary>
		[Display(Name = "OUTSTANDING36400", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOutstand { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "DISPATCH_NUMBER23616", ResourceType = typeof(Resources.Resources))]
		public string ValCoddispa { get; set; }

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "PRODUCT12880", ResourceType = typeof(Resources.Resources))]
		public string ValCodprodu { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCoddilin { get; set; }

		public Dilin_ViewModel() : base("FDILIN") { }

		public Dilin_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDILIN", currentNavigation, nestedForm) { }

		public Dilin_ViewModel(Models.Dilin row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDILIN", row, currentNavigation, nestedForm) { }

		public Dilin_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("dilin", id);
			Model = Models.Dilin.Find(id, "FDILIN", fieldsToQuery: fieldsToLoad);
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
			Models.Dilin model = new Models.Dilin() { Identifier = "FDILIN" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Dilin model)
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

		public static StatusMessage DeleteConditions(Models.Dilin model)
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

		public static StatusMessage ViewConditions(Models.Dilin model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Dilin model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Dilin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Dilin) to ViewModel (Dilin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValLinenumb = ViewModelConversion.ToNumeric(m.ValLinenumb);
 				ValOrdered = ViewModelConversion.ToNumeric(m.ValOrdered);
 				ValDelivere = ViewModelConversion.ToNumeric(m.ValDelivere);
 				ValOutstand = ViewModelConversion.ToNumeric(m.ValOutstand);
 				ValCoddispa = ViewModelConversion.ToString(m.ValCoddispa);
 				ValCodprodu = ViewModelConversion.ToString(m.ValCodprodu);
 				ValCoddilin = ViewModelConversion.ToString(m.ValCoddilin);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Dilin) to ViewModel (Dilin) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Dilin m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dilin) to Model (Dilin) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValLinenumb = ViewModelConversion.ToNumeric(ValLinenumb);
				m.ValOrdered = ViewModelConversion.ToNumeric(ValOrdered);
				m.ValDelivere = ViewModelConversion.ToNumeric(ValDelivere);
				m.ValOutstand = ViewModelConversion.ToNumeric(ValOutstand);
				m.ValCoddispa = ViewModelConversion.ToString(ValCoddispa);
				m.ValCodprodu = ViewModelConversion.ToString(ValCodprodu);
				m.ValCoddilin = ViewModelConversion.ToString(ValCoddilin);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dilin) to Model (Dilin) - Error during mapping");
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
				Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), "FDILIN");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Dilin() { Identifier = "FDILIN" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("dilin");
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

			Model.Identifier = "FDILIN";
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

		protected override void LoadDocumentsProperties(Models.Dilin row)
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
				Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), "FDILIN");
				if (Model == null)
				{
					Model = new Models.Dilin() { Identifier = "FDILIN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dilin");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Dilin___dispadispanr_(qs, lazyLoad);
			Load_Dilin___produproduct_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DILIN]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DILIN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DILIN]/
		public override void Save()
		{

			try { Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), "FDILIN"); }
			finally { if (Model == null) Model = new Models.Dilin() { Identifier = "FDILIN" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DILIN]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Dilin.Find(Navigation.GetStrValue("dilin"), "FDILIN"); }
			finally { if (Model == null) Model = new Models.Dilin() { Identifier = "FDILIN" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DILIN]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DILIN]/
		public override void Destroy(string id)
		{
			Model = Models.Dilin.Find(id, "FDILIN");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableDispaDispanr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Dilin___dispadispanr_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool dilin___dispadispanr_DoLoad = true;
            CriteriaSet dilin___dispadispanr_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("dispa", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    dilin___dispadispanr_Conds.Equal(CSGenioAdispa.FldCoddispa, Navigation.GetValue("dispa"));
                    this.ValCoddispa = Navigation.GetStrValue("dispa");
                }
            }



            TableDispaDispanr = new TableDBEdit<Models.Dispa>();
            TableDispaDispanr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_dispa") != null)
				{
                    this.ValCoddispa = Navigation.GetStrValue("RETURN_dispa");
					Navigation.CurrentLevel.SetEntry("RETURN_dispa", null);
				}
                FillDependant_DilinTableDispaDispanr(lazyLoad);
                //Check if foreignkey comes from history
                TableDispaDispanr.FilledByHistory = Navigation.CheckFilledByHistory("dispa");
                return;
            }


            if (dilin___dispadispanr_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableDispaDispanr, "sTableDispaDispanr", "dTableDispaDispanr", qs, "dispa");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableDispaDispanr_tableFilters"]))
                    TableDispaDispanr.TableFilters = bool.Parse(qs["TableDispaDispanr_tableFilters"]);
                else
                    TableDispaDispanr.TableFilters = false;

                query = qs["qTableDispaDispanr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAdispa.FldDispanr, query + "%");
                }
                dilin___dispadispanr_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableDispaDispanr"] != null ? qs["pTableDispaDispanr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldDispanr, CSGenioAdispa.FldZzstate };

// USE /[MANUAL GQT OVERRQ DILIN_DISPADISPANR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("dispa", FormMode.New) || Navigation.checkFormMode("dispa", FormMode.Duplicate))
                    dilin___dispadispanr_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAdispa.FldZzstate, 0)
                        .Equal(CSGenioAdispa.FldCoddispa, Navigation.GetStrValue("dispa")));
                else
                    dilin___dispadispanr_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAdispa.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //dilin___dispadispanr_Conds = Dispa.AddEPH<CSGenioAdispa>(ref UserContext.Current.User, dilin___dispadispanr_Conds, "LED_DILIN___DISPADISPANR_");

                FieldRef firstVisibleColumn = new FieldRef("dispa", "dispanr");
                ListingMVC<CSGenioAdispa> listing = Models.ModelBase.Where<CSGenioAdispa>(false, dilin___dispadispanr_Conds, fields, offset, numberItems, sorts, "LED_DILIN___DISPADISPANR_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableDispaDispanr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableDispaDispanr.Query = query;
                TableDispaDispanr.Elements = listing.RowsForViewModel<GenioMVC.Models.Dispa>((r) => new GenioMVC.Models.Dispa(r, true, _fieldsToSerialize_DILIN___DISPADISPANR_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_dispa") != null)
				{
					this.ValCoddispa = Navigation.GetStrValue("RETURN_dispa");
					Navigation.CurrentLevel.SetEntry("RETURN_dispa", null);
				}

				TableDispaDispanr.List = new SelectList(TableDispaDispanr.Elements.ToSelectList(x => x.ValDispanr, x => x.ValCoddispa,  x => x.ValCoddispa == this.ValCoddispa), "Value", "Text", this.ValCoddispa);
                FillDependant_DilinTableDispaDispanr();

                //Check if foreignkey comes from history
                TableDispaDispanr.FilledByHistory = Navigation.CheckFilledByHistory("dispa");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableDispaDispanr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Dispa</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DilinTableDispaDispanr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "dispa.coddispa", "dispa.dispanr" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldDispanr };
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
            CSGenioAdispa tempArea = new CSGenioAdispa(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAdispa.FldCoddispa, PKey));
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
        /// Fill Dependant fields values -> TableDispaDispanr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DilinTableDispaDispanr(bool lazyLoad = false)
        {
            var row = GetDependant_DilinTableDispaDispanr(this.ValCoddispa, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoddispa = ViewModelConversion.ToString(row["dispa.coddispa"]);
                TableDispaDispanr.Value = ViewModelConversion.ToNumeric(row["dispa.dispanr"]);
                if (GlobalFunctions.emptyG(this.ValCoddispa) == 1)
                {
                    this.ValCoddispa = "";
                    TableDispaDispanr.Value = 0m;
                    Navigation.ClearValue("dispa");
                }
                else if (lazyLoad)
                {
                    TableDispaDispanr.SetPagination(1, 0, false, false, 1);
                    TableDispaDispanr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoddispa),
                            Text = Convert.ToString(TableDispaDispanr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoddispa);
                }
                TableDispaDispanr.Selected = this.ValCoddispa;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableDispaDispanr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DILIN___DISPADISPANR_ = { "Dispa", "Dispa.ValCoddispa", "Dispa.ValZzstate", "Dispa.ValDispanr" };

        /// <summary>
        /// TableProduProduct -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Dilin___produproduct_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool dilin___produproduct_DoLoad = true;
            CriteriaSet dilin___produproduct_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("produ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    dilin___produproduct_Conds.Equal(CSGenioAprodu.FldCodprodu, Navigation.GetValue("produ"));
                    this.ValCodprodu = Navigation.GetStrValue("produ");
                }
            }



            TableProduProduct = new TableDBEdit<Models.Produ>();
            TableProduProduct.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_produ") != null)
				{
                    this.ValCodprodu = Navigation.GetStrValue("RETURN_produ");
					Navigation.CurrentLevel.SetEntry("RETURN_produ", null);
				}
                FillDependant_DilinTableProduProduct(lazyLoad);
                //Check if foreignkey comes from history
                TableProduProduct.FilledByHistory = Navigation.CheckFilledByHistory("produ");
                return;
            }


            if (dilin___produproduct_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableProduProduct, "sTableProduProduct", "dTableProduProduct", qs, "produ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAprodu.FldProduct), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableProduProduct_tableFilters"]))
                    TableProduProduct.TableFilters = bool.Parse(qs["TableProduProduct_tableFilters"]);
                else
                    TableProduProduct.TableFilters = false;

                query = qs["qTableProduProduct"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAprodu.FldProduct, query + "%");
                }
                dilin___produproduct_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableProduProduct"] != null ? qs["pTableProduProduct"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct, CSGenioAprodu.FldZzstate };

// USE /[MANUAL GQT OVERRQ DILIN_PRODUPRODUCT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("produ", FormMode.New) || Navigation.checkFormMode("produ", FormMode.Duplicate))
                    dilin___produproduct_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAprodu.FldZzstate, 0)
                        .Equal(CSGenioAprodu.FldCodprodu, Navigation.GetStrValue("produ")));
                else
                    dilin___produproduct_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAprodu.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //dilin___produproduct_Conds = Produ.AddEPH<CSGenioAprodu>(ref UserContext.Current.User, dilin___produproduct_Conds, "LED_DILIN___PRODUPRODUCT_");

                FieldRef firstVisibleColumn = new FieldRef("produ", "product");
                ListingMVC<CSGenioAprodu> listing = Models.ModelBase.Where<CSGenioAprodu>(false, dilin___produproduct_Conds, fields, offset, numberItems, sorts, "LED_DILIN___PRODUPRODUCT_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableProduProduct.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableProduProduct.Query = query;
                TableProduProduct.Elements = listing.RowsForViewModel<GenioMVC.Models.Produ>((r) => new GenioMVC.Models.Produ(r, true, _fieldsToSerialize_DILIN___PRODUPRODUCT_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_produ") != null)
				{
					this.ValCodprodu = Navigation.GetStrValue("RETURN_produ");
					Navigation.CurrentLevel.SetEntry("RETURN_produ", null);
				}

				TableProduProduct.List = new SelectList(TableProduProduct.Elements.ToSelectList(x => x.ValProduct, x => x.ValCodprodu,  x => x.ValCodprodu == this.ValCodprodu), "Value", "Text", this.ValCodprodu);
                //Seleciona se só um
                if(TableProduProduct.List != null && TableProduProduct.List.Count() == 1)
                {
					this.ValCodprodu = TableProduProduct.List.First().Value;
					Navigation.SetValue("produ", this.ValCodprodu);
                }
                FillDependant_DilinTableProduProduct();

                //Check if foreignkey comes from history
                TableProduProduct.FilledByHistory = Navigation.CheckFilledByHistory("produ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableProduProduct (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Produ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DilinTableProduProduct(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "produ.codprodu", "produ.product" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldProduct };
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
            CSGenioAprodu tempArea = new CSGenioAprodu(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAprodu.FldCodprodu, PKey));
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
        /// Fill Dependant fields values -> TableProduProduct (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DilinTableProduProduct(bool lazyLoad = false)
        {
            var row = GetDependant_DilinTableProduProduct(this.ValCodprodu, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodprodu = ViewModelConversion.ToString(row["produ.codprodu"]);
                TableProduProduct.Value = ViewModelConversion.ToString(row["produ.product"]);
                if (GlobalFunctions.emptyG(this.ValCodprodu) == 1)
                {
                    this.ValCodprodu = "";
                    TableProduProduct.Value = "";
                    Navigation.ClearValue("produ");
                }
                else if (lazyLoad)
                {
                    TableProduProduct.SetPagination(1, 0, false, false, 1);
                    TableProduProduct.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodprodu),
                            Text = Convert.ToString(TableProduProduct.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodprodu);
                }
                TableProduProduct.Selected = this.ValCodprodu;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableProduProduct): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DILIN___PRODUPRODUCT_ = { "Produ", "Produ.ValCodprodu", "Produ.ValZzstate", "Produ.ValProduct" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DILIN]/
		#endregion
	}
}
