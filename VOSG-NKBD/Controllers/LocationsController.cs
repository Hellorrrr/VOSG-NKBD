using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOSG_NKBD.Data;
using VOSG_NKBD.Models;
 
namespace VOSG_NKBD.Controllers
{

      public class LocationsController : Controller
      {
          private readonly VOSG_NKBDDbContext _context;
  
          public LocationsController(VOSG_NKBDDbContext context)
          {
              _context = context;
          }
  
          public async Task<IActionResult> Index(string searchString, int? pageNumber,
                                                  string currentFilter, string sortOrder)
          {
              ViewData["NameSortParm"]   = String.IsNullOrEmpty(sortOrder)? "name_desc" : "name_asc";
              ViewData["DateSortParm"]   = sortOrder == "City" ? "city_desc" : "city";
              ViewData["CurrentFilter"]  = searchString;
              ViewData["CurrentSort"]    = sortOrder;
  
              var locations = from l in _context.Locations select l;
  
              if (!String.IsNullOrEmpty(searchString))
                  locations = locations.Where(l =>
                  l.LocationName.Contains(searchString) ||
                  l.Addresss.Contains(searchString)     ||
                 l.City.Contains(searchString));
  
              switch (sortOrder)
              {
                  case "name_desc": locations = locations.OrderByDescending(l => l.LocationName); break;
                  case "city":      locations = locations.OrderBy(l => l.City);                   break;
                  case "city_desc": locations = locations.OrderByDescending(l => l.City);         break;
                  default:          locations = locations.OrderBy(l => l.LocationName);           break;
              }

              if (searchString != null) pageNumber = 1;
              else searchString = currentFilter;

              return View(await PaginatedList<Location>.CreateAsync(
                  locations.AsNoTracking(), pageNumber ?? 1, pageSize: 10));
          }

          public async Task<IActionResult> Details(int? id)
          {
                  if (id == null) return NotFound();
                  var location = await _context.Locations.FirstOrDefaultAsync(m => m.LocationsID == id);
                  if (location == null) return NotFound();
                  return View(location);
          }

[Authorize(Roles = "Admin")]
          public IActionResult Create() => View();

[HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
          public async Task<IActionResult> Create(
              [Bind("LocationsID,LocationName,Addresss,Suburb,City,Country,PostalCode,PhoneNumber")] Location location)
          {
                  if (ModelState.IsValid)
                  {
                          _context.Add(location);
                          await _context.SaveChangesAsync();
                          return RedirectToAction(nameof(Index));
                  }
                  return View(location);
          }

[Authorize(Roles = "Admin")]
          public async Task<IActionResult> Edit(int? id)
          {
                  if (id == null) return NotFound();
                  var location = await _context.Locations.FindAsync(id);
                  if (location == null) return NotFound();
                  return View(location);
          }

[HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
          public async Task<IActionResult> Edit(int id,
              [Bind("LocationsID,LocationName,Addresss,Suburb,City,Country,PostalCode,PhoneNumber")] Location location)
          {
                  if (id != location.LocationsID) return NotFound();
                  if (ModelState.IsValid)
                  {
                          try { _context.Update(location); await _context.SaveChangesAsync(); }
                  catch (DbUpdateConcurrencyException)
                  {
                                  if (!LocationExists(location.LocationsID)) return NotFound();
                                  else throw;
                          }
                          return RedirectToAction(nameof(Index));
                  }
                  return View(location);
          }

[Authorize(Roles = "Admin")]
         public async Task<IActionResult> Delete(int? id)
         {
                  if (id == null) return NotFound();
                  var location = await _context.Locations.FirstOrDefaultAsync(m => m.LocationsID == id);
                 if (location == null) return NotFound();
                 return View(location);
         }

         [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
                 var location = await _context.Locations.FindAsync(id);
                 if (location != null) _context.Locations.Remove(location);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }

         private bool LocationExists(int id) =>
             _context.Locations.Any(e => e.LocationsID == id);

         [HttpGet]
         public JsonResult GetMatchingLocations(string term) =>
             Json(_context.Locations
         .Where(l => l.LocationName.Contains(term))
         .Select(l => l.LocationName).Take(10).ToList());
      }
}