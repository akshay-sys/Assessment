using System.Collections.Generic;
using System.Linq;
using Xunit;
using CourseWaitlistAPI.Models;
using CourseWaitlistAPI.Services;

namespace CourseWaitlistAPI.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly CourseService _courseService;
        private readonly Course _course;

        public CourseServiceTests()
        {
            _course = new Course
            {
                Id = 1,
                Capacity = 2,
                EnrolledLearners = new List<Learner>(),
                Waitlist = new List<Learner>()
            };
            _courseService = new CourseService(_course);
        }

        [Fact]
        public void EnrollLearner_ShouldEnroll_WhenCapacityAvailable()
        {
            var request = new EnrollmentRequest { LearnerId = 1, PrerequisitesMet = true };
            var result = _courseService.EnrollLearner(request);
            Assert.True(result);
            Assert.Single(_course.EnrolledLearners);
        }

        [Fact]
        public void EnrollLearner_ShouldAddToWaitlist_WhenCourseIsFull()
        {
            _course.EnrolledLearners.Add(new Learner { Id = 2, Name = "Learner 2" });
            var request = new EnrollmentRequest { LearnerId = 3, PrerequisitesMet = true };
            _courseService.EnrollLearner(request);
            Assert.Single(_course.Waitlist);
            Assert.Equal(3, _course.Waitlist.First().Id);
        }

        [Fact]
        public void DropLearner_ShouldRemoveLearnerAndPromoteFromWaitlist()
        {
            _course.EnrolledLearners.Add(new Learner { Id = 1, Name = "Learner 1" });
            _course.Waitlist.Add(new Learner { Id = 2, Name = "Learner 2" });
            _course.Waitlist.Add(new Learner { Id = 3, Name = "Learner 3" });

            _courseService.DropLearner(1);
            Assert.Empty(_course.EnrolledLearners);
            Assert.Single(_course.EnrolledLearners);
            Assert.Equal(2, _course.EnrolledLearners.First().Id);
        }

        [Fact]
        public void PromoteLearner_ShouldPromoteFirstInWaitlist_WhenSeatOpens()
        {
            _course.Waitlist.Add(new Learner { Id = 1, Name = "Learner 1" });
            _course.Waitlist.Add(new Learner { Id = 2, Name = "Learner 2" });

            _courseService.PromoteLearner();
            Assert.Single(_course.EnrolledLearners);
            Assert.Equal(1, _course.EnrolledLearners.First().Id);
            Assert.Single(_course.Waitlist);
            Assert.Equal(2, _course.Waitlist.First().Id);
        }
    }
}