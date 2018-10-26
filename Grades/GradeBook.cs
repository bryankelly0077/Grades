using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public virtual GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                //if (grade > stats.HighestGrade)
                //{
                //    stats.HighestGrade = grade;
                //}
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value) && NameChanged != null)
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    //this is passsing the gradebook
                    NameChanged(this, args);
                }
                _name = value;

            }
        }
        public event NameChangedDelegate NameChanged;

        private string _name;
        public List<float> grades;
    }
}
