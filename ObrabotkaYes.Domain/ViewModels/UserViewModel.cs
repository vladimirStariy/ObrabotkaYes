using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "№")]
        public uint User_ID { get; set; }
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Роль")]
        public string Role { get; set; }
    }
}
