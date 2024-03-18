using System;
using System.Collections.Generic;
using System.Linq;

using CSGenio.business;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		private Models.WizardStep Vendaw_Fases_GetNextStep(Models.Sale p, string currentStep)
		{
			if (p == null)
			{
				p = new Models.Sale(m_userContext);
				p.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
			}

			Models.WizardStep nextStep = new Models.WizardStep();

			switch (currentStep)
			{
				case "":
					nextStep = new Models.WizardStep("VENDAW01", "FASES", 1);
					break;
				case "wizard-step-FASES-1":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValProspecc))==0)
					{
						nextStep = new Models.WizardStep("VENDAW02", "FASES", 2);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0)
					{
						nextStep = new Models.WizardStep("VENDAW03", "FASES", 3);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-2":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0)
					{
						nextStep = new Models.WizardStep("VENDAW03", "FASES", 3);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-3":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-4":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-5":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-6":
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-7":
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-8":
					CSGenio.framework.Log.Error("Wizard FASES - Forward action is disabled for step 'wizard-step-FASES-8'.");
					// Throw exception as the last step doesn't have a forward action.
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				default:
					CSGenio.framework.Log.Error("Wizard FASES - The specified step doesn't belong to wizard 'FASES'.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
			}

			return nextStep;
		}

		[ActionName("Vendaw_Fases_NextStep")]
		public JsonResult Vendaw_Fases_NextStep([FromBody]RequestWizardModel requestModel)
		{
			var formId = requestModel.FormId;
			var currentStep = requestModel.CurrentStep;
			try
			{
				var model = Models.Sale.Find(formId, UserContext.Current);
				model?.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
				Models.WizardStep nextStep = Vendaw_Fases_GetNextStep(model, currentStep);

				return JsonOK(new { Route = "form-VENDAW-" + nextStep.FormName });
			}
			catch (Exception e)
			{
				return JsonERROR(e.Message);
			}
		}

		private void Vendaw_Fases_CalculatePath(Models.Sale p, string step, ref IList<string> path)
		{
			try
			{
				Models.WizardStep nextStep = Vendaw_Fases_GetNextStep(p, step);
				bool isActive = false;

				switch (nextStep.StepId)
				{
					case "wizard-step-FASES-1":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValProspecc))==0&&CSGenio.business.GlobalFunctions.emptyG(((string)p.ValCodorgan))==0;
						break;
					case "wizard-step-FASES-2":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0;
						break;
					case "wizard-step-FASES-3":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0;
						break;
					case "wizard-step-FASES-4":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0;
						break;
					case "wizard-step-FASES-5":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0;
						break;
					case "wizard-step-FASES-6":
						isActive = CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0;
						break;
					case "wizard-step-FASES-7":
						isActive = CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0;
						break;
					case "wizard-step-FASES-8":
						break;
				}

				if (!string.IsNullOrWhiteSpace(nextStep.StepId))
					path.Add("form-VENDAW-" + nextStep.FormName);
				if (isActive)
					Vendaw_Fases_CalculatePath(p, nextStep.StepId, ref path);
			}
			catch { }
		}

		[ActionName("Vendaw_Fases_GetPath")]
		public JsonResult Vendaw_Fases_GetPath(string formId)
		{
			try
			{
				var model = Models.Sale.Find(formId, UserContext.Current);
				IList<string> path = new List<string>(8);

				if (model != null)
				{
					model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
					Vendaw_Fases_CalculatePath(model, "", ref path);
				}

				string nextStep;
				if (path.Any())
					nextStep = path.Last();
				else
					nextStep = "form-VENDAW-" + Vendaw_Fases_GetNextStep(model, "").FormName;

				return JsonOK(new { Path = path, NextStep = nextStep });
			}
			catch (Exception e)
			{
				return JsonERROR(e.Message);
			}
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw01_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw01_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw01_ViewModel model = new Vendaw01_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw01_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw01_ClearData",
				ViewName = "Vendaw01",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW01]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw02_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw02_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw02_ViewModel model = new Vendaw02_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw02_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw02_ClearData",
				ViewName = "Vendaw02",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW02]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw03_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw03_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw03_ViewModel model = new Vendaw03_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw03_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw03_ClearData",
				ViewName = "Vendaw03",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW03]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw04_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw04_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw04_ViewModel model = new Vendaw04_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw04_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw04_ClearData",
				ViewName = "Vendaw04",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW04]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw05_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw05_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw05_ViewModel model = new Vendaw05_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw05_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw05_ClearData",
				ViewName = "Vendaw05",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW05]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw06_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw06_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw06_ViewModel model = new Vendaw06_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw06_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw06_ClearData",
				ViewName = "Vendaw06",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW06]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw07_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw07_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw07_ViewModel model = new Vendaw07_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw07_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw07_ClearData",
				ViewName = "Vendaw07",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW07]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw08_ClearData")]
		public JsonResult Vendaw_Fases_Vendaw08_ClearData([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			bool isGoingBack = true;
			bool clearData = true;

			Vendaw08_ViewModel model = new Vendaw08_ViewModel(UserContext.Current, new Models.Sale(UserContext.Current));

			if (isGoingBack)
			{
				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model.ValCodvenda = id;
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw08_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model.Navigation.SetValue("isGoingBack", isGoingBack);
			model.Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw08_ClearData",
				ViewName = "Vendaw08",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW08]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}
	}
}
