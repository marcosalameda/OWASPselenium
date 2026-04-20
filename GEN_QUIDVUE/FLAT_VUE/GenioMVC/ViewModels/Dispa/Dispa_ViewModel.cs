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

namespace GenioMVC.ViewModels.Dispa
{
	public class Dispa_ViewModel : FormViewModel<Models.Dispa>, IPreparableForSerialization
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
		/// Title: "Customer" | Type: "CE"
		/// </summary>
		public string ValCodentit { get; set; }
		/// <summary>
		/// Title: "Prepared by" | Type: "CE"
		/// </summary>
		public string ValCodperso { get; set; }

		#endregion

		/// <summary>
		/// Title: "Dispatch date" | Type: "DT"
		/// </summary>
		public DateTime? ValDispadt { get; set; }
		/// <summary>
		/// Title: "Dispatch number" | Type: "N"
		/// </summary>
		public decimal? ValDispanr { get; set; }
		/// <summary>
		/// Title: "Status" | Type: "AC"
		/// </summary>
		[ValidateSetAccess]
		public string ValStatus { get; set; }
		/// <summary>
		/// Title: "Customer" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Entit> TableEntitName { get; set; }
		/// <summary>
		/// Title: "Is prepared" | Type: "L"
		/// </summary>
		public bool ValIsprepar { get; set; }
		/// <summary>
		/// Title: "Prepared" | Type: "DT"
		/// </summary>
		public DateTime? ValPrepared { get; set; }
		/// <summary>
		/// Title: "Prepared by" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Perso> TablePersoName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoddispa { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dispa_ViewModel() : base(null!) { }

		public Dispa_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FDISPA", nestedForm) { }

		public Dispa_ViewModel(UserContext userContext, Models.Dispa row, bool nestedForm = false) : base(userContext, "FDISPA", row, nestedForm) { }

		public Dispa_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("dispa", id);
			Model = Models.Dispa.Find(id, userContext, "FDISPA", fieldsToQuery: fieldsToLoad);
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
			Models.Dispa model = new Models.Dispa(userContext) { Identifier = "FDISPA" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FDISPA");
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
		public override void MapFromModel(Models.Dispa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Dispa) to ViewModel (Dispa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
				ValDispadt = ViewModelConversion.ToDateTime(m.ValDispadt);
				ValDispanr = ViewModelConversion.ToNumeric(m.ValDispanr);
				ValStatus = ViewModelConversion.ToString(m.ValStatus);
				ValIsprepar = ViewModelConversion.ToLogic(m.ValIsprepar);
				ValPrepared = ViewModelConversion.ToDateTime(m.ValPrepared);
				ValCoddispa = ViewModelConversion.ToString(m.ValCoddispa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Dispa) to ViewModel (Dispa) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Dispa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Dispa) to Model (Dispa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
				m.ValDispadt = ViewModelConversion.ToDateTime(ValDispadt);
				m.ValDispanr = ViewModelConversion.ToNumeric(ValDispanr);
				m.ValIsprepar = ViewModelConversion.ToLogic(ValIsprepar);
				m.ValPrepared = ViewModelConversion.ToDateTime(ValPrepared);
				m.ValCoddispa = ViewModelConversion.ToString(ValCoddispa);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValStatus = ViewModelConversion.ToString(ValStatus);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Dispa) to Model (Dispa) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <inheritdoc />
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "dispa.codentit":
						this.ValCodentit = ViewModelConversion.ToString(_value);
						break;
					case "dispa.codperso":
						this.ValCodperso = ViewModelConversion.ToString(_value);
						break;
					case "dispa.dispadt":
						this.ValDispadt = ViewModelConversion.ToDateTime(_value);
						break;
					case "dispa.dispanr":
						this.ValDispanr = ViewModelConversion.ToNumeric(_value);
						break;
					case "dispa.isprepar":
						this.ValIsprepar = ViewModelConversion.ToLogic(_value);
						break;
					case "dispa.prepared":
						this.ValPrepared = ViewModelConversion.ToDateTime(_value);
						break;
					case "dispa.coddispa":
						this.ValCoddispa = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Dispa) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Dispa)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Dispa.Find(id ?? Navigation.GetStrValue("dispa"), m_userContext, "FDISPA"); }
			finally { Model ??= new Models.Dispa(m_userContext) { Identifier = "FDISPA" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), m_userContext, "FDISPA");
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

			Model.Identifier = "FDISPA";
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

		protected override void LoadDocumentsProperties(Models.Dispa row)
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
				Model = Models.Dispa.Find(Navigation.GetStrValue("dispa"), m_userContext, "FDISPA");
				if (Model == null)
				{
					Model = new Models.Dispa(m_userContext) { Identifier = "FDISPA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("dispa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Dispa___entitname____(qs, lazyLoad);
			Load_Dispa___personame____(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DISPA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DISPA]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE DISPA]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DISPA]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DISPA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DISPA]/
		public override void Destroy(string id)
		{
			Model = Models.Dispa.Find(id, m_userContext, "FDISPA");
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
		/// TableEntitName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dispa___entitname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dispa___entitname____DoLoad = true;
			CriteriaSet dispa___entitname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("entit", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dispa___entitname____Conds.Equal(CSGenioAentit.FldCodentit, hValue);
					this.ValCodentit = DBConversion.ToString(hValue);
				}
			}

			TableEntitName = new TableDBEdit<Models.Entit>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
				FillDependant_DispaTableEntitName(lazyLoad);
				return;
			}

			if (dispa___entitname____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
					TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
				else
					TableEntitName.TableFilters = false;

				query = qs["qTableEntitName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAentit.FldName, query + "%");
				}
				dispa___entitname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate];

// USE /[MANUAL GQT OVERRQ DISPA_ENTITNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
					dispa___entitname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAentit.FldZzstate, 0)
						.Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
				else
					dispa___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("entit", "name");
				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, dispa___entitname____Conds, fields, offset, numberItems, sorts, "LED_DISPA___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEntitName.Query = query;
				TableEntitName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Entit(m_userContext, r, true, _fieldsToSerialize_DISPA___ENTITNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
				FillDependant_DispaTableEntitName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Entit</param>
		public ConcurrentDictionary<string, object> GetDependant_DispaTableEntitName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAentit.FldCodentit, CSGenioAentit.FldName];

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

			CSGenioAentit tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DispaTableEntitName(bool lazyLoad = false)
		{
			var row = GetDependant_DispaTableEntitName(this.ValCodentit);
			try
			{

				// Fill List fields
				this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
				TableEntitName.Value = (string)row["entit.name"];
				if (GenFunctions.emptyG(this.ValCodentit) == 1)
				{
					this.ValCodentit = "";
					TableEntitName.Value = "";
					Navigation.ClearValue("entit");
				}
				else if (lazyLoad)
				{
					TableEntitName.SetPagination(1, 0, false, false, 1);
					TableEntitName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodentit),
							Text = Convert.ToString(TableEntitName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodentit);
				}

				TableEntitName.Selected = this.ValCodentit;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DISPA___ENTITNAME____ = ["Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials"];

		/// <summary>
		/// TablePersoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Dispa___personame____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool dispa___personame____DoLoad = true;
			CriteriaSet dispa___personame____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("perso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					dispa___personame____Conds.Equal(CSGenioAperso.FldCodperso, hValue);
					this.ValCodperso = DBConversion.ToString(hValue);
				}
			}

			TablePersoName = new TableDBEdit<Models.Perso>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}
				FillDependant_DispaTablePersoName(lazyLoad);
				return;
			}

			if (dispa___personame____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePersoName, "sTablePersoName", "dTablePersoName", qs, "perso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePersoName_tableFilters"]))
					TablePersoName.TableFilters = bool.Parse(qs["TablePersoName_tableFilters"]);
				else
					TablePersoName.TableFilters = false;

				query = qs["qTablePersoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAperso.FldName, query + "%");
				}
				dispa___personame____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate];

// USE /[MANUAL GQT OVERRQ DISPA_PERSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
					dispa___personame____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAperso.FldZzstate, 0)
						.Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
				else
					dispa___personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("perso", "name");
				ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(m_userContext, false, dispa___personame____Conds, fields, offset, numberItems, sorts, "LED_DISPA___PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePersoName.Query = query;
				TablePersoName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Perso(m_userContext, r, true, _fieldsToSerialize_DISPA___PERSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodperso), "Value", "Text", this.ValCodperso);
				FillDependant_DispaTablePersoName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Perso</param>
		public ConcurrentDictionary<string, object> GetDependant_DispaTablePersoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAperso.FldCodperso, CSGenioAperso.FldName];

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

			CSGenioAperso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAperso.FldCodperso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_DispaTablePersoName(bool lazyLoad = false)
		{
			var row = GetDependant_DispaTablePersoName(this.ValCodperso);
			try
			{

				// Fill List fields
				this.ValCodperso = ViewModelConversion.ToString(row["perso.codperso"]);
				TablePersoName.Value = (string)row["perso.name"];
				if (GenFunctions.emptyG(this.ValCodperso) == 1)
				{
					this.ValCodperso = "";
					TablePersoName.Value = "";
					Navigation.ClearValue("perso");
				}
				else if (lazyLoad)
				{
					TablePersoName.SetPagination(1, 0, false, false, 1);
					TablePersoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodperso),
							Text = Convert.ToString(TablePersoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodperso);
				}

				TablePersoName.Selected = this.ValCodperso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_DISPA___PERSONAME____ = ["Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"dispa.codentit" => ViewModelConversion.ToString(modelValue),
				"dispa.codperso" => ViewModelConversion.ToString(modelValue),
				"dispa.dispadt" => ViewModelConversion.ToDateTime(modelValue),
				"dispa.dispanr" => ViewModelConversion.ToNumeric(modelValue),
				"dispa.status" => ViewModelConversion.ToString(modelValue),
				"dispa.isprepar" => ViewModelConversion.ToLogic(modelValue),
				"dispa.prepared" => ViewModelConversion.ToDateTime(modelValue),
				"dispa.coddispa" => ViewModelConversion.ToString(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"entit.name" => ViewModelConversion.ToString(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				"perso.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DISPA]/

		#endregion
	}
}
