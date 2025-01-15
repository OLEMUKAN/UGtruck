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
    public class DeleteModel : PageModel
    {
        private readonly TruckLoadingApp.Data.ApplicationDbContext _context;

        public DeleteModel(TruckLoadingApp.Data.ApplicationDbContext context)
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

            var load = await _context.Load.FirstOrDefaultAsync(m => m.LoadId == id);

            if (load == null)
            {
                return NotFound();
            }
            else
            {
                Load = load;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load = await _context.Load.FindAsync(id);
            if (load != null)
            {
                Load = load;
                _context.Load.Remove(Load);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
