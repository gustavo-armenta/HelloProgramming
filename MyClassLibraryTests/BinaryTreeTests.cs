using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System.Linq;

namespace MyClassLibraryTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        private BinaryTree<int> oneNodeTree;
        private BinaryTree<int> unbalancedTree;
        private BinaryTree<int> balancedTree;

        [TestInitialize]
        public void Initialize()
        {
            oneNodeTree = new BinaryTree<int>();
            oneNodeTree.Value = 1;
            unbalancedTree = new BinaryTree<int>();
            unbalancedTree.Left = new BinaryTree<int>();
            unbalancedTree.Right = new BinaryTree<int>();
            unbalancedTree.Left.Left = new BinaryTree<int>();
            unbalancedTree.Left.Left.Left = new BinaryTree<int>();
            unbalancedTree.Value = 100;
            unbalancedTree.Left.Value = 50;
            unbalancedTree.Left.Left.Value = 25;
            unbalancedTree.Left.Left.Left.Value = 12;
            unbalancedTree.Right.Value = 150;
            balancedTree = new BinaryTree<int>();
            balancedTree.Left = new BinaryTree<int>();
            balancedTree.Left.Left = new BinaryTree<int>();
            balancedTree.Left.Right = new BinaryTree<int>();
            balancedTree.Right = new BinaryTree<int>();
            balancedTree.Right.Left = new BinaryTree<int>();
            balancedTree.Right.Right = new BinaryTree<int>();
            balancedTree.Value = 100;
            balancedTree.Left.Value = 50;
            balancedTree.Left.Left.Value = 25;
            balancedTree.Left.Right.Value = 75;
            balancedTree.Right.Value = 150;
            balancedTree.Right.Left.Value = 125;
            balancedTree.Right.Right.Value = 175;
        }

        [TestMethod]
        public void Preorder()
        {
            Assert.AreEqual("1", oneNodeTree.Preorder().ToCsv());
            Assert.AreEqual("100,50,25,12,150", unbalancedTree.Preorder().ToCsv());
            Assert.AreEqual("100,50,25,75,150,125,175", balancedTree.Preorder().ToCsv());
        }

        [TestMethod]
        public void Inorder()
        {
            Assert.AreEqual("1", oneNodeTree.Inorder().ToCsv());
            Assert.AreEqual("12,25,50,100,150", unbalancedTree.Inorder().ToCsv());
            Assert.AreEqual("25,50,75,100,125,150,175", balancedTree.Inorder().ToCsv());
        }

        [TestMethod]
        public void Postorder()
        {
            Assert.AreEqual("1", oneNodeTree.Postorder().ToCsv());
            Assert.AreEqual("12,25,50,150,100", unbalancedTree.Postorder().ToCsv());
            Assert.AreEqual("25,75,50,125,175,150,100", balancedTree.Postorder().ToCsv());
        }

        [TestMethod]
        public void IsBalanced()
        {
            Assert.AreEqual(true, oneNodeTree.IsBalanced());
            Assert.AreEqual(false, unbalancedTree.IsBalanced());
            Assert.AreEqual(true, balancedTree.IsBalanced());
        }

        [TestMethod]
        public void FindPath()
        {
            Assert.AreEqual("100,50,25", balancedTree.FindPath(25).ToCsv());
            Assert.AreEqual("100,50", balancedTree.FindPath(50).ToCsv());
            Assert.AreEqual("100,50,75", balancedTree.FindPath(75).ToCsv());
            Assert.AreEqual("100", balancedTree.FindPath(100).ToCsv());
            Assert.AreEqual("100,150,125", balancedTree.FindPath(125).ToCsv());
            Assert.AreEqual("100,150", balancedTree.FindPath(150).ToCsv());
            Assert.AreEqual("100,150,175", balancedTree.FindPath(175).ToCsv());
            Assert.AreEqual("", balancedTree.FindPath(10).ToCsv());
            Assert.AreEqual("", balancedTree.FindPath(60).ToCsv());
            Assert.AreEqual("", balancedTree.FindPath(110).ToCsv());
            Assert.AreEqual("", balancedTree.FindPath(200).ToCsv());
        }

        [TestMethod]
        public void CreateSubtree()
        {
            var node = new BinaryTree<ColorNode>(new ColorNode('A', false));
            node.Left = new BinaryTree<ColorNode>(new ColorNode('B', false));
            node.Right = new BinaryTree<ColorNode>(new ColorNode('C', false));
            node.Left.Left = new BinaryTree<ColorNode>(new ColorNode('D', false));
            node.Left.Right = new BinaryTree<ColorNode>(new ColorNode('E', true));
            node.Right.Left = new BinaryTree<ColorNode>(new ColorNode('F', true));
            node.Right.Right = new BinaryTree<ColorNode>(new ColorNode('G', false));

            var clone = node.CreateSubtree(node);
            var clones = clone.Preorder();
            var list = clones.Select(c => c.Value);
            Assert.AreEqual("A,B,E,C,F", list.ToCsv());
        }

        [TestMethod]
        public void TryFindCommonAncestor()
        {
            int ancestor = default(int);
            Assert.AreEqual(true, balancedTree.TryFindCommonAncestor(25, 175, out ancestor));
            Assert.AreEqual(100, ancestor);
            Assert.AreEqual(true, balancedTree.TryFindCommonAncestor(25, 75, out ancestor));
            Assert.AreEqual(50, ancestor);
            Assert.AreEqual(true, balancedTree.TryFindCommonAncestor(25, 50, out ancestor));
            Assert.AreEqual(100, ancestor);
            Assert.AreEqual(false, balancedTree.TryFindCommonAncestor(25, 10, out ancestor));
            Assert.AreEqual(default(int), ancestor);
        }

        [TestMethod]
        public void BuildUsingInorderPreorder()
        {
            BinaryTree<int> tree = null;
            tree = oneNodeTree.BuildUsingInorderPreorder(oneNodeTree.Inorder(), oneNodeTree.Preorder());
            Assert.AreEqual("1", tree.Postorder().ToCsv());
            tree = unbalancedTree.BuildUsingInorderPreorder(unbalancedTree.Inorder(), unbalancedTree.Preorder());
            Assert.AreEqual("12,25,50,150,100", tree.Postorder().ToCsv());
            tree = balancedTree.BuildUsingInorderPreorder(balancedTree.Inorder(), balancedTree.Preorder());
            Assert.AreEqual("25,75,50,125,175,150,100", tree.Postorder().ToCsv());
        }

        [TestMethod]
        public void BuildUsingInorderPostorder()
        {
            BinaryTree<int> tree = null;
            tree = oneNodeTree.BuildUsingInorderPostorder(oneNodeTree.Inorder(), oneNodeTree.Postorder());
            Assert.AreEqual("1", tree.Preorder().ToCsv());
            tree = unbalancedTree.BuildUsingInorderPostorder(unbalancedTree.Inorder(), unbalancedTree.Postorder());
            Assert.AreEqual("100,50,25,12,150", tree.Preorder().ToCsv());
            tree = balancedTree.BuildUsingInorderPostorder(balancedTree.Inorder(), balancedTree.Postorder());
            Assert.AreEqual("100,50,25,75,150,125,175", tree.Preorder().ToCsv());
        }
    }
}
