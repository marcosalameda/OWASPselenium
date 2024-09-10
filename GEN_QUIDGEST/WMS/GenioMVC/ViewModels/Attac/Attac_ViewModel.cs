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

namespace GenioMVC.ViewModels.Attac
{
	public class Attac_ViewModel : FormViewModel<Models.Attac>
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

		/// <summary>Campo : "Attached" Tipo:"DT"</summary>
		[Display(Name = "ATTACHED26247", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValAttached { get; set; }

		/// <summary>Campo : "Note" Tipo:"MO"</summary>
		[Display(Name = "NOTE54557", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValNote { get; set; }

		/// <summary>Campo : "Document" Tipo:"IB"</summary>
		[Display(Name = "DOCUMENT00695", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValDocument", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValDocument { get; set; }
		public string ValDocumentfk { get; set; }
		public DocumsProperties_ViewModel ValDocumentPropertiesVM { get; set; }


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

		public string ValCodattac { get; set; }

		public Attac_ViewModel() : base("FATTAC") { }

		public Attac_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FATTAC", currentNavigation, nestedForm) { }

		public Attac_ViewModel(Models.Attac row, NavigationContext currentNavigation, bool nestedForm = false) : base("FATTAC", row, currentNavigation, nestedForm) { }

		public Attac_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("attac", id);
			Model = Models.Attac.Find(id, "FATTAC", fieldsToQuery: fieldsToLoad);
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
			Models.Attac model = new Models.Attac() { Identifier = "FATTAC" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Attac model)
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

		public static StatusMessage DeleteConditions(Models.Attac model)
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

		public static StatusMessage ViewConditions(Models.Attac model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Attac model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Attac m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Attac) to ViewModel (Attac) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValAttached = ViewModelConversion.ToDateTime(m.ValAttached);
 				ValNote = ViewModelConversion.ToString(m.ValNote);
 				ValDocument = ViewModelConversion.ToString(m.ValDocument);
				ValDocumentfk = ViewModelConversion.ToString(m.ValDocumentfk);
 				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
 				ValCodattac = ViewModelConversion.ToString(m.ValCodattac);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Attac) to ViewModel (Attac) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Attac m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Attac) to Model (Attac) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValAttached = ViewModelConversion.ToDateTime(ValAttached);
				m.ValNote = ViewModelConversion.ToString(ValNote);
				m.ValDocument = ViewModelConversion.ToString(ValDocument);
				m.ValDocumentfk = ViewModelConversion.ToString(ValDocumentfk);

				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodattac = ViewModelConversion.ToString(ValCodattac);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Attac) to Model (Attac) - Error during mapping");
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
				Model = Models.Attac.Find(Navigation.GetStrValue("attac"), "FATTAC");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Attac() { Identifier = "FATTAC" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("attac");
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

			Model.Identifier = "FATTAC";
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

		protected override void LoadDocumentsProperties(Models.Attac row)
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
				Model = Models.Attac.Find(Navigation.GetStrValue("attac"), "FATTAC");
				if (Model == null)
				{
					Model = new Models.Attac() { Identifier = "FATTAC" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("attac");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Attac___assetname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ATTAC]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ATTAC]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ATTAC]/
		public override void Save()
		{

			try { Model = Models.Attac.Find(Navigation.GetStrValue("attac"), "FATTAC"); }
			finally { if (Model == null) Model = new Models.Attac() { Identifier = "FATTAC" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ATTAC]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Attac.Find(Navigation.GetStrValue("attac"), "FATTAC"); }
			finally { if (Model == null) Model = new Models.Attac() { Identifier = "FATTAC" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ATTAC]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ATTAC]/
		public override void Destroy(string id)
		{
			Model = Models.Attac.Find(id, "FATTAC");
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
        public void Load_Attac___assetname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool attac___assetname____DoLoad = true;
            CriteriaSet attac___assetname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("asset", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    attac___assetname____Conds.Equal(CSGenioAasset.FldCodasset, Navigation.GetValue("asset"));
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
                FillDependant_AttacTableAssetName(lazyLoad);
                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
                return;
            }


            if (attac___assetname____DoLoad)
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
                attac___assetname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ATTAC_ASSETNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
                    attac___assetname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAasset.FldZzstate, 0)
                        .Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
                else
                    attac___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //attac___assetname____Conds = Asset.AddEPH<CSGenioAasset>(ref UserContext.Current.User, attac___assetname____Conds, "LED_ATTAC___ASSETNAME____");

                FieldRef firstVisibleColumn = new FieldRef("asset", "name");
                ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(false, attac___assetname____Conds, fields, offset, numberItems, sorts, "LED_ATTAC___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAssetName.Query = query;
                TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(r, true, _fieldsToSerialize_ATTAC___ASSETNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
                FillDependant_AttacTableAssetName();

                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAssetName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Asset</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AttacTableAssetName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_AttacTableAssetName(bool lazyLoad = false)
        {
            var row = GetDependant_AttacTableAssetName(this.ValCodasset, Navigation);
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


        private readonly string[] _fieldsToSerialize_ATTAC___ASSETNAME____ = { "Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ATTAC]/
		#endregion
	}
}
