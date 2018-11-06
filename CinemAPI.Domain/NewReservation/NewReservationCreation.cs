using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservetion;
using System;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCreation : INewReservation
    {
        private readonly IReservatioRepository reservationRepo;
        private readonly IProjectionRepository projectionRepo;
        private readonly IRoomRepository roomRepo;

        public NewReservationCreation(IReservatioRepository reservationRepo, IProjectionRepository projectionRepo, IRoomRepository roomRepo)
        {
            this.reservationRepo = reservationRepo;
            this.projectionRepo = projectionRepo;
            this.roomRepo = roomRepo;
        }

        public NewReservationSummery New(IReservationRequest reservationReq)
        {
            string newGuid = Guid.NewGuid().ToString("N");
            IReservation reservation = reservationRepo.GetRestInfo(reservationReq.ProjectionId);

            bool isActive = true;

            IReservationTicket reserv = reservationRepo.Insert(new Reservation(
                reservationReq.ProjectionId, 
                newGuid, 
                reservation.ProjectionStartDate, 
                reservation.MovieName, 
                reservation.CinemaName, 
                reservation.RoomNum, 
                reservationReq.Row, 
                reservationReq.Column, 
                isActive));

            return new NewReservationSummery(true, reserv);
        }
    }
}
