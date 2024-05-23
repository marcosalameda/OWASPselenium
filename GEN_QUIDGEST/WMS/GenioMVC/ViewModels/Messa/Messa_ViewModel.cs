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

namespace GenioMVC.ViewModels.Messa
{
	public class Messa_ViewModel : FormViewModel<Models.Messa>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Notification ID" Tipo:"C"</summary>
		[Display(Name = "NOTIFICATION_ID25507", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdnotif { get; set; }

		/// <summary>Campo : "Message ID" Tipo:"C"</summary>
		[Display(Name = "MESSAGE_ID37133", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdmsg { get; set; }

		/// <summary>Campo : "E-mail sent" Tipo:"L"</summary>
		[Display(Name = "E_MAIL_SENT51699", ResourceType = typeof(Resources.Resources))]
		public bool ValMailsent { get; set; }

		/// <summary>Campo : "Error sending mail" Tipo:"C"</summary>
		[Display(Name = "ERROR_SENDING_MAIL44674", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(300, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValMailerr { get; set; }

		/// <summary>Campo : "Entity name" Tipo:"C"</summary>
		[Display(Name = "ENTITY_NAME37999", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Entit>  TableEntitName { get; set; }

		/// <summary>Campo : "Person name" Tipo:"C"</summary>
		[Display(Name = "PERSON_NAME40980", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Perso>  TablePersoName { get; set; }

		/// <summary>Campo : "Document number" Tipo:"N"</summary>
		[Display(Name = "DOCUMENT_NUMBER28451", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDocum_nr { get; set; }

		/// <summary>Campo : "To whom the message was sent" Tipo:"C"</summary>
		[Display(Name = "TO_WHOM_THE_MESSAGE_02337", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "E-mail to whom the message was sent" Tipo:"C"</summary>
		[Display(Name = "E_MAIL_TO_WHOM_THE_M37668", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "Message" Tipo:"MO"</summary>
		[Display(Name = "MESSAGE30602", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValMessage { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatope { get; set; }

		/// <summary>Campo : "Created on" Tipo:"OD"</summary>
		[Display(Name = "CREATED_ON00051", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ENTITY_NAME37999", ResourceType = typeof(Resources.Resources))]
		public string ValCodentit { get; set; }

		[Display(Name = "PERSON_NAME40980", ResourceType = typeof(Resources.Resources))]
		public string ValCodperso { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodmessa { get; set; }

		public Messa_ViewModel() : base("FMESSA") { }

		public Messa_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FMESSA", currentNavigation, nestedForm) { }

		public Messa_ViewModel(Models.Messa row, NavigationContext currentNavigation, bool nestedForm = false) : base("FMESSA", row, currentNavigation, nestedForm) { }

		public Messa_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("messa", id);
			Model = Models.Messa.Find(id, "FMESSA", fieldsToQuery: fieldsToLoad);
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
			Models.Messa model = new Models.Messa() { Identifier = "FMESSA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Messa model)
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

		public static StatusMessage DeleteConditions(Models.Messa model)
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

		public static StatusMessage ViewConditions(Models.Messa model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Messa model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Messa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Messa) to ViewModel (Messa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValIdnotif = ViewModelConversion.ToString(m.ValIdnotif);
 				ValIdmsg = ViewModelConversion.ToString(m.ValIdmsg);
 				ValMailsent = ViewModelConversion.ToLogic(m.ValMailsent);
 				ValMailerr = ViewModelConversion.ToString(m.ValMailerr);
 				ValDocum_nr = ViewModelConversion.ToNumeric(m.ValDocum_nr);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				ValMessage = ViewModelConversion.ToString(m.ValMessage);
 				ValCreatope = ViewModelConversion.ToString(m.ValCreatope);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
 				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
 				ValCodmessa = ViewModelConversion.ToString(m.ValCodmessa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Messa) to ViewModel (Messa) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Messa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Messa) to Model (Messa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValIdnotif = ViewModelConversion.ToString(ValIdnotif);
				m.ValIdmsg = ViewModelConversion.ToString(ValIdmsg);
				m.ValMailsent = ViewModelConversion.ToLogic(ValMailsent);
				m.ValMailerr = ViewModelConversion.ToString(ValMailerr);
				m.ValDocum_nr = ViewModelConversion.ToNumeric(ValDocum_nr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValMessage = ViewModelConversion.ToString(ValMessage);
				m.ValCreatope = ViewModelConversion.ToString(ValCreatope);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
				m.ValCodmessa = ViewModelConversion.ToString(ValCodmessa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Messa) to Model (Messa) - Error during mapping");
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
				Model = Models.Messa.Find(Navigation.GetStrValue("messa"), "FMESSA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Messa() { Identifier = "FMESSA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("messa");
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

			Model.Identifier = "FMESSA";
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

		protected override void LoadDocumentsProperties(Models.Messa row)
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
				Model = Models.Messa.Find(Navigation.GetStrValue("messa"), "FMESSA");
				if (Model == null)
				{
					Model = new Models.Messa() { Identifier = "FMESSA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("messa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Messa___entitname____(qs, lazyLoad);
			Load_Messa___personame____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL MESSA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW MESSA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE MESSA]/
		public override void Save()
		{

			try { Model = Models.Messa.Find(Navigation.GetStrValue("messa"), "FMESSA"); }
			finally { if (Model == null) Model = new Models.Messa() { Identifier = "FMESSA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY MESSA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Messa.Find(Navigation.GetStrValue("messa"), "FMESSA"); }
			finally { if (Model == null) Model = new Models.Messa() { Identifier = "FMESSA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE MESSA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY MESSA]/
		public override void Destroy(string id)
		{
			Model = Models.Messa.Find(id, "FMESSA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableEntitName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Messa___entitname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool messa___entitname____DoLoad = true;
            CriteriaSet messa___entitname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("entit", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    messa___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
                    this.ValCodentit = Navigation.GetStrValue("entit");
                }
            }



            TableEntitName = new TableDBEdit<Models.Entit>();
            TableEntitName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
                    this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
                FillDependant_MessaTableEntitName(lazyLoad);
                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
                return;
            }


            if (messa___entitname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
                    TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
                else
                    TableEntitName.TableFilters = false;

                query = qs["qTableEntitName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAentit.FldName, query + "%");
                }
                messa___entitname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ MESSA_ENTITNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
                    messa___entitname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAentit.FldZzstate, 0)
                        .Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
                else
                    messa___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //messa___entitname____Conds = Entit.AddEPH<CSGenioAentit>(ref UserContext.Current.User, messa___entitname____Conds, "LED_MESSA___ENTITNAME____");

                FieldRef firstVisibleColumn = new FieldRef("entit", "name");
                ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, messa___entitname____Conds, fields, offset, numberItems, sorts, "LED_MESSA___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEntitName.Query = query;
                TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(r, true, _fieldsToSerialize_MESSA___ENTITNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
                FillDependant_MessaTableEntitName();

                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Entit</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_MessaTableEntitName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "entit.codentit", "entit.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName };
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
            CSGenioAentit tempArea = new CSGenioAentit(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));
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
        /// Fill Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_MessaTableEntitName(bool lazyLoad = false)
        {
            var row = GetDependant_MessaTableEntitName(this.ValCodentit, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
                TableEntitName.Value = ViewModelConversion.ToString(row["entit.name"]);
                if (GlobalFunctions.emptyG(this.ValCodentit) == 1)
                {
                    this.ValCodentit = "";
                    TableEntitName.Value = "";
                    Navigation.ClearValue("entit");
                }
                else if (lazyLoad)
                {
                    TableEntitName.SetPagination(1, 0, false, false, 1);
                    TableEntitName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodentit),
                            Text = Convert.ToString(TableEntitName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodentit);
                }
                TableEntitName.Selected = this.ValCodentit;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_MESSA___ENTITNAME____ = { "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials" };

        /// <summary>
        /// TablePersoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Messa___personame____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool messa___personame____DoLoad = true;
            CriteriaSet messa___personame____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("perso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    messa___personame____Conds.Equal(CSGenioAperso.FldCodperso, Navigation.GetValue("perso"));
                    this.ValCodperso = Navigation.GetStrValue("perso");
                }
            }



            TablePersoName = new TableDBEdit<Models.Perso>();
            TablePersoName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
                    this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}
                FillDependant_MessaTablePersoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
                return;
            }


            if (messa___personame____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePersoName, "sTablePersoName", "dTablePersoName", qs, "perso");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePersoName_tableFilters"]))
                    TablePersoName.TableFilters = bool.Parse(qs["TablePersoName_tableFilters"]);
                else
                    TablePersoName.TableFilters = false;

                query = qs["qTablePersoName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAperso.FldName, query + "%");
                }
                messa___personame____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate };

// USE /[MANUAL GQT OVERRQ MESSA_PERSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
                    messa___personame____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAperso.FldZzstate, 0)
                        .Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
                else
                    messa___personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //messa___personame____Conds = Perso.AddEPH<CSGenioAperso>(ref UserContext.Current.User, messa___personame____Conds, "LED_MESSA___PERSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("perso", "name");
                ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(false, messa___personame____Conds, fields, offset, numberItems, sorts, "LED_MESSA___PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePersoName.Query = query;
                TablePersoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Perso>((r) => new GenioMVC.Models.Perso(r, true, _fieldsToSerialize_MESSA___PERSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodperso), "Value", "Text", this.ValCodperso);
                FillDependant_MessaTablePersoName();

                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePersoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Perso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_MessaTablePersoName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "perso.codperso", "perso.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName };
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
            CSGenioAperso tempArea = new CSGenioAperso(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAperso.FldCodperso, PKey));
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
        /// Fill Dependant fields values -> TablePersoName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_MessaTablePersoName(bool lazyLoad = false)
        {
            var row = GetDependant_MessaTablePersoName(this.ValCodperso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodperso = ViewModelConversion.ToString(row["perso.codperso"]);
                TablePersoName.Value = ViewModelConversion.ToString(row["perso.name"]);
                if (GlobalFunctions.emptyG(this.ValCodperso) == 1)
                {
                    this.ValCodperso = "";
                    TablePersoName.Value = "";
                    Navigation.ClearValue("perso");
                }
                else if (lazyLoad)
                {
                    TablePersoName.SetPagination(1, 0, false, false, 1);
                    TablePersoName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodperso),
                            Text = Convert.ToString(TablePersoName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodperso);
                }
                TablePersoName.Selected = this.ValCodperso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_MESSA___PERSONAME____ = { "Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM MESSA]/
		#endregion
	}
}
