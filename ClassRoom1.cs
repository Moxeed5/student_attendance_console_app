using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    internal class ClassRoom
    {
        private static int nextClassID = 1;
        public int ClassID { get; set; }
        public List<Student> Class { get; set; }

        public ClassRoom()
        {
            ClassID = nextClassID;
            nextClassID++;
            Class = new List<Student>();

        }

        public static ClassRoom CreateClassRoom(List<Student> listOfStudents)
        {
            ClassRoom room = new ClassRoom();
            foreach (var student in listOfStudents)
            {
                room.Class.Add(student);
            }
            

            return room;
        }

        public static ClassRoom CreateClassManually()
        {
            ClassRoom room = new ClassRoom();
            Student newStu = Student.createStudent();
            room.Class.Add(newStu);
            return room;
        }

        public static void PrintStudents(ClassRoom room)
        {
            foreach (var student in room.Class)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"StudentID: {student.Id}");
                
            }
        }
    }
}
