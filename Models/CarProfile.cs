using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class CarProfile
    {
        public int ID { get; set; }
        public int SpecificationID { get; set; }
        public Specification Specification { get; set; }
        public ICollection<CarImage> Images { get; set; }
    }
}
