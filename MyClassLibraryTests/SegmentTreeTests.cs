using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class SegmentTreeTests
    {
        [TestMethod]
        public void Add()
        {
            var p = new SegmentTree();
            p.Add(new Segment(14, 15));
            p.Add(new Segment(12, 13));
            p.Add(new Segment(16, 17));
            p.Add(new Segment(10, 11));
            p.Add(new Segment(18, 19));
            Assert.AreEqual("(14,15),(12,13),(16,17),(10,11),,,(18,19)", p.List.ToCsv());
            p.Add(new Segment(14, 15));
            p.Add(new Segment(12, 13));
            p.Add(new Segment(16, 17));
            p.Add(new Segment(10, 11));
            p.Add(new Segment(18, 19));
            Assert.AreEqual("(14,15),(12,13),(16,17),(10,11),,,(18,19)", p.List.ToCsv());
            p.Add(new Segment(9, 11));
            p.Add(new Segment(18, 20));
            Assert.AreEqual("(14,15),(12,13),(16,17),(9,11),,,(18,20)", p.List.ToCsv());
        }
    }
}
