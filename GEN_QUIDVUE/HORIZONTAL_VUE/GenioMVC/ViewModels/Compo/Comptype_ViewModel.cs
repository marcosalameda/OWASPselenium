using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Compo
{
	public class Comptype_ViewModel : FormViewModel<Models.Compo>, IPreparableForSerialization
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
		/// Title: "Components Class" | Type: "CE"
		/// </summary>
		public string ValCodcompc { get; set; }

		#endregion
		/// <summary>
		/// Title: "Component type" | Type: "C"
		/// </summary>
		public string ValComptype { get; set; }
		/// <summary>
		/// Title: "Component class" | Type: "AN"
		/// </summary>
		[ValidateSetAccess]
		public decimal ValCompicon { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValCompicon { get; set; }
		/// <summary>
		/// Title: "Component description" | Type: "MO"
		/// </summary>
		public string ValCompdesc { get; set; }
		/// <summary>
		/// Title: "Components Class" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Compc> TableCompcCompclas { get; set; }
		/// <summary>
		/// Title: "Data type" | Type: "C"
		/// </summary>
		public string ValCdatatyp { get; set; }
		/// <summary>
		/// Title: "Release" | Type: "C"
		/// </summary>
		public string ValRelease { get; set; }
		/// <summary>
		/// Title: "MVC" | Type: "L"
		/// </summary>
		public bool ValMvc { get; set; }
		/// <summary>
		/// Title: "VUE" | Type: "L"
		/// </summary>
		public bool ValVuemvc { get; set; }
		/// <summary>
		/// Title: "Preview" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(450, 400)]
		public GenioMVC.Models.ImageModel ValPreview { get; set; }
		/// <summary>
		/// Title: "When to use" | Type: "MO"
		/// </summary>
		public string ValWuse { get; set; }
		/// <summary>
		/// Title: "When not to use" | Type: "MO"
		/// </summary>
		public string ValWnuse { get; set; }
		/// <summary>
		/// Title: "Accessibilty Compliance & Best Practices" | Type: "MO"
		/// </summary>
		public string ValAccessib { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodcompo { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Comptype_ViewModel() : base(null!) { }

		public Comptype_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCOMPTYPE", nestedForm) { }

		public Comptype_ViewModel(UserContext userContext, Models.Compo row, bool nestedForm = false) : base(userContext, "FCOMPTYPE", row, nestedForm) { }

		public Comptype_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("compo", id);
			Model = Models.Compo.Find(id, userContext, "FCOMPTYPE", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ADMINISTRATION;
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
			Models.Compo model = new Models.Compo(userContext) { Identifier = "FCOMPTYPE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCOMPTYPE");
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
		public override void MapFromModel(Models.Compo m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Compo) to ViewModel (Comptype) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcompc = ViewModelConversion.ToString(m.ValCodcompc);
				ValComptype = ViewModelConversion.ToString(m.ValComptype);
				ValCompicon = ViewModelConversion.ToNumeric(m.ValCompicon);
				ValCompdesc = ViewModelConversion.ToString(m.ValCompdesc);
				ValCdatatyp = ViewModelConversion.ToString(m.ValCdatatyp);
				ValRelease = ViewModelConversion.ToString(m.ValRelease);
				ValMvc = ViewModelConversion.ToLogic(m.ValMvc);
				ValVuemvc = ViewModelConversion.ToLogic(m.ValVuemvc);
				ValPreview = ViewModelConversion.ToImage(m.ValPreview);
				ValWuse = ViewModelConversion.ToString(m.ValWuse);
				ValWnuse = ViewModelConversion.ToString(m.ValWnuse);
				ValAccessib = ViewModelConversion.ToString(m.ValAccessib);
				ValCodcompo = ViewModelConversion.ToString(m.ValCodcompo);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Compo) to ViewModel (Comptype) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Compo m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Comptype) to Model (Compo) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcompc = ViewModelConversion.ToString(ValCodcompc);
				m.ValComptype = ViewModelConversion.ToString(ValComptype);
				m.ValCompdesc = ViewModelConversion.ToString(ValCompdesc);
				m.ValCdatatyp = ViewModelConversion.ToString(ValCdatatyp);
				m.ValRelease = ViewModelConversion.ToString(ValRelease);
				m.ValMvc = ViewModelConversion.ToLogic(ValMvc);
				m.ValVuemvc = ViewModelConversion.ToLogic(ValVuemvc);
				if (ValPreview == null || !ValPreview.IsThumbnail)
					m.ValPreview = ViewModelConversion.ToImage(ValPreview);
				m.ValWuse = ViewModelConversion.ToString(ValWuse);
				m.ValWnuse = ViewModelConversion.ToString(ValWnuse);
				m.ValAccessib = ViewModelConversion.ToString(ValAccessib);
				m.ValCodcompo = ViewModelConversion.ToString(ValCodcompo);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCompicon = ViewModelConversion.ToNumeric(ValCompicon);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Comptype) to Model (Compo) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "compo.codcompc":
						this.ValCodcompc = ViewModelConversion.ToString(_value);
						break;
					case "compo.comptype":
						this.ValComptype = ViewModelConversion.ToString(_value);
						break;
					case "compo.compdesc":
						this.ValCompdesc = ViewModelConversion.ToString(_value);
						break;
					case "compo.cdatatyp":
						this.ValCdatatyp = ViewModelConversion.ToString(_value);
						break;
					case "compo.release":
						this.ValRelease = ViewModelConversion.ToString(_value);
						break;
					case "compo.mvc":
						this.ValMvc = ViewModelConversion.ToLogic(_value);
						break;
					case "compo.vuemvc":
						this.ValVuemvc = ViewModelConversion.ToLogic(_value);
						break;
					case "compo.preview":
						this.ValPreview = ViewModelConversion.ToImage(_value);
						break;
					case "compo.wuse":
						this.ValWuse = ViewModelConversion.ToString(_value);
						break;
					case "compo.wnuse":
						this.ValWnuse = ViewModelConversion.ToString(_value);
						break;
					case "compo.accessib":
						this.ValAccessib = ViewModelConversion.ToString(_value);
						break;
					case "compo.codcompo":
						this.ValCodcompo = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Comptype) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Comptype)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Compo.Find(id ?? Navigation.GetStrValue("compo"), m_userContext, "FCOMPTYPE"); }
			finally { Model ??= new Models.Compo(m_userContext) { Identifier = "FCOMPTYPE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Compo.Find(Navigation.GetStrValue("compo"), m_userContext, "FCOMPTYPE");
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

			Model.Identifier = "FCOMPTYPE";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

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

		protected override void LoadDocumentsProperties(Models.Compo row)
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
				Model = Models.Compo.Find(Navigation.GetStrValue("compo"), m_userContext, "FCOMPTYPE");
				if (Model == null)
				{
					Model = new Models.Compo(m_userContext) { Identifier = "FCOMPTYPE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("compo");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Comptab_compccompclas(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL COMPTYPE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW COMPTYPE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValComptype", Resources.Resources.COMPONENT_TYPE41163, ValComptype, 50);
			validator.StringLength("ValCdatatyp", Resources.Resources.DATA_TYPE47159, ValCdatatyp, 50);
			validator.StringLength("ValRelease", Resources.Resources.RELEASE62976, ValRelease, 6);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE COMPTYPE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY COMPTYPE]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE COMPTYPE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY COMPTYPE]/
		public override void Destroy(string id)
		{
			Model = Models.Compo.Find(id, m_userContext, "FCOMPTYPE");
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
		/// TableCompcCompclas -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Comptab_compccompclas(NameValueCollection qs, bool lazyLoad = false)
		{
			bool comptab_compccompclasDoLoad = true;
			CriteriaSet comptab_compccompclasConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("compc", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					comptab_compccompclasConds.Equal(CSGenioAcompc.FldCodcompc, hValue);
					this.ValCodcompc = DBConversion.ToString(hValue);
				}
			}

			TableCompcCompclas = new TableDBEdit<Models.Compc>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_compc") != null)
				{
					this.ValCodcompc = Navigation.GetStrValue("RETURN_compc");
					Navigation.CurrentLevel.SetEntry("RETURN_compc", null);
				}
				FillDependant_ComptabTableCompcCompclas(lazyLoad);
				return;
			}

			if (comptab_compccompclasDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCompcCompclas, "sTableCompcCompclas", "dTableCompcCompclas", qs, "compc");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcompc.FldCompclas), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCompcCompclas_tableFilters"]))
					TableCompcCompclas.TableFilters = bool.Parse(qs["TableCompcCompclas_tableFilters"]);
				else
					TableCompcCompclas.TableFilters = false;

				query = qs["qTableCompcCompclas"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcompc.FldCompclas, query + "%");
				}
				comptab_compccompclasConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCompcCompclas"] != null ? qs["pTableCompcCompclas"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcompc.FldCodcompc, CSGenioAcompc.FldCompclas, CSGenioAcompc.FldZzstate];

// USE /[MANUAL GQT OVERRQ COMPTAB_COMPCCOMPCLAS]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("compc", FormMode.New) || Navigation.checkFormMode("compc", FormMode.Duplicate))
					comptab_compccompclasConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcompc.FldZzstate, 0)
						.Equal(CSGenioAcompc.FldCodcompc, Navigation.GetStrValue("compc")));
				else
					comptab_compccompclasConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcompc.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("compc", "compclas");
				ListingMVC<CSGenioAcompc> listing = Models.ModelBase.Where<CSGenioAcompc>(m_userContext, false, comptab_compccompclasConds, fields, offset, numberItems, sorts, "LED_COMPTAB_COMPCCOMPCLAS", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCompcCompclas.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCompcCompclas.Query = query;
				TableCompcCompclas.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Compc(m_userContext, r, true, _fieldsToSerialize_COMPTAB_COMPCCOMPCLAS));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_compc") != null)
				{
					this.ValCodcompc = Navigation.GetStrValue("RETURN_compc");
					Navigation.CurrentLevel.SetEntry("RETURN_compc", null);
				}

				TableCompcCompclas.List = new SelectList(TableCompcCompclas.Elements.ToSelectList(x => x.ValCompclas, x => x.ValCodcompc,  x => x.ValCodcompc == this.ValCodcompc), "Value", "Text", this.ValCodcompc);
				FillDependant_ComptabTableCompcCompclas();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCompcCompclas (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Compc</param>
		public ConcurrentDictionary<string, object> GetDependant_ComptabTableCompcCompclas(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcompc.FldCodcompc, CSGenioAcompc.FldCompclas];

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

			CSGenioAcompc tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcompc.FldCodcompc, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCompcCompclas (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ComptabTableCompcCompclas(bool lazyLoad = false)
		{
			var row = GetDependant_ComptabTableCompcCompclas(this.ValCodcompc);
			try
			{

				// Fill List fields
				this.ValCodcompc = ViewModelConversion.ToString(row["compc.codcompc"]);
				TableCompcCompclas.Value = (string)row["compc.compclas"];
				if (GenFunctions.emptyG(this.ValCodcompc) == 1)
				{
					this.ValCodcompc = "";
					TableCompcCompclas.Value = "";
					Navigation.ClearValue("compc");
				}
				else if (lazyLoad)
				{
					TableCompcCompclas.SetPagination(1, 0, false, false, 1);
					TableCompcCompclas.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcompc),
							Text = Convert.ToString(TableCompcCompclas.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcompc);
				}

				TableCompcCompclas.Selected = this.ValCodcompc;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCompcCompclas): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_COMPTAB_COMPCCOMPCLAS = ["Compc", "Compc.ValCodcompc", "Compc.ValZzstate", "Compc.ValCompclas"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"compo.codcompc" => ViewModelConversion.ToString(modelValue),
				"compo.comptype" => ViewModelConversion.ToString(modelValue),
				"compo.compicon" => ViewModelConversion.ToNumeric(modelValue),
				"compo.compdesc" => ViewModelConversion.ToString(modelValue),
				"compo.cdatatyp" => ViewModelConversion.ToString(modelValue),
				"compo.release" => ViewModelConversion.ToString(modelValue),
				"compo.mvc" => ViewModelConversion.ToLogic(modelValue),
				"compo.vuemvc" => ViewModelConversion.ToLogic(modelValue),
				"compo.preview" => ViewModelConversion.ToImage(modelValue),
				"compo.wuse" => ViewModelConversion.ToString(modelValue),
				"compo.wnuse" => ViewModelConversion.ToString(modelValue),
				"compo.accessib" => ViewModelConversion.ToString(modelValue),
				"compo.codcompo" => ViewModelConversion.ToString(modelValue),
				"compc.codcompc" => ViewModelConversion.ToString(modelValue),
				"compc.compclas" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPreview != null)
				ValPreview.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCOMPO, CSGenioAcompo.FldPreview.Field, null, ValCodcompo);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM COMPTYPE]/

		#endregion
	}
}
