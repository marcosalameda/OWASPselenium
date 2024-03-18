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

namespace GenioMVC.ViewModels.Pesso
{
	public class Externo_ViewModel : FormViewModel<Models.Pesso>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Company:" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }

		/// <summary>
		/// Title: "Name:" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Gender" | Type: "AC"
		/// </summary>
		public string ValGender { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }

		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }

		/// <summary>
		/// Title: "Email:" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValPhotogra { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Company:" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodpaise { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodcateg { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpesso { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Externo_ViewModel() : base(null!) { }

		public Externo_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEXTERNO", nestedForm) { }

		public Externo_ViewModel(UserContext userContext, Models.Pesso row, bool nestedForm = false) : base(userContext, "FEXTERNO", row, nestedForm) { }

		public Externo_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, userContext, "FEXTERNO", fieldsToQuery: fieldsToLoad);
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
			Models.Pesso model = new Models.Pesso(userContext) { Identifier = "FEXTERNO" };
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
			Models.Pesso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Externo) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodpaise = ViewModelConversion.ToString(m.ValCodpaise);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Externo) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Externo) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpaise = ViewModelConversion.ToString(ValCodpaise);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Externo) to Model (Pesso) - Error during mapping");
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FEXTERNO");
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

			Model.Identifier = "FEXTERNO";
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

		protected override void LoadDocumentsProperties(Models.Pesso row)
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FEXTERNO");
				if (Model == null)
				{
					Model = new Models.Pesso(m_userContext) { Identifier = "FEXTERNO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Externo_cmpnydesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EXTERNO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EXTERNO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.NAME_23841, ValName, 85);
			validator.Required("ValName", Resources.Resources.NAME_23841, ValName);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL_44228, ValEmail, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EXTERNO]/
		public override void Save()
		{

			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FEXTERNO"); }
			finally { if (Model == null) Model = new Models.Pesso(m_userContext) { Identifier = "FEXTERNO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EXTERNO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FEXTERNO"); }
			finally { if (Model == null) Model = new Models.Pesso(m_userContext) { Identifier = "FEXTERNO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EXTERNO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EXTERNO]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, m_userContext, "FEXTERNO");
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
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Externo_cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool externo_cmpnydesignatDoLoad = true;
			CriteriaSet externo_cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					externo_cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
					this.ValCodempre = Navigation.GetStrValue("cmpny");
				}
			}

			TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
				FillDependant_ExternoTableCmpnyDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
				return;
			}

			if (externo_cmpnydesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
					TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
				else
					TableCmpnyDesignat.TableFilters = false;

				query = qs["qTableCmpnyDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
				}
				externo_cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ EXTERNO_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					externo_cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					externo_cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, externo_cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_EXTERNO_CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_EXTERNO_CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_ExternoTableCmpnyDesignat();

				//Check if foreignkey comes from history
				TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_ExternoTableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];

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

			CSGenioAcmpny tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ExternoTableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_ExternoTableCmpnyDesignat(this.ValCodempre);
			try
			{

				// Fill List fields
				this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
				TableCmpnyDesignat.Value = (string)row["cmpny.designat"];
				if (GlobalFunctions.emptyG(this.ValCodempre) == 1)
				{
					this.ValCodempre = "";
					TableCmpnyDesignat.Value = "";
					Navigation.ClearValue("cmpny");
				}
				else if (lazyLoad)
				{
					TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
					TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodempre),
							Text = Convert.ToString(TableCmpnyDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodempre);
				}

				TableCmpnyDesignat.Selected = this.ValCodempre;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EXTERNO_CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"pesso.gender" => ViewModelConversion.ToString(modelValue),
				"pesso.telephon" => ViewModelConversion.ToString(modelValue),
				"pesso.email" => ViewModelConversion.ToString(modelValue),
				"pesso.photogra" => ViewModelConversion.ToImage(modelValue),
				"pesso.codempre" => ViewModelConversion.ToString(modelValue),
				"pesso.codpaise" => ViewModelConversion.ToString(modelValue),
				"pesso.codcntry" => ViewModelConversion.ToString(modelValue),
				"pesso.codregia" => ViewModelConversion.ToString(modelValue),
				"pesso.codcateg" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EXTERNO]/

		#endregion
	}
}
