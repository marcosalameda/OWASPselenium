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

namespace GenioMVC.ViewModels.Visit
{
	public class Visit2_ViewModel : FormViewModel<Models.Visit>, IPreparableForSerialization
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

		#endregion
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Start" | Type: "DT"
		/// </summary>
		public DateTime? ValStartdt { get; set; }
		/// <summary>
		/// Title: "End" | Type: "DT"
		/// </summary>
		public DateTime? ValDtfim { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }
		/// <summary>
		/// Title: "Day" | Type: "L"
		/// </summary>
		public bool ValTodoodia { get; set; }
		/// <summary>
		/// Title: "Color" | Type: "C"
		/// </summary>
		public string ValColor { get; set; }
		/// <summary>
		/// Title: "Background" | Type: "L"
		/// </summary>
		public bool ValBack { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodvisit { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Visit2_ViewModel() : base(null!) { }

		public Visit2_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FVISIT2", nestedForm) { }

		public Visit2_ViewModel(UserContext userContext, Models.Visit row, bool nestedForm = false) : base(userContext, "FVISIT2", row, nestedForm) { }

		public Visit2_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("visit", id);
			Model = Models.Visit.Find(id, userContext, "FVISIT2", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Visit model = new Models.Visit(userContext) { Identifier = "FVISIT2" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FVISIT2");
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
			Models.Visit model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Visit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Visit) to ViewModel (Visit2) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValStartdt = ViewModelConversion.ToDateTime(m.ValStartdt);
				ValDtfim = ViewModelConversion.ToDateTime(m.ValDtfim);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValTodoodia = ViewModelConversion.ToLogic(m.ValTodoodia);
				ValColor = ViewModelConversion.ToString(m.ValColor);
				ValBack = ViewModelConversion.ToLogic(m.ValBack);
				ValCodvisit = ViewModelConversion.ToString(m.ValCodvisit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Visit) to ViewModel (Visit2) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Visit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Visit2) to Model (Visit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValStartdt = ViewModelConversion.ToDateTime(ValStartdt);
				m.ValDtfim = ViewModelConversion.ToDateTime(ValDtfim);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValTodoodia = ViewModelConversion.ToLogic(ValTodoodia);
				m.ValColor = ViewModelConversion.ToString(ValColor);
				m.ValBack = ViewModelConversion.ToLogic(ValBack);
				m.ValCodvisit = ViewModelConversion.ToString(ValCodvisit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Visit2) to Model (Visit) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "visit.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					case "visit.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "visit.startdt":
						this.ValStartdt = ViewModelConversion.ToDateTime(_value);
						break;
					case "visit.dtfim":
						this.ValDtfim = ViewModelConversion.ToDateTime(_value);
						break;
					case "visit.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "visit.todoodia":
						this.ValTodoodia = ViewModelConversion.ToLogic(_value);
						break;
					case "visit.color":
						this.ValColor = ViewModelConversion.ToString(_value);
						break;
					case "visit.back":
						this.ValBack = ViewModelConversion.ToLogic(_value);
						break;
					case "visit.codvisit":
						this.ValCodvisit = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Visit2) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Visit2)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Visit.Find(id ?? Navigation.GetStrValue("visit"), m_userContext, "FVISIT2"); }
			finally { Model ??= new Models.Visit(m_userContext) { Identifier = "FVISIT2" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Visit.Find(Navigation.GetStrValue("visit"), m_userContext, "FVISIT2");
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

			Model.Identifier = "FVISIT2";
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

		protected override void LoadDocumentsProperties(Models.Visit row)
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
				Model = Models.Visit.Find(Navigation.GetStrValue("visit"), m_userContext, "FVISIT2");
				if (Model == null)
				{
					Model = new Models.Visit(m_userContext) { Identifier = "FVISIT2" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("visit");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Visit2__equipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VISIT2]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VISIT2]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 85);
			validator.StringLength("ValColor", Resources.Resources.COLOR55628, ValColor, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE VISIT2]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VISIT2]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VISIT2]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VISIT2]/
		public override void Destroy(string id)
		{
			Model = Models.Visit.Find(id, m_userContext, "FVISIT2");
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
		public void Load_Visit2__equipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool visit2__equipregistnrDoLoad = true;
			CriteriaSet visit2__equipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					visit2__equipregistnrConds.Equal(CSGenioAequip.FldCodequip, hValue);
					this.ValCodequip = DBConversion.ToString(hValue);
				}
			}

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
				FillDependant_Visit2TableEquipRegistnr(lazyLoad);
				return;
			}

			if (visit2__equipregistnrDoLoad)
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
				visit2__equipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ VISIT2_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					visit2__equipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					visit2__equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, visit2__equipregistnrConds, fields, offset, numberItems, sorts, "LED_VISIT2__EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_VISIT2__EQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_Visit2TableEquipRegistnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_Visit2TableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
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
		public void FillDependant_Visit2TableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_Visit2TableEquipRegistnr(this.ValCodequip);
			try
			{

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

		private readonly string[] _fieldsToSerialize_VISIT2__EQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"visit.codequip" => ViewModelConversion.ToString(modelValue),
				"visit.title" => ViewModelConversion.ToString(modelValue),
				"visit.startdt" => ViewModelConversion.ToDateTime(modelValue),
				"visit.dtfim" => ViewModelConversion.ToDateTime(modelValue),
				"visit.descript" => ViewModelConversion.ToString(modelValue),
				"visit.todoodia" => ViewModelConversion.ToLogic(modelValue),
				"visit.color" => ViewModelConversion.ToString(modelValue),
				"visit.back" => ViewModelConversion.ToLogic(modelValue),
				"visit.codvisit" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM VISIT2]/

		#endregion
	}
}
