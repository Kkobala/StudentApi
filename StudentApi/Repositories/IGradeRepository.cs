using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeEntity>> GetAllAsync(int id);
        Task AddStudentGradeAsync(AddStudentGradeRequest request);
        Task SaveChangesAsync();
    }
}
