using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class SegmentTests
    {
        [TestMethod]
        public void Compare()
        {
            var p = new Segment(4, 7);
            Assert.AreEqual(-1, p.Compare(new Segment(3, 3)));
            Assert.AreEqual(-1, p.Compare(new Segment(8, 8)));
            Assert.AreEqual(0, p.Compare(new Segment(4, 7)));
            Assert.AreEqual(0, p.Compare(new Segment(4, 6)));
            Assert.AreEqual(0, p.Compare(new Segment(5, 7)));
            Assert.AreEqual(0, p.Compare(new Segment(5, 6)));
            Assert.AreEqual(1, p.Compare(new Segment(3, 4)));
            Assert.AreEqual(1, p.Compare(new Segment(3, 5)));
            Assert.AreEqual(1, p.Compare(new Segment(3, 6)));
            Assert.AreEqual(1, p.Compare(new Segment(3, 7)));
            Assert.AreEqual(1, p.Compare(new Segment(7, 8)));
            Assert.AreEqual(1, p.Compare(new Segment(6, 8)));
            Assert.AreEqual(1, p.Compare(new Segment(5, 8)));
            Assert.AreEqual(1, p.Compare(new Segment(4, 8)));
            Assert.AreEqual(1, p.Compare(new Segment(3, 8)));
        }

        [TestMethod]
        public void Merge()
        {
            Segment s, m;
            var p = new Segment(4, 7);

            s = new Segment(4, 7);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(4, 6);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(5, 7);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(5, 6);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(0, 4);
            m = p.Merge(s);
            Assert.AreEqual(s.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(0, 6);
            m = p.Merge(s);
            Assert.AreEqual(s.Start, m.Start);
            Assert.AreEqual(p.End, m.End);

            s = new Segment(5, 11);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(s.End, m.End);

            s = new Segment(7, 11);
            m = p.Merge(s);
            Assert.AreEqual(p.Start, m.Start);
            Assert.AreEqual(s.End, m.End);

            s = new Segment(0, 3);
            m = p.Merge(s);
            Assert.IsNull(m);

            s = new Segment(8, 11);
            m = p.Merge(s);
            Assert.IsNull(m);
        }
    }
}
