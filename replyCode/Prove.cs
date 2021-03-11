using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
   
    class Prove
    {
        private List<int> list = new List<int>();
        int[,] m;
        public Prove()
        {
            
        }

        public void GetMatrix() {
            m = new int[6, 3];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Inserisci valore:");
                    m[i,j]=Console.Read();
                }
            }
        }

        public void PrintMatrix()
        {
            foreach(int i in this.m)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
