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

namespace GenioMVC.ViewModels.Proje
{
	public class Proje_ViewModel : FormViewModel<Models.Proje>, IPreparableForSerialization
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
		/// Title: "Year" | Type: "CE"
		/// </summary>
		public string ValCodyear { get; set; }

		#endregion
		/// <summary>
		/// Title: "Project" | Type: "C"
		/// </summary>
		public string ValProjecto { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Year1> TableYear1Year { get; set; }
		/// <summary>
		/// Title: "First" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValPrimeiro { get; set; }
		/// <summary>
		/// Title: "Before" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValBefore { get; set; }
		/// <summary>
		/// Title: "Following" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValFollowin { get; set; }
		/// <summary>
		/// Title: "Last" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValUltimo { get; set; }
		/// <summary>
		/// Title: "Next - previous =" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValSaldo1 { get; set; }
		/// <summary>
		/// Title: "Last - First =" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValSaldo2 { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodproje { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Proje_ViewModel() : base(null!) { }

		public Proje_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPROJE", nestedForm) { }

		public Proje_ViewModel(UserContext userContext, Models.Proje row, bool nestedForm = false) : base(userContext, "FPROJE", row, nestedForm) { }

		public Proje_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("proje", id);
			Model = Models.Proje.Find(id, userContext, "FPROJE", fieldsToQuery: fieldsToLoad);
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
			Models.Proje model = new Models.Proje(userContext) { Identifier = "FPROJE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPROJE");
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
			Models.Proje model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Proje m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Proje) to ViewModel (Proje) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
				ValProjecto = ViewModelConversion.ToString(m.ValProjecto);
				ValPrimeiro = ViewModelConversion.ToNumeric(m.ValPrimeiro);
				ValBefore = ViewModelConversion.ToNumeric(m.ValBefore);
				ValFollowin = ViewModelConversion.ToNumeric(m.ValFollowin);
				ValUltimo = ViewModelConversion.ToNumeric(m.ValUltimo);
				ValSaldo1 = ViewModelConversion.ToNumeric(m.ValSaldo1);
				ValSaldo2 = ViewModelConversion.ToNumeric(m.ValSaldo2);
				ValCodproje = ViewModelConversion.ToString(m.ValCodproje);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Proje) to ViewModel (Proje) - Error during mapping");
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
		public override void MapToModel(Models.Proje m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proje) to Model (Proje) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
				m.ValProjecto = ViewModelConversion.ToString(ValProjecto);
				m.ValCodproje = ViewModelConversion.ToString(ValCodproje);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValPrimeiro = ViewModelConversion.ToNumeric(ValPrimeiro);
				m.ValBefore = ViewModelConversion.ToNumeric(ValBefore);
				m.ValFollowin = ViewModelConversion.ToNumeric(ValFollowin);
				m.ValUltimo = ViewModelConversion.ToNumeric(ValUltimo);
				m.ValSaldo1 = ViewModelConversion.ToNumeric(ValSaldo1);
				m.ValSaldo2 = ViewModelConversion.ToNumeric(ValSaldo2);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Proje) to Model (Proje) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "proje.codyear":
						this.ValCodyear = ViewModelConversion.ToString(_value);
						break;
					case "proje.projecto":
						this.ValProjecto = ViewModelConversion.ToString(_value);
						break;
					case "proje.codproje":
						this.ValCodproje = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Proje) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Proje)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Proje.Find(id ?? Navigation.GetStrValue("proje"), m_userContext, "FPROJE"); }
			finally { Model ??= new Models.Proje(m_userContext) { Identifier = "FPROJE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Proje.Find(Navigation.GetStrValue("proje"), m_userContext, "FPROJE");
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

			Model.Identifier = "FPROJE";
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

		protected override void LoadDocumentsProperties(Models.Proje row)
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
				Model = Models.Proje.Find(Navigation.GetStrValue("proje"), m_userContext, "FPROJE");
				if (Model == null)
				{
					Model = new Models.Proje(m_userContext) { Identifier = "FPROJE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("proje");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Proje___year1year____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROJE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROJE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValProjecto", Resources.Resources.PROJECT37121, ValProjecto, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PROJE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROJE]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROJE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROJE]/
		public override void Destroy(string id)
		{
			Model = Models.Proje.Find(id, m_userContext, "FPROJE");
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
		/// TableYear1Year -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Proje___year1year____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool proje___year1year____DoLoad = true;
			CriteriaSet proje___year1year____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("year1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					proje___year1year____Conds.Equal(CSGenioAyear1.FldCodyear, hValue);
					this.ValCodyear = DBConversion.ToString(hValue);
				}
			}

			TableYear1Year = new TableDBEdit<Models.Year1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_year1") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year1");
					Navigation.CurrentLevel.SetEntry("RETURN_year1", null);
				}
				FillDependant_ProjeTableYear1Year(lazyLoad);
				return;
			}

			if (proje___year1year____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableYear1Year, "sTableYear1Year", "dTableYear1Year", qs, "year1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAyear1.FldYear), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableYear1Year_tableFilters"]))
					TableYear1Year.TableFilters = bool.Parse(qs["TableYear1Year_tableFilters"]);
				else
					TableYear1Year.TableFilters = false;

				query = qs["qTableYear1Year"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAyear1.FldYear, query + "%");
				}
				proje___year1year____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableYear1Year"] != null ? qs["pTableYear1Year"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAyear1.FldCodyear, CSGenioAyear1.FldYear, CSGenioAyear1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROJE_YEAR1YEAR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("year1", FormMode.New) || Navigation.checkFormMode("year1", FormMode.Duplicate))
					proje___year1year____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAyear1.FldZzstate, 0)
						.Equal(CSGenioAyear1.FldCodyear, Navigation.GetStrValue("year1")));
				else
					proje___year1year____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAyear1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("year1", "year");
				ListingMVC<CSGenioAyear1> listing = Models.ModelBase.Where<CSGenioAyear1>(m_userContext, false, proje___year1year____Conds, fields, offset, numberItems, sorts, "LED_PROJE___YEAR1YEAR____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableYear1Year.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableYear1Year.Query = query;
				TableYear1Year.Elements = listing.RowsForViewModel<GenioMVC.Models.Year1>((r) => new GenioMVC.Models.Year1(m_userContext, r, true, _fieldsToSerialize_PROJE___YEAR1YEAR____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_year1") != null)
				{
					this.ValCodyear = Navigation.GetStrValue("RETURN_year1");
					Navigation.CurrentLevel.SetEntry("RETURN_year1", null);
				}

				TableYear1Year.List = new SelectList(TableYear1Year.Elements.ToSelectList(x => x.ValYear, x => x.ValCodyear,  x => x.ValCodyear == this.ValCodyear), "Value", "Text", this.ValCodyear);
				FillDependant_ProjeTableYear1Year();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableYear1Year (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Year1</param>
		public ConcurrentDictionary<string, object> GetDependant_ProjeTableYear1Year(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAyear1.FldCodyear, CSGenioAyear1.FldYear];

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

			CSGenioAyear1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAyear1.FldCodyear, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableYear1Year (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProjeTableYear1Year(bool lazyLoad = false)
		{
			var row = GetDependant_ProjeTableYear1Year(this.ValCodyear);
			try
			{

				// Fill List fields
				this.ValCodyear = ViewModelConversion.ToString(row["year1.codyear"]);
				TableYear1Year.Value = (string)row["year1.year"];
				if (GlobalFunctions.emptyG(this.ValCodyear) == 1)
				{
					this.ValCodyear = "";
					TableYear1Year.Value = "";
					Navigation.ClearValue("year1");
				}
				else if (lazyLoad)
				{
					TableYear1Year.SetPagination(1, 0, false, false, 1);
					TableYear1Year.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodyear),
							Text = Convert.ToString(TableYear1Year.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodyear);
				}

				TableYear1Year.Selected = this.ValCodyear;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableYear1Year): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROJE___YEAR1YEAR____ = ["Year1", "Year1.ValCodyear", "Year1.ValZzstate", "Year1.ValYear"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"proje.codyear" => ViewModelConversion.ToString(modelValue),
				"proje.projecto" => ViewModelConversion.ToString(modelValue),
				"proje.primeiro" => ViewModelConversion.ToNumeric(modelValue),
				"proje.before" => ViewModelConversion.ToNumeric(modelValue),
				"proje.followin" => ViewModelConversion.ToNumeric(modelValue),
				"proje.ultimo" => ViewModelConversion.ToNumeric(modelValue),
				"proje.saldo1" => ViewModelConversion.ToNumeric(modelValue),
				"proje.saldo2" => ViewModelConversion.ToNumeric(modelValue),
				"proje.codproje" => ViewModelConversion.ToString(modelValue),
				"year1.codyear" => ViewModelConversion.ToString(modelValue),
				"year1.year" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROJE]/

		#endregion
	}
}
