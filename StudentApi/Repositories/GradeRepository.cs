using Microsoft.EntityFrameworkCore;
using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _db;

        public GradeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<GradeEntity>> GetAllAsync(int id)
        {
            return await _db.gradeEntities.Where(x => x.Id == id).ToListAsync();
        }

        public async Task AddStudentGradeAsync(AddStudentGradeRequest request)
        {
            var grade = new GradeEntity();

            grade.Score = request.Score;
            grade.SubjectId = request.SubJectId;
            grade.StudentId = request.StudentId;

            if (request.Score < 0 && request.Score > 100)
            {
                throw new ArgumentException("Grade cannot be less than 0 or more then 100");
            }

            await _db.gradeEntities.AddAsync(grade);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
