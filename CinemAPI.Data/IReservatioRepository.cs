using CinemAPI.Models.Contracts.Reservetion;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IReservatioRepository
    {
        IEnumerable<IReservation> GetRowsColsById(long id);

        IReservation GetRestInfo(long id);

        IReservationTicket Insert(IReservationCreation reservation);

        void CancelReservation(IReservationRequest reserv);
    }
}
