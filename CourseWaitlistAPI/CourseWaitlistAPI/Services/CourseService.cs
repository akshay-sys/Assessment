using System.Collections.Generic;
using System.Linq;
using CourseWaitlistAPI.Models;

namespace CourseWaitlistAPI.Services
{
    public class CourseService
    {
        private readonly Course _course;

        public CourseService(Course course)
        {
            _course = course;
        }

        public string EnrollLearner(EnrollmentRequest request)
        {
            if (_course.EnrolledLearners.Count < _course.Capacity && request.PrerequisitesMet)
            {
                var learner = new Learner { Id = request.LearnerId };
                _course.EnrolledLearners.Add(learner);
                return "Enrollment successful.";
            }
            else if (_course.EnrolledLearners.Count >= _course.Capacity)
            {
                var learner = new Learner { Id = request.LearnerId };
                if (!_course.Waitlist.Any(w => w.Id == learner.Id))
                {
                    _course.Waitlist.Add(learner);
                    return "Course full. Added to waitlist.";
                }
                return "Already enrolled or on waitlist.";
            }
            return "Enrollment failed due to unmet prerequisites.";
        }

        public string DropLearner(int learnerId)
        {
            var learner = _course.EnrolledLearners.FirstOrDefault(l => l.Id == learnerId);
            if (learner != null)
            {
                _course.EnrolledLearners.Remove(learner);
                PromoteLearner();
                return "Learner dropped successfully.";
            }
            return "Learner not found.";
        }

        public List<Learner> GetWaitlist()
        {
            return _course.Waitlist;
        }

        public void PromoteLearner()
        {
            if (_course.EnrolledLearners.Count < _course.Capacity && _course.Waitlist.Any())
            {
                var learnerToPromote = _course.Waitlist.First();
                _course.Waitlist.Remove(learnerToPromote);
                _course.EnrolledLearners.Add(learnerToPromote);
            }
        }
    }
}