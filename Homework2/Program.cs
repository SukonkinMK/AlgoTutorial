using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NodeTwoLinked node1 = new NodeTwoLinked() { Value = 1 };
            node1.AddNote(2);
            node1.AddNote(3);
            NodeTwoLinked findNode = node1.FindNode(2);
            node1.AddNodeAfter(findNode, 4);
            findNode.RemoveNode(2);
            //node1.RemoveNode(findNode);
            int length = node1.GetCount();
            Console.WriteLine("length = {0}", length);

            TestClass testCase1 = new TestClass() { X = 1, arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, ExpectedValue = 0, ExpectedException = null };
            TestClass testCase2 = new TestClass() { X = 7, arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, ExpectedValue = 6, ExpectedException = null };
            TestClass testCase3 = new TestClass() { X = 15, arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, ExpectedValue = -1, ExpectedException = null };
            Console.WriteLine("Test #1");
            TestBinarySearch(testCase1);
            Console.WriteLine("Test #2");
            TestBinarySearch(testCase2);
            Console.WriteLine("Test #3");
            TestBinarySearch(testCase3);
            Console.ReadKey();
        }

        static void TestBinarySearch(TestClass testcase)
        {
            try
            {
                var actual = BinarySearch(testcase.arr, testcase.X);
                if (actual == testcase.ExpectedValue)
                {
                    Console.WriteLine("Valid Test");
                }
                else
                {
                    Console.WriteLine("Invalid Test");
                }
            }
            catch (Exception ex)
            {
                if (testcase.ExpectedException != null)
                {
                    if (ex.GetType() == testcase.ExpectedException.GetType())
                    {
                        Console.WriteLine("Valid Test");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Test");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Test");
                }
            }
        }

        /// <summary>
        /// Поиск значения в массиве бинарным поиском
        /// </summary>
        /// <param name="arr">Массив для поиска</param>
        /// <param name="value">Искомое значение</param>
        /// <returns>индекс найденного элемента или -1, если ничего не найдено</returns>
        static int BinarySearch(int[] arr, int value)
        {
            int min = 0; //О(1)
            int max = arr.Length - 1; //О(1)
            while (min < max)
            //в худшем случае при value == min или value == max 
            // алгоритм сделает log(N) шагов
            {
                int mid = (max + min) / 2;
                if (value == arr[mid])
                {
                    return mid;
                }
                else if (value < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
