using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public class TrainingRepository : ITrainingRepository
    {
       private SportsClubEntities1 edm = new SportsClubEntities1();
        public IEnumerable<TrainingModel> GetAllTrainings() => (from training in edm.Trainings
                                                            select new TrainingModel()
                                                            {
                                                                TrainingId = training.TrainingId,
                                                                TrainingDate = training.TrainingDate,
                                                                TrainingType = training.TrainingType,
                                                                Trainer = training.Trainer
                                                            }).ToList();

        public int TrainingRegistration(TrainingModel training)
        {
            //TODO: бизнес-логику делаем здесь или в контроллере??
            var trainingEntity = new Training()
            {
                TrainingType = training.TrainingType,
                Trainer = training.Trainer,
                TrainingDate = DateTime.UtcNow,
                TrainingId = training.TrainingId,
                Client = training.Client,
                Cost = 300,
                Place = training.Place,
                CountOfFreePlaces = training.CountOfFreePlaces--
            };
            edm.Trainings.Add(trainingEntity);
            return trainingEntity.TrainingId;
        }

        public int EditTraining(TrainingModel training)
        {
            var trainingEntity = edm.Trainings.FirstOrDefault(x => x.TrainingId == training.TrainingId);
            trainingEntity.Trainer = training.Trainer;
            trainingEntity.TrainingDate = DateTime.UtcNow;
            trainingEntity.TrainingType = training.TrainingType;
            trainingEntity.Client = training.Client;
            trainingEntity.Cost = training.Cost;
            trainingEntity.CountOfFreePlaces = training.CountOfFreePlaces;
            trainingEntity.Place = training.Place;
            edm.Trainings.Add(trainingEntity);
            edm.SaveChanges();
            return trainingEntity.TrainingId;
        }

        public int DeleteTraining(int trainingId)
        {
            var trainingEntity = edm.Trainings.Where(x => x.TrainingId == trainingId).FirstOrDefault();
            edm.Trainings.Remove(trainingEntity);
            return trainingEntity.TrainingId;
        }

        public TrainingModel GetTrainingById(int trainingId) => (from training in edm.Trainings
                                                           where training.TrainingId == trainingId
                                                           select new TrainingModel
                                                           {
                                                               TrainingId = training.TrainingId,
                                                               Trainer = training.Trainer,
                                                               TrainingType = training.TrainingType,
                                                               TrainingDate = training.TrainingDate,
                                                               Place = training.Place,
                                                               Cost = training.Cost,
                                                               CountOfFreePlaces = training.CountOfFreePlaces,
                                                               Client = training.Client

                                                           }).FirstOrDefault();

    }
}