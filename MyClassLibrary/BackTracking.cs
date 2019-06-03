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
            return InternalFindPathInMaze(maze, x, y, endx, endy, w, h, solution);
        }

        private bool InternalFindPathInMaze(int[,] maze, int x, int y, int endx, int endy, int w, int h, int[,] solution)
        {
            if (x >= w || y >= h || maze[x, y] != 0)
            {
                return false;
            }
            solution[x, y] = 1;
            if (x == endx && y == endy
                || InternalFindPathInMaze(maze, x + 1, y + 0, endx, endy, w, h, solution)
                || InternalFindPathInMaze(maze, x + 0, y + 1, endx, endy, w, h, solution))
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
            if (a[i, j] == w[iw])
            {
                v[i, j] = true;
                var niw = iw + 1;
                if (niw >= w.Length
                    || InternalBoggle(a, w, v, niw, i + 0, j - 1)
                    || InternalBoggle(a, w, v, niw, i + 0, j + 1)
                    || InternalBoggle(a, w, v, niw, i + 1, j - 1)
                    || InternalBoggle(a, w, v, niw, i + 1, j + 0)
                    || InternalBoggle(a, w, v, niw, i + 1, j + 1)
                    || InternalBoggle(a, w, v, niw, i - 1, j - 1)
                    || InternalBoggle(a, w, v, niw, i - 1, j + 0)
                    || InternalBoggle(a, w, v, niw, i - 1, j + 1))
                {
                    return true;
                }
                v[i, j] = false;
            }

            return false;
        }
    }
}
