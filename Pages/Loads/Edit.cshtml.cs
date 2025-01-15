using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Loads
{
    public class EditModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public EditModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Load Load { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load =  await _context.Load.FirstOrDefaultAsync(m => m.LoadId == id);
            if (load == null)
            {
                return NotFound();
            }
            Load = load;
           ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "ClientId");
           ViewData["DeliveryLocationId"] = new SelectList(_context.Locations, "LocationId", "Address");
           ViewData["PickupLocationId"] = new SelectList(_context.Locations, "LocationId", "Address");
           ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ClientId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(Load.LoadId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoadExists(Guid id)
        {
            return _context.Load.Any(e => e.LoadId == id);
        }
    }
}
