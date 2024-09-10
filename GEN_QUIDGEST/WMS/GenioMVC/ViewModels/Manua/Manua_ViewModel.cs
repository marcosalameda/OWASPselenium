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

namespace GenioMVC.ViewModels.Manua
{
	public class Manua_ViewModel : FormViewModel<Models.Manua>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Kind of equipment" Tipo:"C"</summary>
		[Display(Name = "KIND_OF_EQUIPMENT22928", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Kinde>  TableKindeDesignat { get; set; }

		/// <summary>Campo : "Manual name" Tipo:"C"</summary>
		[Display(Name = "MANUAL_NAME60077", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Digital document" Tipo:"IB"</summary>
		[Display(Name = "DIGITAL_DOCUMENT59580", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValDigdocum", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValDigdocum { get; set; }
		public string ValDigdocumfk { get; set; }
		public DocumsProperties_ViewModel ValDigdocumPropertiesVM { get; set; }

		/// <summary>Campo : "Notes" Tipo:"MO"</summary>
		[Display(Name = "NOTES05274", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValNotes { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "KIND_OF_EQUIPMENT22928", ResourceType = typeof(Resources.Resources))]
		public string ValCodkinde { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodmanua { get; set; }

		public Manua_ViewModel() : base("FMANUA") { }

		public Manua_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FMANUA", currentNavigation, nestedForm) { }

		public Manua_ViewModel(Models.Manua row, NavigationContext currentNavigation, bool nestedForm = false) : base("FMANUA", row, currentNavigation, nestedForm) { }

		public Manua_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("manua", id);
			Model = Models.Manua.Find(id, "FMANUA", fieldsToQuery: fieldsToLoad);
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
			Models.Manua model = new Models.Manua() { Identifier = "FMANUA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Manua model)
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

		public static StatusMessage DeleteConditions(Models.Manua model)
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

		public static StatusMessage ViewConditions(Models.Manua model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Manua model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Manua m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Manua) to ViewModel (Manua) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValDigdocum = ViewModelConversion.ToString(m.ValDigdocum);
				ValDigdocumfk = ViewModelConversion.ToString(m.ValDigdocumfk);
 				ValNotes = ViewModelConversion.ToString(m.ValNotes);
 				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
 				ValCodmanua = ViewModelConversion.ToString(m.ValCodmanua);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Manua) to ViewModel (Manua) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Manua m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Manua) to Model (Manua) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDigdocum = ViewModelConversion.ToString(ValDigdocum);
				m.ValDigdocumfk = ViewModelConversion.ToString(ValDigdocumfk);

				m.ValNotes = ViewModelConversion.ToString(ValNotes);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
				m.ValCodmanua = ViewModelConversion.ToString(ValCodmanua);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Manua) to Model (Manua) - Error during mapping");
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
				Model = Models.Manua.Find(Navigation.GetStrValue("manua"), "FMANUA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Manua() { Identifier = "FMANUA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("manua");
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

			Model.Identifier = "FMANUA";
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

		protected override void LoadDocumentsProperties(Models.Manua row)
		{
			try
			{
				ValDigdocumPropertiesVM = row.GetInfoDoc("ValDigdocum");
			}
			catch (Exception)
			{
				ValDigdocumPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
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
				Model = Models.Manua.Find(Navigation.GetStrValue("manua"), "FMANUA");
				if (Model == null)
				{
					Model = new Models.Manua() { Identifier = "FMANUA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("manua");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Manua___kindedesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL MANUA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW MANUA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE MANUA]/
		public override void Save()
		{

			try { Model = Models.Manua.Find(Navigation.GetStrValue("manua"), "FMANUA"); }
			finally { if (Model == null) Model = new Models.Manua() { Identifier = "FMANUA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY MANUA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Manua.Find(Navigation.GetStrValue("manua"), "FMANUA"); }
			finally { if (Model == null) Model = new Models.Manua() { Identifier = "FMANUA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE MANUA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY MANUA]/
		public override void Destroy(string id)
		{
			Model = Models.Manua.Find(id, "FMANUA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableKindeDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Manua___kindedesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool manua___kindedesignatDoLoad = true;
            CriteriaSet manua___kindedesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("kinde", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    manua___kindedesignatConds.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetValue("kinde"));
                    this.ValCodkinde = Navigation.GetStrValue("kinde");
                }
            }



            TableKindeDesignat = new TableDBEdit<Models.Kinde>();
            TableKindeDesignat.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
                    this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}
                FillDependant_ManuaTableKindeDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
                return;
            }


            if (manua___kindedesignatDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableKindeDesignat, "sTableKindeDesignat", "dTableKindeDesignat", qs, "kinde");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAkinde.FldDesignat), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableKindeDesignat_tableFilters"]))
                    TableKindeDesignat.TableFilters = bool.Parse(qs["TableKindeDesignat_tableFilters"]);
                else
                    TableKindeDesignat.TableFilters = false;

                query = qs["qTableKindeDesignat"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAkinde.FldDesignat, query + "%");
                }
                manua___kindedesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableKindeDesignat"] != null ? qs["pTableKindeDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAkinde.FldZzstate };

// USE /[MANUAL GQT OVERRQ MANUA_KINDEDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("kinde", FormMode.New) || Navigation.checkFormMode("kinde", FormMode.Duplicate))
                    manua___kindedesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAkinde.FldZzstate, 0)
                        .Equal(CSGenioAkinde.FldCodkinde, Navigation.GetStrValue("kinde")));
                else
                    manua___kindedesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAkinde.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //manua___kindedesignatConds = Kinde.AddEPH<CSGenioAkinde>(ref UserContext.Current.User, manua___kindedesignatConds, "LED_MANUA___KINDEDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("kinde", "designat");
                ListingMVC<CSGenioAkinde> listing = Models.ModelBase.Where<CSGenioAkinde>(false, manua___kindedesignatConds, fields, offset, numberItems, sorts, "LED_MANUA___KINDEDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableKindeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableKindeDesignat.Query = query;
                TableKindeDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Kinde>((r) => new GenioMVC.Models.Kinde(r, true, _fieldsToSerialize_MANUA___KINDEDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}

				TableKindeDesignat.List = new SelectList(TableKindeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodkinde,  x => x.ValCodkinde == this.ValCodkinde), "Value", "Text", this.ValCodkinde);
                FillDependant_ManuaTableKindeDesignat();

                //Check if foreignkey comes from history
                TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableKindeDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Kinde</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ManuaTableKindeDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "kinde.codkinde", "kinde.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat };
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
            CSGenioAkinde tempArea = new CSGenioAkinde(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAkinde.FldCodkinde, PKey));
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
        /// Fill Dependant fields values -> TableKindeDesignat (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ManuaTableKindeDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_ManuaTableKindeDesignat(this.ValCodkinde, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodkinde = ViewModelConversion.ToString(row["kinde.codkinde"]);
                TableKindeDesignat.Value = ViewModelConversion.ToString(row["kinde.designat"]);
                if (GlobalFunctions.emptyG(this.ValCodkinde) == 1)
                {
                    this.ValCodkinde = "";
                    TableKindeDesignat.Value = "";
                    Navigation.ClearValue("kinde");
                }
                else if (lazyLoad)
                {
                    TableKindeDesignat.SetPagination(1, 0, false, false, 1);
                    TableKindeDesignat.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodkinde),
                            Text = Convert.ToString(TableKindeDesignat.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodkinde);
                }
                TableKindeDesignat.Selected = this.ValCodkinde;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableKindeDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_MANUA___KINDEDESIGNAT = { "Kinde", "Kinde.ValCodkinde", "Kinde.ValZzstate", "Kinde.ValDesignat" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM MANUA]/
		#endregion
	}
}
