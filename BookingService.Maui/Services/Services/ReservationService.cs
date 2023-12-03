﻿using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Reservation;
using BookingService.Maui.Model.Reservation;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper mapper;
        private readonly IReservationRepository reservationRepository;

        public ReservationService(IMapper mapper, IReservationRepository reservationRepository)
        {
            this.mapper = mapper;
            this.reservationRepository = reservationRepository;
        }
        public async Task<ResultModel<int?>> AddReservation(Reservation model)
        {
            var addReservationModel = mapper.Map<AddReservationRequest>(model);
            var addReservationResult = await reservationRepository.AddReservation(addReservationModel);

            if (!addReservationResult.Result)
                return new ResultModel<int?>(false, addReservationResult.Message, null);

            return new ResultModel<int?>(true, addReservationResult.Value.Id);
        }
    }
}
