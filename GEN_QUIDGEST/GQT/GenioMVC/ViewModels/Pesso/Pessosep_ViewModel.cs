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
	public class Pessosep_ViewModel : FormViewModel<Models.Pesso>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

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

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cmpny>  TableCmpnyDesignat { get; set; }

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

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Professional Category Evolution" Tipo:"DP"</summary>
		[Display(Name = "PROFESSIONAL_CATEGOR43519", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Evcat> ValEvolucao { get; set; }

		/// <summary>Campo : "Contacts" Tipo:"DP"</summary>
		[Display(Name = "CONTACTS55742", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Conta> ValContacto { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		public string ValCodempre { get; set; }

		public string ValCodpaise { get; set; }

		public string ValCodcntry { get; set; }

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

		public Pessosep_ViewModel() : base("FPESSOSEP") { }

		public Pessosep_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSOSEP", currentNavigation, nestedForm) { }

		public Pessosep_ViewModel(Models.Pesso row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSOSEP", row, currentNavigation, nestedForm) { }

		public Pessosep_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, "FPESSOSEP", fieldsToQuery: fieldsToLoad);
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
			Models.Pesso model = new Models.Pesso() { Identifier = "FPESSOSEP" };
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
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pessosep) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValIdfuncio = ViewModelConversion.ToNumeric(m.ValIdfuncio);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValDtnascim = ViewModelConversion.ToDateTime(m.ValDtnascim);
 				ValGender = ViewModelConversion.ToString(m.ValGender);
 				ValInterna = ViewModelConversion.ToLogic(m.ValInterna);
 				ValExterna = ViewModelConversion.ToLogic(m.ValExterna);
 				ValDtultcat = ViewModelConversion.ToDateTime(m.ValDtultcat);
 				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
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
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pessosep) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pessosep) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
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
				CSGenio.framework.Log.Error("Map ViewModel (Pessosep) to Model (Pesso) - Error during mapping");
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSOSEP");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pesso() { Identifier = "FPESSOSEP" };
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

			Model.Identifier = "FPESSOSEP";
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSOSEP");
				if (Model == null)
				{
					Model = new Models.Pesso() { Identifier = "FPESSOSEP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Pessosepcategcategory(qs, lazyLoad);
			Load_Pessos00cmpnydesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESSOSEP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESSOSEP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PESSOSEP]/
		public override void Save()
		{

			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSOSEP"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSOSEP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSOSEP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSOSEP"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSOSEP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSOSEP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSOSEP]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, "FPESSOSEP");
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
        public void Load_Pessosepcategcategory(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pessosepcategcategoryDoLoad = true;
            CriteriaSet pessosepcategcategoryConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("categ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pessosepcategcategoryConds.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetValue("categ"));
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
                FillDependant_PessosepTableCategCategory(lazyLoad);
                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
                return;
            }


            if (pessosepcategcategoryDoLoad)
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
                pessosepcategcategoryConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCategCategory"] != null ? qs["pTableCategCategory"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioAcateg.FldAbbreviation, CSGenioAcateg.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSOSEP_CATEGCATEGORY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("categ", FormMode.New) || Navigation.checkFormMode("categ", FormMode.Duplicate))
                    pessosepcategcategoryConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcateg.FldZzstate, 0)
                        .Equal(CSGenioAcateg.FldCodcateg, Navigation.GetStrValue("categ")));
                else
                    pessosepcategcategoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcateg.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pessosepcategcategoryConds = Categ.AddEPH<CSGenioAcateg>(ref UserContext.Current.User, pessosepcategcategoryConds, "LED_PESSOSEPCATEGCATEGORY");

                FieldRef firstVisibleColumn = new FieldRef("categ", "categoria");
                ListingMVC<CSGenioAcateg> listing = Models.ModelBase.Where<CSGenioAcateg>(false, pessosepcategcategoryConds, fields, offset, numberItems, sorts, "LED_PESSOSEPCATEGCATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCategCategory.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCategCategory.Query = query;
                TableCategCategory.Elements = listing.RowsForViewModel<GenioMVC.Models.Categ>((r) => new GenioMVC.Models.Categ(r, true, _fieldsToSerialize_PESSOSEPCATEGCATEGORY));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}

				TableCategCategory.List = new SelectList(TableCategCategory.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
                FillDependant_PessosepTableCategCategory();

                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCategCategory (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Categ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PessosepTableCategCategory(string PKey, NavigationContext Navigation)
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
        public void FillDependant_PessosepTableCategCategory(bool lazyLoad = false)
        {
            var row = GetDependant_PessosepTableCategCategory(this.ValCodcateg, Navigation);
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


        private readonly string[] _fieldsToSerialize_PESSOSEPCATEGCATEGORY = { "Categ", "Categ.ValCodcateg", "Categ.ValZzstate", "Categ.ValCategoria", "Categ.ValAbbreviation" };

        /// <summary>
        /// TableCmpnyDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pessos00cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pessos00cmpnydesignatDoLoad = true;
            CriteriaSet pessos00cmpnydesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cmpny", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pessos00cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
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
                FillDependant_Pessos00TableCmpnyDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
                return;
            }


            if (pessos00cmpnydesignatDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldAcronym), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldNif), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldTelephon), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldEmail), SortOrder.Ascending));


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
                pessos00cmpnydesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail, CSGenioAcmpny.FldLogo, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSOS00_CMPNYDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
                    pessos00cmpnydesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcmpny.FldZzstate, 0)
                        .Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
                else
                    pessos00cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pessos00cmpnydesignatConds = Cmpny.AddEPH<CSGenioAcmpny>(ref UserContext.Current.User, pessos00cmpnydesignatConds, "LED_PESSOS00CMPNYDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
                ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, pessos00cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESSOS00CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCmpnyDesignat.Query = query;
                TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(r, true, _fieldsToSerialize_PESSOS00CMPNYDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
                FillDependant_Pessos00TableCmpnyDesignat();

                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cmpny</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_Pessos00TableCmpnyDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cmpny.codempre", "cmpny.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };
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
        public void FillDependant_Pessos00TableCmpnyDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_Pessos00TableCmpnyDesignat(this.ValCodempre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

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


        private readonly string[] _fieldsToSerialize_PESSOS00CMPNYDESIGNAT = { "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat", "Cmpny.ValAcronym", "Cmpny.ValNif", "Cmpny.ValTelephon", "Cmpny.ValEmail", "Cmpny.ValLogo" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSOSEP]/
		#endregion
	}
}
