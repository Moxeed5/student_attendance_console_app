using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    internal class AttendenceRecord
    {
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public bool isPresent { get; set; }

        public DayOfWeek dayOfWeek { get; set; }

        public bool? isLate { get; set; }

        public static AttendenceRecord FindStudent(List<AttendenceRecord> records)
        {
            Console.WriteLine("Enter the name of the student to mark as late: ");
            string name = Console.ReadLine();

            AttendenceRecord specificStudentRecord = records.FirstOrDefault(record => record.Student.Name == name);

            return specificStudentRecord;
        }
        public static void Late(AttendenceRecord studentRecord)
        {
            
            studentRecord.isLate = true;
            studentRecord.isPresent = true;
        }

      

        public static void PrintRecords(List<AttendenceRecord> attendence)
        {
            foreach (var record in attendence)
            {
                Console.WriteLine($"Student Name: {record.Student.Name}");
                Console.WriteLine($"StudentID: {record.Student.Id}");
                Console.WriteLine($"Date: {record.Date} {record.dayOfWeek}");
                Console.WriteLine($"Present: {record.isPresent}");
                if(record.isLate ==true)
                {
                    Console.WriteLine($"Tardy: arrvied at {DateTime.Now}");
                }
            }
        }
        public static List<AttendenceRecord> TakeAttendence(List<Student> myStudents)
        {
            List<AttendenceRecord> attendence = new List<AttendenceRecord>();
            foreach (var stu in myStudents)
            {
                AttendenceRecord record = new AttendenceRecord();
                record.Student = stu;
                record.Date = DateTime.Now;
                record.dayOfWeek = DateTime.Today.DayOfWeek;

                Console.WriteLine(stu.Name);
                Console.WriteLine(stu.Id);

                bool validInput = false;

                while (validInput != true)
                {
                    Console.WriteLine("Is student present? \n" +
                    "Y/N");
                    string present = Console.ReadLine().Trim().ToUpper();

                    if (present == "Y")
                    {
                        record.isPresent = true;
                        record.isLate = false;
                        validInput = true;
                    }
                    else if (present == "N")
                    {
                        record.isPresent = false;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, enter Y or N");
                    }
                }

                attendence.Add(record);
            }
                return attendence;
        }

        public static void takeClassRoomAttendence(School school)
        {
            Console.WriteLine("Select a class to take attendence for.");
            int counter = 1;

            foreach (var room in school.ClassRoomList)
            {
                
                Console.WriteLine($"Press {counter} to take attendence for {room.ClassID}");
                counter++;
            }
                int selection = int.Parse(Console.ReadLine()) - 1;

                ClassRoom classOne = school.ClassRoomList[selection];
                List<AttendenceRecord> attendence = new List<AttendenceRecord>();
                    foreach (var stu in classOne.Class)
                    {
                        AttendenceRecord record = new AttendenceRecord();
                        record.Student = stu;
                        record.Date = DateTime.Now;
                        record.dayOfWeek = DateTime.Today.DayOfWeek;

                        Console.WriteLine(stu.Name);
                        Console.WriteLine(stu.Id);

                        bool validInput = false;

                        while (validInput != true)
                        {
                            Console.WriteLine("Is student present? \n" +
                            "Y/N");
                            string present = Console.ReadLine().Trim().ToUpper();

                            if (present == "Y")
                            {
                                record.isPresent = true;
                                record.isLate = false;
                                validInput = true;
                            }
                            else if (present == "N")
                            {
                                record.isPresent = false;
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, enter Y or N");
                            }
                        }
                    }                             
        }
    }   
}
