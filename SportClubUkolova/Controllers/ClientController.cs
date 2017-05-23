using DataModel.Models;
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

        [HttpGet]
        public ActionResult ClientRegistration()
        {
            return View("ClientRegistration");
        }

        public ActionResult ClientRegistration(ClientModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                clientRepo.ClientRegistration(model);
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult EditClient(int clientId)
        {
            var client = clientRepo.GetClientById(clientId);
            return View("EditClientData", client);
        }

        public ActionResult SaveChanges(ClientModel model)
        {
            if(model != null && ModelState.IsValid)
            {
                clientRepo.EditClientInfo(model);
            }
            return RedirectToAction("Index");
        }
    }
}
