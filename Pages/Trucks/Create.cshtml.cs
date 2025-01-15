using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckLoadingApp.Data;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Pages.Trucks
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
        ViewData["DriverId"] = new SelectList(_context.applicationUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Truck Truck { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trucks.Add(Truck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
