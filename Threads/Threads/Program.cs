using System;
using System.Threading;

namespace ThreadSpace
{
    class threads
    {
        public static void upCount()
        {
            for (int i = 1; i <= 10; i++) { Console.WriteLine("Counting : " + i);Thread.Sleep(1000);  }
            Console.WriteLine("Count Up Ended");
        }
        public static void downCount() { for (int i = 10; i >= 0 ; i--) { Console.WriteLine("Counting : " + i);Thread.Sleep(1000); } 
            Console.WriteLine("Count Down Ended"); }
        public static void Main(String[] args) { 
            Thread threads = Thread.CurrentThread;

            threads.Name = "Main thread";
            Console.WriteLine(threads.Name);

            Thread upThread = new Thread(upCount); 
            Thread lowThread = new Thread(downCount);

            upThread.Start();
            lowThread.Start();  

            upThread.Join();
            lowThread.Join();

            Console.WriteLine(threads.Name+" Is Done");
        }
    }
}