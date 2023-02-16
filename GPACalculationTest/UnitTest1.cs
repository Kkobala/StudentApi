using StudentApi.Db.Entities;
using StudentApi.Models;
using StudentApi.Services;

namespace GPACalculationTest
{
    public class Tests
    {
        [Test]
        public void Calculate_Gpa_When_Score_Is_Above_91()
        {
            var calculator = new CalculateGPAService();

            var studentgrade = new List<StudentGrades>();
            studentgrade.Add(new StudentGrades
            {
                Score = 92,
                Credits = 4,
            });

            var gpacalculate = calculator.CalculateGPA(studentgrade);

            Assert.That(gpacalculate, Is.EqualTo(4.0));
        }

        [Test]
        public void Calculate_Gpa_When_Score_Is_Between_81_91()
        {
            var calculator = new CalculateGPAService();

            var studentGrade = new List<StudentGrades>();

            studentGrade.Add(new StudentGrades
            {
                Score = 86,
                Credits = 10,
            });

            var gpaCalculate = calculator.CalculateGPA(studentGrade);

            Assert.That(gpaCalculate, Is.EqualTo(3.0));
        }

        [Test]
        public void Calculate_Gpa_When_Score_Is_Between_51_61() 
        {
            var calculator = new CalculateGPAService();

            var studentgrade = new List<StudentGrades>();

            studentgrade.Add(new StudentGrades
            {
                Score = 52,
                Credits = 5,
            });

            var gpacalculate = calculator.CalculateGPA(studentgrade);

            Assert.That(gpacalculate, Is.EqualTo(0.5));
        }
    }
}