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

namespace GenioMVC.ViewModels.Cmpki
{
	public class Cmpki_ViewModel : FormViewModel<Models.Cmpki>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpequ>  TableTpequTipoequi { get; set; }

		/// <summary>Campo : "Order" Tipo:"N"</summary>
		[Display(Name = "ORDER39632", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N1}" )]
		[NumericAttribute(1)]
		public decimal? ValOrder { get; set; }

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

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpeq1 { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodcmpki { get; set; }

		public Cmpki_ViewModel() : base("FCMPKI") { }

		public Cmpki_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCMPKI", currentNavigation, nestedForm) { }

		public Cmpki_ViewModel(Models.Cmpki row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCMPKI", row, currentNavigation, nestedForm) { }

		public Cmpki_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cmpki", id);
			Model = Models.Cmpki.Find(id, "FCMPKI", fieldsToQuery: fieldsToLoad);
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
			Models.Cmpki model = new Models.Cmpki() { Identifier = "FCMPKI" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cmpki model)
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

		public static StatusMessage DeleteConditions(Models.Cmpki model)
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

		public static StatusMessage ViewConditions(Models.Cmpki model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cmpki model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cmpki m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpki) to ViewModel (Cmpki) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
 				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
 				ValCode = ViewModelConversion.ToString(m.ValCode);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValUrl = ViewModelConversion.ToString(m.ValUrl);
 				ValCodtpeq1 = ViewModelConversion.ToString(m.ValCodtpeq1);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodcmpki = ViewModelConversion.ToString(m.ValCodcmpki);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpki) to ViewModel (Cmpki) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cmpki m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cmpki) to Model (Cmpki) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValCode = ViewModelConversion.ToString(ValCode);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValUrl = ViewModelConversion.ToString(ValUrl);
				m.ValCodtpeq1 = ViewModelConversion.ToString(ValCodtpeq1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodcmpki = ViewModelConversion.ToString(ValCodcmpki);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cmpki) to Model (Cmpki) - Error during mapping");
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
				Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), "FCMPKI");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cmpki() { Identifier = "FCMPKI" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpki");
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

			Model.Identifier = "FCMPKI";
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

		protected override void LoadDocumentsProperties(Models.Cmpki row)
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
				Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), "FCMPKI");
				if (Model == null)
				{
					Model = new Models.Cmpki() { Identifier = "FCMPKI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpki");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Cmpki___tpequtipoequi(qs, lazyLoad);
			Load_Cmpki___tpeq1tipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CMPKI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CMPKI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CMPKI]/
		public override void Save()
		{

			try { Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), "FCMPKI"); }
			finally { if (Model == null) Model = new Models.Cmpki() { Identifier = "FCMPKI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CMPKI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cmpki.Find(Navigation.GetStrValue("cmpki"), "FCMPKI"); }
			finally { if (Model == null) Model = new Models.Cmpki() { Identifier = "FCMPKI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CMPKI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CMPKI]/
		public override void Destroy(string id)
		{
			Model = Models.Cmpki.Find(id, "FCMPKI");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableTpequTipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Cmpki___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool cmpki___tpequtipoequiDoLoad = true;
            CriteriaSet cmpki___tpequtipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpequ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    cmpki___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
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
                FillDependant_CmpkiTableTpequTipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
                return;
            }


            if (cmpki___tpequtipoequiDoLoad)
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
                cmpki___tpequtipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ CMPKI_TPEQUTIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
                    cmpki___tpequtipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpequ.FldZzstate, 0)
                        .Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
                else
                    cmpki___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //cmpki___tpequtipoequiConds = Tpequ.AddEPH<CSGenioAtpequ>(ref UserContext.Current.User, cmpki___tpequtipoequiConds, "LED_CMPKI___TPEQUTIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
                ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, cmpki___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_CMPKI___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpequTipoequi.Query = query;
                TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(r, true, _fieldsToSerialize_CMPKI___TPEQUTIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_CmpkiTableTpequTipoequi();

                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpequ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_CmpkiTableTpequTipoequi(string PKey, NavigationContext Navigation)
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
        public void FillDependant_CmpkiTableTpequTipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_CmpkiTableTpequTipoequi(this.ValCodtpequ, Navigation);
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


        private readonly string[] _fieldsToSerialize_CMPKI___TPEQUTIPOEQUI = { "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi" };

        /// <summary>
        /// TableTpeq1Tipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Cmpki___tpeq1tipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool cmpki___tpeq1tipoequiDoLoad = true;
            CriteriaSet cmpki___tpeq1tipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpeq1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    cmpki___tpeq1tipoequiConds.Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetValue("tpeq1"));
                    this.ValCodtpeq1 = Navigation.GetStrValue("tpeq1");
                }
            }



            TableTpeq1Tipoequi = new TableDBEdit<Models.Tpeq1>();
            TableTpeq1Tipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
                    this.ValCodtpeq1 = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}
                FillDependant_CmpkiTableTpeq1Tipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
                return;
            }


            if (cmpki___tpeq1tipoequiDoLoad)
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
                cmpki___tpeq1tipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpeq1Tipoequi"] != null ? qs["pTableTpeq1Tipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldZzstate };

// USE /[MANUAL GQT OVERRQ CMPKI_TPEQ1TIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpeq1", FormMode.New) || Navigation.checkFormMode("tpeq1", FormMode.Duplicate))
                    cmpki___tpeq1tipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpeq1.FldZzstate, 0)
                        .Equal(CSGenioAtpeq1.FldCodtpequ, Navigation.GetStrValue("tpeq1")));
                else
                    cmpki___tpeq1tipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpeq1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //cmpki___tpeq1tipoequiConds = Tpeq1.AddEPH<CSGenioAtpeq1>(ref UserContext.Current.User, cmpki___tpeq1tipoequiConds, "LED_CMPKI___TPEQ1TIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpeq1", "tipoequi");
                ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, cmpki___tpeq1tipoequiConds, fields, offset, numberItems, sorts, "LED_CMPKI___TPEQ1TIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpeq1Tipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpeq1Tipoequi.Query = query;
                TableTpeq1Tipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpeq1>((r) => new GenioMVC.Models.Tpeq1(r, true, _fieldsToSerialize_CMPKI___TPEQ1TIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpeq1") != null)
				{
					this.ValCodtpeq1 = Navigation.GetStrValue("RETURN_tpeq1");
					Navigation.CurrentLevel.SetEntry("RETURN_tpeq1", null);
				}

				TableTpeq1Tipoequi.List = new SelectList(TableTpeq1Tipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpeq1), "Value", "Text", this.ValCodtpeq1);
                FillDependant_CmpkiTableTpeq1Tipoequi();

                //Check if foreignkey comes from history
                TableTpeq1Tipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpeq1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpeq1Tipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpeq1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_CmpkiTableTpeq1Tipoequi(string PKey, NavigationContext Navigation)
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
        public void FillDependant_CmpkiTableTpeq1Tipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_CmpkiTableTpeq1Tipoequi(this.ValCodtpeq1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpeq1 = ViewModelConversion.ToString(row["tpeq1.codtpequ"]);
                TableTpeq1Tipoequi.Value = ViewModelConversion.ToString(row["tpeq1.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpeq1) == 1)
                {
                    this.ValCodtpeq1 = "";
                    TableTpeq1Tipoequi.Value = "";
                    Navigation.ClearValue("tpeq1");
                }
                else if (lazyLoad)
                {
                    TableTpeq1Tipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpeq1Tipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpeq1),
                            Text = Convert.ToString(TableTpeq1Tipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpeq1);
                }
                TableTpeq1Tipoequi.Selected = this.ValCodtpeq1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpeq1Tipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_CMPKI___TPEQ1TIPOEQUI = { "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CMPKI]/
		#endregion
	}
}
