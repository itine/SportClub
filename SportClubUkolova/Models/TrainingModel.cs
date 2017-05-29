using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClubUkolova.Models
{
    public class TrainingModel
    {
        public int TrainingId { get; set; }

        public int TrainingType { get; set; }

        public System.DateTime TrainingDate { get; set; }

        public int Trainer { get; set; }

        public int Place { get; set; }

        public int Client { get; set; }

        public int Cost { get; set; }

        public int CountOfFreePlaces { get; set; }
    }
}