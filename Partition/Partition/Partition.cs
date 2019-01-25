using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partition
{
    class Partition
    {
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void func(int[] arr, int pivot, int second)
        {
            if (pivot == second)
                return;
            if ((arr[second] < arr[pivot] && second > pivot) || (arr[second] >= arr[pivot] && second < pivot))
            {
                Swap(ref arr[second],ref arr[pivot]);
                Swap(ref second,ref pivot);
            }
           
            if (pivot > second)
                second++;
            else
                second--;

            func(arr, pivot, second);
        }
        static void Main(string[] args)
        {
            int[] a = {10, 40, 30, 20, 5, 10, 3, 9, 12, 43, 31 };
            func(a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + "\t");
            Console.WriteLine();
        }
    }
}
