using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(RegisterStudentRequest request);
        Task SaveChangesAsync();
        //Task UpdateStudentGPA(List<GradeEntity> entities, int id);
    }
}
