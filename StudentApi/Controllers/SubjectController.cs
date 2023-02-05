using Microsoft.AspNetCore.Mvc;
using StudentApi.Db;
using StudentApi.Models.Requests;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly AppDbContext _db;

        public SubjectController(
            ISubjectRepository subjectRepository,
            AppDbContext db)
        {
            _subjectRepository = subjectRepository;
            _db = db;
        }

        [HttpPost("subject-register")]
        public async Task<IActionResult> Register(RegisterSubjectRequest request)
        {
            await _subjectRepository.AddSubjectAsync(request);
            await _subjectRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("top-3-subject")]
        public async Task<IActionResult> Top3Subject()
        {
            var top3Subject = _db.subjectEntities
                           .Select(x => new
                           {
                               Subject = x,
                               AverageScore = _db.gradeEntities.Where(g => g.SubjectId == x.Id).Average(t => t.Score)
                           }).OrderByDescending(x => x.AverageScore).Take(3)
                           .Select(x => x.Subject);

            return Ok(top3Subject);
        }

        [HttpGet("bottom-3-subject")]
        public async Task<IActionResult> Bottom3Subject()
        {
            var bottom3Subject = _db.subjectEntities
                           .Select(x => new
                           {
                               Subject = x,
                               AverageScore = _db.gradeEntities.Where(g => g.SubjectId == x.Id).Average(t => t.Score)
                           }).OrderBy(x => x.AverageScore).Take(3)
                           .Select(x => x.Subject);

            return Ok(bottom3Subject);
        }
    }
}
