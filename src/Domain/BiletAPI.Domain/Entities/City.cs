using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Domain.Entities
{
	public class City :BaseEntity
	{
        public string CityName { get; set; }
		List<Expedition> Expeditions { get; set; }
        public City()
        {
            Expeditions = new List<Expedition>();
        }
    }
}
