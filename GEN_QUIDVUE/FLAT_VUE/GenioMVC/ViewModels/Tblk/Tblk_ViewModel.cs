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

namespace GenioMVC.ViewModels.Tblk
{
	public class Tblk_ViewModel : FormViewModel<Models.Tblk>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Grpb> TableGrpbName { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Trsb> TableTrsbName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValFkey1 { get; set; }

		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValFkey2 { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtblk { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tblk_ViewModel() : base(null!) { }

		public Tblk_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTBLK", nestedForm) { }

		public Tblk_ViewModel(UserContext userContext, Models.Tblk row, bool nestedForm = false) : base(userContext, "FTBLK", row, nestedForm) { }

		public Tblk_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tblk", id);
			Model = Models.Tblk.Find(id, userContext, "FTBLK", fieldsToQuery: fieldsToLoad);
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
			Models.Tblk model = new Models.Tblk(userContext) { Identifier = "FTBLK" };
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
			Models.Tblk model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValFkey1 = ViewModelConversion.ToString(m.ValFkey1);
				ValFkey2 = ViewModelConversion.ToString(m.ValFkey2);
				ValCodtblk = ViewModelConversion.ToString(m.ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tblk) to ViewModel (Tblk) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tblk m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblk) to Model (Tblk) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValFkey1 = ViewModelConversion.ToString(ValFkey1);
				m.ValFkey2 = ViewModelConversion.ToString(ValFkey2);
				m.ValCodtblk = ViewModelConversion.ToString(ValCodtblk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tblk) to Model (Tblk) - Error during mapping");
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
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK");
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

			Model.Identifier = "FTBLK";
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

		protected override void LoadDocumentsProperties(Models.Tblk row)
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
				Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK");
				if (Model == null)
				{
					Model = new Models.Tblk(m_userContext) { Identifier = "FTBLK" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblk");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tblk____grpb_name____(qs, lazyLoad);
			Load_Tblk____trsb_name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TBLK]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TBLK]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TBLK]/
		public override void Save()
		{

			try { Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK"); }
			finally { if (Model == null) Model = new Models.Tblk(m_userContext) { Identifier = "FTBLK" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TBLK]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tblk.Find(Navigation.GetStrValue("tblk"), m_userContext, "FTBLK"); }
			finally { if (Model == null) Model = new Models.Tblk(m_userContext) { Identifier = "FTBLK" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TBLK]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TBLK]/
		public override void Destroy(string id)
		{
			Model = Models.Tblk.Find(id, m_userContext, "FTBLK");
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
		/// TableGrpbName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tblk____grpb_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tblk____grpb_name____DoLoad = true;
			CriteriaSet tblk____grpb_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("grpb", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tblk____grpb_name____Conds.Equal(CSGenioAgrpb.FldCodgrpb, Navigation.GetValue("grpb"));
					this.ValFkey1 = Navigation.GetStrValue("grpb");
				}
			}

			TableGrpbName = new TableDBEdit<Models.Grpb>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
					this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}
				FillDependant_TblkTableGrpbName(lazyLoad);
				//Check if foreignkey comes from history
				TableGrpbName.FilledByHistory = Navigation.CheckFilledByHistory("grpb");
				return;
			}

			if (tblk____grpb_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableGrpbName, "sTableGrpbName", "dTableGrpbName", qs, "grpb");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgrpb.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGrpbName_tableFilters"]))
					TableGrpbName.TableFilters = bool.Parse(qs["TableGrpbName_tableFilters"]);
				else
					TableGrpbName.TableFilters = false;

				query = qs["qTableGrpbName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgrpb.FldName, query + "%");
				}
				tblk____grpb_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGrpbName"] != null ? qs["pTableGrpbName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName, CSGenioAgrpb.FldZzstate };

// USE /[MANUAL GQT OVERRQ TBLK_GRPBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("grpb", FormMode.New) || Navigation.checkFormMode("grpb", FormMode.Duplicate))
					tblk____grpb_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgrpb.FldZzstate, 0)
						.Equal(CSGenioAgrpb.FldCodgrpb, Navigation.GetStrValue("grpb")));
				else
					tblk____grpb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgrpb.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("grpb", "name");
				ListingMVC<CSGenioAgrpb> listing = Models.ModelBase.Where<CSGenioAgrpb>(m_userContext, false, tblk____grpb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____GRPB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGrpbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGrpbName.Query = query;
				TableGrpbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Grpb>((r) => new GenioMVC.Models.Grpb(m_userContext, r, true, _fieldsToSerialize_TBLK____GRPB_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_grpb") != null)
				{
					this.ValFkey1 = Navigation.GetStrValue("RETURN_grpb");
					Navigation.CurrentLevel.SetEntry("RETURN_grpb", null);
				}

				TableGrpbName.List = new SelectList(TableGrpbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodgrpb,  x => x.ValCodgrpb == this.ValFkey1), "Value", "Text", this.ValFkey1);
				FillDependant_TblkTableGrpbName();

				//Check if foreignkey comes from history
				TableGrpbName.FilledByHistory = Navigation.CheckFilledByHistory("grpb");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGrpbName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Grpb</param>
		public ConcurrentDictionary<string, object> GetDependant_TblkTableGrpbName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldName];

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

			CSGenioAgrpb tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgrpb.FldCodgrpb, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGrpbName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TblkTableGrpbName(bool lazyLoad = false)
		{
			var row = GetDependant_TblkTableGrpbName(this.ValFkey1);
			try
			{

				// Fill List fields
				this.ValFkey1 = ViewModelConversion.ToString(row["grpb.codgrpb"]);
				TableGrpbName.Value = (string)row["grpb.name"];
				if (GlobalFunctions.emptyG(this.ValFkey1) == 1)
				{
					this.ValFkey1 = "";
					TableGrpbName.Value = "";
					Navigation.ClearValue("grpb");
				}
				else if (lazyLoad)
				{
					TableGrpbName.SetPagination(1, 0, false, false, 1);
					TableGrpbName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFkey1),
							Text = Convert.ToString(TableGrpbName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFkey1);
				}

				TableGrpbName.Selected = this.ValFkey1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGrpbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TBLK____GRPB_NAME____ = ["Grpb", "Grpb.ValCodgrpb", "Grpb.ValZzstate", "Grpb.ValName"];

		/// <summary>
		/// TableTrsbName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tblk____trsb_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tblk____trsb_name____DoLoad = true;
			CriteriaSet tblk____trsb_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("trsb", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tblk____trsb_name____Conds.Equal(CSGenioAtrsb.FldCodtrsb, Navigation.GetValue("trsb"));
					this.ValFkey2 = Navigation.GetStrValue("trsb");
				}
			}

			TableTrsbName = new TableDBEdit<Models.Trsb>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
					this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}
				FillDependant_TblkTableTrsbName(lazyLoad);
				//Check if foreignkey comes from history
				TableTrsbName.FilledByHistory = Navigation.CheckFilledByHistory("trsb");
				return;
			}

			if (tblk____trsb_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTrsbName, "sTableTrsbName", "dTableTrsbName", qs, "trsb");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtrsb.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTrsbName_tableFilters"]))
					TableTrsbName.TableFilters = bool.Parse(qs["TableTrsbName_tableFilters"]);
				else
					TableTrsbName.TableFilters = false;

				query = qs["qTableTrsbName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtrsb.FldName, query + "%");
				}
				tblk____trsb_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableTrsbName"] != null ? qs["pTableTrsbName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName, CSGenioAtrsb.FldZzstate };

// USE /[MANUAL GQT OVERRQ TBLK_TRSBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("trsb", FormMode.New) || Navigation.checkFormMode("trsb", FormMode.Duplicate))
					tblk____trsb_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtrsb.FldZzstate, 0)
						.Equal(CSGenioAtrsb.FldCodtrsb, Navigation.GetStrValue("trsb")));
				else
					tblk____trsb_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtrsb.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("trsb", "name");
				ListingMVC<CSGenioAtrsb> listing = Models.ModelBase.Where<CSGenioAtrsb>(m_userContext, false, tblk____trsb_name____Conds, fields, offset, numberItems, sorts, "LED_TBLK____TRSB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTrsbName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTrsbName.Query = query;
				TableTrsbName.Elements = listing.RowsForViewModel<GenioMVC.Models.Trsb>((r) => new GenioMVC.Models.Trsb(m_userContext, r, true, _fieldsToSerialize_TBLK____TRSB_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_trsb") != null)
				{
					this.ValFkey2 = Navigation.GetStrValue("RETURN_trsb");
					Navigation.CurrentLevel.SetEntry("RETURN_trsb", null);
				}

				TableTrsbName.List = new SelectList(TableTrsbName.Elements.ToSelectList(x => x.ValName, x => x.ValCodtrsb,  x => x.ValCodtrsb == this.ValFkey2), "Value", "Text", this.ValFkey2);
				FillDependant_TblkTableTrsbName();

				//Check if foreignkey comes from history
				TableTrsbName.FilledByHistory = Navigation.CheckFilledByHistory("trsb");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTrsbName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Trsb</param>
		public ConcurrentDictionary<string, object> GetDependant_TblkTableTrsbName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtrsb.FldCodtrsb, CSGenioAtrsb.FldName];

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

			CSGenioAtrsb tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtrsb.FldCodtrsb, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTrsbName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TblkTableTrsbName(bool lazyLoad = false)
		{
			var row = GetDependant_TblkTableTrsbName(this.ValFkey2);
			try
			{

				// Fill List fields
				this.ValFkey2 = ViewModelConversion.ToString(row["trsb.codtrsb"]);
				TableTrsbName.Value = (string)row["trsb.name"];
				if (GlobalFunctions.emptyG(this.ValFkey2) == 1)
				{
					this.ValFkey2 = "";
					TableTrsbName.Value = "";
					Navigation.ClearValue("trsb");
				}
				else if (lazyLoad)
				{
					TableTrsbName.SetPagination(1, 0, false, false, 1);
					TableTrsbName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFkey2),
							Text = Convert.ToString(TableTrsbName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFkey2);
				}

				TableTrsbName.Selected = this.ValFkey2;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTrsbName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TBLK____TRSB_NAME____ = ["Trsb", "Trsb.ValCodtrsb", "Trsb.ValZzstate", "Trsb.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tblk.name" => ViewModelConversion.ToString(modelValue),
				"tblk.fkey1" => ViewModelConversion.ToString(modelValue),
				"tblk.fkey2" => ViewModelConversion.ToString(modelValue),
				"tblk.codtblk" => ViewModelConversion.ToString(modelValue),
				"grpb.codgrpb" => ViewModelConversion.ToString(modelValue),
				"grpb.name" => ViewModelConversion.ToString(modelValue),
				"trsb.codtrsb" => ViewModelConversion.ToString(modelValue),
				"trsb.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBLK]/

		#endregion
	}
}
