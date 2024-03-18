using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;

namespace GenioMVC.Controllers
{
    public class MessagesController : ControllerBase
    {
        public ActionResult Index()
        {
            List<Message> messageList = new List<Message> { };
            String Id = Messages.getID(Navigation.NavigationId);

            if (TempData[Id] != null)
                messageList = TempData[Id] as List<Message>;

            Messages_ViewModel viewModel = new Messages_ViewModel(messageList);

            return PartialView("_Messages", viewModel);
        }
    }
}
