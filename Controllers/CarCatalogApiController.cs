using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileApp.Data;
using MobileApp.Models;
using MobileApp.Models.Repository;

namespace MobileApp.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class CarCatalogApiController : ControllerBase
    {
        private readonly IDataRepository<CarProfile> _dataRepository;

        public CarCatalogApiController(IDataRepository<CarProfile> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("getall/{latitude}/{longtitude}/{hour}/{dayOfWeek}/{uuid}")]
        public IActionResult Get(double latitude, double longtitude, int hour, int dayOfWeek, int uuid)
        {
            IEnumerable<CarProfile> carProfiles = _dataRepository.
                GetAll(latitude, longtitude, hour, dayOfWeek);
            return Ok(carProfiles);
        }

        [HttpGet("getsearch/{search}/{latitude}/{longtitude}/{hour}/{dayOfWeek}/{uuid}")]
        public IActionResult GetSearch(string search, double latitude, double longtitude, int hour, int dayOfWeek, int uuid)
        {
            IEnumerable<CarProfile> carProfiles = _dataRepository.
                GetSearch(latitude, longtitude, hour, dayOfWeek);
            return Ok(carProfiles);
        }

        [HttpGet("getcar/{id}")]
        public IActionResult GetCar(int id)
        {
            CarProfile carProfiles = _dataRepository.
                GetDetails(id);
            return Ok(carProfiles);
        }

        [HttpGet("getpictures/{id}")]
        public IActionResult GetPictures(int id)
        {
            IEnumerable<CarImage> pictures = _dataRepository.GetPictures(id);
            return Ok(pictures);
        }

        [HttpGet("getpicture/{id}")]
        public IActionResult GetPicture(int id)
        {
            CarImage image = _dataRepository.
                GetPicture(id);
            return Ok(image);
        }

        [HttpGet("getspecial/{latitude}/{longtitude}/{hour}/{dayOfWeek}/{uuid}")]
        public IActionResult GetSpecial(double latitude, double longtitude, int hour, int dayOfWeek, int uuid)
        {
            IEnumerable<CarProfile> carProfiles = _dataRepository.GetSpecial();
            return Ok(carProfiles);
        }

        [HttpGet("getuuid")]
        public IActionResult GetUUID()
        {
            Guid uuid = new Guid();
            return Ok(uuid);
        }

        [HttpPost("setappointment/{name}/{phone}/{details}/{id}/{time}/{date}")]
        public string SetAppointment()
        {
            return "Appointment was set up!";
        }
    }
}