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

namespace GenioMVC.ViewModels.Movim
{
	public class Movim_ViewModel : FormViewModel<Models.Movim>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Change" Tipo:"DT"</summary>
		[Display(Name = "CHANGE36355", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDhmudanc { get; set; }

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "Room No." Tipo:"C"</summary>
		[Display(Name = "ROOM_NO_08024", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Rooms>  TableRoomsRoomnr { get; set; }

		/// <summary>Campo : "Observation" Tipo:"MO"</summary>
		[Display(Name = "OBSERVATION37880", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValObservat { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		[Display(Name = "ROOM_NO_08024", ResourceType = typeof(Resources.Resources))]
		public string ValCodrooms { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodmovim { get; set; }

		public Movim_ViewModel() : base("FMOVIM") { }

		public Movim_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FMOVIM", currentNavigation, nestedForm) { }

		public Movim_ViewModel(Models.Movim row, NavigationContext currentNavigation, bool nestedForm = false) : base("FMOVIM", row, currentNavigation, nestedForm) { }

		public Movim_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("movim", id);
			Model = Models.Movim.Find(id, "FMOVIM", fieldsToQuery: fieldsToLoad);
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
			Models.Movim model = new Models.Movim() { Identifier = "FMOVIM" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Movim model)
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

		public static StatusMessage DeleteConditions(Models.Movim model)
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

		public static StatusMessage ViewConditions(Models.Movim model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Movim model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Movim m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Movim) to ViewModel (Movim) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDhmudanc = ViewModelConversion.ToDateTime(m.ValDhmudanc);
 				ValObservat = ViewModelConversion.ToString(m.ValObservat);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValCodmovim = ViewModelConversion.ToString(m.ValCodmovim);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Movim) to ViewModel (Movim) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Movim m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Movim) to Model (Movim) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDhmudanc = ViewModelConversion.ToDateTime(ValDhmudanc);
				m.ValObservat = ViewModelConversion.ToString(ValObservat);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodmovim = ViewModelConversion.ToString(ValCodmovim);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Movim) to Model (Movim) - Error during mapping");
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
				Model = Models.Movim.Find(Navigation.GetStrValue("movim"), "FMOVIM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Movim() { Identifier = "FMOVIM" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("movim");
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

			Model.Identifier = "FMOVIM";
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

		protected override void LoadDocumentsProperties(Models.Movim row)
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
				Model = Models.Movim.Find(Navigation.GetStrValue("movim"), "FMOVIM");
				if (Model == null)
				{
					Model = new Models.Movim() { Identifier = "FMOVIM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("movim");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Movim___equipregistnr(qs, lazyLoad);
			Load_Movim___roomsroomnr__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL MOVIM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW MOVIM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE MOVIM]/
		public override void Save()
		{

			try { Model = Models.Movim.Find(Navigation.GetStrValue("movim"), "FMOVIM"); }
			finally { if (Model == null) Model = new Models.Movim() { Identifier = "FMOVIM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY MOVIM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Movim.Find(Navigation.GetStrValue("movim"), "FMOVIM"); }
			finally { if (Model == null) Model = new Models.Movim() { Identifier = "FMOVIM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE MOVIM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY MOVIM]/
		public override void Destroy(string id)
		{
			Model = Models.Movim.Find(id, "FMOVIM");
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
        public void Load_Movim___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool movim___equipregistnrDoLoad = true;
            CriteriaSet movim___equipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    movim___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
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
                FillDependant_MovimTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }


            if (movim___equipregistnrDoLoad)
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
                movim___equipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ MOVIM_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    movim___equipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    movim___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //movim___equipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, movim___equipregistnrConds, "LED_MOVIM___EQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, movim___equipregistnrConds, fields, offset, numberItems, sorts, "LED_MOVIM___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_MOVIM___EQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                FillDependant_MovimTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_MovimTableEquipRegistnr(string PKey, NavigationContext Navigation)
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
        public void FillDependant_MovimTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_MovimTableEquipRegistnr(this.ValCodequip, Navigation);
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


        private readonly string[] _fieldsToSerialize_MOVIM___EQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr" };

        /// <summary>
        /// TableRoomsRoomnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Movim___roomsroomnr__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool movim___roomsroomnr__DoLoad = true;
            CriteriaSet movim___roomsroomnr__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("rooms", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    movim___roomsroomnr__Conds.Equal(CSGenioArooms.FldCodrooms, Navigation.GetValue("rooms"));
                    this.ValCodrooms = Navigation.GetStrValue("rooms");
                }
            }



            TableRoomsRoomnr = new TableDBEdit<Models.Rooms>();
            TableRoomsRoomnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_rooms") != null)
				{
                    this.ValCodrooms = Navigation.GetStrValue("RETURN_rooms");
					Navigation.CurrentLevel.SetEntry("RETURN_rooms", null);
				}
                FillDependant_MovimTableRoomsRoomnr(lazyLoad);
                //Check if foreignkey comes from history
                TableRoomsRoomnr.FilledByHistory = Navigation.CheckFilledByHistory("rooms");
                return;
            }


            if (movim___roomsroomnr__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRoomsRoomnr, "sTableRoomsRoomnr", "dTableRoomsRoomnr", qs, "rooms");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArooms.FldRoomnr), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRoomsRoomnr_tableFilters"]))
                    TableRoomsRoomnr.TableFilters = bool.Parse(qs["TableRoomsRoomnr_tableFilters"]);
                else
                    TableRoomsRoomnr.TableFilters = false;

                query = qs["qTableRoomsRoomnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioArooms.FldRoomnr, query + "%");
                }
                movim___roomsroomnr__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRoomsRoomnr"] != null ? qs["pTableRoomsRoomnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioArooms.FldCodrooms, CSGenioArooms.FldRoomnr, CSGenioArooms.FldZzstate };

// USE /[MANUAL GQT OVERRQ MOVIM_ROOMSROOMNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("rooms", FormMode.New) || Navigation.checkFormMode("rooms", FormMode.Duplicate))
                    movim___roomsroomnr__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioArooms.FldZzstate, 0)
                        .Equal(CSGenioArooms.FldCodrooms, Navigation.GetStrValue("rooms")));
                else
                    movim___roomsroomnr__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArooms.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //movim___roomsroomnr__Conds = Rooms.AddEPH<CSGenioArooms>(ref UserContext.Current.User, movim___roomsroomnr__Conds, "LED_MOVIM___ROOMSROOMNR__");

                FieldRef firstVisibleColumn = new FieldRef("rooms", "roomnr");
                ListingMVC<CSGenioArooms> listing = Models.ModelBase.Where<CSGenioArooms>(false, movim___roomsroomnr__Conds, fields, offset, numberItems, sorts, "LED_MOVIM___ROOMSROOMNR__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRoomsRoomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRoomsRoomnr.Query = query;
                TableRoomsRoomnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Rooms>((r) => new GenioMVC.Models.Rooms(r, true, _fieldsToSerialize_MOVIM___ROOMSROOMNR__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_rooms") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_rooms");
					Navigation.CurrentLevel.SetEntry("RETURN_rooms", null);
				}

				TableRoomsRoomnr.List = new SelectList(TableRoomsRoomnr.Elements.ToSelectList(x => x.ValRoomnr, x => x.ValCodrooms,  x => x.ValCodrooms == this.ValCodrooms), "Value", "Text", this.ValCodrooms);
                FillDependant_MovimTableRoomsRoomnr();

                //Check if foreignkey comes from history
                TableRoomsRoomnr.FilledByHistory = Navigation.CheckFilledByHistory("rooms");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRoomsRoomnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Rooms</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_MovimTableRoomsRoomnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "rooms.codrooms", "rooms.roomnr" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioArooms.FldCodrooms, CSGenioArooms.FldRoomnr };
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
            CSGenioArooms tempArea = new CSGenioArooms(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioArooms.FldCodrooms, PKey));
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
        /// Fill Dependant fields values -> TableRoomsRoomnr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_MovimTableRoomsRoomnr(bool lazyLoad = false)
        {
            var row = GetDependant_MovimTableRoomsRoomnr(this.ValCodrooms, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodrooms = ViewModelConversion.ToString(row["rooms.codrooms"]);
                TableRoomsRoomnr.Value = ViewModelConversion.ToString(row["rooms.roomnr"]);
                if (GlobalFunctions.emptyG(this.ValCodrooms) == 1)
                {
                    this.ValCodrooms = "";
                    TableRoomsRoomnr.Value = "";
                    Navigation.ClearValue("rooms");
                }
                else if (lazyLoad)
                {
                    TableRoomsRoomnr.SetPagination(1, 0, false, false, 1);
                    TableRoomsRoomnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodrooms),
                            Text = Convert.ToString(TableRoomsRoomnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodrooms);
                }
                TableRoomsRoomnr.Selected = this.ValCodrooms;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRoomsRoomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_MOVIM___ROOMSROOMNR__ = { "Rooms", "Rooms.ValCodrooms", "Rooms.ValZzstate", "Rooms.ValRoomnr" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM MOVIM]/
		#endregion
	}
}
