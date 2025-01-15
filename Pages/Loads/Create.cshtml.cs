using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Loads
{
    public class CreateModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public CreateModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "ClientId");
        ViewData["DeliveryLocationId"] = new SelectList(_context.Locations, "LocationId", "Address");
        ViewData["PickupLocationId"] = new SelectList(_context.Locations, "LocationId", "Address");
        ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ClientId");
            return Page();
        }

        [BindProperty]
        public Load Load { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Load.Add(Load);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
