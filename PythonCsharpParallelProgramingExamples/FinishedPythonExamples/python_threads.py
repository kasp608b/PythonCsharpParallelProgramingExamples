
#Example of Threads in Python
import threading
import time
import colorama
from threading import Thread
import os

def task(id, sleep_time):
    for i in range(10):
        thread_id = threading.currentThread().ident
        process_id = os.getpid()
        print(f"Task {id} is running on thread: {thread_id} and running on process: {process_id}")
        print()
        
        number = 2
        start_time = time.time()

        while True:
            number = number * number
            if (time.time() - start_time) >= sleep_time:
                print(colorama.Fore.RED + f"Task {id} is finished:")
                break;

if __name__ == '__main__':
    task1 = Thread(target=task, args=(1, 3))
    task2 = Thread(target=task, args=(2, 3))
    task3 = Thread(target=task, args=(3, 4))
    task4 = Thread(target=task, args=(4, 5))
    # Total 150 seconds

    start_time = time.time()

    task1.start()
    task2.start()
    task3.start()
    task4.start()

    task1.join()
    task2.join()
    task3.join()
    task4.join()

    duration = time.time() - start_time
    print(f"{duration} seconds")