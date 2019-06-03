using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Map { get; set; }
        public bool IsWord { get; set; }

        public TrieNode()
        {
            Map = new Dictionary<char, TrieNode>();
        }

        public List<string> Autocomplete(string value)
        {
            var list = new List<string>();
            var n = this;
            var s = value;
            foreach (var c in s)
            {
                if (n == null || !n.Map.ContainsKey(c)) return list;
                n = n.Map[c];
            }
            if (n == null) return list;
            var q = new Queue<(string s, TrieNode n)>();
            q.Enqueue((s, n));
            while (q.Count > 0)
            {
                (s, n) = q.Dequeue();
                if (n.IsWord) list.Add(s);
                foreach (var (c, cn) in n.Map)
                {
                    q.Enqueue((s + c, cn));
                }
            }

            return list;
        }
    }
}
