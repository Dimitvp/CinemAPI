using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservetion;
using System;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationProjectionValidation : INewReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly INewReservation newReserv;

        public NewReservationProjectionValidation(IProjectionRepository projectionRepo, INewReservation newReserv)
        {
            this.projectionRepo = projectionRepo;
            this.newReserv = newReserv;
        }

        public NewReservationSummery New(IReservationRequest reservation)
        {
            IProjection projection = projectionRepo.GetById(reservation.ProjectionId);
            var now = DateTime.UtcNow;

            if (projection == null)
            {
                return new NewReservationSummery(false, $"Projection with id {reservation.ProjectionId} does not exist");
            }
            var tenMinBeforStart = projection.StartDate.AddMinutes(-10);

            if (projection.StartDate <= now || now > tenMinBeforStart)
            {
                return new NewReservationSummery(false, $"You can not make reservation for projection that is already started or there is less then 10 minutes to start.");
            }

            return newReserv.New(reservation);
        }
    }
}
