using StudentApi.Db.Entities;
using StudentApi.Models;

namespace StudentApi.Services
{
    public interface ICalculateGPAService
    {
        double CalculateGPA(List<StudentGrades> gradeEntity);
    }
}
