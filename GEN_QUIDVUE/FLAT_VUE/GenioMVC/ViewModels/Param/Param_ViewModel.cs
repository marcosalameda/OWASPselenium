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

namespace GenioMVC.ViewModels.Param
{
	public class Param_ViewModel : FormViewModel<Models.Param>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Kind of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Kinde> TableKindeDesignat { get; set; }

		/// <summary>
		/// Title: "Parameter" | Type: "C"
		/// </summary>
		public string ValParameter { get; set; }

		/// <summary>
		/// Title: "Data type" | Type: "AC"
		/// </summary>
		public string ValDatatype { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValDatatype { get; set; }

		/// <summary>
		/// Title: "Decimal places" | Type: "AN"
		/// </summary>
		public double ValDecimalplaces { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValDecimalplaces { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Kind of equipment" | Type: "CE"
		/// </summary>
		public string ValCodkinde { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodparam { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Param_ViewModel() : base(null!) { }

		public Param_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPARAM", nestedForm) { }

		public Param_ViewModel(UserContext userContext, Models.Param row, bool nestedForm = false) : base(userContext, "FPARAM", row, nestedForm) { }

		public Param_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("param", id);
			Model = Models.Param.Find(id, userContext, "FPARAM", fieldsToQuery: fieldsToLoad);
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
			Models.Param model = new Models.Param(userContext) { Identifier = "FPARAM" };
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
			Models.Param model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Param m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Param) to ViewModel (Param) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValParameter = ViewModelConversion.ToString(m.ValParameter);
				ValDatatype = ViewModelConversion.ToString(m.ValDatatype);
				ValDecimalplaces = ViewModelConversion.ToDouble(m.ValDecimalplaces);
				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
				ValCodparam = ViewModelConversion.ToString(m.ValCodparam);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Param) to ViewModel (Param) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Param m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Param) to Model (Param) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValParameter = ViewModelConversion.ToString(ValParameter);
				m.ValDatatype = ViewModelConversion.ToString(ValDatatype);
				m.ValDecimalplaces = ViewModelConversion.ToDouble(ValDecimalplaces);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
				m.ValCodparam = ViewModelConversion.ToString(ValCodparam);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Param) to Model (Param) - Error during mapping");
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
				Model = Models.Param.Find(Navigation.GetStrValue("param"), m_userContext, "FPARAM");
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

			Model.Identifier = "FPARAM";
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

		protected override void LoadDocumentsProperties(Models.Param row)
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
				Model = Models.Param.Find(Navigation.GetStrValue("param"), m_userContext, "FPARAM");
				if (Model == null)
				{
					Model = new Models.Param(m_userContext) { Identifier = "FPARAM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("param");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Param___kindedesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PARAM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PARAM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValParameter", Resources.Resources.PARAMETER41976, ValParameter, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PARAM]/
		public override void Save()
		{

			try { Model = Models.Param.Find(Navigation.GetStrValue("param"), m_userContext, "FPARAM"); }
			finally { if (Model == null) Model = new Models.Param(m_userContext) { Identifier = "FPARAM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PARAM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Param.Find(Navigation.GetStrValue("param"), m_userContext, "FPARAM"); }
			finally { if (Model == null) Model = new Models.Param(m_userContext) { Identifier = "FPARAM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PARAM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PARAM]/
		public override void Destroy(string id)
		{
			Model = Models.Param.Find(id, m_userContext, "FPARAM");
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
		/// TableKindeDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Param___kindedesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool param___kindedesignatDoLoad = true;
			CriteriaSet param___kindedesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("kinde", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					param___kindedesignatConds.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetValue("kinde"));
					this.ValCodkinde = Navigation.GetStrValue("kinde");
				}
			}

			TableKindeDesignat = new TableDBEdit<Models.Kinde>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}
				FillDependant_ParamTableKindeDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
				return;
			}

			if (param___kindedesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableKindeDesignat, "sTableKindeDesignat", "dTableKindeDesignat", qs, "kinde");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAkinde.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableKindeDesignat_tableFilters"]))
					TableKindeDesignat.TableFilters = bool.Parse(qs["TableKindeDesignat_tableFilters"]);
				else
					TableKindeDesignat.TableFilters = false;

				query = qs["qTableKindeDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAkinde.FldDesignat, query + "%");
				}
				param___kindedesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableKindeDesignat"] != null ? qs["pTableKindeDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAkinde.FldZzstate };

// USE /[MANUAL GQT OVERRQ PARAM_KINDEDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("kinde", FormMode.New) || Navigation.checkFormMode("kinde", FormMode.Duplicate))
					param___kindedesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAkinde.FldZzstate, 0)
						.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetStrValue("kinde")));
				else
					param___kindedesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAkinde.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("kinde", "designat");
				ListingMVC<CSGenioAkinde> listing = Models.ModelBase.Where<CSGenioAkinde>(m_userContext, false, param___kindedesignatConds, fields, offset, numberItems, sorts, "LED_PARAM___KINDEDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableKindeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableKindeDesignat.Query = query;
				TableKindeDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Kinde>((r) => new GenioMVC.Models.Kinde(m_userContext, r, true, _fieldsToSerialize_PARAM___KINDEDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}

				TableKindeDesignat.List = new SelectList(TableKindeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodkinde,  x => x.ValCodkinde == this.ValCodkinde), "Value", "Text", this.ValCodkinde);
				FillDependant_ParamTableKindeDesignat();

				//Check if foreignkey comes from history
				TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Kinde</param>
		public ConcurrentDictionary<string, object> GetDependant_ParamTableKindeDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat];

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

			CSGenioAkinde tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAkinde.FldCodkinde, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ParamTableKindeDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_ParamTableKindeDesignat(this.ValCodkinde);
			try
			{

				// Fill List fields
				this.ValCodkinde = ViewModelConversion.ToString(row["kinde.codkinde"]);
				TableKindeDesignat.Value = (string)row["kinde.designat"];
				if (GlobalFunctions.emptyG(this.ValCodkinde) == 1)
				{
					this.ValCodkinde = "";
					TableKindeDesignat.Value = "";
					Navigation.ClearValue("kinde");
				}
				else if (lazyLoad)
				{
					TableKindeDesignat.SetPagination(1, 0, false, false, 1);
					TableKindeDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodkinde),
							Text = Convert.ToString(TableKindeDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodkinde);
				}

				TableKindeDesignat.Selected = this.ValCodkinde;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableKindeDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PARAM___KINDEDESIGNAT = ["Kinde", "Kinde.ValCodkinde", "Kinde.ValZzstate", "Kinde.ValDesignat"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"param.parameter" => ViewModelConversion.ToString(modelValue),
				"param.datatype" => ViewModelConversion.ToString(modelValue),
				"param.decimalplaces" => ViewModelConversion.ToDouble(modelValue),
				"param.codkinde" => ViewModelConversion.ToString(modelValue),
				"param.codparam" => ViewModelConversion.ToString(modelValue),
				"kinde.codkinde" => ViewModelConversion.ToString(modelValue),
				"kinde.designat" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PARAM]/

		#endregion
	}
}
