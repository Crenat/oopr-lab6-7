using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Бібліотека TPL
        
        // 2. Створення задачі. Запуск задачі, призупинка задачі.
        Task task1 = new Task(() =>
        {
            Console.WriteLine("Task 1 is executing.");
            Thread.Sleep(1000);
            Console.WriteLine("Task 1 is completed.");
        });

        Task task2 = new Task(() =>
        {
            Console.WriteLine("Task 2 is executing.");
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 is completed.");
        });

        task1.Start();
        task2.Start();

        // Wait for tasks to complete
        Task.WaitAll(task1, task2);

        Console.WriteLine();

        // 3. Застосування лямбда-виразу як задачі
        Task task3 = Task.Run(() =>
        {
            Console.WriteLine("Task 3 is executing.");
            Thread.Sleep(1500);
            Console.WriteLine("Task 3 is completed.");
        });

        task3.Wait();

        Console.WriteLine();

        // 4. Клас Parallel
        Parallel.For(0, 5, i =>
        {
            Console.WriteLine($"Parallel For: {i}");
            Thread.Sleep(500);
        });

        Console.WriteLine();

        // 5. Основні можливості PLINQ
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenNumbers = numbers.AsParallel()
                                .Where(n => n % 2 == 0)
                                .ToArray();

        Console.WriteLine("Even numbers using PLINQ:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
