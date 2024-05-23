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

namespace GenioMVC.ViewModels.Roigi
{
	public class Roigi_ViewModel : FormViewModel<Models.Roigi>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Title" Tipo:"C"</summary>
		[Display(Name = "TITLE21885", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Rogl1>  TableRogl1Title { get; set; }

		/// <summary>Campo : "Order" Tipo:"N"</summary>
		[Display(Name = "ORDER39632", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOrder { get; set; }

		/// <summary>Campo : "Title" Tipo:"C"</summary>
		[Display(Name = "TITLE21885", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTitle { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "TITLE21885", ResourceType = typeof(Resources.Resources))]
		public string ValCodrogl1 { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodroigi { get; set; }

		public Roigi_ViewModel() : base("FROIGI") { }

		public Roigi_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FROIGI", currentNavigation, nestedForm) { }

		public Roigi_ViewModel(Models.Roigi row, NavigationContext currentNavigation, bool nestedForm = false) : base("FROIGI", row, currentNavigation, nestedForm) { }

		public Roigi_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("roigi", id);
			Model = Models.Roigi.Find(id, "FROIGI", fieldsToQuery: fieldsToLoad);
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
			Models.Roigi model = new Models.Roigi() { Identifier = "FROIGI" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Roigi model)
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

		public static StatusMessage DeleteConditions(Models.Roigi model)
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

		public static StatusMessage ViewConditions(Models.Roigi model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Roigi model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Roigi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Roigi) to ViewModel (Roigi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
 				ValTitle = ViewModelConversion.ToString(m.ValTitle);
 				ValCodrogl1 = ViewModelConversion.ToString(m.ValCodrogl1);
 				ValCodroigi = ViewModelConversion.ToString(m.ValCodroigi);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Roigi) to ViewModel (Roigi) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Roigi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Roigi) to Model (Roigi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValCodrogl1 = ViewModelConversion.ToString(ValCodrogl1);
				m.ValCodroigi = ViewModelConversion.ToString(ValCodroigi);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Roigi) to Model (Roigi) - Error during mapping");
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
				Model = Models.Roigi.Find(Navigation.GetStrValue("roigi"), "FROIGI");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Roigi() { Identifier = "FROIGI" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("roigi");
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

			Model.Identifier = "FROIGI";
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

		protected override void LoadDocumentsProperties(Models.Roigi row)
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
				Model = Models.Roigi.Find(Navigation.GetStrValue("roigi"), "FROIGI");
				if (Model == null)
				{
					Model = new Models.Roigi() { Identifier = "FROIGI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("roigi");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Roigi___rogl1title___(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ROIGI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ROIGI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ROIGI]/
		public override void Save()
		{

			try { Model = Models.Roigi.Find(Navigation.GetStrValue("roigi"), "FROIGI"); }
			finally { if (Model == null) Model = new Models.Roigi() { Identifier = "FROIGI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ROIGI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Roigi.Find(Navigation.GetStrValue("roigi"), "FROIGI"); }
			finally { if (Model == null) Model = new Models.Roigi() { Identifier = "FROIGI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ROIGI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ROIGI]/
		public override void Destroy(string id)
		{
			Model = Models.Roigi.Find(id, "FROIGI");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}


        /// <summary>
        /// TableRogl1Title -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Roigi___rogl1title___(NameValueCollection qs, bool lazyLoad = false)
        {
            bool roigi___rogl1title___DoLoad = true;
            CriteriaSet roigi___rogl1title___Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("rogl1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    roigi___rogl1title___Conds.Equal(CSGenioArogl1.FldCodrogl1, Navigation.GetValue("rogl1"));
                    this.ValCodrogl1 = Navigation.GetStrValue("rogl1");
                }
            }



            TableRogl1Title = new TableDBEdit<Models.Rogl1>();
            TableRogl1Title.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_rogl1") != null)
				{
                    this.ValCodrogl1 = Navigation.GetStrValue("RETURN_rogl1");
					Navigation.CurrentLevel.SetEntry("RETURN_rogl1", null);
				}
                FillDependant_RoigiTableRogl1Title(lazyLoad);
                //Check if foreignkey comes from history
                TableRogl1Title.FilledByHistory = Navigation.CheckFilledByHistory("rogl1");
                return;
            }


            if (roigi___rogl1title___DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRogl1Title, "sTableRogl1Title", "dTableRogl1Title", qs, "rogl1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArogl1.FldTitle), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRogl1Title_tableFilters"]))
                    TableRogl1Title.TableFilters = bool.Parse(qs["TableRogl1Title_tableFilters"]);
                else
                    TableRogl1Title.TableFilters = false;

                query = qs["qTableRogl1Title"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioArogl1.FldTitle, query + "%");
                }
                roigi___rogl1title___Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRogl1Title"] != null ? qs["pTableRogl1Title"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioArogl1.FldCodrogl1, CSGenioArogl1.FldTitle, CSGenioArogl1.FldZzstate };

// USE /[MANUAL GQT OVERRQ ROIGI_ROGL1TITLE]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("rogl1", FormMode.New) || Navigation.checkFormMode("rogl1", FormMode.Duplicate))
                    roigi___rogl1title___Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioArogl1.FldZzstate, 0)
                        .Equal(CSGenioArogl1.FldCodrogl1, Navigation.GetStrValue("rogl1")));
                else
                    roigi___rogl1title___Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArogl1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //roigi___rogl1title___Conds = Rogl1.AddEPH<CSGenioArogl1>(ref UserContext.Current.User, roigi___rogl1title___Conds, "LED_ROIGI___ROGL1TITLE___");

                FieldRef firstVisibleColumn = new FieldRef("rogl1", "title");
                ListingMVC<CSGenioArogl1> listing = Models.ModelBase.Where<CSGenioArogl1>(false, roigi___rogl1title___Conds, fields, offset, numberItems, sorts, "LED_ROIGI___ROGL1TITLE___", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRogl1Title.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRogl1Title.Query = query;
                TableRogl1Title.Elements = listing.RowsForViewModel<GenioMVC.Models.Rogl1>((r) => new GenioMVC.Models.Rogl1(r, true, _fieldsToSerialize_ROIGI___ROGL1TITLE___));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_rogl1") != null)
				{
					this.ValCodrogl1 = Navigation.GetStrValue("RETURN_rogl1");
					Navigation.CurrentLevel.SetEntry("RETURN_rogl1", null);
				}

				TableRogl1Title.List = new SelectList(TableRogl1Title.Elements.ToSelectList(x => x.ValTitle, x => x.ValCodrogl1,  x => x.ValCodrogl1 == this.ValCodrogl1), "Value", "Text", this.ValCodrogl1);
                FillDependant_RoigiTableRogl1Title();

                //Check if foreignkey comes from history
                TableRogl1Title.FilledByHistory = Navigation.CheckFilledByHistory("rogl1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRogl1Title (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Rogl1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_RoigiTableRogl1Title(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "rogl1.codrogl1", "rogl1.title" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioArogl1.FldCodrogl1, CSGenioArogl1.FldTitle };
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
            CSGenioArogl1 tempArea = new CSGenioArogl1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioArogl1.FldCodrogl1, PKey));
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
        /// Fill Dependant fields values -> TableRogl1Title (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_RoigiTableRogl1Title(bool lazyLoad = false)
        {
            var row = GetDependant_RoigiTableRogl1Title(this.ValCodrogl1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodrogl1 = ViewModelConversion.ToString(row["rogl1.codrogl1"]);
                TableRogl1Title.Value = ViewModelConversion.ToString(row["rogl1.title"]);
                if (GlobalFunctions.emptyG(this.ValCodrogl1) == 1)
                {
                    this.ValCodrogl1 = "";
                    TableRogl1Title.Value = "";
                    Navigation.ClearValue("rogl1");
                }
                else if (lazyLoad)
                {
                    TableRogl1Title.SetPagination(1, 0, false, false, 1);
                    TableRogl1Title.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodrogl1),
                            Text = Convert.ToString(TableRogl1Title.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodrogl1);
                }
                TableRogl1Title.Selected = this.ValCodrogl1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRogl1Title): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_ROIGI___ROGL1TITLE___ = { "Rogl1", "Rogl1.ValCodrogl1", "Rogl1.ValZzstate", "Rogl1.ValTitle" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ROIGI]/
		#endregion
	}
}
