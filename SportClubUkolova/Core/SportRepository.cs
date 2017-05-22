using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataModel.Models;
using DataModel;
namespace SportClubUkolova.Core
{
    public class SportRepository : ISportRepository
    {
        private SportsClubEntities context = new SportsClubEntities();

        public List<Sport> Sports
        {
            get { return context.Sport.ToList(); }
        }

        public bool AddNewSport(Sport sport)
        {
            if (context.Sport.Find(sport) == null)
                context.Sport.Add(sport); 
            context.Entry(sport).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool DeleteSport(Sport sport)
        {
            if (context.Sport.Find(sport) == null)
                return false;
            context.Sport.Remove(sport);
            context.SaveChanges();
            return true;
        }

    }
}