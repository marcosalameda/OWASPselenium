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

namespace GenioMVC.ViewModels.Lnhag
{
	public class Lnhag_ViewModel : FormViewModel<Models.Lnhag>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "No." Tipo:"N"</summary>
		[Display(Name = "NO_14817", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pedid>  TablePedidNrpedido { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpeq1>  TableTpeq1Tipoequi { get; set; }

		/// <summary>Campo : "Quantity" Tipo:"N"</summary>
		[Display(Name = "QUANTITY06415", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdtpequ { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "NO_14817", ResourceType = typeof(Resources.Resources))]
		public string ValCodpedid { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlnhag { get; set; }

		public Lnhag_ViewModel() : base("FLNHAG") { }

		public Lnhag_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHAG", currentNavigation, nestedForm) { }

		public Lnhag_ViewModel(Models.Lnhag row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHAG", row, currentNavigation, nestedForm) { }

		public Lnhag_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("lnhag", id);
			Model = Models.Lnhag.Find(id, "FLNHAG", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhag model = new Models.Lnhag() { Identifier = "FLNHAG" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Lnhag model)
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

		public static StatusMessage DeleteConditions(Models.Lnhag model)
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

		public static StatusMessage ViewConditions(Models.Lnhag model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Lnhag model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lnhag m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhag) to ViewModel (Lnhag) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValQtdtpequ = ViewModelConversion.ToNumeric(m.ValQtdtpequ);
 				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodlnhag = ViewModelConversion.ToString(m.ValCodlnhag);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhag) to ViewModel (Lnhag) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lnhag m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhag) to Model (Lnhag) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValQtdtpequ = ViewModelConversion.ToNumeric(ValQtdtpequ);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodlnhag = ViewModelConversion.ToString(ValCodlnhag);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhag) to Model (Lnhag) - Error during mapping");
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
				Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), "FLNHAG");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Lnhag() { Identifier = "FLNHAG" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");
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

			Model.Identifier = "FLNHAG";
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

		protected override void LoadDocumentsProperties(Models.Lnhag row)
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
				Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), "FLNHAG");
				if (Model == null)
				{
					Model = new Models.Lnhag() { Identifier = "FLNHAG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Lnhag___pedidnrpedido(qs, lazyLoad);
			Load_Lnhag___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHAG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHAG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LNHAG]/
		public override void Save()
		{

			try { Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), "FLNHAG"); }
			finally { if (Model == null) Model = new Models.Lnhag() { Identifier = "FLNHAG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHAG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lnhag.Find(Navigation.GetStrValue("lnhag"), "FLNHAG"); }
			finally { if (Model == null) Model = new Models.Lnhag() { Identifier = "FLNHAG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHAG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHAG]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhag.Find(id, "FLNHAG");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TablePedidNrpedido -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lnhag___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhag___pedidnrpedidoDoLoad = true;
            CriteriaSet lnhag___pedidnrpedidoConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pedid", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhag___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, Navigation.GetValue("pedid"));
                    this.ValCodpedid = Navigation.GetStrValue("pedid");
                }
            }



            TablePedidNrpedido = new TableDBEdit<Models.Pedid>();
            TablePedidNrpedido.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
                    this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}
                FillDependant_LnhagTablePedidNrpedido(lazyLoad);
                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
                return;
            }


            if (lnhag___pedidnrpedidoDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePedidNrpedido, "sTablePedidNrpedido", "dTablePedidNrpedido", qs, "pedid");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePedidNrpedido_tableFilters"]))
                    TablePedidNrpedido.TableFilters = bool.Parse(qs["TablePedidNrpedido_tableFilters"]);
                else
                    TablePedidNrpedido.TableFilters = false;

                query = qs["qTablePedidNrpedido"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApedid.FldNrpedido, query + "%");
                }
                lnhag___pedidnrpedidoConds.SubSet(search_filters);


                string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHAG_PEDIDNRPEDIDO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
                    lnhag___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApedid.FldZzstate, 0)
                        .Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
                else
                    lnhag___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhag___pedidnrpedidoConds = Pedid.AddEPH<CSGenioApedid>(ref UserContext.Current.User, lnhag___pedidnrpedidoConds, "LED_LNHAG___PEDIDNRPEDIDO");

                FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
                ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(false, lnhag___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHAG___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePedidNrpedido.Query = query;
                TablePedidNrpedido.Elements = listing.RowsForViewModel<GenioMVC.Models.Pedid>((r) => new GenioMVC.Models.Pedid(r, true, _fieldsToSerialize_LNHAG___PEDIDNRPEDIDO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
                FillDependant_LnhagTablePedidNrpedido();

                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePedidNrpedido (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pedid</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhagTablePedidNrpedido(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pedid.codpedid", "pedid.nrpedido" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido };
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
            CSGenioApedid tempArea = new CSGenioApedid(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApedid.FldCodpedid, PKey));
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
        /// Fill Dependant fields values -> TablePedidNrpedido (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LnhagTablePedidNrpedido(bool lazyLoad = false)
        {
            var row = GetDependant_LnhagTablePedidNrpedido(this.ValCodpedid, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpedid = ViewModelConversion.ToString(row["pedid.codpedid"]);
                TablePedidNrpedido.Value = ViewModelConversion.ToNumeric(row["pedid.nrpedido"]);
                if (GlobalFunctions.emptyG(this.ValCodpedid) == 1)
                {
                    this.ValCodpedid = "";
                    TablePedidNrpedido.Value = 0m;
                    Navigation.ClearValue("pedid");
                }
                else if (lazyLoad)
                {
                    TablePedidNrpedido.SetPagination(1, 0, false, false, 1);
                    TablePedidNrpedido.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpedid),
                            Text = Convert.ToString(TablePedidNrpedido.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpedid);
                }
                TablePedidNrpedido.Selected = this.ValCodpedid;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePedidNrpedido): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LNHAG___PEDIDNRPEDIDO = { "Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido" };

        /// <summary>
        /// TableTpeq1Tipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lnhag___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhag___tpeq1tipoequiDoLoad = true;
            CriteriaSet lnhag___tpeq1tipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpeq1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhag___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
                    this.ValCodtpequ = Navigation.GetStrValue("tpeq1");
                }
            }



            TableTpeq1Tipoequi = new TableDBEdit<Models.Tpeq1>();
            TableTpeq1Tipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
                    this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}
                FillDependant_LnhagTableTpeq1Tipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
                return;
            }


            if (lnhag___tpeq1tipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpeq1Tipoequi, "sTableTpeq1Tipoequi", "dTableTpeq1Tipoequi", qs, "tpeq1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpeq1Tipoequi_tableFilters"]))
                    TableTpeq1Tipoequi.TableFilters = bool.Parse(qs["TableTpeq1Tipoequi_tableFilters"]);
                else
                    TableTpeq1Tipoequi.TableFilters = false;

                query = qs["qTableTpeq1Tipoequi"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtpeq1.FldTipoequi, query + "%");
                }
                lnhag___tpeq1tipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHAG_TPEQ1TIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
                    lnhag___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpeq1.FldZzstate, 0)
                        .Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
                else
                    lnhag___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhag___tpeq1tipoequiConds = Tpeq1.AddEPH<CSGenioAtpeq1>(ref UserContext.Current.User, lnhag___tpeq1tipoequiConds, "LED_LNHAG___TPEQ1TIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tipoequi");
                ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, lnhag___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_LNHAG___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpeq1Tipoequi.Query = query;
                TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(r, true, _fieldsToSerialize_LNHAG___TPEQ1TIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_LnhagTableTpeq1Tipoequi();

                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpeq1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhagTableTpeq1Tipoequi(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpeq1.codtpequ", "tpeq1.tipoequi" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi };
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
            CSGenioAtpeq1 tempArea = new CSGenioAtpeq1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpeq1.FldCodtpequ, PKey));
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
        /// Fill Dependant fields values -> TableTpeq1Tipoequi (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LnhagTableTpeq1Tipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_LnhagTableTpeq1Tipoequi(this.ValCodtpequ, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpeq1.codtpequ"]);
                TableTpeq1Tipoequi.Value = ViewModelConversion.ToString(row["tpeq1.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
                {
                    this.ValCodtpequ = "";
                    TableTpeq1Tipoequi.Value = "";
                    Navigation.ClearValue("tpeq1");
                }
                else if (lazyLoad)
                {
                    TableTpeq1Tipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpeq1Tipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpequ),
                            Text = Convert.ToString(TableTpeq1Tipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpequ);
                }
                TableTpeq1Tipoequi.Selected = this.ValCodtpequ;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpeq1Tipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LNHAG___TPEQ1TIPOEQUI = { "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHAG]/
		#endregion
	}
}
