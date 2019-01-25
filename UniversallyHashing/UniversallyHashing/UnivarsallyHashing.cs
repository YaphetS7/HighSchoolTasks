using System;


namespace UniversallyHashing
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        public int number_of_hash_func;

        public HashTable(int sz, int stp, int number_of_hash_func)
        {
            if (number_of_hash_func <= 0 || number_of_hash_func >= 4)
                throw new InvalidOperationException();
            this.number_of_hash_func = number_of_hash_func;
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }
        private long Hash1(string value)
        {
            char[] a = new char[value.Length];
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += a[i] - '0';
            }
            return (sum % size);
        }
        private long Hash2(string value)
        {
            char[] a = new char[value.Length];
            long sum = 0;
            long p_pow = 7;
            long p = 7;
            for (int i = 1; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += (a[i] - '0') * p_pow;
                p_pow = p_pow * p;
            }
            sum += a[0] - '0';
            return (sum % size);
        }
        private long Hash3(string value)
        {
            char[] a = new char[value.Length];
            long sum = 0;
            long p_pow = value.Length;
            if (p_pow > 31)
                p_pow = 53;
            else
                p_pow = 31;
            long p = p_pow;
            for (int i = 1; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += (a[i] - '0') * p_pow;
                p_pow = (p_pow * p);
            }
            sum += a[0] - '0';
            return (sum % size);
        }
        public long HashFun(string value)
        {
            if (number_of_hash_func == 1)
                return Hash1(value);
            if (number_of_hash_func == 2)
                return Hash2(value);
            else
                return Hash3(value);
            // всегда возвращает корректный индекс слота
            //return 0;
        }

        public long SeekSlot(string value)
        {
            long i;
            i = HashFun(value);
            while (i < size && slots[i] != null)
            {
                i += step;
            }
            if (i >= size)
            {
                i = 0;
                while (i < size && slots[i] != null)
                    i++;
            }
            if (i >= size)
                return -1;
            return i;
            // находит индекс пустого слота для значения, или -1
            //return -1;
        }

        public long Put(string value)
        {
            long i;
            i = SeekSlot(value);
            if (i != -1)
            {
                slots[i] = value;
            }
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return i;
        }

        public long Find(string value)
        {
            long i = HashFun(value);
            if (value == slots[i])
                return i;
            else
            {
                for (i = 0; i < size; i++)
                    if (slots[i] == value)
                        return i;
                return -1;
            }
            // находит индекс слота со значением, или -1
            //return -1;
        }
    }
}
