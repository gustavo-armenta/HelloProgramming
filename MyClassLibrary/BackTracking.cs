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
            PrivatePermute(a, 0, a.Length, results);
            return results;
        }

        private void PrivatePermute(char[] a, int left, int right, List<string> results)
        {
            if (left == right)
            {
                results.Add(new string(a));
            }
            else
            {
                for (int i = left; i < right; i++)
                {
                    char c = a[left];
                    a[left] = a[i];
                    a[i] = c;
                    PrivatePermute(a, left + 1, right, results);
                    c = a[left];
                    a[left] = a[i];
                    a[i] = c;
                }
            }
        }

        public bool FindPathInMaze(int[,] maze)
        {
            int w = maze.GetLength(0);
            int h = maze.GetLength(1);
            var solution = new int[w, h];
            return PrivateFindPathInMaze(solution, maze, w, h, 0, 0, w - 1, h - 1);
        }

        private bool PrivateFindPathInMaze(int[,] solution, int[,] maze, int w, int h, int x, int y, int gx, int gy)
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
            if (x == gx && y == gy)
            {
                return true;
            }
            if (PrivateFindPathInMaze(solution, maze, w, h, x + 1, y, gx, gy))
            {
                return true;
            }
            if (PrivateFindPathInMaze(solution, maze, w, h, x, y + 1, gx, gy))
            {
                return true;
            }
            solution[x, y] = 0;
            return false;
        }
    }
}
