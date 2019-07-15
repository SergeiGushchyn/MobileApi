using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class CarImage
    {
        public int CarImageID { get; set; }
        public int CarProfileID { get; set; }
        public CarProfile CarProfile { get; set; }
        public byte[] Picture { get; set; }
    }
}
