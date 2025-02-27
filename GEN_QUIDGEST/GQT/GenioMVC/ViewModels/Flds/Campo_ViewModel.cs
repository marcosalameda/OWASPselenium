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

namespace GenioMVC.ViewModels.Flds
{
	public class Campo_ViewModel : FormViewModel<Models.Flds>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Airline" Tipo:"C"</summary>
		[Display(Name = "AIRLINE57868", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Aero>  TableAeroName { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescrip { get; set; }

		/// <summary>Campo : "Passenger capacity on the plane" Tipo:"N"</summary>
		[Display(Name = "PASSENGER_CAPACITY_O45867", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNpassage { get; set; }

		/// <summary>Campo : "Trip Duration" Tipo:"ND"</summary>
		[Display(Name = "TRIP_DURATION54761", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValDuration { get; set; }

		/// <summary>Campo : "Rounded Ticket Price" Tipo:"$"</summary>
		[Display(Name = "ROUNDED_TICKET_PRICE02323", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get; set; }

		/// <summary>Campo : "Ticket price at tenths" Tipo:"$D"</summary>
		[Display(Name = "TICKET_PRICE_AT_TENT46319", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecobil { get; set; }

		/// <summary>Campo : "Departure date (DD/MM/YEAR)" Tipo:"D"</summary>
		[Display(Name = "DEPARTURE_DATE__DD_M27418", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "Departure date (hour)" Tipo:"DT"</summary>
		[Display(Name = "DEPARTURE_DATE__HOUR17284", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get; set; }

		/// <summary>Campo : "Departure date (seconds)" Tipo:"DS"</summary>
		[Display(Name = "DEPARTURE_DATE__SECO42491", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DS")]
		public DateTime? ValDateseco { get; set; }

		/// <summary>Campo : "Departure hour" Tipo:"T"</summary>
		[Display(Name = "DEPARTURE_HOUR28390", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTime { get; set; }

		/// <summary>Campo : "Creation year of the airport" Tipo:"N"</summary>
		[Display(Name = "CREATION_YEAR_OF_THE06011", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYear { get; set; }

		/// <summary>Campo : "1ªViagem" Tipo:"L"</summary>
		[Display(Name = "_1AVIAGEM10982", ResourceType = typeof(Resources.Resources))]
		public bool ValPrimviag { get; set; }

		/// <summary>Campo : "Have you traveled before?" Tipo:"IF"</summary>
		[Display(Name = "HAVE_YOU_TRAVELED_BE53808", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBConditional")]
		[ConditionalBinder]
		public decimal ValConditio { get; set; }

		/// <summary>Campo : "Class (Enumeração de Texto)" Tipo:"AC"</summary>
		[Display(Name = "CLASS__ENUMERACAO_DE17340", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Class", GenioMVC.Helpers.ArrayType.Character)]
		public string ValClass { get; set; }
		[JsonIgnore]
		public SelectList List_ValClass { get; set; }

		/// <summary>Campo : "Classe (Enumeração Numérica)" Tipo:"AN"</summary>
		[Display(Name = "CLASSE__ENUMERACAO_N29443", ResourceType = typeof(Resources.Resources))]
		[DataArray("Classnum", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValClassnum { get; set; }
		[JsonIgnore]
		public SelectList List_ValClassnum { get; set; }

		/// <summary>Campo : "1st trip (Logical Enumeration)" Tipo:"AL"</summary>
		[Display(Name = "_1ST_TRIP__LOGICAL_E36923", ResourceType = typeof(Resources.Resources))]
		[DataArray("Primviag", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValLogicenu { get; set; }
		[JsonIgnore]
		public SelectList List_ValLogicenu { get; set; }

		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValLogo { get; set; }

		/// <summary>Campo : "Attachments" Tipo:"IB"</summary>
		[Display(Name = "ATTACHMENTS19612", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValAttach", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValAttach { get; set; }
		public string ValAttachfk { get; set; }
		public DocumsProperties_ViewModel ValAttachPropertiesVM { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatuse { get; set; }

		/// <summary>Campo : "Creation Date (DD/MM/YY)" Tipo:"OD"</summary>
		[Display(Name = "CREATION_DATE__DD_MM48834", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }

		/// <summary>Campo : "Creation Date" Tipo:"OT"</summary>
		[Display(Name = "CREATION_DATE32161", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("OT")]
		public string ValCreathou { get; set; }

		/// <summary>Campo : "Complete Creation Date" Tipo:"OI"</summary>
		[Display(Name = "COMPLETE_CREATION_DA42963", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OI")]
		public DateTime? ValCreatins { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "AIRLINE57868", ResourceType = typeof(Resources.Resources))]
		public string ValCodaero { get; set; }

		public string ValCodequip { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Enforce table conditions" Tipo: "L"</summary>
		public bool ValTblcond { get; set; }
		// Field to formula
		/// <summary>Field : "Field state" Tipo: "AC"</summary>
		[AllowHtml]
		public string ValCond { get; set; }
		#endregion

		public string ValCodflds { get; set; }

		public Campo_ViewModel() : base("FCAMPO") { }

		public Campo_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCAMPO", currentNavigation, nestedForm) { }

		public Campo_ViewModel(Models.Flds row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCAMPO", row, currentNavigation, nestedForm) { }

		public Campo_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, "FCAMPO", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds() { Identifier = "FCAMPO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Flds model)
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

		public static StatusMessage DeleteConditions(Models.Flds model)
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

		public static StatusMessage ViewConditions(Models.Flds model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Flds model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Campo) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
 				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
 				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
 				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
 				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
 				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
 				ValTime = ViewModelConversion.ToString(m.ValTime);
 				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
 				ValPrimviag = ViewModelConversion.ToLogic(m.ValPrimviag);
 				ValConditio = ViewModelConversion.ToNumeric(m.ValConditio);
 				ValClass = ViewModelConversion.ToString(m.ValClass);
 				ValClassnum = ViewModelConversion.ToNumeric(m.ValClassnum);
 				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
 				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
 				ValAttach = ViewModelConversion.ToString(m.ValAttach);
				ValAttachfk = ViewModelConversion.ToString(m.ValAttachfk);
 				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
 				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
 				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValTblcond = ViewModelConversion.ToLogic(m.ValTblcond);
 				ValCond = ViewModelConversion.ToString(m.ValCond);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Campo) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Campo) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValPrimviag = ViewModelConversion.ToLogic(ValPrimviag);
				m.ValConditio = ViewModelConversion.ToNumeric(ValConditio);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValClassnum = ViewModelConversion.ToNumeric(ValClassnum);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				m.ValAttach = ViewModelConversion.ToString(ValAttach);
				m.ValAttachfk = ViewModelConversion.ToString(ValAttachfk);

				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValTblcond = ViewModelConversion.ToLogic(ValTblcond);
				m.ValCond = ViewModelConversion.ToString(ValCond);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Campo) to Model (Flds) - Error during mapping");
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FCAMPO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Flds() { Identifier = "FCAMPO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
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

			Model.Identifier = "FCAMPO";
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

		protected override void LoadDocumentsProperties(Models.Flds row)
		{
			try
			{
				ValAttachPropertiesVM = row.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				ValAttachPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
			}
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FCAMPO");
				if (Model == null)
				{
					Model = new Models.Flds() { Identifier = "FCAMPO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Campo___aero_name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CAMPO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CAMPO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CAMPO]/
		public override void Save()
		{

			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FCAMPO"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FCAMPO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CAMPO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FCAMPO"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FCAMPO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CAMPO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CAMPO]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, "FCAMPO");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValClass = new SelectList(
				ArrayClass.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClass);
			this.List_ValClassnum = new SelectList(
				ArrayClassnum.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValClassnum);
			this.List_ValLogicenu = new SelectList(
				ArrayPrimviag.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValLogicenu);
		}


        /// <summary>
        /// TableAeroName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Campo___aero_name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool campo___aero_name____DoLoad = true;
            CriteriaSet campo___aero_name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("aero", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    campo___aero_name____Conds.Equal(CSGenioAaero.FldCodaero, Navigation.GetValue("aero"));
                    this.ValCodaero = Navigation.GetStrValue("aero");
                }
            }



            TableAeroName = new TableDBEdit<Models.Aero>();
            TableAeroName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
                    this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}
                FillDependant_CampoTableAeroName(lazyLoad);
                //Check if foreignkey comes from history
                TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
                return;
            }


            if (campo___aero_name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableAeroName, "sTableAeroName", "dTableAeroName", qs, "aero");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAaero.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableAeroName_tableFilters"]))
                    TableAeroName.TableFilters = bool.Parse(qs["TableAeroName_tableFilters"]);
                else
                    TableAeroName.TableFilters = false;

                query = qs["qTableAeroName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAaero.FldName, query + "%");
                }
                campo___aero_name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAeroName"] != null ? qs["pTableAeroName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAaero.FldZzstate };

// USE /[MANUAL GQT OVERRQ CAMPO_AERONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("aero", FormMode.New) || Navigation.checkFormMode("aero", FormMode.Duplicate))
                    campo___aero_name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAaero.FldZzstate, 0)
                        .Equal(CSGenioAaero.FldCodaero, Navigation.GetStrValue("aero")));
                else
                    campo___aero_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAaero.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //campo___aero_name____Conds = Aero.AddEPH<CSGenioAaero>(ref UserContext.Current.User, campo___aero_name____Conds, "LED_CAMPO___AERO_NAME____");

                FieldRef firstVisibleColumn = new FieldRef("aero", "name");
                ListingMVC<CSGenioAaero> listing = Models.ModelBase.Where<CSGenioAaero>(false, campo___aero_name____Conds, fields, offset, numberItems, sorts, "LED_CAMPO___AERO_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAeroName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAeroName.Query = query;
                TableAeroName.Elements = listing.RowsForViewModel<GenioMVC.Models.Aero>((r) => new GenioMVC.Models.Aero(r, true, _fieldsToSerialize_CAMPO___AERO_NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}

				TableAeroName.List = new SelectList(TableAeroName.Elements.ToSelectList(x => x.ValName, x => x.ValCodaero,  x => x.ValCodaero == this.ValCodaero), "Value", "Text", this.ValCodaero);
                if(!isSearchRequest)
                    FillDependant_CampoTableAeroName();

                //Check if foreignkey comes from history
                TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAeroName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Aero</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_CampoTableAeroName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "aero.codaero", "aero.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAaero.FldCodaero, CSGenioAaero.FldName };
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
            CSGenioAaero tempArea = new CSGenioAaero(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAaero.FldCodaero, PKey));
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
        /// Fill Dependant fields values -> TableAeroName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_CampoTableAeroName(bool lazyLoad = false)
        {
            var row = GetDependant_CampoTableAeroName(this.ValCodaero, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodaero = ViewModelConversion.ToString(row["aero.codaero"]);
                TableAeroName.Value = ViewModelConversion.ToString(row["aero.name"]);
                if (GlobalFunctions.emptyG(this.ValCodaero) == 1)
                {
                    this.ValCodaero = "";
                    TableAeroName.Value = "";
                    Navigation.ClearValue("aero");
                }
                else if (lazyLoad)
                {
                    TableAeroName.SetPagination(1, 0, false, false, 1);
                    TableAeroName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodaero),
                            Text = Convert.ToString(TableAeroName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodaero);
                }
                TableAeroName.Selected = this.ValCodaero;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAeroName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_CAMPO___AERO_NAME____ = { "Aero", "Aero.ValCodaero", "Aero.ValZzstate", "Aero.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CAMPO]/
		#endregion
	}
}
