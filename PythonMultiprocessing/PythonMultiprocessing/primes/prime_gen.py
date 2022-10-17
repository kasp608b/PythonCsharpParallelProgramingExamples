
import math

if __name__ == '__main__':
    print('This is a module to find prime numbers.')

def is_prime(number):
    if number < 2: return False
    if number == 2: return True
    if number % 2 == 0: return False
    for i in range(3, int(math.sqrt(number))+1, 2):
        if number % i == 0: return False
        return True
    

