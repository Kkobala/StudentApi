using Microsoft.AspNetCore.Mvc;
using StudentApi.Db.Entities;
using StudentApi.Models.Requests;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentrepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IGPARepository _calculateGPAService;

        public StudentController(
            IStudentRepository repository, 
            IGradeRepository gradeRepository,
            IGPARepository calculateGPAService)
        {
            _studentrepository = repository;
            _gradeRepository = gradeRepository;
            _calculateGPAService = calculateGPAService;
        }

        [HttpPost("student-register")]
        public async Task<IActionResult> Register(RegisterStudentRequest request)
        {
            await _studentrepository.AddStudentAsync(request);
            await _studentrepository.SaveChangesAsync();

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

        [HttpPost("gpa")]
        public async Task<IActionResult> CalculateStudentGPA(int id)
        {
            var gpa = await _calculateGPAService.CalculateGPA(id);

            return Ok(gpa);
        }
    }
}
