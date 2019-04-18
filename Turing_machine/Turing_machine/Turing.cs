using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Turing_machine
{
    class TuringMachine
    {
        public string current_state;
        public int current_index;
        public int current_left;
        public int[] arr = new int[15];
        public string[,] matrix;
        public TuringMachine(string path)
        {
            string[] a = File.ReadAllLines(path);
            matrix = new string[a.Length, 5];
            for(int i = 0; i < a.Length; i++)
            {
                string[] temp = a[i].Split(',');
                for(int j = 0; j < 5; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
            for (int i = 0; i < 15; i++)
            {
                arr[i] = i;
            }
        }
       
    }
}
