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

namespace GenioMVC.ViewModels.Cntry
{
	public class Pais_ViewModel : FormViewModel<Models.Cntry>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Designation:" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION_35800", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(90, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCountry { get; set; }

		/// <summary>Campo : "Active" Tipo:"L"</summary>
		[Display(Name = "ACTIVE03270", ResourceType = typeof(Resources.Resources))]
		public bool ValActive { get; set; }

		/// <summary>Campo : "Numeric" Tipo:"C"</summary>
		[Display(Name = "NUMERIC19292", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(3, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCodigonr { get; set; }

		/// <summary>Campo : "Alphabetic 2:" Tipo:"C"</summary>
		[Display(Name = "ALPHABETIC_2_16300", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(2, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAlfa2 { get; set; }

		/// <summary>Campo : "Alphabetic 3:" Tipo:"C"</summary>
		[Display(Name = "ALPHABETIC_3_29295", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(3, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAlfa3 { get; set; }

		/// <summary>Campo : "Bandeira" Tipo:"IJ"</summary>
		[Display(Name = "BANDEIRA32255", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 50, false, true)]
		public byte[] ValFlag { get; set; }

		/// <summary>Campo : "Real Estate List" Tipo:"DP"</summary>
		[Display(Name = "REAL_ESTATE_LIST36497", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Propr> ValProprie1 { get; set; }

		/// <summary>Campo : "Real State Map" Tipo:"DP"</summary>
		[Display(Name = "REAL_STATE_MAP58776", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Propr> ValPropried { get; set; }


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

		public string ValCodcntry { get; set; }

		public Pais_ViewModel() : base("FPAIS") { }

		public Pais_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPAIS", currentNavigation, nestedForm) { }

		public Pais_ViewModel(Models.Cntry row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPAIS", row, currentNavigation, nestedForm) { }

		public Pais_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cntry", id);
			Model = Models.Cntry.Find(id, "FPAIS", fieldsToQuery: fieldsToLoad);
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
			Models.Cntry model = new Models.Cntry() { Identifier = "FPAIS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cntry model)
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

		public static StatusMessage DeleteConditions(Models.Cntry model)
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

		public static StatusMessage ViewConditions(Models.Cntry model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cntry model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cntry m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cntry) to ViewModel (Pais) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValCountry = ViewModelConversion.ToString(m.ValCountry);
 				ValActive = ViewModelConversion.ToLogic(m.ValActive);
 				ValCodigonr = ViewModelConversion.ToString(m.ValCodigonr);
 				ValAlfa2 = ViewModelConversion.ToString(m.ValAlfa2);
 				ValAlfa3 = ViewModelConversion.ToString(m.ValAlfa3);
 				ValFlag = ViewModelConversion.ToImage(m.ValFlag);
 				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cntry) to ViewModel (Pais) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cntry m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pais) to Model (Cntry) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCountry = ViewModelConversion.ToString(ValCountry);
				m.ValActive = ViewModelConversion.ToLogic(ValActive);
				m.ValCodigonr = ViewModelConversion.ToString(ValCodigonr);
				m.ValAlfa2 = ViewModelConversion.ToString(ValAlfa2);
				m.ValAlfa3 = ViewModelConversion.ToString(ValAlfa3);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pais) to Model (Cntry) - Error during mapping");
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
				Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), "FPAIS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cntry() { Identifier = "FPAIS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");
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

			Model.Identifier = "FPAIS";
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

		protected override void LoadDocumentsProperties(Models.Cntry row)
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
				Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), "FPAIS");
				if (Model == null)
				{
					Model = new Models.Cntry() { Identifier = "FPAIS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PAIS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PAIS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PAIS]/
		public override void Save()
		{

			try { Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), "FPAIS"); }
			finally { if (Model == null) Model = new Models.Cntry() { Identifier = "FPAIS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PAIS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cntry.Find(Navigation.GetStrValue("cntry"), "FPAIS"); }
			finally { if (Model == null) Model = new Models.Cntry() { Identifier = "FPAIS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PAIS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PAIS]/
		public override void Destroy(string id)
		{
			Model = Models.Cntry.Find(id, "FPAIS");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PAIS]/
		#endregion
	}
}
