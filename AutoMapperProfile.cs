using AutoMapper;
using donet_rpg.DTOS.Flight;
using donet_rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, GetFlightDto>();
            CreateMap<AddFlightDto, Flight>();
        }
    }
}
