using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface ISubjectRepository
    {
        Task AddSubjectAsync(RegisterSubjectRequest request);
        Task SaveChangesAsync();
    }
}
