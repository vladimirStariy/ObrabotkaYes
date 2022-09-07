using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class Profile
    {
        public uint Profile_ID { get; set; }
        public string Login { get; set; }
        public uint User_ID { get; set; }
        public User User { get; set; }
    }
}
