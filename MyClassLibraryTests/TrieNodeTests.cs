using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class TrieNodeTests
    {
        [TestMethod]
        public void Autocomplete()
        {
            var p = new TrieNode();
            p.Map.Add('a', new TrieNode());
            p.Map['a'].Map.Add('r', new TrieNode());
            p.Map['a'].Map['r'].Map.Add('m', new TrieNode());
            p.Map['a'].Map['r'].Map['m'].IsWord = true;
            p.Map['a'].Map['r'].Map['m'].Map.Add('o', new TrieNode());
            p.Map['a'].Map['r'].Map['m'].Map['o'].Map.Add('r', new TrieNode());
            p.Map['a'].Map['r'].Map['m'].Map['o'].Map['r'].IsWord = true;
            p.Map['a'].Map['r'].Map.Add('t', new TrieNode());
            p.Map['a'].Map['r'].Map['t'].IsWord = true;

            Assert.AreEqual("arm,art,armor", p.Autocomplete("ar").ToCsv());
        }
    }
}
