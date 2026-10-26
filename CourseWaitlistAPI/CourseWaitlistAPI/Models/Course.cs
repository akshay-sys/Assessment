public class Course
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public List<Learner> EnrolledLearners { get; set; } = new List<Learner>();
    public List<Learner> Waitlist { get; set; } = new List<Learner>();
}