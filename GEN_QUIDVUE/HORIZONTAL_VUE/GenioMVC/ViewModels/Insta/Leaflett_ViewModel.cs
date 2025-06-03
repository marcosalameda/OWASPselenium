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
	public class Leaflett_ViewModel : FormViewModel<Models.Insta>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Registration No." | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }

		#endregion
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }
		/// <summary>
		/// Title: "" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
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
		[ValidateSetAccess]
		public decimal? ValHours { get; set; }
		/// <summary>
		/// Title: "Price per hour:" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValPrecohor { get; set; }
		/// <summary>
		/// Title: "Value" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValue { get; set; }
		/// <summary>
		/// Title: "Geographic Coordinates" | Type: "GG"
		/// </summary>
		public string ValCoordgeo { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodinsta { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
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

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLEAFLETT");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

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

		/// <inheritdoc />
		public override void MapFromModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
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
				ValCodinsta = ViewModelConversion.ToString(m.ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Leaflett) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Leaflett) to Model (Insta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValDtiniage = ViewModelConversion.ToDateTime(ValDtiniage);
				m.ValDtfimage = ViewModelConversion.ToDateTime(ValDtfimage);
				m.ValAllday = ViewModelConversion.ToLogic(ValAllday);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValUntil = ViewModelConversion.ToDateTime(ValUntil);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodinsta = ViewModelConversion.ToString(ValCodinsta);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValPrecohor = ViewModelConversion.ToNumeric(ValPrecohor);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Leaflett) to Model (Insta) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "insta.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					case "insta.codtpequ":
						this.ValCodtpequ = ViewModelConversion.ToString(_value);
						break;
					case "insta.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "insta.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "insta.dtiniage":
						this.ValDtiniage = ViewModelConversion.ToDateTime(_value);
						break;
					case "insta.dtfimage":
						this.ValDtfimage = ViewModelConversion.ToDateTime(_value);
						break;
					case "insta.allday":
						this.ValAllday = ViewModelConversion.ToLogic(_value);
						break;
					case "insta.since":
						this.ValSince = ViewModelConversion.ToDateTime(_value);
						break;
					case "insta.until":
						this.ValUntil = ViewModelConversion.ToDateTime(_value);
						break;
					case "insta.coordgeo":
						this.ValCoordgeo = ViewModelConversion.ToString(_value);
						break;
					case "insta.codinsta":
						this.ValCodinsta = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Leaflett) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Leaflett)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Insta.Find(id ?? Navigation.GetStrValue("insta"), m_userContext, "FLEAFLETT"); }
			finally { Model ??= new Models.Insta(m_userContext) { Identifier = "FLEAFLETT" }; }

			base.LoadModel();
		}

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
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FLEAFLETT";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
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

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE LEAFLETT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LEAFLETT]/

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
					leaflettequipregistnrConds.Equal(CSGenioAequip.FldCodequip, hValue);
					this.ValCodequip = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			leaflettequipregistnrDoLoad &= AddCriteriaAreaLimit(leaflettequipregistnrConds, CSGenio.business.CSGenioAtpequ.FldCodtpequ, "tpequ", this.ValCodtpequ, true);

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
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("tpequ");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
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
				if (GenFunctions.emptyG(this.ValCodequip) == 1)
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
				"insta.codequip" => ViewModelConversion.ToString(modelValue),
				"insta.codtpequ" => ViewModelConversion.ToString(modelValue),
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
				"insta.codinsta" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LEAFLETT]/

		#endregion
	}
}
