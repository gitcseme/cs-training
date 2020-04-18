using SMS.Core;
using SMS.Data.Entities;
using SMS.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Services
{
    public class StudentService : IStudentService
    {
        public StudentService(IStudentUnitOfWork studentUnitOfWork)
        {
            _StudentUnitOfWork = studentUnitOfWork;
        }

        private readonly IStudentUnitOfWork _StudentUnitOfWork;

        public void Dispose()
        {
            _StudentUnitOfWork.Dispose();
        }

        public async Task CreateStudent(Student student)
        {
            await _StudentUnitOfWork.Students.AddAsync(student);
            await _StudentUnitOfWork.SaveAsync();
        }

        public async Task EditStudent(Student student)
        {
            await _StudentUnitOfWork.Students.EditAsync(student);
            await _StudentUnitOfWork.SaveAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            await _StudentUnitOfWork.Students.RemoveAsync(student);
            await _StudentUnitOfWork.SaveAsync();
        }

        public IEnumerable<Student> GetStudents(int pageIndex, int pageSize, bool isTrackingOff, 
            string searchText, string orderingColumn, string orderDirection, out int total, out int totalFiltered)
        {
            total = 0;
            totalFiltered = 0;
            
            var studentData = _StudentUnitOfWork.Students.Get(s => s.Name.Contains(searchText), "", "", "", pageIndex, pageSize, true);
            total = studentData.Item2;
            totalFiltered = studentData.Item3;

            return studentData.Item1;
        }

        public async Task<(IEnumerable<Student>, int, int)> GetStudentsAsync(int pageIndex, int pageSize, bool isTrackingOff, 
            string searchText, string orderingColumn, string orderDirection)
        {
            return await _StudentUnitOfWork.Students.GetAsync(s => s.Name.Contains(searchText), "", "", "", pageIndex, pageSize, true);
        }

        public Student Get(Guid id)
        {
            return _StudentUnitOfWork.Students.Get(id);
        }
    }
}
