using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels
{
	public class RegisterViewModel : ViewModelBase
	{
		public object FormData { get; set; }

		public string partialView { get; set; }

		public string partialViewJS { get; set; }

		public string redirect { get; set; }

		public string DivID { get; set; }

		public int FormDataOrdem { get; set; }

		public int FormPswOrdem { get; set; }

		public object FormPswData { get; set; }

		public string PswpartialView { get; set; }

		public string Pswredirect { get; set; }

		public string PswDivID { get; set; }
	}
}
