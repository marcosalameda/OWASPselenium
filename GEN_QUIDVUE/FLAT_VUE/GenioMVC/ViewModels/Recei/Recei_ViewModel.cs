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

namespace GenioMVC.ViewModels.Recei
{
	public class Recei_ViewModel : FormViewModel<Models.Recei>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Receipt date" | Type: "DT"
		/// </summary>
		public DateTime? ValDtreceip { get; set; }

		/// <summary>
		/// Title: "Receipt number" | Type: "N"
		/// </summary>
		public decimal? ValNumber { get; set; }

		/// <summary>
		/// Title: "Suplier" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Entit> TableEntitName { get; set; }

		/// <summary>
		/// Title: "Receipt verification" | Type: "DT"
		/// </summary>
		public DateTime? ValDtcheck { get; set; }

		/// <summary>
		/// Title: "To check" | Type: "L"
		/// </summary>
		public bool ValTocheck { get; set; }

		/// <summary>
		/// Title: "Checked" | Type: "L"
		/// </summary>
		public bool ValChecked { get; set; }

		/// <summary>
		/// Title: "Stored" | Type: "L"
		/// </summary>
		public bool ValStored { get; set; }

		/// <summary>
		/// Title: "Storage date" | Type: "DT"
		/// </summary>
		public DateTime? ValDtstorag { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Suplier" | Type: "CE"
		/// </summary>
		public string ValCodentit { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodrecei { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Recei_ViewModel() : base(null!) { }

		public Recei_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FRECEI", nestedForm) { }

		public Recei_ViewModel(UserContext userContext, Models.Recei row, bool nestedForm = false) : base(userContext, "FRECEI", row, nestedForm) { }

		public Recei_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("recei", id);
			Model = Models.Recei.Find(id, userContext, "FRECEI", fieldsToQuery: fieldsToLoad);
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
			Models.Recei model = new Models.Recei(userContext) { Identifier = "FRECEI" };
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
			Models.Recei model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Recei m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Recei) to ViewModel (Recei) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValDtreceip = ViewModelConversion.ToDateTime(m.ValDtreceip);
				ValNumber = ViewModelConversion.ToNumeric(m.ValNumber);
				ValDtcheck = ViewModelConversion.ToDateTime(m.ValDtcheck);
				ValTocheck = ViewModelConversion.ToLogic(m.ValTocheck);
				ValChecked = ViewModelConversion.ToLogic(m.ValChecked);
				ValStored = ViewModelConversion.ToLogic(m.ValStored);
				ValDtstorag = ViewModelConversion.ToDateTime(m.ValDtstorag);
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
				ValCodrecei = ViewModelConversion.ToString(m.ValCodrecei);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Recei) to ViewModel (Recei) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Recei m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Recei) to Model (Recei) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValDtreceip = ViewModelConversion.ToDateTime(ValDtreceip);
				m.ValNumber = ViewModelConversion.ToNumeric(ValNumber);
				m.ValDtcheck = ViewModelConversion.ToDateTime(ValDtcheck);
				m.ValTocheck = ViewModelConversion.ToLogic(ValTocheck);
				m.ValChecked = ViewModelConversion.ToLogic(ValChecked);
				m.ValStored = ViewModelConversion.ToLogic(ValStored);
				m.ValDtstorag = ViewModelConversion.ToDateTime(ValDtstorag);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodrecei = ViewModelConversion.ToString(ValCodrecei);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Recei) to Model (Recei) - Error during mapping");
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
				Model = Models.Recei.Find(Navigation.GetStrValue("recei"), m_userContext, "FRECEI");
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

			Model.Identifier = "FRECEI";
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

		protected override void LoadDocumentsProperties(Models.Recei row)
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
				Model = Models.Recei.Find(Navigation.GetStrValue("recei"), m_userContext, "FRECEI");
				if (Model == null)
				{
					Model = new Models.Recei(m_userContext) { Identifier = "FRECEI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("recei");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Recei___entitname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL RECEI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW RECEI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE RECEI]/
		public override void Save()
		{

			try { Model = Models.Recei.Find(Navigation.GetStrValue("recei"), m_userContext, "FRECEI"); }
			finally { if (Model == null) Model = new Models.Recei(m_userContext) { Identifier = "FRECEI" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY RECEI]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Recei.Find(Navigation.GetStrValue("recei"), m_userContext, "FRECEI"); }
			finally { if (Model == null) Model = new Models.Recei(m_userContext) { Identifier = "FRECEI" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE RECEI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY RECEI]/
		public override void Destroy(string id)
		{
			Model = Models.Recei.Find(id, m_userContext, "FRECEI");
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
		/// TableEntitName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Recei___entitname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool recei___entitname____DoLoad = true;
			CriteriaSet recei___entitname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("entit", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					recei___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
					this.ValCodentit = Navigation.GetStrValue("entit");
				}
			}

			TableEntitName = new TableDBEdit<Models.Entit>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
				FillDependant_ReceiTableEntitName(lazyLoad);
				//Check if foreignkey comes from history
				TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
				return;
			}

			if (recei___entitname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
					TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
				else
					TableEntitName.TableFilters = false;

				query = qs["qTableEntitName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAentit.FldName, query + "%");
				}
				recei___entitname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldContact, CSGenioAentit.FldLanguage, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ RECEI_ENTITNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
					recei___entitname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAentit.FldZzstate, 0)
						.Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
				else
					recei___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("entit", "name");
				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, recei___entitname____Conds, fields, offset, numberItems, sorts, "LED_RECEI___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEntitName.Query = query;
				TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(m_userContext, r, true, _fieldsToSerialize_RECEI___ENTITNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
				FillDependant_ReceiTableEntitName();

				//Check if foreignkey comes from history
				TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Entit</param>
		public ConcurrentDictionary<string, object> GetDependant_ReceiTableEntitName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAentit.FldCodentit, CSGenioAentit.FldName];

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

			CSGenioAentit tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ReceiTableEntitName(bool lazyLoad = false)
		{
			var row = GetDependant_ReceiTableEntitName(this.ValCodentit);
			try
			{

				// Fill List fields
				this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
				TableEntitName.Value = (string)row["entit.name"];
				if (GlobalFunctions.emptyG(this.ValCodentit) == 1)
				{
					this.ValCodentit = "";
					TableEntitName.Value = "";
					Navigation.ClearValue("entit");
				}
				else if (lazyLoad)
				{
					TableEntitName.SetPagination(1, 0, false, false, 1);
					TableEntitName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodentit),
							Text = Convert.ToString(TableEntitName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodentit);
				}

				TableEntitName.Selected = this.ValCodentit;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_RECEI___ENTITNAME____ = ["Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials", "Entit.ValTaxnumbe", "Entit.ValEmail", "Entit.ValPhonenum", "Entit.ValContact", "Entit.ValLanguage"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"recei.dtreceip" => ViewModelConversion.ToDateTime(modelValue),
				"recei.number" => ViewModelConversion.ToNumeric(modelValue),
				"recei.dtcheck" => ViewModelConversion.ToDateTime(modelValue),
				"recei.tocheck" => ViewModelConversion.ToLogic(modelValue),
				"recei.checked" => ViewModelConversion.ToLogic(modelValue),
				"recei.stored" => ViewModelConversion.ToLogic(modelValue),
				"recei.dtstorag" => ViewModelConversion.ToDateTime(modelValue),
				"recei.codentit" => ViewModelConversion.ToString(modelValue),
				"recei.codrecei" => ViewModelConversion.ToString(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"entit.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM RECEI]/

		#endregion
	}
}
