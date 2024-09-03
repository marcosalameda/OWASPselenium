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

namespace GenioMVC.ViewModels.Uicom
{
	public class Uicom_ViewModel : FormViewModel<Models.Uicom>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Miniature" Tipo:"IJ"</summary>
		[Display(Name = "MINIATURE57617", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 270, 50, false, true)]
		public byte[] ValThumbnai { get; set; }

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Category" Tipo:"C"</summary>
		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCategory { get; set; }

		/// <summary>Campo : "Fixed menu name" Tipo:"C"</summary>
		[Display(Name = "FIXED_MENU_NAME38578", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(30, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValMenuid { get; set; }


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

		public string ValCoduicom { get; set; }

		public Uicom_ViewModel() : base("FUICOM") { }

		public Uicom_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FUICOM", currentNavigation, nestedForm) { }

		public Uicom_ViewModel(Models.Uicom row, NavigationContext currentNavigation, bool nestedForm = false) : base("FUICOM", row, currentNavigation, nestedForm) { }

		public Uicom_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("uicom", id);
			Model = Models.Uicom.Find(id, "FUICOM", fieldsToQuery: fieldsToLoad);
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
			Models.Uicom model = new Models.Uicom() { Identifier = "FUICOM" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Uicom model)
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

		public static StatusMessage DeleteConditions(Models.Uicom model)
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

		public static StatusMessage ViewConditions(Models.Uicom model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Uicom model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Uicom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Uicom) to ViewModel (Uicom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValThumbnai = ViewModelConversion.ToImage(m.ValThumbnai);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValCategory = ViewModelConversion.ToString(m.ValCategory);
 				ValMenuid = ViewModelConversion.ToString(m.ValMenuid);
 				ValCoduicom = ViewModelConversion.ToString(m.ValCoduicom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Uicom) to ViewModel (Uicom) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Uicom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Uicom) to Model (Uicom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValMenuid = ViewModelConversion.ToString(ValMenuid);
				m.ValCoduicom = ViewModelConversion.ToString(ValCoduicom);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Uicom) to Model (Uicom) - Error during mapping");
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
				Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), "FUICOM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Uicom() { Identifier = "FUICOM" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("uicom");
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

			Model.Identifier = "FUICOM";
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

		protected override void LoadDocumentsProperties(Models.Uicom row)
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
				Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), "FUICOM");
				if (Model == null)
				{
					Model = new Models.Uicom() { Identifier = "FUICOM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("uicom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL UICOM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW UICOM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE UICOM]/
		public override void Save()
		{

			try { Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), "FUICOM"); }
			finally { if (Model == null) Model = new Models.Uicom() { Identifier = "FUICOM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY UICOM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Uicom.Find(Navigation.GetStrValue("uicom"), "FUICOM"); }
			finally { if (Model == null) Model = new Models.Uicom() { Identifier = "FUICOM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE UICOM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY UICOM]/
		public override void Destroy(string id)
		{
			Model = Models.Uicom.Find(id, "FUICOM");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM UICOM]/
		#endregion
	}
}
