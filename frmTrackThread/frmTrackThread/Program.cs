using System;
using System.Threading;


namespace frmTrackThreadSpace
{

    class MyThreadClass
    {
        public static void Thread1()
        {
            for (int loopCount = 0; loopCount < 2; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name Of Thread: " + thread.Name
                    + " = " + loopCount);
                Thread.Sleep(500);
            }

        }
        public static void Thread2() 
        {
            for (int loopCount = 0; loopCount < 6; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name Of Thread: " + thread.Name
                    + " = " + loopCount);
                Thread.Sleep(1500);
            }
        }
    }

    class frmTrackthread
    {
        public static void Main(string[] args)
        {
            Thread threadA = new Thread(MyThreadClass.Thread1);
            Thread threadB = new Thread(MyThreadClass.Thread1);
            Thread threadC = new Thread(MyThreadClass.Thread2);
            Thread threadD = new Thread(MyThreadClass.Thread2);
            threadA.Name = "Thread A"; threadC.Name = "Thread C";
            threadB.Name = "Thread B"; threadD.Name = "Thread D";
            threadA.Priority = ThreadPriority.Highest; 
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();
            
            threadA.Join();
            Console.WriteLine("The Thread " + Thread.CurrentThread
                + " Has ended");
            threadB.Join();
            Console.WriteLine("The Thread " + Thread.CurrentThread
                + " Has ended");
            threadC.Join();
            Console.WriteLine("The Thread " + Thread.CurrentThread
                + " Has ended");
            threadD.Join();
            Console.WriteLine("The Thread " + Thread.CurrentThread
                + " Has ended");

            Console.WriteLine("-End of Thread-");

        }
    }
}