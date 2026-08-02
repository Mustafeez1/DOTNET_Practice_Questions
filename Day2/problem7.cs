using System;
using System.Collections.Generic;

class TreeNode
{
    public string Value;
    public List<TreeNode> Children;

    public TreeNode(string value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }
}

class problem7
{
    static List<string> FlattenTree(params TreeNode[] roots)
    {
        List<string> list = new List<string>();

        int depth = 0;

        void Traverse(TreeNode node, ref int depth)
        {
            list.Add(node.Value);

            Console.WriteLine(node.Value + " Depth : " + depth);

            depth++;

            foreach (TreeNode child in node.Children)
            {
                Traverse(child, ref depth);
            }

            depth--;
        }

        foreach (TreeNode root in roots)
        {
            depth = 0;
            Traverse(root, ref depth);
        }

        return list;
    }

    static void Main(string[] args)
    {
        TreeNode A = new TreeNode("A");
        TreeNode A1 = new TreeNode("A1");
        TreeNode A2 = new TreeNode("A2");

        A.Children.Add(A1);
        A.Children.Add(A2);

        TreeNode B = new TreeNode("B");
        TreeNode B1 = new TreeNode("B1");
        TreeNode B1a = new TreeNode("B1a");
        TreeNode B1b = new TreeNode("B1b");

        B.Children.Add(B1);

        B1.Children.Add(B1a);
        B1.Children.Add(B1b);

        TreeNode C = new TreeNode("C");

        List<string> result = FlattenTree(A, B, C);

        Console.WriteLine();

        Console.WriteLine("Flatten Tree");

        foreach (string item in result)
        {
            Console.Write(item + " ");
        }
    }
}