using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If you want to generate sample data, type in 'start' and press enter, if you want to recover database type in 'recover' and press enter");
            var entry = Console.ReadLine();
            if(entry == "start")
            {

                var client1 = new Client(1);
                var client2 = new Client(2);
                var client3 = new Client(3);
                var client4 = new Client(4);
                var client5 = new Client(5);

                var threads = new List<Thread>()
            {
                new Thread(new ThreadStart(() => { client1.PerformTransactions(); })),
                new Thread(new ThreadStart(() => { client2.PerformTransactions(); })),
                new Thread(new ThreadStart(() => { client3.PerformTransactions(); })),
                new Thread(new ThreadStart(() => { client4.PerformTransactions(); })),
                new Thread(new ThreadStart(() => { client5.PerformTransactions(); }))
            };


                foreach (var thread in threads)
                {
                    thread.Start();
                    Thread.Sleep(99);
                }

            }
            else if(entry == "recover")
            {

            }


            Console.ReadLine();
        }

    }
}
