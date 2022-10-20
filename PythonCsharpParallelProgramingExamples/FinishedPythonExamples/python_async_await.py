import asyncio
import datetime
import colorama
import random


async def  main():
   
    t0 = datetime.datetime.now()
    print(colorama.Fore.WHITE + "App started.", flush=True)

    data = asyncio.Queue()

    await asyncio.gather(generate_data(20, data),
                         generate_data(20, data), 
                         process_data(40, data))
    
    dt = datetime.datetime.now() - t0
    print(colorama.Fore.WHITE + f"App exiting, total time: {dt.total_seconds():,.2f} sec.", flush=True)


async def generate_data(num: int, data: asyncio.Queue):
    for idx in range(1, num + 1):
        item = idx*idx
        await data.put((item, datetime.datetime.now()))

        print(colorama.Fore.YELLOW + f" -- generated item {idx}", flush=True)
        await asyncio.sleep(random.random() + .5)


async def process_data(num: int, data: asyncio.Queue):
    processed = 0
    while processed < num:
        item = await data.get()

        processed += 1
        value = item[0]
        t = item[1]
        dt = datetime.datetime.now() - t

        print(colorama.Fore.CYAN +
              f" +++ Processed value {value} after {dt.total_seconds():,.2f} sec.", flush=True)
        await asyncio.sleep(.5)


if __name__ == '__main__':
    asyncio.run(main())





