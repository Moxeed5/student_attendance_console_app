using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace TextWriter
    {
        public class FileReader
        {
            public static Dictionary<int, string> ReadFile(string filePath)
            {
                Dictionary<int, string> students = new Dictionary<int, string>();
                int counter = 123;

                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line = reader.ReadLine();

                        while (line != null)
                        {
                            students.Add(counter, line);
                            line = reader.ReadLine();
                            counter += 1;
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

