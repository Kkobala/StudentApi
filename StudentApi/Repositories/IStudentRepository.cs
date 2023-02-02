using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(RegisterStudentRequest request);
        Task SaveChangesAsync();
    }
}
