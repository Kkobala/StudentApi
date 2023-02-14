using StudentApi.Db.Entities;

namespace StudentApi.Services
{
    public interface ICalculateGPAService
    {
        double CalculateGPA(List<GradeEntity> gradeEntity);
    }
}
