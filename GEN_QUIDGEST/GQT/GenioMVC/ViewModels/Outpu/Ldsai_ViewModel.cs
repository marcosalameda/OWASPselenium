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

namespace GenioMVC.ViewModels.Outpu
{
	public class Ldsai_ViewModel : FormViewModel<Models.Outpu>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Document No." Tipo:"N"</summary>
		[Display(Name = "DOCUMENT_NO_30174", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Outpt>  TableOutptDocumenr { get; set; }

		/// <summary>Campo : "" Tipo:"CE"</summary>
		public string OutptValCodwareh { get { return funcOutptValCodwareh != null ? funcOutptValCodwareh() : _auxOutptValCodwareh; } set { funcOutptValCodwareh = () => value; } }
		[JsonIgnore]
		public Func<string> funcOutptValCodwareh { get; set; }
		private string _auxOutptValCodwareh { get; set; }

		/// <summary>Campo : "Line" Tipo:"N"</summary>
		[Display(Name = "LINE27983", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N1}" )]
		[NumericAttribute(1)]
		public decimal? ValLine { get; set; }

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Wareh>  TableWarehWarehdes { get; set; }

		/// <summary>Campo : "Item" Tipo:"C"</summary>
		[Display(Name = "ITEM40802", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Item>  TableItemItemdes { get; set; }

		/// <summary>Campo : "Output quantity:" Tipo:"N"</summary>
		[Display(Name = "OUTPUT_QUANTITY_59942", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValExitqnty { get; set; }

		/// <summary>Campo : "Output No" Tipo:"N"</summary>
		[Display(Name = "OUTPUT_NO41865", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Oudoc>  TableOudocNrdocsda { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ITEM40802", ResourceType = typeof(Resources.Resources))]
		public string ValCoditem { get; set; }

		[Display(Name = "OUTPUT_NO41865", ResourceType = typeof(Resources.Resources))]
		public string ValCoddocsd { get; set; }

		[Display(Name = "DOCUMENT_NO_30174", ResourceType = typeof(Resources.Resources))]
		public string ValCodoutpt { get; set; }

		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodoutpu { get; set; }

		public Ldsai_ViewModel() : base("FLDSAI") { }

		public Ldsai_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLDSAI", currentNavigation, nestedForm) { }

		public Ldsai_ViewModel(Models.Outpu row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLDSAI", row, currentNavigation, nestedForm) { }

		public Ldsai_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("outpu", id);
			Model = Models.Outpu.Find(id, "FLDSAI", fieldsToQuery: fieldsToLoad);
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
			Models.Outpu model = new Models.Outpu() { Identifier = "FLDSAI" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Outpu model)
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

		public static StatusMessage DeleteConditions(Models.Outpu model)
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

		public static StatusMessage ViewConditions(Models.Outpu model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Outpu model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Outpu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Outpu) to ViewModel (Ldsai) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				funcOutptValCodwareh = () => ViewModelConversion.ToString(m.Outpt.ValCodwareh);
 				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
 				ValExitqnty = ViewModelConversion.ToNumeric(m.ValExitqnty);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCoddocsd = ViewModelConversion.ToString(m.ValCoddocsd);
 				ValCodoutpt = ViewModelConversion.ToString(m.ValCodoutpt);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodoutpu = ViewModelConversion.ToString(m.ValCodoutpu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Outpu) to ViewModel (Ldsai) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Outpu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldsai) to Model (Outpu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValExitqnty = ViewModelConversion.ToNumeric(ValExitqnty);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCoddocsd = ViewModelConversion.ToString(ValCoddocsd);
				m.ValCodoutpt = ViewModelConversion.ToString(ValCodoutpt);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodoutpu = ViewModelConversion.ToString(ValCodoutpu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldsai) to Model (Outpu) - Error during mapping");
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
				Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), "FLDSAI");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Outpu() { Identifier = "FLDSAI" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("outpu");
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

			Model.Identifier = "FLDSAI";
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

		protected override void LoadDocumentsProperties(Models.Outpu row)
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
				Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), "FLDSAI");
				if (Model == null)
				{
					Model = new Models.Outpu() { Identifier = "FLDSAI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("outpu");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Ldsai___outptdocumenr(qs, lazyLoad);
			Load_Ldsai___warehwarehdes(qs, lazyLoad);
			Load_Ldsai___item_itemdes_(qs, lazyLoad);
			Load_Ldsai___oudocnrdocsda(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LDSAI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LDSAI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LDSAI]/
		public override void Save()
		{

			try { Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), "FLDSAI"); }
			finally { if (Model == null) Model = new Models.Outpu() { Identifier = "FLDSAI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LDSAI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), "FLDSAI"); }
			finally { if (Model == null) Model = new Models.Outpu() { Identifier = "FLDSAI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LDSAI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LDSAI]/
		public override void Destroy(string id)
		{
			Model = Models.Outpu.Find(id, "FLDSAI");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableOutptDocumenr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Ldsai___outptdocumenr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool ldsai___outptdocumenrDoLoad = true;
            CriteriaSet ldsai___outptdocumenrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("outpt", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldsai___outptdocumenrConds.Equal(CSGenioAoutpt.FldCodoutpt, Navigation.GetValue("outpt"));
                    this.ValCodoutpt = Navigation.GetStrValue("outpt");
                }
            }



            TableOutptDocumenr = new TableDBEdit<Models.Outpt>();
            TableOutptDocumenr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_outpt") != null)
				{
                    this.ValCodoutpt = Navigation.GetStrValue("RETURN_outpt");
					Navigation.CurrentLevel.SetEntry("RETURN_outpt", null);
				}
                FillDependant_LdsaiTableOutptDocumenr(lazyLoad);
                //Check if foreignkey comes from history
                TableOutptDocumenr.FilledByHistory = Navigation.CheckFilledByHistory("outpt");
                return;
            }


            if (ldsai___outptdocumenrDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableOutptDocumenr, "sTableOutptDocumenr", "dTableOutptDocumenr", qs, "outpt");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoutpt.FldDhdocume), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableOutptDocumenr_tableFilters"]))
                    TableOutptDocumenr.TableFilters = bool.Parse(qs["TableOutptDocumenr_tableFilters"]);
                else
                    TableOutptDocumenr.TableFilters = false;

                query = qs["qTableOutptDocumenr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAoutpt.FldDocumenr, query + "%");
                }
                ldsai___outptdocumenrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableOutptDocumenr"] != null ? qs["pTableOutptDocumenr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldDhdocume, CSGenioAoutpt.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_OUTPTDOCUMENR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("outpt", FormMode.New) || Navigation.checkFormMode("outpt", FormMode.Duplicate))
                    ldsai___outptdocumenrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAoutpt.FldZzstate, 0)
                        .Equal(CSGenioAoutpt.FldCodoutpt, Navigation.GetStrValue("outpt")));
                else
                    ldsai___outptdocumenrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAoutpt.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldsai___outptdocumenrConds = Outpt.AddEPH<CSGenioAoutpt>(ref UserContext.Current.User, ldsai___outptdocumenrConds, "LED_LDSAI___OUTPTDOCUMENR");

                FieldRef firstVisibleColumn = new FieldRef("outpt", "documenr");
                ListingMVC<CSGenioAoutpt> listing = Models.ModelBase.Where<CSGenioAoutpt>(false, ldsai___outptdocumenrConds, fields, offset, numberItems, sorts, "LED_LDSAI___OUTPTDOCUMENR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableOutptDocumenr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableOutptDocumenr.Query = query;
                TableOutptDocumenr.Elements = listing.RowsForViewModel<GenioMVC.Models.Outpt>((r) => new GenioMVC.Models.Outpt(r, true, _fieldsToSerialize_LDSAI___OUTPTDOCUMENR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_outpt") != null)
				{
					this.ValCodoutpt = Navigation.GetStrValue("RETURN_outpt");
					Navigation.CurrentLevel.SetEntry("RETURN_outpt", null);
				}

				TableOutptDocumenr.List = new SelectList(TableOutptDocumenr.Elements.ToSelectList(x => x.ValDocumenr, x => x.ValCodoutpt,  x => x.ValCodoutpt == this.ValCodoutpt), "Value", "Text", this.ValCodoutpt);
                if(!isSearchRequest)
                    FillDependant_LdsaiTableOutptDocumenr();

                //Check if foreignkey comes from history
                TableOutptDocumenr.FilledByHistory = Navigation.CheckFilledByHistory("outpt");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableOutptDocumenr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Outpt</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdsaiTableOutptDocumenr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "outpt.codoutpt", "outpt.documenr", "outpt.codwareh" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldCodwareh };
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
            CSGenioAoutpt tempArea = new CSGenioAoutpt(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAoutpt.FldCodoutpt, PKey));
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
        /// Fill Dependant fields values -> TableOutptDocumenr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdsaiTableOutptDocumenr(bool lazyLoad = false)
        {
            var row = GetDependant_LdsaiTableOutptDocumenr(this.ValCodoutpt, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["outpt.codwareh"]);
                    this.funcOutptValCodwareh = () => tempValue;
                }

                // Fill List fields
                this.ValCodoutpt = ViewModelConversion.ToString(row["outpt.codoutpt"]);
                TableOutptDocumenr.Value = ViewModelConversion.ToNumeric(row["outpt.documenr"]);
                if (GlobalFunctions.emptyG(this.ValCodoutpt) == 1)
                {
                    this.ValCodoutpt = "";
                    TableOutptDocumenr.Value = 0m;
                    Navigation.ClearValue("outpt");
                }
                else if (lazyLoad)
                {
                    TableOutptDocumenr.SetPagination(1, 0, false, false, 1);
                    TableOutptDocumenr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodoutpt),
                            Text = Convert.ToString(TableOutptDocumenr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodoutpt);
                }
                TableOutptDocumenr.Selected = this.ValCodoutpt;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOutptDocumenr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDSAI___OUTPTDOCUMENR = { "Outpt", "Outpt.ValCodoutpt", "Outpt.ValZzstate", "Outpt.ValDocumenr", "Outpt.ValDhdocume" };

        /// <summary>
        /// TableWarehWarehdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Ldsai___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
        {
            bool ldsai___warehwarehdesDoLoad = true;
            CriteriaSet ldsai___warehwarehdesConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("wareh", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldsai___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
                    this.ValCodwareh = Navigation.GetStrValue("wareh");
                }
            }



            TableWarehWarehdes = new TableDBEdit<Models.Wareh>();
            TableWarehWarehdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
                    this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
                FillDependant_LdsaiTableWarehWarehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
                return;
            }


            if (ldsai___warehwarehdesDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehdes), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
                    TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
                else
                    TableWarehWarehdes.TableFilters = false;

                query = qs["qTableWarehWarehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
                }
                ldsai___warehwarehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_WAREHWAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
                    ldsai___warehwarehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAwareh.FldZzstate, 0)
                        .Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
                else
                    ldsai___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldsai___warehwarehdesConds = Wareh.AddEPH<CSGenioAwareh>(ref UserContext.Current.User, ldsai___warehwarehdesConds, "LED_LDSAI___WAREHWAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
                ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(false, ldsai___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_LDSAI___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWarehWarehdes.Query = query;
                TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(r, true, _fieldsToSerialize_LDSAI___WAREHWAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                if(!isSearchRequest)
                    FillDependant_LdsaiTableWarehWarehdes();

                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Wareh</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdsaiTableWarehWarehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "wareh.codwareh", "wareh.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };
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
            CSGenioAwareh tempArea = new CSGenioAwareh(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));
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
        /// Fill Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdsaiTableWarehWarehdes(bool lazyLoad = false)
        {
            var row = GetDependant_LdsaiTableWarehWarehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
                TableWarehWarehdes.Value = ViewModelConversion.ToString(row["wareh.warehdes"]);
                if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
                {
                    this.ValCodwareh = "";
                    TableWarehWarehdes.Value = "";
                    Navigation.ClearValue("wareh");
                }
                else if (lazyLoad)
                {
                    TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
                    TableWarehWarehdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodwareh),
                            Text = Convert.ToString(TableWarehWarehdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodwareh);
                }
                TableWarehWarehdes.Selected = this.ValCodwareh;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDSAI___WAREHWAREHDES = { "Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes" };

        /// <summary>
        /// TableItemItemdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Ldsai___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool ldsai___item_itemdes_DoLoad = true;
            CriteriaSet ldsai___item_itemdes_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("item", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldsai___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, Navigation.GetValue("item"));
                    this.ValCoditem = Navigation.GetStrValue("item");
                }
            }

			// Limits Generation

			// Area limit
			ldsai___item_itemdes_DoLoad &= AddCriteriaAreaLimit(ldsai___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);


            TableItemItemdes = new TableDBEdit<Models.Item>();
            TableItemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
                    this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
                FillDependant_LdsaiTableItemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodwareh))
                ldsai___item_itemdes_DoLoad = false;

            if (ldsai___item_itemdes_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemdes), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
                    TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
                else
                    TableItemItemdes.TableFilters = false;

                query = qs["qTableItemItemdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
                }
                ldsai___item_itemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_ITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
                    ldsai___item_itemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAitem.FldZzstate, 0)
                        .Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
                else
                    ldsai___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldsai___item_itemdes_Conds = Item.AddEPH<CSGenioAitem>(ref UserContext.Current.User, ldsai___item_itemdes_Conds, "LED_LDSAI___ITEM_ITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
                ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(false, ldsai___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_LDSAI___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableItemItemdes.Query = query;
                TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(r, true, _fieldsToSerialize_LDSAI___ITEM_ITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
                if(!isSearchRequest)
                    FillDependant_LdsaiTableItemItemdes();

                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Item</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdsaiTableItemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "item.coditem", "item.itemdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("wareh");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAitem tempArea = new CSGenioAitem(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));
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
        /// Fill Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdsaiTableItemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_LdsaiTableItemItemdes(this.ValCoditem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
                TableItemItemdes.Value = ViewModelConversion.ToString(row["item.itemdes"]);
                if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
                {
                    this.ValCoditem = "";
                    TableItemItemdes.Value = "";
                    Navigation.ClearValue("item");
                }
                else if (lazyLoad)
                {
                    TableItemItemdes.SetPagination(1, 0, false, false, 1);
                    TableItemItemdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoditem),
                            Text = Convert.ToString(TableItemItemdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoditem);
                }
                TableItemItemdes.Selected = this.ValCoditem;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDSAI___ITEM_ITEMDES_ = { "Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes" };

        /// <summary>
        /// TableOudocNrdocsda -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Ldsai___oudocnrdocsda(NameValueCollection qs, bool lazyLoad = false)
        {
            bool ldsai___oudocnrdocsdaDoLoad = true;
            CriteriaSet ldsai___oudocnrdocsdaConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("oudoc", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    ldsai___oudocnrdocsdaConds.Equal(CSGenioAoudoc.FldCoddocsd, Navigation.GetValue("oudoc"));
                    this.ValCoddocsd = Navigation.GetStrValue("oudoc");
                }
            }



            TableOudocNrdocsda = new TableDBEdit<Models.Oudoc>();
            TableOudocNrdocsda.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_oudoc") != null)
				{
                    this.ValCoddocsd = Navigation.GetStrValue("RETURN_oudoc");
					Navigation.CurrentLevel.SetEntry("RETURN_oudoc", null);
				}
                FillDependant_LdsaiTableOudocNrdocsda(lazyLoad);
                //Check if foreignkey comes from history
                TableOudocNrdocsda.FilledByHistory = Navigation.CheckFilledByHistory("oudoc");
                return;
            }


            if (ldsai___oudocnrdocsdaDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableOudocNrdocsda, "sTableOudocNrdocsda", "dTableOudocNrdocsda", qs, "oudoc");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoudoc.FldNrdocsda), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableOudocNrdocsda_tableFilters"]))
                    TableOudocNrdocsda.TableFilters = bool.Parse(qs["TableOudocNrdocsda_tableFilters"]);
                else
                    TableOudocNrdocsda.TableFilters = false;

                query = qs["qTableOudocNrdocsda"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAoudoc.FldNrdocsda, query + "%");
                }
                ldsai___oudocnrdocsdaConds.SubSet(search_filters);


                string tryParsePage = qs["pTableOudocNrdocsda"] != null ? qs["pTableOudocNrdocsda"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAoudoc.FldCoddocsd, CSGenioAoudoc.FldNrdocsda, CSGenioAoudoc.FldDtdocsda, CSGenioAoudoc.FldTitle, CSGenioAoudoc.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_OUDOCNRDOCSDA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("oudoc", FormMode.New) || Navigation.checkFormMode("oudoc", FormMode.Duplicate))
                    ldsai___oudocnrdocsdaConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAoudoc.FldZzstate, 0)
                        .Equal(CSGenioAoudoc.FldCoddocsd, Navigation.GetStrValue("oudoc")));
                else
                    ldsai___oudocnrdocsdaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAoudoc.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //ldsai___oudocnrdocsdaConds = Oudoc.AddEPH<CSGenioAoudoc>(ref UserContext.Current.User, ldsai___oudocnrdocsdaConds, "LED_LDSAI___OUDOCNRDOCSDA");

                FieldRef firstVisibleColumn = new FieldRef("oudoc", "nrdocsda");
                ListingMVC<CSGenioAoudoc> listing = Models.ModelBase.Where<CSGenioAoudoc>(false, ldsai___oudocnrdocsdaConds, fields, offset, numberItems, sorts, "LED_LDSAI___OUDOCNRDOCSDA", true, false, firstVisibleColumn: firstVisibleColumn);

                TableOudocNrdocsda.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableOudocNrdocsda.Query = query;
                TableOudocNrdocsda.Elements = listing.RowsForViewModel<GenioMVC.Models.Oudoc>((r) => new GenioMVC.Models.Oudoc(r, true, _fieldsToSerialize_LDSAI___OUDOCNRDOCSDA));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_oudoc") != null)
				{
					this.ValCoddocsd = Navigation.GetStrValue("RETURN_oudoc");
					Navigation.CurrentLevel.SetEntry("RETURN_oudoc", null);
				}

				TableOudocNrdocsda.List = new SelectList(TableOudocNrdocsda.Elements.ToSelectList(x => x.ValNrdocsda, x => x.ValCoddocsd,  x => x.ValCoddocsd == this.ValCoddocsd), "Value", "Text", this.ValCoddocsd);
                if(!isSearchRequest)
                    FillDependant_LdsaiTableOudocNrdocsda();

                //Check if foreignkey comes from history
                TableOudocNrdocsda.FilledByHistory = Navigation.CheckFilledByHistory("oudoc");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableOudocNrdocsda (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Oudoc</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LdsaiTableOudocNrdocsda(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "oudoc.coddocsd", "oudoc.nrdocsda" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAoudoc.FldCoddocsd, CSGenioAoudoc.FldNrdocsda };
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
            CSGenioAoudoc tempArea = new CSGenioAoudoc(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAoudoc.FldCoddocsd, PKey));
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
        /// Fill Dependant fields values -> TableOudocNrdocsda (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LdsaiTableOudocNrdocsda(bool lazyLoad = false)
        {
            var row = GetDependant_LdsaiTableOudocNrdocsda(this.ValCoddocsd, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoddocsd = ViewModelConversion.ToString(row["oudoc.coddocsd"]);
                TableOudocNrdocsda.Value = ViewModelConversion.ToNumeric(row["oudoc.nrdocsda"]);
                if (GlobalFunctions.emptyG(this.ValCoddocsd) == 1)
                {
                    this.ValCoddocsd = "";
                    TableOudocNrdocsda.Value = 0m;
                    Navigation.ClearValue("oudoc");
                }
                else if (lazyLoad)
                {
                    TableOudocNrdocsda.SetPagination(1, 0, false, false, 1);
                    TableOudocNrdocsda.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoddocsd),
                            Text = Convert.ToString(TableOudocNrdocsda.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoddocsd);
                }
                TableOudocNrdocsda.Selected = this.ValCoddocsd;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOudocNrdocsda): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LDSAI___OUDOCNRDOCSDA = { "Oudoc", "Oudoc.ValCoddocsd", "Oudoc.ValZzstate", "Oudoc.ValNrdocsda", "Oudoc.ValDtdocsda", "Oudoc.ValTitle" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LDSAI]/
		#endregion
	}
}
