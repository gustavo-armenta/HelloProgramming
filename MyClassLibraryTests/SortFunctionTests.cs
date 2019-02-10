using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class SortFunctionTests
    {
        [TestMethod]
        public void MergeSort()
        {
            var a = new char[] { 'W', 'Q', 'R', 'A', 'E', 'I', 'O', 'U', 'F', 'C', 'M' };
            var p = new SortFunction();
            Assert.AreEqual("A,C,E,F,I,M,O,Q,R,U,W", p.MergeSort(a, 0, a.Length - 1).ToCsv());
        }
    }
}
