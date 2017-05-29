using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClubUkolova.Core;
using SportClubUkolova.Models;

namespace SportClubUkolova.Controllers
{
    public class PlaceController : Controller
    {
        IPlaceRepository placeRepository = new PlaceRepository();

        public ActionResult Index()
        {
            var places = placeRepository.GetAllPlaces();
            return View(places);
        }

        [HttpGet]
        public ActionResult AddPlace()
        {
            return View("AddPlace");
        }

        public ActionResult AddPlace(PlaceModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                placeRepository.AddNewPlace(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditPlace(int placeId)
        {
            var place = placeRepository.GetPlaceById(placeId);
            return View("EditPlace", place);
        }

        public ActionResult SaveChanges(PlaceModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                placeRepository.EditPlace(model);
            }
            return RedirectToAction("Index");
        }
    }
}
