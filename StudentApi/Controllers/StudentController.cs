using Microsoft.AspNetCore.Mvc;
using StudentApi.Db;
using StudentApi.Models.Requests;
using StudentApi.Repositories;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentrepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly ICalculateGPAService _calculateGPAService;
        private readonly AppDbContext _db;

        public StudentController(
            IStudentRepository repository,
            IGradeRepository gradeRepository,
            ICalculateGPAService calculateGPAService,
            AppDbContext db)
        {
            _studentrepository = repository;
            _gradeRepository = gradeRepository;
            _calculateGPAService = calculateGPAService;
            _db = db;
        }

        [HttpPost("student-register")]
        public async Task<IActionResult> Register(RegisterStudentRequest request)
        {
            await _studentrepository.AddStudentAsync(request);

            return Ok();
        }

        [HttpPost("add-student-grades")]
        public async Task<IActionResult> AddStudentGrade(AddStudentGradeRequest request)
        {
            await _gradeRepository.AddStudentGradeAsync(request);
            await _gradeRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("get-student-grades")]
        public async Task<IActionResult> GetStudentGrades(int id)
        {
            var student = await _gradeRepository.GetAllAsync(id);
            await _gradeRepository.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("calculate-gpa")]
        public async Task<IActionResult> CalculateStudentGPA(int id)
        {
            var gpa = await _calculateGPAService.CalculateGPA(id);

            return Ok(gpa);
        }

        [HttpGet("top-10-student-by-gpa")]
        public async Task<IActionResult> Top10Student()
        {
            var top10Student = _db.studentEntities
                .OrderByDescending(x => x.StudentGPA)
                .Take(10);

            await _studentrepository.SaveChangesAsync();

            return Ok(top10Student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentGPA(int id)
        {
            await _calculateGPAService.UpdateStudentGPA(id);
            return NoContent();
        }
    }
}
