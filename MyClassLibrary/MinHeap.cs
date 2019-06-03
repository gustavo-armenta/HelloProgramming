using System;
using System.Collections.Generic;

namespace MyClassLibrary
{
    public class MinHeap<K, V> where K : IComparable<K>
    {
        private List<(K key, V value)> _list;
        private int _maxSize;

        public MinHeap()
        {
            _list = new List<(K, V)>();
            _maxSize = int.MaxValue;
        }

        public MinHeap(int maxSize)
        {
            _list = new List<(K, V)>();
            _maxSize = maxSize;
        }

        public void Enqueue(K key, V value)
        {
            _list.Add((key, value));
            int ci = _list.Count - 1;
            while (ci > 0)
            {
                var pi = (ci - 1) / 2;
                if (_list[ci].key.CompareTo(_list[pi].key) >= 0)
                    break;
                var tmp = _list[ci]; _list[ci] = _list[pi]; _list[pi] = tmp;
                ci = pi;
            }

            if (_list.Count > _maxSize) Dequeue();
        }

        public (K key, V value) Dequeue()
        {
            var item = _list[0];
            int li = _list.Count - 1;
            _list[0] = _list[li];
            _list.RemoveAt(li);
            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                if (ci + 1 <= li && _list[ci + 1].key.CompareTo(_list[ci].key) < 0) ci = ci + 1;
                if (_list[pi].key.CompareTo(_list[ci].key) <= 0) break;
                var tmp = _list[pi]; _list[pi] = _list[ci]; _list[ci] = tmp;
                pi = ci;
            }

            return item;
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }
    }
}
