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

namespace GenioMVC.ViewModels.Entit
{
	public class Entit_ViewModel : FormViewModel<Models.Entit>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Legal name" Tipo:"C"</summary>
		[Display(Name = "LEGAL_NAME42902", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Company initials" Tipo:"C"</summary>
		[Display(Name = "COMPANY_INITIALS56204", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValInitials { get; set; }

		/// <summary>Campo : "Legal registration" Tipo:"C"</summary>
		[Display(Name = "LEGAL_REGISTRATION04413", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegistra { get; set; }

		/// <summary>Campo : "VAT Number" Tipo:"C"</summary>
		[Display(Name = "VAT_NUMBER24236", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTaxnumbe { get; set; }

		/// <summary>Campo : "Email" Tipo:"C"</summary>
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "Phone number" Tipo:"C"</summary>
		[Display(Name = "PHONE_NUMBER20774", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPhonenum { get; set; }

		/// <summary>Campo : "IBAN (International Bank Account Number)" Tipo:"C"</summary>
		[Display(Name = "IBAN__INTERNATIONAL_45066", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(25, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIban { get; set; }

		/// <summary>Campo : "Building/house number" Tipo:"C"</summary>
		[Display(Name = "BUILDING_HOUSE_NUMBE20738", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBuilding { get; set; }

		/// <summary>Campo : "Street" Tipo:"C"</summary>
		[Display(Name = "STREET44324", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValStreet { get; set; }

		/// <summary>Campo : "Town/City" Tipo:"C"</summary>
		[Display(Name = "TOWN_CITY16259", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTown { get; set; }

		/// <summary>Campo : "County/Province" Tipo:"C"</summary>
		[Display(Name = "COUNTY_PROVINCE34285", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCounty { get; set; }

		/// <summary>Campo : "State/Province" Tipo:"C"</summary>
		[Display(Name = "STATE_PROVINCE28516", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValState { get; set; }

		/// <summary>Campo : "Post office box" Tipo:"C"</summary>
		[Display(Name = "POST_OFFICE_BOX06223", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPobox { get; set; }

		/// <summary>Campo : "ZIP/Postal code" Tipo:"C"</summary>
		[Display(Name = "ZIP_POSTAL_CODE55613", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPostalco { get; set; }

		/// <summary>Campo : "Telephone" Tipo:"C"</summary>
		[Display(Name = "TELEPHONE28697", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTelephon { get; set; }

		/// <summary>Campo : "Fax" Tipo:"C"</summary>
		[Display(Name = "FAX08532", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFax { get; set; }

		/// <summary>Campo : "Web site" Tipo:"C"</summary>
		[Display(Name = "WEB_SITE06263", ResourceType = typeof(Resources.Resources))]
		[RegularExpression(@"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\/\?\.\:\;\'\,]*)?$",ErrorMessageResourceName = "ENDERECO_INVALIDO_40706", ErrorMessageResourceType = typeof(Resources.Resources))]
		[HyperLink]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValWebsite { get; set; }

		/// <summary>Campo : "Person/Department to contact" Tipo:"C"</summary>
		[Display(Name = "PERSON_DEPARTMENT_TO28777", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPerson { get; set; }

		/// <summary>Campo : "Contact telephone number" Tipo:"C"</summary>
		[Display(Name = "CONTACT_TELEPHONE_NU12694", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValContact { get; set; }

		/// <summary>Campo : "Owner" Tipo:"L"</summary>
		[Display(Name = "OWNER09558", ResourceType = typeof(Resources.Resources))]
		public bool ValOwner { get; set; }

		/// <summary>Campo : "Carrier" Tipo:"L"</summary>
		[Display(Name = "CARRIER64855", ResourceType = typeof(Resources.Resources))]
		public bool ValCarrier { get; set; }

		/// <summary>Campo : "Supplier" Tipo:"L"</summary>
		[Display(Name = "SUPPLIER17230", ResourceType = typeof(Resources.Resources))]
		public bool ValSupplier { get; set; }

		/// <summary>Campo : "Manufacturer" Tipo:"L"</summary>
		[Display(Name = "MANUFACTURER50759", ResourceType = typeof(Resources.Resources))]
		public bool ValManufact { get; set; }

		/// <summary>Campo : "Founded in" Tipo:"D"</summary>
		[Display(Name = "FOUNDED_IN54120", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValFounded { get; set; }

		/// <summary>Campo : "Facility name" Tipo:"C"</summary>
		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Faci1>  TableFaci1Name { get; set; }

		/// <summary>Campo : "Facility name" Tipo:"C"</summary>
		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Faci2>  TableFaci2Name { get; set; }

		/// <summary>Campo : "Language" Tipo:"C"</summary>
		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(2, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValLanguage { get; set; }

		/// <summary>Campo : "Currency" Tipo:"C"</summary>
		[Display(Name = "CURRENCY13881", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(3, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCurrency { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public string ValFirstfacilitie { get; set; }

		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		public string ValLastfacilitie { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodentit { get; set; }

		public Entit_ViewModel() : base("FENTIT") { }

		public Entit_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FENTIT", currentNavigation, nestedForm) { }

		public Entit_ViewModel(Models.Entit row, NavigationContext currentNavigation, bool nestedForm = false) : base("FENTIT", row, currentNavigation, nestedForm) { }

		public Entit_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("entit", id);
			Model = Models.Entit.Find(id, "FENTIT", fieldsToQuery: fieldsToLoad);
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
			Models.Entit model = new Models.Entit() { Identifier = "FENTIT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Entit model)
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

		public static StatusMessage DeleteConditions(Models.Entit model)
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

		public static StatusMessage ViewConditions(Models.Entit model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Entit model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Entit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Entit) to ViewModel (Entit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValInitials = ViewModelConversion.ToString(m.ValInitials);
 				ValRegistra = ViewModelConversion.ToString(m.ValRegistra);
 				ValTaxnumbe = ViewModelConversion.ToString(m.ValTaxnumbe);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				ValPhonenum = ViewModelConversion.ToString(m.ValPhonenum);
 				ValIban = ViewModelConversion.ToString(m.ValIban);
 				ValBuilding = ViewModelConversion.ToString(m.ValBuilding);
 				ValStreet = ViewModelConversion.ToString(m.ValStreet);
 				ValTown = ViewModelConversion.ToString(m.ValTown);
 				ValCounty = ViewModelConversion.ToString(m.ValCounty);
 				ValState = ViewModelConversion.ToString(m.ValState);
 				ValPobox = ViewModelConversion.ToString(m.ValPobox);
 				ValPostalco = ViewModelConversion.ToString(m.ValPostalco);
 				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
 				ValFax = ViewModelConversion.ToString(m.ValFax);
 				ValWebsite = ViewModelConversion.ToString(m.ValWebsite);
 				ValPerson = ViewModelConversion.ToString(m.ValPerson);
 				ValContact = ViewModelConversion.ToString(m.ValContact);
 				ValOwner = ViewModelConversion.ToLogic(m.ValOwner);
 				ValCarrier = ViewModelConversion.ToLogic(m.ValCarrier);
 				ValSupplier = ViewModelConversion.ToLogic(m.ValSupplier);
 				ValManufact = ViewModelConversion.ToLogic(m.ValManufact);
 				ValFounded = ViewModelConversion.ToDateTime(m.ValFounded);
 				ValLanguage = ViewModelConversion.ToString(m.ValLanguage);
 				ValCurrency = ViewModelConversion.ToString(m.ValCurrency);
 				ValFirstfacilitie = ViewModelConversion.ToString(m.ValFirstfacilitie);
 				ValLastfacilitie = ViewModelConversion.ToString(m.ValLastfacilitie);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Entit) to ViewModel (Entit) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Entit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Entit) to Model (Entit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValInitials = ViewModelConversion.ToString(ValInitials);
				m.ValRegistra = ViewModelConversion.ToString(ValRegistra);
				m.ValTaxnumbe = ViewModelConversion.ToString(ValTaxnumbe);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValPhonenum = ViewModelConversion.ToString(ValPhonenum);
				m.ValIban = ViewModelConversion.ToString(ValIban);
				m.ValBuilding = ViewModelConversion.ToString(ValBuilding);
				m.ValStreet = ViewModelConversion.ToString(ValStreet);
				m.ValTown = ViewModelConversion.ToString(ValTown);
				m.ValCounty = ViewModelConversion.ToString(ValCounty);
				m.ValState = ViewModelConversion.ToString(ValState);
				m.ValPobox = ViewModelConversion.ToString(ValPobox);
				m.ValPostalco = ViewModelConversion.ToString(ValPostalco);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValFax = ViewModelConversion.ToString(ValFax);
				m.ValWebsite = ViewModelConversion.ToString(ValWebsite);
				m.ValPerson = ViewModelConversion.ToString(ValPerson);
				m.ValContact = ViewModelConversion.ToString(ValContact);
				m.ValOwner = ViewModelConversion.ToLogic(ValOwner);
				m.ValCarrier = ViewModelConversion.ToLogic(ValCarrier);
				m.ValSupplier = ViewModelConversion.ToLogic(ValSupplier);
				m.ValManufact = ViewModelConversion.ToLogic(ValManufact);
				m.ValFounded = ViewModelConversion.ToDateTime(ValFounded);
				m.ValLanguage = ViewModelConversion.ToString(ValLanguage);
				m.ValCurrency = ViewModelConversion.ToString(ValCurrency);
				m.ValFirstfacilitie = ViewModelConversion.ToString(ValFirstfacilitie);
				m.ValLastfacilitie = ViewModelConversion.ToString(ValLastfacilitie);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Entit) to Model (Entit) - Error during mapping");
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
				Model = Models.Entit.Find(Navigation.GetStrValue("entit"), "FENTIT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Entit() { Identifier = "FENTIT" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("entit");
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

			Model.Identifier = "FENTIT";
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

		protected override void LoadDocumentsProperties(Models.Entit row)
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
				Model = Models.Entit.Find(Navigation.GetStrValue("entit"), "FENTIT");
				if (Model == null)
				{
					Model = new Models.Entit() { Identifier = "FENTIT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("entit");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Entit___faci1name____(qs, lazyLoad);
			Load_Entit___faci2name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ENTIT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ENTIT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ENTIT]/
		public override void Save()
		{

			try { Model = Models.Entit.Find(Navigation.GetStrValue("entit"), "FENTIT"); }
			finally { if (Model == null) Model = new Models.Entit() { Identifier = "FENTIT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ENTIT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Entit.Find(Navigation.GetStrValue("entit"), "FENTIT"); }
			finally { if (Model == null) Model = new Models.Entit() { Identifier = "FENTIT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ENTIT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ENTIT]/
		public override void Destroy(string id)
		{
			Model = Models.Entit.Find(id, "FENTIT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableFaci1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Entit___faci1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool entit___faci1name____DoLoad = true;
            CriteriaSet entit___faci1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("faci1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    entit___faci1name____Conds.Equal(CSGenioAfaci1.FldCodfacil, Navigation.GetValue("faci1"));
                    this.ValFirstfacilitie = Navigation.GetStrValue("faci1");
                }
            }



            TableFaci1Name = new TableDBEdit<Models.Faci1>();
            TableFaci1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_faci1") != null)
				{
                    this.ValFirstfacilitie = Navigation.GetStrValue("RETURN_faci1");
					Navigation.CurrentLevel.SetEntry("RETURN_faci1", null);
				}
                FillDependant_EntitTableFaci1Name(lazyLoad);
                //Check if foreignkey comes from history
                TableFaci1Name.FilledByHistory = Navigation.CheckFilledByHistory("faci1");
                return;
            }


            if (entit___faci1name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFaci1Name, "sTableFaci1Name", "dTableFaci1Name", qs, "faci1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfaci1.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFaci1Name_tableFilters"]))
                    TableFaci1Name.TableFilters = bool.Parse(qs["TableFaci1Name_tableFilters"]);
                else
                    TableFaci1Name.TableFilters = false;

                query = qs["qTableFaci1Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfaci1.FldName, query + "%");
                }
                entit___faci1name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFaci1Name"] != null ? qs["pTableFaci1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAfaci1.FldZzstate };

// USE /[MANUAL GQT OVERRQ ENTIT_FACI1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("faci1", FormMode.New) || Navigation.checkFormMode("faci1", FormMode.Duplicate))
                    entit___faci1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfaci1.FldZzstate, 0)
                        .Equal(CSGenioAfaci1.FldCodfacil, Navigation.GetStrValue("faci1")));
                else
                    entit___faci1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfaci1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //entit___faci1name____Conds = Faci1.AddEPH<CSGenioAfaci1>(ref UserContext.Current.User, entit___faci1name____Conds, "LED_ENTIT___FACI1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("faci1", "name");
                ListingMVC<CSGenioAfaci1> listing = Models.ModelBase.Where<CSGenioAfaci1>(false, entit___faci1name____Conds, fields, offset, numberItems, sorts, "LED_ENTIT___FACI1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFaci1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFaci1Name.Query = query;
                TableFaci1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Faci1>((r) => new GenioMVC.Models.Faci1(r, true, _fieldsToSerialize_ENTIT___FACI1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_faci1") != null)
				{
					this.ValFirstfacilitie = Navigation.GetStrValue("RETURN_faci1");
					Navigation.CurrentLevel.SetEntry("RETURN_faci1", null);
				}

				TableFaci1Name.List = new SelectList(TableFaci1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodfacil,  x => x.ValCodfacil == this.ValFirstfacilitie), "Value", "Text", this.ValFirstfacilitie);
                FillDependant_EntitTableFaci1Name();

                //Check if foreignkey comes from history
                TableFaci1Name.FilledByHistory = Navigation.CheckFilledByHistory("faci1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFaci1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Faci1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EntitTableFaci1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "faci1.codfacil", "faci1.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName };
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
            CSGenioAfaci1 tempArea = new CSGenioAfaci1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfaci1.FldCodfacil, PKey));
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
        /// Fill Dependant fields values -> TableFaci1Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EntitTableFaci1Name(bool lazyLoad = false)
        {
            var row = GetDependant_EntitTableFaci1Name(this.ValFirstfacilitie, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValFirstfacilitie = ViewModelConversion.ToString(row["faci1.codfacil"]);
                TableFaci1Name.Value = ViewModelConversion.ToString(row["faci1.name"]);
                if (GlobalFunctions.emptyG(this.ValFirstfacilitie) == 1)
                {
                    this.ValFirstfacilitie = "";
                    TableFaci1Name.Value = "";
                    Navigation.ClearValue("faci1");
                }
                else if (lazyLoad)
                {
                    TableFaci1Name.SetPagination(1, 0, false, false, 1);
                    TableFaci1Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValFirstfacilitie),
                            Text = Convert.ToString(TableFaci1Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValFirstfacilitie);
                }
                TableFaci1Name.Selected = this.ValFirstfacilitie;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFaci1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ENTIT___FACI1NAME____ = { "Faci1", "Faci1.ValCodfacil", "Faci1.ValZzstate", "Faci1.ValName" };

        /// <summary>
        /// TableFaci2Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Entit___faci2name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool entit___faci2name____DoLoad = true;
            CriteriaSet entit___faci2name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("faci2", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    entit___faci2name____Conds.Equal(CSGenioAfaci2.FldCodfacil, Navigation.GetValue("faci2"));
                    this.ValLastfacilitie = Navigation.GetStrValue("faci2");
                }
            }



            TableFaci2Name = new TableDBEdit<Models.Faci2>();
            TableFaci2Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_faci2") != null)
				{
                    this.ValLastfacilitie = Navigation.GetStrValue("RETURN_faci2");
					Navigation.CurrentLevel.SetEntry("RETURN_faci2", null);
				}
                FillDependant_EntitTableFaci2Name(lazyLoad);
                //Check if foreignkey comes from history
                TableFaci2Name.FilledByHistory = Navigation.CheckFilledByHistory("faci2");
                return;
            }


            if (entit___faci2name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFaci2Name, "sTableFaci2Name", "dTableFaci2Name", qs, "faci2");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfaci2.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFaci2Name_tableFilters"]))
                    TableFaci2Name.TableFilters = bool.Parse(qs["TableFaci2Name_tableFilters"]);
                else
                    TableFaci2Name.TableFilters = false;

                query = qs["qTableFaci2Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfaci2.FldName, query + "%");
                }
                entit___faci2name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFaci2Name"] != null ? qs["pTableFaci2Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAfaci2.FldZzstate };

// USE /[MANUAL GQT OVERRQ ENTIT_FACI2NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("faci2", FormMode.New) || Navigation.checkFormMode("faci2", FormMode.Duplicate))
                    entit___faci2name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfaci2.FldZzstate, 0)
                        .Equal(CSGenioAfaci2.FldCodfacil, Navigation.GetStrValue("faci2")));
                else
                    entit___faci2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfaci2.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //entit___faci2name____Conds = Faci2.AddEPH<CSGenioAfaci2>(ref UserContext.Current.User, entit___faci2name____Conds, "LED_ENTIT___FACI2NAME____");

                FieldRef firstVisibleColumn = new FieldRef("faci2", "name");
                ListingMVC<CSGenioAfaci2> listing = Models.ModelBase.Where<CSGenioAfaci2>(false, entit___faci2name____Conds, fields, offset, numberItems, sorts, "LED_ENTIT___FACI2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFaci2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFaci2Name.Query = query;
                TableFaci2Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Faci2>((r) => new GenioMVC.Models.Faci2(r, true, _fieldsToSerialize_ENTIT___FACI2NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_faci2") != null)
				{
					this.ValLastfacilitie = Navigation.GetStrValue("RETURN_faci2");
					Navigation.CurrentLevel.SetEntry("RETURN_faci2", null);
				}

				TableFaci2Name.List = new SelectList(TableFaci2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodfacil,  x => x.ValCodfacil == this.ValLastfacilitie), "Value", "Text", this.ValLastfacilitie);
                FillDependant_EntitTableFaci2Name();

                //Check if foreignkey comes from history
                TableFaci2Name.FilledByHistory = Navigation.CheckFilledByHistory("faci2");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFaci2Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Faci2</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EntitTableFaci2Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "faci2.codfacil", "faci2.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName };
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
            CSGenioAfaci2 tempArea = new CSGenioAfaci2(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfaci2.FldCodfacil, PKey));
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
        /// Fill Dependant fields values -> TableFaci2Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EntitTableFaci2Name(bool lazyLoad = false)
        {
            var row = GetDependant_EntitTableFaci2Name(this.ValLastfacilitie, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValLastfacilitie = ViewModelConversion.ToString(row["faci2.codfacil"]);
                TableFaci2Name.Value = ViewModelConversion.ToString(row["faci2.name"]);
                if (GlobalFunctions.emptyG(this.ValLastfacilitie) == 1)
                {
                    this.ValLastfacilitie = "";
                    TableFaci2Name.Value = "";
                    Navigation.ClearValue("faci2");
                }
                else if (lazyLoad)
                {
                    TableFaci2Name.SetPagination(1, 0, false, false, 1);
                    TableFaci2Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValLastfacilitie),
                            Text = Convert.ToString(TableFaci2Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValLastfacilitie);
                }
                TableFaci2Name.Selected = this.ValLastfacilitie;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFaci2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ENTIT___FACI2NAME____ = { "Faci2", "Faci2.ValCodfacil", "Faci2.ValZzstate", "Faci2.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ENTIT]/
		#endregion
	}
}
