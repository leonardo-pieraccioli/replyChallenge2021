using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class Francesca
    {



        public void ReadAndPrint(String filePath)
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }
            file.Close();
            // System.Console.WriteLine("{0] lines", counter);
            // System.Console.ReadLine();
        }
    }
}
