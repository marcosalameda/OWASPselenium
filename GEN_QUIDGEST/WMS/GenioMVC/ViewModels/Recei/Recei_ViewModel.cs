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

namespace GenioMVC.ViewModels.Recei
{
	public class Recei_ViewModel : FormViewModel<Models.Recei>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Receipt date" Tipo:"DT"</summary>
		[Display(Name = "RECEIPT_DATE00996", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtreceip { get; set; }

		/// <summary>Campo : "Receipt number" Tipo:"N"</summary>
		[Display(Name = "RECEIPT_NUMBER31380", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNumber { get; set; }

		/// <summary>Campo : "Suplier" Tipo:"C"</summary>
		[Display(Name = "SUPLIER38140", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Entit>  TableEntitName { get; set; }

		/// <summary>Campo : "Receipt lines" Tipo:"DP"</summary>
		[Display(Name = "RECEIPT_LINES14292", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Relin> ValReceiptl { get; set; }

		/// <summary>Campo : "Receipt verification" Tipo:"DT"</summary>
		[Display(Name = "RECEIPT_VERIFICATION62328", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtcheck { get; set; }

		/// <summary>Campo : "To check" Tipo:"L"</summary>
		[Display(Name = "TO_CHECK57511", ResourceType = typeof(Resources.Resources))]
		public bool ValTocheck { get; set; }

		/// <summary>Campo : "Checked" Tipo:"L"</summary>
		[Display(Name = "CHECKED31708", ResourceType = typeof(Resources.Resources))]
		public bool ValChecked { get; set; }

		/// <summary>Campo : "Stored" Tipo:"L"</summary>
		[Display(Name = "STORED41854", ResourceType = typeof(Resources.Resources))]
		public bool ValStored { get; set; }

		/// <summary>Campo : "Storage date" Tipo:"DT"</summary>
		[Display(Name = "STORAGE_DATE59954", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtstorag { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "SUPLIER38140", ResourceType = typeof(Resources.Resources))]
		public string ValCodentit { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodrecei { get; set; }

		public Recei_ViewModel() : base("FRECEI") { }

		public Recei_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FRECEI", currentNavigation, nestedForm) { }

		public Recei_ViewModel(Models.Recei row, NavigationContext currentNavigation, bool nestedForm = false) : base("FRECEI", row, currentNavigation, nestedForm) { }

		public Recei_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("recei", id);
			Model = Models.Recei.Find(id, "FRECEI", fieldsToQuery: fieldsToLoad);
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
			Models.Recei model = new Models.Recei() { Identifier = "FRECEI" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Recei model)
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

		public static StatusMessage DeleteConditions(Models.Recei model)
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

		public static StatusMessage ViewConditions(Models.Recei model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Recei model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Recei m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Recei) to ViewModel (Recei) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDtreceip = ViewModelConversion.ToDateTime(m.ValDtreceip);
 				ValNumber = ViewModelConversion.ToNumeric(m.ValNumber);
 				ValDtcheck = ViewModelConversion.ToDateTime(m.ValDtcheck);
 				ValTocheck = ViewModelConversion.ToLogic(m.ValTocheck);
 				ValChecked = ViewModelConversion.ToLogic(m.ValChecked);
 				ValStored = ViewModelConversion.ToLogic(m.ValStored);
 				ValDtstorag = ViewModelConversion.ToDateTime(m.ValDtstorag);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
 				ValCodrecei = ViewModelConversion.ToString(m.ValCodrecei);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Recei) to ViewModel (Recei) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Recei m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Recei) to Model (Recei) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDtreceip = ViewModelConversion.ToDateTime(ValDtreceip);
				m.ValNumber = ViewModelConversion.ToNumeric(ValNumber);
				m.ValDtcheck = ViewModelConversion.ToDateTime(ValDtcheck);
				m.ValTocheck = ViewModelConversion.ToLogic(ValTocheck);
				m.ValChecked = ViewModelConversion.ToLogic(ValChecked);
				m.ValStored = ViewModelConversion.ToLogic(ValStored);
				m.ValDtstorag = ViewModelConversion.ToDateTime(ValDtstorag);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodrecei = ViewModelConversion.ToString(ValCodrecei);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Recei) to Model (Recei) - Error during mapping");
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
				Model = Models.Recei.Find(Navigation.GetStrValue("recei"), "FRECEI");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Recei() { Identifier = "FRECEI" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("recei");
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

			Model.Identifier = "FRECEI";
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

		protected override void LoadDocumentsProperties(Models.Recei row)
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
				Model = Models.Recei.Find(Navigation.GetStrValue("recei"), "FRECEI");
				if (Model == null)
				{
					Model = new Models.Recei() { Identifier = "FRECEI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("recei");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Recei___entitname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL RECEI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW RECEI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE RECEI]/
		public override void Save()
		{

			try { Model = Models.Recei.Find(Navigation.GetStrValue("recei"), "FRECEI"); }
			finally { if (Model == null) Model = new Models.Recei() { Identifier = "FRECEI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY RECEI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Recei.Find(Navigation.GetStrValue("recei"), "FRECEI"); }
			finally { if (Model == null) Model = new Models.Recei() { Identifier = "FRECEI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE RECEI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY RECEI]/
		public override void Destroy(string id)
		{
			Model = Models.Recei.Find(id, "FRECEI");
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
        public void Load_Recei___entitname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool recei___entitname____DoLoad = true;
            CriteriaSet recei___entitname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("entit", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    recei___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
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
                FillDependant_ReceiTableEntitName(lazyLoad);
                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
                return;
            }


            if (recei___entitname____DoLoad)
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
                recei___entitname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldContact, CSGenioAentit.FldLanguage, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ RECEI_ENTITNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
                    recei___entitname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAentit.FldZzstate, 0)
                        .Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
                else
                    recei___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //recei___entitname____Conds = Entit.AddEPH<CSGenioAentit>(ref UserContext.Current.User, recei___entitname____Conds, "LED_RECEI___ENTITNAME____");

                FieldRef firstVisibleColumn = new FieldRef("entit", "name");
                ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, recei___entitname____Conds, fields, offset, numberItems, sorts, "LED_RECEI___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEntitName.Query = query;
                TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(r, true, _fieldsToSerialize_RECEI___ENTITNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
                FillDependant_ReceiTableEntitName();

                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Entit</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ReceiTableEntitName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_ReceiTableEntitName(bool lazyLoad = false)
        {
            var row = GetDependant_ReceiTableEntitName(this.ValCodentit, Navigation);
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


        private readonly string[] _fieldsToSerialize_RECEI___ENTITNAME____ = { "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials", "Entit.ValTaxnumbe", "Entit.ValEmail", "Entit.ValPhonenum", "Entit.ValContact", "Entit.ValLanguage" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM RECEI]/
		#endregion
	}
}
