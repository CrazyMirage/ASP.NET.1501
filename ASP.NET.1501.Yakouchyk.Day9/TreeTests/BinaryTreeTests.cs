using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BookLibrary;

namespace Tree.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        #region Int
        static BinaryTree<int> tree = new BinaryTree<int>();
        static int[] preOrderResult;
        static int[] postOrderResult;
        static int[] inOrderResult;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            tree.Add(11);
            tree.Add(5);
            tree.Add(7);
            tree.Add(4);
            tree.Add(6);
            tree.Add(10);
            tree.Add(15);
            tree.Add(18);
            tree.Add(20);
            tree.Add(25);
            tree.Add(12);
            tree.Add(17);

            postOrderResult = new[] { 4, 6, 10, 7, 5, 12, 17, 25, 20, 18, 15, 11 };
            preOrderResult = new[] { 11, 5, 4, 7, 6, 10, 15, 12, 18, 17, 20, 25 };
            inOrderResult = new[] { 4, 5, 6, 7, 10, 11, 12, 15, 17, 18, 20, 25 };
        }

        [TestMethod()]
        public void ExistTest()
        {
            Assert.IsTrue(tree.Exist(17));
        }

        [TestMethod()]
        public void PostOrderTest()
        {
            List<int> result = new List<int>(tree.PostOrder());
            CollectionAssert.AreEqual(postOrderResult, result);
        }

        [TestMethod()]
        public void PreOrderTest()
        {
            List<int> result = new List<int>(tree.PreOrder());
            CollectionAssert.AreEqual(preOrderResult, result);
        }

        [TestMethod()]
        public void InOrderTest()
        {
            List<int> result = new List<int>(tree.InOrder());
            CollectionAssert.AreEqual(inOrderResult, result);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            List<int> result = new List<int>(tree);
            CollectionAssert.AreEqual(preOrderResult, result);
        }
        #endregion

        #region Book
        [TestMethod()]
        public void AddBookTestWithoutComparator()
        {
            Book[] expected = new[] { new Book("A", "B", "", "", 0), new Book("A", "A", "", "", 43), new Book("B", "B", "", "", 12) };
            BinaryTree<Book> tree = new BinaryTree<Book>();
            foreach(var elem in expected)
                tree.Add(elem);
            List<Book> result = new List<Book>(tree);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddBookTestWithComparator()
        {
            Book[] expected = new[] { new Book("A", "B", "", "", 0), new Book("B", "B", "", "", 12), new Book("A", "A", "", "", 43) };
            BinaryTree<Book> tree = new BinaryTree<Book>((x,y) => x.SizePages - y.SizePages);
            foreach (var elem in expected)
                tree.Add(elem);
            List<Book> result = new List<Book>(tree);
            CollectionAssert.AreEqual(expected, result);
        } 
        #endregion

        #region String
        [TestMethod()]
        public void AddStringTestWithoutComparator()
        {
            String[] expected = new[] { "B", "A", "D", "C" };
            BinaryTree<String> tree = new BinaryTree<String>();
            foreach (var elem in expected)
                tree.Add(elem);
            List<String> result = new List<String>(tree);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddStringTestWithComparator()
        {
            String[] expected = new[] { "B", "D", "C", "A" };
            Comparer<String>cmp = Comparer<String>.Default;
            BinaryTree<String> tree = new BinaryTree<String>((x,y) => -cmp.Compare(x,y));
            foreach (var elem in expected)
                tree.Add(elem);
            List<String> result = new List<String>(tree);
            CollectionAssert.AreEqual(expected, result);
        } 
        #endregion


        #region Point
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void AddPointTestWithoutComparator()
        {
            Point[] expected = new[] { new Point() { X = 3, Y = 6 }, new Point() { X = 4, Y = 6 }, new Point() { X = 2, Y = 1 } };
            BinaryTree<Point> tree = new BinaryTree<Point>();
            foreach (var elem in expected)
                tree.Add(elem);
            List<Point> result = new List<Point>(tree);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddPointTestWithComparator()
        {
            Point[] expected = new[] { new Point() { X = 3, Y = 6 }, new Point() { X = 4, Y = -6 }, new Point() { X = 2, Y = 1 } };
            BinaryTree<Point> tree = new BinaryTree<Point>((x,y) => (x.X + x.Y)-(y.X + y.Y));
            foreach (var elem in expected)
                tree.Add(elem);
            List<Point> result = new List<Point>(tree);
            CollectionAssert.AreEqual(expected, result);
        } 
        #endregion
    }
}
