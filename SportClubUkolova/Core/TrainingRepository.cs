using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataModel.Models;

namespace SportClubUkolova.Core
{
    public class TrainingRepository : ITrainingRepository
    {
        private SportsClubEntities context = new SportsClubEntities();
        public List<Training> AllTrainings { get; private set; }
        public bool EditTraining(Training training)
        {
            if (context.Training.Find(training) == null)
                return false;
            context.Training.Remove(training);
            Training newTraining = new Training()
            {
                Client = training.Client,
                Client1 = training.Client1,
                Cost = training.Cost,
                Place = training.Place,
                Place1 = training.Place1,
                Trainer = training.Trainer,
                Trainer1 = training.Trainer1,
                TrainingDate = DateTime.UtcNow,
                TrainingId = training.TrainingId,
                TrainingType = training.TrainingType
            };
            return true;
        }

        public bool RegistrTraining(Client client, Trainer trainer, Place place)
        {
            if (context.Training.Find(client) != null && context.Training.Find(trainer) != null &&
                context.Training.Find(place) != null)
            {
                Training training = new Training()
                {
                    Client = client.ClientId,
                    Cost = 300,
                    Place = place.PlaceId,
                    Trainer = trainer.TrainerId,
                    TrainingDate = DateTime.UtcNow,
                    Client1 = client,
                    Place1 = place,
                    Trainer1 = trainer,
                    TrainingType = trainer.SportsType 
                };
                context.Training.Add(training);
            }
            else return false;
            context.SaveChanges();
            return true;
        }

        public bool DeleteTraining(Client client)
        {
            var training = context.Training.Where(x => x.Client1 == client).FirstOrDefault();
            if (training == null)
                return false;
            context.Training.Remove(training);
            return true;
        }
    }
}