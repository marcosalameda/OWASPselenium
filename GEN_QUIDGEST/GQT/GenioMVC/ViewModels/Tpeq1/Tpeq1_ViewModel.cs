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

namespace GenioMVC.ViewModels.Tpeq1
{
	public class Tpeq1_ViewModel : FormViewModel<Models.Tpeq1>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Equipment family" Tipo:"C"</summary>
		[Display(Name = "EQUIPMENT_FAMILY41883", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Fami1>  TableFami1Family { get; set; }

		/// <summary>Campo : "Code" Tipo:"TF"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTpequcod { get; set; }

		/// <summary>Campo : "Level:" Tipo:"TN"</summary>
		[Display(Name = "LEVEL_43678", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public decimal ValNivel { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTipoequi { get; set; }

		/// <summary>Campo : "Dependence on" Tipo:"TP"</summary>
		[Display(Name = "DEPENDENCE_ON13941", ResourceType = typeof(Resources.Resources))]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTpequpai { get; set; }

		/// <summary>Campo : "Background Color" Tipo:"C"</summary>
		[Display(Name = "BACKGROUND_COLOR07511", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBackcolo { get; set; }

		/// <summary>Campo : "Letter Color:" Tipo:"C"</summary>
		[Display(Name = "LETTER_COLOR_03195", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCorletra { get; set; }

		/// <summary>Campo : "Maximum Price" Tipo:"$D"</summary>
		[Display(Name = "MAXIMUM_PRICE26470", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get; set; }

		/// <summary>Campo : "Last price" Tipo:"$D"</summary>
		[Display(Name = "LAST_PRICE25852", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get; set; }

		/// <summary>Campo : "In" Tipo:"DT"</summary>
		[Display(Name = "IN34902", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValSince { get; set; }

		/// <summary>Campo : "Quantity" Tipo:"N"</summary>
		[Display(Name = "QUANTITY06415", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get; set; }

		/// <summary>Campo : "Kit" Tipo:"L"</summary>
		[Display(Name = "KIT27179", ResourceType = typeof(Resources.Resources))]
		public bool ValKit { get; set; }


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

		public Tpeq1_ViewModel() : base("FTPEQ1") { }

		public Tpeq1_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTPEQ1", currentNavigation, nestedForm) { }

		public Tpeq1_ViewModel(Models.Tpeq1 row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTPEQ1", row, currentNavigation, nestedForm) { }

		public Tpeq1_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tpeq1", id);
			Model = Models.Tpeq1.Find(id, "FTPEQ1", fieldsToQuery: fieldsToLoad);
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
			Models.Tpeq1 model = new Models.Tpeq1() { Identifier = "FTPEQ1" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tpeq1 model)
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

		public static StatusMessage DeleteConditions(Models.Tpeq1 model)
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

		public static StatusMessage ViewConditions(Models.Tpeq1 model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tpeq1 model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tpeq1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpeq1) to ViewModel (Tpeq1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTpequcod = ViewModelConversion.ToString(m.ValTpequcod);
 				ValNivel = ViewModelConversion.ToNumeric(m.ValNivel);
 				ValTipoequi = ViewModelConversion.ToString(m.ValTipoequi);
 				ValTpequpai = ViewModelConversion.ToString(m.ValTpequpai);
 				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
 				ValCorletra = ViewModelConversion.ToString(m.ValCorletra);
 				ValPrecomax = ViewModelConversion.ToNumeric(m.ValPrecomax);
 				ValPrecoult = ViewModelConversion.ToNumeric(m.ValPrecoult);
 				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
 				ValQtdequip = ViewModelConversion.ToNumeric(m.ValQtdequip);
 				ValKit = ViewModelConversion.ToLogic(m.ValKit);
 				ValCodfamil = ViewModelConversion.ToString(m.ValCodfamil);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tpeq1) to ViewModel (Tpeq1) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tpeq1 m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpeq1) to Model (Tpeq1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTpequcod = ViewModelConversion.ToString(ValTpequcod);
				m.ValNivel = ViewModelConversion.ToNumeric(ValNivel);
				m.ValTipoequi = ViewModelConversion.ToString(ValTipoequi);
				m.ValTpequpai = ViewModelConversion.ToString(ValTpequpai);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
				m.ValCorletra = ViewModelConversion.ToString(ValCorletra);
				m.ValPrecomax = ViewModelConversion.ToNumeric(ValPrecomax);
				m.ValPrecoult = ViewModelConversion.ToNumeric(ValPrecoult);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValQtdequip = ViewModelConversion.ToNumeric(ValQtdequip);
				m.ValKit = ViewModelConversion.ToLogic(ValKit);
				m.ValCodfamil = ViewModelConversion.ToString(ValCodfamil);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpeq1) to Model (Tpeq1) - Error during mapping");
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
				Model = Models.Tpeq1.Find(Navigation.GetStrValue("tpeq1"), "FTPEQ1");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tpeq1() { Identifier = "FTPEQ1" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tpeq1");
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

			Model.Identifier = "FTPEQ1";
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

		protected override void LoadDocumentsProperties(Models.Tpeq1 row)
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
				Model = Models.Tpeq1.Find(Navigation.GetStrValue("tpeq1"), "FTPEQ1");
				if (Model == null)
				{
					Model = new Models.Tpeq1() { Identifier = "FTPEQ1" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tpeq1");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tpeq1___fami1family__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPEQ1]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPEQ1]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPEQ1]/
		public override void Save()
		{

			try { Model = Models.Tpeq1.Find(Navigation.GetStrValue("tpeq1"), "FTPEQ1"); }
			finally { if (Model == null) Model = new Models.Tpeq1() { Identifier = "FTPEQ1" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPEQ1]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tpeq1.Find(Navigation.GetStrValue("tpeq1"), "FTPEQ1"); }
			finally { if (Model == null) Model = new Models.Tpeq1() { Identifier = "FTPEQ1" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPEQ1]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPEQ1]/
		public override void Destroy(string id)
		{
			Model = Models.Tpeq1.Find(id, "FTPEQ1");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableFami1Family -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tpeq1___fami1family__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tpeq1___fami1family__DoLoad = true;
            CriteriaSet tpeq1___fami1family__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("fami1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tpeq1___fami1family__Conds.Equal(CSGenioAfami1.FldCodfamil, Navigation.GetValue("fami1"));
                    this.ValCodfamil = Navigation.GetStrValue("fami1");
                }
            }



            TableFami1Family = new TableDBEdit<Models.Fami1>();
            TableFami1Family.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_fami1") != null)
				{
                    this.ValCodfamil = Navigation.GetStrValue("RETURN_fami1");
					Navigation.CurrentLevel.SetEntry("RETURN_fami1", null);
				}
                FillDependant_Tpeq1TableFami1Family(lazyLoad);
                //Check if foreignkey comes from history
                TableFami1Family.FilledByHistory = Navigation.CheckFilledByHistory("fami1");
                return;
            }


            if (tpeq1___fami1family__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFami1Family, "sTableFami1Family", "dTableFami1Family", qs, "fami1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfami1.FldFamily), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFami1Family_tableFilters"]))
                    TableFami1Family.TableFilters = bool.Parse(qs["TableFami1Family_tableFilters"]);
                else
                    TableFami1Family.TableFilters = false;

                query = qs["qTableFami1Family"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfami1.FldFamily, query + "%");
                }
                tpeq1___fami1family__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFami1Family"] != null ? qs["pTableFami1Family"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfami1.FldCodfamil, CSGenioAfami1.FldFamily, CSGenioAfami1.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPEQ1_FAMI1FAMILY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("fami1", FormMode.New) || Navigation.checkFormMode("fami1", FormMode.Duplicate))
                    tpeq1___fami1family__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfami1.FldZzstate, 0)
                        .Equal(CSGenioAfami1.FldCodfamil, Navigation.GetStrValue("fami1")));
                else
                    tpeq1___fami1family__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfami1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tpeq1___fami1family__Conds = Fami1.AddEPH<CSGenioAfami1>(ref UserContext.Current.User, tpeq1___fami1family__Conds, "LED_TPEQ1___FAMI1FAMILY__");

                FieldRef firstVisibleColumn = new FieldRef("fami1", "family");
                ListingMVC<CSGenioAfami1> listing = Models.ModelBase.Where<CSGenioAfami1>(false, tpeq1___fami1family__Conds, fields, offset, numberItems, sorts, "LED_TPEQ1___FAMI1FAMILY__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFami1Family.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFami1Family.Query = query;
                TableFami1Family.Elements = listing.RowsForViewModel<GenioMVC.Models.Fami1>((r) => new GenioMVC.Models.Fami1(r, true, _fieldsToSerialize_TPEQ1___FAMI1FAMILY__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_fami1") != null)
				{
					this.ValCodfamil = Navigation.GetStrValue("RETURN_fami1");
					Navigation.CurrentLevel.SetEntry("RETURN_fami1", null);
				}

				TableFami1Family.List = new SelectList(TableFami1Family.Elements.ToSelectList(x => x.ValFamily, x => x.ValCodfamil,  x => x.ValCodfamil == this.ValCodfamil), "Value", "Text", this.ValCodfamil);
                FillDependant_Tpeq1TableFami1Family();

                //Check if foreignkey comes from history
                TableFami1Family.FilledByHistory = Navigation.CheckFilledByHistory("fami1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFami1Family (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Fami1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Tpeq1TableFami1Family(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "fami1.codfamil", "fami1.family" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfami1.FldCodfamil, CSGenioAfami1.FldFamily };
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
            CSGenioAfami1 tempArea = new CSGenioAfami1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfami1.FldCodfamil, PKey));
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
        /// Fill Dependant fields values -> TableFami1Family (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Tpeq1TableFami1Family(bool lazyLoad = false)
        {
            var row = GetDependant_Tpeq1TableFami1Family(this.ValCodfamil, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodfamil = ViewModelConversion.ToString(row["fami1.codfamil"]);
                TableFami1Family.Value = ViewModelConversion.ToString(row["fami1.family"]);
                if (GlobalFunctions.emptyG(this.ValCodfamil) == 1)
                {
                    this.ValCodfamil = "";
                    TableFami1Family.Value = "";
                    Navigation.ClearValue("fami1");
                }
                else if (lazyLoad)
                {
                    TableFami1Family.SetPagination(1, 0, false, false, 1);
                    TableFami1Family.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodfamil),
                            Text = Convert.ToString(TableFami1Family.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodfamil);
                }
                TableFami1Family.Selected = this.ValCodfamil;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFami1Family): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TPEQ1___FAMI1FAMILY__ = { "Fami1", "Fami1.ValCodfamil", "Fami1.ValZzstate", "Fami1.ValFamily" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPEQ1]/
		#endregion
	}
}
