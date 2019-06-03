using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class BreadthFirstSearch
    {
        public bool FindPathInMaze(int[,] maze, int startx, int starty, int endx, int endy)
        {
            int w = maze.GetLength(0);
            int h = maze.GetLength(1);
            var v = new int[w, h];
            var q = new Queue<(int x, int y, int c)>();
            var x = startx;
            var y = starty;
            var c = 1;
            q.Enqueue((x, y, c));
            while (q.Count > 0)
            {
                (x, y, c) = q.Dequeue();
                if (x < 0 || y < 0 || x >= w || y >= h || v[x, y] != 0) continue;
                v[x, y] = c;
                c += 1;
                q.Enqueue((x + 0, y - 1, c));
                q.Enqueue((x + 0, y + 1, c));
                q.Enqueue((x - 1, y + 0, c));
                q.Enqueue((x + 1, y + 0, c));
            }

            return v[endx, endy] > 0;
        }
    }
}
