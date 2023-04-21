using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Models.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Lütfen Email Giriniz")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
