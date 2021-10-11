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
    public class DetailsModel : PageModel
    {
        private readonly AssigmentsManager.Data.AssigmentsManagerContext _context;

        public DetailsModel(AssigmentsManager.Data.AssigmentsManagerContext context)
        {
            _context = context;
        }

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
    }
}
