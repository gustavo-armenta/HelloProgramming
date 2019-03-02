using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> list;
        private int maxSize;

        public PriorityQueue()
        {
            list = new List<T>();
            maxSize = int.MaxValue;
        }

        public PriorityQueue(int maxSize)
        {
            list = new List<T>();
            this.maxSize = maxSize;
        }

        public void Enqueue(T value)
        {
            list.Add(value);
            int ci = list.Count - 1;
            while (ci > 0)
            {
                var pi = (ci - 1) / 2;
                if (list[ci].CompareTo(list[pi]) >= 0)
                    break;
                T tmp = list[ci]; list[ci] = list[pi]; list[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            T item = list[0];
            int li = list.Count - 1;
            list[0] = list[li];
            list.RemoveAt(li);
            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                if (ci + 1 <= li && list[ci + 1].CompareTo(list[ci]) < 0) ci = ci + 1;
                if (list[pi].CompareTo(list[ci]) <= 0) break;
                T tmp = list[pi]; list[pi] = list[ci]; list[ci] = tmp;
                pi = ci;
            }

            return item;
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }
    }
}
