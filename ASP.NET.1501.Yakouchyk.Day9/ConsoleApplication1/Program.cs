using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace ConsoleApplication1
{
    class Program
    {
        static BinaryTree<int> tree = new BinaryTree<int>(); 
        static void Main(string[] args)
        {
            int i = 0;
            tree.Add(11);
            tree.Add(5);
            tree.Add(7);
            tree.Add(4);
            tree.Add(6);
            tree.Add(10);

            //Console.WriteLine("PostOrderTest");
            foreach (var elem in tree.PostOrder())
                Console.WriteLine("{1}: {0}", elem, ++i);
        }
    }
}
