using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2Grupp5.Data;
using Garage2Grupp5.Models;
using Garage2Grupp5.ViewModels;

namespace Garage2Grupp5.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        string unParkedVehicleLicensePlate;
        private readonly AppDbContext _context;

        public ParkedVehiclesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ParkingReceipt()
        {
            return View();
        }

        //public IActionResult Unpark(/*string LicensePlate, int? Id*/)
        //{
        //    //UnparkedVehicleViewModel theUnparkedVehicleViewModel = new UnparkedVehicleViewModel();
        //    //var theUnParkedVehicle = _context.UnparkedVehicleViewModel
        //    //               .First(m => m.LicensePlate == unParkedVehicleLicensePlate/*m => m.Id == theUnparkedVehicleViewModel.Id*/);
        //    //theUnparkedVehicleViewModel.ArrivalTime = theParkedVehicle.ArrivalTime;
        //    //theUnparkedVehicleViewModel.Brand = theParkedVehicle.Brand;
        //    ///*parkedVehicle1.Price = */
        //    //theUnparkedVehicleViewModel.parkingTime = theParkedVehicle.parkingTime;
        //    //theUnparkedVehicleViewModel.parkingPrice = theParkedVehicle.parkingPrice;

        //    //theUnparkedVehicleViewModel.Price = theParkedVehicle.Price;
        //    ////theUnparkedVehicleViewModel.Id = theParkedVehicle.Id;
        //    //theUnparkedVehicleViewModel.DepartureTime = theParkedVehicle.DepartureTime;
        //    //theUnparkedVehicleViewModel.LicensePlate = theParkedVehicle.LicensePlate;
        //    //theUnparkedVehicleViewModel.NrOfWheels = theParkedVehicle.NrOfWheels;
        //    //theUnparkedVehicleViewModel.Color = theParkedVehicle.Color;
        //    //theUnparkedVehicleViewModel.Type = theParkedVehicle.Type;
        //    //return View(theUnParkedVehicle);
        //}

        public IActionResult ReceiptOrNot(string LicensePlate, int? Id)
        {
            if (Id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = _context.ParkedVehicle
                .FirstOrDefault(m => m.Id == Id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'AppDbContext.ParkedVehicle'  is null.");
            }
            var parkedVehicle1 = _context.ParkedVehicle.Find(Id);

            UnparkedVehicleViewModel unparkedVehicleViewModel = new UnparkedVehicleViewModel();
            unparkedVehicleViewModel.ArrivalTime = parkedVehicle1.ArrivalTime;
            unparkedVehicleViewModel.Brand = parkedVehicle1.Brand;
            /*parkedVehicle1.Price = */
            unparkedVehicleViewModel.parkingTime = parkedVehicle1.DepartureTime - parkedVehicle1.ArrivalTime;
            unparkedVehicleViewModel.parkingPrice = unparkedVehicleViewModel.parkingTime.TotalHours * 90;

            unparkedVehicleViewModel.Price = parkedVehicle1.Price;
            //unparkedVehicleViewModel.Id = parkedVehicle1.Id;
            unparkedVehicleViewModel.DepartureTime = parkedVehicle1.DepartureTime;
            unparkedVehicleViewModel.LicensePlate = parkedVehicle1.LicensePlate;
            unparkedVehicleViewModel.NrOfWheels = parkedVehicle1.NrOfWheels;
            unparkedVehicleViewModel.Color = parkedVehicle1.Color;
            unparkedVehicleViewModel.Type = parkedVehicle1.Type;
            unParkedVehicleLicensePlate = unparkedVehicleViewModel.LicensePlate;

            if (parkedVehicle1 != null)
            {


                _context.ParkedVehicle.Remove(parkedVehicle1);
            }
            //_context.UnparkedVehicleViewModel.Add(unparkedVehicleViewModel);

            _context.SaveChanges();
            //return RedirectToAction(nameof(ParkingReceipt/*Index*/));
            return View(unparkedVehicleViewModel);
        }

            public IActionResult NoReceipt(string LicensePlate, int? Id)
        {
            if (Id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = _context.ParkedVehicle
                .FirstOrDefault(m => m.Id == Id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'AppDbContext.ParkedVehicle'  is null.");
            }
            var parkedVehicle1 = _context.ParkedVehicle.Find(Id);

            if (parkedVehicle1 != null)
            {
                
                
                _context.ParkedVehicle.Remove(parkedVehicle1);
            }

            _context.SaveChanges();
            //return RedirectToAction(nameof(ParkingReceipt/*Index*/));
            return View("Index.cshtml");

            //if (Id == null || _context.ParkedVehicle == null)
            //{
            //    return NotFound();
            //}

            //var parkedVehicle = _context.ParkedVehicle
            //    .FirstOrDefault(m => m.Id == Id);
            //if (parkedVehicle == null)
            //{
            //    return NotFound();
            //}

            //return View(parkedVehicle);

            //var validateName = _context.ParkedVehicle.FirstOrDefault
            //                    (x => x.LicensePlate == LicensePlate && x.Id != Id);
            //if (validateName != null)
            //{
            //    return Json(false/*, JsonRequestBehavior.AllowGet*/);
            //}
            //else
            //{
            //    return Json(true/*, JsonRequestBehavior.AllowGet*/);
            //}
            //return View();
        }

        //public async Task<IActionResult> Unpark(int? id)
        //{
        //    if (id == null || _context.ParkedVehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    var parkedVehicle = await _context.ParkedVehicle
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (parkedVehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(parkedVehicle);
        //}

        // GET: ParkedVehicles1
        public async Task<IActionResult> Index()
        {
              return View(await _context.ParkedVehicle.ToListAsync());
        }

        // GET: ParkedVehicles1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles1/Create

        // GET: ParkedVehicles/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //public IActionResult Create(int Id)
        //{
        //var validateName = _context.ParkedVehicle.FirstOrDefault
        //                    (x => x.LicensePlate == LicensePlate && x.Id != Id);
        //if (validateName != null)
        //{
        //    return Json(false/*, JsonRequestBehavior.AllowGet*/);
        //}
        //else
        //{
        //    return Json(true/*, JsonRequestBehavior.AllowGet*/);
        //}
        //if (ModelState.IsValid)
        //{
        //    _context.Add(parkedVehicle);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(parkedVehicle);
        //return View();
        //}



        // POST: ParkedVehicles1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,LicensePlate,Type,NrOfWheels,Color,Brand,ArrivalTime")] ParkedVehicle parkedVehicle)
        //{
        //    //var parkedVehicle1 = _context.ParkedVehicle.Find(parkedVehicle.LicensePlate);
        //    //if (parkedVehicle1 != null)
        //    //{
        //    //    return View("LicensePlateAlreadyExistError.cshtml");
        //    //}
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(parkedVehicle);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(parkedVehicle);
        //}

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicensePlate,Type,NrOfWheels,Color,Brand,ArrivalTime,DepartureTime,Price")] ParkedVehicle parkedVehicle)
        {
            //var parkedVehicle1 = _context.ParkedVehicle.Find(parkedVehicle.LicensePlate);
            var parkedVehicle1 = _context.ParkedVehicle.FirstOrDefault(acc => acc.LicensePlate == parkedVehicle.LicensePlate);

            if (parkedVehicle1 != null)
            {
                return View("~/Views/ParkedVehicles/LicensePlateAlreadyExistError.cshtml");
            }
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }






        // GET: ParkedVehicles1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicensePlate,Type,NrOfWheels,Color,Brand,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
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
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'AppDbContext.ParkedVehicle'  is null.");
            }
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
          return _context.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}
