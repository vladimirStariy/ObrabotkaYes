using ObrabotkaYes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class User
    {
        public uint User_ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
