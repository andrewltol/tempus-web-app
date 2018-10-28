using TempusWebApp.Models;
using System;
using System.Collections.Generic;

namespace TempusWebApp.Services
{
    public class DummyEmployeeService : IEmployeeService
    {
        private List<Employee> _employees;

        public DummyEmployeeService()
        {
            CreateEmployees();
        }

        public IList<Employee> GetAll()
        {
            if (_employees == null)
            {
                CreateEmployees();
            }

            return _employees;
        }

        public IList<Employee> GetForRoles(IList<int> roleIds)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetForTask(int taskId)
        {
            throw new NotImplementedException();
        }

        private void CreateEmployees()
        {
            _employees = new List<Employee>();

            var employee1 = new Employee
            {
                Id = 1,
                FirstName = "Andrew",
                LastName = "Tolver",
                HireDate = new DateTime(1988, 8, 3)
            };
            _employees.Add(employee1);

            var employee2 = new Employee
            {
                Id = 2,
                FirstName = "Drake",
                LastName = "Black",
                HireDate = new DateTime(2001, 01, 01)
            };
            _employees.Add(employee2);

            var employee3 = new Employee
            {
                Id = 3,
                FirstName = "Caley",
                LastName = "Tolver",
                HireDate = new DateTime(1989, 1, 9)
            };
            _employees.Add(employee3);

            var employee4 = new Employee
            {
                Id = 4,
                FirstName = "Brock",
                LastName = "Kolb",
                HireDate = new DateTime(2015, 11, 28)
            };
            _employees.Add(employee4);
        }
    }
}
