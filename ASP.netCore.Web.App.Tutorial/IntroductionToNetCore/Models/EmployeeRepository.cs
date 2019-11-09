using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public EmployeeDBContext DBContext { get; }

        public Employee Add(Employee employee)
        {
            DBContext.Employees.Add(employee);
            DBContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = DBContext.Employees.Find(Id);
            if (employee != null)
                DBContext.Employees.Remove(employee);
            DBContext.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return DBContext.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return DBContext.Employees.Find(Id);
        }

        public Employee Update(Employee EmployeeChanges)
        {
            var employee = DBContext.Employees.Attach(EmployeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DBContext.SaveChanges();
            return EmployeeChanges;
        }
    }
}
