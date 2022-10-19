
using System.Diagnostics;

//Example of Tasks in C#

void task(int id, int sleepTime)
{
    for (int i = 1; i <= 10; i++)
    {
        Console.ForegroundColor = ConsoleColor.Gray;

        Stopwatch sw = Stopwatch.StartNew();

        float number = 2;

        while (true)
        {
            number = number * number;

            if (sw.ElapsedMilliseconds >= sleepTime)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task {0} is finished", id);
                break;
            }
        }
    }
}

Task task1 = Task.Factory.StartNew(() => task(1, 3000));
Task task2 = Task.Factory.StartNew(() => task(2, 3000));
Task task3 = Task.Factory.StartNew(() => task(3, 4000));
Task task4 = Task.Factory.StartNew(() => task(4, 5000));

// Total 150 seconds
Stopwatch sw = Stopwatch.StartNew();

Task.WaitAll(task1, task2, task3, task4);

long time = sw.ElapsedMilliseconds;
Console.WriteLine(time / 1000 + " seconds");

