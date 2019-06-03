using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class SegmentTree
    {
        public List<Segment> List { get; private set; }
        public SegmentTree()
        {
            List = new List<Segment>();
        }

        public Segment Get(int i)
        {
            return List[i];
        }

        public void Add(Segment s)
        {
            Segment cs = s;
            int i = 0;
            for (i = 0; i < List.Count;)
            {
                var c = List[i].Compare(cs);
                if (c == -1)
                {
                    if (List[i].Start > cs.Start)
                        i = 2 * i + 1;
                    else
                        i = 2 * i + 2;
                }
                else if (c == 1)
                {
                    List[i] = List[i].Merge(cs);
                    cs = List[i];
                    break;
                }
                else
                {
                    break;
                }
            }

            if (i > List.Count - 1)
            {
                while (i > List.Count - 1)
                    List.Add(null);
                List[i] = cs;
            }
        }
    }
}
