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
            Reservation toDelete = await _reservationRepository.GetAsync(id);
            await _reservationRepository.DeleteAsync(toDelete);

            return _mapper.Map<ReservationDto>(toDelete);
        }

        public async Task<ReservationDto> GetReservation(long id)
        {
            Reservation result = await _reservationRepository.GetAsync(id);

            if (result == null)
            {
                throw new Exception("Reservation not found, implement separate exception later");
            }

            return _mapper.Map<ReservationDto>(result);
        }

        public async Task<IEnumerable<ReservationDto>> GetReservations()
        {
            ICollection<Reservation> result = await _reservationRepository.GetAllAsync();

            return _mapper.Map<List<ReservationDto>>(result);
        }

        public async Task<ReservationDto> PostReservation(ReservationDto reservationDto)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationDto);

            Reservation result = await _reservationRepository.AddAsync(reservation);

            return _mapper.Map<ReservationDto>(result);
        }

        public async Task<ReservationDto> PutReservation(long id, ReservationDto reservationDto)
        {
            Reservation toUpdate = await _reservationRepository.GetAsync(id);
            toUpdate.StratTimestamp = reservationDto.StratTimestamp;
            toUpdate.EndTimestamp = reservationDto.EndTimestamp;

            Reservation result = await _reservationRepository.UpdateAsync(toUpdate, toUpdate.Id);

            return _mapper.Map<ReservationDto>(result);
        }
    }
}
