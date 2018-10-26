using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void UppercaseString()
        {
            string name = "bryan";
            //you need to assign this to the variable name. The String method ToUpper() doesn't modify the string you are pointing to,
            //it creates a new string
            name = name.ToUpper();

            Assert.AreEqual("BRYAN", name);
        }
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2018, 10, 24);
            //if you dont assign this to date i.e date=date.AddDays(1) then the test will fail. 
            //You cannot change a value type so you need to assign it to the date variable
            date = date.AddDays(1);

            Assert.AreEqual(25, date.Day);
        }
        [TestMethod]
        public void UsingArrrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }
        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }
        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
    }
}
