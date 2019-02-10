using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClassLibrary
{
    public class SortFunction
    {
        public char[] MergeSort(char[] a, int start, int end)
        {
            if (end > start)
            {
                int mid = (start + end) / 2;
                MergeSort(a, start, mid);
                MergeSort(a, mid + 1, end);
                InternalMerge(a, start, mid + 1, end);
            }
            return a;
        }

        private void InternalMerge(char[] a, int start, int mid, int end)
        {
            Console.WriteLine($"InternalMerge({start},{mid},{end})");
            char[] temp = new char[(end + 1) - start];
            int i = 0, left = start, right = mid;
            while (i < temp.Length)
            {
                if (left < mid && right <= end)
                {
                    if (a[left] <= a[right])
                    {
                        temp[i++] = a[left++];
                    }
                    else
                    {
                        temp[i++] = a[right++];
                    }
                }
                else if (left < mid)
                {
                    temp[i++] = a[left++];
                }
                else
                {
                    temp[i++] = a[right++];
                }
            }
            i = 0;
            left = start;
            while (i < temp.Length)
            {
                a[left++] = temp[i++];
            }
        }
    }
}
