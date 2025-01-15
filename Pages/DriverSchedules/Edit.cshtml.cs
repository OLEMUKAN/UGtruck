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

namespace TruckLoadingApp.Pages.DriverSchedules
{
    public class EditModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public EditModel(TruckLoadingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DriverSchedule DriverSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverschedule =  await _context.DriverSchedules.FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (driverschedule == null)
            {
                return NotFound();
            }
            DriverSchedule = driverschedule;
           ViewData["DriverId"] = new SelectList(_context.applicationUsers, "Id", "Id");
           ViewData["RouteId"] = new SelectList(_context.TRoutes, "RouteId", "RouteId");
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

            _context.Attach(DriverSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverScheduleExists(DriverSchedule.ScheduleId))
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

        private bool DriverScheduleExists(Guid id)
        {
            return _context.DriverSchedules.Any(e => e.ScheduleId == id);
        }
    }
}
