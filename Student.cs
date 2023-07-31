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
        public int Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
            Id = nextStudentID;
            nextStudentID++;
        }

        public static Student createStudent()
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
            }
            return student;
        }
    }
}
