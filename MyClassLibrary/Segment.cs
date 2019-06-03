using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class Segment
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Segment(int start, int end)
        {
            if (start > end) throw new ArgumentException("start > end");
            Start = start;
            End = end;
        }

        public Segment Merge(Segment s)
        {
            if (Start > s.End || End < s.Start)
                return null;
            else
                return new Segment(Math.Min(Start, s.Start), Math.Max(End, s.End));
        }

        // -1 no overlap
        // 0  equal or full overlap
        // 1  partial overlap
        public int Compare(Segment s)
        {
            if (Start > s.End || End < s.Start)
                return -1;
            else if (Start <= s.Start && End >= s.End)
                return 0;
            else
                return 1;
        }

        public override string ToString()
        {
            return $"({Start},{End})";
        }
    }
}
