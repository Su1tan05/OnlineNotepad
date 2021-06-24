using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OnlineNotepad.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }


    }
}
