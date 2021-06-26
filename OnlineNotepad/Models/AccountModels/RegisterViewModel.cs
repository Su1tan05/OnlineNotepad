using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNotepad.Models
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неправильный Email!")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Пароль должен содержать минимум {2} символов.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
