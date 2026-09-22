using System.Threading;
namespace Threads;

class Program
{
    static void Main(string[] args)
    {
        //Threads
        
        #region Thread Class
        /*Thread thread = new Thread(() => //check the overloads, delegate types allowed.
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine($"Trial {i}");
            }
        });
        thread.Start();
        for (int i = 0; i < 999; i++)
        {
            Console.WriteLine($"Normal {i}");
        }*/
        #endregion
        
        
        
        
        
        #region Thread ID
        //Two ways:
        
        //1
        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        //2
        //Console.WriteLine(Environment.CurrentManagedThreadId);
        
        //These commands bring the ID of the thread where they re called.
        //The ones above would bring the main thread ID whereas the one below will bring our specific thread's

        /*Thread expThread1 = new(() =>
        {
            Console.WriteLine(Environment.CurrentManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        });
        Thread expThread2 = new(() =>
        {
            Console.WriteLine(Environment.CurrentManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        });
        expThread1.Start();
        expThread2.Start();*/
        #endregion
        
        
        
        
        
        #region IsBackground Property
        //In default, this is set false and false means the main thread will not be shut down and the app will be running until the relevant worker thread is finished.
        //But if you set this to true, the worker thread will be shut down just as the main thread is finished.
        
        /*Thread thread = new(() =>
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread {i + 1}");
                Thread.Sleep(1000); //milisec timeout
            }
        });
        
        //thread.IsBackground = true; //Without this, the app will keep running until the thread is finished.
        thread.Start();*/
        #endregion
        
        
        
        
        
        #region Thread State
        /*
         * ThreadState flags (some states can be combined):
         *
         * State              | Meaning
         * -------------------|------------------------------------------------------
         * Running            | The thread is currently executing.
         * Background         | The thread is a background thread; it does not keep the app alive.
         * Unstarted          | The thread has been created but Start() has not been called yet.
         * Stopped            | The thread has finished execution.
         * WaitSleepJoin      | The thread is waiting, sleeping, or blocked in Join().
         */
        
        /*Thread thread = new(() =>
        {
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(1000);
                for (int j = 0; j < 24; j++)
                {
                    Console.Write("");
                    Console.Write("");
                    Console.Write("");
                    Console.Write("");
                }
            }
        });
        thread.Start();
        while (true)
        {
            ThreadState state = thread.ThreadState;
            if (state == ThreadState.Stopped) {
                Console.WriteLine($"Thread state is {state}");
                break;}
            else if (state == ThreadState.Running) Console.WriteLine($"Thread {state}");
        }

        Console.WriteLine($"{ThreadPool.ThreadCount} threads are running");*/
        #endregion
        
        
        
        
        
        #region Locking

        /*int i = 0;
        Lock locker = new();
        Thread thread1 = new(() =>
        {
            lock (locker)
            {
                while (i < 10)
                {
                Console.WriteLine(i++);
                }
            }
        });
        Thread thread2 = new(() =>
        {
            lock (locker)
            {
                while (i < 100)
                {
                    Console.WriteLine(i++);
                }

                Console.WriteLine("ig it waits, behaving in sync");
            }
        });
        thread1.Start();
        thread2.Start();*/
        #endregion
        
        
        
        
        #region Join Method 
        //If we want a thread to pursue sync execution then we use this method.
        /*Thread thread1 = new(() =>
        {
            for (int i = 0; i < 10; i++) Console.WriteLine(i);
        });
        Thread thread2 = new(() =>
        {
            for (int i = 10; i < 20; i++) Console.WriteLine(i);
        });
        thread1.Start();
        thread1.Join(); //Tells the compiler to wait for this thread to finish before initializing others
        thread2.Start();*/

        #endregion
        
        
        
        
        #region Graceful Shutdown (Stopping Thread)

        /*bool stop = false;
        Thread thread = new(() =>
        {
            while (true)
            {
                if (stop) return;
                Thread.Sleep(1000);
                Console.WriteLine("Thread still running");
            }
        });
        thread.Start();
        Thread.Sleep(10000);
        stop = true;*/

        #endregion
        
        
        
        
        
        #region Interrupt Method
        //Interrupt wakes a thread waiting in Sleep(), Wait(), or Join().
        //It throws ThreadInterruptedException inside the interrupted thread.
        //If the thread is not waiting, the exception is thrown at its next Sleep/Wait/Join.

        /*Thread thread = new(() =>
        {
            try
            {
                Console.WriteLine("Worker is sleeping...");
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Sleep was interrupted.");
            }
        });

        thread.Start();
        Thread.Sleep(1000);
        thread.Interrupt(); //Wakes the worker by throwing the exception above.
        thread.Join();*/
        #endregion



        //----------------------------------------------------------------------------------
        //Thread Synchronization & Blocking Synchronization

            #region Monitor.Enter, Monitor.TryEnter and Monitor.Exit Methods for Locking and LockTaken to ensure the Locking action
            //They basically represent the functional method version of the locking mechanism.
            //Enter locks and exit unlocks the specified object

            // Use lock for ordinary protection of shared data.
            // Use Monitor directly when you need Monitor.Wait, Monitor.Pulse,
            // or Monitor.TryEnter with a timeout.

            // Monitor.Exit should be placed in finally so the monitor is released even if an exception occurs;
            // lock does this automatically, so it does not need an explicit try-finally block.

            /*int i = 0;
            Lock lockObj = new();
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
            /*Lock lockObj = new();
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




            //Monitor.TryEnter
            //We get a bool if the action is taken or not.
            /*Lock lockObj = new();
            Thread thread1 = new(() =>
            {
                
                var result = Monitor.TryEnter(lockObj, 1000);
                if (result)
                {
                    try
                    {
                        for(int i = 0; i < 15; i++)
                            System.Console.WriteLine(i);
                    }
                    finally
                    {
                        Monitor.Exit(lockObj);
                    }
                }
            });
            thread1.Start();*/
            #endregion


#region Semaphore & SemaphoreSlim
    // A Semaphore limits concurrent access for threads to a shared resource in the Thread Synchronisation.

    /*
|----------------------------------------------------------------------------------
| Semaphore                          | SemaphoreSlim
|----------------------------------------------------------------------------------
| Older, OS-backed synchronization   | Newer and lightweight, non operating-system 
| primitive.                         | resource synchronization primitive.
|----------------------------------------------------------------------------------
| Can be named and used for          | Works only within the current process;
| synchronization across processes.  | it cannot be named.
|----------------------------------------------------------------------------------
| Supports synchronous waiting only  | Supports both synchronous Wait() and
| (for example, WaitOne()).          | asynchronous WaitAsync().
|----------------------------------------------------------------------------------
| Use it when cross-process          | Usually preferred in modern .NET apps,
| synchronization is required.       | especially when using async/await.
|----------------------------------------------------------------------------------
*/

//Semaphore
/* using Semaphore sem = new(1, 4); //First argument is initial count and the second one is max count. Initial count indicates the number of the thread access at the same time and this can be increased up to the max count.
//Utilizing from the using keyword in the declarations automatically calls the Dispose() method once the instances of the classes implementing IDisposable are done being used.
Thread thread1 = new(() =>
{
    sem.WaitOne(); //Requests access
    for (int i = 1; i < 10; i++){
        System.Console.WriteLine($"Thread 1 {i}");
        Thread.Sleep(200);
    }
    sem.Release(); //Releases the permission slot
});
Thread thread2 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 11; i < 20; i++){
        System.Console.WriteLine($"Thread 2 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

thread1.Start();
thread2.Start();

System.Console.WriteLine();
System.Console.WriteLine();
System.Console.WriteLine();
Thread.Sleep(4000);

sem.Release(1); //Release is also used to increase the permission slots (if used out of no where). You can give how many more slots you want it to have as an argument)

Thread thread3 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 21; i < 30; i++){
        System.Console.WriteLine($"Thread 3 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread4 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 31; i < 40; i++){
        System.Console.WriteLine($"Thread 4 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread5 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 41; i < 50; i++){
        System.Console.WriteLine($"Thread 5 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread6 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 51; i < 60; i++){
        System.Console.WriteLine($"Thread 6 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

Thread thread7 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 61; i < 70; i++){
        System.Console.WriteLine($"Thread 7 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread8 = new(() =>
{
    sem.WaitOne(); 
    for (int i = 71; i < 80; i++){
        System.Console.WriteLine($"Thread 8 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

thread3.Start();
thread4.Start();
thread5.Start();
thread6.Start();
thread7.Start();
thread8.Start();*/


//SemaphoreSlim

//For sync operations, its pretty much the same but we use Wait() rather than WaitOne() method for the SemaphoreSlim concept.
/*SemaphoreSlim sem = new(1, 4); 

Thread thread1 = new(() =>
{
    sem.Wait(); //Requests access
    for (int i = 1; i < 10; i++){
        System.Console.WriteLine($"Thread 1 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread2 = new(() =>
{
    sem.Wait(); 
    for (int i = 11; i < 20; i++){
        System.Console.WriteLine($"Thread 2 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

thread1.Start();
thread2.Start();

System.Console.WriteLine();
System.Console.WriteLine();
System.Console.WriteLine();
Thread.Sleep(4000);

sem.Release(1); 

Thread thread3 = new(() =>
{
    sem.Wait(); 
    for (int i = 21; i < 30; i++){
        System.Console.WriteLine($"Thread 3 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread4 = new(() =>
{
    sem.Wait(); 
    for (int i = 31; i < 40; i++){
        System.Console.WriteLine($"Thread 4 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread5 = new(() =>
{
    sem.Wait(); 
    for (int i = 41; i < 50; i++){
        System.Console.WriteLine($"Thread 5 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread6 = new(() =>
{
    sem.Wait(); 
    for (int i = 51; i < 60; i++){
        System.Console.WriteLine($"Thread 6 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

Thread thread7 = new(() =>
{
    sem.Wait(); 
    for (int i = 61; i < 70; i++){
        System.Console.WriteLine($"Thread 7 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});
Thread thread8 = new(() =>
{
    sem.Wait(); 
    for (int i = 71; i < 80; i++){
        System.Console.WriteLine($"Thread 8 {i}");
        Thread.Sleep(200);
    }
    sem.Release();
});

thread3.Start();
thread4.Start();
thread5.Start();
thread6.Start();
thread7.Start();
thread8.Start();*/

//!!!!!!!!!NOTICE!!!!!!!!!
//Async SemaphoreSlim Practice will be covered after the Asynchronisation Programming Tutorial
#endregion








            //Spinning's Significance is low (P3-4)
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


    }
}
