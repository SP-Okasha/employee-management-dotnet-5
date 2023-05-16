using EmployeeManagement.Models;
using EmployeeManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;

        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedCompleteData()
        {
            await _context.Database.EnsureCreatedAsync().ConfigureAwait(false);
            if (!_context.Employees.Any())
            {
                var testUser1 = new Employee
                {
                    EmplName = "Okasha Momin",
                    EmplCode = "okasha21",
                    CreatedBy = "Okasha",
                    CreatedOn = DateTime.Now
                };

                var testUser2 = new Employee
                {
                    EmplName = "Umair Momin",
                    EmplCode = "umair21",
                    CreatedBy = "Okasha",
                    CreatedOn = DateTime.Now
                };

                _context.Employees.Add(testUser1);
                _context.Employees.Add(testUser2);

                await _context.SaveChangesAsync();
            }
        }
    }
}
