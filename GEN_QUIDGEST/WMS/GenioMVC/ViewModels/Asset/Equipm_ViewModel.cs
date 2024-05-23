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

namespace GenioMVC.ViewModels.Asset
{
	public class Equipm_ViewModel : FormViewModel<Models.Asset>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Identification name" Tipo:"C"</summary>
		[Display(Name = "IDENTIFICATION_NAME16317", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Asset type" Tipo:"AC"</summary>
		[Display(Name = "ASSET_TYPE02033", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Assettyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAssettyp { get; set; }
		[JsonIgnore]
		public SelectList List_ValAssettyp { get; set; }

		/// <summary>Campo : "Asset number" Tipo:"N"</summary>
		[Display(Name = "ASSET_NUMBER52372", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValAssetnum { get; set; }

		/// <summary>Campo : "Identifier type" Tipo:"AC"</summary>
		[Display(Name = "IDENTIFIER_TYPE60623", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Identtyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValIdenttyp { get; set; }
		[JsonIgnore]
		public SelectList List_ValIdenttyp { get; set; }

		/// <summary>Campo : "GRAI – Global Returnable Asset Identifier" Tipo:"C"</summary>
		[Display(Name = "GRAI___GLOBAL_RETURN06821", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGrai { get; set; }

		/// <summary>Campo : "GIAI – Global Individual Asset Identifier" Tipo:"C"</summary>
		[Display(Name = "GIAI___GLOBAL_INDIVI63214", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGiai { get; set; }

		/// <summary>Campo : "Manufacturer" Tipo:"C"</summary>
		[Display(Name = "MANUFACTURER50759", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Manuf>  TableManufName { get; set; }

		/// <summary>Campo : "Kind of equipment" Tipo:"C"</summary>
		[Display(Name = "KIND_OF_EQUIPMENT22928", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Kinde>  TableKindeDesignat { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 400, 300, false, true)]
		public byte[] ValPhoto { get; set; }

		/// <summary>Campo : "Attachments" Tipo:"DP"</summary>
		[Display(Name = "ATTACHMENTS19612", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Attac> ValAttachme { get; set; }

		/// <summary>Campo : "Documents" Tipo:"DP"</summary>
		[Display(Name = "DOCUMENTS14470", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Assma> ValDocument { get; set; }



		/// <summary>Campo : "Parameters" Tipo:"DP"</summary>
		[Display(Name = "PARAMETERS28294", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Asspa> ValParamete { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "KIND_OF_EQUIPMENT22928", ResourceType = typeof(Resources.Resources))]
		public string ValCodkinde { get; set; }

		[Display(Name = "MANUFACTURER50759", ResourceType = typeof(Resources.Resources))]
		public string ValCodmanuf { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodasset { get; set; }

		public Equipm_ViewModel() : base("FEQUIPM") { }

		public Equipm_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIPM", currentNavigation, nestedForm) { }

		public Equipm_ViewModel(Models.Asset row, NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIPM", row, currentNavigation, nestedForm) { }

		public Equipm_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("asset", id);
			Model = Models.Asset.Find(id, "FEQUIPM", fieldsToQuery: fieldsToLoad);
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
			Models.Asset model = new Models.Asset() { Identifier = "FEQUIPM" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Asset model)
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

		public static StatusMessage DeleteConditions(Models.Asset model)
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

		public static StatusMessage ViewConditions(Models.Asset model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Asset model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Equipm) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValAssettyp = ViewModelConversion.ToString(m.ValAssettyp);
 				ValAssetnum = ViewModelConversion.ToNumeric(m.ValAssetnum);
 				ValIdenttyp = ViewModelConversion.ToString(m.ValIdenttyp);
 				ValGrai = ViewModelConversion.ToString(m.ValGrai);
 				ValGiai = ViewModelConversion.ToString(m.ValGiai);
 				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
 				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
 				ValCodmanuf = ViewModelConversion.ToString(m.ValCodmanuf);
 				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Equipm) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equipm) to Model (Asset) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValAssettyp = ViewModelConversion.ToString(ValAssettyp);
				m.ValAssetnum = ViewModelConversion.ToNumeric(ValAssetnum);
				m.ValIdenttyp = ViewModelConversion.ToString(ValIdenttyp);
				m.ValGrai = ViewModelConversion.ToString(ValGrai);
				m.ValGiai = ViewModelConversion.ToString(ValGiai);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
				m.ValCodmanuf = ViewModelConversion.ToString(ValCodmanuf);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equipm) to Model (Asset) - Error during mapping");
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
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), "FEQUIPM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Asset() { Identifier = "FEQUIPM" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("asset");
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

			Model.Identifier = "FEQUIPM";
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

		protected override void LoadDocumentsProperties(Models.Asset row)
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
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), "FEQUIPM");
				if (Model == null)
				{
					Model = new Models.Asset() { Identifier = "FEQUIPM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("asset");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Equipm__manufname____(qs, lazyLoad);
			Load_Equipm__kindedesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIPM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIPM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIPM]/
		public override void Save()
		{

			try { Model = Models.Asset.Find(Navigation.GetStrValue("asset"), "FEQUIPM"); }
			finally { if (Model == null) Model = new Models.Asset() { Identifier = "FEQUIPM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIPM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Asset.Find(Navigation.GetStrValue("asset"), "FEQUIPM"); }
			finally { if (Model == null) Model = new Models.Asset() { Identifier = "FEQUIPM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIPM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIPM]/
		public override void Destroy(string id)
		{
			Model = Models.Asset.Find(id, "FEQUIPM");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValAssettyp = new SelectList(
				ArrayAssettyp.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValAssettyp);
			this.List_ValIdenttyp = new SelectList(
				ArrayIdenttyp.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValIdenttyp);
		}


        /// <summary>
        /// TableManufName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equipm__manufname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equipm__manufname____DoLoad = true;
            CriteriaSet equipm__manufname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("manuf", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equipm__manufname____Conds.Equal(CSGenioAmanuf.FldCodentit, Navigation.GetValue("manuf"));
                    this.ValCodmanuf = Navigation.GetStrValue("manuf");
                }
            }

			// Limits Generation

			object equipm__manufname_____flimitmanuf_manufact = "1";
			equipm__manufname____Conds.Equal(
				CSGenio.business.CSGenioAmanuf.FldManufact,
				equipm__manufname_____flimitmanuf_manufact);


            TableManufName = new TableDBEdit<Models.Manuf>();
            TableManufName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_manuf") != null)
				{
                    this.ValCodmanuf = Navigation.GetStrValue("RETURN_manuf");
					Navigation.CurrentLevel.SetEntry("RETURN_manuf", null);
				}
                FillDependant_EquipmTableManufName(lazyLoad);
                //Check if foreignkey comes from history
                TableManufName.FilledByHistory = Navigation.CheckFilledByHistory("manuf");
                return;
            }


            if (equipm__manufname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableManufName, "sTableManufName", "dTableManufName", qs, "manuf");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmanuf.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableManufName_tableFilters"]))
                    TableManufName.TableFilters = bool.Parse(qs["TableManufName_tableFilters"]);
                else
                    TableManufName.TableFilters = false;

                query = qs["qTableManufName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAmanuf.FldName, query + "%");
                }
                equipm__manufname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableManufName"] != null ? qs["pTableManufName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldInitials, CSGenioAmanuf.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIPM_MANUFNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("manuf", FormMode.New) || Navigation.checkFormMode("manuf", FormMode.Duplicate))
                    equipm__manufname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAmanuf.FldZzstate, 0)
                        .Equal(CSGenioAmanuf.FldCodentit, Navigation.GetStrValue("manuf")));
                else
                    equipm__manufname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmanuf.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equipm__manufname____Conds = Manuf.AddEPH<CSGenioAmanuf>(ref UserContext.Current.User, equipm__manufname____Conds, "LED_EQUIPM__MANUFNAME____");

                FieldRef firstVisibleColumn = new FieldRef("manuf", "name");
                ListingMVC<CSGenioAmanuf> listing = Models.ModelBase.Where<CSGenioAmanuf>(false, equipm__manufname____Conds, fields, offset, numberItems, sorts, "LED_EQUIPM__MANUFNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableManufName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableManufName.Query = query;
                TableManufName.Elements = listing.RowsForViewModel<GenioMVC.Models.Manuf>((r) => new GenioMVC.Models.Manuf(r, true, _fieldsToSerialize_EQUIPM__MANUFNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_manuf") != null)
				{
					this.ValCodmanuf = Navigation.GetStrValue("RETURN_manuf");
					Navigation.CurrentLevel.SetEntry("RETURN_manuf", null);
				}

				TableManufName.List = new SelectList(TableManufName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodmanuf), "Value", "Text", this.ValCodmanuf);
                FillDependant_EquipmTableManufName();

                //Check if foreignkey comes from history
                TableManufName.FilledByHistory = Navigation.CheckFilledByHistory("manuf");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableManufName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Manuf</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipmTableManufName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "manuf.codentit", "manuf.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName };
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
            CSGenioAmanuf tempArea = new CSGenioAmanuf(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAmanuf.FldCodentit, PKey));
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
        /// Fill Dependant fields values -> TableManufName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipmTableManufName(bool lazyLoad = false)
        {
            var row = GetDependant_EquipmTableManufName(this.ValCodmanuf, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodmanuf = ViewModelConversion.ToString(row["manuf.codentit"]);
                TableManufName.Value = ViewModelConversion.ToString(row["manuf.name"]);
                if (GlobalFunctions.emptyG(this.ValCodmanuf) == 1)
                {
                    this.ValCodmanuf = "";
                    TableManufName.Value = "";
                    Navigation.ClearValue("manuf");
                }
                else if (lazyLoad)
                {
                    TableManufName.SetPagination(1, 0, false, false, 1);
                    TableManufName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodmanuf),
                            Text = Convert.ToString(TableManufName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodmanuf);
                }
                TableManufName.Selected = this.ValCodmanuf;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableManufName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIPM__MANUFNAME____ = { "Manuf", "Manuf.ValCodentit", "Manuf.ValZzstate", "Manuf.ValName", "Manuf.ValInitials" };

        /// <summary>
        /// TableKindeDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equipm__kindedesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equipm__kindedesignatDoLoad = true;
            CriteriaSet equipm__kindedesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("kinde", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equipm__kindedesignatConds.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetValue("kinde"));
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
                FillDependant_EquipmTableKindeDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
                return;
            }


            if (equipm__kindedesignatDoLoad)
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
                equipm__kindedesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableKindeDesignat"] != null ? qs["pTableKindeDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAkinde.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIPM_KINDEDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("kinde", FormMode.New) || Navigation.checkFormMode("kinde", FormMode.Duplicate))
                    equipm__kindedesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAkinde.FldZzstate, 0)
                        .Equal(CSGenioAkinde.FldCodkinde, Navigation.GetStrValue("kinde")));
                else
                    equipm__kindedesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAkinde.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equipm__kindedesignatConds = Kinde.AddEPH<CSGenioAkinde>(ref UserContext.Current.User, equipm__kindedesignatConds, "LED_EQUIPM__KINDEDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("kinde", "designat");
                ListingMVC<CSGenioAkinde> listing = Models.ModelBase.Where<CSGenioAkinde>(false, equipm__kindedesignatConds, fields, offset, numberItems, sorts, "LED_EQUIPM__KINDEDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableKindeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableKindeDesignat.Query = query;
                TableKindeDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Kinde>((r) => new GenioMVC.Models.Kinde(r, true, _fieldsToSerialize_EQUIPM__KINDEDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}

				TableKindeDesignat.List = new SelectList(TableKindeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodkinde,  x => x.ValCodkinde == this.ValCodkinde), "Value", "Text", this.ValCodkinde);
                FillDependant_EquipmTableKindeDesignat();

                //Check if foreignkey comes from history
                TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableKindeDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Kinde</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipmTableKindeDesignat(string PKey, NavigationContext Navigation)
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
        public void FillDependant_EquipmTableKindeDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_EquipmTableKindeDesignat(this.ValCodkinde, Navigation);
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


        private readonly string[] _fieldsToSerialize_EQUIPM__KINDEDESIGNAT = { "Kinde", "Kinde.ValCodkinde", "Kinde.ValZzstate", "Kinde.ValDesignat" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIPM]/
		#endregion
	}
}
