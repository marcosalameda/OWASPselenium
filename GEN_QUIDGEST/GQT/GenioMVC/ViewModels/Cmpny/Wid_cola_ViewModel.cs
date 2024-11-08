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

namespace GenioMVC.ViewModels.Cmpny
{
	public class Wid_cola_ViewModel : FormViewModel<Models.Cmpny>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Logo" Tipo:"IJ"</summary>
		[Display(Name = "LOGO62483", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 50, false, true)]
		public byte[] ValLogo { get; set; }

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "People" Tipo:"DP"</summary>
		[Display(Name = "PEOPLE34206", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Pesso> ValPesslist { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodcntry { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodempre { get; set; }

		public Wid_cola_ViewModel() : base("FWID_COLA") { }

		public Wid_cola_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FWID_COLA", currentNavigation, nestedForm) { }

		public Wid_cola_ViewModel(Models.Cmpny row, NavigationContext currentNavigation, bool nestedForm = false) : base("FWID_COLA", row, currentNavigation, nestedForm) { }

		public Wid_cola_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cmpny", id);
			Model = Models.Cmpny.Find(id, "FWID_COLA", fieldsToQuery: fieldsToLoad);
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
			Models.Cmpny model = new Models.Cmpny() { Identifier = "FWID_COLA" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cmpny model)
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

		public static StatusMessage DeleteConditions(Models.Cmpny model)
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

		public static StatusMessage ViewConditions(Models.Cmpny model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cmpny model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Wid_cola) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Wid_cola) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Wid_cola) to Model (Cmpny) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Wid_cola) to Model (Cmpny) - Error during mapping");
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
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FWID_COLA");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cmpny() { Identifier = "FWID_COLA" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");
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

			Model.Identifier = "FWID_COLA";
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

		protected override void LoadDocumentsProperties(Models.Cmpny row)
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
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FWID_COLA");
				if (Model == null)
				{
					Model = new Models.Cmpny() { Identifier = "FWID_COLA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL WID_COLA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW WID_COLA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE WID_COLA]/
		public override void Save()
		{

			try { Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FWID_COLA"); }
			finally { if (Model == null) Model = new Models.Cmpny() { Identifier = "FWID_COLA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY WID_COLA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), "FWID_COLA"); }
			finally { if (Model == null) Model = new Models.Cmpny() { Identifier = "FWID_COLA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE WID_COLA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY WID_COLA]/
		public override void Destroy(string id)
		{
			Model = Models.Cmpny.Find(id, "FWID_COLA");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_COLA]/
		#endregion
	}
}
