﻿using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Xml;
using TextWriter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Net;

namespace TextWriter
{
    public class program
    {
        static void Main()
        {
            
            const string defaultPath = "C:\\Users\\Maxx705\\Documents\\TextWriter\\students.txt";
            
            School school = new School();

          
            List<AttendenceRecord> attendence = new List<AttendenceRecord>();

            bool run = false;

            while (run != true) 
            { 
                
            Console.WriteLine("Welcome to Class Manager");

            Console.WriteLine("Select from the following: ");

            Console.WriteLine("Press 1 to create a classroom");

            Console.WriteLine("Press 2 to take attendence");

            Console.WriteLine("Press 3 to view attendence records");

            //I want to add the ability to view attendence records by each date/day

            Console.WriteLine("Press 4 to mark a student as late");

            Console.WriteLine("Press 5 to export daily attendence");

            Console.WriteLine("Press 6 create a new student");

            Console.WriteLine("Press 7 to exit the program");



                bool validInput = false;
                int userInput = 0;

                while (!validInput)
                {
                    Console.WriteLine("Enter your choice:");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out userInput))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }



                switch (userInput)
            {
                case 1:
                        int userChoice;

                        bool validChoice = false;

                        while (validChoice != true)
                        {
                            Console.WriteLine("Add Students to your class");
                            Console.WriteLine("Enter 1 to create a class by uploading a file, or 2 to manuall enter student for the class");
                            string input = Console.ReadLine();
                            int.TryParse(input, out userChoice);

                            if (userChoice == 1)
                            {
                                int subInput;
                                List<Student> myStudents = new List<Student>();
                                Console.WriteLine("Press 1 to use the supplied file or 2 to use a different file");
                                string choice = Console.ReadLine();
                                int.TryParse(choice, out subInput);
                                if (subInput == 1)
                                {
                                    try
                                    {

                                        myStudents = FileReader.ReadFile(defaultPath);
                                        ClassRoom firstClass = ClassRoom.CreateClassRoom(myStudents);
                                        school.ClassRoomList.Add(firstClass);
                                        Console.WriteLine($"Class ID: {firstClass.ClassID}");
                                        ClassRoom.PrintStudents(firstClass);
                                        validChoice = true;
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
                                        myStudents = FileReader.ReadFile(customPath);
                                        ClassRoom firstClass = ClassRoom.CreateClassRoom(myStudents);
                                        school.ClassRoomList.Add(firstClass);
                                        Console.WriteLine($"Class ID: {firstClass.ClassID}");
                                        ClassRoom.PrintStudents(firstClass);
                                        validChoice = true;
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

                                //ClassRoom firstClass = ClassRoom.CreateClassRoom(myStudents);
                                //school.ClassRoomList.Add(firstClass);
                                //Console.WriteLine($"Class ID: {firstClass.ClassID}");
                                //ClassRoom.PrintStudents(firstClass);

                            }
                            else if (userChoice == 2)
                            {
                                List<Student> myStudents = new List<Student>();

                                bool input2 = false;
                                while (!input2)
                                {
                                    Student newStudent = Student.createStudent();
                                    myStudents.Add(newStudent);

                                    Console.WriteLine($"Successfully created {newStudent.Name}");

                                    bool validOption = false;
                                    while (!validOption)
                                    {
                                        Console.WriteLine("Create another student? Y/N");
                                        string subInput2 = Console.ReadLine().ToUpper();
                                        if (subInput2 == "Y")
                                        {
                                            validOption = true;
                                        }
                                        else if (subInput2 == "N")
                                        {
                                            validOption = true;
                                            input2 = true;
                                            validChoice = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Entry, enter Y for yes or N for no");
                                        }
                                    }
                                }

                                ClassRoom newClass = ClassRoom.CreateClassRoom(myStudents);
                                school.ClassRoomList.Add(newClass);
                                ClassRoom.PrintStudents(newClass);
                            }

                        }
                        break;
                case 2:
                        AttendenceRecord.takeClassRoomAttendence(school);
                    break;
                case 3:
                    AttendenceRecord.PrintRecords(school); 
                    break;
                    case 4:
                        AttendenceRecord.Late(school);
                        break;
                    case 5:
                        FileWriter.ExportAttendence(school);
                        break;
                    case 6:
                        Student.addOneOffStudent(school);

                        break;
                    case 7:
                        run = true;
                        break;

            }

            }

        }
        
    }
}
