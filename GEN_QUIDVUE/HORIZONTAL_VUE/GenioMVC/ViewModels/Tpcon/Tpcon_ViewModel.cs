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

namespace GenioMVC.ViewModels.Tpcon
{
	public class Tpcon_ViewModel : FormViewModel<Models.Tpcon>, IPreparableForSerialization
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
		/// Title: "Genre" | Type: "CE"
		/// </summary>
		public string ValCodgenre { get; set; }

		#endregion
		/// <summary>
		/// Title: "Genre" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Genre> TableGenreGender { get; set; }
		/// <summary>
		/// Title: "Contact Type:" | Type: "C"
		/// </summary>
		public string ValTipocont { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtpcon { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tpcon_ViewModel() : base(null!) { }

		public Tpcon_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTPCON", nestedForm) { }

		public Tpcon_ViewModel(UserContext userContext, Models.Tpcon row, bool nestedForm = false) : base(userContext, "FTPCON", row, nestedForm) { }

		public Tpcon_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tpcon", id);
			Model = Models.Tpcon.Find(id, userContext, "FTPCON", fieldsToQuery: fieldsToLoad);
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
			Models.Tpcon model = new Models.Tpcon(userContext) { Identifier = "FTPCON" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FTPCON");
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
		public override void MapFromModel(Models.Tpcon m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpcon) to ViewModel (Tpcon) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
				ValTipocont = ViewModelConversion.ToString(m.ValTipocont);
				ValCodtpcon = ViewModelConversion.ToString(m.ValCodtpcon);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tpcon) to ViewModel (Tpcon) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tpcon m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcon) to Model (Tpcon) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
				m.ValTipocont = ViewModelConversion.ToString(ValTipocont);
				m.ValCodtpcon = ViewModelConversion.ToString(ValCodtpcon);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Tpcon) to Model (Tpcon) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "tpcon.codgenre":
						this.ValCodgenre = ViewModelConversion.ToString(_value);
						break;
					case "tpcon.tipocont":
						this.ValTipocont = ViewModelConversion.ToString(_value);
						break;
					case "tpcon.codtpcon":
						this.ValCodtpcon = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Tpcon) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Tpcon)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Tpcon.Find(id ?? Navigation.GetStrValue("tpcon"), m_userContext, "FTPCON"); }
			finally { Model ??= new Models.Tpcon(m_userContext) { Identifier = "FTPCON" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), m_userContext, "FTPCON");
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

			Model.Identifier = "FTPCON";
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

		protected override void LoadDocumentsProperties(Models.Tpcon row)
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
				Model = Models.Tpcon.Find(Navigation.GetStrValue("tpcon"), m_userContext, "FTPCON");
				if (Model == null)
				{
					Model = new Models.Tpcon(m_userContext) { Identifier = "FTPCON" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tpcon");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tpcon___genregender__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPCON]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPCON]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTipocont", Resources.Resources.CONTACT_TYPE_27897, ValTipocont, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE TPCON]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPCON]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPCON]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPCON]/
		public override void Destroy(string id)
		{
			Model = Models.Tpcon.Find(id, m_userContext, "FTPCON");
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
		/// TableGenreGender -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tpcon___genregender__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tpcon___genregender__DoLoad = true;
			CriteriaSet tpcon___genregender__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("genre", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tpcon___genregender__Conds.Equal(CSGenioAgenre.FldCodgenre, hValue);
					this.ValCodgenre = DBConversion.ToString(hValue);
				}
			}

			TableGenreGender = new TableDBEdit<Models.Genre>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}
				FillDependant_TpconTableGenreGender(lazyLoad);
				return;
			}

			if (tpcon___genregender__DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableGenreGender, "sTableGenreGender", "dTableGenreGender", qs, "genre");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgenre.FldGender), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGenreGender_tableFilters"]))
					TableGenreGender.TableFilters = bool.Parse(qs["TableGenreGender_tableFilters"]);
				else
					TableGenreGender.TableFilters = false;

				query = qs["qTableGenreGender"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgenre.FldGender, query + "%");
				}
				tpcon___genregender__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGenreGender"] != null ? qs["pTableGenreGender"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender, CSGenioAgenre.FldZzstate];

// USE /[MANUAL GQT OVERRQ TPCON_GENREGENDER]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("genre", FormMode.New) || Navigation.checkFormMode("genre", FormMode.Duplicate))
					tpcon___genregender__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgenre.FldZzstate, 0)
						.Equal(CSGenioAgenre.FldCodgenre, Navigation.GetStrValue("genre")));
				else
					tpcon___genregender__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgenre.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("genre", "gender");
				ListingMVC<CSGenioAgenre> listing = Models.ModelBase.Where<CSGenioAgenre>(m_userContext, false, tpcon___genregender__Conds, fields, offset, numberItems, sorts, "LED_TPCON___GENREGENDER__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGenreGender.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGenreGender.Query = query;
				TableGenreGender.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Genre(m_userContext, r, true, _fieldsToSerialize_TPCON___GENREGENDER__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_genre") != null)
				{
					this.ValCodgenre = Navigation.GetStrValue("RETURN_genre");
					Navigation.CurrentLevel.SetEntry("RETURN_genre", null);
				}

				TableGenreGender.List = new SelectList(TableGenreGender.Elements.ToSelectList(x => x.ValGender, x => x.ValCodgenre,  x => x.ValCodgenre == this.ValCodgenre), "Value", "Text", this.ValCodgenre);
				FillDependant_TpconTableGenreGender();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGenreGender (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Genre</param>
		public ConcurrentDictionary<string, object> GetDependant_TpconTableGenreGender(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgenre.FldCodgenre, CSGenioAgenre.FldGender];

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

			CSGenioAgenre tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgenre.FldCodgenre, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGenreGender (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TpconTableGenreGender(bool lazyLoad = false)
		{
			var row = GetDependant_TpconTableGenreGender(this.ValCodgenre);
			try
			{

				// Fill List fields
				this.ValCodgenre = ViewModelConversion.ToString(row["genre.codgenre"]);
				TableGenreGender.Value = (string)row["genre.gender"];
				if (GenFunctions.emptyG(this.ValCodgenre) == 1)
				{
					this.ValCodgenre = "";
					TableGenreGender.Value = "";
					Navigation.ClearValue("genre");
				}
				else if (lazyLoad)
				{
					TableGenreGender.SetPagination(1, 0, false, false, 1);
					TableGenreGender.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodgenre),
							Text = Convert.ToString(TableGenreGender.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodgenre);
				}

				TableGenreGender.Selected = this.ValCodgenre;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGenreGender): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TPCON___GENREGENDER__ = ["Genre", "Genre.ValCodgenre", "Genre.ValZzstate", "Genre.ValGender"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tpcon.codgenre" => ViewModelConversion.ToString(modelValue),
				"tpcon.tipocont" => ViewModelConversion.ToString(modelValue),
				"tpcon.codtpcon" => ViewModelConversion.ToString(modelValue),
				"genre.codgenre" => ViewModelConversion.ToString(modelValue),
				"genre.gender" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPCON]/

		#endregion
	}
}
