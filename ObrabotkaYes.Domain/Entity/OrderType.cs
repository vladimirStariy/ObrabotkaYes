using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class OrderType
    {
        public uint Type_ID { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
