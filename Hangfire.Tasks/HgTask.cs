﻿using System;
using System.Threading;

namespace Hangfire.Tasks
{
    public static class HgTask
    {
        [Queue("critical")]
        public static void PerformSomeLongRunningTask(int bar)
        {
            Console.WriteLine($"Incoming argument(s) {bar}");
            Console.WriteLine("Started Performing Long Running Tasks..");
            Thread.Sleep(10000);
            Console.WriteLine("Completed Performing Long Running Tasks..");
        }
        [Queue("emailqueue")]
        public static void PerformSomeRecurringTask()
        {
            Console.WriteLine("Started Performing Recurring Tasks..");
            //throw new Exception("Something went wrong !!");
            Thread.Sleep(10000);
            Console.WriteLine("Completed Performing Recurring Tasks..");
        }
    }
}
