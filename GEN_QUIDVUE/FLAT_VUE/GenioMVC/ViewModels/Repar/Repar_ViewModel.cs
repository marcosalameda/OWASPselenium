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

namespace GenioMVC.ViewModels.Repar
{
	public class Repar_ViewModel : FormViewModel<Models.Repar>, IPreparableForSerialization
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
		public string ValCodcateg { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "Registration No." | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }
		/// <summary>
		/// Title: "Technician" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }
		/// <summary>
		/// Title: "Specialty" | Type: "CE"
		/// </summary>
		public string ValCodespec { get; set; }

		#endregion
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }
		/// <summary>
		/// Title: "Designation" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string EquipValDesignat 
		{
			get
			{
				return funcEquipValDesignat != null ? funcEquipValDesignat() : _auxEquipValDesignat;
			}
			set { funcEquipValDesignat = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcEquipValDesignat { get; set; }

		private string _auxEquipValDesignat { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel EquipValPhotogra 
		{
			get
			{
				return funcEquipValPhotogra != null ? funcEquipValPhotogra() : _auxEquipValPhotogra;
			}
			set { funcEquipValPhotogra = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.Models.ImageModel> funcEquipValPhotogra { get; set; }

		private GenioMVC.Models.ImageModel _auxEquipValPhotogra { get; set; }
		/// <summary>
		/// Title: "Repaired on" | Type: "DT"
		/// </summary>
		public DateTime? ValDtrepara { get; set; }
		/// <summary>
		/// Title: "Company Repair Number" | Type: "N"
		/// </summary>
		public decimal? ValNrrepara { get; set; }
		/// <summary>
		/// Title: "Technical area" | Type: "AC"
		/// </summary>
		public string ValTipoarea { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValTipoarea { get; set; }
		/// <summary>
		/// Title: "Specialty" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Speci> TableSpeciEspecial { get; set; }
		/// <summary>
		/// Title: "Technician" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }
		/// <summary>
		/// Title: "Repair Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }
		/// <summary>
		/// Title: "Spent in Hours" | Type: "N"
		/// </summary>
		public decimal? ValHours { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the SpeciValAreatecn field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<string> funcSpeciValAreatecn { get; set; }
		private string _auxSpeciValAreatecn { get; set; }
		/// <summary>Field: "Technical area" Tipo: "AC"</summary>
		[ValidateSetAccess]
		public string SpeciValAreatecn { get { return funcSpeciValAreatecn != null ? funcSpeciValAreatecn() : _auxSpeciValAreatecn; } private set { funcSpeciValAreatecn = () => value; } }

		#endregion

		public string ValCodrepar { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Repar_ViewModel() : base(null!) { }

		public Repar_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FREPAR", nestedForm) { }

		public Repar_ViewModel(UserContext userContext, Models.Repar row, bool nestedForm = false) : base(userContext, "FREPAR", row, nestedForm) { }

		public Repar_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("repar", id);
			Model = Models.Repar.Find(id, userContext, "FREPAR", fieldsToQuery: fieldsToLoad);
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
			Models.Repar model = new Models.Repar(userContext) { Identifier = "FREPAR" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FREPAR");
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

		/// <inheritdoc />
		public override void MapFromModel(Models.Repar m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Repar) to ViewModel (Repar) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodespec = ViewModelConversion.ToString(m.ValCodespec);
				funcEquipValDesignat = () => ViewModelConversion.ToString(m.Equip.ValDesignat);
				funcEquipValPhotogra = () => ViewModelConversion.ToImage(m.Equip.ValPhotogra);
				ValDtrepara = ViewModelConversion.ToDateTime(m.ValDtrepara);
				ValNrrepara = ViewModelConversion.ToNumeric(m.ValNrrepara);
				ValTipoarea = ViewModelConversion.ToString(m.ValTipoarea);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValHours = ViewModelConversion.ToNumeric(m.ValHours);
				funcSpeciValAreatecn = () => ViewModelConversion.ToString(m.Speci.ValAreatecn);
				ValCodrepar = ViewModelConversion.ToString(m.ValCodrepar);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Repar) to ViewModel (Repar) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Repar m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Repar) to Model (Repar) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodespec = ViewModelConversion.ToString(ValCodespec);
				m.ValDtrepara = ViewModelConversion.ToDateTime(ValDtrepara);
				m.ValNrrepara = ViewModelConversion.ToNumeric(ValNrrepara);
				m.ValTipoarea = ViewModelConversion.ToString(ValTipoarea);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValCodrepar = ViewModelConversion.ToString(ValCodrepar);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Repar) to Model (Repar) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "repar.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					case "repar.codpesso":
						this.ValCodpesso = ViewModelConversion.ToString(_value);
						break;
					case "repar.codespec":
						this.ValCodespec = ViewModelConversion.ToString(_value);
						break;
					case "repar.dtrepara":
						this.ValDtrepara = ViewModelConversion.ToDateTime(_value);
						break;
					case "repar.nrrepara":
						this.ValNrrepara = ViewModelConversion.ToNumeric(_value);
						break;
					case "repar.tipoarea":
						this.ValTipoarea = ViewModelConversion.ToString(_value);
						break;
					case "repar.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "repar.hours":
						this.ValHours = ViewModelConversion.ToNumeric(_value);
						break;
					case "repar.codrepar":
						this.ValCodrepar = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Repar) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Repar)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Repar.Find(id ?? Navigation.GetStrValue("repar"), m_userContext, "FREPAR"); }
			finally { Model ??= new Models.Repar(m_userContext) { Identifier = "FREPAR" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Repar.Find(Navigation.GetStrValue("repar"), m_userContext, "FREPAR");
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

			Model.Identifier = "FREPAR";
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
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Repar.Find(Navigation.GetStrValue("repar"), m_userContext, "FREPAR");
				if (Model == null)
				{
					Model = new Models.Repar(m_userContext) { Identifier = "FREPAR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("repar");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

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

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("EquipValDesignat", Resources.Resources.DESIGNATION35876, EquipValDesignat, 85);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE REPAR]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REPAR]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REPAR]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REPAR]/
		public override void Destroy(string id)
		{
			Model = Models.Repar.Find(id, m_userContext, "FREPAR");
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
		public void Load_Repar___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool repar___equipregistnrDoLoad = true;
			CriteriaSet repar___equipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					repar___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, hValue);
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
				FillDependant_ReparTableEquipRegistnr(lazyLoad);
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
				repar___equipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					repar___equipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					repar___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, repar___equipregistnrConds, fields, offset, numberItems, sorts, "LED_REPAR___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_REPAR___EQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_ReparTableEquipRegistnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_ReparTableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
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
		public void FillDependant_ReparTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_ReparTableEquipRegistnr(this.ValCodequip);
			try
			{
				this.funcEquipValDesignat = () => (string)row["equip.designat"];
				this.funcEquipValPhotogra = () => (GenioMVC.Models.ImageModel)row["equip.photogra"];

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

		private readonly string[] _fieldsToSerialize_REPAR___EQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Equip.ValDesignat", "Equip.ValPhotogra"];

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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					repar___speciespecialConds.Equal(CSGenioAspeci.FldCodespec, hValue);
					this.ValCodespec = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

				// Limit by field
				repar___speciespecialConds.Equal(
				CSGenio.business.CSGenioAspeci.FldAreatecn,
				this.ValTipoarea);

			TableSpeciEspecial = new TableDBEdit<Models.Speci>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
					this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}
				FillDependant_ReparTableSpeciEspecial(lazyLoad);
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
				if (!string.IsNullOrEmpty(qs["TableSpeciEspecial_tableFilters"]))
					TableSpeciEspecial.TableFilters = bool.Parse(qs["TableSpeciEspecial_tableFilters"]);
				else
					TableSpeciEspecial.TableFilters = false;

				query = qs["qTableSpeciEspecial"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAspeci.FldEspecial, query + "%");
				}
				repar___speciespecialConds.SubSet(search_filters);

				string tryParsePage = qs["pTableSpeciEspecial"] != null ? qs["pTableSpeciEspecial"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldAreatecn, CSGenioAspeci.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_SPECIESPECIAL]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("speci", FormMode.New) || Navigation.checkFormMode("speci", FormMode.Duplicate))
					repar___speciespecialConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAspeci.FldZzstate, 0)
						.Equal(CSGenioAspeci.FldCodespec, Navigation.GetStrValue("speci")));
				else
					repar___speciespecialConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("speci", "especial");
				ListingMVC<CSGenioAspeci> listing = Models.ModelBase.Where<CSGenioAspeci>(m_userContext, false, repar___speciespecialConds, fields, offset, numberItems, sorts, "LED_REPAR___SPECIESPECIAL", true, false, firstVisibleColumn: firstVisibleColumn);

				TableSpeciEspecial.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableSpeciEspecial.Query = query;
				TableSpeciEspecial.Elements = listing.RowsForViewModel<GenioMVC.Models.Speci>((r) => new GenioMVC.Models.Speci(m_userContext, r, true, _fieldsToSerialize_REPAR___SPECIESPECIAL));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_speci") != null)
				{
					this.ValCodespec = Navigation.GetStrValue("RETURN_speci");
					Navigation.CurrentLevel.SetEntry("RETURN_speci", null);
				}

				TableSpeciEspecial.List = new SelectList(TableSpeciEspecial.Elements.ToSelectList(x => x.ValEspecial, x => x.ValCodespec,  x => x.ValCodespec == this.ValCodespec), "Value", "Text", this.ValCodespec);
				FillDependant_ReparTableSpeciEspecial();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableSpeciEspecial (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Speci</param>
		public ConcurrentDictionary<string, object> GetDependant_ReparTableSpeciEspecial(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldAreatecn];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAspeci tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAspeci.FldCodespec, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableSpeciEspecial (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ReparTableSpeciEspecial(bool lazyLoad = false)
		{
			var row = GetDependant_ReparTableSpeciEspecial(this.ValCodespec);
			try
			{
				this.funcSpeciValAreatecn = () => (string)row["speci.areatecn"];

				// Fill List fields
				this.ValCodespec = ViewModelConversion.ToString(row["speci.codespec"]);
				TableSpeciEspecial.Value = (string)row["speci.especial"];
				if (GenFunctions.emptyG(this.ValCodespec) == 1)
				{
					this.ValCodespec = "";
					TableSpeciEspecial.Value = "";
					Navigation.ClearValue("speci");
				}
				else if (lazyLoad)
				{
					TableSpeciEspecial.SetPagination(1, 0, false, false, 1);
					TableSpeciEspecial.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodespec),
							Text = Convert.ToString(TableSpeciEspecial.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodespec);
				}

				TableSpeciEspecial.Selected = this.ValCodespec;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSpeciEspecial): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_REPAR___SPECIESPECIAL = ["Speci", "Speci.ValCodespec", "Speci.ValZzstate", "Speci.ValEspecial", "Speci.ValAreatecn"];

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
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					repar___pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, hValue);
					this.ValCodpesso = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation


			//Limit type "V" (N:N)
			string key_speci = Navigation.GetStrValue("speci");
			if (!string.IsNullOrEmpty(key_speci))
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

			TablePessoName = new TableDBEdit<Models.Pesso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
				FillDependant_ReparTablePessoName(lazyLoad);
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
				if (!string.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
					TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
				else
					TablePessoName.TableFilters = false;

				query = qs["qTablePessoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApesso.FldName, query + "%");
				}
				repar___pessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ REPAR_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					repar___pessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					repar___pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, repar___pessoname____Conds, fields, offset, numberItems, sorts, "LED_REPAR___PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_REPAR___PESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_ReparTablePessoName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_ReparTablePessoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApesso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ReparTablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_ReparTablePessoName(this.ValCodpesso);
			try
			{

				// Fill List fields
				this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
				TablePessoName.Value = (string)row["pesso.name"];
				if (GenFunctions.emptyG(this.ValCodpesso) == 1)
				{
					this.ValCodpesso = "";
					TablePessoName.Value = "";
					Navigation.ClearValue("pesso");
				}
				else if (lazyLoad)
				{
					TablePessoName.SetPagination(1, 0, false, false, 1);
					TablePessoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpesso),
							Text = Convert.ToString(TablePessoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpesso);
				}

				TablePessoName.Selected = this.ValCodpesso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_REPAR___PESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"repar.codcateg" => ViewModelConversion.ToString(modelValue),
				"repar.codempre" => ViewModelConversion.ToString(modelValue),
				"repar.codequip" => ViewModelConversion.ToString(modelValue),
				"repar.codpesso" => ViewModelConversion.ToString(modelValue),
				"repar.codespec" => ViewModelConversion.ToString(modelValue),
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"equip.photogra" => ViewModelConversion.ToImage(modelValue),
				"repar.dtrepara" => ViewModelConversion.ToDateTime(modelValue),
				"repar.nrrepara" => ViewModelConversion.ToNumeric(modelValue),
				"repar.tipoarea" => ViewModelConversion.ToString(modelValue),
				"repar.descript" => ViewModelConversion.ToString(modelValue),
				"repar.hours" => ViewModelConversion.ToNumeric(modelValue),
				"speci.areatecn" => ViewModelConversion.ToString(modelValue),
				"repar.codrepar" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"speci.codespec" => ViewModelConversion.ToString(modelValue),
				"speci.especial" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (EquipValPhotogra != null)
				EquipValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, ValCodequip);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REPAR]/

		#endregion
	}
}
