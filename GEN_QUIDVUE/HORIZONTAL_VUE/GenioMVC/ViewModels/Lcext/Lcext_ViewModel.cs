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

namespace GenioMVC.ViewModels.Lcext
{
	public class Lcext_ViewModel : FormViewModel<Models.Lcext>, IPreparableForSerialization
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
		/// Title: "Global Location Number" | Type: "CE"
		/// </summary>
		public string ValCodlocat { get; set; }

		#endregion
		/// <summary>
		/// Title: "Global Location Number" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Locat> TableLocatGln { get; set; }
		/// <summary>
		/// Title: "GLN Extension Component" | Type: "C"
		/// </summary>
		public string ValGlnext { get; set; }
		/// <summary>
		/// Title: "Space type" | Type: "AC"
		/// </summary>
		public string ValSpacetyp { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValSpacetyp { get; set; }
		/// <summary>
		/// Title: "Space" | Type: "C"
		/// </summary>
		public string ValSpaceobs { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodlcext { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Lcext_ViewModel() : base(null!) { }

		public Lcext_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLCEXT", nestedForm) { }

		public Lcext_ViewModel(UserContext userContext, Models.Lcext row, bool nestedForm = false) : base(userContext, "FLCEXT", row, nestedForm) { }

		public Lcext_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("lcext", id);
			Model = Models.Lcext.Find(id, userContext, "FLCEXT", fieldsToQuery: fieldsToLoad);
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
			Models.Lcext model = new Models.Lcext(userContext) { Identifier = "FLCEXT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLCEXT");
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
		public override void MapFromModel(Models.Lcext m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lcext) to ViewModel (Lcext) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodlocat = ViewModelConversion.ToString(m.ValCodlocat);
				ValGlnext = ViewModelConversion.ToString(m.ValGlnext);
				ValSpacetyp = ViewModelConversion.ToString(m.ValSpacetyp);
				ValSpaceobs = ViewModelConversion.ToString(m.ValSpaceobs);
				ValCodlcext = ViewModelConversion.ToString(m.ValCodlcext);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lcext) to ViewModel (Lcext) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lcext m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lcext) to Model (Lcext) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodlocat = ViewModelConversion.ToString(ValCodlocat);
				m.ValGlnext = ViewModelConversion.ToString(ValGlnext);
				m.ValSpacetyp = ViewModelConversion.ToString(ValSpacetyp);
				m.ValSpaceobs = ViewModelConversion.ToString(ValSpaceobs);
				m.ValCodlcext = ViewModelConversion.ToString(ValCodlcext);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Lcext) to Model (Lcext) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "lcext.codlocat":
						this.ValCodlocat = ViewModelConversion.ToString(_value);
						break;
					case "lcext.glnext":
						this.ValGlnext = ViewModelConversion.ToString(_value);
						break;
					case "lcext.spacetyp":
						this.ValSpacetyp = ViewModelConversion.ToString(_value);
						break;
					case "lcext.spaceobs":
						this.ValSpaceobs = ViewModelConversion.ToString(_value);
						break;
					case "lcext.codlcext":
						this.ValCodlcext = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Lcext) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Lcext)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Lcext.Find(id ?? Navigation.GetStrValue("lcext"), m_userContext, "FLCEXT"); }
			finally { Model ??= new Models.Lcext(m_userContext) { Identifier = "FLCEXT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), m_userContext, "FLCEXT");
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

			Model.Identifier = "FLCEXT";
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

		protected override void LoadDocumentsProperties(Models.Lcext row)
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
				Model = Models.Lcext.Find(Navigation.GetStrValue("lcext"), m_userContext, "FLCEXT");
				if (Model == null)
				{
					Model = new Models.Lcext(m_userContext) { Identifier = "FLCEXT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lcext");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Lcext___locatgln_____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LCEXT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LCEXT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValGlnext", Resources.Resources.GLN_EXTENSION_COMPON55869, ValGlnext, 50);
			validator.StringLength("ValSpaceobs", Resources.Resources.SPACE62433, ValSpaceobs, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE LCEXT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LCEXT]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LCEXT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LCEXT]/
		public override void Destroy(string id)
		{
			Model = Models.Lcext.Find(id, m_userContext, "FLCEXT");
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
		/// TableLocatGln -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lcext___locatgln_____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lcext___locatgln_____DoLoad = true;
			CriteriaSet lcext___locatgln_____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("locat", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lcext___locatgln_____Conds.Equal(CSGenioAlocat.FldCodlocat, hValue);
					this.ValCodlocat = DBConversion.ToString(hValue);
				}
			}

			TableLocatGln = new TableDBEdit<Models.Locat>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}
				FillDependant_LcextTableLocatGln(lazyLoad);
				return;
			}

			if (lcext___locatgln_____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableLocatGln, "sTableLocatGln", "dTableLocatGln", qs, "locat");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlocat.FldGln), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLocatGln_tableFilters"]))
					TableLocatGln.TableFilters = bool.Parse(qs["TableLocatGln_tableFilters"]);
				else
					TableLocatGln.TableFilters = false;

				query = qs["qTableLocatGln"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlocat.FldGln, query + "%");
				}
				lcext___locatgln_____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLocatGln"] != null ? qs["pTableLocatGln"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAlocat.FldZzstate];

// USE /[MANUAL GQT OVERRQ LCEXT_LOCATGLN]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("locat", FormMode.New) || Navigation.checkFormMode("locat", FormMode.Duplicate))
					lcext___locatgln_____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlocat.FldZzstate, 0)
						.Equal(CSGenioAlocat.FldCodlocat, Navigation.GetStrValue("locat")));
				else
					lcext___locatgln_____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlocat.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("locat", "gln");
				ListingMVC<CSGenioAlocat> listing = Models.ModelBase.Where<CSGenioAlocat>(m_userContext, false, lcext___locatgln_____Conds, fields, offset, numberItems, sorts, "LED_LCEXT___LOCATGLN_____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLocatGln.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLocatGln.Query = query;
				TableLocatGln.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Locat(m_userContext, r, true, _fieldsToSerialize_LCEXT___LOCATGLN_____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}

				TableLocatGln.List = new SelectList(TableLocatGln.Elements.ToSelectList(x => x.ValGln, x => x.ValCodlocat,  x => x.ValCodlocat == this.ValCodlocat), "Value", "Text", this.ValCodlocat);
				FillDependant_LcextTableLocatGln();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLocatGln (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Locat</param>
		public ConcurrentDictionary<string, object> GetDependant_LcextTableLocatGln(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln];

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

			CSGenioAlocat tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlocat.FldCodlocat, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLocatGln (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LcextTableLocatGln(bool lazyLoad = false)
		{
			var row = GetDependant_LcextTableLocatGln(this.ValCodlocat);
			try
			{

				// Fill List fields
				this.ValCodlocat = ViewModelConversion.ToString(row["locat.codlocat"]);
				TableLocatGln.Value = (string)row["locat.gln"];
				if (GenFunctions.emptyG(this.ValCodlocat) == 1)
				{
					this.ValCodlocat = "";
					TableLocatGln.Value = "";
					Navigation.ClearValue("locat");
				}
				else if (lazyLoad)
				{
					TableLocatGln.SetPagination(1, 0, false, false, 1);
					TableLocatGln.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodlocat),
							Text = Convert.ToString(TableLocatGln.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodlocat);
				}

				TableLocatGln.Selected = this.ValCodlocat;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLocatGln): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LCEXT___LOCATGLN_____ = ["Locat", "Locat.ValCodlocat", "Locat.ValZzstate", "Locat.ValGln"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"lcext.codlocat" => ViewModelConversion.ToString(modelValue),
				"lcext.glnext" => ViewModelConversion.ToString(modelValue),
				"lcext.spacetyp" => ViewModelConversion.ToString(modelValue),
				"lcext.spaceobs" => ViewModelConversion.ToString(modelValue),
				"lcext.codlcext" => ViewModelConversion.ToString(modelValue),
				"locat.codlocat" => ViewModelConversion.ToString(modelValue),
				"locat.gln" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LCEXT]/

		#endregion
	}
}
