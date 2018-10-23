using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(34);
            book.AddGrade(23.4f);

            GradeBook book2 = new GradeBook();
            book2.AddGrade(64);
        }
    }
}
