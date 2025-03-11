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

namespace GenioMVC.ViewModels.Glob
{
	public class Globfact_ViewModel : FormViewModel<Models.Glob>, IPreparableForSerialization
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
		/// Title: "Facility type" | Type: "CE"
		/// </summary>
		public string ValCodfacty { get; set; }

		#endregion
		/// <summary>
		/// Title: "Facility type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Facty> TableFactyType { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Home text" Tipo: "MO"</summary>
		[ValidateSetAccess]
		public string ValHome { get; set; }

		#endregion

		public string ValCodglob { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Globfact_ViewModel() : base(null!) { }

		public Globfact_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGLOBFACT", nestedForm) { }

		public Globfact_ViewModel(UserContext userContext, Models.Glob row, bool nestedForm = false) : base(userContext, "FGLOBFACT", row, nestedForm) { }

		public Globfact_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("glob", id);
			Model = Models.Glob.Find(id, userContext, "FGLOBFACT", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Glob model = new Models.Glob(userContext) { Identifier = "FGLOBFACT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FGLOBFACT");
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
			Models.Glob model = Model;
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
		public override void MapFromModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Globfact) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
				ValHome = ViewModelConversion.ToString(m.ValHome);
				ValCodglob = ViewModelConversion.ToString(m.ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Globfact) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Globfact) to Model (Glob) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValCodglob = ViewModelConversion.ToString(ValCodglob);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValHome = ViewModelConversion.ToString(ValHome);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Globfact) to Model (Glob) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "glob.codfacty":
						this.ValCodfacty = ViewModelConversion.ToString(_value);
						break;
					case "glob.codglob":
						this.ValCodglob = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Globfact) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Globfact)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Glob.Find(id ?? Navigation.GetStrValue("glob"), m_userContext, "FGLOBFACT"); }
			finally { Model ??= new Models.Glob(m_userContext) { Identifier = "FGLOBFACT" }; }

			base.LoadModel();
		}

		public void LoadGlob()
		{
			LoadGlob(new NameValueCollection(), false, false);
		}

		public override void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false)
		{
			this.editable = editable;

			Model = Models.Glob.GetGlob(m_userContext, true);

			if (Model == null)
				throw new ModelNotFoundException("Model not found");

			InitModel(qs);
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOBFACT");
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

			Model.Identifier = "FGLOBFACT";
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

		protected override void LoadDocumentsProperties(Models.Glob row)
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
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOBFACT");
				if (Model == null)
				{
					Model = new Models.Glob(m_userContext) { Identifier = "FGLOBFACT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Globfactfactytype____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GLOBFACT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GLOBFACT]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE GLOBFACT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GLOBFACT]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GLOBFACT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GLOBFACT]/
		public override void Destroy(string id)
		{
			Model = Models.Glob.Find(id, m_userContext, "FGLOBFACT");
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
		/// TableFactyType -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Globfactfactytype____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool globfactfactytype____DoLoad = true;
			CriteriaSet globfactfactytype____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("facty", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					globfactfactytype____Conds.Equal(CSGenioAfacty.FldCodfacty, hValue);
					this.ValCodfacty = DBConversion.ToString(hValue);
				}
			}

			TableFactyType = new TableDBEdit<Models.Facty>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}
				FillDependant_GlobfactTableFactyType(lazyLoad);
				return;
			}

			if (globfactfactytype____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableFactyType, "sTableFactyType", "dTableFactyType", qs, "facty");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFactyType_tableFilters"]))
					TableFactyType.TableFilters = bool.Parse(qs["TableFactyType_tableFilters"]);
				else
					TableFactyType.TableFilters = false;

				query = qs["qTableFactyType"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfacty.FldType, query + "%");
				}
				globfactfactytype____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFactyType"] != null ? qs["pTableFactyType"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType, CSGenioAfacty.FldZzstate };

// USE /[MANUAL GQT OVERRQ GLOBFACT_FACTYTYPE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("facty", FormMode.New) || Navigation.checkFormMode("facty", FormMode.Duplicate))
					globfactfactytype____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfacty.FldZzstate, 0)
						.Equal(CSGenioAfacty.FldCodfacty, Navigation.GetStrValue("facty")));
				else
					globfactfactytype____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacty.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("facty", "type");
				ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(m_userContext, false, globfactfactytype____Conds, fields, offset, numberItems, sorts, "LED_GLOBFACTFACTYTYPE____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFactyType.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFactyType.Query = query;
				TableFactyType.Elements = listing.RowsForViewModel<GenioMVC.Models.Facty>((r) => new GenioMVC.Models.Facty(m_userContext, r, true, _fieldsToSerialize_GLOBFACTFACTYTYPE____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}

				TableFactyType.List = new SelectList(TableFactyType.Elements.ToSelectList(x => x.ValType, x => x.ValCodfacty,  x => x.ValCodfacty == this.ValCodfacty), "Value", "Text", this.ValCodfacty);
				FillDependant_GlobfactTableFactyType();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFactyType (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Facty</param>
		public ConcurrentDictionary<string, object> GetDependant_GlobfactTableFactyType(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType];

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

			CSGenioAfacty tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfacty.FldCodfacty, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFactyType (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_GlobfactTableFactyType(bool lazyLoad = false)
		{
			var row = GetDependant_GlobfactTableFactyType(this.ValCodfacty);
			try
			{

				// Fill List fields
				this.ValCodfacty = ViewModelConversion.ToString(row["facty.codfacty"]);
				TableFactyType.Value = (string)row["facty.type"];
				if (GlobalFunctions.emptyG(this.ValCodfacty) == 1)
				{
					this.ValCodfacty = "";
					TableFactyType.Value = "";
					Navigation.ClearValue("facty");
				}
				else if (lazyLoad)
				{
					TableFactyType.SetPagination(1, 0, false, false, 1);
					TableFactyType.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodfacty),
							Text = Convert.ToString(TableFactyType.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodfacty);
				}

				TableFactyType.Selected = this.ValCodfacty;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFactyType): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GLOBFACTFACTYTYPE____ = ["Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"glob.codfacty" => ViewModelConversion.ToString(modelValue),
				"glob.home" => ViewModelConversion.ToString(modelValue),
				"glob.codglob" => ViewModelConversion.ToString(modelValue),
				"facty.codfacty" => ViewModelConversion.ToString(modelValue),
				"facty.type" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GLOBFACT]/

		#endregion
	}
}
