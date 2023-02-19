using Microsoft.AspNetCore.Mvc;
using StudentApi.Db;
using StudentApi.Db.Entities;
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

            var studentGrades = await _gradeRepository.GetStudentGradesAsync(request.StudentId);

            var gpa = _calculateGPAService.CalculateGPA(studentGrades);

            await _gradeRepository.UpdateStudentGPA(request.StudentId, gpa);

            return Ok();
        }

        [HttpGet("get-student-grades")]
        public async Task<IActionResult> GetStudentGrades()
        {
            var student = await _gradeRepository.GetAllAsync();

            return Ok(student);
        }

        [HttpGet("top-10-student-by-gpa")]
        public async Task<IActionResult> Top10Student()
        {
            var top10Student = _db.studentEntities
                .OrderByDescending(x => x.StudentGPA)
                .Take(10);

            return Ok(top10Student);
        }
    }
}
