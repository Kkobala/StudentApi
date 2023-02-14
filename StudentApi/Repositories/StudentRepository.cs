using StudentApi.Db;
using StudentApi.Db.Entities;
using StudentApi.Db.Mapping;
using StudentApi.Models.Requests;
using StudentApi.Services;

namespace StudentApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;
        private readonly ICalculateGPAService _service;

        public StudentRepository(
            AppDbContext db,
            ICalculateGPAService service)
        {
            _db = db;
            _service = service;
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
            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
