using CinemAPI.Models.Contracts.Reservetion;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IReservatioRepository
    {
        IEnumerable<IReservation> GetRowsColsById(long id);

        IReservation GetRestInfo(long id);

        IReservation Insert(IReservationCreation reservation);

        //void CancelReservation(IReservationRequest reserv);

        IReservation GetReservationByGuid(string guid);
    }
}
