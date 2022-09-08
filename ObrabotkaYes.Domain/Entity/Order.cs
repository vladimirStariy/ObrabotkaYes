using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class Order
    {
        public uint Order_ID { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public uint Type_ID { get; set; }
        public OrderType OrderType { get; set; }

        public virtual ICollection<OrderPicture> OrderPictures { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
