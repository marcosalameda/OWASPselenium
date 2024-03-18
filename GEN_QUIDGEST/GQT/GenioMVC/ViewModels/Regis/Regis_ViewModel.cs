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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Regis
{
	public class Regis_ViewModel : FormViewModel<Models.Regis>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Tax ID No:" Tipo:"C"</summary>
		[Display(Name = "TAX_ID_NO_58377", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValNif { get; set; }

		/// <summary>Campo : "Telephone" Tipo:"C"</summary>
		[Display(Name = "TELEPHONE28697", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTelephon { get; set; }

		/// <summary>Campo : "Email:" Tipo:"C"</summary>
		[Display(Name = "EMAIL_44228", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail1 { get; set; }

		/// <summary>Campo : "Alternative Email" Tipo:"C"</summary>
		[Display(Name = "ALTERNATIVE_EMAIL17444", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail2 { get; set; }


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

		public string ValCodregis { get; set; }

		public Regis_ViewModel() : base("FREGIS") { }

		public Regis_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIS", currentNavigation, nestedForm) { }

		public Regis_ViewModel(Models.Regis row, NavigationContext currentNavigation, bool nestedForm = false) : base("FREGIS", row, currentNavigation, nestedForm) { }

		public Regis_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("regis", id);
			Model = Models.Regis.Find(id, "FREGIS", fieldsToQuery: fieldsToLoad);
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
			Models.Regis model = new Models.Regis() { Identifier = "FREGIS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Regis model)
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

		public static StatusMessage DeleteConditions(Models.Regis model)
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

		public static StatusMessage ViewConditions(Models.Regis model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Regis model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Regis m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Regis) to ViewModel (Regis) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValNif = ViewModelConversion.ToString(m.ValNif);
 				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
 				ValEmail1 = ViewModelConversion.ToString(m.ValEmail1);
 				ValEmail2 = ViewModelConversion.ToString(m.ValEmail2);
 				ValCodregis = ViewModelConversion.ToString(m.ValCodregis);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Regis) to ViewModel (Regis) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Regis m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regis) to Model (Regis) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValNif = ViewModelConversion.ToString(ValNif);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail1 = ViewModelConversion.ToString(ValEmail1);
				m.ValEmail2 = ViewModelConversion.ToString(ValEmail2);
				m.ValCodregis = ViewModelConversion.ToString(ValCodregis);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regis) to Model (Regis) - Error during mapping");
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
				Model = Models.Regis.Find(Navigation.GetStrValue("regis"), "FREGIS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Regis() { Identifier = "FREGIS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("regis");
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

			Model.Identifier = "FREGIS";
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

		protected override void LoadDocumentsProperties(Models.Regis row)
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
				Model = Models.Regis.Find(Navigation.GetStrValue("regis"), "FREGIS");
				if (Model == null)
				{
					Model = new Models.Regis() { Identifier = "FREGIS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("regis");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGIS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGIS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REGIS]/
		public override void Save()
		{

			try { Model = Models.Regis.Find(Navigation.GetStrValue("regis"), "FREGIS"); }
			finally { if (Model == null) Model = new Models.Regis() { Identifier = "FREGIS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGIS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Regis.Find(Navigation.GetStrValue("regis"), "FREGIS"); }
			finally { if (Model == null) Model = new Models.Regis() { Identifier = "FREGIS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGIS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGIS]/
		public override void Destroy(string id)
		{
			Model = Models.Regis.Find(id, "FREGIS");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIS]/
		#endregion
	}
}
