using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		private Models.WizardStep Vendaw_Fases_GetNextStep(Models.Sale p, string currentStep)
		{
			if (p == null)
			{
				p = new Models.Sale(m_userContext);
				p.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level);
			}

			Models.WizardStep nextStep = new Models.WizardStep();
			string errorStepMessage = "";

			switch (currentStep)
			{
				case "":
					nextStep = new Models.WizardStep("VENDAW01", "FASES", 1);
					break;
				case "wizard-step-FASES-1":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-2":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-3":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-4":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-5":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-6":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-7":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(errorStepMessage);
				case "wizard-step-FASES-8":
					errorStepMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
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
				model?.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level);
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
					model.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level);
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
	}
}
