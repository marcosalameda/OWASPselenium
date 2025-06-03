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

namespace GenioMVC.ViewModels.Lendi
{
	public class Comod_ViewModel : FormViewModel<Models.Lendi>, IPreparableForSerialization
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
		/// Title: "Lending" | Type: "CE"
		/// </summary>
		public string ValCodpess1 { get; set; }
		/// <summary>
		/// Title: "Borrower:" | Type: "CE"
		/// </summary>
		public string ValCodpess2 { get; set; }

		#endregion
		/// <summary>
		/// Title: "Lending" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess1> TablePess1Name { get; set; }
		/// <summary>
		/// Title: "Borrower:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess2> TablePess2Name { get; set; }
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }
		/// <summary>
		/// Title: "Equipment" | Type: "C"
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
		/// Title: "Loan Frequency" | Type: "AN"
		/// </summary>
		[ValidateSetAccess]
		public decimal EquipValFrequenc 
		{
			get
			{
				return funcEquipValFrequenc != null ? funcEquipValFrequenc() : _auxEquipValFrequenc;
			}
			set { funcEquipValFrequenc = () => value; }
		}

		[JsonIgnore]
		public Func<decimal> funcEquipValFrequenc { get; set; }

		private decimal _auxEquipValFrequenc { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_EquipValFrequenc { get; set; }
		/// <summary>
		/// Title: "Lending No" | Type: "N"
		/// </summary>
		public decimal? ValLendinnr { get; set; }
		/// <summary>
		/// Title: "Start:" | Type: "DT"
		/// </summary>
		public DateTime? ValStart { get; set; }
		/// <summary>
		/// Title: "Warning" | Type: "DT"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValWarndt { get; set; }
		/// <summary>
		/// Title: "End" | Type: "DT"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValEnd { get; set; }
		/// <summary>
		/// Title: "Observation" | Type: "MO"
		/// </summary>
		public string ValObservat { get; set; }
		/// <summary>
		/// Title: "Returned" | Type: "D"
		/// </summary>
		public DateTime? ValReturndt { get; set; }
		/// <summary>
		/// Title: "Returned" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValReturned { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodlendi { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Comod_ViewModel() : base(null!) { }

		public Comod_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCOMOD", nestedForm) { }

		public Comod_ViewModel(UserContext userContext, Models.Lendi row, bool nestedForm = false) : base(userContext, "FCOMOD", row, nestedForm) { }

		public Comod_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("lendi", id);
			Model = Models.Lendi.Find(id, userContext, "FCOMOD", fieldsToQuery: fieldsToLoad);
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
			Models.Lendi model = new Models.Lendi(userContext) { Identifier = "FCOMOD" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCOMOD");
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
			Models.Lendi model = Model;
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
		public override void MapFromModel(Models.Lendi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (Comod) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodpess2 = ViewModelConversion.ToString(m.ValCodpess2);
				funcEquipValDesignat = () => ViewModelConversion.ToString(m.Equip.ValDesignat);
				funcEquipValFrequenc = () => ViewModelConversion.ToNumeric(m.Equip.ValFrequenc);
				ValLendinnr = ViewModelConversion.ToNumeric(m.ValLendinnr);
				ValStart = ViewModelConversion.ToDateTime(m.ValStart);
				ValWarndt = ViewModelConversion.ToDateTime(m.ValWarndt);
				ValEnd = ViewModelConversion.ToDateTime(m.ValEnd);
				ValObservat = ViewModelConversion.ToString(m.ValObservat);
				ValReturndt = ViewModelConversion.ToDateTime(m.ValReturndt);
				ValReturned = ViewModelConversion.ToLogic(m.ValReturned);
				ValCodlendi = ViewModelConversion.ToString(m.ValCodlendi);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (Comod) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lendi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Comod) to Model (Lendi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodpess2 = ViewModelConversion.ToString(ValCodpess2);
				m.ValLendinnr = ViewModelConversion.ToNumeric(ValLendinnr);
				m.ValStart = ViewModelConversion.ToDateTime(ValStart);
				m.ValObservat = ViewModelConversion.ToString(ValObservat);
				m.ValReturndt = ViewModelConversion.ToDateTime(ValReturndt);
				m.ValCodlendi = ViewModelConversion.ToString(ValCodlendi);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValWarndt = ViewModelConversion.ToDateTime(ValWarndt);
				m.ValEnd = ViewModelConversion.ToDateTime(ValEnd);
				m.ValReturned = ViewModelConversion.ToLogic(ValReturned);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Comod) to Model (Lendi) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "lendi.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					case "lendi.codpess1":
						this.ValCodpess1 = ViewModelConversion.ToString(_value);
						break;
					case "lendi.codpess2":
						this.ValCodpess2 = ViewModelConversion.ToString(_value);
						break;
					case "lendi.lendinnr":
						this.ValLendinnr = ViewModelConversion.ToNumeric(_value);
						break;
					case "lendi.start":
						this.ValStart = ViewModelConversion.ToDateTime(_value);
						break;
					case "lendi.observat":
						this.ValObservat = ViewModelConversion.ToString(_value);
						break;
					case "lendi.returndt":
						this.ValReturndt = ViewModelConversion.ToDateTime(_value);
						break;
					case "lendi.codlendi":
						this.ValCodlendi = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Comod) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Comod)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Lendi.Find(id ?? Navigation.GetStrValue("lendi"), m_userContext, "FCOMOD"); }
			finally { Model ??= new Models.Lendi(m_userContext) { Identifier = "FCOMOD" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), m_userContext, "FCOMOD");
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

			Model.Identifier = "FCOMOD";
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

		protected override void LoadDocumentsProperties(Models.Lendi row)
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
				Model = Models.Lendi.Find(Navigation.GetStrValue("lendi"), m_userContext, "FCOMOD");
				if (Model == null)
				{
					Model = new Models.Lendi(m_userContext) { Identifier = "FCOMOD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lendi");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Comod___pess1name____(qs, lazyLoad);
			Load_Comod___pess2name____(qs, lazyLoad);
			Load_Comod___equipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL COMOD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW COMOD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodequip", Resources.Resources.REGISTRATION_NO_06209, ViewModelConversion.ToString(ValCodequip), FieldType.KEY_GUID.GetFormatting());
			validator.StringLength("EquipValDesignat", Resources.Resources.EQUIPMENT03632, EquipValDesignat, 85);

			validator.Required("ValStart", Resources.Resources.START_59353, ViewModelConversion.ToDateTime(ValStart), FieldType.DATETIME.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE COMOD]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY COMOD]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE COMOD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY COMOD]/
		public override void Destroy(string id)
		{
			Model = Models.Lendi.Find(id, m_userContext, "FCOMOD");
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
		/// TablePess1Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Comod___pess1name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool comod___pess1name____DoLoad = true;
			CriteriaSet comod___pess1name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					comod___pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, hValue);
					this.ValCodpess1 = DBConversion.ToString(hValue);
				}
			}

			TablePess1Name = new TableDBEdit<Models.Pess1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
				FillDependant_ComodTablePess1Name(lazyLoad);
				return;
			}

			if (comod___pess1name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
					TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
				else
					TablePess1Name.TableFilters = false;

				query = qs["qTablePess1Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess1.FldName, query + "%");
				}
				comod___pess1name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_PESS1NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
					comod___pess1name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess1.FldZzstate, 0)
						.Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
				else
					comod___pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, false, comod___pess1name____Conds, fields, offset, numberItems, sorts, "LED_COMOD___PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess1Name.Query = query;
				TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(m_userContext, r, true, _fieldsToSerialize_COMOD___PESS1NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
				FillDependant_ComodTablePess1Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess1</param>
		public ConcurrentDictionary<string, object> GetDependant_ComodTablePess1Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName];

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

			CSGenioApess1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ComodTablePess1Name(bool lazyLoad = false)
		{
			var row = GetDependant_ComodTablePess1Name(this.ValCodpess1);
			try
			{

				// Fill List fields
				this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
				TablePess1Name.Value = (string)row["pess1.name"];
				if (GenFunctions.emptyG(this.ValCodpess1) == 1)
				{
					this.ValCodpess1 = "";
					TablePess1Name.Value = "";
					Navigation.ClearValue("pess1");
				}
				else if (lazyLoad)
				{
					TablePess1Name.SetPagination(1, 0, false, false, 1);
					TablePess1Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpess1),
							Text = Convert.ToString(TablePess1Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpess1);
				}

				TablePess1Name.Selected = this.ValCodpess1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_COMOD___PESS1NAME____ = ["Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName"];

		/// <summary>
		/// TablePess2Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Comod___pess2name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool comod___pess2name____DoLoad = true;
			CriteriaSet comod___pess2name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess2", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					comod___pess2name____Conds.Equal(CSGenioApess2.FldCodpesso, hValue);
					this.ValCodpess2 = DBConversion.ToString(hValue);
				}
			}

			TablePess2Name = new TableDBEdit<Models.Pess2>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpess2 = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}
				FillDependant_ComodTablePess2Name(lazyLoad);
				return;
			}

			if (comod___pess2name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePess2Name, "sTablePess2Name", "dTablePess2Name", qs, "pess2");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess2.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess2Name_tableFilters"]))
					TablePess2Name.TableFilters = bool.Parse(qs["TablePess2Name_tableFilters"]);
				else
					TablePess2Name.TableFilters = false;

				query = qs["qTablePess2Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess2.FldName, query + "%");
				}
				comod___pess2name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePess2Name"] != null ? qs["pTablePess2Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioApess2.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_PESS2NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess2", FormMode.New) || Navigation.checkFormMode("pess2", FormMode.Duplicate))
					comod___pess2name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess2.FldZzstate, 0)
						.Equal(CSGenioApess2.FldCodpesso, Navigation.GetStrValue("pess2")));
				else
					comod___pess2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess2.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess2", "name");
				ListingMVC<CSGenioApess2> listing = Models.ModelBase.Where<CSGenioApess2>(m_userContext, false, comod___pess2name____Conds, fields, offset, numberItems, sorts, "LED_COMOD___PESS2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess2Name.Query = query;
				TablePess2Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess2>((r) => new GenioMVC.Models.Pess2(m_userContext, r, true, _fieldsToSerialize_COMOD___PESS2NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpess2 = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}

				TablePess2Name.List = new SelectList(TablePess2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess2), "Value", "Text", this.ValCodpess2);
				FillDependant_ComodTablePess2Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess2Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess2</param>
		public ConcurrentDictionary<string, object> GetDependant_ComodTablePess2Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess2.FldCodpesso, CSGenioApess2.FldName];

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

			CSGenioApess2 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess2.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess2Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ComodTablePess2Name(bool lazyLoad = false)
		{
			var row = GetDependant_ComodTablePess2Name(this.ValCodpess2);
			try
			{

				// Fill List fields
				this.ValCodpess2 = ViewModelConversion.ToString(row["pess2.codpesso"]);
				TablePess2Name.Value = (string)row["pess2.name"];
				if (GenFunctions.emptyG(this.ValCodpess2) == 1)
				{
					this.ValCodpess2 = "";
					TablePess2Name.Value = "";
					Navigation.ClearValue("pess2");
				}
				else if (lazyLoad)
				{
					TablePess2Name.SetPagination(1, 0, false, false, 1);
					TablePess2Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpess2),
							Text = Convert.ToString(TablePess2Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpess2);
				}

				TablePess2Name.Selected = this.ValCodpess2;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_COMOD___PESS2NAME____ = ["Pess2", "Pess2.ValCodpesso", "Pess2.ValZzstate", "Pess2.ValName"];

		/// <summary>
		/// TableEquipRegistnr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Comod___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool comod___equipregistnrDoLoad = true;
			CriteriaSet comod___equipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					comod___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, hValue);
					this.ValCodequip = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			comod___equipregistnrDoLoad &= AddCriteriaAreaLimit(comod___equipregistnrConds, CSGenio.business.CSGenioApess1.FldCodpesso, "pess1", this.ValCodpess1, true);

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
				FillDependant_ComodTableEquipRegistnr(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodpess1))
				comod___equipregistnrDoLoad = false;

			if (comod___equipregistnrDoLoad)
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
				comod___equipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAtpequ.FldTipoequi, CSGenioAequip.FldDesignat, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldDtdeco, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ COMOD_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					comod___equipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					comod___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, comod___equipregistnrConds, fields, offset, numberItems, sorts, "LED_COMOD___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_COMOD___EQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_ComodTableEquipRegistnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_ComodTableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldFrequenc];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("pess1");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAequip.FldCodpess1, hValue);
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
		public void FillDependant_ComodTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_ComodTableEquipRegistnr(this.ValCodequip);
			try
			{
				this.funcEquipValDesignat = () => (string)row["equip.designat"];
				this.funcEquipValFrequenc = () => (decimal)row["equip.frequenc"];

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

		private readonly string[] _fieldsToSerialize_COMOD___EQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr", "Tpequ", "Tpequ.ValTipoequi", "Equip.ValDesignat", "Equip.ValDtaquisi", "Equip.ValDtdeco", "Equip.ValPhotogra", "Equip.ValValortot"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"lendi.codequip" => ViewModelConversion.ToString(modelValue),
				"lendi.codpess1" => ViewModelConversion.ToString(modelValue),
				"lendi.codpess2" => ViewModelConversion.ToString(modelValue),
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"equip.frequenc" => ViewModelConversion.ToNumeric(modelValue),
				"lendi.lendinnr" => ViewModelConversion.ToNumeric(modelValue),
				"lendi.start" => ViewModelConversion.ToDateTime(modelValue),
				"lendi.warndt" => ViewModelConversion.ToDateTime(modelValue),
				"lendi.end" => ViewModelConversion.ToDateTime(modelValue),
				"lendi.observat" => ViewModelConversion.ToString(modelValue),
				"lendi.returndt" => ViewModelConversion.ToDateTime(modelValue),
				"lendi.returned" => ViewModelConversion.ToLogic(modelValue),
				"lendi.codlendi" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				"pess2.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess2.name" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM COMOD]/

		#endregion
	}
}
