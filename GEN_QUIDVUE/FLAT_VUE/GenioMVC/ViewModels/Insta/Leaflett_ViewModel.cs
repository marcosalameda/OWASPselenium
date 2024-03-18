using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Insta
{
	public class Leaflett_ViewModel : FormViewModel<Models.Insta>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }

		/// <summary>
		/// Title: "" | Type: "C"
		/// </summary>
		public string TpequValTipoequi 
		{
			get
			{
				return funcTpequValTipoequi != null ? funcTpequValTipoequi() : _auxTpequValTipoequi;
			}
			set { funcTpequValTipoequi = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcTpequValTipoequi { get; set; }

		private string _auxTpequValTipoequi { get; set; }

		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }

		/// <summary>
		/// Title: "Scheduling" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }

		/// <summary>
		/// Title: "Start" | Type: "DT"
		/// </summary>
		public DateTime? ValDtiniage { get; set; }

		/// <summary>
		/// Title: "End" | Type: "DT"
		/// </summary>
		public DateTime? ValDtfimage { get; set; }

		/// <summary>
		/// Title: "All day" | Type: "L"
		/// </summary>
		public bool ValAllday { get; set; }

		/// <summary>
		/// Title: "Since" | Type: "DT"
		/// </summary>
		public DateTime? ValSince { get; set; }

		/// <summary>
		/// Title: "Until" | Type: "DT"
		/// </summary>
		public DateTime? ValUntil { get; set; }

		/// <summary>
		/// Title: "Quantity of hours:" | Type: "N"
		/// </summary>
		public decimal? ValHours { get; set; }

		/// <summary>
		/// Title: "Price per hour:" | Type: "$D"
		/// </summary>
		public decimal? ValPrecohor { get; set; }

		/// <summary>
		/// Title: "Value" | Type: "$D"
		/// </summary>
		public decimal? ValValue { get; set; }

		/// <summary>
		/// Title: "Geographic Coordinates" | Type: "GG"
		/// </summary>
		public string ValCoordgeo { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Registration No." | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodinsta { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Leaflett_ViewModel() : base(null!) { }

		public Leaflett_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLEAFLETT", nestedForm) { }

		public Leaflett_ViewModel(UserContext userContext, Models.Insta row, bool nestedForm = false) : base(userContext, "FLEAFLETT", row, nestedForm) { }

		public Leaflett_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("insta", id);
			Model = Models.Insta.Find(id, userContext, "FLEAFLETT", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Insta model = new Models.Insta(userContext) { Identifier = "FLEAFLETT" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Insta model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				funcTpequValTipoequi = () => ViewModelConversion.ToString(m.Tpequ.ValTipoequi);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValDtiniage = ViewModelConversion.ToDateTime(m.ValDtiniage);
				ValDtfimage = ViewModelConversion.ToDateTime(m.ValDtfimage);
				ValAllday = ViewModelConversion.ToLogic(m.ValAllday);
				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
				ValUntil = ViewModelConversion.ToDateTime(m.ValUntil);
				ValHours = ViewModelConversion.ToNumeric(m.ValHours);
				ValPrecohor = ViewModelConversion.ToNumeric(m.ValPrecohor);
				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodinsta = ViewModelConversion.ToString(m.ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Leaflett) to Model (Insta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValDtiniage = ViewModelConversion.ToDateTime(ValDtiniage);
				m.ValDtfimage = ViewModelConversion.ToDateTime(ValDtfimage);
				m.ValAllday = ViewModelConversion.ToLogic(ValAllday);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValUntil = ViewModelConversion.ToDateTime(ValUntil);
				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValPrecohor = ViewModelConversion.ToNumeric(ValPrecohor);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodinsta = ViewModelConversion.ToString(ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Leaflett) to Model (Insta) - Error during mapping");
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
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FLEAFLETT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FLEAFLETT";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Insta row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FLEAFLETT");
				if (Model == null)
				{
					Model = new Models.Insta(m_userContext) { Identifier = "FLEAFLETT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("insta");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Leaflettequipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LEAFLETT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LEAFLETT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("TpequValTipoequi", "TpequValTipoequi", TpequValTipoequi, 50);
			validator.StringLength("ValDesignat", Resources.Resources.SCHEDULING24801, ValDesignat, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE LEAFLETT]/
		public override void Save()
		{

			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FLEAFLETT"); }
			finally { if (Model == null) Model = new Models.Insta(m_userContext) { Identifier = "FLEAFLETT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LEAFLETT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FLEAFLETT"); }
			finally { if (Model == null) Model = new Models.Insta(m_userContext) { Identifier = "FLEAFLETT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LEAFLETT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LEAFLETT]/
		public override void Destroy(string id)
		{
			Model = Models.Insta.Find(id, m_userContext, "FLEAFLETT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableEquipRegistnr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Leaflettequipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool leaflettequipregistnrDoLoad = true;
			CriteriaSet leaflettequipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					leaflettequipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
					this.ValCodequip = Navigation.GetStrValue("equip");
				}
			}
			// Limits Generation

			// Area limit
			leaflettequipregistnrDoLoad &= AddCriteriaAreaLimit(leaflettequipregistnrConds, CSGenio.business.CSGenioAtpequ.FldCodtpequ, "tpequ", this.ValCodtpequ, false);

			TableEquipRegistnr = new TableDBEdit<Models.Equip>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
				FillDependant_LeaflettTableEquipRegistnr(lazyLoad);
				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodtpequ))
				leaflettequipregistnrDoLoad = false;

			if (leaflettequipregistnrDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEquipRegistnr_tableFilters"]))
					TableEquipRegistnr.TableFilters = bool.Parse(qs["TableEquipRegistnr_tableFilters"]);
				else
					TableEquipRegistnr.TableFilters = false;

				query = qs["qTableEquipRegistnr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
				}
				leaflettequipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ LEAFLETT_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					leaflettequipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					leaflettequipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, leaflettequipregistnrConds, fields, offset, numberItems, sorts, "LED_LEAFLETTEQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_LEAFLETTEQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_LeaflettTableEquipRegistnr();

				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_LeaflettTableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("tpequ");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAequip.FldCodtpequ, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAequip tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAequip.FldCodequip, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LeaflettTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_LeaflettTableEquipRegistnr(this.ValCodequip);
			try
			{
				this.ValCodtpequ = (string)row["tpequ.codtpequ"];
				this.funcTpequValTipoequi = () => (string)row["tpequ.tipoequi"];

				// Fill List fields
				this.ValCodequip = ViewModelConversion.ToString(row["equip.codequip"]);
				TableEquipRegistnr.Value = (string)row["equip.registnr"];
				if (GlobalFunctions.emptyG(this.ValCodequip) == 1)
				{
					this.ValCodequip = "";
					TableEquipRegistnr.Value = "";
					Navigation.ClearValue("equip");
				}
				else if (lazyLoad)
				{
					TableEquipRegistnr.SetPagination(1, 0, false, false, 1);
					TableEquipRegistnr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodequip),
							Text = Convert.ToString(TableEquipRegistnr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodequip);
				}

				TableEquipRegistnr.Selected = this.ValCodequip;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEquipRegistnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LEAFLETTEQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"insta.descript" => ViewModelConversion.ToString(modelValue),
				"insta.designat" => ViewModelConversion.ToString(modelValue),
				"insta.dtiniage" => ViewModelConversion.ToDateTime(modelValue),
				"insta.dtfimage" => ViewModelConversion.ToDateTime(modelValue),
				"insta.allday" => ViewModelConversion.ToLogic(modelValue),
				"insta.since" => ViewModelConversion.ToDateTime(modelValue),
				"insta.until" => ViewModelConversion.ToDateTime(modelValue),
				"insta.hours" => ViewModelConversion.ToNumeric(modelValue),
				"insta.precohor" => ViewModelConversion.ToNumeric(modelValue),
				"insta.value" => ViewModelConversion.ToNumeric(modelValue),
				"insta.coordgeo" => ViewModelConversion.ToString(modelValue),
				"insta.codequip" => ViewModelConversion.ToString(modelValue),
				"insta.codtpequ" => ViewModelConversion.ToString(modelValue),
				"insta.codinsta" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LEAFLETT]/

		#endregion
	}
}
