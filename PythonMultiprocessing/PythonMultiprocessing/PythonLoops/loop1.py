# SuperFastPython.com
# example of a parallel for loop with the Thread class
from threading import Thread
import time 


# execute a task
def task(value):
    time.sleep(10)
    print(f'.done {value}')

# protect the entry point
if __name__ == '__main__':
    
    start_time = time.time()
   
    # create all tasks
    threads = [Thread(target=task, args=(i,)) for i in range(20)]
    # start all threads
    for thread in threads:
        thread.start()
    # wait for all threads to complete
    for thread in threads:
        thread.join()
    # report that all tasks are completed
    duration = time.time() - start_time
    print(f"Done in {duration} seconds")
