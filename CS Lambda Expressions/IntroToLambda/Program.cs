using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a = () => Console.WriteLine("hello!!! Action\n");
            a();
            
            //takeFAsParameter(print);
            
            Sel sq = (x) => x * x;
            Console.WriteLine(sq(5));


            GenDel<int, int> func = x => x * x; // using built in generic delegate
            Func<int, int> built_in = x => x * x; // using built in generic delegate

            List<Employee> employees = new List<Employee>() {
                new Employee { Name = "Arif", Salary = 2000},
                new Employee { Name = "Hosen", Salary = 8000},
                new Employee { Name = "Hasan", Salary = 5000}
            };

            DelLogic delLogic = (s) => s.Salary > 4000;

            //Employee.GetHighestPayedSalary(employees, (s) => s.Salary > 3000);
            Employee.GetHighestPayedSalary(employees, delLogic);

        }

        public delegate int Sel(int x);
        public delegate TResult GenDel<T, TResult>(T arg);

        public delegate bool DelLogic(Employee emp);
        public static bool logic(Employee emp)
        {
            return emp.Salary > 5000 ? true : false;
        }

        public class Employee
        {
            public string Name { get; set; }
            public int Salary { get; set; }

            public static void GetHighestPayedSalary(List<Employee> empList, DelLogic delLogic)
            {
                foreach (var emp in empList)
                {
                    if (delLogic(emp))
                        Console.WriteLine(emp.Salary);
                }
            }
        }

        private static void takeFAsParameter(Delprint<int> print)
        {
            print(555);
        }

        public delegate TResult LambdaCatcher<T, out TResult>(T arg);

        delegate void Delprint<T>(T x);
        public static void print(int num)
        {
            Console.WriteLine(num);
        }
    }
}
