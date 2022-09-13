using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObrabotkaYes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int Order_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public DateTime PublicationDate { get; set; }
        public uint Type_ID { get; set; }
        public ICollection <uint> Categories { get; set; }
        public IFormFileCollection Uploads { get; set; }
    }
}
