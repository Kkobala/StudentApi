namespace StudentApi.Services
{
    public interface ICalculateGPAService
    {
        Task<double> CalculateGPA(int id);
        Task UpdateStudentGPA(int studentId);
    }
}
