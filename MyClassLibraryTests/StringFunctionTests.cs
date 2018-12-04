using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class StringFunctionTests
    {
        [TestMethod]
        public void IsAnagram()
        {
            StringFunction sf = new StringFunction();
            Assert.IsTrue(sf.IsAnagram("listen", "silent"));
            Assert.IsFalse(sf.IsAnagram("abcdef", "abcdeg"));
        }

        [TestMethod]
        public void IsPalindrome()
        {
            StringFunction sf = new StringFunction();
            Assert.AreEqual(true, sf.IsPalindrome("A man, a plan, a canal, Panama!"));
            Assert.AreEqual(true, sf.IsPalindrome("Amor, Roma"));
            Assert.AreEqual(true, sf.IsPalindrome("race car"));
            Assert.AreEqual(true, sf.IsPalindrome("taco cat"));
            Assert.AreEqual(true, sf.IsPalindrome("Was it a car or a cat I saw?"));
            Assert.AreEqual(true, sf.IsPalindrome("No 'x' in Nixon"));
            Assert.AreEqual(false, sf.IsPalindrome("Not a palindrome"));
        }

        [TestMethod]
        public void ReverseWords()
        {
            StringFunction sf = new StringFunction();
            Assert.AreEqual("Panama! canal, a plan, a man, A", sf.ReverseWords("A man, a plan, a canal, Panama!"));
            Assert.AreEqual("Roma Amor,", sf.ReverseWords("Amor, Roma"));
            Assert.AreEqual("car race", sf.ReverseWords("race car"));
            Assert.AreEqual("cat taco", sf.ReverseWords("taco cat"));
            Assert.AreEqual("saw? I cat a or car a it Was", sf.ReverseWords("Was it a car or a cat I saw?"));
            Assert.AreEqual("Nixon in 'x' No", sf.ReverseWords("No 'x' in Nixon"));
        }

        [TestMethod]
        public void MatchBraces()
        {
            StringFunction sf = new StringFunction();
            Assert.IsTrue(sf.MatchBraces("_{_[_(_)_]_}_"));
            Assert.IsFalse(sf.MatchBraces("_[_(_)_]_}_"));
            Assert.IsFalse(sf.MatchBraces("_{_[_(_)_]_"));
            Assert.IsFalse(sf.MatchBraces("_{_[_(_]_}_"));
        }

        [TestMethod]
        public void CountChars()
        {
            StringFunction sf = new StringFunction();
            Assert.AreEqual("a,b,c,d,e", sf.CountChars("eddcccbbbbaaaaa").ToCsv());
        }
    }
}
