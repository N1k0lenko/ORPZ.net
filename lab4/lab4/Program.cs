using System;
using System.Collections.Generic;
namespace lab4
{
    class Program
    {
        public static Component BuildTree(string exp)
        {
            var root = new Expression();
            Component currentNode = root;
            var currentToken = GetToken(exp);
            while (currentToken != null)
            {
                exp = exp.Substring(currentToken.Length);
                switch (currentToken)
                {
                    case "(":
                        currentNode.Left = new Expression();
                        currentNode.Left.Parent = currentNode;
                        currentNode = currentNode.Left;
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        if (!string.IsNullOrEmpty(currentNode.Exp))
                        {
                            root = new Expression();
                            root.Left = currentNode;
                            currentNode.Parent = root;
                            currentNode = root;
                        }
                        currentNode.Exp = currentToken;
                        currentNode.Right = new Expression();
                        currentNode.Right.Parent = currentNode;
                        currentNode = currentNode.Right;
                        break;
                    case ")":
                        if (currentNode.Parent == null && exp.Length != 0)
                        {
                            root = new Expression();
                            root.Left = currentNode;
                            currentNode.Parent = root;
                        }
                        currentNode = currentNode.Parent;
                        break;
                    default:
                        currentNode.Exp = currentToken;
                        currentNode = currentNode.Parent;
                        break;
                }
                
                currentToken = GetToken(exp);
            }

            return root;
        }

        public static void PrintTree(Component root)
        {
            root.Print();
            if (root.Left != null)
            {
                Console.Write("Лівий: ");
                PrintTree(root.Left);
            }
            if (root.Right != null)
            {
                Console.Write("Правий: ");
                PrintTree(root.Right);
            }
        }
        public static string GetToken(string exp)
        {
            if (string.IsNullOrEmpty(exp))
                return null;
            string token = string.Empty;
            foreach (var c in exp)
            {
                if (c == '(' || c == ')' || c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (token.Length != 0)
                        break;
                    token += c;
                    break;
                }
                token += c;
            }
            return token;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write down the expression");
            string exp = Console.ReadLine();
            var root = BuildTree(exp);
            PrintTree(root);
        }
    }

    abstract class Component
    {
        public string Exp { get; set; }
        public Component Parent { get; set; }
        public Component Left { get; set; }
        public Component Right { get; set; }

        public Component()
        {           
        }
        public virtual void Print()
        {
            Console.WriteLine("Вузол " + Exp);
            if (Left == null && Right == null)
                Console.WriteLine(" Підвузли відсутні");           
        }

    }

    class Expression : Component
    {
        public Expression() : base()
        {
        }
    }
}