using donet_rpg.DTOS.Flight;
using donet_rpg.Model;
using donet_rpg.Model.FlightServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {


        private readonly IFlightService _flighService;

        public FlightController(IFlightService flighService) {
            _flighService = flighService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> Get()
        {
            return Ok(await _flighService.GetAllFlights());
        }

        [HttpGet("{InventoryLegID}")]
        public async Task<ActionResult<ServiceResponse<GetFlightDto>>> GetSingle(int InventoryLegID)
        {
            return Ok(await _flighService.GetFlightById(InventoryLegID));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> AddFlight (AddFlightDto newFlight)
        {
            return Ok(await _flighService.AddFlight(newFlight));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetFlightDto>>> UpdateFlight(UpdateFlightDto updatedFlight)
        {
            var response = await _flighService.UpdateFlight(updatedFlight);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{InventoryLegID}")]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> Delete(int InventoryLegID)
        {
            var response = await _flighService.DeleteFlight(InventoryLegID);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
