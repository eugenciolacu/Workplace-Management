using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class ReservationService : IReservationService
    {
        private ILoggerManager _logger;

        private IReservationRepository _reservationRepository;

        private IMapper _mapper;

        public ReservationService(ILoggerManager logger, IReservationRepository reservationRepository, IMapper mapper)
        {
            _logger = logger;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> DeleteReservation(long id)
        {
            return null;
        }

        public async Task<ReservationDto> GetReservation(long id)
        {
            return null;
        }

        public async Task<IEnumerable<ReservationDto>> GetReservations()
        {
            return null;
        }

        public async Task<ReservationDto> PostReservation(ReservationDto reservationDto)
        {
            return null;
        }

        public async Task<ReservationDto> PutReservation(long id, ReservationDto reservationDto)
        {
            return null;
        }
    }
}
