using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;

namespace SportClubUkolova.Core
{
    public class TrainerRepository : ITrainerRepository
    {
        private SportsClubEntities context = new SportsClubEntities();

        public List<Trainer> AllTrainers
        {
            get { return context.Trainer.ToList(); }
        }
        public bool AddTrainer(Trainer trainer)
        {
            if (context.Trainer.Find(trainer) != null)
                return false;
            context.Trainer.Add(trainer);
            context.SaveChanges();
            return true;
        }

        public bool EditTrainer(Trainer trainer)
        {
            if (context.Trainer.Find(trainer) == null)
                return false;
            DeleteTrainer(trainer.TrainerId);
            Trainer newTrainer = new Trainer()
            {
                Achievements = trainer.Achievements,
                DateBirth = trainer.DateBirth,
                Sport = trainer.Sport,
                SportsType = trainer.SportsType,
                TrainerFIO = trainer.TrainerFIO,
                TrainerId = trainer.TrainerId,
                Training = trainer.Training
            };
            context.Trainer.Add(newTrainer);
            context.SaveChanges();
            return true;
        }

        public bool DeleteTrainer(int? trainerId)
        {
            if (trainerId != null)
            {
                var trainer = context.Trainer.Where(x => x.TrainerId == trainerId).FirstOrDefault();
                if (trainer != null)
                {
                    context.Trainer.Remove(trainer);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}