using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileApp.Data;
using MobileApp.Models;

namespace MobileApp.Controllers
{
    public class CarProfilesController : Controller
    {
        private readonly MobileAppContext _context;

        public CarProfilesController(MobileAppContext context)
        {
            _context = context;
        }

        // GET: CarProfiles
        public async Task<IActionResult> Index()
        {
            var mobileAppContext = _context.CarProfiles.Include(c => c.Specification);
            return View(await mobileAppContext.ToListAsync());
        }

        // GET: CarProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carProfile = await _context.CarProfiles
                .Include(c => c.Specification)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carProfile == null)
            {
                return NotFound();
            }

            return View(carProfile);
        }

        // GET: CarProfiles/Create
        public IActionResult Create()
        {
            ViewData["SpecificationID"] = new SelectList(_context.Specifications, "ID", "ID");
            return View();
        }

        // POST: CarProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Specification")] CarProfile carProfile, ICollection<CarImage> images,
            List<IFormFile> files)
        {
            var fileQuality = 50;
            if (ModelState.IsValid)
            {
                foreach (IFormFile file in files)
                {
                    CarImage image = new CarImage();
                    Image temp;
                    var ms = new MemoryStream();
                    file.CopyTo(ms);
                    temp = Image.FromStream(ms);
                    var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                      .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, fileQuality);
                    using (var outputStream = new MemoryStream())
                    {
                        temp.Save(outputStream, jpegEncoder, encoderParameters);
                        image.Picture = outputStream.ToArray();
                    }
                    images.Add(image);
                    carProfile.Images = images;
                }
                _context.Add(carProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecificationID"] = new SelectList(_context.Specifications, "ID", "ID", carProfile.SpecificationID);
            return View(carProfile);
        }

        // GET: CarProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carProfile = await _context.CarProfiles.FindAsync(id);
            if (carProfile == null)
            {
                return NotFound();
            }
            ViewData["SpecificationID"] = new SelectList(_context.Specifications, "ID", "ID", carProfile.SpecificationID);
            return View(carProfile);
        }

        // POST: CarProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SpecificationID")] CarProfile carProfile)
        {
            if (id != carProfile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarProfileExists(carProfile.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecificationID"] = new SelectList(_context.Specifications, "ID", "ID", carProfile.SpecificationID);
            return View(carProfile);
        }

        // GET: CarProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carProfile = await _context.CarProfiles
                .Include(c => c.Specification)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carProfile == null)
            {
                return NotFound();
            }

            return View(carProfile);
        }

        // POST: CarProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carProfile = await _context.CarProfiles.FindAsync(id);
            _context.CarProfiles.Remove(carProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarProfileExists(int id)
        {
            return _context.CarProfiles.Any(e => e.ID == id);
        }
    }
}
