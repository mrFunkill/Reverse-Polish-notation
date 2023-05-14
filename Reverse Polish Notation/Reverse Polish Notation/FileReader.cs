using System;
using System.IO;

namespace Reverse_Polish_Notation
{
    class FileReader
    {
        public static string Read()
        {
            string fileName = "File.txt";
            string line = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        return line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }
            return line;
        }
    }
}
