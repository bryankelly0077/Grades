using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer speech = new SpeechSynthesizer();
            //speech.Speak("hello bryan");

            GradeBook book = new GradeBook();
            //GradeBook book = new ThrowAwayGradeBook();
            //book.Name = null;
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException )
            {
                Console.WriteLine("Something went wroung");
            }

            //must use += or -= with events
            book.NameChanged += new NameChangedDelegate(OnNameChanged);

            book.Name = "Bryans Book";
            book.Name = "Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            

            GradeStatistics stats = book.ComputeStatistics();
            //Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(book.Name);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ":" + result);
            //C# string formatting - format options
            //Console.WriteLine("{0}:{1}", description, result);
            //format with 2 digits
            //Console.WriteLine("{0}:{1:F2}", description, result);
            //format as currency with dollar symbol
            //Console.WriteLine("{0}:{1:C}", description, result);
        }
        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}", description, result);           
        }

    }
}
