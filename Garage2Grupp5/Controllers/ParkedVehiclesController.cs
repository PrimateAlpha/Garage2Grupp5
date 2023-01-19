﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2Grupp5.Data;
using Garage2Grupp5.Models;
using Garage2Grupp5.ViewModels;
using Garage2Grupp5.Services;
//using AspNetCore;

namespace Garage2Grupp5.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        string? unParkedVehicleLicensePlate;
        private readonly AppDbContext _context;
        private readonly IVehicleTypeSelectListService vehicleTypeSelectListService;


        public ParkedVehiclesController(AppDbContext context, IVehicleTypeSelectListService vehicleTypeSelectListService)
        {
            _context = context;
            this.vehicleTypeSelectListService = vehicleTypeSelectListService;
        }

        public IActionResult ParkingReceipt()
        {
            return View();
        }

        public IActionResult Unpark(/*string LicensePlate, int? Id*/)
        {
            //UnparkedVehicleViewModel theUnparkedVehicleViewModel = new UnparkedVehicleViewModel();

            //var theUnParkedVehicle = _context.ParkedVehicleViewModel
            //.First(m => m.LicensePlate == unParkedVehicleLicensePlate

            ///*m => m.Id == theUnparkedVehicleViewModel.Id*/);
            //theUnparkedVehicleViewModel.ArrivalTime = theParkedVehicle.ArrivalTime;
            //theUnparkedVehicleViewModel.Brand = theParkedVehicle.Brand;
            ///*parkedVehicle1.Price = */
            //theUnparkedVehicleViewModel.parkingTime = theParkedVehicle.parkingTime;
            //theUnparkedVehicleViewModel.parkingPrice = theParkedVehicle.parkingPrice;

            //theUnparkedVehicleViewModel.Price = theParkedVehicle.Price;
            ////theUnparkedVehicleViewModel.Id = theParkedVehicle.Id;
            //theUnparkedVehicleViewModel.DepartureTime = theParkedVehicle.DepartureTime;
            //theUnparkedVehicleViewModel.LicensePlate = theParkedVehicle.LicensePlate;
            //theUnparkedVehicleViewModel.NrOfWheels = theParkedVehicle.NrOfWheels;
            //theUnparkedVehicleViewModel.Color = theParkedVehicle.Color;
            //theUnparkedVehicleViewModel.Type = theParkedVehicle.Type;
            return View(/*theUnParkedVehicle*/);
        }

        public IActionResult UnPark(/*string LicensePlate, */int? Id, bool receipt)
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
            //unparkedVehicleViewModel.Type = parkedVehicle1.Type;
            //unparkedVehicleViewModel.Type.Name = parkedVehicle1.Type;
            unparkedVehicleViewModel.Type = parkedVehicle1.Type;


            unParkedVehicleLicensePlate = unparkedVehicleViewModel.LicensePlate;

            if (parkedVehicle1 != null)
            {


                _context.ParkedVehicle.Remove(parkedVehicle1);
            }
            //_context.UnparkedVehicleViewModel.Add(unparkedVehicleViewModel);

            _context.SaveChanges();
            //return RedirectToAction(nameof(ParkingReceipt/*Index*/));
            if (receipt)
            {
                return View("ParkingReceipt", unparkedVehicleViewModel);

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
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
            var model = new RegisteredVehicleViewModel/*ParkedVehicle*/
            {
                ParkedVehicles = await _context.ParkedVehicle.Include(v => v.Type).Include(v => v.Membership).ToListAsync(),/*movies.ToListAsync()*/
                VehicleTypes = await vehicleTypeSelectListService.GetVehicleTypesAsync() //GetGenresAsync()
            };
            return View(nameof(Index2), model/*await _context.ParkedVehicle.ToListAsync()*/);
        }

        private async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            return await _context.ParkedVehicle.Select(m => m.Type)
                                .Distinct()
                                .Select(g => new SelectListItem
                                {
                                    Text = g.ToString(),
                                    Value = g.ToString()
                                })
                                .ToListAsync();
        }

        public async Task<IActionResult> Index2(/*ParkedVehicleViewModel model*/)
        {
            var parkedVehicles = await _context.ParkedVehicle.Include(v => v.Type).ToListAsync();

            var model = new RegisteredVehicleViewModel
            {
                //ParkedVehicles = parkedVehicles,
                VehicleTypes = parkedVehicles.Select(m => m.Type)
                               .Distinct()
                               .Select(g => new SelectListItem
                               {
                                   Text = g.ToString(),
                                   Value = g.ToString()
                               })
                               .ToList()
            };

            return View(model);

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
        public IActionResult RegisterVehicle()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchWord /*ParkedVehicle parkedVehicle*/)
        {
            //var resList = new List<ParkedVehicle>();
            //foreach(var v in _context.ParkedVehicle)
            //{
            //    if (v.LicensePlate.StartsWith(searchWord))
            //    {
            //        resList.Add(v);

            //    }
            //}

            //Add logic
            IQueryable<ParkedVehicle> vehicles = _context.ParkedVehicle;

            if(!string.IsNullOrWhiteSpace(searchWord))
           vehicles = vehicles.Where(v => v.LicensePlate.StartsWith(searchWord));
            //19.1.2023. Attila Starkenius trying to add
            //function to search even other things than license plate:
            //vehicles = vehicles.Where(v => (v.LicensePlate.StartsWith(searchWord)
            //|| v.Brand.StartsWith(searchWord) || v.Color.StartsWith(searchWord)));
            vehicles = vehicles.Where(v => (v.LicensePlate.StartsWith(searchWord)
            || v.Brand.StartsWith(searchWord) || v.Color.StartsWith(searchWord)));
            



            var model = new RegisteredVehicleViewModel
            {
                ParkedVehicles =vehicles
            };

            return View("Index2", model);

        }

        // POST: ParkedVehicles/RegisterVehicle
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterVehicle(RegisteredVehicleViewModel registeredVehicle/*ParkedVehicle parkedVehicle*/)
        {
            if (await _context.ParkedVehicle.AnyAsync(vt => vt.LicensePlate == registeredVehicle.LicensePlate))
            {
                ModelState.AddModelError("LicensePlate", "Licensplate already exists");

            }

            if (ModelState.IsValid)
            {
                var newVehicle = new ParkedVehicle
                {
                    LicensePlate = registeredVehicle.LicensePlate,
                    Brand = registeredVehicle.Brand,
                    Color = registeredVehicle.Color,
                    ArrivalTime = DateTime.Now,
                    NrOfWheels = registeredVehicle.NrOfWheels,
                    MembershipId = registeredVehicle.MemberId,
                    VehicleTypeId = registeredVehicle.VehicleTypeId
                };

                _context.Add(newVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registeredVehicle);

        }
        //BYt ut agrumentet till en Vymodell


        //var parkedVehicle1 = _context.ParkedVehicle.Find(parkedVehicle.LicensePlate);
        //    var parkedVehicle1 = _context.ParkedVehicle.FirstOrDefault(acc => acc.LicensePlate == registeredVehicle.LicensePlate);
        //    //var vehicleType = _context.VehicleType.FirstOrDefault(acc => acc.Name == parkedVehicle.VehicleType); //
        //    //_context.ParkedVehicle.
        //    //var movies = parkedVehicle.VehicleType is null ?
        //    //                    movies :
        //    //                    movies.Where(m => m.VehicleType == parkedVehicle.VehicleType);
        //    if (parkedVehicle1 != null)
        //    {
        //        return View("~/Views/ParkedVehicles/LicensePlateAlreadyExistError.cshtml");
        //        //
        //    }


        //    var vehicleType = await _context.VehicleType.FirstOrDefaultAsync(vt => vt.Name == registeredVehicle.VehicleType);



        //    var newVehicle = new ParkedVehicle/*ParkedVehicle*/
        //    {
        //        LicensePlate = registeredVehicle.LicensePlate,
        //        Brand = registeredVehicle.Brand,
        //        //VehicleTypeId = vehicleType.Id



        //        //fyll på med resten av properties
        //        //Type = vehicleType
        //        //LicensePlate = vehicleType.
        //    };

        //    //var newVehicle = new RegisteredVehicleViewModel/*ParkedVehicle*/
        //    //{
        //    //    //fyll på med resten av properties
        //    //    //Type = vehicleType
        //    //    //LicensePlate = vehicleType.
        //    //};





        //    if (ModelState.IsValid)
        //    {
        //        //VehicleType vehicleType = new VehicleType();
        //        //vehicleType.Name = parkedVehicle.Type.ToString();
        //        //_context.Add(vehicleType);
        //        _context.Add(newVehicle);                
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(nameof(Details/*Index*/)/*"Index.cshtml"*/, newVehicle/*parkedVehicle*/);
        //}






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
            EditViewModel theEditViewModel = new EditViewModel();
            theEditViewModel.Brand = parkedVehicle.Brand;
            theEditViewModel.Color = parkedVehicle.Color;
            theEditViewModel.MemberId = parkedVehicle.MembershipId;
            theEditViewModel.LicensePlate = parkedVehicle.LicensePlate;
            theEditViewModel.NrOfWheels = parkedVehicle.NrOfWheels;
            theEditViewModel.VehicleTypeId = parkedVehicle.VehicleTypeId;

            return View(theEditViewModel/*parkedVehicle*/);
        }

        // POST: ParkedVehicles1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel editViewModel, int id/*int id, [Bind("Id,LicensePlate,Type,NrOfWheels,Color,Brand,ArrivalTime")] ParkedVehicle parkedVehicle*/)
        {
            //if (id != parkedVehicle.Id)
            //{
            //    return NotFound();
            //}
            ParkedVehicle parkedVehicle = new ParkedVehicle();
            parkedVehicle.Id = id;
            parkedVehicle.Brand = editViewModel.Brand;
            parkedVehicle.Color = editViewModel.Color;
            parkedVehicle.MembershipId = editViewModel.MemberId;
            parkedVehicle.LicensePlate = editViewModel.LicensePlate;
            parkedVehicle.NrOfWheels = editViewModel.NrOfWheels;
            parkedVehicle.VehicleTypeId = editViewModel.VehicleTypeId;

            if (ModelState.IsValid)
            {
                //try
                //{
                    _context.Update(parkedVehicle/*editViewModel*/);
                    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ParkedVehicleExists(parkedVehicle.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(editViewModel);
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
