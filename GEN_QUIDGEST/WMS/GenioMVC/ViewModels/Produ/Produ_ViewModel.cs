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

namespace GenioMVC.ViewModels.Produ
{
	public class Produ_ViewModel : FormViewModel<Models.Produ>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Product" Tipo:"C"</summary>
		[Display(Name = "PRODUCT12880", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValProduct { get; set; }

		/// <summary>Campo : "In use" Tipo:"AL"</summary>
		[Display(Name = "IN_USE42606", ResourceType = typeof(Resources.Resources))]
		[DataArray("Yesno", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValIn_use { get; set; }
		[JsonIgnore]
		public SelectList List_ValIn_use { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "SKU" Tipo:"C"</summary>
		[Display(Name = "SKU42303", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValSku { get; set; }

		/// <summary>Campo : "GTIN" Tipo:"C"</summary>
		[Display(Name = "GTIN45487", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(14, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGtin { get; set; }

		/// <summary>Campo : "Size" Tipo:"C"</summary>
		[Display(Name = "SIZE10299", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValSize { get; set; }

		/// <summary>Campo : "Weight" Tipo:"N"</summary>
		[Display(Name = "WEIGHT36329", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValWeight { get; set; }

		/// <summary>Campo : "Price" Tipo:"$D"</summary>
		[Display(Name = "PRICE06900", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValPrice { get; set; }

		/// <summary>Campo : "Inputs" Tipo:"N"</summary>
		[Display(Name = "INPUTS19315", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValInputs { get; set; }

		/// <summary>Campo : "Outputs" Tipo:"N"</summary>
		[Display(Name = "OUTPUTS47833", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOutputs { get; set; }

		/// <summary>Campo : "Stock" Tipo:"N"</summary>
		[Display(Name = "STOCK37618", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValStock { get; set; }

		/// <summary>Campo : "Image" Tipo:"IJ"</summary>
		[Display(Name = "IMAGE65174", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 400, 300, false, true)]
		public byte[] ValImage { get; set; }

		/// <summary>Campo : "Global Location Number" Tipo:"C"</summary>
		[Display(Name = "GLOBAL_LOCATION_NUMB24637", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Locat>  TableLocatGln { get; set; }

		/// <summary>Campo : "GLN Extension Component" Tipo:"C"</summary>
		[Display(Name = "GLN_EXTENSION_COMPON55869", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Lcext>  TableLcextGlnext { get; set; }

		/// <summary>Campo : "Stock evolution" Tipo:"DP"</summary>
		[Display(Name = "STOCK_EVOLUTION61800", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Stock> ValStockevo { get; set; }

		/// <summary>Campo : "Inputs" Tipo:"DP"</summary>
		[Display(Name = "INPUTS19315", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Relin> ValInputsre { get; set; }

		/// <summary>Campo : "Outputs" Tipo:"DP"</summary>
		[Display(Name = "OUTPUTS47833", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Dilin> ValOutputsd { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "GLN_EXTENSION_COMPON55869", ResourceType = typeof(Resources.Resources))]
		public string ValCodlcext { get; set; }

		[Display(Name = "GLOBAL_LOCATION_NUMB24637", ResourceType = typeof(Resources.Resources))]
		public string ValCodlocat { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodprodu { get; set; }

		public Produ_ViewModel() : base("FPRODU") { }

		public Produ_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPRODU", currentNavigation, nestedForm) { }

		public Produ_ViewModel(Models.Produ row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPRODU", row, currentNavigation, nestedForm) { }

		public Produ_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("produ", id);
			Model = Models.Produ.Find(id, "FPRODU", fieldsToQuery: fieldsToLoad);
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
			Models.Produ model = new Models.Produ() { Identifier = "FPRODU" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Produ model)
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

		public static StatusMessage DeleteConditions(Models.Produ model)
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

		public static StatusMessage ViewConditions(Models.Produ model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Produ model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Produ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Produ) to ViewModel (Produ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValProduct = ViewModelConversion.ToString(m.ValProduct);
 				ValIn_use = ViewModelConversion.ToInteger(m.ValIn_use);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValSku = ViewModelConversion.ToString(m.ValSku);
 				ValGtin = ViewModelConversion.ToString(m.ValGtin);
 				ValSize = ViewModelConversion.ToString(m.ValSize);
 				ValWeight = ViewModelConversion.ToNumeric(m.ValWeight);
 				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
 				ValInputs = ViewModelConversion.ToNumeric(m.ValInputs);
 				ValOutputs = ViewModelConversion.ToNumeric(m.ValOutputs);
 				ValStock = ViewModelConversion.ToNumeric(m.ValStock);
 				ValImage = ViewModelConversion.ToImage(m.ValImage);
 				ValCodlcext = ViewModelConversion.ToString(m.ValCodlcext);
 				ValCodlocat = ViewModelConversion.ToString(m.ValCodlocat);
 				ValCodprodu = ViewModelConversion.ToString(m.ValCodprodu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Produ) to ViewModel (Produ) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Produ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Produ) to Model (Produ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValProduct = ViewModelConversion.ToString(ValProduct);
				m.ValIn_use = ViewModelConversion.ToInteger(ValIn_use);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValSku = ViewModelConversion.ToString(ValSku);
				m.ValGtin = ViewModelConversion.ToString(ValGtin);
				m.ValSize = ViewModelConversion.ToString(ValSize);
				m.ValWeight = ViewModelConversion.ToNumeric(ValWeight);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValInputs = ViewModelConversion.ToNumeric(ValInputs);
				m.ValOutputs = ViewModelConversion.ToNumeric(ValOutputs);
				m.ValStock = ViewModelConversion.ToNumeric(ValStock);
				m.ValCodlcext = ViewModelConversion.ToString(ValCodlcext);
				m.ValCodlocat = ViewModelConversion.ToString(ValCodlocat);
				m.ValCodprodu = ViewModelConversion.ToString(ValCodprodu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Produ) to Model (Produ) - Error during mapping");
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
				Model = Models.Produ.Find(Navigation.GetStrValue("produ"), "FPRODU");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Produ() { Identifier = "FPRODU" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("produ");
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

			Model.Identifier = "FPRODU";
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

		protected override void LoadDocumentsProperties(Models.Produ row)
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
				Model = Models.Produ.Find(Navigation.GetStrValue("produ"), "FPRODU");
				if (Model == null)
				{
					Model = new Models.Produ() { Identifier = "FPRODU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("produ");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Produ___locatgln_____(qs, lazyLoad);
			Load_Produ___lcextglnext__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PRODU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PRODU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PRODU]/
		public override void Save()
		{

			try { Model = Models.Produ.Find(Navigation.GetStrValue("produ"), "FPRODU"); }
			finally { if (Model == null) Model = new Models.Produ() { Identifier = "FPRODU" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PRODU]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Produ.Find(Navigation.GetStrValue("produ"), "FPRODU"); }
			finally { if (Model == null) Model = new Models.Produ() { Identifier = "FPRODU" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PRODU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PRODU]/
		public override void Destroy(string id)
		{
			Model = Models.Produ.Find(id, "FPRODU");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValIn_use = new SelectList(
				ArrayYesno.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValIn_use);
		}


        /// <summary>
        /// TableLocatGln -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Produ___locatgln_____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool produ___locatgln_____DoLoad = true;
            CriteriaSet produ___locatgln_____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("locat", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    produ___locatgln_____Conds.Equal(CSGenioAlocat.FldCodlocat, Navigation.GetValue("locat"));
                    this.ValCodlocat = Navigation.GetStrValue("locat");
                }
            }



            TableLocatGln = new TableDBEdit<Models.Locat>();
            TableLocatGln.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
                    this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}
                FillDependant_ProduTableLocatGln(lazyLoad);
                //Check if foreignkey comes from history
                TableLocatGln.FilledByHistory = Navigation.CheckFilledByHistory("locat");
                return;
            }


            if (produ___locatgln_____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLocatGln, "sTableLocatGln", "dTableLocatGln", qs, "locat");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlocat.FldGln), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLocatGln_tableFilters"]))
                    TableLocatGln.TableFilters = bool.Parse(qs["TableLocatGln_tableFilters"]);
                else
                    TableLocatGln.TableFilters = false;

                query = qs["qTableLocatGln"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAlocat.FldGln, query + "%");
                }
                produ___locatgln_____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLocatGln"] != null ? qs["pTableLocatGln"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAlocat.FldZzstate };

// USE /[MANUAL GQT OVERRQ PRODU_LOCATGLN]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("locat", FormMode.New) || Navigation.checkFormMode("locat", FormMode.Duplicate))
                    produ___locatgln_____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlocat.FldZzstate, 0)
                        .Equal(CSGenioAlocat.FldCodlocat, Navigation.GetStrValue("locat")));
                else
                    produ___locatgln_____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlocat.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //produ___locatgln_____Conds = Locat.AddEPH<CSGenioAlocat>(ref UserContext.Current.User, produ___locatgln_____Conds, "LED_PRODU___LOCATGLN_____");

                FieldRef firstVisibleColumn = new FieldRef("locat", "gln");
                ListingMVC<CSGenioAlocat> listing = Models.ModelBase.Where<CSGenioAlocat>(false, produ___locatgln_____Conds, fields, offset, numberItems, sorts, "LED_PRODU___LOCATGLN_____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLocatGln.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLocatGln.Query = query;
                TableLocatGln.Elements = listing.RowsForViewModel<GenioMVC.Models.Locat>((r) => new GenioMVC.Models.Locat(r, true, _fieldsToSerialize_PRODU___LOCATGLN_____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}

				TableLocatGln.List = new SelectList(TableLocatGln.Elements.ToSelectList(x => x.ValGln, x => x.ValCodlocat,  x => x.ValCodlocat == this.ValCodlocat), "Value", "Text", this.ValCodlocat);
                FillDependant_ProduTableLocatGln();

                //Check if foreignkey comes from history
                TableLocatGln.FilledByHistory = Navigation.CheckFilledByHistory("locat");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLocatGln (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Locat</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProduTableLocatGln(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "locat.codlocat", "locat.gln" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln };
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
            CSGenioAlocat tempArea = new CSGenioAlocat(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlocat.FldCodlocat, PKey));
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
        /// Fill Dependant fields values -> TableLocatGln (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ProduTableLocatGln(bool lazyLoad = false)
        {
            var row = GetDependant_ProduTableLocatGln(this.ValCodlocat, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodlocat = ViewModelConversion.ToString(row["locat.codlocat"]);
                TableLocatGln.Value = ViewModelConversion.ToString(row["locat.gln"]);
                if (GlobalFunctions.emptyG(this.ValCodlocat) == 1)
                {
                    this.ValCodlocat = "";
                    TableLocatGln.Value = "";
                    Navigation.ClearValue("locat");
                }
                else if (lazyLoad)
                {
                    TableLocatGln.SetPagination(1, 0, false, false, 1);
                    TableLocatGln.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodlocat),
                            Text = Convert.ToString(TableLocatGln.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodlocat);
                }
                TableLocatGln.Selected = this.ValCodlocat;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLocatGln): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PRODU___LOCATGLN_____ = { "Locat", "Locat.ValCodlocat", "Locat.ValZzstate", "Locat.ValGln" };

        /// <summary>
        /// TableLcextGlnext -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Produ___lcextglnext__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool produ___lcextglnext__DoLoad = true;
            CriteriaSet produ___lcextglnext__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("lcext", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    produ___lcextglnext__Conds.Equal(CSGenioAlcext.FldCodlcext, Navigation.GetValue("lcext"));
                    this.ValCodlcext = Navigation.GetStrValue("lcext");
                }
            }

			// Limits Generation

			// Area limit
			produ___lcextglnext__DoLoad &= AddCriteriaAreaLimit(produ___lcextglnext__Conds, CSGenio.business.CSGenioAlocat.FldCodlocat, "locat", this.ValCodlocat, true);


            TableLcextGlnext = new TableDBEdit<Models.Lcext>();
            TableLcextGlnext.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_lcext") != null)
				{
                    this.ValCodlcext = Navigation.GetStrValue("RETURN_lcext");
					Navigation.CurrentLevel.SetEntry("RETURN_lcext", null);
				}
                FillDependant_ProduTableLcextGlnext(lazyLoad);
                //Check if foreignkey comes from history
                TableLcextGlnext.FilledByHistory = Navigation.CheckFilledByHistory("lcext");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodlocat))
                produ___lcextglnext__DoLoad = false;

            if (produ___lcextglnext__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLcextGlnext, "sTableLcextGlnext", "dTableLcextGlnext", qs, "lcext");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlcext.FldGlnext), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLcextGlnext_tableFilters"]))
                    TableLcextGlnext.TableFilters = bool.Parse(qs["TableLcextGlnext_tableFilters"]);
                else
                    TableLcextGlnext.TableFilters = false;

                query = qs["qTableLcextGlnext"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAlcext.FldGlnext, query + "%");
                }
                produ___lcextglnext__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLcextGlnext"] != null ? qs["pTableLcextGlnext"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext, CSGenioAlcext.FldZzstate };

// USE /[MANUAL GQT OVERRQ PRODU_LCEXTGLNEXT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("lcext", FormMode.New) || Navigation.checkFormMode("lcext", FormMode.Duplicate))
                    produ___lcextglnext__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlcext.FldZzstate, 0)
                        .Equal(CSGenioAlcext.FldCodlcext, Navigation.GetStrValue("lcext")));
                else
                    produ___lcextglnext__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlcext.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //produ___lcextglnext__Conds = Lcext.AddEPH<CSGenioAlcext>(ref UserContext.Current.User, produ___lcextglnext__Conds, "LED_PRODU___LCEXTGLNEXT__");

                FieldRef firstVisibleColumn = new FieldRef("lcext", "glnext");
                ListingMVC<CSGenioAlcext> listing = Models.ModelBase.Where<CSGenioAlcext>(false, produ___lcextglnext__Conds, fields, offset, numberItems, sorts, "LED_PRODU___LCEXTGLNEXT__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLcextGlnext.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLcextGlnext.Query = query;
                TableLcextGlnext.Elements = listing.RowsForViewModel<GenioMVC.Models.Lcext>((r) => new GenioMVC.Models.Lcext(r, true, _fieldsToSerialize_PRODU___LCEXTGLNEXT__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_lcext") != null)
				{
					this.ValCodlcext = Navigation.GetStrValue("RETURN_lcext");
					Navigation.CurrentLevel.SetEntry("RETURN_lcext", null);
				}

				TableLcextGlnext.List = new SelectList(TableLcextGlnext.Elements.ToSelectList(x => x.ValGlnext, x => x.ValCodlcext,  x => x.ValCodlcext == this.ValCodlcext), "Value", "Text", this.ValCodlcext);
                FillDependant_ProduTableLcextGlnext();

                //Check if foreignkey comes from history
                TableLcextGlnext.FilledByHistory = Navigation.CheckFilledByHistory("lcext");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLcextGlnext (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Lcext</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProduTableLcextGlnext(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "lcext.codlcext", "lcext.glnext" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("locat");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAlcext.FldCodlocat, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAlcext tempArea = new CSGenioAlcext(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlcext.FldCodlcext, PKey));
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
        /// Fill Dependant fields values -> TableLcextGlnext (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ProduTableLcextGlnext(bool lazyLoad = false)
        {
            var row = GetDependant_ProduTableLcextGlnext(this.ValCodlcext, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodlcext = ViewModelConversion.ToString(row["lcext.codlcext"]);
                TableLcextGlnext.Value = ViewModelConversion.ToString(row["lcext.glnext"]);
                if (GlobalFunctions.emptyG(this.ValCodlcext) == 1)
                {
                    this.ValCodlcext = "";
                    TableLcextGlnext.Value = "";
                    Navigation.ClearValue("lcext");
                }
                else if (lazyLoad)
                {
                    TableLcextGlnext.SetPagination(1, 0, false, false, 1);
                    TableLcextGlnext.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodlcext),
                            Text = Convert.ToString(TableLcextGlnext.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodlcext);
                }
                TableLcextGlnext.Selected = this.ValCodlcext;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLcextGlnext): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PRODU___LCEXTGLNEXT__ = { "Lcext", "Lcext.ValCodlcext", "Lcext.ValZzstate", "Lcext.ValGlnext" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PRODU]/
		#endregion
	}
}
