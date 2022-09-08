using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class OrderPicture
    {
        public uint OrderPicture_ID { get; set; }
        public uint Order_ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
