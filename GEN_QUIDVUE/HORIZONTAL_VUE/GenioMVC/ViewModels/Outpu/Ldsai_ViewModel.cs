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

namespace GenioMVC.ViewModels.Outpu
{
	public class Ldsai_ViewModel : FormViewModel<Models.Outpu>, IPreparableForSerialization
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
		/// Title: "Item" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "Output No" | Type: "CE"
		/// </summary>
		public string ValCoddocsd { get; set; }
		/// <summary>
		/// Title: "Document No." | Type: "CE"
		/// </summary>
		public string ValCodoutpt { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "Document No." | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Outpt> TableOutptDocumenr { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string OutptValCodwareh 
		{
			get
			{
				return funcOutptValCodwareh != null ? funcOutptValCodwareh() : _auxOutptValCodwareh;
			}
			set { funcOutptValCodwareh = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcOutptValCodwareh { get; set; }

		private string _auxOutptValCodwareh { get; set; }
		/// <summary>
		/// Title: "Line" | Type: "N"
		/// </summary>
		public decimal? ValLine { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }
		/// <summary>
		/// Title: "Item" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemItemdes { get; set; }
		/// <summary>
		/// Title: "Output quantity:" | Type: "N"
		/// </summary>
		public decimal? ValExitqnty { get; set; }
		/// <summary>
		/// Title: "Output No" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Oudoc> TableOudocNrdocsda { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodoutpu { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Ldsai_ViewModel() : base(null!) { }

		public Ldsai_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLDSAI", nestedForm) { }

		public Ldsai_ViewModel(UserContext userContext, Models.Outpu row, bool nestedForm = false) : base(userContext, "FLDSAI", row, nestedForm) { }

		public Ldsai_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("outpu", id);
			Model = Models.Outpu.Find(id, userContext, "FLDSAI", fieldsToQuery: fieldsToLoad);
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
			Models.Outpu model = new Models.Outpu(userContext) { Identifier = "FLDSAI" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLDSAI");
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

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
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
		public override void MapFromModel(Models.Outpu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Outpu) to ViewModel (Ldsai) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCoddocsd = ViewModelConversion.ToString(m.ValCoddocsd);
				ValCodoutpt = ViewModelConversion.ToString(m.ValCodoutpt);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				funcOutptValCodwareh = () => ViewModelConversion.ToString(m.Outpt.ValCodwareh);
				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
				ValExitqnty = ViewModelConversion.ToNumeric(m.ValExitqnty);
				ValCodoutpu = ViewModelConversion.ToString(m.ValCodoutpu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Outpu) to ViewModel (Ldsai) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Outpu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ldsai) to Model (Outpu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCoddocsd = ViewModelConversion.ToString(ValCoddocsd);
				m.ValCodoutpt = ViewModelConversion.ToString(ValCodoutpt);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValExitqnty = ViewModelConversion.ToNumeric(ValExitqnty);
				m.ValCodoutpu = ViewModelConversion.ToString(ValCodoutpu);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Ldsai) to Model (Outpu) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "outpu.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					case "outpu.coddocsd":
						this.ValCoddocsd = ViewModelConversion.ToString(_value);
						break;
					case "outpu.codoutpt":
						this.ValCodoutpt = ViewModelConversion.ToString(_value);
						break;
					case "outpu.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "outpu.line":
						this.ValLine = ViewModelConversion.ToNumeric(_value);
						break;
					case "outpu.exitqnty":
						this.ValExitqnty = ViewModelConversion.ToNumeric(_value);
						break;
					case "outpu.codoutpu":
						this.ValCodoutpu = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Ldsai) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Ldsai)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Outpu.Find(id ?? Navigation.GetStrValue("outpu"), m_userContext, "FLDSAI"); }
			finally { Model ??= new Models.Outpu(m_userContext) { Identifier = "FLDSAI" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), m_userContext, "FLDSAI");
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

			Model.Identifier = "FLDSAI";
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

		protected override void LoadDocumentsProperties(Models.Outpu row)
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
				Model = Models.Outpu.Find(Navigation.GetStrValue("outpu"), m_userContext, "FLDSAI");
				if (Model == null)
				{
					Model = new Models.Outpu(m_userContext) { Identifier = "FLDSAI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("outpu");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Ldsai___outptdocumenr(qs, lazyLoad);
			Load_Ldsai___warehwarehdes(qs, lazyLoad);
			Load_Ldsai___item_itemdes_(qs, lazyLoad);
			Load_Ldsai___oudocnrdocsda(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LDSAI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LDSAI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE LDSAI]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LDSAI]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LDSAI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LDSAI]/
		public override void Destroy(string id)
		{
			Model = Models.Outpu.Find(id, m_userContext, "FLDSAI");
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
		/// TableOutptDocumenr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldsai___outptdocumenr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldsai___outptdocumenrDoLoad = true;
			CriteriaSet ldsai___outptdocumenrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("outpt", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldsai___outptdocumenrConds.Equal(CSGenioAoutpt.FldCodoutpt, hValue);
					this.ValCodoutpt = DBConversion.ToString(hValue);
				}
			}

			TableOutptDocumenr = new TableDBEdit<Models.Outpt>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_outpt") != null)
				{
					this.ValCodoutpt = Navigation.GetStrValue("RETURN_outpt");
					Navigation.CurrentLevel.SetEntry("RETURN_outpt", null);
				}
				FillDependant_LdsaiTableOutptDocumenr(lazyLoad);
				return;
			}

			if (ldsai___outptdocumenrDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableOutptDocumenr, "sTableOutptDocumenr", "dTableOutptDocumenr", qs, "outpt");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoutpt.FldDhdocume), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableOutptDocumenr_tableFilters"]))
					TableOutptDocumenr.TableFilters = bool.Parse(qs["TableOutptDocumenr_tableFilters"]);
				else
					TableOutptDocumenr.TableFilters = false;

				query = qs["qTableOutptDocumenr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAoutpt.FldDocumenr, query + "%");
				}
				ldsai___outptdocumenrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableOutptDocumenr"] != null ? qs["pTableOutptDocumenr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldDhdocume, CSGenioAoutpt.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_OUTPTDOCUMENR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("outpt", FormMode.New) || Navigation.checkFormMode("outpt", FormMode.Duplicate))
					ldsai___outptdocumenrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAoutpt.FldZzstate, 0)
						.Equal(CSGenioAoutpt.FldCodoutpt, Navigation.GetStrValue("outpt")));
				else
					ldsai___outptdocumenrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAoutpt.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("outpt", "documenr");
				ListingMVC<CSGenioAoutpt> listing = Models.ModelBase.Where<CSGenioAoutpt>(m_userContext, false, ldsai___outptdocumenrConds, fields, offset, numberItems, sorts, "LED_LDSAI___OUTPTDOCUMENR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableOutptDocumenr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableOutptDocumenr.Query = query;
				TableOutptDocumenr.Elements = listing.RowsForViewModel<GenioMVC.Models.Outpt>((r) => new GenioMVC.Models.Outpt(m_userContext, r, true, _fieldsToSerialize_LDSAI___OUTPTDOCUMENR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_outpt") != null)
				{
					this.ValCodoutpt = Navigation.GetStrValue("RETURN_outpt");
					Navigation.CurrentLevel.SetEntry("RETURN_outpt", null);
				}

				TableOutptDocumenr.List = new SelectList(TableOutptDocumenr.Elements.ToSelectList(x => x.ValDocumenr, x => x.ValCodoutpt,  x => x.ValCodoutpt == this.ValCodoutpt), "Value", "Text", this.ValCodoutpt);
				FillDependant_LdsaiTableOutptDocumenr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableOutptDocumenr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Outpt</param>
		public ConcurrentDictionary<string, object> GetDependant_LdsaiTableOutptDocumenr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldCodwareh];

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

			CSGenioAoutpt tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAoutpt.FldCodoutpt, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableOutptDocumenr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LdsaiTableOutptDocumenr(bool lazyLoad = false)
		{
			var row = GetDependant_LdsaiTableOutptDocumenr(this.ValCodoutpt);
			try
			{
				this.funcOutptValCodwareh = () => (string)row["outpt.codwareh"];

				// Fill List fields
				this.ValCodoutpt = ViewModelConversion.ToString(row["outpt.codoutpt"]);
				TableOutptDocumenr.Value = (decimal?)row["outpt.documenr"];
				if (GenFunctions.emptyG(this.ValCodoutpt) == 1)
				{
					this.ValCodoutpt = "";
					TableOutptDocumenr.Value = 0m;
					Navigation.ClearValue("outpt");
				}
				else if (lazyLoad)
				{
					TableOutptDocumenr.SetPagination(1, 0, false, false, 1);
					TableOutptDocumenr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodoutpt),
							Text = Convert.ToString(TableOutptDocumenr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodoutpt);
				}

				TableOutptDocumenr.Selected = this.ValCodoutpt;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOutptDocumenr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LDSAI___OUTPTDOCUMENR = ["Outpt", "Outpt.ValCodoutpt", "Outpt.ValZzstate", "Outpt.ValDocumenr", "Outpt.ValDhdocume"];

		/// <summary>
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldsai___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldsai___warehwarehdesDoLoad = true;
			CriteriaSet ldsai___warehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldsai___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
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
				FillDependant_LdsaiTableWarehWarehdes(lazyLoad);
				return;
			}

			if (ldsai___warehwarehdesDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehdes), SortOrder.Ascending));

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
				ldsai___warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					ldsai___warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					ldsai___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, ldsai___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_LDSAI___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_LDSAI___WAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_LdsaiTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_LdsaiTableWarehWarehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes];

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
		public void FillDependant_LdsaiTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_LdsaiTableWarehWarehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
				TableWarehWarehdes.Value = (string)row["wareh.warehdes"];
				if (GenFunctions.emptyG(this.ValCodwareh) == 1)
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

		private readonly string[] _fieldsToSerialize_LDSAI___WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes"];

		/// <summary>
		/// TableItemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldsai___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldsai___item_itemdes_DoLoad = true;
			CriteriaSet ldsai___item_itemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("item", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldsai___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValCoditem = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			ldsai___item_itemdes_DoLoad &= AddCriteriaAreaLimit(ldsai___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);

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
				FillDependant_LdsaiTableItemItemdes(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodwareh))
				ldsai___item_itemdes_DoLoad = false;

			if (ldsai___item_itemdes_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemdes), SortOrder.Ascending));

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
				ldsai___item_itemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_ITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					ldsai___item_itemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					ldsai___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, ldsai___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_LDSAI___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemItemdes.Query = query;
				TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_LDSAI___ITEM_ITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
				FillDependant_LdsaiTableItemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_LdsaiTableItemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("wareh");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
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
		public void FillDependant_LdsaiTableItemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_LdsaiTableItemItemdes(this.ValCoditem);
			try
			{

				// Fill List fields
				this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemItemdes.Value = (string)row["item.itemdes"];
				if (GenFunctions.emptyG(this.ValCoditem) == 1)
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

		private readonly string[] _fieldsToSerialize_LDSAI___ITEM_ITEMDES_ = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes"];

		/// <summary>
		/// TableOudocNrdocsda -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Ldsai___oudocnrdocsda(NameValueCollection qs, bool lazyLoad = false)
		{
			bool ldsai___oudocnrdocsdaDoLoad = true;
			CriteriaSet ldsai___oudocnrdocsdaConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("oudoc", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					ldsai___oudocnrdocsdaConds.Equal(CSGenioAoudoc.FldCoddocsd, hValue);
					this.ValCoddocsd = DBConversion.ToString(hValue);
				}
			}

			TableOudocNrdocsda = new TableDBEdit<Models.Oudoc>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_oudoc") != null)
				{
					this.ValCoddocsd = Navigation.GetStrValue("RETURN_oudoc");
					Navigation.CurrentLevel.SetEntry("RETURN_oudoc", null);
				}
				FillDependant_LdsaiTableOudocNrdocsda(lazyLoad);
				return;
			}

			if (ldsai___oudocnrdocsdaDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableOudocNrdocsda, "sTableOudocNrdocsda", "dTableOudocNrdocsda", qs, "oudoc");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoudoc.FldNrdocsda), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableOudocNrdocsda_tableFilters"]))
					TableOudocNrdocsda.TableFilters = bool.Parse(qs["TableOudocNrdocsda_tableFilters"]);
				else
					TableOudocNrdocsda.TableFilters = false;

				query = qs["qTableOudocNrdocsda"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAoudoc.FldNrdocsda, query + "%");
				}
				ldsai___oudocnrdocsdaConds.SubSet(search_filters);

				string tryParsePage = qs["pTableOudocNrdocsda"] != null ? qs["pTableOudocNrdocsda"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAoudoc.FldCoddocsd, CSGenioAoudoc.FldNrdocsda, CSGenioAoudoc.FldDtdocsda, CSGenioAoudoc.FldTitle, CSGenioAoudoc.FldZzstate };

// USE /[MANUAL GQT OVERRQ LDSAI_OUDOCNRDOCSDA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("oudoc", FormMode.New) || Navigation.checkFormMode("oudoc", FormMode.Duplicate))
					ldsai___oudocnrdocsdaConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAoudoc.FldZzstate, 0)
						.Equal(CSGenioAoudoc.FldCoddocsd, Navigation.GetStrValue("oudoc")));
				else
					ldsai___oudocnrdocsdaConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAoudoc.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("oudoc", "nrdocsda");
				ListingMVC<CSGenioAoudoc> listing = Models.ModelBase.Where<CSGenioAoudoc>(m_userContext, false, ldsai___oudocnrdocsdaConds, fields, offset, numberItems, sorts, "LED_LDSAI___OUDOCNRDOCSDA", true, false, firstVisibleColumn: firstVisibleColumn);

				TableOudocNrdocsda.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableOudocNrdocsda.Query = query;
				TableOudocNrdocsda.Elements = listing.RowsForViewModel<GenioMVC.Models.Oudoc>((r) => new GenioMVC.Models.Oudoc(m_userContext, r, true, _fieldsToSerialize_LDSAI___OUDOCNRDOCSDA));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_oudoc") != null)
				{
					this.ValCoddocsd = Navigation.GetStrValue("RETURN_oudoc");
					Navigation.CurrentLevel.SetEntry("RETURN_oudoc", null);
				}

				TableOudocNrdocsda.List = new SelectList(TableOudocNrdocsda.Elements.ToSelectList(x => x.ValNrdocsda, x => x.ValCoddocsd,  x => x.ValCoddocsd == this.ValCoddocsd), "Value", "Text", this.ValCoddocsd);
				FillDependant_LdsaiTableOudocNrdocsda();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableOudocNrdocsda (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Oudoc</param>
		public ConcurrentDictionary<string, object> GetDependant_LdsaiTableOudocNrdocsda(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAoudoc.FldCoddocsd, CSGenioAoudoc.FldNrdocsda];

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

			CSGenioAoudoc tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAoudoc.FldCoddocsd, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableOudocNrdocsda (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LdsaiTableOudocNrdocsda(bool lazyLoad = false)
		{
			var row = GetDependant_LdsaiTableOudocNrdocsda(this.ValCoddocsd);
			try
			{

				// Fill List fields
				this.ValCoddocsd = ViewModelConversion.ToString(row["oudoc.coddocsd"]);
				TableOudocNrdocsda.Value = (decimal?)row["oudoc.nrdocsda"];
				if (GenFunctions.emptyG(this.ValCoddocsd) == 1)
				{
					this.ValCoddocsd = "";
					TableOudocNrdocsda.Value = 0m;
					Navigation.ClearValue("oudoc");
				}
				else if (lazyLoad)
				{
					TableOudocNrdocsda.SetPagination(1, 0, false, false, 1);
					TableOudocNrdocsda.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoddocsd),
							Text = Convert.ToString(TableOudocNrdocsda.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoddocsd);
				}

				TableOudocNrdocsda.Selected = this.ValCoddocsd;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableOudocNrdocsda): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LDSAI___OUDOCNRDOCSDA = ["Oudoc", "Oudoc.ValCoddocsd", "Oudoc.ValZzstate", "Oudoc.ValNrdocsda", "Oudoc.ValDtdocsda", "Oudoc.ValTitle"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"outpu.coditem" => ViewModelConversion.ToString(modelValue),
				"outpu.coddocsd" => ViewModelConversion.ToString(modelValue),
				"outpu.codoutpt" => ViewModelConversion.ToString(modelValue),
				"outpu.codwareh" => ViewModelConversion.ToString(modelValue),
				"outpt.codwareh" => ViewModelConversion.ToString(modelValue),
				"outpu.line" => ViewModelConversion.ToNumeric(modelValue),
				"outpu.exitqnty" => ViewModelConversion.ToNumeric(modelValue),
				"outpu.codoutpu" => ViewModelConversion.ToString(modelValue),
				"outpt.codoutpt" => ViewModelConversion.ToString(modelValue),
				"outpt.documenr" => ViewModelConversion.ToNumeric(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"oudoc.coddocsd" => ViewModelConversion.ToString(modelValue),
				"oudoc.nrdocsda" => ViewModelConversion.ToNumeric(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LDSAI]/

		#endregion
	}
}
