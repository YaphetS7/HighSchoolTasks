using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM
{
    class RAM
    {
        private int[] arr;
        private int[] temp;
        public RAM(int length)
        {
            arr = new int[length + 1];
            temp = new int[length + 1];
        }
        public void Read(int value)
        {
            arr[0] = value;
        }
        public void Load(int value, int index)
        {
            arr[index] = value;
        }
        public void Copy(int value, int index)
        {
            arr[index] = value;
        }
        public void Add(int value1, int value2, int index)
        {
            arr[index] = value1 + value2;
        }
        public void Sub(int value1, int value2, int index)
        {
            arr[index] = value1 - value2;
        }
        public void Parse(string s)
        {
            int index;
            string[] str = s.Split(new char[] {' ', ',', ':', ';' });

            if(str[0] == "LOAD" || str[0] == "CPY")
            {
                index = Convert.ToInt32(str[2].Substring(1, str[2].Length - 2));
                int value = GetValue(str[1]);
                if (str[0] == "LOAD")
                    Load(value, index);
                else
                    Copy(value, index);
            }

            if(str[0] == "ADD" || str[0] == "SUB")
            {
                index = Convert.ToInt32(str[3].Substring(1, str[3].Length - 2));
                int value1 = GetValue(str[1]);
                int value2 = GetValue(str[2]);
                if (str[0] == "ADD")
                    Add(value1, value2, index);
                else
                    Sub(value1, value2, index);
            }
        }
        public void Loop(string[] text, int indexOfArray, string name)
        {
            if (arr[indexOfArray] <= 0)
                return;
            int i = 0;
            while(text[i] != name)
            {
                i++;
            }
            while(!text[i].Contains("HALT"))
            {
                i++;
                if (text[i].Contains(name))
                {
                    if (arr[indexOfArray] > 0)
                        Loop(text, indexOfArray, name);
                    else
                        return;
                }
                else
                {
                    Parse(text[i]);
                }
            }
        }
        public int GetValue(string s)
        {
            if (s.Contains("[["))
            {
                return arr[arr[Convert.ToInt32(s.Substring(2, s.Length - 4))]];
            }
            if (s.Contains("["))
            {
                return arr[Convert.ToInt32(s.Substring(1, s.Length - 2))];
            }
            return Convert.ToInt32(s);
        }
        public bool IsStateChanged()
        {
            bool check = false;
            for(int i = 1; i < 10000; i++)
            {
                if (arr[i] != temp[i])
                    check = true;
                temp[i] = arr[i];
            }
            return check;
        }
        public int GetFirst()
        {
            return arr[0];
        }
    }
}
