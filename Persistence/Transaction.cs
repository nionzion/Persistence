using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class Transaction
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;

        public Dictionary<int, Dictionary<int, string>> DataSet = new Dictionary<int, Dictionary<int, string>>();

        public Transaction(int id)
        {
            Id = id;

        }

    }
}
