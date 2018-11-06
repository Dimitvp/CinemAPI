using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Room;
using CinemAPI.Models.DTOs;
using System.Linq;

namespace CinemAPI.Data.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaDbContext db;

        public RoomRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IRoom GetByCinemaAndNumber(int cinemaId, int number)
        {
            return db.Rooms.FirstOrDefault(x => x.CinemaId == cinemaId &&
                                                x.Number == number);
        }

        public IRoom GetById(int id)
        {
            return db.Rooms.FirstOrDefault(x => x.Id == id);
        }

        public IRoom GetRowsAndSeatsPerRow(long id)
        {
            return db.Projections
                .Where(p => p.Id == id)
                .Select(x => new RoomDTO
                {
                    SeatsPerRow = x.Room.SeatsPerRow,
                    Rows = x.Room.Rows
                })
                .Single();
        }

        public void Insert(IRoomCreation room)
        {
            Room newRoom = new Room(room.Number, room.SeatsPerRow, room.Rows, room.CinemaId);

            db.Rooms.Add(newRoom);
            db.SaveChanges();
        }
    }
}