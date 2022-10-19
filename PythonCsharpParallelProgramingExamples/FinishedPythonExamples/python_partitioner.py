# Example of partitioning in Python
from multiprocessing import Pool
import time
import math


n = 100000000
numbers = []

def add_to_array(i):
    return i

def square(number):
    return math.pow(number, 2)

def sequential_loop():
    for i in range(n):
        numbers[i] = math.pow(i, 2)

# This already partitions the interable due to the defualt behavior of pool.map()
# The defualt chunking is 4 items per process
def parallel_loop():
     with Pool() as pool:
        results = pool.map(square, range(n))
        return results

# This partitions the iterable into chunks with the specified size.
def parallel_loop_with_chunksize():
     with Pool() as pool:
        results = pool.map(square, range(n), 10000)
        return results


if __name__ == '__main__':

    with Pool() as pool:
        numbers = pool.map(add_to_array, range(n))
    

    start_time = time.time()
    
    sequential_loop()
    
    duration = time.time() - start_time

    print(f"{duration} SequentialLoop")

    start_time = time.time()
    
    numbers = parallel_loop()
    
    duration = time.time() - start_time

    print(f"{duration} ParallelLoop")

    start_time = time.time()
    
    numbers = parallel_loop_with_chunksize()
    
    duration = time.time() - start_time

    print(f"{duration} ParallelLoopWithChunkSize")