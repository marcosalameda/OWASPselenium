using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Pesso
{
	public class Pesso_ViewModel : FormViewModel<Models.Pesso>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Employee No." Tipo:"N"</summary>
		[Display(Name = "EMPLOYEE_NO_01176", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get; set; }

		/// <summary>Campo : "Name:" Tipo:"C"</summary>
		[Display(Name = "NAME_23841", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Gender" Tipo:"AC"</summary>
		[Display(Name = "GENDER44172", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get; set; }
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }

		/// <summary>Campo : "Birth" Tipo:"D"</summary>
		[Display(Name = "BIRTH21799", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get; set; }

		/// <summary>Campo : "Age" Tipo:"N"</summary>
		[Display(Name = "AGE28663", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIdade { get; set; }

		/// <summary>Campo : "Intern" Tipo:"L"</summary>
		[Display(Name = "INTERN65375", ResourceType = typeof(Resources.Resources))]
		public bool ValInterna { get; set; }

		/// <summary>Campo : "External" Tipo:"L"</summary>
		[Display(Name = "EXTERNAL13375", ResourceType = typeof(Resources.Resources))]
		public bool ValExterna { get; set; }

		/// <summary>Campo : "Category" Tipo:"C"</summary>
		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Categ>  TableCategCategory { get; set; }

		/// <summary>Campo : "Since" Tipo:"D"</summary>
		[Display(Name = "SINCE47259", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pais1>  TablePais1Country { get; set; }

		/// <summary>Campo : "Specialties" Tipo:"DV"</summary>
		[Display(Name = "SPECIALTIES08113", ResourceType = typeof(Resources.Resources))]
		public List<GenioMVC.Models.Speci> List_Especial { get; set; }
		public List<GenioMVC.Models.Speci> List_EspecialSelected { get; set; }
		public string[] List_Especial_SelectedIds { get; set; }
		public string List_Especial_Area { get; set; }

		/// <summary>Campo : "Specialties" Tipo:"DP"</summary>
		[Display(Name = "SPECIALTIES08113", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Esppe> ValEspecitl { get; set; }

		/// <summary>Campo : "Telephone" Tipo:"C"</summary>
		[Display(Name = "TELEPHONE28697", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTelephon { get; set; }

		/// <summary>Campo : "Email:" Tipo:"C"</summary>
		[Display(Name = "EMAIL_44228", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "" Tipo:"DP"</summary>
		public TablePartial<GenioMVC.Models.Conta> ValContacto { get; set; }

		/// <summary>Campo : "Company" Tipo:"C"</summary>
		[Display(Name = "COMPANY52963", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cmpny>  TableCmpnyDesignat { get; set; }

		/// <summary>Campo : "Country" Tipo:"C"</summary>
		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(90, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string CntryValCountry { get { return funcCntryValCountry != null ? funcCntryValCountry() : _auxCntryValCountry; } set { funcCntryValCountry = () => value; } }
		[JsonIgnore]
		public Func<string> funcCntryValCountry { get; set; }
		private string _auxCntryValCountry { get; set; }

		/// <summary>Campo : "Region of the person:" Tipo:"C"</summary>
		[Display(Name = "REGION_OF_THE_PERSON14756", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Regi1>  TableRegi1Regiao { get; set; }

		/// <summary>Campo : "" Tipo:"DP"</summary>
		public TablePartial<GenioMVC.Models.Evcat> ValEvolucao { get; set; }

		/// <summary>Campo : "Alternative Email" Tipo:"C"</summary>
		[Display(Name = "ALTERNATIVE_EMAIL17444", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail2 { get; set; }

		/// <summary>Campo : "Query for external API" Tipo:"C"</summary>
		[Display(Name = "QUERY_FOR_EXTERNAL_A51761", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(250, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValExtquery { get; set; }

		/// <summary>Campo : "Zoom level" Tipo:"N"</summary>
		[Display(Name = "ZOOM_LEVEL17268", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValZoomlvl { get; set; }

		/// <summary>Campo : "Minimum zoom to load features" Tipo:"N"</summary>
		[Display(Name = "MINIMUM_ZOOM_TO_LOAD08509", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValExtminzm { get; set; }

		/// <summary>Campo : "Map height" Tipo:"C"</summary>
		[Display(Name = "MAP_HEIGHT06476", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValMapheigh { get; set; }

		/// <summary>Campo : "Outline weight" Tipo:"N"</summary>
		[Display(Name = "OUTLINE_WEIGHT25236", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValOutweigh { get; set; }

		/// <summary>Campo : "Polyline color" Tipo:"C"</summary>
		[Display(Name = "POLYLINE_COLOR11664", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValLineclr { get; set; }

		/// <summary>Campo : "Polygon color" Tipo:"C"</summary>
		[Display(Name = "POLYGON_COLOR32161", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValPolyclr { get; set; }

		/// <summary>Campo : "Allow drawing markers" Tipo:"L"</summary>
		[Display(Name = "ALLOW_DRAWING_MARKER56732", ResourceType = typeof(Resources.Resources))]
		public bool ValDrawmrk { get; set; }

		/// <summary>Campo : "Allow drawing polylines" Tipo:"L"</summary>
		[Display(Name = "ALLOW_DRAWING_POLYLI25703", ResourceType = typeof(Resources.Resources))]
		public bool ValAllowlin { get; set; }

		/// <summary>Campo : "Allow drawing polygons" Tipo:"L"</summary>
		[Display(Name = "ALLOW_DRAWING_POLYGO46480", ResourceType = typeof(Resources.Resources))]
		public bool ValAllowpol { get; set; }

		/// <summary>Campo : "Allow exporting map" Tipo:"L"</summary>
		[Display(Name = "ALLOW_EXPORTING_MAP27916", ResourceType = typeof(Resources.Resources))]
		public bool ValCanexpor { get; set; }

		/// <summary>Campo : "Group markers in cluster" Tipo:"L"</summary>
		[Display(Name = "GROUP_MARKERS_IN_CLU31341", ResourceType = typeof(Resources.Resources))]
		public bool ValGroupmrk { get; set; }

		/// <summary>Campo : "Allow feature editing" Tipo:"L"</summary>
		[Display(Name = "ALLOW_FEATURE_EDITIN16439", ResourceType = typeof(Resources.Resources))]
		public bool ValCanedit { get; set; }

		/// <summary>Campo : "Allow feature cutting" Tipo:"L"</summary>
		[Display(Name = "ALLOW_FEATURE_CUTTIN10746", ResourceType = typeof(Resources.Resources))]
		public bool ValCancut { get; set; }

		/// <summary>Campo : "Allow feature dragging" Tipo:"L"</summary>
		[Display(Name = "ALLOW_FEATURE_DRAGGI09054", ResourceType = typeof(Resources.Resources))]
		public bool ValCandrag { get; set; }

		/// <summary>Campo : "Allow feature rotation" Tipo:"L"</summary>
		[Display(Name = "ALLOW_FEATURE_ROTATI56653", ResourceType = typeof(Resources.Resources))]
		public bool ValCanrot { get; set; }

		/// <summary>Campo : "Allow feature removal" Tipo:"L"</summary>
		[Display(Name = "ALLOW_FEATURE_REMOVA13844", ResourceType = typeof(Resources.Resources))]
		public bool ValCanremov { get; set; }

		/// <summary>Campo : "Terrain" Tipo:"GS"</summary>
		[Display(Name = "TERRAIN43857", ResourceType = typeof(Resources.Resources))]
		[UIHint("GoogleMaps")]
		public CSGenio.framework.Geography.GeographicData ValTerrain { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COMPANY52963", ResourceType = typeof(Resources.Resources))]
		public string ValCodempre { get; set; }

		public string ValCodpaise { get; set; }

		[Display(Name = "COUNTRY64133", ResourceType = typeof(Resources.Resources))]
		public string ValCodcntry { get; set; }

		[Display(Name = "REGION_OF_THE_PERSON14756", ResourceType = typeof(Resources.Resources))]
		public string ValCodregia { get; set; }

		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		public string ValCodcateg { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Used only for lazy loading of the CmpnyValHeadloc field</summary>
		[Newtonsoft.Json.JsonIgnore]
		public Func<string> funcCmpnyValHeadloc { get; set; }
		private string _auxCmpnyValHeadloc { get; set; }
		/// <summary>Field : "Headquarter location" Tipo: "GG"</summary>
		public string CmpnyValHeadloc { get { return funcCmpnyValHeadloc != null ? funcCmpnyValHeadloc() : _auxCmpnyValHeadloc; } set { funcCmpnyValHeadloc = () => value;} }
		#endregion

		public string ValCodpesso { get; set; }

		public Pesso_ViewModel() : base("FPESSO") { }

		public Pesso_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSO", currentNavigation, nestedForm) { }

		public Pesso_ViewModel(Models.Pesso row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPESSO", row, currentNavigation, nestedForm) { }

		public Pesso_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pesso", id);
			Model = Models.Pesso.Find(id, "FPESSO", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Pesso model = new Models.Pesso() { Identifier = "FPESSO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Pesso model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			return DeleteConditions(Model);
		}

		public static StatusMessage DeleteConditions(Models.Pesso model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			return ViewConditions(Model);
		}

		public static StatusMessage ViewConditions(Models.Pesso model)
		{
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
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
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
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCodpaise = ViewModelConversion.ToString(m.ValCodpaise);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
 				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
 				ValCodcateg = ViewModelConversion.ToString(m.ValCodcateg);
 				funcCmpnyValHeadloc = () => ViewModelConversion.ToString(m.Cmpny.ValHeadloc);
 				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pesso) to ViewModel (Pesso) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pesso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesso) to Model (Pesso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValIdfuncio = ViewModelConversion.ToNumeric(ValIdfuncio);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValDtnascim = ViewModelConversion.ToDateTime(ValDtnascim);
				m.ValIdade = ViewModelConversion.ToNumeric(ValIdade);
				m.ValInterna = ViewModelConversion.ToLogic(ValInterna);
				m.ValExterna = ViewModelConversion.ToLogic(ValExterna);
				m.ValDtultcat = ViewModelConversion.ToDateTime(ValDtultcat);
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
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpaise = ViewModelConversion.ToString(ValCodpaise);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodcateg = ViewModelConversion.ToString(ValCodcateg);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pesso) to Model (Pesso) - Error during mapping");
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
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pesso() { Identifier = "FPESSO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
					}

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FPESSO";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}
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
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO");
				if (Model == null)
				{
					Model = new Models.Pesso() { Identifier = "FPESSO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

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

// USE /[MANUAL GQT VIEWMODEL_SAVE PESSO]/
		public override void Save()
		{

			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PESSO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pesso.Find(Navigation.GetStrValue("pesso"), "FPESSO"); }
			finally { if (Model == null) Model = new Models.Pesso() { Identifier = "FPESSO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PESSO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PESSO]/
		public override void Destroy(string id)
		{
			Model = Models.Pesso.Find(id, "FPESSO");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValGender = new SelectList(
				ArrayGenero.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValGender);
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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso___categcategoryConds.Equal(CSGenioAcateg.FldCodcateg, Navigation.GetValue("categ"));
                    this.ValCodcateg = Navigation.GetStrValue("categ");
                }
            }



            TableCategCategory = new TableDBEdit<Models.Categ>();
            TableCategCategory.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
                    this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}
                FillDependant_PessoTableCategCategory(lazyLoad);
                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
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
                if (!String.IsNullOrEmpty(qs["TableCategCategory_tableFilters"]))
                    TableCategCategory.TableFilters = bool.Parse(qs["TableCategCategory_tableFilters"]);
                else
                    TableCategCategory.TableFilters = false;

                query = qs["qTableCategCategory"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcateg.FldCategoria, query + "%");
                }
                pesso___categcategoryConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCategCategory"] != null ? qs["pTableCategCategory"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioAcateg.FldAbbreviation, CSGenioAcateg.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_CATEGCATEGORY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("categ", FormMode.New) || Navigation.checkFormMode("categ", FormMode.Duplicate))
                    pesso___categcategoryConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcateg.FldZzstate, 0)
                        .Equal(CSGenioAcateg.FldCodcateg, Navigation.GetStrValue("categ")));
                else
                    pesso___categcategoryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcateg.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso___categcategoryConds = Categ.AddEPH<CSGenioAcateg>(ref UserContext.Current.User, pesso___categcategoryConds, "LED_PESSO___CATEGCATEGORY");

                FieldRef firstVisibleColumn = new FieldRef("categ", "categoria");
                ListingMVC<CSGenioAcateg> listing = Models.ModelBase.Where<CSGenioAcateg>(false, pesso___categcategoryConds, fields, offset, numberItems, sorts, "LED_PESSO___CATEGCATEGORY", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCategCategory.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCategCategory.Query = query;
                TableCategCategory.Elements = listing.RowsForViewModel<GenioMVC.Models.Categ>((r) => new GenioMVC.Models.Categ(r, true, _fieldsToSerialize_PESSO___CATEGCATEGORY));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_categ") != null)
				{
					this.ValCodcateg = Navigation.GetStrValue("RETURN_categ");
					Navigation.CurrentLevel.SetEntry("RETURN_categ", null);
				}

				TableCategCategory.List = new SelectList(TableCategCategory.Elements.ToSelectList(x => x.ValCategoria, x => x.ValCodcateg,  x => x.ValCodcateg == this.ValCodcateg), "Value", "Text", this.ValCodcateg);
                FillDependant_PessoTableCategCategory();

                //Check if foreignkey comes from history
                TableCategCategory.FilledByHistory = Navigation.CheckFilledByHistory("categ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCategCategory (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Categ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PessoTableCategCategory(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "categ.codcateg", "categ.categoria" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAcateg tempArea = new CSGenioAcateg(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcateg.FldCodcateg, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableCategCategory (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PessoTableCategCategory(bool lazyLoad = false)
        {
            var row = GetDependant_PessoTableCategCategory(this.ValCodcateg, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcateg = ViewModelConversion.ToString(row["categ.codcateg"]);
                TableCategCategory.Value = ViewModelConversion.ToString(row["categ.categoria"]);
                if (GlobalFunctions.emptyG(this.ValCodcateg) == 1)
                {
                    this.ValCodcateg = "";
                    TableCategCategory.Value = "";
                    Navigation.ClearValue("categ");
                }
                else if (lazyLoad)
                {
                    TableCategCategory.SetPagination(1, 0, false, false, 1);
                    TableCategCategory.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodcateg),
                            Text = Convert.ToString(TableCategCategory.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodcateg);
                }
                TableCategCategory.Selected = this.ValCodcateg;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategCategory): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO___CATEGCATEGORY = { "Categ", "Categ.ValCodcateg", "Categ.ValZzstate", "Categ.ValCategoria", "Categ.ValAbbreviation" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso___pais1country_Conds.Equal(CSGenioApais1.FldCodcntry, Navigation.GetValue("pais1"));
                    this.ValCodcntry = Navigation.GetStrValue("pais1");
                }
            }



            TablePais1Country = new TableDBEdit<Models.Pais1>();
            TablePais1Country.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
                    this.ValCodcntry = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}
                FillDependant_PessoTablePais1Country(lazyLoad);
                //Check if foreignkey comes from history
                TablePais1Country.FilledByHistory = Navigation.CheckFilledByHistory("pais1");
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
                if (!String.IsNullOrEmpty(qs["TablePais1Country_tableFilters"]))
                    TablePais1Country.TableFilters = bool.Parse(qs["TablePais1Country_tableFilters"]);
                else
                    TablePais1Country.TableFilters = false;

                query = qs["qTablePais1Country"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApais1.FldCountry, query + "%");
                }
                pesso___pais1country_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTablePais1Country"] != null ? qs["pTablePais1Country"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApais1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_PAIS1COUNTRY]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pais1", FormMode.New) || Navigation.checkFormMode("pais1", FormMode.Duplicate))
                    pesso___pais1country_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApais1.FldZzstate, 0)
                        .Equal(CSGenioApais1.FldCodcntry, Navigation.GetStrValue("pais1")));
                else
                    pesso___pais1country_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApais1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso___pais1country_Conds = Pais1.AddEPH<CSGenioApais1>(ref UserContext.Current.User, pesso___pais1country_Conds, "LED_PESSO___PAIS1COUNTRY_");

                FieldRef firstVisibleColumn = new FieldRef("pais1", "country");
                ListingMVC<CSGenioApais1> listing = Models.ModelBase.Where<CSGenioApais1>(false, pesso___pais1country_Conds, fields, offset, numberItems, sorts, "LED_PESSO___PAIS1COUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePais1Country.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePais1Country.Query = query;
                TablePais1Country.Elements = listing.RowsForViewModel<GenioMVC.Models.Pais1>((r) => new GenioMVC.Models.Pais1(r, true, _fieldsToSerialize_PESSO___PAIS1COUNTRY_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pais1") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_pais1");
					Navigation.CurrentLevel.SetEntry("RETURN_pais1", null);
				}

				TablePais1Country.List = new SelectList(TablePais1Country.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
                FillDependant_PessoTablePais1Country();

                //Check if foreignkey comes from history
                TablePais1Country.FilledByHistory = Navigation.CheckFilledByHistory("pais1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePais1Country (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pais1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PessoTablePais1Country(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pais1.codcntry", "pais1.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioApais1 tempArea = new CSGenioApais1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApais1.FldCodcntry, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TablePais1Country (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PessoTablePais1Country(bool lazyLoad = false)
        {
            var row = GetDependant_PessoTablePais1Country(this.ValCodcntry, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodcntry = ViewModelConversion.ToString(row["pais1.codcntry"]);
                TablePais1Country.Value = ViewModelConversion.ToString(row["pais1.country"]);
                if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
                {
                    this.ValCodcntry = "";
                    TablePais1Country.Value = "";
                    Navigation.ClearValue("pais1");
                }
                else if (lazyLoad)
                {
                    TablePais1Country.SetPagination(1, 0, false, false, 1);
                    TablePais1Country.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodcntry),
                            Text = Convert.ToString(TablePais1Country.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodcntry);
                }
                TablePais1Country.Selected = this.ValCodcntry;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePais1Country): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO___PAIS1COUNTRY_ = { "Pais1", "Pais1.ValCodcntry", "Pais1.ValZzstate", "Pais1.ValCountry" };
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
			if (List_Especial_SelectedIds == null)
				List_Especial_SelectedIds = new string[0];

			if (pesso___pseudespecialDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAspeci.FldEspecial), SortOrder.Ascending));


				CriteriaSet pesso___pseudespecial_especial_Conds = CriteriaSet.And();
				pesso___pseudespecial_especial_Conds.Equal(CSGenioAesppe.FldCodpesso, ValCodpesso);

// USE /[MANUAL GQT OVERRQ PESSO_PSEUDESPECIAL]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Speci", FormMode.New)) // TODO: Check in Duplicate mode
					pesso___pseudespecialConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Especial = Models.ModelBase.Where<CSGenioAspeci>(false, args: pesso___pseudespecialConds, numRegs: -1, sorts: sorts, fields: new FieldRef[]
					{
						CSGenio.business.CSGenioAspeci.FldCodespec,
						CSGenio.business.CSGenioAspeci.FldEspecial,
						CSGenio.business.CSGenioAspeci.FldAreatecn,
					}).RowsForViewModel<GenioMVC.Models.Speci>((r) => new GenioMVC.Models.Speci(r));

				if (List_Especial_SelectedIds.Length == 0)
					List_Especial_SelectedIds = Models.ModelBase.All<CSGenioAesppe>(pesso___pseudespecial_especial_Conds).Rows.Select(x => x.ValCodespec).ToArray();
				List_EspecialSelected = List_Especial.Where(x => List_Especial_SelectedIds.Contains(x.ValCodespec)).ToList();
			}
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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
                    this.ValCodempre = Navigation.GetStrValue("cmpny");
                }
            }



            TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>();
            TableCmpnyDesignat.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
                    this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
                FillDependant_PessoTableCmpnyDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
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
                if (!String.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
                    TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
                else
                    TableCmpnyDesignat.TableFilters = false;

                query = qs["qTableCmpnyDesignat"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
                }
                pesso___cmpnydesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_CMPNYDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
                    pesso___cmpnydesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcmpny.FldZzstate, 0)
                        .Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
                else
                    pesso___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso___cmpnydesignatConds = Cmpny.AddEPH<CSGenioAcmpny>(ref UserContext.Current.User, pesso___cmpnydesignatConds, "LED_PESSO___CMPNYDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
                ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, pesso___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_PESSO___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCmpnyDesignat.Query = query;
                TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(r, true, _fieldsToSerialize_PESSO___CMPNYDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
                FillDependant_PessoTableCmpnyDesignat();

                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cmpny</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PessoTableCmpnyDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cmpny.codempre", "cmpny.designat", "cmpny.headloc", "cntry.codcntry", "cntry.country" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldHeadloc, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAcmpny tempArea = new CSGenioAcmpny(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PessoTableCmpnyDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_PessoTableCmpnyDesignat(this.ValCodempre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["cmpny.headloc"]);
                    this.funcCmpnyValHeadloc = () => tempValue;
                }
                this.ValCodpaise = ViewModelConversion.ToString(row["cntry.codcntry"]);
                {
                    var tempValue = ViewModelConversion.ToString(row["cntry.country"]);
                    this.funcCntryValCountry = () => tempValue;
                }

                // Fill List fields
                this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
                TableCmpnyDesignat.Value = ViewModelConversion.ToString(row["cmpny.designat"]);
                if (GlobalFunctions.emptyG(this.ValCodempre) == 1)
                {
                    this.ValCodempre = "";
                    TableCmpnyDesignat.Value = "";
                    Navigation.ClearValue("cmpny");
                }
                else if (lazyLoad)
                {
                    TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
                    TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodempre),
                            Text = Convert.ToString(TableCmpnyDesignat.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodempre);
                }
                TableCmpnyDesignat.Selected = this.ValCodempre;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO___CMPNYDESIGNAT = { "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat" };

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
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    pesso___regi1regiao__Conds.Equal(CSGenioAregi1.FldCodregia, Navigation.GetValue("regi1"));
                    this.ValCodregia = Navigation.GetStrValue("regi1");
                }
            }

			// Limits Generation

			// History limit
			pesso___regi1regiao__DoLoad &= AddCriteriaHistoryLimit(pesso___regi1regiao__Conds, CSGenio.business.CSGenioAregi1.FldCodcntry, OperationType.EQUAL, "pais", true);

			// Area limit
			pesso___regi1regiao__DoLoad &= AddCriteriaAreaLimit(pesso___regi1regiao__Conds, CSGenio.business.CSGenioApais1.FldCodcntry, "pais1", this.ValCodcntry, true);


            TableRegi1Regiao = new TableDBEdit<Models.Regi1>();
            TableRegi1Regiao.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
                    this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}
                FillDependant_PessoTableRegi1Regiao(lazyLoad);
                //Check if foreignkey comes from history
                TableRegi1Regiao.FilledByHistory = Navigation.CheckFilledByHistory("regi1");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodcntry))
                pesso___regi1regiao__DoLoad = false;

            if (pesso___regi1regiao__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRegi1Regiao, "sTableRegi1Regiao", "dTableRegi1Regiao", qs, "regi1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregi1.FldRegiao), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRegi1Regiao_tableFilters"]))
                    TableRegi1Regiao.TableFilters = bool.Parse(qs["TableRegi1Regiao_tableFilters"]);
                else
                    TableRegi1Regiao.TableFilters = false;

                query = qs["qTableRegi1Regiao"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAregi1.FldRegiao, query + "%");
                }
                pesso___regi1regiao__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRegi1Regiao"] != null ? qs["pTableRegi1Regiao"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao, CSGenioAregi1.FldZzstate };

// USE /[MANUAL GQT OVERRQ PESSO_REGI1REGIAO]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("regi1", FormMode.New) || Navigation.checkFormMode("regi1", FormMode.Duplicate))
                    pesso___regi1regiao__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAregi1.FldZzstate, 0)
                        .Equal(CSGenioAregi1.FldCodregia, Navigation.GetStrValue("regi1")));
                else
                    pesso___regi1regiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregi1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //pesso___regi1regiao__Conds = Regi1.AddEPH<CSGenioAregi1>(ref UserContext.Current.User, pesso___regi1regiao__Conds, "LED_PESSO___REGI1REGIAO__");

                FieldRef firstVisibleColumn = new FieldRef("regi1", "regiao");
                ListingMVC<CSGenioAregi1> listing = Models.ModelBase.Where<CSGenioAregi1>(false, pesso___regi1regiao__Conds, fields, offset, numberItems, sorts, "LED_PESSO___REGI1REGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRegi1Regiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRegi1Regiao.Query = query;
                TableRegi1Regiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regi1>((r) => new GenioMVC.Models.Regi1(r, true, _fieldsToSerialize_PESSO___REGI1REGIAO__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_regi1") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regi1");
					Navigation.CurrentLevel.SetEntry("RETURN_regi1", null);
				}

				TableRegi1Regiao.List = new SelectList(TableRegi1Regiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
                FillDependant_PessoTableRegi1Regiao();

                //Check if foreignkey comes from history
                TableRegi1Regiao.FilledByHistory = Navigation.CheckFilledByHistory("regi1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRegi1Regiao (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Regi1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_PessoTableRegi1Regiao(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "regi1.codregia", "regi1.regiao" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAregi1.FldCodregia, CSGenioAregi1.FldRegiao };
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
                    else
                        wherecodition.Equal(CSGenioAregi1.FldCodcntry, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAregi1 tempArea = new CSGenioAregi1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAregi1.FldCodregia, PKey));
            QueryUtils.SetInnerJoins(DependantFields, null, tempArea, querySelect);

            ArrayList values = sp.executeReaderOneRow(querySelect);

            // Convert data to internal format
            ConcurrentDictionary<string, object> res = new ConcurrentDictionary<string, object>();
            for(int index = 0; index < DependantFields.Length; index ++)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(refDependantFields[index]);
                if (values.Count == 0)
                    res.TryAdd(DependantFields[index], campoBD.GetValorEmpty());
                else
                    res.TryAdd(DependantFields[index], DBConversion.ToInternal(values[index], campoBD.FieldFormat));
            }

            return res;
        }

        /// <summary>
        /// Fill Dependant fields values -> TableRegi1Regiao (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_PessoTableRegi1Regiao(bool lazyLoad = false)
        {
            var row = GetDependant_PessoTableRegi1Regiao(this.ValCodregia, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodregia = ViewModelConversion.ToString(row["regi1.codregia"]);
                TableRegi1Regiao.Value = ViewModelConversion.ToString(row["regi1.regiao"]);
                if (GlobalFunctions.emptyG(this.ValCodregia) == 1)
                {
                    this.ValCodregia = "";
                    TableRegi1Regiao.Value = "";
                    Navigation.ClearValue("regi1");
                }
                else if (lazyLoad)
                {
                    TableRegi1Regiao.SetPagination(1, 0, false, false, 1);
                    TableRegi1Regiao.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodregia),
                            Text = Convert.ToString(TableRegi1Regiao.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodregia);
                }
                TableRegi1Regiao.Selected = this.ValCodregia;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegi1Regiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_PESSO___REGI1REGIAO__ = { "Regi1", "Regi1.ValCodregia", "Regi1.ValZzstate", "Regi1.ValRegiao" };



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSO]/
		#endregion
	}
}
