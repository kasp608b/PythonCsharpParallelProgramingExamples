
using System.Diagnostics;

//Example of Threads in C#

void task(int id, int sleepTime)
{
    for (int i = 1; i <= 10; i++)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Task {0} is running on " + "thread: {1}" + " and running on processor: {2}", id, Thread.CurrentThread.ManagedThreadId, Thread.GetCurrentProcessorId());

        Stopwatch sw = Stopwatch.StartNew();

        float number = 2;

        while (true)
        {
            number = number * number;

            if(sw.ElapsedMilliseconds >= sleepTime)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task {0} is finished", id);
                break;
            }
        }
    }
}

Thread task1 = new Thread(() => task(1, 3000));
Thread task2 = new Thread(() => task(2, 3000));
Thread task3 = new Thread(() => task(3, 4000));
Thread task4 = new Thread(() => task(4 ,5000));
// Total 150 seconds
Stopwatch sw = Stopwatch.StartNew();

task1.Start();
task2.Start();
task3.Start();
task4.Start();

task1.Join();
task2.Join();
task3.Join();
task4.Join();


long time = sw.ElapsedMilliseconds;
Console.WriteLine(time / 1000 + " seconds");
