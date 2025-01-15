using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Loads
{
    public class IndexModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public IndexModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Load> Load { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Load = await _context.Load
                .Include(l => l.Booking)
                .Include(l => l.DeliveryLocation)
                .Include(l => l.PickupLocation)
                .Include(l => l.Shipment).ToListAsync();
        }
    }
}
