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

namespace GenioMVC.ViewModels.Equip
{
	public class Groupbx_ViewModel : FormViewModel<Models.Equip>, IPreparableForSerialization
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
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCoddeco { get; set; }
		/// <summary>
		/// Title: "Item:" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodpess1 { get; set; }
		/// <summary>
		/// Title: "Room No." | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodrooms { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "Sequential No.:" | Type: "N"
		/// </summary>
		public decimal? ValSequennr { get; set; }
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValRegistnr { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }
		/// <summary>
		/// Title: "Manufacturer's website:" | Type: "C"
		/// </summary>
		public string ValSitefabr { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }
		/// <summary>
		/// Title: "Item:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemItemdes { get; set; }
		/// <summary>
		/// Title: "Decomission:" | Type: "D"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValDtdeco { get; set; }
		/// <summary>
		/// Title: "Room No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Room1> TableRoom1Roomnr { get; set; }
		/// <summary>
		/// Title: "Room Designation" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string Room1ValDesignat 
		{
			get
			{
				return funcRoom1ValDesignat != null ? funcRoom1ValDesignat() : _auxRoom1ValDesignat;
			}
			set { funcRoom1ValDesignat = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcRoom1ValDesignat { get; set; }

		private string _auxRoom1ValDesignat { get; set; }
		/// <summary>
		/// Title: "Designation:" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }
		/// <summary>
		/// Title: "Acquisition:" | Type: "D"
		/// </summary>
		public DateTime? ValDtaquisi { get; set; }
		/// <summary>
		/// Title: "Total Value:" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValortot { get; set; }
		/// <summary>
		/// Title: "Loan Frequency" | Type: "AN"
		/// </summary>
		public decimal ValFrequenc { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValFrequenc { get; set; }
		/// <summary>
		/// Title: "Reference" | Type: "DT"
		/// </summary>
		public DateTime? ValDtrefere { get; set; }
		/// <summary>
		/// Title: "First" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValFirst { get; set; }
		/// <summary>
		/// Title: "Before" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValBefore { get; set; }
		/// <summary>
		/// Title: "Bought" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValBought { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodequip { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Groupbx_ViewModel() : base(null!) { }

		public Groupbx_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGROUPBX", nestedForm) { }

		public Groupbx_ViewModel(UserContext userContext, Models.Equip row, bool nestedForm = false) : base(userContext, "FGROUPBX", row, nestedForm) { }

		public Groupbx_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, userContext, "FGROUPBX", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip(userContext) { Identifier = "FGROUPBX" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FGROUPBX");
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
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
				ValSitefabr = ViewModelConversion.ToString(m.ValSitefabr);
				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
				funcRoom1ValDesignat = () => ViewModelConversion.ToString(m.Room1.ValDesignat);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
				ValFrequenc = ViewModelConversion.ToNumeric(m.ValFrequenc);
				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
				ValFirst = ViewModelConversion.ToString(m.ValFirst);
				ValBefore = ViewModelConversion.ToString(m.ValBefore);
				ValBought = ViewModelConversion.ToLogic(m.ValBought);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Groupbx) - Error during mapping");
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
		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Groupbx) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValSitefabr = ViewModelConversion.ToString(ValSitefabr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValFrequenc = ViewModelConversion.ToNumeric(ValFrequenc);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
				m.ValBefore = ViewModelConversion.ToString(ValBefore);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Groupbx) to Model (Equip) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "equip.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					case "equip.codtpequ":
						this.ValCodtpequ = ViewModelConversion.ToString(_value);
						break;
					case "equip.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "equip.sequennr":
						this.ValSequennr = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.sitefabr":
						this.ValSitefabr = ViewModelConversion.ToString(_value);
						break;
					case "equip.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "equip.dtaquisi":
						this.ValDtaquisi = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.frequenc":
						this.ValFrequenc = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.dtrefere":
						this.ValDtrefere = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Groupbx) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Groupbx)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Equip.Find(id ?? Navigation.GetStrValue("equip"), m_userContext, "FGROUPBX"); }
			finally { Model ??= new Models.Equip(m_userContext) { Identifier = "FGROUPBX" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGROUPBX");
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

			Model.Identifier = "FGROUPBX";
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
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGROUPBX");
				if (Model == null)
				{
					Model = new Models.Equip(m_userContext) { Identifier = "FGROUPBX" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

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

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValRegistnr", Resources.Resources.REGISTRATION_NO_06209, ValRegistnr, 6);
			validator.StringLength("ValSitefabr", Resources.Resources.MANUFACTURER_S_WEBSI12156, ValSitefabr, 256);
			validator.Hyperlink(Resources.Resources.MANUFACTURER_S_WEBSI12156, ValSitefabr);
			validator.StringLength("Room1ValDesignat", Resources.Resources.ROOM_DESIGNATION35483, Room1ValDesignat, 50);
			validator.StringLength("ValDesignat", Resources.Resources.DESIGNATION_35800, ValDesignat, 85);
			validator.StringLength("ValFirst", Resources.Resources.FIRST42972, ValFirst, 10);
			validator.StringLength("ValBefore", Resources.Resources.BEFORE60156, ValBefore, 10);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE GROUPBX]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GROUPBX]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GROUPBX]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GROUPBX]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, m_userContext, "FGROUPBX");
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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					groupbx_tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, hValue);
					this.ValCodtpequ = DBConversion.ToString(hValue);
				}
			}

			TableTpequTipoequi = new TableDBEdit<Models.Tpequ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
				FillDependant_GroupbxTableTpequTipoequi(lazyLoad);
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
				if (!string.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
					TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
				else
					TableTpequTipoequi.TableFilters = false;

				query = qs["qTableTpequTipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
				}
				groupbx_tpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					groupbx_tpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					groupbx_tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, groupbx_tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_GROUPBX_TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_GROUPBX_TPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_GroupbxTableTpequTipoequi();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_GroupbxTableTpequTipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi];

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

			CSGenioAtpequ tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_GroupbxTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_GroupbxTableTpequTipoequi(this.ValCodtpequ);
			try
			{

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
				TableTpequTipoequi.Value = (string)row["tpequ.tipoequi"];
				if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
					TableTpequTipoequi.Value = "";
					Navigation.ClearValue("tpequ");
				}
				else if (lazyLoad)
				{
					TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
					TableTpequTipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpequTipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpequTipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		public List<TreeNode> Tree_TableTpequTipoequi { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TableTpequTipoequi
		/// </summary>
		public void LoadTree_TableTpequTipoequi(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };
			CriteriaSet subfilters = CriteriaSet.And();


			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ GROUPBX_TPEQUVALTIPOEQUI]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet groupbx_tpequtipoequiConds = CriteriaSet.And();
					{
						bool groupbx_tpequtipoequiDoLoad = true;

						if (!groupbx_tpequtipoequiDoLoad)
							return;
						groupbx_tpequtipoequiConds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioAtpequ>()
					{
						BranchLevel = 0, Area = "TPEQU", Form = "", IsTree = true, IsTreeTable = true,
						KeySelector = CSGenioAtpequ.FldCodtpequ,
						Selector = CSGenioAtpequ.FldTpequcod,
						ParentSelector = CSGenioAtpequ.FldTpequpai,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioAtpequ.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldCodtpequ }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, groupbx_tpequtipoequiConds, currentSelectedKey, "IBL_GROUPBX_TPEQUTIPOEQUI"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TableTpequTipoequi = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_GROUPBX_TPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra"];

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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					groupbx_warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
					this.ValCodwareh = DBConversion.ToString(hValue);
				}
			}

			TableWarehWarehdes = new TableDBEdit<Models.Wareh>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
				FillDependant_GroupbxTableWarehWarehdes(lazyLoad);
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
				if (!string.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
					TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
				else
					TableWarehWarehdes.TableFilters = false;

				query = qs["qTableWarehWarehdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
				}
				groupbx_warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldWarehcod, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					groupbx_warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					groupbx_warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, groupbx_warehwarehdesConds, fields, offset, numberItems, sorts, "LED_GROUPBX_WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_GROUPBX_WAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_GroupbxTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_GroupbxTableWarehWarehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes];

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

			CSGenioAwareh tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_GroupbxTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_GroupbxTableWarehWarehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
				TableWarehWarehdes.Value = (string)row["wareh.warehdes"];
				if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
				{
					this.ValCodwareh = "";
					TableWarehWarehdes.Value = "";
					Navigation.ClearValue("wareh");
				}
				else if (lazyLoad)
				{
					TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
					TableWarehWarehdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodwareh),
							Text = Convert.ToString(TableWarehWarehdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodwareh);
				}

				TableWarehWarehdes.Selected = this.ValCodwareh;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GROUPBX_WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes", "Wareh.ValWarehcod"];

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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					groupbx_item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValCoditem = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			groupbx_item_itemdes_DoLoad &= AddCriteriaAreaLimit(groupbx_item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);

			TableItemItemdes = new TableDBEdit<Models.Item>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
				FillDependant_GroupbxTableItemItemdes(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodwareh))
				groupbx_item_itemdes_DoLoad = false;

			if (groupbx_item_itemdes_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
					TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
				else
					TableItemItemdes.TableFilters = false;

				query = qs["qTableItemItemdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
				}
				groupbx_item_itemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_ITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					groupbx_item_itemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					groupbx_item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, groupbx_item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_GROUPBX_ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemItemdes.Query = query;
				TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_GROUPBX_ITEM_ITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
				FillDependant_GroupbxTableItemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_GroupbxTableItemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes];

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
					wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAitem tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_GroupbxTableItemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_GroupbxTableItemItemdes(this.ValCoditem);
			try
			{

				// Fill List fields
				this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemItemdes.Value = (string)row["item.itemdes"];
				if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
				{
					this.ValCoditem = "";
					TableItemItemdes.Value = "";
					Navigation.ClearValue("item");
				}
				else if (lazyLoad)
				{
					TableItemItemdes.SetPagination(1, 0, false, false, 1);
					TableItemItemdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoditem),
							Text = Convert.ToString(TableItemItemdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoditem);
				}

				TableItemItemdes.Selected = this.ValCoditem;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GROUPBX_ITEM_ITEMDES_ = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod"];

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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					groupbx_room1roomnr__Conds.Equal(CSGenioAroom1.FldCodrooms, hValue);
					this.ValCodrooms = DBConversion.ToString(hValue);
				}
			}

			TableRoom1Roomnr = new TableDBEdit<Models.Room1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}
				FillDependant_GroupbxTableRoom1Roomnr(lazyLoad);
				return;
			}

			if (groupbx_room1roomnr__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRoom1Roomnr, "sTableRoom1Roomnr", "dTableRoom1Roomnr", qs, "room1");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRoom1Roomnr_tableFilters"]))
					TableRoom1Roomnr.TableFilters = bool.Parse(qs["TableRoom1Roomnr_tableFilters"]);
				else
					TableRoom1Roomnr.TableFilters = false;

				query = qs["qTableRoom1Roomnr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAroom1.FldRoomnr, query + "%");
				}
				groupbx_room1roomnr__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRoom1Roomnr"] != null ? qs["pTableRoom1Roomnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldZzstate };

// USE /[MANUAL GQT OVERRQ GROUPBX_ROOM1ROOMNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("room1", FormMode.New) || Navigation.checkFormMode("room1", FormMode.Duplicate))
					groupbx_room1roomnr__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAroom1.FldZzstate, 0)
						.Equal(CSGenioAroom1.FldCodrooms, Navigation.GetStrValue("room1")));
				else
					groupbx_room1roomnr__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAroom1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAroom1> listing = Models.ModelBase.Where<CSGenioAroom1>(m_userContext, false, groupbx_room1roomnr__Conds, fields, offset, numberItems, sorts, "LED_GROUPBX_ROOM1ROOMNR__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRoom1Roomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRoom1Roomnr.Query = query;
				TableRoom1Roomnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Room1>((r) => new GenioMVC.Models.Room1(m_userContext, r, true, _fieldsToSerialize_GROUPBX_ROOM1ROOMNR__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}

				TableRoom1Roomnr.List = new SelectList(TableRoom1Roomnr.Elements.ToSelectList(x => x.ValRoomnr, x => x.ValCodrooms,  x => x.ValCodrooms == this.ValCodrooms), "Value", "Text", this.ValCodrooms);
				FillDependant_GroupbxTableRoom1Roomnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRoom1Roomnr (F1)
		/// </summary>
		/// <param name="PKey">Primary Key of Room1</param>
		public ConcurrentDictionary<string, object> GetDependant_GroupbxTableRoom1Roomnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldDesignat];

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

			CSGenioAroom1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAroom1.FldCodrooms, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRoom1Roomnr (F1)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_GroupbxTableRoom1Roomnr(bool lazyLoad = false)
		{
			var row = GetDependant_GroupbxTableRoom1Roomnr(this.ValCodrooms);
			try
			{
				this.funcRoom1ValDesignat = () => (string)row["room1.designat"];

				// Fill List fields
				this.ValCodrooms = ViewModelConversion.ToString(row["room1.codrooms"]);
				TableRoom1Roomnr.Value = (string)row["room1.roomnr"];
				if (GlobalFunctions.emptyG(this.ValCodrooms) == 1)
				{
					this.ValCodrooms = "";
					TableRoom1Roomnr.Value = "";
					Navigation.ClearValue("room1");
				}
				else if (lazyLoad)
				{
					TableRoom1Roomnr.SetPagination(1, 0, false, false, 1);
					TableRoom1Roomnr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodrooms),
							Text = Convert.ToString(TableRoom1Roomnr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodrooms);
				}

				TableRoom1Roomnr.Selected = this.ValCodrooms;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRoom1Roomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GROUPBX_ROOM1ROOMNR__ = ["Room1", "Room1.ValCodrooms", "Room1.ValZzstate"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"equip.codempre" => ViewModelConversion.ToString(modelValue),
				"equip.coddeco" => ViewModelConversion.ToString(modelValue),
				"equip.coditem" => ViewModelConversion.ToString(modelValue),
				"equip.codpess1" => ViewModelConversion.ToString(modelValue),
				"equip.codrooms" => ViewModelConversion.ToString(modelValue),
				"equip.codtpequ" => ViewModelConversion.ToString(modelValue),
				"equip.codwareh" => ViewModelConversion.ToString(modelValue),
				"equip.sequennr" => ViewModelConversion.ToNumeric(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"equip.sitefabr" => ViewModelConversion.ToString(modelValue),
				"equip.dtdeco" => ViewModelConversion.ToDateTime(modelValue),
				"room1.designat" => ViewModelConversion.ToString(modelValue),
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"equip.dtaquisi" => ViewModelConversion.ToDateTime(modelValue),
				"equip.valortot" => ViewModelConversion.ToNumeric(modelValue),
				"equip.frequenc" => ViewModelConversion.ToNumeric(modelValue),
				"equip.dtrefere" => ViewModelConversion.ToDateTime(modelValue),
				"equip.first" => ViewModelConversion.ToString(modelValue),
				"equip.before" => ViewModelConversion.ToString(modelValue),
				"equip.bought" => ViewModelConversion.ToLogic(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"room1.codrooms" => ViewModelConversion.ToString(modelValue),
				"room1.roomnr" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GROUPBX]/

		#endregion
	}
}
