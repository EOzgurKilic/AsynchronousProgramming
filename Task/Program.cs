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
            
            
            #region Declaration
            //There are 3 ways to declare a task in C#:

            //1. Using Task constructor - To manually create a task and start it (with Start()) later.
            //Task task1 = new Task(() => { Console.WriteLine("Task 1 is running."); Thread.Sleep(5000);}); //Constructor takes an Action or Func delegate as a parameter to define the task's work. Reminder: Action delegate represents void methods.
            //task1.Start(); //To start the task execution.

            //2. Using Task.Run() method - The simplest and most common way to create and start a task in one step. It returns a Task object.
            //Task task2 = Task.Run(() => { Console.WriteLine("Task 2 is running."); Thread.Sleep(5000);});

            //3. Using Task.Factory.StartNew() method - another way to create and start a task in one step, returning a Task object. The difference between Task.Run() and Task.Factory.StartNew() is that this method offers more options and configurations for task creation, and it starts subtasks of the parent task in the same thread by default, while Task.Run() does not do this.
            //Task task3 = Task.Factory.StartNew(() => { Console.WriteLine("Task 3 is running."); Thread.Sleep(1000);});
            #endregion


            #region Task Class Methods
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
            //Task cancelledTask = Task.Run(() => {return Task.FromCanceled(new CancellationToken());});


            //FromException()
            //Task Exception = Task.FromException(new Exception("This is an exception!"));

            
            //FromResult()
            /*Task<int> Result = Task.Run(() => 42); // this is the same thingie as below.
            Task<int> Result2 = Task.FromResult(42); // this is the same thingie as above.
            var result = Result.Result;*/ //Task returns assigns this result to the Result property of the Task instance. This property is used to retrieve the result of a completed task. 


            //Yield()
            //will be covered later after async and await keywords are explained.


            //GetAwaiter()
            // GetAwaiter().GetResult() blocks like Result, but throws the original exception instead of wrapping it in AggregateException. Prefer await in async code.
            #endregion
            
            
            #region Task Class Properties
            //Properties List
            /*
             CompletedTask                | Returns a task object that has been already completed successfully.                 A static method
             CurrentId                    | Returns the ID of the current task.                                                 A static method
             Factory                      | The property used to create new tasks.                                              A static method
             IsCanceled                   | Returns a bool based on if the task is cancelled. 
             IsCompleted                  | Returns a bool based on if the task is completed.
             AsyncState                   | Returns the state associated with the task.             
             IsCompletedSuccessfully      | Returns a bool based on if the task is SUCCESSFULLY completed.
             IsFaulted                    | Returns a bool based on if the task encountered an error.
             Id                           | Returns the Id of a task. Non-static version of CurrentId
             Status                       | Returns the status of the task.(if its completed, failed due to an error, successfully completed, etc.)
             */


            //Task expTask = Task.Run(() => { Console.WriteLine("Hello World!"); Thread.Sleep(5000); });
            
            //CompletedTask
            Task X() //Imagine we have a method returning a task object.
            {
                //...Operations,Operations...
                //return Task.Run(() => {}); //Rather than returning a normal task back...
                return Task.CompletedTask; //...we can return a task already completed successfully to indicate the X method is finished.
            }
            
            //CurrentId
            /*Task test = Task.Run(() => { Console.WriteLine(Task.CurrentId); });

            Console.Read();*/
            
            //Factory
            //Task.Factory.StartNew(() => {});
            
            //IsCanceled
            //Console.WriteLine(expTask.IsCanceled);
            
            //IsCompleted
            //Console.WriteLine(expTask.IsCompleted);
            
            //AsyncState
            /*Task asyncTask = Task.Factory.StartNew((i) => { Console.WriteLine("async task"); }, "state"); //As we can see here, we gave the task a state parameter and what that state is as argument to the creation method.
            var state = (string)asyncTask.AsyncState; //We use this property to acquire that state.
            Console.WriteLine(state);*/
            
            //Id
            /*int idExpTask = expTask.Id;
            Console.WriteLine(idExpTask);*/
             
            //IsFaulted
            //Console.WriteLine(expTask.IsFaulted);
            
            //Status
            //Thread.Sleep(6000); //To see the Status difference
            //Console.WriteLine(expTask.Status);
            
            //Thread.Sleep(5000);
            #endregion


            #region TaskFactory & TaskScheduler & TaskCompletionSource Classes
            //TaskFactory Class
            //Precisely used to create and manage tasks.
            //The Factory property of the Task class is actually an instance of the TaskFactory class. It provides methods to create and start tasks, as well as to configure their behavior. 

            //Methods of the TaskFactory Class
            /*
                instance.StartNew() - Creates and starts a new task.
                ContinueWhenAll()   - Its like ContinueWith() method but you give an array of tasks as argument and it will return and start the other task argument you gave to it after all the tasks in the array are completed. 
                ContinueWhenAny()   - Its literally the same as ContinueWhenAll() method but it will return and start the other task argument after any of the tasks in the array are done.
            */


            //ContinueWhenAll()    
            //Its like ContinueWith() method but you give an array of tasks as argument and it will execute the other task argument you gave to it after all the tasks in the array are completed. 
            /*Task taskc1 = Task.Run(() => { Console.WriteLine("Task 1 is running."); Thread.Sleep(1000); Console.WriteLine("Task 1 is completed."); });
            Task taskc2 = Task.Run(() => { Console.WriteLine("Task 2 is running."); Thread.Sleep(2000); Console.WriteLine("Task 2 is completed."); });
            Task taskc3 = Task.Run(() => { Console.WriteLine("Task 3 is running."); Thread.Sleep(3000); Console.WriteLine("Task 3 is completed."); });
            
            Task continuationTask = Task.Factory.ContinueWhenAll(new[] {taskc1, taskc2, taskc3}, (tasks) => {System.Console.WriteLine("All tasks are completed.");});
            Thread.Sleep(4000);*/


            //ContinueWhenAny()
            /*Task taskc1 = Task.Run(() => { Console.WriteLine("Task 1 is running."); Thread.Sleep(1000); Console.WriteLine("Task 1 is completed."); });
            Task taskc2 = Task.Run(() => { Console.WriteLine("Task 2 is running."); Thread.Sleep(2000); Console.WriteLine("Task 2 is completed."); });
            Task taskc3 = Task.Run(() => { Console.WriteLine("Task 3 is running."); Thread.Sleep(3000); Console.WriteLine("Task 3 is completed."); });
            
            Task continuationTask = Task.Factory.ContinueWhenAny(new[] {taskc1, taskc2, taskc3}, (tasks) => {System.Console.WriteLine("All tasks are completed.");});
            Thread.Sleep(4000);*/



            //TaskScheduler Class
            //A TaskScheduler determines how and where tasks are queued and executed. The default scheduler
            //typically uses the ThreadPool; tasks do not necessarily each get their own thread.
            //Custom schedulers are useful for specialized scenarios (for example, controlling concurrency
            //or scheduling work onto a UI thread), but are advanced and rarely needed in everyday code.
            //For now, it is enough to know what a TaskScheduler does; you can skip implementing one.



            //TaskCompletionSource Class
            //Is a assisting class next to the Task class that is used to manage the completion of a task in fail, exception, success, and cancellation scenarios.
            //TaskCompletionSource<T> object enables Task<T> object creation and the control of its completion from outside manually.

            Task<int> expLocalMethod(TaskStatusEnum resultStatus)
            {
                TaskCompletionSource<int> tcs = new();

                switch(resultStatus)
                {
                    case TaskStatusEnum.Result:
                        tcs.SetResult(31); //Sets a result to it
                        break;
                    case TaskStatusEnum.Exception:
                        tcs.SetException(new Exception("This is an exception!")); //Sets an exception to it
                        break;
                    case TaskStatusEnum.Cancelled: //Sets a cancellation to it
                        tcs.SetCanceled();
                        break;
                } //Remember that these three methods are the equavalents of the FromResult(), FromException(), and FromCancellation() methods from the Task class. 

                return tcs.Task; //Returns the task object that is created by the TaskCompletionSource<T> object.
            }
            #endregion
            
            
            #region async await Keywords
            
            //async Keyword
            //We declare a method will do an async operation with this keyword
            
            //The async declared methods must return Task or Task<T> values. It can be a void method too but should be returning a Task for the best practice and cannot return any other type.
            //Though, if a method has async, it can return any value type that is the generic argument of the Task<T> instance it should actually return.
              async Task<int> localAsyncMethod()
              {
                  return 30; //This returns Task.FromResult(30) in the bg and would throw an error if the method wasn't async
              }
            //void usage is not recommended as Task without generics already shows the same behaviour as voids.
            //There is a naming principle about async methods; they should simply end with "Async"
            //async methods should be strictly preferred for use in async methods.
            //We should release the resources we used in async methods. We will be covering IAsyncDisposable later in the tutorials.
            //We should avoid async method usage in Constructors as they pursue a sync behaviour.
            
            //await Keyword
            //Used in async methods to wait for a value in the synchronous way.
            //In normal, to catch an exception that occured in a task, we are doing the long operation below;
            Task taskR = new(() => { Console.WriteLine("code code code and more code!"); throw new Exception("my ass's will wanned this!"); });
            taskR.ContinueWith((taskR) =>
            {
                if(taskR.Exception == null){
                    Console.WriteLine("code completed without any exception");
                }
                else
                {
                    Console.WriteLine("an exception encountered: " + taskR.Exception.Message);
                }
            });     
            //but with async and await keywords we can await an async method output in a try-catch statement and catch the exception if it occurs;

            async Task localAsyncMethod2()
            {
                throw new Exception("async exception!");
            }
            async Task localAsyncMethod3()
            {
                try
                {
                    await localAsyncMethod2();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            localAsyncMethod3();
            #endregion
        }
        enum TaskStatusEnum
        {
            Result,
            Exception,
            Cancelled
        }
    }
}
