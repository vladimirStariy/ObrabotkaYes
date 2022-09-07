using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObrabotkaYes.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите ваш логин")]
        [MaxLength(20, ErrorMessage = "Логин может быть менее 20 символов")]
        [MinLength(3, ErrorMessage = "Логин должен иметь более 3 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
