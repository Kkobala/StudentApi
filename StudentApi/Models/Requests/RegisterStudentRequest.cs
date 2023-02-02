namespace StudentApi.Models.Requests
{
    public class RegisterStudentRequest
    {
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string IdNumber { get; set; }
        public string Course { get; set; }
    }
}
