using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Trucks
{
    public class IndexModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public IndexModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Truck> Truck { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Truck = await _context.Trucks
                .Include(t => t.Driver).ToListAsync();
        }
    }
}
