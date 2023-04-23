using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Domain.Entities
{
	public class Bus :BaseEntity
	{
        public string NumberPlate { get; set; } //Plaka numarası
        public int Seat { get; set; } //Oturacak yer 
        public bool Gender { get; set; } // koltuğu alan kişinin cinsiyeti
    }
}
