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

namespace GenioMVC.ViewModels.Feeca
{
	public class Feeca_ViewModel : FormViewModel<Models.Feeca>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Flds>  TableFldsDescrip { get; set; }

		/// <summary>Campo : "Feedback" Tipo:"C"</summary>
		[Display(Name = "FEEDBACK52855", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFeedback { get; set; }

		/// <summary>Campo : "Attachments" Tipo:"IB"</summary>
		[Display(Name = "ATTACHMENTS19612", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("FldsValAttach", false, true, false, false, DocumentViewTypeMode.Preview)]
		public string FldsValAttach { get { return funcFldsValAttach != null ? funcFldsValAttach() : _auxFldsValAttach; } set { funcFldsValAttach = () => value; } }
		public string FldsValAttachfk { get; set; }
		public DocumsProperties_ViewModel FldsValAttachPropertiesVM { get; set; }
		[JsonIgnore]
		public Func<string> funcFldsValAttach { get; set; }
		private string _auxFldsValAttach { get; set; }

		/// <summary>Campo : "Passenger capacity on the plane" Tipo:"N"</summary>
		[Display(Name = "PASSENGER_CAPACITY_O45867", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? FldsValNpassage { get { return funcFldsValNpassage != null ? funcFldsValNpassage() : _auxFldsValNpassage; } set { funcFldsValNpassage = () => value; } }
		[JsonIgnore]
		public Func<decimal?> funcFldsValNpassage { get; set; }
		private decimal? _auxFldsValNpassage { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		public string ValCodflds { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodfeeca { get; set; }

		public Feeca_ViewModel() : base("FFEECA") { }

		public Feeca_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFEECA", currentNavigation, nestedForm) { }

		public Feeca_ViewModel(Models.Feeca row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFEECA", row, currentNavigation, nestedForm) { }

		public Feeca_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("feeca", id);
			Model = Models.Feeca.Find(id, "FFEECA", fieldsToQuery: fieldsToLoad);
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
			Models.Feeca model = new Models.Feeca() { Identifier = "FFEECA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Feeca model)
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

		public static StatusMessage DeleteConditions(Models.Feeca model)
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

		public static StatusMessage ViewConditions(Models.Feeca model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Feeca model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValFeedback = ViewModelConversion.ToString(m.ValFeedback);
 				funcFldsValAttach = () => ViewModelConversion.ToString(m.Flds.ValAttach);
				FldsValAttachfk = ViewModelConversion.ToString(m.Flds.ValAttachfk);
 				funcFldsValNpassage = () => ViewModelConversion.ToNumeric(m.Flds.ValNpassage);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
 				ValCodfeeca = ViewModelConversion.ToString(m.ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Feeca) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Feeca) to Model (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValFeedback = ViewModelConversion.ToString(ValFeedback);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
				m.ValCodfeeca = ViewModelConversion.ToString(ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Feeca) to Model (Feeca) - Error during mapping");
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), "FFEECA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Feeca() { Identifier = "FFEECA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");
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

			Model.Identifier = "FFEECA";
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

		protected override void LoadDocumentsProperties(Models.Feeca row)
		{
			try
			{
				FldsValAttachPropertiesVM = row.Flds.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				FldsValAttachPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
			}
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), "FFEECA");
				if (Model == null)
				{
					Model = new Models.Feeca() { Identifier = "FFEECA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Feeca___flds_descrip_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FEECA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FEECA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FEECA]/
		public override void Save()
		{

			try { Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), "FFEECA"); }
			finally { if (Model == null) Model = new Models.Feeca() { Identifier = "FFEECA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FEECA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), "FFEECA"); }
			finally { if (Model == null) Model = new Models.Feeca() { Identifier = "FFEECA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FEECA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FEECA]/
		public override void Destroy(string id)
		{
			Model = Models.Feeca.Find(id, "FFEECA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableFldsDescrip -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Feeca___flds_descrip_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool feeca___flds_descrip_DoLoad = true;
            CriteriaSet feeca___flds_descrip_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("flds", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    feeca___flds_descrip_Conds.Equal(CSGenioAflds.FldCodflds, Navigation.GetValue("flds"));
                    this.ValCodflds = Navigation.GetStrValue("flds");
                }
            }



            TableFldsDescrip = new TableDBEdit<Models.Flds>();
            TableFldsDescrip.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_flds") != null)
				{
                    this.ValCodflds = Navigation.GetStrValue("RETURN_flds");
					Navigation.CurrentLevel.SetEntry("RETURN_flds", null);
				}
                FillDependant_FeecaTableFldsDescrip(lazyLoad);
                //Check if foreignkey comes from history
                TableFldsDescrip.FilledByHistory = Navigation.CheckFilledByHistory("flds");
                return;
            }


            if (feeca___flds_descrip_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFldsDescrip, "sTableFldsDescrip", "dTableFldsDescrip", qs, "flds");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFldsDescrip_tableFilters"]))
                    TableFldsDescrip.TableFilters = bool.Parse(qs["TableFldsDescrip_tableFilters"]);
                else
                    TableFldsDescrip.TableFilters = false;

                query = qs["qTableFldsDescrip"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAflds.FldDescrip, query + "%");
                }
                feeca___flds_descrip_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFldsDescrip"] != null ? qs["pTableFldsDescrip"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAflds.FldZzstate };

// USE /[MANUAL GQT OVERRQ FEECA_FLDSDESCRIP]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("flds", FormMode.New) || Navigation.checkFormMode("flds", FormMode.Duplicate))
                    feeca___flds_descrip_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAflds.FldZzstate, 0)
                        .Equal(CSGenioAflds.FldCodflds, Navigation.GetStrValue("flds")));
                else
                    feeca___flds_descrip_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAflds.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //feeca___flds_descrip_Conds = Flds.AddEPH<CSGenioAflds>(ref UserContext.Current.User, feeca___flds_descrip_Conds, "LED_FEECA___FLDS_DESCRIP_");

                FieldRef firstVisibleColumn = new FieldRef("flds", "descrip");
                ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(false, feeca___flds_descrip_Conds, fields, offset, numberItems, sorts, "LED_FEECA___FLDS_DESCRIP_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFldsDescrip.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFldsDescrip.Query = query;
                TableFldsDescrip.Elements = listing.RowsForViewModel<GenioMVC.Models.Flds>((r) => new GenioMVC.Models.Flds(r, true, _fieldsToSerialize_FEECA___FLDS_DESCRIP_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_flds") != null)
				{
					this.ValCodflds = Navigation.GetStrValue("RETURN_flds");
					Navigation.CurrentLevel.SetEntry("RETURN_flds", null);
				}

				TableFldsDescrip.List = new SelectList(TableFldsDescrip.Elements.ToSelectList(x => x.ValDescrip, x => x.ValCodflds,  x => x.ValCodflds == this.ValCodflds), "Value", "Text", this.ValCodflds);
                if(!isSearchRequest)
                    FillDependant_FeecaTableFldsDescrip();

                //Check if foreignkey comes from history
                TableFldsDescrip.FilledByHistory = Navigation.CheckFilledByHistory("flds");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFldsDescrip (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Flds</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_FeecaTableFldsDescrip(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "flds.codflds", "flds.descrip", "flds.attach", "flds.npassage" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAflds.FldAttach, CSGenioAflds.FldNpassage };
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
            CSGenioAflds tempArea = new CSGenioAflds(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAflds.FldCodflds, PKey));
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
        /// Fill Dependant fields values -> TableFldsDescrip (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_FeecaTableFldsDescrip(bool lazyLoad = false)
        {
            var row = GetDependant_FeecaTableFldsDescrip(this.ValCodflds, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["flds.attach"]);
                    this.funcFldsValAttach = () => tempValue;
                }
                {
                    var tempValue = ViewModelConversion.ToNumeric(row["flds.npassage"]);
                    this.funcFldsValNpassage = () => tempValue;
                }

                // Fill List fields
                this.ValCodflds = ViewModelConversion.ToString(row["flds.codflds"]);
                TableFldsDescrip.Value = ViewModelConversion.ToString(row["flds.descrip"]);
                if (GlobalFunctions.emptyG(this.ValCodflds) == 1)
                {
                    this.ValCodflds = "";
                    TableFldsDescrip.Value = "";
                    Navigation.ClearValue("flds");
                }
                else if (lazyLoad)
                {
                    TableFldsDescrip.SetPagination(1, 0, false, false, 1);
                    TableFldsDescrip.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodflds),
                            Text = Convert.ToString(TableFldsDescrip.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodflds);
                }
                TableFldsDescrip.Selected = this.ValCodflds;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFldsDescrip): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_FEECA___FLDS_DESCRIP_ = { "Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Flds.ValDescrip" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FEECA]/
		#endregion
	}
}
