using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_tree
{
    class Matrix
    {
        public int N;
        public string[,] matrix;
        public string[] names;
        public Matrix()
        {

        }
        public Matrix(string[,] matrix, string[] names, int N)
        {
            this.matrix = matrix;
            this.names = names;
            this.N = N;
           
        }
        public void PRINT()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public List<Node> FindAllCategories(string name, Node parent)
        {
            List<Node> nodes = new List<Node>();
            List<string> list = new List<string>();
            int index = FindName(name);
            for (int i = 1; i < N; i++)
            {
                if (!list.Contains(matrix[i, index]))
                {
                    Node node = new Node();
                    node.parent = parent;
                    node.index = - 1;
                    node.name = matrix[i, index];
                    list.Add(matrix[i, index]);
                    nodes.Add(node);
                }
            }
            return nodes;
        }
        public double Entropy(string name)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            double result = 0;

            int number = FindName(name);
            if (number == -1)
                return -1;

            for (int i = 1; i < N; i++)
            {

                if (matrix[i, number] != null && !dict.ContainsKey(matrix[i, number]))
                {
                    dict.Add(matrix[i, number], 1);
                }
                else
                {
                    if (matrix[i, number] != null)
                        dict[matrix[i, number]]++;
                }

            }

            foreach (string s in dict.Keys)
            {
                double share = (double)dict[s] / (N - 1);
                result += (share * Math.Log(share, 2));
            }
            return -1 * result;
        }

        //Считаем Энтропию category(из столбца name) с разбиением по родительскому критерию
        public double EntropyWithSeparation(string name, string category, string nameOfParent)
        {
            int[] indexes = new int[N];
            Dictionary<string, int> dict = new Dictionary<string, int>();
            double result = 0;
            int cnt = 0;
            int index = FindName(name);
            int indexOfParent = FindName(nameOfParent);

            if (index == -1 || indexOfParent == -1)
            {
                return -1;
            }
            int q = 0;
            for (int i = 1; i < N; i++)
            {

                if (matrix[i, index] == category)
                {
                    indexes[q] = i;
                    q++;
                    if (matrix[i, indexOfParent] != null && !dict.ContainsKey(matrix[i, indexOfParent]))
                    {
                        dict.Add(matrix[i, indexOfParent], 1);
                    }
                    else
                    {
                        if (matrix[i, indexOfParent] != null)
                            dict[matrix[i, indexOfParent]]++;
                    }
                    cnt++;
                }
            }
            bool check = true;
            for (int i = 0; i < q - 1; i++)
            {
                check = check && (matrix[indexes[i], indexOfParent] == matrix[indexes[i + 1], indexOfParent]);
            }
            if (!check)
            {
                foreach (string s in dict.Keys)
                {
                    double share = (double)dict[s] / cnt;
                    result += (double)share * Math.Log(share, 2);
                }
            }

            return -1 * result;
        }
        //Считаем информационную важность столбца name
        public double InformationGain(string name, string nameOfParent)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            double result = 0;
            int index = FindName(name);
            int indexOfParent = FindName(nameOfParent);
            for (int i = 1; i < N; i++)
            {

                if (!dict.ContainsKey(matrix[i, index]))
                {
                    dict.Add(matrix[i, index], 1);
                }
                else
                {
                    dict[matrix[i, index]]++;
                }
            }
            foreach (string s in dict.Keys)
            {
                double temp = EntropyWithSeparation(name, s, nameOfParent);
                result += (double)dict[s] * temp / (N - 1);
            }
            return Entropy(nameOfParent) - result;
        }
        public int FindName(string name)
        {
            int ans = -1;
            for (int i = 0; i < names.Length; i++)
            {
                if (name == names[i])
                    ans = i;
            }
            return ans;
        }
        public void DoMatrix(string[,] pmatrix, int size, int length, string currName, string currCategory)
        {
           
            N = 1;
            names = new string[length];
            matrix = new string[size, length];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = pmatrix[0, i];
                matrix[0, i] = pmatrix[0, i];
            }
            int index = FindName(currName);
            for(int i = 1; i < size; i++)
            {
                if(pmatrix[i, index] == currCategory)
                {
                    Build(pmatrix, i, N);
                    N++;
                }
            }
        }
        private void Build(string[,] pmatrix, int index, int cnt)
        {
            for(int i = 0; i < names.Length; i++)
            {
                matrix[cnt, i] = pmatrix[index, i];
            }
        }
    }
    class Node
    {
        public string name;
        public string answer;
        public Matrix matrix = new Matrix();
        public int index = -1;
        public List<Node> nodes = new List<Node>();
        public Node parent = null;
        public bool isLeaf = false;
    }
    class DecisionTree
    {
        public List<string> listOfUsedNames = new List<string>();
        public Node root;
        public int N;
        public string[] names;
        private bool[] check;
        public string[,] matrix;
        public DecisionTree(string[] text)
        {
            Parse(text);
            DoRoot();
        }
        public void Q(string[] str)
        {
            Node curr = root;
            while(!curr.isLeaf)
            {
                if (curr.index == -1)
                    curr = curr.nodes[0];
                else
                    curr = Move(curr, str[curr.index]);
            }
            Console.WriteLine(curr.answer);
        }
        private Node Move(Node node, string next)
        {
            foreach(Node n in node.nodes)
            {
                if(n.name == next)
                {
                    return n;
                }
               
            }
            return null;
        }
        private void DoRoot()
        {
            root = new Node();
            double max = -1;
            int index = -1;
            string name = "";
            Matrix matr = new Matrix(matrix, names, N);
            for(int i = 0; i < matr.names.Length - 1; i++)
            {
                double temp = matr.InformationGain(matr.names[i], matr.names[names.Length - 1]);
                if (temp > max)
                {
                    index = i;
                    name = matr.names[i];
                    max = temp;
                }
            }
            root.matrix = matr;
            root.index = index;
            root.matrix.matrix = matrix;
            root.name = name;
            DoTree(root);
        }
        public void CheckOnLeaf(Node node)
        {
            if (node.matrix.EntropyWithSeparation(node.parent.name, node.name, node.matrix.names[node.matrix.names.Length - 1]) == 0)
            {
                node.isLeaf = true;
                int index = node.matrix.FindName(node.parent.name);
                for(int i = 1; i < node.matrix.N; i++)
                {
                    if(node.matrix.matrix[i, index] == node.name)
                    {
                        node.answer = node.matrix.matrix[i, node.matrix.names.Length - 1];
                        return;
                    }
                }
            }
        }
        private void DoTree(Node node)
        {
            
            if (node.isLeaf)
                return;
            if(node.index == -1)
            {
                Node child = new Node();
                double max = -1;
                int index = -1;
                string name = "";
                Matrix matr = new Matrix();
                matr.DoMatrix(node.parent.matrix.matrix, node.parent.matrix.N, node.parent.matrix.names.Length, node.parent.name, node.name);
                for (int i = 0; i < matr.names.Length - 1; i++)
                {
                    if (!listOfUsedNames.Contains(matr.names[i]))
                    {    
                        double temp = matr.InformationGain(matr.names[i], matr.names[matr.names.Length - 1]);
                        if (temp > max)
                        {
                            index = i;
                            name = matr.names[i];
                            max = temp;
                        }
                    }
                }
                child.name = name;
                child.index = index;
                child.matrix = matr;
                child.parent = node;
                node.nodes.Add(child);
                DoTree(child);
                
            }
            else
            {
                node.nodes = node.matrix.FindAllCategories(node.name, node);
                listOfUsedNames.Add(node.name);
                foreach (Node a in node.nodes)
                {
                    a.matrix = new Matrix(node.matrix.matrix, node.matrix.names, node.matrix.N);
                    CheckOnLeaf(a);
                    DoTree(a);
                }
            }
        }
        public void Parse(string[] text)
        {
            names = text[0].Split(',');
            check = new bool[names.Length];
            N = text.Length;
            matrix = new string[text.Length, N];
            for (int i = 0; i < text.Length; i++)
            {
                string[] temp = text[i].Split(',');
                for (int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
    }
    class Decision_Tree
    {
        static void Main(string[] args)
        {
            string[] strs = File.ReadAllLines("text.txt");
            DecisionTree tree = new DecisionTree(strs);
            string[] res = { "Rain", "Cool", "Normal", "Weak" };
            tree.Q(res);
        }
    }
}
