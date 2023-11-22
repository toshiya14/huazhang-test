using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; set; }

        public bool IsLeaf()
        {
            return this.Left is null && this.Right is null;
        }

        public override string ToString()
        {
            return $"{Value} | left:{Left?.Value} right:{Right?.Value}";
        }
    }

    class NodeVisitor
    {
        public NodeVisitor(Node root)
        {
            this.Root = root;
        }

        public List<Node> GetLeaves()
        {
            var result = new List<Node>();
            this.Visit(result, this.Root);
            return result;
        }

        private void Visit(List<Node> history, Node node)
        {
            if (node.IsLeaf())
            {
                history.Add(node);
                return;
            }
                 
            if (node.Left is not null)
            {
                this.Visit(history, node.Left);
            }

            if (node.Right is not null)
            {
                this.Visit(history, node.Right);
            }
        }

        public Node Root { get; }

        public bool IsLeafAP() { 
            var leaves = this.GetLeaves();
            int? delta = null;
            for (var i = 1; i < leaves.Count; i++)
            {
                if (delta is null)
                {
                    delta = leaves[i].Value - leaves[i - 1].Value;
                }
                if (leaves[i].Value - leaves[i - 1].Value != delta)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
