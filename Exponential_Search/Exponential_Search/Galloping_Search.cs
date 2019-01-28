using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponential_Search
{
    class Galloping_Search
    {
        public static int B_Search(int[] arr, int l, int r, int value)
        {
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (arr[mid] == value)
                    return mid;
                if (arr[mid] > value)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }
        public static int Galloping(int[] arr, int l, int r, int value)
        {
            if (arr[l] == value)
            {
                return l;
            }
            else
            {
                if (arr[l] < value)
                {
                    if (l == 0)
                        l = 1;
                    else
                        l *= 2;

                    if (l > r)
                    {
                        if (arr[r] == value)
                            return r;
                        if (arr[r] > value)
                            return B_Search(arr, l / 2, r, value);
                        return -1;
                    }

                    return Galloping(arr, l, r, value);
                }
                else
                    return B_Search(arr, l / 2, l, value);
               
            }

        }
        static void Main(string[] args)
        {
            int[] a = {1, 2, 3, 5, 7, 10, 15, 100, 201, 202, 206, 2000, 3000 };
            Console.WriteLine(Galloping(a, 0, a.Length - 1, 3000));
        }
    }
}
