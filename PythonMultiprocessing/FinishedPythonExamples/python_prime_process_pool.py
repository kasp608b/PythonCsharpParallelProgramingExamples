# SuperFastPython.com
# example of a parallel for loop with the Pool class
from multiprocessing import Pool
import time

# execute a task
def task(value):
    if is_prime(value):
        return value
    else:
        return
    
def get_primes_synch():
    primes = []
    for i in range(1000000, 2000000):
        if task(i) != None:
            primes.append(i)
            
    return primes

def get_primes_process():
    
   with Pool() as pool:
       return [x for x in pool.map(task, range(1000000, 2000000)) if x != None]
    
def is_prime(number):

    if number < 2: 
         return False;
    if number % 2 == 0:
         return number == 2  # return False
    i = 3
    while i*i <= number:
         if number % i == 0:
             return False
         i += 2
    return True

# protect the entry point
if __name__ == '__main__':
    
    
    # create all tasks
    start_time = time.time()
    
    #primes = get_primes_synch()
    primes = get_primes_process()       
    duration = time.time() - start_time
    print(f"Done in {duration} seconds")
    print(primes)