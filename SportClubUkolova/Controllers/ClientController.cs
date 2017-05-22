using SportClubUkolova.Core;
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

    }
}
