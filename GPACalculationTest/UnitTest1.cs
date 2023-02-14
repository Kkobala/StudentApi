using StudentApi.Db.Entities;
using StudentApi.Services;

namespace GPACalculationTest
{
    public class Tests
    {
        [Test]
        public void Calculate()
        {
            var calculator = new CalculateGPAService();

            var studentgrade = new List<GradeEntity>();
            studentgrade.Add(new GradeEntity
            {
                Id = 1,
                Score = 92,
                Credits = 4,
            });

            
            var gpacalculate = calculator.CalculateGPA(studentgrade);

            Assert.That(gpacalculate, Is.EqualTo(4.0));
        }

        [Test]
        public void CalculateGpa1() 
        {
            var calculator = new CalculateGPAService();

            var studentgrade = new List<GradeEntity>();

            studentgrade.Add(new GradeEntity
            {
                Id = 1,
                Score = 52,
                Credits = 5,
            });

            var gpacalculate = calculator.CalculateGPA(studentgrade);

            Assert.That(gpacalculate, Is.EqualTo(0.5));
        }

        [Test]
        public void CalculateGpa2()
        {
            var calculator = new CalculateGPAService();

            var studentGrade = new List<GradeEntity>();

            studentGrade.Add(new GradeEntity
            {
                Id = 1,
                Score = 86,
                Credits = 10,
            });

            var gpaCalculate = calculator.CalculateGPA(studentGrade);

            Assert.That(gpaCalculate, Is.EqualTo(3.0));
        }
    }
}