using Microsoft.AspNetCore.Mvc;
using StudentApi.Models.Requests;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpPost("subject-register")]
        public async Task<IActionResult> Register(RegisterSubjectRequest request)
        {
            await _subjectRepository.AddSubjectAsync(request);
            await _subjectRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
