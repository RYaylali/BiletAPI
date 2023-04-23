using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Domain.Entities
{
	public class Ticket:BaseEntity
	{
        public string PNR { get; set; } //BİLET REZERVASYO KODU
        public decimal TotalPrice { get; set; }//Toplam bilet fiyatı
        //biletler bir kişiye ait olabilir
        public Guid? CustomerId { get; set; }
        public Customer?  Customer { get; set; }
        //bir biletde tek sefer olur   
        public Guid? ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }

    }
}
