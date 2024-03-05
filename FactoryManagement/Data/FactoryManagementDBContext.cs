using FactoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryManagement.data
{
    public class FactoryManagementDBContext : DbContext
    {
        public FactoryManagementDBContext(DbContextOptions<FactoryManagementDBContext> options): base (options) 
        {
            
        }

        public DbSet<Department> Deparments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeShift> EmployeeShifts { get; set; } 

        public DbSet<Shift> Shifts { get; set; }    

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
        .HasMany(dept => dept.Employees)
        .WithOne(emp => emp.Deparment)
        .HasForeignKey(emp => emp.DepartmentID);

            modelBuilder.Entity<User>().HasData(
          new User { Id = 1, FullName = "John Doe", UserName = "johndoe", Password = "password", NumOfActions = 5 },
          new User { Id = 2, FullName = "Jane Doe", UserName = "janedoe", Password = "password", NumOfActions = 5 }
      );

            // Seed data for Department table
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", ManagerId = 1 },
                new Department { Id = 2, Name = "HR", ManagerId = 2 }
            );

            // Seed data for Employee table
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", StartWorkYear = 2018, DepartmentID = 1 },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Doe", StartWorkYear = 2019, DepartmentID = 2 }
            );

            // Seed data for Shift table
            modelBuilder.Entity<Shift>().HasData(
                new Shift { Id = 1, Date = new DateTime(2023, 1, 1), StartTime = 9, EndTime = 17 }
            );

            // Seed data for EmployeeShift table
            modelBuilder.Entity<EmployeeShift>().HasData(
                new EmployeeShift { Id = 1, EmployeeId = 1, ShiftId = 1 },
                new EmployeeShift { Id = 2, EmployeeId = 2, ShiftId = 1 }
            );

        }
    }
}
