using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_tree
{
    class DecisionTree
    {
        private int N;
        private string[] names;
        private string[,] matrix;
        public DecisionTree(string[] text)
        {
            Parse(text);

        }
        public void Parse(string[] text)
        {
            names = text[0].Split(',');
            N = text.Length;
            matrix = new string[text.Length, N];
            for(int i = 0; i < text.Length; i++)
            {
                string[] temp = text[i].Split(',');
                for(int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
        private int FindName(string name)
        {
            int ans = -1;
            for (int i = 0; i < names.Length; i++)
            {
                if (name == names[i])
                    ans = i;
            }
            if (ans == -1)
                return -1;
            return ans;
        }
        //высчитываем Энтропию критерия name
        public double Entropy(string name)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            double result = 0;
            int number = FindName(name);
            if (number == -1)
                return -1;

            for(int i = 1; i < N; i++)
            {
                if(!dict.ContainsKey(matrix[i, number]))
                {
                    dict.Add(matrix[i, number], 1);
                }
                else
                {
                    dict[matrix[i, number]]++;
                }
            }
            
            foreach (string s in dict.Keys)
            {
                double share =  (double)dict[s] / (N - 1);
                
                result += share * Math.Log(share, 2);
            }
            return -1 * result;
        }
        //Считаем Энтропию category(из столбца name) с разбиением по родительскому критерию(по умолчанию считаю, что он дан в последнем столбце)
        public double EntropyWithSeparation(string name, string category)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            double result = 0;
            int cnt = 0;
            int index = FindName(name);
            if (index == -1)
                return -1;

            for (int i = 1; i < N; i++)
            {
                if (matrix[i, index] == category)
                {
                    if (!dict.ContainsKey(matrix[i, names.Length - 1]))
                    {
                        dict.Add(matrix[i, names.Length - 1], 1);
                    }
                    else
                    {
                        dict[matrix[i, names.Length - 1]]++;
                    }
                    cnt++;
                }
            }
            foreach (string s in dict.Keys)
            {
                double share = (double)dict[s] / cnt;
                result += share * Math.Log(share, 2);
            }
            return -1 * result;
        }
        //Считаем информационную важность столбца name
        public double InformationGain(string name)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            double result = 0;
            int index = FindName(name);
            for(int i = 0; i < N; i++)
            {
                if(!dict.ContainsKey(matrix[i, index]))
                {
                    dict.Add(matrix[i, index], 1);
                }
                else
                {
                    dict[matrix[i, index]]++;
                }
            }
            foreach(string s in dict.Keys)
            {
                result += (double)dict[s] * EntropyWithSeparation(name, s) / (N - 1);
            }


            return 1 - result;
        }
    }
    class Decision_Tree
    {
        static void Main(string[] args)
        {
            string[] strs = File.ReadAllLines("text.txt");
            DecisionTree tree = new DecisionTree(strs);
            Console.WriteLine("Outlook = " + tree.InformationGain("Outlook"));
            Console.WriteLine("Temparature = " + tree.InformationGain("Temperature"));
            Console.WriteLine("Humidity = " + tree.InformationGain("Humidity"));
            Console.WriteLine("Wind = " + tree.InformationGain("Wind"));

        }
    }
}
