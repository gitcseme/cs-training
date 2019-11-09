using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Models
{
    public static class SeedDataExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mark",
                    Department = Dept.IT,
                    Email = "mark@gmail.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mary",
                    Department = Dept.HR,
                    Email = "mary@gmail.com"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Hulk",
                    Department = Dept.Payroll,
                    Email = "hulk@gmail.com"
                },
                new Employee
                {
                    Id = 4,
                    Name = "Roney",
                    Department = Dept.None,
                    Email = "roney@gmail.com"
                }
            );
        }
    }
}
