using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    public class Student
    {
        
        private static int nextStudentID = 1;

        public AttendenceRecord Record { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
            Id = nextStudentID;
            nextStudentID++;
            Record = new AttendenceRecord();
        }

        public static Student createStudent()
        {
            Student student = new Student();

            Console.WriteLine("Create Student");

            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Enter Student Name: ");
                    string name = Console.ReadLine();

                    if (IsValidName(name))
                    {
                        student.Name = name;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid student name. Please enter a name containing only letters.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            return student;
        }

        // Helper method to validate student name
        private static bool IsValidName(string name)
        {
            foreach (char letter in name)
            {
                if (!char.IsLetter(letter))
                {
                    return false;
                }
            }
            return true;
        }



        public static void addOneOffStudent(School school)
        {
            Student student = new Student();

            Console.WriteLine("Create Student");


            bool validInput = false;
            while (validInput != true)
            {
                try
                {
                    Console.WriteLine("Enter Student Name: ");
                    student.Name = Console.ReadLine();
                    validInput = true;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                try
                {
                    Console.WriteLine("Enter a Class ID for the class that you want to add the student to: ");
                    int assignedClass = int.Parse(Console.ReadLine());
                    foreach (var room in school.ClassRoomList)
                    {
                        if (assignedClass == room.ClassID)
                        {
                            room.Class.Add(student);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }
    }
}
