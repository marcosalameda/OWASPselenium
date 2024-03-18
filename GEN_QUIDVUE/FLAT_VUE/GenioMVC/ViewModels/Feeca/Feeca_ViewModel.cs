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

namespace GenioMVC.ViewModels.Feeca
{
	public class Feeca_ViewModel : FormViewModel<Models.Feeca>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Flds> TableFldsDescrip { get; set; }

		/// <summary>
		/// Title: "Feedback" | Type: "C"
		/// </summary>
		public string ValFeedback { get; set; }

		/// <summary>
		/// Title: "Attachments" | Type: "IB"
		/// </summary>
		[Document("FldsValAttach", false, true, false, false, DocumentViewTypeMode.Preview)]
		public string FldsValAttach 
		{
			get
			{
				return funcFldsValAttach != null ? funcFldsValAttach() : _auxFldsValAttach;
			}
			set { funcFldsValAttach = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcFldsValAttach { get; set; }

		private string _auxFldsValAttach { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string FldsValAttachfk { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel FldsValAttachPropertiesVM { get; set; }

		/// <summary>
		/// Title: "Passenger capacity on the plane" | Type: "N"
		/// </summary>
		public decimal? FldsValNpassage 
		{
			get
			{
				return funcFldsValNpassage != null ? funcFldsValNpassage() : _auxFldsValNpassage;
			}
			set { funcFldsValNpassage = () => value; }
		}

		[JsonIgnore]
		public Func<decimal?> funcFldsValNpassage { get; set; }

		private decimal? _auxFldsValNpassage { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Description" | Type: "CE"
		/// </summary>
		public string ValCodflds { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodfeeca { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Feeca_ViewModel() : base(null!) { }

		public Feeca_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFEECA", nestedForm) { }

		public Feeca_ViewModel(UserContext userContext, Models.Feeca row, bool nestedForm = false) : base(userContext, "FFEECA", row, nestedForm) { }

		public Feeca_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("feeca", id);
			Model = Models.Feeca.Find(id, userContext, "FFEECA", fieldsToQuery: fieldsToLoad);
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
			Models.Feeca model = new Models.Feeca(userContext) { Identifier = "FFEECA" };
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
			Models.Feeca model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValFeedback = ViewModelConversion.ToString(m.ValFeedback);
				funcFldsValAttach = () => ViewModelConversion.ToString(m.Flds.ValAttach);
				FldsValAttachfk = ViewModelConversion.ToString(m.Flds.ValAttachfk);
				funcFldsValNpassage = () => ViewModelConversion.ToNumeric(m.Flds.ValNpassage);
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
				ValCodfeeca = ViewModelConversion.ToString(m.ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Feeca) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Feeca) to Model (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValFeedback = ViewModelConversion.ToString(ValFeedback);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
				m.ValCodfeeca = ViewModelConversion.ToString(ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Feeca) to Model (Feeca) - Error during mapping");
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), m_userContext, "FFEECA");
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

			Model.Identifier = "FFEECA";
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

		protected override void LoadDocumentsProperties(Models.Feeca row)
		{
			try
			{
				FldsValAttachPropertiesVM = row.Flds.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				FldsValAttachPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), m_userContext, "FFEECA");
				if (Model == null)
				{
					Model = new Models.Feeca(m_userContext) { Identifier = "FFEECA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Feeca___flds_descrip_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FEECA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FEECA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValFeedback", Resources.Resources.FEEDBACK52855, ValFeedback, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FEECA]/
		public override void Save()
		{

			try { Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), m_userContext, "FFEECA"); }
			finally { if (Model == null) Model = new Models.Feeca(m_userContext) { Identifier = "FFEECA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FEECA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), m_userContext, "FFEECA"); }
			finally { if (Model == null) Model = new Models.Feeca(m_userContext) { Identifier = "FFEECA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FEECA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FEECA]/
		public override void Destroy(string id)
		{
			Model = Models.Feeca.Find(id, m_userContext, "FFEECA");
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
		/// TableFldsDescrip -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Feeca___flds_descrip_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool feeca___flds_descrip_DoLoad = true;
			CriteriaSet feeca___flds_descrip_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("flds", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					feeca___flds_descrip_Conds.Equal(CSGenioAflds.FldCodflds, Navigation.GetValue("flds"));
					this.ValCodflds = Navigation.GetStrValue("flds");
				}
			}

			TableFldsDescrip = new TableDBEdit<Models.Flds>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_flds") != null)
				{
					this.ValCodflds = Navigation.GetStrValue("RETURN_flds");
					Navigation.CurrentLevel.SetEntry("RETURN_flds", null);
				}
				FillDependant_FeecaTableFldsDescrip(lazyLoad);
				//Check if foreignkey comes from history
				TableFldsDescrip.FilledByHistory = Navigation.CheckFilledByHistory("flds");
				return;
			}

			if (feeca___flds_descrip_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableFldsDescrip, "sTableFldsDescrip", "dTableFldsDescrip", qs, "flds");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFldsDescrip_tableFilters"]))
					TableFldsDescrip.TableFilters = bool.Parse(qs["TableFldsDescrip_tableFilters"]);
				else
					TableFldsDescrip.TableFilters = false;

				query = qs["qTableFldsDescrip"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAflds.FldDescrip, query + "%");
				}
				feeca___flds_descrip_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFldsDescrip"] != null ? qs["pTableFldsDescrip"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAflds.FldZzstate };

// USE /[MANUAL GQT OVERRQ FEECA_FLDSDESCRIP]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("flds", FormMode.New) || Navigation.checkFormMode("flds", FormMode.Duplicate))
					feeca___flds_descrip_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAflds.FldZzstate, 0)
						.Equal(CSGenioAflds.FldCodflds, Navigation.GetStrValue("flds")));
				else
					feeca___flds_descrip_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAflds.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("flds", "descrip");
				ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(m_userContext, false, feeca___flds_descrip_Conds, fields, offset, numberItems, sorts, "LED_FEECA___FLDS_DESCRIP_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFldsDescrip.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFldsDescrip.Query = query;
				TableFldsDescrip.Elements = listing.RowsForViewModel<GenioMVC.Models.Flds>((r) => new GenioMVC.Models.Flds(m_userContext, r, true, _fieldsToSerialize_FEECA___FLDS_DESCRIP_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_flds") != null)
				{
					this.ValCodflds = Navigation.GetStrValue("RETURN_flds");
					Navigation.CurrentLevel.SetEntry("RETURN_flds", null);
				}

				TableFldsDescrip.List = new SelectList(TableFldsDescrip.Elements.ToSelectList(x => x.ValDescrip, x => x.ValCodflds,  x => x.ValCodflds == this.ValCodflds), "Value", "Text", this.ValCodflds);
				FillDependant_FeecaTableFldsDescrip();

				//Check if foreignkey comes from history
				TableFldsDescrip.FilledByHistory = Navigation.CheckFilledByHistory("flds");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFldsDescrip (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Flds</param>
		public ConcurrentDictionary<string, object> GetDependant_FeecaTableFldsDescrip(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAflds.FldCodflds, CSGenioAflds.FldDescrip, CSGenioAflds.FldAttach, CSGenioAflds.FldNpassage];

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

			CSGenioAflds tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAflds.FldCodflds, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFldsDescrip (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FeecaTableFldsDescrip(bool lazyLoad = false)
		{
			var row = GetDependant_FeecaTableFldsDescrip(this.ValCodflds);
			try
			{
				this.funcFldsValAttach = () => (string)row["flds.attach"];
				this.funcFldsValNpassage = () => (decimal?)row["flds.npassage"];

				// Fill List fields
				this.ValCodflds = ViewModelConversion.ToString(row["flds.codflds"]);
				TableFldsDescrip.Value = (string)row["flds.descrip"];
				if (GlobalFunctions.emptyG(this.ValCodflds) == 1)
				{
					this.ValCodflds = "";
					TableFldsDescrip.Value = "";
					Navigation.ClearValue("flds");
				}
				else if (lazyLoad)
				{
					TableFldsDescrip.SetPagination(1, 0, false, false, 1);
					TableFldsDescrip.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodflds),
							Text = Convert.ToString(TableFldsDescrip.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodflds);
				}

				TableFldsDescrip.Selected = this.ValCodflds;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFldsDescrip): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FEECA___FLDS_DESCRIP_ = ["Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Flds.ValDescrip"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"feeca.feedback" => ViewModelConversion.ToString(modelValue),
				"flds.attach" => ViewModelConversion.ToString(modelValue),
				"flds.npassage" => ViewModelConversion.ToNumeric(modelValue),
				"feeca.codflds" => ViewModelConversion.ToString(modelValue),
				"feeca.codfeeca" => ViewModelConversion.ToString(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				"flds.descrip" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FEECA]/

		#endregion
	}
}
