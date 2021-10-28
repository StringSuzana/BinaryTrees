using System;
using System.Collections.Generic;

namespace BinaryTreeBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode("a");
            TreeNode b = new TreeNode("b");
            TreeNode c = new TreeNode("c");
            TreeNode d = new TreeNode("d");
            TreeNode e = new TreeNode("e");
            TreeNode f = new TreeNode("f");
            BinaryTree tree = new BinaryTree();
            tree.insert(a);
            tree.insert(b);
            tree.insert(c);
            tree.insert(d);
            tree.insert(e);
            tree.insert(f);

            tree.print_depth_first_search();
        }

    }
    public class BinaryTree
    {
        public TreeNode Root { get; set; }
        public void insert(TreeNode node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Root.insert_child(node);
            }
        }
        public void print_depth_first_search()
        {
            Stack<TreeNode> traverse_stack = new Stack<TreeNode>();
            if (Root != null)
                traverse_stack.Push(this.Root);
            /**1. Is my stack empty?**/
            while (traverse_stack.Count > 0)
            {
                /**2.Pop, make it current**/
                var current = traverse_stack.Pop();
                Console.WriteLine(current.Data);
                /**3.Any children?**/
                if (current.RightNode != null)
                    traverse_stack.Push(current.RightNode);
                if (current.LeftNode != null)
                    traverse_stack.Push(current.LeftNode);
            }

        }
    }
    public class TreeNode
    {
        public string Data { get; set; }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public TreeNode(string data_value)
        {
            this.Data = data_value;
        }
        public void insert_child(TreeNode node)
        {
            if (LeftNode == null)
                LeftNode = node;
            else if (RightNode == null)
                RightNode = node;

            /**I want to fill my tree from left to right on a level.
             * So thet no node can go deeper than one level more than sibling node
             *          o
             *         / \ 
             *        o   o
             *       / \
             *      o   o   <-------this far this is ok
             *     / \
             *    o   o     <-------this is forbidden
             *    
             * **/
            else if (LeftNode.RightNode == null | LeftNode.LeftNode == null)
                LeftNode.insert_child(node);
            else if (RightNode != null)
                RightNode.insert_child(node);
        }

    }

}
