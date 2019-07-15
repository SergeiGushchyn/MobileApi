using MobileApp.Data;
using MobileApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MobileApp.Models.DataManager
{
    public class CarProfileManager : IDataRepository<CarProfile>
    {
        private readonly MobileAppContext _context;

        public CarProfileManager(MobileAppContext context)
        {
            _context = context;
        }

        public IEnumerable<CarProfile> GetAll(double latitude, double longtitude, int hour, int dayOfWeek)
        {
            return _context.CarProfiles.Include(s => s.Specification).ToList();
        }

        public IEnumerable<CarProfile> GetSearch(double latitude, double longtitude, int hour, int dayOfWeek)
        {
            return _context.CarProfiles.OrderBy(c => c.Specification.Make).ToList();
        }

        public CarProfile GetDetails(int id)
        {
            return _context.CarProfiles.
                Where(c => c.ID == id).
                Include(s => s.Specification).
                FirstOrDefault();
        }

        public IEnumerable<CarImage> GetPictures(int id)
        {
            return _context.Images.Where(i => i.CarProfileID == id).ToList();
        }

        public CarImage GetPicture(int id)
        {
            return _context.Images.FirstOrDefault(i => i.CarProfileID == id);
        }

        public IEnumerable<CarProfile> GetSpecial()
        {
            return _context.CarProfiles.
                Where(i => i.Specification.Special == "Yes").
                Include(s => s.Specification).
                ToList();
        }
    }
}
