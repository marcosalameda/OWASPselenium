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

namespace GenioMVC.ViewModels.Tblk
{
	public class Tblk_ViewModel : FormViewModel<Models.Tblk>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Grpb>  TableGrpbName { get; set; }

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Trsb>  TableTrsbName { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValFkey1 { get; set; }

		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		public string ValFkey2 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodtblk { get; set; }

		public Tblk_ViewModel() : base("FTBLK") { }

		public Tblk_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTBLK", currentNavigation, nestedForm) { }

		public Tblk_ViewModel(Models.Tblk row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTBLK", row, currentNavigation, nestedForm) { }

		public Tblk_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tblk", id);
			Model = Models.Tblk.Find(id, "FTBLK", fieldsToQuery: fieldsToLoad);
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
			Models.Tblk model = new Models.Tblk() { Identifier = "FTBLK" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tblk model)
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

		public static StatusMessage DeleteConditions(Models.Tblk model)
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

		public static StatusMessage ViewConditions(Models.Tblk model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tblk model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValFkey1 = ViewModelConversion.ToString(m.ValFkey1);
 				ValFkey2 = ViewModelConversion.ToString(m.ValFkey2);
 				ValCodtblk = ViewModelConversion.ToString(m.ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblk) to Model (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValFkey1 = ViewModelConversion.ToString(ValFkey1);
				m.ValFkey2 = ViewModelConversion.ToString(ValFkey2);
				m.ValCodtblk = ViewModelConversion.ToString(ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblk) to Model (Tblk) - Error during mapping");
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
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), "FTBLK");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tblk() { Identifier = "FTBLK" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tblk");
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

			Model.Identifier = "FTBLK";
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

		protected override void LoadDocumentsProperties(Models.Tblk row)
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
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), "FTBLK");
				if (Model == null)
				{
					Model = new Models.Tblk() { Identifier = "FTBLK" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblk");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Tblk____grpb_name____(qs, lazyLoad);
			Load_Tblk____trsb_name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TBLK]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TBLK]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TBLK]/
		public override void Save()
		{

			try { Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), "FTBLK"); }
			finally { if (Model == null) Model = new Models.Tblk() { Identifier = "FTBLK" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TBLK]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), "FTBLK"); }
			finally { if (Model == null) Model = new Models.Tblk() { Identifier = "FTBLK" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TBLK]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TBLK]/
		public override void Destroy(string id)
		{
			Model = Models.Tblk.Find(id, "FTBLK");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableGrpbName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tblk____grpb_name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tblk____grpb_name____DoLoad = true;
            CriteriaSet tblk____grpb_name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("grpb", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tblk____grpb_name____Conds.Equal(CSGenioAgrpb.FldCodgrpb, Navigation.GetValue("grpb"));
                    this.ValFkey1 = Navigation.GetStrValue("grpb");
                }
            }



            TableGrpbName = new TableDBEdit<Models.Grpb>();
            TableGrpbName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
                    this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}
                FillDependant_TblkTableGrpbName(lazyLoad);
                //Check if foreignkey comes from history
                TableGrpbName.FilledByHistory = Navigation.CheckFilledByHistory("grpb");
                return;
            }


            if (tblk____grpb_name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableGrpbName, "sTableGrpbName", "dTableGrpbName", qs, "grpb");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgrpb.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableGrpbName_tableFilters"]))
                    TableGrpbName.TableFilters = bool.Parse(qs["TableGrpbName_tableFilters"]);
                else
                    TableGrpbName.TableFilters = false;

                query = qs["qTableGrpbName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAgrpb.FldName, query + "%");
                }
                tblk____grpb_name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableGrpbName"] != null ? qs["pTableGrpbName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName, CSGenioAgrpb.FldZzstate };

// USE /[MANUAL GQT OVERRQ TBLK_GRPBNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("grpb", FormMode.New) || Navigation.checkFormMode("grpb", FormMode.Duplicate))
                    tblk____grpb_name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAgrpb.FldZzstate, 0)
                        .Equal(CSGenioAgrpb.FldCodgrpb, Navigation.GetStrValue("grpb")));
                else
                    tblk____grpb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgrpb.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tblk____grpb_name____Conds = Grpb.AddEPH<CSGenioAgrpb>(ref UserContext.Current.User, tblk____grpb_name____Conds, "LED_TBLK____GRPB_NAME____");

                FieldRef firstVisibleColumn = new FieldRef("grpb", "name");
                ListingMVC<CSGenioAgrpb> listing = Models.ModelBase.Where<CSGenioAgrpb>(false, tblk____grpb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____GRPB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableGrpbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableGrpbName.Query = query;
                TableGrpbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Grpb>((r) => new GenioMVC.Models.Grpb(r, true, _fieldsToSerialize_TBLK____GRPB_NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
					this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}

				TableGrpbName.List = new SelectList(TableGrpbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodgrpb,  x => x.ValCodgrpb == this.ValFkey1), "Value", "Text", this.ValFkey1);
                FillDependant_TblkTableGrpbName();

                //Check if foreignkey comes from history
                TableGrpbName.FilledByHistory = Navigation.CheckFilledByHistory("grpb");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableGrpbName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Grpb</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TblkTableGrpbName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "grpb.codgrpb", "grpb.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName };
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
            CSGenioAgrpb tempArea = new CSGenioAgrpb(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAgrpb.FldCodgrpb, PKey));
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
        /// Fill Dependant fields values -> TableGrpbName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TblkTableGrpbName(bool lazyLoad = false)
        {
            var row = GetDependant_TblkTableGrpbName(this.ValFkey1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValFkey1 = ViewModelConversion.ToString(row["grpb.codgrpb"]);
                TableGrpbName.Value = ViewModelConversion.ToString(row["grpb.name"]);
                if (GlobalFunctions.emptyG(this.ValFkey1) == 1)
                {
                    this.ValFkey1 = "";
                    TableGrpbName.Value = "";
                    Navigation.ClearValue("grpb");
                }
                else if (lazyLoad)
                {
                    TableGrpbName.SetPagination(1, 0, false, false, 1);
                    TableGrpbName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValFkey1),
                            Text = Convert.ToString(TableGrpbName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValFkey1);
                }
                TableGrpbName.Selected = this.ValFkey1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGrpbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TBLK____GRPB_NAME____ = { "Grpb", "Grpb.ValCodgrpb", "Grpb.ValZzstate", "Grpb.ValName" };

        /// <summary>
        /// TableTrsbName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Tblk____trsb_name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool tblk____trsb_name____DoLoad = true;
            CriteriaSet tblk____trsb_name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("trsb", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    tblk____trsb_name____Conds.Equal(CSGenioAtrsb.FldCodtrsb, Navigation.GetValue("trsb"));
                    this.ValFkey2 = Navigation.GetStrValue("trsb");
                }
            }



            TableTrsbName = new TableDBEdit<Models.Trsb>();
            TableTrsbName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
                    this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}
                FillDependant_TblkTableTrsbName(lazyLoad);
                //Check if foreignkey comes from history
                TableTrsbName.FilledByHistory = Navigation.CheckFilledByHistory("trsb");
                return;
            }


            if (tblk____trsb_name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTrsbName, "sTableTrsbName", "dTableTrsbName", qs, "trsb");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtrsb.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTrsbName_tableFilters"]))
                    TableTrsbName.TableFilters = bool.Parse(qs["TableTrsbName_tableFilters"]);
                else
                    TableTrsbName.TableFilters = false;

                query = qs["qTableTrsbName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtrsb.FldName, query + "%");
                }
                tblk____trsb_name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableTrsbName"] != null ? qs["pTableTrsbName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName, CSGenioAtrsb.FldZzstate };

// USE /[MANUAL GQT OVERRQ TBLK_TRSBNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("trsb", FormMode.New) || Navigation.checkFormMode("trsb", FormMode.Duplicate))
                    tblk____trsb_name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtrsb.FldZzstate, 0)
                        .Equal(CSGenioAtrsb.FldCodtrsb, Navigation.GetStrValue("trsb")));
                else
                    tblk____trsb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtrsb.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //tblk____trsb_name____Conds = Trsb.AddEPH<CSGenioAtrsb>(ref UserContext.Current.User, tblk____trsb_name____Conds, "LED_TBLK____TRSB_NAME____");

                FieldRef firstVisibleColumn = new FieldRef("trsb", "name");
                ListingMVC<CSGenioAtrsb> listing = Models.ModelBase.Where<CSGenioAtrsb>(false, tblk____trsb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____TRSB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTrsbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTrsbName.Query = query;
                TableTrsbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Trsb>((r) => new GenioMVC.Models.Trsb(r, true, _fieldsToSerialize_TBLK____TRSB_NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
					this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}

				TableTrsbName.List = new SelectList(TableTrsbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodtrsb,  x => x.ValCodtrsb == this.ValFkey2), "Value", "Text", this.ValFkey2);
                FillDependant_TblkTableTrsbName();

                //Check if foreignkey comes from history
                TableTrsbName.FilledByHistory = Navigation.CheckFilledByHistory("trsb");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTrsbName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Trsb</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_TblkTableTrsbName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "trsb.codtrsb", "trsb.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName };
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
            CSGenioAtrsb tempArea = new CSGenioAtrsb(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtrsb.FldCodtrsb, PKey));
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
        /// Fill Dependant fields values -> TableTrsbName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_TblkTableTrsbName(bool lazyLoad = false)
        {
            var row = GetDependant_TblkTableTrsbName(this.ValFkey2, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValFkey2 = ViewModelConversion.ToString(row["trsb.codtrsb"]);
                TableTrsbName.Value = ViewModelConversion.ToString(row["trsb.name"]);
                if (GlobalFunctions.emptyG(this.ValFkey2) == 1)
                {
                    this.ValFkey2 = "";
                    TableTrsbName.Value = "";
                    Navigation.ClearValue("trsb");
                }
                else if (lazyLoad)
                {
                    TableTrsbName.SetPagination(1, 0, false, false, 1);
                    TableTrsbName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValFkey2),
                            Text = Convert.ToString(TableTrsbName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValFkey2);
                }
                TableTrsbName.Selected = this.ValFkey2;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTrsbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_TBLK____TRSB_NAME____ = { "Trsb", "Trsb.ValCodtrsb", "Trsb.ValZzstate", "Trsb.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBLK]/
		#endregion
	}
}
