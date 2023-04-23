using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Domain.Entities
{
	public class Expedition :BaseEntity
	{
        public string ExpeditionCode { get; set; }//sefer kodu
        public string PlaceOfDeparture { get; set; }//kalkış yeri
        public string Destination { get; set; }//kalkış yeri
        public double CarFare { get; set; }//bilet ücreti
        public DateTime DepartureTime { get; set; }//Kalkış saati
        //BİR KİŞİ BİRDEN FAZLA SEFERE BAŞKALARI İÇİN BİLET ALABİLİR OLABİLİR
        List<User> Users { get; set; }
        //SEFER BİRDEN FAZLA ŞEHİRE OLABİLİR
        public Guid CityId { get; set; }
        public City City { get; set; }
        //BİR OTOBÜS TEK BİR SEFERE GİDEBİLİR
        public Guid BusID { get; set; }
        public Bus  Bus { get; set; }
        //bir sefer bir biletde yer alabilir
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Expedition()
        {
            Users = new List<User>();
        }
    }
}
