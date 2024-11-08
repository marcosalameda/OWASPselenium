using System;
using System.Web.Mvc;
using GenioMVC.ViewModels;
using GenioMVC.Models.Navigation;
using CSGenio.framework;
using CSGenio.business;
using System.Collections.Generic;
using System.Linq;

namespace GenioMVC.Controllers
{
    public class SuggestionController : ControllerBase
    {
        public ActionResult Index(string id, string label, string help, string arrayName)
        {
            var model = new SuggestionViewModel(arrayName, UserContext.Current.User.Language)
            {
                NewLabel = label,
                NewHelp = help,
                FieldId = id
            };

            string location = GetCurrentLocation();
            Collaboration collab = Collaboration.ReadXml(location);

            if (string.IsNullOrEmpty(id))
            {
                OpenSuggestion openSuggestion = collab.OpenSuggestions.FirstOrDefault(x => x.IsSame(BuildOpenSuggestion("")));

                if (openSuggestion != null)
                {
                    model.SuggestionText = openSuggestion.SuggestionText;
                    return PartialView(model);
                }
            }

            FieldSuggestion suggestion = collab.FieldSuggestions.FirstOrDefault(x => x.IsSame(BuildFieldSuggestion(id)));
            if (suggestion != null)
            {
                if (!string.IsNullOrEmpty(suggestion.NewLabel))
                {
                    model.NewLabel = suggestion.NewLabel;
                }
                if (!string.IsNullOrEmpty(suggestion.NewHelp))
                {
                    model.NewHelp = suggestion.NewHelp;
                }
            }

            var arraySuggestions = collab.ArrayElementSuggestions.FindAll(x => x.ArrayName == arrayName);
            foreach(var arraySuggestion in arraySuggestions)
            {
                var element = model.Elements.Find(x => x.Id == arraySuggestion.ElementId);
                if (!string.IsNullOrEmpty(arraySuggestion.NewLabel))
                {
                    element.NewLabel = arraySuggestion.NewLabel;
                }
                if (!string.IsNullOrEmpty(arraySuggestion.NewHelp))
                {
                    element.NewHelp = arraySuggestion.NewHelp;
                }
            }

            TempData["Label"] = label;
            TempData["Help"] = help;
            TempData["FieldId"] = id;
            for(int i = 0; i < model.Elements.Count; i++)
            {
                var element = model.Elements[i];
                TempData[$"Elements[{i}].Label"] = element.NewLabel;
                TempData[$"Elements[{i}].Help"] = element.NewHelp;
            }
            return PartialView(model);
        }

        [Helpers.Attributes.ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult List()
        {
            string currentUser = UserContext.Current.User.Name;
            string currentLocation = GetCurrentLocation();
            var model = new SuggestionListViewModel(currentUser, currentLocation);
            return PartialView("List", model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var openSuggestion = BuildOpenSuggestion(form);

            var suggestionsArray = BuildArraySuggestions(form);

            FieldSuggestion fieldSuggestion = BuildFieldSuggestion(form);
            if (fieldSuggestion == null && suggestionsArray.Count == 0 && openSuggestion == null)
            {
                return Json(new { Success = false, Message = Resources.Resources.THERE_ARE_NO_CHANGES03560 });
            }
            try
            {
                string location = GetCurrentLocation();
                Collaboration collaboration = Collaboration.ReadXml(location);
                foreach(var suggestion in suggestionsArray)
                {
                    collaboration.Add(suggestion);
                }
                if (fieldSuggestion != null)
                    collaboration.Add(fieldSuggestion);
                if (openSuggestion != null)
                    collaboration.Add(openSuggestion);
                collaboration.SaveXml(location);
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = Resources.Resources.ERROR_SAVING_SUGGEST51018 });
            }
            return Json(new { Success = true, Message = Resources.Resources.SUGGESTION_WAS_SAVED24194 });
        }

        [HttpPost]
        public ActionResult Save(SuggestionViewModel model)
        {
            var openSuggestion = (model.SuggestionText == null ? null : BuildOpenSuggestion(model.SuggestionText));
            var suggestionsArray = BuildArraySuggestions(model);
            FieldSuggestion fieldSuggestion = BuildFieldSuggestion(model);

            if (fieldSuggestion == null && suggestionsArray.Count == 0 && openSuggestion == null)
            {
                return Json(new { Success = false, Message = Resources.Resources.THERE_ARE_NO_CHANGES03560 });
            }
            try
            {
                string location = GetCurrentLocation();
                Collaboration collaboration = Collaboration.ReadXml(location);
                foreach (var suggestion in suggestionsArray)
                {
                    collaboration.Add(suggestion);
                }
                if (fieldSuggestion != null)
                    collaboration.Add(fieldSuggestion);
                if (openSuggestion != null)
                    collaboration.Add(openSuggestion);
                collaboration.SaveXml(location);
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = Resources.Resources.ERROR_SAVING_SUGGEST51018 });
            }
            return Json(new { Success = true, Message = Resources.Resources.SUGGESTION_WAS_SAVED24194 });
        }

        /// <summary>
        /// Returns the current location, independently of being in edition or show mode
        /// </summary>
        private string GetCurrentLocation()
        {
            string location = Navigation.CurrentLevel.Location.Action;
            if (location.EndsWith("_Edit") || location.EndsWith("_Show"))
                return location.Substring(0, location.Length - 5);
            else
                return location;
        }

        private FieldSuggestion BuildFieldSuggestion(string id)
        {
            var user = UserContext.Current.User;
            FieldSuggestion suggestion = new FieldSuggestion
            {
                FieldId = id,
                User = user.Name,
                Language = user.Language,
                Date = DateTime.Now,
                Location = GetCurrentLocation()
            };
            return suggestion;
        }

        private OpenSuggestion BuildOpenSuggestion(FormCollection form)
        {
            string text = form["SuggestionText"] as string;
            if (text == null)
                return null;

            return BuildOpenSuggestion(text);
        }

        private OpenSuggestion BuildOpenSuggestion(string text)
        {
            var user = UserContext.Current.User;
            OpenSuggestion suggestion = new OpenSuggestion
            {
                User = user.Name,
                Language = user.Language,
                Date = DateTime.Now,
                Location = GetCurrentLocation(),
                SuggestionText = text
            };
            return suggestion;
        }

        private FieldSuggestion BuildFieldSuggestion(FormCollection form)
        {
            string oldLabel = TempData["Label"] as string ?? "";
            string oldHelp = TempData["Help"] as string ?? "";
            string newLabel = form["NewLabel"];
            string newHelp = form["NewHelp"];

            if (oldLabel == newLabel && oldHelp == newHelp)
                return null;

            string id = TempData["FieldId"] as string;

            var suggestion = BuildFieldSuggestion(id);

            if (oldLabel != newLabel)
            {
                suggestion.OldLabel = oldLabel;
                suggestion.NewLabel = newLabel;
            }
            if (oldHelp != newHelp)
            {
                suggestion.OldHelp = oldHelp;
                suggestion.NewHelp = newHelp;
            }
            return suggestion;
        }

        private FieldSuggestion BuildFieldSuggestion(SuggestionViewModel model)
        {
            string oldLabel = TempData["Label"] as string ?? "";
            string oldHelp = TempData["Help"] as string ?? "";
            string newLabel = model.NewLabel;
            string newHelp = model.NewHelp;

            if (oldLabel == newLabel && oldHelp == newHelp)
                return null;

            string id = TempData["FieldId"] as string;

            var suggestion = BuildFieldSuggestion(id);

            if (oldLabel != newLabel)
            {
                suggestion.OldLabel = oldLabel;
                suggestion.NewLabel = newLabel;
            }
            if (oldHelp != newHelp)
            {
                suggestion.OldHelp = oldHelp;
                suggestion.NewHelp = newHelp;
            }
            return suggestion;
        }

        private List<ArrayElementSuggestion> BuildArraySuggestions(FormCollection form)
        {
            string arrayName = form["ArrayName"];
            List<ArrayElementSuggestion> elements = new List<ArrayElementSuggestion>();
            if (String.IsNullOrEmpty(arrayName))
            {
                return elements;
            }
            ArrayInfo arrayInfo = new ArrayInfo(arrayName);
            var user = UserContext.Current.User;
            for (int i=0; i < arrayInfo.Elements.Count; i++)
            {
                string id = arrayInfo.Elements[i];
                string oldLabel = arrayInfo.GetDescription(id, user.Language);
                string oldHelp = arrayInfo.GetHelp(id, user.Language);
                string newLabel = form[$"Elements[{i}].NewLabel"] ?? "";
                string newHelp = form[$"Elements[{i}].NewHelp"] ?? "";

                if (oldLabel == newLabel && oldHelp == newHelp)
                    continue;

                ArrayElementSuggestion suggestion = new ArrayElementSuggestion
                {
                    ArrayName = arrayName,
                    ElementId = id,
                    User = user.Name,
                    Language = user.Language,
                    Date = DateTime.Now
                };

                if (oldLabel != newLabel)
                {
                    suggestion.NewLabel = newLabel;
                }
                if (oldHelp != newHelp)
                {
                    suggestion.OldHelp = oldHelp;
                    suggestion.NewHelp = newHelp;
                }
                suggestion.OldLabel = oldLabel;
                elements.Add(suggestion);
            }
            return elements;
        }

        private List<ArrayElementSuggestion> BuildArraySuggestions(SuggestionViewModel model)
        {
            List<ArrayElementSuggestion> elements = new List<ArrayElementSuggestion>();
            if (String.IsNullOrEmpty(model.ArrayName))
                return elements;

            ArrayInfo arrayInfo = new ArrayInfo(model.ArrayName);
            var user = UserContext.Current.User;
            for (int i=0; i < arrayInfo.Elements.Count; i++)
            {
                string id = arrayInfo.Elements[i];
                string oldLabel = arrayInfo.GetDescription(id, user.Language);
                string oldHelp = arrayInfo.GetHelp(id, user.Language);
                string newLabel = model.Elements[i].NewLabel ?? "";
                string newHelp = model.Elements[i].NewHelp ?? "";

                if (oldLabel == newLabel && oldHelp == newHelp)
                    continue;

                ArrayElementSuggestion suggestion = new ArrayElementSuggestion
                {
                    ArrayName = model.ArrayName,
                    ElementId = id,
                    User = user.Name,
                    Language = user.Language,
                    Date = DateTime.Now
                };

                if (oldLabel != newLabel)
                {
                    suggestion.NewLabel = newLabel;
                }
                if (oldHelp != newHelp)
                {
                    suggestion.OldHelp = oldHelp;
                    suggestion.NewHelp = newHelp;
                }
                suggestion.OldLabel = oldLabel;
                elements.Add(suggestion);
            }
            return elements;
        }
    }
}
