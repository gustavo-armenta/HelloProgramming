using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class PointerTests
    {
        [TestMethod]
        public void SwapPairsInDoubleLink()
        {
            var p = new Pointer<char>();
            var node = new NodeDoubleLink<char>('A');
            node.Right = new NodeDoubleLink<char>('B');
            node.Right.Right = new NodeDoubleLink<char>('C');
            node.Right.Right.Right = new NodeDoubleLink<char>('D');
            node.Right.Right.Right.Right = new NodeDoubleLink<char>('E');
            node = p.SwapPairsInDoubleLink(node);
            Assert.AreEqual('B', node.Value);
            Assert.AreEqual('A', node.Right.Value);
            Assert.AreEqual('D', node.Right.Right.Value);
            Assert.AreEqual('C', node.Right.Right.Right.Value);
            Assert.AreEqual('E', node.Right.Right.Right.Right.Value);
        }
    }
}
