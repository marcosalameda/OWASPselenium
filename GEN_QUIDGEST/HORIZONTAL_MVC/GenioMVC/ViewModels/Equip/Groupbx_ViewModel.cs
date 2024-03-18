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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Equip
{
	public class Groupbx_ViewModel : FormViewModel<Models.Equip>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Sequential No.:" Tipo:"N"</summary>
		[Display(Name = "SEQUENTIAL_NO__11610", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValSequennr { get; set; }

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(6, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegistnr { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpequ>  TableTpequTipoequi { get; set; }

		/// <summary>Campo : "Manufacturer's website:" Tipo:"C"</summary>
		[Display(Name = "MANUFACTURER_S_WEBSI12156", ResourceType = typeof(Resources.Resources))]
		[RegularExpression(@"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\/\?\.\:\;\'\,]*)?$",ErrorMessageResourceName = "ENDERECO_INVALIDO_40706", ErrorMessageResourceType = typeof(Resources.Resources))]
		[HyperLink]
		[AllowHtml]
		[StringLength(256, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValSitefabr { get; set; }

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Wareh>  TableWarehWarehdes { get; set; }

		/// <summary>Campo : "Item:" Tipo:"C"</summary>
		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Item>  TableItemItemdes { get; set; }

		/// <summary>Campo : "Decomission:" Tipo:"D"</summary>
		[Display(Name = "DECOMISSION_04392", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("D")]
		public DateTime? ValDtdeco { get; set; }

		/// <summary>Campo : "Room No." Tipo:"C"</summary>
		[Display(Name = "ROOM_NO_08024", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Room1>  TableRoom1Roomnr { get; set; }

		/// <summary>Campo : "Room Designation" Tipo:"C"</summary>
		[Display(Name = "ROOM_DESIGNATION35483", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Room1ValDesignat { get { return funcRoom1ValDesignat != null ? funcRoom1ValDesignat() : _auxRoom1ValDesignat; } set { funcRoom1ValDesignat = () => value; } }
		[JsonIgnore]
		public Func<string> funcRoom1ValDesignat { get; set; }
		private string _auxRoom1ValDesignat { get; set; }

		/// <summary>Campo : "Designation:" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION_35800", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Acquisition:" Tipo:"D"</summary>
		[Display(Name = "ACQUISITION_53832", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtaquisi { get; set; }

		/// <summary>Campo : "Total Value:" Tipo:"$D"</summary>
		[Display(Name = "TOTAL_VALUE_07456", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValortot { get; set; }

		/// <summary>Campo : "Loan Frequency" Tipo:"AN"</summary>
		[Display(Name = "LOAN_FREQUENCY00930", ResourceType = typeof(Resources.Resources))]
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public double? ValFrequenc { get; set; }
		[JsonIgnore]
		public SelectList List_ValFrequenc { get; set; }

		/// <summary>Campo : "Reference" Tipo:"DT"</summary>
		[Display(Name = "REFERENCE28402", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtrefere { get; set; }

		/// <summary>Campo : "First" Tipo:"C"</summary>
		[Display(Name = "FIRST42972", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFirst { get; set; }

		/// <summary>Campo : "Before" Tipo:"C"</summary>
		[Display(Name = "BEFORE60156", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBefore { get; set; }

		/// <summary>Campo : "Bought" Tipo:"L"</summary>
		[Display(Name = "BOUGHT32044", ResourceType = typeof(Resources.Resources))]
		public bool ValBought { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodempre { get; set; }

		public string ValCoddeco { get; set; }

		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public string ValCoditem { get; set; }

		public string ValCodpess1 { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		[Display(Name = "ROOM_NO_08024", ResourceType = typeof(Resources.Resources))]
		public string ValCodrooms { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodequip { get; set; }

		public Groupbx_ViewModel() : base("FGROUPBX") { }

		public Groupbx_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FGROUPBX", currentNavigation, nestedForm) { }

		public Groupbx_ViewModel(Models.Equip row, NavigationContext currentNavigation, bool nestedForm = false) : base("FGROUPBX", row, currentNavigation, nestedForm) { }

		public Groupbx_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, "FGROUPBX", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip() { Identifier = "FGROUPBX" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Equip model)
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

		public static StatusMessage DeleteConditions(Models.Equip model)
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

		public static StatusMessage ViewConditions(Models.Equip model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Equip model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Groupbx) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
 				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
 				ValSitefabr = ViewModelConversion.ToString(m.ValSitefabr);
 				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
 				funcRoom1ValDesignat = () => ViewModelConversion.ToString(m.Room1.ValDesignat);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
 				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
 				ValFrequenc = ViewModelConversion.ToDouble(m.ValFrequenc);
 				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
 				ValFirst = ViewModelConversion.ToString(m.ValFirst);
 				ValBefore = ViewModelConversion.ToString(m.ValBefore);
 				ValBought = ViewModelConversion.ToLogic(m.ValBought);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Groupbx) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Groupbx) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValSitefabr = ViewModelConversion.ToString(ValSitefabr);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValFrequenc = ViewModelConversion.ToDouble(ValFrequenc);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
				m.ValBefore = ViewModelConversion.ToString(ValBefore);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Groupbx) to Model (Equip) - Error during mapping");
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FGROUPBX");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Equip() { Identifier = "FGROUPBX" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
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

			Model.Identifier = "FGROUPBX";
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

		protected override void LoadDocumentsProperties(Models.Equip row)
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FGROUPBX");
				if (Model == null)
				{
					Model = new Models.Equip() { Identifier = "FGROUPBX" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Groupbx_tpequtipoequi(qs, lazyLoad);
			Load_Groupbx_warehwarehdes(qs, lazyLoad);
			Load_Groupbx_item_itemdes_(qs, lazyLoad);
			Load_Groupbx_room1roomnr__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GROUPBX]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GROUPBX]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GROUPBX]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FGROUPBX"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FGROUPBX" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GROUPBX]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FGROUPBX"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FGROUPBX" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GROUPBX]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GROUPBX]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, "FGROUPBX");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValFrequenc = new SelectList(
				ArrayFreqempr.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValFrequenc);
		}


        /// <summary>
        /// TableTpequTipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Groupbx_tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool groupbx_tpequtipoequiDoLoad = true;
            CriteriaSet groupbx_tpequtipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpequ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    groupbx_tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
                    this.ValCodtpequ = Navigation.GetStrValue("tpequ");
                }
            }



            TableTpequTipoequi = new TableDBEdit<Models.Tpequ>();
            TableTpequTipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
                    this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
                FillDependant_GroupbxTableTpequTipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
                return;
            }


            if (groupbx_tpequtipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
                    TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
                else
                    TableTpequTipoequi.TableFilters = false;

                query = qs["qTableTpequTipoequi"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
                }
                groupbx_tpequtipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_TPEQUTIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
                    groupbx_tpequtipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpequ.FldZzstate, 0)
                        .Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
                else
                    groupbx_tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //groupbx_tpequtipoequiConds = Tpequ.AddEPH<CSGenioAtpequ>(ref UserContext.Current.User, groupbx_tpequtipoequiConds, "LED_GROUPBX_TPEQUTIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
                ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, groupbx_tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_GROUPBX_TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpequTipoequi.Query = query;
                TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(r, true, _fieldsToSerialize_GROUPBX_TPEQUTIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_GroupbxTableTpequTipoequi();

                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpequ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_GroupbxTableTpequTipoequi(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpequ.codtpequ", "tpequ.tipoequi" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi };
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
            CSGenioAtpequ tempArea = new CSGenioAtpequ(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));
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
        /// Fill Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_GroupbxTableTpequTipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_GroupbxTableTpequTipoequi(this.ValCodtpequ, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
                TableTpequTipoequi.Value = ViewModelConversion.ToString(row["tpequ.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
                {
                    this.ValCodtpequ = "";
                    TableTpequTipoequi.Value = "";
                    Navigation.ClearValue("tpequ");
                }
                else if (lazyLoad)
                {
                    TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpequTipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpequ),
                            Text = Convert.ToString(TableTpequTipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpequ);
                }
                TableTpequTipoequi.Selected = this.ValCodtpequ;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }

        public List<TreeNode> Tree_TableTpequTipoequi { get; protected set; }
        /// <summary>
        /// Get tree structure data -> TableTpequTipoequi
        /// </summary>
        public void LoadTree_TableTpequTipoequi(NameValueCollection requestValues)
        {
            List<TreeNode> Tree = null;

            Tree = new List<TreeNode>();
            CriteriaSet groupbx_tpequtipoequiConds = CriteriaSet.And();

            bool groupbx_tpequtipoequiDoLoad = true;

			if(!groupbx_tpequtipoequiDoLoad) return;
            List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


            FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };

            groupbx_tpequtipoequiConds.Equal(CSGenioAtpequ.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
 
			groupbx_tpequtipoequiConds.SubSets.Add(subfilters);


            TreeViewControl<Models.Tpequ> tree = new TreeViewControl<Models.Tpequ>();

// USE /[MANUAL GQT OVERRQ GROUPBX_TPEQUVALTIPOEQUI]/
			tree.AddBranch(new TreeBranchInfo<Models.Tpequ>() {
				Area = "TPEQU", Form = "",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Tpequ, string>(x => x.ValTpequcod),
				ParentSelector = new Func<Models.Tpequ, string>(x => x.ValTpequpai),
				LevelSelector = new Func<Models.Tpequ, double>(x => x.ValNivel),
				TextSelector = new Func<Models.Tpequ, string>(x => string.Format("{0} {1}", x.ValTpequcod, x.ValTipoequi))
			});

            ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, groupbx_tpequtipoequiConds, fields, 0, -1, sorts, "IBL_GROUPBX_TPEQUTIPOEQUI");

            var rowsAsModels = listing.RowsForViewModel<Models.Tpequ>((r) => new Models.Tpequ(r, true, _fieldsToSerialize_GROUPBX_TPEQUTIPOEQUI).SetIsEmptyModel<Models.Tpequ>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
            // Filter the final list to only include the top nodes
            Tree_TableTpequTipoequi = Tree.FindAll(x => x.hasParent == false);
        }

        private readonly string[] _fieldsToSerialize_GROUPBX_TPEQUTIPOEQUI = { "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra" };

        /// <summary>
        /// TableWarehWarehdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Groupbx_warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
        {
            bool groupbx_warehwarehdesDoLoad = true;
            CriteriaSet groupbx_warehwarehdesConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("wareh", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    groupbx_warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
                    this.ValCodwareh = Navigation.GetStrValue("wareh");
                }
            }



            TableWarehWarehdes = new TableDBEdit<Models.Wareh>();
            TableWarehWarehdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
                    this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
                FillDependant_GroupbxTableWarehWarehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
                return;
            }


            if (groupbx_warehwarehdesDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
                    TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
                else
                    TableWarehWarehdes.TableFilters = false;

                query = qs["qTableWarehWarehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
                }
                groupbx_warehwarehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldWarehcod, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_WAREHWAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
                    groupbx_warehwarehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAwareh.FldZzstate, 0)
                        .Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
                else
                    groupbx_warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //groupbx_warehwarehdesConds = Wareh.AddEPH<CSGenioAwareh>(ref UserContext.Current.User, groupbx_warehwarehdesConds, "LED_GROUPBX_WAREHWAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
                ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(false, groupbx_warehwarehdesConds, fields, offset, numberItems, sorts, "LED_GROUPBX_WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWarehWarehdes.Query = query;
                TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(r, true, _fieldsToSerialize_GROUPBX_WAREHWAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                FillDependant_GroupbxTableWarehWarehdes();

                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Wareh</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_GroupbxTableWarehWarehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "wareh.codwareh", "wareh.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };
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
            CSGenioAwareh tempArea = new CSGenioAwareh(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));
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
        /// Fill Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_GroupbxTableWarehWarehdes(bool lazyLoad = false)
        {
            var row = GetDependant_GroupbxTableWarehWarehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
                TableWarehWarehdes.Value = ViewModelConversion.ToString(row["wareh.warehdes"]);
                if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
                {
                    this.ValCodwareh = "";
                    TableWarehWarehdes.Value = "";
                    Navigation.ClearValue("wareh");
                }
                else if (lazyLoad)
                {
                    TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
                    TableWarehWarehdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodwareh),
                            Text = Convert.ToString(TableWarehWarehdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodwareh);
                }
                TableWarehWarehdes.Selected = this.ValCodwareh;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_GROUPBX_WAREHWAREHDES = { "Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes", "Wareh.ValWarehcod" };

        /// <summary>
        /// TableItemItemdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Groupbx_item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool groupbx_item_itemdes_DoLoad = true;
            CriteriaSet groupbx_item_itemdes_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("item", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    groupbx_item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, Navigation.GetValue("item"));
                    this.ValCoditem = Navigation.GetStrValue("item");
                }
            }

			// Limits Generation

			// Area limit
			groupbx_item_itemdes_DoLoad &= AddCriteriaAreaLimit(groupbx_item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, false);


            TableItemItemdes = new TableDBEdit<Models.Item>();
            TableItemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
                    this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
                FillDependant_GroupbxTableItemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodwareh))
                groupbx_item_itemdes_DoLoad = false;

            if (groupbx_item_itemdes_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
                    TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
                else
                    TableItemItemdes.TableFilters = false;

                query = qs["qTableItemItemdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
                }
                groupbx_item_itemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_ITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
                    groupbx_item_itemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAitem.FldZzstate, 0)
                        .Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
                else
                    groupbx_item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //groupbx_item_itemdes_Conds = Item.AddEPH<CSGenioAitem>(ref UserContext.Current.User, groupbx_item_itemdes_Conds, "LED_GROUPBX_ITEM_ITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
                ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(false, groupbx_item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_GROUPBX_ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableItemItemdes.Query = query;
                TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(r, true, _fieldsToSerialize_GROUPBX_ITEM_ITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
                FillDependant_GroupbxTableItemItemdes();

                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Item</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_GroupbxTableItemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "item.coditem", "item.itemdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("wareh");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAitem tempArea = new CSGenioAitem(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));
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
        /// Fill Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_GroupbxTableItemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_GroupbxTableItemItemdes(this.ValCoditem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
                TableItemItemdes.Value = ViewModelConversion.ToString(row["item.itemdes"]);
                if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
                {
                    this.ValCoditem = "";
                    TableItemItemdes.Value = "";
                    Navigation.ClearValue("item");
                }
                else if (lazyLoad)
                {
                    TableItemItemdes.SetPagination(1, 0, false, false, 1);
                    TableItemItemdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoditem),
                            Text = Convert.ToString(TableItemItemdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoditem);
                }
                TableItemItemdes.Selected = this.ValCoditem;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_GROUPBX_ITEM_ITEMDES_ = { "Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod" };

        /// <summary>
        /// TableRoom1Roomnr -> (F1)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Groupbx_room1roomnr__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool groupbx_room1roomnr__DoLoad = true;
            CriteriaSet groupbx_room1roomnr__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("room1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    groupbx_room1roomnr__Conds.Equal(CSGenioAroom1.FldCodrooms, Navigation.GetValue("room1"));
                    this.ValCodrooms = Navigation.GetStrValue("room1");
                }
            }



            TableRoom1Roomnr = new TableDBEdit<Models.Room1>();
            TableRoom1Roomnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
                    this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}
                FillDependant_GroupbxTableRoom1Roomnr(lazyLoad);
                //Check if foreignkey comes from history
                TableRoom1Roomnr.FilledByHistory = Navigation.CheckFilledByHistory("room1");
                return;
            }


            if (groupbx_room1roomnr__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRoom1Roomnr, "sTableRoom1Roomnr", "dTableRoom1Roomnr", qs, "room1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRoom1Roomnr_tableFilters"]))
                    TableRoom1Roomnr.TableFilters = bool.Parse(qs["TableRoom1Roomnr_tableFilters"]);
                else
                    TableRoom1Roomnr.TableFilters = false;

                query = qs["qTableRoom1Roomnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAroom1.FldRoomnr, query + "%");
                }
                groupbx_room1roomnr__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRoom1Roomnr"] != null ? qs["pTableRoom1Roomnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_ROOM1ROOMNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("room1", FormMode.New) || Navigation.checkFormMode("room1", FormMode.Duplicate))
                    groupbx_room1roomnr__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAroom1.FldZzstate, 0)
                        .Equal(CSGenioAroom1.FldCodrooms, Navigation.GetStrValue("room1")));
                else
                    groupbx_room1roomnr__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAroom1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //groupbx_room1roomnr__Conds = Room1.AddEPH<CSGenioAroom1>(ref UserContext.Current.User, groupbx_room1roomnr__Conds, "LED_GROUPBX_ROOM1ROOMNR__");

                FieldRef firstVisibleColumn = null;
                ListingMVC<CSGenioAroom1> listing = Models.ModelBase.Where<CSGenioAroom1>(false, groupbx_room1roomnr__Conds, fields, offset, numberItems, sorts, "LED_GROUPBX_ROOM1ROOMNR__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRoom1Roomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRoom1Roomnr.Query = query;
                TableRoom1Roomnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Room1>((r) => new GenioMVC.Models.Room1(r, true, _fieldsToSerialize_GROUPBX_ROOM1ROOMNR__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}

				TableRoom1Roomnr.List = new SelectList(TableRoom1Roomnr.Elements.ToSelectList(x => x.ValRoomnr, x => x.ValCodrooms,  x => x.ValCodrooms == this.ValCodrooms), "Value", "Text", this.ValCodrooms);
                FillDependant_GroupbxTableRoom1Roomnr();

                //Check if foreignkey comes from history
                TableRoom1Roomnr.FilledByHistory = Navigation.CheckFilledByHistory("room1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRoom1Roomnr (F1)
        /// </summary>
        /// <param name="PKey">Primary Key of Room1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_GroupbxTableRoom1Roomnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "room1.codrooms", "room1.roomnr", "room1.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldDesignat };
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
            CSGenioAroom1 tempArea = new CSGenioAroom1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAroom1.FldCodrooms, PKey));
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
        /// Fill Dependant fields values -> TableRoom1Roomnr (F1)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_GroupbxTableRoom1Roomnr(bool lazyLoad = false)
        {
            var row = GetDependant_GroupbxTableRoom1Roomnr(this.ValCodrooms, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["room1.designat"]);
                    this.funcRoom1ValDesignat = () => tempValue;
                }

                // Fill List fields
                this.ValCodrooms = ViewModelConversion.ToString(row["room1.codrooms"]);
                TableRoom1Roomnr.Value = ViewModelConversion.ToString(row["room1.roomnr"]);
                if (GlobalFunctions.emptyG(this.ValCodrooms) == 1)
                {
                    this.ValCodrooms = "";
                    TableRoom1Roomnr.Value = "";
                    Navigation.ClearValue("room1");
                }
                else if (lazyLoad)
                {
                    TableRoom1Roomnr.SetPagination(1, 0, false, false, 1);
                    TableRoom1Roomnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodrooms),
                            Text = Convert.ToString(TableRoom1Roomnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodrooms);
                }
                TableRoom1Roomnr.Selected = this.ValCodrooms;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRoom1Roomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_GROUPBX_ROOM1ROOMNR__ = { "Room1", "Room1.ValCodrooms", "Room1.ValZzstate" };


		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GROUPBX]/
		#endregion
	}
}
