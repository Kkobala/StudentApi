using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _db;

        public SubjectRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddSubjectAsync(RegisterSubjectRequest request)
        {
            var sunbject = new SubjectEntity()
            {
                SubjectName = request.SubjectName,
                Credits = request.Credits,
            };

            await _db.subjectEntities.AddAsync(sunbject);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
