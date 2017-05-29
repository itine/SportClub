using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClubUkolova.Core;
using SportClubUkolova.Models;

namespace SportClubUkolova.Controllers
{
    public class SportController : Controller
    {
        ISportRepository sportRepository = new SportRepository();

        public ActionResult Index()
        {
            var sports = sportRepository.GetAllSports();
            return View(sports);
        }

        [HttpGet]
        public ActionResult SportAdding()
        {
            return View("SportAdding");
        }

        public ActionResult SportAdding(SportModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                sportRepository.AddNewSport(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditSport(int sportId)
        {
            var sport = sportRepository.GetSportById(sportId);
            return View("EditSport", sport);
        }

        public ActionResult SaveChanges(SportModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                sportRepository.EditSportInfo(model);
            }
            return RedirectToAction("Index");
        }
    }
}
