using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Data
{
    public interface IRoomRepository
    {
        IRoom GetById(int id);

        IRoom GetRowsAndSeatsPerRow(long id);

        IRoom GetByCinemaAndNumber(int cinemaId, int number);

        void Insert(IRoomCreation room);
    }
}