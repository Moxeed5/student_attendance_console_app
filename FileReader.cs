using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace TextWriter
    {
        public class FileReader
        {
        
        public static List<Student> ReadFile(string filePath)
            {
                
                List<Student> students = new List<Student>();
                

                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line = reader.ReadLine();

                        while (line != null)
                        {
                            //students.Add(counter, line);
                            //line = reader.ReadLine();
                            //counter += 1;
                            Student student = new Student();
                            student.Name = line;
                            students.Add(student);
                            line = reader.ReadLine();
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading the file: {ex.Message}");
                }

                return students;
            }
        }
    }

