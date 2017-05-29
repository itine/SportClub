using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using DataModel.Models;
using DataModel;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public class SportRepository : ISportRepository
    {
        private SportsClubEntities1 edm = new SportsClubEntities1();

        public IEnumerable<SportModel> GetAllSports() => (from sport in edm.Sports
                                                            select new SportModel
                                                            {
                                                                SportId = sport.SportId,
                                                                SportName = sport.SportName,
                                                                SportsType = sport.SportsType
                                                            }).ToList();

        public int AddNewSport(SportModel sport)
        {
            var sportEntity = new Sport()
            {
                SportName = sport.SportName,
                SportsType = sport.SportsType
            };
            edm.Sports.Add(sportEntity);
            return sportEntity.SportId;
        }

        public int EditSportInfo(SportModel sport)
        {
            var sportEntity = edm.Sports.FirstOrDefault(x => x.SportId == sport.SportId);
            sportEntity.SportName = sport.SportName;
            sportEntity.SportsType = sport.SportsType;
            edm.Sports.Add(sportEntity);
            edm.SaveChanges();
            return sportEntity.SportId;
        }

        public SportModel GetSportById(int sportId) => (from sport in edm.Sports
                                                           where sport.SportId == sportId
                                                           select new SportModel
                                                           {
                                                                SportName = sport.SportName,
                                                                SportsType = sport.SportsType
                                                           }).FirstOrDefault();


        public int DeleteSport(int sportId)
        {
            var sportEntity = edm.Sports.Where(x => x.SportId == sportId).FirstOrDefault();
            edm.Sports.Remove(sportEntity);
            return sportEntity.SportId;
        }
    }
}