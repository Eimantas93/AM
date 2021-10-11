using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssigmentsManager.Models;

namespace AssigmentsManager.Data
{
    public class AssigmentsManagerContext : DbContext
    {
        public AssigmentsManagerContext (DbContextOptions<AssigmentsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<AssigmentsManager.Models.Assigment> Assigment { get; set; }
    }
}
