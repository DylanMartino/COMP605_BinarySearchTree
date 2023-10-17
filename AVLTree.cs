using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class AVLTree
    {
        public AVL_Node Root { get; set; }

        public AVLTree()
        {
            Root = null;
        }

        public void Add(int data)
        {
            // UI Call
            AVL_Node node = new AVL_Node(data);

            if (Root == null)
            {
                // Tree is empty
                Root = node;
            }
            else
            {
                Root = InsertNode(Root, node);
            }
        }

        private AVL_Node InsertNode(AVL_Node tree, AVL_Node node)
        {
            // 1. Current sub-tree node is empty, insert node here
            if (tree == null)
            {
                tree = node;
                return tree;
            }
            else if (node.Data < tree.Data)
            {
                // 2. Traverse left side, insert when null (Step 1.).
                //    then balance the tree
                tree.Left = InsertNode(tree.Left, node);
                tree = BalanceTree(tree);
            }
            else if (node.Data > tree.Data)
            {
                // 3. Traverse right side, insert when null (Step 1.),
                //    then balance the tree
                tree.Right = InsertNode(tree.Right, node);
                tree = BalanceTree(tree);
            }
            return tree;
        }

        private AVL_Node BalanceTree(AVL_Node current)
        {
            // 1. Obtain a balance reference from height of both
            //    left and right sub-trees from the current node
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                // 2. Left side of the tree is Unbalanced
                //    Decides a left or right rotation.
                if (BalanceFactor(current.Left) > 0)
                {
                    // 3. Left side requires rotation, perform a
                    //    left sub-tree rotation
                    current = RotateLL(current);
                }
                else
                {
                    // 4. Right side requires rotation, perform a
                    //    right sub-tree rotation
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                // 5. Right side of the tree is Unbalanced
                //    Decides a left or right rotation.
                if (BalanceFactor(current.Right) > 0)
                {
                    // 6. Left side requires rotation, perform a
                    //    left sub-tree rotation
                    current = RotateRL(current);
                }
                else
                {
                    // 4. Right side requires rotation, perform a
                    //    right sub-tree rotation
                    current = RotateRR(current);
                }
            }
            return current;
        }

        private AVL_Node RotateRR(AVL_Node parent)
        {
            // Perform a right rotation on the right side of the sub-tree by
            // swapping the nodes around based on reassigning the parent node
            // to the right side of the sub-tree.
            AVL_Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }

        private AVL_Node RotateRL(AVL_Node parent)
        {
            // Perform a left rotation on the right side of the sub-tree by
            // swapping the nodes around based on performing a left rotation
            // on the right side of the sub-tree.
            AVL_Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        private AVL_Node RotateLL(AVL_Node parent)
        {
            // Perform a left rotation on the left side of the sub-tree by
            // swapping the nodes around based on reassigning the parent node
            // on the left side of the sub-tree.
            AVL_Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }

        private AVL_Node RotateLR(AVL_Node parent)
        {
            // Perform a right rotation on the left side of the sub-tree by
            // swapping the nodes around based on performing a right rotation
            // on the left side of the sub-tree.
            AVL_Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private int GetHeight(AVL_Node current)
        {
            // Determine the height of the current sub-tree
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int max = Max(left, right);
                height = max + 1;
            }
            return height;
        }

        private int BalanceFactor(AVL_Node current)
        {
            // Determine if the sub-tree needs to rotate left or
            // right by finding the height of the left and right
            // sides of the subtree, and then taking the difference
            // between the left and right.
            //
            // A balance factor greater than 1(+2) indicates the
            // left side is unbalanced. A balance factor less than
            // -1 (-2) indicates the right side is unbalanced. Every
            // other balance factor does not require rotation.

            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int b_factor = left - right;
            return b_factor;
        }

        #region DELETE OPERATIONS
        private AVL_Node Delete(AVL_Node current, AVL_Node target)
        {
            AVL_Node parent = null; // Pivot Node

            if (current == null)
            {
                // Reached bottom of tree path, reverse stack order
                return null;
            }
            else
            {
                if (target.Data < current.Data)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)
                    {
                        // After possible deletion, we have to check and rebalance the tree
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (target.Data > current.Data)
                {
                    // Traverse right side of the sub-tree
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        // After possible deletion, we have to check and rebalance the tree
                        if (BalanceFactor(current.Left) <= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    // Target found
                    if (current.Right != null)
                    {
                        // Delete its InOrder successor, similar to BST deletion.
                        // Find the smallest value node on the right side of the tree
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent);
                        if (BalanceFactor(current) == 2)
                        {
                            // Must rebalance the tree
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    else
                    {
                        // Left side not null
                        return current.Left;
                    }
                }
            }
            return current;
        }

        public string Remove(int data)
        {
            // UI Method Call
            AVL_Node node = new AVL_Node(data);
            node = Search(Root, node); // Optional

            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + data.ToString() + ", NODE removed";
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found or Tree empty";
            }
        }
        #endregion

        #region SEARCH / FIND
        private AVL_Node Search(AVL_Node tree, AVL_Node node)
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
            AVL_Node node = new AVL_Node(data);
            node = Search(Root, node);
            if (node != null)
            {
                return "Target: " + data.ToString() + ", NODE found: " + node.Data.ToString();
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found or Tree Empty";
            }
        }
        #endregion

        #region TRAVERSE ORDERS
        private string TraversePreOrder(AVL_Node node)
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

        private string TraverseInOrder(AVL_Node node)
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

        private string TraversePostOrder(AVL_Node node)
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

        private int Max(int left, int right)
        {
            return left > right ? left : right;
        }
    }
}
