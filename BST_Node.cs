using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_BinarySearchTree
{
    internal class BST_Node
    {
        public int Data { get; set; }
        public BST_Node Left { get; set; }
        public BST_Node Right { get; set; }

        public BST_Node() 
        { 
            Data = 0;
            Left = null;
            Right = null;
        }

        public BST_Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
