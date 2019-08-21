using System;
using System.Linq;

namespace LINQ_BY_VENKAT
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Group By */

            var EmployeesGroupedByDept = from emp in Employee.GetAllEmployees()
                                         group emp by emp.Department into DepartmentGroup
                                         where DepartmentGroup.Count(e => e.Gender == "Female") > 0
                                         orderby DepartmentGroup.Key
                                         select new
                                         {
                                             Key = DepartmentGroup.Key,
                                             Members = from m in DepartmentGroup
                                                       orderby m.Name
                                                       select m
                                         };

            foreach (var PairOfKeyAndCollection in EmployeesGroupedByDept)
            {
                Console.WriteLine(PairOfKeyAndCollection.Key);
                Console.WriteLine("Average Salary: {0}", PairOfKeyAndCollection.Members.Sum(e => e.Salary));

                foreach (var emp in PairOfKeyAndCollection.Members)
                {
                    Console.WriteLine(" * {0} {1} {2}", emp.Name, emp.Gender, emp.Salary);
                }
                Console.WriteLine();
            }
        }
    }
}
