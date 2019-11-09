using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();

        Employee Add(Employee employee);
        Employee Update(Employee EmployeeChanges);
        Employee Delete(int Id);
    }
}
