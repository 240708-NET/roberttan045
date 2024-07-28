using System;
using CephalonSimarisApp.Characters;

namespace CephalonSimarisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CephalonSimaris simaris = new CephalonSimaris("Simaris");

            Console.Write("Enter your name, Tenno: ");
            string userName = Console.ReadLine();
            Console.WriteLine(simaris.GreetUser(userName));

            string query;
            do
            {
                Console.Write("\nAsk Simaris about 'knowledge' or 'quest' (or type 'exit' to end): ");
                query = Console.ReadLine();

                if (query.ToLower() != "exit")
                {
                    Console.WriteLine(simaris.RespondToQuery(query));
                }
            } while (query.ToLower() != "exit");

            Console.WriteLine("Goodbye, Tenno.");
        }
    }
}