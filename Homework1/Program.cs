using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Program
    {
        static int TEST_VALUE = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1");
            TestCase testCase1 = new TestCase() { X = 2, ExpectedValue = 0, ExpectedFlag = true, ExpectedException = null };
            TestCase testCase2 = new TestCase() { X = 4, ExpectedValue = 0, ExpectedFlag = false, ExpectedException = null };
            TestCase testCase3 = new TestCase() { X = -1, ExpectedValue = 0, ExpectedFlag = true, ExpectedException = new ArgumentException() };
            TestTask1(testCase1);
            TestTask1(testCase2);
            TestTask1(testCase3);
            Console.WriteLine("Задача 3");
            TestCase testCase4 = new TestCase() { X = 0, ExpectedValue = 0, ExpectedFlag = true, ExpectedException = null };
            TestCase testCase5 = new TestCase() { X = 8, ExpectedValue = 21, ExpectedFlag = true, ExpectedException = null };
            TestCase testCase6 = new TestCase() { X = -1, ExpectedValue = 0, ExpectedFlag = true, ExpectedException = new ArgumentException() };
            Console.WriteLine("Тесты с рекурсией");
            TestFibonachi(testCase4,true);
            TestFibonachi(testCase5, true);
            TestFibonachi(testCase6, true);
            Console.WriteLine("Тесты без рекурсии");
            TestFibonachi(testCase4, false);
            TestFibonachi(testCase5, false);
            TestFibonachi(testCase6, false);
            Console.ReadKey();
        }

        /// <summary>
        /// Класс для задания тест условий
        /// </summary>
        public class TestCase
        {
            public int X { get; set; }
            public int ExpectedValue { get; set; }
            public bool ExpectedFlag { get; set; }
            public Exception ExpectedException { get; set; }
        }
       /// <summary>
       /// Тест задачи 1
       /// </summary>
       /// <param name="testCase">параметры теста</param>
        static void TestTask1(TestCase testCase)
        {
            try
            {
                TEST_VALUE = testCase.X;
                bool actual = Task1();
                if (actual == testCase.ExpectedFlag)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        /// <summary>
        /// Тест для функций Фибоначи
        /// </summary>
        /// <param name="testCase">Параметры теста</param>
        /// <param name="">С рекурсией или без</param>
        static void TestFibonachi(TestCase testCase, bool recursive)
        {
            try
            {
                int actual;
                if (recursive)
                    actual = FibonachiRecursive(testCase.X);
                else
                    actual = FibonachiNotRecursive(testCase.X);
                if (actual == testCase.ExpectedValue)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        /// <summary>
        /// Задача 1. составить функцию по блок-схеме
        /// </summary>
        /// <returns>true - простое, false - не простое</returns>
        static bool Task1()
        {
            int number = TEST_VALUE;
            if (number < 0)
            {
                throw new ArgumentException("n must be positive");
            }
            int d = 0, i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;

            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Задача 2. Посчитать сложность алгоритма
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0;  // O(1)
                        if (j != 0)  // O(1)
                        {
                            y = k / j;  // O(1)
                        }
                        sum += inputArray[i] + i + k + j + y;  // O(1)
                    }
                }
            }
            return sum; // O(1)
            // Суммарная сложность O(1 + N * N * (N * 4) + 1) = O(N^3)
        }

        /// <summary>
        /// Вычисление элемента последовательности Фиббоначи через рекурсию
        /// </summary>
        /// <param name="n"> номер элемента последовательности Фиббоначи</param>
        /// <returns>значение элемента последовательности Фиббоначи</returns>
        static int FibonachiRecursive(int n)
        {
            if(n < 0)
            {
                throw new ArgumentException("n must be positive");
            }
            if(n == 0)
            {
                return 0;
            }
            else if(n == 1)
            {
                return 1;
            }
            else
            {
                return FibonachiRecursive(n - 1) + FibonachiRecursive(n - 2);
            }
        }
        /// <summary>
        /// Вычисление элемента последовательности Фиббоначи без рекурсии
        /// </summary>
        /// <param name="n"> номер элемента последовательности Фиббоначи</param>
        /// <returns>значение элемента последовательности Фиббоначи</returns>
        static int FibonachiNotRecursive(int n)
        {
            int f_1 = 0, f_2 = 1;
            if (n < 0)
            {
                throw new ArgumentException("n must be positive");
            }
            else if (n == 0)
            {
                return f_1;
            }
            else if (n == 1)
            {
                return f_2;
            }
            else
            {
                for(int i = 2; i < n; i++)
                {
                    int next = f_2 + f_1;
                    f_1 = f_2;
                    f_2 = next;
                }
                return f_2 + f_1;
            }
        }
    }
}