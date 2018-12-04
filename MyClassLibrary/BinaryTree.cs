using System;
using System.Collections.Generic;

namespace MyClassLibrary
{
    public class BinaryTree<T>
    {
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }
        public T Value { get; set; }

        public List<T> Preorder()
        {
            List<T> list = new List<T>();
            this.PrivatePreorder(this, list);
            return list;
        }

        public List<T> Inorder()
        {
            List<T> list = new List<T>();
            this.PrivateInorder(this, list);
            return list;
        }

        public List<T> Postorder()
        {
            List<T> list = new List<T>();
            this.PrivatePostorder(this, list);
            return list;
        }

        public bool IsBalanced()
        {
            int count = 0;
            int level = 0;
            this.PrivateIsBalanced(this, ref count, ref level, 0);
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
            this.PrivateFindPath(this, stack, value);
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

        public BinaryTree<T> BuildUsingInorderPreorder(List<T> inorder, List<T> preorder)
        {
            return this.PrivateBuildUsingInorderPreorder(new Span<T>(inorder.ToArray()), new Span<T>(preorder.ToArray()));
        }

        public BinaryTree<T> BuildUsingInorderPostorder(List<T> inorder, List<T> postorder)
        {
            return this.PrivateBuildUsingInorderPostorder(new Span<T>(inorder.ToArray()), new Span<T>(postorder.ToArray()));
        }

        private void PrivatePreorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            list.Add(node.Value);
            this.PrivatePreorder(node.Left, list);
            this.PrivatePreorder(node.Right, list);
        }

        private void PrivateInorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            this.PrivateInorder(node.Left, list);
            list.Add(node.Value);
            this.PrivateInorder(node.Right, list);
        }

        private void PrivatePostorder(BinaryTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            this.PrivatePostorder(node.Left, list);
            this.PrivatePostorder(node.Right, list);
            list.Add(node.Value);
        }

        private void PrivateIsBalanced(BinaryTree<T> node, ref int count, ref int level, int curLevel)
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

            this.PrivateIsBalanced(node.Left, ref count, ref level, curLevel);
            this.PrivateIsBalanced(node.Right, ref count, ref level, curLevel);
        }

        private bool PrivateFindPath(BinaryTree<T> node, Stack<T> stack, T value)
        {
            if (node == null)
            {
                return false;
            }

            stack.Push(node.Value);
            if (object.Equals(node.Value, value) ||
                this.PrivateFindPath(node.Left, stack, value) ||
                this.PrivateFindPath(node.Right, stack, value))
            {
                return true;
            }

            stack.Pop();
            return false;
        }

        private BinaryTree<T> PrivateBuildUsingInorderPreorder(Span<T> inorder, Span<T> preorder)
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
            node.Left = this.PrivateBuildUsingInorderPreorder(inorder.Slice(0, leftLength), preorder.Slice(1, leftLength));
            node.Right = this.PrivateBuildUsingInorderPreorder(inorder.Slice(inorder.Length - rightLength, rightLength), preorder.Slice(preorder.Length - rightLength, rightLength));
            return node;
        }

        private BinaryTree<T> PrivateBuildUsingInorderPostorder(Span<T> inorder, Span<T> postorder)
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
            node.Left = this.PrivateBuildUsingInorderPostorder(inorder.Slice(0, leftLength), postorder.Slice(0, leftLength));
            node.Right = this.PrivateBuildUsingInorderPostorder(inorder.Slice(inorder.Length - rightLength, rightLength), postorder.Slice(postorder.Length - rightLength - 1, rightLength));
            return node;
        }
    }
}
