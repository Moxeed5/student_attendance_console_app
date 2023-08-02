using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    public class FileWriter
    {
        public static void ExportAttendence(School school)
        {
            bool validInput = false;
            while (validInput != true)
            {
                Console.WriteLine("Press 1 to use the default export file or 2 to enter a custom path: ");


                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    try
                    {
                        var fileDate = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");
                        string exportPath = $"C:\\Users\\Maxx705\\Documents\\TextWriter\\{fileDate}.txt";
                        using (StreamWriter writer = new StreamWriter(exportPath))

                            foreach (var schoolClass in school.ClassRoomList)
                            {
                                foreach (var student in schoolClass.Class)
                                {
                                    writer.WriteLine($"Student Name: {student.Name}");
                                    writer.WriteLine($"Student ID: {student.Name}");
                                    writer.WriteLine($"{student.Record.Date}, {student.Record.dayOfWeek}");
                                    writer.WriteLine($"Present: {student.Record.isPresent}");
                                    if (student.Record.isLate == true)
                                    {
                                        writer.WriteLine("Tardy");
                                    }
                                }
                            }
                        validInput = true;
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error writing the file: {ex.Message}");
                    }
                }
                else if (userInput == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter in the export file path: ");
                        string customPath = Console.ReadLine();
                        using (StreamWriter writer = new StreamWriter(customPath))

                            foreach (var schoolClass in school.ClassRoomList)
                            {
                                foreach (var student in schoolClass.Class)
                                {
                                    writer.WriteLine($"Student Name: {student.Name}");
                                    writer.WriteLine($"Student ID: {student.Name}");
                                    writer.WriteLine($"{student.Record.Date}, {student.Record.dayOfWeek}");
                                    writer.WriteLine($"Present: {student.Record.isPresent}");
                                    if (student.Record.isLate == true)
                                    {
                                        writer.WriteLine("Tardy");
                                    }
                                }
                            }

                        validInput = true;
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error writing the file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, enter 0 or 1");
                }
            }

        }


    }
}
