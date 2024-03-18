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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Lnhde
{
	public class Lnhde_ViewModel : FormViewModel<Models.Lnhde>
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

		/// <summary>Campo : "Order line:" Tipo:"N"</summary>
		[Display(Name = "ORDER_LINE_13692", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Lnhpd>  TableLnhpdLine { get; set; }

		/// <summary>Campo : "Order" Tipo:"N"</summary>
		[Display(Name = "ORDER39632", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOrdem { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpeq1>  TableTpeq1Tipoequi { get; set; }

		/// <summary>Campo : "Quantity:" Tipo:"N"</summary>
		[Display(Name = "QUANTITY_08002", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQuantida { get; set; }

		/// <summary>Campo : "Code" Tipo:"C"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCode { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "Site" Tipo:"C"</summary>
		[Display(Name = "SITE06486", ResourceType = typeof(Resources.Resources))]
		[RegularExpression(@"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\/\?\.\:\;\'\,]*)?$",ErrorMessageResourceName = "ENDERECO_INVALIDO_40706", ErrorMessageResourceType = typeof(Resources.Resources))]
		[HyperLink]
		[AllowHtml]
		[StringLength(250, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValUrl { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodlnhag { get; set; }

		[Display(Name = "ORDER_LINE_13692", ResourceType = typeof(Resources.Resources))]
		public string ValCodlnhpd { get; set; }

		[Display(Name = "ORDER_NO_15510", ResourceType = typeof(Resources.Resources))]
		public string ValCodpedid { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodlnhde { get; set; }

		public Lnhde_ViewModel() : base("FLNHDE") { }

		public Lnhde_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHDE", currentNavigation, nestedForm) { }

		public Lnhde_ViewModel(Models.Lnhde row, NavigationContext currentNavigation, bool nestedForm = false) : base("FLNHDE", row, currentNavigation, nestedForm) { }

		public Lnhde_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("lnhde", id);
			Model = Models.Lnhde.Find(id, "FLNHDE", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhde model = new Models.Lnhde() { Identifier = "FLNHDE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Lnhde model)
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

		public static StatusMessage DeleteConditions(Models.Lnhde model)
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

		public static StatusMessage ViewConditions(Models.Lnhde model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Lnhde model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Lnhde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhde) to ViewModel (Lnhde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValOrdem = ViewModelConversion.ToNumeric(m.ValOrdem);
 				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
 				ValCode = ViewModelConversion.ToString(m.ValCode);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValUrl = ViewModelConversion.ToString(m.ValUrl);
 				ValCodlnhag = ViewModelConversion.ToString(m.ValCodlnhag);
 				ValCodlnhpd = ViewModelConversion.ToString(m.ValCodlnhpd);
 				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodlnhde = ViewModelConversion.ToString(m.ValCodlnhde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhde) to ViewModel (Lnhde) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Lnhde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhde) to Model (Lnhde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValOrdem = ViewModelConversion.ToNumeric(ValOrdem);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValCode = ViewModelConversion.ToString(ValCode);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValUrl = ViewModelConversion.ToString(ValUrl);
				m.ValCodlnhag = ViewModelConversion.ToString(ValCodlnhag);
				m.ValCodlnhpd = ViewModelConversion.ToString(ValCodlnhpd);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodlnhde = ViewModelConversion.ToString(ValCodlnhde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhde) to Model (Lnhde) - Error during mapping");
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
				Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), "FLNHDE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Lnhde() { Identifier = "FLNHDE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhde");
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

			Model.Identifier = "FLNHDE";
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

		protected override void LoadDocumentsProperties(Models.Lnhde row)
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
				Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), "FLNHDE");
				if (Model == null)
				{
					Model = new Models.Lnhde() { Identifier = "FLNHDE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhde");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Lnhde___pedidnrpedido(qs, lazyLoad);
			Load_Lnhde___lnhpdline____(qs, lazyLoad);
			Load_Lnhde___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHDE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHDE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LNHDE]/
		public override void Save()
		{

			try { Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), "FLNHDE"); }
			finally { if (Model == null) Model = new Models.Lnhde() { Identifier = "FLNHDE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHDE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Lnhde.Find(Navigation.GetStrValue("lnhde"), "FLNHDE"); }
			finally { if (Model == null) Model = new Models.Lnhde() { Identifier = "FLNHDE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHDE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHDE]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhde.Find(id, "FLNHDE");
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
        public void Load_Lnhde___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhde___pedidnrpedidoDoLoad = true;
            CriteriaSet lnhde___pedidnrpedidoConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pedid", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhde___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, Navigation.GetValue("pedid"));
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
                FillDependant_LnhdeTablePedidNrpedido(lazyLoad);
                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
                return;
            }


            if (lnhde___pedidnrpedidoDoLoad)
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
                lnhde___pedidnrpedidoConds.SubSet(search_filters);


                string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_PEDIDNRPEDIDO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
                    lnhde___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApedid.FldZzstate, 0)
                        .Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
                else
                    lnhde___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhde___pedidnrpedidoConds = Pedid.AddEPH<CSGenioApedid>(ref UserContext.Current.User, lnhde___pedidnrpedidoConds, "LED_LNHDE___PEDIDNRPEDIDO");

                FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
                ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(false, lnhde___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHDE___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePedidNrpedido.Query = query;
                TablePedidNrpedido.Elements = listing.RowsForViewModel<GenioMVC.Models.Pedid>((r) => new GenioMVC.Models.Pedid(r, true, _fieldsToSerialize_LNHDE___PEDIDNRPEDIDO));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
                FillDependant_LnhdeTablePedidNrpedido();

                //Check if foreignkey comes from history
                TablePedidNrpedido.FilledByHistory = Navigation.CheckFilledByHistory("pedid");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePedidNrpedido (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pedid</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhdeTablePedidNrpedido(string PKey, NavigationContext Navigation)
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
        public void FillDependant_LnhdeTablePedidNrpedido(bool lazyLoad = false)
        {
            var row = GetDependant_LnhdeTablePedidNrpedido(this.ValCodpedid, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpedid = ViewModelConversion.ToString(row["pedid.codpedid"]);
                TablePedidNrpedido.Value = ViewModelConversion.ToNumeric(row["pedid.nrpedido"]);
                if (GlobalFunctions.emptyG(this.ValCodpedid) == 1)
                {
                    this.ValCodpedid = "";
                    TablePedidNrpedido.Value = 0;
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


        private readonly string[] _fieldsToSerialize_LNHDE___PEDIDNRPEDIDO = { "Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido" };

        /// <summary>
        /// TableLnhpdLine -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lnhde___lnhpdline____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhde___lnhpdline____DoLoad = true;
            CriteriaSet lnhde___lnhpdline____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("lnhpd", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhde___lnhpdline____Conds.Equal(CSGenioAlnhpd.FldCodlnhpd, Navigation.GetValue("lnhpd"));
                    this.ValCodlnhpd = Navigation.GetStrValue("lnhpd");
                }
            }

			// Limits Generation

			// Area limit
			lnhde___lnhpdline____DoLoad &= AddCriteriaAreaLimit(lnhde___lnhpdline____Conds, CSGenio.business.CSGenioApedid.FldCodpedid, "pedid", this.ValCodpedid, false);


            TableLnhpdLine = new TableDBEdit<Models.Lnhpd>();
            TableLnhpdLine.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_lnhpd") != null)
				{
                    this.ValCodlnhpd = Navigation.GetStrValue("RETURN_lnhpd");
					Navigation.CurrentLevel.SetEntry("RETURN_lnhpd", null);
				}
                FillDependant_LnhdeTableLnhpdLine(lazyLoad);
                //Check if foreignkey comes from history
                TableLnhpdLine.FilledByHistory = Navigation.CheckFilledByHistory("lnhpd");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodpedid))
                lnhde___lnhpdline____DoLoad = false;

            if (lnhde___lnhpdline____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLnhpdLine, "sTableLnhpdLine", "dTableLnhpdLine", qs, "lnhpd");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLnhpdLine_tableFilters"]))
                    TableLnhpdLine.TableFilters = bool.Parse(qs["TableLnhpdLine_tableFilters"]);
                else
                    TableLnhpdLine.TableFilters = false;

                query = qs["qTableLnhpdLine"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAlnhpd.FldLine, query + "%");
                }
                lnhde___lnhpdline____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLnhpdLine"] != null ? qs["pTableLnhpdLine"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlnhpd.FldCodlnhpd, CSGenioAlnhpd.FldLine, CSGenioAlnhpd.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_LNHPDLINE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("lnhpd", FormMode.New) || Navigation.checkFormMode("lnhpd", FormMode.Duplicate))
                    lnhde___lnhpdline____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlnhpd.FldZzstate, 0)
                        .Equal(CSGenioAlnhpd.FldCodlnhpd, Navigation.GetStrValue("lnhpd")));
                else
                    lnhde___lnhpdline____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlnhpd.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhde___lnhpdline____Conds = Lnhpd.AddEPH<CSGenioAlnhpd>(ref UserContext.Current.User, lnhde___lnhpdline____Conds, "LED_LNHDE___LNHPDLINE____");

                FieldRef firstVisibleColumn = new FieldRef("lnhpd", "line");
                ListingMVC<CSGenioAlnhpd> listing = Models.ModelBase.Where<CSGenioAlnhpd>(false, lnhde___lnhpdline____Conds, fields, offset, numberItems, sorts, "LED_LNHDE___LNHPDLINE____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLnhpdLine.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLnhpdLine.Query = query;
                TableLnhpdLine.Elements = listing.RowsForViewModel<GenioMVC.Models.Lnhpd>((r) => new GenioMVC.Models.Lnhpd(r, true, _fieldsToSerialize_LNHDE___LNHPDLINE____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_lnhpd") != null)
				{
					this.ValCodlnhpd = Navigation.GetStrValue("RETURN_lnhpd");
					Navigation.CurrentLevel.SetEntry("RETURN_lnhpd", null);
				}

				TableLnhpdLine.List = new SelectList(TableLnhpdLine.Elements.ToSelectList(x => x.ValLine, x => x.ValCodlnhpd,  x => x.ValCodlnhpd == this.ValCodlnhpd), "Value", "Text", this.ValCodlnhpd);
                FillDependant_LnhdeTableLnhpdLine();

                //Check if foreignkey comes from history
                TableLnhpdLine.FilledByHistory = Navigation.CheckFilledByHistory("lnhpd");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLnhpdLine (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Lnhpd</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhdeTableLnhpdLine(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "lnhpd.codlnhpd", "lnhpd.line" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlnhpd.FldCodlnhpd, CSGenioAlnhpd.FldLine };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("pedid");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAlnhpd.FldCodpedid, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAlnhpd tempArea = new CSGenioAlnhpd(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlnhpd.FldCodlnhpd, PKey));
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
        /// Fill Dependant fields values -> TableLnhpdLine (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_LnhdeTableLnhpdLine(bool lazyLoad = false)
        {
            var row = GetDependant_LnhdeTableLnhpdLine(this.ValCodlnhpd, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodlnhpd = ViewModelConversion.ToString(row["lnhpd.codlnhpd"]);
                TableLnhpdLine.Value = ViewModelConversion.ToNumeric(row["lnhpd.line"]);
                if (GlobalFunctions.emptyG(this.ValCodlnhpd) == 1)
                {
                    this.ValCodlnhpd = "";
                    TableLnhpdLine.Value = 0;
                    Navigation.ClearValue("lnhpd");
                }
                else if (lazyLoad)
                {
                    TableLnhpdLine.SetPagination(1, 0, false, false, 1);
                    TableLnhpdLine.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodlnhpd),
                            Text = Convert.ToString(TableLnhpdLine.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodlnhpd);
                }
                TableLnhpdLine.Selected = this.ValCodlnhpd;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLnhpdLine): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_LNHDE___LNHPDLINE____ = { "Lnhpd", "Lnhpd.ValCodlnhpd", "Lnhpd.ValZzstate", "Lnhpd.ValLine" };

        /// <summary>
        /// TableTpeq1Tipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Lnhde___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool lnhde___tpeq1tipoequiDoLoad = true;
            CriteriaSet lnhde___tpeq1tipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpeq1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    lnhde___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
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
                FillDependant_LnhdeTableTpeq1Tipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
                return;
            }


            if (lnhde___tpeq1tipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpeq1Tipoequi, "sTableTpeq1Tipoequi", "dTableTpeq1Tipoequi", qs, "tpeq1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTpequcod), SortOrder.Ascending));
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
                lnhde___tpeq1tipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ LNHDE_TPEQ1TIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
                    lnhde___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpeq1.FldZzstate, 0)
                        .Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
                else
                    lnhde___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //lnhde___tpeq1tipoequiConds = Tpeq1.AddEPH<CSGenioAtpeq1>(ref UserContext.Current.User, lnhde___tpeq1tipoequiConds, "LED_LNHDE___TPEQ1TIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tpequcod");
                ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, lnhde___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_LNHDE___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpeq1Tipoequi.Query = query;
                TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(r, true, _fieldsToSerialize_LNHDE___TPEQ1TIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_LnhdeTableTpeq1Tipoequi();

                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpeq1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_LnhdeTableTpeq1Tipoequi(string PKey, NavigationContext Navigation)
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
        public void FillDependant_LnhdeTableTpeq1Tipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_LnhdeTableTpeq1Tipoequi(this.ValCodtpequ, Navigation);
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

        public List<TreeNode> Tree_TableTpeq1Tipoequi { get; protected set; }
        /// <summary>
        /// Get tree structure data -> TableTpeq1Tipoequi
        /// </summary>
        public void LoadTree_TableTpeq1Tipoequi(NameValueCollection requestValues)
        {
            List<TreeNode> Tree = null;

            Tree = new List<TreeNode>();
            CriteriaSet lnhde___tpeq1tipoequiConds = CriteriaSet.And();

            bool lnhde___tpeq1tipoequiDoLoad = true;

			if(!lnhde___tpeq1tipoequiDoLoad) return;
            List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTpequcod), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending));


            FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldNivel };

            lnhde___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
 
			lnhde___tpeq1tipoequiConds.SubSets.Add(subfilters);


            TreeViewControl<Models.Tpeq1> tree = new TreeViewControl<Models.Tpeq1>();

// USE /[MANUAL GQT OVERRQ LNHDE_TPEQ1VALTIPOEQUI]/
			tree.AddBranch(new TreeBranchInfo<Models.Tpeq1>() {
				Area = "TPEQ1", Form = "",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Tpeq1, string>(x => x.ValTpequcod),
				ParentSelector = new Func<Models.Tpeq1, string>(x => x.ValTpequpai),
				LevelSelector = new Func<Models.Tpeq1, double>(x => x.ValNivel),
				TextSelector = new Func<Models.Tpeq1, string>(x => string.Format("{0} {1}", x.ValTpequcod, x.ValTipoequi))
			});

            ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, lnhde___tpeq1tipoequiConds, fields, 0, -1, sorts, "IBL_LNHDE___TPEQ1TIPOEQUI");

            var rowsAsModels = listing.RowsForViewModel<Models.Tpeq1>((r) => new Models.Tpeq1(r, true, _fieldsToSerialize_LNHDE___TPEQ1TIPOEQUI).SetIsEmptyModel<Models.Tpeq1>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
            // Filter the final list to only include the top nodes
            Tree_TableTpeq1Tipoequi = Tree.FindAll(x => x.hasParent == false);
        }

        private readonly string[] _fieldsToSerialize_LNHDE___TPEQ1TIPOEQUI = { "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTpequcod", "Tpeq1.ValTipoequi" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHDE]/
		#endregion
	}
}
