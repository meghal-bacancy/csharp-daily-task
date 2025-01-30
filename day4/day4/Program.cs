//Write a C# program with two threads. Each thread will try to acquire two locks in reverse order, causing a deadlock. 
//Use Thread.Sleep() to simulate some delay between the lock acquisition. Print a message indicating when the deadlock 
//occurs and how to resolve it.

using System;
using System.Threading;

class Program
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();

    static void Main()
    {
        Thread thread1 = new Thread(Thread1Work);
        Thread thread2 = new Thread(Thread2Work);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    static void Thread1Work()
    {
        lock (lock1)
        {
            Console.WriteLine("Thread 1 acquired lock1");
            Thread.Sleep(1000); // Simulate work

            lock (lock2)
            {
                Console.WriteLine("Thread 1 acquired lock2");
            }
        }
    }

    static void Thread2Work()
    {
        lock (lock2)
        {
            Console.WriteLine("Thread 2 acquired lock2");
            Thread.Sleep(1000); // Simulate work

            lock (lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1");
            }
        }
    }
}