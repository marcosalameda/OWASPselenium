using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Flds;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		private IChatbotService _aiService;
		public FldsController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION FLDS]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAflds>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER FLDS]/

		[HttpPost]
		public JsonResult ReloadDBEdit([FromBody]RequestReloadDBEditModel requestModel)
		{
			var Identifier = requestModel.Identifier ?? "";
			var qs = new NameValueCollection();
			qs.AddRange(Request.Query);
			// The value of the lookup search field comes in 'Values'
			if (requestModel.Values != null)
				qs.AddRange(requestModel.Values);
			this.IsStateReadonly = true;

			dynamic result = null;
			/*
				Instead of loading the entire record from the database, a record will be created in memory with the keys filled in,
					and additional fields from "Field" type limits will be mapped later.
				This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
			*/
			Models.Flds row = new Models.Flds(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("flds");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "CAMPO___AERO_NAME____":	// Field (DB)
						{
							var model = new Campo_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Campo___aero_name____(qs);
							result = model.TableAeroName;
						}
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
						{
							var model = new Fieldhlp_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Fieldhlpaero_name____(qs);
							result = model.TableAeroName;
						}
						break;
					case "FLDSTBL_AERO_NAME____":	// Field (DB)
						{
							var model = new Fldstbl_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Fldstbl_aero_name____(qs);
							result = model.TableAeroName;
						}
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{
				return JsonERROR("On Reload form field: " + Identifier);
			}

			if (result != null)
				return JsonOK(new { List = result.List, TotalRows = result.Pagination.TotalRows, Selected = result.Selected, Value = result.Value });
			return JsonERROR("Not found any valid result");
		}

		[HttpPost]
		public JsonResult GetDependants([FromBody]RequestDependantsModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var Selected = requestModel.Selected;

			ConcurrentDictionary<string, object> values = null;
			this.IsStateReadonly = true;

			try
			{
				// Only the last reload request is accepted.
				var requestNumber = Request.Headers["GetDependantsRequestNumber"];
				if (requestNumber != StringValues.Empty)
					Response.Headers["GetDependantsRequestNumber"] = requestNumber.First();

				UserContext.Current.PersistentSupport.openConnection();
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "CAMPO___AERO_NAME____":	// Field (DB)
						values = new Campo_ViewModel(UserContext.Current).GetDependant_CampoTableAeroName(Selected);
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
						values = new Fieldhlp_ViewModel(UserContext.Current).GetDependant_FieldhlpTableAeroName(Selected);
						break;
					case "FLDSTBL_AERO_NAME____":	// Field (DB)
						values = new Fldstbl_ViewModel(UserContext.Current).GetDependant_FldstblTableAeroName(Selected);
						break;
					default: break;
				}

				if (values == null || !values.Any())
					return JsonERROR("List is empty");

				// Remove DateTime.MinValue
				foreach (KeyValuePair<string, object> field in values)
					if (field.Value is DateTime && (DateTime)field.Value == DateTime.MinValue)
						values.TryUpdate(field.Key, "", DateTime.MinValue);

				// TODO: Sanitize HTML content
				return JsonOK(values);
			}
			catch (Exception)
			{
				return JsonERROR("On Get Dependants - " + Identifier);
			}
			finally
			{
				UserContext.Current.PersistentSupport.closeConnection();
			}
		}





		/// <summary>
		/// Recalculate formulas of the "Campo" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Campo([FromBody]Campo_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FCAMPO"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Fieldhlp" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fieldhlp([FromBody]Fieldhlp_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FFIELDHLP"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}

		// POST: /Flds/FLDSCOND_FLDS_FSERVER1_ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDS_FSERVER1_ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDS_FSERVER1_BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDS_FSERVER1_BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER2_ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER2_ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER2_BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER2_BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER3_ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER3_ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER3_BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER3_BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDS_FSERVER3_ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDS_FSERVER3_ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDS_FSERVER3_BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDS_FSERVER3_BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDPSEUDSTATICTX_ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDPSEUDSTATICTX_ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDPSEUDSTATICTX_BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDPSEUDSTATICTX_BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDPSEUDLISTBTN__ShowWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDPSEUDLISTBTN__ShowWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE") && HasRole("A")
				var result = !(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="HIDE")&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDPSEUDLISTBTN__BlockWhen
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDPSEUDLISTBTN__BlockWhen([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
				// the values coming from the client-side will be accepted as valid, since they won't be saved and are only being used for calculation.
				formData.DisableUserValuesSecurity();
				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK" && HasRole("A")
				var result = !(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A");
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}
		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER1_RequiredCondition
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER1_RequiredCondition([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if ((Logical)(!(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
					return JsonOK(true);

				return JsonOK(false);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER2_RequiredCondition
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER2_RequiredCondition([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if ((Logical)(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
					return JsonOK(true);

				return JsonOK(false);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Flds/FLDSCOND_FLDSCONDFLDS_FSERVER3_RequiredCondition
		[HttpPost]
		public JsonResult FLDSCOND_FLDSCONDFLDS_FSERVER3_RequiredCondition([FromBody] ViewModels.Flds.Fldscond_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Flds(UserContext.Current);

				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if ((Logical)(!(((Logical)p.ValTblcond) == 0)&&((string)p.ValCond)=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
					return JsonOK(true);
				// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if ((Logical)(!(((Logical)p.ValFormcond) == 0)&&((string)p.ValCond)=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
					return JsonOK(true);

				return JsonOK(false);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}


		/// <summary>
		/// Recalculate formulas of the "Fldscond" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fldscond([FromBody]Fldscond_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FFLDSCOND"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Fldstbl" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fldstbl([FromBody]Fldstbl_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FFLDSTBL"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Infields" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Infields([FromBody]Infields_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FINFIELDS"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Listacam" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Listacam([FromBody]Listacam_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FLISTACAM"),
				(model) => formData.MapToModel(model as Models.Flds)
			);
		}

		/// <summary>
		/// Get "See more..." tree structure
		/// </summary>
		/// <returns></returns>
		public JsonResult GetTreeSeeMore([FromBody]RequestLookupModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var queryParams = requestModel.QueryParams;

			try
			{
				// We need the request values to apply filters
				var requestValues = new NameValueCollection();
				if (queryParams != null)
					foreach (var kv in queryParams)
						requestValues.Add(kv.Key, kv.Value);

				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					default:
						break;
				}
			}
			catch (Exception)
			{
				return Json(new { Success = false, Message = "Error" });
			}

			return Json(new { Success = false, Message = "Error" });
		}

		/// <summary>
		/// Gets the necessary tickets to interact with the given document
		/// </summary>
		/// <param name="requestModel">The request model with the table, field and the primary key of the record</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetDocumsTickets([FromBody] RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets("FLDS", requestModel.FieldName, requestModel.KeyValue);
		}

		/// <summary>
		/// Gets the versions of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileVersions([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileVersions(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the properties of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileProperties([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileProperties(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the binary file associated to the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket and view type</param>
		/// <returns>A File object with the content of the document</returns>
		public ActionResult GetFile([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFile(requestModel.Ticket, requestModel.ViewType);
		}

		/// <summary>
		/// Changes the state/properties of a given document
		/// </summary>
		/// <param name="requestModel">The request model with a list of changes</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFilesState([FromBody] RequestDocumsChangeModel requestModel)
		{
			return base.SetFilesState(requestModel.Documents);
		}
	}
}
