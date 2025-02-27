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

namespace GenioMVC.ViewModels.Repar
{
	public class Repar_ViewModel : FormViewModel<Models.Repar>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Equip>  TableEquipRegistnr { get; set; }

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string EquipValDesignat { get { return funcEquipValDesignat != null ? funcEquipValDesignat() : _auxEquipValDesignat; } set { funcEquipValDesignat = () => value; } }
		[JsonIgnore]
		public Func<string> funcEquipValDesignat { get; set; }
		private string _auxEquipValDesignat { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] EquipValPhotogra { get { return funcEquipValPhotogra != null ? funcEquipValPhotogra() : _auxEquipValPhotogra; } set { funcEquipValPhotogra = () => value; } }
		[JsonIgnore]
		public Func<byte[]> funcEquipValPhotogra { get; set; }
		private byte[] _auxEquipValPhotogra { get; set; }

		/// <summary>Campo : "Repaired on" Tipo:"DT"</summary>
		[Display(Name = "REPAIRED_ON23617", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtrepara { get; set; }

		/// <summary>Campo : "Company Repair Number" Tipo:"N"</summary>
		[Display(Name = "COMPANY_REPAIR_NUMBE12157", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNrrepara { get; set; }

		/// <summary>Campo : "Technical area" Tipo:"AC"</summary>
		[Display(Name = "TECHNICAL_AREA50773", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipoarea { get; set; }
		[JsonIgnore]
		public SelectList List_ValTipoarea { get; set; }

		/// <summary>Campo : "Specialty" Tipo:"C"</summary>
		[Display(Name = "SPECIALTY09304", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Speci>  TableSpeciEspecial { get; set; }

		/// <summary>Campo : "Technician" Tipo:"C"</summary>
		[Display(Name = "TECHNICIAN44001", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pesso>  TablePessoName { get; set; }

		/// <summary>Campo : "Repair Description" Tipo:"MO"</summary>
		[Display(Name = "REPAIR_DESCRIPTION35914", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "Spent in Hours" Tipo:"N"</summary>
		[Display(Name = "SPENT_IN_HOURS19366", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValHours { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodcateg { get; set; }

		public string ValCodempre { get; set; }

		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		public string ValCodequip { get; set; }

		[Display(Name = "TECHNICIAN44001", ResourceType = typeof(Resources.Resources))]
		public string ValCodpesso { get; set; }

		[Display(Name = "SPECIALTY09304", ResourceType = typeof(Resources.Resources))]
		public string ValCodespec { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Used only for lazy loading of the SpeciValAreatecn field</summary>
		[Newtonsoft.Json.JsonIgnore]
		public Func<string> funcSpeciValAreatecn { get; set; }
		private string _auxSpeciValAreatecn { get; set; }
		/// <summary>Field : "Technical area" Tipo: "AC"</summary>
		[AllowHtml]
		public string SpeciValAreatecn { get { return funcSpeciValAreatecn != null ? funcSpeciValAreatecn() : _auxSpeciValAreatecn; } set { funcSpeciValAreatecn = () => value;} }
		#endregion

		public string ValCodrepar { get; set; }

		public Repar_ViewModel() : base("FREPAR") { }

		public Repar_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FREPAR", currentNavigation, nestedForm) { }

		public Repar_ViewModel(Models.Repar row, NavigationContext currentNavigation, bool nestedForm = false) : base("FREPAR", row, currentNavigation, nestedForm) { }

		public Repar_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("repar", id);
			Model = Models.Repar.Find(id, "FREPAR", fieldsToQuery: fieldsToLoad);
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
			Models.Repar model = new Models.Repar() { Identifier = "FREPAR" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Repar model)
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

		public static StatusMessage DeleteConditions(Models.Repar model)
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

		public static StatusMessage ViewConditions(Models.Repar model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Repar model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Repar m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Repar) to ViewModel (Repar) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				funcEquipValDesignat = () => ViewModelConversion.ToString(m.Equip.ValDesignat);
 				funcEquipValPhotogra = () => ViewModelConversion.ToImage(m.Equip.ValPhotogra);
 				ValDtrepara = ViewModelConversion.ToDateTime(m.ValDtrepara);
 				ValNrrepara = ViewModelConversion.ToNumeric(m.ValNrrepara);
 				ValTipoarea = ViewModelConversion.ToString(m.ValTipoarea);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValHours = ViewModelConversion.ToNumeric(m.ValHours);
 				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
 				ValCodespec = ViewModelConversion.ToString(m.ValCodespec);
 				funcSpeciValAreatecn = () => ViewModelConversion.ToString(m.Speci.ValAreatecn);
 				ValCodrepar = ViewModelConversion.ToString(m.ValCodrepar);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Repar) to ViewModel (Repar) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Repar m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Repar) to Model (Repar) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDtrepara = ViewModelConversion.ToDateTime(ValDtrepara);
				m.ValNrrepara = ViewModelConversion.ToNumeric(ValNrrepara);
				m.ValTipoarea = ViewModelConversion.ToString(ValTipoarea);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodespec = ViewModelConversion.ToString(ValCodespec);
				m.ValCodrepar = ViewModelConversion.ToString(ValCodrepar);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Repar) to Model (Repar) - Error during mapping");
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
				Model = Models.Repar.Find(Navigation.GetStrValue("repar"), "FREPAR");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Repar() { Identifier = "FREPAR" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("repar");
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

			Model.Identifier = "FREPAR";
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

		protected override void LoadDocumentsProperties(Models.Repar row)
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
				Model = Models.Repar.Find(Navigation.GetStrValue("repar"), "FREPAR");
				if (Model == null)
				{
					Model = new Models.Repar() { Identifier = "FREPAR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("repar");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Repar___equipregistnr(qs, lazyLoad);
			Load_Repar___speciespecial(qs, lazyLoad);
			Load_Repar___pessoname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REPAR]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REPAR]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REPAR]/
		public override void Save()
		{

			try { Model = Models.Repar.Find(Navigation.GetStrValue("repar"), "FREPAR"); }
			finally { if (Model == null) Model = new Models.Repar() { Identifier = "FREPAR" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REPAR]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Repar.Find(Navigation.GetStrValue("repar"), "FREPAR"); }
			finally { if (Model == null) Model = new Models.Repar() { Identifier = "FREPAR" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REPAR]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REPAR]/
		public override void Destroy(string id)
		{
			Model = Models.Repar.Find(id, "FREPAR");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValTipoarea = new SelectList(
				ArrayAreatecn.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValTipoarea);
		}


        /// <summary>
        /// TableEquipRegistnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Repar___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
        {
            bool repar___equipregistnrDoLoad = true;
            CriteriaSet repar___equipregistnrConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("equip", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    repar___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
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
                FillDependant_ReparTableEquipRegistnr(lazyLoad);
                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
                return;
            }


            if (repar___equipregistnrDoLoad)
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
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
                }
                repar___equipregistnrConds.SubSet(search_filters);


                string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_EQUIPREGISTNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
                    repar___equipregistnrConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAequip.FldZzstate, 0)
                        .Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
                else
                    repar___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //repar___equipregistnrConds = Equip.AddEPH<CSGenioAequip>(ref UserContext.Current.User, repar___equipregistnrConds, "LED_REPAR___EQUIPREGISTNR");

                FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
                ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, repar___equipregistnrConds, fields, offset, numberItems, sorts, "LED_REPAR___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

                TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableEquipRegistnr.Query = query;
                TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(r, true, _fieldsToSerialize_REPAR___EQUIPREGISTNR));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
                if(!isSearchRequest)
                    FillDependant_ReparTableEquipRegistnr();

                //Check if foreignkey comes from history
                TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableEquipRegistnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Equip</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ReparTableEquipRegistnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "equip.codequip", "equip.registnr", "equip.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat };
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
        public void FillDependant_ReparTableEquipRegistnr(bool lazyLoad = false)
        {
            var row = GetDependant_ReparTableEquipRegistnr(this.ValCodequip, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["equip.designat"]);
                    this.funcEquipValDesignat = () => tempValue;
                }

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


        private readonly string[] _fieldsToSerialize_REPAR___EQUIPREGISTNR = { "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Equip.ValDesignat", "Equip.ValPhotogra" };

        /// <summary>
        /// TableSpeciEspecial -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Repar___speciespecial(NameValueCollection qs, bool lazyLoad = false)
        {
            bool repar___speciespecialDoLoad = true;
            CriteriaSet repar___speciespecialConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("speci", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    repar___speciespecialConds.Equal(CSGenioAspeci.FldCodespec, Navigation.GetValue("speci"));
                    this.ValCodespec = Navigation.GetStrValue("speci");
                }
            }

			// Limits Generation

				// Limit by field
				repar___speciespecialConds.Equal(
				CSGenio.business.CSGenioAspeci.FldAreatecn,
				this.ValTipoarea);


            TableSpeciEspecial = new TableDBEdit<Models.Speci>();
            TableSpeciEspecial.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
                    this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}
                FillDependant_ReparTableSpeciEspecial(lazyLoad);
                //Check if foreignkey comes from history
                TableSpeciEspecial.FilledByHistory = Navigation.CheckFilledByHistory("speci");
                return;
            }


            if (repar___speciespecialDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableSpeciEspecial, "sTableSpeciEspecial", "dTableSpeciEspecial", qs, "speci");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAspeci.FldEspecial), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableSpeciEspecial_tableFilters"]))
                    TableSpeciEspecial.TableFilters = bool.Parse(qs["TableSpeciEspecial_tableFilters"]);
                else
                    TableSpeciEspecial.TableFilters = false;

                query = qs["qTableSpeciEspecial"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioAspeci.FldEspecial, query + "%");
                }
                repar___speciespecialConds.SubSet(search_filters);


                string tryParsePage = qs["pTableSpeciEspecial"] != null ? qs["pTableSpeciEspecial"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldAreatecn, CSGenioAspeci.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_SPECIESPECIAL]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("speci", FormMode.New) || Navigation.checkFormMode("speci", FormMode.Duplicate))
                    repar___speciespecialConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAspeci.FldZzstate, 0)
                        .Equal(CSGenioAspeci.FldCodespec, Navigation.GetStrValue("speci")));
                else
                    repar___speciespecialConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //repar___speciespecialConds = Speci.AddEPH<CSGenioAspeci>(ref UserContext.Current.User, repar___speciespecialConds, "LED_REPAR___SPECIESPECIAL");

                FieldRef firstVisibleColumn = new FieldRef("speci", "especial");
                ListingMVC<CSGenioAspeci> listing = Models.ModelBase.Where<CSGenioAspeci>(false, repar___speciespecialConds, fields, offset, numberItems, sorts, "LED_REPAR___SPECIESPECIAL", true, false, firstVisibleColumn: firstVisibleColumn);

                TableSpeciEspecial.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableSpeciEspecial.Query = query;
                TableSpeciEspecial.Elements = listing.RowsForViewModel<GenioMVC.Models.Speci>((r) => new GenioMVC.Models.Speci(r, true, _fieldsToSerialize_REPAR___SPECIESPECIAL));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
					this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}

				TableSpeciEspecial.List = new SelectList(TableSpeciEspecial.Elements.ToSelectList(x => x.ValEspecial, x => x.ValCodespec,  x => x.ValCodespec == this.ValCodespec), "Value", "Text", this.ValCodespec);
                if(!isSearchRequest)
                    FillDependant_ReparTableSpeciEspecial();

                //Check if foreignkey comes from history
                TableSpeciEspecial.FilledByHistory = Navigation.CheckFilledByHistory("speci");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableSpeciEspecial (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Speci</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ReparTableSpeciEspecial(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "speci.codespec", "speci.especial", "speci.areatecn" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldAreatecn };
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
            CSGenioAspeci tempArea = new CSGenioAspeci(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAspeci.FldCodespec, PKey));
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
        /// Fill Dependant fields values -> TableSpeciEspecial (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ReparTableSpeciEspecial(bool lazyLoad = false)
        {
            var row = GetDependant_ReparTableSpeciEspecial(this.ValCodespec, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["speci.areatecn"]);
                    this.funcSpeciValAreatecn = () => tempValue;
                }

                // Fill List fields
                this.ValCodespec = ViewModelConversion.ToString(row["speci.codespec"]);
                TableSpeciEspecial.Value = ViewModelConversion.ToString(row["speci.especial"]);
                if (GlobalFunctions.emptyG(this.ValCodespec) == 1)
                {
                    this.ValCodespec = "";
                    TableSpeciEspecial.Value = "";
                    Navigation.ClearValue("speci");
                }
                else if (lazyLoad)
                {
                    TableSpeciEspecial.SetPagination(1, 0, false, false, 1);
                    TableSpeciEspecial.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodespec),
                            Text = Convert.ToString(TableSpeciEspecial.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodespec);
                }
                TableSpeciEspecial.Selected = this.ValCodespec;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSpeciEspecial): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_REPAR___SPECIESPECIAL = { "Speci", "Speci.ValCodespec", "Speci.ValZzstate", "Speci.ValEspecial", "Speci.ValAreatecn" };

        /// <summary>
        /// TablePessoName -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Repar___pessoname____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool repar___pessoname____DoLoad = true;
            CriteriaSet repar___pessoname____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pesso", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    repar___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
                    this.ValCodpesso = Navigation.GetStrValue("pesso");
                }
            }

			// Limits Generation


		//Limit type "V" (N:N)
			string key_speci = Navigation.GetStrValue("speci");
			if(!String.IsNullOrEmpty(key_speci))
			{
				repar___pessoname____Conds.SubSets.Add(GetConditionsToNN(
				CSGenio.business.Area.AreaPESSO,
				CSGenioApesso.FldCodpesso,
				CSGenio.business.Area.AreaESPPE,
				CSGenio.business.Area.AreaSPECI,
				CSGenioAspeci.FldCodespec,
				key_speci,
				null,
				null,
				null,
				false, "LED_REPAR___PESSONAME____"));
			}
			else
				repar___pessoname____DoLoad = false;

            TablePessoName = new TableDBEdit<Models.Pesso>();
            TablePessoName.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
                    this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
                FillDependant_ReparTablePessoName(lazyLoad);
                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
                return;
            }


            if (repar___pessoname____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
                    TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
                else
                    TablePessoName.TableFilters = false;

                query = qs["qTablePessoName"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                bool isSearchRequest = !String.IsNullOrEmpty(query);
                if (isSearchRequest)
                {
					search_filters.Like(CSGenioApesso.FldName, query + "%");
                }
                repar___pessoname____Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_PESSONAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
                    repar___pessoname____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApesso.FldZzstate, 0)
                        .Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
                else
                    repar___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //repar___pessoname____Conds = Pesso.AddEPH<CSGenioApesso>(ref UserContext.Current.User, repar___pessoname____Conds, "LED_REPAR___PESSONAME____");

                FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
                ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(false, repar___pessoname____Conds, fields, offset, numberItems, sorts, "LED_REPAR___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePessoName.Query = query;
                TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(r, true, _fieldsToSerialize_REPAR___PESSONAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
                if(!isSearchRequest)
                    FillDependant_ReparTablePessoName();

                //Check if foreignkey comes from history
                TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pesso</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_ReparTablePessoName(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pesso.codpesso", "pesso.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName };
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
            CSGenioApesso tempArea = new CSGenioApesso(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePessoName (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_ReparTablePessoName(bool lazyLoad = false)
        {
            var row = GetDependant_ReparTablePessoName(this.ValCodpesso, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
                TablePessoName.Value = ViewModelConversion.ToString(row["pesso.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
                {
                    this.ValCodpesso = "";
                    TablePessoName.Value = "";
                    Navigation.ClearValue("pesso");
                }
                else if (lazyLoad)
                {
                    TablePessoName.SetPagination(1, 0, false, false, 1);
                    TablePessoName.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpesso),
                            Text = Convert.ToString(TablePessoName.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpesso);
                }
                TablePessoName.Selected = this.ValCodpesso;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_REPAR___PESSONAME____ = { "Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REPAR]/
		#endregion
	}
}
