using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

    internal class PrimeGenerator
    {
        public long task(int value)
        {
            if (IsPrime(value))
            {
                return value;

            } 
            else
            {
                return 0;
            }

        }

        public List<long> GetPrimesSequential()
        {

            List<long> primes = new List<long>();

            for (int i = 1000000; i <= 2000000; i++)
            {
                if (task(i) != 0)
                {
                    primes.Add(i);
                }
            }

            return primes;

        }

    public List<long> GetPrimesParallel()
    {

        ConcurrentQueue<long> PrimesFound = new ConcurrentQueue<long>();
        Parallel.For(1000000, 2000000, (i) =>
        {
            if (IsPrime(i))
            {
                PrimesFound.Enqueue(i);
            }
        });

        List<long> sortedPrimes = PrimesFound.ToList<long>();
        sortedPrimes.Sort();

        return sortedPrimes;

    }

    private bool IsPrime(long number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var i = 3;
            while (i * i <= number)
            {
                if(number % i == 0)
                {
                    return false;
                }
                i += 2;
            }

            return true;
            
        }

    }


class Program
{   
    static void Main(string[] args)
    {
        PrimeGenerator pg = new PrimeGenerator();

        Stopwatch sw = Stopwatch.StartNew();

        List<long> primes = pg.GetPrimesSequential();

        sw.Stop();

        string time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

        Console.WriteLine(time + " GetPrimesSequential");
        /*
        foreach( long prime in primes)
        {
            Console.Write(prime + ", ");
        }
        */

        Console.WriteLine();

        sw = Stopwatch.StartNew();

        primes = pg.GetPrimesParallel();

        sw.Stop();

         time = String.Format("{0:f3} sec.", sw.Elapsed.TotalSeconds);

        Console.WriteLine(time + " GetPrimesParallel");
        /*
        foreach (long prime in primes)
        {
            Console.Write(prime + ", ");
        }
        */

        Console.WriteLine();


    }
}

