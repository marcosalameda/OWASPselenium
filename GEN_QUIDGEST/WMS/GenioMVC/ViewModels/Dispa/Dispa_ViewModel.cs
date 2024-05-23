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

namespace GenioMVC.ViewModels.Dispa
{
	public class Dispa_ViewModel : FormViewModel<Models.Dispa>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Dispatch date" Tipo:"DT"</summary>
		[Display(Name = "DISPATCH_DATE54413", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDispadt { get; set; }

		/// <summary>Campo : "Dispatch number" Tipo:"N"</summary>
		[Display(Name = "DISPATCH_NUMBER23616", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDispanr { get; set; }

		/// <summary>Campo : "Status" Tipo:"AC"</summary>
		[Display(Name = "STATUS62033", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Dispstat", GenioMVC.Helpers.ArrayType.Character)]
		public string ValStatus { get; set; }
		[JsonIgnore]
		public SelectList List_ValStatus { get; set; }

		/// <summary>Campo : "Customer" Tipo:"C"</summary>
		[Display(Name = "CUSTOMER51658", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Entit>  TableEntitName { get; set; }

		/// <summary>Campo : "Is prepared" Tipo:"L"</summary>
		[Display(Name = "IS_PREPARED16113", ResourceType = typeof(Resources.Resources))]
		public bool ValIsprepar { get; set; }

		/// <summary>Campo : "Prepared" Tipo:"DT"</summary>
		[Display(Name = "PREPARED38522", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValPrepared { get; set; }

		/// <summary>Campo : "Prepared by" Tipo:"C"</summary>
		[Display(Name = "PREPARED_BY36821", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Perso>  TablePersoName { get; set; }

		/// <summary>Campo : "Items" Tipo:"DP"</summary>
		[Display(Name = "ITEMS55321", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Dilin> ValDispatch { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "CUSTOMER51658", ResourceType = typeof(Resources.Resources))]
		public string ValCodentit { get; set; }

		[Display(Name = "PREPARED_BY36821", ResourceType = typeof(Resources.Resources))]
		public string ValCodperso { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCoddispa { get; set; }

		public Dispa_ViewModel() : base("FDISPA") { }

		public Dispa_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDISPA", currentNavigation, nestedForm) { }

		public Dispa_ViewModel(Models.Dispa row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDISPA", row, currentNavigation, nestedForm) { }

		public Dispa_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("dispa", id);
			Model = Models.Dispa.Find(id, "FDISPA", fieldsToQuery: fieldsToLoad);
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
			Models.Dispa model = new Models.Dispa() { Identifier = "FDISPA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Dispa model)
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

		public static StatusMessage DeleteConditions(Models.Dispa model)
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

		public static StatusMessage ViewConditions(Models.Dispa model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Dispa model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Dispa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Dispa) to ViewModel (Dispa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDispadt = ViewModelConversion.ToDateTime(m.ValDispadt);
 				ValDispanr = ViewModelConversion.ToNumeric(m.ValDispanr);
 				ValStatus = ViewModelConversion.ToString(m.ValStatus);
 				ValIsprepar = ViewModelConversion.ToLogic(m.ValIsprepar);
 				ValPrepared = ViewModelConversion.ToDateTime(m.ValPrepared);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
 				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
 				ValCoddispa = ViewModelConversion.ToString(m.ValCoddispa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Dispa) to ViewModel (Dispa) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Dispa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dispa) to Model (Dispa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDispadt = ViewModelConversion.ToDateTime(ValDispadt);
				m.ValDispanr = ViewModelConversion.ToNumeric(ValDispanr);
				m.ValStatus = ViewModelConversion.ToString(ValStatus);
				m.ValIsprepar = ViewModelConversion.ToLogic(ValIsprepar);
				m.ValPrepared = ViewModelConversion.ToDateTime(ValPrepared);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
				m.ValCoddispa = ViewModelConversion.ToString(ValCoddispa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dispa) to Model (Dispa) - Error during mapping");
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
				Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), "FDISPA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Dispa() { Identifier = "FDISPA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("dispa");
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

			Model.Identifier = "FDISPA";
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

		protected override void LoadDocumentsProperties(Models.Dispa row)
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
				Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), "FDISPA");
				if (Model == null)
				{
					Model = new Models.Dispa() { Identifier = "FDISPA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dispa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Dispa___entitname____(qs, lazyLoad);
			Load_Dispa___personame____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DISPA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DISPA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DISPA]/
		public override void Save()
		{

			try { Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), "FDISPA"); }
			finally { if (Model == null) Model = new Models.Dispa() { Identifier = "FDISPA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DISPA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), "FDISPA"); }
			finally { if (Model == null) Model = new Models.Dispa() { Identifier = "FDISPA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DISPA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DISPA]/
		public override void Destroy(string id)
		{
			Model = Models.Dispa.Find(id, "FDISPA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValStatus = new SelectList(
				ArrayDispstat.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValStatus);
		}


        /// <summary>
        /// TableEntitName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Dispa___entitname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool dispa___entitname____DoLoad = true;
            CriteriaSet dispa___entitname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("entit", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    dispa___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
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
                FillDependant_DispaTableEntitName(lazyLoad);
                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
                return;
            }


            if (dispa___entitname____DoLoad)
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
                dispa___entitname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ DISPA_ENTITNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
                    dispa___entitname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAentit.FldZzstate, 0)
                        .Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
                else
                    dispa___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //dispa___entitname____Conds = Entit.AddEPH<CSGenioAentit>(ref UserContext.Current.User, dispa___entitname____Conds, "LED_DISPA___ENTITNAME____");

                FieldRef firstVisibleColumn = new FieldRef("entit", "name");
                ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, dispa___entitname____Conds, fields, offset, numberItems, sorts, "LED_DISPA___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEntitName.Query = query;
                TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(r, true, _fieldsToSerialize_DISPA___ENTITNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
                FillDependant_DispaTableEntitName();

                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Entit</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DispaTableEntitName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_DispaTableEntitName(bool lazyLoad = false)
        {
            var row = GetDependant_DispaTableEntitName(this.ValCodentit, Navigation);
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


        private readonly string[] _fieldsToSerialize_DISPA___ENTITNAME____ = { "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials" };

        /// <summary>
        /// TablePersoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Dispa___personame____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool dispa___personame____DoLoad = true;
            CriteriaSet dispa___personame____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("perso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    dispa___personame____Conds.Equal(CSGenioAperso.FldCodperso, Navigation.GetValue("perso"));
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
                FillDependant_DispaTablePersoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
                return;
            }


            if (dispa___personame____DoLoad)
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
                dispa___personame____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate };

// USE /[MANUAL GQT OVERRQ DISPA_PERSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
                    dispa___personame____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAperso.FldZzstate, 0)
                        .Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
                else
                    dispa___personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //dispa___personame____Conds = Perso.AddEPH<CSGenioAperso>(ref UserContext.Current.User, dispa___personame____Conds, "LED_DISPA___PERSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("perso", "name");
                ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(false, dispa___personame____Conds, fields, offset, numberItems, sorts, "LED_DISPA___PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePersoName.Query = query;
                TablePersoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Perso>((r) => new GenioMVC.Models.Perso(r, true, _fieldsToSerialize_DISPA___PERSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodperso), "Value", "Text", this.ValCodperso);
                FillDependant_DispaTablePersoName();

                //Check if foreignkey comes from history
                TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePersoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Perso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_DispaTablePersoName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_DispaTablePersoName(bool lazyLoad = false)
        {
            var row = GetDependant_DispaTablePersoName(this.ValCodperso, Navigation);
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


        private readonly string[] _fieldsToSerialize_DISPA___PERSONAME____ = { "Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DISPA]/
		#endregion
	}
}
