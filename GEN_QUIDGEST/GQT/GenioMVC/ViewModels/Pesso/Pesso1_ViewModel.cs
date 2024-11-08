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

namespace GenioMVC.ViewModels.Pesso
{
	public class Pesso1_ViewModel : FormViewModel<Models.Pesso>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Employee No." Tipo:"N"</summary>
		[Display(Name = "EMPLOYEE_NO_01176", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get; set; }

		/// <summary>Campo : "Name:" Tipo:"C"</summary>
		[Display(Name = "NAME_23841", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Birth" Tipo:"D"</summary>
		[Display(Name = "BIRTH21799", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get; set; }

		/// <summary>Campo : "Age" Tipo:"N"</summary>
		[Display(Name = "AGE28663", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIdade { get; set; }

		/// <summary>Campo : "Gender" Tipo:"AC"</summary>
		[Display(Name = "GENDER44172", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get; set; }
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }

		/// <summary>Campo : "Intern" Tipo:"L"</summary>
		[Display(Name = "INTERN65375", ResourceType = typeof(Resources.Resources))]
		public bool ValInterna { get; set; }

		/// <summary>Campo : "External" Tipo:"L"</summary>
		[Display(Name = "EXTERNAL13375", ResourceType = typeof(Resources.Resources))]
		public bool ValExterna { get; set; }

		/// <summary>Campo : "Category" Tipo:"C"</summary>
		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Categ>  TableCategCategory { get; set; }

		/// <summary>Campo : "Since" Tipo:"D"</summary>
		[Display(Name = "SINCE47259", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get; set; }

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

		/// <summary>Campo : "" Tipo:"DP"</summary>
		public TablePartial<GenioMVC.Models.Conta> ValContacto { get; set; }

		/// <summary>Campo : "Company" Tipo:"C"</summary>
		[Display(Name = "COMPANY52963", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cmpny>  TableCmpnyDesignat { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(90, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CntryValCountry { get { return funcCntryValCountry != null ? funcCntryValCountry() : _auxCntryValCountry; } set { funcCntryValCountry = () => value; } }
		[JsonIgnore]
		public Func<string> funcCntryValCountry { get; set; }
		private string _auxCntryValCountry { get; set; }

		/// <summary>Campo : "" Tipo:"DP"</summary>
		public TablePartial<GenioMVC.Models.Evcat> ValEvolucao { get; set; }

		/// <summary>Campo : "Region" Tipo:"C"</summary>
		[Display(Name = "REGION12723", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Regi1>  TableRegi1Regiao { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(90, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Pais1ValCountry { get { return funcPais1ValCountry != null ? funcPais1ValCountry() : _auxPais1ValCountry; } set { funcPais1ValCountry = () => value; } }
		[JsonIgnore]
		public Func<string> funcPais1ValCountry { get; set; }
		private string _auxPais1ValCountry { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COMPANY52963", ResourceType = typeof(Resources.Resources))]
		public string ValCodempre { get; set; }

		public string ValCodpaise { get; set; }

		public string ValCodcntry { get; set; }

		[Display(Name = "REGION12723", ResourceType = typeof(Resources.Resources))]
		public string ValCodregia { get; set; }

		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		public string ValCodcateg { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Email" Tipo: "C"</summary>
		[AllowHtml]
		public string ValEmail2 { get; set; }
		#endregion

		public string ValCodpesso { get; set; }

		public Pesso1_ViewModel() : base("FPESSO1") { }

		public Pesso1_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSO1", currentNavigation, nestedForm) { }

		public Pesso1_ViewModel(Models.Pesso row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSO1", row, currentNavigation, nestedForm) { }

		public Pesso1_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, "FPESSO1", fieldsToQuery: fieldsToLoad);
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
			Models.Pesso model = new Models.Pesso() { Identifier = "FPESSO1" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Pesso model)
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

		public static StatusMessage DeleteConditions(Models.Pesso model)
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

		public static StatusMessage ViewConditions(Models.Pesso model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Pesso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso1) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
 				ValIdfuncio = ViewModelConversion.ToNumeric(m.ValIdfuncio);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValDtnascim = ViewModelConversion.ToDateTime(m.ValDtnascim);
 				ValIdade = ViewModelConversion.ToNumeric(m.ValIdade);
 				ValGender = ViewModelConversion.ToString(m.ValGender);
 				ValInterna = ViewModelConversion.ToLogic(m.ValInterna);
 				ValExterna = ViewModelConversion.ToLogic(m.ValExterna);
 				ValDtultcat = ViewModelConversion.ToDateTime(m.ValDtultcat);
 				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				funcCntryValCountry = () => ViewModelConversion.ToString(m.Cntry.ValCountry);
 				funcPais1ValCountry = () => ViewModelConversion.ToString(m.Pais1.ValCountry);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCodpaise = ViewModelConversion.ToString(m.ValCodpaise);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
 				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
 				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
 				ValEmail2 = ViewModelConversion.ToString(m.ValEmail2);
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso1) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesso1) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
				m.ValIdade = ViewModelConversion.ToNumeric(ValIdade);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValInterna = ViewModelConversion.ToLogic(ValInterna);
				m.ValExterna = ViewModelConversion.ToLogic(ValExterna);
				m.ValDtultcat = ViewModelConversion.ToDateTime(ValDtultcat);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpaise = ViewModelConversion.ToString(ValCodpaise);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValEmail2 = ViewModelConversion.ToString(ValEmail2);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesso1) to Model (Pesso) - Error during mapping");
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO1");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pesso() { Identifier = "FPESSO1" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
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

			Model.Identifier = "FPESSO1";
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

		protected override void LoadDocumentsProperties(Models.Pesso row)
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO1");
				if (Model == null)
				{
					Model = new Models.Pesso() { Identifier = "FPESSO1" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			this.ValGender = ViewModelConversion.ToString(Navigation.GetValue("pesso.gender"));
			Load_Pesso1__categcategory(qs, lazyLoad);
			Load_Pesso1__cmpnydesignat(qs, lazyLoad);
			Load_Pesso1__regi1regiao__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESSO1]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESSO1]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PESSO1]/
		public override void Save()
		{

			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO1"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSO1" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSO1]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO1"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSO1" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSO1]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSO1]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, "FPESSO1");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValGender = new SelectList(
				ArrayGenero.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValGender);
		}


        /// <summary>
        /// TableCategCategory -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pesso1__categcategory(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pesso1__categcategoryDoLoad = true;
            CriteriaSet pesso1__categcategoryConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("categ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso1__categcategoryConds.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetValue("categ"));
                    this.ValCodcateg = Navigation.GetStrValue("categ");
                }
            }



            TableCategCategory = new TableDBEdit<Models.Categ>();
            TableCategCategory.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
                    this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}
                FillDependant_Pesso1TableCategCategory(lazyLoad);
                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
                return;
            }


            if (pesso1__categcategoryDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCategCategory, "sTableCategCategory", "dTableCategCategory", qs, "categ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldCategoria), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldAbbreviation), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableCategCategory_tableFilters"]))
                    TableCategCategory.TableFilters = bool.Parse(qs["TableCategCategory_tableFilters"]);
                else
                    TableCategCategory.TableFilters = false;

                query = qs["qTableCategCategory"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcateg.FldCategoria, query + "%");
                }
                pesso1__categcategoryConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCategCategory"] != null ? qs["pTableCategCategory"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioAcateg.FldAbbreviation, CSGenioAcateg.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO1_CATEGCATEGORY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("categ", FormMode.New) || Navigation.checkFormMode("categ", FormMode.Duplicate))
                    pesso1__categcategoryConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcateg.FldZzstate, 0)
                        .Equal(CSGenioAcateg.FldCodcateg, Navigation.GetStrValue("categ")));
                else
                    pesso1__categcategoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcateg.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso1__categcategoryConds = Categ.AddEPH<CSGenioAcateg>(ref UserContext.Current.User, pesso1__categcategoryConds, "LED_PESSO1__CATEGCATEGORY");

                FieldRef firstVisibleColumn = new FieldRef("categ", "categoria");
                ListingMVC<CSGenioAcateg> listing = Models.ModelBase.Where<CSGenioAcateg>(false, pesso1__categcategoryConds, fields, offset, numberItems, sorts, "LED_PESSO1__CATEGCATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCategCategory.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCategCategory.Query = query;
                TableCategCategory.Elements = listing.RowsForViewModel<GenioMVC.Models.Categ>((r) => new GenioMVC.Models.Categ(r, true, _fieldsToSerialize_PESSO1__CATEGCATEGORY));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}

				TableCategCategory.List = new SelectList(TableCategCategory.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
                FillDependant_Pesso1TableCategCategory();

                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCategCategory (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Categ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Pesso1TableCategCategory(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "categ.codcateg", "categ.categoria" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria };
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
            CSGenioAcateg tempArea = new CSGenioAcateg(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcateg.FldCodcateg, PKey));
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
        /// Fill Dependant fields values -> TableCategCategory (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Pesso1TableCategCategory(bool lazyLoad = false)
        {
            var row = GetDependant_Pesso1TableCategCategory(this.ValCodcateg, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcateg = ViewModelConversion.ToString(row["categ.codcateg"]);
                TableCategCategory.Value = ViewModelConversion.ToString(row["categ.categoria"]);
                if (GlobalFunctions.emptyG(this.ValCodcateg) == 1)
                {
                    this.ValCodcateg = "";
                    TableCategCategory.Value = "";
                    Navigation.ClearValue("categ");
                }
                else if (lazyLoad)
                {
                    TableCategCategory.SetPagination(1, 0, false, false, 1);
                    TableCategCategory.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodcateg),
                            Text = Convert.ToString(TableCategCategory.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodcateg);
                }
                TableCategCategory.Selected = this.ValCodcateg;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategCategory): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO1__CATEGCATEGORY = { "Categ", "Categ.ValCodcateg", "Categ.ValZzstate", "Categ.ValCategoria", "Categ.ValAbbreviation" };

        /// <summary>
        /// TableCmpnyDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pesso1__cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pesso1__cmpnydesignatDoLoad = true;
            CriteriaSet pesso1__cmpnydesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cmpny", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso1__cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
                    this.ValCodempre = Navigation.GetStrValue("cmpny");
                }
            }



            TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>();
            TableCmpnyDesignat.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
                    this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
                FillDependant_Pesso1TableCmpnyDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
                return;
            }


            if (pesso1__cmpnydesignatDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
                    TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
                else
                    TableCmpnyDesignat.TableFilters = false;

                query = qs["qTableCmpnyDesignat"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
                }
                pesso1__cmpnydesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail, CSGenioAcmpny.FldLogo, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO1_CMPNYDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
                    pesso1__cmpnydesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcmpny.FldZzstate, 0)
                        .Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
                else
                    pesso1__cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso1__cmpnydesignatConds = Cmpny.AddEPH<CSGenioAcmpny>(ref UserContext.Current.User, pesso1__cmpnydesignatConds, "LED_PESSO1__CMPNYDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
                ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, pesso1__cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESSO1__CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCmpnyDesignat.Query = query;
                TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(r, true, _fieldsToSerialize_PESSO1__CMPNYDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
                FillDependant_Pesso1TableCmpnyDesignat();

                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cmpny</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Pesso1TableCmpnyDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cmpny.codempre", "cmpny.designat", "cntry.codcntry", "cntry.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };
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
            CSGenioAcmpny tempArea = new CSGenioAcmpny(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));
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
        /// Fill Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Pesso1TableCmpnyDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_Pesso1TableCmpnyDesignat(this.ValCodempre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                this.ValCodpaise = ViewModelConversion.ToString(row["cntry.codcntry"]);
                {
                    var tempValue = ViewModelConversion.ToString(row["cntry.country"]);
                    this.funcCntryValCountry = () => tempValue;
                }

                // Fill List fields
                this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
                TableCmpnyDesignat.Value = ViewModelConversion.ToString(row["cmpny.designat"]);
                if (GlobalFunctions.emptyG(this.ValCodempre) == 1)
                {
                    this.ValCodempre = "";
                    TableCmpnyDesignat.Value = "";
                    Navigation.ClearValue("cmpny");
                }
                else if (lazyLoad)
                {
                    TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
                    TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodempre),
                            Text = Convert.ToString(TableCmpnyDesignat.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodempre);
                }
                TableCmpnyDesignat.Selected = this.ValCodempre;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO1__CMPNYDESIGNAT = { "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat", "Cmpny.ValAcronym", "Cmpny.ValNif", "Cmpny.ValTelephon", "Cmpny.ValEmail", "Cmpny.ValLogo" };

        /// <summary>
        /// TableRegi1Regiao -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pesso1__regi1regiao__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pesso1__regi1regiao__DoLoad = true;
            CriteriaSet pesso1__regi1regiao__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("regi1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso1__regi1regiao__Conds.Equal(CSGenioAregi1.FldCodregia, Navigation.GetValue("regi1"));
                    this.ValCodregia = Navigation.GetStrValue("regi1");
                }
            }

			// Limits Generation

			// History limit
			pesso1__regi1regiao__DoLoad &= AddCriteriaHistoryLimit(pesso1__regi1regiao__Conds, CSGenio.business.CSGenioAregi1.FldCodcntry, OperationType.EQUAL, "pais", true);


            TableRegi1Regiao = new TableDBEdit<Models.Regi1>();
            TableRegi1Regiao.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
                    this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}
                FillDependant_Pesso1TableRegi1Regiao(lazyLoad);
                //Check if foreignkey comes from history
                TableRegi1Regiao.FilledByHistory = Navigation.CheckFilledByHistory("regi1");
                return;
            }


            if (pesso1__regi1regiao__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRegi1Regiao, "sTableRegi1Regiao", "dTableRegi1Regiao", qs, "regi1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregi1.FldRegiao), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRegi1Regiao_tableFilters"]))
                    TableRegi1Regiao.TableFilters = bool.Parse(qs["TableRegi1Regiao_tableFilters"]);
                else
                    TableRegi1Regiao.TableFilters = false;

                query = qs["qTableRegi1Regiao"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAregi1.FldRegiao, query + "%");
                }
                pesso1__regi1regiao__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRegi1Regiao"] != null ? qs["pTableRegi1Regiao"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao, CSGenioAregi1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO1_REGI1REGIAO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("regi1", FormMode.New) || Navigation.checkFormMode("regi1", FormMode.Duplicate))
                    pesso1__regi1regiao__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAregi1.FldZzstate, 0)
                        .Equal(CSGenioAregi1.FldCodregia, Navigation.GetStrValue("regi1")));
                else
                    pesso1__regi1regiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregi1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso1__regi1regiao__Conds = Regi1.AddEPH<CSGenioAregi1>(ref UserContext.Current.User, pesso1__regi1regiao__Conds, "LED_PESSO1__REGI1REGIAO__");

                FieldRef firstVisibleColumn = new FieldRef("regi1", "regiao");
                ListingMVC<CSGenioAregi1> listing = Models.ModelBase.Where<CSGenioAregi1>(false, pesso1__regi1regiao__Conds, fields, offset, numberItems, sorts, "LED_PESSO1__REGI1REGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRegi1Regiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRegi1Regiao.Query = query;
                TableRegi1Regiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regi1>((r) => new GenioMVC.Models.Regi1(r, true, _fieldsToSerialize_PESSO1__REGI1REGIAO__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}

				TableRegi1Regiao.List = new SelectList(TableRegi1Regiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
                FillDependant_Pesso1TableRegi1Regiao();

                //Check if foreignkey comes from history
                TableRegi1Regiao.FilledByHistory = Navigation.CheckFilledByHistory("regi1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRegi1Regiao (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Regi1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Pesso1TableRegi1Regiao(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "regi1.codregia", "regi1.regiao", "pais1.codcntry", "pais1.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao, CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry };
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
            CSGenioAregi1 tempArea = new CSGenioAregi1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAregi1.FldCodregia, PKey));
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
        /// Fill Dependant fields values -> TableRegi1Regiao (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_Pesso1TableRegi1Regiao(bool lazyLoad = false)
        {
            var row = GetDependant_Pesso1TableRegi1Regiao(this.ValCodregia, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                this.ValCodcntry = ViewModelConversion.ToString(row["pais1.codcntry"]);
                {
                    var tempValue = ViewModelConversion.ToString(row["pais1.country"]);
                    this.funcPais1ValCountry = () => tempValue;
                }

                // Fill List fields
                this.ValCodregia = ViewModelConversion.ToString(row["regi1.codregia"]);
                TableRegi1Regiao.Value = ViewModelConversion.ToString(row["regi1.regiao"]);
                if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
                {
                    this.ValCodregia = "";
                    TableRegi1Regiao.Value = "";
                    Navigation.ClearValue("regi1");
                }
                else if (lazyLoad)
                {
                    TableRegi1Regiao.SetPagination(1, 0, false, false, 1);
                    TableRegi1Regiao.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodregia),
                            Text = Convert.ToString(TableRegi1Regiao.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodregia);
                }
                TableRegi1Regiao.Selected = this.ValCodregia;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegi1Regiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO1__REGI1REGIAO__ = { "Regi1", "Regi1.ValCodregia", "Regi1.ValZzstate", "Regi1.ValRegiao" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSO1]/
		#endregion
	}
}
