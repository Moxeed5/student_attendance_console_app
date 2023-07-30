using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool? isPresent { get; set; }

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

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                try
                {
                    Console.WriteLine("Enter Student ID: ");
                    student.Id = int.Parse(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return student;
        }
    }
}
