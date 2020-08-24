using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading;

namespace HelloTask
{
    class Program
    {
        public static Stack<int> _stack= new Stack<int>();
        static void Main(string[] args)
        {
            MakeStack();
            PrintStackValue();
            Console.ReadLine();
        }

        public static void MakeStack()
        {
            for (int i = 1; i <= 5000; i++)
            {
                _stack.Push(i);
            }
        }

        public static void PrintStackValue()
        {
            for (int i = 1; i <= 3; i++)
            {
                int threadNum = i + 1;
                int result;
                while(_stack.TryPop(out result))
                {
                    Thread thread = new Thread(() => Print(result));
                    //thread.IsBackground = true;
                    thread.Start();
                }
                   
            }
        }

        public static void PrintSyncronic()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintThreads()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int threadNum = i + 1;
                Thread thread = new Thread(() => Print(threadNum));
                thread.Start();
            }
        }

        public static void PrintThreadPool()
        {
            for (int i = 0; i < 1000000; i++)
            {
                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Console.WriteLine(obj);
                }, i);
            }
        }

        public static void Print(int threadNumber)
        {
            Console.WriteLine(threadNumber);
        }
    }
}
