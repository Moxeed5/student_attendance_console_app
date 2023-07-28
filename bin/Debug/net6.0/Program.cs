using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Xml;
using TextWriter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace TextWriter
{
    public class program
    {
        static void Main()
        {
            /*use Readfile method from FileReader class to injest external 
             document that has student names. Initialize dict and populate
            with loop that tracks a counter int. For each iteration add string name
            and int counter to dict. return dict. 
             */
            const string defaultPath = "C:\\Users\\Maxx705\\Documents\\TextWriter\\students.txt";
            Dictionary<int, string> students = new Dictionary<int, string>();

            // Initialize list of student objects and populate with info from dict */


            List<Student> myStudents = new List<Student>();

            //foreach (var item in students)
            //{
            //    Student student = new Student();
            //    student.Id = item.Key;
            //    student.Name = item.Value;
            //    myStudents.Add(student);

            //}
            List<AttendenceRecord> attendence = new List<AttendenceRecord>();

            bool run = false;

            while (run != true) 
            { 
                
                Console.WriteLine("Welcome to Class Manager");

            Console.WriteLine("Select from the following: ");

            Console.WriteLine("Press 1 to upload a list of Student names");

            Console.WriteLine("Press 2 to take attendence");

            Console.WriteLine("Press 3 to view attendence records");

            //I want to add the ability to view attendence records by each date/day

            Console.WriteLine("Press 4 to mark a student as late");

            Console.WriteLine("Press 5 to export daily attendence");

            Console.WriteLine("Press 6 to exit the program");

            

            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    bool validInput = false;
                    while (validInput != true)
                    {
                        Console.WriteLine("Press 1 to use the supplied file or 2 to use a different file");
                        int subInput = int.Parse(Console.ReadLine());
                        if (subInput == 1)
                        {
                            try
                            {
                                students = FileReader.ReadFile(defaultPath);
                                validInput = true;
                            }

                            catch (IOException ex)
                            {
                                Console.WriteLine($"Error reading the file: {ex.Message}");
                            }
                        }
                        else if (subInput == 2)
                        {
                            Console.WriteLine("Enter the path to your file: ");
                            string customPath = Console.ReadLine();
                            try
                            {
                                students = FileReader.ReadFile(customPath);
                                validInput = true;
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine($"Error reading the file: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option of 1 or 2");
                        }
                            

                            foreach (var item in students)
                            {
                                Student student = new Student();
                                student.Id = item.Key;
                                student.Name = item.Value;
                                myStudents.Add(student);

                            }

                        }
                    break;
                case 2:
                    attendence = AttendenceRecord.TakeAttendence(myStudents);
                    break;
                case 3:
                    AttendenceRecord.PrintRecords(attendence); ;
                    break;
                case 4:
                    AttendenceRecord specificStudent = AttendenceRecord.FindStudent(attendence);
                    AttendenceRecord.Late(specificStudent);
                    break;
                case 5:
                        FileWriter.ExportAttendence(attendence);
                    break;
                case 6:
                    run = true;
                    break;

            }
        }

        }








            //List<AttendenceRecord> attendence; //= AttendenceRecord.TakeAttendence(myStudents);
            
            //AttendenceRecord.PrintRecords(attendence);


            //AttendenceRecord specificStudent = AttendenceRecord.FindStudent(attendence);

            //AttendenceRecord.Late(specificStudent);



        
    }
}
