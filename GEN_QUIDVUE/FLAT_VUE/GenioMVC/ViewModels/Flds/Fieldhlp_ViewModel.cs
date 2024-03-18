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

namespace GenioMVC.ViewModels.Flds
{
	public class Fieldhlp_ViewModel : FormViewModel<Models.Flds>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Text Field" | Type: "C"
		/// </summary>
		public string ValTxtfield { get; set; }

		/// <summary>
		/// Title: "Multine Text" | Type: "MO"
		/// </summary>
		public string ValDescrip { get; set; }

		/// <summary>
		/// Title: "Year" | Type: "N"
		/// </summary>
		public decimal? ValYear { get; set; }

		/// <summary>
		/// Title: "Time" | Type: "T"
		/// </summary>
		public string ValTime { get; set; }

		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }

		/// <summary>
		/// Title: "Date time" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetime { get; set; }

		/// <summary>
		/// Title: "Date second" | Type: "DS"
		/// </summary>
		public DateTime? ValDateseco { get; set; }

		/// <summary>
		/// Title: "Numeric" | Type: "N"
		/// </summary>
		public decimal? ValNpassage { get; set; }

		/// <summary>
		/// Title: "Numeric decimal" | Type: "ND"
		/// </summary>
		public decimal? ValDuration { get; set; }

		/// <summary>
		/// Title: "Currency Decimal" | Type: "$D"
		/// </summary>
		public decimal? ValPrecobil { get; set; }

		/// <summary>
		/// Title: "Currency" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }

		/// <summary>
		/// Title: "Social Security No" | Type: "C"
		/// </summary>
		public string ValSsnumber { get; set; }

		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValZipfield { get; set; }

		/// <summary>
		/// Title: "VAT Number" | Type: "C"
		/// </summary>
		public string ValVatnumbr { get; set; }

		/// <summary>
		/// Title: "Licence plate" | Type: "C"
		/// </summary>
		public string ValLicplate { get; set; }

		/// <summary>
		/// Title: "Banking Account Number" | Type: "C"
		/// </summary>
		public string ValBanknmbr { get; set; }

		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmailfld { get; set; }

		/// <summary>
		/// Title: "IBAN" | Type: "C"
		/// </summary>
		public string ValIbanfiel { get; set; }

		/// <summary>
		/// Title: "Uppercase" | Type: "C"
		/// </summary>
		public string ValUpprtext { get; set; }

		/// <summary>
		/// Title: "Password" | Type: "C"
		/// </summary>
		public string ValPassfld { get; set; }

		/// <summary>
		/// Title: "Colorpicker" | Type: "C"
		/// </summary>
		public string ValClrpicke { get; set; }

		/// <summary>
		/// Title: "Logical" | Type: "L"
		/// </summary>
		public bool ValPrimviag { get; set; }

		/// <summary>
		/// Title: "" | Type: "AL"
		/// </summary>
		public int ValLogicenu { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValLogicenu { get; set; }

		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		public string ValCreatuse { get; set; }

		/// <summary>
		/// Title: "Day" | Type: "OD"
		/// </summary>
		public DateTime? ValCreatdat { get; set; }

		/// <summary>
		/// Title: "Complete Date" | Type: "OI"
		/// </summary>
		public DateTime? ValCreatins { get; set; }

		/// <summary>
		/// Title: "Hour" | Type: "OT"
		/// </summary>
		public string ValCreathou { get; set; }

		/// <summary>
		/// Title: "Airline name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Aero> TableAeroName { get; set; }

		/// <summary>
		/// Title: "Conditional" | Type: "IF"
		/// </summary>
		public double ValConditio { get; set; }

		/// <summary>
		/// Title: "Text Enumeration" | Type: "AC"
		/// </summary>
		public string ValClass { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValClass { get; set; }

		/// <summary>
		/// Title: "Radio Btn" | Type: "AC"
		/// </summary>
		public string ValRadiob { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValRadiob { get; set; }

		/// <summary>
		/// Title: "Logo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.ViewModels.ImageModel ValLogo { get; set; }

		/// <summary>
		/// Title: "Document" | Type: "IB"
		/// </summary>
		[Document("ValAttach", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValAttach { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValAttachfk { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValAttachPropertiesVM { get; set; }

		/// <summary>
		/// Title: "No. register" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Equip> TableEquipRegistnr { get; set; }

		/// <summary>
		/// Title: "Show record" | Type: "L"
		/// </summary>
		public bool ValShwrc { get; set; }

		/// <summary>
		/// Title: "Numeric Enumeration" | Type: "AN"
		/// </summary>
		public double ValClassnum { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValClassnum { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Airline name" | Type: "CE"
		/// </summary>
		public string ValCodaero { get; set; }

		/// <summary>
		/// Title: "No. register" | Type: "CE"
		/// </summary>
		public string ValCodequip { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodflds { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Fieldhlp_ViewModel() : base(null!) { }

		public Fieldhlp_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFIELDHLP", nestedForm) { }

		public Fieldhlp_ViewModel(UserContext userContext, Models.Flds row, bool nestedForm = false) : base(userContext, "FFIELDHLP", row, nestedForm) { }

		public Fieldhlp_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, userContext, "FFIELDHLP", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Flds model = new Models.Flds(userContext) { Identifier = "FFIELDHLP" };
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
			Models.Flds model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fieldhlp) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValTxtfield = ViewModelConversion.ToString(m.ValTxtfield);
				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValTime = ViewModelConversion.ToString(m.ValTime);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValSsnumber = ViewModelConversion.ToString(m.ValSsnumber);
				ValZipfield = ViewModelConversion.ToString(m.ValZipfield);
				ValVatnumbr = ViewModelConversion.ToString(m.ValVatnumbr);
				ValLicplate = ViewModelConversion.ToString(m.ValLicplate);
				ValBanknmbr = ViewModelConversion.ToString(m.ValBanknmbr);
				ValEmailfld = ViewModelConversion.ToString(m.ValEmailfld);
				ValIbanfiel = ViewModelConversion.ToString(m.ValIbanfiel);
				ValUpprtext = ViewModelConversion.ToString(m.ValUpprtext);
				ValPassfld = ViewModelConversion.ToString(m.ValPassfld);
				ValClrpicke = ViewModelConversion.ToString(m.ValClrpicke);
				ValPrimviag = ViewModelConversion.ToLogic(m.ValPrimviag);
				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
				ValConditio = ViewModelConversion.ToDouble(m.ValConditio);
				ValClass = ViewModelConversion.ToString(m.ValClass);
				ValRadiob = ViewModelConversion.ToString(m.ValRadiob);
				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
				ValAttach = ViewModelConversion.ToString(m.ValAttach);
				ValAttachfk = ViewModelConversion.ToString(m.ValAttachfk);
				ValShwrc = ViewModelConversion.ToLogic(m.ValShwrc);
				ValClassnum = ViewModelConversion.ToDouble(m.ValClassnum);
				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fieldhlp) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fieldhlp) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTxtfield = ViewModelConversion.ToString(ValTxtfield);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValSsnumber = ViewModelConversion.ToString(ValSsnumber);
				m.ValZipfield = ViewModelConversion.ToString(ValZipfield);
				m.ValVatnumbr = ViewModelConversion.ToString(ValVatnumbr);
				m.ValLicplate = ViewModelConversion.ToString(ValLicplate);
				m.ValBanknmbr = ViewModelConversion.ToString(ValBanknmbr);
				m.ValEmailfld = ViewModelConversion.ToString(ValEmailfld);
				m.ValIbanfiel = ViewModelConversion.ToString(ValIbanfiel);
				m.ValUpprtext = ViewModelConversion.ToString(ValUpprtext);
				m.ValPassfld = ViewModelConversion.ToString(ValPassfld);
				m.ValClrpicke = ViewModelConversion.ToString(ValClrpicke);
				m.ValPrimviag = ViewModelConversion.ToLogic(ValPrimviag);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValConditio = ViewModelConversion.ToDouble(ValConditio);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValRadiob = ViewModelConversion.ToString(ValRadiob);
				m.ValLogo = ViewModelConversion.ToImage(ValLogo);
				m.ValAttach = ViewModelConversion.ToString(ValAttach);
				m.ValAttachfk = ViewModelConversion.ToString(ValAttachfk);
				m.ValShwrc = ViewModelConversion.ToLogic(ValShwrc);
				m.ValClassnum = ViewModelConversion.ToDouble(ValClassnum);
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fieldhlp) to Model (Flds) - Error during mapping");
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFIELDHLP");
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

			Model.Identifier = "FFIELDHLP";
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

		protected override void LoadDocumentsProperties(Models.Flds row)
		{
			try
			{
				ValAttachPropertiesVM = row.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				ValAttachPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFIELDHLP");
				if (Model == null)
				{
					Model = new Models.Flds(m_userContext) { Identifier = "FFIELDHLP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Fieldhlpaero_name____(qs, lazyLoad);
			Load_Fieldhlpequipregistnr(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FIELDHLP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FIELDHLP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValTxtfield", Resources.Resources.TEXT_FIELD41810, ValTxtfield, 50);
			validator.StringLength("ValSsnumber", Resources.Resources.SOCIAL_SECURITY_NO48150, ValSsnumber, 11);
			validator.StringLength("ValZipfield", Resources.Resources.ZIPCODE21021, ValZipfield, 8);
			validator.StringLength("ValVatnumbr", Resources.Resources.VAT_NUMBER24236, ValVatnumbr, 9);
			validator.StringLength("ValLicplate", Resources.Resources.LICENCE_PLATE07627, ValLicplate, 8);
			validator.StringLength("ValBanknmbr", Resources.Resources.BANKING_ACCOUNT_NUMB62548, ValBanknmbr, 24);
			validator.StringLength("ValEmailfld", Resources.Resources.EMAIL25170, ValEmailfld, 50);
			validator.StringLength("ValIbanfiel", Resources.Resources.IBAN28506, ValIbanfiel, 34);
			validator.StringLength("ValUpprtext", Resources.Resources.UPPERCASE48238, ValUpprtext, 50);
			validator.StringLength("ValPassfld", Resources.Resources.PASSWORD09467, ValPassfld, 50);
			validator.StringLength("ValClrpicke", Resources.Resources.COLORPICKER39653, ValClrpicke, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FIELDHLP]/
		public override void Save()
		{

			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFIELDHLP"); }
			finally { if (Model == null) Model = new Models.Flds(m_userContext) { Identifier = "FFIELDHLP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FIELDHLP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFIELDHLP"); }
			finally { if (Model == null) Model = new Models.Flds(m_userContext) { Identifier = "FFIELDHLP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FIELDHLP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FIELDHLP]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, m_userContext, "FFIELDHLP");
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
		/// TableAeroName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Fieldhlpaero_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool fieldhlpaero_name____DoLoad = true;
			CriteriaSet fieldhlpaero_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("aero", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					fieldhlpaero_name____Conds.Equal(CSGenioAaero.FldCodaero, Navigation.GetValue("aero"));
					this.ValCodaero = Navigation.GetStrValue("aero");
				}
			}

			TableAeroName = new TableDBEdit<Models.Aero>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}
				FillDependant_FieldhlpTableAeroName(lazyLoad);
				//Check if foreignkey comes from history
				TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
				return;
			}

			if (fieldhlpaero_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAeroName, "sTableAeroName", "dTableAeroName", qs, "aero");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAaero.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAeroName_tableFilters"]))
					TableAeroName.TableFilters = bool.Parse(qs["TableAeroName_tableFilters"]);
				else
					TableAeroName.TableFilters = false;

				query = qs["qTableAeroName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAaero.FldName, query + "%");
				}
				fieldhlpaero_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAeroName"] != null ? qs["pTableAeroName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAaero.FldZzstate };

// USE /[MANUAL GQT OVERRQ FIELDHLP_AERONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("aero", FormMode.New) || Navigation.checkFormMode("aero", FormMode.Duplicate))
					fieldhlpaero_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAaero.FldZzstate, 0)
						.Equal(CSGenioAaero.FldCodaero, Navigation.GetStrValue("aero")));
				else
					fieldhlpaero_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAaero.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("aero", "name");
				ListingMVC<CSGenioAaero> listing = Models.ModelBase.Where<CSGenioAaero>(m_userContext, false, fieldhlpaero_name____Conds, fields, offset, numberItems, sorts, "LED_FIELDHLPAERO_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAeroName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAeroName.Query = query;
				TableAeroName.Elements = listing.RowsForViewModel<GenioMVC.Models.Aero>((r) => new GenioMVC.Models.Aero(m_userContext, r, true, _fieldsToSerialize_FIELDHLPAERO_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}

				TableAeroName.List = new SelectList(TableAeroName.Elements.ToSelectList(x => x.ValName, x => x.ValCodaero,  x => x.ValCodaero == this.ValCodaero), "Value", "Text", this.ValCodaero);
				FillDependant_FieldhlpTableAeroName();

				//Check if foreignkey comes from history
				TableAeroName.FilledByHistory = Navigation.CheckFilledByHistory("aero");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAeroName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Aero</param>
		public ConcurrentDictionary<string, object> GetDependant_FieldhlpTableAeroName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAaero.FldCodaero, CSGenioAaero.FldName];

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

			CSGenioAaero tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAaero.FldCodaero, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAeroName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FieldhlpTableAeroName(bool lazyLoad = false)
		{
			var row = GetDependant_FieldhlpTableAeroName(this.ValCodaero);
			try
			{

				// Fill List fields
				this.ValCodaero = ViewModelConversion.ToString(row["aero.codaero"]);
				TableAeroName.Value = (string)row["aero.name"];
				if (GlobalFunctions.emptyG(this.ValCodaero) == 1)
				{
					this.ValCodaero = "";
					TableAeroName.Value = "";
					Navigation.ClearValue("aero");
				}
				else if (lazyLoad)
				{
					TableAeroName.SetPagination(1, 0, false, false, 1);
					TableAeroName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodaero),
							Text = Convert.ToString(TableAeroName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodaero);
				}

				TableAeroName.Selected = this.ValCodaero;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAeroName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FIELDHLPAERO_NAME____ = ["Aero", "Aero.ValCodaero", "Aero.ValZzstate", "Aero.ValName"];

		/// <summary>
		/// TableEquipRegistnr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Fieldhlpequipregistnr(NameValueCollection qs, bool lazyLoad = false)
		{
			bool fieldhlpequipregistnrDoLoad = true;
			CriteriaSet fieldhlpequipregistnrConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("equip", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					fieldhlpequipregistnrConds.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));
					this.ValCodequip = Navigation.GetStrValue("equip");
				}
			}

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
				FillDependant_FieldhlpTableEquipRegistnr(lazyLoad);
				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
				return;
			}

			if (fieldhlpequipregistnrDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEquipRegistnr, "sTableEquipRegistnr", "dTableEquipRegistnr", qs, "equip");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

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
				fieldhlpequipregistnrConds.SubSet(search_filters);

				string tryParsePage = qs["pTableEquipRegistnr"] != null ? qs["pTableEquipRegistnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldZzstate };

// USE /[MANUAL GQT OVERRQ FIELDHLP_EQUIPREGISTNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("equip", FormMode.New) || Navigation.checkFormMode("equip", FormMode.Duplicate))
					fieldhlpequipregistnrConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAequip.FldZzstate, 0)
						.Equal(CSGenioAequip.FldCodequip, Navigation.GetStrValue("equip")));
				else
					fieldhlpequipregistnrConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAequip.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("equip", "registnr");
				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(m_userContext, false, fieldhlpequipregistnrConds, fields, offset, numberItems, sorts, "LED_FIELDHLPEQUIPREGISTNR", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEquipRegistnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEquipRegistnr.Query = query;
				TableEquipRegistnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Equip>((r) => new GenioMVC.Models.Equip(m_userContext, r, true, _fieldsToSerialize_FIELDHLPEQUIPREGISTNR));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_equip") != null)
				{
					this.ValCodequip = Navigation.GetStrValue("RETURN_equip");
					Navigation.CurrentLevel.SetEntry("RETURN_equip", null);
				}

				TableEquipRegistnr.List = new SelectList(TableEquipRegistnr.Elements.ToSelectList(x => x.ValRegistnr, x => x.ValCodequip,  x => x.ValCodequip == this.ValCodequip), "Value", "Text", this.ValCodequip);
				FillDependant_FieldhlpTableEquipRegistnr();

				//Check if foreignkey comes from history
				TableEquipRegistnr.FilledByHistory = Navigation.CheckFilledByHistory("equip");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEquipRegistnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Equip</param>
		public ConcurrentDictionary<string, object> GetDependant_FieldhlpTableEquipRegistnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr];

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
		public void FillDependant_FieldhlpTableEquipRegistnr(bool lazyLoad = false)
		{
			var row = GetDependant_FieldhlpTableEquipRegistnr(this.ValCodequip);
			try
			{

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

		private readonly string[] _fieldsToSerialize_FIELDHLPEQUIPREGISTNR = ["Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Equip.ValRegistnr"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"flds.txtfield" => ViewModelConversion.ToString(modelValue),
				"flds.descrip" => ViewModelConversion.ToString(modelValue),
				"flds.year" => ViewModelConversion.ToNumeric(modelValue),
				"flds.time" => ViewModelConversion.ToString(modelValue),
				"flds.date" => ViewModelConversion.ToDateTime(modelValue),
				"flds.datetime" => ViewModelConversion.ToDateTime(modelValue),
				"flds.dateseco" => ViewModelConversion.ToDateTime(modelValue),
				"flds.npassage" => ViewModelConversion.ToNumeric(modelValue),
				"flds.duration" => ViewModelConversion.ToNumeric(modelValue),
				"flds.precobil" => ViewModelConversion.ToNumeric(modelValue),
				"flds.price" => ViewModelConversion.ToNumeric(modelValue),
				"flds.ssnumber" => ViewModelConversion.ToString(modelValue),
				"flds.zipfield" => ViewModelConversion.ToString(modelValue),
				"flds.vatnumbr" => ViewModelConversion.ToString(modelValue),
				"flds.licplate" => ViewModelConversion.ToString(modelValue),
				"flds.banknmbr" => ViewModelConversion.ToString(modelValue),
				"flds.emailfld" => ViewModelConversion.ToString(modelValue),
				"flds.ibanfiel" => ViewModelConversion.ToString(modelValue),
				"flds.upprtext" => ViewModelConversion.ToString(modelValue),
				"flds.passfld" => ViewModelConversion.ToString(modelValue),
				"flds.clrpicke" => ViewModelConversion.ToString(modelValue),
				"flds.primviag" => ViewModelConversion.ToLogic(modelValue),
				"flds.logicenu" => ViewModelConversion.ToInteger(modelValue),
				"flds.creatuse" => ViewModelConversion.ToString(modelValue),
				"flds.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creatins" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creathou" => ViewModelConversion.ToString(modelValue),
				"flds.conditio" => ViewModelConversion.ToDouble(modelValue),
				"flds.class" => ViewModelConversion.ToString(modelValue),
				"flds.radiob" => ViewModelConversion.ToString(modelValue),
				"flds.logo" => ViewModelConversion.ToImage(modelValue),
				"flds.attach" => ViewModelConversion.ToString(modelValue),
				"flds.shwrc" => ViewModelConversion.ToLogic(modelValue),
				"flds.classnum" => ViewModelConversion.ToDouble(modelValue),
				"flds.codaero" => ViewModelConversion.ToString(modelValue),
				"flds.codequip" => ViewModelConversion.ToString(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				"aero.codaero" => ViewModelConversion.ToString(modelValue),
				"aero.name" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FIELDHLP]/

		#endregion
	}
}
