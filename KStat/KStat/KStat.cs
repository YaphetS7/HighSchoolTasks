using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KStat
{
    class KStat
    {
        public static int KStat(int[] arr, int L, int R, int k)
        {

            int temp = Partition(arr, L, R);
            if (temp == k)
                return arr[k];

            if (k < temp)
                R = temp - 1;
            else
                L = temp + 1;

            return KStat(arr, L, R, k);
            
        }
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int Partition(int[] arr, int pivot, int second)
        {
            while (pivot != second)
            {
                if ((arr[second] <= arr[pivot] && second > pivot) || (arr[second] >= arr[pivot] && second < pivot))
                {
                    Swap(ref arr[second], ref arr[pivot]);
                    Swap(ref second, ref pivot);
                }

                if (pivot > second)
                    second++;
                else
                    second--;
            }
            return pivot;
        }
        static void Main(string[] args)
        {
            int[] a = {7, 8, 1, 4, 5, 3, 2, 0, 6 };
            

            Console.WriteLine(KStat(a, 0, 8, 1));
        }
    }
}
