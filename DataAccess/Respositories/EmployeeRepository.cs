using System;
using System.Data.Entity;
using System.Threading.Tasks;
using DataAccess.DataContext;
using DataAccess.Entities;

namespace DataAccess.Respositories
{
    public class EmployeeRepository
    {
        public virtual async Task<Employee> SaveAsync(Employee employee)
        {
            using (var context = new CodingExerciseContext())
            {
                if (employee == null)
                {
                    throw new ArgumentException("Invalid Employee.");
                }

                context.Employees.Add(employee);
                await context.SaveChangesAsync();

                return employee;
            }
        }

        public virtual async Task<Employee> FindAsync(int id)
        {
            using (var context = new CodingExerciseContext())
            {
                return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}