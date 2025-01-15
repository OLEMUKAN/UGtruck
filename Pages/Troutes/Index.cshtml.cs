using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Troutes
{
    public class IndexModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public IndexModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TRoute> TRoute { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TRoute = await _context.TRoutes
                .Include(t => t.Destination)
                .Include(t => t.Driver)
                .Include(t => t.Origin)
                .Include(t => t.Truck).ToListAsync();
        }
    }
}
