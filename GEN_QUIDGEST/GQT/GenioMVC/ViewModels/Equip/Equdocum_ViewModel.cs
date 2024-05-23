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
	public class Equdocum_ViewModel : FormViewModel<Models.Equip>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Designation" Tipo:"C"</summary>
		[Display(Name = "DESIGNATION35876", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }


		/// <summary>Campo : "Digital Attachements" Tipo:"DP"</summary>
		[Display(Name = "DIGITAL_ATTACHEMENTS44886", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Anexd> ValLisanex { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodempre { get; set; }

		public string ValCoddeco { get; set; }

		public string ValCoditem { get; set; }

		public string ValCodpess1 { get; set; }

		public string ValCodtpequ { get; set; }

		public string ValCodwareh { get; set; }

		public string ValCodrooms { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "No. register" Tipo: "C"</summary>
		[AllowHtml]
		public string ValRegistnr { get; set; }
		// Field to formula
		/// <summary>Used only for lazy loading of the ItemValItemdes field</summary>
		[Newtonsoft.Json.JsonIgnore]
		public Func<string> funcItemValItemdes { get; set; }
		private string _auxItemValItemdes { get; set; }
		/// <summary>Field : "Article" Tipo: "C"</summary>
		[AllowHtml]
		public string ItemValItemdes { get { return funcItemValItemdes != null ? funcItemValItemdes() : _auxItemValItemdes; } set { funcItemValItemdes = () => value;} }
		#endregion

		public string ValCodequip { get; set; }

		public Equdocum_ViewModel() : base("FEQUDOCUM") { }

		public Equdocum_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUDOCUM", currentNavigation, nestedForm) { }

		public Equdocum_ViewModel(Models.Equip row, NavigationContext currentNavigation, bool nestedForm = false) : base("FEQUDOCUM", row, currentNavigation, nestedForm) { }

		public Equdocum_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, "FEQUDOCUM", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip() { Identifier = "FEQUDOCUM" };
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
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equdocum) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
 				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
 				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
 				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
 				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
 				funcItemValItemdes = () => ViewModelConversion.ToString(m.Item.ValItemdes);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equdocum) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equdocum) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equdocum) to Model (Equip) - Error during mapping");
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUDOCUM");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Equip() { Identifier = "FEQUDOCUM" };
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

			Model.Identifier = "FEQUDOCUM";
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUDOCUM");
				if (Model == null)
				{
					Model = new Models.Equip() { Identifier = "FEQUDOCUM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUDOCUM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUDOCUM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EQUDOCUM]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUDOCUM"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUDOCUM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUDOCUM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), "FEQUDOCUM"); }
			finally { if (Model == null) Model = new Models.Equip() { Identifier = "FEQUDOCUM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUDOCUM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUDOCUM]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, "FEQUDOCUM");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUDOCUM]/
		#endregion
	}
}
