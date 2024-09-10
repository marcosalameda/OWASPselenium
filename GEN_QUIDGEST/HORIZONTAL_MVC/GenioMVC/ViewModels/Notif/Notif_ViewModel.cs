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

namespace GenioMVC.ViewModels.Notif
{
	public class Notif_ViewModel : FormViewModel<Models.Notif>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Lending No" Tipo:"N"</summary>
		[Display(Name = "LENDING_NO14727", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNrcomoda { get; set; }

		/// <summary>Campo : "Start" Tipo:"DT"</summary>
		[Display(Name = "START00919", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValBegin { get; set; }

		/// <summary>Campo : "End" Tipo:"DT"</summary>
		[Display(Name = "END47577", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get; set; }

		/// <summary>Campo : "Receiver's Email" Tipo:"C"</summary>
		[Display(Name = "RECEIVER_S_EMAIL60306", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(100, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "ID of the notification that generated the message" Tipo:"C"</summary>
		[Display(Name = "ID_OF_THE_NOTIFICATI28920", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdnotif { get; set; }

		/// <summary>Campo : "Mensage ID" Tipo:"C"</summary>
		[Display(Name = "MENSAGE_ID32109", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdmsg { get; set; }

		/// <summary>Campo : "Text of sent message" Tipo:"MO"</summary>
		[Display(Name = "TEXT_OF_SENT_MESSAGE03008", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValMessage { get; set; }

		/// <summary>Campo : "Erro on sending the email" Tipo:"C"</summary>
		[Display(Name = "ERRO_ON_SENDING_THE_05516", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(300, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValMailerr { get; set; }

		/// <summary>Campo : "Receiver" Tipo:"C"</summary>
		[Display(Name = "RECEIVER16744", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Created on" Tipo:"OD"</summary>
		[Display(Name = "CREATED_ON00051", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatope { get; set; }

		/// <summary>Campo : "Returned" Tipo:"L"</summary>
		[Display(Name = "RETURNED01606", ResourceType = typeof(Resources.Resources))]
		public bool ValReturned { get; set; }

		/// <summary>Campo : "Returned" Tipo:"D"</summary>
		[Display(Name = "RETURNED01606", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtdevolu { get; set; }

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess2>  TablePess2Name { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValCodpesso { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodnotif { get; set; }

		public Notif_ViewModel() : base("FNOTIF") { }

		public Notif_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FNOTIF", currentNavigation, nestedForm) { }

		public Notif_ViewModel(Models.Notif row, NavigationContext currentNavigation, bool nestedForm = false) : base("FNOTIF", row, currentNavigation, nestedForm) { }

		public Notif_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("notif", id);
			Model = Models.Notif.Find(id, "FNOTIF", fieldsToQuery: fieldsToLoad);
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
			Models.Notif model = new Models.Notif() { Identifier = "FNOTIF" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Notif model)
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

		public static StatusMessage DeleteConditions(Models.Notif model)
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

		public static StatusMessage ViewConditions(Models.Notif model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Notif model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Notif m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Notif) to ViewModel (Notif) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValNrcomoda = ViewModelConversion.ToNumeric(m.ValNrcomoda);
 				ValBegin = ViewModelConversion.ToDateTime(m.ValBegin);
 				ValEnd = ViewModelConversion.ToDateTime(m.ValEnd);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				ValIdnotif = ViewModelConversion.ToString(m.ValIdnotif);
 				ValIdmsg = ViewModelConversion.ToString(m.ValIdmsg);
 				ValMessage = ViewModelConversion.ToString(m.ValMessage);
 				ValMailerr = ViewModelConversion.ToString(m.ValMailerr);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValCreatope = ViewModelConversion.ToString(m.ValCreatope);
 				ValReturned = ViewModelConversion.ToLogic(m.ValReturned);
 				ValDtdevolu = ViewModelConversion.ToDateTime(m.ValDtdevolu);
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
 				ValCodnotif = ViewModelConversion.ToString(m.ValCodnotif);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Notif) to ViewModel (Notif) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Notif m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Notif) to Model (Notif) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValNrcomoda = ViewModelConversion.ToNumeric(ValNrcomoda);
				m.ValBegin = ViewModelConversion.ToDateTime(ValBegin);
				m.ValEnd = ViewModelConversion.ToDateTime(ValEnd);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValIdnotif = ViewModelConversion.ToString(ValIdnotif);
				m.ValIdmsg = ViewModelConversion.ToString(ValIdmsg);
				m.ValMessage = ViewModelConversion.ToString(ValMessage);
				m.ValMailerr = ViewModelConversion.ToString(ValMailerr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreatope = ViewModelConversion.ToString(ValCreatope);
				m.ValReturned = ViewModelConversion.ToLogic(ValReturned);
				m.ValDtdevolu = ViewModelConversion.ToDateTime(ValDtdevolu);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodnotif = ViewModelConversion.ToString(ValCodnotif);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Notif) to Model (Notif) - Error during mapping");
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
				Model = Models.Notif.Find(Navigation.GetStrValue("notif"), "FNOTIF");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Notif() { Identifier = "FNOTIF" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("notif");
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

			Model.Identifier = "FNOTIF";
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

		protected override void LoadDocumentsProperties(Models.Notif row)
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
				Model = Models.Notif.Find(Navigation.GetStrValue("notif"), "FNOTIF");
				if (Model == null)
				{
					Model = new Models.Notif() { Identifier = "FNOTIF" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("notif");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Notif___pess2name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL NOTIF]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW NOTIF]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE NOTIF]/
		public override void Save()
		{

			try { Model = Models.Notif.Find(Navigation.GetStrValue("notif"), "FNOTIF"); }
			finally { if (Model == null) Model = new Models.Notif() { Identifier = "FNOTIF" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY NOTIF]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Notif.Find(Navigation.GetStrValue("notif"), "FNOTIF"); }
			finally { if (Model == null) Model = new Models.Notif() { Identifier = "FNOTIF" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE NOTIF]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY NOTIF]/
		public override void Destroy(string id)
		{
			Model = Models.Notif.Find(id, "FNOTIF");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TablePess2Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Notif___pess2name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool notif___pess2name____DoLoad = true;
            CriteriaSet notif___pess2name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess2", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    notif___pess2name____Conds.Equal(CSGenioApess2.FldCodpesso, Navigation.GetValue("pess2"));
                    this.ValCodpesso = Navigation.GetStrValue("pess2");
                }
            }



            TablePess2Name = new TableDBEdit<Models.Pess2>();
            TablePess2Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
                    this.ValCodpesso = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}
                FillDependant_NotifTablePess2Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess2Name.FilledByHistory = Navigation.CheckFilledByHistory("pess2");
                return;
            }


            if (notif___pess2name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess2Name, "sTablePess2Name", "dTablePess2Name", qs, "pess2");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess2.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess2Name_tableFilters"]))
                    TablePess2Name.TableFilters = bool.Parse(qs["TablePess2Name_tableFilters"]);
                else
                    TablePess2Name.TableFilters = false;

                query = qs["qTablePess2Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApess2.FldName, query + "%");
                }
                notif___pess2name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePess2Name"] != null ? qs["pTablePess2Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioApess2.FldZzstate };

// USE /[MANUAL GQT OVERRQ NOTIF_PESS2NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess2", FormMode.New) || Navigation.checkFormMode("pess2", FormMode.Duplicate))
                    notif___pess2name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess2.FldZzstate, 0)
                        .Equal(CSGenioApess2.FldCodpesso, Navigation.GetStrValue("pess2")));
                else
                    notif___pess2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess2.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //notif___pess2name____Conds = Pess2.AddEPH<CSGenioApess2>(ref UserContext.Current.User, notif___pess2name____Conds, "LED_NOTIF___PESS2NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess2", "name");
                ListingMVC<CSGenioApess2> listing = Models.ModelBase.Where<CSGenioApess2>(false, notif___pess2name____Conds, fields, offset, numberItems, sorts, "LED_NOTIF___PESS2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess2Name.Query = query;
                TablePess2Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess2>((r) => new GenioMVC.Models.Pess2(r, true, _fieldsToSerialize_NOTIF___PESS2NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}

				TablePess2Name.List = new SelectList(TablePess2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
                FillDependant_NotifTablePess2Name();

                //Check if foreignkey comes from history
                TablePess2Name.FilledByHistory = Navigation.CheckFilledByHistory("pess2");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess2Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess2</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_NotifTablePess2Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess2.codpesso", "pess2.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };
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
            CSGenioApess2 tempArea = new CSGenioApess2(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess2.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePess2Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_NotifTablePess2Name(bool lazyLoad = false)
        {
            var row = GetDependant_NotifTablePess2Name(this.ValCodpesso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpesso = ViewModelConversion.ToString(row["pess2.codpesso"]);
                TablePess2Name.Value = ViewModelConversion.ToString(row["pess2.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
                {
                    this.ValCodpesso = "";
                    TablePess2Name.Value = "";
                    Navigation.ClearValue("pess2");
                }
                else if (lazyLoad)
                {
                    TablePess2Name.SetPagination(1, 0, false, false, 1);
                    TablePess2Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpesso),
                            Text = Convert.ToString(TablePess2Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpesso);
                }
                TablePess2Name.Selected = this.ValCodpesso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_NOTIF___PESS2NAME____ = { "Pess2", "Pess2.ValCodpesso", "Pess2.ValZzstate", "Pess2.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM NOTIF]/
		#endregion
	}
}
