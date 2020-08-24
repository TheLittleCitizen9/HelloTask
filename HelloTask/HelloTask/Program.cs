using System;
using System.Threading;

namespace HelloTask
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintThreads();
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

        public static void Print(int threadNumber)
        {
            Console.WriteLine(threadNumber);
        }
    }
}
