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

namespace GenioMVC.ViewModels.Asspa
{
	public class Asspa_ViewModel : FormViewModel<Models.Asspa>
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

		/// <summary>Campo : "Data type" Tipo:"AC"</summary>
		[Display(Name = "DATA_TYPE47159", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Datatype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDatatype { get; set; }
		[JsonIgnore]
		public SelectList List_ValDatatype { get; set; }

		/// <summary>Campo : "Decimal places" Tipo:"N"</summary>
		[Display(Name = "DECIMAL_PLACES62575", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDecimalplaces { get; set; }

		/// <summary>Campo : "Parameter" Tipo:"C"</summary>
		[Display(Name = "PARAMETER41976", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Param>  TableParamParamete { get; set; }

		/// <summary>Campo : "Text" Tipo:"C"</summary>
		[Display(Name = "TEXT04938", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValText { get; set; }

		/// <summary>Campo : "Quantity" Tipo:"N"</summary>
		[Display(Name = "QUANTITY06415", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N4}" )]
		[NumericAttribute(4)]
		public decimal? ValQuantity { get; set; }

		/// <summary>Campo : "Date" Tipo:"D"</summary>
		[Display(Name = "DATE18475", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDate { get; set; }

		/// <summary>Campo : "To show" Tipo:"C"</summary>
		[Display(Name = "TO_SHOW13268", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValToshow { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "IDENTIFICATION_NAME16317", ResourceType = typeof(Resources.Resources))]
		public string ValCodasset { get; set; }

		[Display(Name = "PARAMETER41976", ResourceType = typeof(Resources.Resources))]
		public string ValCodparam { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodasspa { get; set; }

		public Asspa_ViewModel() : base("FASSPA") { }

		public Asspa_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FASSPA", currentNavigation, nestedForm) { }

		public Asspa_ViewModel(Models.Asspa row, NavigationContext currentNavigation, bool nestedForm = false) : base("FASSPA", row, currentNavigation, nestedForm) { }

		public Asspa_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("asspa", id);
			Model = Models.Asspa.Find(id, "FASSPA", fieldsToQuery: fieldsToLoad);
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
			Models.Asspa model = new Models.Asspa() { Identifier = "FASSPA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Asspa model)
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

		public static StatusMessage DeleteConditions(Models.Asspa model)
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

		public static StatusMessage ViewConditions(Models.Asspa model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Asspa model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Asspa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Asspa) to ViewModel (Asspa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDatatype = ViewModelConversion.ToString(m.ValDatatype);
 				ValDecimalplaces = ViewModelConversion.ToNumeric(m.ValDecimalplaces);
 				ValText = ViewModelConversion.ToString(m.ValText);
 				ValQuantity = ViewModelConversion.ToNumeric(m.ValQuantity);
 				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
 				ValToshow = ViewModelConversion.ToString(m.ValToshow);
 				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
 				ValCodparam = ViewModelConversion.ToString(m.ValCodparam);
 				ValCodasspa = ViewModelConversion.ToString(m.ValCodasspa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Asspa) to ViewModel (Asspa) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Asspa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Asspa) to Model (Asspa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDatatype = ViewModelConversion.ToString(ValDatatype);
				m.ValDecimalplaces = ViewModelConversion.ToNumeric(ValDecimalplaces);
				m.ValText = ViewModelConversion.ToString(ValText);
				m.ValQuantity = ViewModelConversion.ToNumeric(ValQuantity);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValToshow = ViewModelConversion.ToString(ValToshow);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodparam = ViewModelConversion.ToString(ValCodparam);
				m.ValCodasspa = ViewModelConversion.ToString(ValCodasspa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Asspa) to Model (Asspa) - Error during mapping");
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
				Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), "FASSPA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Asspa() { Identifier = "FASSPA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("asspa");
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

			Model.Identifier = "FASSPA";
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

		protected override void LoadDocumentsProperties(Models.Asspa row)
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
				Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), "FASSPA");
				if (Model == null)
				{
					Model = new Models.Asspa() { Identifier = "FASSPA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("asspa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Asspa___assetname____(qs, lazyLoad);
			Load_Asspa___paramparamete(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ASSPA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ASSPA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ASSPA]/
		public override void Save()
		{

			try { Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), "FASSPA"); }
			finally { if (Model == null) Model = new Models.Asspa() { Identifier = "FASSPA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ASSPA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Asspa.Find(Navigation.GetStrValue("asspa"), "FASSPA"); }
			finally { if (Model == null) Model = new Models.Asspa() { Identifier = "FASSPA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ASSPA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ASSPA]/
		public override void Destroy(string id)
		{
			Model = Models.Asspa.Find(id, "FASSPA");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValDatatype = new SelectList(
				ArrayDatatype.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValDatatype);
		}


        /// <summary>
        /// TableAssetName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Asspa___assetname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool asspa___assetname____DoLoad = true;
            CriteriaSet asspa___assetname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("asset", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    asspa___assetname____Conds.Equal(CSGenioAasset.FldCodasset, Navigation.GetValue("asset"));
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
                FillDependant_AsspaTableAssetName(lazyLoad);
                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
                return;
            }


            if (asspa___assetname____DoLoad)
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
                asspa___assetname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSPA_ASSETNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
                    asspa___assetname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAasset.FldZzstate, 0)
                        .Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
                else
                    asspa___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //asspa___assetname____Conds = Asset.AddEPH<CSGenioAasset>(ref UserContext.Current.User, asspa___assetname____Conds, "LED_ASSPA___ASSETNAME____");

                FieldRef firstVisibleColumn = new FieldRef("asset", "name");
                ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(false, asspa___assetname____Conds, fields, offset, numberItems, sorts, "LED_ASSPA___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableAssetName.Query = query;
                TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(r, true, _fieldsToSerialize_ASSPA___ASSETNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
                FillDependant_AsspaTableAssetName();

                //Check if foreignkey comes from history
                TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableAssetName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Asset</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AsspaTableAssetName(string PKey, NavigationContext Navigation)
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
        public void FillDependant_AsspaTableAssetName(bool lazyLoad = false)
        {
            var row = GetDependant_AsspaTableAssetName(this.ValCodasset, Navigation);
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


        private readonly string[] _fieldsToSerialize_ASSPA___ASSETNAME____ = { "Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName" };

        /// <summary>
        /// TableParamParamete -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Asspa___paramparamete(NameValueCollection qs, bool lazyLoad = false)
        {
            bool asspa___paramparameteDoLoad = true;
            CriteriaSet asspa___paramparameteConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("param", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    asspa___paramparameteConds.Equal(CSGenioAparam.FldCodparam, Navigation.GetValue("param"));
                    this.ValCodparam = Navigation.GetStrValue("param");
                }
            }



            TableParamParamete = new TableDBEdit<Models.Param>();
            TableParamParamete.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_param") != null)
				{
                    this.ValCodparam = Navigation.GetStrValue("RETURN_param");
					Navigation.CurrentLevel.SetEntry("RETURN_param", null);
				}
                FillDependant_AsspaTableParamParamete(lazyLoad);
                //Check if foreignkey comes from history
                TableParamParamete.FilledByHistory = Navigation.CheckFilledByHistory("param");
                return;
            }


            if (asspa___paramparameteDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableParamParamete, "sTableParamParamete", "dTableParamParamete", qs, "param");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAparam.FldParameter), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableParamParamete_tableFilters"]))
                    TableParamParamete.TableFilters = bool.Parse(qs["TableParamParamete_tableFilters"]);
                else
                    TableParamParamete.TableFilters = false;

                query = qs["qTableParamParamete"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAparam.FldParameter, query + "%");
                }
                asspa___paramparameteConds.SubSet(search_filters);


                string tryParsePage = qs["pTableParamParamete"] != null ? qs["pTableParamParamete"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter, CSGenioAparam.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSPA_PARAMPARAMETE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("param", FormMode.New) || Navigation.checkFormMode("param", FormMode.Duplicate))
                    asspa___paramparameteConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAparam.FldZzstate, 0)
                        .Equal(CSGenioAparam.FldCodparam, Navigation.GetStrValue("param")));
                else
                    asspa___paramparameteConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAparam.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //asspa___paramparameteConds = Param.AddEPH<CSGenioAparam>(ref UserContext.Current.User, asspa___paramparameteConds, "LED_ASSPA___PARAMPARAMETE");

                FieldRef firstVisibleColumn = new FieldRef("param", "parameter");
                ListingMVC<CSGenioAparam> listing = Models.ModelBase.Where<CSGenioAparam>(false, asspa___paramparameteConds, fields, offset, numberItems, sorts, "LED_ASSPA___PARAMPARAMETE", true, false, firstVisibleColumn: firstVisibleColumn);

                TableParamParamete.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableParamParamete.Query = query;
                TableParamParamete.Elements = listing.RowsForViewModel<GenioMVC.Models.Param>((r) => new GenioMVC.Models.Param(r, true, _fieldsToSerialize_ASSPA___PARAMPARAMETE));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_param") != null)
				{
					this.ValCodparam = Navigation.GetStrValue("RETURN_param");
					Navigation.CurrentLevel.SetEntry("RETURN_param", null);
				}

				TableParamParamete.List = new SelectList(TableParamParamete.Elements.ToSelectList(x => x.ValParameter, x => x.ValCodparam,  x => x.ValCodparam == this.ValCodparam), "Value", "Text", this.ValCodparam);
                FillDependant_AsspaTableParamParamete();

                //Check if foreignkey comes from history
                TableParamParamete.FilledByHistory = Navigation.CheckFilledByHistory("param");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableParamParamete (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Param</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_AsspaTableParamParamete(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "param.codparam", "param.parameter" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter };
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
            CSGenioAparam tempArea = new CSGenioAparam(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAparam.FldCodparam, PKey));
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
        /// Fill Dependant fields values -> TableParamParamete (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_AsspaTableParamParamete(bool lazyLoad = false)
        {
            var row = GetDependant_AsspaTableParamParamete(this.ValCodparam, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodparam = ViewModelConversion.ToString(row["param.codparam"]);
                TableParamParamete.Value = ViewModelConversion.ToString(row["param.parameter"]);
                if (GlobalFunctions.emptyG(this.ValCodparam) == 1)
                {
                    this.ValCodparam = "";
                    TableParamParamete.Value = "";
                    Navigation.ClearValue("param");
                }
                else if (lazyLoad)
                {
                    TableParamParamete.SetPagination(1, 0, false, false, 1);
                    TableParamParamete.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodparam),
                            Text = Convert.ToString(TableParamParamete.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodparam);
                }
                TableParamParamete.Selected = this.ValCodparam;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableParamParamete): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ASSPA___PARAMPARAMETE = { "Param", "Param.ValCodparam", "Param.ValZzstate", "Param.ValParameter" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSPA]/
		#endregion
	}
}
