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

namespace GenioMVC.ViewModels.Pwcom
{
	public class Pwcom_ViewModel : FormViewModel<Models.Pwcom>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Login Name" Tipo:"C"</summary>
		[Display(Name = "LOGIN_NAME03494", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Psw>  TablePswNome { get; set; }

		/// <summary>Campo : "Lending:" Tipo:"C"</summary>
		[Display(Name = "LENDING_48355", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess1>  TablePess1Name { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 135, false, true)]
		public byte[] ValFoto { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "LENDING_48355", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess1 { get; set; }

		[Display(Name = "LOGIN_NAME03494", ResourceType = typeof(Resources.Resources))]
		public string ValCodpsw { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Name" Tipo: "C"</summary>
		[AllowHtml]
		public string ValName { get; set; }
		#endregion

		public string ValCodpwcom { get; set; }

		public Pwcom_ViewModel() : base("FPWCOM") { }

		public Pwcom_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPWCOM", currentNavigation, nestedForm) { }

		public Pwcom_ViewModel(Models.Pwcom row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPWCOM", row, currentNavigation, nestedForm) { }

		public Pwcom_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pwcom", id);
			Model = Models.Pwcom.Find(id, "FPWCOM", fieldsToQuery: fieldsToLoad);
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
			Models.Pwcom model = new Models.Pwcom() { Identifier = "FPWCOM" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Pwcom model)
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

		public static StatusMessage DeleteConditions(Models.Pwcom model)
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

		public static StatusMessage ViewConditions(Models.Pwcom model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Pwcom model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pwcom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pwcom) to ViewModel (Pwcom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValFoto = ViewModelConversion.ToImage(m.ValFoto);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValCodpwcom = ViewModelConversion.ToString(m.ValCodpwcom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pwcom) to ViewModel (Pwcom) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pwcom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pwcom) to Model (Pwcom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodpwcom = ViewModelConversion.ToString(ValCodpwcom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pwcom) to Model (Pwcom) - Error during mapping");
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
				Model = Models.Pwcom.Find(Navigation.GetStrValue("pwcom"), "FPWCOM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pwcom() { Identifier = "FPWCOM" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("pwcom");
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

			Model.Identifier = "FPWCOM";
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

		protected override void LoadDocumentsProperties(Models.Pwcom row)
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
				Model = Models.Pwcom.Find(Navigation.GetStrValue("pwcom"), "FPWCOM");
				if (Model == null)
				{
					Model = new Models.Pwcom() { Identifier = "FPWCOM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pwcom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Pwcom___psw__nome____(qs, lazyLoad);
			Load_Pwcom___pess1name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PWCOM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PWCOM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PWCOM]/
		public override void Save()
		{

			try { Model = Models.Pwcom.Find(Navigation.GetStrValue("pwcom"), "FPWCOM"); }
			finally { if (Model == null) Model = new Models.Pwcom() { Identifier = "FPWCOM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PWCOM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pwcom.Find(Navigation.GetStrValue("pwcom"), "FPWCOM"); }
			finally { if (Model == null) Model = new Models.Pwcom() { Identifier = "FPWCOM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PWCOM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PWCOM]/
		public override void Destroy(string id)
		{
			Model = Models.Pwcom.Find(id, "FPWCOM");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TablePswNome -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pwcom___psw__nome____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pwcom___psw__nome____DoLoad = true;
            CriteriaSet pwcom___psw__nome____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("psw", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pwcom___psw__nome____Conds.Equal(CSGenioApsw.FldCodpsw, Navigation.GetValue("psw"));
                    this.ValCodpsw = Navigation.GetStrValue("psw");
                }
            }



            TablePswNome = new TableDBEdit<Models.Psw>();
            TablePswNome.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
                    this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
                FillDependant_PwcomTablePswNome(lazyLoad);
                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
                return;
            }


            if (pwcom___psw__nome____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
                    TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
                else
                    TablePswNome.TableFilters = false;

                query = qs["qTablePswNome"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
                }
                pwcom___psw__nome____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWCOM_PSWNOME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
                    pwcom___psw__nome____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApsw.FldZzstate, 0)
                        .Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
                else
                    pwcom___psw__nome____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pwcom___psw__nome____Conds = Psw.AddEPH<CSGenioApsw>(ref UserContext.Current.User, pwcom___psw__nome____Conds, "LED_PWCOM___PSW__NOME____");

                FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
                ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(false, pwcom___psw__nome____Conds, fields, offset, numberItems, sorts, "LED_PWCOM___PSW__NOME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePswNome.Query = query;
                TablePswNome.Elements = listing.RowsForViewModel<GenioMVC.Models.Psw>((r) => new GenioMVC.Models.Psw(r, true, _fieldsToSerialize_PWCOM___PSW__NOME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
                FillDependant_PwcomTablePswNome();

                //Check if foreignkey comes from history
                TablePswNome.FilledByHistory = Navigation.CheckFilledByHistory("psw");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePswNome (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Psw</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PwcomTablePswNome(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "psw.codpsw", "psw.nome" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome };
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
            CSGenioApsw tempArea = new CSGenioApsw(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));
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
        /// Fill Dependant fields values -> TablePswNome (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PwcomTablePswNome(bool lazyLoad = false)
        {
            var row = GetDependant_PwcomTablePswNome(this.ValCodpsw, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
                TablePswNome.Value = ViewModelConversion.ToString(row["psw.nome"]);
                if (GlobalFunctions.emptyG(this.ValCodpsw) == 1)
                {
                    this.ValCodpsw = "";
                    TablePswNome.Value = "";
                    Navigation.ClearValue("psw");
                }
                else if (lazyLoad)
                {
                    TablePswNome.SetPagination(1, 0, false, false, 1);
                    TablePswNome.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpsw),
                            Text = Convert.ToString(TablePswNome.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpsw);
                }
                TablePswNome.Selected = this.ValCodpsw;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PWCOM___PSW__NOME____ = { "Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome" };

        /// <summary>
        /// TablePess1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Pwcom___pess1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool pwcom___pess1name____DoLoad = true;
            CriteriaSet pwcom___pess1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pwcom___pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, Navigation.GetValue("pess1"));
                    this.ValCodpess1 = Navigation.GetStrValue("pess1");
                }
            }



            TablePess1Name = new TableDBEdit<Models.Pess1>();
            TablePess1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
                    this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
                FillDependant_PwcomTablePess1Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
                return;
            }


            if (pwcom___pess1name____DoLoad)
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
                pwcom___pess1name____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWCOM_PESS1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
                    pwcom___pess1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess1.FldZzstate, 0)
                        .Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
                else
                    pwcom___pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pwcom___pess1name____Conds = Pess1.AddEPH<CSGenioApess1>(ref UserContext.Current.User, pwcom___pess1name____Conds, "LED_PWCOM___PESS1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
                ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, pwcom___pess1name____Conds, fields, offset, numberItems, sorts, "LED_PWCOM___PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess1Name.Query = query;
                TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(r, true, _fieldsToSerialize_PWCOM___PESS1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
                FillDependant_PwcomTablePess1Name();

                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PwcomTablePess1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess1.codpesso", "pess1.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName };
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
        public void FillDependant_PwcomTablePess1Name(bool lazyLoad = false)
        {
            var row = GetDependant_PwcomTablePess1Name(this.ValCodpess1, Navigation);
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


        private readonly string[] _fieldsToSerialize_PWCOM___PESS1NAME____ = { "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PWCOM]/
		#endregion
	}
}
