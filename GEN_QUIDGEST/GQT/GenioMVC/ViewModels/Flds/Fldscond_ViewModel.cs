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

namespace GenioMVC.ViewModels.Flds
{
	public class Fldscond_ViewModel : FormViewModel<Models.Flds>
	{
		public override bool HasWriteConditions { get => true; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Field state" Tipo:"AC"</summary>
		[Display(Name = "FIELD_STATE03599", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Acondtst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValCond { get; set; }
		[JsonIgnore]
		public SelectList List_ValCond { get; set; }

		/// <summary>Campo : "Cumprir condições da tabela" Tipo:"L"</summary>
		[Display(Name = "CUMPRIR_CONDICOES_DA06337", ResourceType = typeof(Resources.Resources))]
		public bool ValTblcond { get; set; }

		/// <summary>Campo : "Cumprir condições do formulário" Tipo:"L"</summary>
		[Display(Name = "CUMPRIR_CONDICOES_DO41487", ResourceType = typeof(Resources.Resources))]
		public bool ValFormcond { get; set; }

		/// <summary>Campo : "Campo com condições client-side" Tipo:"C"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_42569", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFclient1 { get; set; }

		/// <summary>Campo : "Campo com condição de Preenchimento" Tipo:"C"</summary>
		[Display(Name = "CAMPO_COM_CONDICAO_D59708", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFfillwhn { get; set; }

		/// <summary>Campo : "Campo com condições server-side" Tipo:"DT"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_22485", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValFserver1 { get; set; }

		/// <summary>Campo : "Campo com condições client-side" Tipo:"L"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_42569", ResourceType = typeof(Resources.Resources))]
		public bool ValFclient2 { get; set; }

		/// <summary>Campo : "Campo com condições server-side" Tipo:"N"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_22485", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N2}" )]
		[NumericAttribute(2)]
		public decimal? ValFserver2 { get; set; }

		/// <summary>Campo : "Campo com condições client-side" Tipo:"IB"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_42569", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValFclient3", false, false, false, false, DocumentViewTypeMode.Preview)]
		public string ValFclient3 { get; set; }
		public string ValFclient3fk { get; set; }
		public DocumsProperties_ViewModel ValFclient3PropertiesVM { get; set; }

		/// <summary>Campo : "Campo com condições server-side" Tipo:"IJ"</summary>
		[Display(Name = "CAMPO_COM_CONDICOES_22485", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 30, 100, false, true)]
		public byte[] ValFserver3 { get; set; }


		/// <summary>Campo : "" Tipo:"DN"</summary>
		public GridTableList<GenioMVC.ViewModels.Feeca.Fldscondpseudgridtbl__ViewModel> ValGridtbl { get; set; }

		/// <summary>Campo : "" Tipo:"DP"</summary>
		public TablePartial<GenioMVC.Models.Feeca> ValListtbl { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodaero { get; set; }

		public string ValCodequip { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Description" Tipo: "MO"</summary>
		[AllowHtml]
		public string ValDescrip { get; set; }
		#endregion

		public string ValCodflds { get; set; }

		public Fldscond_ViewModel() : base("FFLDSCOND") { }

		public Fldscond_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFLDSCOND", currentNavigation, nestedForm) { }

		public Fldscond_ViewModel(Models.Flds row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFLDSCOND", row, currentNavigation, nestedForm) { }

		public Fldscond_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, "FFLDSCOND", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds() { Identifier = "FFLDSCOND" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Flds model)
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

		public static StatusMessage DeleteConditions(Models.Flds model)
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

		public static StatusMessage ViewConditions(Models.Flds model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Flds model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Flds areaFlds = model;
			try
			{
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(GenioMVC.Models.Navigation.UserContext.Current.User,"A"))
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFserver2).isEmptyValue(model.ValFserver2))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFclient3).isEmptyValue(model.ValFclient3))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(GenioMVC.Models.Navigation.UserContext.Current.User,"A"))
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFserver3).isEmptyValue(model.ValFserver3))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFclient2).isEmptyValue(model.ValFclient2))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FFLDSCOND access condition: {exc.Message}");
				throw exc;
			}
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
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fldscond) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValCond = ViewModelConversion.ToString(m.ValCond);
 				ValTblcond = ViewModelConversion.ToLogic(m.ValTblcond);
 				ValFormcond = ViewModelConversion.ToLogic(m.ValFormcond);
 				ValFclient1 = ViewModelConversion.ToString(m.ValFclient1);
 				ValFfillwhn = ViewModelConversion.ToString(m.ValFfillwhn);
 				ValFserver1 = ViewModelConversion.ToDateTime(m.ValFserver1);
 				ValFclient2 = ViewModelConversion.ToLogic(m.ValFclient2);
 				ValFserver2 = ViewModelConversion.ToNumeric(m.ValFserver2);
 				ValFclient3 = ViewModelConversion.ToString(m.ValFclient3);
				ValFclient3fk = ViewModelConversion.ToString(m.ValFclient3fk);
 				ValFserver3 = ViewModelConversion.ToImage(m.ValFserver3);
 				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
 				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
 				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fldscond) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fldscond) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCond = ViewModelConversion.ToString(ValCond);
				m.ValTblcond = ViewModelConversion.ToLogic(ValTblcond);
				m.ValFormcond = ViewModelConversion.ToLogic(ValFormcond);
				m.ValFclient1 = ViewModelConversion.ToString(ValFclient1);
				m.ValFfillwhn = ViewModelConversion.ToString(ValFfillwhn);
				m.ValFserver1 = ViewModelConversion.ToDateTime(ValFserver1);
				m.ValFclient2 = ViewModelConversion.ToLogic(ValFclient2);
				m.ValFserver2 = ViewModelConversion.ToNumeric(ValFserver2);
				m.ValFclient3 = ViewModelConversion.ToString(ValFclient3);
				m.ValFclient3fk = ViewModelConversion.ToString(ValFclient3fk);

				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fldscond) to Model (Flds) - Error during mapping");
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFLDSCOND");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Flds() { Identifier = "FFLDSCOND" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
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

			Model.Identifier = "FFLDSCOND";
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

		protected override void LoadDocumentsProperties(Models.Flds row)
		{
			try
			{
				ValFclient3PropertiesVM = row.GetInfoDoc("ValFclient3");
			}
			catch (Exception)
			{
				ValFclient3PropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
			}
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFLDSCOND");
				if (Model == null)
				{
					Model = new Models.Flds() { Identifier = "FFLDSCOND" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FLDSCOND]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FLDSCOND]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FLDSCOND]/
		public override void Save()
		{
			try
			{
				this.ValGridtbl?.Save();
			}
			catch (FieldValidationException fvExc)
			{
				var sMsg = StatusMessage.Error();
				foreach (var message in fvExc.StatusMessage.GetErrorList())
					sMsg.MergeStatusMessage(new StatusMessage(message.Status, message.Message, string.Format("Gridtbl.{0}", message.Origin)));

				throw new FieldValidationException(sMsg, fvExc.ExceptionSite);
			}

			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFLDSCOND"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FFLDSCOND" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FLDSCOND]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Flds.Find(Navigation.GetStrValue("flds"), "FFLDSCOND"); }
			finally { if (Model == null) Model = new Models.Flds() { Identifier = "FFLDSCOND" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FLDSCOND]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FLDSCOND]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, "FFLDSCOND");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValCond = new SelectList(
				ArrayAcondtst.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValCond);
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FLDSCOND]/
		#endregion
	}
}
