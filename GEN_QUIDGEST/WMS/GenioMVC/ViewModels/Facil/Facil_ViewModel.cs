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

namespace GenioMVC.ViewModels.Facil
{
	public class Facil_ViewModel : FormViewModel<Models.Facil>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Legal name" Tipo:"C"</summary>
		[Display(Name = "LEGAL_NAME42902", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Entit>  TableEntitName { get; set; }

		/// <summary>Campo : "Incorporation" Tipo:"D"</summary>
		[Display(Name = "INCORPORATION10135", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get; set; }

		/// <summary>Campo : "Facility name" Tipo:"C"</summary>
		[Display(Name = "FACILITY_NAME19514", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Facility type" Tipo:"AC"</summary>
		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get; set; }
		[JsonIgnore]
		public SelectList List_ValFaciltyp { get; set; }

		/// <summary>Campo : "Facility type" Tipo:"C"</summary>
		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Facty>  TableFactyType { get; set; }

		/// <summary>Campo : "Address" Tipo:"MO"</summary>
		[Display(Name = "ADDRESS04342", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValAddress { get; set; }

		/// <summary>Campo : "Image" Tipo:"IJ"</summary>
		[Display(Name = "IMAGE65174", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 400, 300, false, true)]
		public byte[] ValImage { get; set; }

		/// <summary>Campo : "GPS input" Tipo:"AC"</summary>
		[Display(Name = "GPS_INPUT13625", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get; set; }
		[JsonIgnore]
		public SelectList List_ValGpsinput { get; set; }

		/// <summary>Campo : "Latitude" Tipo:"ND"</summary>
		[Display(Name = "LATITUDE11291", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N6}" )]
		[NumericAttribute(6)]
		public decimal? ValLatitude { get; set; }

		/// <summary>Campo : "Longitude" Tipo:"ND"</summary>
		[Display(Name = "LONGITUDE01015", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N6}" )]
		[NumericAttribute(6)]
		public decimal? ValLongitud { get; set; }

		/// <summary>Campo : "Geographical coordinate" Tipo:"GG"</summary>
		[Display(Name = "GEOGRAPHICAL_COORDIN45869", ResourceType = typeof(Resources.Resources))]
		[UIHint("Leaflet")]
		public string ValGeocoori { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "LEGAL_NAME42902", ResourceType = typeof(Resources.Resources))]
		public string ValCodentit { get; set; }

		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		public string ValCodfacty { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodfacil { get; set; }

		public Facil_ViewModel() : base("FFACIL") { }

		public Facil_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFACIL", currentNavigation, nestedForm) { }

		public Facil_ViewModel(Models.Facil row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFACIL", row, currentNavigation, nestedForm) { }

		public Facil_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("facil", id);
			Model = Models.Facil.Find(id, "FFACIL", fieldsToQuery: fieldsToLoad);
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
			Models.Facil model = new Models.Facil() { Identifier = "FFACIL" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Facil model)
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

		public static StatusMessage DeleteConditions(Models.Facil model)
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

		public static StatusMessage ViewConditions(Models.Facil model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Facil model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Facil m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Facil) to ViewModel (Facil) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValIncorpor = ViewModelConversion.ToDateTime(m.ValIncorpor);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValFaciltyp = ViewModelConversion.ToString(m.ValFaciltyp);
 				ValAddress = ViewModelConversion.ToString(m.ValAddress);
 				ValImage = ViewModelConversion.ToImage(m.ValImage);
 				ValGpsinput = ViewModelConversion.ToString(m.ValGpsinput);
 				ValLatitude = ViewModelConversion.ToNumeric(m.ValLatitude);
 				ValLongitud = ViewModelConversion.ToNumeric(m.ValLongitud);
 				ValGeocoori = ViewModelConversion.ToString(m.ValGeocoori);
 				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
 				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
 				ValCodfacil = ViewModelConversion.ToString(m.ValCodfacil);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Facil) to ViewModel (Facil) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Facil m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facil) to Model (Facil) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValIncorpor = ViewModelConversion.ToDateTime(ValIncorpor);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValFaciltyp = ViewModelConversion.ToString(ValFaciltyp);
				m.ValAddress = ViewModelConversion.ToString(ValAddress);
				m.ValGpsinput = ViewModelConversion.ToString(ValGpsinput);
				m.ValLatitude = ViewModelConversion.ToNumeric(ValLatitude);
				m.ValLongitud = ViewModelConversion.ToNumeric(ValLongitud);
				m.ValGeocoori = ViewModelConversion.ToString(ValGeocoori);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValCodfacil = ViewModelConversion.ToString(ValCodfacil);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facil) to Model (Facil) - Error during mapping");
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
				Model = Models.Facil.Find(Navigation.GetStrValue("facil"), "FFACIL");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Facil() { Identifier = "FFACIL" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("facil");
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

			Model.Identifier = "FFACIL";
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

		protected override void LoadDocumentsProperties(Models.Facil row)
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
				Model = Models.Facil.Find(Navigation.GetStrValue("facil"), "FFACIL");
				if (Model == null)
				{
					Model = new Models.Facil() { Identifier = "FFACIL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("facil");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Facil___entitname____(qs, lazyLoad);
			Load_Facil___factytype____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FACIL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FACIL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FACIL]/
		public override void Save()
		{

			try { Model = Models.Facil.Find(Navigation.GetStrValue("facil"), "FFACIL"); }
			finally { if (Model == null) Model = new Models.Facil() { Identifier = "FFACIL" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FACIL]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Facil.Find(Navigation.GetStrValue("facil"), "FFACIL"); }
			finally { if (Model == null) Model = new Models.Facil() { Identifier = "FFACIL" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FACIL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FACIL]/
		public override void Destroy(string id)
		{
			Model = Models.Facil.Find(id, "FFACIL");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValFaciltyp = new SelectList(
				ArrayFaciltyp.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValFaciltyp);
			this.List_ValGpsinput = new SelectList(
				ArrayGpsinput.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValGpsinput);
		}


        /// <summary>
        /// TableEntitName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Facil___entitname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool facil___entitname____DoLoad = true;
            CriteriaSet facil___entitname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("entit", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    facil___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
                    this.ValCodentit = Navigation.GetStrValue("entit");
                }
            }



            TableEntitName = new TableDBEdit<Models.Entit>();
            TableEntitName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
                    this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
                FillDependant_FacilTableEntitName(lazyLoad);
                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
                return;
            }


            if (facil___entitname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
                    TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
                else
                    TableEntitName.TableFilters = false;

                query = qs["qTableEntitName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAentit.FldName, query + "%");
                }
                facil___entitname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ FACIL_ENTITNAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
                    facil___entitname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAentit.FldZzstate, 0)
                        .Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
                else
                    facil___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //facil___entitname____Conds = Entit.AddEPH<CSGenioAentit>(ref UserContext.Current.User, facil___entitname____Conds, "LED_FACIL___ENTITNAME____");

                FieldRef firstVisibleColumn = new FieldRef("entit", "name");
                ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, facil___entitname____Conds, fields, offset, numberItems, sorts, "LED_FACIL___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEntitName.Query = query;
                TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(r, true, _fieldsToSerialize_FACIL___ENTITNAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
                FillDependant_FacilTableEntitName();

                //Check if foreignkey comes from history
                TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Entit</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_FacilTableEntitName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "entit.codentit", "entit.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName };
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
            CSGenioAentit tempArea = new CSGenioAentit(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));
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
        /// Fill Dependant fields values -> TableEntitName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_FacilTableEntitName(bool lazyLoad = false)
        {
            var row = GetDependant_FacilTableEntitName(this.ValCodentit, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
                TableEntitName.Value = ViewModelConversion.ToString(row["entit.name"]);
                if (GlobalFunctions.emptyG(this.ValCodentit) == 1)
                {
                    this.ValCodentit = "";
                    TableEntitName.Value = "";
                    Navigation.ClearValue("entit");
                }
                else if (lazyLoad)
                {
                    TableEntitName.SetPagination(1, 0, false, false, 1);
                    TableEntitName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodentit),
                            Text = Convert.ToString(TableEntitName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodentit);
                }
                TableEntitName.Selected = this.ValCodentit;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_FACIL___ENTITNAME____ = { "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials" };

        /// <summary>
        /// TableFactyType -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Facil___factytype____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool facil___factytype____DoLoad = true;
            CriteriaSet facil___factytype____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("facty", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    facil___factytype____Conds.Equal(CSGenioAfacty.FldCodfacty, Navigation.GetValue("facty"));
                    this.ValCodfacty = Navigation.GetStrValue("facty");
                }
            }



            TableFactyType = new TableDBEdit<Models.Facty>();
            TableFactyType.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
                    this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}
                FillDependant_FacilTableFactyType(lazyLoad);
                //Check if foreignkey comes from history
                TableFactyType.FilledByHistory = Navigation.CheckFilledByHistory("facty");
                return;
            }


            if (facil___factytype____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableFactyType, "sTableFactyType", "dTableFactyType", qs, "facty");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableFactyType_tableFilters"]))
                    TableFactyType.TableFilters = bool.Parse(qs["TableFactyType_tableFilters"]);
                else
                    TableFactyType.TableFilters = false;

                query = qs["qTableFactyType"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAfacty.FldType, query + "%");
                }
                facil___factytype____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableFactyType"] != null ? qs["pTableFactyType"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType, CSGenioAfacty.FldLayrname, CSGenioAfacty.FldIconurl, CSGenioAfacty.FldShadowur, CSGenioAfacty.FldIconancx, CSGenioAfacty.FldIconancy, CSGenioAfacty.FldIconheig, CSGenioAfacty.FldIconwid, CSGenioAfacty.FldPopupanx, CSGenioAfacty.FldPopupany, CSGenioAfacty.FldShadowax, CSGenioAfacty.FldShadoway, CSGenioAfacty.FldShadowhe, CSGenioAfacty.FldShadowwi, CSGenioAfacty.FldZzstate };

// USE /[MANUAL GQT OVERRQ FACIL_FACTYTYPE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("facty", FormMode.New) || Navigation.checkFormMode("facty", FormMode.Duplicate))
                    facil___factytype____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAfacty.FldZzstate, 0)
                        .Equal(CSGenioAfacty.FldCodfacty, Navigation.GetStrValue("facty")));
                else
                    facil___factytype____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacty.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //facil___factytype____Conds = Facty.AddEPH<CSGenioAfacty>(ref UserContext.Current.User, facil___factytype____Conds, "LED_FACIL___FACTYTYPE____");

                FieldRef firstVisibleColumn = new FieldRef("facty", "type");
                ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(false, facil___factytype____Conds, fields, offset, numberItems, sorts, "LED_FACIL___FACTYTYPE____", true, false, firstVisibleColumn: firstVisibleColumn);

                TableFactyType.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableFactyType.Query = query;
                TableFactyType.Elements = listing.RowsForViewModel<GenioMVC.Models.Facty>((r) => new GenioMVC.Models.Facty(r, true, _fieldsToSerialize_FACIL___FACTYTYPE____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}

				TableFactyType.List = new SelectList(TableFactyType.Elements.ToSelectList(x => x.ValType, x => x.ValCodfacty,  x => x.ValCodfacty == this.ValCodfacty), "Value", "Text", this.ValCodfacty);
                FillDependant_FacilTableFactyType();

                //Check if foreignkey comes from history
                TableFactyType.FilledByHistory = Navigation.CheckFilledByHistory("facty");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableFactyType (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Facty</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_FacilTableFactyType(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "facty.codfacty", "facty.type" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType };
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
            CSGenioAfacty tempArea = new CSGenioAfacty(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAfacty.FldCodfacty, PKey));
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
        /// Fill Dependant fields values -> TableFactyType (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_FacilTableFactyType(bool lazyLoad = false)
        {
            var row = GetDependant_FacilTableFactyType(this.ValCodfacty, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodfacty = ViewModelConversion.ToString(row["facty.codfacty"]);
                TableFactyType.Value = ViewModelConversion.ToString(row["facty.type"]);
                if (GlobalFunctions.emptyG(this.ValCodfacty) == 1)
                {
                    this.ValCodfacty = "";
                    TableFactyType.Value = "";
                    Navigation.ClearValue("facty");
                }
                else if (lazyLoad)
                {
                    TableFactyType.SetPagination(1, 0, false, false, 1);
                    TableFactyType.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodfacty),
                            Text = Convert.ToString(TableFactyType.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodfacty);
                }
                TableFactyType.Selected = this.ValCodfacty;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFactyType): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_FACIL___FACTYTYPE____ = { "Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType", "Facty.ValLayrname", "Facty.ValIconurl", "Facty.ValShadowur", "Facty.ValIconancx", "Facty.ValIconancy", "Facty.ValIconheig", "Facty.ValIconwid", "Facty.ValPopupanx", "Facty.ValPopupany", "Facty.ValShadowax", "Facty.ValShadoway", "Facty.ValShadowhe", "Facty.ValShadowwi" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FACIL]/
		#endregion
	}
}
