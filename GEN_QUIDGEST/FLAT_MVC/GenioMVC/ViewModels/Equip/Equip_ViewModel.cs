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

namespace GenioMVC.ViewModels.Equip
{
	public class Equip_ViewModel : FormViewModel<Models.Equip>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Company:" Tipo:"C"</summary>
		[Display(Name = "COMPANY_22615", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Cmpny>  TableCmpnyDesignat { get; set; }

		/// <summary>Campo : "Person" Tipo:"C"</summary>
		[Display(Name = "PERSON10446", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Pess1>  TablePess1Name { get; set; }

		/// <summary>Campo : "Sequential No." Tipo:"N"</summary>
		[Display(Name = "SEQUENTIAL_NO_04803", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValSequennr { get; set; }

		/// <summary>Campo : "Registration No." Tipo:"C"</summary>
		[Display(Name = "REGISTRATION_NO_06209", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(6, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRegistnr { get; set; }

		/// <summary>Campo : "Type of equipment" Tipo:"C"</summary>
		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Tpequ>  TableTpequTipoequi { get; set; }

		/// <summary>Campo : "Manufacturer's website:" Tipo:"C"</summary>
		[Display(Name = "MANUFACTURER_S_WEBSI12156", ResourceType = typeof(Resources.Resources))]
		[RegularExpression(@"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\/\?\.\:\;\'\,]*)?$",ErrorMessageResourceName = "ENDERECO_INVALIDO_40706", ErrorMessageResourceType = typeof(Resources.Resources))]
		[HyperLink]
		[AllowHtml]
		[StringLength(256, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValSitefabr { get; set; }

		/// <summary>Campo : "Warehouse" Tipo:"C"</summary>
		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Wareh>  TableWarehWarehdes { get; set; }

		/// <summary>Campo : "Item:" Tipo:"C"</summary>
		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Item>  TableItemItemdes { get; set; }

		/// <summary>Campo : "Designation:" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION_35800", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Loan Frequency" Tipo:"AN"</summary>
		[Display(Name = "LOAN_FREQUENCY00930", ResourceType = typeof(Resources.Resources))]
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValFrequenc { get; set; }
		[JsonIgnore]
		public SelectList List_ValFrequenc { get; set; }

		/// <summary>Campo : "Total Value:" Tipo:"$D"</summary>
		[Display(Name = "TOTAL_VALUE_07456", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValortot { get; set; }

		/// <summary>Campo : "Acquisition:" Tipo:"D"</summary>
		[Display(Name = "ACQUISITION_53832", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtaquisi { get; set; }

		/// <summary>Campo : "Decomission:" Tipo:"D"</summary>
		[Display(Name = "DECOMISSION_04392", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("D")]
		public DateTime? ValDtdeco { get; set; }

		/// <summary>Campo : "bought" Tipo:"L"</summary>
		[Display(Name = "BOUGHT35496", ResourceType = typeof(Resources.Resources))]
		public bool ValBought { get; set; }

		/// <summary>Campo : "Room No:" Tipo:"C"</summary>
		[Display(Name = "ROOM_NO_15796", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Room1>  TableRoom1Roomnr { get; set; }

		/// <summary>Campo : "Room Designation:" Tipo:"C"</summary>
		[Display(Name = "ROOM_DESIGNATION_33759", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string Room1ValDesignat { get { return funcRoom1ValDesignat != null ? funcRoom1ValDesignat() : _auxRoom1ValDesignat; } set { funcRoom1ValDesignat = () => value; } }
		[JsonIgnore]
		public Func<string> funcRoom1ValDesignat { get; set; }
		private string _auxRoom1ValDesignat { get; set; }

		/// <summary>Campo : "Reference" Tipo:"DT"</summary>
		[Display(Name = "REFERENCE28402", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtrefere { get; set; }

		/// <summary>Campo : "First" Tipo:"C"</summary>
		[Display(Name = "FIRST42972", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFirst { get; set; }

		/// <summary>Campo : "Before" Tipo:"C"</summary>
		[Display(Name = "BEFORE60156", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBefore { get; set; }

		/// <summary>Campo : "Following" Tipo:"C"</summary>
		[Display(Name = "FOLLOWING22170", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFollowin { get; set; }

		/// <summary>Campo : "last" Tipo:"C"</summary>
		[Display(Name = "LAST48120", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValLast { get; set; }

		/// <summary>Campo : "Quantity of transactions" Tipo:"N"</summary>
		[Display(Name = "QUANTITY_OF_TRANSACT63133", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValQtdmovim { get; set; }

		/// <summary>Campo : "Movements" Tipo:"MO"</summary>
		[Display(Name = "MOVEMENTS47007", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValMoviment { get; set; }

		/// <summary>Campo : "Choose room" Tipo:"DW"</summary>
		[Display(Name = "CHOOSE_ROOM04275", ResourceType = typeof(Resources.Resources))]
		public List<GenioMVC.Models.Rooms> List_Movimevv { get; set; }
		public List<GenioMVC.Models.Rooms> List_MovimevvSelected { get; set; }
		public string[] List_Movimevv_SelectedIds { get; set; }
		public string List_Movimevv_Area { get; set; }

		/// <summary>Campo : "Multiple Values Extended" Tipo:"EV"</summary>
		[Display(Name = "MULTIPLE_VALUES_EXTE07457", ResourceType = typeof(Resources.Resources))]
		public string List_Roomsmve { get; set; }

		/// <summary>Campo : "Equipment movement history:" Tipo:"DP"</summary>
		[Display(Name = "EQUIPMENT_MOVEMENT_H06876", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Movim> ValMovimels { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] ValPhotogra { get; set; }

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] ValLastpho { get; set; }

		/// <summary>Campo : "Facilities:" Tipo:"DP"</summary>
		[Display(Name = "FACILITIES_23844", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstalag { get; set; }

		/// <summary>Campo : "Facilities:" Tipo:"DP"</summary>
		[Display(Name = "FACILITIES_23844", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Insta> ValInstalac { get; set; }

		/// <summary>Campo : "Equipment Repairs" Tipo:"DP"</summary>
		[Display(Name = "EQUIPMENT_REPAIRS62266", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Repar> ValReparaco { get; set; }

		/// <summary>Campo : "Decomission No." Tipo:"N"</summary>
		[Display(Name = "DECOMISSION_NO_16646", ResourceType = typeof(Resources.Resources))]
		public TableDBEdit<GenioMVC.Models.Decom>  TableDecomDecomnr { get; set; }

		/// <summary>Campo : "Downed equipment" Tipo:"L"</summary>
		[Display(Name = "DOWNED_EQUIPMENT43331", ResourceType = typeof(Resources.Resources))]
		public bool ValIfabatif { get; set; }

		/// <summary>Campo : "Photos" Tipo:"DP"</summary>
		[Display(Name = "PHOTOS39221", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Photo> ValFotoequi { get; set; }

		/// <summary>Campo : "Visits:" Tipo:"DP"</summary>
		[Display(Name = "VISITS_63312", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Visit> ValVisequip { get; set; }

		/// <summary>Campo : "Digital Attachments" Tipo:"DP"</summary>
		[Display(Name = "DIGITAL_ATTACHMENTS64891", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Anexd> ValAnexos { get; set; }

		/// <summary>Campo : "Timeline" Tipo:"FT"</summary>
		[Display(Name = "TIMELINE45857", ResourceType = typeof(Resources.Resources))]
		public string ValTlequipa { get; set; }

		/// <summary>Campo : "Show record" Tipo:"L"</summary>
		[Display(Name = "SHOW_RECORD53851", ResourceType = typeof(Resources.Resources))]
		public bool ValShowrc { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		[Display(Name = "COMPANY_22615", ResourceType = typeof(Resources.Resources))]
		public string ValCodempre { get; set; }

		[Display(Name = "DECOMISSION_NO_16646", ResourceType = typeof(Resources.Resources))]
		public string ValCoddeco { get; set; }

		[Display(Name = "ITEM_31041", ResourceType = typeof(Resources.Resources))]
		public string ValCoditem { get; set; }

		[Display(Name = "PERSON10446", ResourceType = typeof(Resources.Resources))]
		public string ValCodpess1 { get; set; }

		[Display(Name = "TYPE_OF_EQUIPMENT64921", ResourceType = typeof(Resources.Resources))]
		public string ValCodtpequ { get; set; }

		[Display(Name = "WAREHOUSE51864", ResourceType = typeof(Resources.Resources))]
		public string ValCodwareh { get; set; }

		[Display(Name = "ROOM_NO_15796", ResourceType = typeof(Resources.Resources))]
		public string ValCodrooms { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodequip { get; set; }

		public Equip_ViewModel() : base("FEQUIP") { }

		public Equip_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIP", currentNavigation, nestedForm) { }

		public Equip_ViewModel(Models.Equip row, NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUIP", row, currentNavigation, nestedForm) { }

		public Equip_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, "FEQUIP", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Equip model = new Models.Equip() { Identifier = "FEQUIP" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Equip model)
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

		public static StatusMessage DeleteConditions(Models.Equip model)
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

		public static StatusMessage ViewConditions(Models.Equip model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Equip model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
 				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
 				ValSitefabr = ViewModelConversion.ToString(m.ValSitefabr);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValFrequenc = ViewModelConversion.ToNumeric(m.ValFrequenc);
 				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
 				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
 				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
 				ValBought = ViewModelConversion.ToLogic(m.ValBought);
 				funcRoom1ValDesignat = () => ViewModelConversion.ToString(m.Room1.ValDesignat);
 				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
 				ValFirst = ViewModelConversion.ToString(m.ValFirst);
 				ValBefore = ViewModelConversion.ToString(m.ValBefore);
 				ValFollowin = ViewModelConversion.ToString(m.ValFollowin);
 				ValLast = ViewModelConversion.ToString(m.ValLast);
 				ValQtdmovim = ViewModelConversion.ToNumeric(m.ValQtdmovim);
 				ValMoviment = ViewModelConversion.ToString(m.ValMoviment);
 				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
 				ValLastpho = ViewModelConversion.ToImage(m.ValLastpho);
 				ValIfabatif = ViewModelConversion.ToLogic(m.ValIfabatif);
 				ValShowrc = ViewModelConversion.ToLogic(m.ValShowrc);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equip) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equip) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValSitefabr = ViewModelConversion.ToString(ValSitefabr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValFrequenc = ViewModelConversion.ToNumeric(ValFrequenc);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
				m.ValBefore = ViewModelConversion.ToString(ValBefore);
				m.ValFollowin = ViewModelConversion.ToString(ValFollowin);
				m.ValLast = ViewModelConversion.ToString(ValLast);
				m.ValQtdmovim = ViewModelConversion.ToNumeric(ValQtdmovim);
				m.ValMoviment = ViewModelConversion.ToString(ValMoviment);
				m.ValIfabatif = ViewModelConversion.ToLogic(ValIfabatif);
				m.ValShowrc = ViewModelConversion.ToLogic(ValShowrc);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equip) to Model (Equip) - Error during mapping");
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIP");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Equip() { Identifier = "FEQUIP" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
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

			Model.Identifier = "FEQUIP";
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
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIP");
				if (Model == null)
				{
					Model = new Models.Equip() { Identifier = "FEQUIP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

			Load_Equip___cmpnydesignat(qs, lazyLoad);
			Load_Equip___pess1name____(qs, lazyLoad);
			Load_Equip___tpequtipoequi(qs, lazyLoad);
			Load_Equip___warehwarehdes(qs, lazyLoad);
			Load_Equip___item_itemdes_(qs, lazyLoad);
			Load_Equip___room1roomnr__(qs, lazyLoad);
			Load_Equip___decomdecomnr_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIP]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIP"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUIP" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIP]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUIP"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUIP" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIP]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, "FEQUIP");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValFrequenc = new SelectList(
				ArrayFreqempr.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValFrequenc);
		}


        /// <summary>
        /// TableCmpnyDesignat -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___cmpnydesignatDoLoad = true;
            CriteriaSet equip___cmpnydesignatConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("cmpny", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetValue("cmpny"));
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
                FillDependant_EquipTableCmpnyDesignat(lazyLoad);
                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
                return;
            }


            if (equip___cmpnydesignatDoLoad)
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
                equip___cmpnydesignatConds.SubSet(search_filters);


                string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_CMPNYDESIGNAT]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
                    equip___cmpnydesignatConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAcmpny.FldZzstate, 0)
                        .Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
                else
                    equip___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___cmpnydesignatConds = Cmpny.AddEPH<CSGenioAcmpny>(ref UserContext.Current.User, equip___cmpnydesignatConds, "LED_EQUIP___CMPNYDESIGNAT");

                FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
                ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, equip___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_EQUIP___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

                TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableCmpnyDesignat.Query = query;
                TableCmpnyDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Cmpny>((r) => new GenioMVC.Models.Cmpny(r, true, _fieldsToSerialize_EQUIP___CMPNYDESIGNAT));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
                FillDependant_EquipTableCmpnyDesignat();

                //Check if foreignkey comes from history
                TableCmpnyDesignat.FilledByHistory = Navigation.CheckFilledByHistory("cmpny");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableCmpnyDesignat (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Cmpny</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableCmpnyDesignat(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "cmpny.codempre", "cmpny.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };
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
        public void FillDependant_EquipTableCmpnyDesignat(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableCmpnyDesignat(this.ValCodempre, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

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


        private readonly string[] _fieldsToSerialize_EQUIP___CMPNYDESIGNAT = { "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat" };

        /// <summary>
        /// TablePess1Name -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___pess1name____(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___pess1name____DoLoad = true;
            CriteriaSet equip___pess1name____Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("pess1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, Navigation.GetValue("pess1"));
                    this.ValCodpess1 = Navigation.GetStrValue("pess1");
                }
            }

			// Limits Generation

			// Area limit
			equip___pess1name____DoLoad &= AddCriteriaAreaLimit(equip___pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);


            TablePess1Name = new TableDBEdit<Models.Pess1>();
            TablePess1Name.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
                    this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
                FillDependant_EquipTablePess1Name(lazyLoad);
                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodempre))
                equip___pess1name____DoLoad = false;

            if (equip___pess1name____DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
                    TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
                else
                    TablePess1Name.TableFilters = false;

                query = qs["qTablePess1Name"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioApess1.FldName, query + "%");
                }
                equip___pess1name____Conds.SubSet(search_filters);

                // Last updated by [CJP] at [2016.12.07]
                // Os filtros definidos no Qfield DBEdit passam a ser filtros fracos, to não limparem o Qvalue escolhido.
                // Os filtros podem ser alterados no "ver mais", mas não são obrigatórios.

                string selectedValue = qs["pess1"] ?? this.ValCodpess1;
                CriteriaSet weakFilters = CriteriaSet.Or();
				if (!string.IsNullOrEmpty(selectedValue))
					weakFilters.Equal(CSGenioApess1.FldCodpesso, selectedValue);

                CriteriaSet subfilters = CriteriaSet.And();
                if (Navigation.CheckKey("filter_ValCodpess1__1") && (bool)Navigation.GetValue("filter_ValCodpess1__1") == true)
                {
						subfilters.Equal(CSGenioApess1.FldGender, "F");

                }
                else
                    Navigation.SetValue("filter_ValCodpess1__1", false);

                if (Navigation.CheckKey("filter_ValCodpess1__2") && (bool)Navigation.GetValue("filter_ValCodpess1__2") == true)
                {
						subfilters.Equal(CSGenioApess1.FldGender, "M");

                }
                else
                    Navigation.SetValue("filter_ValCodpess1__2", false);

                weakFilters.SubSets.Add(subfilters);
                equip___pess1name____Conds.SubSets.Add(weakFilters);

                string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_PESS1NAME]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
                    equip___pess1name____Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioApess1.FldZzstate, 0)
                        .Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
                else
                    equip___pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___pess1name____Conds = Pess1.AddEPH<CSGenioApess1>(ref UserContext.Current.User, equip___pess1name____Conds, "LED_EQUIP___PESS1NAME____");

                FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
                ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, equip___pess1name____Conds, fields, offset, numberItems, sorts, "LED_EQUIP___PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

                TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TablePess1Name.Query = query;
                TablePess1Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess1>((r) => new GenioMVC.Models.Pess1(r, true, _fieldsToSerialize_EQUIP___PESS1NAME____));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
                //Seleciona se só um
                if(TablePess1Name.List != null && TablePess1Name.List.Count() == 1)
                {
					this.ValCodpess1 = TablePess1Name.List.First().Value;
					Navigation.SetValue("pess1", this.ValCodpess1);
                }
                FillDependant_EquipTablePess1Name();

                //Check if foreignkey comes from history
                TablePess1Name.FilledByHistory = Navigation.CheckFilledByHistory("pess1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Pess1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTablePess1Name(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "pess1.codpesso", "pess1.name" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldName };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("cmpny");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioApess1 tempArea = new CSGenioApess1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));
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
        /// Fill Dependant fields values -> TablePess1Name (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTablePess1Name(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTablePess1Name(this.ValCodpess1, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
                TablePess1Name.Value = ViewModelConversion.ToString(row["pess1.name"]);
                if (GlobalFunctions.emptyG(this.ValCodpess1) == 1)
                {
                    this.ValCodpess1 = "";
                    TablePess1Name.Value = "";
                    Navigation.ClearValue("pess1");
                }
                else if (lazyLoad)
                {
                    TablePess1Name.SetPagination(1, 0, false, false, 1);
                    TablePess1Name.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodpess1),
                            Text = Convert.ToString(TablePess1Name.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodpess1);
                }
                TablePess1Name.Selected = this.ValCodpess1;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }

        public List<TreeNode> Tree_TablePess1Name { get; protected set; }
        /// <summary>
        /// Get tree structure data -> TablePess1Name
        /// </summary>
        public void LoadTree_TablePess1Name(NameValueCollection requestValues)
        {
            List<TreeNode> Tree = null;

            Tree = new List<TreeNode>();
            CriteriaSet equip___pess1name____Conds = CriteriaSet.And();

            bool equip___pess1name____DoLoad = true;
			// Limits Generation

			// Area limit
			equip___pess1name____DoLoad &= AddCriteriaAreaLimit(equip___pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

			if(!equip___pess1name____DoLoad) return;
            List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


            FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldName };

            equip___pess1name____Conds.Equal(CSGenioApess1.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
            {
                var groupFilters = CriteriaSet.Or();
                bool filter_Equip_Pess1ValName__1 = false;
                if (requestValues["filter_Equip_Pess1ValName_"] != null)
                    filter_Equip_Pess1ValName__1 = requestValues["filter_Equip_Pess1ValName_"].Contains("1");
                else if (Navigation.CheckKey("filter_Equip_Pess1ValName__1"))
                    filter_Equip_Pess1ValName__1 = (bool)Navigation.GetValue("filter_Equip_Pess1ValName__1");
                Navigation.SetValue("filter_Equip_Pess1ValName__1", filter_Equip_Pess1ValName__1);
                if (filter_Equip_Pess1ValName__1)
                {
					groupFilters.Equal(CSGenioApess1.FldGender, "F");

                }

                 subfilters.SubSets.Add(groupFilters);
            }
            {
                var groupFilters = CriteriaSet.Or();
                bool filter_Equip_Pess1ValName__2 = false;
                if (requestValues["filter_Equip_Pess1ValName_"] != null)
                    filter_Equip_Pess1ValName__2 = requestValues["filter_Equip_Pess1ValName_"].Contains("2");
                else if (Navigation.CheckKey("filter_Equip_Pess1ValName__2"))
                    filter_Equip_Pess1ValName__2 = (bool)Navigation.GetValue("filter_Equip_Pess1ValName__2");
                Navigation.SetValue("filter_Equip_Pess1ValName__2", filter_Equip_Pess1ValName__2);
                if (filter_Equip_Pess1ValName__2)
                {
					groupFilters.Equal(CSGenioApess1.FldGender, "M");

                }

                 subfilters.SubSets.Add(groupFilters);
            }
 
			equip___pess1name____Conds.SubSets.Add(subfilters);


            TreeViewControl<Models.Pess1> tree = new TreeViewControl<Models.Pess1>();

// USE /[MANUAL GQT OVERRQ EQUIP_PESS1VALNAME]/
			tree.AddBranch(new TreeBranchInfo<Models.Pess1>() {
				Area = "PESS1", Form = "",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Pess1, string>(x => x.ValName),
				TextSelector = new Func<Models.Pess1, string>(x => string.Format("{0}", x.ValName))
			});

            ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, equip___pess1name____Conds, fields, 0, -1, sorts, "IBL_EQUIP___PESS1NAME____");

            var rowsAsModels = listing.RowsForViewModel<Models.Pess1>((r) => new Models.Pess1(r, true, _fieldsToSerialize_EQUIP___PESS1NAME____).SetIsEmptyModel<Models.Pess1>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
            // Filter the final list to only include the top nodes
            Tree_TablePess1Name = Tree.FindAll(x => x.hasParent == false);
        }

        private readonly string[] _fieldsToSerialize_EQUIP___PESS1NAME____ = { "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName" };

        /// <summary>
        /// TableTpequTipoequi -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___tpequtipoequiDoLoad = true;
            CriteriaSet equip___tpequtipoequiConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("tpequ", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetValue("tpequ"));
                    this.ValCodtpequ = Navigation.GetStrValue("tpequ");
                }
            }



            TableTpequTipoequi = new TableDBEdit<Models.Tpequ>();
            TableTpequTipoequi.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
                    this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
                FillDependant_EquipTableTpequTipoequi(lazyLoad);
                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
                return;
            }


            if (equip___tpequtipoequiDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
                    TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
                else
                    TableTpequTipoequi.TableFilters = false;

                query = qs["qTableTpequTipoequi"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
                }
                equip___tpequtipoequiConds.SubSet(search_filters);


                string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_TPEQUTIPOEQUI]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
                    equip___tpequtipoequiConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAtpequ.FldZzstate, 0)
                        .Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
                else
                    equip___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___tpequtipoequiConds = Tpequ.AddEPH<CSGenioAtpequ>(ref UserContext.Current.User, equip___tpequtipoequiConds, "LED_EQUIP___TPEQUTIPOEQUI");

                FieldRef firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
                ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, equip___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_EQUIP___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

                TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableTpequTipoequi.Query = query;
                TableTpequTipoequi.Elements = listing.RowsForViewModel<GenioMVC.Models.Tpequ>((r) => new GenioMVC.Models.Tpequ(r, true, _fieldsToSerialize_EQUIP___TPEQUTIPOEQUI));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
                FillDependant_EquipTableTpequTipoequi();

                //Check if foreignkey comes from history
                TableTpequTipoequi.FilledByHistory = Navigation.CheckFilledByHistory("tpequ");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Tpequ</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableTpequTipoequi(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "tpequ.codtpequ", "tpequ.tipoequi" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi };
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
            CSGenioAtpequ tempArea = new CSGenioAtpequ(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));
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
        /// Fill Dependant fields values -> TableTpequTipoequi (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTableTpequTipoequi(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableTpequTipoequi(this.ValCodtpequ, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
                TableTpequTipoequi.Value = ViewModelConversion.ToString(row["tpequ.tipoequi"]);
                if (GlobalFunctions.emptyG(this.ValCodtpequ) == 1)
                {
                    this.ValCodtpequ = "";
                    TableTpequTipoequi.Value = "";
                    Navigation.ClearValue("tpequ");
                }
                else if (lazyLoad)
                {
                    TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
                    TableTpequTipoequi.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodtpequ),
                            Text = Convert.ToString(TableTpequTipoequi.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodtpequ);
                }
                TableTpequTipoequi.Selected = this.ValCodtpequ;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }

        public List<TreeNode> Tree_TableTpequTipoequi { get; protected set; }
        /// <summary>
        /// Get tree structure data -> TableTpequTipoequi
        /// </summary>
        public void LoadTree_TableTpequTipoequi(NameValueCollection requestValues)
        {
            List<TreeNode> Tree = null;

            Tree = new List<TreeNode>();
            CriteriaSet equip___tpequtipoequiConds = CriteriaSet.And();

            bool equip___tpequtipoequiDoLoad = true;

			if(!equip___tpequtipoequiDoLoad) return;
            List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


            FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };

            equip___tpequtipoequiConds.Equal(CSGenioAtpequ.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
 
			equip___tpequtipoequiConds.SubSets.Add(subfilters);


            TreeViewControl<Models.Tpequ> tree = new TreeViewControl<Models.Tpequ>();

// USE /[MANUAL GQT OVERRQ EQUIP_TPEQUVALTIPOEQUI]/
			tree.AddBranch(new TreeBranchInfo<Models.Tpequ>() {
				Area = "TPEQU", Form = "",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Tpequ, string>(x => x.ValTpequcod),
				ParentSelector = new Func<Models.Tpequ, string>(x => x.ValTpequpai),
				LevelSelector = new Func<Models.Tpequ, decimal>(x => x.ValNivel),
				TextSelector = new Func<Models.Tpequ, string>(x => string.Format("{0} {1}", x.ValTpequcod, x.ValTipoequi))
			});

            ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, equip___tpequtipoequiConds, fields, 0, -1, sorts, "IBL_EQUIP___TPEQUTIPOEQUI");

            var rowsAsModels = listing.RowsForViewModel<Models.Tpequ>((r) => new Models.Tpequ(r, true, _fieldsToSerialize_EQUIP___TPEQUTIPOEQUI).SetIsEmptyModel<Models.Tpequ>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
            // Filter the final list to only include the top nodes
            Tree_TableTpequTipoequi = Tree.FindAll(x => x.hasParent == false);
        }

        private readonly string[] _fieldsToSerialize_EQUIP___TPEQUTIPOEQUI = { "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra" };

        /// <summary>
        /// TableWarehWarehdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___warehwarehdesDoLoad = true;
            CriteriaSet equip___warehwarehdesConds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("wareh", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));
                    this.ValCodwareh = Navigation.GetStrValue("wareh");
                }
            }



            TableWarehWarehdes = new TableDBEdit<Models.Wareh>();
            TableWarehWarehdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
                    this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
                FillDependant_EquipTableWarehWarehdes(lazyLoad);
                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
                return;
            }


            if (equip___warehwarehdesDoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
                    TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
                else
                    TableWarehWarehdes.TableFilters = false;

                query = qs["qTableWarehWarehdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
                }
                equip___warehwarehdesConds.SubSet(search_filters);


                string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldWarehcod, CSGenioAwareh.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_WAREHWAREHDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
                    equip___warehwarehdesConds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAwareh.FldZzstate, 0)
                        .Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
                else
                    equip___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___warehwarehdesConds = Wareh.AddEPH<CSGenioAwareh>(ref UserContext.Current.User, equip___warehwarehdesConds, "LED_EQUIP___WAREHWAREHDES");

                FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
                ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(false, equip___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_EQUIP___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

                TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableWarehWarehdes.Query = query;
                TableWarehWarehdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Wareh>((r) => new GenioMVC.Models.Wareh(r, true, _fieldsToSerialize_EQUIP___WAREHWAREHDES));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
                FillDependant_EquipTableWarehWarehdes();

                //Check if foreignkey comes from history
                TableWarehWarehdes.FilledByHistory = Navigation.CheckFilledByHistory("wareh");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Wareh</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableWarehWarehdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "wareh.codwareh", "wareh.warehdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };
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
            CSGenioAwareh tempArea = new CSGenioAwareh(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));
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
        /// Fill Dependant fields values -> TableWarehWarehdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTableWarehWarehdes(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableWarehWarehdes(this.ValCodwareh, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
                TableWarehWarehdes.Value = ViewModelConversion.ToString(row["wareh.warehdes"]);
                if (GlobalFunctions.emptyG(this.ValCodwareh) == 1)
                {
                    this.ValCodwareh = "";
                    TableWarehWarehdes.Value = "";
                    Navigation.ClearValue("wareh");
                }
                else if (lazyLoad)
                {
                    TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
                    TableWarehWarehdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodwareh),
                            Text = Convert.ToString(TableWarehWarehdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodwareh);
                }
                TableWarehWarehdes.Selected = this.ValCodwareh;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIP___WAREHWAREHDES = { "Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes", "Wareh.ValWarehcod" };

        /// <summary>
        /// TableItemItemdes -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___item_itemdes_DoLoad = true;
            CriteriaSet equip___item_itemdes_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("item", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, Navigation.GetValue("item"));
                    this.ValCoditem = Navigation.GetStrValue("item");
                }
            }

			// Limits Generation

			// Area limit
			equip___item_itemdes_DoLoad &= AddCriteriaAreaLimit(equip___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);


            TableItemItemdes = new TableDBEdit<Models.Item>();
            TableItemItemdes.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
                    this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
                FillDependant_EquipTableItemItemdes(lazyLoad);
                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
                return;
            }

            if (String.IsNullOrEmpty(this.ValCodwareh))
                equip___item_itemdes_DoLoad = false;

            if (equip___item_itemdes_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
                if (requestedSort != null)
                        sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
                    TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
                else
                    TableItemItemdes.TableFilters = false;

                query = qs["qTableItemItemdes"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
                }
                equip___item_itemdes_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_ITEMITEMDES]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
                    equip___item_itemdes_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAitem.FldZzstate, 0)
                        .Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
                else
                    equip___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___item_itemdes_Conds = Item.AddEPH<CSGenioAitem>(ref UserContext.Current.User, equip___item_itemdes_Conds, "LED_EQUIP___ITEM_ITEMDES_");

                FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
                ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(false, equip___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_EQUIP___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableItemItemdes.Query = query;
                TableItemItemdes.Elements = listing.RowsForViewModel<GenioMVC.Models.Item>((r) => new GenioMVC.Models.Item(r, true, _fieldsToSerialize_EQUIP___ITEM_ITEMDES_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
                FillDependant_EquipTableItemItemdes();

                //Check if foreignkey comes from history
                TableItemItemdes.FilledByHistory = Navigation.CheckFilledByHistory("item");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Item</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableItemItemdes(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "item.coditem", "item.itemdes" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes };
            var returnEmptyDependants = false;
            CriteriaSet wherecodition = CriteriaSet.And();

            // Return default values
            if (GlobalFunctions.emptyG(PKey) == 1)
                returnEmptyDependants = true;

            // Check if the limit(s) is filled if exists
            {
                object hValue = Navigation.GetValue("wareh");
                if (!(hValue is Array))
                {
                    if (GlobalFunctions.emptyG(hValue) == 1)
                        returnEmptyDependants = true;
                    else
                        wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
                }
            }
            // - - - - - - - - - - - - - - - - - - - - -

            if(returnEmptyDependants)
                return getDefaultValuesForFields(refDependantFields);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            User u = UserContext.Current.User;
            CSGenioAitem tempArea = new CSGenioAitem(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));
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
        /// Fill Dependant fields values -> TableItemItemdes (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTableItemItemdes(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableItemItemdes(this.ValCoditem, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
                TableItemItemdes.Value = ViewModelConversion.ToString(row["item.itemdes"]);
                if (GlobalFunctions.emptyG(this.ValCoditem) == 1)
                {
                    this.ValCoditem = "";
                    TableItemItemdes.Value = "";
                    Navigation.ClearValue("item");
                }
                else if (lazyLoad)
                {
                    TableItemItemdes.SetPagination(1, 0, false, false, 1);
                    TableItemItemdes.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoditem),
                            Text = Convert.ToString(TableItemItemdes.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoditem);
                }
                TableItemItemdes.Selected = this.ValCoditem;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIP___ITEM_ITEMDES_ = { "Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod" };

        /// <summary>
        /// TableRoom1Roomnr -> (F1)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___room1roomnr__(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___room1roomnr__DoLoad = true;
            CriteriaSet equip___room1roomnr__Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("room1", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___room1roomnr__Conds.Equal(CSGenioAroom1.FldCodrooms, Navigation.GetValue("room1"));
                    this.ValCodrooms = Navigation.GetStrValue("room1");
                }
            }



            TableRoom1Roomnr = new TableDBEdit<Models.Room1>();
            TableRoom1Roomnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
                    this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}
                FillDependant_EquipTableRoom1Roomnr(lazyLoad);
                //Check if foreignkey comes from history
                TableRoom1Roomnr.FilledByHistory = Navigation.CheckFilledByHistory("room1");
                return;
            }


            if (equip___room1roomnr__DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableRoom1Roomnr, "sTableRoom1Roomnr", "dTableRoom1Roomnr", qs, "room1");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableRoom1Roomnr_tableFilters"]))
                    TableRoom1Roomnr.TableFilters = bool.Parse(qs["TableRoom1Roomnr_tableFilters"]);
                else
                    TableRoom1Roomnr.TableFilters = false;

                query = qs["qTableRoom1Roomnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAroom1.FldRoomnr, query + "%");
                }
                equip___room1roomnr__Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableRoom1Roomnr"] != null ? qs["pTableRoom1Roomnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_ROOM1ROOMNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("room1", FormMode.New) || Navigation.checkFormMode("room1", FormMode.Duplicate))
                    equip___room1roomnr__Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAroom1.FldZzstate, 0)
                        .Equal(CSGenioAroom1.FldCodrooms, Navigation.GetStrValue("room1")));
                else
                    equip___room1roomnr__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAroom1.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___room1roomnr__Conds = Room1.AddEPH<CSGenioAroom1>(ref UserContext.Current.User, equip___room1roomnr__Conds, "LED_EQUIP___ROOM1ROOMNR__");

                FieldRef firstVisibleColumn = null;
                ListingMVC<CSGenioAroom1> listing = Models.ModelBase.Where<CSGenioAroom1>(false, equip___room1roomnr__Conds, fields, offset, numberItems, sorts, "LED_EQUIP___ROOM1ROOMNR__", true, false, firstVisibleColumn: firstVisibleColumn);

                TableRoom1Roomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableRoom1Roomnr.Query = query;
                TableRoom1Roomnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Room1>((r) => new GenioMVC.Models.Room1(r, true, _fieldsToSerialize_EQUIP___ROOM1ROOMNR__));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}

				TableRoom1Roomnr.List = new SelectList(TableRoom1Roomnr.Elements.ToSelectList(x => x.ValRoomnr, x => x.ValCodrooms,  x => x.ValCodrooms == this.ValCodrooms), "Value", "Text", this.ValCodrooms);
                FillDependant_EquipTableRoom1Roomnr();

                //Check if foreignkey comes from history
                TableRoom1Roomnr.FilledByHistory = Navigation.CheckFilledByHistory("room1");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableRoom1Roomnr (F1)
        /// </summary>
        /// <param name="PKey">Primary Key of Room1</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableRoom1Roomnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "room1.codrooms", "room1.roomnr", "room1.designat" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldDesignat };
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
            CSGenioAroom1 tempArea = new CSGenioAroom1(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAroom1.FldCodrooms, PKey));
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
        /// Fill Dependant fields values -> TableRoom1Roomnr (F1)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTableRoom1Roomnr(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableRoom1Roomnr(this.ValCodrooms, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.
                {
                    var tempValue = ViewModelConversion.ToString(row["room1.designat"]);
                    this.funcRoom1ValDesignat = () => tempValue;
                }

                // Fill List fields
                this.ValCodrooms = ViewModelConversion.ToString(row["room1.codrooms"]);
                TableRoom1Roomnr.Value = ViewModelConversion.ToString(row["room1.roomnr"]);
                if (GlobalFunctions.emptyG(this.ValCodrooms) == 1)
                {
                    this.ValCodrooms = "";
                    TableRoom1Roomnr.Value = "";
                    Navigation.ClearValue("room1");
                }
                else if (lazyLoad)
                {
                    TableRoom1Roomnr.SetPagination(1, 0, false, false, 1);
                    TableRoom1Roomnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCodrooms),
                            Text = Convert.ToString(TableRoom1Roomnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCodrooms);
                }
                TableRoom1Roomnr.Selected = this.ValCodrooms;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRoom1Roomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIP___ROOM1ROOMNR__ = { "Room1", "Room1.ValCodrooms", "Room1.ValZzstate" };
		/// <summary>
		/// List_Movimevv -> (DW)
		/// </summary>
		/// <param name="qs"></param>
		public void Load_Equip___pseudmovimevv(NameValueCollection qs)
		{
			bool equip___pseudmovimevvDoLoad = true;
			CriteriaSet equip___pseudmovimevvConds = CriteriaSet.And();


			this.List_Movimevv_Area = "Rooms";
			this.List_Movimevv = new List<GenioMVC.Models.Rooms>();
			this.List_MovimevvSelected = new List<GenioMVC.Models.Rooms>();
			if (List_Movimevv_SelectedIds == null)
				List_Movimevv_SelectedIds = new string[0];

			if (equip___pseudmovimevvDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();


				CriteriaSet equip___pseudmovimevv_roomnr_Conds = CriteriaSet.And();
				equip___pseudmovimevv_roomnr_Conds.Equal(CSGenioAmovim.FldCodequip, ValCodequip);

// USE /[MANUAL GQT OVERRQ EQUIP_PSEUDMOVIMEVV]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Rooms", FormMode.New)) // TODO: Check in Duplicate mode
					equip___pseudmovimevvConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArooms.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Movimevv = Models.ModelBase.Where<CSGenioArooms>(false, args: equip___pseudmovimevvConds, numRegs: -1, sorts: sorts, fields: new FieldRef[]
					{
						CSGenio.business.CSGenioArooms.FldCodrooms,
						CSGenio.business.CSGenioArooms.FldRoomnr,
						CSGenio.business.CSGenioArooms.FldDesignat,
					}).RowsForViewModel<GenioMVC.Models.Rooms>((r) => new GenioMVC.Models.Rooms(r));

				if (List_Movimevv_SelectedIds.Length == 0)
					List_Movimevv_SelectedIds = Models.ModelBase.All<CSGenioAmovim>(equip___pseudmovimevv_roomnr_Conds).Rows.Select(x => x.ValCodrooms).ToArray();
				List_MovimevvSelected = List_Movimevv.Where(x => List_Movimevv_SelectedIds.Contains(x.ValCodrooms)).ToList();
			}
		}

        /// <summary>
        /// TableDecomDecomnr -> (DB)
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void Load_Equip___decomdecomnr_(NameValueCollection qs, bool lazyLoad = false)
        {
            bool equip___decomdecomnr_DoLoad = true;
            CriteriaSet equip___decomdecomnr_Conds = CriteriaSet.And();
            {
                object hValue = Navigation.GetValue("decom", true);
                if (hValue != null && !(hValue is Array) && !String.IsNullOrEmpty(Convert.ToString(hValue)))
                {
                    equip___decomdecomnr_Conds.Equal(CSGenioAdecom.FldCoddeco, Navigation.GetValue("decom"));
                    this.ValCoddeco = Navigation.GetStrValue("decom");
                }
            }



            TableDecomDecomnr = new TableDBEdit<Models.Decom>();
            TableDecomDecomnr.IsLazyLoad = lazyLoad;
            if(lazyLoad)
            {
                if (Navigation.CurrentLevel.GetEntry("RETURN_decom") != null)
				{
                    this.ValCoddeco = Navigation.GetStrValue("RETURN_decom");
					Navigation.CurrentLevel.SetEntry("RETURN_decom", null);
				}
                FillDependant_EquipTableDecomDecomnr(lazyLoad);
                //Check if foreignkey comes from history
                TableDecomDecomnr.FilledByHistory = Navigation.CheckFilledByHistory("decom");
                return;
            }


            if (equip___decomdecomnr_DoLoad)
            {
                List<ColumnSort> sorts = new List<ColumnSort>();
                ColumnSort requestedSort = GetRequestSort(TableDecomDecomnr, "sTableDecomDecomnr", "dTableDecomDecomnr", qs, "decom");
                if (requestedSort != null)
                        sorts.Add(requestedSort);


                string query = "";
                if (!String.IsNullOrEmpty(qs["TableDecomDecomnr_tableFilters"]))
                    TableDecomDecomnr.TableFilters = bool.Parse(qs["TableDecomDecomnr_tableFilters"]);
                else
                    TableDecomDecomnr.TableFilters = false;

                query = qs["qTableDecomDecomnr"];

                //RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
                // O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
                //  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
                CriteriaSet search_filters = CriteriaSet.And();
                if (!String.IsNullOrEmpty(query))
                {
					search_filters.Like(CSGenioAdecom.FldDecomnr, query + "%");
                }
                equip___decomdecomnr_Conds.SubSet(search_filters);


                string tryParsePage = qs["pTableDecomDecomnr"] != null ? qs["pTableDecomDecomnr"].ToString() : "1";
                int page = !String.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
                int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
                int offset = (page - 1) * numberItems;

                FieldRef[] fields = new FieldRef[] { CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAdecom.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIP_DECOMDECOMNR]/

                // Limitation by Zzstate
                /*
                    Records that are currently being inserted or duplicated will also be included.
                    Client-side persistence will try to fill the "text" value of that option.
                */
                if(Navigation.checkFormMode("decom", FormMode.New) || Navigation.checkFormMode("decom", FormMode.Duplicate))
                    equip___decomdecomnr_Conds.SubSet(CriteriaSet.Or()
                        .Equal(CSGenioAdecom.FldZzstate, 0)
                        .Equal(CSGenioAdecom.FldCoddeco, Navigation.GetStrValue("decom")));
                else
                    equip___decomdecomnr_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAdecom.FldZzstate), CriteriaOperator.Equal, 0));

                //EPH
                //equip___decomdecomnr_Conds = Decom.AddEPH<CSGenioAdecom>(ref UserContext.Current.User, equip___decomdecomnr_Conds, "LED_EQUIP___DECOMDECOMNR_");

                FieldRef firstVisibleColumn = new FieldRef("decom", "decomnr");
                ListingMVC<CSGenioAdecom> listing = Models.ModelBase.Where<CSGenioAdecom>(false, equip___decomdecomnr_Conds, fields, offset, numberItems, sorts, "LED_EQUIP___DECOMDECOMNR_", true, false, firstVisibleColumn: firstVisibleColumn);

                TableDecomDecomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
                TableDecomDecomnr.Query = query;
                TableDecomDecomnr.Elements = listing.RowsForViewModel<GenioMVC.Models.Decom>((r) => new GenioMVC.Models.Decom(r, true, _fieldsToSerialize_EQUIP___DECOMDECOMNR_));

                //creaed by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
                //last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
                if (Navigation.CurrentLevel.GetEntry("RETURN_decom") != null)
				{
					this.ValCoddeco = Navigation.GetStrValue("RETURN_decom");
					Navigation.CurrentLevel.SetEntry("RETURN_decom", null);
				}

				TableDecomDecomnr.List = new SelectList(TableDecomDecomnr.Elements.ToSelectList(x => x.ValDecomnr, x => x.ValCoddeco,  x => x.ValCoddeco == this.ValCoddeco), "Value", "Text", this.ValCoddeco);
                FillDependant_EquipTableDecomDecomnr();

                //Check if foreignkey comes from history
                TableDecomDecomnr.FilledByHistory = Navigation.CheckFilledByHistory("decom");
            }
        }

        /// <summary>
        /// Get Dependant fields values -> TableDecomDecomnr (DB)
        /// </summary>
        /// <param name="PKey">Primary Key of Decom</param>
        /// <param name="Navigation">Navigation context</param>
        public static ConcurrentDictionary<string, object> GetDependant_EquipTableDecomDecomnr(string PKey, NavigationContext Navigation)
        {
            string[] DependantFields = new string[] { "decom.coddeco", "decom.decomnr" };
            FieldRef[] refDependantFields = new FieldRef[] { CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr };
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
            CSGenioAdecom tempArea = new CSGenioAdecom(u);

            // Fields to select
            SelectQuery querySelect = new SelectQuery();
            querySelect.PageSize(1);
            foreach (FieldRef field in refDependantFields)
                querySelect.Select(field);

            querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
                .Where(wherecodition.Equal(CSGenioAdecom.FldCoddeco, PKey));
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
        /// Fill Dependant fields values -> TableDecomDecomnr (DB)
        /// </summary>
        /// <param name="lazyLoad">Lazy loading of dropdown items</param>
        public void FillDependant_EquipTableDecomDecomnr(bool lazyLoad = false)
        {
            var row = GetDependant_EquipTableDecomDecomnr(this.ValCoddeco, Navigation);
            try
            {
                // That code doesn't include fields of the own control and can be empty if no one dependant field present on the form.

                // Fill List fields
                this.ValCoddeco = ViewModelConversion.ToString(row["decom.coddeco"]);
                TableDecomDecomnr.Value = ViewModelConversion.ToNumeric(row["decom.decomnr"]);
                if (GlobalFunctions.emptyG(this.ValCoddeco) == 1)
                {
                    this.ValCoddeco = "";
                    TableDecomDecomnr.Value = 0m;
                    Navigation.ClearValue("decom");
                }
                else if (lazyLoad)
                {
                    TableDecomDecomnr.SetPagination(1, 0, false, false, 1);
                    TableDecomDecomnr.List = new SelectList(new List<SelectListItem>() {
                        new SelectListItem
                        {
                            Value = Convert.ToString(this.ValCoddeco),
                            Text = Convert.ToString(TableDecomDecomnr.Value),
                            Selected = true
                        } }, "Value", "Text", this.ValCoddeco);
                }
                TableDecomDecomnr.Selected = this.ValCoddeco;

            }
            catch (Exception ex) { CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableDecomDecomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "")); }
        }


        private readonly string[] _fieldsToSerialize_EQUIP___DECOMDECOMNR_ = { "Decom", "Decom.ValCoddeco", "Decom.ValZzstate", "Decom.ValDecomnr" };



		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValMoviment = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValMoviment, false);
		}

		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP]/
		#endregion
	}
}
