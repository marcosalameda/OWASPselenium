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

namespace GenioMVC.ViewModels.Tpequ
{
	public class Tpequ_ViewModel : FormViewModel<Models.Tpequ>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Equipment family" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Famil> TableFamilFamily { get; set; }

		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		public string ValTipoequi { get; set; }

		/// <summary>
		/// Title: "Code" | Type: "TF"
		/// </summary>
		public string ValTpequcod { get; set; }

		/// <summary>
		/// Title: "Level:" | Type: "TN"
		/// </summary>
		public double ValNivel { get; set; }

		/// <summary>
		/// Title: "Kit" | Type: "L"
		/// </summary>
		public bool ValKit { get; set; }

		/// <summary>
		/// Title: "Maximum Price" | Type: "$D"
		/// </summary>
		public decimal? ValPrecomax { get; set; }

		/// <summary>
		/// Title: "Background Color" | Type: "C"
		/// </summary>
		public string ValBackcolo { get; set; }

		/// <summary>
		/// Title: "Letter Color" | Type: "C"
		/// </summary>
		public string ValCorletra { get; set; }

		/// <summary>
		/// Title: "Dependence on" | Type: "TP"
		/// </summary>
		public string ValTpequpai { get; set; }

		/// <summary>
		/// Title: "Last Price" | Type: "$D"
		/// </summary>
		public decimal? ValPrecoult { get; set; }

		/// <summary>
		/// Title: "Since" | Type: "DT"
		/// </summary>
		public DateTime? ValSince { get; set; }

		/// <summary>
		/// Title: "Quantity of equipment:" | Type: "N"
		/// </summary>
		public decimal? ValQtdequip { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Equipment family" | Type: "CE"
		/// </summary>
		public string ValCodfamil { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtpequ { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tpequ_ViewModel() : base(null!) { }

		public Tpequ_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTPEQU", nestedForm) { }

		public Tpequ_ViewModel(UserContext userContext, Models.Tpequ row, bool nestedForm = false) : base(userContext, "FTPEQU", row, nestedForm) { }

		public Tpequ_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tpequ", id);
			Model = Models.Tpequ.Find(id, userContext, "FTPEQU", fieldsToQuery: fieldsToLoad);
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
			Models.Tpequ model = new Models.Tpequ(userContext) { Identifier = "FTPEQU" };
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
			Models.Tpequ model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Tpequ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValTipoequi = ViewModelConversion.ToString(m.ValTipoequi);
				ValTpequcod = ViewModelConversion.ToString(m.ValTpequcod);
				ValNivel = ViewModelConversion.ToDouble(m.ValNivel);
				ValKit = ViewModelConversion.ToLogic(m.ValKit);
				ValPrecomax = ViewModelConversion.ToNumeric(m.ValPrecomax);
				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
				ValCorletra = ViewModelConversion.ToString(m.ValCorletra);
				ValTpequpai = ViewModelConversion.ToString(m.ValTpequpai);
				ValPrecoult = ViewModelConversion.ToNumeric(m.ValPrecoult);
				ValSince = ViewModelConversion.ToDateTime(m.ValSince);
				ValQtdequip = ViewModelConversion.ToNumeric(m.ValQtdequip);
				ValCodfamil = ViewModelConversion.ToString(m.ValCodfamil);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tpequ) to ViewModel (Tpequ) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tpequ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpequ) to Model (Tpequ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTipoequi = ViewModelConversion.ToString(ValTipoequi);
				m.ValTpequcod = ViewModelConversion.ToString(ValTpequcod);
				m.ValNivel = ViewModelConversion.ToDouble(ValNivel);
				m.ValKit = ViewModelConversion.ToLogic(ValKit);
				m.ValPrecomax = ViewModelConversion.ToNumeric(ValPrecomax);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
				m.ValCorletra = ViewModelConversion.ToString(ValCorletra);
				m.ValTpequpai = ViewModelConversion.ToString(ValTpequpai);
				m.ValPrecoult = ViewModelConversion.ToNumeric(ValPrecoult);
				m.ValSince = ViewModelConversion.ToDateTime(ValSince);
				m.ValQtdequip = ViewModelConversion.ToNumeric(ValQtdequip);
				m.ValCodfamil = ViewModelConversion.ToString(ValCodfamil);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tpequ) to Model (Tpequ) - Error during mapping");
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
				Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), m_userContext, "FTPEQU");
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

			Model.Identifier = "FTPEQU";
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

		protected override void LoadDocumentsProperties(Models.Tpequ row)
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
				Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), m_userContext, "FTPEQU");
				if (Model == null)
				{
					Model = new Models.Tpequ(m_userContext) { Identifier = "FTPEQU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tpequ___familfamily__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPEQU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPEQU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValTipoequi", Resources.Resources.TYPE_OF_EQUIPMENT64921, ValTipoequi, 50);
			validator.StringLength("ValTpequcod", Resources.Resources.CODE49225, ValTpequcod, 20);
			validator.Required("ValTpequcod", Resources.Resources.CODE49225, ValTpequcod);
			validator.StringLength("ValBackcolo", Resources.Resources.BACKGROUND_COLOR07511, ValBackcolo, 50);
			validator.StringLength("ValCorletra", Resources.Resources.LETTER_COLOR63305, ValCorletra, 50);
			validator.StringLength("ValTpequpai", Resources.Resources.DEPENDENCE_ON13941, ValTpequpai, 20);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPEQU]/
		public override void Save()
		{

			try { Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), m_userContext, "FTPEQU"); }
			finally { if (Model == null) Model = new Models.Tpequ(m_userContext) { Identifier = "FTPEQU" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPEQU]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tpequ.Find(Navigation.GetStrValue("tpequ"), m_userContext, "FTPEQU"); }
			finally { if (Model == null) Model = new Models.Tpequ(m_userContext) { Identifier = "FTPEQU" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPEQU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPEQU]/
		public override void Destroy(string id)
		{
			Model = Models.Tpequ.Find(id, m_userContext, "FTPEQU");
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
		/// TableFamilFamily -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tpequ___familfamily__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tpequ___familfamily__DoLoad = true;
			CriteriaSet tpequ___familfamily__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("famil", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tpequ___familfamily__Conds.Equal(CSGenioAfamil.FldCodfamil, Navigation.GetValue("famil"));
					this.ValCodfamil = Navigation.GetStrValue("famil");
				}
			}

			TableFamilFamily = new TableDBEdit<Models.Famil>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_famil") != null)
				{
					this.ValCodfamil = Navigation.GetStrValue("RETURN_famil");
					Navigation.CurrentLevel.SetEntry("RETURN_famil", null);
				}
				FillDependant_TpequTableFamilFamily(lazyLoad);
				//Check if foreignkey comes from history
				TableFamilFamily.FilledByHistory = Navigation.CheckFilledByHistory("famil");
				return;
			}

			if (tpequ___familfamily__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableFamilFamily, "sTableFamilFamily", "dTableFamilFamily", qs, "famil");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfamil.FldFamily), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFamilFamily_tableFilters"]))
					TableFamilFamily.TableFilters = bool.Parse(qs["TableFamilFamily_tableFilters"]);
				else
					TableFamilFamily.TableFilters = false;

				query = qs["qTableFamilFamily"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfamil.FldFamily, query + "%");
				}
				tpequ___familfamily__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFamilFamily"] != null ? qs["pTableFamilFamily"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAfamil.FldZzstate };

// USE /[MANUAL GQT OVERRQ TPEQU_FAMILFAMILY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("famil", FormMode.New) || Navigation.checkFormMode("famil", FormMode.Duplicate))
					tpequ___familfamily__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfamil.FldZzstate, 0)
						.Equal(CSGenioAfamil.FldCodfamil, Navigation.GetStrValue("famil")));
				else
					tpequ___familfamily__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfamil.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("famil", "family");
				ListingMVC<CSGenioAfamil> listing = Models.ModelBase.Where<CSGenioAfamil>(m_userContext, false, tpequ___familfamily__Conds, fields, offset, numberItems, sorts, "LED_TPEQU___FAMILFAMILY__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFamilFamily.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFamilFamily.Query = query;
				TableFamilFamily.Elements = listing.RowsForViewModel<GenioMVC.Models.Famil>((r) => new GenioMVC.Models.Famil(m_userContext, r, true, _fieldsToSerialize_TPEQU___FAMILFAMILY__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_famil") != null)
				{
					this.ValCodfamil = Navigation.GetStrValue("RETURN_famil");
					Navigation.CurrentLevel.SetEntry("RETURN_famil", null);
				}

				TableFamilFamily.List = new SelectList(TableFamilFamily.Elements.ToSelectList(x => x.ValFamily, x => x.ValCodfamil,  x => x.ValCodfamil == this.ValCodfamil), "Value", "Text", this.ValCodfamil);
				FillDependant_TpequTableFamilFamily();

				//Check if foreignkey comes from history
				TableFamilFamily.FilledByHistory = Navigation.CheckFilledByHistory("famil");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFamilFamily (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Famil</param>
		public ConcurrentDictionary<string, object> GetDependant_TpequTableFamilFamily(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily];

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

			CSGenioAfamil tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfamil.FldCodfamil, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFamilFamily (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TpequTableFamilFamily(bool lazyLoad = false)
		{
			var row = GetDependant_TpequTableFamilFamily(this.ValCodfamil);
			try
			{

				// Fill List fields
				this.ValCodfamil = ViewModelConversion.ToString(row["famil.codfamil"]);
				TableFamilFamily.Value = (string)row["famil.family"];
				if (GlobalFunctions.emptyG(this.ValCodfamil) == 1)
				{
					this.ValCodfamil = "";
					TableFamilFamily.Value = "";
					Navigation.ClearValue("famil");
				}
				else if (lazyLoad)
				{
					TableFamilFamily.SetPagination(1, 0, false, false, 1);
					TableFamilFamily.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodfamil),
							Text = Convert.ToString(TableFamilFamily.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodfamil);
				}

				TableFamilFamily.Selected = this.ValCodfamil;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFamilFamily): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TPEQU___FAMILFAMILY__ = ["Famil", "Famil.ValCodfamil", "Famil.ValZzstate", "Famil.ValFamily"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"tpequ.tpequcod" => ViewModelConversion.ToString(modelValue),
				"tpequ.nivel" => ViewModelConversion.ToDouble(modelValue),
				"tpequ.kit" => ViewModelConversion.ToLogic(modelValue),
				"tpequ.precomax" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.backcolo" => ViewModelConversion.ToString(modelValue),
				"tpequ.corletra" => ViewModelConversion.ToString(modelValue),
				"tpequ.tpequpai" => ViewModelConversion.ToString(modelValue),
				"tpequ.precoult" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.since" => ViewModelConversion.ToDateTime(modelValue),
				"tpequ.qtdequip" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.codfamil" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"famil.codfamil" => ViewModelConversion.ToString(modelValue),
				"famil.family" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPEQU]/

		#endregion
	}
}
