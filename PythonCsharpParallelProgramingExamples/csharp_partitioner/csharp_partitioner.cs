using System.Collections.Concurrent;
using System.Diagnostics;


int n = 100000000;
double[] numbers = new double[n];

Parallel.ForEach(Partitioner.Create(0, n), (range) =>
{
    for (int i = range.Item1; i < range.Item2; i++) { numbers[i] = i; }
}
);


void PartitionedParallelLoop()
{

    Parallel.ForEach(Partitioner.Create(0, n), (range) =>
    {
        for (int i = range.Item1; i < range.Item2; i++) { numbers[i] = Math.Pow(numbers[i], 2); }
    }
);
}

void PartitionedSpecifiedSizeParallelLoop()
{

    Parallel.ForEach(Partitioner.Create(0, n, 10000), (range) =>
    {
        for (int i = range.Item1; i < range.Item2; i++) { numbers[i] = Math.Pow(numbers[i], 2); }
    }
);
}

void SequentialLoop()
{
    for (int i = 0; i < n; i++)
    {
        numbers[i] = Math.Pow(numbers[i], 2);


    }

}

void ParallelLoop()
{
    Parallel.For(0, n, i =>
    {
        numbers[i] = Math.Pow(numbers[i], 2);
    });
}


Stopwatch sw = Stopwatch.StartNew();

SequentialLoop();

sw.Stop();

string time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

Console.WriteLine(time + " SeqentialLoop");

Console.WriteLine();

sw = Stopwatch.StartNew();

ParallelLoop();

sw.Stop();

time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

Console.WriteLine(time + " ParallelLoop");

Console.WriteLine();

sw = Stopwatch.StartNew();

PartitionedParallelLoop();

sw.Stop();

time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

Console.WriteLine(time + " PartitionedParallelLoop");

Console.WriteLine();

sw = Stopwatch.StartNew();

PartitionedSpecifiedSizeParallelLoop();

sw.Stop();

time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

Console.WriteLine(time + " PartitionedSpecifiedSizeParallelLoop");
