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
    public class DetailsModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public DetailsModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DriverSchedule DriverSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverschedule = await _context.DriverSchedules.FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (driverschedule == null)
            {
                return NotFound();
            }
            else
            {
                DriverSchedule = driverschedule;
            }
            return Page();
        }
    }
}
