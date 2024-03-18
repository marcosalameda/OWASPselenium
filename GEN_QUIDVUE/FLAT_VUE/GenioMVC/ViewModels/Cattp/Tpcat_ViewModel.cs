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

namespace GenioMVC.ViewModels.Cattp
{
	public class Tpcat_ViewModel : FormViewModel<Models.Cattp>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Category type" | Type: "C"
		/// </summary>
		public string ValTpcatego { get; set; }

		/// <summary>
		/// Title: "Sub categoria" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Sbcat> TableSbcatSubcateg { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Sub categoria" | Type: "CE"
		/// </summary>
		public string ValCodsbcat { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtpcat { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tpcat_ViewModel() : base(null!) { }

		public Tpcat_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTPCAT", nestedForm) { }

		public Tpcat_ViewModel(UserContext userContext, Models.Cattp row, bool nestedForm = false) : base(userContext, "FTPCAT", row, nestedForm) { }

		public Tpcat_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("cattp", id);
			Model = Models.Cattp.Find(id, userContext, "FTPCAT", fieldsToQuery: fieldsToLoad);
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
			Models.Cattp model = new Models.Cattp(userContext) { Identifier = "FTPCAT" };
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
			Models.Cattp model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cattp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cattp) to ViewModel (Tpcat) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValTpcatego = ViewModelConversion.ToString(m.ValTpcatego);
				ValCodsbcat = ViewModelConversion.ToString(m.ValCodsbcat);
				ValCodtpcat = ViewModelConversion.ToString(m.ValCodtpcat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cattp) to ViewModel (Tpcat) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cattp m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcat) to Model (Cattp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTpcatego = ViewModelConversion.ToString(ValTpcatego);
				m.ValCodsbcat = ViewModelConversion.ToString(ValCodsbcat);
				m.ValCodtpcat = ViewModelConversion.ToString(ValCodtpcat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpcat) to Model (Cattp) - Error during mapping");
				throw;
			}
		}

		#endregion


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), m_userContext, "FTPCAT");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FTPCAT";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
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

		protected override void LoadDocumentsProperties(Models.Cattp row)
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
				Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), m_userContext, "FTPCAT");
				if (Model == null)
				{
					Model = new Models.Cattp(m_userContext) { Identifier = "FTPCAT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cattp");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tpcat___sbcatsubcateg(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPCAT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPCAT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValTpcatego", Resources.Resources.CATEGORY_TYPE23058, ValTpcatego, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPCAT]/
		public override void Save()
		{

			try { Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), m_userContext, "FTPCAT"); }
			finally { if (Model == null) Model = new Models.Cattp(m_userContext) { Identifier = "FTPCAT" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPCAT]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cattp.Find(Navigation.GetStrValue("cattp"), m_userContext, "FTPCAT"); }
			finally { if (Model == null) Model = new Models.Cattp(m_userContext) { Identifier = "FTPCAT" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPCAT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPCAT]/
		public override void Destroy(string id)
		{
			Model = Models.Cattp.Find(id, m_userContext, "FTPCAT");
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
		/// TableSbcatSubcateg -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tpcat___sbcatsubcateg(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tpcat___sbcatsubcategDoLoad = true;
			CriteriaSet tpcat___sbcatsubcategConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("sbcat", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tpcat___sbcatsubcategConds.Equal(CSGenioAsbcat.FldCodsbcat, Navigation.GetValue("sbcat"));
					this.ValCodsbcat = Navigation.GetStrValue("sbcat");
				}
			}

			TableSbcatSubcateg = new TableDBEdit<Models.Sbcat>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_sbcat") != null)
				{
					this.ValCodsbcat = Navigation.GetStrValue("RETURN_sbcat");
					Navigation.CurrentLevel.SetEntry("RETURN_sbcat", null);
				}
				FillDependant_TpcatTableSbcatSubcateg(lazyLoad);
				//Check if foreignkey comes from history
				TableSbcatSubcateg.FilledByHistory = Navigation.CheckFilledByHistory("sbcat");
				return;
			}

			if (tpcat___sbcatsubcategDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableSbcatSubcateg, "sTableSbcatSubcateg", "dTableSbcatSubcateg", qs, "sbcat");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsbcat.FldSubcateg), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableSbcatSubcateg_tableFilters"]))
					TableSbcatSubcateg.TableFilters = bool.Parse(qs["TableSbcatSubcateg_tableFilters"]);
				else
					TableSbcatSubcateg.TableFilters = false;

				query = qs["qTableSbcatSubcateg"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAsbcat.FldSubcateg, query + "%");
				}
				tpcat___sbcatsubcategConds.SubSet(search_filters);

				string tryParsePage = qs["pTableSbcatSubcateg"] != null ? qs["pTableSbcatSubcateg"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAsbcat.FldCodsbcat, CSGenioAsbcat.FldSubcateg, CSGenioAsbcat.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPCAT_SBCATSUBCATEG]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("sbcat", FormMode.New) || Navigation.checkFormMode("sbcat", FormMode.Duplicate))
					tpcat___sbcatsubcategConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAsbcat.FldZzstate, 0)
						.Equal(CSGenioAsbcat.FldCodsbcat, Navigation.GetStrValue("sbcat")));
				else
					tpcat___sbcatsubcategConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAsbcat.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("sbcat", "subcateg");
				ListingMVC<CSGenioAsbcat> listing = Models.ModelBase.Where<CSGenioAsbcat>(m_userContext, false, tpcat___sbcatsubcategConds, fields, offset, numberItems, sorts, "LED_TPCAT___SBCATSUBCATEG", true, false, firstVisibleColumn: firstVisibleColumn);

				TableSbcatSubcateg.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableSbcatSubcateg.Query = query;
				TableSbcatSubcateg.Elements = listing.RowsForViewModel<GenioMVC.Models.Sbcat>((r) => new GenioMVC.Models.Sbcat(m_userContext, r, true, _fieldsToSerialize_TPCAT___SBCATSUBCATEG));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_sbcat") != null)
				{
					this.ValCodsbcat = Navigation.GetStrValue("RETURN_sbcat");
					Navigation.CurrentLevel.SetEntry("RETURN_sbcat", null);
				}

				TableSbcatSubcateg.List = new SelectList(TableSbcatSubcateg.Elements.ToSelectList(x => x.ValSubcateg, x => x.ValCodsbcat,  x => x.ValCodsbcat == this.ValCodsbcat), "Value", "Text", this.ValCodsbcat);
				FillDependant_TpcatTableSbcatSubcateg();

				//Check if foreignkey comes from history
				TableSbcatSubcateg.FilledByHistory = Navigation.CheckFilledByHistory("sbcat");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableSbcatSubcateg (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Sbcat</param>
		public ConcurrentDictionary<string, object> GetDependant_TpcatTableSbcatSubcateg(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAsbcat.FldCodsbcat, CSGenioAsbcat.FldSubcateg];

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

			CSGenioAsbcat tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAsbcat.FldCodsbcat, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableSbcatSubcateg (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TpcatTableSbcatSubcateg(bool lazyLoad = false)
		{
			var row = GetDependant_TpcatTableSbcatSubcateg(this.ValCodsbcat);
			try
			{

				// Fill List fields
				this.ValCodsbcat = ViewModelConversion.ToString(row["sbcat.codsbcat"]);
				TableSbcatSubcateg.Value = (string)row["sbcat.subcateg"];
				if (GlobalFunctions.emptyG(this.ValCodsbcat) == 1)
				{
					this.ValCodsbcat = "";
					TableSbcatSubcateg.Value = "";
					Navigation.ClearValue("sbcat");
				}
				else if (lazyLoad)
				{
					TableSbcatSubcateg.SetPagination(1, 0, false, false, 1);
					TableSbcatSubcateg.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodsbcat),
							Text = Convert.ToString(TableSbcatSubcateg.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodsbcat);
				}

				TableSbcatSubcateg.Selected = this.ValCodsbcat;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSbcatSubcateg): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TPCAT___SBCATSUBCATEG = ["Sbcat", "Sbcat.ValCodsbcat", "Sbcat.ValZzstate", "Sbcat.ValSubcateg"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"cattp.tpcatego" => ViewModelConversion.ToString(modelValue),
				"cattp.codsbcat" => ViewModelConversion.ToString(modelValue),
				"cattp.codtpcat" => ViewModelConversion.ToString(modelValue),
				"sbcat.codsbcat" => ViewModelConversion.ToString(modelValue),
				"sbcat.subcateg" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPCAT]/

		#endregion
	}
}
