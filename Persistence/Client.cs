using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Persistence
{
    public class Client
    {
        public int Id { get; set; }
        public Client(int clientId)
        {
            Id = clientId;
        }

        public void PerformTransactions()
        {
            var ta = PersistanceManager.Instance.BeginTransaction();

            for (var i = 0; i < 10; i++)
            {

                for (int j = 0; j < new Random().Next(1, 6); j++)
                {
                    Console.WriteLine($"Client {Id} writes [TransactionId: {ta.Id}]");
                    PersistanceManager.Instance.Write(ta.Id, int.Parse($"{Id}{i}"), $"{Guid.NewGuid()}");
                    Thread.Sleep(250);

                }
            }

            PersistanceManager.Instance.Commit(ta.Id);



        }
    }
}
