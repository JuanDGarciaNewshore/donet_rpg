using AutoMapper;
using donet_rpg.DTOS.Flight;
using donet_rpg.Model;
using donet_rpg.Model.FlightServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg.Services.Impl
{
    public class FlightService : IFlightService
    {
        private static List<Flight> Flights = new List<Flight>
        {
            new Flight()
                };
        private readonly ILogger<FlightService> _logger;
        private readonly IMapper _mapper;
        private readonly IFlightDataService _flightDataService;
        public FlightService(IMapper mapper, ILogger<FlightService> logger, IFlightDataService flightDataService)
        {
            _mapper = mapper;
            _logger = logger;
            _flightDataService = flightDataService;

        }


        public async Task<ServiceResponse<List<GetFlightDto>>> AddFlight(AddFlightDto newFlight)
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();

            try
            { 
                serviceResponse = await _flightDataService.AddFlight(newFlight);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            try
            {
                serviceResponse = await _flightDataService.DeleteFlight(Id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFlightDto>>> GetAllFlights()
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            try
            {
                serviceResponse = await _flightDataService.GetAllFlights();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetFlightDto>> GetFlightById(int InventoryLegId)
        {
            var serviceResponse = new ServiceResponse<GetFlightDto>();

            try
            {
                serviceResponse = await _flightDataService.GetFlightById(InventoryLegId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetFlightDto>> UpdateFlight(UpdateFlightDto updatedFlight)
        {
            var serviceResponse = new ServiceResponse<GetFlightDto>();
            try
            {
                serviceResponse = await _flightDataService.UpdateFlight(updatedFlight);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return serviceResponse;
        }
    }
}