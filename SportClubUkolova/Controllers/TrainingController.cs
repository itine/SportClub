using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClubUkolova.Core;
using SportClubUkolova.Models;

namespace SportClubUkolova.Controllers
{
    public class TrainingController : Controller
    {
        ITrainingRepository trainingRepository = new TrainingRepository();

        public ActionResult Index()
        {
            var trainings = trainingRepository.GetAllTrainings();
            return View(trainings);
        }

        [HttpGet]
        public ActionResult TrainingRegistration()
        {
            return View("TrainingRegistration");
        }

        public ActionResult TrainingRegistration(TrainingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                trainingRepository.TrainingRegistration(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditTraining(int trainingId)
        {
            var training = trainingRepository.GetTrainingById(trainingId);
            return View("EditTraining", training);
        }

        public ActionResult SaveChanges(TrainingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                trainingRepository.EditTraining(model);
            }
            return RedirectToAction("Index");
        }
    }
}
