using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    public class AttendenceRecord
    {
        
        public DateTime Date { get; set; }
        public bool isPresent { get; set; }

        public DayOfWeek dayOfWeek { get; set; }

        public bool? isLate { get; set; }

        //public static AttendenceRecord FindStudentAttendence(Student student)
        //{
        //    Console.WriteLine("Enter the name of the student to mark as late: ");
        //    string name = Console.ReadLine();

        //    AttendenceRecord specificStudentRecord = records.FirstOrDefault(record => record.Student.Name == name);

        //    return specificStudentRecord;
        //}
        public static void Late(School school)
        {
            Console.WriteLine("Enter student to mark late: ");
            string inputname = Console.ReadLine();
            foreach(var room in school.ClassRoomList)
            {
                foreach(var stu in room.Class)
                {
                    if(stu.Name == inputname)
                    {
                        stu.Record.isLate = true;
                        stu.Record.isPresent = true;
                    }
                }

            }
        }

      

        public static void PrintRecords(School school)
        {
            
            int counter = 1;

            foreach (var room in school.ClassRoomList)
            {

                Console.WriteLine($"Press {counter} to view attendence records for Class ID: {room.ClassID}");
                counter++;
            }
            int selection = int.Parse(Console.ReadLine()) - 1;
            ClassRoom classOne = school.ClassRoomList[selection];

            foreach (var student in classOne.Class)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"StudentID: {student.Id}");
                Console.WriteLine($"Date: {student.Record.Date} : {student.Record.dayOfWeek}");
                Console.WriteLine($"Present: {student.Record.isPresent}");
                if(student.Record.isLate ==true)
                {
                    Console.WriteLine($"Tardy: arrvied at {DateTime.Now}");
                }
            }
        }
     
        //Im making Attendence record obj a property of Student
        //doing this to create a direct connection between Student objs and their attendence. 
        //I'll be able to view attendence for individual students easily as well

        //I'll need to update this method to access stu.record.isPresent, stud.record.Date, etc
        //This is because I'll be accessing attendence as a prop within Student
        public static void takeClassRoomAttendence(School school)
        {
            Console.WriteLine("Select a class to take attendence for.");
            int counter = 1;

            foreach (var room in school.ClassRoomList)
            {
                
                Console.WriteLine($"Press {counter} to take attendence for Class ID: {room.ClassID}");
                counter++;
            }
                
            int selection = int.Parse(Console.ReadLine()) - 1;

                ClassRoom classOne = school.ClassRoomList[selection];
                //List<AttendenceRecord> attendence = new List<AttendenceRecord>();
                    foreach (var stu in classOne.Class)
                    {
                        //AttendenceRecord record = new AttendenceRecord();
                        //record.Student = stu;
                        stu.Record.Date = DateTime.Now;
                        stu.Record.dayOfWeek = DateTime.Today.DayOfWeek;

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
                                stu.Record.isPresent = true;
                                stu.Record.isLate = false;
                                validInput = true;
                            }
                            else if (present == "N")
                            {
                                stu.Record.isPresent = false;
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
