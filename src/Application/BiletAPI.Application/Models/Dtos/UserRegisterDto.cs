using BiletAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Models.Dtos
{
    public class UserRegisterDto
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage ="Lütfen isminizi giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Lütfen soyisminizi giriniz")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen yaşınızı giriniz")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Lütfen cinsiyetinizi giriniz")]
        public bool Gender { get; set; }
        [Required(ErrorMessage ="Lütfen mail adresinizi giriniz")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="Lütfen telefon numaranızı giriniz")]
        public float PhoneNumber { get; set; }
        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
		public Status Status { get; set; }

	}
}
