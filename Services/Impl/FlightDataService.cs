using AutoMapper;
using donet_rpg.Data;
using donet_rpg.DTOS.Flight;
using donet_rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace donet_rpg.Services.Impl
{
    public class FlightDataService : IFlightDataService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;


        public FlightDataService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Task<ServiceResponse<List<GetFlightDto>>> AddFlight(AddFlightDto newFlight)
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            var flight = _mapper.Map<Flight>(newFlight);
            _dbContext.Flights.Add(flight);
            _dbContext.SaveChanges();
            serviceResponse.Data = _dbContext.Flights.Select(c => _mapper.Map<GetFlightDto>(c)).ToList();
            return Task.FromResult(serviceResponse);
        }

        public Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            var flight = _dbContext.Flights.First(c => c.Id == Id);
            _dbContext.Flights.Remove(flight);
            _dbContext.SaveChanges();
            serviceResponse.Data = _dbContext.Flights.Select(c => _mapper.Map<GetFlightDto>(c)).ToList();
            return Task.FromResult(serviceResponse);

        }

        public Task<ServiceResponse<List<GetFlightDto>>> GetAllFlights()
        {
            var serviceResponse = new ServiceResponse<List<GetFlightDto>>();
            serviceResponse.Data = _dbContext.Flights.Select(c => _mapper.Map<GetFlightDto>(c)).ToList();
            return Task.FromResult(serviceResponse);
        }

        public Task<ServiceResponse<GetFlightDto>> GetFlightById(int InventoryLegId)
        {
            var serviceResponse = new ServiceResponse<GetFlightDto>();
            serviceResponse.Data = _mapper.Map<GetFlightDto>(_dbContext.Flights.FirstOrDefault(c => c.Id == InventoryLegId));
            return Task.FromResult(serviceResponse);
        }

        public Task<ServiceResponse<GetFlightDto>> UpdateFlight(UpdateFlightDto updatedFlight)
        {
            var serviceResponse = new ServiceResponse<GetFlightDto>();
            var flight = _dbContext.Flights.FirstOrDefault(c => c.Id == updatedFlight.Id);
            flight.ArrivalStation = updatedFlight.ArrivalStation;
            flight.DepartureStation = updatedFlight.DepartureStation;
            flight.DepartureDate = updatedFlight.DepartureDate;
            flight.Price = updatedFlight.Price;
            flight.CurrencyCode = updatedFlight.CurrencyCode;
            _dbContext.Flights.Update(flight);
            _dbContext.SaveChanges();
            serviceResponse.Data = _mapper.Map<GetFlightDto>(flight);
            return Task.FromResult(serviceResponse);

        }
    }
}
