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

namespace GenioMVC.ViewModels.Anexd
{
	public class Anexd_ViewModel : FormViewModel<Models.Anexd>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "No. register" Tipo:"C"</summary>
		[Display(Name = "NO__REGISTER04207", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "Attached" Tipo:"DT"</summary>
		[Display(Name = "ATTACHED26247", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDthranex { get; set; }

		/// <summary>Campo : "Reference" Tipo:"C"</summary>
		[Display(Name = "REFERENCE28402", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValReferenc { get; set; }

		/// <summary>Campo : "Title" Tipo:"C"</summary>
		[Display(Name = "TITLE21885", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTitle { get; set; }

		/// <summary>Campo : "Language" Tipo:"C"</summary>
		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Langu>  TableLanguLangua { get; set; }

		/// <summary>Campo : "Translated Title" Tipo:"C"</summary>
		[Display(Name = "TRANSLATED_TITLE04469", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTittradu { get; set; }

		/// <summary>Campo : "Document" Tipo:"IB"</summary>
		[Display(Name = "DOCUMENT00695", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValDocument", false, true, false, false, DocumentViewTypeMode.Preview)]
		public string ValDocument { get; set; }
		public string ValDocumentfk { get; set; }
		public DocumsProperties_ViewModel ValDocumentPropertiesVM { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "NO__REGISTER04207", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		[Display(Name = "LANGUAGE16872", ResourceType = typeof(Resources.Resources))]
		public string ValCodlang { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodanexd { get; set; }

		public Anexd_ViewModel() : base("FANEXD") { }

		public Anexd_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FANEXD", currentNavigation, nestedForm) { }

		public Anexd_ViewModel(Models.Anexd row, NavigationContext currentNavigation, bool nestedForm = false) : base("FANEXD", row, currentNavigation, nestedForm) { }

		public Anexd_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("anexd", id);
			Model = Models.Anexd.Find(id, "FANEXD", fieldsToQuery: fieldsToLoad);
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
			Models.Anexd model = new Models.Anexd() { Identifier = "FANEXD" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Anexd model)
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

		public static StatusMessage DeleteConditions(Models.Anexd model)
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

		public static StatusMessage ViewConditions(Models.Anexd model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Anexd model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Anexd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Anexd) to ViewModel (Anexd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDthranex = ViewModelConversion.ToDateTime(m.ValDthranex);
 				ValReferenc = ViewModelConversion.ToString(m.ValReferenc);
 				ValTitle = ViewModelConversion.ToString(m.ValTitle);
 				ValTittradu = ViewModelConversion.ToString(m.ValTittradu);
 				ValDocument = ViewModelConversion.ToString(m.ValDocument);
				ValDocumentfk = ViewModelConversion.ToString(m.ValDocumentfk);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodlang = ViewModelConversion.ToString(m.ValCodlang);
 				ValCodanexd = ViewModelConversion.ToString(m.ValCodanexd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Anexd) to ViewModel (Anexd) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Anexd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Anexd) to Model (Anexd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDthranex = ViewModelConversion.ToDateTime(ValDthranex);
				m.ValReferenc = ViewModelConversion.ToString(ValReferenc);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValTittradu = ViewModelConversion.ToString(ValTittradu);
				m.ValDocument = ViewModelConversion.ToString(ValDocument);
				m.ValDocumentfk = ViewModelConversion.ToString(ValDocumentfk);

				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodlang = ViewModelConversion.ToString(ValCodlang);
				m.ValCodanexd = ViewModelConversion.ToString(ValCodanexd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Anexd) to Model (Anexd) - Error during mapping");
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
				Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), "FANEXD");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Anexd() { Identifier = "FANEXD" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("anexd");
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

			Model.Identifier = "FANEXD";
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

		protected override void LoadDocumentsProperties(Models.Anexd row)
		{
			try
			{
				ValDocumentPropertiesVM = row.GetInfoDoc("ValDocument");
			}
			catch (Exception)
			{
				ValDocumentPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
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
				Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), "FANEXD");
				if (Model == null)
				{
					Model = new Models.Anexd() { Identifier = "FANEXD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("anexd");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Anexd___equipregistnr(qs, lazyLoad);
			Load_Anexd___langulangua__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ANEXD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ANEXD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ANEXD]/
		public override void Save()
		{

			try { Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), "FANEXD"); }
			finally { if (Model == null) Model = new Models.Anexd() { Identifier = "FANEXD" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ANEXD]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), "FANEXD"); }
			finally { if (Model == null) Model = new Models.Anexd() { Identifier = "FANEXD" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ANEXD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ANEXD]/
		public override void Destroy(string id)
		{
			Model = Models.Anexd.Find(id, "FANEXD");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableEquipRegistnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Anexd___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool anexd___equipregistnrDoLoad = true;
            CriteriaSet anexd___equipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    anexd___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
                    this.ValCodequip = Navigation.GetStrValue("equip");
                }
            }



            TableEquipRegistnr = new TableDBEdit<Models.Equip>();
            TableEquipRegistnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
                    this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
                FillDependant_AnexdTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }


            if (anexd___equipregistnrDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEquipRegistnr_tableFilters"]))
                    TableEquipRegistnr.TableFilters = bool.Parse(qs["TableEquipRegistnr_tableFilters"]);
                else
                    TableEquipRegistnr.TableFilters = false;

                query = qs["qTableEquipRegistnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
                }
                anexd___equipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ ANEXD_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    anexd___equipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    anexd___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //anexd___equipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, anexd___equipregistnrConds, "LED_ANEXD___EQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, anexd___equipregistnrConds, fields, offset, numberItems, sorts, "LED_ANEXD___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_ANEXD___EQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                FillDependant_AnexdTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AnexdTableEquipRegistnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "equip.codequip", "equip.registnr" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr };
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
            CSGenioAequip tempArea = new CSGenioAequip(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAequip.FldCodequip, PKey));
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
        /// Fill Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AnexdTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_AnexdTableEquipRegistnr(this.ValCodequip, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodequip = ViewModelConversion.ToString(row["equip.codequip"]);
                TableEquipRegistnr.Value = ViewModelConversion.ToString(row["equip.registnr"]);
                if (GlobalFunctions.emptyG(this.ValCodequip) == 1)
                {
                    this.ValCodequip = "";
                    TableEquipRegistnr.Value = "";
                    Navigation.ClearValue("equip");
                }
                else if (lazyLoad)
                {
                    TableEquipRegistnr.SetPagination(1, 0, false, false, 1);
                    TableEquipRegistnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodequip),
                            Text = Convert.ToString(TableEquipRegistnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodequip);
                }
                TableEquipRegistnr.Selected = this.ValCodequip;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEquipRegistnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ANEXD___EQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr" };

        /// <summary>
        /// TableLanguLangua -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Anexd___langulangua__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool anexd___langulangua__DoLoad = true;
            CriteriaSet anexd___langulangua__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("langu", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    anexd___langulangua__Conds.Equal(CSGenioAlangu.FldCodlang, Navigation.GetValue("langu"));
                    this.ValCodlang = Navigation.GetStrValue("langu");
                }
            }



            TableLanguLangua = new TableDBEdit<Models.Langu>();
            TableLanguLangua.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_langu") != null)
				{
                    this.ValCodlang = Navigation.GetStrValue("RETURN_langu");
					Navigation.CurrentLevel.SetEntry("RETURN_langu", null);
				}
                FillDependant_AnexdTableLanguLangua(lazyLoad);
                //Check if foreignkey comes from history
                TableLanguLangua.FilledByHistory = Navigation.CheckFilledByHistory("langu");
                return;
            }


            if (anexd___langulangua__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableLanguLangua, "sTableLanguLangua", "dTableLanguLangua", qs, "langu");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlangu.FldLangua), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableLanguLangua_tableFilters"]))
                    TableLanguLangua.TableFilters = bool.Parse(qs["TableLanguLangua_tableFilters"]);
                else
                    TableLanguLangua.TableFilters = false;

                query = qs["qTableLanguLangua"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAlangu.FldLangua, query + "%");
                }
                anexd___langulangua__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableLanguLangua"] != null ? qs["pTableLanguLangua"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua, CSGenioAlangu.FldZzstate };

// USE /[MANUAL GQT OVERRQ ANEXD_LANGULANGUA]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("langu", FormMode.New) || Navigation.checkFormMode("langu", FormMode.Duplicate))
                    anexd___langulangua__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAlangu.FldZzstate, 0)
                        .Equal(CSGenioAlangu.FldCodlang, Navigation.GetStrValue("langu")));
                else
                    anexd___langulangua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlangu.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //anexd___langulangua__Conds = Langu.AddEPH<CSGenioAlangu>(ref UserContext.Current.User, anexd___langulangua__Conds, "LED_ANEXD___LANGULANGUA__");

                FieldRef firstVisibleColumn = new FieldRef("langu", "langua");
                ListingMVC<CSGenioAlangu> listing = Models.ModelBase.Where<CSGenioAlangu>(false, anexd___langulangua__Conds, fields, offset, numberItems, sorts, "LED_ANEXD___LANGULANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableLanguLangua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableLanguLangua.Query = query;
                TableLanguLangua.Elements = listing.RowsForViewModel<GenioMVC.Models.Langu>((r) => new GenioMVC.Models.Langu(r, true, _fieldsToSerialize_ANEXD___LANGULANGUA__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_langu") != null)
				{
					this.ValCodlang = Navigation.GetStrValue("RETURN_langu");
					Navigation.CurrentLevel.SetEntry("RETURN_langu", null);
				}

				TableLanguLangua.List = new SelectList(TableLanguLangua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodlang), "Value", "Text", this.ValCodlang);
                FillDependant_AnexdTableLanguLangua();

                //Check if foreignkey comes from history
                TableLanguLangua.FilledByHistory = Navigation.CheckFilledByHistory("langu");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableLanguLangua (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Langu</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AnexdTableLanguLangua(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "langu.codlang", "langu.langua" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua };
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
            CSGenioAlangu tempArea = new CSGenioAlangu(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAlangu.FldCodlang, PKey));
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
        /// Fill Dependant fields values -> TableLanguLangua (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AnexdTableLanguLangua(bool lazyLoad = false)
        {
            var row = GetDependant_AnexdTableLanguLangua(this.ValCodlang, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodlang = ViewModelConversion.ToString(row["langu.codlang"]);
                TableLanguLangua.Value = ViewModelConversion.ToString(row["langu.langua"]);
                if (GlobalFunctions.emptyG(this.ValCodlang) == 1)
                {
                    this.ValCodlang = "";
                    TableLanguLangua.Value = "";
                    Navigation.ClearValue("langu");
                }
                else if (lazyLoad)
                {
                    TableLanguLangua.SetPagination(1, 0, false, false, 1);
                    TableLanguLangua.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodlang),
                            Text = Convert.ToString(TableLanguLangua.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodlang);
                }
                TableLanguLangua.Selected = this.ValCodlang;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLanguLangua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ANEXD___LANGULANGUA__ = { "Langu", "Langu.ValCodlang", "Langu.ValZzstate", "Langu.ValLangua" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ANEXD]/
		#endregion
	}
}
