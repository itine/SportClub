using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public interface ISportRepository
    {
        IEnumerable<SportModel> GetAllSports();
        int AddNewSport(SportModel sport);
        int EditSportInfo(SportModel sport);
        SportModel GetSportById(int sportId);
        int DeleteSport(int sportId);
    }
}