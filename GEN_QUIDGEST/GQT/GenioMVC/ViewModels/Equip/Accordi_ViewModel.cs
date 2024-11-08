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

namespace GenioMVC.ViewModels.Equip
{
	public class Accordi_ViewModel : FormViewModel<Models.Equip>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Company:" Tipo:"C"</summary>
		[Display(Name = "COMPANY_22615", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cmpny>  TableCmpnyDesignat { get; set; }

		/// <summary>Campo : "Person" Tipo:"C"</summary>
		[Display(Name = "PERSON10446", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess1>  TablePess1Name { get; set; }

		/// <summary>Campo : "Sequential no." Tipo:"N"</summary>
		[Display(Name = "SEQUENTIAL_NO_38590", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValSequennr { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Facilities:" Tipo:"DP"</summary>
		[Display(Name = "FACILITIES_23844", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstalag { get; set; }

		/// <summary>Campo : "Facilities" Tipo:"DP"</summary>
		[Display(Name = "FACILITIES08876", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstalac { get; set; }

		/// <summary>Campo : "Equipment repairs:" Tipo:"DP"</summary>
		[Display(Name = "EQUIPMENT_REPAIRS_35392", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Repar> ValReparaco { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COMPANY_22615", ResourceType = typeof(Resources.Resources))]
		public string ValCodempre { get; set; }

		public string ValCoddeco { get; set; }

		public string ValCoditem { get; set; }

		[Display(Name = "PERSON10446", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess1 { get; set; }

		public string ValCodtpequ { get; set; }

		public string ValCodwareh { get; set; }

		public string ValCodrooms { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "No. register" Tipo: "C"</summary>
		[AllowHtml]
		public string ValRegistnr { get; set; }
		#endregion

		public string ValCodequip { get; set; }

		public Accordi_ViewModel() : base("FACCORDI") { }

		public Accordi_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FACCORDI", currentNavigation, nestedForm) { }

		public Accordi_ViewModel(Models.Equip row, NavigationContext currentNavigation, bool nestedForm = false) : base("FACCORDI", row, currentNavigation, nestedForm) { }

		public Accordi_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, "FACCORDI", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip() { Identifier = "FACCORDI" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Equip model)
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

		public static StatusMessage DeleteConditions(Models.Equip model)
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

		public static StatusMessage ViewConditions(Models.Equip model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Equip model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Accordi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Accordi) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Accordi) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Accordi) to Model (Equip) - Error during mapping");
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FACCORDI");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Equip() { Identifier = "FACCORDI" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
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

			Model.Identifier = "FACCORDI";
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

		protected override void LoadDocumentsProperties(Models.Equip row)
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FACCORDI");
				if (Model == null)
				{
					Model = new Models.Equip() { Identifier = "FACCORDI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Accordi_cmpnydesignat(qs, lazyLoad);
			Load_Accordi_pess1name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ACCORDI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ACCORDI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ACCORDI]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FACCORDI"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FACCORDI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ACCORDI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FACCORDI"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FACCORDI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ACCORDI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ACCORDI]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, "FACCORDI");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableCmpnyDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Accordi_cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool accordi_cmpnydesignatDoLoad = true;
            CriteriaSet accordi_cmpnydesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cmpny", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    accordi_cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
                    this.ValCodempre = Navigation.GetStrValue("cmpny");
                }
            }



            TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>();
            TableCmpnyDesignat.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
                    this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
                FillDependant_AccordiTableCmpnyDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
                return;
            }


            if (accordi_cmpnydesignatDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
                    TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
                else
                    TableCmpnyDesignat.TableFilters = false;

                query = qs["qTableCmpnyDesignat"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
                }
                accordi_cmpnydesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ ACCORDI_CMPNYDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
                    accordi_cmpnydesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcmpny.FldZzstate, 0)
                        .Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
                else
                    accordi_cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //accordi_cmpnydesignatConds = Cmpny.AddEPH<CSGenioAcmpny>(ref UserContext.Current.User, accordi_cmpnydesignatConds, "LED_ACCORDI_CMPNYDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
                ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, accordi_cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_ACCORDI_CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCmpnyDesignat.Query = query;
                TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(r, true, _fieldsToSerialize_ACCORDI_CMPNYDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
                FillDependant_AccordiTableCmpnyDesignat();

                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cmpny</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AccordiTableCmpnyDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cmpny.codempre", "cmpny.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };
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
            CSGenioAcmpny tempArea = new CSGenioAcmpny(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));
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
        /// Fill Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AccordiTableCmpnyDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_AccordiTableCmpnyDesignat(this.ValCodempre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
                TableCmpnyDesignat.Value = ViewModelConversion.ToString(row["cmpny.designat"]);
                if (GlobalFunctions.emptyG(this.ValCodempre) == 1)
                {
                    this.ValCodempre = "";
                    TableCmpnyDesignat.Value = "";
                    Navigation.ClearValue("cmpny");
                }
                else if (lazyLoad)
                {
                    TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
                    TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodempre),
                            Text = Convert.ToString(TableCmpnyDesignat.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodempre);
                }
                TableCmpnyDesignat.Selected = this.ValCodempre;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ACCORDI_CMPNYDESIGNAT = { "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat" };

        /// <summary>
        /// TablePess1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Accordi_pess1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool accordi_pess1name____DoLoad = true;
            CriteriaSet accordi_pess1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    accordi_pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, Navigation.GetValue("pess1"));
                    this.ValCodpess1 = Navigation.GetStrValue("pess1");
                }
            }

			// Limits Generation

			// Area limit
			accordi_pess1name____DoLoad &= AddCriteriaAreaLimit(accordi_pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);


            TablePess1Name = new TableDBEdit<Models.Pess1>();
            TablePess1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
                    this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
                FillDependant_AccordiTablePess1Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodempre))
                accordi_pess1name____DoLoad = false;

            if (accordi_pess1name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
                    TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
                else
                    TablePess1Name.TableFilters = false;

                query = qs["qTablePess1Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApess1.FldName, query + "%");
                }
                accordi_pess1name____Conds.SubSet(search_filters);

                // Last updated by [CJP] at [2016.12.07]
                // Os filtros definidos no Qfield DBEdit passam a ser filtros fracos, to não limparem o Qvalue escolhido.
                // Os filtros podem ser alterados no "ver mais", mas não são obrigatórios.

                string selectedValue = qs["pess1"] ?? this.ValCodpess1;
                CriteriaSet weakFilters = CriteriaSet.Or();
				if (!string.IsNullOrEmpty(selectedValue))
					weakFilters.Equal(CSGenioApess1.FldCodpesso, selectedValue);

                CriteriaSet subfilters = CriteriaSet.And();
                if (Navigation.CheckKey("filter_ValCodpess1__1") && (bool)Navigation.GetValue("filter_ValCodpess1__1") == true)
                {
						subfilters.Equal(CSGenioApess1.FldGender, "F");

                }
                else
                    Navigation.SetValue("filter_ValCodpess1__1", false);

                if (Navigation.CheckKey("filter_ValCodpess1__2") && (bool)Navigation.GetValue("filter_ValCodpess1__2") == true)
                {
						subfilters.Equal(CSGenioApess1.FldGender, "M");

                }
                else
                    Navigation.SetValue("filter_ValCodpess1__2", false);

                weakFilters.SubSets.Add(subfilters);
                accordi_pess1name____Conds.SubSets.Add(weakFilters);

                string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ ACCORDI_PESS1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
                    accordi_pess1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess1.FldZzstate, 0)
                        .Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
                else
                    accordi_pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //accordi_pess1name____Conds = Pess1.AddEPH<CSGenioApess1>(ref UserContext.Current.User, accordi_pess1name____Conds, "LED_ACCORDI_PESS1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
                ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, accordi_pess1name____Conds, fields, offset, numberItems, sorts, "LED_ACCORDI_PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess1Name.Query = query;
                TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(r, true, _fieldsToSerialize_ACCORDI_PESS1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
                //Seleciona se só um
                if(TablePess1Name.List != null && TablePess1Name.List.Count() == 1)
                {
					this.ValCodpess1 = TablePess1Name.List.First().Value;
					Navigation.SetValue("pess1", this.ValCodpess1);
                }
                FillDependant_AccordiTablePess1Name();

                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AccordiTablePess1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess1.codpesso", "pess1.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("cmpny");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioApess1 tempArea = new CSGenioApess1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AccordiTablePess1Name(bool lazyLoad = false)
        {
            var row = GetDependant_AccordiTablePess1Name(this.ValCodpess1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
                TablePess1Name.Value = ViewModelConversion.ToString(row["pess1.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpess1) == 1)
                {
                    this.ValCodpess1 = "";
                    TablePess1Name.Value = "";
                    Navigation.ClearValue("pess1");
                }
                else if (lazyLoad)
                {
                    TablePess1Name.SetPagination(1, 0, false, false, 1);
                    TablePess1Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpess1),
                            Text = Convert.ToString(TablePess1Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpess1);
                }
                TablePess1Name.Selected = this.ValCodpess1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }

        public List<TreeNode> Tree_TablePess1Name { get; protected set; }
        /// <summary>
        /// Get tree structure data -> TablePess1Name
        /// </summary>
        public void LoadTree_TablePess1Name(NameValueCollection requestValues)
        {
            List<TreeNode> Tree = null;

            Tree = new List<TreeNode>();
            CriteriaSet accordi_pess1name____Conds = CriteriaSet.And();

            bool accordi_pess1name____DoLoad = true;
			// Limits Generation

			// Area limit
			accordi_pess1name____DoLoad &= AddCriteriaAreaLimit(accordi_pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

			if(!accordi_pess1name____DoLoad) return;
            List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


            FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldName };

            accordi_pess1name____Conds.Equal(CSGenioApess1.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
            {
                var groupFilters = CriteriaSet.Or();
                bool filter_Accordi_Pess1ValName__1 = false;
                if (requestValues["filter_Accordi_Pess1ValName_"] != null)
                    filter_Accordi_Pess1ValName__1 = requestValues["filter_Accordi_Pess1ValName_"].Contains("1");
                else if (Navigation.CheckKey("filter_Accordi_Pess1ValName__1"))
                    filter_Accordi_Pess1ValName__1 = (bool)Navigation.GetValue("filter_Accordi_Pess1ValName__1");
                Navigation.SetValue("filter_Accordi_Pess1ValName__1", filter_Accordi_Pess1ValName__1);
                if (filter_Accordi_Pess1ValName__1)
                {
					groupFilters.Equal(CSGenioApess1.FldGender, "F");

                }

                 subfilters.SubSets.Add(groupFilters);
            }
            {
                var groupFilters = CriteriaSet.Or();
                bool filter_Accordi_Pess1ValName__2 = false;
                if (requestValues["filter_Accordi_Pess1ValName_"] != null)
                    filter_Accordi_Pess1ValName__2 = requestValues["filter_Accordi_Pess1ValName_"].Contains("2");
                else if (Navigation.CheckKey("filter_Accordi_Pess1ValName__2"))
                    filter_Accordi_Pess1ValName__2 = (bool)Navigation.GetValue("filter_Accordi_Pess1ValName__2");
                Navigation.SetValue("filter_Accordi_Pess1ValName__2", filter_Accordi_Pess1ValName__2);
                if (filter_Accordi_Pess1ValName__2)
                {
					groupFilters.Equal(CSGenioApess1.FldGender, "M");

                }

                 subfilters.SubSets.Add(groupFilters);
            }
 
			accordi_pess1name____Conds.SubSets.Add(subfilters);


            TreeViewControl<Models.Pess1> tree = new TreeViewControl<Models.Pess1>();

// USE /[MANUAL GQT OVERRQ ACCORDI_PESS1VALNAME]/
			tree.AddBranch(new TreeBranchInfo<Models.Pess1>() {
				Area = "PESS1", Form = "",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Pess1, string>(x => x.ValName),
				TextSelector = new Func<Models.Pess1, string>(x => string.Format("{0}", x.ValName))
			});

            ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, accordi_pess1name____Conds, fields, 0, -1, sorts, "IBL_ACCORDI_PESS1NAME____");

            var rowsAsModels = listing.RowsForViewModel<Models.Pess1>((r) => new Models.Pess1(r, true, _fieldsToSerialize_ACCORDI_PESS1NAME____).SetIsEmptyModel<Models.Pess1>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
            // Filter the final list to only include the top nodes
            Tree_TablePess1Name = Tree.FindAll(x => x.hasParent == false);
        }

        private readonly string[] _fieldsToSerialize_ACCORDI_PESS1NAME____ = { "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ACCORDI]/
		#endregion
	}
}
