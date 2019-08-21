using System;
using System.Collections.Generic;
using System.Linq;

namespace PagingUsingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> students = Student.GetAllStudetns();

            // AsEnumerable() takes pressure from DB.
            //var res = students // Suppose it is comming from database.
            //            .AsEnumerable() // brings data in memory. Then apply filters in memory.
            //            .Where(s => s.TotalMarks > 500)
            //            .OrderBy(s => s.StudentID)
            //            .Take(3);

            do
            {
                Console.WriteLine("Enter page number  - 1,2,3, or 4");
                int pageNumber = 0;
                if (int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber >= 1 && pageNumber <= 4)
                    {
                        int pageSize = 3;
                        IEnumerable<Student> result = students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                        Console.WriteLine();

                        Console.WriteLine("Displaying page : {0}", pageNumber);
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.StudentID + "\t" + item.Name + "\t" + item.TotalMarks);
                        }
                        Console.WriteLine();
                    }
                    else Console.WriteLine("Number must be between 1 and 4");
                }
                else Console.WriteLine("Number must be between 1 and 4");
            }while(true);

        }
    }
}
