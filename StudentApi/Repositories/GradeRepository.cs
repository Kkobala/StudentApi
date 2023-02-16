using Microsoft.EntityFrameworkCore;
using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Models;
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

        public async Task<List<StudentGrades>> GetStudentGradesAsync(int studentid)
        {
            var student = await _db.studentEntities.FindAsync(studentid);

            if (student == null)
            {
                throw new ArgumentException("student not found");
            }

            var studentGrades = _db.gradeEntities
                .Include(g => g.Subject)
                .Where(g => g.StudentId == studentid)
                .Select(g => new StudentGrades
                {
                    Credits = g.Subject.Credits,
                    Score = g.Score,
                })
                .ToList();

            return studentGrades;
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
            await _db.SaveChangesAsync();
        }

        public async Task UpdateStudentGPA(int id, double gpa)
        {
            var student = await _db.studentEntities.FindAsync(id);

            student!.StudentGPA = gpa; 

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<GradeEntity>> GetAllAsync()
        {
            await _db.gradeEntities.ToListAsync();
            await _db.SaveChangesAsync();
            return _db.gradeEntities;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
