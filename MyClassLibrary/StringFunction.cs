using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyClassLibrary
{
    public class StringFunction
    {
        public bool IsAnagram(string s1, string s2)
        {
            if (s1 == null || s2 == null || s1.Length != s2.Length)
            {
                return false;
            }

            var mapChar = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (!mapChar.ContainsKey(s1[i]))
                {
                    mapChar[s1[i]] = 0;
                }

                if (!mapChar.ContainsKey(s2[i]))
                {
                    mapChar[s2[i]] = 0;
                }

                mapChar[s1[i]]++;
                mapChar[s2[i]]--;
            }

            foreach (var (k, v) in mapChar)
            {
                if (v != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindrome(string value)
        {
            string s = Regex.Replace(value, @"[^\w]", string.Empty).ToLower();
            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
            }

            return true;
        }

        public string ReverseWords(string s)
        {
            char[] c = s.ToCharArray();
            this.PrivateReverse(c, 0, c.Length);
            int start = 0;
            for (int i = 0; i <= c.Length; i++)
            {
                if (i == c.Length || c[i] == ' ')
                {
                    this.PrivateReverse(c, start, i);
                    start = i + 1;
                }
            }

            return new string(c);
        }

        public bool MatchBraces(string s)
        {
            HashSet<char> open = new HashSet<char> { '{', '[', '(' };
            Dictionary<char, char> close = new Dictionary<char, char>();
            close.Add('}', '{');
            close.Add(']', '[');
            close.Add(')', '(');
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (open.Contains(c))
                {
                    stack.Push(c);
                }
                else if (close.ContainsKey(c))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char o = stack.Pop();
                    if (o != close[c])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public List<char> CountChars(string s)
        {
            var array = new CharCounter[char.MaxValue];
            for(int i =0; i<array.Length; i++)
            {
                array[i] = new CharCounter();
                array[i].Char = (char)i;
            }

            foreach (var c in s)
            {
                array[(int)c].Counter += 1;
            }

            var ordered = array
                .Where(r => r.Counter > 0)
                .OrderByDescending(r => r.Counter);
            return new List<char>(ordered.Select(r => r.Char));
        }

        private class CharCounter
        {
            public char Char { get; set; }
            public int Counter { get; set; }
        }

        private void PrivateReverse(char[] c, int start, int end)
        {
            for (int i = 0; i < (end - start) / 2; i++)
            {
                char t = c[start + i];
                c[start + i] = c[end - 1 - i];
                c[end - 1 - i] = t;
            }
        }
    }
}
