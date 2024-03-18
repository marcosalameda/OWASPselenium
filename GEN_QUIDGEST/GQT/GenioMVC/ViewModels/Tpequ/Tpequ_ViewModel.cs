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

namespace GenioMVC.ViewModels.Tpequ
{
	public class Tpequ_ViewModel : FormViewModel<Models.Tpequ>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Equipment family" Tipo:"C"</summary>
		[Display(Name = "EQUIPMENT_FAMILY41883", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Famil>  TableFamilFamily { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTipoequi { get; set; }

		/// <summary>Campo : "Code" Tipo:"TF"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTpequcod { get; set; }

		/// <summary>Campo : "Level:" Tipo:"TN"</summary>
		[Display(Name = "LEVEL_43678", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public double ValNivel { get; set; }

		/// <summary>Campo : "Kit" Tipo:"L"</summary>
		[Display(Name = "KIT27179", ResourceType = typeof(Resources.Resources))]
		public bool ValKit { get; set; }

		/// <summary>Campo : "Maximum Price" Tipo:"$D"</summary>
		[Display(Name = "MAXIMUM_PRICE26470", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get; set; }

		/// <summary>Campo : "Background Color" Tipo:"C"</summary>
		[Display(Name = "BACKGROUND_COLOR07511", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBackcolo { get; set; }

		/// <summary>Campo : "Letter Color" Tipo:"C"</summary>
		[Display(Name = "LETTER_COLOR63305", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCorletra { get; set; }

		/// <summary>Campo : "Dependence on" Tipo:"TP"</summary>
		[Display(Name = "DEPENDENCE_ON13941", ResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTpequpai { get; set; }

		/// <summary>Campo : "Last Price" Tipo:"$D"</summary>
		[Display(Name = "LAST_PRICE56195", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get; set; }

		/// <summary>Campo : "Since" Tipo:"DT"</summary>
		[Display(Name = "SINCE47259", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("DT")]
		public DateTime? ValSince { get; set; }

		/// <summary>Campo : "Componentes do kit" Tipo:"DP"</summary>
		[Display(Name = "COMPONENTES_DO_KIT59823", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Cmpki> ValComponen { get; set; }

		/// <summary>Campo : "c" Tipo:"DP"</summary>
		[Display(Name = "C51806", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Tabpr> ValEvolucao { get; set; }


		/// <summary>Campo : "Facilities:" Tipo:"DP"</summary>
		[Display(Name = "FACILITIES_23844", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstalac { get; set; }

		/// <summary>Campo : "Map with facilities:" Tipo:"DP"</summary>
		[Display(Name = "MAP_WITH_FACILITIES_33619", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstala1 { get; set; }

		/// <summary>Campo : "Quantity of equipment:" Tipo:"N"</summary>
		[Display(Name = "QUANTITY_OF_EQUIPMEN09806", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "EQUIPMENT_FAMILY41883", ResourceType = typeof(Resources.Resources))]
		public string ValCodfamil { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtpequ { get; set; }

		public Tpequ_ViewModel() : base("FTPEQU") { }

		public Tpequ_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTPEQU", currentNavigation, nestedForm) { }

		public Tpequ_ViewModel(Models.Tpequ row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTPEQU", row, currentNavigation, nestedForm) { }

		public Tpequ_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tpequ", id);
			Model = Models.Tpequ.Find(id, "FTPEQU", fieldsToQuery: fieldsToLoad);
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
			Models.Tpequ model = new Models.Tpequ() { Identifier = "FTPEQU" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tpequ model)
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

		public static StatusMessage DeleteConditions(Models.Tpequ model)
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

		public static StatusMessage ViewConditions(Models.Tpequ model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tpequ model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Tpequ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTipoequi = ViewModelConversion.ToString(m.ValTipoequi);
 				ValTpequcod = ViewModelConversion.ToString(m.ValTpequcod);
 				ValNivel = ViewModelConversion.ToDouble(m.ValNivel);
 				ValKit = ViewModelConversion.ToLogic(m.ValKit);
 				ValPrecomax = ViewModelConversion.ToNumeric(m.ValPrecomax);
 				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
 				ValCorletra = ViewModelConversion.ToString(m.ValCorletra);
 				ValTpequpai = ViewModelConversion.ToString(m.ValTpequpai);
 				ValPrecoult = ViewModelConversion.ToNumeric(m.ValPrecoult);
 				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
 				ValQtdequip = ViewModelConversion.ToNumeric(m.ValQtdequip);
 				ValCodfamil = ViewModelConversion.ToString(m.ValCodfamil);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Tpequ) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpequ) to Model (Tpequ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTipoequi = ViewModelConversion.ToString(ValTipoequi);
				m.ValTpequcod = ViewModelConversion.ToString(ValTpequcod);
				m.ValNivel = ViewModelConversion.ToDouble(ValNivel);
				m.ValKit = ViewModelConversion.ToLogic(ValKit);
				m.ValPrecomax = ViewModelConversion.ToNumeric(ValPrecomax);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
				m.ValCorletra = ViewModelConversion.ToString(ValCorletra);
				m.ValTpequpai = ViewModelConversion.ToString(ValTpequpai);
				m.ValPrecoult = ViewModelConversion.ToNumeric(ValPrecoult);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValQtdequip = ViewModelConversion.ToNumeric(ValQtdequip);
				m.ValCodfamil = ViewModelConversion.ToString(ValCodfamil);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpequ) to Model (Tpequ) - Error during mapping");
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
				Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), "FTPEQU");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tpequ() { Identifier = "FTPEQU" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");
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

			Model.Identifier = "FTPEQU";
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

		protected override void LoadDocumentsProperties(Models.Tpequ row)
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
				Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), "FTPEQU");
				if (Model == null)
				{
					Model = new Models.Tpequ() { Identifier = "FTPEQU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tpequ___familfamily__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPEQU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPEQU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPEQU]/
		public override void Save()
		{

			try { Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), "FTPEQU"); }
			finally { if (Model == null) Model = new Models.Tpequ() { Identifier = "FTPEQU" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPEQU]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), "FTPEQU"); }
			finally { if (Model == null) Model = new Models.Tpequ() { Identifier = "FTPEQU" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPEQU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPEQU]/
		public override void Destroy(string id)
		{
			Model = Models.Tpequ.Find(id, "FTPEQU");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableFamilFamily -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tpequ___familfamily__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tpequ___familfamily__DoLoad = true;
            CriteriaSet tpequ___familfamily__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("famil", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tpequ___familfamily__Conds.Equal(CSGenioAfamil.FldCodfamil, Navigation.GetValue("famil"));
                    this.ValCodfamil = Navigation.GetStrValue("famil");
                }
            }



            TableFamilFamily = new TableDBEdit<Models.Famil>();
            TableFamilFamily.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_famil") != null)
				{
                    this.ValCodfamil = Navigation.GetStrValue("RETURN_famil");
					Navigation.CurrentLevel.SetEntry("RETURN_famil", null);
				}
                FillDependant_TpequTableFamilFamily(lazyLoad);
                //Check if foreignkey comes from history
                TableFamilFamily.FilledByHistory = Navigation.CheckFilledByHistory("famil");
                return;
            }


            if (tpequ___familfamily__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFamilFamily, "sTableFamilFamily", "dTableFamilFamily", qs, "famil");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfamil.FldFamily), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFamilFamily_tableFilters"]))
                    TableFamilFamily.TableFilters = bool.Parse(qs["TableFamilFamily_tableFilters"]);
                else
                    TableFamilFamily.TableFilters = false;

                query = qs["qTableFamilFamily"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfamil.FldFamily, query + "%");
                }
                tpequ___familfamily__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFamilFamily"] != null ? qs["pTableFamilFamily"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAfamil.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPEQU_FAMILFAMILY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("famil", FormMode.New) || Navigation.checkFormMode("famil", FormMode.Duplicate))
                    tpequ___familfamily__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfamil.FldZzstate, 0)
                        .Equal(CSGenioAfamil.FldCodfamil, Navigation.GetStrValue("famil")));
                else
                    tpequ___familfamily__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfamil.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tpequ___familfamily__Conds = Famil.AddEPH<CSGenioAfamil>(ref UserContext.Current.User, tpequ___familfamily__Conds, "LED_TPEQU___FAMILFAMILY__");

                FieldRef firstVisibleColumn = new FieldRef("famil", "family");
                ListingMVC<CSGenioAfamil> listing = Models.ModelBase.Where<CSGenioAfamil>(false, tpequ___familfamily__Conds, fields, offset, numberItems, sorts, "LED_TPEQU___FAMILFAMILY__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFamilFamily.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFamilFamily.Query = query;
                TableFamilFamily.Elements = listing.RowsForViewModel<GenioMVC.Models.Famil>((r) => new GenioMVC.Models.Famil(r, true, _fieldsToSerialize_TPEQU___FAMILFAMILY__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_famil") != null)
				{
					this.ValCodfamil = Navigation.GetStrValue("RETURN_famil");
					Navigation.CurrentLevel.SetEntry("RETURN_famil", null);
				}

				TableFamilFamily.List = new SelectList(TableFamilFamily.Elements.ToSelectList(x => x.ValFamily, x => x.ValCodfamil,  x => x.ValCodfamil == this.ValCodfamil), "Value", "Text", this.ValCodfamil);
                FillDependant_TpequTableFamilFamily();

                //Check if foreignkey comes from history
                TableFamilFamily.FilledByHistory = Navigation.CheckFilledByHistory("famil");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFamilFamily (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Famil</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TpequTableFamilFamily(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "famil.codfamil", "famil.family" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily };
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
            CSGenioAfamil tempArea = new CSGenioAfamil(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfamil.FldCodfamil, PKey));
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
        /// Fill Dependant fields values -> TableFamilFamily (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TpequTableFamilFamily(bool lazyLoad = false)
        {
            var row = GetDependant_TpequTableFamilFamily(this.ValCodfamil, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodfamil = ViewModelConversion.ToString(row["famil.codfamil"]);
                TableFamilFamily.Value = ViewModelConversion.ToString(row["famil.family"]);
                if (GlobalFunctions.emptyG(this.ValCodfamil) == 1)
                {
                    this.ValCodfamil = "";
                    TableFamilFamily.Value = "";
                    Navigation.ClearValue("famil");
                }
                else if (lazyLoad)
                {
                    TableFamilFamily.SetPagination(1, 0, false, false, 1);
                    TableFamilFamily.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodfamil),
                            Text = Convert.ToString(TableFamilFamily.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodfamil);
                }
                TableFamilFamily.Selected = this.ValCodfamil;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFamilFamily): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TPEQU___FAMILFAMILY__ = { "Famil", "Famil.ValCodfamil", "Famil.ValZzstate", "Famil.ValFamily" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPEQU]/
		#endregion
	}
}
