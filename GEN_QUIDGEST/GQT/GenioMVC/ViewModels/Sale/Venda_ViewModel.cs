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

namespace GenioMVC.ViewModels.Sale
{
	public class Venda_ViewModel : FormViewModel<Models.Sale>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Organization" Tipo:"C"</summary>
		[Display(Name = "ORGANIZATION64123", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Organ>  TableOrganOrganiza { get; set; }

		/// <summary>Campo : "leader no." Tipo:"N"</summary>
		[Display(Name = "LEADER_NO_11905", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNrlide { get; set; }

		/// <summary>Campo : "Start" Tipo:"DT"</summary>
		[Display(Name = "START00919", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get; set; }

		/// <summary>Campo : "Identification of business opportunity" Tipo:"C"</summary>
		[Display(Name = "IDENTIFICATION_OF_BU58085", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdentifi { get; set; }

		/// <summary>Campo : "Potential Buyers" Tipo:"C"</summary>
		[Display(Name = "POTENTIAL_BUYERS56564", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPotcompr { get; set; }

		/// <summary>Campo : "Prospection carried out" Tipo:"L"</summary>
		[Display(Name = "PROSPECTION_CARRIED_20791", ResourceType = typeof(Resources.Resources))]
		public bool ValProspecc { get; set; }

		/// <summary>Campo : "Interested" Tipo:"L"</summary>
		[Display(Name = "INTERESTED34576", ResourceType = typeof(Resources.Resources))]
		public bool ValInteress { get; set; }

		/// <summary>Campo : "Without Financial Resources" Tipo:"L"</summary>
		[Display(Name = "WITHOUT_FINANCIAL_RE10399", ResourceType = typeof(Resources.Resources))]
		public bool ValSemrfina { get; set; }

		/// <summary>Campo : "No decision-making power" Tipo:"L"</summary>
		[Display(Name = "NO_DECISION_MAKING_P36615", ResourceType = typeof(Resources.Resources))]
		public bool ValSemcapac { get; set; }

		/// <summary>Campo : "Qualification" Tipo:"DT"</summary>
		[Display(Name = "QUALIFICATION64257", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get; set; }

		/// <summary>Campo : "Qualification carried out" Tipo:"L"</summary>
		[Display(Name = "QUALIFICATION_CARRIE05255", ResourceType = typeof(Resources.Resources))]
		public bool ValQualific { get; set; }

		/// <summary>Campo : "Pre-approach" Tipo:"DT"</summary>
		[Display(Name = "PRE_APPROACH58979", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValPreabord { get; set; }

		/// <summary>Campo : "Homework done" Tipo:"L"</summary>
		[Display(Name = "HOMEWORK_DONE45166", ResourceType = typeof(Resources.Resources))]
		public bool ValHomework { get; set; }

		/// <summary>Campo : "Approach" Tipo:"DT"</summary>
		[Display(Name = "APPROACH06577", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtaborda { get; set; }

		/// <summary>Campo : "Approach made" Tipo:"L"</summary>
		[Display(Name = "APPROACH_MADE54225", ResourceType = typeof(Resources.Resources))]
		public bool ValApproach { get; set; }

		/// <summary>Campo : "Presentation made" Tipo:"DT"</summary>
		[Display(Name = "PRESENTATION_MADE15117", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtaprese { get; set; }

		/// <summary>Campo : "Presentation" Tipo:"L"</summary>
		[Display(Name = "PRESENTATION64246", ResourceType = typeof(Resources.Resources))]
		public bool ValApresent { get; set; }

		/// <summary>Campo : "Overcoming objections" Tipo:"DT"</summary>
		[Display(Name = "OVERCOMING_OBJECTION04521", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtsupera { get; set; }

		/// <summary>Campo : "Closing Attempts" Tipo:"DT"</summary>
		[Display(Name = "CLOSING_ATTEMPTS65102", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValTentfech { get; set; }

		/// <summary>Campo : "Closing of the sale" Tipo:"DT"</summary>
		[Display(Name = "CLOSING_OF_THE_SALE05493", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtvenda { get; set; }

		/// <summary>Campo : "Follow-up" Tipo:"DT"</summary>
		[Display(Name = "FOLLOW_UP22119", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtacompa { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ORGANIZATION64123", ResourceType = typeof(Resources.Resources))]
		public string ValCodorgan { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodvenda { get; set; }

		public Venda_ViewModel() : base("FVENDA") { }

		public Venda_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FVENDA", currentNavigation, nestedForm) { }

		public Venda_ViewModel(Models.Sale row, NavigationContext currentNavigation, bool nestedForm = false) : base("FVENDA", row, currentNavigation, nestedForm) { }

		public Venda_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("sale", id);
			Model = Models.Sale.Find(id, "FVENDA", fieldsToQuery: fieldsToLoad);
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
			Models.Sale model = new Models.Sale() { Identifier = "FVENDA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Sale model)
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

		public static StatusMessage DeleteConditions(Models.Sale model)
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

		public static StatusMessage ViewConditions(Models.Sale model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Sale model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Venda) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValNrlide = ViewModelConversion.ToNumeric(m.ValNrlide);
				ValStartdt = ViewModelConversion.ToDateTime(m.ValStartdt);
				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
				ValPotcompr = ViewModelConversion.ToString(m.ValPotcompr);
				ValProspecc = ViewModelConversion.ToLogic(m.ValProspecc);
				ValInteress = ViewModelConversion.ToLogic(m.ValInteress);
				ValSemrfina = ViewModelConversion.ToLogic(m.ValSemrfina);
				ValSemcapac = ViewModelConversion.ToLogic(m.ValSemcapac);
				ValDtqualif = ViewModelConversion.ToDateTime(m.ValDtqualif);
				ValQualific = ViewModelConversion.ToLogic(m.ValQualific);
				ValPreabord = ViewModelConversion.ToDateTime(m.ValPreabord);
				ValHomework = ViewModelConversion.ToLogic(m.ValHomework);
				ValDtaborda = ViewModelConversion.ToDateTime(m.ValDtaborda);
				ValApproach = ViewModelConversion.ToLogic(m.ValApproach);
				ValDtaprese = ViewModelConversion.ToDateTime(m.ValDtaprese);
				ValApresent = ViewModelConversion.ToLogic(m.ValApresent);
				ValDtsupera = ViewModelConversion.ToDateTime(m.ValDtsupera);
				ValTentfech = ViewModelConversion.ToDateTime(m.ValTentfech);
				ValDtvenda = ViewModelConversion.ToDateTime(m.ValDtvenda);
				ValDtacompa = ViewModelConversion.ToDateTime(m.ValDtacompa);
				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
				ValCodvenda = ViewModelConversion.ToString(m.ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Venda) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Venda) to Model (Sale) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValNrlide = ViewModelConversion.ToNumeric(ValNrlide);
				m.ValStartdt = ViewModelConversion.ToDateTime(ValStartdt);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValPotcompr = ViewModelConversion.ToString(ValPotcompr);
				m.ValProspecc = ViewModelConversion.ToLogic(ValProspecc);
				m.ValInteress = ViewModelConversion.ToLogic(ValInteress);
				m.ValSemrfina = ViewModelConversion.ToLogic(ValSemrfina);
				m.ValSemcapac = ViewModelConversion.ToLogic(ValSemcapac);
				m.ValDtqualif = ViewModelConversion.ToDateTime(ValDtqualif);
				m.ValQualific = ViewModelConversion.ToLogic(ValQualific);
				m.ValPreabord = ViewModelConversion.ToDateTime(ValPreabord);
				m.ValHomework = ViewModelConversion.ToLogic(ValHomework);
				m.ValDtaborda = ViewModelConversion.ToDateTime(ValDtaborda);
				m.ValApproach = ViewModelConversion.ToLogic(ValApproach);
				m.ValDtaprese = ViewModelConversion.ToDateTime(ValDtaprese);
				m.ValApresent = ViewModelConversion.ToLogic(ValApresent);
				m.ValDtsupera = ViewModelConversion.ToDateTime(ValDtsupera);
				m.ValTentfech = ViewModelConversion.ToDateTime(ValTentfech);
				m.ValDtvenda = ViewModelConversion.ToDateTime(ValDtvenda);
				m.ValDtacompa = ViewModelConversion.ToDateTime(ValDtacompa);
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValCodvenda = ViewModelConversion.ToString(ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Venda) to Model (Sale) - Error during mapping");
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Sale() { Identifier = "FVENDA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
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

			Model.Identifier = "FVENDA";
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

		protected override void LoadDocumentsProperties(Models.Sale row)
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDA");
				if (Model == null)
				{
					Model = new Models.Sale() { Identifier = "FVENDA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Venda___organorganiza(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VENDA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VENDA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE VENDA]/
		public override void Save()
		{

			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDA"); }
			finally { if (Model == null) Model = new Models.Sale() { Identifier = "FVENDA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VENDA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDA"); }
			finally { if (Model == null) Model = new Models.Sale() { Identifier = "FVENDA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VENDA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VENDA]/
		public override void Destroy(string id)
		{
			Model = Models.Sale.Find(id, "FVENDA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableOrganOrganiza -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Venda___organorganiza(NameValueCollection qs, bool lazyLoad = false)
        {
            bool venda___organorganizaDoLoad = true;
            CriteriaSet venda___organorganizaConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("organ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    venda___organorganizaConds.Equal(CSGenioAorgan.FldCodorgan, Navigation.GetValue("organ"));
                    this.ValCodorgan = Navigation.GetStrValue("organ");
                }
            }



            TableOrganOrganiza = new TableDBEdit<Models.Organ>();
            TableOrganOrganiza.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
                    this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}
                FillDependant_VendaTableOrganOrganiza(lazyLoad);
                //Check if foreignkey comes from history
                TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
                return;
            }


            if (venda___organorganizaDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableOrganOrganiza, "sTableOrganOrganiza", "dTableOrganOrganiza", qs, "organ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAorgan.FldOrganiza), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableOrganOrganiza_tableFilters"]))
                    TableOrganOrganiza.TableFilters = bool.Parse(qs["TableOrganOrganiza_tableFilters"]);
                else
                    TableOrganOrganiza.TableFilters = false;

                query = qs["qTableOrganOrganiza"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAorgan.FldOrganiza, query + "%");
                }
                venda___organorganizaConds.SubSet(search_filters);


                string tryParsePage = qs["pTableOrganOrganiza"] != null ? qs["pTableOrganOrganiza"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza, CSGenioAorgan.FldZzstate };

// USE /[MANUAL GQT OVERRQ VENDA_ORGANORGANIZA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("organ", FormMode.New) || Navigation.checkFormMode("organ", FormMode.Duplicate))
                    venda___organorganizaConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAorgan.FldZzstate, 0)
                        .Equal(CSGenioAorgan.FldCodorgan, Navigation.GetStrValue("organ")));
                else
                    venda___organorganizaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAorgan.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //venda___organorganizaConds = Organ.AddEPH<CSGenioAorgan>(ref UserContext.Current.User, venda___organorganizaConds, "LED_VENDA___ORGANORGANIZA");

                FieldRef firstVisibleColumn = new FieldRef("organ", "organiza");
                ListingMVC<CSGenioAorgan> listing = Models.ModelBase.Where<CSGenioAorgan>(false, venda___organorganizaConds, fields, offset, numberItems, sorts, "LED_VENDA___ORGANORGANIZA", true, false, firstVisibleColumn: firstVisibleColumn);

                TableOrganOrganiza.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableOrganOrganiza.Query = query;
                TableOrganOrganiza.Elements = listing.RowsForViewModel<GenioMVC.Models.Organ>((r) => new GenioMVC.Models.Organ(r, true, _fieldsToSerialize_VENDA___ORGANORGANIZA));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_organ") != null)
				{
					this.ValCodorgan = Navigation.GetStrValue("RETURN_organ");
					Navigation.CurrentLevel.SetEntry("RETURN_organ", null);
				}

				TableOrganOrganiza.List = new SelectList(TableOrganOrganiza.Elements.ToSelectList(x => x.ValOrganiza, x => x.ValCodorgan,  x => x.ValCodorgan == this.ValCodorgan), "Value", "Text", this.ValCodorgan);
                if(!isSearchRequest)
                    FillDependant_VendaTableOrganOrganiza();

                //Check if foreignkey comes from history
                TableOrganOrganiza.FilledByHistory = Navigation.CheckFilledByHistory("organ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableOrganOrganiza (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Organ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_VendaTableOrganOrganiza(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "organ.codorgan", "organ.organiza" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAorgan.FldCodorgan, CSGenioAorgan.FldOrganiza };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GenFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAorgan tempArea = new CSGenioAorgan(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAorgan.FldCodorgan, PKey));
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
        /// Fill Dependant fields values -> TableOrganOrganiza (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_VendaTableOrganOrganiza(bool lazyLoad = false)
        {
            var row = GetDependant_VendaTableOrganOrganiza(this.ValCodorgan, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodorgan = ViewModelConversion.ToString(row["organ.codorgan"]);
                TableOrganOrganiza.Value = ViewModelConversion.ToString(row["organ.organiza"]);
                if (GenFunctions.emptyG(this.ValCodorgan) == 1)
                {
                    this.ValCodorgan = "";
                    TableOrganOrganiza.Value = "";
                    Navigation.ClearValue("organ");
                }
                else if (lazyLoad)
                {
                    TableOrganOrganiza.SetPagination(1, 0, false, false, 1);
                    TableOrganOrganiza.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodorgan),
                            Text = Convert.ToString(TableOrganOrganiza.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodorgan);
                }
                TableOrganOrganiza.Selected = this.ValCodorgan;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOrganOrganiza): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_VENDA___ORGANORGANIZA = { "Organ", "Organ.ValCodorgan", "Organ.ValZzstate", "Organ.ValOrganiza" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM VENDA]/
		#endregion
	}
}
