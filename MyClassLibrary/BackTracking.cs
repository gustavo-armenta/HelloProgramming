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
    }
}
