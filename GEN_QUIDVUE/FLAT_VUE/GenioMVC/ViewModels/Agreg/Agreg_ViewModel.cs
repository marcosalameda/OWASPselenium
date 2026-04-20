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

namespace GenioMVC.ViewModels.Agreg
{
	public class Agreg_ViewModel : FormViewModel<Models.Agreg>, IPreparableForSerialization
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
		/// Title: "Project" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodproje { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodyear { get; set; }

		#endregion

		/// <summary>
		/// Title: "Project" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Proje> TableProjeProjecto { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Year> TableYearYear { get; set; }
		/// <summary>
		/// Title: "Value" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValue { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodaggre { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Agreg_ViewModel() : base(null!) { }

		public Agreg_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FAGREG", nestedForm) { }

		public Agreg_ViewModel(UserContext userContext, Models.Agreg row, bool nestedForm = false) : base(userContext, "FAGREG", row, nestedForm) { }

		public Agreg_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("agreg", id);
			Model = Models.Agreg.Find(id, userContext, "FAGREG", fieldsToQuery: fieldsToLoad);
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
			Models.Agreg model = new Models.Agreg(userContext) { Identifier = "FAGREG" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FAGREG");
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
		public override void MapFromModel(Models.Agreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Agreg) to ViewModel (Agreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodproje = ViewModelConversion.ToString(m.ValCodproje);
				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
				ValCodaggre = ViewModelConversion.ToString(m.ValCodaggre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Agreg) to ViewModel (Agreg) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Agreg m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Agreg) to Model (Agreg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodaggre = ViewModelConversion.ToString(ValCodaggre);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodproje = ViewModelConversion.ToString(ValCodproje);
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Agreg) to Model (Agreg) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "agreg.codaggre":
						this.ValCodaggre = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Agreg) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Agreg)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Agreg.Find(id ?? Navigation.GetStrValue("agreg"), m_userContext, "FAGREG"); }
			finally { Model ??= new Models.Agreg(m_userContext) { Identifier = "FAGREG" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), m_userContext, "FAGREG");
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

			Model.Identifier = "FAGREG";
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

		protected override void LoadDocumentsProperties(Models.Agreg row)
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
				Model = Models.Agreg.Find(Navigation.GetStrValue("agreg"), m_userContext, "FAGREG");
				if (Model == null)
				{
					Model = new Models.Agreg(m_userContext) { Identifier = "FAGREG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("agreg");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Agreg___projeprojecto(qs, lazyLoad);
			Load_Agreg___year_year____(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL AGREG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW AGREG]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE AGREG]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY AGREG]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE AGREG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY AGREG]/
		public override void Destroy(string id)
		{
			Model = Models.Agreg.Find(id, m_userContext, "FAGREG");
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
		/// TableProjeProjecto -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Agreg___projeprojecto(NameValueCollection qs, bool lazyLoad = false)
		{
			bool agreg___projeprojectoDoLoad = true;
			CriteriaSet agreg___projeprojectoConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("proje", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					agreg___projeprojectoConds.Equal(CSGenioAproje.FldCodproje, hValue);
					this.ValCodproje = DBConversion.ToString(hValue);
				}
			}

			TableProjeProjecto = new TableDBEdit<Models.Proje>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_proje") != null)
				{
					this.ValCodproje = Navigation.GetStrValue("RETURN_proje");
					Navigation.CurrentLevel.SetEntry("RETURN_proje", null);
				}
				FillDependant_AgregTableProjeProjecto(lazyLoad);
				return;
			}

			if (agreg___projeprojectoDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableProjeProjecto, "sTableProjeProjecto", "dTableProjeProjecto", qs, "proje");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAproje.FldProjecto), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableProjeProjecto_tableFilters"]))
					TableProjeProjecto.TableFilters = bool.Parse(qs["TableProjeProjecto_tableFilters"]);
				else
					TableProjeProjecto.TableFilters = false;

				query = qs["qTableProjeProjecto"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAproje.FldProjecto, query + "%");
				}
				agreg___projeprojectoConds.SubSet(search_filters);

				string tryParsePage = qs["pTableProjeProjecto"] != null ? qs["pTableProjeProjecto"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto, CSGenioAproje.FldZzstate];

// USE /[MANUAL GQT OVERRQ AGREG_PROJEPROJECTO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("proje", FormMode.New) || Navigation.checkFormMode("proje", FormMode.Duplicate))
					agreg___projeprojectoConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAproje.FldZzstate, 0)
						.Equal(CSGenioAproje.FldCodproje, Navigation.GetStrValue("proje")));
				else
					agreg___projeprojectoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAproje.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("proje", "projecto");
				ListingMVC<CSGenioAproje> listing = Models.ModelBase.Where<CSGenioAproje>(m_userContext, false, agreg___projeprojectoConds, fields, offset, numberItems, sorts, "LED_AGREG___PROJEPROJECTO", true, false, firstVisibleColumn: firstVisibleColumn);

				TableProjeProjecto.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableProjeProjecto.Query = query;
				TableProjeProjecto.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Proje(m_userContext, r, true, _fieldsToSerialize_AGREG___PROJEPROJECTO));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_proje") != null)
				{
					this.ValCodproje = Navigation.GetStrValue("RETURN_proje");
					Navigation.CurrentLevel.SetEntry("RETURN_proje", null);
				}

				TableProjeProjecto.List = new SelectList(TableProjeProjecto.Elements.ToSelectList(x => x.ValProjecto, x => x.ValCodproje,  x => x.ValCodproje == this.ValCodproje), "Value", "Text", this.ValCodproje);
				FillDependant_AgregTableProjeProjecto();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableProjeProjecto (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Proje</param>
		public ConcurrentDictionary<string, object> GetDependant_AgregTableProjeProjecto(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto];

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

			CSGenioAproje tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAproje.FldCodproje, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableProjeProjecto (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AgregTableProjeProjecto(bool lazyLoad = false)
		{
			var row = GetDependant_AgregTableProjeProjecto(this.ValCodproje);
			try
			{

				// Fill List fields
				this.ValCodproje = ViewModelConversion.ToString(row["proje.codproje"]);
				TableProjeProjecto.Value = (string)row["proje.projecto"];
				if (GenFunctions.emptyG(this.ValCodproje) == 1)
				{
					this.ValCodproje = "";
					TableProjeProjecto.Value = "";
					Navigation.ClearValue("proje");
				}
				else if (lazyLoad)
				{
					TableProjeProjecto.SetPagination(1, 0, false, false, 1);
					TableProjeProjecto.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodproje),
							Text = Convert.ToString(TableProjeProjecto.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodproje);
				}

				TableProjeProjecto.Selected = this.ValCodproje;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableProjeProjecto): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_AGREG___PROJEPROJECTO = ["Proje", "Proje.ValCodproje", "Proje.ValZzstate", "Proje.ValProjecto"];

		/// <summary>
		/// TableYearYear -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Agreg___year_year____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool agreg___year_year____DoLoad = true;
			CriteriaSet agreg___year_year____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("year", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					agreg___year_year____Conds.Equal(CSGenioAyear.FldCodyear, hValue);
					this.ValCodyear = DBConversion.ToString(hValue);
				}
			}

			TableYearYear = new TableDBEdit<Models.Year>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_year") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year");
					Navigation.CurrentLevel.SetEntry("RETURN_year", null);
				}
				FillDependant_AgregTableYearYear(lazyLoad);
				return;
			}

			if (agreg___year_year____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableYearYear, "sTableYearYear", "dTableYearYear", qs, "year");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAyear.FldYear), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableYearYear_tableFilters"]))
					TableYearYear.TableFilters = bool.Parse(qs["TableYearYear_tableFilters"]);
				else
					TableYearYear.TableFilters = false;

				query = qs["qTableYearYear"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAyear.FldYear, query + "%");
				}
				agreg___year_year____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableYearYear"] != null ? qs["pTableYearYear"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAyear.FldZzstate];

// USE /[MANUAL GQT OVERRQ AGREG_YEARYEAR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("year", FormMode.New) || Navigation.checkFormMode("year", FormMode.Duplicate))
					agreg___year_year____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAyear.FldZzstate, 0)
						.Equal(CSGenioAyear.FldCodyear, Navigation.GetStrValue("year")));
				else
					agreg___year_year____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAyear.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("year", "year");
				ListingMVC<CSGenioAyear> listing = Models.ModelBase.Where<CSGenioAyear>(m_userContext, false, agreg___year_year____Conds, fields, offset, numberItems, sorts, "LED_AGREG___YEAR_YEAR____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableYearYear.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableYearYear.Query = query;
				TableYearYear.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Year(m_userContext, r, true, _fieldsToSerialize_AGREG___YEAR_YEAR____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_year") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year");
					Navigation.CurrentLevel.SetEntry("RETURN_year", null);
				}

				TableYearYear.List = new SelectList(TableYearYear.Elements.ToSelectList(x => x.ValYear, x => x.ValCodyear,  x => x.ValCodyear == this.ValCodyear), "Value", "Text", this.ValCodyear);
				FillDependant_AgregTableYearYear();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableYearYear (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Year</param>
		public ConcurrentDictionary<string, object> GetDependant_AgregTableYearYear(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAyear.FldCodyear, CSGenioAyear.FldYear];

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

			CSGenioAyear tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAyear.FldCodyear, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableYearYear (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AgregTableYearYear(bool lazyLoad = false)
		{
			var row = GetDependant_AgregTableYearYear(this.ValCodyear);
			try
			{

				// Fill List fields
				this.ValCodyear = ViewModelConversion.ToString(row["year.codyear"]);
				TableYearYear.Value = (string)row["year.year"];
				if (GenFunctions.emptyG(this.ValCodyear) == 1)
				{
					this.ValCodyear = "";
					TableYearYear.Value = "";
					Navigation.ClearValue("year");
				}
				else if (lazyLoad)
				{
					TableYearYear.SetPagination(1, 0, false, false, 1);
					TableYearYear.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodyear),
							Text = Convert.ToString(TableYearYear.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodyear);
				}

				TableYearYear.Selected = this.ValCodyear;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableYearYear): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_AGREG___YEAR_YEAR____ = ["Year", "Year.ValCodyear", "Year.ValZzstate", "Year.ValYear"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"agreg.codproje" => ViewModelConversion.ToString(modelValue),
				"agreg.codyear" => ViewModelConversion.ToString(modelValue),
				"agreg.value" => ViewModelConversion.ToNumeric(modelValue),
				"agreg.codaggre" => ViewModelConversion.ToString(modelValue),
				"proje.codproje" => ViewModelConversion.ToString(modelValue),
				"proje.projecto" => ViewModelConversion.ToString(modelValue),
				"year.codyear" => ViewModelConversion.ToString(modelValue),
				"year.year" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM AGREG]/

		#endregion
	}
}
