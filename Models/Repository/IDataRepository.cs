using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(double latitude, double longtitude, int hour, int dayOfWeek);
        IEnumerable<TEntity> GetSearch(double latitude, double longtitude, int hour, int dayOfWeek);
        IEnumerable<CarImage> GetPictures(int id);
        IEnumerable<CarProfile> GetSpecial();
        TEntity GetDetails(int id);
        CarImage GetPicture(int id);
    }
}
