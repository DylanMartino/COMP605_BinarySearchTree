using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class AVL_Node
    {
        public int Data { get; set; }
        public AVL_Node Left { get; set; }
        public AVL_Node Right { get; set; }

        public AVL_Node()
        {
            Data = 0;
            Left = null;
            Right = null;
        }

        public AVL_Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
