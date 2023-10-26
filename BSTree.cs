using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class BSTree
    {
        public Node Root { get; set; }

        public BSTree()
        {
            Root = null;
        }

        #region INSERT / ADD OPERATIONS
        private void InsertNode(Node tree, Node node)
        {
            // This is a recursive method used to traverse the tree
            // 1. Compare node for less than node in tree
            if (tree.Word.CompareTo(node.Word) < 0)
            {
                if (tree.Left == null)
                {
                    // 2. Left is empty, insert node
                    tree.Left = node;
                }
                else
                {
                    // 3. Left is not empty, traverse the tree using
                    //    recursive call
                    InsertNode(tree.Left, node);
                }
            }
            // 4. Compare node for greater than node in tree
            if (tree.Word.CompareTo(node.Word) > 0)
            {
                if (tree.Right == null)
                {
                    // 5. Right is empty, insert node
                    tree.Right = node;
                }
                else
                {
                    // 6. Right not empty, traverse the tree using
                    //    recursive call
                    InsertNode(tree.Right, node);
                }
            }
        }

        public void Add(string word)
        {
            Node node = new Node(word);

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                InsertNode(Root, node);
            }
        }

        private int MinValue(Node node)
        {
            // Finds the minimum node in the rightside of the tree
            int minval = node.Word.Length;
            while (node.Left != null)
            {
                // Traverse the tree replacing the minval with the
                // node on the left side of the tree
                minval = node.Left.Length;
                node = node.Left;
            }
            return minval;
        }
        #endregion

        #region DELETE OPERATIONS
        private Node Delete(Node tree, Node node)
        {
            if (tree == null)
            {
                // 1. Reached null side of the tree, return to unload stack
                return tree;
            }
            if (tree.Word.CompareTo(node.Word) < 0)
            {
                // 2. Traverse left side to find node
                tree.Left = Delete(tree.Left, node);
            }
            else if (tree.Word.CompareTo(node.Word) > 0)
            {
                // 3. Traverse right side to find node
                tree.Right = Delete(tree.Right, node);
            }
            else
            {
                // 4. Found node to delete

                // Check if node has only one child node or no child node
                if (tree.Left == null)
                {
                    // 5. Pull right side of tree up
                    return tree.Right;
                }
                else if (tree.Right == null)
                {
                    // 6. Pull left side of tree up
                    return tree.Left;
                }
                else
                {
                    // 7. Node has two leaf nodes, get the InOrder successor node
                    // (the smallest), therefore traverse right side and replace the
                    // node found with the current node
                    tree.Length = MinValue(tree.Right);

                    // 8. Traverse the right side of the tree to delete the InOrder Successor
                    tree.Right = Delete(tree.Right, tree);
                }
            }
            return tree;
        }

        public string Remove(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Word: " + word.ToString() + " Length: " + word.Length.ToString() + ", removed from the BSTree successfully!\n";
            }
            else
            {
                return "Word: " + word.ToString() + ", not found in the tree.\n";
            }
        }
        #endregion

        #region SEARCH / FIND OPERATIONS
        private Node Search(Node tree, Node node)
        {
            if (tree != null)
            {
                // 1. Have not reach the end of a branch
                if (tree.Word.CompareTo(node.Word) == 0)
                {
                    // 2. Node found
                    return tree;
                }
                if (tree.Word.CompareTo(node.Word) < 0)
                {
                    // 3. Traverse left side
                    return Search(tree.Left, node);
                }
                else
                {
                    // 4. Traverse right side
                    return Search(tree.Right, node);
                }
            }
            // 5. Not Found
            return null;
        }

        public string Find(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);
            if (node != null)
            {
                return "\nWord: " + word.ToString() + " Length: " + word.Length.ToString() + " Found in the BS Tree.\n";
            }
            else
            {
                return "\nWord: " + word.ToString() + ", not found or the tree is empty.\n";
            }
        }
        #endregion

        #region TRAVERSE ORDERS
        private string TraversePreOrder(Node node, bool isRoot = false)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                if (isRoot)
                {
                    sb.Append($"[{node.Word}] "); // Append the root node with brackets
                }
                else
                {
                    sb.Append(node.Word + " "); // Append other nodes
                }
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }

        private string TraverseInOrder(Node node, bool isRoot = false)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                if (isRoot)
                {
                    sb.Append($"[{node.Word}] "); // Append the root node with brackets
                }
                else
                {
                    sb.Append(node.Word + " "); // Append other nodes
                }
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }

        private string TraversePostOrder(Node node, bool isRoot = false)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                if (isRoot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    sb.Append($"[{node.Word}] "); // Append the root node with brackets
                    Console.ResetColor();
                }
                else
                {
                    sb.Append(node.Word + " "); // Append other nodes
                }
            }
            return sb.ToString();
        }

        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("The TREE is empty.");
            }
            else
            {
                sb.Append(TraversePreOrder(Root, true));
            }
            return sb.ToString();
        }

        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("The TREE is empty.");
            }
            else
            {
                sb.Append(TraverseInOrder(Root, true));
            }
            return sb.ToString();
        }

        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("The TREE is empty.");
            }
            else
            {
                sb.Append(TraversePostOrder(Root, true));
            }
            return sb.ToString();
        }
        #endregion
    }
}
