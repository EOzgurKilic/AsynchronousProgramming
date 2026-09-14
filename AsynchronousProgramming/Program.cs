using System;

namespace AsynchronousProgramming
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            //Gonna be added to the Threads project. For some reason there has been a problem tryna push that project on the pc where it was created and therefore, I have no access to it rn.
            #region Your spinning practice (kept as a comment)
            /*
            // utilized approach to keep multithreads in sync that make operations on the same source (variables, etc.) while running at the same time
            bool thread1Access = true;
            bool thread2Access = false;
            bool ending = false;
            int num1 = 0;
            Thread thread1 = new(() =>
            {
                int count = 0;
                while (count++ < 30)
                {
                    Thread.Sleep(1000);
                    if (thread1Access)
                    {
                        if (num1 < 10)
                        {
                            System.Console.WriteLine(num1++);
                        }
                        else
                        {
                            thread1Access = false;
                            thread2Access = true;
                        }
                    }
                }
                ending = true;
            });
            Thread thread2 = new(() =>
            {
                while (true)
                {
                    if (thread2Access)
                    {
                        num1 /= 10;
                        thread2Access = false;
                        thread1Access = true;
                    }
                    if (ending) break;
                }
            });
            thread1.Start();
            thread2.Start();
            */
            #endregion
            #region Minimal spinning advanced practice
            // Spinning fits a very short wait: the consumer waits for the producer's result.
            /*int result = 0;
            bool resultIsReady = false;

            Thread producer = new(() =>
            {
                result = 42;
                Volatile.Write(ref resultIsReady, true);
            });

            producer.Start();
            SpinWait.SpinUntil(() => Volatile.Read(ref resultIsReady));

            Console.WriteLine($"Result: {result}");
            producer.Join();*/
            #endregion




            #region Monitor.Enter, Monitor.TryEnter and Monitor.Exit Methods for Locking and LockTaken to ensure the Locking action
            //They basically represent the functional method version of the locking mechanism.
            //Enter locks and exit unlocks the specified object

            // Use lock for ordinary protection of shared data.
            // Use Monitor directly when you need Monitor.Wait, Monitor.Pulse,
            // or Monitor.TryEnter with a timeout.

            // Monitor.Exit should be placed in finally so the monitor is released even if an exception occurs;
            // lock does this automatically, so it does not need an explicit try-finally block.

            /*int i = 0;
            object lockObj = new();
            Thread thread1 = new(() =>
            {
                try{
                    Monitor.Enter(lockObj);
                    for (i = 0; i < 10; i++)
                    {
                        System.Console.WriteLine($"Thread 1 {i}");
                    }
                }
                finally
                {
                    Monitor.Exit(lockObj);
                }
            });
            Thread thread2 = new(() =>
            {
                
                try{
                    Monitor.Enter(lockObj);
                    for (i = 0; i < 10; i++)
                    {
                        System.Console.WriteLine($"Thread 2 {i}");
                    }
                }
                finally
                {
                    Monitor.Exit(lockObj);
                }
            });
            thread1.Start();
            thread2.Start();*/


            //LockTaken
            /*object lockObj = new();
            Thread thread1 = new(() =>
            {
                
                try{
                    bool lockTaken = false;
                    Monitor.Enter(lockObj,ref lockTaken);
                    if(lockTaken){    
                        for (int i = 0; i < 10; i++)
                        {
                            System.Console.WriteLine($"Thread 1 {i}");
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(lockObj);
                }
            });
            thread1.Start();*/
            #endregion





        }
    }
}
