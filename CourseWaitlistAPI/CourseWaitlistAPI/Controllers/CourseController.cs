using Microsoft.AspNetCore.Mvc;
using CourseWaitlistAPI.Models;
using CourseWaitlistAPI.Services;

namespace CourseWaitlistAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("enroll")]
        public IActionResult EnrollLearner([FromBody] EnrollmentRequest request)
        {
            var result = _courseService.EnrollLearner(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("drop/{learnerId}")]
        public IActionResult DropLearner(int learnerId)
        {
            var result = _courseService.DropLearner(learnerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("waitlist")]
        public IActionResult GetWaitlist()
        {
            var waitlist = _courseService.GetWaitlist();
            return Ok(waitlist);
        }

        [HttpPost("promote")]
        public IActionResult PromoteLearner()
        {
            var result = _courseService.PromoteLearner();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}