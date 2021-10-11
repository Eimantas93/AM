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
    public class IndexModel : PageModel
    {
        private readonly AssigmentsManager.Data.AssigmentsManagerContext _context;

        public IndexModel(AssigmentsManager.Data.AssigmentsManagerContext context)
        {
            _context = context;
        }

        public IList<Assigment> Assigment { get;set; }

        public async Task OnGetAsync()
        {
            Assigment = await _context.Assigment.ToListAsync();
        }
    }
}
