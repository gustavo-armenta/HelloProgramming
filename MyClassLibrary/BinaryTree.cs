using System;
using System.Collections.Generic;

namespace MyClassLibrary
{
    public class BinaryTree<T>
    {
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }
        public T Value { get; set; }

        public BinaryTree()
        {
        }

        public BinaryTree(T value)
        {
            this.Value = value;
        }

        public List<T> Preorder()
        {
            // recursion solution is print, left, right
            // iteration solution is pop, print, push right, push left
            var list = new List<T>();
            var stack = new Stack<BinaryTree<T>>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                list.Add(node.Value);
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return list;
        }

        public List<T> Inorder()
        {
            // recursion solution is left, print, right
            // iteration solution is push many left, pop, print, push right
            var list = new List<T>();
            var stack = new Stack<BinaryTree<T>>();
            var node = this;
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();
                list.Add(node.Value);
                node = node.Right;
            }

            return list;
        }

        public List<T> Postorder()
        {
            // recursion solution is left, right, print
            // iterative solution is 2 stacks and 2 loops
            List<T> list = new List<T>();
            var s1 = new Stack<BinaryTree<T>>();
            var s2 = new Stack<BinaryTree<T>>();
            var node = this;
            s1.Push(node);
            while(s1.Count > 0)
            {
                node = s1.Pop();
                s2.Push(node);
                if (node.Left != null)
                    s1.Push(node.Left);
                if (node.Right != null)
                    s1.Push(node.Right);
            }

            while(s2.Count > 0)
            {
                node = s2.Pop();
                list.Add(node.Value);
            }
            
            return list;
        }

        public bool IsBalanced()
        {
            int count = 0;
            int level = 0;
            this.InternalIsBalanced(this, ref count, ref level, 0);
            double expected = Math.Ceiling(Math.Log(count + 1, 2));
            if (expected > 2)
            {
                return expected == level;
            }
            else
            {
                return true;
            }
        }

        public List<T> FindPath(T value)
        {
            Stack<T> stack = new Stack<T>();
            this.InternalFindPath(this, stack, value);
            List<T> list = new List<T>();
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
            list.Reverse();

            return list;
        }

        public bool TryFindCommonAncestor(T value1, T value2, out T ancestor)
        {
            List<T> list1 = this.FindPath(value1);
            List<T> list2 = this.FindPath(value2);
            bool result = false;
            ancestor = default(T);
            for (int i = 0; i < list1.Count - 1 && i < list2.Count - 1; i++)
            {
                if (object.Equals(list1[i], list2[i]))
                {
                    ancestor = list1[i];
                    result = true;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public BinaryTree<ColorNode> CreateSubtree(BinaryTree<ColorNode> node)
        {
            if (node == null) return null;
            var clone = new BinaryTree<ColorNode>(new ColorNode(node.Value.Value, node.Value.IsColored));
            var left = CreateSubtree(node.Left);
            if (left != null) clone.Left = left;
            var right = CreateSubtree(node.Right);
            if (right != null) clone.Right = right;
            if (clone.Value.IsColored || clone.Left != null || clone.Right != null)
            {
                return clone;
            }

            return null;
        }

        public BinaryTree<T> BuildUsingInorderPreorder(List<T> inorder, List<T> preorder)
        {
            return this.InternalBuildUsingInorderPreorder(new Span<T>(inorder.ToArray()), new Span<T>(preorder.ToArray()));
        }

        public BinaryTree<T> BuildUsingInorderPostorder(List<T> inorder, List<T> postorder)
        {
            return this.InternalBuildUsingInorderPostorder(new Span<T>(inorder.ToArray()), new Span<T>(postorder.ToArray()));
        }

        private void InternalPreorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            list.Add(node.Value);
            this.InternalPreorder(node.Left, list);
            this.InternalPreorder(node.Right, list);
        }

        private void InternalInorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            this.InternalInorder(node.Left, list);
            list.Add(node.Value);
            this.InternalInorder(node.Right, list);
        }

        private void InternalPostorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            this.InternalPostorder(node.Left, list);
            this.InternalPostorder(node.Right, list);
            list.Add(node.Value);
        }

        private void InternalIsBalanced(BinaryTree<T> node, ref int count, ref int level, int curLevel)
        {
            if (node == null)
            {
                return;
            }

            count++;
            curLevel++;
            if (curLevel > level)
            {
                level = curLevel;
            }

            this.InternalIsBalanced(node.Left, ref count, ref level, curLevel);
            this.InternalIsBalanced(node.Right, ref count, ref level, curLevel);
        }

        private bool InternalFindPath(BinaryTree<T> node, Stack<T> stack, T value)
        {
            if (node == null)
            {
                return false;
            }

            stack.Push(node.Value);
            if (object.Equals(node.Value, value) ||
                this.InternalFindPath(node.Left, stack, value) ||
                this.InternalFindPath(node.Right, stack, value))
            {
                return true;
            }

            stack.Pop();
            return false;
        }

        private BinaryTree<T> InternalBuildUsingInorderPreorder(Span<T> inorder, Span<T> preorder)
        {
            if (inorder.Length != preorder.Length)
            {
                throw new Exception($"Different lengths. inorder={inorder.Length} preorder={preorder.Length}");
            }

            if (inorder.Length == 0)
            {
                return null;
            }

            int leftLength = 0;
            for (leftLength = 0; leftLength < inorder.Length && !object.Equals(preorder[0], inorder[leftLength]); leftLength++) ;
            if (leftLength == inorder.Length)
            {
                leftLength = 0;
            }

            int rightLength = inorder.Length - leftLength - 1;
            rightLength = rightLength > -1 ? rightLength : 0;

            BinaryTree<T> node = new BinaryTree<T>();
            node.Value = preorder[0];
            node.Left = this.InternalBuildUsingInorderPreorder(inorder.Slice(0, leftLength), preorder.Slice(1, leftLength));
            node.Right = this.InternalBuildUsingInorderPreorder(inorder.Slice(inorder.Length - rightLength, rightLength), preorder.Slice(preorder.Length - rightLength, rightLength));
            return node;
        }

        private BinaryTree<T> InternalBuildUsingInorderPostorder(Span<T> inorder, Span<T> postorder)
        {
            if (inorder.Length != postorder.Length)
            {
                throw new Exception($"Different lengths. inorder={inorder.Length} postorder={postorder.Length}");
            }

            if (inorder.Length == 0)
            {
                return null;
            }

            int leftLength = 0;
            for (leftLength = 0; leftLength < inorder.Length && !object.Equals(postorder[postorder.Length - 1], inorder[leftLength]); leftLength++) ;
            if (leftLength == inorder.Length)
            {
                leftLength = 0;
            }

            int rightLength = inorder.Length - leftLength - 1;
            rightLength = rightLength > -1 ? rightLength : 0;

            BinaryTree<T> node = new BinaryTree<T>();
            node.Value = postorder[postorder.Length - 1];
            node.Left = this.InternalBuildUsingInorderPostorder(inorder.Slice(0, leftLength), postorder.Slice(0, leftLength));
            node.Right = this.InternalBuildUsingInorderPostorder(inorder.Slice(inorder.Length - rightLength, rightLength), postorder.Slice(postorder.Length - rightLength - 1, rightLength));
            return node;
        }
    }

    public class ColorNode
    {
        public char Value { get; set; }
        public bool IsColored { get; set; }

        public ColorNode(char value, bool isColored)
        {
            Value = value;
            IsColored = isColored;
        }
    }
}
