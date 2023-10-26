using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Node
    {
        public string Word { get; set; }

        public int Length { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
            Word = null;
            Length = 0;
            Left = null;
            Right = null;
        }

        public Node(string word)
        {
            this.Word = word;
            this.Length = word.Length;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Word.ToString();
        }
    }
}
