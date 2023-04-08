using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(10, 20, 30);
            Time time2 = new Time(1, 30, 45);
            Console.WriteLine($"Time 1: {time1.Hours}:{time1.Minutes}:{time1.Seconds}");
            Console.WriteLine($"Time 2: {time2.Hours}:{time2.Minutes}:{time2.Seconds}");

            Time sum = time1 + time2;
            Console.WriteLine($"Time 1 + Time 2: {sum.Hours}:{sum.Minutes}:{sum.Seconds}");

            Time difference = time1 - time2;
            Console.WriteLine($"Time 1 - Time 2: {difference.Hours}:{difference.Minutes}:{difference.Seconds}");

            Time increment = ++time1;
            Console.WriteLine($"Time 1 incremented: {increment.Hours}:{increment.Minutes}:{increment.Seconds}");

            Time decrement = --time1;
            Console.WriteLine($"Time 1 decremented: {decrement.Hours}:{decrement.Minutes}:{decrement.Seconds}");

            if (time1 == time2)
            {
                Console.WriteLine("Time 1 equals Time 2");
            }
            else
            {
                Console.WriteLine("Time 1 does not equal Time 2");
            }

            Console.ReadLine();
        }
    }
}