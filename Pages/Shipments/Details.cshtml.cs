using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Shipments
{
    public class DetailsModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public DetailsModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Shipment Shipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipments.FirstOrDefaultAsync(m => m.ShipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }
            else
            {
                Shipment = shipment;
            }
            return Page();
        }
    }
}
