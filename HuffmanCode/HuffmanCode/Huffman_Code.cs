using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    class Huffman_Code
    {
        static void Main(string[] args)
        {
            HuffmanCode hf = new HuffmanCode();
            string a = "мама мыла раму";
            string result = hf.Converting(a);

            Console.WriteLine("Исходная строка: мама мыла раму");
           
            Console.WriteLine("Кодировка каждого символа:");
            foreach(BinaryInterpretation bi in hf.chars)
            {
                Console.WriteLine(bi.symbol + " - " + bi.bin);
            }
            Console.WriteLine("Готовая строка:");
            
            Console.WriteLine(result);
        }
    }
    class KeyValue
    {
        public string key;
        public int value;
        public int priority;
        public KeyValue left, right;
        public KeyValue(string key, int value)
        {
            this.key = key;
            left = null;
            right = null;
            this.value = value;
        }
        public KeyValue(int priority)
        {
            this.priority = priority;
            left = null;
            right = null;
        }
    }
    class BinaryInterpretation
    {
        public string symbol;
        public string bin;
        public BinaryInterpretation(string symbol, string bin)
        {
            this.symbol = symbol;
            this.bin = bin;
        }
    }
    class HuffmanCode
    {
        private KeyValue root;
        private string currStr;
        private List<KeyValue> list = new List<KeyValue>();
        public List<BinaryInterpretation> chars = new List<BinaryInterpretation>();
        public string Converting(string input)
        {
            list.Clear();
            currStr = input;
            string output = "";
            Counter(input);
            Search(root, "");
            output = Result();
            return output;
        }
        private void Counter(string str)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(Convert.ToString(str[i])))
                {
                    dict.Add(Convert.ToString(str[i]), 1);
                }
                else
                {
                    dict[Convert.ToString(str[i])]++;
                }
            }
            foreach(KeyValuePair<string, int> k in dict)
            {
                KeyValue kv = new KeyValue(k.Key, k.Value);
                kv.priority = k.Value;
                list.Add(kv);
            }
            DoTree();
        }
        private string Result()
        {
            string result = currStr;
            foreach(BinaryInterpretation a in chars)
            {
                result = result.Replace(a.symbol, a.bin);
            }

            return result;
        }
        private void Search(KeyValue node, string s)
        {
            if (node.left == null && node.right == null)
                chars.Add(new BinaryInterpretation(node.key, s)); 
            else
            {
                if (node.left != null)
                    Search(node.left, s + "0");
                if (node.right != null)
                    Search(node.right, s + "1");
            }
        }
        private void DoTree()
        {
            int i = list.Count - 1;
            while (list.Count >= 1)
            {
                if (list.Count == 1)
                {
                    root = list[0];
                    break;
                }
                else
                {
                    int val1 = list[i].priority;
                    int val2 = list[i - 1].priority;
                    int val3 = -1;
                    if (i - 2 >= 0)
                    {
                        val3 = list[i - 2].priority;
                        if (val1 + val2 > val2 + val3)
                        {
                            i--;
                        }
                        else
                        {
                            KeyValue temp = new KeyValue(val1 + val2);
                            temp.left = list[i];
                            temp.right = list[i - 1];
                            list.Remove(temp.left);
                            list.Remove(temp.right);
                            list.Add(temp);
                            i--;
                        }
                    }
                    else
                    {
                        KeyValue temp = new KeyValue(val1 + val2);
                        temp.left = list[i];
                        temp.right = list[i - 1];
                        list.Remove(temp.left);
                        list.Remove(temp.right);
                        list.Add(temp);
                    }
                }  
            }
        }


    }
}
