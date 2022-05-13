using Microsoft.EntityFrameworkCore;
using RelationsRevisited.Models;

namespace RelationsRevisited.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
               .HasData
               (new Department { DepartmentId = 1, Name="IT" },
               new Department { DepartmentId = 2, Name = "HR"}
           );
            modelBuilder.Entity<Employee>()
                .HasData 
                (new Employee { EmployeeId=1,FirstName="kenan",LastName="Kurda",EmployeeCvId=1,DepartmentId=1 },
                new Employee { EmployeeId = 2, FirstName = "Pearl", LastName = "De Smet",EmployeeCvId=3,DepartmentId=2 }
            );
            modelBuilder.Entity<EmployeeCv>()
               .HasData
               (new EmployeeCv { EmployeeCvId = 1, Title=".Net Developer" },
               new EmployeeCv { EmployeeCvId = 2, Title = "Java Developer"},
               new EmployeeCv { EmployeeCvId = 3, Title = "administratief medewerker" }
           );
            modelBuilder.Entity<Skills>()
              .HasData
              (new Skills { SkillsId = 1, SkillsDescription = "C#,Sql,......" },
              new Skills { SkillsId = 2, SkillsDescription = "Administratie ervaring...." }
          );
            modelBuilder.Entity<Employee_Skills>()
             .HasData
             (new Employee_Skills { Id=1,EmployeeId=1,SkillsId=1},
             new Employee_Skills {Id=2,EmployeeId=2,SkillsId=2}
         );
            modelBuilder.Entity<Employee_Skills>()
                .HasOne(e => e.Employee)
                .WithMany(s => s.Employees_Skills)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee_Skills>()
             .HasOne(e => e.Skills)
             .WithMany(s => s.Employees_Skills)
             .HasForeignKey(e => e.SkillsId);

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <EmployeeCv> EmployeeCvs { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employee_Skills> Employee_Skills { get; set; }
    }
}
