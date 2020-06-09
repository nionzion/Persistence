using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class Operation
    {
        public Transaction Transaction { get; set; }
        public string Data { get; set; }

        public int PageId { get; set; }
    }
}
