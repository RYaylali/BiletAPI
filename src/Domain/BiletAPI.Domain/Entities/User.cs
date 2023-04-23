using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Domain.Entities
{
	public class User :BaseEntity
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Mail { get; set; }
        public float PhoneNumber { get; set; }
        public string Password { get; set; }
        //BİR KİŞİ BİR SEFERDE YER ALABİLİR
        public Guid ExpeditionID { get; set; }
        public Expedition Expedition { get; set; }
        //bir kişi birden fazla bilet alabilir
        List<Ticket> Tickets { get; set; }
        public User()
        {
            Tickets = new List<Ticket>();
        }
    }
}
