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
	public class Pesso_ViewModel : FormViewModel<Models.Pesso>, IPreparableForSerialization
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
		/// Title: "Category" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodcateg { get; set; }
		/// <summary>
		/// Title: "Company" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodpaise { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }
		/// <summary>
		/// Title: "Region of the person:" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }

		#endregion
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValPhotogra { get; set; }
		/// <summary>
		/// Title: "Employee No." | Type: "N"
		/// </summary>
		public decimal? ValIdfuncio { get; set; }
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
		/// Title: "Birth" | Type: "D"
		/// </summary>
		public DateTime? ValDtnascim { get; set; }
		/// <summary>
		/// Title: "Age" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValIdade { get; set; }
		/// <summary>
		/// Title: "Intern" | Type: "L"
		/// </summary>
		public bool ValInterna { get; set; }
		/// <summary>
		/// Title: "External" | Type: "L"
		/// </summary>
		public bool ValExterna { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Categ> TableCategCategory { get; set; }
		/// <summary>
		/// Title: "Since" | Type: "D"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValDtultcat { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pais1> TablePais1Country { get; set; }
		/// <summary>
		/// Title: "Specialties" | Type: "PSEUD"
		/// </summary>
		[ValidateSetAccess]
		public List<GenioMVC.Models.Speci> List_Especial { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public List<GenioMVC.Models.Speci> List_EspecialSelected { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string[] List_Especial_SelectedIds { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string List_Especial_Area { get; set; }
		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }
		/// <summary>
		/// Title: "Email:" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Company" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CntryValCountry 
		{
			get
			{
				return funcCntryValCountry != null ? funcCntryValCountry() : _auxCntryValCountry;
			}
			set { funcCntryValCountry = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCntryValCountry { get; set; }

		private string _auxCntryValCountry { get; set; }
		/// <summary>
		/// Title: "Region of the person:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Regi1> TableRegi1Regiao { get; set; }
		/// <summary>
		/// Title: "Alternative Email" | Type: "C"
		/// </summary>
		public string ValEmail2 { get; set; }
		/// <summary>
		/// Title: "Query for external API" | Type: "C"
		/// </summary>
		public string ValExtquery { get; set; }
		/// <summary>
		/// Title: "Zoom level" | Type: "N"
		/// </summary>
		public decimal? ValZoomlvl { get; set; }
		/// <summary>
		/// Title: "Minimum zoom to load features" | Type: "N"
		/// </summary>
		public decimal? ValExtminzm { get; set; }
		/// <summary>
		/// Title: "Map height" | Type: "C"
		/// </summary>
		public string ValMapheigh { get; set; }
		/// <summary>
		/// Title: "Outline weight" | Type: "N"
		/// </summary>
		public decimal? ValOutweigh { get; set; }
		/// <summary>
		/// Title: "Polyline color" | Type: "C"
		/// </summary>
		public string ValLineclr { get; set; }
		/// <summary>
		/// Title: "Polygon color" | Type: "C"
		/// </summary>
		public string ValPolyclr { get; set; }
		/// <summary>
		/// Title: "Allow drawing markers" | Type: "L"
		/// </summary>
		public bool ValDrawmrk { get; set; }
		/// <summary>
		/// Title: "Allow drawing polylines" | Type: "L"
		/// </summary>
		public bool ValAllowlin { get; set; }
		/// <summary>
		/// Title: "Allow drawing polygons" | Type: "L"
		/// </summary>
		public bool ValAllowpol { get; set; }
		/// <summary>
		/// Title: "Allow exporting map" | Type: "L"
		/// </summary>
		public bool ValCanexpor { get; set; }
		/// <summary>
		/// Title: "Group markers in cluster" | Type: "L"
		/// </summary>
		public bool ValGroupmrk { get; set; }
		/// <summary>
		/// Title: "Allow feature editing" | Type: "L"
		/// </summary>
		public bool ValCanedit { get; set; }
		/// <summary>
		/// Title: "Allow feature cutting" | Type: "L"
		/// </summary>
		public bool ValCancut { get; set; }
		/// <summary>
		/// Title: "Allow feature dragging" | Type: "L"
		/// </summary>
		public bool ValCandrag { get; set; }
		/// <summary>
		/// Title: "Allow feature rotation" | Type: "L"
		/// </summary>
		public bool ValCanrot { get; set; }
		/// <summary>
		/// Title: "Allow feature removal" | Type: "L"
		/// </summary>
		public bool ValCanremov { get; set; }
		/// <summary>
		/// Title: "Terrain" | Type: "GS"
		/// </summary>
		public CSGenio.framework.Geography.GeographicData ValTerrain { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the CmpnyValHeadloc field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<string> funcCmpnyValHeadloc { get; set; }
		private string _auxCmpnyValHeadloc { get; set; }
		/// <summary>Field: "Headquarter location" Tipo: "GG"</summary>
		[ValidateSetAccess]
		public string CmpnyValHeadloc { get { return funcCmpnyValHeadloc != null ? funcCmpnyValHeadloc() : _auxCmpnyValHeadloc; } private set { funcCmpnyValHeadloc = () => value; } }

		#endregion

		public string ValCodpesso { get; set; }

		private readonly string[] _fieldsToSerialize = ["Glob", "Glob.ValApiurl"];
		/// <summary>
		/// Gets the list of fields that should be serialized when sending information to the client-side.
		/// Currently, it is only used to limit the serialized fields of the GLOB table.
		/// </summary>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Pesso_ViewModel() : base(null!) { }

		public Pesso_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPESSO", nestedForm) { }

		public Pesso_ViewModel(UserContext userContext, Models.Pesso row, bool nestedForm = false) : base(userContext, "FPESSO", row, nestedForm) { }

		public Pesso_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, userContext, "FPESSO", fieldsToQuery: fieldsToLoad);
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
			Models.Pesso model = new Models.Pesso(userContext) { Identifier = "FPESSO" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPESSO");
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

		/// <inheritdoc />
		public override void MapFromModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCodpaise = ViewModelConversion.ToString(m.ValCodpaise);
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValIdfuncio = ViewModelConversion.ToNumeric(m.ValIdfuncio);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValDtnascim = ViewModelConversion.ToDateTime(m.ValDtnascim);
				ValIdade = ViewModelConversion.ToNumeric(m.ValIdade);
				ValInterna = ViewModelConversion.ToLogic(m.ValInterna);
				ValExterna = ViewModelConversion.ToLogic(m.ValExterna);
				ValDtultcat = ViewModelConversion.ToDateTime(m.ValDtultcat);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				funcCntryValCountry = () => ViewModelConversion.ToString(m.Cntry.ValCountry);
				ValEmail2 = ViewModelConversion.ToString(m.ValEmail2);
				ValExtquery = ViewModelConversion.ToString(m.ValExtquery);
				ValZoomlvl = ViewModelConversion.ToNumeric(m.ValZoomlvl);
				ValExtminzm = ViewModelConversion.ToNumeric(m.ValExtminzm);
				ValMapheigh = ViewModelConversion.ToString(m.ValMapheigh);
				ValOutweigh = ViewModelConversion.ToNumeric(m.ValOutweigh);
				ValLineclr = ViewModelConversion.ToString(m.ValLineclr);
				ValPolyclr = ViewModelConversion.ToString(m.ValPolyclr);
				ValDrawmrk = ViewModelConversion.ToLogic(m.ValDrawmrk);
				ValAllowlin = ViewModelConversion.ToLogic(m.ValAllowlin);
				ValAllowpol = ViewModelConversion.ToLogic(m.ValAllowpol);
				ValCanexpor = ViewModelConversion.ToLogic(m.ValCanexpor);
				ValGroupmrk = ViewModelConversion.ToLogic(m.ValGroupmrk);
				ValCanedit = ViewModelConversion.ToLogic(m.ValCanedit);
				ValCancut = ViewModelConversion.ToLogic(m.ValCancut);
				ValCandrag = ViewModelConversion.ToLogic(m.ValCandrag);
				ValCanrot = ViewModelConversion.ToLogic(m.ValCanrot);
				ValCanremov = ViewModelConversion.ToLogic(m.ValCanremov);
				ValTerrain = ViewModelConversion.ToGeographicShape(m.ValTerrain);
				funcCmpnyValHeadloc = () => ViewModelConversion.ToString(m.Cmpny.ValHeadloc);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesso) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpaise = ViewModelConversion.ToString(ValCodpaise);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				if (ValPhotogra == null || !ValPhotogra.IsThumbnail)
					m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
				m.ValInterna = ViewModelConversion.ToLogic(ValInterna);
				m.ValExterna = ViewModelConversion.ToLogic(ValExterna);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValEmail2 = ViewModelConversion.ToString(ValEmail2);
				m.ValExtquery = ViewModelConversion.ToString(ValExtquery);
				m.ValZoomlvl = ViewModelConversion.ToNumeric(ValZoomlvl);
				m.ValExtminzm = ViewModelConversion.ToNumeric(ValExtminzm);
				m.ValMapheigh = ViewModelConversion.ToString(ValMapheigh);
				m.ValOutweigh = ViewModelConversion.ToNumeric(ValOutweigh);
				m.ValLineclr = ViewModelConversion.ToString(ValLineclr);
				m.ValPolyclr = ViewModelConversion.ToString(ValPolyclr);
				m.ValDrawmrk = ViewModelConversion.ToLogic(ValDrawmrk);
				m.ValAllowlin = ViewModelConversion.ToLogic(ValAllowlin);
				m.ValAllowpol = ViewModelConversion.ToLogic(ValAllowpol);
				m.ValCanexpor = ViewModelConversion.ToLogic(ValCanexpor);
				m.ValGroupmrk = ViewModelConversion.ToLogic(ValGroupmrk);
				m.ValCanedit = ViewModelConversion.ToLogic(ValCanedit);
				m.ValCancut = ViewModelConversion.ToLogic(ValCancut);
				m.ValCandrag = ViewModelConversion.ToLogic(ValCandrag);
				m.ValCanrot = ViewModelConversion.ToLogic(ValCanrot);
				m.ValCanremov = ViewModelConversion.ToLogic(ValCanremov);
				m.ValTerrain = ViewModelConversion.ToGeographicShape(ValTerrain);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValIdade = ViewModelConversion.ToNumeric(ValIdade);
				m.ValDtultcat = ViewModelConversion.ToDateTime(ValDtultcat);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Pesso) to Model (Pesso) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "pesso.codempre":
						this.ValCodempre = ViewModelConversion.ToString(_value);
						break;
					case "pesso.codpaise":
						this.ValCodpaise = ViewModelConversion.ToString(_value);
						break;
					case "pesso.codcntry":
						this.ValCodcntry = ViewModelConversion.ToString(_value);
						break;
					case "pesso.codregia":
						this.ValCodregia = ViewModelConversion.ToString(_value);
						break;
					case "pesso.photogra":
						this.ValPhotogra = ViewModelConversion.ToImage(_value);
						break;
					case "pesso.idfuncio":
						this.ValIdfuncio = ViewModelConversion.ToNumeric(_value);
						break;
					case "pesso.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "pesso.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "pesso.dtnascim":
						this.ValDtnascim = ViewModelConversion.ToDateTime(_value);
						break;
					case "pesso.interna":
						this.ValInterna = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.externa":
						this.ValExterna = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.telephon":
						this.ValTelephon = ViewModelConversion.ToString(_value);
						break;
					case "pesso.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "pesso.email2":
						this.ValEmail2 = ViewModelConversion.ToString(_value);
						break;
					case "pesso.extquery":
						this.ValExtquery = ViewModelConversion.ToString(_value);
						break;
					case "pesso.zoomlvl":
						this.ValZoomlvl = ViewModelConversion.ToNumeric(_value);
						break;
					case "pesso.extminzm":
						this.ValExtminzm = ViewModelConversion.ToNumeric(_value);
						break;
					case "pesso.mapheigh":
						this.ValMapheigh = ViewModelConversion.ToString(_value);
						break;
					case "pesso.outweigh":
						this.ValOutweigh = ViewModelConversion.ToNumeric(_value);
						break;
					case "pesso.lineclr":
						this.ValLineclr = ViewModelConversion.ToString(_value);
						break;
					case "pesso.polyclr":
						this.ValPolyclr = ViewModelConversion.ToString(_value);
						break;
					case "pesso.drawmrk":
						this.ValDrawmrk = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.allowlin":
						this.ValAllowlin = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.allowpol":
						this.ValAllowpol = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.canexpor":
						this.ValCanexpor = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.groupmrk":
						this.ValGroupmrk = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.canedit":
						this.ValCanedit = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.cancut":
						this.ValCancut = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.candrag":
						this.ValCandrag = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.canrot":
						this.ValCanrot = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.canremov":
						this.ValCanremov = ViewModelConversion.ToLogic(_value);
						break;
					case "pesso.terrain":
						this.ValTerrain = ViewModelConversion.ToGeographicShape(_value);
						break;
					case "pesso.codpesso":
						this.ValCodpesso = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Pesso) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Pesso)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Pesso.Find(id ?? Navigation.GetStrValue("pesso"), m_userContext, "FPESSO"); }
			finally { Model ??= new Models.Pesso(m_userContext) { Identifier = "FPESSO" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSO");
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

			Model.Identifier = "FPESSO";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), m_userContext, "FPESSO");
				if (Model == null)
				{
					Model = new Models.Pesso(m_userContext) { Identifier = "FPESSO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Pesso___categcategory(qs, lazyLoad);
			Load_Pesso___pais1country_(qs, lazyLoad);
			Load_Pesso___cmpnydesignat(qs, lazyLoad);
			Load_Pesso___regi1regiao__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PESSO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PESSO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME_23841, ValName, 85);

			validator.Required("ValName", Resources.Resources.NAME_23841, ViewModelConversion.ToString(ValName), FieldType.TEXTO.Formatting);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL_44228, ValEmail, 254);
			validator.StringLength("CntryValCountry", Resources.Resources.COUNTRY64133, CntryValCountry, 90);
			validator.StringLength("ValEmail2", Resources.Resources.ALTERNATIVE_EMAIL17444, ValEmail2, 254);
			validator.StringLength("ValExtquery", Resources.Resources.QUERY_FOR_EXTERNAL_A51761, ValExtquery, 250);
			validator.StringLength("ValMapheigh", Resources.Resources.MAP_HEIGHT06476, ValMapheigh, 50);
			validator.StringLength("ValLineclr", Resources.Resources.POLYLINE_COLOR11664, ValLineclr, 50);
			validator.StringLength("ValPolyclr", Resources.Resources.POLYGON_COLOR32161, ValPolyclr, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PESSO]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSO]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSO]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, m_userContext, "FPESSO");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
			Load_Pesso___pseudespecial_selected_ids();
		}

		/// <summary>
		/// TableCategCategory -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pesso___categcategory(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pesso___categcategoryDoLoad = true;
			CriteriaSet pesso___categcategoryConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("categ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pesso___categcategoryConds.Equal(CSGenioAcateg.FldCodcateg, hValue);
					this.ValCodcateg = DBConversion.ToString(hValue);
				}
			}

			TableCategCategory = new TableDBEdit<Models.Categ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}
				FillDependant_PessoTableCategCategory(lazyLoad);
				return;
			}

			if (pesso___categcategoryDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCategCategory, "sTableCategCategory", "dTableCategCategory", qs, "categ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldCategoria), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcateg.FldAbbreviation), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCategCategory_tableFilters"]))
					TableCategCategory.TableFilters = bool.Parse(qs["TableCategCategory_tableFilters"]);
				else
					TableCategCategory.TableFilters = false;

				query = qs["qTableCategCategory"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcateg.FldCategoria, query + "%");
				}
				pesso___categcategoryConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategCategory"] != null ? qs["pTableCategCategory"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioAcateg.FldAbbreviation, CSGenioAcateg.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_CATEGCATEGORY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("categ", FormMode.New) || Navigation.checkFormMode("categ", FormMode.Duplicate))
					pesso___categcategoryConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcateg.FldZzstate, 0)
						.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetStrValue("categ")));
				else
					pesso___categcategoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcateg.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("categ", "categoria");
				ListingMVC<CSGenioAcateg> listing = Models.ModelBase.Where<CSGenioAcateg>(m_userContext, false, pesso___categcategoryConds, fields, offset, numberItems, sorts, "LED_PESSO___CATEGCATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategCategory.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategCategory.Query = query;
				TableCategCategory.Elements = listing.RowsForViewModel<GenioMVC.Models.Categ>((r) => new GenioMVC.Models.Categ(m_userContext, r, true, _fieldsToSerialize_PESSO___CATEGCATEGORY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}

				TableCategCategory.List = new SelectList(TableCategCategory.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
				FillDependant_PessoTableCategCategory();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategCategory (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Categ</param>
		public ConcurrentDictionary<string, object> GetDependant_PessoTableCategCategory(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria];

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

			CSGenioAcateg tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcateg.FldCodcateg, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCategCategory (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PessoTableCategCategory(bool lazyLoad = false)
		{
			var row = GetDependant_PessoTableCategCategory(this.ValCodcateg);
			try
			{

				// Fill List fields
				this.ValCodcateg = ViewModelConversion.ToString(row["categ.codcateg"]);
				TableCategCategory.Value = (string)row["categ.categoria"];
				if (GlobalFunctions.emptyG(this.ValCodcateg) == 1)
				{
					this.ValCodcateg = "";
					TableCategCategory.Value = "";
					Navigation.ClearValue("categ");
				}
				else if (lazyLoad)
				{
					TableCategCategory.SetPagination(1, 0, false, false, 1);
					TableCategCategory.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcateg),
							Text = Convert.ToString(TableCategCategory.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcateg);
				}

				TableCategCategory.Selected = this.ValCodcateg;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategCategory): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESSO___CATEGCATEGORY = ["Categ", "Categ.ValCodcateg", "Categ.ValZzstate", "Categ.ValCategoria", "Categ.ValAbbreviation"];

		/// <summary>
		/// TablePais1Country -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pesso___pais1country_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pesso___pais1country_DoLoad = true;
			CriteriaSet pesso___pais1country_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pais1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pesso___pais1country_Conds.Equal(CSGenioApais1.FldCodcntry, hValue);
					this.ValCodcntry = DBConversion.ToString(hValue);
				}
			}

			TablePais1Country = new TableDBEdit<Models.Pais1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}
				FillDependant_PessoTablePais1Country(lazyLoad);
				return;
			}

			if (pesso___pais1country_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePais1Country, "sTablePais1Country", "dTablePais1Country", qs, "pais1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApais1.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePais1Country_tableFilters"]))
					TablePais1Country.TableFilters = bool.Parse(qs["TablePais1Country_tableFilters"]);
				else
					TablePais1Country.TableFilters = false;

				query = qs["qTablePais1Country"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApais1.FldCountry, query + "%");
				}
				pesso___pais1country_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePais1Country"] != null ? qs["pTablePais1Country"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApais1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_PAIS1COUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pais1", FormMode.New) || Navigation.checkFormMode("pais1", FormMode.Duplicate))
					pesso___pais1country_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApais1.FldZzstate, 0)
						.Equal(CSGenioApais1.FldCodcntry, Navigation.GetStrValue("pais1")));
				else
					pesso___pais1country_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApais1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pais1", "country");
				ListingMVC<CSGenioApais1> listing = Models.ModelBase.Where<CSGenioApais1>(m_userContext, false, pesso___pais1country_Conds, fields, offset, numberItems, sorts, "LED_PESSO___PAIS1COUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePais1Country.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePais1Country.Query = query;
				TablePais1Country.Elements = listing.RowsForViewModel<GenioMVC.Models.Pais1>((r) => new GenioMVC.Models.Pais1(m_userContext, r, true, _fieldsToSerialize_PESSO___PAIS1COUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}

				TablePais1Country.List = new SelectList(TablePais1Country.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_PessoTablePais1Country();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePais1Country (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pais1</param>
		public ConcurrentDictionary<string, object> GetDependant_PessoTablePais1Country(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry];

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

			CSGenioApais1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApais1.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePais1Country (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PessoTablePais1Country(bool lazyLoad = false)
		{
			var row = GetDependant_PessoTablePais1Country(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["pais1.codcntry"]);
				TablePais1Country.Value = (string)row["pais1.country"];
				if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TablePais1Country.Value = "";
					Navigation.ClearValue("pais1");
				}
				else if (lazyLoad)
				{
					TablePais1Country.SetPagination(1, 0, false, false, 1);
					TablePais1Country.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TablePais1Country.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TablePais1Country.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePais1Country): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESSO___PAIS1COUNTRY_ = ["Pais1", "Pais1.ValCodcntry", "Pais1.ValZzstate", "Pais1.ValCountry"];
		/// <summary>
		/// List_Especial -> (DV)
		/// </summary>
		/// <param name="qs"></param>
		public void Load_Pesso___pseudespecial(NameValueCollection qs)
		{
			bool pesso___pseudespecialDoLoad = true;
			CriteriaSet pesso___pseudespecialConds = CriteriaSet.And();


			this.List_Especial_Area = "Speci";
			this.List_Especial = new List<GenioMVC.Models.Speci>();
			this.List_EspecialSelected = new List<GenioMVC.Models.Speci>();
			
			if (pesso___pseudespecialDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAspeci.FldEspecial), SortOrder.Ascending));



// USE /[MANUAL GQT OVERRQ PESSO_PSEUDESPECIAL]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Speci", FormMode.New)) // TODO: Check in Duplicate mode
					pesso___pseudespecialConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Especial = Models.ModelBase.Where<CSGenioAspeci>(m_userContext, false, args: pesso___pseudespecialConds, numRegs: -1, sorts: sorts).RowsForViewModel<GenioMVC.Models.Speci>((r) => new GenioMVC.Models.Speci(m_userContext, r));
				
				// Get primary keys of selected rows
				Load_Pesso___pseudespecial_selected_ids();
				
				List_EspecialSelected = List_Especial.Where(x => List_Especial_SelectedIds.Contains(x.ValCodespec)).ToList();
			}
		}
		
		/// <summary>
		/// List_Especial_SelectedIds
		/// </summary>
		public void Load_Pesso___pseudespecial_selected_ids()
		{
			if (List_Especial_SelectedIds == null)
				List_Especial_SelectedIds = [];
			
			// Create criteria set
			CriteriaSet pesso___pseudespecial_especial_Conds = CriteriaSet.And();
			pesso___pseudespecial_especial_Conds.Equal(CSGenioAesppe.FldCodpesso, ValCodpesso);

			// Get primary keys of selected rows
			if (List_Especial_SelectedIds.Length == 0)
				List_Especial_SelectedIds = Models.ModelBase.All<CSGenioAesppe>(m_userContext, pesso___pseudespecial_especial_Conds).Rows.Select(x => x.ValCodespec).ToArray();
		}

		/// <summary>
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pesso___cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pesso___cmpnydesignatDoLoad = true;
			CriteriaSet pesso___cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pesso___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, hValue);
					this.ValCodempre = DBConversion.ToString(hValue);
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
				FillDependant_PessoTableCmpnyDesignat(lazyLoad);
				return;
			}

			if (pesso___cmpnydesignatDoLoad)
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
				pesso___cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					pesso___cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					pesso___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, pesso___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESSO___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_PESSO___CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_PessoTableCmpnyDesignat();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_PessoTableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldHeadloc, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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
		public void FillDependant_PessoTableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_PessoTableCmpnyDesignat(this.ValCodempre);
			try
			{
				this.funcCmpnyValHeadloc = () => (string)row["cmpny.headloc"];
				this.ValCodpaise = (string)row["cntry.codcntry"];
				this.funcCntryValCountry = () => (string)row["cntry.country"];

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

		private readonly string[] _fieldsToSerialize_PESSO___CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		/// <summary>
		/// TableRegi1Regiao -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Pesso___regi1regiao__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool pesso___regi1regiao__DoLoad = true;
			CriteriaSet pesso___regi1regiao__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("regi1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					pesso___regi1regiao__Conds.Equal(CSGenioAregi1.FldCodregia, hValue);
					this.ValCodregia = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// History limit
			pesso___regi1regiao__DoLoad &= AddCriteriaHistoryLimit(pesso___regi1regiao__Conds, CSGenio.business.CSGenioAregi1.FldCodcntry, OperationType.EQUAL, "pais", true);

			// Area limit
			pesso___regi1regiao__DoLoad &= AddCriteriaAreaLimit(pesso___regi1regiao__Conds, CSGenio.business.CSGenioApais1.FldCodcntry, "pais1", this.ValCodcntry, true);

			TableRegi1Regiao = new TableDBEdit<Models.Regi1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}
				FillDependant_PessoTableRegi1Regiao(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				pesso___regi1regiao__DoLoad = false;

			if (pesso___regi1regiao__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRegi1Regiao, "sTableRegi1Regiao", "dTableRegi1Regiao", qs, "regi1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregi1.FldRegiao), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRegi1Regiao_tableFilters"]))
					TableRegi1Regiao.TableFilters = bool.Parse(qs["TableRegi1Regiao_tableFilters"]);
				else
					TableRegi1Regiao.TableFilters = false;

				query = qs["qTableRegi1Regiao"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAregi1.FldRegiao, query + "%");
				}
				pesso___regi1regiao__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRegi1Regiao"] != null ? qs["pTableRegi1Regiao"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao, CSGenioAregi1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_REGI1REGIAO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("regi1", FormMode.New) || Navigation.checkFormMode("regi1", FormMode.Duplicate))
					pesso___regi1regiao__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAregi1.FldZzstate, 0)
						.Equal(CSGenioAregi1.FldCodregia, Navigation.GetStrValue("regi1")));
				else
					pesso___regi1regiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregi1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("regi1", "regiao");
				ListingMVC<CSGenioAregi1> listing = Models.ModelBase.Where<CSGenioAregi1>(m_userContext, false, pesso___regi1regiao__Conds, fields, offset, numberItems, sorts, "LED_PESSO___REGI1REGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRegi1Regiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRegi1Regiao.Query = query;
				TableRegi1Regiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regi1>((r) => new GenioMVC.Models.Regi1(m_userContext, r, true, _fieldsToSerialize_PESSO___REGI1REGIAO__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}

				TableRegi1Regiao.List = new SelectList(TableRegi1Regiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
				FillDependant_PessoTableRegi1Regiao();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRegi1Regiao (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Regi1</param>
		public ConcurrentDictionary<string, object> GetDependant_PessoTableRegi1Regiao(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("pais1");
				if (!(hValue is Array))
				{
					if (GlobalFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAregi1.FldCodcntry, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAregi1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAregi1.FldCodregia, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRegi1Regiao (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_PessoTableRegi1Regiao(bool lazyLoad = false)
		{
			var row = GetDependant_PessoTableRegi1Regiao(this.ValCodregia);
			try
			{

				// Fill List fields
				this.ValCodregia = ViewModelConversion.ToString(row["regi1.codregia"]);
				TableRegi1Regiao.Value = (string)row["regi1.regiao"];
				if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
				{
					this.ValCodregia = "";
					TableRegi1Regiao.Value = "";
					Navigation.ClearValue("regi1");
				}
				else if (lazyLoad)
				{
					TableRegi1Regiao.SetPagination(1, 0, false, false, 1);
					TableRegi1Regiao.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodregia),
							Text = Convert.ToString(TableRegi1Regiao.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodregia);
				}

				TableRegi1Regiao.Selected = this.ValCodregia;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegi1Regiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PESSO___REGI1REGIAO__ = ["Regi1", "Regi1.ValCodregia", "Regi1.ValZzstate", "Regi1.ValRegiao"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"pesso.codcateg" => ViewModelConversion.ToString(modelValue),
				"pesso.codempre" => ViewModelConversion.ToString(modelValue),
				"pesso.codpaise" => ViewModelConversion.ToString(modelValue),
				"pesso.codcntry" => ViewModelConversion.ToString(modelValue),
				"pesso.codregia" => ViewModelConversion.ToString(modelValue),
				"pesso.photogra" => ViewModelConversion.ToImage(modelValue),
				"pesso.idfuncio" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"pesso.gender" => ViewModelConversion.ToString(modelValue),
				"pesso.dtnascim" => ViewModelConversion.ToDateTime(modelValue),
				"pesso.idade" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.interna" => ViewModelConversion.ToLogic(modelValue),
				"pesso.externa" => ViewModelConversion.ToLogic(modelValue),
				"pesso.dtultcat" => ViewModelConversion.ToDateTime(modelValue),
				"pesso.telephon" => ViewModelConversion.ToString(modelValue),
				"pesso.email" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"pesso.email2" => ViewModelConversion.ToString(modelValue),
				"pesso.extquery" => ViewModelConversion.ToString(modelValue),
				"pesso.zoomlvl" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.extminzm" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.mapheigh" => ViewModelConversion.ToString(modelValue),
				"pesso.outweigh" => ViewModelConversion.ToNumeric(modelValue),
				"pesso.lineclr" => ViewModelConversion.ToString(modelValue),
				"pesso.polyclr" => ViewModelConversion.ToString(modelValue),
				"pesso.drawmrk" => ViewModelConversion.ToLogic(modelValue),
				"pesso.allowlin" => ViewModelConversion.ToLogic(modelValue),
				"pesso.allowpol" => ViewModelConversion.ToLogic(modelValue),
				"pesso.canexpor" => ViewModelConversion.ToLogic(modelValue),
				"pesso.groupmrk" => ViewModelConversion.ToLogic(modelValue),
				"pesso.canedit" => ViewModelConversion.ToLogic(modelValue),
				"pesso.cancut" => ViewModelConversion.ToLogic(modelValue),
				"pesso.candrag" => ViewModelConversion.ToLogic(modelValue),
				"pesso.canrot" => ViewModelConversion.ToLogic(modelValue),
				"pesso.canremov" => ViewModelConversion.ToLogic(modelValue),
				"pesso.terrain" => ViewModelConversion.ToGeographicShape(modelValue),
				"cmpny.headloc" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"categ.codcateg" => ViewModelConversion.ToString(modelValue),
				"categ.categoria" => ViewModelConversion.ToString(modelValue),
				"pais1.codcntry" => ViewModelConversion.ToString(modelValue),
				"pais1.country" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"regi1.codregia" => ViewModelConversion.ToString(modelValue),
				"regi1.regiao" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhotogra != null)
				ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPESSO, CSGenioApesso.FldPhotogra.Field, null, ValCodpesso);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSO]/

		#endregion
	}
}
