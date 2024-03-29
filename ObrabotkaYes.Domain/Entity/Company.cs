﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Entity
{
    public class Company
    {
        public uint Company_ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string INN { get; set; }
        public string Description { get; set; }
        public byte[]? Avatar { get; set; }
    }
}
