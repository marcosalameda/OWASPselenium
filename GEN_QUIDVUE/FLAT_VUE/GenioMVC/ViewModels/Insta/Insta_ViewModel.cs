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

namespace GenioMVC.ViewModels.Insta
{
	public class Insta_ViewModel : FormViewModel<Models.Insta>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }

		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }

		/// <summary>
		/// Title: "Designation:" | Type: "C"
		/// </summary>
		public string EquipValDesignat 
		{
			get
			{
				return funcEquipValDesignat != null ? funcEquipValDesignat() : _auxEquipValDesignat;
			}
			set { funcEquipValDesignat = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcEquipValDesignat { get; set; }

		private string _auxEquipValDesignat { get; set; }

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel EquipValPhotogra 
		{
			get
			{
				return funcEquipValPhotogra != null ? funcEquipValPhotogra() : _auxEquipValPhotogra;
			}
			set { funcEquipValPhotogra = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.ViewModels.ImageModel> funcEquipValPhotogra { get; set; }

		private GenioMVC.ViewModels.ImageModel _auxEquipValPhotogra { get; set; }

		/// <summary>
		/// Title: "Since:" | Type: "DT"
		/// </summary>
		public DateTime? ValSince { get; set; }

		/// <summary>
		/// Title: "Until" | Type: "DT"
		/// </summary>
		public DateTime? ValUntil { get; set; }

		/// <summary>
		/// Title: "Quantity of hours:" | Type: "N"
		/// </summary>
		public decimal? ValHours { get; set; }

		/// <summary>
		/// Title: "Price per hour:" | Type: "$D"
		/// </summary>
		public decimal? ValPrecohor { get; set; }

		/// <summary>
		/// Title: "Value:" | Type: "$D"
		/// </summary>
		public decimal? ValValue { get; set; }

		/// <summary>
		/// Title: "Geographic Coordinates" | Type: "GG"
		/// </summary>
		public string ValCoordgeo { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Registration No." | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodinsta { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Insta_ViewModel() : base(null!) { }

		public Insta_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FINSTA", nestedForm) { }

		public Insta_ViewModel(UserContext userContext, Models.Insta row, bool nestedForm = false) : base(userContext, "FINSTA", row, nestedForm) { }

		public Insta_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("insta", id);
			Model = Models.Insta.Find(id, userContext, "FINSTA", fieldsToQuery: fieldsToLoad);
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
			Models.Insta model = new Models.Insta(userContext) { Identifier = "FINSTA" };
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
			Models.Insta model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Insta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				funcEquipValDesignat = () => ViewModelConversion.ToString(m.Equip.ValDesignat);
				funcEquipValPhotogra = () => ViewModelConversion.ToImage(m.Equip.ValPhotogra);
				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
				ValUntil = ViewModelConversion.ToDateTime(m.ValUntil);
				ValHours = ViewModelConversion.ToNumeric(m.ValHours);
				ValPrecohor = ViewModelConversion.ToNumeric(m.ValPrecohor);
				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodinsta = ViewModelConversion.ToString(m.ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Insta) to ViewModel (Insta) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Insta m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Insta) to Model (Insta) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValUntil = ViewModelConversion.ToDateTime(ValUntil);
				m.ValHours = ViewModelConversion.ToNumeric(ValHours);
				m.ValPrecohor = ViewModelConversion.ToNumeric(ValPrecohor);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodinsta = ViewModelConversion.ToString(ValCodinsta);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Insta) to Model (Insta) - Error during mapping");
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
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FINSTA");
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

			Model.Identifier = "FINSTA";
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

		protected override void LoadDocumentsProperties(Models.Insta row)
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
				Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FINSTA");
				if (Model == null)
				{
					Model = new Models.Insta(m_userContext) { Identifier = "FINSTA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("insta");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Insta___tpequtipoequi(qs, lazyLoad);
			Load_Insta___equipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL INSTA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW INSTA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("EquipValDesignat", Resources.Resources.DESIGNATION_35800, EquipValDesignat, 85);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE INSTA]/
		public override void Save()
		{

			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FINSTA"); }
			finally { if (Model == null) Model = new Models.Insta(m_userContext) { Identifier = "FINSTA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY INSTA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Insta.Find(Navigation.GetStrValue("insta"), m_userContext, "FINSTA"); }
			finally { if (Model == null) Model = new Models.Insta(m_userContext) { Identifier = "FINSTA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE INSTA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY INSTA]/
		public override void Destroy(string id)
		{
			Model = Models.Insta.Find(id, m_userContext, "FINSTA");
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
		/// TableTpequTipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Insta___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool insta___tpequtipoequiDoLoad = true;
			CriteriaSet insta___tpequtipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpequ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					insta___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
					this.ValCodtpequ = Navigation.GetStrValue("tpequ");
				}
			}

			TableTpequTipoequi = new TableDBEdit<Models.Tpequ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
				FillDependant_InstaTableTpequTipoequi(lazyLoad);
				//Check if foreignkey comes from history
				TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
				return;
			}

			if (insta___tpequtipoequiDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
					TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
				else
					TableTpequTipoequi.TableFilters = false;

				query = qs["qTableTpequTipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
				}
				insta___tpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ INSTA_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					insta___tpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					insta___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, insta___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_INSTA___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_INSTA___TPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_InstaTableTpequTipoequi();

				//Check if foreignkey comes from history
				TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_InstaTableTpequTipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi];

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

			CSGenioAtpequ tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_InstaTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_InstaTableTpequTipoequi(this.ValCodtpequ);
			try
			{

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
				TableTpequTipoequi.Value = (string)row["tpequ.tipoequi"];
				if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
					TableTpequTipoequi.Value = "";
					Navigation.ClearValue("tpequ");
				}
				else if (lazyLoad)
				{
					TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
					TableTpequTipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpequTipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpequTipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		public List<TreeNode> Tree_TableTpequTipoequi { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TableTpequTipoequi
		/// </summary>
		public void LoadTree_TableTpequTipoequi(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel };
			CriteriaSet subfilters = CriteriaSet.And();


			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ INSTA_TPEQUVALTIPOEQUI]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet insta___tpequtipoequiConds = CriteriaSet.And();
					{
						bool insta___tpequtipoequiDoLoad = true;

						if (!insta___tpequtipoequiDoLoad)
							return;
						insta___tpequtipoequiConds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioAtpequ>()
					{
						BranchLevel = 0, Area = "TPEQU", Form = "", IsTree = true, IsTreeTable = true,
						KeySelector = CSGenioAtpequ.FldCodtpequ,
						Selector = CSGenioAtpequ.FldTpequcod,
						ParentSelector = CSGenioAtpequ.FldTpequpai,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioAtpequ.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTpequpai }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, insta___tpequtipoequiConds, currentSelectedKey, "IBL_INSTA___TPEQUTIPOEQUI"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TableTpequTipoequi = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_INSTA___TPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValQtdequip"];

		/// <summary>
		/// TableEquipRegistnr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Insta___equipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool insta___equipregistnrDoLoad = true;
			CriteriaSet insta___equipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					insta___equipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
					this.ValCodequip = Navigation.GetStrValue("equip");
				}
			}
			// Limits Generation

			// Area limit
			insta___equipregistnrDoLoad &= AddCriteriaAreaLimit(insta___equipregistnrConds, CSGenio.business.CSGenioAtpequ.FldCodtpequ, "tpequ", this.ValCodtpequ, false);

			TableEquipRegistnr = new TableDBEdit<Models.Equip>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}
				FillDependant_InstaTableEquipRegistnr(lazyLoad);
				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodtpequ))
				insta___equipregistnrDoLoad = false;

			if (insta___equipregistnrDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEquipRegistnr_tableFilters"]))
					TableEquipRegistnr.TableFilters = bool.Parse(qs["TableEquipRegistnr_tableFilters"]);
				else
					TableEquipRegistnr.TableFilters = false;

				query = qs["qTableEquipRegistnr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAequip.FldRegistnr, query + "%");
				}
				insta___equipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldSequennr, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldDtdeco, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ INSTA_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					insta___equipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					insta___equipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "designat");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, insta___equipregistnrConds, fields, offset, numberItems, sorts, "LED_INSTA___EQUIPREGISTNR", true, true, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_INSTA___EQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				//Seleciona se só um
				if (TableEquipRegistnr.List != null && TableEquipRegistnr.List.Count() == 1)
				{
					this.ValCodequip = TableEquipRegistnr.List.First().Value;
					Navigation.SetValue("equip", this.ValCodequip);
				}
				FillDependant_InstaTableEquipRegistnr();

				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_InstaTableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioAequip.FldPhotogra];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("tpequ");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAequip.FldCodtpequ, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAequip tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAequip.FldCodequip, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_InstaTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_InstaTableEquipRegistnr(this.ValCodequip);
			try
			{
				this.funcEquipValDesignat = () => (string)row["equip.designat"];
				this.funcEquipValPhotogra = () => (GenioMVC.ViewModels.ImageModel)row["equip.photogra"];

				// Fill List fields
				this.ValCodequip = ViewModelConversion.ToString(row["equip.codequip"]);
				TableEquipRegistnr.Value = (string)row["equip.registnr"];
				if (GlobalFunctions.emptyG(this.ValCodequip) == 1)
				{
					this.ValCodequip = "";
					TableEquipRegistnr.Value = "";
					Navigation.ClearValue("equip");
				}
				else if (lazyLoad)
				{
					TableEquipRegistnr.SetPagination(1, 0, false, false, 1);
					TableEquipRegistnr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodequip),
							Text = Convert.ToString(TableEquipRegistnr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodequip);
				}

				TableEquipRegistnr.Selected = this.ValCodequip;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEquipRegistnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_INSTA___EQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValDesignat", "Equip.ValRegistnr", "Equip.ValSequennr", "Equip.ValDtaquisi", "Equip.ValDtdeco", "Equip.ValPhotogra", "Equip.ValValortot"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"equip.photogra" => ViewModelConversion.ToImage(modelValue),
				"insta.since" => ViewModelConversion.ToDateTime(modelValue),
				"insta.until" => ViewModelConversion.ToDateTime(modelValue),
				"insta.hours" => ViewModelConversion.ToNumeric(modelValue),
				"insta.precohor" => ViewModelConversion.ToNumeric(modelValue),
				"insta.value" => ViewModelConversion.ToNumeric(modelValue),
				"insta.coordgeo" => ViewModelConversion.ToString(modelValue),
				"insta.codequip" => ViewModelConversion.ToString(modelValue),
				"insta.codtpequ" => ViewModelConversion.ToString(modelValue),
				"insta.codinsta" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM INSTA]/

		#endregion
	}
}
