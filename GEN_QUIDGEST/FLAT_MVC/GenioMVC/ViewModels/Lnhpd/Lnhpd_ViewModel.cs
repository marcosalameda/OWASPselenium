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

namespace GenioMVC.ViewModels.Lnhpd
{
	public class Lnhpd_ViewModel : FormViewModel<Models.Lnhpd>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Order no:" Tipo:"N"</summary>
		[Display(Name = "ORDER_NO_15510", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pedid>  TablePedidNrpedido { get; set; }

		/// <summary>Campo : "Line" Tipo:"N"</summary>
		[Display(Name = "LINE27983", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValLine { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpequ>  TableTpequTipoequi { get; set; }


		/// <summary>Campo : "Quantity" Tipo:"N"</summary>
		[Display(Name = "QUANTITY06415", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQuantida { get; set; }

		/// <summary>Campo : "Breakdown:" Tipo:"DP"</summary>
		[Display(Name = "BREAKDOWN_60448", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Lnhde> ValDesagreg { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "ORDER_NO_15510", ResourceType = typeof(Resources.Resources))]
		public string ValCodpedid { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlnhpd { get; set; }

		public Lnhpd_ViewModel() : base("FLNHPD") { }

		public Lnhpd_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHPD", currentNavigation, nestedForm) { }

		public Lnhpd_ViewModel(Models.Lnhpd row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHPD", row, currentNavigation, nestedForm) { }

		public Lnhpd_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("lnhpd", id);
			Model = Models.Lnhpd.Find(id, "FLNHPD", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhpd model = new Models.Lnhpd() { Identifier = "FLNHPD" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Lnhpd model)
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

		public static StatusMessage DeleteConditions(Models.Lnhpd model)
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

		public static StatusMessage ViewConditions(Models.Lnhpd model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Lnhpd model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lnhpd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhpd) to ViewModel (Lnhpd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
 				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
 				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodlnhpd = ViewModelConversion.ToString(m.ValCodlnhpd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhpd) to ViewModel (Lnhpd) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lnhpd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhpd) to Model (Lnhpd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodlnhpd = ViewModelConversion.ToString(ValCodlnhpd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhpd) to Model (Lnhpd) - Error during mapping");
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
				Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), "FLNHPD");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Lnhpd() { Identifier = "FLNHPD" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");
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

			Model.Identifier = "FLNHPD";
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

		protected override void LoadDocumentsProperties(Models.Lnhpd row)
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
				Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), "FLNHPD");
				if (Model == null)
				{
					Model = new Models.Lnhpd() { Identifier = "FLNHPD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Lnhpd___pedidnrpedido(qs, lazyLoad);
			Load_Lnhpd___tpequtipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHPD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHPD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LNHPD]/
		public override void Save()
		{

			try { Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), "FLNHPD"); }
			finally { if (Model == null) Model = new Models.Lnhpd() { Identifier = "FLNHPD" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHPD]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), "FLNHPD"); }
			finally { if (Model == null) Model = new Models.Lnhpd() { Identifier = "FLNHPD" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHPD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHPD]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhpd.Find(id, "FLNHPD");
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
        public void Load_Lnhpd___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhpd___pedidnrpedidoDoLoad = true;
            CriteriaSet lnhpd___pedidnrpedidoConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pedid", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhpd___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, Navigation.GetValue("pedid"));
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
                FillDependant_LnhpdTablePedidNrpedido(lazyLoad);
                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
                return;
            }


            if (lnhpd___pedidnrpedidoDoLoad)
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
                lnhpd___pedidnrpedidoConds.SubSet(search_filters);


                string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHPD_PEDIDNRPEDIDO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
                    lnhpd___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApedid.FldZzstate, 0)
                        .Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
                else
                    lnhpd___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhpd___pedidnrpedidoConds = Pedid.AddEPH<CSGenioApedid>(ref UserContext.Current.User, lnhpd___pedidnrpedidoConds, "LED_LNHPD___PEDIDNRPEDIDO");

                FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
                ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(false, lnhpd___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHPD___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePedidNrpedido.Query = query;
                TablePedidNrpedido.Elements = listing.RowsForViewModel<GenioMVC.Models.Pedid>((r) => new GenioMVC.Models.Pedid(r, true, _fieldsToSerialize_LNHPD___PEDIDNRPEDIDO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
                FillDependant_LnhpdTablePedidNrpedido();

                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePedidNrpedido (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pedid</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhpdTablePedidNrpedido(string PKey, NavigationContext Navigation)
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
        public void FillDependant_LnhpdTablePedidNrpedido(bool lazyLoad = false)
        {
            var row = GetDependant_LnhpdTablePedidNrpedido(this.ValCodpedid, Navigation);
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


        private readonly string[] _fieldsToSerialize_LNHPD___PEDIDNRPEDIDO = { "Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido" };

        /// <summary>
        /// TableTpequTipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lnhpd___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhpd___tpequtipoequiDoLoad = true;
            CriteriaSet lnhpd___tpequtipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpequ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhpd___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
                    this.ValCodtpequ = Navigation.GetStrValue("tpequ");
                }
            }



            TableTpequTipoequi = new TableDBEdit<Models.Tpequ>();
            TableTpequTipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
                    this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
                FillDependant_LnhpdTableTpequTipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
                return;
            }


            if (lnhpd___tpequtipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTipoequi), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
                    TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
                else
                    TableTpequTipoequi.TableFilters = false;

                query = qs["qTableTpequTipoequi"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
                }
                lnhpd___tpequtipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHPD_TPEQUTIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
                    lnhpd___tpequtipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpequ.FldZzstate, 0)
                        .Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
                else
                    lnhpd___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhpd___tpequtipoequiConds = Tpequ.AddEPH<CSGenioAtpequ>(ref UserContext.Current.User, lnhpd___tpequtipoequiConds, "LED_LNHPD___TPEQUTIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
                ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, lnhpd___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_LNHPD___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpequTipoequi.Query = query;
                TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(r, true, _fieldsToSerialize_LNHPD___TPEQUTIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_LnhpdTableTpequTipoequi();

                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpequ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhpdTableTpequTipoequi(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpequ.codtpequ", "tpequ.tipoequi" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi };
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
            CSGenioAtpequ tempArea = new CSGenioAtpequ(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));
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
        /// Fill Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LnhpdTableTpequTipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_LnhpdTableTpequTipoequi(this.ValCodtpequ, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
                TableTpequTipoequi.Value = ViewModelConversion.ToString(row["tpequ.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
                {
                    this.ValCodtpequ = "";
                    TableTpequTipoequi.Value = "";
                    Navigation.ClearValue("tpequ");
                }
                else if (lazyLoad)
                {
                    TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpequTipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpequ),
                            Text = Convert.ToString(TableTpequTipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpequ);
                }
                TableTpequTipoequi.Selected = this.ValCodtpequ;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LNHPD___TPEQUTIPOEQUI = { "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHPD]/
		#endregion
	}
}
