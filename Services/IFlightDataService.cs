using donet_rpg.DTOS.Flight;
using donet_rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg.Services
{
    public interface IFlightDataService
    {
        Task<ServiceResponse<List<GetFlightDto>>> GetAllFlights();

        Task<ServiceResponse<GetFlightDto>> GetFlightById(int InventoryLegId);

        Task<ServiceResponse<List<GetFlightDto>>> AddFlight(AddFlightDto newFlight);

        Task<ServiceResponse<GetFlightDto>> UpdateFlight(UpdateFlightDto UpdatedFlight);
        Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight(int InventoryLegId);
    }
}
