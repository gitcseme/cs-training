using SMS.Core;
using SMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Data.Services
{
    public interface IStudentService : IService
    {
        Task CreateStudent(Student student);
        Task EditStudent(Student student);
        Task DeleteStudent(Student student);
        Student Get(Guid id);

        IEnumerable<Student> GetStudents(int pageIndex, int pageSize, bool isTrackingOff, string searchText, string orderingColumn, string orderDirection, out int total, out int totalFiltered);
        Task<(IEnumerable<Student>, int, int)> GetStudentsAsync(int pageIndex, int pageSize, bool isTrackingOff, string searchText, string orderingColumn, string orderDirection);
    }
}