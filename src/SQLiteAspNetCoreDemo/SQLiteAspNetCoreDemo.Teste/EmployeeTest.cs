using System;
using System.Linq;
using Xunit;

namespace SQLiteAspNetCoreDemo.Teste
{
    public class EmployeeTest
    {
        SQLiteDBContext db;
        public EmployeeTest()
        {
            db = new SQLiteDBContext();
        }

        private void CreateEmployee(string Name)
        {
            // Create
            db.Employees.Add(new Employee { FirstName = Name, LastName = "Doe", Age = 55 });
            db.SaveChanges();
        }

        private Employee GetEmployee()
        {
            try
            {
                return db.Employees
                    .OrderBy(b => b.Id)
                    .First();
            }
            catch
            {
                return null;
            }
        }

        private void DeleteEmployee(Employee employee)
        {
            db.Remove(employee);
            db.SaveChanges();
        }

        [Fact]
        public void Create()
        {
            string Name = "John";
            CreateEmployee(Name);

            // Read
            var employee = GetEmployee();

            Assert.Equal(employee.FirstName, Name);

            DeleteEmployee(employee);
        }

        [Fact]
        public void Update()
        {
            string Name = "Louis";
            CreateEmployee("John");

            // Read
            var employee = GetEmployee();

            // Update
            employee.FirstName = Name;
            employee.Age = 90;
            db.SaveChanges();

            // Read
            employee = GetEmployee();

            Assert.Equal(employee.FirstName, Name);

            // Delete
            DeleteEmployee(employee);
        }

        [Fact]
        public void Delete()
        {
            // Create
            CreateEmployee("John");
            // Read
            var employee = GetEmployee();
            // Delete
            DeleteEmployee(employee);

            employee = GetEmployee();
            Assert.Null(employee);
        }
    }
}
