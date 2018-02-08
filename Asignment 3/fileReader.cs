using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment_3
{
    class FileReader
    {
        List<String> result = new List<String>();
        public List<String> readFile(String filename)
        {
            int counter = 0;
            string line;

            //string filePath = System.IO.Path.GetFullPath(filename);
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                result.Add(line);
                counter++;
            }

            file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            //System.Console.ReadLine();
            return result;
        }
    }
}
