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

namespace GenioMVC.ViewModels.Insta
{
	public class Leaflett_ViewModel : FormViewModel<Models.Insta>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "" Tipo:"C"</summary>
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string TpequValTipoequi { get { return funcTpequValTipoequi != null ? funcTpequValTipoequi() : _auxTpequValTipoequi; } set { funcTpequValTipoequi = () => value; } }
		[JsonIgnore]
		public Func<string> funcTpequValTipoequi { get; set; }
		private string _auxTpequValTipoequi { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "Scheduling" Tipo:"C"</summary>
		[Display(Name = "SCHEDULING24801", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Start" Tipo:"DT"</summary>
		[Display(Name = "START00919", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtiniage { get; set; }

		/// <summary>Campo : "End" Tipo:"DT"</summary>
		[Display(Name = "END47577", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtfimage { get; set; }

		/// <summary>Campo : "All day" Tipo:"L"</summary>
		[Display(Name = "ALL_DAY18496", ResourceType = typeof(Resources.Resources))]
		public bool ValAllday { get; set; }

		/// <summary>Campo : "Since" Tipo:"DT"</summary>
		[Display(Name = "SINCE47259", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValSince { get; set; }

		/// <summary>Campo : "Until" Tipo:"DT"</summary>
		[Display(Name = "UNTIL39173", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValUntil { get; set; }

		/// <summary>Campo : "Quantity of hours:" Tipo:"N"</summary>
		[Display(Name = "QUANTITY_OF_HOURS_61426", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValHours { get; set; }

		/// <summary>Campo : "Price per hour:" Tipo:"$D"</summary>
		[Display(Name = "PRICE_PER_HOUR_37472", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecohor { get; set; }

		/// <summary>Campo : "Value" Tipo:"$D"</summary>
		[Display(Name = "VALUE10285", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get; set; }

		/// <summary>Campo : "Geographic Coordinates" Tipo:"GG"</summary>
		[Display(Name = "GEOGRAPHIC_COORDINAT42880", ResourceType = typeof(Resources.Resources))]
		[UIHint("Leaflet")]
		public string ValCoordgeo { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		public string ValCodtpequ { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodinsta { get; set; }

		public Leaflett_ViewModel() : base("FLEAFLETT") { }

		public Leaflett_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLEAFLETT", currentNavigation, nestedForm) { }

		public Leaflett_ViewModel(Models.Insta row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLEAFLETT", row, currentNavigation, nestedForm) { }

		public Leaflett_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("insta", id);
			Model = Models.Insta.Find(id, "FLEAFLETT", fieldsToQuery: fieldsToLoad);
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
			Models.Insta model = new Models.Insta() { Identifier = "FLEAFLETT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Insta model)
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

		public static StatusMessage DeleteConditions(Models.Insta model)
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

		public static StatusMessage ViewConditions(Models.Insta model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Insta model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				funcTpequValTipoequi = () => ViewModelConversion.ToString(m.Tpequ.ValTipoequi);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValDtiniage = ViewModelConversion.ToDateTime(m.ValDtiniage);
 				ValDtfimage = ViewModelConversion.ToDateTime(m.ValDtfimage);
 				ValAllday = ViewModelConversion.ToLogic(m.ValAllday);
 				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
 				ValUntil = ViewModelConversion.ToDateTime(m.ValUntil);
 				ValHours = ViewModelConversion.ToNumeric(m.ValHours);
 				ValPrecohor = ViewModelConversion.ToNumeric(m.ValPrecohor);
 				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
 				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodinsta = ViewModelConversion.ToString(m.ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Leaflett) to Model (Insta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValDtiniage = ViewModelConversion.ToDateTime(ValDtiniage);
				m.ValDtfimage = ViewModelConversion.ToDateTime(ValDtfimage);
				m.ValAllday = ViewModelConversion.ToLogic(ValAllday);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValUntil = ViewModelConversion.ToDateTime(ValUntil);
				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValPrecohor = ViewModelConversion.ToNumeric(ValPrecohor);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodinsta = ViewModelConversion.ToString(ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Leaflett) to Model (Insta) - Error during mapping");
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
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), "FLEAFLETT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Insta() { Identifier = "FLEAFLETT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("insta");
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

			Model.Identifier = "FLEAFLETT";
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

		protected override void LoadDocumentsProperties(Models.Insta row)
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
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), "FLEAFLETT");
				if (Model == null)
				{
					Model = new Models.Insta() { Identifier = "FLEAFLETT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("insta");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Leaflettequipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LEAFLETT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LEAFLETT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LEAFLETT]/
		public override void Save()
		{

			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), "FLEAFLETT"); }
			finally { if (Model == null) Model = new Models.Insta() { Identifier = "FLEAFLETT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LEAFLETT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), "FLEAFLETT"); }
			finally { if (Model == null) Model = new Models.Insta() { Identifier = "FLEAFLETT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LEAFLETT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LEAFLETT]/
		public override void Destroy(string id)
		{
			Model = Models.Insta.Find(id, "FLEAFLETT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableEquipRegistnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Leaflettequipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool leaflettequipregistnrDoLoad = true;
            CriteriaSet leaflettequipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    leaflettequipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
                    this.ValCodequip = Navigation.GetStrValue("equip");
                }
            }

			// Limits Generation

			// Area limit
			leaflettequipregistnrDoLoad &= AddCriteriaAreaLimit(leaflettequipregistnrConds, CSGenio.business.CSGenioAtpequ.FldCodtpequ, "tpequ", this.ValCodtpequ, true);


            TableEquipRegistnr = new TableDBEdit<Models.Equip>();
            TableEquipRegistnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
                    this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
                FillDependant_LeaflettTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodtpequ))
                leaflettequipregistnrDoLoad = false;

            if (leaflettequipregistnrDoLoad)
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
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
                }
                leaflettequipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ LEAFLETT_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    leaflettequipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    leaflettequipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //leaflettequipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, leaflettequipregistnrConds, "LED_LEAFLETTEQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, leaflettequipregistnrConds, fields, offset, numberItems, sorts, "LED_LEAFLETTEQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_LEAFLETTEQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                FillDependant_LeaflettTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LeaflettTableEquipRegistnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "equip.codequip", "equip.registnr", "tpequ.codtpequ", "tpequ.tipoequi" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("tpequ");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAequip.FldCodtpequ, hValue);
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
        public void FillDependant_LeaflettTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_LeaflettTableEquipRegistnr(this.ValCodequip, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
                {
                    var tempValue = ViewModelConversion.ToString(row["tpequ.tipoequi"]);
                    this.funcTpequValTipoequi = () => tempValue;
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


        private readonly string[] _fieldsToSerialize_LEAFLETTEQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LEAFLETT]/
		#endregion
	}
}
