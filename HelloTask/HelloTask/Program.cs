using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Threading.Tasks;

namespace HelloTask
{
    class Program
    {
        public static Stack<int> _stack= new Stack<int>();
        static void Main(string[] args)
        {
            MakeStack();
            PrintStackParallel();
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
                Thread thread = new Thread(() => PrintStack());
                //thread.IsBackground = true;
                thread.Start();
                   
            }
        }

        public static void PrintStackParallel()
        {
            Parallel.For(1, 5001, i =>
            {
                PrintStack();
            });
        }

        public static void PrintStack()
        {
            int result;
            while (_stack.TryPop(out result))
            {
                Console.WriteLine(result);
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
