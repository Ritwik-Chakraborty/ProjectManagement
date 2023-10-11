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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Project>()
            .HasMany(p => p.Employees)
            .WithMany(e => e.Projects)
            .UsingEntity<ProjectEmployee>(
                j => j
                    .HasOne(pe => pe.Employee)
                    .WithMany()
                    .HasForeignKey(pe => pe.Emp_Id),
                j => j
                    .HasOne(pe => pe.Project)
                    .WithMany()
                    .HasForeignKey(pe => pe.Project_Id)
    );
        }

        public DbSet<CPMS.Models.ProjectEmployee>? ProjectEmployee { get; set; }


    }
}
