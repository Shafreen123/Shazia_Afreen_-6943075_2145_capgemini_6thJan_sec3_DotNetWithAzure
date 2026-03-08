using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> ticketQueue = new Queue<string>();
        Stack<string> actionHistory = new Stack<string>();

        ticketQueue.Enqueue("Ticket 1: Login Issue");
        ticketQueue.Enqueue("Ticket 2: Payment Failure");
        ticketQueue.Enqueue("Ticket 3: Account Locked");

      
        Console.WriteLine("Processing Tickets...\n");

        for (int i = 0; i < 3; i++)
        {
            if (ticketQueue.Count > 0)
            {
                string ticket = ticketQueue.Dequeue();
                Console.WriteLine("Processing: " + ticket);

             
                actionHistory.Push("Checked logs for " + ticket);
                actionHistory.Push("Resolved issue for " + ticket);

                Console.WriteLine("Undo Action: " + actionHistory.Pop());
            }
        }

     
        Console.WriteLine("\nRemaining Tickets in Queue:");
        foreach (var ticket in ticketQueue)
            Console.WriteLine(ticket);
    }
}
