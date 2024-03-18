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

namespace GenioMVC.ViewModels.Outpt
{
	public class Dsaid_ViewModel : FormViewModel<Models.Outpt>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Ware1>  TableWare1Warehdes { get; set; }

		/// <summary>Campo : "No:" Tipo:"N"</summary>
		[Display(Name = "NO_29277", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDocumenr { get; set; }

		/// <summary>Campo : "Date:" Tipo:"DT"</summary>
		[Display(Name = "DATE_55218", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDhdocume { get; set; }

		/// <summary>Campo : "Output:" Tipo:"DP"</summary>
		[Display(Name = "OUTPUT_10769", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Outpu> ValSaidas { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodoutpt { get; set; }

		public Dsaid_ViewModel() : base("FDSAID") { }

		public Dsaid_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDSAID", currentNavigation, nestedForm) { }

		public Dsaid_ViewModel(Models.Outpt row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDSAID", row, currentNavigation, nestedForm) { }

		public Dsaid_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("outpt", id);
			Model = Models.Outpt.Find(id, "FDSAID", fieldsToQuery: fieldsToLoad);
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
			Models.Outpt model = new Models.Outpt() { Identifier = "FDSAID" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Outpt model)
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

		public static StatusMessage DeleteConditions(Models.Outpt model)
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

		public static StatusMessage ViewConditions(Models.Outpt model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Outpt model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Outpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Outpt) to ViewModel (Dsaid) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDocumenr = ViewModelConversion.ToNumeric(m.ValDocumenr);
 				ValDhdocume = ViewModelConversion.ToDateTime(m.ValDhdocume);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodoutpt = ViewModelConversion.ToString(m.ValCodoutpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Outpt) to ViewModel (Dsaid) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Outpt m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dsaid) to Model (Outpt) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDocumenr = ViewModelConversion.ToNumeric(ValDocumenr);
				m.ValDhdocume = ViewModelConversion.ToDateTime(ValDhdocume);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodoutpt = ViewModelConversion.ToString(ValCodoutpt);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dsaid) to Model (Outpt) - Error during mapping");
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
				Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), "FDSAID");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Outpt() { Identifier = "FDSAID" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("outpt");
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

			Model.Identifier = "FDSAID";
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

		protected override void LoadDocumentsProperties(Models.Outpt row)
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
				Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), "FDSAID");
				if (Model == null)
				{
					Model = new Models.Outpt() { Identifier = "FDSAID" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("outpt");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Dsaid___ware1warehdes(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DSAID]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DSAID]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DSAID]/
		public override void Save()
		{

			try { Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), "FDSAID"); }
			finally { if (Model == null) Model = new Models.Outpt() { Identifier = "FDSAID" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DSAID]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Outpt.Find(Navigation.GetStrValue("outpt"), "FDSAID"); }
			finally { if (Model == null) Model = new Models.Outpt() { Identifier = "FDSAID" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DSAID]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DSAID]/
		public override void Destroy(string id)
		{
			Model = Models.Outpt.Find(id, "FDSAID");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableWare1Warehdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Dsaid___ware1warehdes(NameValueCollection qs, bool lazyLoad = false)
        {
            bool dsaid___ware1warehdesDoLoad = true;
            CriteriaSet dsaid___ware1warehdesConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("ware1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    dsaid___ware1warehdesConds.Equal(CSGenioAware1.FldCodwareh, Navigation.GetValue("ware1"));
                    this.ValCodwareh = Navigation.GetStrValue("ware1");
                }
            }



            TableWare1Warehdes = new TableDBEdit<Models.Ware1>();
            TableWare1Warehdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
                    this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}
                FillDependant_DsaidTableWare1Warehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWare1Warehdes.FilledByHistory = Navigation.CheckFilledByHistory("ware1");
                return;
            }


            if (dsaid___ware1warehdesDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableWare1Warehdes, "sTableWare1Warehdes", "dTableWare1Warehdes", qs, "ware1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAware1.FldWarehdes), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableWare1Warehdes_tableFilters"]))
                    TableWare1Warehdes.TableFilters = bool.Parse(qs["TableWare1Warehdes_tableFilters"]);
                else
                    TableWare1Warehdes.TableFilters = false;

                query = qs["qTableWare1Warehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAware1.FldWarehdes, query + "%");
                }
                dsaid___ware1warehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWare1Warehdes"] != null ? qs["pTableWare1Warehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes, CSGenioAware1.FldZzstate };

// USE /[MANUAL GQT OVERRQ DSAID_WARE1WAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("ware1", FormMode.New) || Navigation.checkFormMode("ware1", FormMode.Duplicate))
                    dsaid___ware1warehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAware1.FldZzstate, 0)
                        .Equal(CSGenioAware1.FldCodwareh, Navigation.GetStrValue("ware1")));
                else
                    dsaid___ware1warehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAware1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //dsaid___ware1warehdesConds = Ware1.AddEPH<CSGenioAware1>(ref UserContext.Current.User, dsaid___ware1warehdesConds, "LED_DSAID___WARE1WAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("ware1", "warehdes");
                ListingMVC<CSGenioAware1> listing = Models.ModelBase.Where<CSGenioAware1>(false, dsaid___ware1warehdesConds, fields, offset, numberItems, sorts, "LED_DSAID___WARE1WAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWare1Warehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWare1Warehdes.Query = query;
                TableWare1Warehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Ware1>((r) => new GenioMVC.Models.Ware1(r, true, _fieldsToSerialize_DSAID___WARE1WAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_ware1") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_ware1");
					Navigation.CurrentLevel.SetEntry("RETURN_ware1", null);
				}

				TableWare1Warehdes.List = new SelectList(TableWare1Warehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                FillDependant_DsaidTableWare1Warehdes();

                //Check if foreignkey comes from history
                TableWare1Warehdes.FilledByHistory = Navigation.CheckFilledByHistory("ware1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWare1Warehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Ware1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DsaidTableWare1Warehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "ware1.codwareh", "ware1.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes };
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
            CSGenioAware1 tempArea = new CSGenioAware1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAware1.FldCodwareh, PKey));
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
        /// Fill Dependant fields values -> TableWare1Warehdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_DsaidTableWare1Warehdes(bool lazyLoad = false)
        {
            var row = GetDependant_DsaidTableWare1Warehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["ware1.codwareh"]);
                TableWare1Warehdes.Value = ViewModelConversion.ToString(row["ware1.warehdes"]);
                if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
                {
                    this.ValCodwareh = "";
                    TableWare1Warehdes.Value = "";
                    Navigation.ClearValue("ware1");
                }
                else if (lazyLoad)
                {
                    TableWare1Warehdes.SetPagination(1, 0, false, false, 1);
                    TableWare1Warehdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodwareh),
                            Text = Convert.ToString(TableWare1Warehdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodwareh);
                }
                TableWare1Warehdes.Selected = this.ValCodwareh;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWare1Warehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_DSAID___WARE1WAREHDES = { "Ware1", "Ware1.ValCodwareh", "Ware1.ValZzstate", "Ware1.ValWarehdes" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DSAID]/
		#endregion
	}
}
