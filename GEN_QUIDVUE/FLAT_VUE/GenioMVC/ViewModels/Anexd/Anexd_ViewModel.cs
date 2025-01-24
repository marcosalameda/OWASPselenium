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

namespace GenioMVC.ViewModels.Anexd
{
	public class Anexd_ViewModel : FormViewModel<Models.Anexd>, IPreparableForSerialization
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
		/// Title: "No. register" | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "CE"
		/// </summary>
		public string ValCodlang { get; set; }

		#endregion
		/// <summary>
		/// Title: "No. register" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }
		/// <summary>
		/// Title: "Attached" | Type: "DT"
		/// </summary>
		public DateTime? ValDthranex { get; set; }
		/// <summary>
		/// Title: "Reference" | Type: "C"
		/// </summary>
		public string ValReferenc { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Langu> TableLanguLangua { get; set; }
		/// <summary>
		/// Title: "Translated Title" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValTittradu { get; set; }
		/// <summary>
		/// Title: "Document" | Type: "IB"
		/// </summary>
		[Document("ValDocument", true, false, false, DocumentViewTypeMode.Preview)]
		public string ValDocument { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValDocumentfk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValDocumentPropertiesVM { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodanexd { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Anexd_ViewModel() : base(null!) { }

		public Anexd_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FANEXD", nestedForm) { }

		public Anexd_ViewModel(UserContext userContext, Models.Anexd row, bool nestedForm = false) : base(userContext, "FANEXD", row, nestedForm) { }

		public Anexd_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("anexd", id);
			Model = Models.Anexd.Find(id, userContext, "FANEXD", fieldsToQuery: fieldsToLoad);
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
			Models.Anexd model = new Models.Anexd(userContext) { Identifier = "FANEXD" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FANEXD");
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
			Models.Anexd model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Anexd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Anexd) to ViewModel (Anexd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodlang = ViewModelConversion.ToString(m.ValCodlang);
				ValDthranex = ViewModelConversion.ToDateTime(m.ValDthranex);
				ValReferenc = ViewModelConversion.ToString(m.ValReferenc);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValTittradu = ViewModelConversion.ToString(m.ValTittradu);
				ValDocument = ViewModelConversion.ToString(m.ValDocument);
				ValDocumentfk = ViewModelConversion.ToString(m.ValDocumentfk);
				ValCodanexd = ViewModelConversion.ToString(m.ValCodanexd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Anexd) to ViewModel (Anexd) - Error during mapping");
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
		public override void MapToModel(Models.Anexd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Anexd) to Model (Anexd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodlang = ViewModelConversion.ToString(ValCodlang);
				m.ValDthranex = ViewModelConversion.ToDateTime(ValDthranex);
				m.ValReferenc = ViewModelConversion.ToString(ValReferenc);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValDocument = ViewModelConversion.ToString(ValDocument);
				m.ValDocumentfk = ViewModelConversion.ToString(ValDocumentfk);
				m.ValCodanexd = ViewModelConversion.ToString(ValCodanexd);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValTittradu = ViewModelConversion.ToString(ValTittradu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Anexd) to Model (Anexd) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "anexd.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					case "anexd.codlang":
						this.ValCodlang = ViewModelConversion.ToString(_value);
						break;
					case "anexd.dthranex":
						this.ValDthranex = ViewModelConversion.ToDateTime(_value);
						break;
					case "anexd.referenc":
						this.ValReferenc = ViewModelConversion.ToString(_value);
						break;
					case "anexd.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "anexd.document":
						this.ValDocument = ViewModelConversion.ToString(_value);
						break;
					case "anexd.codanexd":
						this.ValCodanexd = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Anexd) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Anexd)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Anexd.Find(id ?? Navigation.GetStrValue("anexd"), m_userContext, "FANEXD"); }
			finally { Model ??= new Models.Anexd(m_userContext) { Identifier = "FANEXD" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), m_userContext, "FANEXD");
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

			Model.Identifier = "FANEXD";
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

		protected override void LoadDocumentsProperties(Models.Anexd row)
		{
			try
			{
				ValDocumentPropertiesVM = row.GetInfoDoc("ValDocument");
			}
			catch (Exception)
			{
				ValDocumentPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
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
				Model = Models.Anexd.Find(Navigation.GetStrValue("anexd"), m_userContext, "FANEXD");
				if (Model == null)
				{
					Model = new Models.Anexd(m_userContext) { Identifier = "FANEXD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("anexd");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Anexd___equipregistnr(qs, lazyLoad);
			Load_Anexd___langulangua__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ANEXD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ANEXD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValReferenc", Resources.Resources.REFERENCE28402, ValReferenc, 50);
			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 85);
			validator.StringLength("ValTittradu", Resources.Resources.TRANSLATED_TITLE04469, ValTittradu, 85);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ANEXD]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ANEXD]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ANEXD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ANEXD]/
		public override void Destroy(string id)
		{
			Model = Models.Anexd.Find(id, m_userContext, "FANEXD");
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
		public void Load_Anexd___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool anexd___equipregistnrDoLoad = true;
			CriteriaSet anexd___equipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					anexd___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, hValue);
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
				FillDependant_AnexdTableEquipRegistnr(lazyLoad);
				return;
			}

			if (anexd___equipregistnrDoLoad)
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
				anexd___equipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ ANEXD_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					anexd___equipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					anexd___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, anexd___equipregistnrConds, fields, offset, numberItems, sorts, "LED_ANEXD___EQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_ANEXD___EQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_AnexdTableEquipRegistnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_AnexdTableEquipRegistnr(string PKey)
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
		public void FillDependant_AnexdTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_AnexdTableEquipRegistnr(this.ValCodequip);
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

		private readonly string[] _fieldsToSerialize_ANEXD___EQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr"];

		/// <summary>
		/// TableLanguLangua -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Anexd___langulangua__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool anexd___langulangua__DoLoad = true;
			CriteriaSet anexd___langulangua__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("langu", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					anexd___langulangua__Conds.Equal(CSGenioAlangu.FldCodlang, hValue);
					this.ValCodlang = DBConversion.ToString(hValue);
				}
			}

			TableLanguLangua = new TableDBEdit<Models.Langu>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_langu") != null)
				{
					this.ValCodlang = Navigation.GetStrValue("RETURN_langu");
					Navigation.CurrentLevel.SetEntry("RETURN_langu", null);
				}
				FillDependant_AnexdTableLanguLangua(lazyLoad);
				return;
			}

			if (anexd___langulangua__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableLanguLangua, "sTableLanguLangua", "dTableLanguLangua", qs, "langu");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlangu.FldLangua), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLanguLangua_tableFilters"]))
					TableLanguLangua.TableFilters = bool.Parse(qs["TableLanguLangua_tableFilters"]);
				else
					TableLanguLangua.TableFilters = false;

				query = qs["qTableLanguLangua"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlangu.FldLangua, query + "%");
				}
				anexd___langulangua__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLanguLangua"] != null ? qs["pTableLanguLangua"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua, CSGenioAlangu.FldZzstate };

// USE /[MANUAL GQT OVERRQ ANEXD_LANGULANGUA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("langu", FormMode.New) || Navigation.checkFormMode("langu", FormMode.Duplicate))
					anexd___langulangua__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlangu.FldZzstate, 0)
						.Equal(CSGenioAlangu.FldCodlang, Navigation.GetStrValue("langu")));
				else
					anexd___langulangua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlangu.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("langu", "langua");
				ListingMVC<CSGenioAlangu> listing = Models.ModelBase.Where<CSGenioAlangu>(m_userContext, false, anexd___langulangua__Conds, fields, offset, numberItems, sorts, "LED_ANEXD___LANGULANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLanguLangua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLanguLangua.Query = query;
				TableLanguLangua.Elements = listing.RowsForViewModel<GenioMVC.Models.Langu>((r) => new GenioMVC.Models.Langu(m_userContext, r, true, _fieldsToSerialize_ANEXD___LANGULANGUA__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_langu") != null)
				{
					this.ValCodlang = Navigation.GetStrValue("RETURN_langu");
					Navigation.CurrentLevel.SetEntry("RETURN_langu", null);
				}

				TableLanguLangua.List = new SelectList(TableLanguLangua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodlang), "Value", "Text", this.ValCodlang);
				FillDependant_AnexdTableLanguLangua();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLanguLangua (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Langu</param>
		public ConcurrentDictionary<string, object> GetDependant_AnexdTableLanguLangua(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlangu.FldCodlang, CSGenioAlangu.FldLangua];

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

			CSGenioAlangu tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlangu.FldCodlang, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLanguLangua (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AnexdTableLanguLangua(bool lazyLoad = false)
		{
			var row = GetDependant_AnexdTableLanguLangua(this.ValCodlang);
			try
			{

				// Fill List fields
				this.ValCodlang = ViewModelConversion.ToString(row["langu.codlang"]);
				TableLanguLangua.Value = (string)row["langu.langua"];
				if (GlobalFunctions.emptyG(this.ValCodlang) == 1)
				{
					this.ValCodlang = "";
					TableLanguLangua.Value = "";
					Navigation.ClearValue("langu");
				}
				else if (lazyLoad)
				{
					TableLanguLangua.SetPagination(1, 0, false, false, 1);
					TableLanguLangua.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodlang),
							Text = Convert.ToString(TableLanguLangua.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodlang);
				}

				TableLanguLangua.Selected = this.ValCodlang;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLanguLangua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ANEXD___LANGULANGUA__ = ["Langu", "Langu.ValCodlang", "Langu.ValZzstate", "Langu.ValLangua"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"anexd.codequip" => ViewModelConversion.ToString(modelValue),
				"anexd.codlang" => ViewModelConversion.ToString(modelValue),
				"anexd.dthranex" => ViewModelConversion.ToDateTime(modelValue),
				"anexd.referenc" => ViewModelConversion.ToString(modelValue),
				"anexd.title" => ViewModelConversion.ToString(modelValue),
				"anexd.tittradu" => ViewModelConversion.ToString(modelValue),
				"anexd.document" => ViewModelConversion.ToString(modelValue),
				"anexd.codanexd" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"langu.codlang" => ViewModelConversion.ToString(modelValue),
				"langu.langua" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ANEXD]/

		#endregion
	}
}
