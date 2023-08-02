using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    //think about adding a dependency injection container
    //there is one included in c# .NET, Microsoft.Extensions.DependencyInjection

    //double check that adding classes to school list works (school is the name of the ClassRoom obj list)

    //update attendence record object to accept school list

    //allow user to select class that they want to take attendence for

    //then let's get this thing connected to a db
    public class ClassRoom
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

        public static void CreateClassManually(List<Student> students)
        {
            ClassRoom room = new ClassRoom();
            foreach (var stu in students)
            {
                room.Class.Add(stu);
            }
            
        }

        public static void PrintStudents(ClassRoom room)
        {
            foreach (var student in room.Class)
            {
                Console.WriteLine($"Class ID: {room.ClassID}");
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"StudentID: {student.Id}");
                
            }
        }
    }
}
