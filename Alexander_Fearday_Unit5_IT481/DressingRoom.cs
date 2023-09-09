using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alexander_Fearday_Unit5_IT481
{
    class DressingRoom
    {
        int rooms;
        Semaphore Semaphore;
        long waitTimer;
        long runTimmer;

        public DressingRoom()
        {
            rooms = 3;
            Semaphore = new Semaphore(rooms, rooms);
        }

        public DressingRoom(int r)
        {
            rooms = r;
            Semaphore = new Semaphore(rooms, rooms);
        }

        public async Task RequestRoom(Customer c)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Customer is waiting.");

            stopwatch.Start();
            Semaphore.WaitOne();
            stopwatch.Stop();
            waitTimer += stopwatch.ElapsedTicks;

            int roomWaitTime = GetRandomNumber(1, 3);
            stopwatch.Start();
            Thread.Sleep(roomWaitTime * c.getNumberOfItems());
            stopwatch.Stop();
            runTimmer += stopwatch.ElapsedTicks;

            Console.WriteLine("Customer finished trying on items in room");
            Semaphore.Release();
        }

        public long getWaitTime()
        {
            return waitTimer;
        }

        public long getRunTime()
        {
            return runTimmer;
        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }

    }
}
