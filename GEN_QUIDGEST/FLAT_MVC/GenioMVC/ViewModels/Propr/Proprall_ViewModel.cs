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

namespace GenioMVC.ViewModels.Propr
{
	public class Proprall_ViewModel : FormViewModel<Models.Propr>
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

		/// <summary>Campo : "real estate" Tipo:"C"</summary>
		[Display(Name = "REAL_ESTATE15399", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Estimated price" Tipo:"$D"</summary>
		[Display(Name = "ESTIMATED_PRICE02986", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoest { get; set; }

		/// <summary>Campo : "Property Type" Tipo:"C"</summary>
		[Display(Name = "PROPERTY_TYPE33991", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tppro>  TableTpproTppropri { get; set; }

		/// <summary>Campo : "Furnished" Tipo:"L"</summary>
		[Display(Name = "FURNISHED37431", ResourceType = typeof(Resources.Resources))]
		public bool ValMobilada { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cntry>  TableCntryCountry { get; set; }

		/// <summary>Campo : "Region" Tipo:"C"</summary>
		[Display(Name = "REGION12723", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Regio>  TableRegioRegiao { get; set; }

		/// <summary>Campo : "Address" Tipo:"MO"</summary>
		[Display(Name = "ADDRESS04342", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValEndereco { get; set; }

		/// <summary>Campo : "Localization" Tipo:"C"</summary>
		[Display(Name = "LOCALIZATION34148", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValLocalida { get; set; }

		/// <summary>Campo : "Zipcode" Tipo:"C"</summary>
		[Display(Name = "ZIPCODE21021", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPostalco { get; set; }

		/// <summary>Campo : "Zipcode" Tipo:"C"</summary>
		[Display(Name = "ZIPCODE21021", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPostallo { get; set; }

		/// <summary>Campo : "Bathroom" Tipo:"N"</summary>
		[Display(Name = "BATHROOM12866", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtd_wc { get; set; }

		/// <summary>Campo : "Rooms" Tipo:"N"</summary>
		[Display(Name = "ROOMS06809", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdquart { get; set; }

		/// <summary>Campo : "Square meters" Tipo:"N"</summary>
		[Display(Name = "SQUARE_METERS28913", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValM2 { get; set; }

		/// <summary>Campo : "Available from" Tipo:"D"</summary>
		[Display(Name = "AVAILABLE_FROM53703", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtdispon { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[UIHint("tinymce")]
		[AllowHtml, Helpers.Attributes.HtmlSanitizer(isDocument: true)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "Geographic Coordinates" Tipo:"GG"</summary>
		[Display(Name = "GEOGRAPHIC_COORDINAT42880", ResourceType = typeof(Resources.Resources))]
		[UIHint("GoogleMaps")]
		public string ValCoordgeo { get; set; }

		/// <summary>Campo : "Seller" Tipo:"C"</summary>
		[Display(Name = "SELLER36870", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pesso>  TablePessoName { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public string ValCodcntry { get; set; }

		public string ValCodpais1 { get; set; }

		[Display(Name = "SELLER36870", ResourceType = typeof(Resources.Resources))]
		public string ValCodpesso { get; set; }

		[Display(Name = "REGION12723", ResourceType = typeof(Resources.Resources))]
		public string ValCodregia { get; set; }

		[Display(Name = "PROPERTY_TYPE33991", ResourceType = typeof(Resources.Resources))]
		public string ValCodtppro { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodpropr { get; set; }

		public Proprall_ViewModel() : base("FPROPRALL") { }

		public Proprall_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPROPRALL", currentNavigation, nestedForm) { }

		public Proprall_ViewModel(Models.Propr row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPROPRALL", row, currentNavigation, nestedForm) { }

		public Proprall_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("propr", id);
			Model = Models.Propr.Find(id, "FPROPRALL", fieldsToQuery: fieldsToLoad);
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
			Models.Propr model = new Models.Propr() { Identifier = "FPROPRALL" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Propr model)
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

		public static StatusMessage DeleteConditions(Models.Propr model)
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

		public static StatusMessage ViewConditions(Models.Propr model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Propr model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Proprall) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValPrecoest = ViewModelConversion.ToNumeric(m.ValPrecoest);
 				ValMobilada = ViewModelConversion.ToLogic(m.ValMobilada);
 				ValEndereco = ViewModelConversion.ToString(m.ValEndereco);
 				ValLocalida = ViewModelConversion.ToString(m.ValLocalida);
 				ValPostalco = ViewModelConversion.ToString(m.ValPostalco);
 				ValPostallo = ViewModelConversion.ToString(m.ValPostallo);
 				ValQtd_wc = ViewModelConversion.ToNumeric(m.ValQtd_wc);
 				ValQtdquart = ViewModelConversion.ToNumeric(m.ValQtdquart);
 				ValM2 = ViewModelConversion.ToNumeric(m.ValM2);
 				ValDtdispon = ViewModelConversion.ToDateTime(m.ValDtdispon);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
 				ValCodpais1 = ViewModelConversion.ToString(m.ValCodpais1);
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
 				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
 				ValCodtppro = ViewModelConversion.ToString(m.ValCodtppro);
 				ValCodpropr = ViewModelConversion.ToString(m.ValCodpropr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Proprall) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proprall) to Model (Propr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValPrecoest = ViewModelConversion.ToNumeric(ValPrecoest);
				m.ValMobilada = ViewModelConversion.ToLogic(ValMobilada);
				m.ValEndereco = ViewModelConversion.ToString(ValEndereco);
				m.ValLocalida = ViewModelConversion.ToString(ValLocalida);
				m.ValPostalco = ViewModelConversion.ToString(ValPostalco);
				m.ValPostallo = ViewModelConversion.ToString(ValPostallo);
				m.ValQtd_wc = ViewModelConversion.ToNumeric(ValQtd_wc);
				m.ValQtdquart = ViewModelConversion.ToNumeric(ValQtdquart);
				m.ValM2 = ViewModelConversion.ToNumeric(ValM2);
				m.ValDtdispon = ViewModelConversion.ToDateTime(ValDtdispon);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpais1 = ViewModelConversion.ToString(ValCodpais1);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodtppro = ViewModelConversion.ToString(ValCodtppro);
				m.ValCodpropr = ViewModelConversion.ToString(ValCodpropr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proprall) to Model (Propr) - Error during mapping");
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
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), "FPROPRALL");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Propr() { Identifier = "FPROPRALL" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("propr");
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

			Model.Identifier = "FPROPRALL";
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

		protected override void LoadDocumentsProperties(Models.Propr row)
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
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), "FPROPRALL");
				if (Model == null)
				{
					Model = new Models.Propr() { Identifier = "FPROPRALL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("propr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Propralltpprotppropri(qs, lazyLoad);
			Load_Proprallcntrycountry_(qs, lazyLoad);
			Load_Proprallregioregiao__(qs, lazyLoad);
			Load_Proprallpessoname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROPRALL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROPRALL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PROPRALL]/
		public override void Save()
		{

			try { Model = Models.Propr.Find(Navigation.GetStrValue("propr"), "FPROPRALL"); }
			finally { if (Model == null) Model = new Models.Propr() { Identifier = "FPROPRALL" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROPRALL]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Propr.Find(Navigation.GetStrValue("propr"), "FPROPRALL"); }
			finally { if (Model == null) Model = new Models.Propr() { Identifier = "FPROPRALL" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROPRALL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROPRALL]/
		public override void Destroy(string id)
		{
			Model = Models.Propr.Find(id, "FPROPRALL");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableTpproTppropri -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Propralltpprotppropri(NameValueCollection qs, bool lazyLoad = false)
        {
            bool propralltpprotppropriDoLoad = true;
            CriteriaSet propralltpprotppropriConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tppro", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    propralltpprotppropriConds.Equal(CSGenioAtppro.FldCodtppro, Navigation.GetValue("tppro"));
                    this.ValCodtppro = Navigation.GetStrValue("tppro");
                }
            }



            TableTpproTppropri = new TableDBEdit<Models.Tppro>();
            TableTpproTppropri.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
                    this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}
                FillDependant_ProprallTableTpproTppropri(lazyLoad);
                //Check if foreignkey comes from history
                TableTpproTppropri.FilledByHistory = Navigation.CheckFilledByHistory("tppro");
                return;
            }


            if (propralltpprotppropriDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpproTppropri, "sTableTpproTppropri", "dTableTpproTppropri", qs, "tppro");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtppro.FldTppropri), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpproTppropri_tableFilters"]))
                    TableTpproTppropri.TableFilters = bool.Parse(qs["TableTpproTppropri_tableFilters"]);
                else
                    TableTpproTppropri.TableFilters = false;

                query = qs["qTableTpproTppropri"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtppro.FldTppropri, query + "%");
                }
                propralltpprotppropriConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpproTppropri"] != null ? qs["pTableTpproTppropri"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioAtppro.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_TPPROTPPROPRI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tppro", FormMode.New) || Navigation.checkFormMode("tppro", FormMode.Duplicate))
                    propralltpprotppropriConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtppro.FldZzstate, 0)
                        .Equal(CSGenioAtppro.FldCodtppro, Navigation.GetStrValue("tppro")));
                else
                    propralltpprotppropriConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtppro.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //propralltpprotppropriConds = Tppro.AddEPH<CSGenioAtppro>(ref UserContext.Current.User, propralltpprotppropriConds, "LED_PROPRALLTPPROTPPROPRI");

                FieldRef firstVisibleColumn = new FieldRef("tppro", "tppropri");
                ListingMVC<CSGenioAtppro> listing = Models.ModelBase.Where<CSGenioAtppro>(false, propralltpprotppropriConds, fields, offset, numberItems, sorts, "LED_PROPRALLTPPROTPPROPRI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpproTppropri.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpproTppropri.Query = query;
                TableTpproTppropri.Elements = listing.RowsForViewModel<GenioMVC.Models.Tppro>((r) => new GenioMVC.Models.Tppro(r, true, _fieldsToSerialize_PROPRALLTPPROTPPROPRI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
					this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}

				TableTpproTppropri.List = new SelectList(TableTpproTppropri.Elements.ToSelectList(x => x.ValTppropri, x => x.ValCodtppro,  x => x.ValCodtppro == this.ValCodtppro), "Value", "Text", this.ValCodtppro);
                FillDependant_ProprallTableTpproTppropri();

                //Check if foreignkey comes from history
                TableTpproTppropri.FilledByHistory = Navigation.CheckFilledByHistory("tppro");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpproTppropri (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tppro</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProprallTableTpproTppropri(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tppro.codtppro", "tppro.tppropri" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri };
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
            CSGenioAtppro tempArea = new CSGenioAtppro(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtppro.FldCodtppro, PKey));
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
        /// Fill Dependant fields values -> TableTpproTppropri (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ProprallTableTpproTppropri(bool lazyLoad = false)
        {
            var row = GetDependant_ProprallTableTpproTppropri(this.ValCodtppro, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtppro = ViewModelConversion.ToString(row["tppro.codtppro"]);
                TableTpproTppropri.Value = ViewModelConversion.ToString(row["tppro.tppropri"]);
                if (GlobalFunctions.emptyG(this.ValCodtppro) == 1)
                {
                    this.ValCodtppro = "";
                    TableTpproTppropri.Value = "";
                    Navigation.ClearValue("tppro");
                }
                else if (lazyLoad)
                {
                    TableTpproTppropri.SetPagination(1, 0, false, false, 1);
                    TableTpproTppropri.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtppro),
                            Text = Convert.ToString(TableTpproTppropri.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtppro);
                }
                TableTpproTppropri.Selected = this.ValCodtppro;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpproTppropri): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PROPRALLTPPROTPPROPRI = { "Tppro", "Tppro.ValCodtppro", "Tppro.ValZzstate", "Tppro.ValTppropri" };

        /// <summary>
        /// TableCntryCountry -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Proprallcntrycountry_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool proprallcntrycountry_DoLoad = true;
            CriteriaSet proprallcntrycountry_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cntry", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    proprallcntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
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
                FillDependant_ProprallTableCntryCountry(lazyLoad);
                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
                return;
            }


            if (proprallcntrycountry_DoLoad)
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
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
                }
                proprallcntrycountry_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_CNTRYCOUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
                    proprallcntrycountry_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcntry.FldZzstate, 0)
                        .Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
                else
                    proprallcntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //proprallcntrycountry_Conds = Cntry.AddEPH<CSGenioAcntry>(ref UserContext.Current.User, proprallcntrycountry_Conds, "LED_PROPRALLCNTRYCOUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
                ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(false, proprallcntrycountry_Conds, fields, offset, numberItems, sorts, "LED_PROPRALLCNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCntryCountry.Query = query;
                TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(r, true, _fieldsToSerialize_PROPRALLCNTRYCOUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
                FillDependant_ProprallTableCntryCountry();

                //Check if foreignkey comes from history
                TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCntryCountry (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cntry</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProprallTableCntryCountry(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cntry.codcntry", "cntry.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };
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
        public void FillDependant_ProprallTableCntryCountry(bool lazyLoad = false)
        {
            var row = GetDependant_ProprallTableCntryCountry(this.ValCodcntry, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
                TableCntryCountry.Value = ViewModelConversion.ToString(row["cntry.country"]);
                if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
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


        private readonly string[] _fieldsToSerialize_PROPRALLCNTRYCOUNTRY_ = { "Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry" };

        /// <summary>
        /// TableRegioRegiao -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Proprallregioregiao__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool proprallregioregiao__DoLoad = true;
            CriteriaSet proprallregioregiao__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("regio", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    proprallregioregiao__Conds.Equal(CSGenioAregio.FldCodregia, Navigation.GetValue("regio"));
                    this.ValCodregia = Navigation.GetStrValue("regio");
                }
            }

			// Limits Generation

			// Area limit
			proprallregioregiao__DoLoad &= AddCriteriaAreaLimit(proprallregioregiao__Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, true);


            TableRegioRegiao = new TableDBEdit<Models.Regio>();
            TableRegioRegiao.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
                    this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}
                FillDependant_ProprallTableRegioRegiao(lazyLoad);
                //Check if foreignkey comes from history
                TableRegioRegiao.FilledByHistory = Navigation.CheckFilledByHistory("regio");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodcntry))
                proprallregioregiao__DoLoad = false;

            if (proprallregioregiao__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRegioRegiao, "sTableRegioRegiao", "dTableRegioRegiao", qs, "regio");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregio.FldRegiao), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRegioRegiao_tableFilters"]))
                    TableRegioRegiao.TableFilters = bool.Parse(qs["TableRegioRegiao_tableFilters"]);
                else
                    TableRegioRegiao.TableFilters = false;

                query = qs["qTableRegioRegiao"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAregio.FldRegiao, query + "%");
                }
                proprallregioregiao__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRegioRegiao"] != null ? qs["pTableRegioRegiao"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioAregio.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_REGIOREGIAO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("regio", FormMode.New) || Navigation.checkFormMode("regio", FormMode.Duplicate))
                    proprallregioregiao__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAregio.FldZzstate, 0)
                        .Equal(CSGenioAregio.FldCodregia, Navigation.GetStrValue("regio")));
                else
                    proprallregioregiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregio.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //proprallregioregiao__Conds = Regio.AddEPH<CSGenioAregio>(ref UserContext.Current.User, proprallregioregiao__Conds, "LED_PROPRALLREGIOREGIAO__");

                FieldRef firstVisibleColumn = new FieldRef("regio", "regiao");
                ListingMVC<CSGenioAregio> listing = Models.ModelBase.Where<CSGenioAregio>(false, proprallregioregiao__Conds, fields, offset, numberItems, sorts, "LED_PROPRALLREGIOREGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRegioRegiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRegioRegiao.Query = query;
                TableRegioRegiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regio>((r) => new GenioMVC.Models.Regio(r, true, _fieldsToSerialize_PROPRALLREGIOREGIAO__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}

				TableRegioRegiao.List = new SelectList(TableRegioRegiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
                FillDependant_ProprallTableRegioRegiao();

                //Check if foreignkey comes from history
                TableRegioRegiao.FilledByHistory = Navigation.CheckFilledByHistory("regio");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRegioRegiao (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Regio</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProprallTableRegioRegiao(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "regio.codregia", "regio.regiao" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("cntry");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAregio.FldCodcntry, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAregio tempArea = new CSGenioAregio(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAregio.FldCodregia, PKey));
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
        /// Fill Dependant fields values -> TableRegioRegiao (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ProprallTableRegioRegiao(bool lazyLoad = false)
        {
            var row = GetDependant_ProprallTableRegioRegiao(this.ValCodregia, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodregia = ViewModelConversion.ToString(row["regio.codregia"]);
                TableRegioRegiao.Value = ViewModelConversion.ToString(row["regio.regiao"]);
                if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
                {
                    this.ValCodregia = "";
                    TableRegioRegiao.Value = "";
                    Navigation.ClearValue("regio");
                }
                else if (lazyLoad)
                {
                    TableRegioRegiao.SetPagination(1, 0, false, false, 1);
                    TableRegioRegiao.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodregia),
                            Text = Convert.ToString(TableRegioRegiao.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodregia);
                }
                TableRegioRegiao.Selected = this.ValCodregia;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegioRegiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PROPRALLREGIOREGIAO__ = { "Regio", "Regio.ValCodregia", "Regio.ValZzstate", "Regio.ValRegiao" };

        /// <summary>
        /// TablePessoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Proprallpessoname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool proprallpessoname____DoLoad = true;
            CriteriaSet proprallpessoname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pesso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    proprallpessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
                    this.ValCodpesso = Navigation.GetStrValue("pesso");
                }
            }

			// Limits Generation

			// Area limit
			proprallpessoname____DoLoad &= AddCriteriaAreaLimit(proprallpessoname____Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, true);


            TablePessoName = new TableDBEdit<Models.Pesso>();
            TablePessoName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
                    this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
                FillDependant_ProprallTablePessoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodcntry))
                proprallpessoname____DoLoad = false;

            if (proprallpessoname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
                    TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
                else
                    TablePessoName.TableFilters = false;

                query = qs["qTablePessoName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApesso.FldName, query + "%");
                }
                proprallpessoname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_PESSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
                    proprallpessoname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApesso.FldZzstate, 0)
                        .Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
                else
                    proprallpessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //proprallpessoname____Conds = Pesso.AddEPH<CSGenioApesso>(ref UserContext.Current.User, proprallpessoname____Conds, "LED_PROPRALLPESSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
                ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(false, proprallpessoname____Conds, fields, offset, numberItems, sorts, "LED_PROPRALLPESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePessoName.Query = query;
                TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(r, true, _fieldsToSerialize_PROPRALLPESSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
                FillDependant_ProprallTablePessoName();

                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pesso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ProprallTablePessoName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pesso.codpesso", "pesso.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("cntry");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioApesso.FldCodpaise, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioApesso tempArea = new CSGenioApesso(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ProprallTablePessoName(bool lazyLoad = false)
        {
            var row = GetDependant_ProprallTablePessoName(this.ValCodpesso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
                TablePessoName.Value = ViewModelConversion.ToString(row["pesso.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
                {
                    this.ValCodpesso = "";
                    TablePessoName.Value = "";
                    Navigation.ClearValue("pesso");
                }
                else if (lazyLoad)
                {
                    TablePessoName.SetPagination(1, 0, false, false, 1);
                    TablePessoName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpesso),
                            Text = Convert.ToString(TablePessoName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpesso);
                }
                TablePessoName.Selected = this.ValCodpesso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PROPRALLPESSONAME____ = { "Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName" };



		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValDescript = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValDescript, true);
		}

		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPRALL]/
		#endregion
	}
}
