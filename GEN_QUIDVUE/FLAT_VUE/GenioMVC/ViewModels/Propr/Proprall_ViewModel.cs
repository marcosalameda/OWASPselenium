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

namespace GenioMVC.ViewModels.Propr
{
	public class Proprall_ViewModel : FormViewModel<Models.Propr>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValPhotogra { get; set; }

		/// <summary>
		/// Title: "real estate" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Estimated price" | Type: "$D"
		/// </summary>
		public decimal? ValPrecoest { get; set; }

		/// <summary>
		/// Title: "Property Type" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Tppro> TableTpproTppropri { get; set; }

		/// <summary>
		/// Title: "Furnished" | Type: "L"
		/// </summary>
		public bool ValMobilada { get; set; }

		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }

		/// <summary>
		/// Title: "Region" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Regio> TableRegioRegiao { get; set; }

		/// <summary>
		/// Title: "Address" | Type: "MO"
		/// </summary>
		public string ValEndereco { get; set; }

		/// <summary>
		/// Title: "Localization" | Type: "C"
		/// </summary>
		public string ValLocalida { get; set; }

		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValPostalco { get; set; }

		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValPostallo { get; set; }

		/// <summary>
		/// Title: "Bathroom" | Type: "N"
		/// </summary>
		public decimal? ValQtd_wc { get; set; }

		/// <summary>
		/// Title: "Rooms" | Type: "N"
		/// </summary>
		public decimal? ValQtdquart { get; set; }

		/// <summary>
		/// Title: "Square meters" | Type: "N"
		/// </summary>
		public decimal? ValM2 { get; set; }

		/// <summary>
		/// Title: "Available from" | Type: "D"
		/// </summary>
		public DateTime? ValDtdispon { get; set; }

		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }

		/// <summary>
		/// Title: "Geographic Coordinates" | Type: "GG"
		/// </summary>
		public string ValCoordgeo { get; set; }

		/// <summary>
		/// Title: "Seller" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodpais1 { get; set; }

		/// <summary>
		/// Title: "Seller" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }

		/// <summary>
		/// Title: "Region" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }

		/// <summary>
		/// Title: "Property Type" | Type: "CE"
		/// </summary>
		public string ValCodtppro { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpropr { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Proprall_ViewModel() : base(null!) { }

		public Proprall_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPROPRALL", nestedForm) { }

		public Proprall_ViewModel(UserContext userContext, Models.Propr row, bool nestedForm = false) : base(userContext, "FPROPRALL", row, nestedForm) { }

		public Proprall_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("propr", id);
			Model = Models.Propr.Find(id, userContext, "FPROPRALL", fieldsToQuery: fieldsToLoad);
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
			Models.Propr model = new Models.Propr(userContext) { Identifier = "FPROPRALL" };
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
			Models.Propr model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Proprall) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValPrecoest = ViewModelConversion.ToNumeric(m.ValPrecoest);
				ValMobilada = ViewModelConversion.ToLogic(m.ValMobilada);
				ValEndereco = ViewModelConversion.ToString(m.ValEndereco);
				ValLocalida = ViewModelConversion.ToString(m.ValLocalida);
				ValPostalco = ViewModelConversion.ToString(m.ValPostalco);
				ValPostallo = ViewModelConversion.ToString(m.ValPostallo);
				ValQtd_wc = ViewModelConversion.ToNumeric(m.ValQtd_wc);
				ValQtdquart = ViewModelConversion.ToNumeric(m.ValQtdquart);
				ValM2 = ViewModelConversion.ToNumeric(m.ValM2);
				ValDtdispon = ViewModelConversion.ToDateTime(m.ValDtdispon);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodpais1 = ViewModelConversion.ToString(m.ValCodpais1);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValCodtppro = ViewModelConversion.ToString(m.ValCodtppro);
				ValCodpropr = ViewModelConversion.ToString(m.ValCodpropr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Proprall) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proprall) to Model (Propr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValPrecoest = ViewModelConversion.ToNumeric(ValPrecoest);
				m.ValMobilada = ViewModelConversion.ToLogic(ValMobilada);
				m.ValEndereco = ViewModelConversion.ToString(ValEndereco);
				m.ValLocalida = ViewModelConversion.ToString(ValLocalida);
				m.ValPostalco = ViewModelConversion.ToString(ValPostalco);
				m.ValPostallo = ViewModelConversion.ToString(ValPostallo);
				m.ValQtd_wc = ViewModelConversion.ToNumeric(ValQtd_wc);
				m.ValQtdquart = ViewModelConversion.ToNumeric(ValQtdquart);
				m.ValM2 = ViewModelConversion.ToNumeric(ValM2);
				m.ValDtdispon = ViewModelConversion.ToDateTime(ValDtdispon);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpais1 = ViewModelConversion.ToString(ValCodpais1);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodtppro = ViewModelConversion.ToString(ValCodtppro);
				m.ValCodpropr = ViewModelConversion.ToString(ValCodpropr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Proprall) to Model (Propr) - Error during mapping");
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
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPRALL");
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

			Model.Identifier = "FPROPRALL";
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

		protected override void LoadDocumentsProperties(Models.Propr row)
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
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPRALL");
				if (Model == null)
				{
					Model = new Models.Propr(m_userContext) { Identifier = "FPROPRALL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("propr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Propralltpprotppropri(qs, lazyLoad);
			Load_Proprallcntrycountry_(qs, lazyLoad);
			Load_Proprallregioregiao__(qs, lazyLoad);
			Load_Proprallpessoname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROPRALL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROPRALL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.REAL_ESTATE15399, ValName, 85);
			validator.StringLength("ValLocalida", Resources.Resources.LOCALIZATION34148, ValLocalida, 50);
			validator.StringLength("ValPostalco", Resources.Resources.ZIPCODE21021, ValPostalco, 20);
			validator.StringLength("ValPostallo", Resources.Resources.ZIPCODE21021, ValPostallo, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PROPRALL]/
		public override void Save()
		{

			try { Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPRALL"); }
			finally { if (Model == null) Model = new Models.Propr(m_userContext) { Identifier = "FPROPRALL" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROPRALL]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPRALL"); }
			finally { if (Model == null) Model = new Models.Propr(m_userContext) { Identifier = "FPROPRALL" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROPRALL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROPRALL]/
		public override void Destroy(string id)
		{
			Model = Models.Propr.Find(id, m_userContext, "FPROPRALL");
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
		/// TableTpproTppropri -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Propralltpprotppropri(NameValueCollection qs, bool lazyLoad = false)
		{
			bool propralltpprotppropriDoLoad = true;
			CriteriaSet propralltpprotppropriConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tppro", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					propralltpprotppropriConds.Equal(CSGenioAtppro.FldCodtppro, Navigation.GetValue("tppro"));
					this.ValCodtppro = Navigation.GetStrValue("tppro");
				}
			}

			TableTpproTppropri = new TableDBEdit<Models.Tppro>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
					this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}
				FillDependant_ProprallTableTpproTppropri(lazyLoad);
				//Check if foreignkey comes from history
				TableTpproTppropri.FilledByHistory = Navigation.CheckFilledByHistory("tppro");
				return;
			}

			if (propralltpprotppropriDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpproTppropri, "sTableTpproTppropri", "dTableTpproTppropri", qs, "tppro");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtppro.FldTppropri), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpproTppropri_tableFilters"]))
					TableTpproTppropri.TableFilters = bool.Parse(qs["TableTpproTppropri_tableFilters"]);
				else
					TableTpproTppropri.TableFilters = false;

				query = qs["qTableTpproTppropri"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtppro.FldTppropri, query + "%");
				}
				propralltpprotppropriConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpproTppropri"] != null ? qs["pTableTpproTppropri"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioAtppro.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_TPPROTPPROPRI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tppro", FormMode.New) || Navigation.checkFormMode("tppro", FormMode.Duplicate))
					propralltpprotppropriConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtppro.FldZzstate, 0)
						.Equal(CSGenioAtppro.FldCodtppro, Navigation.GetStrValue("tppro")));
				else
					propralltpprotppropriConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtppro.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tppro", "tppropri");
				ListingMVC<CSGenioAtppro> listing = Models.ModelBase.Where<CSGenioAtppro>(m_userContext, false, propralltpprotppropriConds, fields, offset, numberItems, sorts, "LED_PROPRALLTPPROTPPROPRI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpproTppropri.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpproTppropri.Query = query;
				TableTpproTppropri.Elements = listing.RowsForViewModel<GenioMVC.Models.Tppro>((r) => new GenioMVC.Models.Tppro(m_userContext, r, true, _fieldsToSerialize_PROPRALLTPPROTPPROPRI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
					this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}

				TableTpproTppropri.List = new SelectList(TableTpproTppropri.Elements.ToSelectList(x => x.ValTppropri, x => x.ValCodtppro,  x => x.ValCodtppro == this.ValCodtppro), "Value", "Text", this.ValCodtppro);
				FillDependant_ProprallTableTpproTppropri();

				//Check if foreignkey comes from history
				TableTpproTppropri.FilledByHistory = Navigation.CheckFilledByHistory("tppro");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpproTppropri (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tppro</param>
		public ConcurrentDictionary<string, object> GetDependant_ProprallTableTpproTppropri(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri];

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

			CSGenioAtppro tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtppro.FldCodtppro, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpproTppropri (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProprallTableTpproTppropri(bool lazyLoad = false)
		{
			var row = GetDependant_ProprallTableTpproTppropri(this.ValCodtppro);
			try
			{

				// Fill List fields
				this.ValCodtppro = ViewModelConversion.ToString(row["tppro.codtppro"]);
				TableTpproTppropri.Value = (string)row["tppro.tppropri"];
				if (GlobalFunctions.emptyG(this.ValCodtppro) == 1)
				{
					this.ValCodtppro = "";
					TableTpproTppropri.Value = "";
					Navigation.ClearValue("tppro");
				}
				else if (lazyLoad)
				{
					TableTpproTppropri.SetPagination(1, 0, false, false, 1);
					TableTpproTppropri.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtppro),
							Text = Convert.ToString(TableTpproTppropri.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtppro);
				}

				TableTpproTppropri.Selected = this.ValCodtppro;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpproTppropri): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPRALLTPPROTPPROPRI = ["Tppro", "Tppro.ValCodtppro", "Tppro.ValZzstate", "Tppro.ValTppropri"];

		/// <summary>
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Proprallcntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool proprallcntrycountry_DoLoad = true;
			CriteriaSet proprallcntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					proprallcntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetValue("cntry"));
					this.ValCodcntry = Navigation.GetStrValue("cntry");
				}
			}

			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
				FillDependant_ProprallTableCntryCountry(lazyLoad);
				//Check if foreignkey comes from history
				TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
				return;
			}

			if (proprallcntrycountry_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				query = qs["qTableCntryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				}
				proprallcntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					proprallcntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					proprallcntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, proprallcntrycountry_Conds, fields, offset, numberItems, sorts, "LED_PROPRALLCNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_PROPRALLCNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_ProprallTableCntryCountry();

				//Check if foreignkey comes from history
				TableCntryCountry.FilledByHistory = Navigation.CheckFilledByHistory("cntry");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_ProprallTableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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

			CSGenioAcntry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProprallTableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_ProprallTableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TableCntryCountry.Value = "";
					Navigation.ClearValue("cntry");
				}
				else if (lazyLoad)
				{
					TableCntryCountry.SetPagination(1, 0, false, false, 1);
					TableCntryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TableCntryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TableCntryCountry.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPRALLCNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		/// <summary>
		/// TableRegioRegiao -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Proprallregioregiao__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool proprallregioregiao__DoLoad = true;
			CriteriaSet proprallregioregiao__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("regio", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					proprallregioregiao__Conds.Equal(CSGenioAregio.FldCodregia, Navigation.GetValue("regio"));
					this.ValCodregia = Navigation.GetStrValue("regio");
				}
			}
			// Limits Generation

			// Area limit
			proprallregioregiao__DoLoad &= AddCriteriaAreaLimit(proprallregioregiao__Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, false);

			TableRegioRegiao = new TableDBEdit<Models.Regio>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}
				FillDependant_ProprallTableRegioRegiao(lazyLoad);
				//Check if foreignkey comes from history
				TableRegioRegiao.FilledByHistory = Navigation.CheckFilledByHistory("regio");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				proprallregioregiao__DoLoad = false;

			if (proprallregioregiao__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRegioRegiao, "sTableRegioRegiao", "dTableRegioRegiao", qs, "regio");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregio.FldRegiao), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRegioRegiao_tableFilters"]))
					TableRegioRegiao.TableFilters = bool.Parse(qs["TableRegioRegiao_tableFilters"]);
				else
					TableRegioRegiao.TableFilters = false;

				query = qs["qTableRegioRegiao"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAregio.FldRegiao, query + "%");
				}
				proprallregioregiao__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRegioRegiao"] != null ? qs["pTableRegioRegiao"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioAregio.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_REGIOREGIAO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("regio", FormMode.New) || Navigation.checkFormMode("regio", FormMode.Duplicate))
					proprallregioregiao__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAregio.FldZzstate, 0)
						.Equal(CSGenioAregio.FldCodregia, Navigation.GetStrValue("regio")));
				else
					proprallregioregiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregio.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("regio", "regiao");
				ListingMVC<CSGenioAregio> listing = Models.ModelBase.Where<CSGenioAregio>(m_userContext, false, proprallregioregiao__Conds, fields, offset, numberItems, sorts, "LED_PROPRALLREGIOREGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRegioRegiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRegioRegiao.Query = query;
				TableRegioRegiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regio>((r) => new GenioMVC.Models.Regio(m_userContext, r, true, _fieldsToSerialize_PROPRALLREGIOREGIAO__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}

				TableRegioRegiao.List = new SelectList(TableRegioRegiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
				FillDependant_ProprallTableRegioRegiao();

				//Check if foreignkey comes from history
				TableRegioRegiao.FilledByHistory = Navigation.CheckFilledByHistory("regio");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Regio</param>
		public ConcurrentDictionary<string, object> GetDependant_ProprallTableRegioRegiao(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cntry");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAregio.FldCodcntry, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAregio tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAregio.FldCodregia, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProprallTableRegioRegiao(bool lazyLoad = false)
		{
			var row = GetDependant_ProprallTableRegioRegiao(this.ValCodregia);
			try
			{

				// Fill List fields
				this.ValCodregia = ViewModelConversion.ToString(row["regio.codregia"]);
				TableRegioRegiao.Value = (string)row["regio.regiao"];
				if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
				{
					this.ValCodregia = "";
					TableRegioRegiao.Value = "";
					Navigation.ClearValue("regio");
				}
				else if (lazyLoad)
				{
					TableRegioRegiao.SetPagination(1, 0, false, false, 1);
					TableRegioRegiao.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodregia),
							Text = Convert.ToString(TableRegioRegiao.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodregia);
				}

				TableRegioRegiao.Selected = this.ValCodregia;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegioRegiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPRALLREGIOREGIAO__ = ["Regio", "Regio.ValCodregia", "Regio.ValZzstate", "Regio.ValRegiao"];

		/// <summary>
		/// TablePessoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Proprallpessoname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool proprallpessoname____DoLoad = true;
			CriteriaSet proprallpessoname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pesso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					proprallpessoname____Conds.Equal(CSGenioApesso.FldCodpesso, Navigation.GetValue("pesso"));
					this.ValCodpesso = Navigation.GetStrValue("pesso");
				}
			}
			// Limits Generation

			// Area limit
			proprallpessoname____DoLoad &= AddCriteriaAreaLimit(proprallpessoname____Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, false);

			TablePessoName = new TableDBEdit<Models.Pesso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
				FillDependant_ProprallTablePessoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				proprallpessoname____DoLoad = false;

			if (proprallpessoname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
					TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
				else
					TablePessoName.TableFilters = false;

				query = qs["qTablePessoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApesso.FldName, query + "%");
				}
				proprallpessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate };

// USE /[MANUAL GQT OVERRQ PROPRALL_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					proprallpessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					proprallpessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, proprallpessoname____Conds, fields, offset, numberItems, sorts, "LED_PROPRALLPESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_PROPRALLPESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_ProprallTablePessoName();

				//Check if foreignkey comes from history
				TablePessoName.FilledByHistory = Navigation.CheckFilledByHistory("pesso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_ProprallTablePessoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cntry");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApesso.FldCodpaise, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApesso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProprallTablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_ProprallTablePessoName(this.ValCodpesso);
			try
			{

				// Fill List fields
				this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
				TablePessoName.Value = (string)row["pesso.name"];
				if (GlobalFunctions.emptyG(this.ValCodpesso) == 1)
				{
					this.ValCodpesso = "";
					TablePessoName.Value = "";
					Navigation.ClearValue("pesso");
				}
				else if (lazyLoad)
				{
					TablePessoName.SetPagination(1, 0, false, false, 1);
					TablePessoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpesso),
							Text = Convert.ToString(TablePessoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpesso);
				}

				TablePessoName.Selected = this.ValCodpesso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPRALLPESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"propr.photogra" => ViewModelConversion.ToImage(modelValue),
				"propr.name" => ViewModelConversion.ToString(modelValue),
				"propr.precoest" => ViewModelConversion.ToNumeric(modelValue),
				"propr.mobilada" => ViewModelConversion.ToLogic(modelValue),
				"propr.endereco" => ViewModelConversion.ToString(modelValue),
				"propr.localida" => ViewModelConversion.ToString(modelValue),
				"propr.postalco" => ViewModelConversion.ToString(modelValue),
				"propr.postallo" => ViewModelConversion.ToString(modelValue),
				"propr.qtd_wc" => ViewModelConversion.ToNumeric(modelValue),
				"propr.qtdquart" => ViewModelConversion.ToNumeric(modelValue),
				"propr.m2" => ViewModelConversion.ToNumeric(modelValue),
				"propr.dtdispon" => ViewModelConversion.ToDateTime(modelValue),
				"propr.descript" => ViewModelConversion.ToString(modelValue),
				"propr.coordgeo" => ViewModelConversion.ToString(modelValue),
				"propr.codcntry" => ViewModelConversion.ToString(modelValue),
				"propr.codpais1" => ViewModelConversion.ToString(modelValue),
				"propr.codpesso" => ViewModelConversion.ToString(modelValue),
				"propr.codregia" => ViewModelConversion.ToString(modelValue),
				"propr.codtppro" => ViewModelConversion.ToString(modelValue),
				"propr.codpropr" => ViewModelConversion.ToString(modelValue),
				"tppro.codtppro" => ViewModelConversion.ToString(modelValue),
				"tppro.tppropri" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"regio.codregia" => ViewModelConversion.ToString(modelValue),
				"regio.regiao" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPRALL]/

		#endregion
	}
}
