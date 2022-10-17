# SuperFastPython.com
# example of a parallel for loop with the Process class
from multiprocessing import Process
import time
from primes import prime_gen


# execute a task
def task(value):
   prime_gen.is_prime(value)
    
# protect the entry point
if __name__ == '__main__':
    # create all tasks
    start_time = time.time()
    
    processes = [Process(target=task, args=(i,)) for i in range(20)]
    # start all processes
    for process in processes:
        process.start()
    # wait for all processes to complete
    for process in processes:
        process.join()
    # report that all tasks are completed
    duration = time.time() - start_time
    print(f"Done in {duration} seconds")
