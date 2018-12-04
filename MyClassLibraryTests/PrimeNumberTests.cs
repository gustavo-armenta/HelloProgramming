using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class PrimeNumberTests
    {
        [TestMethod]
        public void FindAll()
        {
            PrimeNumber p = new PrimeNumber();
            Assert.AreEqual("2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97", p.FindAll(100).ToCsv());
        }

        [TestMethod]
        public void TryFindPrimeFactors()
        {
            PrimeNumber n = new PrimeNumber();
            int p;
            int q;
            bool b;
            b = n.TryFindPrimeFactors(4, out p, out q);
            Assert.IsTrue(b);
            Assert.AreEqual(2, p);
            Assert.AreEqual(2, q);
            b = n.TryFindPrimeFactors(9, out p, out q);
            Assert.IsTrue(b);
            Assert.AreEqual(3, p);
            Assert.AreEqual(2, q);
            b = n.TryFindPrimeFactors(125, out p, out q);
            Assert.IsTrue(b);
            Assert.AreEqual(5, p);
            Assert.AreEqual(3, q);
            b = n.TryFindPrimeFactors(126, out p, out q);
            Assert.IsFalse(b);
        }
    }
}
