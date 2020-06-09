using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Persistence
{
    public sealed class PersistanceManager
    {
        private static PersistanceManager _instance = null;

        private PersistanceManager()
        {

        }

        public List<Transaction> Transactions = new List<Transaction>();

        public static PersistanceManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersistanceManager();
            
                return _instance;
            }
        }



        public int BufferSize { get; set; } = 5;

        public List<Operation> Buffer = new List<Operation>();

        int lsn = 1;
        int taId = 0;

        public Transaction BeginTransaction()
        {
            taId++;
            Logger.Append($"{lsn};{taId};BOT", "log.txt");
            lsn++;
            var transaction = new Transaction(taId);
            Transactions.Add(transaction);
            return transaction;
        }

        public void Commit(int taId)
        {
            Logger.Append($"{lsn};{taId};EOT", "log.txt");
            Transactions.Where(ta => ta.Id == taId).FirstOrDefault().IsCompleted = true;
            lsn++;
        }

        public void Write(int taId, int pageId, string data)
        {
            Logger.Append($"{lsn};{taId};{pageId};{data}", "log.txt");
            lsn++;

            Buffer.Add(new Operation { Data = data, Transaction = Transactions.First(t => t.Id == taId), PageId = pageId });
            
            if(Buffer.Count > BufferSize)
            {
                var commitedTransactions = Buffer.Where(op => op.Transaction.IsCompleted).ToList();
                foreach(var ta in commitedTransactions)
                {
                    Logger.Write($"{lsn} {data}", $"page_{pageId}.txt");
                    Buffer.Remove(ta); 
                }

            }
        }


    }
}
