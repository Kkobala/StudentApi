using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Models.Requests;

namespace StudentApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddStudentAsync(RegisterStudentRequest request)
        {
            var student = new StudentEntity()
            {
                StudentName = request.StudentName,
                StudentLastName = request.StudentLastName,
                IdNumber = request.IdNumber,
                Course = request.Course
            };

            await _db.studentEntities.AddAsync(student);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
