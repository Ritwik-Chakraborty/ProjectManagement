using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CPMS.Models;

namespace CPMS.Data
{
    public class CPMSContext : DbContext
    {
        public CPMSContext(DbContextOptions<CPMSContext> options)
            : base(options)
        {
        }

        public DbSet<CPMS.Models.Department> Department { get; set; } = default!;

        public DbSet<CPMS.Models.Employee>? Employee { get; set; }

        public DbSet<CPMS.Models.ProjectResponse>? ProjectResponse { get; set; }

        public DbSet<CPMS.Models.Project>? Project { get; set; }

        public DbSet<ProjectResponse> ProjectsResponses { get; set; }


    }
}
