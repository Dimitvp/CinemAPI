using CinemAPI.Models.Contracts.Reservetion;

namespace CinemAPI.Data
{
    public interface IReservatioRepository
    {
        //IReservation Get(long projectionId, string gui, DateTime projectionStartDate, string movieName, string cinemaName, int roomNum, int row, int column);

        IReservation GetRestInfo(long id);

        void Insert(IReservationCreation reservation);
    }
}
