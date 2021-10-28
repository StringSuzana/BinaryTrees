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
            TreeNode g = new TreeNode("g");
            TreeNode h = new TreeNode("h");
            TreeNode i = new TreeNode("i");
            TreeNode j = new TreeNode("j");
            TreeNode k = new TreeNode("k");
            TreeNode l = new TreeNode("l");
            TreeNode m = new TreeNode("m");
            TreeNode n = new TreeNode("n");
            TreeNode o = new TreeNode("o");
            TreeNode p = new TreeNode("p");
            TreeNode r = new TreeNode("r");
            TreeNode s = new TreeNode("s");
            TreeNode t = new TreeNode("t");
            TreeNode u = new TreeNode("u");
            TreeNode v = new TreeNode("v");
            BinaryTree tree = new BinaryTree();
            tree.insert(a);
            tree.insert(b);
            tree.insert(c);
            tree.insert(d);
            tree.insert(e);
            tree.insert(f);
            tree.insert(g);
            tree.insert(h);
            tree.insert(i);
            tree.insert(j);
            tree.insert(k);
            tree.insert(l);
            tree.insert(m);
            tree.insert(n);
            tree.insert(o);
            tree.insert(p);
            tree.insert(r);
            tree.insert(s);
            tree.insert(t);
            tree.insert(u);
            tree.insert(v);


            Console.WriteLine($"Depth firs iteratively: {tree.print_depth_first_search()}");
            Console.WriteLine($"Depth first search recursively: {tree.depth_first_search_recursive(tree.Root)}");
            Console.WriteLine( $"Breadth first search: {tree.breadth_first_search(tree.Root)}"); 
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
                Console.WriteLine(Root.Data);
                Root.insert_child(node);
            }
        }
        public string print_depth_first_search()
        {
            string result = string.Empty;

            Stack<TreeNode> traverse_stack = new Stack<TreeNode>();
            if (Root != null)
                traverse_stack.Push(this.Root);
            /**1. Is my stack empty?**/
            while (traverse_stack.Count > 0)
            {
                /**2.Pop, make it current**/
                var current = traverse_stack.Pop();
                result += current.Data;
                /**3.Any children?**/
                if (current.RightNode != null)
                    traverse_stack.Push(current.RightNode);
                if (current.LeftNode != null)
                    traverse_stack.Push(current.LeftNode);

            }
            return result;
        }
        public string depth_first_search_recursive(TreeNode node)
        {
            string right = "";
            string left = "";
            if (node == null) return "Empty";

            if (node.RightNode != null)
            {
                right = depth_first_search_recursive(node.RightNode);
                //Console.WriteLine("right: " + right);
            }
            if (node.LeftNode != null)
            {
                left = depth_first_search_recursive(node.LeftNode);
                //Console.WriteLine("left: " + left);
            }

            return node.Data + left + right;

        }
        public string breadth_first_search(TreeNode root)
        {
            string result = string.Empty;

            /**CAN NOT BE RECURSIVE**/
            if (root == null)
                return string.Empty;
            var traverse_queue = new Queue<TreeNode>();
            traverse_queue.Enqueue(root);
            while (traverse_queue.Count > 0)
            {
                var current = traverse_queue.Dequeue();
                result += current.Data;
                /**Traversing from left to right**/
                if (current.LeftNode != null)
                    traverse_queue.Enqueue(current.LeftNode);
                if (current.RightNode != null)
                    traverse_queue.Enqueue(current.RightNode);
            }

            return result;
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
           // Console.WriteLine(Data);
            if (LeftNode == null)
                LeftNode = node;
            else if (RightNode == null)
                RightNode = node;

            /**I want to fill my tree from left to right:.
             *              a
             *             / \ 
             *            b   c
             *           / \   |\
             *          d   e  f g
             *         /\   |\
             *        h  i  j k
             *       /\  /\
             *      l  m n o
             *     /|  |\
             *    p r  s t
             *   / \
             *  u   v
             *  
             * **/
            else if (LeftNode.RightNode == null | LeftNode.LeftNode == null)
                LeftNode.insert_child(node);
            else if (RightNode.RightNode == null | RightNode.LeftNode == null)
                RightNode.insert_child(node);
            else
                LeftNode.insert_child(node);
        }

    }

}
