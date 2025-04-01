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

namespace GenioMVC.ViewModels.Cmpny
{
	public class Empre_ViewModel : FormViewModel<Models.Cmpny>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValLogo { get; set; }

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Acronym" Tipo:"C"</summary>
		[Display(Name = "ACRONYM00872", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAcronym { get; set; }

		/// <summary>Campo : "Tax identification:" Tipo:"C"</summary>
		[Display(Name = "TAX_IDENTIFICATION_55044", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValNif { get; set; }

		/// <summary>Campo : "Telephone" Tipo:"C"</summary>
		[Display(Name = "TELEPHONE28697", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTelephon { get; set; }

		/// <summary>Campo : "Email:" Tipo:"C"</summary>
		[Display(Name = "EMAIL_44228", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cntry>  TableCntryCountry { get; set; }

		/// <summary>Campo : "Quantity of people" Tipo:"N"</summary>
		[Display(Name = "QUANTITY_OF_PEOPLE64893", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdpesso { get; set; }

		/// <summary>Campo : "Headquarter location" Tipo:"GG"</summary>
		[Display(Name = "HEADQUARTER_LOCATION30734", ResourceType = typeof(Resources.Resources))]
		[UIHint("GoogleMaps")]
		public string ValHeadloc { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public string ValCodcntry { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodempre { get; set; }

		public Empre_ViewModel() : base("FEMPRE") { }

		public Empre_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FEMPRE", currentNavigation, nestedForm) { }

		public Empre_ViewModel(Models.Cmpny row, NavigationContext currentNavigation, bool nestedForm = false) : base("FEMPRE", row, currentNavigation, nestedForm) { }

		public Empre_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cmpny", id);
			Model = Models.Cmpny.Find(id, "FEMPRE", fieldsToQuery: fieldsToLoad);
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
			Models.Cmpny model = new Models.Cmpny() { Identifier = "FEMPRE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cmpny model)
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

		public static StatusMessage DeleteConditions(Models.Cmpny model)
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

		public static StatusMessage ViewConditions(Models.Cmpny model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cmpny model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Empre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValAcronym = ViewModelConversion.ToString(m.ValAcronym);
				ValNif = ViewModelConversion.ToString(m.ValNif);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValQtdpesso = ViewModelConversion.ToNumeric(m.ValQtdpesso);
				ValHeadloc = ViewModelConversion.ToString(m.ValHeadloc);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Empre) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Empre) to Model (Cmpny) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValAcronym = ViewModelConversion.ToString(ValAcronym);
				m.ValNif = ViewModelConversion.ToString(ValNif);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValQtdpesso = ViewModelConversion.ToNumeric(ValQtdpesso);
				m.ValHeadloc = ViewModelConversion.ToString(ValHeadloc);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Empre) to Model (Cmpny) - Error during mapping");
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
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FEMPRE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cmpny() { Identifier = "FEMPRE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");
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

			Model.Identifier = "FEMPRE";
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

		protected override void LoadDocumentsProperties(Models.Cmpny row)
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
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FEMPRE");
				if (Model == null)
				{
					Model = new Models.Cmpny() { Identifier = "FEMPRE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Empre___cntrycountry_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EMPRE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EMPRE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EMPRE]/
		public override void Save()
		{

			try { Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FEMPRE"); }
			finally { if (Model == null) Model = new Models.Cmpny() { Identifier = "FEMPRE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EMPRE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FEMPRE"); }
			finally { if (Model == null) Model = new Models.Cmpny() { Identifier = "FEMPRE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EMPRE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EMPRE]/
		public override void Destroy(string id)
		{
			Model = Models.Cmpny.Find(id, "FEMPRE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableCntryCountry -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Empre___cntrycountry_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool empre___cntrycountry_DoLoad = true;
            CriteriaSet empre___cntrycountry_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cntry", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    empre___cntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
                    this.ValCodcntry = Navigation.GetStrValue("cntry");
                }
            }



            TableCntryCountry = new TableDBEdit<Models.Cntry>();
            TableCntryCountry.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
                    this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
                FillDependant_EmpreTableCntryCountry(lazyLoad);
                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
                return;
            }


            if (empre___cntrycountry_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
                    TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
                else
                    TableCntryCountry.TableFilters = false;

                query = qs["qTableCntryCountry"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
                }
                empre___cntrycountry_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ EMPRE_CNTRYCOUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
                    empre___cntrycountry_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcntry.FldZzstate, 0)
                        .Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
                else
                    empre___cntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //empre___cntrycountry_Conds = Cntry.AddEPH<CSGenioAcntry>(ref UserContext.Current.User, empre___cntrycountry_Conds, "LED_EMPRE___CNTRYCOUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
                ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(false, empre___cntrycountry_Conds, fields, offset, numberItems, sorts, "LED_EMPRE___CNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCntryCountry.Query = query;
                TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(r, true, _fieldsToSerialize_EMPRE___CNTRYCOUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
                if(!isSearchRequest)
                    FillDependant_EmpreTableCntryCountry();

                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cntry</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EmpreTableCntryCountry(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cntry.codcntry", "cntry.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };
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
            CSGenioAcntry tempArea = new CSGenioAcntry(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));
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
        /// Fill Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EmpreTableCntryCountry(bool lazyLoad = false)
        {
            var row = GetDependant_EmpreTableCntryCountry(this.ValCodcntry, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
                TableCntryCountry.Value = ViewModelConversion.ToString(row["cntry.country"]);
                if (GenFunctions.emptyG(this.ValCodcntry) == 1)
                {
                    this.ValCodcntry = "";
                    TableCntryCountry.Value = "";
                    Navigation.ClearValue("cntry");
                }
                else if (lazyLoad)
                {
                    TableCntryCountry.SetPagination(1, 0, false, false, 1);
                    TableCntryCountry.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodcntry),
                            Text = Convert.ToString(TableCntryCountry.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodcntry);
                }
                TableCntryCountry.Selected = this.ValCodcntry;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EMPRE___CNTRYCOUNTRY_ = { "Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EMPRE]/
		#endregion
	}
}
