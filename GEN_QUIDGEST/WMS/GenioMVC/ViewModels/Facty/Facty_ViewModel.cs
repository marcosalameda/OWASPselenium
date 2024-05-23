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

namespace GenioMVC.ViewModels.Facty
{
	public class Facty_ViewModel : FormViewModel<Models.Facty>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Facility type" Tipo:"C"</summary>
		[Display(Name = "FACILITY_TYPE44577", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(25, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValType { get; set; }

		/// <summary>Campo : "Layer name" Tipo:"C"</summary>
		[Display(Name = "LAYER_NAME49545", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValLayrname { get; set; }

		/// <summary>Campo : "Icon URL" Tipo:"C"</summary>
		[Display(Name = "ICON_URL07016", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIconurl { get; set; }

		/// <summary>Campo : "Shadow URL" Tipo:"C"</summary>
		[Display(Name = "SHADOW_URL57805", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValShadowur { get; set; }

		/// <summary>Campo : "Icon anchor (x-axis)" Tipo:"N"</summary>
		[Display(Name = "ICON_ANCHOR__X_AXIS_18664", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIconancx { get; set; }

		/// <summary>Campo : "Icon anchor (y-axis)" Tipo:"N"</summary>
		[Display(Name = "ICON_ANCHOR__Y_AXIS_63725", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIconancy { get; set; }

		/// <summary>Campo : "Icon height" Tipo:"N"</summary>
		[Display(Name = "ICON_HEIGHT61896", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIconheig { get; set; }

		/// <summary>Campo : "Icon width" Tipo:"N"</summary>
		[Display(Name = "ICON_WIDTH02295", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValIconwid { get; set; }

		/// <summary>Campo : "Popup anchor (x-axis)" Tipo:"N"</summary>
		[Display(Name = "POPUP_ANCHOR__X_AXIS15060", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValPopupanx { get; set; }

		/// <summary>Campo : "Popup anchor (y-axis)" Tipo:"N"</summary>
		[Display(Name = "POPUP_ANCHOR__Y_AXIS64670", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValPopupany { get; set; }

		/// <summary>Campo : "Shadow anchor (x-axis)" Tipo:"N"</summary>
		[Display(Name = "SHADOW_ANCHOR__X_AXI31230", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValShadowax { get; set; }

		/// <summary>Campo : "Shadow anchor (y-axis)" Tipo:"N"</summary>
		[Display(Name = "SHADOW_ANCHOR__Y_AXI51495", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValShadoway { get; set; }

		/// <summary>Campo : "Shadow height" Tipo:"N"</summary>
		[Display(Name = "SHADOW_HEIGHT64343", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValShadowhe { get; set; }

		/// <summary>Campo : "Shadow width" Tipo:"N"</summary>
		[Display(Name = "SHADOW_WIDTH01769", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValShadowwi { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodfacty { get; set; }

		public Facty_ViewModel() : base("FFACTY") { }

		public Facty_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFACTY", currentNavigation, nestedForm) { }

		public Facty_ViewModel(Models.Facty row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFACTY", row, currentNavigation, nestedForm) { }

		public Facty_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("facty", id);
			Model = Models.Facty.Find(id, "FFACTY", fieldsToQuery: fieldsToLoad);
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
			Models.Facty model = new Models.Facty() { Identifier = "FFACTY" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Facty model)
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

		public static StatusMessage DeleteConditions(Models.Facty model)
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

		public static StatusMessage ViewConditions(Models.Facty model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Facty model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Facty m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Facty) to ViewModel (Facty) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValType = ViewModelConversion.ToString(m.ValType);
 				ValLayrname = ViewModelConversion.ToString(m.ValLayrname);
 				ValIconurl = ViewModelConversion.ToString(m.ValIconurl);
 				ValShadowur = ViewModelConversion.ToString(m.ValShadowur);
 				ValIconancx = ViewModelConversion.ToNumeric(m.ValIconancx);
 				ValIconancy = ViewModelConversion.ToNumeric(m.ValIconancy);
 				ValIconheig = ViewModelConversion.ToNumeric(m.ValIconheig);
 				ValIconwid = ViewModelConversion.ToNumeric(m.ValIconwid);
 				ValPopupanx = ViewModelConversion.ToNumeric(m.ValPopupanx);
 				ValPopupany = ViewModelConversion.ToNumeric(m.ValPopupany);
 				ValShadowax = ViewModelConversion.ToNumeric(m.ValShadowax);
 				ValShadoway = ViewModelConversion.ToNumeric(m.ValShadoway);
 				ValShadowhe = ViewModelConversion.ToNumeric(m.ValShadowhe);
 				ValShadowwi = ViewModelConversion.ToNumeric(m.ValShadowwi);
 				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Facty) to ViewModel (Facty) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Facty m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facty) to Model (Facty) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValType = ViewModelConversion.ToString(ValType);
				m.ValLayrname = ViewModelConversion.ToString(ValLayrname);
				m.ValIconurl = ViewModelConversion.ToString(ValIconurl);
				m.ValShadowur = ViewModelConversion.ToString(ValShadowur);
				m.ValIconancx = ViewModelConversion.ToNumeric(ValIconancx);
				m.ValIconancy = ViewModelConversion.ToNumeric(ValIconancy);
				m.ValIconheig = ViewModelConversion.ToNumeric(ValIconheig);
				m.ValIconwid = ViewModelConversion.ToNumeric(ValIconwid);
				m.ValPopupanx = ViewModelConversion.ToNumeric(ValPopupanx);
				m.ValPopupany = ViewModelConversion.ToNumeric(ValPopupany);
				m.ValShadowax = ViewModelConversion.ToNumeric(ValShadowax);
				m.ValShadoway = ViewModelConversion.ToNumeric(ValShadoway);
				m.ValShadowhe = ViewModelConversion.ToNumeric(ValShadowhe);
				m.ValShadowwi = ViewModelConversion.ToNumeric(ValShadowwi);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facty) to Model (Facty) - Error during mapping");
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
				Model = Models.Facty.Find(Navigation.GetStrValue("facty"), "FFACTY");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Facty() { Identifier = "FFACTY" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("facty");
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

			Model.Identifier = "FFACTY";
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

		protected override void LoadDocumentsProperties(Models.Facty row)
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
				Model = Models.Facty.Find(Navigation.GetStrValue("facty"), "FFACTY");
				if (Model == null)
				{
					Model = new Models.Facty() { Identifier = "FFACTY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("facty");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FACTY]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FACTY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FACTY]/
		public override void Save()
		{

			try { Model = Models.Facty.Find(Navigation.GetStrValue("facty"), "FFACTY"); }
			finally { if (Model == null) Model = new Models.Facty() { Identifier = "FFACTY" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FACTY]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Facty.Find(Navigation.GetStrValue("facty"), "FFACTY"); }
			finally { if (Model == null) Model = new Models.Facty() { Identifier = "FFACTY" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FACTY]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FACTY]/
		public override void Destroy(string id)
		{
			Model = Models.Facty.Find(id, "FFACTY");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FACTY]/
		#endregion
	}
}
