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

namespace GenioMVC.ViewModels.Assma
{
	public class Assma_ViewModel : FormViewModel<Models.Assma>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Identification name" Tipo:"C"</summary>
		[Display(Name = "IDENTIFICATION_NAME16317", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Asset>  TableAssetName { get; set; }

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

		[Display(Name = "IDENTIFICATION_NAME16317", ResourceType = typeof(Resources.Resources))]
		public string ValCodasset { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodassma { get; set; }

		public Assma_ViewModel() : base("FASSMA") { }

		public Assma_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FASSMA", currentNavigation, nestedForm) { }

		public Assma_ViewModel(Models.Assma row, NavigationContext currentNavigation, bool nestedForm = false) : base("FASSMA", row, currentNavigation, nestedForm) { }

		public Assma_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("assma", id);
			Model = Models.Assma.Find(id, "FASSMA", fieldsToQuery: fieldsToLoad);
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
			Models.Assma model = new Models.Assma() { Identifier = "FASSMA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Assma model)
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

		public static StatusMessage DeleteConditions(Models.Assma model)
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

		public static StatusMessage ViewConditions(Models.Assma model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Assma model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Assma m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Assma) to ViewModel (Assma) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValDigdocum = ViewModelConversion.ToString(m.ValDigdocum);
				ValDigdocumfk = ViewModelConversion.ToString(m.ValDigdocumfk);
 				ValNotes = ViewModelConversion.ToString(m.ValNotes);
 				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
 				ValCodassma = ViewModelConversion.ToString(m.ValCodassma);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Assma) to ViewModel (Assma) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Assma m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Assma) to Model (Assma) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDigdocum = ViewModelConversion.ToString(ValDigdocum);
				m.ValDigdocumfk = ViewModelConversion.ToString(ValDigdocumfk);

				m.ValNotes = ViewModelConversion.ToString(ValNotes);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodassma = ViewModelConversion.ToString(ValCodassma);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Assma) to Model (Assma) - Error during mapping");
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
				Model = Models.Assma.Find(Navigation.GetStrValue("assma"), "FASSMA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Assma() { Identifier = "FASSMA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("assma");
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

			Model.Identifier = "FASSMA";
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

		protected override void LoadDocumentsProperties(Models.Assma row)
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
				Model = Models.Assma.Find(Navigation.GetStrValue("assma"), "FASSMA");
				if (Model == null)
				{
					Model = new Models.Assma() { Identifier = "FASSMA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("assma");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Assma___assetname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ASSMA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ASSMA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ASSMA]/
		public override void Save()
		{

			try { Model = Models.Assma.Find(Navigation.GetStrValue("assma"), "FASSMA"); }
			finally { if (Model == null) Model = new Models.Assma() { Identifier = "FASSMA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ASSMA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Assma.Find(Navigation.GetStrValue("assma"), "FASSMA"); }
			finally { if (Model == null) Model = new Models.Assma() { Identifier = "FASSMA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ASSMA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ASSMA]/
		public override void Destroy(string id)
		{
			Model = Models.Assma.Find(id, "FASSMA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableAssetName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Assma___assetname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool assma___assetname____DoLoad = true;
            CriteriaSet assma___assetname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("asset", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    assma___assetname____Conds.Equal(CSGenioAasset.FldCodasset, Navigation.GetValue("asset"));
                    this.ValCodasset = Navigation.GetStrValue("asset");
                }
            }



            TableAssetName = new TableDBEdit<Models.Asset>();
            TableAssetName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
                    this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}
                FillDependant_AssmaTableAssetName(lazyLoad);
                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
                return;
            }


            if (assma___assetname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableAssetName, "sTableAssetName", "dTableAssetName", qs, "asset");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableAssetName_tableFilters"]))
                    TableAssetName.TableFilters = bool.Parse(qs["TableAssetName_tableFilters"]);
                else
                    TableAssetName.TableFilters = false;

                query = qs["qTableAssetName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAasset.FldName, query + "%");
                }
                assma___assetname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSMA_ASSETNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
                    assma___assetname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAasset.FldZzstate, 0)
                        .Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
                else
                    assma___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //assma___assetname____Conds = Asset.AddEPH<CSGenioAasset>(ref UserContext.Current.User, assma___assetname____Conds, "LED_ASSMA___ASSETNAME____");

                FieldRef firstVisibleColumn = new FieldRef("asset", "name");
                ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(false, assma___assetname____Conds, fields, offset, numberItems, sorts, "LED_ASSMA___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAssetName.Query = query;
                TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(r, true, _fieldsToSerialize_ASSMA___ASSETNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
                FillDependant_AssmaTableAssetName();

                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAssetName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Asset</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AssmaTableAssetName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "asset.codasset", "asset.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName };
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
            CSGenioAasset tempArea = new CSGenioAasset(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAasset.FldCodasset, PKey));
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
        /// Fill Dependant fields values -> TableAssetName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AssmaTableAssetName(bool lazyLoad = false)
        {
            var row = GetDependant_AssmaTableAssetName(this.ValCodasset, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodasset = ViewModelConversion.ToString(row["asset.codasset"]);
                TableAssetName.Value = ViewModelConversion.ToString(row["asset.name"]);
                if (GlobalFunctions.emptyG(this.ValCodasset) == 1)
                {
                    this.ValCodasset = "";
                    TableAssetName.Value = "";
                    Navigation.ClearValue("asset");
                }
                else if (lazyLoad)
                {
                    TableAssetName.SetPagination(1, 0, false, false, 1);
                    TableAssetName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodasset),
                            Text = Convert.ToString(TableAssetName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodasset);
                }
                TableAssetName.Selected = this.ValCodasset;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAssetName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ASSMA___ASSETNAME____ = { "Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSMA]/
		#endregion
	}
}
