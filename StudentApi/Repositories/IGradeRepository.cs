using StudentApi.Db.Entities;
using StudentApi.Models;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeEntity>> GetAllAsync();
        Task AddStudentGradeAsync(AddStudentGradeRequest request);
        Task<List<StudentGrades>> GetStudentGradesAsync(int studentid);
        Task SaveChangesAsync();
        Task UpdateStudentGPA(int id, double gpa);
    }
}
