using Microsoft.EntityFrameworkCore;
using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Models.Requests;
using StudentApi.Services;

namespace StudentApi.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ICalculateGPAService _service;
        private readonly AppDbContext _db;

        public GradeRepository(
            AppDbContext db,
            ICalculateGPAService service)
        {
            _db = db;
            _service = service;
        }

        public async Task<List<GradeEntity>> GetAllAsync(int studentid)
        {
            return await _db.gradeEntities
                .Where(x => x.StudentId == studentid)
                .Select(x => new GradeEntity
                {
                    StudentId = x.StudentId,
                    Credits = x.SubjectId,
                    Score = x.Score,
                })
                .ToListAsync();
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

        public async Task UpdateStudentGPA(int id)
        {
            var grades = await _db.gradeEntities.Where(g => g.StudentId == id).ToListAsync();

            var gpa = _service.CalculateGPA(grades);

            var grade = await _db.gradeEntities.FindAsync(id);
            grade!.StudentGPA = gpa;

            _db.gradeEntities.Update(grade);

            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
