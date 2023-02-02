namespace StudentApi.Models.Requests
{
    public class AddStudentGradeRequest
    {
        public int StudentId { get; set; }
        public int SubJectId { get; set; }
        public int Score { get; set; }
    }
}
