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

namespace GenioMVC.ViewModels.Equip
{
	public class Accordi_ViewModel : FormViewModel<Models.Equip>, IPreparableForSerialization
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
		/// Title: "Company:" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCoddeco { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "Person" | Type: "CE"
		/// </summary>
		public string ValCodpess1 { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodrooms { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodtpequ { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodwareh { get; set; }

		#endregion

		/// <summary>
		/// Title: "Company:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }
		/// <summary>
		/// Title: "Person" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess1> TablePess1Name { get; set; }
		/// <summary>
		/// Title: "Sequential no." | Type: "N"
		/// </summary>
		public decimal? ValSequennr { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValPhotogra { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "No. register" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string ValRegistnr { get; set; }

		#endregion

		public string ValCodequip { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Accordi_ViewModel() : base(null!) { }

		public Accordi_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FACCORDI", nestedForm) { }

		public Accordi_ViewModel(UserContext userContext, Models.Equip row, bool nestedForm = false) : base(userContext, "FACCORDI", row, nestedForm) { }

		public Accordi_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, userContext, "FACCORDI", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip(userContext) { Identifier = "FACCORDI" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FACCORDI");
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
		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Accordi) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Accordi) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Accordi) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				if (ValPhotogra == null || !ValPhotogra.IsThumbnail)
					m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Accordi) to Model (Equip) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <inheritdoc />
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "equip.codempre":
						this.ValCodempre = ViewModelConversion.ToString(_value);
						break;
					case "equip.codpess1":
						this.ValCodpess1 = ViewModelConversion.ToString(_value);
						break;
					case "equip.sequennr":
						this.ValSequennr = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.photogra":
						this.ValPhotogra = ViewModelConversion.ToImage(_value);
						break;
					case "equip.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Accordi) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Accordi)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Equip.Find(id ?? Navigation.GetStrValue("equip"), m_userContext, "FACCORDI"); }
			finally { Model ??= new Models.Equip(m_userContext) { Identifier = "FACCORDI" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FACCORDI");
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

			Model.Identifier = "FACCORDI";
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

		protected override void LoadDocumentsProperties(Models.Equip row)
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FACCORDI");
				if (Model == null)
				{
					Model = new Models.Equip(m_userContext) { Identifier = "FACCORDI" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Accordi_cmpnydesignat(qs, lazyLoad);
			Load_Accordi_pess1name____(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ACCORDI]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ACCORDI]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ACCORDI]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ACCORDI]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ACCORDI]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ACCORDI]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, m_userContext, "FACCORDI");
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
		public void Load_Accordi_cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool accordi_cmpnydesignatDoLoad = true;
			CriteriaSet accordi_cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					accordi_cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, hValue);
					this.ValCodempre = DBConversion.ToString(hValue);
				}
			}

			TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
				FillDependant_AccordiTableCmpnyDesignat(lazyLoad);
				return;
			}

			if (accordi_cmpnydesignatDoLoad)
			{
				List<ColumnSort> sorts = [];
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
				accordi_cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate];

// USE /[MANUAL GQT OVERRQ ACCORDI_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					accordi_cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					accordi_cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, accordi_cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_ACCORDI_CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_ACCORDI_CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_AccordiTableCmpnyDesignat();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_AccordiTableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];

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
		public void FillDependant_AccordiTableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_AccordiTableCmpnyDesignat(this.ValCodempre);
			try
			{

				// Fill List fields
				this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
				TableCmpnyDesignat.Value = (string)row["cmpny.designat"];
				if (GenFunctions.emptyG(this.ValCodempre) == 1)
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

		private readonly string[] _fieldsToSerialize_ACCORDI_CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		/// <summary>
		/// TablePess1Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Accordi_pess1name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool accordi_pess1name____DoLoad = true;
			CriteriaSet accordi_pess1name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					accordi_pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, hValue);
					this.ValCodpess1 = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			accordi_pess1name____DoLoad &= AddCriteriaAreaLimit(accordi_pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

			TablePess1Name = new TableDBEdit<Models.Pess1>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
				FillDependant_AccordiTablePess1Name(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodempre))
				accordi_pess1name____DoLoad = false;

			if (accordi_pess1name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
					TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
				else
					TablePess1Name.TableFilters = false;

				query = qs["qTablePess1Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess1.FldName, query + "%");
				}
				accordi_pess1name____Conds.SubSet(search_filters);

				// Last updated by [CJP] at [2016.12.07]
				// Os filtros definidos no Qfield DBEdit passam a ser filtros fracos, to não limparem o Qvalue escolhido.
				// Os filtros podem ser alterados no "ver mais", mas não são obrigatórios.

				string selectedValue = qs["pess1"] ?? this.ValCodpess1;
				CriteriaSet weakFilters = CriteriaSet.Or();
				if (!string.IsNullOrEmpty(selectedValue))
					weakFilters.Equal(CSGenioApess1.FldCodpesso, selectedValue);

				CriteriaSet subfilters = CriteriaSet.And();
				weakFilters.SubSets.Add(subfilters);
				accordi_pess1name____Conds.SubSets.Add(weakFilters);

				string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate];

// USE /[MANUAL GQT OVERRQ ACCORDI_PESS1NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
					accordi_pess1name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess1.FldZzstate, 0)
						.Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
				else
					accordi_pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, false, accordi_pess1name____Conds, fields, offset, numberItems, sorts, "LED_ACCORDI_PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess1Name.Query = query;
				TablePess1Name.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Pess1(m_userContext, r, true, _fieldsToSerialize_ACCORDI_PESS1NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
				//Seleciona se só um
				if (TablePess1Name.List != null && TablePess1Name.List.Count() == 1)
				{
					this.ValCodpess1 = TablePess1Name.List.First().Value;
					Navigation.SetValue("pess1", this.ValCodpess1);
				}
				FillDependant_AccordiTablePess1Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess1</param>
		public ConcurrentDictionary<string, object> GetDependant_AccordiTablePess1Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cmpny");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApess1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AccordiTablePess1Name(bool lazyLoad = false)
		{
			var row = GetDependant_AccordiTablePess1Name(this.ValCodpess1);
			try
			{

				// Fill List fields
				this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
				TablePess1Name.Value = (string)row["pess1.name"];
				if (GenFunctions.emptyG(this.ValCodpess1) == 1)
				{
					this.ValCodpess1 = "";
					TablePess1Name.Value = "";
					Navigation.ClearValue("pess1");
				}
				else if (lazyLoad)
				{
					TablePess1Name.SetPagination(1, 0, false, false, 1);
					TablePess1Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpess1),
							Text = Convert.ToString(TablePess1Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpess1);
				}

				TablePess1Name.Selected = this.ValCodpess1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		public List<TreeNode> Tree_TablePess1Name { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TablePess1Name
		/// </summary>
		public void LoadTree_TablePess1Name(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldName };
			CriteriaSet subfilters = CriteriaSet.And();

			{
				var groupFilters = CriteriaSet.Or();
				subfilters.SubSets.Add(groupFilters);
			}
			{
				var groupFilters = CriteriaSet.Or();
				subfilters.SubSets.Add(groupFilters);
			}

			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ ACCORDI_PESS1VALNAME]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet accordi_pess1name____Conds = CriteriaSet.And();
					{
						bool accordi_pess1name____DoLoad = true;
						// Limits Generation

						// Area limit
						accordi_pess1name____DoLoad &= AddCriteriaAreaLimit(accordi_pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

						if (!accordi_pess1name____DoLoad)
							return;
						accordi_pess1name____Conds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioApess1>()
					{
						BranchLevel = 0, Area = "PESS1", Form = "", IsTree = true, IsTreeTable = false,
						KeySelector = CSGenioApess1.FldCodpesso,
						Selector = CSGenioApess1.FldName,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioApess1.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioApess1.FldName, CSGenioApess1.FldCodpesso }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, accordi_pess1name____Conds, currentSelectedKey, "IBL_ACCORDI_PESS1NAME____"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TablePess1Name = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_ACCORDI_PESS1NAME____ = ["Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"equip.codempre" => ViewModelConversion.ToString(modelValue),
				"equip.coddeco" => ViewModelConversion.ToString(modelValue),
				"equip.coditem" => ViewModelConversion.ToString(modelValue),
				"equip.codpess1" => ViewModelConversion.ToString(modelValue),
				"equip.codrooms" => ViewModelConversion.ToString(modelValue),
				"equip.codtpequ" => ViewModelConversion.ToString(modelValue),
				"equip.codwareh" => ViewModelConversion.ToString(modelValue),
				"equip.sequennr" => ViewModelConversion.ToNumeric(modelValue),
				"equip.photogra" => ViewModelConversion.ToImage(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhotogra != null)
				ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, ValCodequip);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ACCORDI]/

		#endregion
	}
}
