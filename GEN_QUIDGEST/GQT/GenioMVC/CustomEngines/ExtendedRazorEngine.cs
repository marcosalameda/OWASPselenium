using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.CustomEngines
{
    public class ExtendedRazorEngine : RazorViewEngine
    {
        public void AddViewLocationFormat(string path)
        {
            List<string> existingPaths = new List<string>(ViewLocationFormats);
            if(!existingPaths.Contains(path))
                existingPaths.Add(path);

            ViewLocationFormats = existingPaths.ToArray();
        }

        public void AddPartialViewLocationFormat(string path)
        {
            List<string> existingPaths = new List<string>(PartialViewLocationFormats);
            if(!existingPaths.Contains(path))
                existingPaths.Add(path);

            PartialViewLocationFormats = existingPaths.ToArray();
        }
		
		// JFG 07/04/2017 Layout per module disabled. This funcionality will be implement in the future in another way and place.
		/*
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var module = controllerContext.RouteData.Values["module"].ToString();
            var layout = GetLayoutForModule(module);
            return base.CreatePartialView(controllerContext, partialPath.Replace("%Layout", layout));
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var module = controllerContext.RouteData.Values["module"].ToString();
            var layout = GetLayoutForModule(module);
            return base.CreateView(controllerContext, viewPath.Replace("%Layout", layout), masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var module = controllerContext.RouteData.Values["module"].ToString();
            var layout = GetLayoutForModule(module);
            return base.FileExists(controllerContext, virtualPath.Replace("%Layout", layout));
        }

        private string GetLayoutForModule(string module)
        {
            switch (module)
            {
                case "GQT":
                case "PTN":
                case "TBS":
                case "REG":
                case "STY":
                default:
                    // Public
                    return "HorzMenu_WithHeader";
            }
        }
		*/
    }
}
