namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task Class
            
            //Task Class is mainly used to represent an asynchronous operation and commonly (and mainly) used for async programming. We run tasks in separate threads and they can be used to perform bg operations.

            //Task and Thread classes are similar in many ways but are not the same. They are preferred over each other in different scenarios.

            //Difference Table
            /*
            Task Class	                                                                                        |	Thread Class
            Used in asynchronous programming.	                                                                |	Used when low level control over threads is needed in multithreaded programming.
            Task provides an easier use in the modern C# programming with async and await keywords.             |   Thread class enables direct thread creation and management. 
            Is optimized and managed by the .NET runtime. ThreadPool is used to manage threads for this purpose	|   Comparably more system resources are consumed when using Thread class.

            */
            
            
            //Declaration
            //There are 3 ways to declare a task in C#:

            //1. Using Task constructor - To manually create a task and start it (with Start()) later.
            Task task1 = new Task(() => { Console.WriteLine("Task 1 is running."); Thread.Sleep(5000);}); //Constructor takes an Action or Func delegate as a parameter to define the task's work. Reminder: Action delegate represents void methods.
            //task1.Start(); //To start the task execution.

            //2. Using Task.Run() method - The simplest and most common way to create and start a task in one step. It returns a Task object.
            Task task2 = Task.Run(() => { Console.WriteLine("Task 2 is running."); Thread.Sleep(5000);});

            //3. Using Task.Factory.StartNew() method - another way to create and start a task in one step, returning a Task object. The difference between Task.Run() and Task.Factory.StartNew() is that this method offers more options and configurations for task creation, and it starts subtasks of the parent task in the same thread by default, while Task.Run() does not do this.
            Task task3 = Task.Factory.StartNew(() => { Console.WriteLine("Task 3 is running."); Thread.Sleep(1000);});


            //Task Class Methods
            //Method List
            /*
            Method Name	                  |	Description

            Start()                       | Starts the manually created task by the Task constructor and new keyword.
            Wait()                        | Waits for the task to complete the execution to move on wherever it is called.
            WaitAll()                     | Waits for all the tasks (that are given as arguments to the method) in progress to complete the execution to move on wherever it is called. A static method of the Task class.
            WaitAny()                     | Waits for any task in progress to complete the execution to move on wherever it is called.
            WhenAll()                     | Will return a task after all the tasks given as arguments to the method are completed. A static method of the Task class.
            WhenAny()                     | Will return a task after any of the tasks given as arguments to the method are completed. A static method of the Task class.
            ContinueWith()                | Used to make an operation after a task is completed. Takes an Action as the operation to be performed.
            Delay()                       | Creates a task that will complete after a specified time delay. A static method of the Task class. The async version of Thread.Sleep() method. 
                                          | It is non-blocking and does not block the thread it is called on. 
            FromCancellation()            | Returns a cancelled task that is completed with a CancellationTokenSource.Token. A static method of the Task class.
            FromException()               | Returns a task that ends with an exception. A static method of the Task class.
            FromResult()                  | Returns a task that successfully completes with a certain result. A static method of the Task class.
            Yield()                       | Returns a task that asynchronously yields back to the current context when awaited. A static method of the Task class.
            GetAwaiter()                  | For Task<T>, GetAwaiter().GetResult() blocks until completion and returns the result. Like Result, it blocks; unlike Result, it throws the original exception instead of wrapping it in AggregateException. Prefer await in async code.
            

            */

            //Wait()
            /*task2.Wait();
            task1.Start();*/

            //WaitAll()
            //Task.WaitAll(task2, task3);


            //WaitAny()
            /*Task.WaitAny(task2, task3);
            Console.WriteLine("Task 3 is completed.");*/


            //WhenAll()
            //In WhenAll(), waiting action is performed in a different thread unlike WaitAll() where waiting action is performed in the same thread. So, Main Thread will not wait for WhenAll() to complete and will continue executing the next lines of code. 
            //Task.WhenAll(task2, task3);


            //WhenAny()
            //Task.WhenAny(task2, task3);

            //ContinueWith()
            /*task2.ContinueWith((_task) => {Console.WriteLine("Task 2 is completed.");}); 
            Thread.Sleep(6000);*/
            

            //Delay()
            //will be covered later after async and await keywords are explained.


            //FromCancellation()
            Task cancelledTask = Task.Run(() => {return Task.FromCanceled(new CancellationToken());});


            //FromException()
            Task Exception = Task.FromException(new Exception("This is an exception!"));

            
            //FromResult()
            Task<int> Result = Task.Run(() => 42); // this is the same thingie as below.
            Task<int> Result2 = Task.FromResult(42); // this is the same thingie as above.
            var result = Result.Result; //Task returns assigns this result to the Result property of the Task instance. This property is used to retrieve the result of a completed task. 


            //Yield()
            //will be covered later after async and await keywords are explained.


            //GetAwaiter()
            // GetAwaiter().GetResult() blocks like Result, but throws the original exception instead of wrapping it in AggregateException. Prefer await in async code.
        }
    }
}
