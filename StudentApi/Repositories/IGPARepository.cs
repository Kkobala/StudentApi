using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public interface IGPARepository
    {
        Task<double> CalculateGPA(int id);
        Task SaveChangesAsync();
    }
}
