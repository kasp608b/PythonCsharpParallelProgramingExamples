
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

var t0 = System.DateTime.Now;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"Starting at {t0}");

var data = new ConcurrentQueue<DataField>();


var task1 =  GenerateData(20, data);
var task2 =  GenerateData(20, data);
var task3 =  ProcessData(40, data);

Task.WaitAll(task1, task2, task3);

var dt = System.DateTime.Now - t0;

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"App exiting, total time: {dt.Seconds} sec." );


async Task<string> GenerateData(int num, ConcurrentQueue<DataField> data)
{
    Random rand = new Random();
    for (int i = 1; i < num + 1; i++)
    {
        var item = i * i;
        data.Enqueue(new DataField(item, DateTime.Now));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($" -- generated item {i}");
        await Task.Delay(((rand.Next(0, 1))*1000) + 500);

    }


    return "GenerateData done";



}

async Task<string> ProcessData(int num, ConcurrentQueue<DataField> data)
{
    var processed = 0;
    Random rand = new Random();
    while (processed < num)
    {
        if (data.TryDequeue(out var item))
        {
            processed += 1;
            var value = item.item;
            var dt = DateTime.Now - item.time;    

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" +++ Processed value {value} after {dt.TotalSeconds} sec.");
            await Task.Delay(500);
        }
    }

    return "ProcessData done";
}

internal class DataField
{
    public int item { get; private set; }
    public DateTime time { get; private set; }

    public DataField(int item, DateTime time)
    {
        this.item = item;
        this.time = time;
    }
}



 