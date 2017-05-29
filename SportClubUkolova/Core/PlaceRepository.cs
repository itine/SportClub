using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public class PlaceRepository : IPlaceRepository
    {
        private SportsClubEntities1 edm = new SportsClubEntities1();
        public IEnumerable<PlaceModel> GetAllPlaces() => (from place in edm.Places
                                                            select new PlaceModel()
                                                            {
                                                                Capacity = place.Capacity,
                                                                PlaceId = place.PlaceId,
                                                                PlaceName = place.PlaceName
                                                            }).ToList();


        public int AddNewPlace(PlaceModel place)
        {
            var placeEntity = new Place()
            {
                Capacity = place.Capacity,
                PlaceName = place.PlaceName
            };
            edm.Places.Add(placeEntity);
            return placeEntity.PlaceId;
        }

        public int DeletePlace(PlaceModel place)
        {
            var placeEntity = edm.Places.Where(x => x.PlaceId == place.PlaceId).FirstOrDefault();
            edm.Places.Remove(placeEntity);
            return placeEntity.PlaceId;
        }

        public int EditPlace(PlaceModel place)
        {
            var placeEntity = edm.Places.FirstOrDefault(x => x.PlaceId == place.PlaceId);
            placeEntity.Capacity = place.Capacity;
            placeEntity.PlaceName = place.PlaceName;
            edm.Places.Add(placeEntity);
            edm.SaveChanges();
            return placeEntity.PlaceId;
        }

        public PlaceModel GetPlaceById(int placeId) => (from place in edm.Places
                                                           where place.PlaceId ==placeId
                                                           select new PlaceModel()
                                                           {
                                                               PlaceId = place.PlaceId,
                                                               Capacity = place.Capacity,
                                                               PlaceName = place.PlaceName
                                                           }).FirstOrDefault();
    }
}