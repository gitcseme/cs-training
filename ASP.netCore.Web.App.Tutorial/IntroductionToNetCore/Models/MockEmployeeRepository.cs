using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1, Name="Alamin", Department=Dept.HR, Email="abc@gmail.com"},
                new Employee() {Id=2, Name="Asad", Department=Dept.IT, Email="bcd@gmail.com"},
                new Employee() {Id=3, Name="Al Mamun", Department=Dept.IT, Email="cde@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee EmployeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == EmployeeChanges.Id);
            if (employee != null)
            {
                employee.Name = EmployeeChanges.Name;
                employee.Email = EmployeeChanges.Email;
                employee.Department = EmployeeChanges.Department;
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
