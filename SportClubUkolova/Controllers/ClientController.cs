using SportClubUkolova.Core;
using SportClubUkolova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClubUkolova.Controllers
{
    public class ClientController : Controller
    {

        IClientRepository clientRepo = new ClientRepository();

        public ActionResult Index()
        {
            var clients = clientRepo.GetAllClients();
            return View(clients);
        }

        public ActionResult ClientRegistration(ClientModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                clientRepo.ClientRegistration(model);
            }
            return RedirectToAction("Index");
        }

    }
}
