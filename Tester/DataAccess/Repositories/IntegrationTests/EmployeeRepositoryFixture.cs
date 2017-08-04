using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Respositories;
using NUnit.Framework;

namespace Tester.DataAccess.Repositories.IntegrationTests
{
    [TestFixture]
    public class EmployeeRepositoryFixture : RepositoryFixture
    {
        private Employee CreateEmployee(int index = 1)
        {
            var employee = new Employee();
            employee.Name = $"Test name {index}";
            employee.Email = $"test{index}@test.com";
            employee.ManagerId = index;
            return employee;
        }

        [Test]
        public async Task FindAsync_ReturnsEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            var repository = new EmployeeRepository();

            // Act        
            var savedEmployee = await repository.SaveAsync(employee);

            // Assert
            using (var context = new CodingExerciseContext())
            {
                Assert.IsNotNull(savedEmployee);
                var employeeFromDatabase = context.Employees.FirstOrDefault(e => e.Id == savedEmployee.Id);
                Assert.IsNotNull(employeeFromDatabase);
                Assert.AreEqual(employee.Name, employeeFromDatabase.Name);
                Assert.AreEqual(employee.Email, employeeFromDatabase.Email);
                Assert.AreEqual(employee.ManagerId, employeeFromDatabase.ManagerId);
                Assert.AreEqual(employee.Role, employeeFromDatabase.Role);
            }
        }


        [Test]
        public async Task SaveAsync_SavesEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            var repository = new EmployeeRepository();

            // Act   
            var savedEmployee = await repository.SaveAsync(employee);

            // Assert
            using (var context = new CodingExerciseContext())
            {
                Assert.IsNotNull(savedEmployee);
                var employeeFromDatabase = context.Employees.FirstOrDefault(e => e.Id == savedEmployee.Id);
                Assert.IsNotNull(employeeFromDatabase);
                Assert.AreEqual(employee.Name, employeeFromDatabase.Name);
                Assert.AreEqual(employee.Email, employeeFromDatabase.Email);
                Assert.AreEqual(employee.ManagerId, employeeFromDatabase.ManagerId);
                Assert.AreEqual(employee.Role, employeeFromDatabase.Role);
            }
        }
    }
}