using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CourseWaitlistAPI.Tests
{
    public class CourseControllerTests
    {
        private readonly CourseController _controller;
        private readonly Mock<ICourseService> _mockService;

        public CourseControllerTests()
        {
            _mockService = new Mock<ICourseService>();
            _controller = new CourseController(_mockService.Object);
        }

        [Fact]
        public void EnrollLearner_ValidRequest_ReturnsOk()
        {
            var request = new EnrollmentRequest { LearnerId = 1, PrerequisitesMet = true };
            _mockService.Setup(s => s.EnrollLearner(request)).Returns(true);

            var result = _controller.EnrollLearner(request);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void EnrollLearner_InvalidRequest_ReturnsBadRequest()
        {
            var request = new EnrollmentRequest { LearnerId = 1, PrerequisitesMet = false };
            _mockService.Setup(s => s.EnrollLearner(request)).Returns(false);

            var result = _controller.EnrollLearner(request);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DropLearner_ValidId_ReturnsOk()
        {
            int learnerId = 1;
            _mockService.Setup(s => s.DropLearner(learnerId)).Returns(true);

            var result = _controller.DropLearner(learnerId);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DropLearner_InvalidId_ReturnsNotFound()
        {
            int learnerId = 1;
            _mockService.Setup(s => s.DropLearner(learnerId)).Returns(false);

            var result = _controller.DropLearner(learnerId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetWaitlist_ReturnsWaitlist()
        {
            var waitlist = new List<Learner> { new Learner { Id = 1, Name = "John Doe" } };
            _mockService.Setup(s => s.GetWaitlist()).Returns(waitlist);

            var result = _controller.GetWaitlist();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<List<Learner>>(okResult.Value);
            Assert.Equal(waitlist.Count, returnValue.Count);
        }

        [Fact]
        public void PromoteLearner_SeatAvailable_ReturnsOk()
        {
            _mockService.Setup(s => s.PromoteLearner()).Returns(true);

            var result = _controller.PromoteLearner();

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void PromoteLearner_NoSeatAvailable_ReturnsNotFound()
        {
            _mockService.Setup(s => s.PromoteLearner()).Returns(false);

            var result = _controller.PromoteLearner();

            Assert.IsType<NotFoundResult>(result);
        }
    }
}