using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public interface ITrainingRepository
    {
        IEnumerable<TrainingModel> GetAllTrainings();
        int TrainingRegistration(TrainingModel training);
        int EditTraining(TrainingModel training);
        int DeleteTraining(int trainingId);
        TrainingModel GetTrainingById(int trainingId);
    }
}