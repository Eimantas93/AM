using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssigmentsManager.Data;
using AssigmentsManager.Models;

namespace AssigmentsManager.Pages.Assigments
{
    public class DeleteModel : PageModel
    {
        private readonly AssigmentsManager.Data.AssigmentsManagerContext _context;

        public DeleteModel(AssigmentsManager.Data.AssigmentsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assigment Assigment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assigment = await _context.Assigment.FirstOrDefaultAsync(m => m.ID == id);

            if (Assigment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assigment = await _context.Assigment.FindAsync(id);

            if (Assigment != null)
            {
                _context.Assigment.Remove(Assigment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
