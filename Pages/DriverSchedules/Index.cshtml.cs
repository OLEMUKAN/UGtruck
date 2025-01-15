using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.DriverSchedules
{
    public class IndexModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public IndexModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DriverSchedule> DriverSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DriverSchedule = await _context.DriverSchedules
                .Include(d => d.Driver)
                .Include(d => d.Route).ToListAsync();
        }
    }
}
