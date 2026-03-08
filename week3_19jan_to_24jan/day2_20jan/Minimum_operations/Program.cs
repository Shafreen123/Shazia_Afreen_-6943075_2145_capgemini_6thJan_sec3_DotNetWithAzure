using System;
using System.Collections.Generic;

namespace MahirlOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Queue<(int value, int steps)> q = new Queue<(int, int)>();
            HashSet<int> visited = new HashSet<int>();

            q.Enqueue((10, 0));
            visited.Add(10);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                int val = current.value;
                int steps = current.steps;

                if (val == N)
                {
                    Console.WriteLine(steps);
                    return;
                }

                int[] nextValues = { val + 2, val - 1, val * 3 };

                foreach (int next in nextValues)
                {
                    if (next >= 0 && next <= 3 * N && !visited.Contains(next))
                    {
                        visited.Add(next);
                        q.Enqueue((next, steps + 1));
                    }
                }
            }
        }
    }
}
