using donet_rpg.Model;
using donet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg.DTOS.Flight
{
    public class GetFlightDto
    {


        public string DepartureStation { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime DepartureDate { get; set; }


        public decimal Price { get; set; }

        public string CurrencyCode { get; set; }

        public Transport Transport { get; set; }
    }
}
