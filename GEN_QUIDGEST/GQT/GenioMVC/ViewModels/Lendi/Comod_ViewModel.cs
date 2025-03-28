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

namespace GenioMVC.ViewModels.Lendi
{
	public class Comod_ViewModel : FormViewModel<Models.Lendi>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Lending" Tipo:"C"</summary>
		[Display(Name = "LENDING18782", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess1>  TablePess1Name { get; set; }

		/// <summary>Campo : "Borrower:" Tipo:"C"</summary>
		[Display(Name = "BORROWER_22692", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess2>  TablePess2Name { get; set; }

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "Equipment" Tipo:"C"</summary>
		[Display(Name = "EQUIPMENT03632", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string EquipValDesignat { get { return funcEquipValDesignat != null ? funcEquipValDesignat() : _auxEquipValDesignat; } set { funcEquipValDesignat = () => value; } }
		[JsonIgnore]
		public Func<string> funcEquipValDesignat { get; set; }
		private string _auxEquipValDesignat { get; set; }

		/// <summary>Campo : "Loan Frequency" Tipo:"AN"</summary>
		[Display(Name = "LOAN_FREQUENCY00930", ResourceType = typeof(Resources.Resources))]
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? EquipValFrequenc { get { return funcEquipValFrequenc != null ? funcEquipValFrequenc() : _auxEquipValFrequenc; } set { funcEquipValFrequenc = () => value; } }
		[JsonIgnore]
		public SelectList List_EquipValFrequenc { get; set; }
		[JsonIgnore]
		public Func<decimal?> funcEquipValFrequenc { get; set; }
		private decimal? _auxEquipValFrequenc { get; set; }

		/// <summary>Campo : "Lending No" Tipo:"N"</summary>
		[Display(Name = "LENDING_NO14727", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValLendinnr { get; set; }

		/// <summary>Campo : "Start:" Tipo:"DT"</summary>
		[Display(Name = "START_59353", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValStart { get; set; }

		/// <summary>Campo : "Warning" Tipo:"DT"</summary>
		[Display(Name = "WARNING52043", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("DT")]
		public DateTime? ValWarndt { get; set; }

		/// <summary>Campo : "End" Tipo:"DT"</summary>
		[Display(Name = "END47577", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get; set; }

		/// <summary>Campo : "Observation" Tipo:"MO"</summary>
		[Display(Name = "OBSERVATION37880", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValObservat { get; set; }

		/// <summary>Campo : "Returned" Tipo:"D"</summary>
		[Display(Name = "RETURNED01606", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValReturndt { get; set; }

		/// <summary>Campo : "Returned" Tipo:"L"</summary>
		[Display(Name = "RETURNED01606", ResourceType = typeof(Resources.Resources))]
		public bool ValReturned { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		[Display(Name = "LENDING18782", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess1 { get; set; }

		[Display(Name = "BORROWER_22692", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess2 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlendi { get; set; }

		public Comod_ViewModel() : base("FCOMOD") { }

		public Comod_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCOMOD", currentNavigation, nestedForm) { }

		public Comod_ViewModel(Models.Lendi row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCOMOD", row, currentNavigation, nestedForm) { }

		public Comod_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("lendi", id);
			Model = Models.Lendi.Find(id, "FCOMOD", fieldsToQuery: fieldsToLoad);
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
			Models.Lendi model = new Models.Lendi() { Identifier = "FCOMOD" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Lendi model)
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

		public static StatusMessage DeleteConditions(Models.Lendi model)
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

		public static StatusMessage ViewConditions(Models.Lendi model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Lendi model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lendi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (Comod) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				funcEquipValDesignat = () => ViewModelConversion.ToString(m.Equip.ValDesignat);
				funcEquipValFrequenc = () => ViewModelConversion.ToNumeric(m.Equip.ValFrequenc);
				ValLendinnr = ViewModelConversion.ToNumeric(m.ValLendinnr);
				ValStart = ViewModelConversion.ToDateTime(m.ValStart);
				ValWarndt = ViewModelConversion.ToDateTime(m.ValWarndt);
				ValEnd = ViewModelConversion.ToDateTime(m.ValEnd);
				ValObservat = ViewModelConversion.ToString(m.ValObservat);
				ValReturndt = ViewModelConversion.ToDateTime(m.ValReturndt);
				ValReturned = ViewModelConversion.ToLogic(m.ValReturned);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodpess2 = ViewModelConversion.ToString(m.ValCodpess2);
				ValCodlendi = ViewModelConversion.ToString(m.ValCodlendi);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (Comod) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lendi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Comod) to Model (Lendi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValLendinnr = ViewModelConversion.ToNumeric(ValLendinnr);
				m.ValStart = ViewModelConversion.ToDateTime(ValStart);
				m.ValWarndt = ViewModelConversion.ToDateTime(ValWarndt);
				m.ValEnd = ViewModelConversion.ToDateTime(ValEnd);
				m.ValObservat = ViewModelConversion.ToString(ValObservat);
				m.ValReturndt = ViewModelConversion.ToDateTime(ValReturndt);
				m.ValReturned = ViewModelConversion.ToLogic(ValReturned);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodpess2 = ViewModelConversion.ToString(ValCodpess2);
				m.ValCodlendi = ViewModelConversion.ToString(ValCodlendi);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Comod) to Model (Lendi) - Error during mapping");
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
				Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), "FCOMOD");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Lendi() { Identifier = "FCOMOD" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("lendi");
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

			Model.Identifier = "FCOMOD";
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

		protected override void LoadDocumentsProperties(Models.Lendi row)
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
				Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), "FCOMOD");
				if (Model == null)
				{
					Model = new Models.Lendi() { Identifier = "FCOMOD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lendi");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Comod___pess1name____(qs, lazyLoad);
			Load_Comod___pess2name____(qs, lazyLoad);
			Load_Comod___equipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL COMOD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW COMOD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE COMOD]/
		public override void Save()
		{

			try { Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), "FCOMOD"); }
			finally { if (Model == null) Model = new Models.Lendi() { Identifier = "FCOMOD" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY COMOD]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), "FCOMOD"); }
			finally { if (Model == null) Model = new Models.Lendi() { Identifier = "FCOMOD" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE COMOD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY COMOD]/
		public override void Destroy(string id)
		{
			Model = Models.Lendi.Find(id, "FCOMOD");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_EquipValFrequenc = new SelectList(
				ArrayFreqempr.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.EquipValFrequenc);
		}


        /// <summary>
        /// TablePess1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Comod___pess1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool comod___pess1name____DoLoad = true;
            CriteriaSet comod___pess1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    comod___pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, Navigation.GetValue("pess1"));
                    this.ValCodpess1 = Navigation.GetStrValue("pess1");
                }
            }



            TablePess1Name = new TableDBEdit<Models.Pess1>();
            TablePess1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
                    this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
                FillDependant_ComodTablePess1Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
                return;
            }


            if (comod___pess1name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
                    TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
                else
                    TablePess1Name.TableFilters = false;

                query = qs["qTablePess1Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApess1.FldName, query + "%");
                }
                comod___pess1name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_PESS1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
                    comod___pess1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess1.FldZzstate, 0)
                        .Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
                else
                    comod___pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //comod___pess1name____Conds = Pess1.AddEPH<CSGenioApess1>(ref UserContext.Current.User, comod___pess1name____Conds, "LED_COMOD___PESS1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
                ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, comod___pess1name____Conds, fields, offset, numberItems, sorts, "LED_COMOD___PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess1Name.Query = query;
                TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(r, true, _fieldsToSerialize_COMOD___PESS1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
                if(!isSearchRequest)
                    FillDependant_ComodTablePess1Name();

                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ComodTablePess1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess1.codpesso", "pess1.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName };
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
            CSGenioApess1 tempArea = new CSGenioApess1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ComodTablePess1Name(bool lazyLoad = false)
        {
            var row = GetDependant_ComodTablePess1Name(this.ValCodpess1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
                TablePess1Name.Value = ViewModelConversion.ToString(row["pess1.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpess1) == 1)
                {
                    this.ValCodpess1 = "";
                    TablePess1Name.Value = "";
                    Navigation.ClearValue("pess1");
                }
                else if (lazyLoad)
                {
                    TablePess1Name.SetPagination(1, 0, false, false, 1);
                    TablePess1Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpess1),
                            Text = Convert.ToString(TablePess1Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpess1);
                }
                TablePess1Name.Selected = this.ValCodpess1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_COMOD___PESS1NAME____ = { "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName" };

        /// <summary>
        /// TablePess2Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Comod___pess2name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool comod___pess2name____DoLoad = true;
            CriteriaSet comod___pess2name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess2", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    comod___pess2name____Conds.Equal(CSGenioApess2.FldCodpesso, Navigation.GetValue("pess2"));
                    this.ValCodpess2 = Navigation.GetStrValue("pess2");
                }
            }



            TablePess2Name = new TableDBEdit<Models.Pess2>();
            TablePess2Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
                    this.ValCodpess2 = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}
                FillDependant_ComodTablePess2Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess2Name.FilledByHistory = Navigation.CheckFilledByHistory("pess2");
                return;
            }


            if (comod___pess2name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess2Name, "sTablePess2Name", "dTablePess2Name", qs, "pess2");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess2.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess2Name_tableFilters"]))
                    TablePess2Name.TableFilters = bool.Parse(qs["TablePess2Name_tableFilters"]);
                else
                    TablePess2Name.TableFilters = false;

                query = qs["qTablePess2Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApess2.FldName, query + "%");
                }
                comod___pess2name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePess2Name"] != null ? qs["pTablePess2Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioApess2.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_PESS2NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess2", FormMode.New) || Navigation.checkFormMode("pess2", FormMode.Duplicate))
                    comod___pess2name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess2.FldZzstate, 0)
                        .Equal(CSGenioApess2.FldCodpesso, Navigation.GetStrValue("pess2")));
                else
                    comod___pess2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess2.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //comod___pess2name____Conds = Pess2.AddEPH<CSGenioApess2>(ref UserContext.Current.User, comod___pess2name____Conds, "LED_COMOD___PESS2NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess2", "name");
                ListingMVC<CSGenioApess2> listing = Models.ModelBase.Where<CSGenioApess2>(false, comod___pess2name____Conds, fields, offset, numberItems, sorts, "LED_COMOD___PESS2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess2Name.Query = query;
                TablePess2Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess2>((r) => new GenioMVC.Models.Pess2(r, true, _fieldsToSerialize_COMOD___PESS2NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpess2 = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}

				TablePess2Name.List = new SelectList(TablePess2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess2), "Value", "Text", this.ValCodpess2);
                if(!isSearchRequest)
                    FillDependant_ComodTablePess2Name();

                //Check if foreignkey comes from history
                TablePess2Name.FilledByHistory = Navigation.CheckFilledByHistory("pess2");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess2Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess2</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ComodTablePess2Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess2.codpesso", "pess2.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };
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
            CSGenioApess2 tempArea = new CSGenioApess2(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess2.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePess2Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ComodTablePess2Name(bool lazyLoad = false)
        {
            var row = GetDependant_ComodTablePess2Name(this.ValCodpess2, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpess2 = ViewModelConversion.ToString(row["pess2.codpesso"]);
                TablePess2Name.Value = ViewModelConversion.ToString(row["pess2.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpess2) == 1)
                {
                    this.ValCodpess2 = "";
                    TablePess2Name.Value = "";
                    Navigation.ClearValue("pess2");
                }
                else if (lazyLoad)
                {
                    TablePess2Name.SetPagination(1, 0, false, false, 1);
                    TablePess2Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpess2),
                            Text = Convert.ToString(TablePess2Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpess2);
                }
                TablePess2Name.Selected = this.ValCodpess2;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_COMOD___PESS2NAME____ = { "Pess2", "Pess2.ValCodpesso", "Pess2.ValZzstate", "Pess2.ValName" };

        /// <summary>
        /// TableEquipRegistnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Comod___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool comod___equipregistnrDoLoad = true;
            CriteriaSet comod___equipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    comod___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
                    this.ValCodequip = Navigation.GetStrValue("equip");
                }
            }

			// Limits Generation

			// Area limit
			comod___equipregistnrDoLoad &= AddCriteriaAreaLimit(comod___equipregistnrConds, CSGenio.business.CSGenioApess1.FldCodpesso, "pess1", this.ValCodpess1, true);


            TableEquipRegistnr = new TableDBEdit<Models.Equip>();
            TableEquipRegistnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
                    this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
                FillDependant_ComodTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodpess1))
                comod___equipregistnrDoLoad = false;

            if (comod___equipregistnrDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEquipRegistnr_tableFilters"]))
                    TableEquipRegistnr.TableFilters = bool.Parse(qs["TableEquipRegistnr_tableFilters"]);
                else
                    TableEquipRegistnr.TableFilters = false;

                query = qs["qTableEquipRegistnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
                }
                comod___equipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldDtdeco, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    comod___equipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    comod___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //comod___equipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, comod___equipregistnrConds, "LED_COMOD___EQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, comod___equipregistnrConds, fields, offset, numberItems, sorts, "LED_COMOD___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_COMOD___EQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                if(!isSearchRequest)
                    FillDependant_ComodTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ComodTableEquipRegistnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "equip.codequip", "equip.registnr", "equip.designat", "equip.frequenc" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldFrequenc };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("pess1");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAequip.FldCodpess1, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAequip tempArea = new CSGenioAequip(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAequip.FldCodequip, PKey));
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
        /// Fill Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ComodTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_ComodTableEquipRegistnr(this.ValCodequip, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["equip.designat"]);
                    this.funcEquipValDesignat = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["equip.frequenc"]);
                    this.funcEquipValFrequenc = () => tempValue;
                }

                // Fill List fields
                this.ValCodequip = ViewModelConversion.ToString(row["equip.codequip"]);
                TableEquipRegistnr.Value = ViewModelConversion.ToString(row["equip.registnr"]);
                if (GlobalFunctions.emptyG(this.ValCodequip) == 1)
                {
                    this.ValCodequip = "";
                    TableEquipRegistnr.Value = "";
                    Navigation.ClearValue("equip");
                }
                else if (lazyLoad)
                {
                    TableEquipRegistnr.SetPagination(1, 0, false, false, 1);
                    TableEquipRegistnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodequip),
                            Text = Convert.ToString(TableEquipRegistnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodequip);
                }
                TableEquipRegistnr.Selected = this.ValCodequip;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEquipRegistnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_COMOD___EQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Tpequ", "Tpequ.ValTipoequi", "Equip.ValDesignat", "Equip.ValDtaquisi", "Equip.ValDtdeco", "Equip.ValPhotogra", "Equip.ValValortot" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM COMOD]/
		#endregion
	}
}
