using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class NodeDoubleLink<T>
    {
        public T Value { get; set; }
        public NodeDoubleLink<T> Left { get; set; }
        public NodeDoubleLink<T> Right { get; set; }
        public NodeDoubleLink(T value)
        {
            this.Value = value;
        }
    }

    public class Pointer<T>
    {
        public NodeDoubleLink<T> SwapPairsInDoubleLink(NodeDoubleLink<T> node)
        {
            var left = node;
            var right = node?.Right;
            while (left != null && right != null)
            {
                var previous = left.Left;
                var next = right.Right;
                if (previous != null) previous.Right = right;
                if (next != null) next.Left = left;
                left.Left = right;
                left.Right = next;
                right.Left = previous;
                right.Right = left;
                left = next;
                right = left?.Right;
            }

            return node?.Left;
        }
    }
}
