using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class Operation
    {
        public uint Operation_ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; } 

        public virtual ICollection<Company> Companies { get; set; }
    }
}
