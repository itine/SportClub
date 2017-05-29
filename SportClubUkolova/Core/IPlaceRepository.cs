using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public interface IPlaceRepository
    {
        IEnumerable<PlaceModel> GetAllPlaces();
        int AddNewPlace(PlaceModel place);
        int DeletePlace(PlaceModel place);
        int EditPlace(PlaceModel place);
        PlaceModel GetPlaceById(int placeId);

    }
}