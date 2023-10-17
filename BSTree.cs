using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_BinarySearchTree
{
    internal class BSTree
    {
        public BST_Node Root { get; set; }

        public BSTree()
        {
            Root = null;
        }

        private void InsertNode(BST_Node tree, BST_Node node)
        {
            // This is a recursive methos used to traverse the tree
            // 1. Compare node for less than node in tree
            if (node.Data < tree.Data)
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
            if (node.Data > tree.Data)
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

        public void Add(int data)
        {
            BST_Node node = new BST_Node(data);

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                InsertNode(Root, node);
            }
        }

        private BST_Node Delete(BST_Node tree, BST_Node node)
        {
            if (tree == null)
            {
                // 1. Reached null side of the tree, return to unload stack
                return tree;
            }
            if (node.Data < tree.Data)
            {
                // 2. Traverse left side to find node
                tree.Left = Delete(tree.Left, node);
            }
            else if (node.Data > tree.Data)
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
                    tree.Data = MinValue(tree.Right);

                    // 8. Traverse the right side of the tree to delete the InOrder Successor
                    tree.Right = Delete(tree.Right, tree);
                }
            }
            return tree;
        }

        private int MinValue(BST_Node node)
        {
            // Finds the minimum node in the rightside of the tree
            int minval = node.Data;
            while (node.Left != null)
            {
                // Traverse the tree replacing the minval with the
                // node on the left side of the tree
                minval = node.Left.Data;
                node = node.Left;
            }
            return minval;
        }

        public string Remove(int data)
        {
            BST_Node node = new BST_Node(data);
            //node = Search(Root, node);
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + data.ToString() + ", NODE removed";
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found";
            }
        }

        #region SEARCH / FIND
        private BST_Node Search(BST_Node tree, BST_Node node)
        {
            if (tree != null)
            {
                // 1. Have not reach the end of a branch
                if (node.Data == tree.Data)
                {
                    // 2. Node found
                    return tree;
                }
                if (node.Data < tree.Data)
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

        public string Find(int data)
        {
            BST_Node node = new BST_Node(data);
            node = Search(Root, node);
            if (node != null)
            {
                return "Target: " + data.ToString() + ", NODE found: " + node.Data.ToString();
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found or Tree Empty: " + node.Data.ToString();
            }
        }
        #endregion

        #region TRAVERSE ORDERS
        private string TraversePreOrder(BST_Node node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }

        private string TraverseInOrder(BST_Node node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append(node.ToString() + " ");
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }

        private string TraversePostOrder(BST_Node node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                sb.Append(node.ToString() + " ");
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
                sb.Append(TraversePreOrder(Root));
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
                sb.Append(TraverseInOrder(Root));
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
                sb.Append(TraversePostOrder(Root));
            }
            return sb.ToString();
        }
        #endregion
    }
}
