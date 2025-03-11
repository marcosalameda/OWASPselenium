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

namespace GenioMVC.ViewModels.Pwreg
{
	public class Pwreg_ViewModel : FormViewModel<Models.Pwreg>, IPreparableForSerialization
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
		/// Title: "Login Name" | Type: "CE"
		/// </summary>
		public string ValCodpsw { get; set; }
		/// <summary>
		/// Title: "Region" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }

		#endregion
		/// <summary>
		/// Title: "Login Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Psw> TablePswNome { get; set; }
		/// <summary>
		/// Title: "Region" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Regio> TableRegioRegiao { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpwreg { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pwreg_ViewModel() : base(null!) { }

		public Pwreg_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPWREG", nestedForm) { }

		public Pwreg_ViewModel(UserContext userContext, Models.Pwreg row, bool nestedForm = false) : base(userContext, "FPWREG", row, nestedForm) { }

		public Pwreg_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pwreg", id);
			Model = Models.Pwreg.Find(id, userContext, "FPWREG", fieldsToQuery: fieldsToLoad);
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
			Models.Pwreg model = new Models.Pwreg(userContext) { Identifier = "FPWREG" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPWREG");
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
			Models.Pwreg model = Model;
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
		public override void MapFromModel(Models.Pwreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pwreg) to ViewModel (Pwreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValCodpwreg = ViewModelConversion.ToString(m.ValCodpwreg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pwreg) to ViewModel (Pwreg) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Pwreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pwreg) to Model (Pwreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodpwreg = ViewModelConversion.ToString(ValCodpwreg);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Pwreg) to Model (Pwreg) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "pwreg.codpsw":
						this.ValCodpsw = ViewModelConversion.ToString(_value);
						break;
					case "pwreg.codregia":
						this.ValCodregia = ViewModelConversion.ToString(_value);
						break;
					case "pwreg.codpwreg":
						this.ValCodpwreg = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Pwreg) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Pwreg)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Pwreg.Find(id ?? Navigation.GetStrValue("pwreg"), m_userContext, "FPWREG"); }
			finally { Model ??= new Models.Pwreg(m_userContext) { Identifier = "FPWREG" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Pwreg.Find(Navigation.GetStrValue("pwreg"), m_userContext, "FPWREG");
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

			Model.Identifier = "FPWREG";
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

		protected override void LoadDocumentsProperties(Models.Pwreg row)
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
				Model = Models.Pwreg.Find(Navigation.GetStrValue("pwreg"), m_userContext, "FPWREG");
				if (Model == null)
				{
					Model = new Models.Pwreg(m_userContext) { Identifier = "FPWREG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pwreg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pwreg___psw__nome____(qs, lazyLoad);
			Load_Pwreg___regioregiao__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PWREG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PWREG]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE PWREG]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PWREG]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PWREG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PWREG]/
		public override void Destroy(string id)
		{
			Model = Models.Pwreg.Find(id, m_userContext, "FPWREG");
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
		/// TablePswNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pwreg___psw__nome____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pwreg___psw__nome____DoLoad = true;
			CriteriaSet pwreg___psw__nome____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("psw", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pwreg___psw__nome____Conds.Equal(CSGenioApsw.FldCodpsw, hValue);
					this.ValCodpsw = DBConversion.ToString(hValue);
				}
			}

			TablePswNome = new TableDBEdit<Models.Psw>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
				FillDependant_PwregTablePswNome(lazyLoad);
				return;
			}

			if (pwreg___psw__nome____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
					TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
				else
					TablePswNome.TableFilters = false;

				query = qs["qTablePswNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
				}
				pwreg___psw__nome____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWREG_PSWNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
					pwreg___psw__nome____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApsw.FldZzstate, 0)
						.Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
				else
					pwreg___psw__nome____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, pwreg___psw__nome____Conds, fields, offset, numberItems, sorts, "LED_PWREG___PSW__NOME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePswNome.Query = query;
				TablePswNome.Elements = listing.RowsForViewModel<GenioMVC.Models.Psw>((r) => new GenioMVC.Models.Psw(m_userContext, r, true, _fieldsToSerialize_PWREG___PSW__NOME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
				FillDependant_PwregTablePswNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Psw</param>
		public ConcurrentDictionary<string, object> GetDependant_PwregTablePswNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome];

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

			CSGenioApsw tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PwregTablePswNome(bool lazyLoad = false)
		{
			var row = GetDependant_PwregTablePswNome(this.ValCodpsw);
			try
			{

				// Fill List fields
				this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
				TablePswNome.Value = (string)row["psw.nome"];
				if (GlobalFunctions.emptyG(this.ValCodpsw) == 1)
				{
					this.ValCodpsw = "";
					TablePswNome.Value = "";
					Navigation.ClearValue("psw");
				}
				else if (lazyLoad)
				{
					TablePswNome.SetPagination(1, 0, false, false, 1);
					TablePswNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpsw),
							Text = Convert.ToString(TablePswNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpsw);
				}

				TablePswNome.Selected = this.ValCodpsw;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PWREG___PSW__NOME____ = ["Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome"];

		/// <summary>
		/// TableRegioRegiao -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pwreg___regioregiao__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pwreg___regioregiao__DoLoad = true;
			CriteriaSet pwreg___regioregiao__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("regio", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pwreg___regioregiao__Conds.Equal(CSGenioAregio.FldCodregia, hValue);
					this.ValCodregia = DBConversion.ToString(hValue);
				}
			}

			TableRegioRegiao = new TableDBEdit<Models.Regio>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}
				FillDependant_PwregTableRegioRegiao(lazyLoad);
				return;
			}

			if (pwreg___regioregiao__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRegioRegiao, "sTableRegioRegiao", "dTableRegioRegiao", qs, "regio");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregio.FldRegiao), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRegioRegiao_tableFilters"]))
					TableRegioRegiao.TableFilters = bool.Parse(qs["TableRegioRegiao_tableFilters"]);
				else
					TableRegioRegiao.TableFilters = false;

				query = qs["qTableRegioRegiao"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAregio.FldRegiao, query + "%");
				}
				pwreg___regioregiao__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRegioRegiao"] != null ? qs["pTableRegioRegiao"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioAregio.FldZzstate };

// USE /[MANUAL GQT OVERRQ PWREG_REGIOREGIAO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("regio", FormMode.New) || Navigation.checkFormMode("regio", FormMode.Duplicate))
					pwreg___regioregiao__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAregio.FldZzstate, 0)
						.Equal(CSGenioAregio.FldCodregia, Navigation.GetStrValue("regio")));
				else
					pwreg___regioregiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregio.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("regio", "regiao");
				ListingMVC<CSGenioAregio> listing = Models.ModelBase.Where<CSGenioAregio>(m_userContext, false, pwreg___regioregiao__Conds, fields, offset, numberItems, sorts, "LED_PWREG___REGIOREGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRegioRegiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRegioRegiao.Query = query;
				TableRegioRegiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regio>((r) => new GenioMVC.Models.Regio(m_userContext, r, true, _fieldsToSerialize_PWREG___REGIOREGIAO__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}

				TableRegioRegiao.List = new SelectList(TableRegioRegiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
				FillDependant_PwregTableRegioRegiao();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Regio</param>
		public ConcurrentDictionary<string, object> GetDependant_PwregTableRegioRegiao(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao];

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

			CSGenioAregio tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAregio.FldCodregia, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PwregTableRegioRegiao(bool lazyLoad = false)
		{
			var row = GetDependant_PwregTableRegioRegiao(this.ValCodregia);
			try
			{

				// Fill List fields
				this.ValCodregia = ViewModelConversion.ToString(row["regio.codregia"]);
				TableRegioRegiao.Value = (string)row["regio.regiao"];
				if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
				{
					this.ValCodregia = "";
					TableRegioRegiao.Value = "";
					Navigation.ClearValue("regio");
				}
				else if (lazyLoad)
				{
					TableRegioRegiao.SetPagination(1, 0, false, false, 1);
					TableRegioRegiao.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodregia),
							Text = Convert.ToString(TableRegioRegiao.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodregia);
				}

				TableRegioRegiao.Selected = this.ValCodregia;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegioRegiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PWREG___REGIOREGIAO__ = ["Regio", "Regio.ValCodregia", "Regio.ValZzstate", "Regio.ValRegiao"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pwreg.codpsw" => ViewModelConversion.ToString(modelValue),
				"pwreg.codregia" => ViewModelConversion.ToString(modelValue),
				"pwreg.codpwreg" => ViewModelConversion.ToString(modelValue),
				"psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"psw.nome" => ViewModelConversion.ToString(modelValue),
				"regio.codregia" => ViewModelConversion.ToString(modelValue),
				"regio.regiao" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PWREG]/

		#endregion
	}
}
