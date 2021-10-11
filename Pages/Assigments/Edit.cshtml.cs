using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssigmentsManager.Data;
using AssigmentsManager.Models;

namespace AssigmentsManager.Pages.Assigments
{
    public class EditModel : PageModel
    {
        private readonly AssigmentsManager.Data.AssigmentsManagerContext _context;

        public EditModel(AssigmentsManager.Data.AssigmentsManagerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Assigment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssigmentExists(Assigment.ID))
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

        private bool AssigmentExists(int id)
        {
            return _context.Assigment.Any(e => e.ID == id);
        }
    }
}
