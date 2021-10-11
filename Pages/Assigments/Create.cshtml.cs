using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssigmentsManager.Data;
using AssigmentsManager.Models;

namespace AssigmentsManager.Pages.Assigments
{
    public class CreateModel : PageModel
    {
        private readonly AssigmentsManager.Data.AssigmentsManagerContext _context;

        public CreateModel(AssigmentsManager.Data.AssigmentsManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Assigment Assigment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assigment.Add(Assigment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
