using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;

namespace SportClubUkolova.Core
{
    public interface ITrainingRepository
    {
        List<Training> AllTrainings { get; }

        bool EditTraining(Training training);
        bool RegistrTraining(Client client, Trainer trainer, Place place);
        bool DeleteTraining(Client client);
    }
}