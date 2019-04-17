using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class Backtracking
    {
        public List<string> Permute(string s)
        {
            var a = s.ToCharArray();
            var results = new List<string>();
            PrivatePermute(a, 0, results);
            return results;
        }

        private void PrivatePermute(char[] a, int left, List<string> results)
        {
            if (left == a.Length)
            {
                results.Add(new string(a));
                return;
            }

            for (int i = left; i < a.Length; i++)
            {
                char c = a[left];
                a[left] = a[i];
                a[i] = c;
                PrivatePermute(a, left + 1, results);
                c = a[left];
                a[left] = a[i];
                a[i] = c;
            }
        }

        public bool FindPathInMaze(int[,] maze, int x, int y, int endx, int endy)
        {
            int w = maze.GetLength(0);
            int h = maze.GetLength(1);
            var solution = new int[w, h];
            return PrivateFindPathInMaze(solution, maze, w, h, x, y, endx, endy);
        }

        private bool PrivateFindPathInMaze(int[,] solution, int[,] maze, int w, int h, int x, int y, int endx, int endy)
        {
            if (x >= w || y >= h)
            {
                return false;
            }
            if (maze[x, y] != 0)
            {
                return false;
            }
            solution[x, y] = 1;
            if (x == endx && y == endy)
            {
                return true;
            }
            if (PrivateFindPathInMaze(solution, maze, w, h, x + 1, y, endx, endy))
            {
                return true;
            }
            if (PrivateFindPathInMaze(solution, maze, w, h, x, y + 1, endx, endy))
            {
                return true;
            }
            solution[x, y] = 0;
            return false;
        }

        public bool FindWordBoggle(char[,] a, string s)
        {
            var v = new bool[a.GetLength(0), a.GetLength(1)];
            var w = s.ToCharArray();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (InternalBoggle(a, w, v, 0, i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool InternalBoggle(char[,] a, char[] w, bool[,] v, int iw, int i, int j)
        {
            if (i < 0 || j < 0 || i >= a.GetLength(0) || j >= a.GetLength(1) || v[i, j])
            {
                return false;
            }
            else if (a[i, j] == w[iw])
            {
                v[i, j] = true;
                if (iw + 1 >= w.Length
                    || InternalBoggle(a, w, v, iw + 1, i, j - 1)
                    || InternalBoggle(a, w, v, iw + 1, i, j + 1)
                    || InternalBoggle(a, w, v, iw + 1, i + 1, j - 1)
                    || InternalBoggle(a, w, v, iw + 1, i + 1, j)
                    || InternalBoggle(a, w, v, iw + 1, i + 1, j + 1)
                    || InternalBoggle(a, w, v, iw + 1, i - 1, j - 1)
                    || InternalBoggle(a, w, v, iw + 1, i - 1, j)
                    || InternalBoggle(a, w, v, iw + 1, i - 1, j + 1))
                {
                    return true;
                }
                else
                {
                    v[i, j] = false;
                }
            }

            return false;
        }
    }
}
