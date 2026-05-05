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

namespace GenioMVC.ViewModels.Tblk
{
	public class Tblk_ViewModel : FormViewModel<Models.Tblk>, IPreparableForSerialization
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
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValFkey1 { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValFkey2 { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Grpb> TableGrpbName { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Trsb> TableTrsbName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtblk { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tblk_ViewModel() : base(null!) { }

		public Tblk_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTBLK", nestedForm) { }

		public Tblk_ViewModel(UserContext userContext, Models.Tblk row, bool nestedForm = false) : base(userContext, "FTBLK", row, nestedForm) { }

		public Tblk_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tblk", id);
			Model = Models.Tblk.Find(id, userContext, "FTBLK", fieldsToQuery: fieldsToLoad);
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
			Models.Tblk model = new Models.Tblk(userContext) { Identifier = "FTBLK" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FTBLK");
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
		public override void MapFromModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValFkey1 = ViewModelConversion.ToString(m.ValFkey1);
				ValFkey2 = ViewModelConversion.ToString(m.ValFkey2);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCodtblk = ViewModelConversion.ToString(m.ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblk) to Model (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValFkey1 = ViewModelConversion.ToString(ValFkey1);
				m.ValFkey2 = ViewModelConversion.ToString(ValFkey2);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodtblk = ViewModelConversion.ToString(ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Tblk) to Model (Tblk) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "tblk.fkey1":
						this.ValFkey1 = ViewModelConversion.ToString(_value);
						break;
					case "tblk.fkey2":
						this.ValFkey2 = ViewModelConversion.ToString(_value);
						break;
					case "tblk.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "tblk.codtblk":
						this.ValCodtblk = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Tblk) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Tblk)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Tblk.Find(id ?? Navigation.GetStrValue("tblk"), m_userContext, "FTBLK"); }
			finally { Model ??= new Models.Tblk(m_userContext) { Identifier = "FTBLK" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK");
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

			Model.Identifier = "FTBLK";
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

		protected override void LoadDocumentsProperties(Models.Tblk row)
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
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK");
				if (Model == null)
				{
					Model = new Models.Tblk(m_userContext) { Identifier = "FTBLK" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblk");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tblk____grpb_name____(qs, lazyLoad);
			Load_Tblk____trsb_name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TBLK]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TBLK]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE TBLK]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TBLK]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TBLK]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TBLK]/
		public override void Destroy(string id)
		{
			Model = Models.Tblk.Find(id, m_userContext, "FTBLK");
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
		/// TableGrpbName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tblk____grpb_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tblk____grpb_name____DoLoad = true;
			CriteriaSet tblk____grpb_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("grpb", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tblk____grpb_name____Conds.Equal(CSGenioAgrpb.FldCodgrpb, hValue);
					this.ValFkey1 = DBConversion.ToString(hValue);
				}
			}

			TableGrpbName = new TableDBEdit<Models.Grpb>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
					this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}
				FillDependant_TblkTableGrpbName(lazyLoad);
				return;
			}

			if (tblk____grpb_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableGrpbName, "sTableGrpbName", "dTableGrpbName", qs, "grpb");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgrpb.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGrpbName_tableFilters"]))
					TableGrpbName.TableFilters = bool.Parse(qs["TableGrpbName_tableFilters"]);
				else
					TableGrpbName.TableFilters = false;

				query = qs["qTableGrpbName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgrpb.FldName, query + "%");
				}
				tblk____grpb_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGrpbName"] != null ? qs["pTableGrpbName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName, CSGenioAgrpb.FldZzstate];

// USE /[MANUAL GQT OVERRQ TBLK_GRPBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("grpb", FormMode.New) || Navigation.checkFormMode("grpb", FormMode.Duplicate))
					tblk____grpb_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgrpb.FldZzstate, 0)
						.Equal(CSGenioAgrpb.FldCodgrpb, Navigation.GetStrValue("grpb")));
				else
					tblk____grpb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgrpb.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("grpb", "name");
				ListingMVC<CSGenioAgrpb> listing = Models.ModelBase.Where<CSGenioAgrpb>(m_userContext, false, tblk____grpb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____GRPB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGrpbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGrpbName.Query = query;
				TableGrpbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Grpb>((r) => new GenioMVC.Models.Grpb(m_userContext, r, true, _fieldsToSerialize_TBLK____GRPB_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
					this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}

				TableGrpbName.List = new SelectList(TableGrpbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodgrpb,  x => x.ValCodgrpb == this.ValFkey1), "Value", "Text", this.ValFkey1);
				FillDependant_TblkTableGrpbName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGrpbName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Grpb</param>
		public ConcurrentDictionary<string, object> GetDependant_TblkTableGrpbName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName];

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

			CSGenioAgrpb tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgrpb.FldCodgrpb, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGrpbName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TblkTableGrpbName(bool lazyLoad = false)
		{
			var row = GetDependant_TblkTableGrpbName(this.ValFkey1);
			try
			{

				// Fill List fields
				this.ValFkey1 = ViewModelConversion.ToString(row["grpb.codgrpb"]);
				TableGrpbName.Value = (string)row["grpb.name"];
				if (GenFunctions.emptyG(this.ValFkey1) == 1)
				{
					this.ValFkey1 = "";
					TableGrpbName.Value = "";
					Navigation.ClearValue("grpb");
				}
				else if (lazyLoad)
				{
					TableGrpbName.SetPagination(1, 0, false, false, 1);
					TableGrpbName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFkey1),
							Text = Convert.ToString(TableGrpbName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFkey1);
				}

				TableGrpbName.Selected = this.ValFkey1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGrpbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TBLK____GRPB_NAME____ = ["Grpb", "Grpb.ValCodgrpb", "Grpb.ValZzstate", "Grpb.ValName"];

		/// <summary>
		/// TableTrsbName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tblk____trsb_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tblk____trsb_name____DoLoad = true;
			CriteriaSet tblk____trsb_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("trsb", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tblk____trsb_name____Conds.Equal(CSGenioAtrsb.FldCodtrsb, hValue);
					this.ValFkey2 = DBConversion.ToString(hValue);
				}
			}

			TableTrsbName = new TableDBEdit<Models.Trsb>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
					this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}
				FillDependant_TblkTableTrsbName(lazyLoad);
				return;
			}

			if (tblk____trsb_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTrsbName, "sTableTrsbName", "dTableTrsbName", qs, "trsb");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtrsb.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTrsbName_tableFilters"]))
					TableTrsbName.TableFilters = bool.Parse(qs["TableTrsbName_tableFilters"]);
				else
					TableTrsbName.TableFilters = false;

				query = qs["qTableTrsbName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtrsb.FldName, query + "%");
				}
				tblk____trsb_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableTrsbName"] != null ? qs["pTableTrsbName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName, CSGenioAtrsb.FldZzstate];

// USE /[MANUAL GQT OVERRQ TBLK_TRSBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("trsb", FormMode.New) || Navigation.checkFormMode("trsb", FormMode.Duplicate))
					tblk____trsb_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtrsb.FldZzstate, 0)
						.Equal(CSGenioAtrsb.FldCodtrsb, Navigation.GetStrValue("trsb")));
				else
					tblk____trsb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtrsb.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("trsb", "name");
				ListingMVC<CSGenioAtrsb> listing = Models.ModelBase.Where<CSGenioAtrsb>(m_userContext, false, tblk____trsb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____TRSB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTrsbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTrsbName.Query = query;
				TableTrsbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Trsb>((r) => new GenioMVC.Models.Trsb(m_userContext, r, true, _fieldsToSerialize_TBLK____TRSB_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
					this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}

				TableTrsbName.List = new SelectList(TableTrsbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodtrsb,  x => x.ValCodtrsb == this.ValFkey2), "Value", "Text", this.ValFkey2);
				FillDependant_TblkTableTrsbName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTrsbName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Trsb</param>
		public ConcurrentDictionary<string, object> GetDependant_TblkTableTrsbName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName];

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

			CSGenioAtrsb tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtrsb.FldCodtrsb, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTrsbName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TblkTableTrsbName(bool lazyLoad = false)
		{
			var row = GetDependant_TblkTableTrsbName(this.ValFkey2);
			try
			{

				// Fill List fields
				this.ValFkey2 = ViewModelConversion.ToString(row["trsb.codtrsb"]);
				TableTrsbName.Value = (string)row["trsb.name"];
				if (GenFunctions.emptyG(this.ValFkey2) == 1)
				{
					this.ValFkey2 = "";
					TableTrsbName.Value = "";
					Navigation.ClearValue("trsb");
				}
				else if (lazyLoad)
				{
					TableTrsbName.SetPagination(1, 0, false, false, 1);
					TableTrsbName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFkey2),
							Text = Convert.ToString(TableTrsbName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFkey2);
				}

				TableTrsbName.Selected = this.ValFkey2;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTrsbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TBLK____TRSB_NAME____ = ["Trsb", "Trsb.ValCodtrsb", "Trsb.ValZzstate", "Trsb.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tblk.fkey1" => ViewModelConversion.ToString(modelValue),
				"tblk.fkey2" => ViewModelConversion.ToString(modelValue),
				"tblk.name" => ViewModelConversion.ToString(modelValue),
				"tblk.codtblk" => ViewModelConversion.ToString(modelValue),
				"grpb.codgrpb" => ViewModelConversion.ToString(modelValue),
				"grpb.name" => ViewModelConversion.ToString(modelValue),
				"trsb.codtrsb" => ViewModelConversion.ToString(modelValue),
				"trsb.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBLK]/

		#endregion
	}
}
