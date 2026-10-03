using System.Linq.Expressions;
using System.Threading;
namespace Threads;

class Program
{
    volatile static int vl; 
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


            #region Non-Blocking Synchronisation
            // Volatile:
            /* 
            A volatile variable provides cross-thread visibility and memory-ordering guarantees
            without blocking or providing mutual exclusion. Without volatile, the compiler/CPU
            may optimize accesses so a thread keeps using a previously loaded value (e.g. in a
            data register) instead of observing another thread's update. This can be faster, but the
            other thread is not guaranteed to ever see the update. Volatile prevents this kind
            of optimization for the variable, ensuring that subsequent reads observe the required
            cross-thread changes. It may have some overhead compared to a normal variable, but
            unlike lock, it does not make threads wait for each other.
            
            Key distinction:
            Normal → potentially faster, but no cross-thread visibility guarantee.
            Volatile → reliable visibility, non-blocking, no mutual exclusion.
            */

            //!!!!USEFUL WHEN ...!!!!
            //... one thread updates a variable and multiple threads read it.


            //Remember that this scenerio is not easy to observe manually but it occurs
            //volatile int i = 0; !!!Footnote: volitale fields can be only declared within classes & structs & etc. but not in method bodies. Check this classes body above to see the declaration of the int i.
            /*vl = 0;
            Thread th1 = new(() =>
            {
                while (true)
                    vl++;
                
            });
            Thread th2 = new(() =>
            {
                while(true){
                    System.Console.WriteLine(vl);
                    Thread.Sleep(1);
                }
            });
            Thread th3 = new(() =>
            {
                while (true)
                    vl--;
                
            });
            th1.IsBackground = true;
            th2.IsBackground = true;
            th3.IsBackground = true;

            th1.Start();
            th2.Start();
            th3.Start();
            Thread.Sleep(300);*/
            
            
            
            #endregion

            
            #region Interlocked Class
            //Considered in Non-Blocking Synchronisation. 
            //Used at performing operations on variables used in multiple threads in a safe, and synchronous way.
            
            //Might feel like volatile keyword usage but this class is safer as it provides operations at an atomic level (remember why the transaction from SQL was called "Atomic" to be able to remember what atomic means).
            //It first blocks access coming from any other point, performs the operation, and then releases the field.
            //On the other hand, volatile keyword only makes sure that the marked field's data is always pulled from RAM anywhere in the code as the previously loaded value might be pulled from a data register instead of observing another thread's update. 
            
            //!!!!! YOU SHOULD PREFER THIS CLASS OVER VOLATILE KEYWORD IF YOU ARE PARTICULARLY WORKING ON PRIMITIVE VALUES !!!!!!!
            
            //Interlocked.Increment(ref field);
            //Interlocked.Decrement(ref field);
            //Interlocked.Add(ref field, whatsGonnaBeAdded);
            //Interlocked.Exchange(ref field, whatFieldsGonnaBe); This changes the given field's value
            //Interlocked.CompareExchange(ref field, whatFieldsGonnaBe, ifEqualToThis); This changes the given field's value if it is equal to the third argument

            /* int no = 0;
            Thread thread1 = new(() =>
            {
                while (true)
                {
                    Interlocked.Increment(ref no);
                }
            });
            Thread thread2 = new(() => { 
                while (true)
                {
                    Console.WriteLine(no);
                } 
            });
            Thread thread3 = new(() =>
            {
                while (true)
                {
                    Interlocked.Decrement(ref no);
                }
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();*/
            #endregion

            #region MemoryBarrier
            //When this method is called, all the thingies modified, used, manipulated above it get processed and updated if they were touched in another thread.
            /*int i = 0;
            Thread writeThread = new(() =>
            {
                while (true)
                {
                    i++;
                    Thread.MemoryBarrier(); //saved the i's updated val and updated it if it was modified sw else in the code.
                }
            });
            
            Thread readThread = new(() =>
            {
                while (true)
                {
                    Thread.MemoryBarrier();//saved nothing as there is nothing to be saved above here and updated all the properties, fields, variables, etc. saved in sw else before
                    Console.WriteLine(i);
                }
            });
            writeThread.Start();
            readThread.Start();*/
            #endregion
            
            

            #region Signalling - ManualResetEvent, AutoResetEvent, CountdownEvent
            /*ManualResetEvent: is a tool that makes multiple threads wait for an even to happen to go on,
            can be manually reset.*/

            //AutoResetEvent: is a tool that makes a single thread wait for an even to happen to go on.

            //CountdownEvent: used to wait for a certain number of threads to be done with a specific process.
            
            
            //AutoResetEvent
            /*AutoResetEvent autoR = new AutoResetEvent(false); //we set it to false so that we can send the signal by setting it to true at any point in the code
            Thread td1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1 operation is done!");
                autoR.Set(); //This Set method turns the false bool value into true and gives the signal.
            });
            Thread td2 = new Thread(() =>
            {
                autoR.WaitOne(); //although this line exists in both the second and the third thread, the first one to execute this line will get the permission
                //and the other one will not be executed as AutoResetEvent tool permits a single thread, wherever the WaitOne() is called first to go on. 
                //But if we want the other thread to execute its body, we can add the Set method call at the ends of both td2 and td3.
                //This way, the first one to execute WaitOne() call will allow the other one to execute the same method by executing Set() method at the end of their body.
                Console.WriteLine("Thread 2 operation is permitted to start!");
                autoR.Set(); //After the usage of the first Set method call, a reset action should be done normally but as u can understand from the name of this event, it does that automatically.
            });
            Thread td3 = new Thread(() =>
            {
                autoR.WaitOne();
                Console.WriteLine("Thread 3 operation is permitted to start!");
                autoR.Set(); //Will allow td2 to execute WaitOne() if it executes WaitOne() call first.
            });
            td1.Start();
            td2.Start();
            td3.Start();*/
            
            
            //ManuelResentEventSlim
            //This class's Set method will let all the waiting Wait() lines to proceed with the code explicitly instead of  letting one do it.
            //If we want this permission to stop at this point after releasing it with a Set() call, we will be utilizing from the Reset() call to still keep those who hasn't got the signal yet after the Set() call waiting. Keep in mind that some can get the signal first and proceed, and the remaining might be late for that, ending up exposed to the Reset() call and waiting for the next Set() call to proceed.
            /*ManualResetEventSlim mre = new ManualResetEventSlim(false);
            Thread td1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1 operation is done!");
                mre.Set(); 
            });
            Thread td2 = new Thread(() =>
            {
                mre.Wait();
                Console.WriteLine("Thread 2 operation is permitted to start!");
            });
            Thread td3 = new Thread(() =>
            {
                mre.Wait();
                Console.WriteLine("Thread 3 operation is permitted to start!");
            });
            td1.Start();
            td2.Start();
            td3.Start();*/
            
            
            //EventWaitHandle
            //This class will behave the same way either ManuelReset on AutoReset based on the second argument we will give to its constructor.
            EventWaitHandle eventR = new EventWaitHandle(false, EventResetMode.ManualReset);
            //EventWaitHandle eventR = new EventWaitHandle(false, EventResetMode.AutoReset);
            /*Thread td1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1 operation is done!");
                eventR.Set(); 
            });
            Thread td2 = new Thread(() =>
            {
                eventR.WaitOne(); 
                Console.WriteLine("Thread 2 operation is permitted to start!");
            });
            Thread td3 = new Thread(() =>
            {
                eventR.WaitOne();
                Console.WriteLine("Thread 3 operation is permitted to start!");
            });
            td1.Start();
            td2.Start();
            td3.Start();*/
            
            
            //CountdownEvent
            //CountdownEvent will make a thread wait until a specified number of signals are given.
            /*CountdownEvent countdown = new CountdownEvent(3);//means 3 signals must be called for the thread where the wait method is called to proceed.
            Thread td1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1 operation is done!");
                countdown.Signal();
            });
            Thread td2 = new Thread(() =>
            {
                Console.WriteLine("Thread 2 operation is permitted to start!");
                countdown.Signal();
            });
            Thread td3 = new Thread(() =>
            {
                Console.WriteLine("Thread 3 operation is permitted to start!");
                Thread.Sleep(4000);
                countdown.Signal();
            });
            td1.Start();
            td2.Start();
            td3.Start();
            Console.WriteLine("Main thread is expecting the signals");
            countdown.Wait();
            Console.WriteLine("All the signals are triggered!");*/
            #endregion
    
    
    //-----------------------------------------------------------------------------------------
        //Thread Pool
        //is a tool designed to manage, sustain multiple threads under a roof and make existing threads useable again.
        //Primary purpose of its usage is utilizing from the CPU resources more efficiently and hamper unnecessary thread creation.
        //Its threads are background threads, meaning they will be shut down once Main reaches the end.

        ThreadPool.SetMaxThreads(4, 1); //the max no of threads. The second argument sets the maximum number of threads used to process asynchronous I/O completions.
        ThreadPool.SetMinThreads(4, 1); //Minimum the pool works toward as requests arrive. The second argument sets the min number of threads used to process asynchronous I/O completions.
        // In most applications, there is no need to change the ThreadPool limits.
        // The default values are usually sufficient.

        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 1"); //After giving the delegate as the first argument, you give the remaining arguments here in the way they correspond to the relevant delegate's arguments.
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 2");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 3");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 4");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 5");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 6");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 7");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 8");
        ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 9");

        Console.Read();

        void WorkerMethod(object state)
        {
            string name = (string)state;
            System.Console.WriteLine($"{name} has been initialized!");
            Thread.Sleep(new Random().Next(1000, 5000));
            System.Console.WriteLine($"{name} done!");
        }

        //Wait Handles
        //It involves signalling mechanism and the ninth tutorial vid about this mechanism is unavailable on youtube for some reason. Therefore I will be skipping it temporarily, already informed teacher Gençay about this. You are at 30:00 in the 10th video. Come back here once the ninth vid is uploaded and u finish it.
    }
}
